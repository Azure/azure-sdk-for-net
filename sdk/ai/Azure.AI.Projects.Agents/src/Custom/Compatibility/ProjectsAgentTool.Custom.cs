// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using Azure.AI.Extensions.OpenAI;
using OpenAI;
using OpenAI.Responses;

#pragma warning disable OPENAI001

namespace Azure.AI.Projects.Agents;

public abstract partial class ProjectsAgentTool
{
    /// <summary> Creates a legacy Bing grounding tool. </summary>
    public static BingGroundingTool CreateBingGroundingTool(BingGroundingSearchToolOptions options) => new BingGroundingTool(options);
    /// <summary> Creates a legacy Microsoft Fabric tool. </summary>
    public static MicrosoftFabricPreviewTool CreateMicrosoftFabricTool(FabricDataAgentToolOptions options) => new MicrosoftFabricPreviewTool(options);
    /// <summary> Creates a legacy SharePoint tool. </summary>
    public static SharepointPreviewTool CreateSharepointTool(SharePointGroundingToolOptions options) => new SharepointPreviewTool(options);
    /// <summary> Creates a legacy Azure AI Search tool. </summary>
    public static AzureAISearchTool CreateAzureAISearchTool(AzureAISearchToolOptions options = null) => new AzureAISearchTool(options ?? new());
    /// <summary> Creates a legacy OpenAPI tool. </summary>
    public static OpenAPITool CreateOpenApiTool(OpenApiFunctionDefinition definition) => new OpenAPITool(definition);
    /// <summary> Creates a legacy Bing custom search tool. </summary>
    public static BingCustomSearchPreviewTool CreateBingCustomSearchTool(BingCustomSearchToolOptions parameters) => new BingCustomSearchPreviewTool(parameters);
    /// <summary> Creates a legacy browser automation tool. </summary>
    public static BrowserAutomationPreviewTool CreateBrowserAutomationTool(BrowserAutomationToolOptions parameters) => new BrowserAutomationPreviewTool(parameters);
    /// <summary> Creates a legacy structured outputs tool. </summary>
    public static CaptureStructuredOutputsTool CreateStructuredOutputsTool(StructuredOutputDefinition outputs) => new CaptureStructuredOutputsTool(outputs);
    /// <summary> Creates an agent-to-agent response tool from the legacy definition. </summary>
    public static ResponseTool CreateA2ATool(Uri baseUri, string agentCardPath = null) => new A2APreviewTool(baseUri)
    {
        AgentCardPath = agentCardPath,
    };

    /// <summary> Converts a legacy tool to a shared response tool. </summary>
    public static implicit operator ResponseTool(ProjectsAgentTool agentTool)
    {
        Argument.AssertNotNull(agentTool, nameof(agentTool));
        return ModelReaderWriter.Read<ResponseTool>(
            ModelReaderWriter.Write(
                agentTool,
                ModelReaderWriterOptions.Json,
                AzureAIProjectsAgentsContext.Default),
            ModelReaderWriterOptions.Json,
            AzureAIExtensionsOpenAIContext.Default);
    }
}
