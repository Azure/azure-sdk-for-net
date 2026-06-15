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
    [CodeGenSuppress("Circuits")]
    public partial class ExpressRoutePortData
    {
        [WirePath("properties.circuits")] public IReadOnlyList<WritableSubResource> Circuits => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Circuits);
    }
}

#pragma warning restore CS0612, CS0618, CS1591
