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
    /// <summary> Backward-compat alias for HciClusterOfferResource. </summary>
    [Obsolete("This class is now deprecated. Please use the new class `HciClusterOfferResource` moving forward.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class OfferResource : HciClusterOfferResource
    {
        /// <summary> Gets the resource type for the operations. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static new ResourceType ResourceType => HciClusterOfferResource.ResourceType;

        /// <summary> Gets the data representing this Feature. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new OfferData Data => (OfferData)(object)base.Data;

        /// <summary> Initializes a new instance of <see cref="OfferResource"/>. </summary>
        protected OfferResource()
        {
        }

        /// <summary>
        /// Get Offer resource details within a publisher of HCI Cluster.
        /// </summary>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new Response<OfferResource> Get(string expand, CancellationToken cancellationToken)
        {
            var response = base.Get(expand, cancellationToken);
            return Response.FromValue((OfferResource)(object)response.Value, response.GetRawResponse());
        }

        /// <summary>
        /// Get Offer resource details within a publisher of HCI Cluster.
        /// </summary>
        /// <param name="expand"> Specify $expand=content,contentVersion to populate additional fields related to the marketplace offer. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual new async Task<Response<OfferResource>> GetAsync(string expand, CancellationToken cancellationToken)
        {
            var response = await base.GetAsync(expand, cancellationToken).ConfigureAwait(false);
            return Response.FromValue((OfferResource)(object)response.Value, response.GetRawResponse());
        }
    }
}
