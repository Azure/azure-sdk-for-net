// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using OpenAI;
using OpenAI.Responses;

#pragma warning disable OPENAI001

namespace Azure.AI.Projects.Agents;

[CodeGenType("Tool")]
public abstract partial class ProjectsAgentTool
{
    /// <summary> Creates a Bing grounding tool with the supplied options. </summary>
    /// <param name="options">Configuration options for the Bing grounding tool.</param>
    public static BingGroundingTool CreateBingGroundingTool(BingGroundingSearchToolOptions options) => new BingGroundingTool(options);
    /// <summary> Creates a Microsoft Fabric data agent tool with the supplied options. </summary>
    /// <param name="options">Configuration options for the Fabric data agent tool.</param>
    public static MicrosoftFabricPreviewTool CreateMicrosoftFabricTool(FabricDataAgentToolOptions options) => new MicrosoftFabricPreviewTool(options);
    /// <summary> Creates a SharePoint grounding tool with the supplied options. </summary>
    /// <param name="options">Configuration options for the SharePoint grounding tool.</param>
    public static SharepointPreviewTool CreateSharepointTool(SharePointGroundingToolOptions options) => new SharepointPreviewTool(options);
    /// <summary> Creates an Azure AI Search tool with the supplied options. </summary>
    /// <param name="options">Optional configuration options for the Azure AI Search tool.</param>
    public static AzureAISearchTool CreateAzureAISearchTool(AzureAISearchToolOptions options = null) => new AzureAISearchTool(options ?? new());
    /// <summary> Creates an OpenAPI tool from the supplied function definition. </summary>
    /// <param name="definition">The OpenAPI function definition.</param>
    public static OpenAPITool CreateOpenApiTool(OpenApiFunctionDefinition definition) => new OpenAPITool(definition);
    /// <summary> Creates a Bing custom search tool with the supplied options. </summary>
    /// <param name="parameters">Configuration options for the Bing custom search tool.</param>
    public static BingCustomSearchPreviewTool CreateBingCustomSearchTool(BingCustomSearchToolOptions parameters) => new BingCustomSearchPreviewTool(parameters);
    /// <summary> Creates a browser-automation tool with the supplied options. </summary>
    /// <param name="parameters">Configuration options for the browser-automation tool.</param>
    public static BrowserAutomationPreviewTool CreateBrowserAutomationTool(BrowserAutomationToolOptions parameters) => new BrowserAutomationPreviewTool(parameters);
    /// <summary> Creates a tool that captures structured outputs from the agent. </summary>
    /// <param name="outputs">The structured output definition the agent should produce.</param>
    public static CaptureStructuredOutputsTool CreateStructuredOutputsTool(StructuredOutputDefinition outputs) => new CaptureStructuredOutputsTool(outputs);
    /// <summary>
    /// Creates a new tool that lets the agent communicate with another agent over the
    /// Agent-to-Agent (A2A) protocol.
    /// </summary>
    /// <param name="baseUri">The base URI of the remote agent endpoint.</param>
    /// <param name="agentCardPath">Optional path to the remote agent's agent card.</param>
    public static ResponseTool CreateA2ATool(Uri baseUri, string agentCardPath = null) => new A2APreviewTool(baseUri)
    {
        AgentCardPath = agentCardPath,
    };

    /// <summary>
    /// Implicitly converts a <see cref="ProjectsAgentTool"/> into the underlying
    /// <see cref="ResponseTool"/> representation by round-tripping through the wire format.
    /// </summary>
    /// <param name="agentTool">The agent tool to convert.</param>
    public static implicit operator ResponseTool(ProjectsAgentTool agentTool)
    {
        return ModelReaderWriter.Read<ResponseTool>(
            ModelReaderWriter.Write(
                agentTool,
                ModelSerializationExtensions.WireOptions,
                AzureAIProjectsAgentsContext.Default),
            ModelSerializationExtensions.WireOptions,
            OpenAIContext.Default);
    }

    /// <summary>
    /// Reinterprets a tool from the OpenAI <c>ResponseTool</c> hierarchy as a
    /// <see cref="ProjectsAgentTool"/> by round-tripping through the wire format.
    /// </summary>
    /// <typeparam name="T">The source tool type.</typeparam>
    /// <param name="tool">The source tool instance.</param>
    public static ProjectsAgentTool AsProjectTool<T>(T tool)
    {
        Argument.AssertNotNull(tool, nameof(tool));
        // ProjectTool is an alias of ResponseTool in a Azure.AI.Projects namespace, so we can reinterpret ResponseTool.
        BinaryData serializedResponseItem = ModelReaderWriter.Write(tool, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default);
        return ModelReaderWriter.Read<ProjectsAgentTool>(serializedResponseItem, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default);
    }
}
