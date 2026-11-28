// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MigrationDiscovery
{
    // The SDK exposes the ARM data model as ImportMachinesJobContent while retaining
    // the generated resource and collection names.
    [CodeGenType("ImportMachinesJobData")]
    public partial class ImportMachinesJobContent
    {
    }
}
