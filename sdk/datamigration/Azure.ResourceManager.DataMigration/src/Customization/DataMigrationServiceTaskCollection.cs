// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration
{
    // The old GA SDK named the services/projects/tasks collection "DataMigrationServiceTaskCollection".
    // The new generator names it "TaskCollection". Rename back for backward compatibility.
    [CodeGenType("TaskCollection")]
    public partial class DataMigrationServiceTaskCollection
    {
    }
}
