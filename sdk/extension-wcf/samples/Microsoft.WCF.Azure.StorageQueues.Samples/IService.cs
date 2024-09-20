// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.WCF.Azure.StorageQueues.Samples
{
    [ServiceContract]
    public interface IService : IChannel
    {
        [OperationContract(IsOneWay = true)]
        Task SendDataAsync(int value);

        [OperationContract(IsOneWay = true)]
        Task SendDataUsingDataContractAsync(CompositeType composite);
    }
}