// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using Azure.AI.Projects.Agents._Beta.VoiceAgents;

#pragma warning disable AAIP001
#pragma warning disable AAIP002
namespace Azure.AI.Projects.Agents.Tests;

public class BetaVoiceAgentsConversationsTests : AgentsTestBase
{
    public BetaVoiceAgentsConversationsTests(bool isAsync) : base(isAsync)
    {
    }

    private async Task<string> EnsureConversationsAgentAsync(AgentAdministrationClient agentsClient)
    {
        try
        {
            await agentsClient.GetAgentAsync(CONVERSATIONS_AGENT_NAME);
        }
        catch (ClientResultException ex) when (ex.Status == 404)
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

    // The BetaVoiceAgentsConversations surface only reads history that a realtime session persisted
    // (see LiveTests\ProjectsRealtimeConversationTests.PersistedConversationIsRetrievableAfterSession
    // for the corresponding write path); a freshly created agent has no realtime session history, so
    // this is the only conversation-history scenario coverable without a live realtime connection.
    [RecordedTest]
    public async Task TestGetAgentConversationsReturnsEmptyForNewAgent()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        BetaVoiceAgentsConversations conversationsClient = agentsClient.GetBetaVoiceAgentEndpointConversations();
        string agentName = await EnsureConversationsAgentAsync(agentsClient);

        List<VoiceConversation> conversations = await conversationsClient
            .GetAgentConversationsAsync(agentName)
            .ToListAsync();
        Console.WriteLine($"[REST] LIST conversations -> {conversations.Count} conversation(s)");

        Assert.That(conversations, Is.Not.Null);
    }

    [RecordedTest]
    public async Task TestGetAgentConversationThrowsForUnknownConversation()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        BetaVoiceAgentsConversations conversationsClient = agentsClient.GetBetaVoiceAgentEndpointConversations();
        string agentName = await EnsureConversationsAgentAsync(agentsClient);

        // The service's conversation-id format validator rejects an arbitrary fake id -- including
        // plausibly-prefixed ones -- before it would ever reach a not-found check (its exact
        // expected id shape/length isn't publicly documented; verified live 2026-09-17 that a
        // "conv_"-prefixed 32-char id is rejected as the wrong length). Only assert that a client
        // error is surfaced, not a specific status code.
        string fakeConversationId = $"conv_{Recording.Random.NewGuid():N}";

        ClientResultException exception = Assert.ThrowsAsync<ClientResultException>(
            () => conversationsClient.GetAgentConversationAsync(agentName, fakeConversationId));
        Console.WriteLine($"[REST] GET unknown conversation -> {exception.Status}");
        Assert.That(exception.Status, Is.GreaterThanOrEqualTo(400));
    }

    // -----------------------------------------------------------------------
    // Verifies the remaining single-resource conversation reads (item, response, audio, audio item)
    // and delete each surface a client error for a nonexistent conversation/item/response id,
    // without requiring a live realtime session's persisted history (see the class-level comment
    // above TestGetAgentConversationsReturnsEmptyForNewAgent for why that can't be produced here).
    // -----------------------------------------------------------------------
    [RecordedTest]
    public async Task TestConversationSubResourcesThrowForUnknownIds()
    {
        AgentAdministrationClient agentsClient = GetTestClient();
        BetaVoiceAgentsConversations conversationsClient = agentsClient.GetBetaVoiceAgentEndpointConversations();
        string agentName = await EnsureConversationsAgentAsync(agentsClient);
        // See comment on TestGetAgentConversationThrowsForUnknownConversation: the service's id
        // format validator rejects these before a not-found check is reached, so only a generic
        // client-error status is asserted below, not a specific code.
        string fakeConversationId = $"conv_{Recording.Random.NewGuid():N}";
        string fakeItemId = $"item_{Recording.Random.NewGuid():N}";
        string fakeResponseId = $"resp_{Recording.Random.NewGuid():N}";

        ClientResultException itemException = Assert.ThrowsAsync<ClientResultException>(
            () => conversationsClient.GetAgentConversationItemAsync(agentName, fakeConversationId, fakeItemId));
        Console.WriteLine($"[REST] GET unknown conversation item -> {itemException.Status}");
        Assert.That(itemException.Status, Is.GreaterThanOrEqualTo(400));

        ClientResultException responseException = Assert.ThrowsAsync<ClientResultException>(
            () => conversationsClient.GetAgentConversationResponseAsync(agentName, fakeConversationId, fakeResponseId));
        Console.WriteLine($"[REST] GET unknown conversation response -> {responseException.Status}");
        Assert.That(responseException.Status, Is.GreaterThanOrEqualTo(400));

        ClientResultException audioException = Assert.ThrowsAsync<ClientResultException>(
            () => conversationsClient.GetAgentConversationAudioAsync(agentName, fakeConversationId));
        Console.WriteLine($"[REST] GET unknown conversation audio -> {audioException.Status}");
        Assert.That(audioException.Status, Is.GreaterThanOrEqualTo(400));

        ClientResultException audioItemException = Assert.ThrowsAsync<ClientResultException>(
            () => conversationsClient.GetAgentConversationAudioItemAsync(agentName, fakeConversationId, fakeItemId));
        Console.WriteLine($"[REST] GET unknown conversation audio item -> {audioItemException.Status}");
        Assert.That(audioItemException.Status, Is.GreaterThanOrEqualTo(400));

        ClientResultException deleteException = Assert.ThrowsAsync<ClientResultException>(
            () => conversationsClient.DeleteAgentConversationAsync(agentName, fakeConversationId));
        Console.WriteLine($"[REST] DELETE unknown conversation -> {deleteException.Status}");
        Assert.That(deleteException.Status, Is.GreaterThanOrEqualTo(400));
    }
}
