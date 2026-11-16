// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using NUnit.Framework;

#pragma warning disable AAIP001, SCME0001

namespace Azure.AI.Projects.Agents.Tests;

public class LiveDecisionMessageTests
{
    private const string MessageJson = """
        {"type":"message","role":"user","content":[{"type":"input_text","text":"Decision context"}],
         "extension":{"count":7,"enabled":true,"optional":null}}
        """;

    [TestCase("J")]
    [TestCase("W")]
    public void PublicInputConstructorAndPatchCreateACompleteMessage(string format)
    {
        LiveDecisionInputItemParamMessage message = new();
        message.Patch.Set("$.role"u8, "user");
        message.Patch.Set("$.content"u8, BinaryData.FromString("""[{"type":"input_text","text":"Decision context"}]"""));
        message.Patch.Set("$.extension"u8, BinaryData.FromString("""{"count":7,"enabled":true,"optional":null}"""));
        Assert.That(message.Patch.GetString("$.role"u8), Is.EqualTo("user"));
        LiveClientEvent command = new LiveClientEventLiveDecisionItemCreateParam(message);
        using JsonDocument document = JsonDocument.Parse(Write(command, format));
        AssertPayload(document.RootElement.GetProperty("item"));
    }

    [TestCase("J")]
    [TestCase("W")]
    public void InputMessageSurvivesBaseAndEnclosingEventSerialization(string format)
    {
        LiveDecisionInputItemParam item = Read<LiveDecisionInputItemParam>(MessageJson);
        Assert.That(item, Is.TypeOf<LiveDecisionInputItemParamMessage>());
        using JsonDocument direct = JsonDocument.Parse(Write(item, format));
        AssertPayload(direct.RootElement);

        LiveClientEvent command = new LiveClientEventLiveDecisionItemCreateParam(item) { EventId = "decision-message" };
        using JsonDocument envelope = JsonDocument.Parse(Write(command, format));
        Assert.That(envelope.RootElement.GetProperty("type").GetString(), Is.EqualTo("decision.item.create"));
        AssertPayload(envelope.RootElement.GetProperty("item"));
    }

    [TestCase("J")]
    [TestCase("W")]
    public void StoredMessageSurvivesBaseAndAcknowledgmentSerialization(string format)
    {
        LiveServerEvent serverEvent = Read<LiveServerEvent>(
            $$"""{"type":"decision.item.created","event_id":"ack","item":{{MessageJson}}}""");
        Assert.That(serverEvent, Is.TypeOf<LiveServerEventLiveDecisionItemCreated>());
        LiveDecisionStoredInputItemParam item = ((LiveServerEventLiveDecisionItemCreated)serverEvent).Item;
        Assert.That(item, Is.TypeOf<LiveDecisionStoredInputItemParamMessage>());
        LiveDecisionStoredInputItemParamMessage message = (LiveDecisionStoredInputItemParamMessage)item;
        Assert.That(message.Patch.GetString("$.role"u8), Is.EqualTo("user"));
        using JsonDocument content = JsonDocument.Parse(message.Patch.GetJson("$.content"u8));
        Assert.That(content.RootElement[0].GetProperty("text").GetString(), Is.EqualTo("Decision context"));
        message.Patch.Set("$.extension.count"u8, 7);
        using JsonDocument direct = JsonDocument.Parse(Write(item, format));
        AssertPayload(direct.RootElement);
        using JsonDocument envelope = JsonDocument.Parse(Write(serverEvent, format));
        AssertPayload(envelope.RootElement.GetProperty("item"));
    }

    [TestCase(typeof(LiveDecisionInputItemParamMessage))]
    [TestCase(typeof(LiveDecisionStoredInputItemParamMessage))]
    public void MessagePayloadIsPubliclyInspectable(Type type)
        => Assert.That(type.GetProperty("Patch")?.GetMethod?.IsPublic, Is.True);

