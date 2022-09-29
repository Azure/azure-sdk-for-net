// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Globalization;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights
{
    /// <summary> A class to add extension methods to SubscriptionPolicySetDefinition. </summary>
    public partial class SubscriptionPolicySetDefinitionResourceExtensionClient : ArmResource
    {
        private ClientDiagnostics _policyEventsClientDiagnostics;
        private PolicyEventsRestOperations _policyEventsRestClient;
        private ClientDiagnostics _policyStatesClientDiagnostics;
        private PolicyStatesRestOperations _policyStatesRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionPolicySetDefinitionResourceExtensionClient"/> class for mocking. </summary>
        protected SubscriptionPolicySetDefinitionResourceExtensionClient()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionPolicySetDefinitionResourceExtensionClient"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionPolicySetDefinitionResourceExtensionClient(ArmClient client, ResourceIdentifier id) : base(client, id)
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
        /// Summarizes policy states for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForPolicySetDefinition
        /// </summary>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicySummary>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionPolicyInsightsResource.SummarizePolicyStates");
                scope.Start();
                try
                {
                    var response = await _policyStatesRestClient.SummarizeForPolicySetDefinitionAsync(Id.SubscriptionId, Id.Name, policyStatesSummaryResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
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
        /// Summarizes policy states for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForPolicySetDefinition
        /// </summary>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            Page<PolicySummary> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionPolicyInsightsResource.SummarizePolicyStates");
                scope.Start();
                try
                {
                    var response = _policyStatesRestClient.SummarizeForPolicySetDefinition(Id.SubscriptionId, Id.Name, policyStatesSummaryResource, queryOptions, cancellationToken: cancellationToken);
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
        /// Queries policy states for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForPolicySetDefinition
        /// </summary>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicyState>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyStatesRestClient.ListQueryResultsForPolicySetDefinitionAsync(Id.SubscriptionId, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyStatesRestClient.ListQueryResultsForPolicySetDefinitionNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Queries policy states for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForPolicySetDefinition
        /// </summary>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            Page<PolicyState> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = _policyStatesRestClient.ListQueryResultsForPolicySetDefinition(Id.SubscriptionId, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken);
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
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = _policyStatesRestClient.ListQueryResultsForPolicySetDefinitionNextPage(nextLink, Id.SubscriptionId, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken);
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
        /// Queries policy events for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForPolicySetDefinition
        /// </summary>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicyEvent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyEventsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyEventsRestClient.ListQueryResultsForPolicySetDefinitionAsync(Id.SubscriptionId, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _policyEventsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyEventsRestClient.ListQueryResultsForPolicySetDefinitionNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Queries policy events for the subscription level policy set definition.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policySetDefinitions/{policySetDefinitionName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForPolicySetDefinition
        /// </summary>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            Page<PolicyEvent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyEventsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = _policyEventsRestClient.ListQueryResultsForPolicySetDefinition(Id.SubscriptionId, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken);
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
                using var scope = _policyEventsClientDiagnostics.CreateScope("SubscriptionPolicySetDefinitionPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = _policyEventsRestClient.ListQueryResultsForPolicySetDefinitionNextPage(nextLink, Id.SubscriptionId, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken);
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
    }
}
