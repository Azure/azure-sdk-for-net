// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel.Primitives;
using System.Linq;
using NUnit.Framework;
using OpenAI.Responses;

namespace Azure.AI.Projects.OpenAI.Tests;

[Category("Smoke")]
[Parallelizable(ParallelScope.All)]
public class ResponsesSmokeTests : ProjectsOpenAITestBase
{
    public ResponsesSmokeTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public void TestResponseItemExtension()
    {
        string rawStructuredInputsItem = """
            {
              "type": "structured_inputs",
              "inputs": {
                "hello": "world"
              }
            }
            """;

        ResponseItem item = ModelReaderWriter.Read<ResponseItem>(BinaryData.FromString(rawStructuredInputsItem));
        Assert.That(item, Is.Not.Null);

        AgentResponseItem agentResponseItem = item.AsAgentResponseItem();
        Assert.That(agentResponseItem, Is.Not.Null);

        ResponseItem revertedResponseItem = agentResponseItem;
        Assert.That(revertedResponseItem, Is.Not.Null);
    }

    [Test]
    public void TestResponseCreationOptionsExtensions()
    {
        ResponseCreationOptions options = new();
        Assert.That(options.Agent, Is.Null);
        Assert.That(options.AgentConversationId, Is.Null);

        options.Agent = new AgentReference("my-agent");
        Assert.That(options.Agent?.Name, Is.EqualTo("my-agent"));
        Assert.That(options.Agent?.Version, Is.Null);

        options.Agent = "my-other-agent";
        Assert.That(options.Agent?.Name, Is.EqualTo("my-other-agent"));
        Assert.That(options.Agent?.Version, Is.Null);

        options.Agent = new AgentReference("one-more-agent", "42");
        Assert.That(options.Agent?.Name, Is.EqualTo("one-more-agent"));
        Assert.That(options.Agent?.Version, Is.EqualTo("42"));

        options.Agent = null;
        Assert.That(options.Agent, Is.Null);

        options.AgentConversationId = "conv_abcd1234";
        Assert.That(options.AgentConversationId, Is.EqualTo("conv_abcd1234"));
        options.AgentConversationId = null;
        Assert.That(options.AgentConversationId, Is.Null);

        Assert.That(options.StructuredInputs, Is.Not.Null);
        Assert.That(options.StructuredInputs.Keys, Is.Empty);
        Assert.That(options.StructuredInputs?.Keys, Is.Empty);
        Assert.That(options.StructuredInputs?.Values, Is.Empty);
        Assert.That(ModelReaderWriter.Write(options).ToString(), Does.Not.Contain("structured_inputs"));

        options.StructuredInputs["foo"] = BinaryData.FromString(@"""bar""");
        Assert.That(ModelReaderWriter.Write(options).ToString(), Does.Contain("structured_inputs"));
        Assert.That(options.StructuredInputs.ContainsKey("foo"), Is.True);
        Assert.That(options.StructuredInputs.ContainsKey("bar"), Is.False);
        Assert.That(options.StructuredInputs.Keys, Has.Count.EqualTo(1));
        Assert.That(options.StructuredInputs.Values, Has.Count.EqualTo(1));
        Assert.That(options.StructuredInputs.Keys.First(), Is.EqualTo("foo"));
        Assert.That(options.StructuredInputs.Values.First().ToString(), Is.EqualTo(@"""bar"""));
        Assert.That(options.StructuredInputs.TryGetValue("foo", out BinaryData fooBytes), Is.True);
        Assert.That(fooBytes?.ToString(), Is.EqualTo("bar"));
        Assert.That(options.StructuredInputs.TryGetValue("bar", out BinaryData _), Is.False);

        options.StructuredInputs.Clear();
        Assert.That(options.StructuredInputs, Is.Not.Null);
        Assert.That(options.StructuredInputs.Keys, Is.Empty);
        Assert.That(options.StructuredInputs?.Keys, Is.Empty);
        Assert.That(options.StructuredInputs?.Values, Is.Empty);

        options.StructuredInputs["foo"u8] = BinaryData.FromString(@"""bar""");
        Assert.That(ModelReaderWriter.Write(options).ToString(), Does.Contain("structured_inputs"));
        Assert.That(options.StructuredInputs.TryGetValue("foo", out fooBytes), Is.True);
        Assert.That(options.StructuredInputs.TryGetValue("bar", out BinaryData _), Is.False);

        options = new()
        {
            StructuredInputs =
            {
                ["foo"] = BinaryData.FromString(@"""bar"""),
                ["baz"] = BinaryData.FromString(@"""quz"""),
            }
        };
        Assert.That(ModelReaderWriter.Write(options).ToString(), Does.Contain("structured_inputs"));
        Assert.That(options.StructuredInputs.ContainsKey("foo"), Is.True);
        Assert.That(options.StructuredInputs.ContainsKey("bar"), Is.False);
        Assert.That(options.StructuredInputs.ContainsKey("baz"), Is.True);
        Assert.That(options.StructuredInputs.ContainsKey("quz"), Is.False);
        Assert.That(options.StructuredInputs.Keys, Has.Count.EqualTo(2));
        Assert.That(options.StructuredInputs.Values, Has.Count.EqualTo(2));
        Assert.That(options.StructuredInputs.Keys.First(), Is.EqualTo("foo"));
        Assert.That(options.StructuredInputs.Keys.Last(), Is.EqualTo("baz"));
        Assert.That(options.StructuredInputs.Values.First().ToString(), Is.EqualTo(@"""bar"""));
        Assert.That(options.StructuredInputs.Values.Last().ToString(), Is.EqualTo(@"""quz"""));
        Assert.That(options.StructuredInputs.TryGetValue("foo", out fooBytes), Is.True);
        Assert.That(fooBytes?.ToString(), Is.EqualTo("bar"));
        Assert.That(options.StructuredInputs.TryGetValue("bar", out BinaryData _), Is.False);
        Assert.That(options.StructuredInputs.TryGetValue("baz", out BinaryData bazBytes), Is.True);
        Assert.That(bazBytes?.ToString(), Is.EqualTo("quz"));

        options.StructuredInputs.Remove("foo");
        Assert.That(options.StructuredInputs.ContainsKey("foo"), Is.False);
        Assert.That(options.StructuredInputs.ContainsKey("bar"), Is.False);
        Assert.That(options.StructuredInputs.ContainsKey("baz"), Is.True);
        Assert.That(options.StructuredInputs.ContainsKey("quz"), Is.False);
        Assert.That(options.StructuredInputs.Keys, Has.Count.EqualTo(1));
        Assert.That(options.StructuredInputs.Values, Has.Count.EqualTo(1));
        Assert.That(options.StructuredInputs.Keys.First(), Is.EqualTo("baz"));
        Assert.That(options.StructuredInputs.Values.First().ToString(), Is.EqualTo(@"""quz"""));
        Assert.That(options.StructuredInputs.TryGetValue("foo", out BinaryData _), Is.False);
        Assert.That(options.StructuredInputs.TryGetValue("bar", out BinaryData _), Is.False);
        Assert.That(options.StructuredInputs.TryGetValue("baz", out bazBytes), Is.True);
        Assert.That(bazBytes?.ToString(), Is.EqualTo("quz"));

        options.StructuredInputs.Add("stringValueKey", "stringValueValue");
        Assert.That(options.StructuredInputs["stringValueKey"].ToString(), Is.EqualTo("stringValueValue"));
        options.StructuredInputs.Add("intValueKey", 42);
        Assert.That(int.TryParse(options.StructuredInputs["intValueKey"].ToString(), out int retrievedIntValue), Is.True);
        Assert.That(retrievedIntValue, Is.EqualTo(42));
        options.StructuredInputs.Add("boolValueKey", true);
        Console.WriteLine(ModelReaderWriter.Write(options).ToString());
        Assert.That(bool.TryParse(options.StructuredInputs["boolValueKey"].ToString(), out bool retrievedBoolValue), Is.True);
        Assert.That(retrievedBoolValue, Is.True);
    }
}
