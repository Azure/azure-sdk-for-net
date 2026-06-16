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
    [CodeGenSuppress("GeneratevirtualwanvpnserverconfigurationvpnprofileAsync", typeof(WaitUntil), typeof(VirtualWanVpnProfileContent), typeof(CancellationToken))]
    [CodeGenSuppress("Generatevirtualwanvpnserverconfigurationvpnprofile", typeof(WaitUntil), typeof(VirtualWanVpnProfileContent), typeof(CancellationToken))]
    public partial class VirtualWanResource
    {
        public virtual Task<ArmOperation> DownloadVpnSitesConfigurationAsync(WaitUntil waitUntil, GetVpnSitesConfigurationContent content, CancellationToken cancellationToken) => default;
        public virtual ArmOperation DownloadVpnSitesConfiguration(WaitUntil waitUntil, GetVpnSitesConfigurationContent content, CancellationToken cancellationToken) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<VpnProfileResponse>> GenerateVirtualWanVpnServerConfigurationVpnProfileAsync(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<VpnProfileResponse> GenerateVirtualWanVpnServerConfigurationVpnProfile(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken) => default;
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<VpnProfileResponse>> GeneratevirtualwanvpnserverconfigurationvpnprofileAsync(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken = default)
            => GenerateVirtualWanVpnServerConfigurationVpnProfileAsync(waitUntil, content, cancellationToken);
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<VpnProfileResponse> Generatevirtualwanvpnserverconfigurationvpnprofile(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken = default)
            => GenerateVirtualWanVpnServerConfigurationVpnProfile(waitUntil, content, cancellationToken);
        public virtual Task<ArmOperation<VpnServerConfigurationsResponse>> GetVpnServerConfigurationsAssociatedWithVirtualWanAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
        public virtual ArmOperation<VpnServerConfigurationsResponse> GetVpnServerConfigurationsAssociatedWithVirtualWan(WaitUntil waitUntil, CancellationToken cancellationToken) => default;
    }
}
