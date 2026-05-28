// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CoreWCF;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Samples
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract(IsOneWay = true)]
        void SendData(int value);

        [OperationContract(IsOneWay = true)]
        void SendDataUsingDataContract(CompositeType composite);
    }
}
