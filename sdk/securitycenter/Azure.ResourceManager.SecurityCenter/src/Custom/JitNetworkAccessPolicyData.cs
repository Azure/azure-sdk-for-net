// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: preserves Azure.ResourceManager.SecurityCenter 1.1.0 public API shape during the MPG migration.
    [CodeGenSuppress("Location")]
    public partial class JitNetworkAccessPolicyData
    {
        /// <summary> Location where the resource is stored. </summary>
        public AzureLocation? Location { get; }
    }
}
