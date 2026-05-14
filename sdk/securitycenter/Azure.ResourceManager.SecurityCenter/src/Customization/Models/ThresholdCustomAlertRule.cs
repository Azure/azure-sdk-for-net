// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated time-window rule subtype calls the threshold constructor with wire-order parameters.
    // This overload bridges that order to the generated constructor.
    public partial class ThresholdCustomAlertRule
    {
        /// <summary> Initializes a new instance of <see cref="ThresholdCustomAlertRule"/>. </summary>
        /// <param name="ruleType"> The custom alert rule type. </param>
        /// <param name="isEnabled"> Whether the custom alert rule is enabled. </param>
        /// <param name="minThreshold"> The minimum threshold. </param>
        /// <param name="maxThreshold"> The maximum threshold. </param>
        protected internal ThresholdCustomAlertRule(string ruleType, bool isEnabled, int minThreshold, int maxThreshold)
            : this(isEnabled, ruleType, minThreshold, maxThreshold)
        {
        }
    }
}
