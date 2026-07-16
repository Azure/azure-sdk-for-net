// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkGatewayResource type. </summary>
    public partial class VirtualNetworkGatewayResource
    {
        /// <summary> Invokes the GenerateVpnClientPackageAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<string>> GenerateVpnClientPackageAsync(WaitUntil waitUntil, VpnClientContent content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GenerateVpnClientPackage compatibility operation. </summary>
        public virtual ArmOperation<string> GenerateVpnClientPackage(WaitUntil waitUntil, VpnClientContent content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GenerateVpnProfileAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `GenerateVpnProfileAsync` with `VpnClientContent` instead.", false)]
        public virtual Task<ArmOperation<string>> GenerateVpnProfileAsync(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GenerateVpnProfile compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `GenerateVpnProfile` with `VpnClientContent` instead.", false)]
        public virtual ArmOperation<string> GenerateVpnProfile(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GeneratevpnclientpackageAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `GeneratevpnclientpackageAsync` with `VpnClientContent` instead.", false)]
        public virtual Task<ArmOperation<string>> GeneratevpnclientpackageAsync(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the Generatevpnclientpackage compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `Generatevpnclientpackage` with `VpnClientContent` instead.", false)]
        public virtual ArmOperation<string> Generatevpnclientpackage(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the StartPacketCaptureAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `StartPacketCaptureAsync` with `VpnPacketCaptureStartContent` instead.", false)]
        public virtual Task<ArmOperation<string>> StartPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStartParameters content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the StartPacketCapture compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `StartPacketCapture` with `VpnPacketCaptureStartContent` instead.", false)]
        public virtual ArmOperation<string> StartPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStartParameters content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the StopPacketCaptureAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `StopPacketCaptureAsync` with `VpnPacketCaptureStopContent` instead.", false)]
        public virtual Task<ArmOperation<string>> StopPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStopParameters content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the StopPacketCapture compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release, please use `StopPacketCapture` with `VpnPacketCaptureStopContent` instead.", false)]
        public virtual ArmOperation<string> StopPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStopParameters content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
