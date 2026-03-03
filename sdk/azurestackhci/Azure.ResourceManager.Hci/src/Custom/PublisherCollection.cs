// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterPublisherCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterPublisherCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PublisherCollection : HciClusterPublisherCollection, IEnumerable<PublisherResource>, IAsyncEnumerable<PublisherResource>
    {
        /// <summary> Initializes a new instance of <see cref="PublisherCollection"/>. </summary>
        protected PublisherCollection()
        {
        }

        IEnumerator<PublisherResource> IEnumerable<PublisherResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator() as IEnumerator<PublisherResource>
                ?? throw new NotSupportedException("Use HciClusterPublisherCollection instead.");
        }

        IAsyncEnumerator<PublisherResource> IAsyncEnumerable<PublisherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken) as IAsyncEnumerator<PublisherResource>
                ?? throw new NotSupportedException("Use HciClusterPublisherCollection instead.");
        }

        /// <summary> Get Publisher resource details within a HCI Cluster. </summary>
        /// <param name="publisherName"> The name of the publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Response<PublisherResource> Get(string publisherName, CancellationToken cancellationToken)
        {
            var response = base.Get(publisherName, cancellationToken);
            return Response.FromValue((PublisherResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Get Publisher resource details within a HCI Cluster. </summary>
        /// <param name="publisherName"> The name of the publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new async Task<Response<PublisherResource>> GetAsync(string publisherName, CancellationToken cancellationToken)
        {
            var response = await base.GetAsync(publisherName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((PublisherResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> List Publishers available across publishers for the HCI Cluster. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Pageable<PublisherResource> GetAll(CancellationToken cancellationToken)
        {
            return PageableHelpers.CastPageable<HciClusterPublisherResource, PublisherResource>(base.GetAll(cancellationToken));
        }

        /// <summary> List Publishers available across publishers for the HCI Cluster. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new AsyncPageable<PublisherResource> GetAllAsync(CancellationToken cancellationToken)
        {
            return PageableHelpers.CastAsyncPageable<HciClusterPublisherResource, PublisherResource>(base.GetAllAsync(cancellationToken));
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="publisherName"> The name of the publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new NullableResponse<PublisherResource> GetIfExists(string publisherName, CancellationToken cancellationToken)
        {
            var response = base.GetIfExists(publisherName, cancellationToken);
            if (response.HasValue)
            {
                return new NullableResponseWrapper<PublisherResource>((PublisherResource)(object)response.Value, response.GetRawResponse());
            }
            return new NullableResponseWrapper<PublisherResource>(null, response.GetRawResponse());
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="publisherName"> The name of the publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new async Task<NullableResponse<PublisherResource>> GetIfExistsAsync(string publisherName, CancellationToken cancellationToken)
        {
            var response = await base.GetIfExistsAsync(publisherName, cancellationToken).ConfigureAwait(false);
            if (response.HasValue)
            {
                return new NullableResponseWrapper<PublisherResource>((PublisherResource)(object)response.Value, response.GetRawResponse());
            }
            return new NullableResponseWrapper<PublisherResource>(null, response.GetRawResponse());
        }
    }
}
