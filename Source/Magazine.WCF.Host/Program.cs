using System;
using System.Collections.Generic;
using Autofac;
using Autofac.Integration.Wcf;
using Magazine.DAL.Core;
using Magazine.DAL.TestRepositories;
using Magazine.WCF.Service;
using Serilog;

namespace Magazine.WCF.Host
{
    internal class Program
    {
        internal static void Main()
        {
            var serviceTypes = new List<Type> { typeof(AuthorService), typeof(ArticleService), typeof(CommentService) };
            ContainerBuilder builder = GetContainerBuilder(serviceTypes);

            using (var container = builder.Build())
            {
                AutofacHostFactory.Container = container;

                var configServicesHost = container.Resolve<ConfigServiceHosts>();

                configServicesHost.OpenHosts(container, serviceTypes);

                Console.ReadLine();

            }
        }

        private static ContainerBuilder GetContainerBuilder(IEnumerable<Type> serviceTypes)
        {
            var builder = new ContainerBuilder();

            ILogger logger = new LoggerConfiguration()
                        .WriteTo
                        .Console()
                        .CreateLogger();
            builder.RegisterInstance(logger)
                .As<ILogger>()
                .SingleInstance();

            builder.RegisterType<TestDataUnitOfWork>().As<IUnitOfWork>();

            foreach (var type in serviceTypes)
                builder.RegisterType(type);

            builder.RegisterType<ConfigServiceHosts>();

            return builder;
        }

    }
}
