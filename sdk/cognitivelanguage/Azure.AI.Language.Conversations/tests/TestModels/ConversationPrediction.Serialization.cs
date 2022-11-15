// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationPrediction
    {
        internal static ConversationPrediction DeserializeConversationPrediction(JsonElement element)
        {
            IReadOnlyList<ConversationIntent> intents = default;
            IReadOnlyList<ConversationEntity> entities = default;
            ProjectKind projectKind = default;
            Optional<string> topIntent = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("intents"))
                {
                    List<ConversationIntent> array = new List<ConversationIntent>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ConversationIntent.DeserializeConversationIntent(item));
                    }
                    intents = array;
                    continue;
                }
                if (property.NameEquals("entities"))
                {
                    List<ConversationEntity> array = new List<ConversationEntity>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ConversationEntity.DeserializeConversationEntity(item));
                    }
                    entities = array;
                    continue;
                }
                if (property.NameEquals("projectKind"))
                {
                    projectKind = new ProjectKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("topIntent"))
                {
                    topIntent = property.Value.GetString();
                    continue;
                }
            }
            return new ConversationPrediction(projectKind, topIntent.Value, intents, entities);
        }
    }
}
