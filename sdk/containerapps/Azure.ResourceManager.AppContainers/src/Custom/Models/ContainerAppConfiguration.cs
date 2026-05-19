// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.ResourceManager.AppContainers;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppContainers.Models
{
    [CodeGenSuppress("JavaAgent")]
    [CodeGenSuppress("AutoConfigureDataProtection")]
    public partial class ContainerAppConfiguration
    {
    }
}
