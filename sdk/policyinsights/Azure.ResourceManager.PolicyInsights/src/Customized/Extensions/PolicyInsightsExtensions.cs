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
        /// Summarizes policy states for the resource group level policy assignment.
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
        /// Summarizes policy states for the resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            Page<PolicySummary> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("ResourceGroupPolicyAssignmentPolicyInsightsResource.SummarizePolicyStates");
                scope.Start();
                try
                {
                    var response = _policyStatesRestClient.SummarizeForResourceGroupLevelPolicyAssignment(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStatesSummaryResource, queryOptions, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Queries policy states for the resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicyState>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("ResourceGroupPolicyAssignmentPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyStatesRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PolicyState>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("ResourceGroupPolicyAssignmentPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyStatesRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Queries policy states for the resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            Page<PolicyState> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("ResourceGroupPolicyAssignmentPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = _policyStatesRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignment(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PolicyState> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("ResourceGroupPolicyAssignmentPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = _policyStatesRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Queries policy events for the resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicyEvent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyEventsClientDiagnostics.CreateScope("ResourceGroupPolicyAssignmentPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyEventsRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PolicyEvent>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _policyEventsClientDiagnostics.CreateScope("ResourceGroupPolicyAssignmentPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyEventsRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Queries policy events for the resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            Page<PolicyEvent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyEventsClientDiagnostics.CreateScope("ResourceGroupPolicyAssignmentPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = _policyEventsRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignment(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PolicyEvent> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _policyEventsClientDiagnostics.CreateScope("ResourceGroupPolicyAssignmentPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = _policyEventsRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        private static SubscriptionPolicyDefinitionResourceExtensionClient GetExtensionClient(SubscriptionPolicyDefinitionResource subscriptionPolicyDefinitionResource)
        {
            return subscriptionPolicyDefinitionResource.GetCachedClient((client) =>
            {
                return new SubscriptionPolicyDefinitionResourceExtensionClient(client, subscriptionPolicyDefinitionResource.Id);
            }
            );
        }

        private static SubscriptionPolicySetDefinitionResourceExtensionClient GetExtensionClient(SubscriptionPolicySetDefinitionResource subscriptionPolicySetDefinitionResource)
        {
            return subscriptionPolicySetDefinitionResource.GetCachedClient((client) =>
            {
                return new SubscriptionPolicySetDefinitionResourceExtensionClient(client, subscriptionPolicySetDefinitionResource.Id);
            }
            );
        }
    }
}
