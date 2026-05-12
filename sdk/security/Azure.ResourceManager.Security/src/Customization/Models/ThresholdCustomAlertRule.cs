// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Security.Models
{
    public partial class ThresholdCustomAlertRule
    {
        protected internal ThresholdCustomAlertRule(string ruleType, bool isEnabled, int minThreshold, int maxThreshold)
            : this(isEnabled, ruleType, minThreshold, maxThreshold)
        {
        }
    }
}
