// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEvents", typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEventsAsync", typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStates", typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStatesAsync", typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForResourceGroupLevelPolicyAssignmentPolicyStates", typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForResourceGroupLevelPolicyAssignmentPolicyStatesAsync", typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    public partial class PolicyInsightsResourceGroupMockingExtension : ArmResource
    {
    }
}
