// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Redis.Models;

namespace Azure.ResourceManager.Redis
{
    public partial class RedisResource
    {
        /// <summary> Update an existing Redis cache. </summary>
        /// <param name="patch"> Parameters supplied to the Update Redis operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use another long-running operation with same method name instead.", false)]
        public virtual async Task<Response<RedisResource>> UpdateAsync(RedisPatch patch, CancellationToken cancellationToken = default)
        {
            var operation = await UpdateAsync(WaitUntil.Completed, patch, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }

        /// <summary> Update an existing Redis cache. </summary>
        /// <param name="patch"> Parameters supplied to the Update Redis operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.ObsoleteAttribute("This method is obsolete and will be removed in a future release. Please use another long-running operation with same method name instead.", false)]
        public virtual Response<RedisResource> Update(RedisPatch patch, CancellationToken cancellationToken = default)
        {
            var operation = Update(WaitUntil.Completed, patch, cancellationToken);
            return Response.FromValue(operation.Value, operation.GetRawResponse());
        }
    }
}
