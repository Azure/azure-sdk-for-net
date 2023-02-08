// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationsSummaryResultSummariesItem : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("aspect");
            writer.WriteStringValue(Aspect);
            writer.WritePropertyName("text");
            writer.WriteStringValue(Text);
            if (Optional.IsCollectionDefined(Contexts))
            {
                writer.WritePropertyName("contexts");
                writer.WriteStartArray();
                foreach (var item in Contexts)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static ConversationsSummaryResultSummariesItem DeserializeConversationsSummaryResultSummariesItem(JsonElement element)
        {
            string aspect = default;
            string text = default;
            Optional<IList<ItemizedSummaryContext>> contexts = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("aspect"))
                {
                    aspect = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("text"))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("contexts"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<ItemizedSummaryContext> array = new List<ItemizedSummaryContext>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ItemizedSummaryContext.DeserializeItemizedSummaryContext(item));
                    }
                    contexts = array;
                    continue;
                }
            }
            return new ConversationsSummaryResultSummariesItem(aspect, text, Optional.ToList(contexts));
        }
    }
}
