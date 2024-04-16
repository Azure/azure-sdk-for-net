// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.AI.OpenAI;

// CUSTOM CODE NOTE:
//   This portion of the partial class ensures we have factory exposure for all needed types, including ones
//   added in custom code.

public partial class StreamingChatCompletionsUpdate
{
    internal static List<StreamingChatCompletionsUpdate> DeserializeStreamingChatCompletionsUpdates(JsonElement element)
    {
        if (element.ValueKind == JsonValueKind.Null)
        {
            return new();
        }

        string id = default;
        string model = default;
        DateTimeOffset created = default;
        string systemFingerprint = null;
        ContentFilterResultsForPrompt requestContentFilterResults = null;
        List<StreamingChoiceData> choiceEntries = new();

        foreach (JsonProperty property in element.EnumerateObject())
        {
            if (property.NameEquals("id"u8))
            {
                id = property.Value.GetString();
                continue;
            }
            if (property.NameEquals("model"u8))
            {
                model = property.Value.GetString();
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
                    choiceEntries.Add(StreamingChoiceData.DeserializeStreamingChoiceData(choiceElement));
                }
            }
        }

        // If a chunk has no choices, we infer an empty one to aid traversal/expansion
        if (choiceEntries.Count == 0)
        {
            choiceEntries.Add(StreamingChoiceData.Empty);
        }

        // We inflate the possible combination of information into one StreamingChatCompletionsUpdate per tool
        // call update per choice, inferring an empty item in cases where the dimension isn't populated.

        List<StreamingChatCompletionsUpdate> results = new();

        foreach (StreamingChoiceData choiceData in choiceEntries)
        {
            foreach (StreamingToolCallUpdate toolCallUpdate in choiceData.Delta.ToolCallUpdates)
            {
                // This assembles the complete message context (including content filter information) for this item
                AzureChatExtensionsMessageContext azureMessageContext = choiceData.Delta.AzureMessageContext;
                if (requestContentFilterResults is not null || choiceData.ResponseFilterResults is not null)
                {
                    azureMessageContext ??= new();
                    azureMessageContext.RequestContentFilterResults = requestContentFilterResults;
                    azureMessageContext.ResponseContentFilterResults = choiceData.ResponseFilterResults;
                }

                results.Add(new(
                    id,
                    model,
                    created,
                    systemFingerprint,
                    choiceData.Index,
                    choiceData.Delta.Role,
                    choiceData.Delta.AuthorName,
                    choiceData.Delta.ContentUpdate,
                    choiceData.LogProbabilityInfo,
                    choiceData.FinishReason,
                    choiceData.Delta.FunctionName,
                    choiceData.Delta.FunctionArgumentsUpdate,
                    toolCallUpdate,
                    azureMessageContext));
            }
        }

        return results;
    }

    // CUSTOM CODE NOTE:
    // The below internal structs exist solely to decompose the non-trivial deserialization logic performed when
    // converting response chunks into the typed StreamingChatCompletionsUpdate.

    internal struct StreamingChoiceData
    {
        internal int Index { get; set; }
        internal CompletionsFinishReason? FinishReason { get; set; }
        internal ChatChoiceLogProbabilityInfo LogProbabilityInfo { get; set; }
        internal ContentFilterResultsForChoice ResponseFilterResults { get; set; }
        internal StreamingDeltaData Delta { get; set; } = StreamingDeltaData.Empty;

        public StreamingChoiceData() {}
        internal static StreamingChoiceData Empty { get; } = new();

        internal static StreamingChoiceData DeserializeStreamingChoiceData(JsonElement element, ModelReaderWriterOptions _ = default)
        {
            StreamingChoiceData result = new();

            foreach (JsonProperty choiceProperty in element.EnumerateObject())
            {
                if (choiceProperty.NameEquals("index"u8))
                {
                    result.Index = choiceProperty.Value.GetInt32();
                    continue;
                }
                if (choiceProperty.NameEquals("finish_reason"u8))
                {
                    if (choiceProperty.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    result.FinishReason = new CompletionsFinishReason(choiceProperty.Value.GetString());
                    continue;
                }
                if (choiceProperty.NameEquals("logprobs"u8))
                {
                    result.LogProbabilityInfo = ChatChoiceLogProbabilityInfo.DeserializeChatChoiceLogProbabilityInfo(choiceProperty.Value);
                    continue;
                }

                if (choiceProperty.NameEquals("content_filter_results"u8))
                {
                    if (choiceProperty.Value.EnumerateObject().Any())
                    {
                        // Note: there's only one of these per choice
                        result.ResponseFilterResults = ContentFilterResultsForChoice.DeserializeContentFilterResultsForChoice(choiceProperty.Value);
                    }
                    continue;
                }
                if (choiceProperty.NameEquals("delta"u8))
                {
                    result.Delta = StreamingDeltaData.DeserializeStreamingDeltaData(choiceProperty.Value);
                    continue;
                }
            }

            return result;
        }
    }

    internal struct StreamingDeltaData
    {
        internal ChatRole? Role { get; set; }
        internal string AuthorName { get; set; }
        internal string ContentUpdate { get; set; }
        internal string FunctionName { get; set; }
        internal string FunctionArgumentsUpdate { get; set; }
        internal IList<StreamingToolCallUpdate> ToolCallUpdates { get; set; }
        internal AzureChatExtensionsMessageContext AzureMessageContext { get; set; }

        public StreamingDeltaData()
        {
            ToolCallUpdates = new List<StreamingToolCallUpdate>();
        }
        internal static StreamingDeltaData Empty { get; } = new()
        {
            ToolCallUpdates = new List<StreamingToolCallUpdate>() { null }
        };

        internal static StreamingDeltaData DeserializeStreamingDeltaData(JsonElement element, ModelReaderWriterOptions _ = default)
        {
            StreamingDeltaData result = new();

            foreach (JsonProperty deltaProperty in element.EnumerateObject())
            {
                if (deltaProperty.NameEquals("role"u8))
                {
                    result.Role = deltaProperty.Value.GetString();
                    continue;
                }
                if (deltaProperty.NameEquals("name"u8))
                {
                    result.AuthorName = deltaProperty.Value.GetString();
                    continue;
                }
                if (deltaProperty.NameEquals("content"u8))
                {
                    result.ContentUpdate = deltaProperty.Value.GetString();
                    continue;
                }
                if (deltaProperty.NameEquals("function_call"u8))
                {
                    foreach (JsonProperty functionProperty in deltaProperty.Value.EnumerateObject())
                    {
                        if (functionProperty.NameEquals("name"u8))
                        {
                            result.FunctionName = functionProperty.Value.GetString();
                            continue;
                        }
                        if (functionProperty.NameEquals("arguments"u8))
                        {
                            result.FunctionArgumentsUpdate = functionProperty.Value.GetString();
                            continue;
                        }
                    }
                }
                if (deltaProperty.NameEquals("tool_calls"))
                {
                    foreach (JsonElement toolCallElement in deltaProperty.Value.EnumerateArray())
                    {
                        result.ToolCallUpdates.Add(StreamingToolCallUpdate.DeserializeStreamingToolCallUpdate(toolCallElement));
                    }
                }
                if (deltaProperty.NameEquals("context"u8))
                {
                    result.AzureMessageContext = AzureChatExtensionsMessageContext.DeserializeAzureChatExtensionsMessageContext(deltaProperty.Value);
                    continue;
                }
            }

            // Note: we add a null tool call update to the array solely to assist in traversal/expansion
            if (result.ToolCallUpdates.Count == 0)
            {
                result.ToolCallUpdates.Add(null);
            }

            return result;
        }
    }
}
