// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Suppress duplicate generated methods caused by multi-scope operations
    [CodeGenSuppress("GetMaintenanceConfigurationResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    public static partial class MaintenanceExtensions
    {
    }
}
