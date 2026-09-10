// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Kusto.Models;

namespace Azure.ResourceManager.Kusto
{
    public partial class KustoClusterResource
    {
        // Backward-compat: the previous AutoRest SDK exposed Update with a string ifMatch parameter; the
        // TypeSpec generator types the If-Match header as ETag?. These overloads preserve the original signature.

        /// <summary> Update a Kusto cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<KustoClusterResource> Update(WaitUntil waitUntil, KustoClusterPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, patch, ifMatch is null ? default(ETag?) : new ETag(ifMatch), cancellationToken);
        }

        /// <summary> Update a Kusto cluster. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<KustoClusterResource>> UpdateAsync(WaitUntil waitUntil, KustoClusterPatch patch, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, patch, ifMatch is null ? default(ETag?) : new ETag(ifMatch), cancellationToken).ConfigureAwait(false);
        }
    }
}
