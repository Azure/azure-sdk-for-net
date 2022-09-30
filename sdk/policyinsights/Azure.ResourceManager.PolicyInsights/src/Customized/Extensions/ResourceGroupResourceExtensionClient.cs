// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using Azure.Core;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights
{
    /// <summary> A class to add extension methods to ResourceGroupResource. </summary>
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEvents", typeof(PolicyEventType), typeof(string), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEventsAsync", typeof(PolicyEventType), typeof(string), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStates", typeof(PolicyStateType), typeof(string), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStatesAsync", typeof(PolicyStateType), typeof(string), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForResourceGroupLevelPolicyAssignmentPolicyStates", typeof(PolicyStateSummaryType), typeof(string), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForResourceGroupLevelPolicyAssignmentPolicyStatesAsync", typeof(PolicyStateSummaryType), typeof(string), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    internal partial class ResourceGroupResourceExtensionClient : ArmResource
    {
    }
}
