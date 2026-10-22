// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    public partial class NetworkTrackedResourceData
    {
        // The legacy SSL factory and persistence adapter must populate native metadata without exposing a public setter.
        /// <summary> Gets the resource type. </summary>
        [CodeGenMember("ResourceType")]
        public ResourceType? ResourceType { get; internal set; }
    }
}
