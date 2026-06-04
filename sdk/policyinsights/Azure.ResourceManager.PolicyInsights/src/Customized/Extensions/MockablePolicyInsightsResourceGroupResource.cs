// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    // GA back-compat shims for resource-group-scoped query/summarize/trigger/check
    // operations. See MockablePolicyInsightsSubscriptionResource.cs for rationale.
    public partial class MockablePolicyInsightsResourceGroupResource
    {
        /// <summary> Queries policy events for the resources under the resource group. </summary>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForResourceGroupAsync(policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events for the resources under the resource group. </summary>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForResourceGroup(policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the resource group. </summary>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForResourceGroupAsync(policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the resource group. </summary>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForResourceGroup(policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy tracked resources under the resource group. </summary>
        public virtual AsyncPageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForResourceGroupAsync(policyTrackedResourceType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy tracked resources under the resource group. </summary>
        public virtual Pageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForResourceGroup(policyTrackedResourceType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states for the resources under the resource group. </summary>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsAsyncPageableAsync(ct => SummarizeForResourceGroupAsync(policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        /// <summary> Summarizes policy states for the resources under the resource group. </summary>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsPageable(ct => SummarizeForResourceGroup(policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        /// <summary> Triggers a policy evaluation scan for all the resources under the resource group. </summary>
        public virtual Task<ArmOperation> TriggerPolicyStateEvaluationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => TriggerResourceGroupEvaluationAsync(waitUntil, cancellationToken);

        /// <summary> Triggers a policy evaluation scan for all the resources under the resource group. </summary>
        public virtual ArmOperation TriggerPolicyStateEvaluation(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => TriggerResourceGroupEvaluation(waitUntil, cancellationToken);

        /// <summary> Checks what restrictions Azure Policy will place on a resource within the resource group. </summary>
        public virtual Task<Response<CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(CheckPolicyRestrictionsContent content, CancellationToken cancellationToken = default)
            => CheckAtResourceGroupScopeAsync(content, cancellationToken);

        /// <summary> Checks what restrictions Azure Policy will place on a resource within the resource group. </summary>
        public virtual Response<CheckPolicyRestrictionsResult> CheckPolicyRestrictions(CheckPolicyRestrictionsContent content, CancellationToken cancellationToken = default)
            => CheckAtResourceGroupScope(content, cancellationToken);
    }
}
