// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.CosmosDB.Models
{
    // The historical SDK exposed the discriminator fallback type as `UnknownBackupPolicy`
    // (referenced by [PersistableModelProxy(typeof(UnknownBackupPolicy))] on
    // CosmosDBAccountBackupPolicy). The MPG generator names this fallback after the base
    // model — `UnknownCosmosDBAccountBackupPolicy` — which is a binary-incompatible
    // change. Use [CodeGenType] to rename the generated class back to UnknownBackupPolicy
    // so the PersistableModelProxy reference matches the previously-shipped contract.
    [CodeGenType("UnknownCosmosDBAccountBackupPolicy")]
    internal partial class UnknownBackupPolicy { }
}
