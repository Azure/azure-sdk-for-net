// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    // Preserves previous flattened properties and setter signatures on the server data model.
    /// <summary>
    /// A class representing the PostgreSqlFlexibleServer data model.
    /// Represents a server.
    /// </summary>
    public partial class PostgreSqlFlexibleServerData : TrackedResourceData
    {
        /// <summary> Max storage allowed for a server. </summary>
        [WirePath("properties.storage.storageSizeGB")]
        public int? StorageSizeInGB
        {
            get => Storage is null ? default : Storage.StorageSizeInGB;
            set
            {
                if (Storage is null)
                    Storage = new PostgreSqlFlexibleServerStorage();
                Storage.StorageSizeInGB = value;
            }
        }
        /// <summary> Replicas allowed for a server. </summary>
        [WirePath("properties.replicaCapacity")]
        public int? ReplicaCapacity
        {
            get => Properties is null ? default : Properties.ReplicaCapacity;
            set
            {
                // Setter is preserved for binary compatibility; replicaCapacity is service-readonly in the generated model.
            }
        }
    }
}
