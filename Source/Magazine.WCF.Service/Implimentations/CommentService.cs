using System;
using System.Collections.Generic;
using Magazine.DAL.Core;

namespace Magazine.WCF.Service
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> repository;
        public CommentService(IUnitOfWork unitOfWork)
        {
            repository = unitOfWork.CommentRepository;
        }

        public void Create(Comment item)
        {
            repository.Create(item);
        }

        public Comment FindById(int id)
        {
            return repository.FindById(id);
        }

        public IEnumerable<Comment> Get()
        {
            return repository.Get();
        }

        public void Remove(int id)
        {
            repository.Remove(id);
        }
    }
}
