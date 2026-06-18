// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Monitor.Models
{
    /// <summary> Legacy subscription monitor metric. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class SubscriptionMonitorMetric : IJsonModel<SubscriptionMonitorMetric>, IPersistableModel<SubscriptionMonitorMetric>
    {
        /// <summary> The display description. </summary>
        public string DisplayDescription { get; }

        /// <summary> The error code. </summary>
        public string ErrorCode { get; }

        /// <summary> The error message. </summary>
        public string ErrorMessage { get; }

        /// <summary> The metric identifier. </summary>
        public string Id { get; }

        /// <summary> The metric name. </summary>
        public MonitorLocalizableString Name { get; }

        /// <summary> The subscription-scope metric type. </summary>
        public string SubscriptionScopeMetricType { get; }

        /// <summary> The metric time series. </summary>
        public IReadOnlyList<MonitorTimeSeriesElement> Timeseries { get; }

        /// <summary> The metric unit. </summary>
        public MonitorMetricUnit Unit { get; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        SubscriptionMonitorMetric IJsonModel<SubscriptionMonitorMetric>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<SubscriptionMonitorMetric>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        SubscriptionMonitorMetric IPersistableModel<SubscriptionMonitorMetric>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<SubscriptionMonitorMetric>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<SubscriptionMonitorMetric>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}
