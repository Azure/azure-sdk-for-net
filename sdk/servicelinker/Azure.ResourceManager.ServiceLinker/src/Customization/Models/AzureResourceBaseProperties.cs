// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ServiceLinker.Models
{
    // The TypeSpec generator emits an internal deserialization constructor, while the GA SDK
    // exposed a protected constructor that allowed external derived resource-property models.
    [CodeGenSuppress("AzureResourceBaseProperties")]
    public abstract partial class AzureResourceBaseProperties
    {
        /// <summary> Initializes a new instance of <see cref="AzureResourceBaseProperties"/> for deserialization. </summary>
        protected AzureResourceBaseProperties() { }
    }
}
