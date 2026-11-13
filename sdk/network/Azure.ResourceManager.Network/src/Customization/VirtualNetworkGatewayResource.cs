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
    public partial class VirtualNetworkGatewayResource
    {
        /// <summary> Generates a VPN client profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<string>> GenerateVpnProfileAsync(WaitUntil waitUntil, VpnClientParameters vpnClientParameters, CancellationToken cancellationToken = default)
            => GenerateVpnProfileAsync(waitUntil, (VpnClientContent)vpnClientParameters, cancellationToken);

        /// <summary> Generates a VPN client profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual ArmOperation<string> GenerateVpnProfile(WaitUntil waitUntil, VpnClientParameters vpnClientParameters, CancellationToken cancellationToken = default)
            => GenerateVpnProfile(waitUntil, (VpnClientContent)vpnClientParameters, cancellationToken);

        /// <summary> Generates a VPN client package. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<string>> GeneratevpnclientpackageAsync(WaitUntil waitUntil, VpnClientParameters vpnClientParameters, CancellationToken cancellationToken = default)
            => GenerateVpnClientPackageAsync(waitUntil, vpnClientParameters, cancellationToken);

        /// <summary> Generates a VPN client package. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual ArmOperation<string> Generatevpnclientpackage(WaitUntil waitUntil, VpnClientParameters vpnClientParameters, CancellationToken cancellationToken = default)
            => GenerateVpnClientPackage(waitUntil, vpnClientParameters, cancellationToken);

        /// <summary> Starts packet capture on the virtual network gateway. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<string>> StartPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStartParameters vpnPacketCaptureStartParameters, CancellationToken cancellationToken = default)
            => StartPacketCaptureAsync(waitUntil, (VpnPacketCaptureStartContent)vpnPacketCaptureStartParameters, cancellationToken);

        /// <summary> Starts packet capture on the virtual network gateway. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual ArmOperation<string> StartPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStartParameters vpnPacketCaptureStartParameters, CancellationToken cancellationToken = default)
            => StartPacketCapture(waitUntil, (VpnPacketCaptureStartContent)vpnPacketCaptureStartParameters, cancellationToken);

        /// <summary> Stops packet capture on the virtual network gateway. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<string>> StopPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStopParameters vpnPacketCaptureStopParameters, CancellationToken cancellationToken = default)
            => StopPacketCaptureAsync(waitUntil, (VpnPacketCaptureStopContent)vpnPacketCaptureStopParameters, cancellationToken);

        /// <summary> Stops packet capture on the virtual network gateway. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is obsolete and will be removed in a future release", false)]
        [ForwardsClientCalls]
        public virtual ArmOperation<string> StopPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStopParameters vpnPacketCaptureStopParameters, CancellationToken cancellationToken = default)
            => StopPacketCapture(waitUntil, (VpnPacketCaptureStopContent)vpnPacketCaptureStopParameters, cancellationToken);
    }
}
