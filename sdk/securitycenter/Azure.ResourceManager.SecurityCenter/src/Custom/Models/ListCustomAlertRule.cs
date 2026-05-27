// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: generated derived constructors still need the GA base constructor argument order.
    public partial class ListCustomAlertRule
    {
        private protected ListCustomAlertRule(string ruleType, bool isEnabled) : base(ruleType, isEnabled)
        {
        }
    }
}
