// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    // Abstract discriminated base for backupPolicy union. MPG no longer emits a protected
    // parameterless ctor (base/derived ctors pass the discriminator explicitly). Re-declare it
    // to preserve the 1.4.0 GA public-API surface; subclasses still wire the discriminator base.
    public abstract partial class CosmosDBAccountBackupPolicy
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBAccountBackupPolicy"/>. </summary>
        protected CosmosDBAccountBackupPolicy()
        {
        }
    }
}
