// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Monitor.Models
{
    // TypeSpec no longer models the legacy AlertRule condition hierarchy.
    // Keep this obsolete aggregation payload for ManagementEventRuleCondition compatibility.
    /// <summary> A management event aggregation condition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This API is no longer supported.", false)]
    public partial class ManagementEventAggregationCondition : IJsonModel<ManagementEventAggregationCondition>, IPersistableModel<ManagementEventAggregationCondition>
    {
        /// <summary> Initializes a new instance of <see cref="ManagementEventAggregationCondition"/>. </summary>
        public ManagementEventAggregationCondition()
        {
        }

        /// <summary> The condition operator. </summary>
        public MonitorConditionOperator? Operator { get; set; }

        /// <summary> The threshold. </summary>
        public double? Threshold { get; set; }

        /// <summary> The time window over which to evaluate the condition. </summary>
        public TimeSpan? WindowSize { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        ManagementEventAggregationCondition IJsonModel<ManagementEventAggregationCondition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<ManagementEventAggregationCondition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        ManagementEventAggregationCondition IPersistableModel<ManagementEventAggregationCondition>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<ManagementEventAggregationCondition>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<ManagementEventAggregationCondition>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}
