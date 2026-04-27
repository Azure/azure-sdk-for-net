// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This class is entirely custom — the MPG generator does not generate resource-level methods
    // for the LogAnalytics_GetLogAnalyticsMetrics operation (a GET with complex array query parameters such as
    // metrics, customDomains, protocols, etc.). Only the low-level REST request builder
    // (LogAnalyticsRestOperations.CreateGetLogAnalyticsMetricsRequest) is generated.
    // The old SDK (AutoRest-generated) exposed this operation as a spread-parameter method on ProfileResource.
    // To maintain backward API compatibility, the custom ProfileResource.cs provides both the old spread-parameter
    // overload and a new Options-based overload. This class serves as the parameter container for the Options-based
    // overload, grouping the required and optional query parameters into a single object.

    /// <summary> The ProfileResourceGetLogAnalyticsMetricsOptions. </summary>
    public partial class ProfileResourceGetLogAnalyticsMetricsOptions
    {
        /// <summary> Initializes a new instance of <see cref="ProfileResourceGetLogAnalyticsMetricsOptions"/>. </summary>
        /// <param name="metrics"> The metrics to use. </param>
        /// <param name="dateTimeBegin"> The date time begin. </param>
        /// <param name="dateTimeEnd"> The date time end. </param>
        /// <param name="granularity"> The granularity. </param>
        /// <param name="customDomains"> The custom domains. </param>
        /// <param name="protocols"> The protocols. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="metrics"/>, <paramref name="customDomains"/> or <paramref name="protocols"/> is null. </exception>
        public ProfileResourceGetLogAnalyticsMetricsOptions(IEnumerable<LogMetric> metrics, DateTimeOffset dateTimeBegin, DateTimeOffset dateTimeEnd, LogMetricsGranularity granularity, IEnumerable<string> customDomains, IEnumerable<string> protocols)
        {
            Argument.AssertNotNull(metrics, nameof(metrics));
            Argument.AssertNotNull(customDomains, nameof(customDomains));
            Argument.AssertNotNull(protocols, nameof(protocols));

            Metrics = metrics.ToList();
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            Granularity = granularity;
            CustomDomains = customDomains.ToList();
            Protocols = protocols.ToList();
            GroupBy = new ChangeTrackingList<LogMetricsGroupBy>();
            Continents = new ChangeTrackingList<string>();
            CountryOrRegions = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="ProfileResourceGetLogAnalyticsMetricsOptions"/> for deserialization. </summary>
        internal ProfileResourceGetLogAnalyticsMetricsOptions()
        {
        }

        /// <summary> The metrics. </summary>
        [WirePath("metrics")]
        public IList<LogMetric> Metrics { get; }
        /// <summary> The date time begin. </summary>
        [WirePath("dateTimeBegin")]
        public DateTimeOffset DateTimeBegin { get; }
        /// <summary> The date time end. </summary>
        [WirePath("dateTimeEnd")]
        public DateTimeOffset DateTimeEnd { get; }
        /// <summary> The granularity. </summary>
        [WirePath("granularity")]
        public LogMetricsGranularity Granularity { get; }
        /// <summary> The custom domains. </summary>
        [WirePath("customDomains")]
        public IList<string> CustomDomains { get; }
        /// <summary> The protocols. </summary>
        [WirePath("protocols")]
        public IList<string> Protocols { get; }
        /// <summary> The group by. </summary>
        [WirePath("groupBy")]
        public IList<LogMetricsGroupBy> GroupBy { get; }
        /// <summary> The continents. </summary>
        [WirePath("continents")]
        public IList<string> Continents { get; }
        /// <summary> The country or regions. </summary>
        [WirePath("countryOrRegions")]
        public IList<string> CountryOrRegions { get; }
    }
}
