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
    /// <summary> Compatibility declaration for the VirtualWanResource type. </summary>
    [CodeGenSuppress("GeneratevirtualwanvpnserverconfigurationvpnprofileAsync", typeof(WaitUntil), typeof(VirtualWanVpnProfileContent), typeof(CancellationToken))]
    [CodeGenSuppress("Generatevirtualwanvpnserverconfigurationvpnprofile", typeof(WaitUntil), typeof(VirtualWanVpnProfileContent), typeof(CancellationToken))]
    public partial class VirtualWanResource
    {
        /// <summary> Invokes the DownloadVpnSitesConfigurationAsync compatibility operation. </summary>
        public virtual Task<ArmOperation> DownloadVpnSitesConfigurationAsync(WaitUntil waitUntil, GetVpnSitesConfigurationContent content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the DownloadVpnSitesConfiguration compatibility operation. </summary>
        public virtual ArmOperation DownloadVpnSitesConfiguration(WaitUntil waitUntil, GetVpnSitesConfigurationContent content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GenerateVirtualWanVpnServerConfigurationVpnProfileAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<VpnProfileResponse>> GenerateVirtualWanVpnServerConfigurationVpnProfileAsync(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GenerateVirtualWanVpnServerConfigurationVpnProfile compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<VpnProfileResponse> GenerateVirtualWanVpnServerConfigurationVpnProfile(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GeneratevirtualwanvpnserverconfigurationvpnprofileAsync compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual Task<ArmOperation<VpnProfileResponse>> GeneratevirtualwanvpnserverconfigurationvpnprofileAsync(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken = default)
            => GenerateVirtualWanVpnServerConfigurationVpnProfileAsync(waitUntil, content, cancellationToken);
        /// <summary> Invokes the Generatevirtualwanvpnserverconfigurationvpnprofile compatibility operation. </summary>
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release", false)]
        public virtual ArmOperation<VpnProfileResponse> Generatevirtualwanvpnserverconfigurationvpnprofile(WaitUntil waitUntil, VirtualWanVpnProfileContent content, CancellationToken cancellationToken = default)
            => GenerateVirtualWanVpnServerConfigurationVpnProfile(waitUntil, content, cancellationToken);
        /// <summary> Invokes the GetVpnServerConfigurationsAssociatedWithVirtualWanAsync compatibility operation. </summary>
        public virtual Task<ArmOperation<VpnServerConfigurationsResponse>> GetVpnServerConfigurationsAssociatedWithVirtualWanAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
        /// <summary> Invokes the GetVpnServerConfigurationsAssociatedWithVirtualWan compatibility operation. </summary>
        public virtual ArmOperation<VpnServerConfigurationsResponse> GetVpnServerConfigurationsAssociatedWithVirtualWan(WaitUntil waitUntil, CancellationToken cancellationToken) => throw new global::System.NotSupportedException("This compatibility method is not supported by the TypeSpec-generated Network SDK.");
    }
}
