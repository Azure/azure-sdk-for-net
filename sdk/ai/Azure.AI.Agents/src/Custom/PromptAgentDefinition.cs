// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.AI.Agents;

[CodeGenType("PromptAgentDefinition")]
[CodeGenSerialization(nameof(Tools), DeserializationValueHook = nameof(DeserializeToolsValue))]
[CodeGenSerialization(propertyName: nameof(ReasoningOptions), SerializationName = "reasoning", DeserializationValueHook = nameof(DeserializeReasoningValue))]
[CodeGenSerialization(propertyName: nameof(TextOptions), SerializationName = "text", DeserializationValueHook = nameof(DeserializeTextValue))]
public partial class PromptAgentDefinition
{
    /// <summary>
    /// An array of tools the model may call while generating a response. You
    /// can specify which tool to use by setting the `tool_choice` parameter.
    /// </summary>
    [CodeGenMember("Tools")]
    public IList<OpenAI.Responses.ResponseTool> Tools { get; }

    [CodeGenMember("Reasoning")]
    public OpenAI.Responses.ResponseReasoningOptions ReasoningOptions { get; set; }

    [CodeGenMember("Text")]
    public OpenAI.Responses.ResponseTextOptions TextOptions { get; set; }

    private static void DeserializeToolsValue(JsonProperty property, ref IList<OpenAI.Responses.ResponseTool> tools)
    {
        IList<OpenAI.Responses.ResponseTool> replacementTools = new ChangeTrackingList<OpenAI.Responses.ResponseTool>();

        if (property.Value.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement element in property.Value.EnumerateArray())
            {
                OpenAI.Responses.ResponseTool tool = ModelReaderWriter.Read<OpenAI.Responses.ResponseTool>(
                    BinaryData.FromString(element.GetRawText()),
                    ModelReaderWriterOptions.Json,
                    OpenAI.OpenAIContext.Default);
                replacementTools.Add(tool);
            }
        }
        tools = replacementTools;
    }

    private static void DeserializeReasoningValue(JsonProperty property, ref OpenAI.Responses.ResponseReasoningOptions reasoningOptions)
    {
        if (property.Value.ValueKind == JsonValueKind.Object)
        {
            reasoningOptions = ModelReaderWriter.Read<OpenAI.Responses.ResponseReasoningOptions>(
                BinaryData.FromString(property.Value.GetRawText()),
                ModelReaderWriterOptions.Json,
                OpenAI.OpenAIContext.Default);
        }
    }

    private static void DeserializeTextValue(JsonProperty property, ref OpenAI.Responses.ResponseTextOptions textOptions)
    {
        if (property.Value.ValueKind == JsonValueKind.Object)
        {
            textOptions = ModelReaderWriter.Read<OpenAI.Responses.ResponseTextOptions>(
                BinaryData.FromString(property.Value.GetRawText()),
                ModelReaderWriterOptions.Json,
                OpenAI.OpenAIContext.Default);
        }
    }
}
