// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.CosmosDBForPostgreSql.Models;

namespace Azure.ResourceManager.CosmosDBForPostgreSql
{
    // Backward-compat only: baseline PromoteReadReplica had 2-param signature (no content body).
    // New API version adds optional content param.
    public partial class CosmosDBForPostgreSqlClusterResource
    {
        /// <summary> Promotes read replica cluster to an independent read-write cluster. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation PromoteReadReplica(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            return PromoteReadReplica(waitUntil, default(CosmosDBForPostgreSqlPromoteRequestContent), cancellationToken);
        }

        /// <summary> Promotes read replica cluster to an independent read-write cluster. </summary>
        /// <param name="waitUntil"> Defines how to use the LRO. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation> PromoteReadReplicaAsync(WaitUntil waitUntil, CancellationToken cancellationToken)
        {
            return await PromoteReadReplicaAsync(waitUntil, default(CosmosDBForPostgreSqlPromoteRequestContent), cancellationToken).ConfigureAwait(false);
        }
    }
}
