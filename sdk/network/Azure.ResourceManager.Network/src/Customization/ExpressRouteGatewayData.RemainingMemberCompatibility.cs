// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRouteGatewayData type. </summary>
    [CodeGenSuppress("ExpressRouteConnections")]
    public partial class ExpressRouteGatewayData
    {
        /// <summary> Gets or sets the ExpressRouteConnections compatibility property. </summary>
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        public IReadOnlyList<ExpressRouteConnectionData> ExpressRouteConnections => Properties?.ExpressRouteConnections as IReadOnlyList<ExpressRouteConnectionData>;
    }
}
