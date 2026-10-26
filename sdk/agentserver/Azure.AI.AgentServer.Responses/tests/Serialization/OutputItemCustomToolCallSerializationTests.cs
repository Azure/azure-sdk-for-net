// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.AI.AgentServer.Responses.Models;
using Azure.AI.Extensions.OpenAI;
using CallStatus = Azure.AI.AgentServer.Responses.Models.FunctionCallStatus;

namespace Azure.AI.AgentServer.Responses.Tests.Serialization;

/// <summary>
/// The custom tool call items are generated from the spec, so the base type (OpenAI's ResponseItem) owns
/// <c>type</c> and <c>id</c> while the Azure attribution fields (<c>response_id</c>, <c>agent_reference</c>
/// and <c>created_by</c>) live on the item's JsonPatch. These tests pin that every field is written exactly
/// once and survives a round trip.
/// </summary>
public class OutputItemCustomToolCallSerializationTests
{
    private const string CreatedByJson = """{"agent":{"type":"agent_id","name":"my-agent","version":"3"},"response_id":"resp_1"}""";

    private const string CustomToolCallJson = """
        {
          "type": "custom_tool_call",
          "id": "ctc_123",
          "call_id": "call_123",
          "caller": { "type": "program", "caller_id": "prog_1" },
          "namespace": "tools",
          "name": "run_script",
          "input": "print('hi')",
          "async": true,
          "status": "in_progress",
          "created_by": { "agent": { "type": "agent_id", "name": "my-agent", "version": "3" }, "response_id": "resp_1" },
          "agent_reference": { "type": "agent_reference", "name": "my-agent", "version": "3" },
          "response_id": "resp_1"
        }
        """;

    private const string CustomToolCallOutputJson = """
        {
          "type": "custom_tool_call_output",
          "id": "ctco_123",
          "call_id": "call_123",
          "caller": { "type": "direct" },
          "output": "done",
          "status": "completed",
          "created_by": { "agent": { "type": "agent_id", "name": "my-agent", "version": "3" }, "response_id": "resp_1" },
          "agent_reference": { "type": "agent_reference", "name": "my-agent", "version": "3" },
          "response_id": "resp_1"
        }
        """;

    private static readonly string[] CustomToolCallProperties =
    [
        "type", "id", "call_id", "caller", "namespace", "name", "input", "async", "status",
        "created_by", "agent_reference", "response_id",
    ];

    private static readonly string[] CustomToolCallOutputProperties =
    [
        "type", "id", "call_id", "caller", "output", "status",
        "created_by", "agent_reference", "response_id",
    ];

    // ========================================
    // OutputItemCustomToolCall
    // ========================================

    [Test]
    public void CustomToolCall_Write_EmitsEveryPropertyExactlyOnce()
    {
        var item = CreateCustomToolCall();

        using var document = Write(item);
        var root = document.RootElement;

        AssertEachPropertyWrittenOnce(root, CustomToolCallProperties);
        Assert.Multiple(() =>
        {
            Assert.That(root.GetProperty("type").GetString(), Is.EqualTo("custom_tool_call"));
            Assert.That(root.GetProperty("id").GetString(), Is.EqualTo("ctc_123"));
            Assert.That(root.GetProperty("call_id").GetString(), Is.EqualTo("call_123"));
            Assert.That(root.GetProperty("caller").GetProperty("caller_id").GetString(), Is.EqualTo("prog_1"));
            Assert.That(root.GetProperty("namespace").GetString(), Is.EqualTo("tools"));
            Assert.That(root.GetProperty("name").GetString(), Is.EqualTo("run_script"));
            Assert.That(root.GetProperty("input").GetString(), Is.EqualTo("print('hi')"));
            Assert.That(root.GetProperty("async").GetBoolean(), Is.True);
            Assert.That(root.GetProperty("status").GetString(), Is.EqualTo("in_progress"));
            Assert.That(root.GetProperty("response_id").GetString(), Is.EqualTo("resp_1"));
            Assert.That(root.GetProperty("agent_reference").GetProperty("name").GetString(), Is.EqualTo("my-agent"));
            Assert.That(root.GetProperty("agent_reference").GetProperty("version").GetString(), Is.EqualTo("3"));
            Assert.That(root.GetProperty("created_by").GetProperty("response_id").GetString(), Is.EqualTo("resp_1"));
        });
    }

