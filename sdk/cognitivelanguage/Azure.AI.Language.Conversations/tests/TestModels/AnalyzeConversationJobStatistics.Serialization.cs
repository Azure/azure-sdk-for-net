// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class AnalyzeConversationJobStatistics
    {
        internal static AnalyzeConversationJobStatistics DeserializeAnalyzeConversationJobStatistics(JsonElement element)
        {
            Optional<ConversationRequestStatistics> statistics = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("statistics"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    statistics = ConversationRequestStatistics.DeserializeConversationRequestStatistics(property.Value);
                    continue;
                }
            }
            return new AnalyzeConversationJobStatistics(statistics.Value);
        }
    }
}
