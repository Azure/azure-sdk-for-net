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
            var input = new ProfileResourceGetLogAnalyticsMetricsOptions(metrics, dateTimeBegin, dateTimeEnd, granularity, customDomains, protocols);
            foreach (var item in groupBy)
            {
                input.GroupBy.Add(item);
            }
            foreach (var item in continents)
            {
                input.Continents.Add(item);
            }
            foreach (var item in countryOrRegions)
            {
                input.CountryOrRegions.Add(item);
            }
            return await GetLogAnalyticsMetricsAsync(input, cancellationToken).ConfigureAwait(false);
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
            var input = new ProfileResourceGetLogAnalyticsMetricsOptions(metrics, dateTimeBegin, dateTimeEnd, granularity, customDomains, protocols);
            foreach (var item in groupBy)
            {
                input.GroupBy.Add(item);
            }
            foreach (var item in continents)
            {
                input.Continents.Add(item);
            }
            foreach (var item in countryOrRegions)
            {
                input.CountryOrRegions.Add(item);
            }
            return GetLogAnalyticsMetrics(input, cancellationToken);
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
            var input = new ProfileResourceGetLogAnalyticsRankingsOptions(rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd);
            foreach (var item in customDomains)
            {
                input.CustomDomains.Add(item);
            }
            return await GetLogAnalyticsRankingsAsync(input, cancellationToken).ConfigureAwait(false);
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
            var input = new ProfileResourceGetLogAnalyticsRankingsOptions(rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd);
            foreach (var item in customDomains)
            {
                input.CustomDomains.Add(item);
            }
            return GetLogAnalyticsRankings(input, cancellationToken);
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
            var input = new ProfileResourceGetWafLogAnalyticsMetricsOptions(metrics, dateTimeBegin, dateTimeEnd, granularity);
            foreach (var item in actions)
            {
                input.Actions.Add(item);
            }
            foreach (var item in groupBy)
            {
                input.GroupBy.Add(item);
            }
            foreach (var item in ruleTypes)
            {
                input.RuleTypes.Add(item);
            }
            return await GetWafLogAnalyticsMetricsAsync(input, cancellationToken).ConfigureAwait(false);
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
            var input = new ProfileResourceGetWafLogAnalyticsMetricsOptions(metrics, dateTimeBegin, dateTimeEnd, granularity);
            foreach (var item in actions)
            {
                input.Actions.Add(item);
            }
            foreach (var item in groupBy)
            {
                input.GroupBy.Add(item);
            }
            foreach (var item in ruleTypes)
            {
                input.RuleTypes.Add(item);
            }
            return GetWafLogAnalyticsMetrics(input, cancellationToken);
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
            var input = new ProfileResourceGetWafLogAnalyticsRankingsOptions(metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings);
            foreach (var item in actions)
            {
                input.Actions.Add(item);
            }
            foreach (var item in ruleTypes)
            {
                input.RuleTypes.Add(item);
            }
            return await GetWafLogAnalyticsRankingsAsync(input, cancellationToken).ConfigureAwait(false);
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
            var input = new ProfileResourceGetWafLogAnalyticsRankingsOptions(metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings);
            foreach (var item in actions)
            {
                input.Actions.Add(item);
            }
            foreach (var item in ruleTypes)
            {
                input.RuleTypes.Add(item);
            }
            return GetWafLogAnalyticsRankings(input, cancellationToken);
        }
    }
}
