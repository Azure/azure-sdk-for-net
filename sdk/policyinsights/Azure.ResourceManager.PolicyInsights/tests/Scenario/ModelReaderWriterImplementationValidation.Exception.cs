// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.ResourceManager.TestFramework
{
    public sealed partial class ModelReaderWriterImplementationValidation
    {
        public ModelReaderWriterImplementationValidation()
        {
            ExceptionList = new[]
            {
                "Azure.ResourceManager.PolicyInsights.Models.PolicyQuerySettings",
                "Azure.ResourceManager.PolicyInsights.Models.ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions",
                "Azure.ResourceManager.PolicyInsights.Models.ResourceGroupResourceGetQueryResultsForResourceGroupComponentPolicyStatesOptions",
                "Azure.ResourceManager.PolicyInsights.Models.ResourceGroupResourceGetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesOptions",
                "Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForPolicyDefinitionComponentPolicyStatesOptions",
                "Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForSubscriptionComponentPolicyStatesOptions",
                "Azure.ResourceManager.PolicyInsights.Models.SubscriptionResourceGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesOptions"
            };
        }
    }
}
