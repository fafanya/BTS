using System.Collections.Generic;
using System.ServiceModel;
using Kernel.Service;

namespace BTS.Service
{
    [ServiceContract]
    [ServiceKnownType(typeof(TStorage))]
    public interface ITrackingService
    {
        [OperationContract]
        [ServiceKnownType(typeof(TStorage))]
        int Insert(TStorage storage);
        [OperationContract]
        [ServiceKnownType(typeof(TStorage))]
        void Update(TStorage storage);
        [OperationContract]
        [ServiceKnownType(typeof(TStorage))]
        void Delete(TStorage storage);
        [OperationContract]
        [ServiceKnownType(typeof(TStorage))]
        IEnumerable<TStorage> LoadList(TStorage query);
        [OperationContract]
        [ServiceKnownType(typeof(TStorage))]
        TStorage LoadDetails(TStorage query);
    }
}