// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.SecurityInsights.Mocking;
using Azure.ResourceManager.SecurityInsights.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights
{
    // Preserve the previously generated body parameter names for named-argument callers.
    // TODO: Remove this customization after https://github.com/Azure/azure-sdk-for-net/issues/64685 is fixed.
    [CodeGenSuppress("QueryThreatIntelligenceIndicatorsAsync", typeof(ArmClient), typeof(ResourceIdentifier), typeof(ThreatIntelligenceFilteringCriteria), typeof(CancellationToken))]
    [CodeGenSuppress("QueryThreatIntelligenceIndicators", typeof(ArmClient), typeof(ResourceIdentifier), typeof(ThreatIntelligenceFilteringCriteria), typeof(CancellationToken))]
    [CodeGenSuppress("PostAsync", typeof(ArmClient), typeof(ResourceIdentifier), typeof(Models.DataConnectorsCheckRequirements), typeof(CancellationToken))]
    [CodeGenSuppress("Post", typeof(ArmClient), typeof(ResourceIdentifier), typeof(Models.DataConnectorsCheckRequirements), typeof(CancellationToken))]
    public static partial class SecurityInsightsExtensions
    {
        /// <summary>
        /// Query threat intelligence indicators as per filtering criteria.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableSecurityInsightsArmClient.QueryThreatIntelligenceIndicatorsAsync(ResourceIdentifier, ThreatIntelligenceFilteringCriteria, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="threatIntelligenceFilteringCriteria"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> A collection of <see cref="SecurityInsightsThreatIntelligenceIndicatorResource"/> that may take multiple service requests to iterate over. </returns>
        public static AsyncPageable<SecurityInsightsThreatIntelligenceIndicatorResource> QueryThreatIntelligenceIndicatorsAsync(this ArmClient client, ResourceIdentifier scope, ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableSecurityInsightsArmClient(client).QueryThreatIntelligenceIndicatorsAsync(scope, threatIntelligenceFilteringCriteria, cancellationToken);
        }

        /// <summary>
        /// Query threat intelligence indicators as per filtering criteria.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableSecurityInsightsArmClient.QueryThreatIntelligenceIndicators(ResourceIdentifier, ThreatIntelligenceFilteringCriteria, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="threatIntelligenceFilteringCriteria"> The content of the action request. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        /// <returns> A collection of <see cref="SecurityInsightsThreatIntelligenceIndicatorResource"/> that may take multiple service requests to iterate over. </returns>
        public static Pageable<SecurityInsightsThreatIntelligenceIndicatorResource> QueryThreatIntelligenceIndicators(this ArmClient client, ResourceIdentifier scope, ThreatIntelligenceFilteringCriteria threatIntelligenceFilteringCriteria, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableSecurityInsightsArmClient(client).QueryThreatIntelligenceIndicators(scope, threatIntelligenceFilteringCriteria, cancellationToken);
        }

        /// <summary>
        /// Get requirements state for a data connector type.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableSecurityInsightsArmClient.PostAsync(ResourceIdentifier, Models.DataConnectorsCheckRequirements, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="dataConnectorsCheckRequirements"> The parameters for requirements check message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        public static async Task<Response<DataConnectorRequirementsState>> PostAsync(this ArmClient client, ResourceIdentifier scope, Models.DataConnectorsCheckRequirements dataConnectorsCheckRequirements, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return await GetMockableSecurityInsightsArmClient(client).PostAsync(scope, dataConnectorsCheckRequirements, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get requirements state for a data connector type.
        /// <item>
        /// <term> Mocking. </term>
        /// <description> To mock this method, please mock <see cref="MockableSecurityInsightsArmClient.Post(ResourceIdentifier, Models.DataConnectorsCheckRequirements, CancellationToken)"/> instead. </description>
        /// </item>
        /// </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="scope"> The scope that the resource will apply against. </param>
        /// <param name="dataConnectorsCheckRequirements"> The parameters for requirements check message. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="client"/> is null. </exception>
        public static Response<DataConnectorRequirementsState> Post(this ArmClient client, ResourceIdentifier scope, Models.DataConnectorsCheckRequirements dataConnectorsCheckRequirements, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(client, nameof(client));

            return GetMockableSecurityInsightsArmClient(client).Post(scope, dataConnectorsCheckRequirements, cancellationToken);
        }
    }
}
