// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.Cdn.Models;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;

namespace Azure.ResourceManager.Cdn
{
    public partial class ProfileResource
    {
        /// <summary>
        /// Get log report for AFD profile
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getLogAnalyticsMetrics</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_GetLogAnalyticsMetrics</description>
        /// </item>
        /// </list>
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

            ProfileResourceGetLogAnalyticsMetricsOptions options = new ProfileResourceGetLogAnalyticsMetricsOptions(metrics, dateTimeBegin, dateTimeEnd, granularity, customDomains, protocols);
            if (groupBy is not null)
            {
                foreach (var item in groupBy)
                {
                    options.GroupBy.Add(item);
                }
            }
            if (continents is not null)
            {
                foreach (var item in continents)
                {
                    options.Continents.Add(item);
                }
            }
            if (countryOrRegions is not null)
            {
                foreach (var item in countryOrRegions)
                {
                    options.CountryOrRegions.Add(item);
                }
            }
            return await GetLogAnalyticsMetricsAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get log report for AFD profile
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getLogAnalyticsMetrics</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_GetLogAnalyticsMetrics</description>
        /// </item>
        /// </list>
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

            ProfileResourceGetLogAnalyticsMetricsOptions options = new ProfileResourceGetLogAnalyticsMetricsOptions(metrics, dateTimeBegin, dateTimeEnd, granularity, customDomains, protocols);
            if (groupBy is not null)
            {
                foreach (var item in groupBy)
                {
                    options.GroupBy.Add(item);
                }
            }
            if (continents is not null)
            {
                foreach (var item in continents)
                {
                    options.Continents.Add(item);
                }
            }
            if (countryOrRegions is not null)
            {
                foreach (var item in countryOrRegions)
                {
                    options.CountryOrRegions.Add(item);
                }
            }
            return GetLogAnalyticsMetrics(options, cancellationToken);
        }

        /// <summary>
        /// Get log analytics ranking report for AFD profile
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getLogAnalyticsRankings</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_GetLogAnalyticsRankings</description>
        /// </item>
        /// </list>
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

            ProfileResourceGetLogAnalyticsRankingsOptions options = new ProfileResourceGetLogAnalyticsRankingsOptions(rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd);
            if (customDomains is not null)
            {
                foreach (var item in customDomains)
                {
                    options.CustomDomains.Add(item);
                }
            }
            return await GetLogAnalyticsRankingsAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get log analytics ranking report for AFD profile
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getLogAnalyticsRankings</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_GetLogAnalyticsRankings</description>
        /// </item>
        /// </list>
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

            ProfileResourceGetLogAnalyticsRankingsOptions options = new ProfileResourceGetLogAnalyticsRankingsOptions(rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd);
            if (customDomains is not null)
            {
                foreach (var item in customDomains)
                {
                    options.CustomDomains.Add(item);
                }
            }
            return GetLogAnalyticsRankings(options, cancellationToken);
        }

        /// <summary>
        /// Get Waf related log analytics report for AFD profile.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getWafLogAnalyticsMetrics</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_GetWafLogAnalyticsMetrics</description>
        /// </item>
        /// </list>
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

            ProfileResourceGetWafLogAnalyticsMetricsOptions options = new ProfileResourceGetWafLogAnalyticsMetricsOptions(metrics, dateTimeBegin, dateTimeEnd, granularity);
            if (actions is not null)
            {
                foreach (var item in actions)
                {
                    options.Actions.Add(item);
                }
            }
            if (groupBy is not null)
            {
                foreach (var item in groupBy)
                {
                    options.GroupBy.Add(item);
                }
            }
            if (ruleTypes is not null)
            {
                foreach (var item in ruleTypes)
                {
                    options.RuleTypes.Add(item);
                }
            }
            return await GetWafLogAnalyticsMetricsAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Waf related log analytics report for AFD profile.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getWafLogAnalyticsMetrics</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_GetWafLogAnalyticsMetrics</description>
        /// </item>
        /// </list>
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

            ProfileResourceGetWafLogAnalyticsMetricsOptions options = new ProfileResourceGetWafLogAnalyticsMetricsOptions(metrics, dateTimeBegin, dateTimeEnd, granularity);
            if (actions is not null)
            {
                foreach (var item in actions)
                {
                    options.Actions.Add(item);
                }
            }
            if (groupBy is not null)
            {
                foreach (var item in groupBy)
                {
                    options.GroupBy.Add(item);
                }
            }
            if (ruleTypes is not null)
            {
                foreach (var item in ruleTypes)
                {
                    options.RuleTypes.Add(item);
                }
            }
            return GetWafLogAnalyticsMetrics(options, cancellationToken);
        }

        /// <summary>
        /// Get WAF log analytics charts for AFD profile
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getWafLogAnalyticsRankings</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_GetWafLogAnalyticsRankings</description>
        /// </item>
        /// </list>
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

            ProfileResourceGetWafLogAnalyticsRankingsOptions options = new ProfileResourceGetWafLogAnalyticsRankingsOptions(metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings);
            if (actions is not null)
            {
                foreach (var item in actions)
                {
                    options.Actions.Add(item);
                }
            }
            if (ruleTypes is not null)
            {
                foreach (var item in ruleTypes)
                {
                    options.RuleTypes.Add(item);
                }
            }
            return await GetWafLogAnalyticsRankingsAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get WAF log analytics charts for AFD profile
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Cdn/profiles/{profileName}/getWafLogAnalyticsRankings</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>LogAnalytics_GetWafLogAnalyticsRankings</description>
        /// </item>
        /// </list>
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

            ProfileResourceGetWafLogAnalyticsRankingsOptions options = new ProfileResourceGetWafLogAnalyticsRankingsOptions(metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings);
            if (actions is not null)
            {
                foreach (var item in actions)
                {
                    options.Actions.Add(item);
                }
            }
            if (ruleTypes is not null)
            {
                foreach (var item in ruleTypes)
                {
                    options.RuleTypes.Add(item);
                }
            }
            return GetWafLogAnalyticsRankings(options, cancellationToken);
        }
    }
}
