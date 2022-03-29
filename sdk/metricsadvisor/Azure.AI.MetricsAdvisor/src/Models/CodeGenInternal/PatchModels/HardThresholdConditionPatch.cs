// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.MetricsAdvisor.Models
{
    internal partial class HardThresholdConditionPatch : IUtf8JsonSerializable
    {
        // Full qualification must be used so CodeGen skips the generation of this method.
        // See: https://github.com/Azure/autorest.csharp/issues/793
        void global::Azure.Core.IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WriteNullObjectValue("lowerBound", LowerBound);
            writer.WriteNullObjectValue("upperBound", UpperBound);
            writer.WriteNullStringValue("anomalyDetectorDirection", AnomalyDetectorDirection);
            writer.WriteNullObjectValue("suppressCondition", SuppressCondition);
            writer.WriteEndObject();
        }
    }
}
