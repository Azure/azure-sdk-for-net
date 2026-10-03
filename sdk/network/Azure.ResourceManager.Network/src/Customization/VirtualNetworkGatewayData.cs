// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> A class representing the VirtualNetworkGateway data model. </summary>
    public partial class VirtualNetworkGatewayData
    {
        // Preserve the flattened API because the address-space model now has multiple properties and is no longer flattened.
        /// <summary> A list of address blocks reserved for this virtual network in CIDR notation. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.customRoutes.addressPrefixes")]
        public IList<string> CustomRoutesAddressPrefixes
        {
            get
            {
                CustomRoutes ??= new VirtualNetworkAddressSpace();
                return CustomRoutes.AddressPrefixes;
            }
        }

        // Preserve the identifier API now that the internal reference uses WritableSubResource and is no longer ID-flattened.
        /// <summary> Resource ID. </summary>
        [WirePath("properties.gatewayDefaultSite.id")]
        public ResourceIdentifier GatewayDefaultSiteId
        {
            get => GatewayDefaultSite?.Id;
            set
            {
                GatewayDefaultSite ??= new WritableSubResource();
                GatewayDefaultSite.Id = value;
            }
        }

        // Preserve the pre-TypeSpec property name because it maps to the same wire property as the generated member.
        /// <inheritdoc cref="ActiveActive"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use ActiveActive instead.")]
        public bool? Active
        {
            get => ActiveActive;
            set => ActiveActive = value;
        }
    }
}
