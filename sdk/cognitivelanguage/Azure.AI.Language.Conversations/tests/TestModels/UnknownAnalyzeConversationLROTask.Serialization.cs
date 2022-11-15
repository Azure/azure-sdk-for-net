// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    internal partial class UnknownAnalyzeConversationLROTask : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("kind");
            writer.WriteStringValue(Kind.ToString());
            if (Optional.IsDefined(TaskName))
            {
                writer.WritePropertyName("taskName");
                writer.WriteStringValue(TaskName);
            }
            writer.WriteEndObject();
        }

        internal static UnknownAnalyzeConversationLROTask DeserializeUnknownAnalyzeConversationLROTask(JsonElement element)
        {
            AnalyzeConversationLROTaskKind kind = "Unknown";
            Optional<string> taskName = default;
            foreach (var property in element.EnumerateObject())
            {
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
            return new UnknownAnalyzeConversationLROTask(taskName.Value, kind);
        }
    }
}
