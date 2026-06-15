// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    // Backward-compat justification: preserve the generated access rule subscription model with an OperationalInsights-prefixed name.
    [CodeGenType("AccessRulePropertiesSubscription")]
    public partial class OperationalInsightsNetworkSecurityPerimeterAccessRuleSubscription
    {
    }
}
