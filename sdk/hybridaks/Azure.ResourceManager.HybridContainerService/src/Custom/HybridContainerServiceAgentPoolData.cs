// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridContainerService
{
    // The TypeSpec resource omits the GA tags envelope, so the C# generator cannot recreate the shipped Tags property.
    [CodeGenSerialization(nameof(Tags), SerializationName = "tags")]
    public partial class HybridContainerServiceAgentPoolData
    {
        /// <summary> Resource tags. </summary>
        public IDictionary<string, string> Tags { get; }
    }
}
