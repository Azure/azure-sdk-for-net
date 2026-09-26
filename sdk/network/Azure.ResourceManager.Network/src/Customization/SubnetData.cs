// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing the Subnet data model. </summary>
    [CodeGenSuppress("IPAllocations")]
    public partial class SubnetData
    {
        /// <summary> Compatibility member. </summary>
        public IList<WritableSubResource> IPAllocations { get; } = new List<WritableSubResource>();

        /// <summary> Compatibility member. </summary>
        public IReadOnlyList<NetworkIPConfigurationProfile> IPConfigurationProfiles { get; } = new List<NetworkIPConfigurationProfile>();

        /// <summary> Compatibility member. </summary>
        public IReadOnlyList<NetworkIPConfiguration> IPConfigurations => Properties is null ? default : Properties.IPConfigurations;

        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="PrivateEndpointNetworkPolicy"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointNetworkPolicy instead.")]
        public VirtualNetworkPrivateEndpointNetworkPolicy? PrivateEndpointNetworkPolicies
        {
            get => PrivateEndpointNetworkPolicy;
            set => PrivateEndpointNetworkPolicy = value;
        }

        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="PrivateLinkServiceNetworkPolicy"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateLinkServiceNetworkPolicy instead.")]
        public VirtualNetworkPrivateLinkServiceNetworkPolicy? PrivateLinkServiceNetworkPolicies
        {
            get => PrivateLinkServiceNetworkPolicy;
            set => PrivateLinkServiceNetworkPolicy = value;
        }
    }
}
