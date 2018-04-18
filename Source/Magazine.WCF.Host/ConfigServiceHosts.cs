using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using Autofac;
using Autofac.Integration.Wcf;
using Serilog;

namespace Magazine.WCF.Host
{
    public class ConfigServiceHosts : IDisposable
    {
        private const string CONFIG_SECTION_SERVICE_PATH = "system.serviceModel/services";

        private readonly ILogger logger;
        private readonly IList<ServiceHost> hosts = new List<ServiceHost>();
        private bool disposed = false;

        public ConfigServiceHosts(ILogger logger)
        {
            this.logger = logger;
        }

        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            foreach (ServiceHost host in hosts)
            {
                if (host.State == CommunicationState.Opening)
                {
                    host.Close();
                }
                ((IDisposable)host).Dispose();
            }

            disposed = true;
        }

        internal void OpenHosts(IContainer container, IEnumerable<Type> serviceTypes)
        {
            var services = ConfigurationManager.GetSection(CONFIG_SECTION_SERVICE_PATH) as ServicesSection;

            foreach (ServiceElement service in services.Services)
            {
                Type serviceType = serviceTypes.SingleOrDefault(t => t.FullName == service.Name);
                if (serviceType == null)
                {
                    logger.Warning($"Service {service.Name} couldn't been loaded because the appropriate type was not loaded in this assembly.");
                    continue;
                }

                OpenHost(service, serviceType, container);
            }
        }

        private void OpenHost(ServiceElement service, Type serviceType, IContainer container)
        {
            try
            {
                ServiceHost serviceHost = new ServiceHost(serviceType);
                hosts.Add(serviceHost);
                serviceHost.AddDependencyInjectionBehavior(serviceType, container);
                serviceHost.Open();

                logger.Information($"Service {serviceType} is live now at: {string.Join(", ", serviceHost.BaseAddresses)}");
            }
            catch (Exception ex)
            {
                logger.Error($"Service {service.Name} couldn't been loaded. {ex.Message}");
            }
        }

    }
}
