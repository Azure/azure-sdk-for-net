// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Kusto.Models;

namespace Azure.ResourceManager.Kusto
{
    public partial class KustoClusterCollection
    {
        /// <summary> Creates or updates a Kusto cluster using the legacy conditional headers signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<KustoClusterResource> CreateOrUpdate(WaitUntil waitUntil, string clusterName, KustoClusterData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken)
        {
            var matchConditions = new MatchConditions();
            if (ifMatch != null) matchConditions.IfMatch = new ETag(ifMatch);
            if (ifNoneMatch != null) matchConditions.IfNoneMatch = new ETag(ifNoneMatch);
            return CreateOrUpdate(waitUntil, clusterName, data, matchConditions, cancellationToken);
        }

        /// <summary> Creates or updates a Kusto cluster using the legacy conditional headers signature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<ArmOperation<KustoClusterResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string clusterName, KustoClusterData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken)
        {
            var matchConditions = new MatchConditions();
            if (ifMatch != null) matchConditions.IfMatch = new ETag(ifMatch);
            if (ifNoneMatch != null) matchConditions.IfNoneMatch = new ETag(ifNoneMatch);
            return CreateOrUpdateAsync(waitUntil, clusterName, data, matchConditions, cancellationToken);
        }
    }
}
