// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DataFactory
{
    // Customization on DataFactoryTriggerResource restores upstream back-compat surfaces dropped by
    // MPG generation:
    //  1) `string ifNoneMatch` / `string ifMatch` overloads of Get/Update. The MPG generator types the
    //     ARM common-types v6 If-None-Match / If-Match headers as `Azure.ETag?`; these wrappers accept
    //     `string` and forward to the ETag overload so existing call sites compile unchanged. The
    //     on-the-wire request is identical.
    //  2) `Pageable<T>` / `AsyncPageable<T>` for trigger runs query operations (when present). The
    //     spec marks these operations as paged via `x-ms-pageable` in swagger but the TypeSpec
    //     migration loses that marker, so the MPG generator emits a single non-paged response.
    public partial class DataFactoryTriggerResource
    {
        /// <summary> Gets a trigger. </summary>
        /// <param name="ifNoneMatch"> ETag of the trigger entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryTriggerResource>> GetAsync(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a trigger. </summary>
        /// <param name="ifNoneMatch"> ETag of the trigger entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryTriggerResource> Get(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Updates a trigger. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The trigger definition. </param>
        /// <param name="ifMatch"> ETag of the trigger entity. Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryTriggerResource>> UpdateAsync(WaitUntil waitUntil, DataFactoryTriggerData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await UpdateAsync(waitUntil, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Updates a trigger. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> The trigger definition. </param>
        /// <param name="ifMatch"> ETag of the trigger entity. Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryTriggerResource> Update(WaitUntil waitUntil, DataFactoryTriggerData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return Update(waitUntil, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }
    }
}
