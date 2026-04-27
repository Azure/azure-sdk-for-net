// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
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
            name: "mcp1",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxVersion toolBox2 = await toolboxClient.CreateToolboxVersionAsync(
            name: "mcp2",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxVersion toolBox3 = await toolboxClient.CreateToolboxVersionAsync(
            name: "mcp2",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxRecord record = await toolboxClient.GetToolboxAsync(name: toolBox2.Name);
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
        HashSet<string> recordNames = [.. await toolboxClient.GetToolboxesAsync().Select(x => x.Name).ToListAsync()];
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
            name: "mcp",
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
            name: "mcp",
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
        ToolboxVersion toolBox = await toolboxClient.GetToolboxVersionAsync(name: "mcp", version: "1");
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
        await toolboxClient.DeleteToolboxVersionAsync(name: "mcp", version: deleteVersion);
        HashSet<string> versionNumbers = [.. await toolboxClient.GetToolboxVersionsAsync(toolboxName: "mcp").Select(x => x.Version).ToListAsync()];
        Assert.That(versionNumbers, Does.Not.Contains(deleteVersion));
        Assert.That(versionNumbers, Does.Contain(string.Equals(deleteVersion, "2") ? "1" : "2"));
        await toolboxClient.DeleteToolboxAsync(name: record.Name);
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
            name: TOOLBOX,
            tools: [tool],
            description: $"{toolType}"
        );
        Assert.That(toolBox.Name, Is.EqualTo(TOOLBOX));
        Assert.That(toolBox.Description, Is.EqualTo($"{toolType}"));
        Assert.That(toolBox.Tools.Count, Is.EqualTo(1));
        Assert.That(toolBox.Tools[0].GetType(), Is.EqualTo(tool.GetType()));
        toolBox = await toolboxClient.GetToolboxVersionAsync(name: TOOLBOX, version: toolBox.Version);
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

    [RecordedTest]
    public async Task TestListToolboxes()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
        List<ToolboxRecord> records = await toolboxClient.GetToolboxesAsync().ToListAsync();
        int created = 0;
        ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        while (records.Count + created <= PAGE_SIZE)
        {
            await toolboxClient.CreateToolboxVersionAsync(
                name: $"{TOOLBOX}_{created}",
                tools: [tool],
                description: "Example toolbox created by the azure-ai-projects sample.",
                metadata: new Dictionary<string, string> {
                    {"team", "Engineers"}
                }
            );
            created++;
        }
        int newSize = records.Count + created;
        records = await toolboxClient.GetToolboxesAsync(limit: PAGE_SIZE, order: AgentListOrder.Ascending).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(newSize));
        // Go forward.
        List<ToolboxRecord> forward = await toolboxClient.GetToolboxesAsync(order: AgentListOrder.Ascending, after: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[forward.Count - 1].Id, Is.EqualTo(records[records.Count - 1].Id));
        // Two limits:
        forward = await toolboxClient.GetToolboxesAsync(order: AgentListOrder.Ascending, after: records[0].Id, before: records[3].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(2));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[1].Id, Is.EqualTo(records[2].Id));
        // Go backwards.
        List<ToolboxRecord> backwards = await toolboxClient.GetToolboxesAsync(order: AgentListOrder.Descending, before: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 1].Id));
        Assert.That(backwards[backwards.Count - 1].Id, Is.EqualTo(records[1].Id));
        // Two limits.
        backwards = await toolboxClient.GetToolboxesAsync(order: AgentListOrder.Descending, after: records[records.Count -1].Id, before: records[records.Count - 4].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(2));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 2].Id));
        Assert.That(backwards[1].Id, Is.EqualTo(records[records.Count - 3].Id));
    }

    [RecordedTest]
    public async Task TestListToolboxVersions()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
        List<ToolboxVersion> records = await toolboxClient.GetToolboxVersionsAsync(toolboxName: TOOLBOX, order: AgentListOrder.Ascending).ToListAsync();
        int created = 0;
        ProjectsAgentTool tool = ProjectsAgentTool.AsProjectTool(ResponseTool.CreateMcpTool(
            serverLabel: "api-specs",
            serverUri: new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            toolCallApprovalPolicy: new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        ));
        while (records.Count + created <= PAGE_SIZE)
        {
            await toolboxClient.CreateToolboxVersionAsync(
                name: TOOLBOX,
                tools: [tool],
                description: "Example toolbox created by the azure-ai-projects sample.",
                metadata: new Dictionary<string, string> {
                    {"team", "Engineers"}
                }
            );
            created++;
        }
        int newSize = records.Count + created;
        records = await toolboxClient.GetToolboxVersionsAsync(toolboxName: TOOLBOX, limit: PAGE_SIZE, order: AgentListOrder.Ascending).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(newSize));
        // Go forward.
        List<ToolboxVersion> forward = await toolboxClient.GetToolboxVersionsAsync(toolboxName: TOOLBOX, order: AgentListOrder.Ascending, after: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[forward.Count - 1].Id, Is.EqualTo(records[records.Count - 1].Id));
        // Two limits:
        forward = await toolboxClient.GetToolboxVersionsAsync(toolboxName: TOOLBOX, order: AgentListOrder.Ascending, after: records[0].Id, before: records[3].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(2));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[1].Id, Is.EqualTo(records[2].Id));
        // Go backwards.
        List<ToolboxVersion> backwards = await toolboxClient.GetToolboxVersionsAsync(toolboxName: TOOLBOX, order: AgentListOrder.Descending, before: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 1].Id));
        Assert.That(backwards[backwards.Count - 1].Id, Is.EqualTo(records[1].Id));
        // Two limits.
        backwards = await toolboxClient.GetToolboxVersionsAsync(toolboxName: TOOLBOX, order: AgentListOrder.Descending, after: records[records.Count - 1].Id, before: records[records.Count - 4].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(2));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 2].Id));
        Assert.That(backwards[1].Id, Is.EqualTo(records[records.Count - 3].Id));
    }

    [RecordedTest]
    public async Task TestPatchHostedAgent()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient);
        AgentEndpoint config = new()
        {
            VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 74)]),
            Protocols = { AgentEndpointProtocol.Responses }
        };
        AgentsSkill simpleSkill = await skillsClient.CreateSkillAsync(name: SKILL, description: "Calculates the sum of two numbers.", instructions: """
            To calculate the sum  run
            ```bash
            echo $((<first> + <second>))
            ```
            ```powershell
            (<first> + <second>)
            ```
            Replace <first> and <second> by the actual summation arguments.
            """);
        AgentCard card = new(version: "42", [new AgentCardSkill(id: simpleSkill.SkillId, name: SKILL)]);
        PatchAgentOptions patchOptions = new()
        {
            AgentEndpoint = config,
            AgentCard = card,
        };
        ProjectsAgentRecord patchedRecord = await agentsClient.PatchAgentObjectAsync(
            agentName: agentVersion.Name,
            patchAgentOptions: patchOptions);
        Assert.That(patchedRecord.AgentEndpoint.Protocols, Has.Count.EqualTo(1));
        Assert.That(patchedRecord.AgentEndpoint.Protocols[0], Is.EqualTo(AgentEndpointProtocol.Responses));
        Assert.That(patchedRecord.AgentEndpoint.VersionSelector.VersionSelectionRules, Has.Count.EqualTo(1));
        Assert.That(patchedRecord.AgentEndpoint.VersionSelector.VersionSelectionRules[0], Is.InstanceOf(typeof(FixedRatioVersionSelectionRule)));
        Assert.That(((FixedRatioVersionSelectionRule)patchedRecord.AgentEndpoint.VersionSelector.VersionSelectionRules[0]).TrafficPercentage, Is.EqualTo(74));
        Assert.That(patchedRecord.AgentCard.Version, Is.EqualTo("42"));
        Assert.That(patchedRecord.AgentCard.Skills, Has.Count.EqualTo(1));
        Assert.That(patchedRecord.AgentCard.Skills[0].Id, Is.EqualTo(simpleSkill.SkillId));
    }

    [RecordedTest]
    public async Task TestSessionCRUD()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient);
        string sessionKey1 = "sample_session_key1";
        string sessionKey2 = "sample_session_key2";
        // Create
        ProjectAgentSession session1 = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
            isolationKey: sessionKey1,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        Assert.That(session1.VersionIndicator, Is.InstanceOf(typeof(VersionRefIndicator)));
        Assert.That(((VersionRefIndicator)session1.VersionIndicator).AgentVersion, Is.EqualTo(agentVersion.Version));
        while (session1.Status != AgentSessionStatus.Failed && session1.Status != AgentSessionStatus.Active)
        {
            await Delay();
            session1 = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
        }
        Assert.That(session1.Status, Is.EqualTo(AgentSessionStatus.Active));
        Assert.That(session1.AgentSessionId, Is.EqualTo(session1.AgentSessionId));
        ProjectAgentSession session2 = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
            isolationKey: sessionKey2,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        Assert.That(session2.VersionIndicator, Is.InstanceOf(typeof(VersionRefIndicator)));
        Assert.That(((VersionRefIndicator)session2.VersionIndicator).AgentVersion, Is.EqualTo(agentVersion.Version));
        while (session2.Status != AgentSessionStatus.Failed && session2.Status != AgentSessionStatus.Active)
        {
            await Delay();
            session2 = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
        }
        Assert.That(session2.Status, Is.EqualTo(AgentSessionStatus.Active));
        Assert.That(session2.AgentSessionId, Is.EqualTo(session2.AgentSessionId));
        // Get
        ProjectAgentSession session = await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
        Assert.That(session.AgentSessionId, Is.EqualTo(session1.AgentSessionId));
        Assert.That(session.VersionIndicator, Is.InstanceOf(typeof(VersionRefIndicator)));
        Assert.That(((VersionRefIndicator)session.VersionIndicator).AgentVersion, Is.EqualTo(agentVersion.Version));
        // List
        HashSet<string> sessions = [..await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).Select(x => x.AgentSessionId).ToListAsync()];
        Assert.That(sessions, Has.Count.EqualTo(2));
        Assert.That(sessions, Does.Contain(session1.AgentSessionId));
        Assert.That(sessions, Does.Contain(session2.AgentSessionId));
        // Delete
        await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId, isolationKey: sessionKey1);
        sessions = [.. await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).Select(x => x.AgentSessionId).ToListAsync()];
        Assert.That(sessions, Has.Count.EqualTo(1));
        Assert.That(sessions, Does.Not.Contain(session1.AgentSessionId));
        Assert.That(sessions, Does.Contain(session2.AgentSessionId));
        await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId, isolationKey: sessionKey2);
        sessions = [.. await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).Select(x => x.AgentSessionId).ToListAsync()];
        Assert.That(sessions, Has.Count.EqualTo(0));
    }

    [RecordedTest]
    public async Task TestSessionPagination()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient, "01");
        await DeleteAllSessionsAsync(agentsClient, agentVersion.Name, "key_1");
        string sessionIdBase = $"session_{(IsAsync ? "async" : "sync")}_09";
        // Make sure that chronological order is the reverse of session ID alphanumeric order.
        for (int i = 0; i < PAGE_SIZE + 1; i++)
        {
            try
            {
                await agentsClient.CreateSessionAsync(
                    agentName: agentVersion.Name,
                    agentSessionId: $"{sessionIdBase}_{PAGE_SIZE - i}",
                    isolationKey: "key_1",
                    versionIndicator: new VersionRefIndicator(agentVersion.Version)
                );
            }
            catch
            {
                SessionLogEvent evt = await agentsClient.GetSessionLogStreamAsync(
                    agentName: agentVersion.Name,
                    agentVersion: agentVersion.Version,
                    sessionId: $"{sessionIdBase}_{PAGE_SIZE - i}"
                );
                Console.WriteLine(evt.Data);
                throw;
            }
        }
        await foreach (ProjectAgentSession sess in agentsClient.GetSessionsAsync(agentName: agentVersion.Name, limit: PAGE_SIZE, order: AgentListOrder.Ascending))
        {
            Console.WriteLine(sess.AgentSessionId);
        }
        List<ProjectAgentSession> records = await agentsClient.GetSessionsAsync(agentName: agentVersion.Name, limit: PAGE_SIZE, order: AgentListOrder.Ascending).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(PAGE_SIZE + 1));
        // Go forward.
        List<ProjectAgentSession> forward = await agentsClient.GetSessionsAsync(agentName: agentVersion.Name, order: AgentListOrder.Ascending, after: records[0].AgentSessionId, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].AgentSessionId, Is.EqualTo(records[1].AgentSessionId));
        Assert.That(forward[forward.Count - 1].AgentSessionId, Is.EqualTo(records[records.Count - 1].AgentSessionId));
        // Two limits:
        forward = await agentsClient.GetSessionsAsync(agentName: agentVersion.Name, order: AgentListOrder.Ascending, after: records[0].AgentSessionId, before: records[3].AgentSessionId, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(2));
        Assert.That(forward[0].AgentSessionId, Is.EqualTo(records[1].AgentSessionId));
        Assert.That(forward[1].AgentSessionId, Is.EqualTo(records[2].AgentSessionId));
        // Go backwards.
        List<ProjectAgentSession> backwards = await agentsClient.GetSessionsAsync(agentName: agentVersion.Name, order: AgentListOrder.Descending, before: records[0].AgentSessionId, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        Assert.That(backwards[0].AgentSessionId, Is.EqualTo(records[records.Count - 1].AgentSessionId));
        Assert.That(backwards[backwards.Count - 1].AgentSessionId, Is.EqualTo(records[1].AgentSessionId));
        // Two limits.
        backwards = await agentsClient.GetSessionsAsync(agentName: agentVersion.Name, order: AgentListOrder.Descending, after: records[records.Count - 1].AgentSessionId, before: records[records.Count - 4].AgentSessionId, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(2));
        Assert.That(backwards[0].AgentSessionId, Is.EqualTo(records[records.Count - 2].AgentSessionId));
        Assert.That(backwards[1].AgentSessionId, Is.EqualTo(records[records.Count - 3].AgentSessionId));
        await DeleteAllSessionsAsync(agentsClient, agentVersion.Name, "key_1");
    }

    [RecordedTest]
    public async Task TestSessionLogs()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient);
        string sessionName = IsAsync ? "session_async_12345678" : "session_sync_12345678";
        try
        {
            ProjectAgentSession session = await agentsClient.CreateSessionAsync(
                agentName: agentVersion.Name,
                agentSessionId: sessionName,
                isolationKey: "key_1",
                versionIndicator: new VersionRefIndicator(agentVersion.Version)
            );
        }
        finally
        {
            SessionLogEvent logEvent = await agentsClient.GetSessionLogStreamAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version, sessionId: sessionName);
            Assert.That(logEvent.Data, Is.Not.Empty);
        }
    }

    [RecordedTest]
    public async Task TestSessionFilesCRUD()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentSessionFiles filesClient = agentsClient.GetAgentSessionFiles();
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient, "01");
        ProjectAgentSession session = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
            isolationKey: "key_1",
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        string fileLocalPath = GetTestFile("weather_openapi.json");
        string file1 = "file1.json", file2 = "file2.json";
        int fileLength = File.ReadAllBytes(fileLocalPath).Length;
        //Create
        SessionFileWriteResponse writeResponse = await filesClient.UploadSessionFileAsync(
            agentName: agentVersion.Name,
            sessionId: session.AgentSessionId,
            sessionStoragePath: $"storage/{file1}",
            localPath: fileLocalPath
        );
        Assert.That(writeResponse.Path, Is.EqualTo($"storage/{file1}"));
        Assert.That(writeResponse.BytesWritten, Is.EqualTo(fileLength));
        fileLocalPath = GetTestFile("test.txt");
        fileLength = File.ReadAllBytes(fileLocalPath).Length;
        writeResponse = await filesClient.UploadSessionFileAsync(
            agentName: agentVersion.Name,
            sessionId: session.AgentSessionId,
            sessionStoragePath: $"storage/{file2}",
            localPath: fileLocalPath
        );
        Assert.That(writeResponse.Path, Is.EqualTo($"storage/{file2}"));
        Assert.That(writeResponse.BytesWritten, Is.EqualTo(fileLength));
        // List
        SessionDirectoryListResponse response = await filesClient.GetSessionFilesAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, sessionStoragePath: "storage");
        Assert.That(response.Entries, Has.Count.EqualTo(2));
        List<string> lstEntries = [.. response.Entries.Select(x => x.Name)];
        Assert.That(lstEntries, Does.Contain(file1));
        Assert.That(lstEntries, Does.Contain(file2));
        // Download
        string temporaryFile = Path.GetTempFileName();
        File.Delete(temporaryFile);
        BinaryData dataBin = await filesClient.DownloadSessionFileAsync(
            agentName: agentVersion.Name,
            sessionId: session.AgentSessionId,
            sessionStoragePath: $"storage/{file2}",
            localPath: temporaryFile
        );
        string data = File.ReadAllText(temporaryFile);
        Assert.That(data, Is.EqualTo("The test file\n"));
        data = dataBin.ToString();
        Assert.That(data, Is.EqualTo("The test file\n"));
        // Delete
        await filesClient.DeleteSessionFileAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, path: $"storage/{file2}");
        response = await filesClient.GetSessionFilesAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, sessionStoragePath: "storage");
        lstEntries = [.. response.Entries.Select(x => x.Name)];
        Assert.That(lstEntries, Has.Count.EqualTo(1));
        Assert.That(lstEntries[0], Is.EqualTo(file1));
        await filesClient.DeleteSessionFileAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, path: $"storage/{file1}");
        response = await filesClient.GetSessionFilesAsync(agentName: agentVersion.Name, sessionId: session.AgentSessionId, sessionStoragePath: "storage");
        Assert.That(response.Entries, Has.Count.EqualTo(0));
        await agentsClient.DeleteSessionAsync(
            agentName: agentVersion.Name,
            sessionId: session.AgentSessionId,
            isolationKey: $"key_1"
        );
    }

    [LiveOnly]
    [Test]
    public async Task TestSkillFromFile()
    {
        // Creating archive is not deterministic.
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
        string fileSkillName = $"{SKILL}_file";
        AgentsSkill skillFromFile = await skillsClient.CreateSkillFromPackageAsync(GetTestFile("roll-dice"));
        Assert.That(skillFromFile.Name, Is.EqualTo(fileSkillName));
        Assert.That(skillFromFile.Description, Is.EqualTo("Roll dice using a random number generator."));
        string savePath = Path.Combine(Path.GetTempPath(), "saved_skill");
        try
        {
            Directory.Delete(savePath, true);
        }
        catch { }
        BinaryData data = await skillsClient.DownloadSkillAsync(skillFromFile.Name, savePath);
        Assert.That(savePath, Does.Exist);
        string skillMdPath = Path.Combine(savePath, "SKILL.md");
        Assert.That(skillMdPath, Does.Exist);
        string skillMd = File.ReadAllText(skillMdPath);
        Assert.That(skillMd, Does.Contain(fileSkillName));
        Assert.That(skillMd, Does.Contain("Roll dice using a random number generator."));
        Directory.Delete(savePath, true);
        SaveAndUnzipData(savePath, data);
        Assert.That(savePath, Does.Exist);
        skillMdPath = Path.Combine(savePath, "SKILL.md");
        Assert.That(skillMdPath, Does.Exist);
        skillMd = File.ReadAllText(skillMdPath);
        Assert.That(skillMd, Does.Contain(fileSkillName));
        Assert.That(skillMd, Does.Contain("Roll dice using a random number generator."));
        Directory.Delete(savePath, true);
    }

    [RecordedTest]
    public async Task TestSkillsCRUD()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
        string codeSkillName = $"{SKILL}_code", codeSkillName2 = $"{SKILL}_code2";
        await foreach (AgentsSkill skill1 in skillsClient.GetSkillsAsync())
        {
            if (skill1.Name.StartsWith(SKILL))
            {
                await skillsClient.DeleteSkillAsync(skill1.Name);
            }
        }
        AgentsSkill skillFromCode = await skillsClient.CreateSkillAsync(name: codeSkillName, description: "Calculates the sum of two numbers.", instructions: """
            To calculate the sum run
            ```bash
            echo $((<first> + <second>))
            ```
            ```powershell
            (<first> + <second>)
            ```
            Replace <first> and <second> by the actual summation arguments.
            """);
        Assert.That(skillFromCode.Name, Is.EqualTo(codeSkillName));
        Assert.That(skillFromCode.Description, Is.EqualTo("Calculates the sum of two numbers."));
        AgentsSkill skillFromCode2 = await skillsClient.CreateSkillAsync(name: codeSkillName2, description: "Divides one number by the other.", instructions: """
            To calculate the division run
            ```bash
            echo $((<first> / <second>))
            ```
            ```powershell
            (<first> + <second>)
            ```
            Replace <first> and <second> by the actual division arguments.
            """);
        Assert.That(skillFromCode2.Name, Is.EqualTo(codeSkillName2));
        Assert.That(skillFromCode2.Description, Is.EqualTo("Divides one number by the other."));
        // Update
        AgentsSkill skill = await skillsClient.UpdateSkillAsync(name: codeSkillName, description: "Calculates the product of two numbers.", instructions: """
            To calculate the multiplication run
            ```bash
            echo $((<first> * <second>))
            ```
            ```powershell
            (<first> * <second>)
            ```
            Replace <first> and <second> by the actual multiplication arguments.
            """);
        Assert.That(skill.Name, Is.EqualTo(codeSkillName));
        Assert.That(skill.Description, Is.EqualTo("Calculates the product of two numbers."));
        // Get
        skillFromCode = await skillsClient.GetSkillAsync(name: codeSkillName);
        Assert.That(skillFromCode.Name, Is.EqualTo(codeSkillName));
        Assert.That(skillFromCode.Description, Is.EqualTo("Calculates the product of two numbers."));
        // List
        HashSet<string> skills = [.. await skillsClient.GetSkillsAsync().Select(x => x.Name).ToListAsync()];
        Assert.That(skills, Does.Contain(codeSkillName));
        Assert.That(skills, Does.Contain(codeSkillName2));
        // Delete
        await skillsClient.DeleteSkillAsync(name: codeSkillName);
        skills = [.. await skillsClient.GetSkillsAsync().Select(x => x.Name).ToListAsync()];
        Assert.That(skills, Does.Not.Contain(codeSkillName));
        Assert.That(skills, Does.Contain(codeSkillName2));
        await skillsClient.DeleteSkillAsync(name: codeSkillName2);
        skills = [.. await skillsClient.GetSkillsAsync().Select(x => x.Name).ToListAsync()];
        Assert.That(skills, Does.Not.Contain(codeSkillName));
        Assert.That(skills, Does.Not.Contain(codeSkillName2));
    }

    [RecordedTest]
    public async Task TestSkillPagination()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
        int initialCount = (await skillsClient.GetSkillsAsync(limit: PAGE_SIZE, order: AgentListOrder.Ascending).ToListAsync()).Count;
        for (int i = 0; i < PAGE_SIZE + 1; i++)
        {
            await skillsClient.CreateSkillAsync(
                name: $"{SKILL}_{i}",
                description: "Calculates the sum of two numbers.",
                instructions: """
                To calculate the sum  run
                ```bash
                echo $((<first> + <second>))
                ```
                ```powershell
                (<first> + <second>)
                ```
                Replace <first> and <second> by the actual summation arguments.
                """
            );
        }
        List<AgentsSkill> records = await skillsClient.GetSkillsAsync(limit: PAGE_SIZE, order: AgentListOrder.Ascending).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(PAGE_SIZE + 1 + initialCount));
        // Go forward.
        List<AgentsSkill> forward = await skillsClient.GetSkillsAsync(order: AgentListOrder.Ascending, after: records[0].SkillId, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].SkillId, Is.EqualTo(records[1].SkillId));
        Assert.That(forward[forward.Count - 1].SkillId, Is.EqualTo(records[records.Count - 1].SkillId));
        // Two limits:
        forward = await skillsClient.GetSkillsAsync(order: AgentListOrder.Ascending, after: records[0].SkillId, before: records[3].SkillId, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(2));
        Assert.That(forward[0].SkillId, Is.EqualTo(records[1].SkillId));
        Assert.That(forward[1].SkillId, Is.EqualTo(records[2].SkillId));
        // Go backwards.
        List<AgentsSkill> backwards = await skillsClient.GetSkillsAsync(order: AgentListOrder.Descending, before: records[0].SkillId, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        Assert.That(backwards[0].SkillId, Is.EqualTo(records[records.Count - 1].SkillId));
        Assert.That(backwards[backwards.Count - 1].SkillId, Is.EqualTo(records[1].SkillId));
        // Two limits.
        backwards = await skillsClient.GetSkillsAsync(order: AgentListOrder.Descending, after: records[records.Count - 1].SkillId, before: records[records.Count - 4].SkillId, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(2));
        Assert.That(backwards[0].SkillId, Is.EqualTo(records[records.Count - 2].SkillId));
        Assert.That(backwards[1].SkillId, Is.EqualTo(records[records.Count - 3].SkillId));
    }

    #region Helpers
    public static async Task DeleteAllSessionsAsync(AgentAdministrationClient agentsClient, string agentName, string key)
    {
        List<string> sessions = await agentsClient.GetSessionsAsync(agentName: agentName).Select(x => x.AgentSessionId).ToListAsync();
        foreach (string session in sessions)
        {
            await agentsClient.DeleteSessionAsync(
                agentName: agentName,
                sessionId: session,
                isolationKey: key
            );
        }
    }

    private static void SaveAndUnzipData(string directoryPath, BinaryData content)
    {
        string temporaryFile = Path.GetTempFileName();
        File.Delete(temporaryFile);
        File.WriteAllBytes(temporaryFile, content.ToArray());
        ZipFile.ExtractToDirectory(temporaryFile, directoryPath);
    }

    private async Task<ProjectsAgentVersion> CreateHostedAgent(AgentAdministrationClient agentsClient, string suffix=default)
    {
        Uri uriEndpoint = new Uri(TestEnvironment.FOUNDRY_PROJECT_ENDPOINT);
        string accountId = uriEndpoint.Authority.Substring(0, uriEndpoint.Authority.IndexOf('.'));
        HostedAgentDefinition agentDefinition = new(
            versions: [new ProtocolVersionRecord(ProjectsAgentProtocol.Responses, "1.0.0")],
            cpu: "0.5",
            memory: "1Gi"
        )
        {
            EnvironmentVariables = {
                { "AZURE_OPENAI_ENDPOINT", $"https://{accountId}.cognitiveservices.azure.com/" },
                { "AZURE_OPENAI_CHAT_DEPLOYMENT_NAME", TestEnvironment.FOUNDRY_MODEL_NAME }
            },
            Image = TestEnvironment.AGENT_DOCKER_IMAGE,
        };
        ProjectsAgentVersionCreationOptions creationOptions = new(agentDefinition);
        creationOptions.Metadata["enableVnextExperience"] = "true";
        ProjectsAgentVersion agent = await agentsClient.CreateAgentVersionAsync(
            agentName: string.IsNullOrEmpty(suffix) ? HOSTED_AGENT : $"{HOSTED_AGENT}-{suffix}",
            options: creationOptions);
        while (agent.Status != AgentVersionStatus.Active && agent.Status != AgentVersionStatus.Failed)
        {
            await Delay();
            agent = await agentsClient.GetAgentVersionAsync(agentName: agent.Name, agentVersion: agent.Version);
        }
        Assert.That(agent.Status, Is.EqualTo(AgentVersionStatus.Active), $"Agent deployment failed status: {agent.Status}");
        return agent;
    }
    #endregion
}
