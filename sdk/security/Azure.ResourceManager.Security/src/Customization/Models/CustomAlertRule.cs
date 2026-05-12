// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Security.Models
{
    // Generated discriminator subtypes call the base constructor with wire-order parameters.
    // This overload bridges that order to the generated base constructor.
    public abstract partial class CustomAlertRule
    {
        protected internal CustomAlertRule(string ruleType, bool isEnabled) : this(isEnabled, ruleType)
        {
        }
    }
}
