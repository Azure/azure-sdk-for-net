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
    /// <summary> The ProfileResourceGetWafLogAnalyticsRankingsOptions. </summary>
    public partial class ProfileResourceGetWafLogAnalyticsRankingsOptions : IJsonModel<ProfileResourceGetWafLogAnalyticsRankingsOptions>, IPersistableModel<ProfileResourceGetWafLogAnalyticsRankingsOptions>
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

            Metrics = new List<WafMetric>(metrics);
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            MaxRanking = maxRanking;
            Rankings = new List<WafRankingType>(rankings);
            Actions = new List<WafAction>();
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

        /// <summary> Writes the model to the provided <see cref="Utf8JsonWriter"/>. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Reads and creates a <see cref="ProfileResourceGetWafLogAnalyticsRankingsOptions"/> from the provided <see cref="Utf8JsonReader"/>. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ProfileResourceGetWafLogAnalyticsRankingsOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Writes the model into a <see cref="BinaryData"/>. </summary>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Reads and creates a <see cref="ProfileResourceGetWafLogAnalyticsRankingsOptions"/> from the provided <see cref="BinaryData"/>. </summary>
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ProfileResourceGetWafLogAnalyticsRankingsOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        ProfileResourceGetWafLogAnalyticsRankingsOptions IJsonModel<ProfileResourceGetWafLogAnalyticsRankingsOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => JsonModelCreateCore(ref reader, options);

        void IJsonModel<ProfileResourceGetWafLogAnalyticsRankingsOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        ProfileResourceGetWafLogAnalyticsRankingsOptions IPersistableModel<ProfileResourceGetWafLogAnalyticsRankingsOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
            => PersistableModelCreateCore(data, options);

        string IPersistableModel<ProfileResourceGetWafLogAnalyticsRankingsOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<ProfileResourceGetWafLogAnalyticsRankingsOptions>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);
    }
}
