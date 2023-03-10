// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.SecurityInsights.Models;

namespace Azure.ResourceManager.SecurityInsights
{
    public partial class SecurityInsightsThreatIntelligenceIndicatorCollection
    {
        // we have these customized two methods here because in its generated version, the parameter name of SecurityInsightsThreatIntelligenceIndicatorData is "content", and when this package goes GA, it is "data"
        // we currently do not have a way to change it using configuration through our generator therefore we have to use customized code here.
        /// <summary>
        /// Update a threat Intelligence indicator.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ThreatIntelligenceIndicators_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Threat intelligence indicator name field. </param>
        /// <param name="data"> Properties of threat intelligence indicators to create and update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SecurityInsightsThreatIntelligenceIndicatorResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, SecurityInsightsThreatIntelligenceIndicatorData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsThreatIntelligenceIndicatorThreatIntelligenceIndicatorsClientDiagnostics.CreateScope("SecurityInsightsThreatIntelligenceIndicatorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _securityInsightsThreatIntelligenceIndicatorThreatIntelligenceIndicatorsRestClient.UpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, data, cancellationToken).ConfigureAwait(false);
                var operation = new SecurityInsightsArmOperation<SecurityInsightsThreatIntelligenceIndicatorResource>(Response.FromValue(new SecurityInsightsThreatIntelligenceIndicatorResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update a threat Intelligence indicator.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/threatIntelligence/main/indicators/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ThreatIntelligenceIndicators_Update</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Threat intelligence indicator name field. </param>
        /// <param name="data"> Properties of threat intelligence indicators to create and update. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SecurityInsightsThreatIntelligenceIndicatorResource> CreateOrUpdate(WaitUntil waitUntil, string name, SecurityInsightsThreatIntelligenceIndicatorData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsThreatIntelligenceIndicatorThreatIntelligenceIndicatorsClientDiagnostics.CreateScope("SecurityInsightsThreatIntelligenceIndicatorCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _securityInsightsThreatIntelligenceIndicatorThreatIntelligenceIndicatorsRestClient.Update(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, name, data, cancellationToken);
                var operation = new SecurityInsightsArmOperation<SecurityInsightsThreatIntelligenceIndicatorResource>(Response.FromValue(new SecurityInsightsThreatIntelligenceIndicatorResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
