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
    /// <summary> Compatibility declaration for the ExpressRouteCircuitAuthorizationData type. </summary>
    [CodeGenSuppress("ConnectionResourceUri")]
    public partial class ExpressRouteCircuitAuthorizationData
    {
        /// <summary> Gets or sets the ConnectionResourceUri compatibility property. </summary>
        [WirePath("properties.connectionResourceUri")]
        public Uri ConnectionResourceUri => WritableSubResourceCollectionCompatibility.ParseUri(Properties?.ConnectionResourceUri);
    }
}
