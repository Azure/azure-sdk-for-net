// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_AzureAISearch : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task AzureAISearchAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_AzureAISearch
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
        #region Snippet:Sample_CreateAgent_AzureAISearch_Async
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
        #region Snippet:Sample_CreateResponse_AzureAISearch_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseResult response = await responseClient.CreateResponseAsync("What is the temperature rating of the cozynights sleeping bag?");
        #endregion

        #region Snippet:Sample_WaitForResponse_AzureAISearch
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");
        #endregion

        #region Snippet:Sample_Cleanup_AzureAISearch_Async
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

        #region Snippet:Sample_CreateAgent_AzureAISearch_Sync
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
        #region Snippet:Sample_CreateResponse_AzureAISearch_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseResult response = responseClient.CreateResponse("What is the temperature rating of the cozynights sleeping bag?");
        #endregion

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");

        #region Snippet:Sample_Cleanup_AzureAISearch_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    #region Snippet:Sample_FormatReference_AzureAISearch
    private static string GetFormattedAnnotation(ResponseResult response)
    {
        foreach (ResponseItem item in response.OutputItems)
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
        }
        return "";
    }
    #endregion

    public Sample_AzureAISearch(bool isAsync) : base(isAsync)
    { }
}
