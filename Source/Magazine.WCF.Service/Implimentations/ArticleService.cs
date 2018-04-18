using System;
using System.Collections.Generic;
using System.ServiceModel;
using Magazine.DAL.Core;

namespace Magazine.WCF.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> repository;
        public ArticleService(IUnitOfWork unitOfWork)
        {
            repository = unitOfWork.ArticalRepository;
        }

        public void Create(Article item)
        {
            repository.Create(item);
        }

        public Article FindById(int id)
        {
            return repository.FindById(id);
        }

        public IEnumerable<Article> Get()
        {
            return repository.Get();
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }
    }
}
