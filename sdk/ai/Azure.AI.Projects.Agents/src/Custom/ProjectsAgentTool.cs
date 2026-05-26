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
    public static BingGroundingTool CreateBingGroundingTool(BingGroundingSearchToolOptions options) => new BingGroundingTool(options);
    public static MicrosoftFabricPreviewTool CreateMicrosoftFabricTool(FabricDataAgentToolOptions options) => new MicrosoftFabricPreviewTool(options);
    public static SharepointPreviewTool CreateSharepointTool(SharePointGroundingToolOptions options) => new SharepointPreviewTool(options);
    public static AzureAISearchTool CreateAzureAISearchTool(AzureAISearchToolOptions options = null) => new AzureAISearchTool(options ?? new());
    public static OpenAPITool CreateOpenApiTool(OpenApiFunctionDefinition definition) => new OpenAPITool(definition);
    public static BingCustomSearchPreviewTool CreateBingCustomSearchTool(BingCustomSearchToolOptions parameters) => new BingCustomSearchPreviewTool(parameters);
    public static BrowserAutomationPreviewTool CreateBrowserAutomationTool(BrowserAutomationToolOptions parameters) => new BrowserAutomationPreviewTool(parameters);
    public static CaptureStructuredOutputsTool CreateStructuredOutputsTool(StructuredOutputDefinition outputs) => new CaptureStructuredOutputsTool(outputs);
    public static ResponseTool CreateA2ATool(Uri baseUri, string agentCardPath = null) => new A2APreviewTool(baseUri)
    {
        AgentCardPath = agentCardPath,
    };

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
    public static ProjectsAgentTool AsProjectTool(ResponseTool tool)
    {
        Argument.AssertNotNull(tool, nameof(tool));
        // ProjectTool is an alias of ResponseTool in a Azure.AI.Projects namespace, so we can reinterpret ResponseTool.
        BinaryData serializedResponseItem = ModelReaderWriter.Write(tool, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default);
        return ModelReaderWriter.Read<ProjectsAgentTool>(serializedResponseItem, ModelSerializationExtensions.WireOptions, AzureAIProjectsAgentsContext.Default);
    }
}
