// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CheckAtManagementGroupScopeAsync", typeof(ResourceIdentifier), typeof(CheckManagementGroupPolicyRestrictionsContent), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CheckAtManagementGroupScope", typeof(ResourceIdentifier), typeof(CheckManagementGroupPolicyRestrictionsContent), typeof(CancellationToken))]
    // PolicyEvents query-results re-hosted onto PolicyDefinition / PolicySetDefinition / PolicyAssignment resources
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyEventsAsync", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyEvents", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyEventsAsync", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyEvents", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEventsAsync", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEvents", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEventsAsync", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEvents", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    // PolicyStates query-results re-hosted
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyStatesAsync", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyStates", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyStatesAsync", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyStates", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStatesAsync", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStates", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStatesAsync", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStates", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    // SummarizeFor* re-hosted
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForPolicyDefinitionPolicyStatesAsync", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForPolicyDefinitionPolicyStates", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForPolicySetDefinitionPolicyStatesAsync", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForPolicySetDefinitionPolicyStates", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForResourceGroupLevelPolicyAssignmentPolicyStatesAsync", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForResourceGroupLevelPolicyAssignmentPolicyStates", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForSubscriptionLevelPolicyAssignmentPolicyStatesAsync", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForSubscriptionLevelPolicyAssignmentPolicyStates", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    // ManagementGroup scope (re-hosted to MockablePolicyInsightsManagementGroupResource)
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForManagementGroupAsync", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForManagementGroup", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForManagementGroupAsync", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForManagementGroup", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForManagementGroupAsync", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForManagementGroup", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    // Resource (arbitrary scope) — renamed in place to GetPolicyEventQueryResults / GetPolicyStateQueryResults / SummarizePolicyStates
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceAsync", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResource", typeof(ResourceIdentifier), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceAsync", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResource", typeof(ResourceIdentifier), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForResourceAsync", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForResource", typeof(ResourceIdentifier), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    // PolicyTrackedResources renames (ArmClient + MG re-host)
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceAsync", typeof(ResourceIdentifier), typeof(PolicyTrackedResourceType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResource", typeof(ResourceIdentifier), typeof(PolicyTrackedResourceType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForManagementGroupAsync", typeof(ResourceIdentifier), typeof(PolicyTrackedResourceType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForManagementGroup", typeof(ResourceIdentifier), typeof(PolicyTrackedResourceType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    // ComponentPolicyStates — fix queryOptions forwarding (generator bug #59950)
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceComponentPolicyStatesAsync", typeof(ResourceIdentifier), typeof(ComponentPolicyStatesResource), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceComponentPolicyStates", typeof(ResourceIdentifier), typeof(ComponentPolicyStatesResource), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForPolicyDefinitionComponentPolicyStatesAsync", typeof(ResourceIdentifier), typeof(ComponentPolicyStatesResource), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForPolicyDefinitionComponentPolicyStates", typeof(ResourceIdentifier), typeof(ComponentPolicyStatesResource), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesAsync", typeof(ResourceIdentifier), typeof(ComponentPolicyStatesResource), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStates", typeof(ResourceIdentifier), typeof(ComponentPolicyStatesResource), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesAsync", typeof(ResourceIdentifier), typeof(ComponentPolicyStatesResource), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStates", typeof(ResourceIdentifier), typeof(ComponentPolicyStatesResource), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    public partial class MockablePolicyInsightsArmClient
    {
        // ===== Renamed (kept on ArmClient): GetQueryResultsForResource -> GetPolicyEventQueryResults/... (arbitrary scope) =====

        /// <summary> Queries policy events for the resource. </summary>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(ResourceIdentifier scope, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyEventsGetQueryResultsForResourceAsyncCollectionResultOfT(
                PolicyEventsRestClient, policyEventType.ToString(), scope.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.Expand, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsArmClient.GetPolicyEventQueryResults");
        }

        /// <summary> Queries policy events for the resource. </summary>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(ResourceIdentifier scope, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyEventsGetQueryResultsForResourceCollectionResultOfT(
                PolicyEventsRestClient, policyEventType.ToString(), scope.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.Expand, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsArmClient.GetPolicyEventQueryResults");
        }

        /// <summary> Queries policy states for the resource. </summary>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(ResourceIdentifier scope, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyStatesGetQueryResultsForResourceAsyncCollectionResultOfT(
                PolicyStatesRestClient, policyStateType.ToString(), scope.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.Expand, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsArmClient.GetPolicyStateQueryResults");
        }

        /// <summary> Queries policy states for the resource. </summary>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(ResourceIdentifier scope, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyStatesGetQueryResultsForResourceCollectionResultOfT(
                PolicyStatesRestClient, policyStateType.ToString(), scope.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.Expand, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsArmClient.GetPolicyStateQueryResults");
        }

        /// <summary>
        /// Summarizes policy states for the resource.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{resourceId}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PolicyStatesOperationGroup_SummarizeForResource. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="policyStateSummaryType"></param>
        /// <param name="policyQuerySettings"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        /// <returns> A collection of <see cref="PolicySummary"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(ResourceIdentifier scope, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PolicyStatesSummarizeForResourceAsyncCollectionResultOfT(
                PolicyStatesRestClient,
                policyStateSummaryType.ToString(),
                scope.ToString(),
                policyQuerySettings?.Top,
                policyQuerySettings?.From,
                policyQuerySettings?.To,
                policyQuerySettings?.Filter,
                context,
                "MockablePolicyInsightsArmClient.SummarizePolicyStates");
        }

        /// <summary>
        /// Summarizes policy states for the resource.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{resourceId}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PolicyStatesOperationGroup_SummarizeForResource. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="policyStateSummaryType"></param>
        /// <param name="policyQuerySettings"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        /// <returns> A collection of <see cref="PolicySummary"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(ResourceIdentifier scope, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PolicyStatesSummarizeForResourceCollectionResultOfT(
                PolicyStatesRestClient,
                policyStateSummaryType.ToString(),
                scope.ToString(),
                policyQuerySettings?.Top,
                policyQuerySettings?.From,
                policyQuerySettings?.To,
                policyQuerySettings?.Filter,
                context,
                "MockablePolicyInsightsArmClient.SummarizePolicyStates");
        }

        // ===== PolicyTrackedResources (renamed): GetQueryResultsForResource/ManagementGroup -> GetPolicyTrackedResourceQueryResults =====

        /// <summary> Queries policy tracked resources for the resource. </summary>
        public virtual AsyncPageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(ResourceIdentifier scope, PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyTrackedResourcesGetQueryResultsForResourceAsyncCollectionResultOfT(
                PolicyTrackedResourcesRestClient, scope.ToString(), policyTrackedResourceType.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.Filter,
                context, "MockablePolicyInsightsArmClient.GetPolicyTrackedResourceQueryResults");
        }

        /// <summary> Queries policy tracked resources for the resource. </summary>
        public virtual Pageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(ResourceIdentifier scope, PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyTrackedResourcesGetQueryResultsForResourceCollectionResultOfT(
                PolicyTrackedResourcesRestClient, scope.ToString(), policyTrackedResourceType.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.Filter,
                context, "MockablePolicyInsightsArmClient.GetPolicyTrackedResourceQueryResults");
        }

        /// <summary>
        /// Queries component policy states for the resource.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{resourceId}/providers/Microsoft.PolicyInsights/componentPolicyStates/{componentPolicyStatesResource}/queryResults. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ComponentPolicyStatesOperationGroup_ListQueryResultsForResource. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="componentPolicyStatesResource"></param>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        public virtual AsyncPageable<ComponentPolicyState> GetQueryResultsForResourceComponentPolicyStatesAsync(ResourceIdentifier scope, ComponentPolicyStatesResource componentPolicyStatesResource, PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ComponentPolicyStatesGetQueryResultsForResourceComponentPolicyStatesAsyncCollectionResultOfT(
                ComponentPolicyStatesRestClient, scope.ToString(), componentPolicyStatesResource.ToString(),
                queryOptions?.Top, queryOptions?.OrderBy, queryOptions?.Select,
                queryOptions?.From, queryOptions?.To, queryOptions?.Filter,
                queryOptions?.Apply, queryOptions?.Expand,
                context, "MockablePolicyInsightsArmClient.GetQueryResultsForResourceComponentPolicyStates");
        }

        /// <summary>
        /// Queries component policy states for the resource.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /{resourceId}/providers/Microsoft.PolicyInsights/componentPolicyStates/{componentPolicyStatesResource}/queryResults. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ComponentPolicyStatesOperationGroup_ListQueryResultsForResource. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="componentPolicyStatesResource"></param>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        public virtual Pageable<ComponentPolicyState> GetQueryResultsForResourceComponentPolicyStates(ResourceIdentifier scope, ComponentPolicyStatesResource componentPolicyStatesResource, PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ComponentPolicyStatesGetQueryResultsForResourceComponentPolicyStatesCollectionResultOfT(
                ComponentPolicyStatesRestClient, scope.ToString(), componentPolicyStatesResource.ToString(),
                queryOptions?.Top, queryOptions?.OrderBy, queryOptions?.Select,
                queryOptions?.From, queryOptions?.To, queryOptions?.Filter,
                queryOptions?.Apply, queryOptions?.Expand,
                context, "MockablePolicyInsightsArmClient.GetQueryResultsForResourceComponentPolicyStates");
        }

        /// <summary>
        /// Queries component policy states for the subscription level policy definition.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/{authorizationNamespace}/policyDefinitions/{policyDefinitionName}/providers/Microsoft.PolicyInsights/componentPolicyStates/{componentPolicyStatesResource}/queryResults. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ComponentPolicyStatesOperationGroup_ListQueryResultsForPolicyDefinition. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="componentPolicyStatesResource"></param>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        public virtual AsyncPageable<ComponentPolicyState> GetQueryResultsForPolicyDefinitionComponentPolicyStatesAsync(ResourceIdentifier scope, ComponentPolicyStatesResource componentPolicyStatesResource, PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ComponentPolicyStatesGetQueryResultsForPolicyDefinitionComponentPolicyStatesAsyncCollectionResultOfT(
                ComponentPolicyStatesRestClient, scope.SubscriptionId, scope.Name, componentPolicyStatesResource.ToString(),
                queryOptions?.Top, queryOptions?.OrderBy, queryOptions?.Select,
                queryOptions?.From, queryOptions?.To, queryOptions?.Filter, queryOptions?.Apply,
                context, "MockablePolicyInsightsArmClient.GetQueryResultsForPolicyDefinitionComponentPolicyStates");
        }

        /// <summary>
        /// Queries component policy states for the subscription level policy definition.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/{authorizationNamespace}/policyDefinitions/{policyDefinitionName}/providers/Microsoft.PolicyInsights/componentPolicyStates/{componentPolicyStatesResource}/queryResults. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ComponentPolicyStatesOperationGroup_ListQueryResultsForPolicyDefinition. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="componentPolicyStatesResource"></param>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        public virtual Pageable<ComponentPolicyState> GetQueryResultsForPolicyDefinitionComponentPolicyStates(ResourceIdentifier scope, ComponentPolicyStatesResource componentPolicyStatesResource, PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ComponentPolicyStatesGetQueryResultsForPolicyDefinitionComponentPolicyStatesCollectionResultOfT(
                ComponentPolicyStatesRestClient, scope.SubscriptionId, scope.Name, componentPolicyStatesResource.ToString(),
                queryOptions?.Top, queryOptions?.OrderBy, queryOptions?.Select,
                queryOptions?.From, queryOptions?.To, queryOptions?.Filter, queryOptions?.Apply,
                context, "MockablePolicyInsightsArmClient.GetQueryResultsForPolicyDefinitionComponentPolicyStates");
        }

        /// <summary>
        /// Queries component policy states for the subscription level policy assignment.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/{authorizationNamespace}/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/componentPolicyStates/{componentPolicyStatesResource}/queryResults. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ComponentPolicyStatesOperationGroup_ListQueryResultsForSubscriptionLevelPolicyAssignment. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="componentPolicyStatesResource"></param>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        public virtual AsyncPageable<ComponentPolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesAsync(ResourceIdentifier scope, ComponentPolicyStatesResource componentPolicyStatesResource, PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ComponentPolicyStatesGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesAsyncCollectionResultOfT(
                ComponentPolicyStatesRestClient, scope.SubscriptionId, scope.Name, componentPolicyStatesResource.ToString(),
                queryOptions?.Top, queryOptions?.OrderBy, queryOptions?.Select,
                queryOptions?.From, queryOptions?.To, queryOptions?.Filter, queryOptions?.Apply,
                context, "MockablePolicyInsightsArmClient.GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStates");
        }

        /// <summary>
        /// Queries component policy states for the subscription level policy assignment.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/{authorizationNamespace}/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/componentPolicyStates/{componentPolicyStatesResource}/queryResults. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ComponentPolicyStatesOperationGroup_ListQueryResultsForSubscriptionLevelPolicyAssignment. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="componentPolicyStatesResource"></param>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        public virtual Pageable<ComponentPolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStates(ResourceIdentifier scope, ComponentPolicyStatesResource componentPolicyStatesResource, PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ComponentPolicyStatesGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesCollectionResultOfT(
                ComponentPolicyStatesRestClient, scope.SubscriptionId, scope.Name, componentPolicyStatesResource.ToString(),
                queryOptions?.Top, queryOptions?.OrderBy, queryOptions?.Select,
                queryOptions?.From, queryOptions?.To, queryOptions?.Filter, queryOptions?.Apply,
                context, "MockablePolicyInsightsArmClient.GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStates");
        }

        /// <summary>
        /// Queries component policy states for the resource group level policy assignment.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{authorizationNamespace}/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/componentPolicyStates/{componentPolicyStatesResource}/queryResults. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ComponentPolicyStatesOperationGroup_ListQueryResultsForResourceGroupLevelPolicyAssignment. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="componentPolicyStatesResource"></param>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        public virtual AsyncPageable<ComponentPolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesAsync(ResourceIdentifier scope, ComponentPolicyStatesResource componentPolicyStatesResource, PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ComponentPolicyStatesGetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesAsyncCollectionResultOfT(
                ComponentPolicyStatesRestClient, scope.SubscriptionId, scope.ResourceGroupName, scope.Name, componentPolicyStatesResource.ToString(),
                queryOptions?.Top, queryOptions?.OrderBy, queryOptions?.Select,
                queryOptions?.From, queryOptions?.To, queryOptions?.Filter, queryOptions?.Apply,
                context, "MockablePolicyInsightsArmClient.GetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStates");
        }

        /// <summary>
        /// Queries component policy states for the resource group level policy assignment.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{authorizationNamespace}/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/componentPolicyStates/{componentPolicyStatesResource}/queryResults. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ComponentPolicyStatesOperationGroup_ListQueryResultsForResourceGroupLevelPolicyAssignment. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="componentPolicyStatesResource"></param>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> is null. </exception>
        public virtual Pageable<ComponentPolicyState> GetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStates(ResourceIdentifier scope, ComponentPolicyStatesResource componentPolicyStatesResource, PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ComponentPolicyStatesGetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStatesCollectionResultOfT(
                ComponentPolicyStatesRestClient, scope.SubscriptionId, scope.ResourceGroupName, scope.Name, componentPolicyStatesResource.ToString(),
                queryOptions?.Top, queryOptions?.OrderBy, queryOptions?.Select,
                queryOptions?.From, queryOptions?.To, queryOptions?.Filter, queryOptions?.Apply,
                context, "MockablePolicyInsightsArmClient.GetQueryResultsForResourceGroupLevelPolicyAssignmentComponentPolicyStates");
        }

        // ===== GA-shape ComponentPolicyStates query overloads (obsolete + throw) =====
        /// <summary> [Obsolete] Use the new GetQueryResultsForResourceComponentPolicyStatesAsync(ResourceIdentifier, ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) overload instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use GetQueryResultsForResourceComponentPolicyStatesAsync(ResourceIdentifier, ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) instead.")]
        public virtual AsyncPageable<ComponentPolicyState> GetQueryResultsForResourceComponentPolicyStatesAsync(ResourceIdentifier scope, ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use GetQueryResultsForResourceComponentPolicyStatesAsync(ResourceIdentifier, ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) instead.");
        }

        /// <summary> [Obsolete] Use the new GetQueryResultsForResourceComponentPolicyStates(ResourceIdentifier, ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) overload instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use GetQueryResultsForResourceComponentPolicyStates(ResourceIdentifier, ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) instead.")]
        public virtual Pageable<ComponentPolicyState> GetQueryResultsForResourceComponentPolicyStates(ResourceIdentifier scope, ArmResourceGetQueryResultsForResourceComponentPolicyStatesOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use GetQueryResultsForResourceComponentPolicyStates(ResourceIdentifier, ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) instead.");
        }
    }
}
