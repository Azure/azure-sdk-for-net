// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Security.Models
{
    public partial class ListCustomAlertRule
    {
        protected internal ListCustomAlertRule(string ruleType, bool isEnabled) : this(isEnabled, ruleType)
        {
        }
    }
}
