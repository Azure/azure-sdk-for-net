// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

#pragma warning disable OPENAI001

namespace Azure.AI.Agents;

[CodeGenType("Tool")]
public abstract partial class AgentTool
{
    public static BingGroundingAgentTool CreateBingGroundingTool(BingGroundingSearchToolParameters parameters) => new BingGroundingAgentTool(parameters);
    public static MicrosoftFabricAgentTool CreateMicrosoftFabricTool(FabricDataAgentToolParameters parameters) => new MicrosoftFabricAgentTool(parameters);
    public static SharepointAgentTool CreateSharepointTool(SharepointGroundingToolParameters parameters) => new SharepointAgentTool(parameters);
    public static AzureAISearchAgentTool CreateAzureAISearchTool(AzureAISearchToolOptions options = null) => new AzureAISearchAgentTool(options ?? new());
    public static OpenApiAgentTool CreateOpenApiTool(OpenApiFunctionDefinition definition) => new OpenApiAgentTool(definition);
    public static BingCustomSearchAgentTool CreateBingCustomSearchTool(BingCustomSearchToolParameters parameters) => new BingCustomSearchAgentTool(parameters);
    public static BrowserAutomationAgentTool CreateBrowserAutomationTool(BrowserAutomationToolParameters parameters) => new BrowserAutomationAgentTool(parameters);
    public static CaptureStructuredOutputsTool CreateStructuredOutputsTool(StructuredOutputDefinition outputs) => new CaptureStructuredOutputsTool(outputs);
    public static ResponseTool CreateA2ATool(Uri baseUri, string agentCardPath = null) => new A2ATool(baseUri)
    {
        AgentCardPath = agentCardPath,
    };

    public static implicit operator ResponseTool(AgentTool agentTool)
    {
        return ModelReaderWriter.Read<ResponseTool>(
            ModelReaderWriter.Write(
                agentTool,
                ModelSerializationExtensions.WireOptions,
                AzureAIAgentsContext.Default),
            ModelSerializationExtensions.WireOptions,
            OpenAIContext.Default);
    }
}
