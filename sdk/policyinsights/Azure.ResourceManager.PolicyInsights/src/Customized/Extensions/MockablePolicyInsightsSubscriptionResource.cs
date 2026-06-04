// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    // Adds GA back-compat method names that the new emitter does not produce
    // because using @@clientName on the spec ops would collide on the shared
    // MockablePolicyInsightsArmClient / REST client (the 4-way Sub/RG/MG/Resource
    // variants of each query/summarize family). These are pure delegations to the
    // generator-emitted methods with the new (per-scope) names.
    public partial class MockablePolicyInsightsSubscriptionResource
    {
        private MockablePolicyInsightsArmClient ArmMockable
            => Client.GetCachedClient(c => new MockablePolicyInsightsArmClient(c, ResourceIdentifier.Root));

        // === Subscription scope (per-scope variants) ===
        /// <summary> Queries policy events for the resources under the subscription. </summary>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForSubscriptionAsync(policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events for the resources under the subscription. </summary>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForSubscription(policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the subscription. </summary>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForSubscriptionAsync(policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the subscription. </summary>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForSubscription(policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy tracked resources under the subscription. </summary>
        public virtual AsyncPageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForSubscriptionAsync(policyTrackedResourceType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy tracked resources under the subscription. </summary>
        public virtual Pageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => GetQueryResultsForSubscription(policyTrackedResourceType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states for the resources under the subscription. </summary>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsAsyncPageableAsync(ct => SummarizeForSubscriptionAsync(policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        /// <summary> Summarizes policy states for the resources under the subscription. </summary>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsPageable(ct => SummarizeForSubscription(policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        /// <summary> Triggers a policy evaluation scan for all the resources under the subscription. </summary>
        public virtual Task<ArmOperation> TriggerPolicyStateEvaluationAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => TriggerSubscriptionEvaluationAsync(waitUntil, cancellationToken);

        /// <summary> Triggers a policy evaluation scan for all the resources under the subscription. </summary>
        public virtual ArmOperation TriggerPolicyStateEvaluation(WaitUntil waitUntil, CancellationToken cancellationToken = default)
            => TriggerSubscriptionEvaluation(waitUntil, cancellationToken);

        /// <summary> Checks what restrictions Azure Policy will place on a resource within a subscription. </summary>
        public virtual Task<Response<CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(CheckPolicyRestrictionsContent content, CancellationToken cancellationToken = default)
            => CheckAtSubscriptionScopeAsync(content, cancellationToken);

        /// <summary> Checks what restrictions Azure Policy will place on a resource within a subscription. </summary>
        public virtual Response<CheckPolicyRestrictionsResult> CheckPolicyRestrictions(CheckPolicyRestrictionsContent content, CancellationToken cancellationToken = default)
            => CheckAtSubscriptionScope(content, cancellationToken);

        // === Subscription-level PolicyDefinition / PolicySetDefinition / PolicyAssignment shims ===
        // These delegate to the ArmClient versions with the corresponding scope identifier built from this subscription + the named inner ARM resource.

        /// <summary> Queries policy events for the resources under the subscription-level policy definition. </summary>
        public virtual AsyncPageable<PolicyEvent> GetQueryResultsForPolicyDefinitionPolicyEventsAsync(string policyDefinitionName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForPolicyDefinitionPolicyEventsAsync(BuildScope("policyDefinitions", policyDefinitionName), policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events for the resources under the subscription-level policy definition. </summary>
        public virtual Pageable<PolicyEvent> GetQueryResultsForPolicyDefinitionPolicyEvents(string policyDefinitionName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForPolicyDefinitionPolicyEvents(BuildScope("policyDefinitions", policyDefinitionName), policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events for the resources under the subscription-level policy set definition. </summary>
        public virtual AsyncPageable<PolicyEvent> GetQueryResultsForPolicySetDefinitionPolicyEventsAsync(string policySetDefinitionName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForPolicySetDefinitionPolicyEventsAsync(BuildScope("policySetDefinitions", policySetDefinitionName), policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events for the resources under the subscription-level policy set definition. </summary>
        public virtual Pageable<PolicyEvent> GetQueryResultsForPolicySetDefinitionPolicyEvents(string policySetDefinitionName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForPolicySetDefinitionPolicyEvents(BuildScope("policySetDefinitions", policySetDefinitionName), policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events for the resources under the subscription-level policy assignment. </summary>
        public virtual AsyncPageable<PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEventsAsync(string policyAssignmentName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEventsAsync(BuildScope("policyAssignments", policyAssignmentName), policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events for the resources under the subscription-level policy assignment. </summary>
        public virtual Pageable<PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEvents(string policyAssignmentName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEvents(BuildScope("policyAssignments", policyAssignmentName), policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the subscription-level policy definition. </summary>
        public virtual AsyncPageable<PolicyState> GetQueryResultsForPolicyDefinitionPolicyStatesAsync(string policyDefinitionName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForPolicyDefinitionPolicyStatesAsync(BuildScope("policyDefinitions", policyDefinitionName), policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the subscription-level policy definition. </summary>
        public virtual Pageable<PolicyState> GetQueryResultsForPolicyDefinitionPolicyStates(string policyDefinitionName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForPolicyDefinitionPolicyStates(BuildScope("policyDefinitions", policyDefinitionName), policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the subscription-level policy set definition. </summary>
        public virtual AsyncPageable<PolicyState> GetQueryResultsForPolicySetDefinitionPolicyStatesAsync(string policySetDefinitionName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForPolicySetDefinitionPolicyStatesAsync(BuildScope("policySetDefinitions", policySetDefinitionName), policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the subscription-level policy set definition. </summary>
        public virtual Pageable<PolicyState> GetQueryResultsForPolicySetDefinitionPolicyStates(string policySetDefinitionName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForPolicySetDefinitionPolicyStates(BuildScope("policySetDefinitions", policySetDefinitionName), policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the subscription-level policy assignment. </summary>
        public virtual AsyncPageable<PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStatesAsync(string policyAssignmentName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStatesAsync(BuildScope("policyAssignments", policyAssignmentName), policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the subscription-level policy assignment. </summary>
        public virtual Pageable<PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStates(string policyAssignmentName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStates(BuildScope("policyAssignments", policyAssignmentName), policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states for the resources under the subscription-level policy definition. </summary>
        public virtual AsyncPageable<PolicySummary> SummarizeForPolicyDefinitionPolicyStatesAsync(string policyDefinitionName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsAsyncPageableAsync(ct => ArmMockable.SummarizeForPolicyDefinitionPolicyStatesAsync(BuildScope("policyDefinitions", policyDefinitionName), policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        /// <summary> Summarizes policy states for the resources under the subscription-level policy definition. </summary>
        public virtual Pageable<PolicySummary> SummarizeForPolicyDefinitionPolicyStates(string policyDefinitionName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsPageable(ct => ArmMockable.SummarizeForPolicyDefinitionPolicyStates(BuildScope("policyDefinitions", policyDefinitionName), policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        /// <summary> Summarizes policy states for the resources under the subscription-level policy set definition. </summary>
        public virtual AsyncPageable<PolicySummary> SummarizeForPolicySetDefinitionPolicyStatesAsync(string policySetDefinitionName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsAsyncPageableAsync(ct => ArmMockable.SummarizeForPolicySetDefinitionPolicyStatesAsync(BuildScope("policySetDefinitions", policySetDefinitionName), policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        /// <summary> Summarizes policy states for the resources under the subscription-level policy set definition. </summary>
        public virtual Pageable<PolicySummary> SummarizeForPolicySetDefinitionPolicyStates(string policySetDefinitionName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsPageable(ct => ArmMockable.SummarizeForPolicySetDefinitionPolicyStates(BuildScope("policySetDefinitions", policySetDefinitionName), policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        /// <summary> Summarizes policy states for the resources under the subscription-level policy assignment. </summary>
        public virtual AsyncPageable<PolicySummary> SummarizeForSubscriptionLevelPolicyAssignmentPolicyStatesAsync(string policyAssignmentName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsAsyncPageableAsync(ct => ArmMockable.SummarizeForSubscriptionLevelPolicyAssignmentPolicyStatesAsync(BuildScope("policyAssignments", policyAssignmentName), policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        /// <summary> Summarizes policy states for the resources under the subscription-level policy assignment. </summary>
        public virtual Pageable<PolicySummary> SummarizeForSubscriptionLevelPolicyAssignmentPolicyStates(string policyAssignmentName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => CompatHelpers.AsPageable(ct => ArmMockable.SummarizeForSubscriptionLevelPolicyAssignmentPolicyStates(BuildScope("policyAssignments", policyAssignmentName), policyStateSummaryType, policyQuerySettings, ct), cancellationToken);

        private ResourceIdentifier BuildScope(string segmentType, string segmentName)
            => new ResourceIdentifier($"{Id}/providers/Microsoft.Authorization/{segmentType}/{segmentName}");
    }
}
