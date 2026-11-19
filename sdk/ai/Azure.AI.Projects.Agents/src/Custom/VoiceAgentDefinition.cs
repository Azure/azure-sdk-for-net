// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using OpenAI.Realtime;

namespace Azure.AI.Projects.Agents;

public partial class VoiceAgentDefinition
{
    /// <summary>
    /// The maximum output-token count for one response.
    /// </summary>
    [CodeGenMember("MaxOutputTokens")]
    internal BinaryData InternalMaxOutputTokens { get; set; }

    /// <summary>
    /// The maximum output-token count for one response, -1 means infinity.
    /// </summary>
    public VoiceAgentMaxOutputTokens MaxOutputTokens { get => VoiceAgentMaxOutputTokens.FromBinaryData(InternalMaxOutputTokens); set => InternalMaxOutputTokens = ModelReaderWriter.Write(value, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default); }

    [CodeGenMember("ToolChoice")]
    internal BinaryData InternalToolChoice { get; set; }

    /// <summary>
    /// How the model chooses tools for generated responses. `none` prevents tool calls, `auto` lets the model decide,
    /// `required` requires at least one tool call, and a specific function or MCP tool can be selected with an object.
    /// Defaults to `auto`.
    /// </summary>
    public ToolChoiceOption ToolChoice { get => ToolChoiceOption.FromBinaryData(InternalToolChoice); set => InternalToolChoice = ModelReaderWriter.Write(value, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default); }
}
