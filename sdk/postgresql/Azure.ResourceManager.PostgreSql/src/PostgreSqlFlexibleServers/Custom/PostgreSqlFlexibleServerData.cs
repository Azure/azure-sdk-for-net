// Copyright (c) Microsoft Corporation. All rights reserved.
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
        /// <summary> Replicas allowed for a server. </summary>
        [WirePath("properties.replicaCapacity")]
        public int? ReplicaCapacity
        {
            get;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set;
        }
        /// <summary> User assigned managed identities assigned to the server. </summary>
        [WirePath("identity")]
        public PostgreSqlFlexibleServerUserAssignedIdentity UserAssignedIdentity
        {
            get;
            set;
        }
    }
}
