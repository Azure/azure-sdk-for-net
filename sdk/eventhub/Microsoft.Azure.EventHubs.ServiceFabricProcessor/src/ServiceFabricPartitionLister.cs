// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.using System;

namespace Microsoft.Azure.EventHubs.ServiceFabricProcessor
{
    using System;
    using System.Fabric;
    using System.Fabric.Query;
    using System.Threading.Tasks;

    class ServiceFabricPartitionLister : IFabricPartitionLister
    {
        private ServicePartitionList partitionList = null;

        public async Task<int> GetServiceFabricPartitionCount(Uri serviceFabricServiceName)
        {
            using (FabricClient fabricClient = new FabricClient())
            {
                this.partitionList = await fabricClient.QueryManager.GetPartitionListAsync(serviceFabricServiceName);
            }
            return this.partitionList.Count;
        }

        public Task<int> GetServiceFabricPartitionOrdinal(Guid serviceFabricPartitionId)
        {
            int ordinal = -1;
            for (int a = 0; a < partitionList.Count; a++)
            {
                if (this.partitionList[a].PartitionInformation.Id == serviceFabricPartitionId)
                {
                    ordinal = a;
                    break;
                }
            }
            return Task.FromResult<int>(ordinal);
        }
    }
}
