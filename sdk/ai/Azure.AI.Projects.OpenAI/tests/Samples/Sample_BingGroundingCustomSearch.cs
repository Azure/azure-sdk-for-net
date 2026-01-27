// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_CustomBingSearch : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task BingCustomSearchAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_CustomBingSearch
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionName = System.Environment.GetEnvironmentVariable("CUSTOM_BING_CONNECTION_NAME");
        var customInstanceName = System.Environment.GetEnvironmentVariable("BING_CUSTOM_SEARCH_INSTANCE_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionName = TestEnvironment.CUSTOM_BING_CONNECTION_NAME;
        var customInstanceName = TestEnvironment.BING_CUSTOM_SEARCH_INSTANCE_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion
        #region Snippet:Sample_CreateAgent_CustomBingSearch_Async
        AIProjectConnection bingConnectionName = await projectClient.Connections.GetConnectionAsync(connectionName: connectionName);
        BingCustomSearchPreviewTool customBingSearchAgentTool = new(new BingCustomSearchToolParameters(
            searchConfigurations: [new BingCustomSearchConfiguration(projectConnectionId: bingConnectionName.Id, instanceName: customInstanceName)]
            )
        );
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent.",
            Tools = { customBingSearchAgentTool, }
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_CustomBingSearch_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseResult response = await responseClient.CreateResponseAsync("How many medals did the USA win in the 2024 summer olympics?");
        #endregion

        #region Snippet:Sample_WaitForResponse_CustomBingSearch
        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");
        #endregion

        #region Snippet:Sample_Cleanup_CustomBingSearch_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void BingCustomSearch()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionName = System.Environment.GetEnvironmentVariable("CUSTOM_BING_CONNECTION_NAME");
        var customInstanceName = System.Environment.GetEnvironmentVariable("BING_CUSTOM_SEARCH_INSTANCE_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionName = TestEnvironment.CUSTOM_BING_CONNECTION_NAME;
        var customInstanceName = TestEnvironment.BING_CUSTOM_SEARCH_INSTANCE_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #region Snippet:Sample_CreateAgent_CustomBingSearch_Sync
        AIProjectConnection bingConnectionName = projectClient.Connections.GetConnection(connectionName: connectionName);
        BingCustomSearchPreviewTool customBingSearchAgentTool = new(new BingCustomSearchToolParameters(
            searchConfigurations: [new BingCustomSearchConfiguration(projectConnectionId: bingConnectionName.Id, instanceName: customInstanceName)]
            )
        );
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful agent.",
            Tools = { customBingSearchAgentTool, }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_CustomBingSearch_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);

        ResponseResult response = responseClient.CreateResponse("How many medals did the USA win in the 2024 summer olympics?");
        #endregion

        Assert.That(response.Status, Is.EqualTo(ResponseStatus.Completed));
        Console.WriteLine($"{response.GetOutputText()}{GetFormattedAnnotation(response)}");

        #region Snippet:Sample_Cleanup_CustomBingSearch_Sync
        projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    #region Snippet:Sample_FormatReference_CustomBingSearch
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

    public Sample_CustomBingSearch(bool isAsync) : base(isAsync)
    { }
}
