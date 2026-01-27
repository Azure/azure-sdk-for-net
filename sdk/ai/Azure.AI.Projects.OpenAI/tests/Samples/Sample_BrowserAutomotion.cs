// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests.Samples;

public class Sample_BrowserAutomotion : ProjectsOpenAITestBase
{
    #region Snippet:Sample_ParseResponse_BrowserAutomotion
    private static void ParseResponse(StreamingResponseUpdate streamResponse)
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
            Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
        }
        else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
        {
            throw new InvalidOperationException($"The stream has failed with the error: {errorUpdate.Message}");
        }
    }
    #endregion

    [Test]
    [AsyncOnly]
    public async Task BrowserAutomotionAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateProjectClient_BrowserAutomotion
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var playwrightConnectionName = System.Environment.GetEnvironmentVariable("PLAYWRIGHT_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var playwrightConnectionName = TestEnvironment.PLAYWRIGHT_CONNECTION_NAME;
#endif
        AIProjectClientOptions options = new()
        {
            NetworkTimeout = TimeSpan.FromMinutes(5)
        };
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);

        #endregion
        #region Snippet:Sample_CreateAgent_BrowserAutomotion_Async
        AIProjectConnection playwrightConnection = await projectClient.Connections.GetConnectionAsync(playwrightConnectionName);
        BrowserAutomationPreviewTool playwrightTool = new(
            new BrowserAutomationToolParameters(
                new BrowserAutomationToolConnectionParameters(playwrightConnection.Id)
            ));

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are an Agent helping with browser automation tasks.\n" +
            "You can answer questions, provide information, and assist with various tasks\n" +
            "related to web browsing using the Browser Automation tool available to you.",
            Tools = {playwrightTool}
        };
        AgentVersion agentVersion = await projectClient.Agents.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_BrowserAutomotion_Async
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            StreamingEnabled = true,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("Your goal is to report the percent of Microsoft year-to-date stock price change.\n" +
                    "To do that, go to the website finance.yahoo.com.\n" +
                    "At the top of the page, you will find a search bar.\n" +
                    "Enter the value 'MSFT', to get information about the Microsoft stock price.\n" +
                    "At the top of the resulting page you will see a default chart of Microsoft stock price.\n" +
                    "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it.")
            }
        };
        await foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreamingAsync(responseOptions))
        {
            ParseResponse(update);
        }
        #endregion

        #region Snippet:Sample_Cleanup_BrowserAutomotion_Async
        await projectClient.Agents.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void BrowserAutomotion()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var playwrightConnectionName = System.Environment.GetEnvironmentVariable("PLAYWRIGHT_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var playwrightConnectionName = TestEnvironment.PLAYWRIGHT_CONNECTION_NAME;
#endif
        AIProjectClientOptions options = new()
        {
            NetworkTimeout = TimeSpan.FromMinutes(5)
        };
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        #region Snippet:Sample_CreateAgent_BrowserAutomotion_Sync
        AIProjectConnection playwrightConnection = projectClient.Connections.GetConnection(playwrightConnectionName);
        BrowserAutomationPreviewTool playwrightTool = new(
            new BrowserAutomationToolParameters(
                new BrowserAutomationToolConnectionParameters(playwrightConnection.Id)
            ));

        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are an Agent helping with browser automation tasks.\n" +
            "You can answer questions, provide information, and assist with various tasks\n" +
            "related to web browsing using the Browser Automation tool available to you.",
            Tools = { playwrightTool }
        };
        AgentVersion agentVersion = projectClient.Agents.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_BrowserAutomotion_Sync
        ProjectResponsesClient responseClient = projectClient.OpenAI.GetProjectResponsesClientForAgent(agentVersion.Name);
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            StreamingEnabled = true,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("Your goal is to report the percent of Microsoft year-to-date stock price change.\n" +
                    "To do that, go to the website finance.yahoo.com.\n" +
                    "At the top of the page, you will find a search bar.\n" +
                    "Enter the value 'MSFT', to get information about the Microsoft stock price.\n" +
                    "At the top of the resulting page you will see a default chart of Microsoft stock price.\n" +
                    "Click on 'YTD' at the top of that chart, and report the percent value that shows up just below it.")
            }
        };
        foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreaming(responseOptions))
        {
            ParseResponse(update);
        }
        #endregion

        #region Snippet:Sample_Cleanup_BrowserAutomotion_Sync
        projectClient.Agents.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_BrowserAutomotion(bool isAsync) : base(isAsync)
    { }
}
