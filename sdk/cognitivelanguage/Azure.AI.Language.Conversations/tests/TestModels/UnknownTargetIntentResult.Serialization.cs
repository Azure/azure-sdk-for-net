// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    internal partial class UnknownTargetIntentResult
    {
        internal static UnknownTargetIntentResult DeserializeUnknownTargetIntentResult(JsonElement element)
        {
            TargetProjectKind targetProjectKind = "Unknown";
            Optional<string> apiVersion = default;
            double confidenceScore = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("targetProjectKind"))
                {
                    targetProjectKind = new TargetProjectKind(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("apiVersion"))
                {
                    apiVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("confidenceScore"))
                {
                    confidenceScore = property.Value.GetDouble();
                    continue;
                }
            }
            return new UnknownTargetIntentResult(targetProjectKind, apiVersion.Value, confidenceScore);
        }
    }
}
