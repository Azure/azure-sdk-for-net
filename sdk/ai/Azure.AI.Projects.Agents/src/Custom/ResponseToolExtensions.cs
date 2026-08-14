// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;

/// <summary>
/// Extension methods that convert OpenAI <see cref="ResponseTool"/> instances into the
/// equivalent <see cref="ProjectsAgentTool"/> representation.
/// </summary>
public static partial class ResponseToolExtensions
{
    /// <summary>
    /// Reinterprets an OpenAI <see cref="ResponseTool"/> as a <see cref="ProjectsAgentTool"/>
    /// by round-tripping through the wire format.
    /// </summary>
    /// <param name="responseTool">The OpenAI response tool to convert.</param>
    public static ProjectsAgentTool AsAgentTool(this ResponseTool responseTool)
    {
        return ModelReaderWriter.Read<ProjectsAgentTool>(
            ModelReaderWriter.Write(responseTool, ModelSerializationExtensions.WireOptions, OpenAIContext.Default),
            ModelSerializationExtensions.WireOptions,
            AzureAIProjectsAgentsContext.Default);
    }
}
