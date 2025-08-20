// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.using System;

namespace Microsoft.Azure.EventHubs.ServiceFabricProcessor
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// 
    /// </summary>
    public interface IFabricPartitionLister
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceFabricServiceName"></param>
        /// <returns></returns>
        Task<int> GetServiceFabricPartitionCount(Uri serviceFabricServiceName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceFabricPartitionId"></param>
        /// <returns></returns>
        Task<int> GetServiceFabricPartitionOrdinal(Guid serviceFabricPartitionId);
    }
}
