// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Consumption.Models
{
    public abstract partial class ConsumptionReservationRecommendation
    {
        /// <summary> Initializes a new instance of <see cref="ConsumptionReservationRecommendation"/>. </summary>
        protected ConsumptionReservationRecommendation()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }
    }
}
