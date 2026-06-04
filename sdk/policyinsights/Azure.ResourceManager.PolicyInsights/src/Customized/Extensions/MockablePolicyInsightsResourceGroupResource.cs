// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    // GA back-compat shims for resource-group-scoped query/summarize/trigger/check
    // operations. See MockablePolicyInsightsSubscriptionResource.cs for rationale.
    public partial class MockablePolicyInsightsResourceGroupResource
    {
        private MockablePolicyInsightsArmClient ArmMockable
            => Client.GetCachedClient(c => new MockablePolicyInsightsArmClient(c, ResourceIdentifier.Root));

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

        // === Resource-group-level PolicyAssignment shims ===

        /// <summary> Queries policy events for the resources under the resource-group-level policy assignment. </summary>
        public virtual AsyncPageable<PolicyEvent> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEventsAsync(string policyAssignmentName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEventsAsync(BuildPolicyAssignmentScope(policyAssignmentName), policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events for the resources under the resource-group-level policy assignment. </summary>
        public virtual Pageable<PolicyEvent> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEvents(string policyAssignmentName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEvents(BuildPolicyAssignmentScope(policyAssignmentName), policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the resource-group-level policy assignment. </summary>
        public virtual AsyncPageable<PolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStatesAsync(string policyAssignmentName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStatesAsync(BuildPolicyAssignmentScope(policyAssignmentName), policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the resource-group-level policy assignment. </summary>
        public virtual Pageable<PolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStates(string policyAssignmentName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStates(BuildPolicyAssignmentScope(policyAssignmentName), policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states for the resources under the resource-group-level policy assignment. </summary>
        public virtual AsyncPageable<PolicySummary> SummarizeForResourceGroupLevelPolicyAssignmentPolicyStatesAsync(string policyAssignmentName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsAsyncPageableAsync(ct => ArmMockable.SummarizeForResourceGroupLevelPolicyAssignmentPolicyStatesAsync(BuildPolicyAssignmentScope(policyAssignmentName), policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        /// <summary> Summarizes policy states for the resources under the resource-group-level policy assignment. </summary>
        public virtual Pageable<PolicySummary> SummarizeForResourceGroupLevelPolicyAssignmentPolicyStates(string policyAssignmentName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsPageable(ct => ArmMockable.SummarizeForResourceGroupLevelPolicyAssignmentPolicyStates(BuildPolicyAssignmentScope(policyAssignmentName), policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        private ResourceIdentifier BuildPolicyAssignmentScope(string policyAssignmentName)
            => new ResourceIdentifier($"{Id}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}");
    }
}
