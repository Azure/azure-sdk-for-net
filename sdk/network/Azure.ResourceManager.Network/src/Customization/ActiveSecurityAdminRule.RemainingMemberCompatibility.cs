// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ActiveSecurityAdminRule type. </summary>
    [CodeGenSuppress("Sources")]
    [CodeGenSuppress("Destinations")]
    [CodeGenSuppress("SourcePortRanges")]
    [CodeGenSuppress("DestinationPortRanges")]
    public partial class ActiveSecurityAdminRule
    {
        /// <summary> Gets or sets the Sources compatibility property. </summary>
        public IReadOnlyList<AddressPrefixItem> Sources => Properties?.Sources as IReadOnlyList<AddressPrefixItem>;
        /// <summary> Gets or sets the Destinations compatibility property. </summary>
        public IReadOnlyList<AddressPrefixItem> Destinations => Properties?.Destinations as IReadOnlyList<AddressPrefixItem>;
        /// <summary> Gets or sets the SourcePortRanges compatibility property. </summary>
        public IReadOnlyList<string> SourcePortRanges => Properties?.SourcePortRanges as IReadOnlyList<string>;
        /// <summary> Gets or sets the DestinationPortRanges compatibility property. </summary>
        public IReadOnlyList<string> DestinationPortRanges => Properties?.DestinationPortRanges as IReadOnlyList<string>;
    }
}
