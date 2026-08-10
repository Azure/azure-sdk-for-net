// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This class is entirely custom — the MPG generator does not generate resource-level methods
    // for the LogAnalytics_GetWafLogAnalyticsRankings operation (a GET with complex array query parameters such as
    // metrics, rankings, actions, ruleTypes, etc.). Only the low-level REST request builder
    // (LogAnalyticsRestOperations.CreateGetWafLogAnalyticsRankingsRequest) is generated.
    // The old SDK (AutoRest-generated) exposed this operation as a spread-parameter method on ProfileResource.
    // To maintain backward API compatibility, the custom ProfileResource.cs provides both the old spread-parameter
    // overload and a new Options-based overload. This class serves as the parameter container for the Options-based
    // overload, grouping the required and optional query parameters into a single object.

    /// <summary> The ProfileResourceGetWafLogAnalyticsRankingsOptions. </summary>
    public partial class ProfileResourceGetWafLogAnalyticsRankingsOptions
    {
        /// <summary> Initializes a new instance of <see cref="ProfileResourceGetWafLogAnalyticsRankingsOptions"/>. </summary>
        /// <param name="metrics"> The metrics. </param>
        /// <param name="dateTimeBegin"> The date time begin. </param>
        /// <param name="dateTimeEnd"> The date time end. </param>
        /// <param name="maxRanking"> The max ranking. </param>
        /// <param name="rankings"> The rankings. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metrics"/> or <paramref name="rankings"/> is null. </exception>
        public ProfileResourceGetWafLogAnalyticsRankingsOptions(IEnumerable<WafMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, int maxRanking, IEnumerable<WafRankingType> rankings)
        {
            Argument.AssertNotNull(metrics, nameof(metrics));
            Argument.AssertNotNull(rankings, nameof(rankings));

            Metrics = metrics.ToList();
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            MaxRanking = maxRanking;
            Rankings = rankings.ToList();
            Actions = new ChangeTrackingList<WafAction>();
            RuleTypes = new ChangeTrackingList<WafRuleType>();
        }

        /// <summary> Initializes a new instance of <see cref="ProfileResourceGetWafLogAnalyticsRankingsOptions"/> for deserialization. </summary>
        internal ProfileResourceGetWafLogAnalyticsRankingsOptions()
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
        /// <summary> The max ranking. </summary>
        [WirePath("maxRanking")]
        public int MaxRanking { get; }
        /// <summary> The rankings. </summary>
        [WirePath("rankings")]
        public IList<WafRankingType> Rankings { get; }
        /// <summary> The actions. </summary>
        [WirePath("actions")]
        public IList<WafAction> Actions { get; }
        /// <summary> The rule types. </summary>
        [WirePath("ruleTypes")]
        public IList<WafRuleType> RuleTypes { get; }
    }
}
