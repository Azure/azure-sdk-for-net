// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.MachineLearningServices.Models
{
    public partial class EarlyTerminationPolicyConfiguration : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("policyType");
            writer.WriteStringValue(PolicyType.ToString());
            if (Optional.IsDefined(EvaluationInterval))
            {
                writer.WritePropertyName("evaluationInterval");
                writer.WriteNumberValue(EvaluationInterval.Value);
            }
            if (Optional.IsDefined(DelayEvaluation))
            {
                writer.WritePropertyName("delayEvaluation");
                writer.WriteNumberValue(DelayEvaluation.Value);
            }
            writer.WriteEndObject();
        }

        internal static EarlyTerminationPolicyConfiguration DeserializeEarlyTerminationPolicyConfiguration(JsonElement element)
        {
            EarlyTerminationPolicyType policyType = default;
            Optional<int> evaluationInterval = default;
            Optional<int> delayEvaluation = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("policyType"))
                {
                    policyType = new EarlyTerminationPolicyType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("evaluationInterval"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    evaluationInterval = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("delayEvaluation"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    delayEvaluation = property.Value.GetInt32();
                    continue;
                }
            }
            return new EarlyTerminationPolicyConfiguration(policyType, Optional.ToNullable(evaluationInterval), Optional.ToNullable(delayEvaluation));
        }
    }
}
