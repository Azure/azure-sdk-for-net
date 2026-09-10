// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.DataFactory.Models;

namespace Azure.ResourceManager.DataFactory
{
    // Customization restores back-compat overloads on DataFactoryPrivateEndpointConnectionCollection where the MPG generator changed the
    // If-Match/If-None-Match header parameter type from `string` to `ETag?` (ARM common-types v6 models them
    // as `Azure.ETag`). Wrappers convert `string` -> `ETag?` for CreateOrUpdate/Get/Exists so existing call
    // sites compile unchanged; the on-the-wire request is identical. Marked [EditorBrowsable(Never)] to
    // discourage new usage of the legacy signatures.
    public partial class DataFactoryPrivateEndpointConnectionCollection
    {
        /// <summary> Creates or updates a private endpoint connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="content"> The content. </param>
        /// <param name="ifMatch"> ETag of the private endpoint connection entity. Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<DataFactoryPrivateEndpointConnectionResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string privateEndpointConnectionName, DataFactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch, CancellationToken cancellationToken = default)
        {
            return await CreateOrUpdateAsync(waitUntil, privateEndpointConnectionName, content, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Creates or updates a private endpoint connection. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="content"> The content. </param>
        /// <param name="ifMatch"> ETag of the private endpoint connection entity. Should only be specified for update, for which it should match existing entity or can be * for unconditional update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<DataFactoryPrivateEndpointConnectionResource> CreateOrUpdate(WaitUntil waitUntil, string privateEndpointConnectionName, DataFactoryPrivateEndpointConnectionCreateOrUpdateContent content, string ifMatch, CancellationToken cancellationToken = default)
        {
            return CreateOrUpdate(waitUntil, privateEndpointConnectionName, content, ifMatch != null ? new ETag(ifMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a private endpoint connection. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="ifNoneMatch"> ETag of the private endpoint connection entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPrivateEndpointConnectionResource>> GetAsync(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a private endpoint connection. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="ifNoneMatch"> ETag of the private endpoint connection entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPrivateEndpointConnectionResource> Get(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="ifNoneMatch"> ETag of the private endpoint connection entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await ExistsAsync(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks to see if the resource exists in azure. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="ifNoneMatch"> ETag of the private endpoint connection entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Exists(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="ifNoneMatch"> ETag of the private endpoint connection entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<DataFactoryPrivateEndpointConnectionResource>> GetIfExistsAsync(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetIfExistsAsync(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="ifNoneMatch"> ETag of the private endpoint connection entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<DataFactoryPrivateEndpointConnectionResource> GetIfExists(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetIfExists(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
