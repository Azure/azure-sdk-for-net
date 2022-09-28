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
    /// <summary>
    /// A class extending from the SubscriptionPolicyAssignmentResource in Azure.ResourceManager.PolicyInsights along with the instance operations that can be performed on it.
    /// You can only construct a <see cref="SubscriptionPolicyAssignmentPolicyInsightsResource" /> from a <see cref="ResourceIdentifier" /> with a resource type of Microsoft.Authorization/policyAssignments.
    /// </summary>
    public partial class SubscriptionPolicyAssignmentPolicyInsightsResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="SubscriptionPolicyAssignmentPolicyInsightsResource"/> instance. </summary>
        internal static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string policyAssignmentName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _policyEventsClientDiagnostics;
        private readonly PolicyEventsRestOperations _policyEventsRestClient;
        private readonly ClientDiagnostics _policyStatesClientDiagnostics;
        private readonly PolicyStatesRestOperations _policyStatesRestClient;

        /// <summary> Initializes a new instance of the <see cref="SubscriptionPolicyAssignmentPolicyInsightsResource"/> class for mocking. </summary>
        protected SubscriptionPolicyAssignmentPolicyInsightsResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SubscriptionPolicyAssignmentPolicyInsightsResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal SubscriptionPolicyAssignmentPolicyInsightsResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _policyEventsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PolicyInsights", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _policyEventsRestClient = new PolicyEventsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
            _policyStatesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.PolicyInsights", ProviderConstants.DefaultProviderNamespace, Diagnostics);
            _policyStatesRestClient = new PolicyStatesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Authorization/policyAssignments";

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary>
        /// Summarizes policy states for the subscription level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForSubscriptionLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicySummary>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicyAssignmentPolicyInsightsResource.SummarizePolicyStates");
                scope.Start();
                try
                {
                    var response = await _policyStatesRestClient.SummarizeForSubscriptionLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.Name, policyStatesSummaryResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Summarizes policy states for the subscription level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize
        /// Operation Id: PolicyStates_SummarizeForSubscriptionLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStatesSummaryResource"> The virtual resource under PolicyStates resource type for summarize action. In a given time range, &apos;latest&apos; represents the latest policy state(s) and is the only allowed value. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicySummary" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStatesSummaryResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            Page<PolicySummary> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicyAssignmentPolicyInsightsResource.SummarizePolicyStates");
                scope.Start();
                try
                {
                    var response = _policyStatesRestClient.SummarizeForSubscriptionLevelPolicyAssignment(Id.SubscriptionId, Id.Name, policyStatesSummaryResource, queryOptions, cancellationToken: cancellationToken);
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
        /// Queries policy states for the subscription level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicyState>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicyAssignmentPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyStatesRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicyAssignmentPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyStatesRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Queries policy states for the subscription level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesResource}/queryResults
        /// Operation Id: PolicyStates_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// </summary>
        /// <param name="policyStatesResource"> The virtual resource under PolicyStates resource type. In a given time range, &apos;latest&apos; represents the latest policy state(s), whereas &apos;default&apos; represents all policy state(s). </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyState" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStatesResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            Page<PolicyState> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicyAssignmentPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = _policyStatesRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignment(Id.SubscriptionId, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken);
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
                using var scope = _policyStatesClientDiagnostics.CreateScope("SubscriptionPolicyAssignmentPolicyInsightsResource.GetPolicyStateQueryResults");
                scope.Start();
                try
                {
                    var response = _policyStatesRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentNextPage(nextLink, Id.SubscriptionId, Id.Name, policyStatesResource, queryOptions, cancellationToken: cancellationToken);
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
        /// Queries policy events for the subscription level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// </summary>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<PolicyEvent>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyEventsClientDiagnostics.CreateScope("SubscriptionPolicyAssignmentPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyEventsRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentAsync(Id.SubscriptionId, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
                using var scope = _policyEventsClientDiagnostics.CreateScope("SubscriptionPolicyAssignmentPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = await _policyEventsRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentNextPageAsync(nextLink, Id.SubscriptionId, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Queries policy events for the subscription level policy assignment.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Authorization/policyAssignments/{policyAssignmentName}/providers/Microsoft.PolicyInsights/policyEvents/{policyEventsResource}/queryResults
        /// Operation Id: PolicyEvents_ListQueryResultsForSubscriptionLevelPolicyAssignment
        /// </summary>
        /// <param name="policyEventsResource"> The name of the virtual resource under PolicyEvents resource type; only &quot;default&quot; is allowed. </param>
        /// <param name="queryOptions"> Parameter group. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicyEvent" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventsResource, PolicyQuerySettings queryOptions = null, CancellationToken cancellationToken = default)
        {
            Page<PolicyEvent> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _policyEventsClientDiagnostics.CreateScope("SubscriptionPolicyAssignmentPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = _policyEventsRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignment(Id.SubscriptionId, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken);
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
                using var scope = _policyEventsClientDiagnostics.CreateScope("SubscriptionPolicyAssignmentPolicyInsightsResource.GetPolicyEventQueryResults");
                scope.Start();
                try
                {
                    var response = _policyEventsRestClient.ListQueryResultsForSubscriptionLevelPolicyAssignmentNextPage(nextLink, Id.SubscriptionId, Id.Name, policyEventsResource, queryOptions, cancellationToken: cancellationToken);
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
