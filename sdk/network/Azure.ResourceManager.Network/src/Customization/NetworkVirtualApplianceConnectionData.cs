// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Network.Models;

namespace Azure.ResourceManager.Network
{
    /// <summary>
    /// A class representing the NetworkVirtualApplianceConnection data model.
    /// NetworkVirtualApplianceConnection resource.
    /// </summary>
    public partial class NetworkVirtualApplianceConnectionData : NetworkResourceData
    {
        /// <summary> The Routing Configuration indicating the associated and propagated route tables on this connection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RoutingConfigurationNfv RoutingConfiguration { get; set; }
    }
}
