using System;
using System.Runtime.Serialization;

namespace Magazine.DAL.Core
{
    [DataContract]
    public class Entity : ICloneable
    {
        [DataMember]
        public int Id { get; set; }

        public object Clone()
        {
            var clone = (Entity)MemberwiseClone();
            HandleCloned(clone);
            return clone;
        }

        protected virtual void HandleCloned(Entity clone) { }

    }
}
