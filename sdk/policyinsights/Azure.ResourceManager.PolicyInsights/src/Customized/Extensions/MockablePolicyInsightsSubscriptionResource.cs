// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CheckAtSubscriptionScopeAsync", typeof(CheckPolicyRestrictionsContent), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("CheckAtSubscriptionScope", typeof(CheckPolicyRestrictionsContent), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionAsync", typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscription", typeof(PolicyEventType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionAsync", typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscription", typeof(PolicyStateType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForSubscriptionAsync", typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("SummarizeForSubscription", typeof(PolicyStateSummaryType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionAsync", typeof(PolicyTrackedResourceType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscription", typeof(PolicyTrackedResourceType), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    // ComponentPolicyStates — fix queryOptions forwarding (generator bug #59950)
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionComponentPolicyStatesAsync", typeof(ComponentPolicyStatesResource), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSuppress("GetQueryResultsForSubscriptionComponentPolicyStates", typeof(ComponentPolicyStatesResource), typeof(PolicyQuerySettings), typeof(CancellationToken))]
    public partial class MockablePolicyInsightsSubscriptionResource
    {
        /// <summary>
        /// Checks what restrictions Azure Policy will place on a resource within a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/checkPolicyRestrictions. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PolicyRestrictionsOperationGroup_CheckAtSubscriptionScope. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response<CheckPolicyRestrictionsResult>> CheckPolicyRestrictionsAsync(CheckPolicyRestrictionsContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = PolicyRestrictionsClientDiagnostics.CreateScope("MockablePolicyInsightsSubscriptionResource.CheckPolicyRestrictions");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = PolicyRestrictionsRestClient.CreateCheckAtSubscriptionScopeRequest(Id.SubscriptionId, CheckPolicyRestrictionsContent.ToRequestContent(content), context);
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
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks what restrictions Azure Policy will place on a resource within a subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/checkPolicyRestrictions. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PolicyRestrictionsOperationGroup_CheckAtSubscriptionScope. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The request body. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response<CheckPolicyRestrictionsResult> CheckPolicyRestrictions(CheckPolicyRestrictionsContent content, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(content, nameof(content));

            using DiagnosticScope scope = PolicyRestrictionsClientDiagnostics.CreateScope("MockablePolicyInsightsSubscriptionResource.CheckPolicyRestrictions");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = PolicyRestrictionsRestClient.CreateCheckAtSubscriptionScopeRequest(Id.SubscriptionId, CheckPolicyRestrictionsContent.ToRequestContent(content), context);
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
                scope.Failed(e);
                throw;
            }
        }

        // ===== Renamed: GetQueryResultsForSubscription -> GetPolicyEventQueryResults / GetPolicyStateQueryResults =====

        /// <summary> Queries policy events for the resources under the subscription. </summary>
        public virtual AsyncPageable<PolicyEvent> GetPolicyEventQueryResultsAsync(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyEventsGetQueryResultsForSubscriptionAsyncCollectionResultOfT(
                PolicyEventsRestClient, Id.SubscriptionId, policyEventType.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsSubscriptionResource.GetPolicyEventQueryResults");
        }

        /// <summary> Queries policy events for the resources under the subscription. </summary>
        public virtual Pageable<PolicyEvent> GetPolicyEventQueryResults(PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyEventsGetQueryResultsForSubscriptionCollectionResultOfT(
                PolicyEventsRestClient, Id.SubscriptionId, policyEventType.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsSubscriptionResource.GetPolicyEventQueryResults");
        }

        /// <summary> Queries policy states for the resources under the subscription. </summary>
        public virtual AsyncPageable<PolicyState> GetPolicyStateQueryResultsAsync(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyStatesGetQueryResultsForSubscriptionAsyncCollectionResultOfT(
                PolicyStatesRestClient, Id.SubscriptionId, policyStateType.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsSubscriptionResource.GetPolicyStateQueryResults");
        }

        /// <summary> Queries policy states for the resources under the subscription. </summary>
        public virtual Pageable<PolicyState> GetPolicyStateQueryResults(PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyStatesGetQueryResultsForSubscriptionCollectionResultOfT(
                PolicyStatesRestClient, Id.SubscriptionId, policyStateType.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.OrderBy, policyQuerySettings?.Select,
                policyQuerySettings?.From, policyQuerySettings?.To, policyQuerySettings?.Filter,
                policyQuerySettings?.Apply, policyQuerySettings?.SkipToken,
                context, "MockablePolicyInsightsSubscriptionResource.GetPolicyStateQueryResults");
        }

        /// <summary>
        /// Summarizes policy states for the resources under the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PolicyStatesOperationGroup_SummarizeForSubscription. </description>
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
            return new PolicyStatesSummarizeForSubscriptionAsyncCollectionResultOfT(
                PolicyStatesRestClient,
                Id.SubscriptionId,
                policyStateSummaryType.ToString(),
                policyQuerySettings?.Top,
                policyQuerySettings?.From,
                policyQuerySettings?.To,
                policyQuerySettings?.Filter,
                context,
                "MockablePolicyInsightsSubscriptionResource.SummarizePolicyStates");
        }

        /// <summary>
        /// Summarizes policy states for the resources under the subscription.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/policyStates/{policyStatesSummaryResource}/summarize. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> PolicyStatesOperationGroup_SummarizeForSubscription. </description>
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
            return new PolicyStatesSummarizeForSubscriptionCollectionResultOfT(
                PolicyStatesRestClient,
                Id.SubscriptionId,
                policyStateSummaryType.ToString(),
                policyQuerySettings?.Top,
                policyQuerySettings?.From,
                policyQuerySettings?.To,
                policyQuerySettings?.Filter,
                context,
                "MockablePolicyInsightsSubscriptionResource.SummarizePolicyStates");
        }

        /// <summary>
        /// Queries component policy states under subscription scope.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/componentPolicyStates/{componentPolicyStatesResource}/queryResults. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ComponentPolicyStatesOperationGroup_ListQueryResultsForSubscription. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="componentPolicyStatesResource"></param>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<ComponentPolicyState> GetQueryResultsForSubscriptionComponentPolicyStatesAsync(ComponentPolicyStatesResource componentPolicyStatesResource, PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ComponentPolicyStatesGetQueryResultsForSubscriptionComponentPolicyStatesAsyncCollectionResultOfT(
                ComponentPolicyStatesRestClient, Id.SubscriptionId, componentPolicyStatesResource.ToString(),
                queryOptions?.Top, queryOptions?.OrderBy, queryOptions?.Select,
                queryOptions?.From, queryOptions?.To, queryOptions?.Filter, queryOptions?.Apply,
                context, "MockablePolicyInsightsSubscriptionResource.GetQueryResultsForSubscriptionComponentPolicyStates");
        }

        /// <summary>
        /// Queries component policy states under subscription scope.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/providers/Microsoft.PolicyInsights/componentPolicyStates/{componentPolicyStatesResource}/queryResults. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ComponentPolicyStatesOperationGroup_ListQueryResultsForSubscription. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2024-10-01. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="componentPolicyStatesResource"></param>
        /// <param name="queryOptions"></param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<ComponentPolicyState> GetQueryResultsForSubscriptionComponentPolicyStates(ComponentPolicyStatesResource componentPolicyStatesResource, PolicyQuerySettings queryOptions = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new ComponentPolicyStatesGetQueryResultsForSubscriptionComponentPolicyStatesCollectionResultOfT(
                ComponentPolicyStatesRestClient, Id.SubscriptionId, componentPolicyStatesResource.ToString(),
                queryOptions?.Top, queryOptions?.OrderBy, queryOptions?.Select,
                queryOptions?.From, queryOptions?.To, queryOptions?.Filter, queryOptions?.Apply,
                context, "MockablePolicyInsightsSubscriptionResource.GetQueryResultsForSubscriptionComponentPolicyStates");
        }

        /// <summary> Queries policy tracked resources under the subscription. </summary>
        public virtual AsyncPageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResultsAsync(PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyTrackedResourcesGetQueryResultsForSubscriptionAsyncCollectionResultOfT(
                PolicyTrackedResourcesRestClient, Id.SubscriptionId, policyTrackedResourceType.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.Filter,
                context, "MockablePolicyInsightsSubscriptionResource.GetPolicyTrackedResourceQueryResults");
        }

        /// <summary> Queries policy tracked resources under the subscription. </summary>
        public virtual Pageable<PolicyTrackedResourceRecord> GetPolicyTrackedResourceQueryResults(PolicyTrackedResourceType policyTrackedResourceType, PolicyQuerySettings policyQuerySettings = default, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            return new PolicyTrackedResourcesGetQueryResultsForSubscriptionCollectionResultOfT(
                PolicyTrackedResourcesRestClient, Id.SubscriptionId, policyTrackedResourceType.ToString(),
                policyQuerySettings?.Top, policyQuerySettings?.Filter,
                context, "MockablePolicyInsightsSubscriptionResource.GetPolicyTrackedResourceQueryResults");
        }

        // ===== GA-shape ComponentPolicyStates query overloads (obsolete + throw) =====

        /// <summary> [Obsolete] Use the new GetQueryResultsForSubscriptionComponentPolicyStatesAsync(ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) overload instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use GetQueryResultsForSubscriptionComponentPolicyStatesAsync(ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) instead.")]
        public virtual AsyncPageable<ComponentPolicyState> GetQueryResultsForSubscriptionComponentPolicyStatesAsync(SubscriptionResourceGetQueryResultsForSubscriptionComponentPolicyStatesOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use GetQueryResultsForSubscriptionComponentPolicyStatesAsync(ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) instead.");
        }

        /// <summary> [Obsolete] Use the new GetQueryResultsForSubscriptionComponentPolicyStates(ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) overload instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use GetQueryResultsForSubscriptionComponentPolicyStates(ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) instead.")]
        public virtual Pageable<ComponentPolicyState> GetQueryResultsForSubscriptionComponentPolicyStates(SubscriptionResourceGetQueryResultsForSubscriptionComponentPolicyStatesOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use GetQueryResultsForSubscriptionComponentPolicyStates(ComponentPolicyStatesResource, PolicyQuerySettings, CancellationToken) instead.");
        }

        /// <summary> [Obsolete] Use the new GetQueryResultsForPolicyDefinitionComponentPolicyStatesAsync(...) overload instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the new GetQueryResultsForPolicyDefinitionComponentPolicyStatesAsync overload on ArmClient instead.")]
        public virtual AsyncPageable<ComponentPolicyState> GetQueryResultsForPolicyDefinitionComponentPolicyStatesAsync(SubscriptionResourceGetQueryResultsForPolicyDefinitionComponentPolicyStatesOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the new GetQueryResultsForPolicyDefinitionComponentPolicyStatesAsync overload on ArmClient instead.");
        }

        /// <summary> [Obsolete] Use the new GetQueryResultsForPolicyDefinitionComponentPolicyStates(...) overload instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the new GetQueryResultsForPolicyDefinitionComponentPolicyStates overload on ArmClient instead.")]
        public virtual Pageable<ComponentPolicyState> GetQueryResultsForPolicyDefinitionComponentPolicyStates(SubscriptionResourceGetQueryResultsForPolicyDefinitionComponentPolicyStatesOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the new GetQueryResultsForPolicyDefinitionComponentPolicyStates overload on ArmClient instead.");
        }

        /// <summary> [Obsolete] Use the new GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesAsync(...) overload instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the new GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesAsync overload on ArmClient instead.")]
        public virtual AsyncPageable<ComponentPolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesAsync(SubscriptionResourceGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the new GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesAsync overload on ArmClient instead.");
        }

        /// <summary> [Obsolete] Use the new GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStates(...) overload instead. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the new GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStates overload on ArmClient instead.")]
        public virtual Pageable<ComponentPolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStates(SubscriptionResourceGetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStatesOptions options, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the new GetQueryResultsForSubscriptionLevelPolicyAssignmentComponentPolicyStates overload on ArmClient instead.");
        }

        // ===== Orphaned GA Mockable Get/Summarize* with (string name, ...) signature (obsolete + throw) =====
        // These were never reached by any extension method on PolicyInsightsExtensions in GA.
        // Retained only to satisfy ApiCompat; use the dedicated SubscriptionPolicyDefinitionResource / SubscriptionPolicySetDefinitionResource / PolicyAssignmentResource APIs instead.
        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicyDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.")]
        public virtual AsyncPageable<PolicyEvent> GetQueryResultsForPolicyDefinitionPolicyEventsAsync(string policyDefinitionName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicyDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.")]
        public virtual Pageable<PolicyEvent> GetQueryResultsForPolicyDefinitionPolicyEvents(string policyDefinitionName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicyDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.")]
        public virtual AsyncPageable<PolicyState> GetQueryResultsForPolicyDefinitionPolicyStatesAsync(string policyDefinitionName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicyDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.")]
        public virtual Pageable<PolicyState> GetQueryResultsForPolicyDefinitionPolicyStates(string policyDefinitionName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicySetDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.")]
        public virtual AsyncPageable<PolicyEvent> GetQueryResultsForPolicySetDefinitionPolicyEventsAsync(string policySetDefinitionName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicySetDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.")]
        public virtual Pageable<PolicyEvent> GetQueryResultsForPolicySetDefinitionPolicyEvents(string policySetDefinitionName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicySetDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.")]
        public virtual AsyncPageable<PolicyState> GetQueryResultsForPolicySetDefinitionPolicyStatesAsync(string policySetDefinitionName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicySetDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.")]
        public virtual Pageable<PolicyState> GetQueryResultsForPolicySetDefinitionPolicyStates(string policySetDefinitionName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated PolicyAssignmentResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.")]
        public virtual AsyncPageable<PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEventsAsync(string policyAssignmentName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated PolicyAssignmentResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.")]
        public virtual Pageable<PolicyEvent> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyEvents(string policyAssignmentName, PolicyEventType policyEventType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated PolicyAssignmentResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.")]
        public virtual AsyncPageable<PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStatesAsync(string policyAssignmentName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated PolicyAssignmentResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.")]
        public virtual Pageable<PolicyState> GetQueryResultsForSubscriptionLevelPolicyAssignmentPolicyStates(string policyAssignmentName, PolicyStateType policyStateType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicyDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.")]
        public virtual AsyncPageable<PolicySummary> SummarizeForPolicyDefinitionPolicyStatesAsync(string policyDefinitionName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicyDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.")]
        public virtual Pageable<PolicySummary> SummarizeForPolicyDefinitionPolicyStates(string policyDefinitionName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicyDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicySetDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.")]
        public virtual AsyncPageable<PolicySummary> SummarizeForPolicySetDefinitionPolicyStatesAsync(string policySetDefinitionName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated SubscriptionPolicySetDefinitionResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.")]
        public virtual Pageable<PolicySummary> SummarizeForPolicySetDefinitionPolicyStates(string policySetDefinitionName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated SubscriptionPolicySetDefinitionResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated PolicyAssignmentResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.")]
        public virtual AsyncPageable<PolicySummary> SummarizeForSubscriptionLevelPolicyAssignmentPolicyStatesAsync(string policyAssignmentName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.");
        }

        /// <summary> [Obsolete] Orphan GA shape. No replacement; use the dedicated PolicyAssignmentResource APIs. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.")]
        public virtual Pageable<PolicySummary> SummarizeForSubscriptionLevelPolicyAssignmentPolicyStates(string policyAssignmentName, PolicyStateSummaryType policyStateSummaryType, PolicyQuerySettings policyQuerySettings = null, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("This overload is no longer supported. Use the dedicated PolicyAssignmentResource APIs instead.");
        }
    }
}
