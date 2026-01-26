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
    public static BingGroundingTool CreateBingGroundingTool(BingGroundingSearchToolOptions options) => new BingGroundingTool(options);
    public static MicrosoftFabricPreviewTool CreateMicrosoftFabricTool(FabricDataAgentToolOptions options) => new MicrosoftFabricPreviewTool(options);
    public static SharepointPreviewTool CreateSharepointTool(SharePointGroundingToolOptions options) => new SharepointPreviewTool(options);
    public static AzureAISearchTool CreateAzureAISearchTool(AzureAISearchToolOptions options = null) => new AzureAISearchTool(options ?? new());
    public static OpenAPITool CreateOpenApiTool(OpenAPIFunctionDefinition definition) => new OpenAPITool(definition);
    public static BingCustomSearchPreviewTool CreateBingCustomSearchTool(BingCustomSearchToolParameters parameters) => new BingCustomSearchPreviewTool(parameters);
    public static BrowserAutomationPreviewTool CreateBrowserAutomationTool(BrowserAutomationToolParameters parameters) => new BrowserAutomationPreviewTool(parameters);
    public static CaptureStructuredOutputsTool CreateStructuredOutputsTool(StructuredOutputDefinition outputs) => new CaptureStructuredOutputsTool(outputs);
    public static ResponseTool CreateA2ATool(Uri baseUri, string agentCardPath = null) => new A2APreviewTool(baseUri)
    {
        AgentCardPath = agentCardPath,
    };

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
