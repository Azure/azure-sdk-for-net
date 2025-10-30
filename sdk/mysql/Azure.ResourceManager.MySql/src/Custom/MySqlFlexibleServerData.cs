// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.MySql.FlexibleServers.Models;

namespace Azure.ResourceManager.MySql.FlexibleServers
{
    /// <summary>
    /// A class representing the MySqlFlexibleServer data model.
    /// Represents a server.
    /// </summary>
    public partial class MySqlFlexibleServerData : TrackedResourceData
    {
        /// <summary> Restore point creation time (ISO8601 format), specifying the time to restore from. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? RestorePointInTime { get => RestorePointInTime; set => RestorePointInTime = value; }

        /// <summary> PrivateEndpointConnections related properties of a server. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<MySqlFlexibleServersPrivateEndpointConnection> PrivateEndpointConnections
        {
            get
            {
                if (ServerPrivateEndpointConnections == null)
                    return null;
                var list = new List<MySqlFlexibleServersPrivateEndpointConnection>();
                foreach (var item in ServerPrivateEndpointConnections)
                {
                    var model = new MySqlFlexibleServersPrivateEndpointConnection();
                    if (item.GroupIds != null && model.GroupIds is IList<string> modelGroupIds)
                    {
                        foreach (var gid in item.GroupIds)
                            modelGroupIds.Add(gid);
                    }
                    model.PrivateEndpoint = item.PrivateEndpoint;
                    model.ConnectionState = item.PrivateLinkServiceConnectionState;
                    list.Add(model);
                }
                return list;
            }
        }
    }
}
