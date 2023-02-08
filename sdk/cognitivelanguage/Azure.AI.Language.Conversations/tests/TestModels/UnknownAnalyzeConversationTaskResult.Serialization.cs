// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    internal partial class UnknownAnalyzeConversationTaskResult
    {
        internal static UnknownAnalyzeConversationTaskResult DeserializeUnknownAnalyzeConversationTaskResult(JsonElement element)
        {
            AnalyzeConversationTaskResultsKind kind = "Unknown";
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("kind"))
                {
                    kind = new AnalyzeConversationTaskResultsKind(property.Value.GetString());
                    continue;
                }
            }
            return new UnknownAnalyzeConversationTaskResult(kind);
        }
    }
}
