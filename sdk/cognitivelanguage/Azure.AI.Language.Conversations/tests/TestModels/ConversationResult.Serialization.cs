// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationResult
    {
        internal static ConversationResult DeserializeConversationResult(JsonElement element)
        {
            string query = default;
            Optional<string> detectedLanguage = default;
            Optional<ConversationPrediction> prediction = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("query"))
                {
                    query = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("detectedLanguage"))
                {
                    detectedLanguage = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("prediction"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    prediction = ConversationPrediction.DeserializeConversationPrediction(property.Value);
                    continue;
                }
            }
            return new ConversationResult(query, detectedLanguage.Value, prediction.Value);
        }
    }
}
