// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CosmosDB.Models
{
    // CosmosDBAccountBackupPolicy is the abstract discriminated base for the
    // backupPolicy union (Periodic / Continuous / Unknown). MPG no longer emits a
    // protected parameterless ctor on the base because the base/derived constructors
    // pass the discriminator value explicitly. The legacy SDK shipped a public-API
    // protected `()` ctor that downstream test code and (de)serializers relied on.
    // Re-declare it here to preserve the historical surface; subclasses still call
    // the discriminator-injecting base ctor on the wire path.
    public abstract partial class CosmosDBAccountBackupPolicy
    {
        /// <summary> Initializes a new instance of <see cref="CosmosDBAccountBackupPolicy"/>. </summary>
        protected CosmosDBAccountBackupPolicy()
        {
        }
    }
}
