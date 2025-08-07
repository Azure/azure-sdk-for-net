// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    /// <summary> A class to add extension methods to PolicyAssignmentResource. </summary>
    public partial class MockablePolicyInsightsPolicyAssignmentResource : ArmResource
    {
        private ClientDiagnostics _policyEventsClientDiagnostics;
        private PolicyEventsRestOperations _policyEventsRestClient;
        private ClientDiagnostics _policyStatesClientDiagnostics;
        private PolicyStatesRestOperations _policyStatesRestClient;

        private static readonly ResourceType _subscription = new ResourceType("Microsoft.Resources/subscriptions");
        private static readonly ResourceType _resourceGroup = new ResourceType("Microsoft.Resources/resourceGroups");

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

        private ClientDiagnostics PolicyEventsClientDiagnostics => _policyEventsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.PolicyInsights", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private PolicyEventsRestOperations PolicyEventsRestClient => _policyEventsRestClient ??= new PolicyEventsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        private ClientDiagnostics PolicyStatesClientDiagnostics => _policyStatesClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.PolicyInsights", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private PolicyStatesRestOperations PolicyStatesRestClient => _policyStatesRestClient ??= new PolicyStatesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);

        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// Summarizes policy states for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStateSummaryType"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="policyQuerySettings"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicySummary>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = PolicyStatesClientDiagnostics.CreateScope("PolicyAssignmentResourceExtensionClient.SummarizePolicyStates");
                scope.Start();
                try
                {
                    if (Id.Parent.ResourceType == _resourceGroup)
                    {
                        var response = await PolicyStatesRestClient.SummarizeForResourceGroupLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStateSummaryType, policyQuerySettings, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                    }
                    else if (Id.Parent.ResourceType == _subscription)
                    {
                        var response = await PolicyStatesRestClient.SummarizeForSubscriptionLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.Name, policyStateSummaryType, policyQuerySettings, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                    }
                    else
                    {
                        throw new InvalidOperationException("This method can only execute against subscription level or resource group level policy assignment.");
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary>
        /// Summarizes policy states for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStateSummaryType"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="policyQuerySettings"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            Page<PolicySummary> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = PolicyStatesClientDiagnostics.CreateScope("PolicyAssignmentResourceExtensionClient.SummarizePolicyStates");
                scope.Start();
                try
                {
                    if (Id.Parent.ResourceType == _resourceGroup)
                    {
                        var response = PolicyStatesRestClient.SummarizeForResourceGroupLevelPolicyAssignment(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStateSummaryType, policyQuerySettings, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                    }
                    else if (Id.Parent.ResourceType == _subscription)
                    {
                        var response = PolicyStatesRestClient.SummarizeForSubscriptionLevelPolicyAssignment(Id.SubscriptionId, Id.Name, policyStateSummaryType, policyQuerySettings, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                    }
                    else
                    {
                        throw new InvalidOperationException("This method can only execute against subscription level or resource group level policy assignment.");
                    }
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
        /// Queries policy states for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStateType"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="policyQuerySettings"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicyState>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = PolicyStatesClientDiagnostics.CreateScope("PolicyAssignmentResourceExtensionClient.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    if (Id.Parent.ResourceType == _resourceGroup)
                    {
                        var response = await PolicyStatesRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStateType, policyQuerySettings, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else if (Id.Parent.ResourceType == _subscription)
                    {
                        var response = await PolicyStatesRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.Name, policyStateType, policyQuerySettings, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else
                    {
                        throw new InvalidOperationException("This method can only execute against subscription level or resource group level policy assignment.");
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PolicyState>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = PolicyStatesClientDiagnostics.CreateScope("PolicyAssignmentResourceExtensionClient.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    if (Id.Parent.ResourceType == _resourceGroup)
                    {
                        var response = await PolicyStatesRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStateType, policyQuerySettings, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else if (Id.Parent.ResourceType == _subscription)
                    {
                        var response = await PolicyStatesRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, policyStateType, policyQuerySettings, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else
                    {
                        throw new InvalidOperationException("This method can only execute against subscription level or resource group level policy assignment.");
                    }
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
        /// Queries policy states for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStateType"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="policyQuerySettings"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            Page<PolicyState> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = PolicyStatesClientDiagnostics.CreateScope("PolicyAssignmentResourceExtensionClient.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    if (Id.Parent.ResourceType == _resourceGroup)
                    {
                        var response = PolicyStatesRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignment(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStateType, policyQuerySettings, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else if (Id.Parent.ResourceType == _subscription)
                    {
                        var response = PolicyStatesRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignment(Id.SubscriptionId, Id.Name, policyStateType, policyQuerySettings, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else
                    {
                        throw new InvalidOperationException("This method can only execute against subscription level or resource group level policy assignment.");
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PolicyState> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = PolicyStatesClientDiagnostics.CreateScope("PolicyAssignmentResourceExtensionClient.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    if (Id.Parent.ResourceType == _resourceGroup)
                    {
                        var response = PolicyStatesRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyStateType, policyQuerySettings, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else if (Id.Parent.ResourceType == _subscription)
                    {
                        var response = PolicyStatesRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentNextPage(nextLink, Id.SubscriptionId, Id.Name, policyStateType, policyQuerySettings, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else
                    {
                        throw new InvalidOperationException("This method can only execute against subscription level or resource group level policy assignment.");
                    }
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
        /// Queries policy events for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyEventType"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="policyQuerySettings"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicyEvent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = PolicyEventsClientDiagnostics.CreateScope("PolicyAssignmentResourceExtensionClient.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    if (Id.Parent.ResourceType == _resourceGroup)
                    {
                        var response = await PolicyEventsRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyEventType, policyQuerySettings, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else if (Id.Parent.ResourceType == _subscription)
                    {
                        var response = await PolicyEventsRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.Name, policyEventType, policyQuerySettings, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else
                    {
                        throw new InvalidOperationException("This method can only execute against subscription level or resource group level policy assignment.");
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<PolicyEvent>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = PolicyEventsClientDiagnostics.CreateScope("PolicyAssignmentResourceExtensionClient.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    if (Id.Parent.ResourceType == _resourceGroup)
                    {
                        var response = await PolicyEventsRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyEventType, policyQuerySettings, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else if (Id.Parent.ResourceType == _subscription)
                    {
                        var response = await PolicyEventsRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, policyEventType, policyQuerySettings, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else
                    {
                        throw new InvalidOperationException("This method can only execute against subscription level or resource group level policy assignment.");
                    }
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
        /// Queries policy events for the subscription level or resource group level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForResourceGroupLevelPolicyAssignment
        /// </summary>
        /// <param name="policyEventType"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="policyQuerySettings"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            Page<PolicyEvent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = PolicyEventsClientDiagnostics.CreateScope("PolicyAssignmentResourceExtensionClient.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    if (Id.Parent.ResourceType == _resourceGroup)
                    {
                        var response = PolicyEventsRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignment(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyEventType, policyQuerySettings, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else if (Id.Parent.ResourceType == _subscription)
                    {
                        var response = PolicyEventsRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignment(Id.SubscriptionId, Id.Name, policyEventType, policyQuerySettings, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else
                    {
                        throw new InvalidOperationException("This method can only execute against subscription level or resource group level policy assignment.");
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<PolicyEvent> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = PolicyEventsClientDiagnostics.CreateScope("PolicyAssignmentResourceExtensionClient.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    if (Id.Parent.ResourceType == _resourceGroup)
                    {
                        var response = PolicyEventsRestClient.ListQueryResultsForResourceGroupLevelPolicyAssignmentNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, policyEventType, policyQuerySettings, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else if (Id.Parent.ResourceType == _subscription)
                    {
                        var response = PolicyEventsRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentNextPage(nextLink, Id.SubscriptionId, Id.Name, policyEventType, policyQuerySettings, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value, response.Value.ODataNextLink, response.GetRawResponse());
                    }
                    else
                    {
                        throw new InvalidOperationException("This method can only execute against subscription level or resource group level policy assignment.");
                    }
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
