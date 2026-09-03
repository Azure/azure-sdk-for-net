// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

#pragma warning disable AAIP001
namespace Azure.AI.Projects.Agents.Tests;

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
