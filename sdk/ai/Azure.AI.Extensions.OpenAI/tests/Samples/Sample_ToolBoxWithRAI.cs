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

public class Sample_ToolBoxWithRAI : ProjectsOpenAITestBase
{
    [Test]
    [AsyncOnly]
    public async Task ToolBoxWithRAIAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateAgentClient_ToolBoxWithRAI
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var raiPolicyName = System.Environment.GetEnvironmentVariable("RAI_POLICY_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var raiPolicyName = TestEnvironment.RAI_POLICY_NAME;
#endif
        DefaultAzureCredential credential = new();
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: credential);
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        #endregion
        try
        {
            toolboxClient.DeleteToolbox(name: "myToolbox");
        }
        catch { }
        #region Snippet:Sample_CreateToolbox_ToolBoxWithRAI_Async
        ProjectsAgentTool mcp = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        ToolboxPolicies raiPolicies = new()
        {
            RaiConfig = new(raiPolicyName)
        };
        ToolboxVersion toolBox = await toolboxClient.CreateToolboxVersionAsync(
            name: "myToolbox",
            tools: [mcp],
            policies: raiPolicies,
            description: "Toolbox with guardrail."
        );
        #endregion
        #region Snippet:Sample_CreateAgent_ToolBoxWithRAI_Async
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = {
                ResponseTool.CreateMcpTool(
                    serverLabel: "rai-github",
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
        #region Snippet:Sample_CreateResponse_ToolBoxWithRAI_Async
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        CreateResponseOptions nextResponseOptions = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem("Please summarize the Azure REST API specifications Readme?") }
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
                    if (string.Equals(mcpToolCall.ServerLabel, "rai-github"))
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

        #region Snippet:Sample_Cleanup_ToolBoxWithRAI_Async
        await toolboxClient.DeleteToolboxAsync(name: toolBox.Name);
        await projectClient.AgentAdministrationClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ToolBoxWithRAISync()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
        var raiPolicyName = System.Environment.GetEnvironmentVariable("RAI_POLICY_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
        var raiPolicyName = TestEnvironment.RAI_POLICY_NAME;
#endif
        DefaultAzureCredential credential = new();
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: credential);
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        try
        {
            toolboxClient.DeleteToolbox(name: "myToolbox");
        }
        catch { }
        #region Snippet:Sample_CreateToolbox_ToolBoxWithRAI_Sync
        ProjectsAgentTool mcp = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        ToolboxPolicies raiPolicies = new()
        {
            RaiConfig = new(raiPolicyName)
        };
        ToolboxVersion toolBox = toolboxClient.CreateToolboxVersion(
            name: "myToolbox",
            tools: [mcp],
            policies: raiPolicies,
            description: "Toolbox with guardrail."
        );
        #endregion
        #region Snippet:Sample_CreateAgent_ToolBoxWithRAI_Sync
        DeclarativeAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "You are a helpful assistant.",
            Tools = {
                ResponseTool.CreateMcpTool(
                    serverLabel: "rai-github",
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
        #region Snippet:Sample_CreateResponse_ToolBoxWithRAI_Sync
        ProjectResponsesClient responseClient = projectClient.ProjectOpenAIClient.GetProjectResponsesClientForAgent(agentVersion.Name);

        CreateResponseOptions nextResponseOptions = new()
        {
            InputItems = { ResponseItem.CreateUserMessageItem("Please summarize the Azure REST API specifications Readme?") }
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
                    if (string.Equals(mcpToolCall.ServerLabel, "rai-github"))
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

        #region Snippet:Sample_Cleanup_ToolBoxWithRAI_Sync
        toolboxClient.DeleteToolbox(name: toolBox.Name);
        projectClient.AgentAdministrationClient.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_ToolBoxWithRAI(bool isAsync) : base(isAsync)
    { }
}
