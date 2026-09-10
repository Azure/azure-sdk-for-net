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
    /// <summary> Compatibility declaration for the OutboundRuleData type. </summary>
    [CodeGenSuppress("FrontendIPConfigurations")]
    public partial class OutboundRuleData
    {
        /// <summary> Gets or sets the FrontendIPConfigurations compatibility property. </summary>
        [WirePath("properties.frontendIPConfigurations")]
        public IList<WritableSubResource> FrontendIPConfigurations => WritableSubResourceCollectionCompatibility.AsList(Properties?.FrontendIPConfigurations);
    }
}
