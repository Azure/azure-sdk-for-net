// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Network
{
    public partial class ManagementGroupNetworkManagerConnectionResource
    {
        /// <summary> Updates the connection using the former subscription-specific data type. </summary>
        public virtual Task<ArmOperation<ManagementGroupNetworkManagerConnectionResource>> UpdateAsync(WaitUntil waitUntil, SubscriptionNetworkManagerConnectionData data, CancellationToken cancellationToken = default)
            => UpdateAsync(waitUntil, data?.ToNetworkManagerConnectionData(), cancellationToken);

        /// <summary> Updates the connection using the former subscription-specific data type. </summary>
        public virtual ArmOperation<ManagementGroupNetworkManagerConnectionResource> Update(WaitUntil waitUntil, SubscriptionNetworkManagerConnectionData data, CancellationToken cancellationToken = default)
            => Update(waitUntil, data?.ToNetworkManagerConnectionData(), cancellationToken);
    }
}
