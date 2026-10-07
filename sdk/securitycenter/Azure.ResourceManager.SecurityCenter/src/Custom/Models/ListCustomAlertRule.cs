// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: generated derived constructors call the GA base constructor argument order.
    public partial class ListCustomAlertRule
    {
        /// <summary> Initializes a new instance of <see cref="ListCustomAlertRule"/>. </summary>
        /// <param name="ruleType"> The type of the custom alert rule. </param>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        protected ListCustomAlertRule(string ruleType, bool isEnabled) : base(ruleType, isEnabled)
        {
        }
    }
}
