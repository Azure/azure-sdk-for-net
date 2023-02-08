// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.AI.Language.Conversations
{
    public partial class TargetIntentResult
    {
        internal static TargetIntentResult DeserializeTargetIntentResult(JsonElement element)
        {
            if (element.TryGetProperty("targetProjectKind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "Conversation": return ConversationTargetIntentResult.DeserializeConversationTargetIntentResult(element);
                    case "Luis": return LuisTargetIntentResult.DeserializeLuisTargetIntentResult(element);
                    case "NonLinked": return NoneLinkedTargetIntentResult.DeserializeNoneLinkedTargetIntentResult(element);
                    case "QuestionAnswering": return QuestionAnsweringTargetIntentResult.DeserializeQuestionAnsweringTargetIntentResult(element);
                }
            }
            return UnknownTargetIntentResult.DeserializeUnknownTargetIntentResult(element);
        }
    }
}
