﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.PostgreSql.FlexibleServers.Models;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    /// <summary>
    /// A class representing the PostgreSqlFlexibleServer data model.
    /// Represents a server.
    /// </summary>
    public partial class PostgreSqlFlexibleServerData : TrackedResourceData
    {
        /// <summary> Max storage allowed for a server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        public int? ReplicaCapacity
        {
            get;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set;
        }
    }
}
