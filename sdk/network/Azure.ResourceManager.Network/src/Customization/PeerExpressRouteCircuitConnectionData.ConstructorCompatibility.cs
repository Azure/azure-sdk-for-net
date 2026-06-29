// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the PeerExpressRouteCircuitConnectionData type. </summary>
    [CodeGenSuppress("PeerExpressRouteCircuitConnectionData")]
    public partial class PeerExpressRouteCircuitConnectionData
    {
        /// <summary> Initializes a new instance of the PeerExpressRouteCircuitConnectionData class. </summary>
        public PeerExpressRouteCircuitConnectionData()
        {
        }
    }
}
