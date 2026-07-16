// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.AI.Projects.Agents;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Extensions.OpenAI.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_ToolSearch : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task ToolSearchAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_ToolSearch
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        DefaultAzureCredential credential = new();
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: credential);
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        #endregion
        try
        {
            toolboxClient.Delete(name: "myToolbox");
        }
        catch { }
        #region Snippet:Sample_CreateToolbox_ToolSearch_Async
        MCPToolboxTool mcp = new(serverLabel: "api-specs")
        {
            ServerUri = new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            ToolCallApprovalPolicy = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        };
        CodeInterpreterToolboxTool codeInterpreter = new()
        {
            Container = new CodeInterpreterToolContainer(
                CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
            )
        };
        ToolboxSearchPreviewToolboxTool searchTool = new()
        {
            Name = "ToolBoxSearch",
            Description = "Search for the toolboxes"
        };
        ToolboxVersion toolBox = await toolboxClient.CreateVersionAsync(
            name: "myToolbox",
            tools: [mcp, codeInterpreter, searchTool],
            description: "Example toolbox created by the azure-ai-projects sample."
        );
        #endregion
        #region Snippet:Sample_CreateAgent_ToolSearch_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = {
                ResponseTool.CreateMcpTool(
                    serverLabel: "search-tool",
                    serverUri: new Uri($"{projectEndpoint}/toolboxes/{toolBox.Name}/versions/{toolBox.Version}/mcp?api-version=v1"),
                    authorizationToken: credential.GetToken(new(scopes: ["https://ai.azure.com/.default"])).Token,
                    headers: new Dictionary<string, string>() {
                        { "Foundry-Features", "Toolboxes=V1Preview" }
                    }
                ),
            }
        };
        ProjectsAgentVersion agentVersion = await projectClient.AgentAdministrationClient.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_ToolSearch_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        CreateResponseOptions nextResponseOptions = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem("What tools are available?") }
        };
        ResponseResult latestResponse = null;

        while (nextResponseOptions is not null)
        {
            latestResponse = await responseClient.CreateResponseAsync(nextResponseOptions);
            nextResponseOptions = null;

            foreach (ResponseItem responseItem in latestResponse.OutputItems)
            {
                if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
                {
                    nextResponseOptions = new CreateResponseOptions()
                    {
                        PreviousResponseId = latestResponse.Id,
                    };
                    if (string.Equals(mcpToolCall.ServerLabel, "search-tool"))
                    {
                        Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                        // Automatically approve the MCP request to allow the agent to proceed
                        // In production, you might want to implement more sophisticated approval logic
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
                    }
                    else
                    {
                        Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
                    }
                }
                else if (responseItem is McpToolDefinitionListItem listItem)
                {
                    Console.WriteLine("Found tools:");
                    foreach (McpToolDefinition tool in listItem.ToolDefinitions)
                    {
                        Console.WriteLine($"    {tool.Name}");
                    }
                }
            }
        }
        Console.WriteLine(latestResponse.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_ToolSearch_Async
        await toolboxClient.DeleteAsync(name: toolBox.Name);
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ToolSearchSync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        DefaultAzureCredential credential = new();
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: credential);
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        try
        {
            toolboxClient.Delete(name: "myToolbox");
        }
        catch { }
        #region Snippet:Sample_CreateToolbox_ToolSearch_Sync
        MCPToolboxTool mcp = new(serverLabel: "api-specs")
        {
            ServerUri = new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            ToolCallApprovalPolicy = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        };
        CodeInterpreterToolboxTool codeInterpreter = new()
        {
            Container = new CodeInterpreterToolContainer(
                CodeInterpreterToolContainerConfiguration.CreateAutomaticContainerConfiguration([])
            )
        };
        ToolboxSearchPreviewToolboxTool searchTool = new()
        {
            Name = "ToolBoxSearch",
            Description = "Search for the toolboxes"
        };
        ToolboxVersion toolBox = toolboxClient.CreateVersion(
            name: "myToolbox",
            tools: [mcp, codeInterpreter, searchTool],
            description: "Example toolbox created by the azure-ai-projects sample."
        );
        #endregion
        #region Snippet:Sample_CreateAgent_ToolSearch_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = {
                ResponseTool.CreateMcpTool(
                    serverLabel: "search-tool",
                    serverUri: new Uri($"{projectEndpoint}/toolboxes/{toolBox.Name}/versions/{toolBox.Version}/mcp?api-version=v1"),
                    authorizationToken: credential.GetToken(new(scopes: ["https://ai.azure.com/.default"])).Token,
                    headers: new Dictionary<string, string>() {
                        { "Foundry-Features", "Toolboxes=V1Preview" }
                    }
                ),
            }
        };
        ProjectsAgentVersion agentVersion = projectClient.AgentAdministrationClient.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion
        #region Snippet:Sample_CreateResponse_ToolSearch_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        CreateResponseOptions nextResponseOptions = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem("What tools are available?") }
        };
        ResponseResult latestResponse = null;

        while (nextResponseOptions is not null)
        {
            latestResponse = responseClient.CreateResponse(nextResponseOptions);
            nextResponseOptions = null;

            foreach (ResponseItem responseItem in latestResponse.OutputItems)
            {
                if (responseItem is McpToolCallApprovalRequestItem mcpToolCall)
                {
                    nextResponseOptions = new CreateResponseOptions()
                    {
                        PreviousResponseId = latestResponse.Id,
                    };
                    if (string.Equals(mcpToolCall.ServerLabel, "search-tool"))
                    {
                        Console.WriteLine($"Approving {mcpToolCall.ServerLabel}...");
                        // Automatically approve the MCP request to allow the agent to proceed
                        // In production, you might want to implement more sophisticated approval logic
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: true));
                    }
                    else
                    {
                        Console.WriteLine($"Rejecting unknown call {mcpToolCall.ServerLabel}...");
                        nextResponseOptions.InputItems.Add(ResponseItem.CreateMcpApprovalResponseItem(approvalRequestId: mcpToolCall.Id, approved: false));
                    }
                }
                else if (responseItem is McpToolDefinitionListItem listItem)
                {
                    Console.WriteLine("Found tools:");
                    foreach (McpToolDefinition tool in listItem.ToolDefinitions)
                    {
                        Console.WriteLine($"    {tool.Name}");
                    }
                }
            }
        }
        Console.WriteLine(latestResponse.GetOutputText());
        #endregion

        #region Snippet:Sample_Cleanup_ToolSearch_Sync
        toolboxClient.Delete(name: toolBox.Name);
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_ToolSearch(bool isAsync) : base(isAsync)
    { }
}
