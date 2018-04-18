using System;
using System.Collections.Generic;
using System.Linq;
using Magazine.DAL.Core;
using Magazine.DAL.TestRepositories.TestData;

namespace Magazine.DAL.TestRepositories
{
    internal class TestCommentRepository : IRepository<Comment>
    {
        private readonly IList<Comment> comments;

        internal TestCommentRepository()
        {
            comments = TestComments.CloneCurrentSet();
        }

        public Comment Create(Comment item)
        {
            item.Id = comments.Count;
            comments.Add(item);
            return item;
        }

        public Comment FindById(int id)
        {
            return comments.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Comment> Get()
        {
            return comments.ToList();
        }

        public IEnumerable<Comment> Get(Func<Comment, bool> predicate)
        {
            return comments.Where(predicate).ToList();
        }

        public void Remove(int id)
        {
            var entity = FindById(id);
            if (entity != null)
                comments.Remove(entity);
        }

        public void Update(Comment item)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            TestComments.UpdateCurrentSet(comments);
        }
    }
}
