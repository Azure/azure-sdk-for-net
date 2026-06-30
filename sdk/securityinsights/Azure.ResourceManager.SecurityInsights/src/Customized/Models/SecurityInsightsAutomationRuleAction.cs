// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // Keep the GA SDK surface inheritable; generated code only has discriminator constructors.
    [CodeGenSuppress("SecurityInsightsAutomationRuleAction")]
    public abstract partial class SecurityInsightsAutomationRuleAction
    {
        /// <summary> Initializes a new instance of <see cref="SecurityInsightsAutomationRuleAction"/>. </summary>
        protected SecurityInsightsAutomationRuleAction()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SecurityInsightsAutomationRuleAction"/>. </summary>
        /// <param name="order"></param>
        protected SecurityInsightsAutomationRuleAction(int order)
        {
            Order = order;
        }
    }
}
