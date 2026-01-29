// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.Qumulo.Models
{
    /// <summary>
    /// Marketplace details used to identify the Marketplace subscription for the Qumulo resource.
    /// </summary>
    public partial class MarketplaceDetails
    {
        /// <summary> Initializes a new instance of <see cref="MarketplaceDetails"/>. </summary>
        /// <param name="planId"> Plan Id. </param>
        /// <param name="offerId"> Offer Id. </param>
        /// <param name="publisherId"> Publisher Id. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="planId"/>, <paramref name="offerId"/> or <paramref name="publisherId"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MarketplaceDetails(string planId, string offerId, string publisherId)
            : this(planId, offerId)
        {
            PublisherId = publisherId;
        }

        /// <summary>
        /// Marketplace subscription status.
        /// Please use <see cref="QumuloMarketplaceSubscriptionStatus"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MarketplaceSubscriptionStatus? MarketplaceSubscriptionStatus => QumuloMarketplaceSubscriptionStatus?.ToString().ToMarketplaceSubscriptionStatus();
    }
}
