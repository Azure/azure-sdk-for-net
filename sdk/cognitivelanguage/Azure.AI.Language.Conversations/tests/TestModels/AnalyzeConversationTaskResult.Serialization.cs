// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;

namespace Azure.AI.Language.Conversations
{
    public partial class AnalyzeConversationTaskResult
    {
        internal static AnalyzeConversationTaskResult DeserializeAnalyzeConversationTaskResult(JsonElement element)
        {
            if (element.TryGetProperty("kind", out JsonElement discriminator))
            {
                switch (discriminator.GetString())
                {
                    case "ConversationResult": return ConversationalTaskResult.DeserializeConversationalTaskResult(element);
                }
            }
            return UnknownAnalyzeConversationTaskResult.DeserializeUnknownAnalyzeConversationTaskResult(element);
        }
    }
}
