// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class WholeMetricConfigurationPatch
    {
        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(ConditionOperator))
            {
                writer.WritePropertyName("conditionOperator");
                writer.WriteStringValue(ConditionOperator.Value.ToString());
            }
            writer.WriteNullObjectValue("smartDetectionCondition", SmartDetectionCondition);
            writer.WriteNullObjectValue("hardThresholdCondition", HardThresholdCondition);
            writer.WriteNullObjectValue("changeThresholdCondition", ChangeThresholdCondition);
            writer.WriteEndObject();
        }
    }
}
