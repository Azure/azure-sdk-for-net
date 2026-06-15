// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable
#pragma warning disable CS0612, CS0618, CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network
{
    [CodeGenSuppress("ConnectionResourceUri")]
    public partial class ExpressRouteCircuitAuthorizationData
    {
        [WirePath("properties.connectionResourceUri")] public Uri ConnectionResourceUri => WritableSubResourceCollectionCompatibility.ParseUri(Properties?.ConnectionResourceUri);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
