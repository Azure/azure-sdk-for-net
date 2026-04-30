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
            throw new NotSupportedException("This type is obsolete. Please use HciClusterOfferCollection instead.");
        }

        IAsyncEnumerator<OfferResource> IAsyncEnumerable<OfferResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterOfferCollection instead.");
        }

        /// <summary>
        /// Get Offer resource details within a publisher of HCI Cluster.
        /// </summary>
        /// <param name="offerName"> The name of the offer. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Response<OfferResource> Get(string offerName, string expand, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterOfferCollection instead.");
        }

        /// <summary>
        /// Get Offer resource details within a publisher of HCI Cluster.
        /// </summary>
        /// <param name="offerName"> The name of the offer. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<Response<OfferResource>> GetAsync(string offerName, string expand, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterOfferCollection instead.");
        }

        /// <summary>
        /// List Offers available across publishers for the HCI Cluster.
        /// </summary>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Pageable<OfferResource> GetAll(string expand, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterOfferCollection instead.");
        }

        /// <summary>
        /// List Offers available across publishers for the HCI Cluster.
        /// </summary>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new AsyncPageable<OfferResource> GetAllAsync(string expand, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterOfferCollection instead.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        /// <param name="offerName"> The name of the offer. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new NullableResponse<OfferResource> GetIfExists(string offerName, string expand, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterOfferCollection instead.");
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// </summary>
        /// <param name="offerName"> The name of the offer. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<NullableResponse<OfferResource>> GetIfExistsAsync(string offerName, string expand, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterOfferCollection instead.");
        }
    }
}
