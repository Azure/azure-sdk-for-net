// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable CS0612, CS0618, CS1591

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("Sources")]
    [CodeGenSuppress("Destinations")]
    [CodeGenSuppress("SourcePortRanges")]
    [CodeGenSuppress("DestinationPortRanges")]
    public partial class ActiveSecurityAdminRule
    {
        public IReadOnlyList<AddressPrefixItem> Sources => Properties?.Sources as IReadOnlyList<AddressPrefixItem>;
        public IReadOnlyList<AddressPrefixItem> Destinations => Properties?.Destinations as IReadOnlyList<AddressPrefixItem>;
        public IReadOnlyList<string> SourcePortRanges => Properties?.SourcePortRanges as IReadOnlyList<string>;
        public IReadOnlyList<string> DestinationPortRanges => Properties?.DestinationPortRanges as IReadOnlyList<string>;
    }
}
