// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using TypeSpecCodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter
{
    /// <summary> Concrete proxy resource types can be created by aliasing this type using a specific property type. </summary>
    [TypeSpecCodeGenSuppressAttribute("Location")]
    public partial class JitNetworkAccessPolicyData
    {
        // Preserve the shipped nullable C# API; generated code currently emits a non-nullable AzureLocation.
        /// <summary> Location where the resource is stored. </summary>
        public AzureLocation? Location { get; internal set; }
    }
}
