// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class AnalyzeConversationSentimentResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("results");
            writer.WriteObjectValue(Results);
            writer.WritePropertyName("kind");
            writer.WriteStringValue(Kind.ToString());
            if (Optional.IsDefined(TaskName))
            {
                writer.WritePropertyName("taskName");
                writer.WriteStringValue(TaskName);
            }
            writer.WritePropertyName("lastUpdateDateTime");
            writer.WriteStringValue(LastUpdateDateTime, "O");
            writer.WritePropertyName("status");
            writer.WriteStringValue(Status.ToString());
            writer.WriteEndObject();
        }

        internal static AnalyzeConversationSentimentResult DeserializeAnalyzeConversationSentimentResult(JsonElement element)
        {
            ConversationSentimentResults results = default;
            AnalyzeConversationResultsKind kind = default;
            Optional<string> taskName = default;
            DateTimeOffset lastUpdateDateTime = default;
            State status = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("results"))
                {
                    results = ConversationSentimentResults.DeserializeConversationSentimentResults(property.Value);
                    continue;
                }
                if (property.NameEquals("kind"))
                {
                    kind = new AnalyzeConversationResultsKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("taskName"))
                {
                    taskName = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("lastUpdateDateTime"))
                {
                    lastUpdateDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("status"))
                {
                    status = new State(property.Value.GetString());
                    continue;
                }
            }
            return new AnalyzeConversationSentimentResult(lastUpdateDateTime, status, kind, taskName.Value, results);
        }
    }
}
