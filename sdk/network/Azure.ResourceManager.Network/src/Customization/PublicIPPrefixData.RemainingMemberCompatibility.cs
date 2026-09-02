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
    /// <summary> Compatibility declaration for the PublicIPPrefixData type. </summary>
    [CodeGenSuppress("PublicIPAddresses")]
    public partial class PublicIPPrefixData
    {
        /// <summary> Gets the PublicIPAddresses compatibility property. </summary>
        public IReadOnlyList<SubResource> PublicIPAddresses => Properties is null
            ? Array.Empty<SubResource>()
            : new ReadOnlyReferencedPublicIpAddressList(Properties.PublicIPAddresses);
    }
}
