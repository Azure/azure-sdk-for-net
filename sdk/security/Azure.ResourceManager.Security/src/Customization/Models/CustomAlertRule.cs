// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Security.Models
{
    public abstract partial class CustomAlertRule
    {
        protected internal CustomAlertRule(string ruleType, bool isEnabled) : this(isEnabled, ruleType)
        {
        }
    }
}
