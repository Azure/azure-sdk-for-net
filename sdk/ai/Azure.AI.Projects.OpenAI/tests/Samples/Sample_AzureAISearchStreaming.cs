// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_AzureAISearchStreaming : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task AzureAISearchAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_AzureAISearchStreaming
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var aiSearchConnectionName = System.Environment.GetEnvironmentVariable("AI_SEARCH_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var aiSearchConnectionName = TestEnvironment.AI_SEARCH_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #endregion
        #region Snippet:Sample_CreateAgent_AzureAISearchStreaming_Async
        AzureAISearchToolIndex index = new()
        {
            ProjectConnectionId = aiSearchConnectionName,
            IndexName = "sample_index",
            TopK = 5,
            Filter = "category eq 'sleeping bag'",
            QueryType = AzureAISearchQueryType.Simple
        };
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant. You must always provide citations for answers using the tool and render them as: `\u3010message_idx:search_idx\u2020source\u3011`.",
            Tools = { new AzureAISearchTool(new AzureAISearchToolOptions(indexes: [index])) }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_StreamResponse_AzureAISearchStreaming_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        string annotation = "";
        string text = "";
        await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync("What is the temperature rating of the cozynights sleeping bag?"))
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

        #region Snippet:Sample_Cleanup_AzureAISearchStreaming_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void AzureAISearchSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var aiSearchConnectionName = System.Environment.GetEnvironmentVariable("AI_SEARCH_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var aiSearchConnectionName = TestEnvironment.AI_SEARCH_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_AzureAISearchStreaming_Sync
        AzureAISearchToolIndex index = new()
        {
            ProjectConnectionId = aiSearchConnectionName,
            IndexName = "sample_index",
            TopK = 5,
            Filter = "category eq 'sleeping bag'",
            QueryType = AzureAISearchQueryType.Simple
        };
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant. You must always provide citations for answers using the tool and render them as: `\u3010message_idx:search_idx\u2020source\u3011`.",
            Tools = { new AzureAISearchTool(new AzureAISearchToolOptions(indexes: [index])) }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_StreamResponse_AzureAISearchStreaming_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        string annotation = "";
        string text = "";
        foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreaming("What is the temperature rating of the cozynights sleeping bag?"))
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

        #region Snippet:Sample_Cleanup_AzureAISearchStreaming_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    #region Snippet:Sample_FormatReference_AzureAISearchStreaming
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

    public Sample_AzureAISearchStreaming(bool isAsync) : base(isAsync)
    { }
}
