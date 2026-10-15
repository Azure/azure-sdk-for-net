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

public class Sample_BrowserAutomotion : ProjectsOpenAITestBase
{
    private AIProjectClient _projectClient;
    private ProjectsAgentVersion _agentVersion;

    #region Snippet:Sample_ParseResponse_BrowserAutomotion
    private static void ParseResponse(StreamingResponseUpdate streamResponse)
    {
        if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
        {
            Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
        }
        else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
        {
            Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
        }
        else if (streamResponse is StreamingResponseErrorUpdate errorUpdate)
        {
            throw new InvalidOperationException($"The stream has failed: {errorUpdate.Message}, error code: {errorUpdate.Code}");
        }
        else if (streamResponse is StreamingResponseFailedUpdate failedUpdate)
        {
            throw new InvalidOperationException($"The response has failed: {failedUpdate.Response.Error?.Message}, error code: {failedUpdate.Response.Error?.Code}");
        }
        else if (streamResponse is StreamingResponseIncompleteUpdate incompleteUpdate)
        {
            throw new InvalidOperationException($"The response is incomplete: {incompleteUpdate.Response.Id}");
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
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var playwrightConnectionId = System.Environment.GetEnvironmentVariable("BROWSER_AUTOMATION_PROJECT_CONNECTION_ID");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var playwrightConnectionId = TestEnvironment.BROWSER_AUTOMATION_PROJECT_CONNECTION_ID;
#endif
        AIProjectClientOptions options = new()
        {
            NetworkTimeout = TimeSpan.FromMinutes(5)
        };
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);

        #endregion
        #region Snippet:Sample_CreateAgent_BrowserAutomotion_Async
        BrowserAutomationTool playwrightTool = new(
            new BrowserAutomationToolOptions(
                new BrowserAutomationToolConnectionOptions(playwrightConnectionId)
            ));

        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are an Agent helping with browser automation tasks.\n" +
            "You can answer questions, provide information, and assist with various tasks\n" +
            "related to web browsing using the Browser Automation tool available to you.",
            Tools = { playwrightTool }
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        _projectClient = projectClient;
        _agentVersion = agentVersion;
        #region Snippet:Sample_CreateResponse_BrowserAutomotion_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
            new AgentReference(agentVersion.Name, agentVersion.Version));
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            StreamingEnabled = true,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("Use the Browser Automation tool to visit https://finance.yahoo.com/quote/MSFT/performance/. " +
                    "Read the YTD return shown on the page for Microsoft (MSFT) and report the percentage with its label. " +
                    "Use the visible page content, not prior knowledge. Do not use the search bar or interact with charts. " +
                    "If the value is unavailable or access is blocked, say so rather than guessing.")
            }
        };
        await foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreamingAsync(responseOptions))
        {
            ParseResponse(update);
        }
        #endregion
    }

    [Test]
    [SyncOnly]
    public void BrowserAutomotion()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var playwrightConnectionId = System.Environment.GetEnvironmentVariable("BROWSER_AUTOMATION_PROJECT_CONNECTION_ID");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var playwrightConnectionId = TestEnvironment.BROWSER_AUTOMATION_PROJECT_CONNECTION_ID;
#endif
        AIProjectClientOptions options = new()
        {
            NetworkTimeout = TimeSpan.FromMinutes(5)
        };
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        #region Snippet:Sample_CreateAgent_BrowserAutomotion_Sync
        BrowserAutomationTool playwrightTool = new(
            new BrowserAutomationToolOptions(
                new BrowserAutomationToolConnectionOptions(playwrightConnectionId)
            ));

        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are an Agent helping with browser automation tasks.\n" +
            "You can answer questions, provide information, and assist with various tasks\n" +
            "related to web browsing using the Browser Automation tool available to you.",
            Tools = { playwrightTool }
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        _projectClient = projectClient;
        _agentVersion = agentVersion;
        #region Snippet:Sample_CreateResponse_BrowserAutomotion_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
            new AgentReference(agentVersion.Name, agentVersion.Version));
        CreateResponseOptions responseOptions = new()
        {
            ToolChoice = ResponseToolChoice.CreateRequiredChoice(),
            StreamingEnabled = true,
            InputItems =
            {
                ResponseItem.CreateUserMessageItem("Use the Browser Automation tool to visit https://finance.yahoo.com/quote/MSFT/performance/. " +
                    "Read the YTD return shown on the page for Microsoft (MSFT) and report the percentage with its label. " +
                    "Use the visible page content, not prior knowledge. Do not use the search bar or interact with charts. " +
                    "If the value is unavailable or access is blocked, say so rather than guessing.")
            }
        };
        foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreaming(responseOptions))
        {
            ParseResponse(update);
        }
        #endregion
    }

    [TearDown]
    public override void Cleanup()
    {
        if (_agentVersion is not null)
        {
            _projectClient.AgentAdministrationClient.DeleteAgentVersion(
                agentName: _agentVersion.Name, agentVersion: _agentVersion.Version);
            _agentVersion = null;
        }
        base.Cleanup();
    }

    public Sample_BrowserAutomotion(bool isAsync) : base(isAsync)
    { }
}
