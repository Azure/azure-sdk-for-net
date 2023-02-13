// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationsSummaryResult : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("summaries");
            writer.WriteStartArray();
            foreach (var item in Summaries)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static ConversationsSummaryResult DeserializeConversationsSummaryResult(JsonElement element)
        {
            IList<ConversationsSummaryResultSummariesItem> summaries = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("summaries"))
                {
                    List<ConversationsSummaryResultSummariesItem> array = new List<ConversationsSummaryResultSummariesItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ConversationsSummaryResultSummariesItem.DeserializeConversationsSummaryResultSummariesItem(item));
                    }
                    summaries = array;
                    continue;
                }
            }
            return new ConversationsSummaryResult(summaries);
        }
    }
}
