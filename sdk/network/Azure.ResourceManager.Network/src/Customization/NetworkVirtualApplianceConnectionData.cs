// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the NetworkVirtualApplianceConnectionData type. </summary>
    public partial class NetworkVirtualApplianceConnectionData
    {
        /// <summary> Compatibility member. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is deprecated and it will be removed in a future version. Please use RoutingConfiguration instead.")]
        public RoutingConfiguration ConnectionRoutingConfiguration { get; set; }
    }
}
