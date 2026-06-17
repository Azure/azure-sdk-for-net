// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: generated derived constructors call the GA base constructor argument order.
    public partial class ThresholdCustomAlertRule
    {
        internal ThresholdCustomAlertRule(string ruleType, bool isEnabled, int minThreshold, int maxThreshold) : base(ruleType, isEnabled)
        {
            MinThreshold = minThreshold;
            MaxThreshold = maxThreshold;
        }
    }
}
