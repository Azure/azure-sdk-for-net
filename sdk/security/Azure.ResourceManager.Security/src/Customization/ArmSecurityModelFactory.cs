// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Security.Models
{
    [CodeGenSuppress("ResourceDetails", typeof(Source?), typeof(string), typeof(string))]
    public static partial class ArmSecurityModelFactory
    {
    }
}
