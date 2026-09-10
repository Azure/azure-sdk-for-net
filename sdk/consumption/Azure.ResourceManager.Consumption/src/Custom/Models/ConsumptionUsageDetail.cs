// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Consumption.Models
{
    // Same rationale as ConsumptionReservationRecommendation: provide a parameterless protected ctor
    // that initializes Tags to an empty ChangeTrackingDictionary, matching the shipped v1.x surface.
    public abstract partial class ConsumptionUsageDetail
    {
        /// <summary> Initializes a new instance of <see cref="ConsumptionUsageDetail"/>. </summary>
        protected ConsumptionUsageDetail()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }
    }
}
