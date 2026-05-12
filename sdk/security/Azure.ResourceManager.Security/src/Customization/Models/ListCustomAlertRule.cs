// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Security.Models
{
    // Generated list-rule subtypes call this intermediate constructor with wire-order parameters.
    // This overload bridges that order to the generated constructor.
    public partial class ListCustomAlertRule
    {
        protected internal ListCustomAlertRule(string ruleType, bool isEnabled) : this(isEnabled, ruleType)
        {
        }
    }
}
