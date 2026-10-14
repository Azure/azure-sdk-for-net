// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json.Nodes;
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
    #region Snippet:Sample_ParseResponse_BrowserAutomotion
    internal static bool ParseResponse(StreamingResponseUpdate streamResponse)
    {
        if (streamResponse is StreamingResponseCreatedUpdate createUpdate)
        {
            Console.WriteLine($"Stream response created with ID: {createUpdate.Response.Id}");
        }
        else if (streamResponse is StreamingResponseOutputTextDoneUpdate textDoneUpdate)
        {
            Console.WriteLine($"Response done with full message: {textDoneUpdate.Text}");
        }
        else if (streamResponse is StreamingResponseOutputItemDoneUpdate itemDoneUpdate)
        {
            // GA browser actions use remote function items, which are not strongly typed by this SDK.
            string kind = itemDoneUpdate.Item.Kind.ToString();
            if (kind == "remote_function_call" || kind == "remote_function_call_output")
            {
                JsonNode item = JsonNode.Parse(ModelReaderWriter.Write(itemDoneUpdate.Item).ToString());
                string callId = item["call_id"].GetValue<string>();
                if (kind == "remote_function_call")
                {
                    JsonObject arguments = JsonNode.Parse(item["arguments"].GetValue<string>()).AsObject();
                    arguments.Remove("browserSessionId");
                    Console.WriteLine($"Browser action: {item["name"].GetValue<string>()}, call ID: {callId}, arguments: {arguments.ToJsonString()}");
                }
                else
                {
                    Console.WriteLine($"Browser action completed: {callId}");
                }
            }
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
        return streamResponse is StreamingResponseCompletedUpdate;
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
        var playwrightConnectionName = System.Environment.GetEnvironmentVariable("PLAYWRIGHT_MCP_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var playwrightConnectionName = TestEnvironment.PLAYWRIGHT_MCP_CONNECTION_NAME;
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
                new BrowserAutomationToolConnectionOptions(playwrightConnectionName)
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
        #region Snippet:Sample_CreateResponse_BrowserAutomotion_Async
        try
        {
            ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
                new AgentReference(agentVersion.Name, agentVersion.Version));
            CreateResponseOptions responseOptions = new()
            {
                StreamingEnabled = true,
                InputItems =
                {
                    ResponseItem.CreateUserMessageItem("Use the Browser Automation tool to visit https://example.com. " +
                        "Read the page and report its title and the visible description paragraph. " +
                        "Base your answer on the browser results, not on prior knowledge.")
                }
            };
            bool responseCompleted = false;
            await foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreamingAsync(responseOptions))
            {
                responseCompleted |= ParseResponse(update);
            }
            if (!responseCompleted)
            {
                throw new InvalidOperationException("The stream ended before the response completed.");
            }
        }
        #endregion

        #region Snippet:Sample_Cleanup_BrowserAutomotion_Async
        finally
        {
            await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
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
        var playwrightConnectionName = System.Environment.GetEnvironmentVariable("PLAYWRIGHT_MCP_CONNECTION_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var playwrightConnectionName = TestEnvironment.PLAYWRIGHT_MCP_CONNECTION_NAME;
#endif
        AIProjectClientOptions options = new()
        {
            NetworkTimeout = TimeSpan.FromMinutes(5)
        };
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        #region Snippet:Sample_CreateAgent_BrowserAutomotion_Sync
        BrowserAutomationTool playwrightTool = new(
            new BrowserAutomationToolOptions(
                new BrowserAutomationToolConnectionOptions(playwrightConnectionName)
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
        #region Snippet:Sample_CreateResponse_BrowserAutomotion_Sync
        try
        {
            ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(
                new AgentReference(agentVersion.Name, agentVersion.Version));
            CreateResponseOptions responseOptions = new()
            {
                StreamingEnabled = true,
                InputItems =
                {
                    ResponseItem.CreateUserMessageItem("Use the Browser Automation tool to visit https://example.com. " +
                        "Read the page and report its title and the visible description paragraph. " +
                        "Base your answer on the browser results, not on prior knowledge.")
                }
            };
            bool responseCompleted = false;
            foreach (StreamingResponseUpdate update in responseClient.CreateResponseStreaming(responseOptions))
            {
                responseCompleted |= ParseResponse(update);
            }
            if (!responseCompleted)
            {
                throw new InvalidOperationException("The stream ended before the response completed.");
            }
        }
        #endregion

        #region Snippet:Sample_Cleanup_BrowserAutomotion_Sync
        finally
        {
            projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        }
        #endregion
    }

    public Sample_BrowserAutomotion(bool isAsync) : base(isAsync)
    { }
}
