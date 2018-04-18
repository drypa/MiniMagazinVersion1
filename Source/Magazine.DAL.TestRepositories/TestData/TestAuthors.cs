using System;
using System.Collections.Generic;
using System.Text;
using Magazine.DAL.Core;

namespace Magazine.DAL.TestRepositories.TestData
{
    internal static class TestAuthors
    {

        static TestAuthors()
        {
            var first = new Author { Id = 1, FirstName = "Vitaly", LastName = "Lapin" };
            var second = new Author { Id = 2, FirstName = "Iskander", LastName = "Yarmukhametov" };
            CurrentSet = new List<Author>
            {
                first,
                second
            };
        }
        internal static IEnumerable<Author> CurrentSet { get; private set; }

        internal static IList<Author> CloneCurrentSet()
        {
            var authors = new List<Author>();

            foreach (var article in CurrentSet)
                authors.Add((Author)article.Clone());

            return authors;
        }

        internal static void UpdateCurrentSet(IEnumerable<Author> authors)
        {
            CurrentSet = authors;
        }

    }
}
