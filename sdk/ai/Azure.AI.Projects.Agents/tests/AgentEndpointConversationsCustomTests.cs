// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
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

    [TestCase(false)]
    [TestCase(true)]
    public async Task GetAgentConversationResponsesDeserializesRealtimeValues(bool isAsync)
    {
        MockPipelineTransport transport = new(_ => new MockPipelineResponse(200).WithContent(
            """
            {"data":[{"id":"resp_test","conversation_id":"conv_test","object":"realtime.response","status":"completed","output_modalities":["text"],"output":[]}],"has_more":false}
            """))
        {
            ExpectSyncPipeline = !isAsync
        };
        AgentAdministrationClientOptions options = new() { Transport = transport };
        AgentAdministrationClient agentsClient = new(new Uri("https://fake-account.services.ai.azure.com/api/projects/fake-project"), options);
        AgentEndpointConversations conversationsClient = agentsClient.GetAgentEndpointConversations();

        List<VoiceResult> responses = [];
        if (isAsync)
        {
            await foreach (VoiceResult response in conversationsClient.GetAgentConversationResponsesAsync("agent", "conversation"))
            {
                responses.Add(response);
            }
        }
        else
        {
            foreach (VoiceResult response in conversationsClient.GetAgentConversationResponses("agent", "conversation"))
            {
                responses.Add(response);
            }
        }

        Assert.Multiple(() =>
        {
            Assert.That(responses, Has.Count.EqualTo(1));
            Assert.That(responses[0].Status, Is.EqualTo(new RealtimeResponseStatus("completed")));
            Assert.That(responses[0].OutputModalities, Is.EquivalentTo(new[] { new RealtimeOutputModality("text") }));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
        });
    }

    [Test]
    public void SemanticVadDeserializesEagerness()
    {
        VoiceAgentSemanticVadTurnDetection detection = ModelReaderWriter.Read<VoiceAgentSemanticVadTurnDetection>(
            BinaryData.FromString("""{"type":"semantic_vad","eagerness":"low"}"""),
            ModelReaderWriterOptions.Json,
            AzureAIProjectsAgentsContext.Default);

        Assert.That(detection.Eagerness, Is.EqualTo(new RealtimeSemanticVadEagernessLevel("low")));
    }
}
