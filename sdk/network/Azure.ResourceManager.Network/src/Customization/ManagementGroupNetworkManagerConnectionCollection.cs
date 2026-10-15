// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Network
{
    public partial class ManagementGroupNetworkManagerConnectionCollection
    {
        // Restores the mistakenly exposed GA subscription-specific overload solely to mitigate breaking changes and delegates
        // to the canonical generated overload accepting NetworkManagerConnectionData.
        /// <summary> Creates or updates a management group network manager connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete and will be removed in a future release. Use CreateOrUpdateAsync with NetworkManagerConnectionData instead.")]
        public virtual Task<ArmOperation<ManagementGroupNetworkManagerConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkManagerConnectionName, SubscriptionNetworkManagerConnectionData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, networkManagerConnectionName, data?.ToNetworkManagerConnectionData(), cancellationToken);

        // Restores the mistakenly exposed GA subscription-specific overload solely to mitigate breaking changes and delegates
        // to the canonical generated overload accepting NetworkManagerConnectionData.
        /// <summary> Creates or updates a management group network manager connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is obsolete and will be removed in a future release. Use CreateOrUpdate with NetworkManagerConnectionData instead.")]
        public virtual ArmOperation<ManagementGroupNetworkManagerConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string networkManagerConnectionName, SubscriptionNetworkManagerConnectionData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, networkManagerConnectionName, data?.ToNetworkManagerConnectionData(), cancellationToken);
    }
}
