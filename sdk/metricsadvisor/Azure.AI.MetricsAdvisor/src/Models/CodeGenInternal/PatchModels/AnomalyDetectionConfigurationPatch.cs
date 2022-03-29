// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class AnomalyDetectionConfigurationPatch
    {
        /// <summary> detection configuration for series group. </summary>
        public IList<MetricSeriesGroupDetectionCondition> DimensionGroupOverrideConfigurations { get; internal set; }

        /// <summary> detection configuration for specific series. </summary>
        public IList<MetricSingleSeriesDetectionCondition> SeriesOverrideConfigurations { get; internal set; }

        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteNullObjectValue("name", Name);
            writer.WriteNullObjectValue("description", Description);
            writer.WriteNullObjectValue("wholeMetricConfiguration", WholeMetricConfiguration);
            if (Optional.IsCollectionDefined(DimensionGroupOverrideConfigurations))
            {
                writer.WritePropertyName("dimensionGroupOverrideConfigurations");
                writer.WriteStartArray();
                foreach (var item in DimensionGroupOverrideConfigurations)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(SeriesOverrideConfigurations))
            {
                writer.WritePropertyName("seriesOverrideConfigurations");
                writer.WriteStartArray();
                foreach (var item in SeriesOverrideConfigurations)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }
    }
}
