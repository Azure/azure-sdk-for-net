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
    /// <summary> Backward-compat alias for HciClusterUpdateRunCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterUpdateRunCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class UpdateRunCollection : HciClusterUpdateRunCollection, IEnumerable<UpdateRunResource>, IAsyncEnumerable<UpdateRunResource>
    {
        /// <summary> Initializes a new instance of <see cref="UpdateRunCollection"/>. </summary>
        protected UpdateRunCollection()
        {
        }

        IEnumerator<UpdateRunResource> IEnumerable<UpdateRunResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator() as IEnumerator<UpdateRunResource>
                ?? throw new NotSupportedException("Use HciClusterUpdateRunCollection instead.");
        }

        IAsyncEnumerator<UpdateRunResource> IAsyncEnumerable<UpdateRunResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken) as IAsyncEnumerator<UpdateRunResource>
                ?? throw new NotSupportedException("Use HciClusterUpdateRunCollection instead.");
        }

        /// <summary> Get the Update run for a specified update. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Response<UpdateRunResource> Get(string updateRunName, CancellationToken cancellationToken)
        {
            var response = base.Get(updateRunName, cancellationToken);
            return Response.FromValue((UpdateRunResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Get the Update run for a specified update. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<Response<UpdateRunResource>> GetAsync(string updateRunName, CancellationToken cancellationToken)
        {
            var response = await base.GetAsync(updateRunName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((UpdateRunResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> List all Update runs. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Pageable<UpdateRunResource> GetAll(CancellationToken cancellationToken)
        {
            return PageableHelpers.CastPageable<HciClusterUpdateRunResource, UpdateRunResource>(base.GetAll(cancellationToken));
        }

        /// <summary> List all Update runs. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new AsyncPageable<UpdateRunResource> GetAllAsync(CancellationToken cancellationToken)
        {
            return PageableHelpers.CastAsyncPageable<HciClusterUpdateRunResource, UpdateRunResource>(base.GetAllAsync(cancellationToken));
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new NullableResponse<UpdateRunResource> GetIfExists(string updateRunName, CancellationToken cancellationToken)
        {
            var response = base.GetIfExists(updateRunName, cancellationToken);
            if (response.HasValue)
            {
                return new NullableResponseWrapper<UpdateRunResource>((UpdateRunResource)(object)response.Value, response.GetRawResponse());
            }
            return new NullableResponseWrapper<UpdateRunResource>(null, response.GetRawResponse());
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<NullableResponse<UpdateRunResource>> GetIfExistsAsync(string updateRunName, CancellationToken cancellationToken)
        {
            var response = await base.GetIfExistsAsync(updateRunName, cancellationToken).ConfigureAwait(false);
            if (response.HasValue)
            {
                return new NullableResponseWrapper<UpdateRunResource>((UpdateRunResource)(object)response.Value, response.GetRawResponse());
            }
            return new NullableResponseWrapper<UpdateRunResource>(null, response.GetRawResponse());
        }

        /// <summary> Put Update runs for a specified update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="data"> The update run data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<UpdateRunResource> CreateOrUpdate(WaitUntil waitUntil, string updateRunName, UpdateRunData data, CancellationToken cancellationToken)
        {
            var operation = base.CreateOrUpdate(waitUntil, updateRunName, data, cancellationToken);
            return new ArmOperationWrapper<HciClusterUpdateRunResource, UpdateRunResource>(operation);
        }

        /// <summary> Put Update runs for a specified update. </summary>
        /// <param name="waitUntil"> Wait until operation completes. </param>
        /// <param name="updateRunName"> The name of the update run. </param>
        /// <param name="data"> The update run data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<UpdateRunResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string updateRunName, UpdateRunData data, CancellationToken cancellationToken)
        {
            var operation = await base.CreateOrUpdateAsync(waitUntil, updateRunName, data, cancellationToken).ConfigureAwait(false);
            return new ArmOperationWrapper<HciClusterUpdateRunResource, UpdateRunResource>(operation);
        }
    }
}
