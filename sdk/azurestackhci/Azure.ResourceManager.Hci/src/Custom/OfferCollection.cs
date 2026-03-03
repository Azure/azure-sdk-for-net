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
    /// <summary> Backward-compat alias for HciClusterOfferCollection. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterOfferCollection` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class OfferCollection : HciClusterOfferCollection, IEnumerable<OfferResource>, IAsyncEnumerable<OfferResource>
    {
        /// <summary> Initializes a new instance of <see cref="OfferCollection"/>. </summary>
        protected OfferCollection()
        {
        }

        IEnumerator<OfferResource> IEnumerable<OfferResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator() as IEnumerator<OfferResource>
                ?? throw new NotSupportedException("Use HciClusterOfferCollection instead.");
        }

        IAsyncEnumerator<OfferResource> IAsyncEnumerable<OfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken) as IAsyncEnumerator<OfferResource>
                ?? throw new NotSupportedException("Use HciClusterOfferCollection instead.");
        }

        /// <summary>
        /// Get Offer resource details within a publisher of HCI Cluster.
        /// </summary>
        /// <param name="offerName"> The name of the offer. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Response<OfferResource> Get(string offerName, string expand, CancellationToken cancellationToken)
        {
            var response = base.Get(offerName, expand, cancellationToken);
            return Response.FromValue((OfferResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary>
        /// Get Offer resource details within a publisher of HCI Cluster.
        /// </summary>
        /// <param name="offerName"> The name of the offer. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new async Task<Response<OfferResource>> GetAsync(string offerName, string expand, CancellationToken cancellationToken)
        {
            var response = await base.GetAsync(offerName, expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((OfferResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary>
        /// List Offers available across publishers for the HCI Cluster.
        /// </summary>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Pageable<OfferResource> GetAll(string expand, CancellationToken cancellationToken)
        {
            return PageableHelpers.CastPageable<HciClusterOfferResource, OfferResource>(base.GetAll(expand, cancellationToken));
        }

        /// <summary>
        /// List Offers available across publishers for the HCI Cluster.
        /// </summary>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new AsyncPageable<OfferResource> GetAllAsync(string expand, CancellationToken cancellationToken)
        {
            return PageableHelpers.CastAsyncPageable<HciClusterOfferResource, OfferResource>(base.GetAllAsync(expand, cancellationToken));
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        /// <param name="offerName"> The name of the offer. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new NullableResponse<OfferResource> GetIfExists(string offerName, string expand, CancellationToken cancellationToken)
        {
            var response = base.GetIfExists(offerName, expand, cancellationToken);
            if (response.HasValue)
            {
                return new NullableResponseWrapper<OfferResource>((OfferResource)(object)response.Value, response.GetRawResponse());
            }
            return new NullableResponseWrapper<OfferResource>(null, response.GetRawResponse());
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        /// <param name="offerName"> The name of the offer. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new async Task<NullableResponse<OfferResource>> GetIfExistsAsync(string offerName, string expand, CancellationToken cancellationToken)
        {
            var response = await base.GetIfExistsAsync(offerName, expand, cancellationToken).ConfigureAwait(false);
            if (response.HasValue)
            {
                return new NullableResponseWrapper<OfferResource>((OfferResource)(object)response.Value, response.GetRawResponse());
            }
            return new NullableResponseWrapper<OfferResource>(null, response.GetRawResponse());
        }
    }
}
