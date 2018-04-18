using System;
using System.Collections.Generic;
using System.ServiceModel;
using Magazine.DAL.Core;

namespace Magazine.WCF.Service
{
    [ServiceContract]
    public interface IArticleService
    {
        [OperationContract]
        void Create(Article item);

        [OperationContract]
        Article FindById(int id);

        [OperationContract]
        IEnumerable<Article> Get();

        [OperationContract]
        void Remove(int id);
    }
}