    [Test]
    public void TypedSiblingsKeepTheirPayloads(
        [Values("function_call", "function_call_output", "custom_tool_call", "custom_tool_call_output")] string type,
        [Values(false, true)] bool stored,
        [Values("J", "W")] string format)
    {
        string fields = type switch
        {
            "function_call" => """ "name":"lookup","arguments":"{\"value\":7}" """,
            "function_call_output" or "custom_tool_call_output" => """ "output":"result" """,
            _ => """ "name":"custom","input":"data" """
        };
        string json = $$"""{"type":"{{type}}","id":"item-1","call_id":"call-1",{{fields}}}""";
        Type expectedType = (stored, type) switch
        {
            (false, "function_call") => typeof(LiveDecisionFunctionCallParam),
            (false, "function_call_output") => typeof(LiveDecisionFunctionCallOutputParam),
            (false, "custom_tool_call") => typeof(LiveDecisionCustomToolCallParam),
            (false, _) => typeof(LiveDecisionCustomToolCallOutputParam),
            (true, "function_call") => typeof(LiveDecisionStoredFunctionCallParam),
            (true, "function_call_output") => typeof(LiveDecisionStoredFunctionCallOutputParam),
            (true, "custom_tool_call") => typeof(LiveDecisionStoredCustomToolCallParam),
            _ => typeof(LiveDecisionStoredCustomToolCallOutputParam)
        };
        BinaryData data;
        if (stored)
        {
            LiveDecisionStoredInputItemParam item = Read<LiveDecisionStoredInputItemParam>(json);
            Assert.That(item, Is.TypeOf(expectedType));
            data = Write(item, format);
        }
        else
        {
            LiveDecisionInputItemParam item = Read<LiveDecisionInputItemParam>(json);
            Assert.That(item, Is.TypeOf(expectedType));
            data = Write(item, format);
        }
        using JsonDocument document = JsonDocument.Parse(data);
        Assert.Multiple(() =>
        {
            Assert.That(document.RootElement.GetProperty("type").GetString(), Is.EqualTo(type));
            Assert.That(document.RootElement.GetProperty("call_id").GetString(), Is.EqualTo("call-1"));
            if (type == "function_call")
            {
                Assert.That(document.RootElement.GetProperty("name").GetString(), Is.EqualTo("lookup"));
                Assert.That(document.RootElement.GetProperty("arguments").GetString(), Is.EqualTo("""{"value":7}"""));
            }
            else if (type == "custom_tool_call")
            {
                Assert.That(document.RootElement.GetProperty("name").GetString(), Is.EqualTo("custom"));
                Assert.That(document.RootElement.GetProperty("input").GetString(), Is.EqualTo("data"));
            }
            else
            {
                Assert.That(document.RootElement.GetProperty("output").GetString(), Is.EqualTo("result"));
            }
        });
    }

    private static void AssertPayload(JsonElement message)
    {
        Assert.Multiple(() =>
        {
            Assert.That(message.GetProperty("type").GetString(), Is.EqualTo("message"));
            Assert.That(message.GetProperty("role").GetString(), Is.EqualTo("user"));
            Assert.That(message.GetProperty("content")[0].GetProperty("type").GetString(), Is.EqualTo("input_text"));
            Assert.That(message.GetProperty("content")[0].GetProperty("text").GetString(), Is.EqualTo("Decision context"));
            Assert.That(message.GetProperty("extension").GetProperty("count").GetInt32(), Is.EqualTo(7));
            Assert.That(message.GetProperty("extension").GetProperty("enabled").GetBoolean(), Is.True);
            Assert.That(message.GetProperty("extension").GetProperty("optional").ValueKind, Is.EqualTo(JsonValueKind.Null));
        });
    }

    private static T Read<T>(string json)
        => ModelReaderWriter.Read<T>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);

    private static BinaryData Write<T>(T value, string format)
        => ModelReaderWriter.Write(value, new ModelReaderWriterOptions(format), AzureAIProjectsAgentsContext.Default);
}
