// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
//   This portion of the partial class ensures we have factory exposure for all needed types, including ones
//   added in custom code.

public partial class StreamingChatCompletionsUpdate
{
    internal static List<StreamingChatCompletionsUpdate> DeserializeStreamingChatCompletionsUpdates(JsonElement element)
    {
        var results = new List<StreamingChatCompletionsUpdate>();
        if (element.ValueKind == JsonValueKind.Null)
        {
            return results;
        }
        string id = default;
        DateTimeOffset created = default;
        string systemFingerprint = null;
        AzureChatExtensionsMessageContext azureExtensionsContext = null;
        ContentFilterResultsForPrompt requestContentFilterResults = null;
        foreach (JsonProperty property in element.EnumerateObject())
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
            if (property.NameEquals("system_fingerprint"))
            {
                systemFingerprint = property.Value.GetString();
                continue;
            }
            // CUSTOM CODE NOTE: temporary, custom handling of forked keys for prompt filter results
            if (property.NameEquals("prompt_annotations"u8) || property.NameEquals("prompt_filter_results"))
            {
                if (property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }
                List<ContentFilterResultsForPrompt> array = new List<ContentFilterResultsForPrompt>();
                foreach (var item in property.Value.EnumerateArray())
                {
                    requestContentFilterResults = ContentFilterResultsForPrompt.DeserializeContentFilterResultsForPrompt(item);
                }
                continue;
            }
            if (property.NameEquals("choices"u8))
            {
                foreach (JsonElement choiceElement in property.Value.EnumerateArray())
                {
                    ChatRole? role = null;
                    string contentUpdate = null;
                    string functionName = null;
                    string authorName = null;
                    string functionArgumentsUpdate = null;
                    int choiceIndex = 0;
                    CompletionsFinishReason? finishReason = null;
                    ContentFilterResultsForChoice responseContentFilterResults = null;
                    ChangeTrackingList<StreamingToolCallUpdate> toolCallUpdates = new();

                    foreach (JsonProperty choiceProperty in choiceElement.EnumerateObject())
                    {
                        if (choiceProperty.NameEquals("index"u8))
                        {
                            choiceIndex = choiceProperty.Value.GetInt32();
                            continue;
                        }
                        if (choiceProperty.NameEquals("finish_reason"u8))
                        {
                            if (choiceProperty.Value.ValueKind == JsonValueKind.Null)
                            {
                                finishReason = null;
                                continue;
                            }
                            finishReason = new CompletionsFinishReason(choiceProperty.Value.GetString());
                            continue;
                        }
                        if (choiceProperty.NameEquals("delta"u8))
                        {
                            foreach (JsonProperty deltaProperty in choiceProperty.Value.EnumerateObject())
                            {
                                if (deltaProperty.NameEquals("role"u8))
                                {
                                    role = deltaProperty.Value.GetString();
                                    continue;
                                }
                                if (deltaProperty.NameEquals("name"u8))
                                {
                                    authorName = deltaProperty.Value.GetString();
                                    continue;
                                }
                                if (deltaProperty.NameEquals("content"u8))
                                {
                                    contentUpdate = deltaProperty.Value.GetString();
                                    continue;
                                }
                                if (deltaProperty.NameEquals("function_call"u8))
                                {
                                    foreach (JsonProperty functionProperty in deltaProperty.Value.EnumerateObject())
                                    {
                                        if (functionProperty.NameEquals("name"u8))
                                        {
                                            functionName = functionProperty.Value.GetString();
                                            continue;
                                        }
                                        if (functionProperty.NameEquals("arguments"u8))
                                        {
                                            functionArgumentsUpdate = functionProperty.Value.GetString();
                                        }
                                    }
                                }
                                if (deltaProperty.NameEquals("tool_calls"))
                                {
                                    foreach (JsonElement toolCallElement in deltaProperty.Value.EnumerateArray())
                                    {
                                        toolCallUpdates.Add(
                                            StreamingToolCallUpdate.DeserializeStreamingToolCallUpdate(toolCallElement));
                                    }
                                }
                                if (deltaProperty.NameEquals("context"u8))
                                {
                                    azureExtensionsContext = AzureChatExtensionsMessageContext
                                        .DeserializeAzureChatExtensionsMessageContext(deltaProperty.Value);
                                    continue;
                                }
                            }
                        }
                        if (choiceProperty.NameEquals("content_filter_results"u8))
                        {
                            if (choiceProperty.Value.EnumerateObject().Any())
                            {
                                responseContentFilterResults
                                    = ContentFilterResultsForChoice.DeserializeContentFilterResultsForChoice(choiceProperty.Value);
                            }
                            continue;
                        }
                    }
                    if (requestContentFilterResults is not null || responseContentFilterResults is not null)
                    {
                        azureExtensionsContext ??= new AzureChatExtensionsMessageContext();
                        azureExtensionsContext.RequestContentFilterResults = requestContentFilterResults;
                        azureExtensionsContext.ResponseContentFilterResults = responseContentFilterResults;
                    }
                    // In the unlikely event that more than one tool call arrives on a single chunk, we'll generate
                    // separate updates just like for choices. Adding a "null" if empty lets us avoid a separate loop.
                    if (toolCallUpdates.Count == 0)
                    {
                        toolCallUpdates.Add(null);
                    }
                    foreach (StreamingToolCallUpdate toolCallUpdate in toolCallUpdates)
                    {
                        results.Add(new StreamingChatCompletionsUpdate(
                            id,
                            created,
                            systemFingerprint,
                            choiceIndex,
                            role,
                            authorName,
                            contentUpdate,
                            finishReason,
                            functionName,
                            functionArgumentsUpdate,
                            toolCallUpdate,
                            azureExtensionsContext));
                    }
                }
                continue;
            }
        }
        if (results.Count == 0)
        {
            if (requestContentFilterResults is not null)
            {
                azureExtensionsContext ??= new AzureChatExtensionsMessageContext()
                {
                    RequestContentFilterResults = requestContentFilterResults,
                };
            }
            results.Add(new StreamingChatCompletionsUpdate(id, created, systemFingerprint, azureExtensionsContext: azureExtensionsContext));
        }
        return results;
    }
}
