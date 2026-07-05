// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This class is entirely custom — the MPG generator does not generate resource-level methods
    // for the LogAnalytics_GetLogAnalyticsRankings operation (a GET with complex array query parameters such as
    // rankings, metrics, customDomains, etc.). Only the low-level REST request builder
    // (LogAnalyticsRestOperations.CreateGetLogAnalyticsRankingsRequest) is generated.
    // The old SDK (AutoRest-generated) exposed this operation as a spread-parameter method on ProfileResource.
    // To maintain backward API compatibility, the custom ProfileResource.cs provides both the old spread-parameter
    // overload and a new Options-based overload. This class serves as the parameter container for the Options-based
    // overload, grouping the required and optional query parameters into a single object.

    /// <summary> The ProfileResourceGetLogAnalyticsRankingsOptions. </summary>
    public partial class ProfileResourceGetLogAnalyticsRankingsOptions
    {
        /// <summary> Initializes a new instance of <see cref="ProfileResourceGetLogAnalyticsRankingsOptions"/>. </summary>
        /// <param name="rankings"> The rankings. </param>
        /// <param name="metrics"> The metrics. </param>
        /// <param name="maxRanking"> The max ranking. </param>
        /// <param name="dateTimeBegin"> The date time begin. </param>
        /// <param name="dateTimeEnd"> The date time end. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="rankings"/> or <paramref name="metrics"/> is null. </exception>
        public ProfileResourceGetLogAnalyticsRankingsOptions(IEnumerable<LogRanking> rankings, IEnumerable<LogRankingMetric> metrics, int maxRanking, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd)
        {
            Argument.AssertNotNull(rankings, nameof(rankings));
            Argument.AssertNotNull(metrics, nameof(metrics));

            Rankings = rankings.ToList();
            Metrics = metrics.ToList();
            MaxRanking = maxRanking;
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            CustomDomains = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="ProfileResourceGetLogAnalyticsRankingsOptions"/> for deserialization. </summary>
        internal ProfileResourceGetLogAnalyticsRankingsOptions()
        {
        }

        /// <summary> The rankings. </summary>
        [WirePath("rankings")]
        public IList<LogRanking> Rankings { get; }
        /// <summary> The metrics. </summary>
        [WirePath("metrics")]
        public IList<LogRankingMetric> Metrics { get; }
        /// <summary> The max ranking. </summary>
        [WirePath("maxRanking")]
        public int MaxRanking { get; }
        /// <summary> The date time begin. </summary>
        [WirePath("dateTimeBegin")]
        public DateTimeOffset DateTimeBegin { get; }
        /// <summary> The date time end. </summary>
        [WirePath("dateTimeEnd")]
        public DateTimeOffset DateTimeEnd { get; }
        /// <summary> The custom domains. </summary>
        [WirePath("customDomains")]
        public IList<string> CustomDomains { get; }
    }
}
