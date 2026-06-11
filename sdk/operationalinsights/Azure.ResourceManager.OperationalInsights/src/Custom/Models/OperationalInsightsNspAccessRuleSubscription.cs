// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    // Backward-compat justification: preserve the GA SDK's OperationalInsights-prefixed NSP access rule subscription model name.
    [CodeGenType("AccessRulePropertiesSubscription")]
    public partial class OperationalInsightsNspAccessRuleSubscription
    {
    }
}
