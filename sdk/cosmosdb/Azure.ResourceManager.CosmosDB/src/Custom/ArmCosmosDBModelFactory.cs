// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The generator emits a backward-compatible CassandraClusterDataCenterNodeItem
    // factory overload that takes Guid? hostId, but the model's hostId property is
    // typed as string. The auto-generated body passes the Guid? straight to the
    // string-typed constructor and fails to compile (CS1503). Suppress the broken
    // overload via [CodeGenSuppress] and re-declare it here with an explicit
    // hostId.ToString() conversion so the public surface preserves the historical
    // Guid? signature.
    [CodeGenSuppress(
        "CassandraClusterDataCenterNodeItem",
        typeof(string),
        typeof(CassandraNodeState?),
        typeof(string),
        typeof(string),
        typeof(string),
        typeof(IEnumerable<string>),
        typeof(int?),
        typeof(Guid?),
        typeof(string),
        typeof(string),
        typeof(long?),
        typeof(long?),
        typeof(long?),
        typeof(long?),
        typeof(long?),
        typeof(long?),
        typeof(double?))]
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
                hostId: hostId?.ToString(),
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
