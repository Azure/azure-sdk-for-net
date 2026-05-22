// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents;

public static partial class ResponseToolExtensions
{
    public static ProjectsAgentTool AsAgentTool(this ResponseTool responseTool)
    {
        return ModelReaderWriter.Read<ProjectsAgentTool>(
            ModelReaderWriter.Write(responseTool, ModelSerializationExtensions.WireOptions, OpenAIContext.Default),
            ModelSerializationExtensions.WireOptions,
            AzureAIProjectsAgentsContext.Default);
    }
}
