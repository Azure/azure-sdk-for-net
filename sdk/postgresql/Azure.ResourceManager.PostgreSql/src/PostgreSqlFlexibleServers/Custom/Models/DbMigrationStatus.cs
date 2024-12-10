// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    /// <summary> Migration status of an individual database. </summary>
    public partial class DbMigrationStatus
    {
        /// <summary> Number of tables queued for the migration of a DB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("fullLoadQueuedTables")]
        public int? NumFullLoadQueuedTables { get; }
        /// <summary> Number of tables errored out during the migration of a DB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("fullLoadErroredTables")]
        public int? NumFullLoadErroredTables { get; }
        /// <summary> Number of tables loading during the migration of a DB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("fullLoadLoadingTables")]
        public int? NumFullLoadLoadingTables { get; }
        /// <summary> Number of tables loaded during the migration of a DB. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("fullLoadCompletedTables")]
        public int? NumFullLoadCompletedTables { get; }
    }
}
