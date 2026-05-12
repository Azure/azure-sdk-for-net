// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Security.Models
{
    // Suppress the generated factory for the abstract ResourceDetails discriminator base type.
    // The generated method attempts to instantiate the abstract base instead of a concrete discriminator subtype.
    [CodeGenSuppress("ResourceDetails", typeof(Source?), typeof(string), typeof(string))]
    public static partial class ArmSecurityModelFactory
    {
    }
}
