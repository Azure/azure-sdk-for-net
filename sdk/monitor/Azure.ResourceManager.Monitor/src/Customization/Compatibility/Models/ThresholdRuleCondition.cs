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
    // Keep this obsolete derived type so the stable AlertRuleCondition polymorphic API remains loadable.
    /// <summary> A threshold rule condition. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is no longer supported.", false)]
    public partial class ThresholdRuleCondition : AlertRuleCondition, IJsonModel<ThresholdRuleCondition>, IPersistableModel<ThresholdRuleCondition>
    {
        /// <summary> Initializes a new instance of <see cref="ThresholdRuleCondition"/>. </summary>
        /// <param name="operator"> The condition operator. </param>
        /// <param name="threshold"> The threshold. </param>
        public ThresholdRuleCondition(MonitorConditionOperator @operator, double threshold)
        {
            Operator = @operator;
            Threshold = threshold;
        }

        /// <summary> The condition operator. </summary>
        public MonitorConditionOperator Operator { get; set; }

        /// <summary> The threshold. </summary>
        public double Threshold { get; set; }

        /// <summary> The time aggregation type. </summary>
        public ThresholdRuleConditionTimeAggregationType? TimeAggregation { get; set; }

        /// <summary> The time window over which to evaluate the condition. </summary>
        public TimeSpan? WindowSize { get; set; }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        ThresholdRuleCondition IJsonModel<ThresholdRuleCondition>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        void IJsonModel<ThresholdRuleCondition>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        ThresholdRuleCondition IPersistableModel<ThresholdRuleCondition>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<ThresholdRuleCondition>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<ThresholdRuleCondition>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");
    }
}
