using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Magazine.DAL.Core;

namespace Magazine.DAL.TestRepositories.TestData
{
    internal static class TestArticles
    {
        static TestArticles()
        {

            var first = new Article
            {
                Id = 1,
                Title = "Декоративные элементы в WPF (Adorner)",
                Text = "Создание окна оповещений для проекта IDS HS и другие возможности декорирования контролов с помощью Adorner.",
                Created = new DateTime(2016, 4, 17),
                Author = TestAuthors.CurrentSet.FirstOrDefault(a => a.Id == 1)
            };

            foreach (Comment comment in TestComments.CurrentSet)
            {
                comment.ArticalId = first.Id;
                first.Comments.Add(comment);
            }

            var second = new Article
            {
                Id = 2,
                Title = "Akka.NET или еще один способ сломать себе мозг",
                Text = "Вводный рассказ про Akka.NET и акторную модель.",
                Created = new DateTime(2016, 12, 1),
                Author = TestAuthors.CurrentSet.FirstOrDefault(a => a.Id == 2)
            };

            CurrentSet = new List<Article>
            {
                first,
                second
            };
        }

        internal static IEnumerable<Article> CurrentSet { get; private set; }

        internal static IList<Article> CloneCurrentSet()
        {
            var articles = new List<Article>();

            foreach (var article in CurrentSet)
                articles.Add((Article)article.Clone());

            return articles;
        }

        internal static void UpdateCurrentSet(IEnumerable<Article> articles)
        {
            CurrentSet = articles;
        }
    }
}
