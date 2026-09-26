// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the RoutingConfigurationNfv type. </summary>
    [CodeGenType("RoutingConfiguration")]
    public partial class RoutingConfigurationNfv
    {
        /// <summary> Compatibility member. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and no longer functions. Please use AssociatedRouteTableId instead.", false)]
        public Uri AssociatedRouteTableResourceUri { get; set; }
        /// <summary> Compatibility member. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and no longer functions. Please use InboundRouteMapId instead.", false)]
        public Uri InboundRouteMapResourceUri { get; set; }
        /// <summary> Compatibility member. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and no longer functions. Please use OutboundRouteMapId instead.", false)]
        public Uri OutboundRouteMapResourceUri { get; set; }
    }
}
