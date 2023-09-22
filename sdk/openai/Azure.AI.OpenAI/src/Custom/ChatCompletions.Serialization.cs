// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI
{
    public partial class ChatCompletions
    {
        internal static ChatCompletions DeserializeChatCompletions(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string id = default;
            DateTimeOffset created = default;
            IReadOnlyList<ChatChoice> choices = default;
            Optional<IReadOnlyList<PromptFilterResult>> promptAnnotations = default;
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
                if (property.NameEquals("choices"u8))
                {
                    List<ChatChoice> array = new List<ChatChoice>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChatChoice.DeserializeChatChoice(item));
                    }
                    choices = array;
                    continue;
                }
                // CUSTOM CODE NOTE: temporary, custom handling of forked keys for prompt filter results
                if (property.NameEquals("prompt_annotations"u8) || property.NameEquals("prompt_filter_results"u8))
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
                if (property.NameEquals("usage"u8))
                {
                    usage = CompletionsUsage.DeserializeCompletionsUsage(property.Value);
                    continue;
                }
            }
            return new ChatCompletions(id, created, choices, Optional.ToList(promptAnnotations), usage);
        }
    }
}
