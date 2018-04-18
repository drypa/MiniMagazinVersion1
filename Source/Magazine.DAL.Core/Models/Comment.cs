using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Magazine.DAL.Core
{
    [DataContract]
    public class Comment : TextEntity
    {
        [DataMember]
        public int ArticalId { get; set; }
        public virtual Article Article { get; set; }
    }
}
