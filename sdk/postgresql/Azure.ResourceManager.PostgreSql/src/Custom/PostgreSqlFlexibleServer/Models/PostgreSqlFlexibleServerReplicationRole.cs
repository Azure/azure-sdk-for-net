// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Used to indicate role of the server in replication set. </summary>
    public readonly partial struct PostgreSqlFlexibleServerReplicationRole : IEquatable<PostgreSqlFlexibleServerReplicationRole>
    {
        private const string SecondaryValue = "Secondary";
        private const string WalReplicaValue = "WalReplica";
        private const string SyncReplicaValue = "SyncReplica";
        private const string GeoSyncReplicaValue = "GeoSyncReplica";
        /// <summary> Secondary. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerReplicationRole Secondary { get; } = new PostgreSqlFlexibleServerReplicationRole(SecondaryValue);
        /// <summary> WalReplica. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerReplicationRole WalReplica { get; } = new PostgreSqlFlexibleServerReplicationRole(WalReplicaValue);
        /// <summary> SyncReplica. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerReplicationRole SyncReplica { get; } = new PostgreSqlFlexibleServerReplicationRole(SyncReplicaValue);
        /// <summary> AsyncReplica. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static PostgreSqlFlexibleServerReplicationRole GeoSyncReplica { get; } = new PostgreSqlFlexibleServerReplicationRole(GeoSyncReplicaValue);
    }
}
