// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class SentimentConfidenceScores : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("positive");
            writer.WriteNumberValue(Positive);
            writer.WritePropertyName("neutral");
            writer.WriteNumberValue(Neutral);
            writer.WritePropertyName("negative");
            writer.WriteNumberValue(Negative);
            writer.WriteEndObject();
        }

        internal static SentimentConfidenceScores DeserializeSentimentConfidenceScores(JsonElement element)
        {
            double positive = default;
            double neutral = default;
            double negative = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("positive"))
                {
                    positive = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("neutral"))
                {
                    neutral = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("negative"))
                {
                    negative = property.Value.GetDouble();
                    continue;
                }
            }
            return new SentimentConfidenceScores(positive, neutral, negative);
        }
    }
}
