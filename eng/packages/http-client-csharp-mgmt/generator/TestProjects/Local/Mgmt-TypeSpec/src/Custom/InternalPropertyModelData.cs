// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.MgmtTypeSpec.Tests.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Generator.MgmtTypeSpec.Tests
{
    // Suppress the generated public Properties property and re-expose as internal.
    // This is a common pattern during migration to maintain backward compatibility.
    [CodeGenSuppress("Properties")]
    public partial class InternalPropertyModelData
    {
        /// <summary> The resource-specific properties for this resource. </summary>
        [WirePath("properties")]
        internal InternalPropertyModelProperties Properties { get; set; }
    }
}
