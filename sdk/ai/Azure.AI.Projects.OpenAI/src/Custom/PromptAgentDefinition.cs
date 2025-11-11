// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI;

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
    public IList<global::OpenAI.Responses.ResponseTool> Tools { get; }

    [CodeGenMember("Reasoning")]
    public global::OpenAI.Responses.ResponseReasoningOptions ReasoningOptions { get; set; }

    [CodeGenMember("Text")]
    public global::OpenAI.Responses.ResponseTextOptions TextOptions { get; set; }

    private static void DeserializeToolsValue(JsonProperty property, ref IList<ResponseTool> tools)
    {
        IList<ResponseTool> replacementTools = new ChangeTrackingList<ResponseTool>();

        if (property.Value.ValueKind == JsonValueKind.Array)
        {
            foreach (JsonElement element in property.Value.EnumerateArray())
            {
                ResponseTool tool = ModelReaderWriter.Read<ResponseTool>(
                    BinaryData.FromString(element.GetRawText()),
                    ModelReaderWriterOptions.Json,
                    OpenAIContext.Default);
                replacementTools.Add(tool);
            }
        }
        tools = replacementTools;
    }

    /// <summary> Initializes a new instance of <see cref="PromptAgentDefinition"/>. </summary>
    /// <param name="model"> The model deployment to use for this agent. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="model"/> is null. </exception>
    public PromptAgentDefinition(string model) : base(AgentKind.Prompt)
    {
        Argument.AssertNotNull(model, nameof(model));

        Model = model;
        Tools = new ChangeTrackingList<ResponseTool>();
        StructuredInputs = new ChangeTrackingDictionary<string, StructuredInputDefinition>();
    }

    /// <summary> Initializes a new instance of <see cref="PromptAgentDefinition"/>. </summary>
    /// <param name="kind"></param>
    /// <param name="contentFilterConfiguration"> Configuration for Responsible AI (RAI) content filtering and safety features. </param>
    /// <param name="additionalBinaryDataProperties"> Keeps track of any properties unknown to the library. </param>
    /// <param name="model"> The model deployment to use for this agent. </param>
    /// <param name="instructions"> A system (or developer) message inserted into the model's context. </param>
    /// <param name="temperature">
    /// What sampling temperature to use, between 0 and 2. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic.
    /// We generally recommend altering this or `top_p` but not both.
    /// </param>
    /// <param name="topP">
    /// An alternative to sampling with temperature, called nucleus sampling,
    /// where the model considers the results of the tokens with top_p probability
    /// mass. So 0.1 means only the tokens comprising the top 10% probability mass
    /// are considered.
    ///
    /// We generally recommend altering this or `temperature` but not both.
    /// </param>
    /// <param name="reasoningOptions"></param>
    /// <param name="tools">
    /// An array of tools the model may call while generating a response. You
    /// can specify which tool to use by setting the `tool_choice` parameter.
    /// </param>
    /// <param name="textOptions"> Configuration options for a text response from the model. Can be plain text or structured JSON data. </param>
    /// <param name="structuredInputs"> Set of structured inputs that can participate in prompt template substitution or tool argument bindings. </param>
    internal PromptAgentDefinition(AgentKind kind, ContentFilterConfiguration contentFilterConfiguration, IDictionary<string, BinaryData> additionalBinaryDataProperties, string model, string instructions, float? temperature, float? topP, ResponseReasoningOptions reasoningOptions, IList<ResponseTool> tools, ResponseTextOptions textOptions, IDictionary<string, StructuredInputDefinition> structuredInputs) : base(kind, contentFilterConfiguration, additionalBinaryDataProperties)
    {
        Model = model;
        Instructions = instructions;
        Temperature = temperature;
        TopP = topP;
        ReasoningOptions = reasoningOptions;
        Tools = tools;
        TextOptions = textOptions;
        StructuredInputs = structuredInputs;
    }

    private static void DeserializeReasoningValue(JsonProperty property, ref ResponseReasoningOptions reasoningOptions)
    {
        if (property.Value.ValueKind == JsonValueKind.Object)
        {
            reasoningOptions = ModelReaderWriter.Read<ResponseReasoningOptions>(
                BinaryData.FromString(property.Value.GetRawText()),
                ModelReaderWriterOptions.Json,
                OpenAIContext.Default);
        }
    }

    private static void DeserializeTextValue(JsonProperty property, ref ResponseTextOptions textOptions)
    {
        if (property.Value.ValueKind == JsonValueKind.Object)
        {
            textOptions = ModelReaderWriter.Read<ResponseTextOptions>(
                BinaryData.FromString(property.Value.GetRawText()),
                ModelReaderWriterOptions.Json,
                OpenAIContext.Default);
        }
    }
}
