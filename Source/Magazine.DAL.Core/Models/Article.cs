using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Magazine.DAL.Core
{
    [DataContract]
    public class Article : TextEntity
    {
        public Article()
        {
            Comments = new HashSet<Comment>();
        }

        [DataMember]
        public string TizerPath { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}