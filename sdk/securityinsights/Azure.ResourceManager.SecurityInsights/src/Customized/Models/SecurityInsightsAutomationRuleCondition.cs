// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // Keep the GA SDK surface inheritable; generated code only has a discriminator constructor.
    [CodeGenSuppress("SecurityInsightsAutomationRuleCondition")]
    public abstract partial class SecurityInsightsAutomationRuleCondition
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsightsAutomationRuleCondition"/>. </summary>
        protected SecurityInsightsAutomationRuleCondition()
        {
        }
    }
}
