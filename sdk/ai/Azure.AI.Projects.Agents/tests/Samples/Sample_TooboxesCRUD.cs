// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.Agents.Tests.Samples;
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
        #region Snippet:Sample_CreateClient_ToolboxesAgentsCRUD
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("FOUNDRY_PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("FOUNDRY_MODEL_NAME");
#else
        var projectEndpoint = TestEnvironment.FOUNDRY_PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.FOUNDRY_MODEL_NAME;
#endif
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("Toolboxes=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
        string toolboxName = "mcp";
        #endregion
        DeleteToolboxMayBe(toolboxClient, toolboxName);
        #region Snippet:Sample_CreateToolbox_ToolboxesAgentsCRUD_Async
        ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        ToolboxVersion toolBox1 = await toolboxClient.CreateToolboxVersionAsync(
            toolboxName: toolboxName,
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxVersion toolBox2 = await toolboxClient.CreateToolboxVersionAsync(
            toolboxName: toolboxName,
            tools: [tool],
            description: "Another toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Data scientists"}
            }
        );
        string status = "unknown status";
        toolBox1.Metadata?.TryGetValue("team", out status);
        Console.WriteLine($"Toolbox: {toolBox1.Name}, version: {toolBox1.Version}, (tools: {toolBox1.Tools.Count}) (team: {status}).");
        #endregion

        #region Snippet:Sample_GetToolbox_ToolboxesAgentsCRUD_Async
        ToolboxRecord record = await toolboxClient.GetToolboxAsync(toolboxName: toolBox1.Name);
        Console.WriteLine($"The default version for a toolbox {record.Name} is {record.DefaultVersion}");
        #endregion

        #region Snippet:Sample_GetToolboxVersion_ToolboxesAgentsCRUD_Async
        ToolboxVersion toolBox = await toolboxClient.GetToolboxVersionAsync(record.Name, record.DefaultVersion);
        Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
        #endregion

        #region Snippet:Sample_UpdateToolbox_ToolboxesAgentsCRUD_Async
        string newVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
        record = await toolboxClient.UpdateToolboxAsync(toolboxName, newVersion);
        Console.WriteLine($"The default version for a toolbox {record.Name} is now {record.DefaultVersion}");
        #endregion

        #region Snippet:Sample_ListToolboxVersions_ToolboxesAgentsCRUD_Async
        List<ToolboxVersion> toolboxes = await toolboxClient.GetToolboxVersionsAsync(toolBox.Name).ToListAsync();
        Console.WriteLine($"Found {toolboxes.Count} toolbox version(s).");
        foreach (ToolboxVersion item in toolboxes)
        {
            Console.WriteLine($"  - {item.Name} ({item.Version})");
        }
        #endregion

        #region Snippet:Sample_ListToolboxes_ToolboxesAgentsCRUD_Async
        List<ToolboxRecord> records = await toolboxClient.GetToolboxesAsync().ToListAsync();
        Console.WriteLine($"Found {records.Count} toolbox(es).");
        foreach (ToolboxRecord item in records)
        {
            Console.WriteLine($"  - {item.Name} ({item.Id})");
        }
        #endregion

        #region Snippet:Sample_DeleteToolbox_ToolboxesAgentsCRUD_Async
        // We cannot delete the default version.
        string deleteVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
        await toolboxClient.DeleteToolboxVersionAsync(toolBox.Name, deleteVersion);
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
        AgentAdministrationClientOptions options = new();
        options.AddPolicy(new FeaturePolicy("Toolboxes=V1Preview"), PipelinePosition.PerCall);
        AgentAdministrationClient agentsClient = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential(), options: options);
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
        string toolboxName = "mcp";
        DeleteToolboxMayBe(toolboxClient, toolboxName);
        #region Snippet:Sample_CreateToolbox_ToolboxesAgentsCRUD_Sync
        ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        ToolboxVersion toolBox1 = toolboxClient.CreateToolboxVersion(
            toolboxName: toolboxName,
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxVersion toolBox2 = toolboxClient.CreateToolboxVersion(
            toolboxName: toolboxName,
            tools: [tool],
            description: "Another toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Data scientists"}
            }
        );
        string status = "unknown status";
        toolBox1.Metadata?.TryGetValue("team", out status);
        Console.WriteLine($"Toolbox: {toolBox1.Name}, version: {toolBox1.Version}, (tools: {toolBox1.Tools.Count}) (team: {status}).");
        #endregion

        #region Snippet:Sample_GetToolbox_ToolboxesAgentsCRUD_Sync
        ToolboxRecord record = toolboxClient.GetToolbox(toolboxName: toolBox1.Name);
        Console.WriteLine($"The default version for a toolbox {record.Name} is {record.DefaultVersion}");
        #endregion

        #region Snippet:Sample_GetToolboxVersion_ToolboxesAgentsCRUD_Sync
        ToolboxVersion toolBox = toolboxClient.GetToolboxVersion(record.Name, record.DefaultVersion);
        Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
        #endregion

        #region Snippet:Sample_UpdateToolbox_ToolboxesAgentsCRUD_Sync
        string newVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
        record = toolboxClient.UpdateToolbox(toolboxName, newVersion);
        Console.WriteLine($"The default version for a toolbox {record.Name} is now {record.DefaultVersion}");
        #endregion

        #region Snippet:Sample_ListToolboxVersions_ToolboxesAgentsCRUD_Sync
        List<ToolboxVersion> toolboxes = [.. toolboxClient.GetToolboxVersions(toolBox.Name)];
        Console.WriteLine($"Found {toolboxes.Count} toolbox version(s).");
        foreach (ToolboxVersion item in toolboxes)
        {
            Console.WriteLine($"  - {item.Name} ({item.Version})");
        }
        #endregion

        #region Snippet:Sample_ListToolboxes_ToolboxesAgentsCRUD_Sync
        List<ToolboxRecord> records = [.. toolboxClient.GetToolboxes()];
        Console.WriteLine($"Found {records.Count} toolbox(es).");
        foreach (ToolboxRecord item in records)
        {
            Console.WriteLine($"  - {item.Name} ({item.Id})");
        }
        #endregion

        #region Snippet:Sample_DeleteToolbox_ToolboxesAgentsCRUD_Sync
        // We cannot delete the default version.
        string deleteVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
        toolboxClient.DeleteToolboxVersion(toolBox.Name, deleteVersion);
        toolboxClient.DeleteToolbox(toolBox.Name);
        #endregion
    }
    public Sample_Toolboxes_CRUD(bool isAsync) : base(isAsync)
    { }
}
