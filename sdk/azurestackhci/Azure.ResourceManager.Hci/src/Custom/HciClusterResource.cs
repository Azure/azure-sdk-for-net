// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Hci
{
    public partial class HciClusterResource
    {
        /// <summary> List Offers available across publishers for the HCI Cluster (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<HciClusterOfferResource> GetHciClusterOffersAsync(string expand = default, CancellationToken cancellationToken = default)
            => GetByClusterAsync(expand, cancellationToken);

        /// <summary> List Offers available across publishers for the HCI Cluster (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<HciClusterOfferResource> GetHciClusterOffers(string expand = default, CancellationToken cancellationToken = default)
            => GetByCluster(expand, cancellationToken);

        // Backward-compat methods for old type aliases

        /// <summary> List Offers available across publishers for the HCI Cluster (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterOffers` moving forward.")]
        public virtual Pageable<OfferResource> GetOffers(string expand, CancellationToken cancellationToken)
            => throw new NotSupportedException("This method is now deprecated. Please use the new method `GetHciClusterOffers` moving forward.");

        /// <summary> List Offers available across publishers for the HCI Cluster (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterOffersAsync` moving forward.")]
        public virtual AsyncPageable<OfferResource> GetOffersAsync(string expand, CancellationToken cancellationToken)
            => throw new NotSupportedException("This method is now deprecated. Please use the new method `GetHciClusterOffersAsync` moving forward.");

        /// <summary> Gets a collection of HciClusterPublisherResources (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterPublishers` moving forward.")]
        [ForwardsClientCalls]
        public virtual PublisherCollection GetPublishers()
            => throw new NotSupportedException("This method is now deprecated. Please use the new method `GetHciClusterPublishers` moving forward.");

        /// <summary> Gets a HciClusterPublisherResource (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterPublisher` moving forward.")]
        [ForwardsClientCalls]
        public virtual Response<PublisherResource> GetPublisher(string publisherName, CancellationToken cancellationToken)
            => throw new NotSupportedException("This method is now deprecated. Please use the new method `GetHciClusterPublisher` moving forward.");

        /// <summary> Gets a HciClusterPublisherResource (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterPublisherAsync` moving forward.")]
        [ForwardsClientCalls]
        public virtual async Task<Response<PublisherResource>> GetPublisherAsync(string publisherName, CancellationToken cancellationToken)
            => throw new NotSupportedException("This method is now deprecated. Please use the new method `GetHciClusterPublisherAsync` moving forward.");

        /// <summary> Gets a collection of HciClusterUpdateResources (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdates` moving forward.")]
        [ForwardsClientCalls]
        public virtual UpdateCollection GetUpdates()
            => throw new NotSupportedException("This method is now deprecated. Please use the new method `GetHciClusterUpdates` moving forward.");

        /// <summary> Gets a HciClusterUpdateResource (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdate` moving forward.")]
        [ForwardsClientCalls]
        public virtual Response<UpdateResource> GetUpdate(string updateName, CancellationToken cancellationToken)
            => throw new NotSupportedException("This method is now deprecated. Please use the new method `GetHciClusterUpdate` moving forward.");

        /// <summary> Gets a HciClusterUpdateResource (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateAsync` moving forward.")]
        [ForwardsClientCalls]
        public virtual async Task<Response<UpdateResource>> GetUpdateAsync(string updateName, CancellationToken cancellationToken)
            => throw new NotSupportedException("This method is now deprecated. Please use the new method `GetHciClusterUpdateAsync` moving forward.");

        /// <summary> Gets the UpdateSummaryResource (backward-compat). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummary` moving forward.")]
        [ForwardsClientCalls]
        public virtual UpdateSummaryResource GetUpdateSummary()
            => throw new NotSupportedException("This method is now deprecated. Please use the new method `GetHciClusterUpdateSummary` moving forward.");
    }
}
