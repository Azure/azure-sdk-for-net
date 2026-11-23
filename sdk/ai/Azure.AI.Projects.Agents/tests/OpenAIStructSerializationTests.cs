// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests;
#pragma warning disable AAIP001, AAIP002, OPENAI001, OPENAI002
// Properties typed as string-valued structs from the OpenAI library (for example
// RealtimeResponseStatus) must round-trip as JSON strings, not through ModelReaderWriter.
public class OpenAIStructSerializationTests
{
    [Test]
    public void VoiceResultStatusAndOutputModalitiesRoundTrip()
    {
        const string json = "{\"id\":\"resp_1\",\"object\":\"realtime.response\",\"status\":\"completed\",\"output\":[],\"output_modalities\":[\"audio\",\"text\"]}";
        VoiceResult result = ModelReaderWriter.Read<VoiceResult>(BinaryData.FromString(json));
        Assert.That(result.Status?.ToString(), Is.EqualTo("completed"));
        Assert.That(result.OutputModalities, Has.Count.EqualTo(2));
        Assert.That(result.OutputModalities[0].ToString(), Is.EqualTo("audio"));
        Assert.That(ModelReaderWriter.Write(result).ToString(), Is.EqualTo(json));
    }

    [Test]
    public void SemanticVadEagernessRoundTrips()
    {
        const string json = "{\"type\":\"semantic_vad\",\"eagerness\":\"low\"}";
        var turnDetection = (VoiceAgentSemanticVadTurnDetection)ModelReaderWriter.Read<VoiceAgentTurnDetectionConfiguration>(BinaryData.FromString(json));
        Assert.That(turnDetection.Eagerness?.ToString(), Is.EqualTo("low"));
        Assert.That(ModelReaderWriter.Write<VoiceAgentTurnDetectionConfiguration>(turnDetection).ToString(), Is.EqualTo(json));
    }

    [Test]
    public void WebSearchToolboxToolSearchContextSizeRoundTrips()
    {
        const string json = "{\"type\":\"web_search\",\"search_context_size\":\"high\"}";
        var tool = (WebSearchToolboxTool)ModelReaderWriter.Read<ToolboxTool>(BinaryData.FromString(json));
        Assert.That(tool.SearchContextSize?.ToString(), Is.EqualTo("high"));
        Assert.That(ModelReaderWriter.Write<ToolboxTool>(tool).ToString(), Is.EqualTo(json));
    }

    [Test]
    public void McpToolboxToolConnectorIdRoundTrips()
    {
        const string json = "{\"type\":\"mcp\",\"server_label\":\"x\",\"connector_id\":\"connector_gmail\"}";
        var tool = (McpToolboxTool)ModelReaderWriter.Read<ToolboxTool>(BinaryData.FromString(json));
        Assert.That(tool.ConnectorId?.ToString(), Is.EqualTo("connector_gmail"));
        Assert.That(ModelReaderWriter.Write<ToolboxTool>(tool).ToString(), Is.EqualTo(json));
    }

    [Test]
    public void ShellContainerMemoryLimitRoundTrips()
    {
        const string json = "{\"type\":\"container_auto\",\"memory_limit\":\"4g\"}";
        var environment = (ToolboxShellContainerAutoEnvironment)ModelReaderWriter.Read<ToolboxShellEnvironment>(BinaryData.FromString(json));
        Assert.That(environment.MemoryLimit?.ToString(), Is.EqualTo("4g"));
        Assert.That(ModelReaderWriter.Write<ToolboxShellEnvironment>(environment).ToString(), Is.EqualTo(json));
    }
}
