// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the RoutingConfigurationNfv type. </summary>
    [CodeGenType("RoutingConfiguration")]
    public partial class RoutingConfigurationNfv
    {
        /// <summary> Compatibility member. </summary>
        public global::System.Uri AssociatedRouteTableResourceUri { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::System.Uri InboundRouteMapResourceUri { get; set; }
        /// <summary> Compatibility member. </summary>
        public global::System.Uri OutboundRouteMapResourceUri { get; set; }
    }
}
