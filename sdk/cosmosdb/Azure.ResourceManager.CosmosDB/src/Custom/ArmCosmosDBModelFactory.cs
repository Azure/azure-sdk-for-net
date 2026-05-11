// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.CosmosDB.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The previously shipped CassandraClusterDataCenterNodeItem factory had 17
    // parameters; the regenerated factory adds an 18th parameter `isLatestModel`.
    // Add a back-compat 17-parameter overload that forwards to the generated
    // 18-parameter factory with isLatestModel set to default(bool?).
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

        // Back-compat factory for CosmosDBFleetData. The previous AutoRest contract
        // exposed `provisioningState` directly as a constructor argument; the MPG
        // generator wraps it inside FleetResourceProperties and only emits an
        // internal constructor — so the historical public factory is missing.
        // Re-introduce it here, projecting provisioningState through the inner
        // FleetResourceProperties holder.
        /// <summary> Initializes a new instance of <see cref="CosmosDBFleetData"/>. </summary>
        public static CosmosDBFleetData CosmosDBFleetData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, Azure.ResourceManager.Models.SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, CosmosDBStatus? provisioningState = null)
        {
            tags ??= new Dictionary<string, string>();
            return new CosmosDBFleetData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                properties: new FleetResourceProperties { ProvisioningState = provisioningState });
        }
    }
}
