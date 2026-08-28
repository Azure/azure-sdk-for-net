// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declarations for generated members that intentionally hide inherited ARM members. </summary>
    [CodeGenSuppress("Name")]
    [CodeGenSuppress("Id")]
    [CodeGenSuppress("ResourceType")]
    public partial class NetworkSecurityPerimeterAssociableResourceType
    {
        // The generated member intentionally preserves the service wire shape while hiding an inherited ARM member.
        // TODO: Remove this SDK-side workaround after https://github.com/Azure/azure-sdk-for-net/issues/60023 is fixed.
        /// <summary> The name of the resource that is unique within a resource group. This name can be used to access the resource. </summary>
        [WirePath("name")]
        public new string Name { get; }
        /// <summary> Identifier of the perimeter associable resource. </summary>
        [WirePath("id")]
        public new string Id { get; }
        /// <summary> Resource type/provider name. </summary>
        [WirePath("properties.resourceType")]
        public new string ResourceType
        {
            get
            {
                return Properties is null ? default : Properties.ResourceType;
            }
        }
    }
}
