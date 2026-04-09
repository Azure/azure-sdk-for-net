// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using Microsoft.Testing.Platform.OutputDevice;
using NUnit.Framework;
using OpenAI.Responses;

#pragma warning disable AAIP001
namespace Azure.AI.Projects.Agents.Tests;

public class AgentsTests : AgentsTestBase
{
    public AgentsTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task ErrorsGiveGoodExceptionMessages()
    {
        AgentAdministrationClient agentsClient = GetTestClient();

        ClientResultException exception = null;
        try
        {
            _ = await agentsClient.GetAgentAsync("SomeAgentNameThatReallyDoesNotExistAndNeverShould3490");
        }
        catch (ClientResultException ex)
        {
            exception = ex;
        }

        Assert.That(exception?.Message, Does.Contain("exist"));
    }

    [RecordedTest]
    public async Task TestAgentCRUD()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectsAgentDefinition emptyAgentDefinition = new DeclarativeAgentDefinition(TestEnvironment.FOUNDRY_MODEL_NAME);

        const string emptyPromptAgentName = "TestNoVersionAgentFromDotnetTests";
        try
        {
            await agentsClient.DeleteAgentAsync(emptyPromptAgentName);
        }
        catch (ClientResultException)
        {
            // We do not have the agent to begin with.
        }
        ProjectsAgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(
            emptyPromptAgentName,
            new ProjectsAgentVersionCreationOptions(emptyAgentDefinition)
            {
                Metadata = { ["delete_me"] = "please " },
            });
        Assert.That(newAgentVersion?.Id, Is.Not.Null.And.Not.Empty);

        ProjectsAgentRecord retrievedAgent = await agentsClient.GetAgentAsync(emptyPromptAgentName);
        Assert.That(retrievedAgent?.Id, Is.EqualTo(newAgentVersion.Name));

