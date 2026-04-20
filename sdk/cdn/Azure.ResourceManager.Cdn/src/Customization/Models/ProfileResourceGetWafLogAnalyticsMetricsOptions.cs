// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.ResourceManager.Cdn.Models
{
    // Customization: This Options class was previously generated via @@override in client.tsp.
    // After removing the client.tsp overrides, it must be preserved as custom code
    // to maintain backward API compatibility with the old SDK's parameter-wrapping pattern.
    /// <summary> The ProfileResourceGetWafLogAnalyticsMetricsOptions. </summary>
    public partial class ProfileResourceGetWafLogAnalyticsMetricsOptions : IJsonModel<ProfileResourceGetWafLogAnalyticsMetricsOptions>, IPersistableModel<ProfileResourceGetWafLogAnalyticsMetricsOptions>
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

            Metrics = new List<WafMetric>(metrics);
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            Granularity = granularity;
            Actions = new List<WafAction>();
            GroupBy = new List<WafRankingGroupBy>();
            RuleTypes = new List<WafRuleType>();
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

        /// <inheritdoc />
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected virtual ProfileResourceGetWafLogAnalyticsMetricsOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        protected virtual ProfileResourceGetWafLogAnalyticsMetricsOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        ProfileResourceGetWafLogAnalyticsMetricsOptions IJsonModel<ProfileResourceGetWafLogAnalyticsMetricsOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => JsonModelCreateCore(ref reader, options);

        void IJsonModel<ProfileResourceGetWafLogAnalyticsMetricsOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        ProfileResourceGetWafLogAnalyticsMetricsOptions IPersistableModel<ProfileResourceGetWafLogAnalyticsMetricsOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
            => PersistableModelCreateCore(data, options);

        string IPersistableModel<ProfileResourceGetWafLogAnalyticsMetricsOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<ProfileResourceGetWafLogAnalyticsMetricsOptions>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);
    }
}
