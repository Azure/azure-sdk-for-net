// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;
using Azure.AI.AgentServer.Core.Tools.Utilities;

namespace Azure.AI.AgentServer.Core.Unit.Tests.Tools.Utilities;

public class ToolConfigurationParserTests
{
    [Test]
    public void Constructor_WithEmptyList_ReturnsEmptyLists()
    {
        var parser = new ToolConfigurationParser(new List<FoundryTool>());

        Assert.That(parser.HostedMcpTools, Is.Empty);
        Assert.That(parser.ConnectedTools, Is.Empty);
    }

    [Test]
    public void Constructor_CategorizesHostedMcpTools()
    {
        var tools = new List<FoundryTool>
        {
            new FoundryHostedMcpTool("tool1"),
            new FoundryHostedMcpTool("tool2")
        };

        var parser = new ToolConfigurationParser(tools);

        Assert.That(parser.HostedMcpTools, Has.Count.EqualTo(2));
        Assert.That(parser.ConnectedTools, Has.Count.EqualTo(0));
        Assert.That(parser.HostedMcpTools[0].Name, Is.EqualTo("tool1"));
        Assert.That(parser.HostedMcpTools[1].Name, Is.EqualTo("tool2"));
    }

    [Test]
    public void Constructor_CategorizesConnectedMcpTools()
    {
        var tools = new List<FoundryTool>
        {
            FoundryConnectedTool.Mcp("conn1"),
            FoundryConnectedTool.Mcp("conn2")
        };

        var parser = new ToolConfigurationParser(tools);

        Assert.That(parser.HostedMcpTools, Has.Count.EqualTo(0));
        Assert.That(parser.ConnectedTools, Has.Count.EqualTo(2));
        Assert.That(parser.ConnectedTools[0].ProjectConnectionId, Is.EqualTo("conn1"));
        Assert.That(parser.ConnectedTools[1].ProjectConnectionId, Is.EqualTo("conn2"));
    }

    [Test]
    public void Constructor_CategorizesConnectedA2aTools()
    {
        var tools = new List<FoundryTool>
        {
            FoundryConnectedTool.A2a("conn1"),
            FoundryConnectedTool.A2a("conn2")
        };

        var parser = new ToolConfigurationParser(tools);

        Assert.That(parser.HostedMcpTools, Has.Count.EqualTo(0));
        Assert.That(parser.ConnectedTools, Has.Count.EqualTo(2));
        Assert.That(parser.ConnectedTools[0].Protocol, Is.EqualTo(FoundryToolProtocol.A2A));
        Assert.That(parser.ConnectedTools[1].Protocol, Is.EqualTo(FoundryToolProtocol.A2A));
    }

    [Test]
    public void Constructor_CategorizesMixedTools()
    {
        var tools = new List<FoundryTool>
        {
            new FoundryHostedMcpTool("hosted1"),
            FoundryConnectedTool.Mcp("conn1"),
            new FoundryHostedMcpTool("hosted2"),
            FoundryConnectedTool.A2a("conn2")
        };

        var parser = new ToolConfigurationParser(tools);

        Assert.That(parser.HostedMcpTools, Has.Count.EqualTo(2));
        Assert.That(parser.ConnectedTools, Has.Count.EqualTo(2));
        Assert.That(parser.HostedMcpTools[0].Name, Is.EqualTo("hosted1"));
        Assert.That(parser.HostedMcpTools[1].Name, Is.EqualTo("hosted2"));
        Assert.That(parser.ConnectedTools[0].ProjectConnectionId, Is.EqualTo("conn1"));
        Assert.That(parser.ConnectedTools[1].ProjectConnectionId, Is.EqualTo("conn2"));
    }

    [Test]
    public void Constructor_PreservesToolOrder()
    {
        var tools = new List<FoundryTool>
        {
            new FoundryHostedMcpTool("z_tool"),
            new FoundryHostedMcpTool("a_tool"),
            new FoundryHostedMcpTool("m_tool")
        };

        var parser = new ToolConfigurationParser(tools);

        Assert.That(parser.HostedMcpTools[0].Name, Is.EqualTo("z_tool"));
        Assert.That(parser.HostedMcpTools[1].Name, Is.EqualTo("a_tool"));
        Assert.That(parser.HostedMcpTools[2].Name, Is.EqualTo("m_tool"));
    }
}
