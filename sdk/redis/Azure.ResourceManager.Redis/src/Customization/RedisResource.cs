// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Redis.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Redis
{
    // TODO: Remove these suppressions and custom methods when https://github.com/microsoft/typespec/issues/11609 is fixed.
    [CodeGenSuppress("GetRedisPatchScheduleAsync", typeof(RedisPatchScheduleDefaultName), typeof(CancellationToken))]
    [CodeGenSuppress("GetRedisPatchSchedule", typeof(RedisPatchScheduleDefaultName), typeof(CancellationToken))]
    public partial class RedisResource
    {
        /// <summary> Gets the patching schedule of a redis cache. </summary>
        /// <param name="defaultName"> The name of the RedisPatchSchedule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual async Task<Response<RedisPatchScheduleResource>> GetRedisPatchScheduleAsync(RedisPatchScheduleDefaultName defaultName, CancellationToken cancellationToken = default)
        {
            return await GetRedisPatchSchedules().GetAsync(defaultName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the patching schedule of a redis cache. </summary>
        /// <param name="defaultName"> The name of the RedisPatchSchedule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public virtual Response<RedisPatchScheduleResource> GetRedisPatchSchedule(RedisPatchScheduleDefaultName defaultName, CancellationToken cancellationToken = default)
        {
            return GetRedisPatchSchedules().Get(defaultName, cancellationToken);
        }

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
