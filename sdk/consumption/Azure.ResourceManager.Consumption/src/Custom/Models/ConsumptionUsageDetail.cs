// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Consumption.Models
{
    public abstract partial class ConsumptionUsageDetail
    {
        /// <summary> Initializes a new instance of <see cref="ConsumptionUsageDetail"/>. </summary>
        protected ConsumptionUsageDetail()
        {
            Tags = new ChangeTrackingDictionary<string, string>();
        }
    }
}
