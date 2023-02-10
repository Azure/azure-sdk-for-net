// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationPIIResults : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("conversations");
            writer.WriteStartArray();
            foreach (var item in Conversations)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("errors");
            writer.WriteStartArray();
            foreach (var item in Errors)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            if (Optional.IsDefined(Statistics))
            {
                writer.WritePropertyName("statistics");
                writer.WriteObjectValue(Statistics);
            }
            writer.WritePropertyName("modelVersion");
            writer.WriteStringValue(ModelVersion);
            writer.WriteEndObject();
        }

        internal static ConversationPIIResults DeserializeConversationPIIResults(JsonElement element)
        {
            IList<ConversationPIIResultsConversationsItem> conversations = default;
            IList<InputError> errors = default;
            Optional<RequestStatistics> statistics = default;
            string modelVersion = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("conversations"))
                {
                    List<ConversationPIIResultsConversationsItem> array = new List<ConversationPIIResultsConversationsItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ConversationPIIResultsConversationsItem.DeserializeConversationPIIResultsConversationsItem(item));
                    }
                    conversations = array;
                    continue;
                }
                if (property.NameEquals("errors"))
                {
                    List<InputError> array = new List<InputError>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(InputError.DeserializeInputError(item));
                    }
                    errors = array;
                    continue;
                }
                if (property.NameEquals("statistics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    statistics = RequestStatistics.DeserializeRequestStatistics(property.Value);
                    continue;
                }
                if (property.NameEquals("modelVersion"))
                {
                    modelVersion = property.Value.GetString();
                    continue;
                }
            }
            return new ConversationPIIResults(errors, statistics.Value, modelVersion, conversations);
        }
    }
}
