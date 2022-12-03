// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class AnalyzeConversationalSentimentTask : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Parameters))
            {
                writer.WritePropertyName("parameters");
                writer.WriteObjectValue(Parameters);
            }
            writer.WritePropertyName("kind");
            writer.WriteStringValue(Kind.ToString());
            if (Optional.IsDefined(TaskName))
            {
                writer.WritePropertyName("taskName");
                writer.WriteStringValue(TaskName);
            }
            writer.WriteEndObject();
        }

        internal static AnalyzeConversationalSentimentTask DeserializeAnalyzeConversationalSentimentTask(JsonElement element)
        {
            Optional<ConversationalSentimentTaskParameters> parameters = default;
            AnalyzeConversationLROTaskKind kind = default;
            Optional<string> taskName = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("parameters"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    parameters = ConversationalSentimentTaskParameters.DeserializeConversationalSentimentTaskParameters(property.Value);
                    continue;
                }
                if (property.NameEquals("kind"))
                {
                    kind = new AnalyzeConversationLROTaskKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("taskName"))
                {
                    taskName = property.Value.GetString();
                    continue;
                }
            }
            return new AnalyzeConversationalSentimentTask(taskName.Value, kind, parameters.Value);
        }
    }
}
