// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    // Without suppression, the generator emits a flattened string ResourceType that collides with ResourceData.ResourceType.
    // This partial replaces the flattened member and restores the released string Id and Type metadata aliases.
    [CodeGenSuppress("ResourceType")]
    public partial class NetworkSecurityPerimeterAssociableResourceType
    {
        /// <summary> Identifier of the perimeter associable resource. </summary>
        public new string Id => base.Id?.ToString();

        /// <summary> The ARM resource type. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete. Please use ResourceType instead.")]
        public string Type => base.ResourceType.ToString();

        // Restores the released flattened service resource type while inherited metadata owns ARM resource serialization.
        /// <summary> Gets the service resource type. </summary>
        public new string ResourceType => Properties?.ResourceType;
    }
}
