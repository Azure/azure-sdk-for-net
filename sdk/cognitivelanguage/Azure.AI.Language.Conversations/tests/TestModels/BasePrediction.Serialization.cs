// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.AI.Language.Conversations
{
    public partial class BasePrediction
    {
        internal static BasePrediction DeserializeBasePrediction(JsonElement element)
        {
            if (element.TryGetProperty("projectKind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Orchestration": return OrchestrationPrediction.DeserializeOrchestrationPrediction(element);
                    case "Conversation": return ConversationPrediction.DeserializeConversationPrediction(element);
                }
            }
            return UnknownBasePrediction.DeserializeUnknownBasePrediction(element);
        }
    }
}
