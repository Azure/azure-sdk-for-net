// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;

namespace Azure.ResourceManager.Kusto
{
    public partial class KustoClusterCollection
    {
        // Backward-compat: the previous AutoRest SDK exposed CreateOrUpdate with separate string ifMatch
        // and string ifNoneMatch parameters; the TypeSpec generator merges both conditional headers into a
        // single Azure.MatchConditions parameter. These overloads preserve the original signature.

        /// <summary> Create or update a Kusto cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<KustoClusterResource> CreateOrUpdate(WaitUntil waitUntil, string clusterName, KustoClusterData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, clusterName, data, ToMatchConditions(ifMatch, ifNoneMatch), cancellationToken);
        }

        /// <summary> Create or update a Kusto cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<KustoClusterResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string clusterName, KustoClusterData data, string ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, clusterName, data, ToMatchConditions(ifMatch, ifNoneMatch), cancellationToken).ConfigureAwait(false);
        }

        private static MatchConditions ToMatchConditions(string ifMatch, string ifNoneMatch)
        {
            if (ifMatch is null && ifNoneMatch is null)
            {
                return null;
            }

            return new MatchConditions
            {
                IfMatch = ifMatch is null ? default(ETag?) : new ETag(ifMatch),
                IfNoneMatch = ifNoneMatch is null ? default(ETag?) : new ETag(ifNoneMatch),
            };
        }
    }
}
