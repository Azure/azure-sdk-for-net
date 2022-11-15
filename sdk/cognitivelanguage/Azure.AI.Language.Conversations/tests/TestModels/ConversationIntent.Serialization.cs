// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationIntent
    {
        internal static ConversationIntent DeserializeConversationIntent(JsonElement element)
        {
            string category = default;
            float confidenceScore = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("category"))
                {
                    category = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("confidenceScore"))
                {
                    confidenceScore = property.Value.GetSingle();
                    continue;
                }
            }
            return new ConversationIntent(category, confidenceScore);
        }
    }
}