    [Test]
    public void CustomToolCall_Write_WithoutOptionalFields_OmitsThem()
    {
        var item = new OutputItemCustomToolCall("call_123", "run_script", "print('hi')", CallStatus.Completed);

        using var document = Write(item);

        AssertEachPropertyWrittenOnce(document.RootElement, "type", "call_id", "name", "input", "status");
        Assert.That(document.RootElement.GetProperty("status").GetString(), Is.EqualTo("completed"));
    }

    [Test]
    public void CustomToolCall_Read_PopulatesEveryProperty()
    {
        var item = ModelReaderWriter.Read<OutputItemCustomToolCall>(
            BinaryData.FromString(CustomToolCallJson),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;

        Assert.Multiple(() =>
        {
            Assert.That(item.Id, Is.EqualTo("ctc_123"));
            Assert.That(item.CallId, Is.EqualTo("call_123"));
            Assert.That(item.Caller, Is.InstanceOf<ProgramToolCallCaller>());
            Assert.That(((ProgramToolCallCaller)item.Caller).CallerId, Is.EqualTo("prog_1"));
            Assert.That(item.Namespace, Is.EqualTo("tools"));
            Assert.That(item.Name, Is.EqualTo("run_script"));
            Assert.That(item.Input, Is.EqualTo("print('hi')"));
            Assert.That(item.Async, Is.True);
            Assert.That(item.Status, Is.EqualTo(CallStatus.InProgress));
            Assert.That(item.ResponseId, Is.EqualTo("resp_1"));
            Assert.That(item.AgentReference?.Name, Is.EqualTo("my-agent"));
            Assert.That(item.AgentReference?.Version, Is.EqualTo("3"));
            Assert.That(item.CreatedBy?.ToString(), Does.Contain("\"response_id\":\"resp_1\"").Or.Contain("\"response_id\": \"resp_1\""));
        });
    }

    [Test]
    public void CustomToolCall_RoundTrip_PreservesEveryProperty()
    {
        var item = ModelReaderWriter.Read<OutputItemCustomToolCall>(
            BinaryData.FromString(CustomToolCallJson),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;

        using var first = Write(item);
        AssertEachPropertyWrittenOnce(first.RootElement, CustomToolCallProperties);
        AssertSameJson(CustomToolCallJson, first.RootElement);

        var reread = ModelReaderWriter.Read<OutputItemCustomToolCall>(
            BinaryData.FromString(first.RootElement.GetRawText()),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;
        using var second = Write(reread);

        AssertSameJson(first.RootElement.GetRawText(), second.RootElement);
    }

    [Test]
    public void CustomToolCall_RoundTrip_PreservesUnknownProperties()
    {
        var json = CustomToolCallJson.Replace("\"type\": \"custom_tool_call\",", "\"type\": \"custom_tool_call\", \"x_unknown\": { \"a\": 1 },");
        var item = ModelReaderWriter.Read<OutputItemCustomToolCall>(
            BinaryData.FromString(json),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;

        using var document = Write(item);

        AssertEachPropertyWrittenOnce(document.RootElement, [.. CustomToolCallProperties, "x_unknown"]);
        Assert.That(document.RootElement.GetProperty("x_unknown").GetProperty("a").GetInt32(), Is.EqualTo(1));
    }

    [Test]
    public void CustomToolCall_Read_NullAgentReference_LeavesItUnset()
    {
        var json = CustomToolCallJson.Replace(
            "\"agent_reference\": { \"type\": \"agent_reference\", \"name\": \"my-agent\", \"version\": \"3\" },",
            "\"agent_reference\": null,");

        var item = ModelReaderWriter.Read<OutputItemCustomToolCall>(
            BinaryData.FromString(json),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;

        Assert.That(item.AgentReference, Is.Null);
        using var document = Write(item);
        Assert.That(document.RootElement.EnumerateObject().Select(p => p.Name), Does.Not.Contain("agent_reference"));
    }

    [Test]
    public void CustomToolCall_SystemTextJsonConverter_RoundTrips()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new TypeSpecModelConverterFactory());

        var item = JsonSerializer.Deserialize<OutputItemCustomToolCall>(CustomToolCallJson, options)!;
        var json = JsonSerializer.Serialize(item, options);

        using var document = JsonDocument.Parse(json);
        AssertEachPropertyWrittenOnce(document.RootElement, CustomToolCallProperties);
        AssertSameJson(CustomToolCallJson, document.RootElement);
    }

    // ========================================
    // OutputItemCustomToolCallOutput
    // ========================================

    [Test]
    public void CustomToolCallOutput_Write_EmitsEveryPropertyExactlyOnce()
    {
        var item = CreateCustomToolCallOutput();

        using var document = Write(item);
        var root = document.RootElement;

        AssertEachPropertyWrittenOnce(root, CustomToolCallOutputProperties);
        Assert.Multiple(() =>
        {
            Assert.That(root.GetProperty("type").GetString(), Is.EqualTo("custom_tool_call_output"));
            Assert.That(root.GetProperty("id").GetString(), Is.EqualTo("ctco_123"));
            Assert.That(root.GetProperty("call_id").GetString(), Is.EqualTo("call_123"));
            Assert.That(root.GetProperty("caller").GetProperty("type").GetString(), Is.EqualTo("direct"));
            Assert.That(root.GetProperty("output").GetString(), Is.EqualTo("done"));
            Assert.That(root.GetProperty("status").GetString(), Is.EqualTo("completed"));
            Assert.That(root.GetProperty("response_id").GetString(), Is.EqualTo("resp_1"));
            Assert.That(root.GetProperty("agent_reference").GetProperty("name").GetString(), Is.EqualTo("my-agent"));
            Assert.That(root.GetProperty("agent_reference").GetProperty("version").GetString(), Is.EqualTo("3"));
            Assert.That(root.GetProperty("created_by").GetProperty("response_id").GetString(), Is.EqualTo("resp_1"));
        });
    }

    [Test]
    public void CustomToolCallOutput_Write_WithoutOptionalFields_OmitsThem()
    {
        var item = new OutputItemCustomToolCallOutput("call_123", BinaryData.FromString("\"done\""), FunctionCallOutputStatusEnum.Incomplete);

        using var document = Write(item);

        AssertEachPropertyWrittenOnce(document.RootElement, "type", "call_id", "output", "status");
        Assert.That(document.RootElement.GetProperty("status").GetString(), Is.EqualTo("incomplete"));
    }

    [Test]
    public void CustomToolCallOutput_Read_PopulatesEveryProperty()
    {
        var item = ModelReaderWriter.Read<OutputItemCustomToolCallOutput>(
            BinaryData.FromString(CustomToolCallOutputJson),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;

        Assert.Multiple(() =>
        {
            Assert.That(item.Id, Is.EqualTo("ctco_123"));
            Assert.That(item.CallId, Is.EqualTo("call_123"));
            Assert.That(item.Caller, Is.InstanceOf<DirectToolCallCallerParam>());
            Assert.That(item.Output.ToString(), Is.EqualTo("\"done\""));
            Assert.That(item.Status, Is.EqualTo(FunctionCallOutputStatusEnum.Completed));
            Assert.That(item.ResponseId, Is.EqualTo("resp_1"));
            Assert.That(item.AgentReference?.Name, Is.EqualTo("my-agent"));
            Assert.That(item.AgentReference?.Version, Is.EqualTo("3"));
            Assert.That(item.CreatedBy?.ToString(), Does.Contain("\"response_id\":\"resp_1\"").Or.Contain("\"response_id\": \"resp_1\""));
        });
    }

    [Test]
    public void CustomToolCallOutput_RoundTrip_PreservesEveryProperty()
    {
        var item = ModelReaderWriter.Read<OutputItemCustomToolCallOutput>(
            BinaryData.FromString(CustomToolCallOutputJson),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;

        using var first = Write(item);
        AssertEachPropertyWrittenOnce(first.RootElement, CustomToolCallOutputProperties);
        AssertSameJson(CustomToolCallOutputJson, first.RootElement);

        var reread = ModelReaderWriter.Read<OutputItemCustomToolCallOutput>(
            BinaryData.FromString(first.RootElement.GetRawText()),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;
        using var second = Write(reread);

        AssertSameJson(first.RootElement.GetRawText(), second.RootElement);
    }

    [Test]
    public void CustomToolCallOutput_RoundTrip_PreservesUnknownProperties()
    {
        var json = CustomToolCallOutputJson.Replace("\"type\": \"custom_tool_call_output\",", "\"type\": \"custom_tool_call_output\", \"x_unknown\": { \"a\": 1 },");
        var item = ModelReaderWriter.Read<OutputItemCustomToolCallOutput>(
            BinaryData.FromString(json),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;

        using var document = Write(item);

        AssertEachPropertyWrittenOnce(document.RootElement, [.. CustomToolCallOutputProperties, "x_unknown"]);
        Assert.That(document.RootElement.GetProperty("x_unknown").GetProperty("a").GetInt32(), Is.EqualTo(1));
    }

    [Test]
    public void CustomToolCallOutput_Read_NullAgentReference_LeavesItUnset()
    {
        var json = CustomToolCallOutputJson.Replace(
            "\"agent_reference\": { \"type\": \"agent_reference\", \"name\": \"my-agent\", \"version\": \"3\" },",
            "\"agent_reference\": null,");

        var item = ModelReaderWriter.Read<OutputItemCustomToolCallOutput>(
            BinaryData.FromString(json),
            ModelReaderWriterOptions.Json,
            AzureAIAgentServerResponsesContext.Default)!;

        Assert.That(item.AgentReference, Is.Null);
        using var document = Write(item);
        Assert.That(document.RootElement.EnumerateObject().Select(p => p.Name), Does.Not.Contain("agent_reference"));
    }

    [Test]
    public void CustomToolCallOutput_SystemTextJsonConverter_RoundTrips()
    {
        var options = new JsonSerializerOptions();
        options.Converters.Add(new TypeSpecModelConverterFactory());

        var item = JsonSerializer.Deserialize<OutputItemCustomToolCallOutput>(CustomToolCallOutputJson, options)!;
        var json = JsonSerializer.Serialize(item, options);

        using var document = JsonDocument.Parse(json);
        AssertEachPropertyWrittenOnce(document.RootElement, CustomToolCallOutputProperties);
        AssertSameJson(CustomToolCallOutputJson, document.RootElement);
    }

    // ========================================
    // Helpers
    // ========================================

    private static OutputItemCustomToolCall CreateCustomToolCall()
    {
        var item = new OutputItemCustomToolCall("call_123", "run_script", "print('hi')", CallStatus.InProgress)
        {
            Id = "ctc_123",
            Caller = new ProgramToolCallCaller("prog_1"),
            Namespace = "tools",
            Async = true,
        };
        item.ResponseId = "resp_1";
        item.AgentReference = new AgentReference("my-agent", "3");
        item.CreatedBy = BinaryData.FromString(CreatedByJson);
        return item;
    }

    private static OutputItemCustomToolCallOutput CreateCustomToolCallOutput()
    {
        var item = new OutputItemCustomToolCallOutput("call_123", BinaryData.FromString("\"done\""), FunctionCallOutputStatusEnum.Completed)
        {
            Id = "ctco_123",
            Caller = new DirectToolCallCallerParam(),
        };
        item.ResponseId = "resp_1";
        item.AgentReference = new AgentReference("my-agent", "3");
        item.CreatedBy = BinaryData.FromString(CreatedByJson);
        return item;
    }

    private static JsonDocument Write<T>(T model) where T : class, IJsonModel<T>
        => JsonDocument.Parse(ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, AzureAIAgentServerResponsesContext.Default));

    // Comparing the written names as a multiset fails on both duplicated and unexpected properties.
    private static void AssertEachPropertyWrittenOnce(JsonElement root, params string[] expected)
        => Assert.That(root.EnumerateObject().Select(p => p.Name).ToArray(), Is.EquivalentTo(expected));

    private static void AssertSameJson(string expected, JsonElement actual)
    {
        using var expectedDocument = JsonDocument.Parse(expected);
        Assert.That(
            System.Text.Json.Nodes.JsonNode.DeepEquals(
                System.Text.Json.Nodes.JsonNode.Parse(expectedDocument.RootElement.GetRawText()),
                System.Text.Json.Nodes.JsonNode.Parse(actual.GetRawText())),
            Is.True,
            $"Expected: {expectedDocument.RootElement.GetRawText()}{Environment.NewLine}Actual: {actual.GetRawText()}");
    }
}
