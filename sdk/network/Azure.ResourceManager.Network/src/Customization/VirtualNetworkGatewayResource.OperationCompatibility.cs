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
        public virtual Task<ArmOperation<string>> GenerateVpnClientPackageAsync(WaitUntil waitUntil, VpnClientContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GenerateVpnClientPackage compatibility operation. </summary>
        public virtual ArmOperation<string> GenerateVpnClientPackage(WaitUntil waitUntil, VpnClientContent content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GenerateVpnProfileAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<string>> GenerateVpnProfileAsync(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GenerateVpnProfile compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<string> GenerateVpnProfile(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GeneratevpnclientpackageAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<string>> GeneratevpnclientpackageAsync(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the Generatevpnclientpackage compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<string> Generatevpnclientpackage(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVpnclientIPsecParametersAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<VpnClientIPsecParameters>> GetVpnclientIPsecParametersAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the GetVpnclientIPsecParameters compatibility operation. </summary>
        public virtual ArmOperation<VpnClientIPsecParameters> GetVpnclientIPsecParameters(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the SetVpnclientIPsecParametersAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<VpnClientIPsecParameters>> SetVpnclientIPsecParametersAsync(WaitUntil waitUntil, VpnClientIPsecParameters content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the SetVpnclientIPsecParameters compatibility operation. </summary>
        public virtual ArmOperation<VpnClientIPsecParameters> SetVpnclientIPsecParameters(WaitUntil waitUntil, VpnClientIPsecParameters content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the StartPacketCaptureAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<string>> StartPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStartParameters content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the StartPacketCapture compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<string> StartPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStartParameters content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the StopPacketCaptureAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<string>> StopPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStopParameters content, CancellationToken cancellationToken) => default;
        /// <summary> Invokes the StopPacketCapture compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<string> StopPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStopParameters content, CancellationToken cancellationToken) => default;
    }
}
