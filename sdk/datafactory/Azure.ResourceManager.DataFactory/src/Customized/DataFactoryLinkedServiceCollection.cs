// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.DataFactory
{
    // Customization restores back-compat overloads on DataFactoryLinkedServiceCollection where the MPG generator changed the
    // If-Match/If-None-Match header parameter type from `string` to `ETag?` (ARM common-types v6 models them
    // as `Azure.ETag`). Wrappers convert `string` -> `ETag?` for CreateOrUpdate/Get/Exists so existing call
    // sites compile unchanged; the on-the-wire request is identical. Marked [EditorBrowsable(Never)] to
    // discourage new usage of the legacy signatures.
    public partial class DataFactoryLinkedServiceCollection
    {
        /// <summary> Creates or updates a linked service. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="data"> The linked service definition. </param>
        /// <param name="ifMatch"> ETag of the linkedService entity. Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryLinkedServiceResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string linkedServiceName, DataFactoryLinkedServiceData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, linkedServiceName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Creates or updates a linked service. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="data"> The linked service definition. </param>
        /// <param name="ifMatch"> ETag of the linkedService entity. Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryLinkedServiceResource> CreateOrUpdate(WaitUntil waitUntil, string linkedServiceName, DataFactoryLinkedServiceData data, string ifMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, linkedServiceName, data, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a linked service. </summary>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="ifNoneMatch"> ETag of the linkedService entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryLinkedServiceResource>> GetAsync(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a linked service. </summary>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="ifNoneMatch"> ETag of the linkedService entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryLinkedServiceResource> Get(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="ifNoneMatch"> ETag of the linkedService entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="ifNoneMatch"> ETag of the linkedService entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Exists(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="ifNoneMatch"> ETag of the linkedService entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DataFactoryLinkedServiceResource>> GetIfExistsAsync(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="ifNoneMatch"> ETag of the linkedService entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DataFactoryLinkedServiceResource> GetIfExists(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetIfExists(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
