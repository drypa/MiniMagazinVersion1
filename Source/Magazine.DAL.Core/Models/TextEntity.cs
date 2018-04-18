using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Magazine.DAL.Core
{
    [DataContract]
    public abstract class TextEntity : Entity
    {
        [DataMember]
        public DateTime Created { get; set; }

        [DataMember]
        public string Text { get; set; }

        [DataMember]
        public int AuthorId { get; set; }

        [DataMember]
        public virtual Author Author { get; set; }

        protected override void HandleCloned(Entity clone)
        {
            base.HandleCloned(clone);

            var textEntity = (TextEntity)clone;

            if (Author != null)
                textEntity.Author = (Author) Author.Clone();

        }
    }
}
