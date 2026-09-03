// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.AppContainers.Models
{
    // The shared C# name is service-specific for provisioning analyzer compliance. Preserve the shipped management name and all APIs that reference it.
    [CodeGenType("ContainerAppOtlpHeader")]
    public partial class Header
    {
    }
}
