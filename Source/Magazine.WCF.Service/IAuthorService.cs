using System;
using System.Collections.Generic;
using System.ServiceModel;
using Magazine.DAL.Core;
//using Magazine.DAL.Core;

namespace Magazine.WCF.Service
{
    [ServiceContract]
    public interface IAuthorService
    {
        [OperationContract]
        IEnumerable<Author> Get();

    }
}