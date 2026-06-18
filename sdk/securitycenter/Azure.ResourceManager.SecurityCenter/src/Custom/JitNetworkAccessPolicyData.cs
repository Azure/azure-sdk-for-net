// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityCenter
{
    // The current TypeSpec constructor/property list follows the latest wire schema, but the GA SDK exposed a different constructor or property signature; CodeGenSuppress lets this partial provide the GA shape explicitly.
    [CodeGenSuppress("Location")]
    public partial class JitNetworkAccessPolicyData
    {
        /// <summary> Location where the resource is stored. </summary>
        public AzureLocation? Location { get; }
    }
}
