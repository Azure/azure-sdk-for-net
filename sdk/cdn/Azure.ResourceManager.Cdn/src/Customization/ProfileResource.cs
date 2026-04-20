// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Cdn.Models;

namespace Azure.ResourceManager.Cdn
{
    // Customization: This file customizes the ProfileResource log analytics methods to maintain backward API compatibility with the previous SDK.
    // Reason: The TypeSpec generator wraps the parameters of GetLogAnalyticsMetrics, GetLogAnalyticsRankings,
    // GetWafLogAnalyticsMetrics, and GetWafLogAnalyticsRankings into Options objects (parameter wrapping pattern),
    // but the old SDK uses individual spread parameters. To maintain backward compatibility, these methods are
    // re-implemented here to accept spread parameters and internally call the REST client directly, bypassing the generated Options wrappers.
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
            return await GetLogAnalyticsMetricsDirectAsync(metrics, dateTimeBegin, dateTimeEnd, granularity, customDomains, protocols, groupBy, continents, countryOrRegions, cancellationToken).ConfigureAwait(false);
        }

        private async Task<Response<MetricsResponse>> GetLogAnalyticsMetricsDirectAsync(IEnumerable<LogMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, LogMetricsGranularity granularity, IEnumerable<string> customDomains, IEnumerable<string> protocols, IEnumerable<LogMetricsGroupBy> groupBy, IEnumerable<string> continents, IEnumerable<string> countryOrRegions, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetLogAnalyticsMetrics");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _logAnalyticsRestClient.CreateGetLogAnalyticsMetricsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, granularity.ToString(), customDomains, protocols, groupBy, continents, countryOrRegions, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MetricsResponse> response = Response.FromValue(MetricsResponse.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
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
            return GetLogAnalyticsMetricsDirect(metrics, dateTimeBegin, dateTimeEnd, granularity, customDomains, protocols, groupBy, continents, countryOrRegions, cancellationToken);
        }

        private Response<MetricsResponse> GetLogAnalyticsMetricsDirect(IEnumerable<LogMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, LogMetricsGranularity granularity, IEnumerable<string> customDomains, IEnumerable<string> protocols, IEnumerable<LogMetricsGroupBy> groupBy, IEnumerable<string> continents, IEnumerable<string> countryOrRegions, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetLogAnalyticsMetrics");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _logAnalyticsRestClient.CreateGetLogAnalyticsMetricsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, granularity.ToString(), customDomains, protocols, groupBy, continents, countryOrRegions, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MetricsResponse> response = Response.FromValue(MetricsResponse.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
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
            return await GetLogAnalyticsRankingsDirectAsync(rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd, customDomains, cancellationToken).ConfigureAwait(false);
        }

        private async Task<Response<RankingsResponse>> GetLogAnalyticsRankingsDirectAsync(IEnumerable<LogRanking> rankings, IEnumerable<LogRankingMetric> metrics, int maxRanking, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, IEnumerable<string> customDomains, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetLogAnalyticsRankings");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _logAnalyticsRestClient.CreateGetLogAnalyticsRankingsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd, customDomains, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<RankingsResponse> response = Response.FromValue(RankingsResponse.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
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
            return GetLogAnalyticsRankingsDirect(rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd, customDomains, cancellationToken);
        }

        private Response<RankingsResponse> GetLogAnalyticsRankingsDirect(IEnumerable<LogRanking> rankings, IEnumerable<LogRankingMetric> metrics, int maxRanking, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, IEnumerable<string> customDomains, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetLogAnalyticsRankings");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _logAnalyticsRestClient.CreateGetLogAnalyticsRankingsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, rankings, metrics, maxRanking, dateTimeBegin, dateTimeEnd, customDomains, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<RankingsResponse> response = Response.FromValue(RankingsResponse.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
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
            return await GetWafLogAnalyticsMetricsDirectAsync(metrics, dateTimeBegin, dateTimeEnd, granularity, actions, groupBy, ruleTypes, cancellationToken).ConfigureAwait(false);
        }

        private async Task<Response<WafMetricsResponse>> GetWafLogAnalyticsMetricsDirectAsync(IEnumerable<WafMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, WafGranularity granularity, IEnumerable<WafAction> actions, IEnumerable<WafRankingGroupBy> groupBy, IEnumerable<WafRuleType> ruleTypes, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetWafLogAnalyticsMetrics");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _logAnalyticsRestClient.CreateGetWafLogAnalyticsMetricsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, granularity.ToString(), actions, groupBy, ruleTypes, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<WafMetricsResponse> response = Response.FromValue(WafMetricsResponse.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
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
            return GetWafLogAnalyticsMetricsDirect(metrics, dateTimeBegin, dateTimeEnd, granularity, actions, groupBy, ruleTypes, cancellationToken);
        }

        private Response<WafMetricsResponse> GetWafLogAnalyticsMetricsDirect(IEnumerable<WafMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, WafGranularity granularity, IEnumerable<WafAction> actions, IEnumerable<WafRankingGroupBy> groupBy, IEnumerable<WafRuleType> ruleTypes, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetWafLogAnalyticsMetrics");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _logAnalyticsRestClient.CreateGetWafLogAnalyticsMetricsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, granularity.ToString(), actions, groupBy, ruleTypes, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<WafMetricsResponse> response = Response.FromValue(WafMetricsResponse.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
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
            return await GetWafLogAnalyticsRankingsDirectAsync(metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings, actions, ruleTypes, cancellationToken).ConfigureAwait(false);
        }

        private async Task<Response<WafRankingsResponse>> GetWafLogAnalyticsRankingsDirectAsync(IEnumerable<WafMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, int maxRanking, IEnumerable<WafRankingType> rankings, IEnumerable<WafAction> actions, IEnumerable<WafRuleType> ruleTypes, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetWafLogAnalyticsRankings");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _logAnalyticsRestClient.CreateGetWafLogAnalyticsRankingsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings, actions, ruleTypes, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<WafRankingsResponse> response = Response.FromValue(WafRankingsResponse.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
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
            return GetWafLogAnalyticsRankingsDirect(metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings, actions, ruleTypes, cancellationToken);
        }

        private Response<WafRankingsResponse> GetWafLogAnalyticsRankingsDirect(IEnumerable<WafMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, int maxRanking, IEnumerable<WafRankingType> rankings, IEnumerable<WafAction> actions, IEnumerable<WafRuleType> ruleTypes, CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _logAnalyticsClientDiagnostics.CreateScope("ProfileResource.GetWafLogAnalyticsRankings");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _logAnalyticsRestClient.CreateGetWafLogAnalyticsRankingsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, metrics, dateTimeBegin, dateTimeEnd, maxRanking, rankings, actions, ruleTypes, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<WafRankingsResponse> response = Response.FromValue(WafRankingsResponse.FromResponse(result), result);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
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
        /// </summary>
        /// <param name="options"> The options parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<MetricsResponse>> GetLogAnalyticsMetricsAsync(ProfileResourceGetLogAnalyticsMetricsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return await GetLogAnalyticsMetricsDirectAsync(options.Metrics, options.DateTimeBegin, options.DateTimeEnd, options.Granularity, options.CustomDomains, options.Protocols, options.GroupBy, options.Continents, options.CountryOrRegions, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get log report for AFD profile
        /// </summary>
        /// <param name="options"> The options parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<MetricsResponse> GetLogAnalyticsMetrics(ProfileResourceGetLogAnalyticsMetricsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return GetLogAnalyticsMetricsDirect(options.Metrics, options.DateTimeBegin, options.DateTimeEnd, options.Granularity, options.CustomDomains, options.Protocols, options.GroupBy, options.Continents, options.CountryOrRegions, cancellationToken);
        }

        /// <summary>
        /// Get log analytics ranking report for AFD profile
        /// </summary>
        /// <param name="options"> The options parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<RankingsResponse>> GetLogAnalyticsRankingsAsync(ProfileResourceGetLogAnalyticsRankingsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return await GetLogAnalyticsRankingsDirectAsync(options.Rankings, options.Metrics, options.MaxRanking, options.DateTimeBegin, options.DateTimeEnd, options.CustomDomains, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get log analytics ranking report for AFD profile
        /// </summary>
        /// <param name="options"> The options parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<RankingsResponse> GetLogAnalyticsRankings(ProfileResourceGetLogAnalyticsRankingsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return GetLogAnalyticsRankingsDirect(options.Rankings, options.Metrics, options.MaxRanking, options.DateTimeBegin, options.DateTimeEnd, options.CustomDomains, cancellationToken);
        }

        /// <summary>
        /// Get Waf related log analytics report for AFD profile.
        /// </summary>
        /// <param name="options"> The options parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<WafMetricsResponse>> GetWafLogAnalyticsMetricsAsync(ProfileResourceGetWafLogAnalyticsMetricsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return await GetWafLogAnalyticsMetricsDirectAsync(options.Metrics, options.DateTimeBegin, options.DateTimeEnd, options.Granularity, options.Actions, options.GroupBy, options.RuleTypes, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get Waf related log analytics report for AFD profile.
        /// </summary>
        /// <param name="options"> The options parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<WafMetricsResponse> GetWafLogAnalyticsMetrics(ProfileResourceGetWafLogAnalyticsMetricsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return GetWafLogAnalyticsMetricsDirect(options.Metrics, options.DateTimeBegin, options.DateTimeEnd, options.Granularity, options.Actions, options.GroupBy, options.RuleTypes, cancellationToken);
        }

        /// <summary>
        /// Get WAF log analytics charts for AFD profile
        /// </summary>
        /// <param name="options"> The options parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual async Task<Response<WafRankingsResponse>> GetWafLogAnalyticsRankingsAsync(ProfileResourceGetWafLogAnalyticsRankingsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return await GetWafLogAnalyticsRankingsDirectAsync(options.Metrics, options.DateTimeBegin, options.DateTimeEnd, options.MaxRanking, options.Rankings, options.Actions, options.RuleTypes, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get WAF log analytics charts for AFD profile
        /// </summary>
        /// <param name="options"> The options parameters. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="options"/> is null. </exception>
        public virtual Response<WafRankingsResponse> GetWafLogAnalyticsRankings(ProfileResourceGetWafLogAnalyticsRankingsOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(options, nameof(options));
            return GetWafLogAnalyticsRankingsDirect(options.Metrics, options.DateTimeBegin, options.DateTimeEnd, options.MaxRanking, options.Rankings, options.Actions, options.RuleTypes, cancellationToken);
        }
    }
}
