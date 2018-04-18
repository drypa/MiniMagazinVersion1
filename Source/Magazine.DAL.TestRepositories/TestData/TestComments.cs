using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magazine.DAL.Core;

namespace Magazine.DAL.TestRepositories.TestData
{
    internal static class TestComments
    {
        static TestComments()
        {
            var first = new Comment
            {
                Id = 1,
                Text = "It's awesome!",
                Created = new DateTime(2016, 4, 20),
                Author = TestAuthors.CurrentSet.FirstOrDefault(a => a.Id == 2)
            };
            var second = new Comment
            {
                Id = 2,
                Text = "Thank you!",
                Created = new DateTime(2016, 4, 21),
                Author = TestAuthors.CurrentSet.FirstOrDefault(a => a.Id == 1)
            };

            CurrentSet = new List<Comment> { first, second };
        }

        internal static IEnumerable<Comment> CurrentSet { get; private set; }

        internal static IList<Comment> CloneCurrentSet()
        {
            var comments = new List<Comment>();

            foreach (var comment in CurrentSet)
                comments.Add((Comment)comment.Clone());

            return comments;
        }

        internal static void UpdateCurrentSet(IEnumerable<Comment> comments)
        {
            CurrentSet = comments;
        }

    }
}
