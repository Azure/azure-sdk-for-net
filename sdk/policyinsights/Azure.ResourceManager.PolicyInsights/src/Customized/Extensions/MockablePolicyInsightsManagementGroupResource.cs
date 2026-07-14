// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    /// <summary>
    /// A class to add extension methods to <see cref="Azure.ResourceManager.ManagementGroups.ManagementGroupResource"/>.
    /// Re-hosts PolicyEvents/PolicyStates/Summarize from generic <c>ArmClient</c> scope onto
    /// <c>ManagementGroupResource</c> for discoverability, matching GA shape.
    /// </summary>
    public partial class MockablePolicyInsightsManagementGroupResource : ArmResource
    {
        private ClientDiagnostics _policyEventsClientDiagnostics;
        private PolicyEvents _policyEventsRestClient;
        private ClientDiagnostics _policyStatesClientDiagnostics;
        private PolicyStates _policyStatesRestClient;
        private ClientDiagnostics _policyRestrictionsClientDiagnostics;
        private PolicyRestrictions _policyRestrictionsRestClient;

        /// <summary> Initializes a new instance of <see cref="MockablePolicyInsightsManagementGroupResource"/> for mocking. </summary>
        protected MockablePolicyInsightsManagementGroupResource()
        {
        }

        /// <summary> Initializes a new instance of <see cref="MockablePolicyInsightsManagementGroupResource"/>. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal MockablePolicyInsightsManagementGroupResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        private ClientDiagnostics PolicyEventsClientDiagnostics => _policyEventsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.PolicyInsights.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private PolicyEvents PolicyEventsRestClient => _policyEventsRestClient ??= new PolicyEvents(PolicyEventsClientDiagnostics, Pipeline, Endpoint, "2024-10-01");
        private ClientDiagnostics PolicyStatesClientDiagnostics => _policyStatesClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.PolicyInsights.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private PolicyStates PolicyStatesRestClient => _policyStatesRestClient ??= new PolicyStates(PolicyStatesClientDiagnostics, Pipeline, Endpoint, "2024-10-01");
        private ClientDiagnostics PolicyRestrictionsClientDiagnostics => _policyRestrictionsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.PolicyInsights.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private PolicyRestrictions PolicyRestrictionsRestClient => _policyRestrictionsRestClient ??= new PolicyRestrictions(PolicyRestrictionsClientDiagnostics, Pipeline, Endpoint, "2024-10-01");
        private ClientDiagnostics _policyTrackedResourcesClientDiagnostics;
        private PolicyTrackedResources _policyTrackedResourcesRestClient;
        private ClientDiagnostics PolicyTrackedResourcesClientDiagnostics => _policyTrackedResourcesClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.PolicyInsights.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private PolicyTrackedResources PolicyTrackedResourcesRestClient => _policyTrackedResourcesRestClient ??= new PolicyTrackedResources(PolicyTrackedResourcesClientDiagnostics, Pipeline, Endpoint, "2018-07-01-preview");

        /// <summary> Checks what restrictions Azure Policy will place on resources within a management group. </summary>
        /// <param name="content"> The check policy restrictions parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(CheckManagementGroupPolicyRestrictionsContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope0 = PolicyRestrictionsClientDiagnostics.CreateScope("MockablePolicyInsightsManagementGroupResource.CheckPolicyRestrictions");
            scope0.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = PolicyRestrictionsRestClient.CreateCheckAtManagementGroupScopeRequest(Id.Name, CheckManagementGroupPolicyRestrictionsContent.ToRequestContent(content), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<CheckPolicyRestrictionsResult> response = Response.FromValue(CheckPolicyRestrictionsResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <summary> Checks what restrictions Azure Policy will place on resources within a management group. </summary>
        /// <param name="content"> The check policy restrictions parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<CheckPolicyRestrictionsResult> CheckPolicyRestrictions(CheckManagementGroupPolicyRestrictionsContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope0 = PolicyRestrictionsClientDiagnostics.CreateScope("MockablePolicyInsightsManagementGroupResource.CheckPolicyRestrictions");
            scope0.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = PolicyRestrictionsRestClient.CreateCheckAtManagementGroupScopeRequest(Id.Name, CheckManagementGroupPolicyRestrictionsContent.ToRequestContent(content), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<CheckPolicyRestrictionsResult> response = Response.FromValue(CheckPolicyRestrictionsResult.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope0.Failed(e);
                throw;
            }
        }

        /// <summary> Queries policy events for the resources under the management group. </summary>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyEventsGetQueryResultsForManagementGroupAsyncCollectionResultOfT(
                PolicyEventsRestClient, policyEventType.ToString(), Id.Name,
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsManagementGroupResource.GetPolicyEventQueryResults");
        }

        /// <summary> Queries policy events for the resources under the management group. </summary>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyEventsGetQueryResultsForManagementGroupCollectionResultOfT(
                PolicyEventsRestClient, policyEventType.ToString(), Id.Name,
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsManagementGroupResource.GetPolicyEventQueryResults");
        }

        /// <summary> Queries policy states for the resources under the management group. </summary>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyStatesGetQueryResultsForManagementGroupAsyncCollectionResultOfT(
                PolicyStatesRestClient, policyStateType.ToString(), Id.Name,
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsManagementGroupResource.GetPolicyStateQueryResults");
        }

        /// <summary> Queries policy states for the resources under the management group. </summary>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyStatesGetQueryResultsForManagementGroupCollectionResultOfT(
                PolicyStatesRestClient, policyStateType.ToString(), Id.Name,
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsManagementGroupResource.GetPolicyStateQueryResults");
        }

        /// <summary>
        /// Summarizes policy states for the resources under the management group.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/{managementGroupsNamespace}/managementGroups/{managementGroupName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PolicyStatesOperationGroup_SummarizeForManagementGroup. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyStateSummaryType"></param>
        /// <param name="policyQuerySettings"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicySummary"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<PolicySummary> SummarizePolicyStatesAsync(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PolicyStatesSummarizeForManagementGroupAsyncCollectionResultOfT(
                PolicyStatesRestClient,
                policyStateSummaryType.ToString(),
                Id.Name,
                policyQuerySettings?.Top,
                policyQuerySettings?.From,
                policyQuerySettings?.To,
                policyQuerySettings?.Filter,
                context,
                "MockablePolicyInsightsManagementGroupResource.SummarizePolicyStates");
        }

        /// <summary>
        /// Summarizes policy states for the resources under the management group.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /providers/{managementGroupsNamespace}/managementGroups/{managementGroupName}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PolicyStatesOperationGroup_SummarizeForManagementGroup. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="policyStateSummaryType"></param>
        /// <param name="policyQuerySettings"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="PolicySummary"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<PolicySummary> SummarizePolicyStates(PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PolicyStatesSummarizeForManagementGroupCollectionResultOfT(
                PolicyStatesRestClient,
                policyStateSummaryType.ToString(),
                Id.Name,
                policyQuerySettings?.Top,
                policyQuerySettings?.From,
                policyQuerySettings?.To,
                policyQuerySettings?.Filter,
                context,
                "MockablePolicyInsightsManagementGroupResource.SummarizePolicyStates");
        }

        /// <summary> Queries policy tracked resources under the management group. </summary>
        public virtual AsyncPageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyTrackedResourcesGetQueryResultsForManagementGroupAsyncCollectionResultOfT(
                PolicyTrackedResourcesRestClient, Id.Name, policyTrackedResourceType.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.Filter,
                context, "MockablePolicyInsightsManagementGroupResource.GetPolicyTrackedResourceQueryResults");
        }

        /// <summary> Queries policy tracked resources under the management group. </summary>
        public virtual Pageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyTrackedResourcesGetQueryResultsForManagementGroupCollectionResultOfT(
                PolicyTrackedResourcesRestClient, Id.Name, policyTrackedResourceType.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.Filter,
                context, "MockablePolicyInsightsManagementGroupResource.GetPolicyTrackedResourceQueryResults");
        }
    }
}
