// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This class is entirely custom — the MPG generator does not generate resource-level methods
    // for the LogAnalytics_GetWafLogAnalyticsMetrics operation (a GET with complex array query parameters such as
    // metrics, actions, groupBy, ruleTypes, etc.). Only the low-level REST request builder
    // (LogAnalyticsRestOperations.CreateGetWafLogAnalyticsMetricsRequest) is generated.
    // The old SDK (AutoRest-generated) exposed this operation as a spread-parameter method on ProfileResource.
    // To maintain backward API compatibility, the custom ProfileResource.cs provides both the old spread-parameter
    // overload and a new Options-based overload. This class serves as the parameter container for the Options-based
    // overload, grouping the required and optional query parameters into a single object.

    /// <summary> The ProfileResourceGetWafLogAnalyticsMetricsOptions. </summary>
    public partial class ProfileResourceGetWafLogAnalyticsMetricsOptions
    {
        /// <summary> Initializes a new instance of <see cref="ProfileResourceGetWafLogAnalyticsMetricsOptions"/>. </summary>
        /// <param name="metrics"> The metrics. </param>
        /// <param name="dateTimeBegin"> The date time begin. </param>
        /// <param name="dateTimeEnd"> The date time end. </param>
        /// <param name="granularity"> The granularity. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metrics"/> is null. </exception>
        public ProfileResourceGetWafLogAnalyticsMetricsOptions(IEnumerable<WafMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, WafGranularity granularity)
        {
            Argument.AssertNotNull(metrics, nameof(metrics));

            Metrics = metrics.ToList();
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            Granularity = granularity;
            Actions = new ChangeTrackingList<WafAction>();
            GroupBy = new ChangeTrackingList<WafRankingGroupBy>();
            RuleTypes = new ChangeTrackingList<WafRuleType>();
        }

        /// <summary> Initializes a new instance of <see cref="ProfileResourceGetWafLogAnalyticsMetricsOptions"/> for deserialization. </summary>
        internal ProfileResourceGetWafLogAnalyticsMetricsOptions()
        {
        }

        /// <summary> The metrics. </summary>
        [WirePath("metrics")]
        public IList<WafMetric> Metrics { get; }
        /// <summary> The date time begin. </summary>
        [WirePath("dateTimeBegin")]
        public DateTimeOffset DateTimeBegin { get; }
        /// <summary> The date time end. </summary>
        [WirePath("dateTimeEnd")]
        public DateTimeOffset DateTimeEnd { get; }
        /// <summary> The granularity. </summary>
        [WirePath("granularity")]
        public WafGranularity Granularity { get; }
        /// <summary> The actions. </summary>
        [WirePath("actions")]
        public IList<WafAction> Actions { get; }
        /// <summary> The group by. </summary>
        [WirePath("groupBy")]
        public IList<WafRankingGroupBy> GroupBy { get; }
        /// <summary> The rule types. </summary>
        [WirePath("ruleTypes")]
        public IList<WafRuleType> RuleTypes { get; }
    }
}
