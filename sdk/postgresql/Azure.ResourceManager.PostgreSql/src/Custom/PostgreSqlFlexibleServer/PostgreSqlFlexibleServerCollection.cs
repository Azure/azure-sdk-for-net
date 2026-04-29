// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers
{
    public partial class PostgreSqlFlexibleServerCollection
    {
        /// <summary> List all the replicas for a given server. </summary>
        /// <param name="serverName"> The name of the server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Pageable<PostgreSqlFlexibleServerResource> GetReplicas(string serverName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serverName, nameof(serverName));

            var serverId = PostgreSqlFlexibleServerResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, serverName);
            var server = PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerResource(Client, serverId);
            return server.GetReplicas(cancellationToken);
        }

        /// <summary> List all the replicas for a given server. </summary>
        /// <param name="serverName"> The name of the server. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual AsyncPageable<PostgreSqlFlexibleServerResource> GetReplicasAsync(string serverName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(serverName, nameof(serverName));

            var serverId = PostgreSqlFlexibleServerResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, serverName);
            var server = PostgreSqlFlexibleServersExtensions.GetPostgreSqlFlexibleServerResource(Client, serverId);
            return server.GetReplicasAsync(cancellationToken);
        }
    }
}
