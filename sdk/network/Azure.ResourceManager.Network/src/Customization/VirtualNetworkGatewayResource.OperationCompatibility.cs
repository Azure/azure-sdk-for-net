// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0612, CS0618, CS1591

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
    public partial class VirtualNetworkGatewayResource
    {
        public virtual Task<ArmOperation<string>> GenerateVpnClientPackageAsync(WaitUntil waitUntil, VpnClientContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> GenerateVpnClientPackage(WaitUntil waitUntil, VpnClientContent content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<string>> GenerateVpnProfileAsync(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> GenerateVpnProfile(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<string>> GeneratevpnclientpackageAsync(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> Generatevpnclientpackage(WaitUntil waitUntil, VpnClientParameters content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<VpnClientIPsecParameters>> GetVpnclientIPsecParametersAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<VpnClientIPsecParameters> GetVpnclientIPsecParameters(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<VpnClientIPsecParameters>> SetVpnclientIPsecParametersAsync(WaitUntil waitUntil, VpnClientIPsecParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<VpnClientIPsecParameters> SetVpnclientIPsecParameters(WaitUntil waitUntil, VpnClientIPsecParameters content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<string>> StartPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStartParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> StartPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStartParameters content, CancellationToken cancellationToken) => default;
        public virtual Task<ArmOperation<string>> StopPacketCaptureAsync(WaitUntil waitUntil, VpnPacketCaptureStopParameters content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<string> StopPacketCapture(WaitUntil waitUntil, VpnPacketCaptureStopParameters content, CancellationToken cancellationToken) => default;
    }
}
