// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.Purview.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Purview
{
    // Old API exposed Properties as public on PurviewPrivateLinkResourceData.
    // The new generator makes it internal due to property flattening.
    public partial class PurviewPrivateLinkResourceData
    {
        /// <summary> The private link resource properties. </summary>
        public PurviewPrivateLinkResourceProperties Properties { get; }
    }
}
