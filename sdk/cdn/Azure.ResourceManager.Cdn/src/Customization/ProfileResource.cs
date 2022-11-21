// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Cdn.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Cdn
{
    /// <summary>
    /// A Class representing a Profile along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="ProfileResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetProfileResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetProfile method.
    /// </summary>
    public partial class ProfileResource : ArmResource
    {
        /// <summary>
        /// Get log report for AFD profile
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getLogAnalyticsMetrics
        /// Operation Id: LogAnalytics_GetLogAnalyticsMetrics
        /// </summary>
        /// <param name="metrics"> The ArrayOfLogMetric to use. </param>
        /// <param name="dateTimeBegin"> The DateTime to use. </param>
        /// <param name="dateTimeEnd"> The DateTime to use. </param>
        /// <param name="granularity"> The LogMetricsGranularity to use. </param>
        /// <param name="customDomains"> The ArrayOfGet11ItemsItem to use. </param>
        /// <param name="protocols"> The ArrayOfGet12ItemsItem to use. </param>
        /// <param name="groupBy"> The ArrayOfLogMetricsGroupBy to use. </param>
        /// <param name="continents"> The ArrayOfGet9ItemsItem to use. </param>
        /// <param name="countryOrRegions"> The ArrayOfGet10ItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metrics"/>, <paramref name="customDomains"/> or <paramref name="protocols"/> is null. </exception>
        public virtual async Task<Response<MetricsResponse>> GetLogAnalyticsMetricsAsync(IEnumerable<LogMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, LogMetricsGranularity granularity, IEnumerable<string> customDomains, IEnumerable<string> protocols, IEnumerable<LogMetricsGroupBy> groupBy = null, IEnumerable<string> continents = null, IEnumerable<string> countryOrRegions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(metrics, nameof(metrics));
            Argument.AssertNotNull(customDomains, nameof(customDomains));
            Argument.AssertNotNull(protocols, nameof(protocols));

            using var scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetLogAnalyticsMetrics");
            scope.Start();
            try
            {
                var response = await _logAnalyticsRestClient.GetLogAnalyticsMetricsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, granularity, customDomains, protocols, groupBy, continents, countryOrRegions, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get log report for AFD profile
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getLogAnalyticsMetrics
        /// Operation Id: LogAnalytics_GetLogAnalyticsMetrics
        /// </summary>
        /// <param name="metrics"> The ArrayOfLogMetric to use. </param>
        /// <param name="dateTimeBegin"> The DateTime to use. </param>
        /// <param name="dateTimeEnd"> The DateTime to use. </param>
        /// <param name="granularity"> The LogMetricsGranularity to use. </param>
        /// <param name="customDomains"> The ArrayOfGet11ItemsItem to use. </param>
        /// <param name="protocols"> The ArrayOfGet12ItemsItem to use. </param>
        /// <param name="groupBy"> The ArrayOfLogMetricsGroupBy to use. </param>
        /// <param name="continents"> The ArrayOfGet9ItemsItem to use. </param>
        /// <param name="countryOrRegions"> The ArrayOfGet10ItemsItem to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metrics"/>, <paramref name="customDomains"/> or <paramref name="protocols"/> is null. </exception>
        public virtual Response<MetricsResponse> GetLogAnalyticsMetrics(IEnumerable<LogMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, LogMetricsGranularity granularity, IEnumerable<string> customDomains, IEnumerable<string> protocols, IEnumerable<LogMetricsGroupBy> groupBy = null, IEnumerable<string> continents = null, IEnumerable<string> countryOrRegions = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(metrics, nameof(metrics));
            Argument.AssertNotNull(customDomains, nameof(customDomains));
            Argument.AssertNotNull(protocols, nameof(protocols));

            using var scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetLogAnalyticsMetrics");
            scope.Start();
            try
            {
                var response = _logAnalyticsRestClient.GetLogAnalyticsMetrics(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, granularity, customDomains, protocols, groupBy, continents, countryOrRegions, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get log analytics ranking report for AFD profile
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getLogAnalyticsRankings
        /// Operation Id: LogAnalytics_GetLogAnalyticsRankings
        /// </summary>
        /// <param name="rankings"> The ArrayOfLogRanking to use. </param>
        /// <param name="metrics"> The ArrayOfLogRankingMetric to use. </param>
        /// <param name="maxRanking"> The Integer to use. </param>
        /// <param name="dateTimeBegin"> The DateTime to use. </param>
        /// <param name="dateTimeEnd"> The DateTime to use. </param>
        /// <param name="customDomains"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="rankings"/> or <paramref name="metrics"/> is null. </exception>
        public virtual async Task<Response<RankingsResponse>> GetLogAnalyticsRankingsAsync(IEnumerable<LogRanking> rankings, IEnumerable<LogRankingMetric> metrics, int maxRanking, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, IEnumerable<string> customDomains = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(rankings, nameof(rankings));
            Argument.AssertNotNull(metrics, nameof(metrics));

            using var scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetLogAnalyticsRankings");
            scope.Start();
            try
            {
                var response = await _logAnalyticsRestClient.GetLogAnalyticsRankingsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd, customDomains, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get log analytics ranking report for AFD profile
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getLogAnalyticsRankings
        /// Operation Id: LogAnalytics_GetLogAnalyticsRankings
        /// </summary>
        /// <param name="rankings"> The ArrayOfLogRanking to use. </param>
        /// <param name="metrics"> The ArrayOfLogRankingMetric to use. </param>
        /// <param name="maxRanking"> The Integer to use. </param>
        /// <param name="dateTimeBegin"> The DateTime to use. </param>
        /// <param name="dateTimeEnd"> The DateTime to use. </param>
        /// <param name="customDomains"> The ArrayOfString to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="rankings"/> or <paramref name="metrics"/> is null. </exception>
        public virtual Response<RankingsResponse> GetLogAnalyticsRankings(IEnumerable<LogRanking> rankings, IEnumerable<LogRankingMetric> metrics, int maxRanking, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, IEnumerable<string> customDomains = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(rankings, nameof(rankings));
            Argument.AssertNotNull(metrics, nameof(metrics));

            using var scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetLogAnalyticsRankings");
            scope.Start();
            try
            {
                var response = _logAnalyticsRestClient.GetLogAnalyticsRankings(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd, customDomains, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get Waf related log analytics report for AFD profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getWafLogAnalyticsMetrics
        /// Operation Id: LogAnalytics_GetWafLogAnalyticsMetrics
        /// </summary>
        /// <param name="metrics"> The ArrayOfWafMetric to use. </param>
        /// <param name="dateTimeBegin"> The DateTime to use. </param>
        /// <param name="dateTimeEnd"> The DateTime to use. </param>
        /// <param name="granularity"> The WafGranularity to use. </param>
        /// <param name="actions"> The ArrayOfWafAction to use. </param>
        /// <param name="groupBy"> The ArrayOfWafRankingGroupBy to use. </param>
        /// <param name="ruleTypes"> The ArrayOfWafRuleType to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metrics"/> is null. </exception>
        public virtual async Task<Response<WafMetricsResponse>> GetWafLogAnalyticsMetricsAsync(IEnumerable<WafMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, WafGranularity granularity, IEnumerable<WafAction> actions = null, IEnumerable<WafRankingGroupBy> groupBy = null, IEnumerable<WafRuleType> ruleTypes = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(metrics, nameof(metrics));

            using var scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetWafLogAnalyticsMetrics");
            scope.Start();
            try
            {
                var response = await _logAnalyticsRestClient.GetWafLogAnalyticsMetricsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, granularity, actions, groupBy, ruleTypes, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get Waf related log analytics report for AFD profile.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getWafLogAnalyticsMetrics
        /// Operation Id: LogAnalytics_GetWafLogAnalyticsMetrics
        /// </summary>
        /// <param name="metrics"> The ArrayOfWafMetric to use. </param>
        /// <param name="dateTimeBegin"> The DateTime to use. </param>
        /// <param name="dateTimeEnd"> The DateTime to use. </param>
        /// <param name="granularity"> The WafGranularity to use. </param>
        /// <param name="actions"> The ArrayOfWafAction to use. </param>
        /// <param name="groupBy"> The ArrayOfWafRankingGroupBy to use. </param>
        /// <param name="ruleTypes"> The ArrayOfWafRuleType to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metrics"/> is null. </exception>
        public virtual Response<WafMetricsResponse> GetWafLogAnalyticsMetrics(IEnumerable<WafMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, WafGranularity granularity, IEnumerable<WafAction> actions = null, IEnumerable<WafRankingGroupBy> groupBy = null, IEnumerable<WafRuleType> ruleTypes = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(metrics, nameof(metrics));

            using var scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetWafLogAnalyticsMetrics");
            scope.Start();
            try
            {
                var response = _logAnalyticsRestClient.GetWafLogAnalyticsMetrics(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, granularity, actions, groupBy, ruleTypes, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get WAF log analytics charts for AFD profile
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getWafLogAnalyticsRankings
        /// Operation Id: LogAnalytics_GetWafLogAnalyticsRankings
        /// </summary>
        /// <param name="metrics"> The ArrayOfWafMetric to use. </param>
        /// <param name="dateTimeBegin"> The DateTime to use. </param>
        /// <param name="dateTimeEnd"> The DateTime to use. </param>
        /// <param name="maxRanking"> The Integer to use. </param>
        /// <param name="rankings"> The ArrayOfWafRankingType to use. </param>
        /// <param name="actions"> The ArrayOfWafAction to use. </param>
        /// <param name="ruleTypes"> The ArrayOfWafRuleType to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metrics"/> or <paramref name="rankings"/> is null. </exception>
        public virtual async Task<Response<WafRankingsResponse>> GetWafLogAnalyticsRankingsAsync(IEnumerable<WafMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, int maxRanking, IEnumerable<WafRankingType> rankings, IEnumerable<WafAction> actions = null, IEnumerable<WafRuleType> ruleTypes = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(metrics, nameof(metrics));
            Argument.AssertNotNull(rankings, nameof(rankings));

            using var scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetWafLogAnalyticsRankings");
            scope.Start();
            try
            {
                var response = await _logAnalyticsRestClient.GetWafLogAnalyticsRankingsAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings, actions, ruleTypes, cancellationToken).ConfigureAwait(false);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get WAF log analytics charts for AFD profile
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getWafLogAnalyticsRankings
        /// Operation Id: LogAnalytics_GetWafLogAnalyticsRankings
        /// </summary>
        /// <param name="metrics"> The ArrayOfWafMetric to use. </param>
        /// <param name="dateTimeBegin"> The DateTime to use. </param>
        /// <param name="dateTimeEnd"> The DateTime to use. </param>
        /// <param name="maxRanking"> The Integer to use. </param>
        /// <param name="rankings"> The ArrayOfWafRankingType to use. </param>
        /// <param name="actions"> The ArrayOfWafAction to use. </param>
        /// <param name="ruleTypes"> The ArrayOfWafRuleType to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metrics"/> or <paramref name="rankings"/> is null. </exception>
        public virtual Response<WafRankingsResponse> GetWafLogAnalyticsRankings(IEnumerable<WafMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, int maxRanking, IEnumerable<WafRankingType> rankings, IEnumerable<WafAction> actions = null, IEnumerable<WafRuleType> ruleTypes = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(metrics, nameof(metrics));
            Argument.AssertNotNull(rankings, nameof(rankings));

            using var scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetWafLogAnalyticsRankings");
            scope.Start();
            try
            {
                var response = _logAnalyticsRestClient.GetWafLogAnalyticsRankings(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings, actions, ruleTypes, cancellationToken);
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
