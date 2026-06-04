// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable CS1591 // Missing XML doc comment — back-compat shim types.
#pragma warning disable SA1402 // File may only contain a single type — grouped shims.

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.ManagementGroups;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    // GA exposed dedicated Mockable*Resource classes for several non-standard ARM
    // scopes. The new emitter does not generate them because the spec's per-scope
    // ops use Legacy.ExtensionOperations templates rather than scope-specific
    // resource templates. Re-introduce them as thin SDK shims so the GA public
    // surface (and the [Mocking] extension pattern) keeps working.
    public partial class MockablePolicyInsightsManagementGroupResource : ArmResource
    {
        private MockablePolicyInsightsArmClient ArmMockable
            => Client.GetCachedClient(c => new MockablePolicyInsightsArmClient(c, ResourceIdentifier.Root));

        /// <summary> Initializes a new instance of the <see cref="MockablePolicyInsightsManagementGroupResource"/> class for mocking. </summary>
        protected MockablePolicyInsightsManagementGroupResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockablePolicyInsightsManagementGroupResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockablePolicyInsightsManagementGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Queries policy events for the resources under the management group. </summary>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyEventQueryResultsAsync(Id, policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events for the resources under the management group. </summary>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyEventQueryResults(Id, policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the management group. </summary>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyStateQueryResultsAsync(Id, policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states for the resources under the management group. </summary>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyStateQueryResults(Id, policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy tracked resources under the management group. </summary>
        public virtual AsyncPageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyTrackedResourceQueryResultsAsync(Id, policyTrackedResourceType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy tracked resources under the management group. </summary>
        public virtual Pageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyTrackedResourceQueryResults(Id, policyTrackedResourceType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states for the resources under the management group. </summary>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.SummarizePolicyStatesAsync(Id, policyStateSummaryType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states for the resources under the management group. </summary>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.SummarizePolicyStates(Id, policyStateSummaryType, policyQuerySettings, cancellationToken);

        /// <summary> Checks what restrictions Azure Policy will place on a resource within the management group. </summary>
        public virtual Task<Response<CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(CheckManagementGroupPolicyRestrictionsContent content, CancellationToken cancellationToken = default)
            => ArmMockable.CheckAtManagementGroupScopeAsync(Id, content, cancellationToken);

        /// <summary> Checks what restrictions Azure Policy will place on a resource within the management group. </summary>
        public virtual Response<CheckPolicyRestrictionsResult> CheckPolicyRestrictions(CheckManagementGroupPolicyRestrictionsContent content, CancellationToken cancellationToken = default)
            => ArmMockable.CheckAtManagementGroupScope(Id, content, cancellationToken);
    }

    /// <summary> Mockable extension class for <see cref="Azure.ResourceManager.Resources.PolicyAssignmentResource"/>. </summary>
    public partial class MockablePolicyInsightsPolicyAssignmentResource : ArmResource
    {
        private MockablePolicyInsightsArmClient ArmMockable
            => Client.GetCachedClient(c => new MockablePolicyInsightsArmClient(c, ResourceIdentifier.Root));

        /// <summary> Initializes a new instance of the <see cref="MockablePolicyInsightsPolicyAssignmentResource"/> class for mocking. </summary>
        protected MockablePolicyInsightsPolicyAssignmentResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockablePolicyInsightsPolicyAssignmentResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockablePolicyInsightsPolicyAssignmentResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Queries policy events. </summary>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyEventQueryResultsAsync(Id, policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events. </summary>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyEventQueryResults(Id, policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states. </summary>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyStateQueryResultsAsync(Id, policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states. </summary>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyStateQueryResults(Id, policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states. </summary>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.SummarizePolicyStatesAsync(Id, policyStateSummaryType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states. </summary>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.SummarizePolicyStates(Id, policyStateSummaryType, policyQuerySettings, cancellationToken);
    }

    /// <summary> Mockable extension class for <see cref="Azure.ResourceManager.Resources.SubscriptionPolicyDefinitionResource"/>. </summary>
    public partial class MockablePolicyInsightsSubscriptionPolicyDefinitionResource : ArmResource
    {
        private MockablePolicyInsightsArmClient ArmMockable
            => Client.GetCachedClient(c => new MockablePolicyInsightsArmClient(c, ResourceIdentifier.Root));

        /// <summary> Initializes a new instance of the <see cref="MockablePolicyInsightsSubscriptionPolicyDefinitionResource"/> class for mocking. </summary>
        protected MockablePolicyInsightsSubscriptionPolicyDefinitionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockablePolicyInsightsSubscriptionPolicyDefinitionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockablePolicyInsightsSubscriptionPolicyDefinitionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Queries policy events. </summary>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyEventQueryResultsAsync(Id, policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events. </summary>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyEventQueryResults(Id, policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states. </summary>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyStateQueryResultsAsync(Id, policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states. </summary>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyStateQueryResults(Id, policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states. </summary>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.SummarizePolicyStatesAsync(Id, policyStateSummaryType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states. </summary>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.SummarizePolicyStates(Id, policyStateSummaryType, policyQuerySettings, cancellationToken);
    }

    /// <summary> Mockable extension class for <see cref="Azure.ResourceManager.Resources.SubscriptionPolicySetDefinitionResource"/>. </summary>
    public partial class MockablePolicyInsightsSubscriptionPolicySetDefinitionResource : ArmResource
    {
        private MockablePolicyInsightsArmClient ArmMockable
            => Client.GetCachedClient(c => new MockablePolicyInsightsArmClient(c, ResourceIdentifier.Root));

        /// <summary> Initializes a new instance of the <see cref="MockablePolicyInsightsSubscriptionPolicySetDefinitionResource"/> class for mocking. </summary>
        protected MockablePolicyInsightsSubscriptionPolicySetDefinitionResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MockablePolicyInsightsSubscriptionPolicySetDefinitionResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockablePolicyInsightsSubscriptionPolicySetDefinitionResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Queries policy events. </summary>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyEventQueryResultsAsync(Id, policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy events. </summary>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyEventQueryResults(Id, policyEventType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states. </summary>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyStateQueryResultsAsync(Id, policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Queries policy states. </summary>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.GetPolicyStateQueryResults(Id, policyStateType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states. </summary>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.SummarizePolicyStatesAsync(Id, policyStateSummaryType, policyQuerySettings, cancellationToken);

        /// <summary> Summarizes policy states. </summary>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
            => ArmMockable.SummarizePolicyStates(Id, policyStateSummaryType, policyQuerySettings, cancellationToken);
    }

    // GA-era Mockable*MockingExtension classes (legacy two-tier mockable pattern).
    // Empty partial classes — they have no methods, just the type declaration GA shipped.
    public partial class PolicyInsightsResourceGroupMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="PolicyInsightsResourceGroupMockingExtension"/> class. </summary>
        public PolicyInsightsResourceGroupMockingExtension()
        {
        }
    }

    public partial class PolicyInsightsSubscriptionMockingExtension : ArmResource
    {
        /// <summary> Initializes a new instance of the <see cref="PolicyInsightsSubscriptionMockingExtension"/> class. </summary>
        public PolicyInsightsSubscriptionMockingExtension()
        {
        }
    }
}
