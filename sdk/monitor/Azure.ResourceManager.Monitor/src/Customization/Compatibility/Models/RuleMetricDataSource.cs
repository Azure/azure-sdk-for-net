// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Monitor.Models
{
    // TypeSpec no longer models the legacy AlertRule data-source hierarchy.
    // Keep this obsolete derived type so the stable RuleDataSource polymorphic API remains loadable.
    /// <summary> A metric alert rule data source. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class RuleMetricDataSource : RuleDataSource, IJsonModel<RuleMetricDataSource>, IPersistableModel<RuleMetricDataSource>
    {
        /// <summary> Initializes a new instance of <see cref="RuleMetricDataSource"/>. </summary>
        public RuleMetricDataSource()
        {
        }

        /// <summary> The metric name. </summary>
        public string MetricName { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        RuleMetricDataSource IJsonModel<RuleMetricDataSource>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<RuleMetricDataSource>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        RuleMetricDataSource IPersistableModel<RuleMetricDataSource>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<RuleMetricDataSource>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<RuleMetricDataSource>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}
