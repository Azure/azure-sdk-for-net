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
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherCollection instead.");
        }

        IAsyncEnumerator<PublisherResource> IAsyncEnumerable<PublisherResource>.GetAsyncEnumerator(System.Threading.CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherCollection instead.");
        }

        /// <summary> Get Publisher resource details within a HCI Cluster. </summary>
        /// <param name="publisherName"> The name of the publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Response<PublisherResource> Get(string publisherName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherCollection instead.");
        }

        /// <summary> Get Publisher resource details within a HCI Cluster. </summary>
        /// <param name="publisherName"> The name of the publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<Response<PublisherResource>> GetAsync(string publisherName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherCollection instead.");
        }

        /// <summary> List Publishers available across publishers for the HCI Cluster. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Pageable<PublisherResource> GetAll(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherCollection instead.");
        }

        /// <summary> List Publishers available across publishers for the HCI Cluster. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new AsyncPageable<PublisherResource> GetAllAsync(CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherCollection instead.");
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="publisherName"> The name of the publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new NullableResponse<PublisherResource> GetIfExists(string publisherName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherCollection instead.");
        }

        /// <summary> Tries to get details for this resource from the service. </summary>
        /// <param name="publisherName"> The name of the publisher. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<NullableResponse<PublisherResource>> GetIfExistsAsync(string publisherName, CancellationToken cancellationToken)
        {
            throw new NotSupportedException("This type is obsolete. Please use HciClusterPublisherCollection instead.");
        }
    }
}
