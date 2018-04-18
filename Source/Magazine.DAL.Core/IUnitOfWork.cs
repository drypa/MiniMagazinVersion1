using System;

namespace Magazine.DAL.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Author> AuthorRepository { get; }

        IRepository<Article> ArticalRepository { get; }

        IRepository<Comment> CommentRepository { get; }
        void Save();
    }
}
