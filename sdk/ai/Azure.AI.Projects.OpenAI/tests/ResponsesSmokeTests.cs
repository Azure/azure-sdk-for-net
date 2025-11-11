// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Files;
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
    }
}
