using System;
using System.Collections.Generic;
using System.ServiceModel;
using Magazine.DAL.Core;

namespace Magazine.WCF.Service
{
    [ServiceContract]
    public interface ICommentService
    {
        [OperationContract]
        void Create(Comment item);

        [OperationContract]
        Comment FindById(int id);

        [OperationContract]
        IEnumerable<Comment> Get();

        [OperationContract]
        void Remove(int id);
    }
}
