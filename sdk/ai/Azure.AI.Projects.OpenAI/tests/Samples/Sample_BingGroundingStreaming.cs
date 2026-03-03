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

public class Sample_BingGroundingStreaming : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task BingGroundingStreamingAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_BingGroundingStreaming
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionName = System.Environment.GetEnvironmentVariable("BING_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionName = TestEnvironment.BING_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_BingGroundingStreaming_Async
        AIProjectConnection bingConnectionName = projectClient.Connections.GetConnection(connectionName: connectionName);
        BingGroundingTool bingGroundingAgentTool = new(new BingGroundingSearchToolOptions(
            searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: bingConnectionName.Id)]
            )
        );
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent.",
            Tools = { bingGroundingAgentTool }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_StreamResponse_BingGroundingStreaming_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        string annotation = "";
        string text = "";
        await foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreamingAsync("How does wikipedia explain Euler's Identity?"))
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

        #region Snippet:Sample_Cleanup_BingGroundingStreaming_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void BingGroundingStreamingSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionName = System.Environment.GetEnvironmentVariable("BING_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionName = TestEnvironment.BING_CONNECTION_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_BingGroundingStreaming_Sync
        AIProjectConnection bingConnectionName = projectClient.Connections.GetConnection(connectionName: connectionName);
        BingGroundingTool bingGroundingAgentTool = new(new BingGroundingSearchToolOptions(
            searchConfigurations: [new BingGroundingSearchConfiguration(projectConnectionId: bingConnectionName.Id)]
            )
        );
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent.",
            Tools = { bingGroundingAgentTool }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_StreamResponse_BingGroundingStreaming_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        string annotation = "";
        string text = "";
        foreach (StreamingResponseUpdate streamResponse in responseClient.CreateResponseStreaming("How does wikipedia explain Euler's Identity?"))
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

        #region Snippet:Sample_Cleanup_BingGroundingStreaming_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    #region Snippet:Sample_FormatReference_BingGroundingStreaming
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

    public Sample_BingGroundingStreaming(bool isAsync) : base(isAsync)
    { }
}
