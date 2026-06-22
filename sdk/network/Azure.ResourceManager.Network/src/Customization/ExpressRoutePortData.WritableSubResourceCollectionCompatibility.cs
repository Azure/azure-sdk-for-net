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
    /// <summary> Compatibility declaration for the ExpressRoutePortData type. </summary>
    [CodeGenSuppress("Circuits")]
    public partial class ExpressRoutePortData
    {
        /// <summary> Gets or sets the Circuits compatibility property. </summary>
        [WirePath("properties.circuits")]
        public IReadOnlyList<WritableSubResource> Circuits => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.Circuits);
    }
}
