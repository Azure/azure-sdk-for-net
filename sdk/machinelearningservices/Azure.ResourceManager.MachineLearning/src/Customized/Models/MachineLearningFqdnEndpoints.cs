// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore GA flattened Properties bag over generated Category/Endpoints properties.
    public partial class MachineLearningFqdnEndpoints
    {
        /// <summary> Gets the FQDN endpoint property bag. </summary>
        [WirePath("properties")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MachineLearningFqdnEndpointsProperties Properties => new MachineLearningFqdnEndpointsProperties(Category, Endpoints is null ? null : new List<MachineLearningFqdnEndpoint>(Endpoints));
    }
}
