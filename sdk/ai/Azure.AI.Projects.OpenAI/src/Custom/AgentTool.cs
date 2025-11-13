// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

#pragma warning disable OPENAI001

namespace Azure.AI.Projects.OpenAI;

[CodeGenType("Tool")]
public abstract partial class AgentTool
{
    public static BingGroundingAgentTool CreateBingGroundingTool(BingGroundingSearchToolOptions options) => new BingGroundingAgentTool(options);
    public static MicrosoftFabricAgentTool CreateMicrosoftFabricTool(FabricDataAgentToolOptions options) => new MicrosoftFabricAgentTool(options);
    public static SharepointAgentTool CreateSharepointTool(SharePointGroundingToolOptions options) => new SharepointAgentTool(options);
    public static AzureAISearchAgentTool CreateAzureAISearchTool(AzureAISearchToolOptions options = null) => new AzureAISearchAgentTool(options ?? new());
    public static OpenAPIAgentTool CreateOpenApiTool(OpenAPIFunctionDefinition definition) => new OpenAPIAgentTool(definition);
    public static BingCustomSearchAgentTool CreateBingCustomSearchTool(BingCustomSearchToolParameters parameters) => new BingCustomSearchAgentTool(parameters);
    public static BrowserAutomationAgentTool CreateBrowserAutomationTool(BrowserAutomationToolParameters parameters) => new BrowserAutomationAgentTool(parameters);
    public static CaptureStructuredOutputsTool CreateStructuredOutputsTool(StructuredOutputDefinition outputs) => new CaptureStructuredOutputsTool(outputs);
    public static ResponseTool CreateA2ATool(Uri baseUri, string agentCardPath = null) => new A2ATool(baseUri)
    {
        AgentCardPath = agentCardPath,
    };

    public static LocalShellAgentTool CreateLocalShellTool() => new LocalShellAgentTool();

    public static implicit operator ResponseTool(AgentTool agentTool)
    {
        return ModelReaderWriter.Read<ResponseTool>(
            ModelReaderWriter.Write(
                agentTool,
                ModelSerializationExtensions.WireOptions,
                AzureAIProjectsOpenAIContext.Default),
            ModelSerializationExtensions.WireOptions,
            OpenAIContext.Default);
    }
}
