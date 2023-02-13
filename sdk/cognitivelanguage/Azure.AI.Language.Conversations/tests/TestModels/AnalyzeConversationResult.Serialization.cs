// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class AnalyzeConversationResult
    {
        internal static AnalyzeConversationResult DeserializeAnalyzeConversationResult(JsonElement element)
        {
            string query = default;
            Optional<string> detectedLanguage = default;
            BasePrediction prediction = default;
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
                    prediction = BasePrediction.DeserializeBasePrediction(property.Value);
                    continue;
                }
            }
            return new AnalyzeConversationResult(query, detectedLanguage.Value, prediction);
        }
    }
}
