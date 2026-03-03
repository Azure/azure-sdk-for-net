// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterUpdateCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateCollection : HciClusterUpdateCollection, IEnumerable<UpdateResource>, IAsyncEnumerable<UpdateResource>
    {
        /// <summary> Initializes a new instance of <see cref="UpdateCollection"/>. </summary>
        protected UpdateCollection()
        {
        }

        IEnumerator<UpdateResource> IEnumerable<UpdateResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator() as IEnumerator<UpdateResource>
                ?? throw new NotSupportedException("Use HciClusterUpdateCollection instead.");
        }

        IAsyncEnumerator<UpdateResource> IAsyncEnumerable<UpdateResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken) as IAsyncEnumerator<UpdateResource>
                ?? throw new NotSupportedException("Use HciClusterUpdateCollection instead.");
        }

        /// <summary> Get specified Update. </summary>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Response<UpdateResource> Get(string updateName, CancellationToken cancellationToken)
        {
            var response = base.Get(updateName, cancellationToken);
            return Response.FromValue((UpdateResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Get specified Update. </summary>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new async Task<Response<UpdateResource>> GetAsync(string updateName, CancellationToken cancellationToken)
        {
            var response = await base.GetAsync(updateName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((UpdateResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> List all Updates. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Pageable<UpdateResource> GetAll(CancellationToken cancellationToken)
        {
            return PageableHelpers.CastPageable<HciClusterUpdateResource, UpdateResource>(base.GetAll(cancellationToken));
        }

        /// <summary> List all Updates. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new AsyncPageable<UpdateResource> GetAllAsync(CancellationToken cancellationToken)
        {
            return PageableHelpers.CastAsyncPageable<HciClusterUpdateResource, UpdateResource>(base.GetAllAsync(cancellationToken));
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new NullableResponse<UpdateResource> GetIfExists(string updateName, CancellationToken cancellationToken)
        {
            var response = base.GetIfExists(updateName, cancellationToken);
            if (response.HasValue)
            {
                return new NullableResponseWrapper<UpdateResource>((UpdateResource)(object)response.Value, response.GetRawResponse());
            }
            return new NullableResponseWrapper<UpdateResource>(null, response.GetRawResponse());
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new async Task<NullableResponse<UpdateResource>> GetIfExistsAsync(string updateName, CancellationToken cancellationToken)
        {
            var response = await base.GetIfExistsAsync(updateName, cancellationToken).ConfigureAwait(false);
            if (response.HasValue)
            {
                return new NullableResponseWrapper<UpdateResource>((UpdateResource)(object)response.Value, response.GetRawResponse());
            }
            return new NullableResponseWrapper<UpdateResource>(null, response.GetRawResponse());
        }

        /// <summary> Put specified Update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="data"> The update data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ArmOperation<UpdateResource> CreateOrUpdate(WaitUntil waitUntil, string updateName, UpdateData data, CancellationToken cancellationToken)
        {
            var operation = base.CreateOrUpdate(waitUntil, updateName, data, cancellationToken);
            return new ArmOperationWrapper<HciClusterUpdateResource, UpdateResource>(operation);
        }

        /// <summary> Put specified Update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="updateName"> The name of the update. </param>
        /// <param name="data"> The update data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<ArmOperation<UpdateResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string updateName, UpdateData data, CancellationToken cancellationToken)
        {
            var operation = await base.CreateOrUpdateAsync(waitUntil, updateName, data, cancellationToken).ConfigureAwait(false);
            return new ArmOperationWrapper<HciClusterUpdateResource, UpdateResource>(operation);
        }
    }
}
