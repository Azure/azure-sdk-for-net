// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration.Models
{
    // The new generator creates "UnknownDataMigrationMongoDBProgress" but
    // the old GA API exposed [PersistableModelProxy(typeof(UnknownMongoDBProgress))].
    [CodeGenType("UnknownDataMigrationMongoDBProgress")]
    internal partial class UnknownMongoDBProgress : DataMigrationMongoDBProgress
    {
    }
}
