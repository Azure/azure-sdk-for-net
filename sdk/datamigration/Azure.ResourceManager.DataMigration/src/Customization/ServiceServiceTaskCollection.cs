// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration
{
    // The old GA SDK named the services/serviceTasks collection "ServiceServiceTaskCollection".
    // The new generator names it "DataMigrationServiceTaskCollection". Rename back for backward compatibility.
    [CodeGenType("DataMigrationServiceTaskCollection")]
    public partial class ServiceServiceTaskCollection
    {
    }
}
