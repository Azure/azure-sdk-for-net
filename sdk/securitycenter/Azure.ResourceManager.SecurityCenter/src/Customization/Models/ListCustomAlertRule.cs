// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated list-rule subtypes call this intermediate constructor with wire-order parameters.
    // This overload bridges that order to the generated constructor.
    public partial class ListCustomAlertRule
    {
        /// <summary> Initializes a new instance of <see cref="ListCustomAlertRule"/>. </summary>
        /// <param name="ruleType"> The custom alert rule type. </param>
        /// <param name="isEnabled"> Whether the custom alert rule is enabled. </param>
        protected internal ListCustomAlertRule(string ruleType, bool isEnabled) : this(isEnabled, ruleType)
        {
        }
    }
}
