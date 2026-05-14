// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated discriminator subtypes call the base constructor with wire-order parameters.
    // This overload bridges that order to the generated base constructor.
    public abstract partial class CustomAlertRule
    {
        /// <summary> Initializes a new instance of <see cref="CustomAlertRule"/>. </summary>
        /// <param name="ruleType"> The custom alert rule type. </param>
        /// <param name="isEnabled"> Whether the custom alert rule is enabled. </param>
        protected internal CustomAlertRule(string ruleType, bool isEnabled) : this(isEnabled, ruleType)
        {
        }
    }
}
