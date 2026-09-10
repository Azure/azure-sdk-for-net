// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;

public class Sample_WebSearchPreviewStreaming : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task WebSearchPreviewStreamingAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_WebSearchPreviewStreaming
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_WebSearchPreviewStreaming_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that can search the web.",
            Tools = { ResponseTool.CreateWebSearchPreviewTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_StreamResponse_WebSearchPreviewStreaming_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        string annotation = "";
        string text = "";
        CreateResponseOptions options = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("Show me the latest London Underground service updates") },
        };
        await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync(options))
        {
            if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
            {
                Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
            }
            else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
            {
                Console.WriteLine($"Delta: {textDelta.Delta}");
            }
            else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
            {
                text = textDoneUpdate.Text;
            }
            else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
            {
                if (annotation.Length == 0)
                {
                    annotation = GetFormattedAnnotation(itemDoneUpdate.Item);
                }
            }
            else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
            {
                throw new InvalidOperationException($"The stream has failed: {errorUpdate.Message}");
            }
        }
        Console.WriteLine($"{text}{annotation}");
        #endregion

        #region Snippet:Sample_Cleanup_WebSearchPreviewStreaming_Async
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void WebSearchPreviewStreaming()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClientOptions opts = new();
        //opts.AddPolicy(GetDumpPolicy(), System.ClientModel.Primitives.PipelinePosition.PerCall);

        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: opts);
        #region Snippet:Sample_CreateAgent_WebSearchPreviewStreaming_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant that can search the web.",
            Tools = { ResponseTool.CreateWebSearchPreviewTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_StreamResponse_WebSearchPreviewStreaming_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        string annotation = "";
        string text = "";
        CreateResponseOptions options = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("Show me the latest London Underground service updates") },
        };

        foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreaming(options))
        {
            if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
            {
                Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
            }
            else if (streamResponse is StreamingResponseOutputTextDeltaUpdate textDelta)
            {
                Console.WriteLine($"Delta: {textDelta.Delta}");
            }
            else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
            {
                text = textDoneUpdate.Text;
            }
            else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
            {
                if (annotation.Length == 0)
                {
                    annotation = GetFormattedAnnotation(itemDoneUpdate.Item);
                }
            }
            else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
            {
                throw new InvalidOperationException($"The stream has failed: {errorUpdate.Message}");
            }
        }
        Console.WriteLine($"{text}{annotation}");
        #endregion

        #region Snippet:Sample_Cleanup_WebSearchPreviewStreaming_Sync
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    #region Snippet:Sample_FormatReference_WebSearchPreviewStreaming
    private static string GetFormattedAnnotation(ResponseItem item)
    {
        if (item is MessageResponseItem messageItem)
        {
            foreach (ResponseContentPart content in messageItem.Content)
            {
                foreach (ResponseMessageAnnotation annotation in content.OutputTextAnnotations)
                {
                    if (annotation is UriCitationMessageAnnotation uriAnnotation)
                    {
                        return $" [{uriAnnotation.Title}]({uriAnnotation.Uri})";
                    }
                }
            }
        }
        return "";
    }
    #endregion

    public Sample_WebSearchPreviewStreaming(bool isAsync) : base(isAsync)
    { }
}
