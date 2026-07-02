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
using NUnit.Framework.Internal;
using NUnit.Framework.Legacy;
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
    [TestCase(true)]
    [TestCase(false)]
    public async Task TestAgentCRUD(bool useExternalAgent)
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectsAgentDefinition emptyAgentDefinition = useExternalAgent ? new ExternalAgentDefinition() { OtelAgentId = "foo"} :  new DeclarativeAgentDefinition(TestEnvironment.FOUNDRY_MODEL_NAME);

        ProjectsAgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(
            AGENT_NAME2,
            new ProjectsAgentVersionCreationOptions(emptyAgentDefinition)
            {
                Metadata = { ["delete_me"] = "please " },
            });
        Assert.That(newAgentVersion?.Id, Is.Not.Null.And.Not.Empty);

        ProjectsAgentRecord retrievedAgent = await agentsClient.GetAgentAsync(AGENT_NAME2);
        Assert.That(retrievedAgent?.Id, Is.EqualTo(newAgentVersion.Name));

        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, new ProjectsAgentVersionCreationOptions(emptyAgentDefinition));
        Assert.That(AGENT_NAME, Is.EqualTo(agentVersion.Name));
        Assert.That(agentVersion.Description, Is.Empty);
        Assert.That(agentVersion.Metadata, Is.Empty);
        agentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, new ProjectsAgentVersionCreationOptions(emptyAgentDefinition)
        {
            Metadata = { { "foo", "bar" } }
        });
        // Get Version
        ProjectsAgentVersion agentVersionObject_ = await agentsClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        ValidateDefinition(agentVersionObject_, useExternalAgent);
        Assert.That(agentVersionObject_.Name, Is.EqualTo(AGENT_NAME));
        Assert.That(agentVersionObject_.Version, Is.EqualTo(agentVersion.Version));
        // Get
        ProjectsAgentRecord agentObject_ = await agentsClient.GetAgentAsync(agentName: agentVersion.Name);
        ValidateDefinition(agentObject_.Versions.Latest, useExternalAgent);
        Assert.That(agentObject_.Name, Is.EqualTo(AGENT_NAME));
        // List Agents
        ProjectsAgentKind goodKind = useExternalAgent ? ProjectsAgentKind.External : ProjectsAgentKind.Prompt;
        ProjectsAgentKind badKind = ProjectsAgentKind.Workflow;
        List<ProjectsAgentRecord> records = await agentsClient.GetAgentsAsync(kind: badKind).ToListAsync();
        List<ProjectsAgentRecord> test = [.. records.Where(x => string.Equals(x.Name, AGENT_NAME))];
        Assert.That(test, Has.Count.EqualTo(0));
        records = await agentsClient.GetAgentsAsync(kind: goodKind).ToListAsync();
        test = [.. records.Where(x => string.Equals(x.Name, AGENT_NAME))];
        Assert.That(test, Has.Count.EqualTo(1));
        ValidateDefinition(test[0].Versions.Latest, useExternalAgent);
        test = [.. records.Where(x => string.Equals(x.Name, AGENT_NAME2))];
        Assert.That(test, Has.Count.EqualTo(1));
        ValidateDefinition(test[0].Versions.Latest, useExternalAgent);

        // List Versions
        List<ProjectsAgentVersion> recordVersions = await agentsClient.GetAgentVersionsAsync(agentName: AGENT_NAME2).ToListAsync();
        Assert.That(recordVersions, Has.Count.EqualTo(1));
        ValidateDefinition(recordVersions[0], useExternalAgent);

        recordVersions = await agentsClient.GetAgentVersionsAsync(agentName: AGENT_NAME).ToListAsync();
        Assert.That(recordVersions, Has.Count.EqualTo(2));
        ValidateDefinition(recordVersions[0], useExternalAgent);
        // DeleteVersion
        string expectedVersion = recordVersions[1].Version;
        await agentsClient.DeleteAgentVersionAsync(agentName: AGENT_NAME, agentVersion: recordVersions[0].Version);
        recordVersions = await agentsClient.GetAgentVersionsAsync(agentName: AGENT_NAME).ToListAsync();
        Assert.That(recordVersions, Has.Count.EqualTo(1));
        Assert.That(recordVersions[0].Version, Is.EqualTo(expectedVersion));
        // Delete
        await agentsClient.DeleteAgentAsync(agentName: AGENT_NAME2);
        records = await agentsClient.GetAgentsAsync(kind: goodKind).Where(x => string.Equals(x.Name, AGENT_NAME2)).ToListAsync();
        Assert.That(records, Has.Count.EqualTo(0));
    }

    private static void ValidateDefinition(ProjectsAgentVersion agent, bool useExternalAgent)
    {
        if (useExternalAgent)
        {
            Assert.That(agent.Definition, Is.InstanceOf<ExternalAgentDefinition>());
        }
        else
        {
            Assert.That(agent.Definition, Is.InstanceOf<DeclarativeAgentDefinition>());
        }
    }

    [RecordedTest]
    public async Task TestToolboxesCRUD()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
        try
        {
            await toolboxClient.DeleteAsync("mcp1");
        }
        catch { }
        try
        {
            await toolboxClient.DeleteAsync("mcp2");
        }
        catch { }
        MCPToolboxTool tool = new(serverLabel: "api-specs")
        {
            Name = "mcp-tool",
            Description = "Test mcp tool",
            ServerUri = new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            ToolCallApprovalPolicy = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        };
        // Create
        ToolboxVersion toolBox1 = await toolboxClient.CreateVersionAsync(
            name: "mcp1",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxVersion toolBox2 = await toolboxClient.CreateVersionAsync(
            name: "mcp2",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxVersion toolBox3 = await toolboxClient.CreateVersionAsync(
            name: "mcp2",
            tools: [tool],
            description: "Example toolbox created by the azure-ai-projects sample.",
            metadata: new Dictionary<string, string> {
                {"team", "Engineers"}
            }
        );
        ToolboxRecord record = await toolboxClient.GetAsync(name: toolBox2.Name);
        Assert.That(record.Name, Is.EqualTo(toolBox3.Name));
        string newVersion = string.Equals(record.DefaultVersion, "1") ? "2" : "1";
        // Update
        record = await toolboxClient.UpdateDefaultVersionAsync(record.Name, newVersion);
        Assert.That(record.Name, Is.EqualTo(toolBox2.Name));
        Assert.That(record.DefaultVersion, Is.EqualTo(newVersion));
        // Get
        record = await toolboxClient.GetAsync("mcp2");
        Assert.That(record.Name, Is.EqualTo("mcp2"));
        Assert.That(record.DefaultVersion, Is.EqualTo(newVersion));
        // List
        HashSet<string> recordNames = [.. await toolboxClient.GetAllAsync().Select(x => x.Name).ToListAsync()];
        Assert.That(recordNames, Does.Contain("mcp1"));
        Assert.That(recordNames, Does.Contain("mcp2"));
        // Delete
        await toolboxClient.DeleteAsync("mcp1");
        recordNames = [.. await toolboxClient.GetAllAsync().Select(x => x.Name).ToListAsync()];
        Assert.That(recordNames, Does.Not.Contains("mcp1"));
        Assert.That(recordNames, Does.Contain("mcp2"));
        await toolboxClient.DeleteAsync("mcp2");
        recordNames = [.. await toolboxClient.GetAllAsync().Select(x => x.Name).ToListAsync()];
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
            await toolboxClient.DeleteAsync("mcp");
        }
        catch { }
        MCPToolboxTool tool = new(serverLabel: "api-specs")
        {
            Name = "mcp-tool",
            Description = "Test mcp tool",
            ServerUri = new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            ToolCallApprovalPolicy = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        };
        // Create
        ToolboxVersion toolBox1 = await toolboxClient.CreateVersionAsync(
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
        ToolboxVersion toolBox2 = await toolboxClient.CreateVersionAsync(
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
        ToolboxVersion toolBox = await toolboxClient.GetVersionAsync(name: "mcp", version: "1");
        Assert.That(toolBox.Name, Is.EqualTo("mcp"));
        Assert.That(toolBox.Version, Is.EqualTo("1"));
        Assert.That(toolBox.Metadata, Does.ContainKey("team"));
        Assert.That(toolBox.Metadata["team"], Is.EqualTo("Engineers"));
        // List
        List<ToolboxVersion> versions = await toolboxClient.GetVersionsAsync(name: "mcp").ToListAsync();
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
        ToolboxRecord record = await toolboxClient.GetAsync("mcp");
        string deleteVersion = string.Equals(record.DefaultVersion, toolBox1.Version) ? toolBox2.Version : toolBox1.Version;
        await toolboxClient.DeleteVersionAsync(name: "mcp", version: deleteVersion);
        HashSet<string> versionNumbers = [.. await toolboxClient.GetVersionsAsync(name: "mcp").Select(x => x.Version).ToListAsync()];
        Assert.That(versionNumbers, Does.Not.Contains(deleteVersion));
        Assert.That(versionNumbers, Does.Contain(string.Equals(deleteVersion, "2") ? "1" : "2"));
        await toolboxClient.DeleteAsync(name: record.Name);
        Assert.ThrowsAsync<ClientResultException>(async () => await toolboxClient.GetVersionsAsync(name: "mcp").ToListAsync());
    }

    [Test]
    [SyncOnly]
    public async Task TestArchiveFile()
    {
        string path = GetTestFile(GetTestFile("test.txt"));
        (BinaryData data, string sha256sum) = FileHelper.CreateAndReadZipFile(path);
        Assert.That(sha256sum, Is.Not.Null.And.Not.Empty);
        string tempDir = Path.GetTempPath();
        string tempFile = Path.Combine(tempDir, "test.txt");
        FileHelper.SaveAndUnzipData(tempDir, data);
        FileAssert.Exists(tempFile);
        try
        {
            FileAssert.AreEqual(path, tempFile);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }

    [Test]
    [SyncOnly]
    public async Task TestArchiveDirectory()
    {
        string path = GetTestFile(GetTestFile("roll-dice"));
        BinaryData data = FileHelper.CreateAndReadZipFileFromDirectory(path);
        string tempDir = Path.GetTempPath();
        string expectedPath = Path.Combine(tempDir, "sample-skill");
        try
        {
            Directory.Delete(expectedPath, true);
        }
        catch { }
        FileHelper.SaveAndUnzipData(expectedPath, data);
        Assert.That(expectedPath, Does.Exist);
        Assert.That(File.GetAttributes(expectedPath) & FileAttributes.Directory, Is.EqualTo(FileAttributes.Directory));
        try
        {
            string skill = Path.Combine(expectedPath, "SKILL.md");
            Assert.That(skill, Does.Exist);
            FileAssert.AreEqual(Path.Combine(path, "SKILL.md"), skill);
            Assert.That(Path.Combine(expectedPath, "references"), Does.Exist);
            string sampleReference = Path.Combine(expectedPath, "references", "sample.md");
            Assert.That(sampleReference, Does.Exist);
            FileAssert.AreEqual(Path.Combine(path, "references", "sample.md"), sampleReference);
        }
        finally
        {
            Directory.Delete(expectedPath, true);
        }
    }

    [RecordedTest]
    [TestCase(ToolType.CodeInterpreter)]
    [TestCase(ToolType.CodeInterpreterGen)]
    [TestCase(ToolType.FileSearch)]
    [TestCase(ToolType.WebSearch)]
    [TestCase(ToolType.AzureAISearch)]
    [TestCase(ToolType.OpenAPI)]
    [TestCase(ToolType.A2A)]
    [TestCase(ToolType.MCP)]
    [TestCase(ToolType.BrowserAutomation)]
    [TestCase(ToolType.WorkIQ)]
    [TestCase(ToolType.FabricIQ)]
    [TestCase(ToolType.ReminderPreview)]
    public async Task TestToolsetVariety(ToolType toolType)
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
        ToolboxTool tool = GetAgentToolDefinition(toolType);
        ToolboxVersion toolBox = await toolboxClient.CreateVersionAsync(
            name: TOOLBOX,
            tools: [tool],
            description: $"{toolType}"
        );
        Assert.That(toolBox.Name, Is.EqualTo(TOOLBOX));
        Assert.That(toolBox.Description, Is.EqualTo($"{toolType}"));
        Assert.That(toolBox.Tools.Count, Is.EqualTo(1));
        Assert.That(toolBox.Tools[0].GetType(), Is.EqualTo(tool.GetType()));
        toolBox = await toolboxClient.GetVersionAsync(name: TOOLBOX, version: toolBox.Version);
        Assert.That(toolBox.Name, Is.EqualTo(TOOLBOX));
        Assert.That(toolBox.Description, Is.EqualTo($"{toolType}"));
        Assert.That(toolBox.Tools.Count, Is.EqualTo(1));
        Assert.That(toolBox.Tools[0].GetType(), Is.EqualTo(tool.GetType()));
        // Use the tool to create an Agent
        DeclarativeAgentDefinition definition = new(TestEnvironment.FOUNDRY_MODEL_NAME)
        {
            Tools = { ProjectsAgentTool.AsProjectTool(toolBox.Tools[0]) }
        };
        ProjectsAgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, new ProjectsAgentVersionCreationOptions(definition));
        if (agentVersion.Definition is DeclarativeAgentDefinition declarativeDefinition)
        {
            Assert.That(declarativeDefinition.Tools, Has.Count.EqualTo(1));
            Assert.That(declarativeDefinition.Tools[0].GetType(), Is.EqualTo(((ResponseTool)ProjectsAgentTool.AsProjectTool(toolBox.Tools[0])).GetType()));
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
        List<ToolboxRecord> records = await toolboxClient.GetAllAsync().ToListAsync();
        int created = 0;
        MCPToolboxTool tool = new(serverLabel: "api-specs")
        {
            Name = "mcp-tool",
            Description = "Test MCP tool",
            ServerUri = new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            ToolCallApprovalPolicy = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        };
        while (records.Count + created <= PAGE_SIZE)
        {
            await toolboxClient.CreateVersionAsync(
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
        records = await toolboxClient.GetAllAsync(limit: PAGE_SIZE, order: AgentListOrder.Ascending).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(newSize));
        // Go forward.
        List<ToolboxRecord> forward = await toolboxClient.GetAllAsync(order: AgentListOrder.Ascending, after: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[forward.Count - 1].Id, Is.EqualTo(records[records.Count - 1].Id));
        // Two limits:
        forward = await toolboxClient.GetAllAsync(order: AgentListOrder.Ascending, after: records[0].Id, before: records[3].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(2));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[1].Id, Is.EqualTo(records[2].Id));
        // Go backwards.
        List<ToolboxRecord> backwards = await toolboxClient.GetAllAsync(order: AgentListOrder.Descending, before: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 1].Id));
        Assert.That(backwards[backwards.Count - 1].Id, Is.EqualTo(records[1].Id));
        // Two limits.
        backwards = await toolboxClient.GetAllAsync(order: AgentListOrder.Descending, after: records[records.Count -1].Id, before: records[records.Count - 4].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(2));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 2].Id));
        Assert.That(backwards[1].Id, Is.EqualTo(records[records.Count - 3].Id));
    }

    [RecordedTest]
    public async Task TestListToolboxVersions()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentToolboxes toolboxClient = agentsClient.GetAgentToolboxes();
        List<ToolboxVersion> records = await toolboxClient.GetVersionsAsync(name: TOOLBOX, order: AgentListOrder.Ascending).ToListAsync();
        int created = 0;
        MCPToolboxTool tool = new(serverLabel: "api-specs")
        {
            Name = "mcp-tool",
            Description = "Test MCP tool",
            ServerUri = new Uri("https://gitmcp.io/Azure/azure-rest-api-specs"),
            ToolCallApprovalPolicy = new McpToolCallApprovalPolicy(GlobalMcpToolCallApprovalPolicy.AlwaysRequireApproval)
        };
        while (records.Count + created <= PAGE_SIZE)
        {
            await toolboxClient.CreateVersionAsync(
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
        records = await toolboxClient.GetVersionsAsync(name: TOOLBOX, limit: PAGE_SIZE, order: AgentListOrder.Ascending).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(newSize));
        // Go forward.
        List<ToolboxVersion> forward = await toolboxClient.GetVersionsAsync(name: TOOLBOX, order: AgentListOrder.Ascending, after: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[forward.Count - 1].Id, Is.EqualTo(records[records.Count - 1].Id));
        // Two limits:
        forward = await toolboxClient.GetVersionsAsync(name: TOOLBOX, order: AgentListOrder.Ascending, after: records[0].Id, before: records[3].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(2));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[1].Id, Is.EqualTo(records[2].Id));
        // Go backwards.
        List<ToolboxVersion> backwards = await toolboxClient.GetVersionsAsync(name: TOOLBOX, order: AgentListOrder.Descending, before: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 1].Id));
        Assert.That(backwards[backwards.Count - 1].Id, Is.EqualTo(records[1].Id));
        // Two limits.
        backwards = await toolboxClient.GetVersionsAsync(name: TOOLBOX, order: AgentListOrder.Descending, after: records[records.Count - 1].Id, before: records[records.Count - 4].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(backwards.Count, Is.EqualTo(2));
        Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 2].Id));
        Assert.That(backwards[1].Id, Is.EqualTo(records[records.Count - 3].Id));
    }

    [Ignore("Blocked by the ADO Item 5384172.")]
    [RecordedTest]
    public async Task TestPatchHostedAgent()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient);
        AgentEndpointConfiguration config = new()
        {
            VersionSelector = new([new FixedRatioVersionSelectionRule(agentVersion: agentVersion.Version, trafficPercentage: 74)]),
            ProtocolConfiguration = new()
            {
                Responses = new()
            }
        };
        SkillInlineContent content = new(
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
        SkillVersion simpleSkill = await skillsClient.CreateSkillVersionAsync(name: SKILL, inlineContent: content);
        AgentCard card = new(version: "42", [new AgentCardSkill(id: simpleSkill.Id, name: SKILL)]);
        PatchAgentOptions patchOptions = new()
        {
            AgentEndpoint = config,
            AgentCard = card,
        };
        ProjectsAgentRecord patchedRecord = await agentsClient.PatchAgentAsync(
            agentName: agentVersion.Name,
            patchAgentOptions: patchOptions);
        Assert.That(patchedRecord.AgentEndpoint.ProtocolConfiguration.Responses, Is.Not.Null);
        Assert.That(patchedRecord.AgentEndpoint.ProtocolConfiguration.Invocations, Is.Null);
        Assert.That(patchedRecord.AgentEndpoint.ProtocolConfiguration.A2a, Is.Null);
        Assert.That(patchedRecord.AgentEndpoint.ProtocolConfiguration.Mcp, Is.Null);
        Assert.That(patchedRecord.AgentEndpoint.VersionSelector.VersionSelectionRules, Has.Count.EqualTo(1));
        Assert.That(patchedRecord.AgentEndpoint.VersionSelector.VersionSelectionRules[0], Is.InstanceOf(typeof(FixedRatioVersionSelectionRule)));
        Assert.That(((FixedRatioVersionSelectionRule)patchedRecord.AgentEndpoint.VersionSelector.VersionSelectionRules[0]).TrafficPercentage, Is.EqualTo(74));
        Assert.That(patchedRecord.AgentCard.Version, Is.EqualTo("42"));
        Assert.That(patchedRecord.AgentCard.Skills, Has.Count.EqualTo(1));
        Assert.That(patchedRecord.AgentCard.Skills[0].Id, Is.EqualTo(simpleSkill.Id));
    }

    [RecordedTest]
    public async Task TestSessionCRUD()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient, "01");
        // Create
        ProjectAgentSession session1 = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
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
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        Assert.That(session2.VersionIndicator, Is.InstanceOf<VersionRefIndicator>());
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
        Assert.That(session.VersionIndicator, Is.InstanceOf<VersionRefIndicator>());
        Assert.That(((VersionRefIndicator)session.VersionIndicator).AgentVersion, Is.EqualTo(agentVersion.Version));
        // List
        HashSet<string> sessions = [..await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).Select(x => x.AgentSessionId).ToListAsync()];
        Assert.That(sessions, Has.Count.EqualTo(2));
        Assert.That(sessions, Does.Contain(session1.AgentSessionId));
        Assert.That(sessions, Does.Contain(session2.AgentSessionId));
        // Delete
        await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId);
        Assert.ThrowsAsync<ClientResultException>(async () => await agentsClient.GetSessionAsync(agentName: agentVersion.Name, sessionId: session1.AgentSessionId));
        // See work item 5291142. [HostedAgentsVNext] Bug: Removed session is still being listed.
        //sessions = [.. await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).Select(x => x.AgentSessionId).ToListAsync()];
        //Assert.That(sessions, Has.Count.EqualTo(1));
        //Assert.That(sessions, Does.Not.Contain(session1.AgentSessionId));
        //Assert.That(sessions, Does.Contain(session2.AgentSessionId));
        // Workaround
        sessions = [.. await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).Where(x => x.Status == AgentSessionStatus.Active).Select(x => x.AgentSessionId).ToListAsync()];
        Assert.That(sessions, Has.Count.EqualTo(1));
        Assert.That(sessions, Does.Not.Contain(session1.AgentSessionId));
        Assert.That(sessions, Does.Contain(session2.AgentSessionId));
        sessions = [.. await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).Where(x => x.Status == AgentSessionStatus.Deleted).Select(x => x.AgentSessionId).ToListAsync()];
        Assert.That(sessions, Has.Count.EqualTo(1));
        Assert.That(sessions, Does.Not.Contain(session2.AgentSessionId));
        Assert.That(sessions, Does.Contain(session1.AgentSessionId));
        await agentsClient.DeleteSessionAsync(agentName: agentVersion.Name, sessionId: session2.AgentSessionId);
        //sessions = [.. await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).Select(x => x.AgentSessionId).ToListAsync()];
        //Assert.That(sessions, Has.Count.EqualTo(0));
        // Workaround
        sessions = [.. await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).Where(x => x.Status == AgentSessionStatus.Deleted).Select(x => x.AgentSessionId).ToListAsync()];
        Assert.That(sessions, Does.Contain(session1.AgentSessionId));
        Assert.That(sessions, Does.Contain(session2.AgentSessionId));
        sessions = [.. await agentsClient.GetSessionsAsync(agentName: agentVersion.Name).Where(x => x.Status == AgentSessionStatus.Active).Select(x => x.AgentSessionId).ToListAsync()];
        Assert.That(sessions, Has.Count.EqualTo(0));
    }

    [RecordedTest]
    public async Task TestSessionPagination()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient, "01");
        await DeleteAllSessionsAsync(agentsClient, agentVersion.Name);
        string sessionIdBase = $"session_{(IsAsync ? "async" : "sync")}_10";
        // Make sure that chronological order is the reverse of session ID alphanumeric order.
        for (int i = 0; i < PAGE_SIZE + 1; i++)
        {
            try
            {
                await agentsClient.CreateSessionAsync(
                    agentName: agentVersion.Name,
                    agentSessionId: $"{sessionIdBase}_{PAGE_SIZE - i}",
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
        await DeleteAllSessionsAsync(agentsClient, agentVersion.Name);
    }

    [RecordedTest]
    public async Task TestSessionLogs()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient, "01");
        string sessionName = IsAsync ? "session_async_12345679" : "session_sync_12345679";
        try
        {
            ProjectAgentSession session = await agentsClient.CreateSessionAsync(
                agentName: agentVersion.Name,
                agentSessionId: sessionName,
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
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient, "01");
        ProjectAgentSession session = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        AgentSessionFiles filesClient = agentsClient.GetAgentSessionFiles(agentVersion.Name, session.AgentSessionId);
        string fileLocalPath = GetTestFile("weather_openapi.json");
        string file1 = "file1.json", file2 = "file2.json";
        int fileLength = File.ReadAllBytes(fileLocalPath).Length;
        //Create
        SessionFileWriteResponse writeResponse = await filesClient.UploadAsync(
            sessionStoragePath: $"storage/{file1}",
            localPath: fileLocalPath
        );
        Assert.That(writeResponse.Path, Is.EqualTo($"storage/{file1}"));
        Assert.That(writeResponse.BytesWritten, Is.EqualTo(fileLength));
        fileLocalPath = GetTestFile("test.txt");
        fileLength = File.ReadAllBytes(fileLocalPath).Length;
        writeResponse = await filesClient.UploadAsync(
            sessionStoragePath: $"storage/{file2}",
            localPath: fileLocalPath
        );
        Assert.That(writeResponse.Path, Is.EqualTo($"storage/{file2}"));
        Assert.That(writeResponse.BytesWritten, Is.EqualTo(fileLength));
        // List
        AsyncCollectionResult<SessionDirectoryEntry> response = filesClient.GetAllAsync(sessionStoragePath: "storage");
        List<string> lstEntries = await response.Select(x => x.Name).ToListAsync();
        Assert.That(lstEntries, Does.Contain(file1));
        Assert.That(lstEntries, Does.Contain(file2));
        // Download
        string temporaryFile = Path.GetTempFileName();
        File.Delete(temporaryFile);
        BinaryData dataBin = await filesClient.DownloadAsync(
            sessionStoragePath: $"storage/{file2}",
            localPath: temporaryFile
        );
        string data = File.ReadAllText(temporaryFile);
        Assert.That(data, Is.EqualTo("The test file\n"));
        data = dataBin.ToString();
        Assert.That(data, Is.EqualTo("The test file\n"));
        // Delete
        await filesClient.DeleteAsync(localPath: $"storage/{file2}");
        response = filesClient.GetAllAsync(sessionStoragePath: "storage");
        lstEntries = await response.Select(x => x.Name).ToListAsync();
        Assert.That(lstEntries, Has.Count.EqualTo(1));
        Assert.That(lstEntries[0], Is.EqualTo(file1));
        await filesClient.DeleteAsync(localPath: $"storage/{file1}");
        response = filesClient.GetAllAsync(sessionStoragePath: "storage");
        Assert.That(await response.ToListAsync(), Has.Count.EqualTo(0));
        await agentsClient.DeleteSessionAsync(
            agentName: agentVersion.Name,
            sessionId: session.AgentSessionId
        );
    }

    [RecordedTest]
    public async Task TestSessionFilePagination()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectsAgentVersion agentVersion = await CreateHostedAgent(agentsClient, "01");
        ProjectAgentSession session = await agentsClient.CreateSessionAsync(
            agentName: agentVersion.Name,
            versionIndicator: new VersionRefIndicator(agentVersion.Version)
        );
        AgentSessionFiles filesClient = agentsClient.GetAgentSessionFiles(agentVersion.Name, session.AgentSessionId);
        string fileLocalPath = GetTestFile("test.txt");
        int fileLength = File.ReadAllBytes(fileLocalPath).Length;
        // Make sure that chronological order is the reverse of session ID alphanumeric order.
        for (int i = 0; i < PAGE_SIZE + 1; i++)
        {
            SessionFileWriteResponse writeResponse = await filesClient.UploadAsync(
                sessionStoragePath: $"storage/file{i}.json",
                localPath: fileLocalPath
            );
            Assert.That(writeResponse.Path, Is.EqualTo($"storage/file{i}.json"));
            Assert.That(writeResponse.BytesWritten, Is.EqualTo(fileLength));
        }
        List<SessionDirectoryEntry> records = await filesClient.GetAllAsync(sessionStoragePath: "storage", limit: PAGE_SIZE, order: AgentListOrder.Ascending).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(PAGE_SIZE + 1));
        // Go forward.
        //List<SessionDirectoryEntry> forward = await filesClient.GetSessionFilesAsync(agentName: agentVersion.Name, agentSessionId: session.AgentSessionId, sessionStoragePath: "storage", order: AgentListOrder.Ascending, after: records[0].Name, limit: PAGE_SIZE).ToListAsync();
        //Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        //Assert.That(forward[0].Name, Is.EqualTo(records[1].Name));
        //Assert.That(forward[forward.Count - 1].Name, Is.EqualTo(records[records.Count - 1].Name));
        //// Two limits:
        //forward = await filesClient.GetSessionFilesAsync(agentName: agentVersion.Name, agentSessionId: session.AgentSessionId, sessionStoragePath: "storage", order: AgentListOrder.Ascending, after: records[0].Name, before: records[3].Name, limit: PAGE_SIZE).ToListAsync();
        //Assert.That(forward.Count, Is.EqualTo(2));
        //Assert.That(forward[0].Name, Is.EqualTo(records[1].Name));
        //Assert.That(forward[1].Name, Is.EqualTo(records[2].Name));
        //// Go backwards.
        //List<SessionDirectoryEntry> backwards = await filesClient.GetSessionFilesAsync(agentName: agentVersion.Name, agentSessionId: session.AgentSessionId, sessionStoragePath: "storage", order: AgentListOrder.Descending, before: records[0].Name, limit: PAGE_SIZE).ToListAsync();
        //Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        //Assert.That(backwards[0].Name, Is.EqualTo(records[records.Count - 1].Name));
        //Assert.That(backwards[backwards.Count - 1].Name, Is.EqualTo(records[1].Name));
        //// Two limits.
        //backwards = await filesClient.GetSessionFilesAsync(agentName: agentVersion.Name, agentSessionId: session.AgentSessionId, sessionStoragePath: "storage", order: AgentListOrder.Descending, after: records[records.Count - 1].Name, before: records[records.Count - 4].Name, limit: PAGE_SIZE).ToListAsync();
        //Assert.That(backwards.Count, Is.EqualTo(2));
        //Assert.That(backwards[0].Name, Is.EqualTo(records[records.Count - 2].Name));
        //Assert.That(backwards[1].Name, Is.EqualTo(records[records.Count - 3].Name));
    }

    [LiveOnly]
    [Test]
    public async Task TestSkillFromFile()
    {
        // Creating archive is not deterministic.
        AgentAdministrationClient agentsClient = GetTestClient();
        ProjectAgentSkills skillsClient = agentsClient.GetAgentSkills();
        string fileSkillName = $"{SKILL}_file";
        AgentsSkill skillFromFile = await skillsClient.CreateSkillVersionFromFilesAsync("roll-dice", GetTestFile("roll-dice"));
        Assert.That(skillFromFile.Name, Is.EqualTo("roll-dice"));
        Assert.That(skillFromFile.Description, Is.EqualTo("Roll dice using a random number generator."));
        string savePath = Path.Combine(Path.GetTempPath(), "saved_skill");
        try
        {
            Directory.Delete(savePath, true);
        }
        catch { }
        BinaryData data = await skillsClient.GetSkillContentAsync(skillFromFile.Name, savePath);
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
        string codeSkillName = $"{SKILL}-code", codeSkillName2 = $"{SKILL}-code2";
        await foreach (AgentsSkill skill1 in skillsClient.GetSkillsAsync())
        {
            if (skill1.Name.StartsWith(SKILL))
            {
                await skillsClient.DeleteSkillAsync(skill1.Name);
            }
        }
        SkillInlineContent content = new(
            description: "Calculates the sum of two numbers.",
            instructions: """
                To calculate the sum run
                ```bash
                echo $((<first> + <second>))
                ```
                ```powershell
                (<first> + <second>)
                ```
                Replace <first> and <second> by the actual summation arguments.
                """
        );
        SkillVersion skillFromCode = await skillsClient.CreateSkillVersionAsync(name: codeSkillName, inlineContent: content);
        string oldVersion = skillFromCode.Version;
        Assert.That(skillFromCode.Name, Is.EqualTo(codeSkillName));
        Assert.That(skillFromCode.Description, Is.EqualTo("Calculates the sum of two numbers."));
        content = new(
            description: "Divides one number by the other.",
            instructions: """
            To calculate the division run
            ```bash
            echo $((<first> / <second>))
            ```
            ```powershell
            (<first> + <second>)
            ```
            Replace <first> and <second> by the actual division arguments.
            """
        );
        SkillVersion skillFromCode2 = await skillsClient.CreateSkillVersionAsync(name: codeSkillName2, inlineContent: content);
        Assert.That(skillFromCode2.Name, Is.EqualTo(codeSkillName2));
        Assert.That(skillFromCode2.Description, Is.EqualTo("Divides one number by the other."));
        // Update
        content = new(
            description: "Calculates the product of two numbers.",
            instructions: """
                To calculate the multiplication run
                ```bash
                echo $((<first> * <second>))
                ```
                ```powershell
                (<first> * <second>)
                ```
                Replace <first> and <second> by the actual multiplication arguments.
                """
        );
        SkillVersion updatedVersion = await skillsClient.CreateSkillVersionAsync(name: codeSkillName, inlineContent: content);
        AgentsSkill skill = await skillsClient.UpdateDefaultVersionAsync(name: codeSkillName, defaultVersion: updatedVersion.Version);
        Assert.That(skill.Name, Is.EqualTo(codeSkillName));
        Assert.That(skill.Description, Is.EqualTo("Calculates the product of two numbers."));
        skill = await skillsClient.UpdateDefaultVersionAsync(name: codeSkillName, defaultVersion: oldVersion);
        Assert.That(skill.Name, Is.EqualTo(codeSkillName));
        Assert.That(skill.Description, Is.EqualTo("Calculates the sum of two numbers."));
        await skillsClient.UpdateDefaultVersionAsync(name: codeSkillName, defaultVersion: updatedVersion.Version);
        // Get
        AgentsSkill retrievedSkill = await skillsClient.GetSkillAsync(name: codeSkillName);
        Assert.That(retrievedSkill.Name, Is.EqualTo(codeSkillName));
        Assert.That(retrievedSkill.Description, Is.EqualTo("Calculates the product of two numbers."));
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
        SkillInlineContent contrent = new(
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
        for (int i = 0; i < PAGE_SIZE + 1; i++)
        {
            await skillsClient.CreateSkillVersionAsync(
                name: $"{SKILL}-{i}",
                inlineContent: contrent
            );
        }
        List<AgentsSkill> records = await skillsClient.GetSkillsAsync(limit: PAGE_SIZE, order: AgentListOrder.Ascending).ToListAsync();
        Assert.That(records.Count, Is.EqualTo(PAGE_SIZE + 1 + initialCount));
        // Go forward.
        List<AgentsSkill> forward = await skillsClient.GetSkillsAsync(order: AgentListOrder.Ascending, after: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(records.Count - 1));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[forward.Count - 1].Id, Is.EqualTo(records[records.Count - 1].Id));
        // Two limits:
        forward = await skillsClient.GetSkillsAsync(order: AgentListOrder.Ascending, after: records[0].Id, before: records[3].Id, limit: PAGE_SIZE).ToListAsync();
        Assert.That(forward.Count, Is.EqualTo(2));
        Assert.That(forward[0].Id, Is.EqualTo(records[1].Id));
        Assert.That(forward[1].Id, Is.EqualTo(records[2].Id));
        // Blocked by work item 5312533
        // Go backwards.
        //List<AgentsSkill> backwards = await skillsClient.GetSkillsAsync(order: AgentListOrder.Descending, before: records[0].Id, limit: PAGE_SIZE).ToListAsync();
        //Assert.That(backwards.Count, Is.EqualTo(records.Count - 1));
        //Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 1].Id));
        //Assert.That(backwards[backwards.Count - 1].Id, Is.EqualTo(records[1].Id));
        // Two limits.
        //List<AgentsSkill> backwards = await skillsClient.GetSkillsAsync(order: AgentListOrder.Descending, after: records[records.Count - 1].Id, before: records[records.Count - 4].Id, limit: PAGE_SIZE).ToListAsync();
        //Assert.That(backwards.Count, Is.EqualTo(2));
        //Assert.That(backwards[0].Id, Is.EqualTo(records[records.Count - 2].Id));
        //Assert.That(backwards[1].Id, Is.EqualTo(records[records.Count - 3].Id));
    }

    #region Helpers
    public static async Task DeleteAllSessionsAsync(AgentAdministrationClient agentsClient, string agentName)
    {
        List<string> sessions = await agentsClient.GetSessionsAsync(agentName: agentName).Select(x => x.AgentSessionId).ToListAsync();
        foreach (string session in sessions)
        {
            await agentsClient.DeleteSessionAsync(
                agentName: agentName,
                sessionId: session
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
            ContainerConfiguration = new(TestEnvironment.AGENT_DOCKER_IMAGE)
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
