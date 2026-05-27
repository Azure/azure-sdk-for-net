// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the TypeSpec migration. The current service shape exposes the
    // enum-valued IsWorkloadManagementNetworkEnabled property, but the shipped SDK also had an obsolete
    // bool alias. Removing this alias would break callers compiled against the previous package.
    public partial class NetworkFabricControllerData
    {
        /// <summary> A workload management network is required for all the tenant (workload) traffic. This traffic is only dedicated for Tenant workloads which are required to access internet or any other MSFT/Public endpoints. This is used for the backward compatibility. </summary>
        [Obsolete("This property is obsolete and will be removed in a future version. Use IsWorkloadManagementNetworkEnabled instead.")]
        public bool? IsWorkloadManagementNetwork => IsWorkloadManagementNetworkEnabled?.Equals(global::Azure.ResourceManager.ManagedNetworkFabric.Models.IsWorkloadManagementNetworkEnabled.True);
    }
}
