// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using OpenAI.Realtime;

#pragma warning disable AAIP001
#pragma warning disable AAIP002
#pragma warning disable OPENAI002

namespace Azure.AI.Projects.Agents.Tests;

public class AgentEndpointConversationsCustomTests
{
    [TestCase(false)]
    [TestCase(true)]
    public async Task GetAgentConversationItemDeserializesRealtimeItem(bool isAsync)
    {
        RealtimeItem expected = RealtimeItem.CreateUserMessageItem("hello");
        BinaryData content = ModelReaderWriter.Write(expected, ModelReaderWriterOptions.Json, AzureAIProjectsAgentsContext.Default);
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200).WithContent(content.ToString()))
        {
            ExpectSyncPipeline = !isAsync
        };
        AgentAdministrationClientOptions options = new() { Transport = transport };
        AgentAdministrationClient agentsClient = new(new Uri("https://fake-account.services.ai.azure.com/api/projects/fake-project"), options);
        AgentEndpointConversations conversationsClient = agentsClient.GetAgentEndpointConversations();

        ClientResult<RealtimeItem> result = isAsync
            ? await conversationsClient.GetAgentConversationItemAsync("agent", "conversation", "item")
            : conversationsClient.GetAgentConversationItem("agent", "conversation", "item");

        Assert.Multiple(() =>
        {
            Assert.That(result.Value.Kind, Is.EqualTo(expected.Kind));
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
        });
    }
}