        await agentsClient.DeleteAgentAsync(newAgentVersion.Name);

        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, new ProjectsAgentVersionCreationOptions(emptyAgentDefinition));
        Assert.That(AGENT_NAME, Is.EqualTo(agentVersion.Name));
        ProjectsAgentVersion agentVersionObject_ = await agentsClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Assert.That(AGENT_NAME, Is.EqualTo(agentVersionObject_.Name));
        Assert.That(agentVersion.Version, Is.EqualTo(agentVersionObject_.Version));
        Assert.That(agentVersion.Description, Is.Empty);
        Assert.That(agentVersion.Metadata, Is.Empty);
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Assert.ThrowsAsync<ClientResultException>(async () => await agentsClient.GetAgentVersionAsync(agentVersion.Name, agentVersion.Version));
    }

    [RecordedTest]
    public async Task TestToolboxesCRUD()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
        try
        {
            await toolboxClient.DeleteToolboxAsync("mcp1");
        }
        catch { }
        try
        {
            await toolboxClient.DeleteToolboxAsync("mcp2");
        }
        catch { }
        ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        // Create
        ToolboxVersion toolBox1 = await toolboxClient.CreateToolboxVersionAsync(
            toolboxName: "mcp1",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxVersion toolBox2 = await toolboxClient.CreateToolboxVersionAsync(
            toolboxName: "mcp2",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxVersion toolBox3 = await toolboxClient.CreateToolboxVersionAsync(
            toolboxName: "mcp2",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxRecord record = await toolboxClient.GetToolboxAsync(toolboxName: toolBox2.Name);
        Assert.That(record.Name, Is.EqualTo(toolBox3.Name));
        string newVersion = string.Equals(record.DefaultVersion, "1") ? "2" : "1";
        // Update
        record = await toolboxClient.UpdateToolboxAsync(record.Name, newVersion);
        Assert.That(record.Name, Is.EqualTo(toolBox2.Name));
        Assert.That(record.DefaultVersion, Is.EqualTo(newVersion));
        // Get
        record = await toolboxClient.GetToolboxAsync("mcp2");
        Assert.That(record.Name, Is.EqualTo("mcp2"));
        Assert.That(record.DefaultVersion, Is.EqualTo(newVersion));
        // List
        HashSet<string> recordNames = [..await toolboxClient.GetToolboxesAsync().Select(x => x.Name).ToListAsync()];
        Assert.That(recordNames, Does.Contain("mcp1"));
        Assert.That(recordNames, Does.Contain("mcp2"));
        // Delete
        await toolboxClient.DeleteToolboxAsync("mcp1");
        recordNames = [.. await toolboxClient.GetToolboxesAsync().Select(x => x.Name).ToListAsync()];
        Assert.That(recordNames, Does.Not.Contains("mcp1"));
        Assert.That(recordNames, Does.Contain("mcp2"));
        await toolboxClient.DeleteToolboxAsync("mcp2");
        recordNames = [.. await toolboxClient.GetToolboxesAsync().Select(x => x.Name).ToListAsync()];
        Assert.That(recordNames, Does.Not.Contains("mcp1"));
        Assert.That(recordNames, Does.Not.Contains("mcp2"));
    }

    [RecordedTest]
    public async Task TestToolboxVersionsCRUD()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
        try
        {
            await toolboxClient.DeleteToolboxAsync("mcp");
        }
        catch { }
        ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        // Create
        ToolboxVersion toolBox1 = await toolboxClient.CreateToolboxVersionAsync(
            toolboxName: "mcp",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        Assert.That(toolBox1.Name, Is.EqualTo("mcp"));
        Assert.That(toolBox1.Version, Is.EqualTo("1"));
        Assert.That(toolBox1.Metadata, Does.ContainKey("team"));
        Assert.That(toolBox1.Metadata["team"], Is.EqualTo("Engineers"));
        ToolboxVersion toolBox2 = await toolboxClient.CreateToolboxVersionAsync(
            toolboxName: "mcp",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Data Scientists"}
            }
        );
        Assert.That(toolBox2.Name, Is.EqualTo("mcp"));
        Assert.That(toolBox2.Version, Is.EqualTo("2"));
        Assert.That(toolBox2.Metadata, Does.ContainKey("team"));
        Assert.That(toolBox2.Metadata["team"], Is.EqualTo("Data Scientists"));
        // Get
        ToolboxVersion toolBox = await toolboxClient.GetToolboxVersionAsync(toolboxName: "mcp", version: "1");
        Assert.That(toolBox.Name, Is.EqualTo("mcp"));
        Assert.That(toolBox.Version, Is.EqualTo("1"));
        Assert.That(toolBox.Metadata, Does.ContainKey("team"));
        Assert.That(toolBox.Metadata["team"], Is.EqualTo("Engineers"));
        // List
        List<ToolboxVersion> versions = await toolboxClient.GetToolboxVersionsAsync(toolboxName: "mcp").ToListAsync();
        Assert.That(versions.Count, Is.EqualTo(2));
        if (string.Equals(versions[0].Version, "1"))
        {
            toolBox1 = versions[0];
            toolBox2 = versions[1];
        }
        else
        {
            toolBox1 = versions[1];
            toolBox2 = versions[0];
        }
        Assert.That(toolBox1.Name, Is.EqualTo("mcp"));
        Assert.That(toolBox1.Version, Is.EqualTo("1"));
        Assert.That(toolBox1.Metadata, Does.ContainKey("team"));
        Assert.That(toolBox1.Metadata["team"], Is.EqualTo("Engineers"));
        Assert.That(toolBox2.Name, Is.EqualTo("mcp"));
        Assert.That(toolBox2.Version, Is.EqualTo("2"));
        Assert.That(toolBox2.Metadata, Does.ContainKey("team"));
        Assert.That(toolBox2.Metadata["team"], Is.EqualTo("Data Scientists"));
        // Delete
        ToolboxRecord record = await toolboxClient.GetToolboxAsync("mcp");
        string deleteVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
        await toolboxClient.DeleteToolboxVersionAsync(toolboxName: "mcp", version: deleteVersion);
        HashSet<string> versionNumbers = [..await toolboxClient.GetToolboxVersionsAsync(toolboxName: "mcp").Select(x => x.Version).ToListAsync()];
        Assert.That(versionNumbers, Does.Not.Contains(deleteVersion));
        Assert.That(versionNumbers, Does.Contain(string.Equals(deleteVersion, "2") ? "1" : "2"));
        await toolboxClient.DeleteToolboxAsync(toolboxName: record.Name);
        Assert.ThrowsAsync<ClientResultException>(async () => await toolboxClient.GetToolboxVersionsAsync(toolboxName: "mcp").ToListAsync());
    }

    [RecordedTest]
    [TestCase(ToolType.CodeInterpreter)]
    [TestCase(ToolType.CodeInterpreterGen)]
    [TestCase(ToolType.FileSearch)]
    // [TestCase(ToolType.ImageGeneration)] Not supported in toolsets.
    [TestCase(ToolType.WebSearch)]
    // [TestCase(ToolType.WebSearchPreview)] Not supported in toolsets.
    // [TestCase(ToolType.Memory)] Not supported in toolsets.
    [TestCase(ToolType.AzureAISearch)]
    // [TestCase(ToolType.BingGrounding)] Not supported in toolsets.
    // [TestCase(ToolType.BingGroundingCustom)] Not supported in toolsets.
    [TestCase(ToolType.OpenAPI)]
    // [TestCase(ToolType.Sharepoint)] Not supported in toolsets.
    // [TestCase(ToolType.BrowserAutomation)] Not supported in toolsets.
    // [TestCase(ToolType.MicrosoftFabric)] Not supported in toolsets.
    [TestCase(ToolType.A2A)]
    // [TestCase(ToolType.AzureFunction)] Not supported in toolsets.
    // [TestCase(ToolType.FunctionCall)] Not supported in toolsets.
    [TestCase(ToolType.MCP)]
    // [TestCase(ToolType.ComputerUse)] Not supported in toolsets.
    public async Task TestToolsetVariety(ToolType toolType)
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
        ResponseTool oaiTool = GetAgentToolDefinition(toolType);
        ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(oaiTool);
        ToolboxVersion toolBox = await toolboxClient.CreateToolboxVersionAsync(
            toolboxName: TOOLBOX,
            tools: [tool],
            description: $"{toolType}"
        );
        Assert.That(toolBox.Name, Is.EqualTo(TOOLBOX));
        Assert.That(toolBox.Description, Is.EqualTo($"{toolType}"));
        Assert.That(toolBox.Tools.Count, Is.EqualTo(1));
        Assert.That(toolBox.Tools[0].GetType(), Is.EqualTo(tool.GetType()));
        toolBox = await toolboxClient.GetToolboxVersionAsync(toolboxName: TOOLBOX, version: toolBox.Version);
        Assert.That(toolBox.Name, Is.EqualTo(TOOLBOX));
        Assert.That(toolBox.Description, Is.EqualTo($"{toolType}"));
        Assert.That(toolBox.Tools.Count, Is.EqualTo(1));
        Assert.That(toolBox.Tools[0].GetType(), Is.EqualTo(tool.GetType()));
        // Use trhe tool to create an Agent
        DeclarativeAgentDefinition definition = new(TestEnvironment.FOUNDRY_MODEL_NAME)
        {
            Tools = { toolBox.Tools[0] }
        };
        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, new ProjectsAgentVersionCreationOptions(definition));
        if (agentVersion.Definition is DeclarativeAgentDefinition declarativeDefinition)
        {
            Assert.That(declarativeDefinition.Tools.Count(), Is.EqualTo(1));
            Assert.That(declarativeDefinition.Tools[0].GetType(), Is.EqualTo(oaiTool.GetType()));
        }
        else
        {
            Assert.Fail($"The agent definition is of wrong typoe: {agentVersion.Definition}");
        }
    }
}
