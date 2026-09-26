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
    /// <summary> A class representing the VirtualNetwork data model. </summary>
    [CodeGenSuppress("IPAllocations")]
    public partial class VirtualNetworkData
    {
        /// <summary> Compatibility member. </summary>
        public IList<string> AddressPrefixes
        {
            get
            {
                AddressSpace ??= new VirtualNetworkAddressSpace();
                return AddressSpace.AddressPrefixes;
            }
        }

        /// <summary> Compatibility member. </summary>
        public IList<WritableSubResource> IPAllocations { get; } = new List<WritableSubResource>();

        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="PrivateEndpointVnetPolicy"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use PrivateEndpointVnetPolicy instead.")]
        public PrivateEndpointVnetPolicy? PrivateEndpointVNetPolicies
        {
            get => PrivateEndpointVnetPolicy;
            set => PrivateEndpointVnetPolicy = value;
        }
    }
}
