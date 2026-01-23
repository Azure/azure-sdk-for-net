// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Unit.Tests.Tools.Models;

public class FoundryConnectedToolTests
{
    [Test]
    public void Mcp_CreatesToolWithMcpProtocol()
    {
        var tool = FoundryConnectedTool.Mcp("connection123");

        Assert.That(tool.Protocol, Is.EqualTo(FoundryToolProtocol.MCP));
        Assert.That(tool.ProjectConnectionId, Is.EqualTo("connection123"));
        Assert.That(tool.Type, Is.EqualTo("mcp"));
    }

    [Test]
    public void A2a_CreatesToolWithA2aProtocol()
    {
        var tool = FoundryConnectedTool.A2a("connection456");

        Assert.That(tool.Protocol, Is.EqualTo(FoundryToolProtocol.A2A));
        Assert.That(tool.ProjectConnectionId, Is.EqualTo("connection456"));
        Assert.That(tool.Type, Is.EqualTo("a2a"));
    }

    [Test]
    public void Id_GeneratesCorrectFormatForMcp()
    {
        var tool = FoundryConnectedTool.Mcp("conn123");

        Assert.That(tool.Id, Is.EqualTo("connected:mcp:conn123"));
    }

    [Test]
    public void Id_GeneratesCorrectFormatForA2a()
    {
        var tool = FoundryConnectedTool.A2a("conn456");

        Assert.That(tool.Id, Is.EqualTo("connected:a2a:conn456"));
    }

    [Test]
    public void Source_ReturnsConnected()
    {
        var mcpTool = FoundryConnectedTool.Mcp("conn");
        var a2aTool = FoundryConnectedTool.A2a("conn");

        Assert.That(mcpTool.Source, Is.EqualTo(FoundryToolSource.CONNECTED));
        Assert.That(a2aTool.Source, Is.EqualTo(FoundryToolSource.CONNECTED));
    }

    [Test]
    public void Constructor_WithNullProjectConnectionId_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new FoundryConnectedTool(FoundryToolProtocol.MCP, null!));
    }

    [Test]
    public void Constructor_WithAdditionalProperties_PreservesProperties()
    {
        var additionalProperties = new Dictionary<string, object?>
        {
            { "custom_key", "custom_value" },
            { "number_key", 42 }
        };

        var tool = FoundryConnectedTool.Mcp("conn123", additionalProperties);

        Assert.That(tool.AdditionalProperties, Is.Not.Null);
        Assert.That(tool.AdditionalProperties!["custom_key"], Is.EqualTo("custom_value"));
        Assert.That(tool.AdditionalProperties!["number_key"], Is.EqualTo(42));
    }

    [Test]
    public void RecordEquality_WithSameValues_AreEqual()
    {
        var tool1 = FoundryConnectedTool.Mcp("conn123");
        var tool2 = FoundryConnectedTool.Mcp("conn123");

        Assert.That(tool1, Is.EqualTo(tool2));
    }

    [Test]
    public void RecordEquality_WithDifferentValues_AreNotEqual()
    {
        var tool1 = FoundryConnectedTool.Mcp("conn123");
        var tool2 = FoundryConnectedTool.Mcp("conn456");

        Assert.That(tool1, Is.Not.EqualTo(tool2));
    }

    [Test]
    public void RecordEquality_WithDifferentProtocols_AreNotEqual()
    {
        var mcpTool = FoundryConnectedTool.Mcp("conn123");
        var a2aTool = FoundryConnectedTool.A2a("conn123");

        Assert.That(mcpTool, Is.Not.EqualTo(a2aTool));
    }
}
