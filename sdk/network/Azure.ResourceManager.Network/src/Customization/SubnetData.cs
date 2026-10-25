// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    public partial class SubnetData
    {
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
