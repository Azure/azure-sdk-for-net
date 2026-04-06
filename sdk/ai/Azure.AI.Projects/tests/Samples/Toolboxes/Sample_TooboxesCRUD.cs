// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;
using Azure.AI.Projects.Agents;

namespace Azure.AI.Projects.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_Toolboxes_CRUD : SamplesBase
{
    private void DeleteToolboxMayBe(AgentToolboxes client, string name)
    {
        try
        {
            client.DeleteToolbox(name);
        }
        catch
        {
            // Nothing here.
        }
    }

    [Test]
    [AsyncOnly]
    public async Task ToolboxesCRUDAsync()
    {
        #region Snippet:Sample_CreateClient_ToolboxesCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        string toolboxName = "mcp";
        #endregion
        DeleteToolboxMayBe(toolboxClient, toolboxName);
        #region Snippet:Sample_CreateToolbox_ToolboxesCRUD_Async
        ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        ToolboxVersion toolBox = await toolboxClient.CreateToolboxVersionAsync(
            toolboxName: toolboxName,
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"status", "created"}
            }
        );
        string status = "unknown status";
        toolBox.Metadata?.TryGetValue("status", out status);
        Console.WriteLine($"Toolbox: {toolBox.Name}, (tools: {toolBox.Tools.Count}) (status: {status}");
        #endregion

        #region Snippet:Sample_GetToolbox_ToolboxesCRUD_Async
        toolBox = await toolboxClient.GetToolboxVersionAsync(toolBox.Name, toolBox.Version);
        Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
        #endregion

        #region Snippet:Sample_ListToolbox_ToolboxesCRUD_Async
        List<ToolboxVersion> toolboxes = await toolboxClient.GetToolboxVersionsAsync(toolBox.Name).ToListAsync();
        Console.WriteLine($"Found {toolboxes.Count} toolsets");
        foreach (ToolboxVersion item in toolboxes)
        {
            Console.WriteLine($"  - {item.Name} ({item.Id})");
        }
        #endregion

        #region Snippet:Sample_DeleteToolbox_ToolboxesCRUD_Async
        await toolboxClient.DeleteToolboxAsync(toolBox.Name);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ToolboxesCRUDSync()
    {
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AIProjectClient projectClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        AgentToolboxes toolboxClient = projectClient.AgentAdministrationClient.GetAgentToolboxes();
        string toolboxName = "mcp";
        DeleteToolboxMayBe(toolboxClient, toolboxName);
        #region Snippet:Sample_CreateToolbox_ToolboxesCRUD_Sync
        ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        ToolboxVersion toolBox = toolboxClient.CreateToolboxVersion(
            toolboxName: toolboxName,
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"status", "created"}
            }
        );
        string status = "unknown status";
        toolBox.Metadata?.TryGetValue("status", out status);
        Console.WriteLine($"Toolbox: {toolBox.Name}, (tools: {toolBox.Tools.Count}) (status: {status}");
        #endregion

        #region Snippet:Sample_GetToolbox_ToolboxesCRUD_Sync
        toolBox = toolboxClient.GetToolboxVersion(toolBox.Name, toolBox.Version);
        Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
        #endregion

        #region Snippet:Sample_ListToolbox_ToolboxesCRUD_Sync
        List<ToolboxVersion> toolboxes = [..toolboxClient.GetToolboxVersions(toolBox.Name)];
        Console.WriteLine($"Found {toolboxes.Count} toolsets");
        foreach (ToolboxVersion item in toolboxes)
        {
            Console.WriteLine($"  - {item.Name} ({item.Id})");
        }
        #endregion

        #region Snippet:Sample_DeleteToolbox_ToolboxesCRUD_Sync
        toolboxClient.DeleteToolbox(toolBox.Name);
        #endregion
    }
    public Sample_Toolboxes_CRUD(bool isAsync) : base(isAsync)
    { }
}
