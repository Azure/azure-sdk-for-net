// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The previously shipped CassandraClusterDataCenterNodeItem factory had 17
    // parameters; the regenerated factory adds an 18th parameter `isLatestModel`.
    // Add a back-compat 17-parameter overload that forwards to the generated
    // 18-parameter factory with isLatestModel set to default(bool?).
    public static partial class ArmCosmosDBModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="Models.CassandraClusterDataCenterNodeItem"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static CassandraClusterDataCenterNodeItem CassandraClusterDataCenterNodeItem(string address, CassandraNodeState? state, string status, string cassandraProcessStatus, string load, IEnumerable<string> tokens, int? size, Guid? hostId, string rack, string timestamp, long? diskUsedKB, long? diskFreeKB, long? memoryUsedKB, long? memoryBuffersAndCachedKB, long? memoryFreeKB, long? memoryTotalKB, double? cpuUsage)
        {
            return CassandraClusterDataCenterNodeItem(
                address: address,
                state: state,
                status: status,
                cassandraProcessStatus: cassandraProcessStatus,
                load: load,
                tokens: tokens,
                size: size,
                hostId: hostId,
                rack: rack,
                timestamp: timestamp,
                diskUsedKB: diskUsedKB,
                diskFreeKB: diskFreeKB,
                memoryUsedKB: memoryUsedKB,
                memoryBuffersAndCachedKB: memoryBuffersAndCachedKB,
                memoryFreeKB: memoryFreeKB,
                memoryTotalKB: memoryTotalKB,
                cpuUsage: cpuUsage,
                isLatestModel: default);
        }
    }
}
