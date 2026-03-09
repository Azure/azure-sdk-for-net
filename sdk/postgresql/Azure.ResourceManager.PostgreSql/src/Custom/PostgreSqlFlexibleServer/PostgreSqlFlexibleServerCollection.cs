// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    public partial class PostgreSqlFlexibleServerCollection
    {
        /// <summary> List all the replicas for a given server. </summary>
        /// <param name="serverName"> The name of the server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<PostgreSqlFlexibleServerResource> GetReplicas(string serverName, CancellationToken cancellationToken = default)
        {
            var server = Get(serverName, cancellationToken).Value;
            return server.GetReplicasByServer(cancellationToken);
        }

        /// <summary> List all the replicas for a given server. </summary>
        /// <param name="serverName"> The name of the server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<PostgreSqlFlexibleServerResource> GetReplicasAsync(string serverName, CancellationToken cancellationToken = default)
        {
            var server = Get(serverName, cancellationToken).Value;
            return server.GetReplicasByServerAsync(cancellationToken);
        }
    }
}
