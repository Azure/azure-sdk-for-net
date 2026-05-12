// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Security.Models
{
    // Generated time-window rule subtype calls the threshold constructor with wire-order parameters.
    // This overload bridges that order to the generated constructor.
    public partial class ThresholdCustomAlertRule
    {
        protected internal ThresholdCustomAlertRule(string ruleType, bool isEnabled, int minThreshold, int maxThreshold)
            : this(isEnabled, ruleType, minThreshold, maxThreshold)
        {
        }
    }
}
