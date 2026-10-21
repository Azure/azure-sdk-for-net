// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.ContentSafety.Tests
{
    public class AgentContextConstructorTests
    {
        [TestCase("AgentStartup")]
        [TestCase("Input")]
        [TestCase("PreModelCall")]
        [TestCase("PostModelCall")]
        [TestCase("PreToolCall")]
        [TestCase("PostToolCall")]
        [TestCase("Output")]
        [TestCase("AgentShutdown")]
        public void RequiredPayloadConstructorPreservesAuthoritativeContext(string exampleName)
        {
            using JsonDocument example = JsonDocument.Parse(File.ReadAllText(Path.Combine(
                TestContext.CurrentContext.TestDirectory, "AgentHooksExamples", $"UnifiedModerate_{exampleName}.json")));
            JsonElement expected = example.RootElement.GetProperty("parameters").GetProperty("body");
            AgentContext source = ModelReaderWriter.Read<AgentContext>(BinaryData.FromString(expected.GetRawText()));
            AgentContext constructed = source switch
            {
                AgentStartupContext => new AgentStartupContext(
                    source.Timestamp, source.Sequence, source.Agent, source.Session, source.Target, source.AgentInit),
                AgentInputContext => new AgentInputContext(
                    source.Timestamp, source.Sequence, source.Agent, source.Session, source.Target, source.Input),
                AgentPreModelCallContext => new AgentPreModelCallContext(
                    source.Timestamp, source.Sequence, source.Agent, source.Session, source.Target, source.Model, source.Messages),
                AgentPostModelCallContext => new AgentPostModelCallContext(
                    source.Timestamp, source.Sequence, source.Agent, source.Session, source.Target, source.Model, source.Response),
                AgentPreToolCallContext => new AgentPreToolCallContext(
                    source.Timestamp, source.Sequence, source.Agent, source.Session, source.Target, source.ToolCall),
                AgentPostToolCallContext => new AgentPostToolCallContext(
                    source.Timestamp, source.Sequence, source.Agent, source.Session, source.Target, source.ToolCall, source.ToolResult),
                AgentOutputContext => new AgentOutputContext(
                    source.Timestamp, source.Sequence, source.Agent, source.Session, source.Target, source.Output),
                AgentShutdownContext => new AgentShutdownContext(
                    source.Timestamp, source.Sequence, source.Agent, source.Session, source.Target, source.Summary),
                _ => throw new AssertionException("Unexpected context type in authoritative fixture.")
            };
            constructed.Extensions = source.Extensions;

            using JsonDocument serialized = Serialize(constructed);
            Assert.That(serialized.RootElement.GetProperty("timestamp").GetDateTimeOffset(), Is.EqualTo(source.Timestamp));
            JsonNode actualJson = JsonNode.Parse(serialized.RootElement.GetRawText());
            JsonNode expectedJson = JsonNode.Parse(expected.GetRawText());
            actualJson["timestamp"] = expectedJson["timestamp"].DeepClone();
            Assert.That(JsonNode.DeepEquals(actualJson, expectedJson), Is.True);
        }

        [Test]
        public void PreModelContextPreservesExplicitlyEmptyMessages()
        {
            var context = new AgentPreModelCallContext(
                DateTimeOffset.Parse("2026-10-08T04:00:02Z"),
                2,
                new AgentDefinition("support-agent", "agent-framework"),
                new AgentSession("example-session"),
                BinaryData.FromString("[]"),
                new AgentModel("example-model"),
                Array.Empty<AgentMessage>());

            using JsonDocument serialized = Serialize(context);
            Assert.Multiple(() =>
            {
                Assert.That(serialized.RootElement.GetProperty("messages").ValueKind, Is.EqualTo(JsonValueKind.Array));
                Assert.That(serialized.RootElement.GetProperty("messages").GetArrayLength(), Is.Zero);
                Assert.That(serialized.RootElement.GetProperty("target").GetArrayLength(), Is.Zero);
            });
        }

        [TestCase("null")]
        [TestCase("false")]
        [TestCase("42")]
        [TestCase("\"tool result\"")]
        [TestCase("[]")]
        [TestCase("{\"nested\":[1,true,null]}")]
        public void PostToolContextPreservesNativeJsonValue(string json)
        {
            BinaryData value = BinaryData.FromString(json);
            var context = new AgentPostToolCallContext(
                DateTimeOffset.Parse("2026-10-08T04:00:05Z"),
                5,
                new AgentDefinition("support-agent", "agent-framework"),
                new AgentSession("example-session"),
                value,
                new AgentToolCall("call-1", "example-tool", new AgentJsonObject()),
                new AgentToolResult(value, false));

            using JsonDocument serialized = Serialize(context);
            using JsonDocument expected = JsonDocument.Parse(json);
            Assert.Multiple(() =>
            {
                Assert.That(serialized.RootElement.GetProperty("target").ValueKind, Is.EqualTo(expected.RootElement.ValueKind));
                Assert.That(serialized.RootElement.GetProperty("tool_result").GetProperty("value").ValueKind, Is.EqualTo(expected.RootElement.ValueKind));
                Assert.That(JsonNode.DeepEquals(
                    JsonNode.Parse(serialized.RootElement.GetProperty("target").GetRawText()),
                    JsonNode.Parse(json)), Is.True);
                Assert.That(JsonNode.DeepEquals(
                    JsonNode.Parse(serialized.RootElement.GetProperty("tool_result").GetProperty("value").GetRawText()),
                    JsonNode.Parse(json)), Is.True);
            });
        }

        private static JsonDocument Serialize(AgentContext context)
        {
            using RequestContent content = context;
            using var stream = new MemoryStream();
            content.WriteTo(stream, CancellationToken.None);
            return JsonDocument.Parse(stream.ToArray());
        }
    }
}
