using System;
using System.Collections.Generic;
using System.Linq;
using Magazine.DAL.Core;
using Magazine.DAL.TestRepositories.TestData;

namespace Magazine.DAL.TestRepositories
{
    internal class TestArticleRepository : IRepository<Article>
    {
        private readonly IList<Article> articles;

        internal TestArticleRepository()
        {
            articles = TestArticles.CloneCurrentSet();
        }

        public Article Create(Article item)
        {
            item.Id = articles.Count;
            articles.Add(item);
            return item;
        }

        public Article FindById(int id)
        {
            return articles.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Article> Get()
        {
            return articles.Select(a => new Article { Id = a.Id, Title = a.Title}).ToList();
        }

        public IEnumerable<Article> Get(Func<Article, bool> predicate)
        {
            return articles.Where(predicate).ToList();
        }

        public void Remove(int id)
        {
            var entity = FindById(id);
            if (entity != null)
                articles.Remove(entity);
        }

        public void Update(Article item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            TestArticles.UpdateCurrentSet(articles);
        }
    }
}
