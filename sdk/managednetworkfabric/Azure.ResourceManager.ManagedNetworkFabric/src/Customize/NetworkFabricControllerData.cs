// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    // Backward compatibility shim for the swagger upgrade from package-2023-06-15 to package-2025-07-15.
    // The new API version changed the IsWorkloadManagementNetwork property type from bool? to
    // an enum (IsWorkloadManagementNetworkEnabled). This shim preserves the v1.1.2 bool? property
    // by converting the enum value.
    public partial class NetworkFabricControllerData
    {
        /// <summary> A workload management network is required for all the tenant (workload) traffic. This traffic is only dedicated for Tenant workloads which are required to access internet or any other MSFT/Public endpoints. This is used for the backward compatibility. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future version. Use IsWorkloadManagementNetworkEnabled instead.")]
        public bool? IsWorkloadManagementNetwork
        {
            get
            {
                if (IsWorkloadManagementNetworkEnabled == null)
                    return null;
                if (IsWorkloadManagementNetworkEnabled == Models.IsWorkloadManagementNetworkEnabled.True)
                    return true;
                if (IsWorkloadManagementNetworkEnabled == Models.IsWorkloadManagementNetworkEnabled.False)
                    return false;
                return null;
            }
        }
    }
}
