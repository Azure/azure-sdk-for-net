// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Batch
{
    // Backward-compatible overloads for CreateOrUpdate/CreateOrUpdateAsync.
    // The old API (v1.6.0) used separate ETag? and string parameters; the new generator uses MatchConditions.
    public partial class BatchAccountPoolCollection
    {
        /// <summary> Creates a new pool inside the specified account. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="poolName"> The pool name. This must be unique within the account. </param>
        /// <param name="data"> Additional parameters for pool creation. </param>
        /// <param name="ifMatch"> The entity state (ETag) version of the pool to update. A value of "*" can be used to apply the operation only if the pool already exists. If omitted, this operation will always be applied. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new pool to be created, but to prevent updating an existing pool. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<BatchAccountPoolResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string poolName, BatchAccountPoolData data, ETag? ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            MatchConditions matchConditions = null;
            if (ifMatch.HasValue || ifNoneMatch != null)
            {
                matchConditions = new MatchConditions();
                if (ifMatch.HasValue)
                {
                    matchConditions.IfMatch = ifMatch.Value;
                }
                if (ifNoneMatch != null)
                {
                    matchConditions.IfNoneMatch = new ETag(ifNoneMatch);
                }
            }
            return await CreateOrUpdateAsync(waitUntil, poolName, data, matchConditions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Creates a new pool inside the specified account. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="poolName"> The pool name. This must be unique within the account. </param>
        /// <param name="data"> Additional parameters for pool creation. </param>
        /// <param name="ifMatch"> The entity state (ETag) version of the pool to update. A value of "*" can be used to apply the operation only if the pool already exists. If omitted, this operation will always be applied. </param>
        /// <param name="ifNoneMatch"> Set to '*' to allow a new pool to be created, but to prevent updating an existing pool. Other values will be ignored. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<BatchAccountPoolResource> CreateOrUpdate(WaitUntil waitUntil, string poolName, BatchAccountPoolData data, ETag? ifMatch, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            MatchConditions matchConditions = null;
            if (ifMatch.HasValue || ifNoneMatch != null)
            {
                matchConditions = new MatchConditions();
                if (ifMatch.HasValue)
                {
                    matchConditions.IfMatch = ifMatch.Value;
                }
                if (ifNoneMatch != null)
                {
                    matchConditions.IfNoneMatch = new ETag(ifNoneMatch);
                }
            }
            return CreateOrUpdate(waitUntil, poolName, data, matchConditions, cancellationToken);
        }
    }
}
