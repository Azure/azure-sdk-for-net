// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Agents;

public static partial class ResponseToolExtensions
{
    public static AgentTool AsAgentTool(this ResponseTool responseTool)
    {
        return ModelReaderWriter.Read<AgentTool>(
            ModelReaderWriter.Write(responseTool, ModelSerializationExtensions.WireOptions, OpenAIContext.Default),
            ModelSerializationExtensions.WireOptions,
            AzureAIAgentsContext.Default);
    }
}
