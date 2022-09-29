// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.PolicyInsights.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.PolicyInsights
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.PolicyInsights. </summary>
    [CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyEvents", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyEventsAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyEvents", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyEventsAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEvents", typeof(ResourceGroupResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyEventsAsync", typeof(ResourceGroupResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEvents", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEventsAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicyDefinitionPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForPolicySetDefinitionPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStates", typeof(ResourceGroupResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForResourceGroupLevelPolicyAssignmentPolicyStatesAsync", typeof(ResourceGroupResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForPolicyDefinitionPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForPolicyDefinitionPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForPolicySetDefinitionPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForPolicySetDefinitionPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForResourceGroupLevelPolicyAssignmentPolicyStates", typeof(ResourceGroupResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForResourceGroupLevelPolicyAssignmentPolicyStatesAsync", typeof(ResourceGroupResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForSubscriptionLevelPolicyAssignmentPolicyStates", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [CodeGenSuppress("SummarizeForSubscriptionLevelPolicyAssignmentPolicyStatesAsync", typeof(SubscriptionResource), typeof(string), typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    public static partial class PolicyInsightsExtensions
    {
        private static PolicyAssignmentResourceExtensionClient GetExtensionClient(PolicyAssignmentResource policyAssignmentResource)
        {
            return policyAssignmentResource.GetCachedClient((client) =>
            {
                return new PolicyAssignmentResourceExtensionClient(client, policyAssignmentResource.Id);
            }
            );
        }

        /// <summary>
        /// Summarizes policy states for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyAssignmentResource"> The <see cref="PolicyAssignmentResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(this PolicyAssignmentResource policyAssignmentResource, PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(policyAssignmentResource).SummarizePolicyStatesAsync(policyStatesSummaryResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Summarizes policy states for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyAssignmentResource"> The <see cref="PolicyAssignmentResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PolicySummary> SummarizePolicyStates(this PolicyAssignmentResource policyAssignmentResource, PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(policyAssignmentResource).SummarizePolicyStates(policyStatesSummaryResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy states for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyAssignmentResource"> The <see cref="PolicyAssignmentResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(this PolicyAssignmentResource policyAssignmentResource, PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(policyAssignmentResource).GetPolicyStateQueryResultsAsync(policyStatesResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy states for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyAssignmentResource"> The <see cref="PolicyAssignmentResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PolicyState> GetPolicyStateQueryResults(this PolicyAssignmentResource policyAssignmentResource, PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(policyAssignmentResource).GetPolicyStateQueryResults(policyStatesResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy events for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyAssignmentResource"> The <see cref="PolicyAssignmentResource" /> instance the method will execute against. </param>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(this PolicyAssignmentResource policyAssignmentResource, PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(policyAssignmentResource).GetPolicyEventQueryResultsAsync(policyEventsResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy events for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyAssignmentResource"> The <see cref="PolicyAssignmentResource" /> instance the method will execute against. </param>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PolicyEvent> GetPolicyEventQueryResults(this PolicyAssignmentResource policyAssignmentResource, PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(policyAssignmentResource).GetPolicyEventQueryResults(policyEventsResource, queryOptions, cancellationToken);
        }

        private static SubscriptionPolicyDefinitionResourceExtensionClient GetExtensionClient(SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource)
        {
            return subscriptionPolicyDefinitionResource.GetCachedClient((client) =>
            {
                return new SubscriptionPolicyDefinitionResourceExtensionClient(client, subscriptionPolicyDefinitionResource.Id);
            }
            );
        }

        /// <summary>
        /// Summarizes policy states for the subscription level policy definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForPolicyDefinition
        /// </summary>
        /// <param name="subscriptionPolicyDefinitionResource"> The <see cref="SubscriptionPolicyDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(this SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicyDefinitionResource).SummarizePolicyStatesAsync(policyStatesSummaryResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Summarizes policy states for the subscription level policy definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForPolicyDefinition
        /// </summary>
        /// <param name="subscriptionPolicyDefinitionResource"> The <see cref="SubscriptionPolicyDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PolicySummary> SummarizePolicyStates(this SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicyDefinitionResource).SummarizePolicyStates(policyStatesSummaryResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy states for the subscription level policy definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForPolicyDefinition
        /// </summary>
        /// <param name="subscriptionPolicyDefinitionResource"> The <see cref="SubscriptionPolicyDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(this SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicyDefinitionResource).GetPolicyStateQueryResultsAsync(policyStatesResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy states for the subscription level policy definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForPolicyDefinition
        /// </summary>
        /// <param name="subscriptionPolicyDefinitionResource"> The <see cref="SubscriptionPolicyDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PolicyState> GetPolicyStateQueryResults(this SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicyDefinitionResource).GetPolicyStateQueryResults(policyStatesResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy events for the subscription level policy definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForPolicyDefinition
        /// </summary>
        /// <param name="subscriptionPolicyDefinitionResource"> The <see cref="SubscriptionPolicyDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(this SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicyDefinitionResource).GetPolicyEventQueryResultsAsync(policyEventsResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy events for the subscription level policy definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyDefinitions/{policyDefinitionName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForPolicyDefinition
        /// </summary>
        /// <param name="subscriptionPolicyDefinitionResource"> The <see cref="SubscriptionPolicyDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PolicyEvent> GetPolicyEventQueryResults(this SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource, PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicyDefinitionResource).GetPolicyEventQueryResults(policyEventsResource, queryOptions, cancellationToken);
        }

        private static SubscriptionPolicySetDefinitionResourceExtensionClient GetExtensionClient(SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource)
        {
            return subscriptionPolicySetDefinitionResource.GetCachedClient((client) =>
            {
                return new SubscriptionPolicySetDefinitionResourceExtensionClient(client, subscriptionPolicySetDefinitionResource.Id);
            }
            );
        }

        /// <summary>
        /// Summarizes policy states for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForPolicySetDefinition
        /// </summary>
        /// <param name="subscriptionPolicySetDefinitionResource"> The <see cref="SubscriptionPolicySetDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(this SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicySetDefinitionResource).SummarizePolicyStatesAsync(policyStatesSummaryResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Summarizes policy states for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForPolicySetDefinition
        /// </summary>
        /// <param name="subscriptionPolicySetDefinitionResource"> The <see cref="SubscriptionPolicySetDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PolicySummary> SummarizePolicyStates(this SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicySetDefinitionResource).SummarizePolicyStates(policyStatesSummaryResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy states for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForPolicySetDefinition
        /// </summary>
        /// <param name="subscriptionPolicySetDefinitionResource"> The <see cref="SubscriptionPolicySetDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(this SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicySetDefinitionResource).GetPolicyStateQueryResultsAsync(policyStatesResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy states for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForPolicySetDefinition
        /// </summary>
        /// <param name="subscriptionPolicySetDefinitionResource"> The <see cref="SubscriptionPolicySetDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PolicyState> GetPolicyStateQueryResults(this SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicySetDefinitionResource).GetPolicyStateQueryResults(policyStatesResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy events for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForPolicySetDefinition
        /// </summary>
        /// <param name="subscriptionPolicySetDefinitionResource"> The <see cref="SubscriptionPolicySetDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(this SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicySetDefinitionResource).GetPolicyEventQueryResultsAsync(policyEventsResource, queryOptions, cancellationToken);
        }

        /// <summary>
        /// Queries policy events for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForPolicySetDefinition
        /// </summary>
        /// <param name="subscriptionPolicySetDefinitionResource"> The <see cref="SubscriptionPolicySetDefinitionResource" /> instance the method will execute against. </param>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public static Pageable<PolicyEvent> GetPolicyEventQueryResults(this SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource, PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            return GetExtensionClient(subscriptionPolicySetDefinitionResource).GetPolicyEventQueryResults(policyEventsResource, queryOptions, cancellationToken);
        }
    }
}
