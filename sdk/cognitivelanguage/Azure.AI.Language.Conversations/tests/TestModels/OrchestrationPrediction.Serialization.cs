// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class OrchestrationPrediction
    {
        internal static OrchestrationPrediction DeserializeOrchestrationPrediction(JsonElement element)
        {
            IReadOnlyDictionary<string, TargetIntentResult> intents = default;
            ProjectKind projectKind = default;
            Optional<string> topIntent = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("intents"))
                {
                    Dictionary<string, TargetIntentResult> dictionary = new Dictionary<string, TargetIntentResult>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(property0.Name, TargetIntentResult.DeserializeTargetIntentResult(property0.Value));
                    }
                    intents = dictionary;
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
            return new OrchestrationPrediction(projectKind, topIntent.Value, intents);
        }
    }
}
