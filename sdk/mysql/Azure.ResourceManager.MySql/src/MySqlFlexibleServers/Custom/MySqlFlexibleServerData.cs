// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;
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
        /// <summary> PrivateEndpointConnections related properties of a server. </summary>
        public IReadOnlyList<MySqlFlexibleServersPrivateEndpointConnection> PrivateEndpointConnections { get; }
    }
}
