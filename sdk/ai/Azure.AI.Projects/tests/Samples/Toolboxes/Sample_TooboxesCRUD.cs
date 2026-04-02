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

namespace Azure.AI.Projects.Tests.Samples;
#pragma warning disable AAIP001

public class Sample_Toolboxes_CRUD : SamplesBase
{
    private void DeleteToolboxMayBe(ProjectToolboxes client, string name)
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
        ProjectToolboxes toolboxClient = projectClient.GetProjectToolboxesClient();
        string toolboxName = "mcp";
        #endregion
        DeleteToolboxMayBe(toolboxClient, toolboxName);
        #region Snippet:Sample_CreateToolbox_ToolboxesCRUD_Async
        ProjectTool tool = ProjectTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        ToolboxRecord toolBox = await toolboxClient.CreateToolboxAsync(
            toolboxName: toolboxName,
            tools: [tool],
            description: "Example toolset created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"status", "created"}
            }
        );
        string status = "unknown status";
        toolBox.Versions.Latest.Metadata?.TryGetValue("status", out status);
        Console.WriteLine($"Toolbox: {toolBox.Name}, (tools: {toolBox.Versions.Latest.Tools.Count}) (status: {status}");
        #endregion

        #region Sample_GetToolbox_ToolboxesCRUD_Async
        toolBox = await toolboxClient.GetToolboxAsync(toolBox.Name);
        Console.WriteLine($"Retrieved toolbox: {toolBox.Name} ({toolBox.Id})");
        #endregion

        #region Sample_UpdateToolbox_ToolboxesCRUD_Async
        BinaryData update = BinaryData.FromObjectAsJson(
            new
            {
                description = "Updated description for the sample toolset.",
                metadata = new
                {
                    status = "updated"
                }
            }
        );
        using BinaryContent updateContent = BinaryContent.Create(update);
        ClientResult data = await toolboxClient.UpdateToolboxAsync(
            toolboxName: toolboxName,
            content: updateContent
        );
        toolBox = ClientResult.FromValue((ToolboxRecord)data, data.GetRawResponse());
        status = "unknown status";
        toolBox.Versions.Latest.Metadata?.TryGetValue("status", out status);
        Console.WriteLine($"Toolbox: {toolBox.Name}, (tools: {toolBox.Versions.Latest.Tools.Count}) (status: {status}");
        #endregion

        #region Snippet:Sample_ListToolbox_ToolboxesCRUD_Async
        List<ToolboxRecord> toolboxes = await toolboxClient.GetToolboxesAsync().ToListAsync();
        Console.WriteLine($"Found {toolboxes.Count} toolsets");
        foreach (ToolboxRecord item in toolboxes)
        {
            Console.WriteLine($"  - {item.Name} ({item.Id})");
        }
        #endregion

        #region Snippet:Sample_DeleteToolbox_ToolboxesCRUD_Async
        DeleteToolboxResponse deletionResult = await toolboxClient.DeleteToolboxAsync(toolBox.Name);
        Console.WriteLine($"The toolbox {deletionResult.Name} was {(deletionResult.Deleted ? "" : "not ")} deleted.");
        #endregion
    }
    public Sample_Toolboxes_CRUD(bool isAsync) : base(isAsync)
    { }
}
