// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationPIIResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("conversationItems");
            writer.WriteStartArray();
            foreach (var item in ConversationItems)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static ConversationPIIResult DeserializeConversationPIIResult(JsonElement element)
        {
            IList<ConversationPIIItemResult> conversationItems = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("conversationItems"))
                {
                    List<ConversationPIIItemResult> array = new List<ConversationPIIItemResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ConversationPIIItemResult.DeserializeConversationPIIItemResult(item));
                    }
                    conversationItems = array;
                    continue;
                }
            }
            return new ConversationPIIResult(conversationItems);
        }
    }
}
