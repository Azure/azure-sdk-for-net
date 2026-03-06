// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    [SuppressMessage("StyleCop.CSharp.NamingRules", "AZC0032:DisallowedModelNameSuffix")]
    public partial class StorageAccountMigrationData
    {
        // Constructor overload to fix generator backward-compat factory method bug:
        // The generated factory passes string id and ResourceType? but the constructor expects
        // ResourceIdentifier id and ResourceType.
        internal StorageAccountMigrationData(string id, string name, ResourceType? resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, StorageAccountMigrationProperties storageAccountMigrationDetails)
            : this(id != null ? new ResourceIdentifier(id) : null, name, resourceType ?? default, systemData, additionalBinaryDataProperties, storageAccountMigrationDetails)
        {
        }
    }
}
