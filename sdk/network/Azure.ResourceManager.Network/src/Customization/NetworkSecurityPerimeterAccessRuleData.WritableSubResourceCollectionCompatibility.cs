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
    /// <summary> Compatibility declaration for the NetworkSecurityPerimeterAccessRuleData type. </summary>
    [CodeGenSuppress("Subscriptions")]
    public partial class NetworkSecurityPerimeterAccessRuleData
    {
        /// <summary> Gets or sets the Subscriptions compatibility property. </summary>
        [WirePath("properties.subscriptions")]
        public IList<WritableSubResource> Subscriptions => WritableSubResourceCollectionCompatibility.AsList(Properties?.Subscriptions);
    }
}
