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
    /// How the model chooses tools for generated responses. `none` prevents tool calls, `auto` lets the model decide,
    /// `required` requires at least one tool call, and a specific function or MCP tool can be selected with an object.
    /// Defaults to `auto`.
    /// </summary>
    public ToolChoiceOption ToolChoice { get => ToolChoiceOption.FromBinaryData(InternalToolChoice); set => InternalToolChoice = ModelReaderWriter.Write(value, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default); }
}
