// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

// The prior GA SDK's StorageAccountMigrationData shadows ResourceData.Id
// with `new string Id` for backward compatibility (the spec defines Id as
// a plain string, not an ARM resource identifier). The generated
// constructor chain `(ArmClient, StorageAccountMigrationData data) :
// this(client, data.Id)` therefore passes a string, but the base
// ArmResource only accepts ResourceIdentifier. This overload bridges the
// gap by converting the string to a ResourceIdentifier.

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
