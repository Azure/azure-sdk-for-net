// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.ResourceManager.Qumulo.Models
{
    /// <summary>
    /// Marketplace details used to identify the Marketplace subscription for the Qumulo resource.
    /// </summary>
    public partial class QumuloMarketplaceDetails
    {
        /// <summary> Initializes a new instance of <see cref="QumuloMarketplaceDetails"/>. </summary>
        /// <param name="planId"> Plan Id. </param>
        /// <param name="offerId"> Offer Id. </param>
        /// <param name="publisherId"> Publisher Id. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="planId"/>, <paramref name="offerId"/> or <paramref name="publisherId"/> is null. </exception>
        public QumuloMarketplaceDetails(string planId, string offerId, string publisherId)
            : this(planId, offerId)
        {
            PublisherId = publisherId;
        }
    }
}
