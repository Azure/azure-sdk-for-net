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
    /// <summary> Compatibility declaration for the NetworkManagerResource type. </summary>
    [CodeGenSuppress("GetActiveConnectivityConfigurationsAsync", typeof(ActiveConfigurationContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetActiveConnectivityConfigurations", typeof(ActiveConfigurationContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetActiveSecurityAdminRulesAsync", typeof(ActiveConfigurationContent), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetActiveSecurityAdminRules", typeof(ActiveConfigurationContent), typeof(int?), typeof(CancellationToken))]
    public partial class NetworkManagerResource
    {
        /// <summary> Invokes the GetActiveConnectivityConfigurationsAsync compatibility operation. </summary>
        public virtual AsyncPageable<ActiveConnectivityConfiguration> GetActiveConnectivityConfigurationsAsync(ActiveConfigurationContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        /// <summary> Invokes the GetActiveConnectivityConfigurations compatibility operation. </summary>
        public virtual Pageable<ActiveConnectivityConfiguration> GetActiveConnectivityConfigurations(ActiveConfigurationContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        /// <summary> Invokes the GetActiveSecurityAdminRulesAsync compatibility operation. </summary>
        public virtual AsyncPageable<ActiveBaseSecurityAdminRule> GetActiveSecurityAdminRulesAsync(ActiveConfigurationContent content, int? top = default, CancellationToken cancellationToken = default) => default;
        /// <summary> Invokes the GetActiveSecurityAdminRules compatibility operation. </summary>
        public virtual Pageable<ActiveBaseSecurityAdminRule> GetActiveSecurityAdminRules(ActiveConfigurationContent content, int? top = default, CancellationToken cancellationToken = default) => default;
    }
}
