// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Compatibility customization: the generator emits this discriminator constructor as private protected, but the GA API exposes it as protected for derived custom alert rule types.
    public abstract partial class CustomAlertRule
    {
        /// <summary> Initializes a new instance of <see cref="CustomAlertRule"/>. </summary>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        protected CustomAlertRule(bool isEnabled) : this(default(string), isEnabled)
        {
        }

        /// <summary> Initializes a new instance of <see cref="CustomAlertRule"/>. </summary>
        /// <param name="ruleType"> The type of the custom alert rule. </param>
        /// <param name="isEnabled"> Status of the custom alert. </param>
        protected CustomAlertRule(string ruleType, bool isEnabled)
        {
            RuleType = ruleType;
            IsEnabled = isEnabled;
            _additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
        }
    }
}
