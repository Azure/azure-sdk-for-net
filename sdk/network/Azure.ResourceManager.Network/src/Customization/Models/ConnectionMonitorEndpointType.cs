// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public readonly partial struct ConnectionMonitorEndpointType
    {
        // client.tsp restores the original .NET casing (Vm/Vmss) on the generated
        // members. Preserve the uppercase spellings introduced by TypeSpec as hidden,
        // obsolete aliases so callers can migrate without a source or binary break.
        // Forward to the generated members rather than duplicating their wire values;
        // the SDK name changes, but AzureVM/AzureArcVM/AzureVMSS on the wire do not.
        /// <summary> AzureArcVM. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This value is deprecated and it will be removed in a future version. Please use AzureArcVm instead.")]
        public static ConnectionMonitorEndpointType AzureArcVM => AzureArcVm;
        /// <summary> AzureVM. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This value is deprecated and it will be removed in a future version. Please use AzureVm instead.")]
        public static ConnectionMonitorEndpointType AzureVM => AzureVm;
        /// <summary> AzureVMSS. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This value is deprecated and it will be removed in a future version. Please use AzureVmss instead.")]
        public static ConnectionMonitorEndpointType AzureVMSS => AzureVmss;

        // These monitor-category values were exposed on this type by the incorrect client name.
        // Keep them available for compatibility, but hide them from endpoint-value completion.
        /// <summary> MultiEndpoint. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConnectionMonitorEndpointType MultiEndpoint { get; } = new ConnectionMonitorEndpointType("MultiEndpoint");
        /// <summary> SingleSourceDestination. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConnectionMonitorEndpointType SingleSourceDestination { get; } = new ConnectionMonitorEndpointType("SingleSourceDestination");
    }
}
