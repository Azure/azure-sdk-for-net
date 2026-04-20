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
    /// <summary> The ProfileResourceGetLogAnalyticsRankingsOptions. </summary>
    public partial class ProfileResourceGetLogAnalyticsRankingsOptions : IJsonModel<ProfileResourceGetLogAnalyticsRankingsOptions>, IPersistableModel<ProfileResourceGetLogAnalyticsRankingsOptions>
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

            Rankings = new List<LogRanking>(rankings);
            Metrics = new List<LogRankingMetric>(metrics);
            MaxRanking = maxRanking;
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            CustomDomains = new List<string>();
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

        /// <summary> Writes the model to the provided <see cref="Utf8JsonWriter"/>. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Reads and creates a <see cref="ProfileResourceGetLogAnalyticsRankingsOptions"/> from the provided <see cref="Utf8JsonReader"/>. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ProfileResourceGetLogAnalyticsRankingsOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Writes the model into a <see cref="BinaryData"/>. </summary>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Reads and creates a <see cref="ProfileResourceGetLogAnalyticsRankingsOptions"/> from the provided <see cref="BinaryData"/>. </summary>
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ProfileResourceGetLogAnalyticsRankingsOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        ProfileResourceGetLogAnalyticsRankingsOptions IJsonModel<ProfileResourceGetLogAnalyticsRankingsOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => JsonModelCreateCore(ref reader, options);

        void IJsonModel<ProfileResourceGetLogAnalyticsRankingsOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        ProfileResourceGetLogAnalyticsRankingsOptions IPersistableModel<ProfileResourceGetLogAnalyticsRankingsOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
            => PersistableModelCreateCore(data, options);

        string IPersistableModel<ProfileResourceGetLogAnalyticsRankingsOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<ProfileResourceGetLogAnalyticsRankingsOptions>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);
    }
}
