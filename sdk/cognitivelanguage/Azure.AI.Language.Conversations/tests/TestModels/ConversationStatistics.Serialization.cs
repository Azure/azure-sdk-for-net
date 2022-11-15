// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationStatistics : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("transactionsCount");
            writer.WriteNumberValue(TransactionsCount);
            writer.WriteEndObject();
        }

        internal static ConversationStatistics DeserializeConversationStatistics(JsonElement element)
        {
            int transactionsCount = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("transactionsCount"))
                {
                    transactionsCount = property.Value.GetInt32();
                    continue;
                }
            }
            return new ConversationStatistics(transactionsCount);
        }
    }
}
