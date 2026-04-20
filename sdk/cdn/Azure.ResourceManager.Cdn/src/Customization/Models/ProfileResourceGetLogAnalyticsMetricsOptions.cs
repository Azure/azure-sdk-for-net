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
    /// <summary> The ProfileResourceGetLogAnalyticsMetricsOptions. </summary>
    public partial class ProfileResourceGetLogAnalyticsMetricsOptions : IJsonModel<ProfileResourceGetLogAnalyticsMetricsOptions>, IPersistableModel<ProfileResourceGetLogAnalyticsMetricsOptions>
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

            Metrics = new List<LogMetric>(metrics);
            DateTimeBegin = dateTimeBegin;
            DateTimeEnd = dateTimeEnd;
            Granularity = granularity;
            CustomDomains = new List<string>(customDomains);
            Protocols = new List<string>(protocols);
            GroupBy = new List<LogMetricsGroupBy>();
            Continents = new List<string>();
            CountryOrRegions = new List<string>();
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

        /// <summary> Writes the model to the provided <see cref="Utf8JsonWriter"/>. </summary>
        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Reads and creates a <see cref="ProfileResourceGetLogAnalyticsMetricsOptions"/> from the provided <see cref="Utf8JsonReader"/>. </summary>
        /// <param name="reader"> The JSON reader. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ProfileResourceGetLogAnalyticsMetricsOptions JsonModelCreateCore(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Writes the model into a <see cref="BinaryData"/>. </summary>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual BinaryData PersistableModelWriteCore(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        /// <summary> Reads and creates a <see cref="ProfileResourceGetLogAnalyticsMetricsOptions"/> from the provided <see cref="BinaryData"/>. </summary>
        /// <param name="data"> The data to parse. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual ProfileResourceGetLogAnalyticsMetricsOptions PersistableModelCreateCore(BinaryData data, ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }

        ProfileResourceGetLogAnalyticsMetricsOptions IJsonModel<ProfileResourceGetLogAnalyticsMetricsOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => JsonModelCreateCore(ref reader, options);

        void IJsonModel<ProfileResourceGetLogAnalyticsMetricsOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => JsonModelWriteCore(writer, options);

        ProfileResourceGetLogAnalyticsMetricsOptions IPersistableModel<ProfileResourceGetLogAnalyticsMetricsOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
            => PersistableModelCreateCore(data, options);

        string IPersistableModel<ProfileResourceGetLogAnalyticsMetricsOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<ProfileResourceGetLogAnalyticsMetricsOptions>.Write(ModelReaderWriterOptions options)
            => PersistableModelWriteCore(options);
    }
}
