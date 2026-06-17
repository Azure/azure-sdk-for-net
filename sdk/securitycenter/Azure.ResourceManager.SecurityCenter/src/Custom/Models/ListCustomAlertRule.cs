// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: generated derived constructors call the GA base constructor argument order.
    public partial class ListCustomAlertRule
    {
        internal ListCustomAlertRule(string ruleType, bool isEnabled) : base(ruleType, isEnabled)
        {
        }
    }
}
