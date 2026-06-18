// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the VirtualNetworkResource type. </summary>
    [CodeGenSuppress("GetNetworkManagerEffectiveConnectivityConfigurationsAsync", typeof(NetworkManagementQueryContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkManagerEffectiveConnectivityConfigurations", typeof(NetworkManagementQueryContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkManagerEffectiveSecurityAdminRulesAsync", typeof(NetworkManagementQueryContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetNetworkManagerEffectiveSecurityAdminRules", typeof(NetworkManagementQueryContent), typeof(int?), typeof(CancellationToken))]
    public partial class VirtualNetworkResource
    {
        /// <summary> Invokes the GetNetworkManagerEffectiveConnectivityConfigurationsAsync compatibility operation. </summary>
        public virtual AsyncPageable<EffectiveConnectivityConfiguration> GetNetworkManagerEffectiveConnectivityConfigurationsAsync(NetworkManagementQueryContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        /// <summary> Invokes the GetNetworkManagerEffectiveConnectivityConfigurations compatibility operation. </summary>
        public virtual Pageable<EffectiveConnectivityConfiguration> GetNetworkManagerEffectiveConnectivityConfigurations(NetworkManagementQueryContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        /// <summary> Invokes the GetNetworkManagerEffectiveSecurityAdminRulesAsync compatibility operation. </summary>
        public virtual AsyncPageable<EffectiveBaseSecurityAdminRule> GetNetworkManagerEffectiveSecurityAdminRulesAsync(NetworkManagementQueryContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        /// <summary> Invokes the GetNetworkManagerEffectiveSecurityAdminRules compatibility operation. </summary>
        public virtual Pageable<EffectiveBaseSecurityAdminRule> GetNetworkManagerEffectiveSecurityAdminRules(NetworkManagementQueryContent content, int? top = default, CancellationToken cancellationToken = default) => default;
    }
}
