// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRoutePortsLocationData type. </summary>
    [CodeGenSuppress("ExpressRoutePortsLocationData")]
    public partial class ExpressRoutePortsLocationData
    {
        /// <summary> Initializes a new instance of the ExpressRoutePortsLocationData class. </summary>
        public ExpressRoutePortsLocationData()
        {
        }
    }
}
