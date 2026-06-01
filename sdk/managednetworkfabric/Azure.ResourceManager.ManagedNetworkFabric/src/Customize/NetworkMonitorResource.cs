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
    public partial class NetworkMonitorResource
    {
        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use UpdateAsync(WaitUntil, NetworkMonitorPatchContent, CancellationToken) instead.")]
        public virtual Task<ArmOperation<NetworkMonitorResource>> UpdateAsync(WaitUntil waitUntil, NetworkMonitorPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));
            return UpdateAsync(waitUntil, patch.ToContent(), cancellationToken);
        }

        /// <summary> Backward-compatible update overload accepting the shipped patch type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This compatibility method is obsolete and will be removed in a future version. Use Update(WaitUntil, NetworkMonitorPatchContent, CancellationToken) instead.")]
        public virtual ArmOperation<NetworkMonitorResource> Update(WaitUntil waitUntil, NetworkMonitorPatch patch, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(patch, nameof(patch));
            return Update(waitUntil, patch.ToContent(), cancellationToken);
        }
    }
}
