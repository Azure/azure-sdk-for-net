// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs.Tests.ServiceFabricProcessor
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Azure.EventHubs.ServiceFabricProcessor;
    using Xunit;

    class MockPartitionLister : IFabricPartitionLister
    {
        private readonly int partitionCount;
        private readonly int partitionOrdinal;

        public MockPartitionLister(int count, int ordinal)
        {
            Assert.True(count > 0, $"Count must be at least 1, not {count}");
            Assert.True(ordinal >= 0, $"Ordinal must be at least 0, not {ordinal}");
            Assert.True(ordinal < count, $"Ordinal {ordinal} too large for count {count}");
            this.partitionCount = count;
            this.partitionOrdinal = ordinal;
        }

        public Task<int> GetServiceFabricPartitionCount(Uri serviceFabricServiceName)
        {
            return Task.FromResult<int>(this.partitionCount);
        }

        public Task<int> GetServiceFabricPartitionOrdinal(Guid serviceFabricPartitionId)
        {
            return Task.FromResult<int>(this.partitionOrdinal);
        }
    }
}
