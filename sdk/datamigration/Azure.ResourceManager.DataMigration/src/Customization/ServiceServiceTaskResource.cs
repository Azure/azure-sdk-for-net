// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration
{
    // The old GA SDK named the services/serviceTasks resource "ServiceServiceTaskResource".
    // The new generator names it "DataMigrationServiceTaskResource". Rename back for backward compatibility.
    [CodeGenType("DataMigrationServiceTaskResource")]
    public partial class ServiceServiceTaskResource
    {
    }
}
