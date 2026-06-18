// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    /// <summary> Compatibility declaration for the ExpressRoutePortAuthorizationData type. </summary>
    [CodeGenSuppress("CircuitResourceUri")]
    public partial class ExpressRoutePortAuthorizationData
    {
        /// <summary> Gets or sets the CircuitResourceUri compatibility property. </summary>
        [WirePath("properties.circuitResourceUri")]
        public Uri CircuitResourceUri => WritableSubResourceCollectionCompatibility.ParseUri(Properties?.CircuitResourceUri);
    }
}
