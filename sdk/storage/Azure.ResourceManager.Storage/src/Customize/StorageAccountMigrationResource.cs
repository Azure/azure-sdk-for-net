// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// Structural fix: Adds string-id constructor bridge needed by generated code.
// StorageAccountMigrationData shadows ResourceData.Id with a string for backward compatibility.

using Azure.Core;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageAccountMigrationResource
    {
        internal StorageAccountMigrationResource(ArmClient client, string id) : base(client, new ResourceIdentifier(id))
        {
        }
    }
}
