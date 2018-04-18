using System;
using System.Collections.Generic;
using System.Linq;
using Magazine.DAL.Core;
using Magazine.DAL.TestRepositories.TestData;

namespace Magazine.DAL.TestRepositories
{
    internal class TestAuthorRepository : IRepository<Author>
    {
        private readonly IList<Author> authors;

        internal TestAuthorRepository()
        {
            authors = TestAuthors.CloneCurrentSet();
        }

        public Author Create(Author item)
        {
            item.Id = authors.Count;
            authors.Add(item);
            return item;
        }

        public Author FindById(int id)
        {
            return authors.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Author> Get()
        {
            return authors.ToList();
        }

        public IEnumerable<Author> Get(Func<Author, bool> predicate)
        {
            return authors.Where(predicate).ToList();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Author item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            TestAuthors.UpdateCurrentSet(authors);
        }
    }
}
