// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
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
    }
}
