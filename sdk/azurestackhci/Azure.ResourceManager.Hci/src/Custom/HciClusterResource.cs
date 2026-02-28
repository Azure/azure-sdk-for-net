// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;

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
    }
}
