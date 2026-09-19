// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Network
{
    public partial class ManagementGroupNetworkManagerConnectionCollection
    {
        /// <summary> Creates or updates a network manager connection using the former subscription-specific data type. </summary>
        public virtual Task<ArmOperation<ManagementGroupNetworkManagerConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string networkManagerConnectionName, SubscriptionNetworkManagerConnectionData data, CancellationToken cancellationToken = default)
            => CreateOrUpdateAsync(waitUntil, networkManagerConnectionName, data?.ToNetworkManagerConnectionData(), cancellationToken);

        /// <summary> Creates or updates a network manager connection using the former subscription-specific data type. </summary>
        public virtual ArmOperation<ManagementGroupNetworkManagerConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string networkManagerConnectionName, SubscriptionNetworkManagerConnectionData data, CancellationToken cancellationToken = default)
            => CreateOrUpdate(waitUntil, networkManagerConnectionName, data?.ToNetworkManagerConnectionData(), cancellationToken);
    }
}
