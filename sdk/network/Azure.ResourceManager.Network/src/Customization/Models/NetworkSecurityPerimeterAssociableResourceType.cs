// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    [CodeGenSuppress("ResourceType")]
    public partial class NetworkSecurityPerimeterAssociableResourceType
    {
        /// <summary> Identifier of the perimeter associable resource. </summary>
        public new string Id => base.Id?.ToString();

        /// <summary> The ARM resource type. </summary>
        public string Type => base.ResourceType.ToString();

        /// <summary> Resource type/provider name. </summary>
        public new string ResourceType => Properties?.ResourceType;
    }
}
