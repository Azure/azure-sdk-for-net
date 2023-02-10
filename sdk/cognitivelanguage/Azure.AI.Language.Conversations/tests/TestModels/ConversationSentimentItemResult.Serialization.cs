// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationSentimentItemResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("participantId");
            writer.WriteStringValue(ParticipantId);
            writer.WritePropertyName("sentiment");
            writer.WriteStringValue(Sentiment.ToString());
            writer.WritePropertyName("confidenceScores");
            writer.WriteObjectValue(ConfidenceScores);
            writer.WriteEndObject();
        }

        internal static ConversationSentimentItemResult DeserializeConversationSentimentItemResult(JsonElement element)
        {
            string id = default;
            string participantId = default;
            TextSentiment sentiment = default;
            SentimentConfidenceScores confidenceScores = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("participantId"))
                {
                    participantId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sentiment"))
                {
                    sentiment = new TextSentiment(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("confidenceScores"))
                {
                    confidenceScores = SentimentConfidenceScores.DeserializeSentimentConfidenceScores(property.Value);
                    continue;
                }
            }
            return new ConversationSentimentItemResult(id, participantId, sentiment, confidenceScores);
        }
    }
}
