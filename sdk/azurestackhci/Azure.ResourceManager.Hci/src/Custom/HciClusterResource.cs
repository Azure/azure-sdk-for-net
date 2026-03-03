// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Hci
{
    public partial class HciClusterResource
    {
        /// <summary> List Offers available across publishers for the HCI Cluster (backward-compat). </summary>
        [Obsolete("This method is now deprecated. Please use GetByCluster instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<HciClusterOfferResource> GetHciClusterOffersAsync(string expand = default, CancellationToken cancellationToken = default)
            => GetByClusterAsync(expand, cancellationToken);

        /// <summary> List Offers available across publishers for the HCI Cluster (backward-compat). </summary>
        [Obsolete("This method is now deprecated. Please use GetByCluster instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<HciClusterOfferResource> GetHciClusterOffers(string expand = default, CancellationToken cancellationToken = default)
            => GetByCluster(expand, cancellationToken);

        // Backward-compat methods for old type aliases

        /// <summary> List Offers available across publishers for the HCI Cluster (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<OfferResource> GetOffers(string expand, CancellationToken cancellationToken)
            => PageableHelpers.CastPageable<HciClusterOfferResource, OfferResource>(GetByCluster(expand, cancellationToken));

        /// <summary> List Offers available across publishers for the HCI Cluster (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<OfferResource> GetOffersAsync(string expand, CancellationToken cancellationToken)
            => PageableHelpers.CastAsyncPageable<HciClusterOfferResource, OfferResource>(GetByClusterAsync(expand, cancellationToken));

        /// <summary> Gets a collection of HciClusterPublisherResources (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual PublisherCollection GetPublishers()
            => (PublisherCollection)(object)GetHciClusterPublishers();

        /// <summary> Gets a HciClusterPublisherResource (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PublisherResource> GetPublisher(string publisherName, CancellationToken cancellationToken)
        {
            var response = GetHciClusterPublisher(publisherName, cancellationToken);
            return Response.FromValue((PublisherResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Gets a HciClusterPublisherResource (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<PublisherResource>> GetPublisherAsync(string publisherName, CancellationToken cancellationToken)
        {
            var response = await GetHciClusterPublisherAsync(publisherName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((PublisherResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Gets a collection of HciClusterUpdateResources (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual UpdateCollection GetUpdates()
            => (UpdateCollection)(object)GetHciClusterUpdates();

        /// <summary> Gets a HciClusterUpdateResource (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<UpdateResource> GetUpdate(string updateName, CancellationToken cancellationToken)
        {
            var response = GetHciClusterUpdate(updateName, cancellationToken);
            return Response.FromValue((UpdateResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Gets a HciClusterUpdateResource (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<UpdateResource>> GetUpdateAsync(string updateName, CancellationToken cancellationToken)
        {
            var response = await GetHciClusterUpdateAsync(updateName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((UpdateResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary> Gets the UpdateSummaryResource (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual UpdateSummaryResource GetUpdateSummary()
            => (UpdateSummaryResource)(object)GetHciClusterUpdateSummary();
    }
}
