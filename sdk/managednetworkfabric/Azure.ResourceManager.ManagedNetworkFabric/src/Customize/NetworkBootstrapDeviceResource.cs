// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ManagedNetworkFabric.Models;

namespace Azure.ResourceManager.ManagedNetworkFabric
{
    public partial class NetworkBootstrapDeviceResource
    {
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkBootstrapDevicePatchContent, CancellationToken) instead.")]
        public virtual Task<ArmOperation<NetworkBootstrapDeviceResource>> UpdateAsync(WaitUntil waitUntil, NetworkBootstrapDevicePatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkBootstrapDevicePatchContent, CancellationToken) instead.");
        }

        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkBootstrapDevicePatchContent, CancellationToken) instead.")]
        public virtual ArmOperation<NetworkBootstrapDeviceResource> Update(WaitUntil waitUntil, NetworkBootstrapDevicePatch patch, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkBootstrapDevicePatchContent, CancellationToken) instead.");
        }
    }
}
