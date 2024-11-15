// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Azure.AI.Inference
{
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
            List<StreamingChatChoiceUpdate> choiceEntries = new();
            CompletionsUsage completionsUsage = null;

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
                if (property.NameEquals("choices"u8))
                {
                    foreach (JsonElement choiceElement in property.Value.EnumerateArray())
                    {
                        choiceEntries.Add(StreamingChatChoiceUpdate.DeserializeStreamingChatChoiceUpdate(choiceElement));
                    }
                }
                if (property.NameEquals("usage"u8))
                {
                    completionsUsage = StreamingChoiceData.DeserializeUsageData(property.Value);
                }
            }

            // If a chunk has no choices, we infer an empty one to aid traversal/expansion
            if (choiceEntries.Count == 0)
            {
                choiceEntries.Add(new StreamingChatChoiceUpdate());
            }

            // We inflate the possible combination of information into one StreamingChatCompletionsUpdate per tool
            // call update per choice, inferring an empty item in cases where the dimension isn't populated.

            List<StreamingChatCompletionsUpdate> results = new();

            foreach (StreamingChatChoiceUpdate choiceData in choiceEntries)
            {
                foreach (StreamingChatResponseToolCallUpdate toolCallUpdate in choiceData.Delta.ToolCalls)
                {
                    results.Add(new(
                        id,
                        model,
                        created,
                        choiceData.Delta.Role,
                        choiceData.Delta.Content,
                        choiceData.FinishReason,
                        toolCallUpdate,
                        completionsUsage
                        ));
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
            internal StreamingDeltaData Delta { get; set; } = StreamingDeltaData.Empty;

            public StreamingChoiceData() { }
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
                    if (choiceProperty.NameEquals("delta"u8))
                    {
                        result.Delta = StreamingDeltaData.DeserializeStreamingDeltaData(choiceProperty.Value);
                        continue;
                    }
                }

                return result;
            }

            internal static CompletionsUsage DeserializeUsageData(JsonElement element, ModelReaderWriterOptions _ = default)
            {
                if (element.ValueKind != JsonValueKind.Object)
                {
                    return null;
                }
                int completionTokens = 0;
                int promptTokens = 0;
                int totalTokens = 0;
                foreach (JsonProperty usageProperty in element.EnumerateObject())
                {
                    if (usageProperty.NameEquals("completion_tokens"u8))
                    {
                        completionTokens = usageProperty.Value.GetInt32();
                    }
                    else if (usageProperty.NameEquals("prompt_tokens"u8))
                    {
                        promptTokens = usageProperty.Value.GetInt32();
                    }
                    else if (usageProperty.NameEquals("total_tokens"u8))
                    {
                        totalTokens = usageProperty.Value.GetInt32();
                    }
                }
                return new CompletionsUsage(
                    completionTokens: completionTokens,
                    promptTokens: promptTokens,
                    totalTokens: totalTokens
                    );
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
}
