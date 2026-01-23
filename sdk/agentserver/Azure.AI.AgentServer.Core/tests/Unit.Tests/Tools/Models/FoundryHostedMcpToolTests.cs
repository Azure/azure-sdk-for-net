// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tools.Models;

namespace Azure.AI.AgentServer.Core.Unit.Tests.Tools.Models;

public class FoundryHostedMcpToolTests
{
    [Test]
    public void Constructor_CreatesToolWithCorrectName()
    {
        var tool = new FoundryHostedMcpTool("bing_search");

        Assert.That(tool.Name, Is.EqualTo("bing_search"));
    }

    [Test]
    public void Create_CreatesToolWithCorrectName()
    {
        var tool = FoundryHostedMcpTool.Create("my_tool");

        Assert.That(tool.Name, Is.EqualTo("my_tool"));
    }

    [Test]
    public void Id_GeneratesCorrectFormat()
    {
        var tool = new FoundryHostedMcpTool("my_tool");

        Assert.That(tool.Id, Is.EqualTo("hosted_mcp:my_tool"));
    }

    [Test]
    public void Source_ReturnsHostedMcp()
    {
        var tool = new FoundryHostedMcpTool("tool");

        Assert.That(tool.Source, Is.EqualTo(FoundryToolSource.HOSTED_MCP));
    }

    [Test]
    public void Constructor_WithNullName_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new FoundryHostedMcpTool(null!));
    }

    [Test]
    public void Constructor_WithAdditionalProperties_PreservesProperties()
    {
        var additionalProperties = new Dictionary<string, object?>
        {
            { "config_key", "config_value" },
            { "enabled", true }
        };

        var tool = new FoundryHostedMcpTool("test_tool", additionalProperties);

        Assert.That(tool.AdditionalProperties, Is.Not.Null);
        Assert.That(tool.AdditionalProperties!["config_key"], Is.EqualTo("config_value"));
        Assert.That(tool.AdditionalProperties!["enabled"], Is.EqualTo(true));
    }

    [Test]
    public void RecordEquality_WithSameValues_AreEqual()
    {
        var tool1 = new FoundryHostedMcpTool("test_tool");
        var tool2 = new FoundryHostedMcpTool("test_tool");

        Assert.That(tool1, Is.EqualTo(tool2));
    }

    [Test]
    public void RecordEquality_WithDifferentNames_AreNotEqual()
    {
        var tool1 = new FoundryHostedMcpTool("tool1");
        var tool2 = new FoundryHostedMcpTool("tool2");

        Assert.That(tool1, Is.Not.EqualTo(tool2));
    }

    [Test]
    public void Create_WithAdditionalProperties_PreservesProperties()
    {
        var additionalProperties = new Dictionary<string, object?>
        {
            { "key", "value" }
        };

        var tool = FoundryHostedMcpTool.Create("test", additionalProperties);

        Assert.That(tool.AdditionalProperties, Is.Not.Null);
        Assert.That(tool.AdditionalProperties!["key"], Is.EqualTo("value"));
    }
}
