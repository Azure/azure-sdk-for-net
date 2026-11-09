// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.SecurityInsights;
using Azure.ResourceManager.SecurityInsights.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Mocking
{
    // Preserve the previously generated body parameter names for named-argument callers.
    [CodeGenSuppress("QueryThreatIntelligenceIndicatorsAsync", typeof(ResourceIdentifier), typeof(ThreatIntelligenceFilteringCriteria), typeof(CancellationToken))]
    [CodeGenSuppress("QueryThreatIntelligenceIndicators", typeof(ResourceIdentifier), typeof(ThreatIntelligenceFilteringCriteria), typeof(CancellationToken))]
    [CodeGenSuppress("PostAsync", typeof(ResourceIdentifier), typeof(Models.DataConnectorsCheckRequirements), typeof(CancellationToken))]
    [CodeGenSuppress("Post", typeof(ResourceIdentifier), typeof(Models.DataConnectorsCheckRequirements), typeof(CancellationToken))]
    public partial class MockableSecurityInsightsArmClient
    {
        /// <summary>
        /// Query threat intelligence indicators as per filtering criteria.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/queryIndicators. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ThreatIntelligenceIndicatorOperationGroup_QueryIndicators. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="threatIntelligenceFilteringCriteria"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="threatIntelligenceFilteringCriteria"/> is null. </exception>
        /// <returns> A collection of <see cref="SecurityInsightsThreatIntelligenceIndicatorResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityInsightsThreatIntelligenceIndicatorResource> QueryThreatIntelligenceIndicatorsAsync(ResourceIdentifier scope, ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNull(threatIntelligenceFilteringCriteria, nameof(threatIntelligenceFilteringCriteria));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new AsyncPageableWrapper<SecurityInsightsThreatIntelligenceIndicatorBaseData, SecurityInsightsThreatIntelligenceIndicatorResource>(new SecurityInsightsThreatIntelligenceIndicatorBaseDataAsyncCollectionResultOfT(
                ThreatIntelligenceIndicatorRestClient,
                Guid.Parse(scope.SubscriptionId),
                scope.ResourceGroupName,
                scope.Name,
                ThreatIntelligenceFilteringCriteria.ToRequestContent(threatIntelligenceFilteringCriteria),
                context,
                "MockableSecurityInsightsArmClient.QueryThreatIntelligenceIndicators"), data => new SecurityInsightsThreatIntelligenceIndicatorResource(Client, data));
        }

        /// <summary>
        /// Query threat intelligence indicators as per filtering criteria.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/queryIndicators. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> ThreatIntelligenceIndicatorOperationGroup_QueryIndicators. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="threatIntelligenceFilteringCriteria"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="threatIntelligenceFilteringCriteria"/> is null. </exception>
        /// <returns> A collection of <see cref="SecurityInsightsThreatIntelligenceIndicatorResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityInsightsThreatIntelligenceIndicatorResource> QueryThreatIntelligenceIndicators(ResourceIdentifier scope, ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNull(threatIntelligenceFilteringCriteria, nameof(threatIntelligenceFilteringCriteria));

            RequestContext context = new RequestContext
            {
                CancellationToken = cancellationToken
            };
            return new PageableWrapper<SecurityInsightsThreatIntelligenceIndicatorBaseData, SecurityInsightsThreatIntelligenceIndicatorResource>(new SecurityInsightsThreatIntelligenceIndicatorBaseDataCollectionResultOfT(
                ThreatIntelligenceIndicatorRestClient,
                Guid.Parse(scope.SubscriptionId),
                scope.ResourceGroupName,
                scope.Name,
                ThreatIntelligenceFilteringCriteria.ToRequestContent(threatIntelligenceFilteringCriteria),
                context,
                "MockableSecurityInsightsArmClient.QueryThreatIntelligenceIndicators"), data => new SecurityInsightsThreatIntelligenceIndicatorResource(Client, data));
        }

        /// <summary>
        /// Get requirements state for a data connector type.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectorsCheckRequirements. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DataConnectorsCheckRequirementsOperationGroup_Post. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="dataConnectorsCheckRequirements"> The parameters for requirements check message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="dataConnectorsCheckRequirements"/> is null. </exception>
        public virtual async Task<Response<DataConnectorRequirementsState>> PostAsync(ResourceIdentifier scope, Models.DataConnectorsCheckRequirements dataConnectorsCheckRequirements, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNull(dataConnectorsCheckRequirements, nameof(dataConnectorsCheckRequirements));

            using DiagnosticScope scope0 = DataConnectorsCheckRequirementsClientDiagnostics.CreateScope("MockableSecurityInsightsArmClient.Post");
            scope0.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = DataConnectorsCheckRequirementsRestClient.CreatePostRequest(Guid.Parse(scope.SubscriptionId), scope.ResourceGroupName, scope.Name, Models.DataConnectorsCheckRequirements.ToRequestContent(dataConnectorsCheckRequirements), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<DataConnectorRequirementsState> response = Response.FromValue(DataConnectorRequirementsState.FromResponse(result), result);
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

        /// <summary>
        /// Get requirements state for a data connector type.
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/dataConnectorsCheckRequirements. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> DataConnectorsCheckRequirementsOperationGroup_Post. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-01-preview. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="dataConnectorsCheckRequirements"> The parameters for requirements check message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="scope"/> or <paramref name="dataConnectorsCheckRequirements"/> is null. </exception>
        public virtual Response<DataConnectorRequirementsState> Post(ResourceIdentifier scope, Models.DataConnectorsCheckRequirements dataConnectorsCheckRequirements, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(scope, nameof(scope));
            Argument.AssertNotNull(dataConnectorsCheckRequirements, nameof(dataConnectorsCheckRequirements));

            using DiagnosticScope scope0 = DataConnectorsCheckRequirementsClientDiagnostics.CreateScope("MockableSecurityInsightsArmClient.Post");
            scope0.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = DataConnectorsCheckRequirementsRestClient.CreatePostRequest(Guid.Parse(scope.SubscriptionId), scope.ResourceGroupName, scope.Name, Models.DataConnectorsCheckRequirements.ToRequestContent(dataConnectorsCheckRequirements), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<DataConnectorRequirementsState> response = Response.FromValue(DataConnectorRequirementsState.FromResponse(result), result);
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
    }
}
