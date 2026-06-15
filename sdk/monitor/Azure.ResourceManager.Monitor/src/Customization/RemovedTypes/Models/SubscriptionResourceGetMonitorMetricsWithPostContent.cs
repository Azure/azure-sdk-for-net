// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy POST content for getting monitor metrics for a subscription. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class SubscriptionResourceGetMonitorMetricsWithPostContent : IJsonModel<SubscriptionResourceGetMonitorMetricsWithPostContent>, IPersistableModel<SubscriptionResourceGetMonitorMetricsWithPostContent>
    {
        /// <summary> Initializes a new instance of <see cref="SubscriptionResourceGetMonitorMetricsWithPostContent"/>. </summary>
        public SubscriptionResourceGetMonitorMetricsWithPostContent()
        {
        }

        /// <summary> The timespan of the query. </summary>
        public TimeSpan? Timespan { get; set; }

        /// <summary> The interval of the query. </summary>
        public TimeSpan? Interval { get; set; }

        /// <summary> The metric names. </summary>
        public string MetricNames { get; set; }

        /// <summary> The aggregation to use. </summary>
        public string Aggregation { get; set; }

        /// <summary> The filter to apply. </summary>
        public string Filter { get; set; }

        /// <summary> The maximum number of records. </summary>
        public int? Top { get; set; }

        /// <summary> The order by expression. </summary>
        public string OrderBy { get; set; }

        /// <summary> Dimension names to roll up by. </summary>
        public string RollUpBy { get; set; }

        /// <summary> The result type. </summary>
        public MonitorMetricResultType? ResultType { get; set; }

        /// <summary> The metric namespace. </summary>
        public string MetricNamespace { get; set; }

        /// <summary> Whether to auto-adjust the time grain. </summary>
        public bool? AutoAdjustTimegrain { get; set; }

        /// <summary> Whether to validate dimensions. </summary>
        public bool? ValidateDimensions { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        SubscriptionResourceGetMonitorMetricsWithPostContent IJsonModel<SubscriptionResourceGetMonitorMetricsWithPostContent>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<SubscriptionResourceGetMonitorMetricsWithPostContent>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        SubscriptionResourceGetMonitorMetricsWithPostContent IPersistableModel<SubscriptionResourceGetMonitorMetricsWithPostContent>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<SubscriptionResourceGetMonitorMetricsWithPostContent>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<SubscriptionResourceGetMonitorMetricsWithPostContent>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}
