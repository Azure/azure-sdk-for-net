// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;

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
}
