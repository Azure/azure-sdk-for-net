// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class EndpointServiceResult
    {
        // Generated constructors and deserializers still need to populate the released read-only metadata.
        /// <summary> Gets the resource type. </summary>
        [CodeGenMember("ResourceType")]
        public ResourceType? ResourceType { get; internal set; }
    }
}
