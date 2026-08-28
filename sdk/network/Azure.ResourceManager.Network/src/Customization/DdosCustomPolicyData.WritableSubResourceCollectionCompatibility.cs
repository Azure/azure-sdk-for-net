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
    /// <summary> Compatibility declaration for the DdosCustomPolicyData type. </summary>
    [CodeGenSuppress("PublicIPAddresses")]
    public partial class DdosCustomPolicyData
    {
        /// <summary> Gets or sets the PublicIPAddresses compatibility property. </summary>
        [System.ObsoleteAttribute("This property is obsolete and will be removed in a future release", false)]
        [WirePath("properties.publicIPAddresses")]
        public IReadOnlyList<WritableSubResource> PublicIPAddresses => WritableSubResourceCollectionCompatibility.AsReadOnlyList(Properties?.PublicIPAddresses);
    }
}
