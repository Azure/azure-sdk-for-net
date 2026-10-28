// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Network
{
    public partial class VpnGatewayResource
    {
        /// <summary> Resets the VPN gateway. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<VpnGatewayResource>> ResetAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
            => ResetAsync(waitUntil, ipConfigurationId: default, cancellationToken);

        /// <summary> Resets the VPN gateway. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual ArmOperation<VpnGatewayResource> Reset(WaitUntil waitUntil, CancellationToken cancellationToken)
            => Reset(waitUntil, ipConfigurationId: default, cancellationToken);
    }
}
