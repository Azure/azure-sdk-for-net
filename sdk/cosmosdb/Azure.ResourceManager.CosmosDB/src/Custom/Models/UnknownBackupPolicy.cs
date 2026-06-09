// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // 1.4.0 GA referenced the discriminator fallback as `UnknownBackupPolicy`
    // (via [PersistableModelProxy(typeof(UnknownBackupPolicy))]). MPG names it
    // `UnknownCosmosDBAccountBackupPolicy`. Rename via [CodeGenType] to match the shipped contract.
    [CodeGenType("UnknownCosmosDBAccountBackupPolicy")]
    internal partial class UnknownBackupPolicy { }
}
