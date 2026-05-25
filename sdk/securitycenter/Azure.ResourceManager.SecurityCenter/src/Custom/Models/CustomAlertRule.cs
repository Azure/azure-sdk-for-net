// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using CodeGenSuppressAttribute = Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppressAttribute;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [CodeGenSuppress("CustomAlertRule", typeof(string), typeof(bool))]
    public abstract partial class CustomAlertRule
    {
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
