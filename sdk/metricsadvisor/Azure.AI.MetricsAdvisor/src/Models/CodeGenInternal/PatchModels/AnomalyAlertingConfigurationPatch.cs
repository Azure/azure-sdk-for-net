// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    /// <summary> The AnomalyAlertingConfigurationPatch. </summary>
    internal partial class AnomalyAlertingConfigurationPatch
    {
        /// <summary> hook unique ids. </summary>
        public IList<Guid> HookIds { get; internal set; }

        /// <summary> Anomaly alerting configurations. </summary>
        public IList<MetricAlertConfiguration> MetricAlertingConfigurations { get; internal set; }

        /// <summary> dimensions used to split alert. </summary>
        public IList<string> SplitAlertByDimensions { get; internal set; }

        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteNullObjectValue("name", Name);
            writer.WriteNullObjectValue("description", Description);
            if (Optional.IsDefined(CrossMetricsOperator))
            {
                writer.WritePropertyName("crossMetricsOperator");
                writer.WriteStringValue(CrossMetricsOperator.Value.ToString());
            }
            if (Optional.IsCollectionDefined(SplitAlertByDimensions))
            {
                writer.WritePropertyName("splitAlertByDimensions");
                writer.WriteStartArray();
                foreach (var item in SplitAlertByDimensions)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(HookIds))
            {
                writer.WritePropertyName("hookIds");
                writer.WriteStartArray();
                foreach (var item in HookIds)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(MetricAlertingConfigurations))
            {
                writer.WritePropertyName("metricAlertingConfigurations");
                writer.WriteStartArray();
                foreach (var item in MetricAlertingConfigurations)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
    }
}
