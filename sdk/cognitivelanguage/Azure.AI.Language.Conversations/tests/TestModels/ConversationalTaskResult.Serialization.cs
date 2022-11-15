// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationalTaskResult
    {
        internal static ConversationalTaskResult DeserializeConversationalTaskResult(JsonElement element)
        {
            AnalyzeConversationResult result = default;
            AnalyzeConversationTaskResultsKind kind = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("result"))
                {
                    result = AnalyzeConversationResult.DeserializeAnalyzeConversationResult(property.Value);
                    continue;
                }
                if (property.NameEquals("kind"))
                {
                    kind = new AnalyzeConversationTaskResultsKind(property.Value.GetString());
                    continue;
                }
            }
            return new ConversationalTaskResult(kind, result);
        }
    }
}
