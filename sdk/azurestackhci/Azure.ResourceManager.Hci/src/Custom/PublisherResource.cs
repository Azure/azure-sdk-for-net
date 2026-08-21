// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Backward-compat alias for HciClusterPublisherResource. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterPublisherResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class PublisherResource : HciClusterPublisherResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly new ResourceType ResourceType = HciClusterPublisherResource.ResourceType;

        /// <summary> Gets the data representing this Feature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new PublisherData Data => throw new NotSupportedException("This class is obsolete. Please use HciClusterPublisherResource instead.");

        /// <summary> Initializes a new instance of <see cref="PublisherResource"/>. </summary>
        protected PublisherResource()
        {
        }

        /// <summary> Get Publisher resource details within a HCI Cluster. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Response<PublisherResource> Get(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherResource instead.");
        }

        /// <summary> Get Publisher resource details within a HCI Cluster. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<Response<PublisherResource>> GetAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherResource instead.");
        }

        /// <summary> Gets a collection of HciClusterOfferResources in the HciClusterPublisher. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual OfferCollection GetOffers()
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherResource instead.");
        }

        /// <summary> Gets a Offer resource. </summary>
        /// <param name="offerName"> The name of the offer. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual Response<OfferResource> GetOffer(string offerName, string expand, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherResource instead.");
        }

        /// <summary> Gets a Offer resource. </summary>
        /// <param name="offerName"> The name of the offer. </param>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [ForwardsClientCalls]
        public virtual async Task<Response<OfferResource>> GetOfferAsync(string offerName, string expand, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherResource instead.");
        }
    }
}
