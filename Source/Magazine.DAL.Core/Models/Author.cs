using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Magazine.DAL.Core
{
    [DataContract]
    public sealed class Author : Entity
    {
        public Author()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
        }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
