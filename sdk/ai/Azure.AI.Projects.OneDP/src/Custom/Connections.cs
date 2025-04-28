// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Linq;

namespace Azure.AI.Projects.OneDP
{
    // Data plane generated sub-client.
    /// <summary> The Connections sub-client. </summary>
    public partial class Connections
    {
        /// <summary> Get the details of a single connection. </summary>
        /// <param name="category"> Category of the workspace connection. </param>
        public virtual Response<Connection> GetDefaultConnection(ConnectionType category)
        {
            Pageable<Connection> connections = GetConnections(category, true);
            Connection connection = connections.FirstOrDefault();
            return Response.FromValue(connection, null);
        }
    }
}
