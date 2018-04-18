using System;
using System.Collections.Generic;
using System.ServiceModel;
using Magazine.DAL.Core;

namespace Magazine.WCF.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> repository;
        public AuthorService(IUnitOfWork unitOfWork)
        {
            repository = unitOfWork.AuthorRepository;
        }

        public IEnumerable<Author> Get()
        {
            return repository.Get();
        }
    }
}
