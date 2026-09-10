// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration.Models
{
    // The new generator creates "UnknownDataMigrationCommandProperties" but
    // the old GA API exposed [PersistableModelProxy(typeof(UnknownCommandProperties))].
    // Rename back to preserve the attribute value for ApiCompat.
    [CodeGenType("UnknownDataMigrationCommandProperties")]
    internal partial class UnknownCommandProperties : DataMigrationCommandProperties
    {
    }
}
