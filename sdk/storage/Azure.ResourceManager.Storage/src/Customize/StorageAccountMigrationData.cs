// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        internal StorageAccountMigrationData(string id, string name, ResourceType? resourceType, SystemData systemData, IDictionary<string, BinaryData> additionalBinaryDataProperties, StorageAccountMigrationProperties storageAccountMigrationDetails, string name0)
            : this(id != null ? new ResourceIdentifier(id) : null, name, resourceType ?? default, systemData, additionalBinaryDataProperties, storageAccountMigrationDetails, name0)
        {
        }

        // Backward-compat: old SDK had settable Name property.
        // Shadow the read-only Name from ResourceData to add a setter.
        // Safe because no generated code references data.Name.
        /// <summary> The name of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("name")]
        public new string Name
        {
            get => base.Name;
            set { /* no-op for backward compatibility */ }
        }

        // Backward-compat: old SDK had Nullable<ResourceType> ResourceType with setter.
        // Shadow the non-nullable read-only ResourceType from ResourceData.
        // Safe because no generated code references data.ResourceType on this type.
        /// <summary> The type of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public new ResourceType? ResourceType
        {
            get => base.ResourceType;
            set { /* no-op for backward compatibility */ }
        }

        // Note: The old API had string Id (not ResourceIdentifier).
        // Cannot safely shadow Id with `new string Id` because generated
        // StorageAccountMigrationResource constructor uses data.Id as ResourceIdentifier.
        // This type change is suppressed via ApiCompatBaseline.txt.
    }
}
