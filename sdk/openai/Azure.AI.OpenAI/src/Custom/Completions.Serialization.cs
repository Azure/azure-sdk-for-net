// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    public partial class Completions
    {
        internal static Completions DeserializeCompletions(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            DateTimeOffset created = default;
            Optional<IReadOnlyList<PromptFilterResult>> promptAnnotations = default;
            IReadOnlyList<Choice> choices = default;
            CompletionsUsage usage = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("created"u8))
                {
                    created = DateTimeOffset.FromUnixTimeSeconds(property.Value.GetInt64());
                    continue;
                }
                // CUSTOM CODE NOTE: temporary, custom handling of forked keys for prompt filter results
                if (property.NameEquals("prompt_annotations"u8) || property.NameEquals("prompt_filter_results"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<PromptFilterResult> array = new List<PromptFilterResult>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(PromptFilterResult.DeserializePromptFilterResult(item));
                    }
                    promptAnnotations = array;
                    continue;
                }
                if (property.NameEquals("choices"u8))
                {
                    List<Choice> array = new List<Choice>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(Choice.DeserializeChoice(item));
                    }
                    choices = array;
                    continue;
                }
                if (property.NameEquals("usage"u8))
                {
                    usage = CompletionsUsage.DeserializeCompletionsUsage(property.Value);
                    continue;
                }
            }
            return new Completions(id, created, Optional.ToList(promptAnnotations), choices, usage);
        }

        /// <summary> Deserializes the model from a raw response. </summary>
        /// <param name="response"> The response to deserialize the model from. </param>
        internal static Completions FromResponse(Response response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeCompletions(document.RootElement);
        }
    }
}
