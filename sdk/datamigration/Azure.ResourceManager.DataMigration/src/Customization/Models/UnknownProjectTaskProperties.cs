// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataMigration.Models
{
    // The new generator creates "UnknownDataMigrationProjectTaskProperties" but
    // the old GA API exposed [PersistableModelProxy(typeof(UnknownProjectTaskProperties))].
    [CodeGenType("UnknownDataMigrationProjectTaskProperties")]
    internal partial class UnknownProjectTaskProperties : DataMigrationProjectTaskProperties
    {
    }
}
