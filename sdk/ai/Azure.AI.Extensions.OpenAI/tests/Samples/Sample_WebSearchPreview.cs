// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;

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
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_WebSearchPreviewStreaming_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent.",
            Tools = { ResponseTool.CreateWebSearchPreviewTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_StreamResponse_WebSearchPreviewStreaming_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        string annotation = "";
        string text = "";
        CreateResponseOptions options = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("How many medals did the USA win in the 2024 summer olympics?") },
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
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void WebSearchPreviewStreaming()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateAgent_WebSearchPreviewStreaming_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent.",
            Tools = { ResponseTool.CreateWebSearchPreviewTool(userLocation: WebSearchToolLocation.CreateApproximateLocation(country: "GB", city: "London", region: "London")), }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_StreamResponse_WebSearchPreviewStreaming_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        string annotation = "";
        string text = "";
        CreateResponseOptions options = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            InputItems = { ResponseItem.CreateUserMessageItem("How many medals did the USA win in the 2024 summer olympics?") },
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
        projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
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
