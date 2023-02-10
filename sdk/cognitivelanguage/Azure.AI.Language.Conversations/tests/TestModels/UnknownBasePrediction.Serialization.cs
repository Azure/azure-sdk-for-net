// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    internal partial class UnknownBasePrediction
    {
        internal static UnknownBasePrediction DeserializeUnknownBasePrediction(JsonElement element)
        {
            ProjectKind projectKind = "Unknown";
            Optional<string> topIntent = default;
            foreach (var property in element.EnumerateObject())
            {
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
            return new UnknownBasePrediction(projectKind, topIntent.Value);
        }
    }
}
