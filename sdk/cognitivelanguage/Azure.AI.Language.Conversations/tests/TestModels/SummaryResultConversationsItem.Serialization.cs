// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class SummaryResultConversationsItem : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id");
            writer.WriteStringValue(Id);
            writer.WritePropertyName("warnings");
            writer.WriteStartArray();
            foreach (var item in Warnings)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(Statistics))
            {
                writer.WritePropertyName("statistics");
                writer.WriteObjectValue(Statistics);
            }
            writer.WritePropertyName("summaries");
            writer.WriteStartArray();
            foreach (var item in Summaries)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }

        internal static SummaryResultConversationsItem DeserializeSummaryResultConversationsItem(JsonElement element)
        {
            string id = default;
            IList<InputWarning> warnings = default;
            Optional<ConversationStatistics> statistics = default;
            IList<ConversationsSummaryResultSummariesItem> summaries = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("warnings"))
                {
                    List<InputWarning> array = new List<InputWarning>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InputWarning.DeserializeInputWarning(item));
                    }
                    warnings = array;
                    continue;
                }
                if (property.NameEquals("statistics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    statistics = ConversationStatistics.DeserializeConversationStatistics(property.Value);
                    continue;
                }
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
            return new SummaryResultConversationsItem(summaries, id, warnings, statistics.Value);
        }
    }
}
