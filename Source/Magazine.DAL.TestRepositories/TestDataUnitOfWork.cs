using System;
using Magazine.DAL.Core;

namespace Magazine.DAL.TestRepositories
{
    public class TestDataUnitOfWork : IUnitOfWork
    {
        private readonly TestAuthorRepository authorRepository = new TestAuthorRepository();
        private readonly TestArticleRepository articalRepository = new TestArticleRepository();
        private readonly TestCommentRepository commentRepository = new TestCommentRepository();

        public IRepository<Author> AuthorRepository => authorRepository;
        public IRepository<Article> ArticalRepository => articalRepository;
        public IRepository<Comment> CommentRepository => commentRepository;

        public void Dispose()
        {
        }

        public void Save()
        {
            authorRepository.Save();
            articalRepository.Save();
            commentRepository.Save();
        }
    }
}
