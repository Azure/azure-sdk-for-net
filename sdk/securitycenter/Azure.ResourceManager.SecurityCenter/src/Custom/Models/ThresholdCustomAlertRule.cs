// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: the GA API exposes the discriminator constructor as protected for derived custom alert rule types.
    public partial class ThresholdCustomAlertRule
    {
        /// <summary> Initializes a new instance of <see cref="ThresholdCustomAlertRule"/>. </summary>
        /// <param name="ruleType"> The type of the custom alert rule. </param>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        /// <param name="minThreshold"> The minimum threshold. </param>
        /// <param name="maxThreshold"> The maximum threshold. </param>
        protected ThresholdCustomAlertRule(string ruleType, bool isEnabled, int minThreshold, int maxThreshold) : base(ruleType, isEnabled)
        {
            MinThreshold = minThreshold;
            MaxThreshold = maxThreshold;
        }
    }
}
