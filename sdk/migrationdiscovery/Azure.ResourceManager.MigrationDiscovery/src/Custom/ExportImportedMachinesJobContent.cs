// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MigrationDiscovery
{
    // The SDK exposes the ARM data model as ExportImportedMachinesJobContent while retaining
    // the generated resource and collection names.
    [CodeGenType("ExportImportedMachinesJobData")]
    public partial class ExportImportedMachinesJobContent
    {
    }
}
