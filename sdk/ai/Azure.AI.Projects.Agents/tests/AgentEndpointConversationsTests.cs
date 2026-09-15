// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using Microsoft.ClientModel.TestFramework.Mocks;
using NUnit.Framework;
using OpenAI;
using OpenAI.Realtime;

#pragma warning disable AAIP001
namespace Azure.AI.Projects.Agents.Tests;

// These tests use only the protocol-method mocking seam and do not require a live agent or recordings.
[Experimental("AAIP001")]
public class AgentConversationItemCompatibilityTests
{
    [Test]
    public void ImplementationOptInsDoNotMakeStablePublicSurfaceExperimental()
    {
        Assert.That(typeof(DeclarativeAgentDefinition).GetCustomAttribute<ExperimentalAttribute>(), Is.Null);
        Assert.That(typeof(DeclarativeAgentDefinition).GetConstructor([typeof(string)]).GetCustomAttribute<ExperimentalAttribute>(), Is.Null);
        Assert.That(typeof(ProjectsAgentRecord).GetCustomAttribute<ExperimentalAttribute>(), Is.Null);
        Assert.That(typeof(AgentHarness).GetCustomAttribute<ExperimentalAttribute>(), Is.Null);
        Assert.That(typeof(VoiceResponseBase).GetCustomAttribute<ExperimentalAttribute>(), Is.Null);
        Assert.That(typeof(DeclarativeAgentDefinition).GetProperty(nameof(DeclarativeAgentDefinition.Skills)).GetCustomAttribute<ExperimentalAttribute>().DiagnosticId, Is.EqualTo("AAIP001"));
        Assert.That(typeof(DeclarativeAgentDefinition).GetProperty(nameof(DeclarativeAgentDefinition.Harness)).GetCustomAttribute<ExperimentalAttribute>().DiagnosticId, Is.EqualTo("AAIP001"));
        Assert.That(typeof(ProjectsAgentRecord).GetProperty(nameof(ProjectsAgentRecord.DigitalWorkerType)).GetCustomAttribute<ExperimentalAttribute>().DiagnosticId, Is.EqualTo("AAIP001"));
        Assert.That(typeof(VoiceResponseBase).GetProperty(nameof(VoiceResponseBase.StatusDetails)).GetCustomAttribute<ExperimentalAttribute>().DiagnosticId, Is.EqualTo("AAIP002"));
        Assert.That(typeof(VoiceResponseBase).GetProperty(nameof(VoiceResponseBase.Usage)).GetCustomAttribute<ExperimentalAttribute>().DiagnosticId, Is.EqualTo("AAIP002"));
    }

    [TestCase("""{"id":"item_message","type":"message","role":"user","status":"completed","content":[{"type":"input_text","text":"Hello"}]}""", false)]
    [TestCase("""{"id":"item_message","type":"message","role":"user","status":"completed","content":[{"type":"input_text","text":"Hello"}]}""", true)]
    [TestCase("""{"id":"item_call","type":"function_call","call_id":"call_test","name":"get_weather","arguments":"{}","status":"completed"}""", false)]
    [TestCase("""{"id":"item_call","type":"function_call","call_id":"call_test","name":"get_weather","arguments":"{}","status":"completed"}""", true)]
    public async Task ConversationItemDeserializesAndPreservesProtocolResult(string json, bool isAsync)
    {
        using CancellationTokenSource cancellation = new();
        MockPipelineResponse response = new MockPipelineResponse(200).WithContent(json);
        ConversationItemClient client = new(response);

        ClientResult<RealtimeItem> result = isAsync
            ? await client.GetAgentConversationItemAsync("agent", "conversation", "item", cancellation.Token)
            : client.GetAgentConversationItem("agent", "conversation", "item", cancellation.Token);

        Assert.That(result.GetRawResponse(), Is.SameAs(response));
        Assert.That(client.Arguments, Is.EqualTo(("agent", "conversation", "item")));
        Assert.That(client.Options.CancellationToken, Is.EqualTo(cancellation.Token));
        Assert.That(client.CalledAsync, Is.EqualTo(isAsync));
        using JsonDocument expected = JsonDocument.Parse(json);
        using JsonDocument actual = JsonDocument.Parse(ModelReaderWriter.Write(result.Value, ModelReaderWriterOptions.Json, OpenAIContext.Default));
        foreach (JsonProperty property in expected.RootElement.EnumerateObject())
        {
            Assert.That(actual.RootElement.GetProperty(property.Name).ToString(), Is.EqualTo(property.Value.ToString()));
        }
    }

    [TestCase(0, null, false)]
    [TestCase(1, null, false)]
    [TestCase(2, null, false)]
    [TestCase(0, "", false)]
    [TestCase(1, "", false)]
    [TestCase(2, "", false)]
    [TestCase(0, null, true)]
    [TestCase(1, null, true)]
    [TestCase(2, null, true)]
    [TestCase(0, "", true)]
    [TestCase(1, "", true)]
    [TestCase(2, "", true)]
    public void ConversationItemValidatesArgumentsBeforeCallingProtocol(int index, string invalidValue, bool isAsync)
    {
        string[] arguments = ["agent", "conversation", "item"];
        string[] parameterNames = ["agentName", "conversationId", "itemId"];
        arguments[index] = invalidValue;
        ConversationItemClient client = new(new MockPipelineResponse(200));

        ArgumentException exception = Assert.CatchAsync<ArgumentException>(async () =>
        {
            if (isAsync)
            {
                await client.GetAgentConversationItemAsync(arguments[0], arguments[1], arguments[2]);
            }
            else
            {
                client.GetAgentConversationItem(arguments[0], arguments[1], arguments[2]);
            }
        });

        Assert.That(exception.ParamName, Is.EqualTo(parameterNames[index]));
        Assert.That(exception, invalidValue is null ? Is.TypeOf<ArgumentNullException>() : Is.TypeOf<ArgumentException>());
        Assert.That(client.Options, Is.Null, "Argument validation must happen before invoking the protocol overload.");
    }

