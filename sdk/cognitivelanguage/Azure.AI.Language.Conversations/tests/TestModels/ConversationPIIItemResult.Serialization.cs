// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationPIIItemResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("redactedContent");
            writer.WriteObjectValue(RedactedContent);
            writer.WritePropertyName("entities");
            writer.WriteStartArray();
            foreach (var item in Entities)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static ConversationPIIItemResult DeserializeConversationPIIItemResult(JsonElement element)
        {
            string id = default;
            RedactedTranscriptContent redactedContent = default;
            IList<Entity> entities = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("redactedContent"))
                {
                    redactedContent = RedactedTranscriptContent.DeserializeRedactedTranscriptContent(property.Value);
                    continue;
                }
                if (property.NameEquals("entities"))
                {
                    List<Entity> array = new List<Entity>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Entity.DeserializeEntity(item));
                    }
                    entities = array;
                    continue;
                }
            }
            return new ConversationPIIItemResult(id, redactedContent, entities);
        }
    }
}
