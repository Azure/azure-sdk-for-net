// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

namespace Azure.AI.Projects.Agents;

public partial class VoiceAgentLlmGeneratedGreetingConfig
{
    [CodeGenMember("ToolChoice")]
    internal BinaryData InternalToolChoice { get; set; }

    /// <summary>
    /// Controls tool selection: <c>auto</c> lets the model decide (the default), <c>none</c> disables tools,
    /// and <c>required</c> requires a tool call. Use a tool-choice object to select a specific function or MCP tool.
    /// </summary>
    public ToolChoiceOption ToolChoice { get => ToolChoiceOption.FromBinaryData(InternalToolChoice); set => InternalToolChoice = ModelReaderWriter.Write(value, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default); }
}
