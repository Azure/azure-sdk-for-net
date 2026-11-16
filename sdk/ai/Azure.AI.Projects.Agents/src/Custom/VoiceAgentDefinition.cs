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
    /// Maximum output tokens per response. Use <see cref="VoiceAgentMaxOutputTokens.Infinity"/> for no limit.
    /// </summary>
    public VoiceAgentMaxOutputTokens MaxOutputTokens { get => VoiceAgentMaxOutputTokens.FromBinaryData(InternalMaxOutputTokens); set => InternalMaxOutputTokens = ModelReaderWriter.Write(value, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default); }

    [CodeGenMember("ToolChoice")]
    internal BinaryData InternalToolChoice { get; set; }

    /// <summary>
    /// Controls tool selection: <c>auto</c> lets the model decide (the default), <c>none</c> disables tools,
    /// and <c>required</c> requires a tool call. Use a tool-choice object to select a specific function or MCP tool.
    /// </summary>
    public ToolChoiceOption ToolChoice { get => ToolChoiceOption.FromBinaryData(InternalToolChoice); set => InternalToolChoice = ModelReaderWriter.Write(value, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default); }
}
