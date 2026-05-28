// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.Confluent.Models
{
    /// <summary> Model factory for models. </summary>
    public partial class ArmConfluentModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="ConfluentOfferDetail"/>. </summary>
        /// <param name="publisherId"> Publisher Id. </param>
        /// <param name="id"> Offer Id. </param>
        /// <param name="planId"> Offer Plan Id. </param>
        /// <param name="planName"> Offer Plan Name. </param>
        /// <param name="termUnit"> Offer Plan Term unit. </param>
        /// <param name="status"> SaaS Offer Status. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ConfluentOfferDetail ConfluentOfferDetail(string publisherId, string id, string planId, string planName, string termUnit, ConfluentSaaSOfferStatus? status)
        {
            return new ConfluentOfferDetail(publisherId, id, planId, planName, termUnit, status);
        }
    }
}
