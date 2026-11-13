// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class VirtualWanResource
    {
        /// <summary> Generates a VPN profile for a virtual WAN. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<VpnProfileResponse>> GeneratevirtualwanvpnserverconfigurationvpnprofileAsync(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken = default)
            => GenerateVirtualWanVpnServerConfigurationVpnProfileAsync(waitUntil, content, cancellationToken);

        /// <summary> Generates a VPN profile for a virtual WAN. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual ArmOperation<VpnProfileResponse> Generatevirtualwanvpnserverconfigurationvpnprofile(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken = default)
            => GenerateVirtualWanVpnServerConfigurationVpnProfile(waitUntil, content, cancellationToken);
    }
}