    [TestCase(false)]
    [TestCase(true)]
    public void ConversationItemPreservesProtocolFailure(bool isAsync)
    {
        MockPipelineResponse response = new MockPipelineResponse(404).WithContent("""{"error":{"message":"Not found"}}""");
        ClientResultException failure = new(response);
        ConversationItemClient client = new(response, failure);

        ClientResultException actual = Assert.ThrowsAsync<ClientResultException>(async () =>
        {
            if (isAsync)
            {
                await client.GetAgentConversationItemAsync("agent", "conversation", "item");
            }
            else
            {
                client.GetAgentConversationItem("agent", "conversation", "item");
            }
        });

        Assert.That(actual, Is.SameAs(failure));
    }

    private sealed class ConversationItemClient : AgentEndpointConversations
    {
        private readonly PipelineResponse _response;
        private readonly ClientResultException _failure;
        public (string AgentName, string ConversationId, string ItemId) Arguments { get; private set; }
        public RequestOptions Options { get; private set; }
        public bool CalledAsync { get; private set; }

        public ConversationItemClient(PipelineResponse response, ClientResultException failure = null)
        {
            _response = response;
            _failure = failure;
        }

        public override ClientResult GetAgentConversationItem(string agentName, string conversationId, string itemId, RequestOptions options)
        {
            Arguments = (agentName, conversationId, itemId);
            Options = options;
            if (_failure is not null)
            {
                throw _failure;
            }
            return ClientResult.FromResponse(_response);
        }

        public override Task<ClientResult> GetAgentConversationItemAsync(string agentName, string conversationId, string itemId, RequestOptions options)
        {
            CalledAsync = true;
            return Task.FromResult(GetAgentConversationItem(agentName, conversationId, itemId, options));
        }
    }
}

public class AgentEndpointConversationsTests : AgentsTestBase
{
    public AgentEndpointConversationsTests(bool isAsync) : base(isAsync)
    {
    }

    private async Task<string> EnsureConversationsAgentAsync(AgentAdministrationClient agentsClient)
    {
        try
        {
            await agentsClient.GetAgentAsync(CONVERSATIONS_AGENT_NAME);
        }
        catch
        {
            VoiceAgentDefinition definition = new()
            {
                ModelType = VoiceModelType.SelfDeployed,
                Model = TestEnvironment.FOUNDRY_MODEL_NAME,
                Instructions = "Respond briefly and helpfully.",
            };
            definition.OutputModalities.Add(VoiceOutputModality.Text);
            await agentsClient.CreateAgentVersionAsync(
                CONVERSATIONS_AGENT_NAME,
                new ProjectsAgentVersionCreationOptions(definition));
        }
        return CONVERSATIONS_AGENT_NAME;
    }

    [RecordedTest]
    public async Task TestGetAgentConversationsReturnsEmptyForNewAgent()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentEndpointConversations conversationsClient = agentsClient.GetAgentEndpointConversations();
        string agentName = await EnsureConversationsAgentAsync(agentsClient);

        List<VoiceConversation> conversations = await conversationsClient.GetAgentConversationsAsync(agentName).ToListAsync();

        Assert.That(conversations, Is.Not.Null);
    }

    [RecordedTest]
    public async Task TestGetAgentConversationGivesClientErrorForUnknownId()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentEndpointConversations conversationsClient = agentsClient.GetAgentEndpointConversations();
        string agentName = await EnsureConversationsAgentAsync(agentsClient);

        ClientResultException exception = null;
        try
        {
            _ = await conversationsClient.GetAgentConversationAsync(agentName, "conv_00000000000000000000000000000000");
        }
        catch (ClientResultException ex)
        {
            exception = ex;
        }

        Assert.That(exception, Is.Not.Null, "Retrieving a nonexistent conversation must throw.");
        Assert.That(exception.Status, Is.InRange(400, 499), "A nonexistent/invalid conversation ID must produce a 4xx client error.");
    }

    [RecordedTest]
    public async Task TestDeleteAgentConversationGivesClientErrorForUnknownId()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        AgentEndpointConversations conversationsClient = agentsClient.GetAgentEndpointConversations();
        string agentName = await EnsureConversationsAgentAsync(agentsClient);

        ClientResultException exception = null;
        try
        {
            _ = await conversationsClient.DeleteAgentConversationAsync(agentName, "conv_00000000000000000000000000000000");
        }
        catch (ClientResultException ex)
        {
            exception = ex;
        }

        Assert.That(exception, Is.Not.Null, "Deleting a nonexistent conversation must throw.");
        Assert.That(exception.Status, Is.InRange(400, 499), "A nonexistent/invalid conversation ID must produce a 4xx client error.");
    }
}
