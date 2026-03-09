// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using System;
using System.ClientModel;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Agents.Tests;

public class AgentsTests : AgentsTestBase
{
    public AgentsTests(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task ErrorsGiveGoodExceptionMessages()
    {
        AgentsClient agentsClient = GetTestClient();

        ClientResultException exception = null;
        try
        {
            _ = await agentsClient.GetAgentAsync("SomeAgentNameThatReallyDoesNotExistAndNeverShould3490");
        }
        catch (ClientResultException ex)
        {
            exception = ex;
        }

        Assert.That(exception?.Message, Does.Contain("exist"));
    }

    [RecordedTest]
    public async Task TestAgentCRUD()
    {
        AgentsClient agentsClient = GetTestClient();
        AgentDefinition emptyAgentDefinition = new PromptAgentDefinition(TestEnvironment.MODELDEPLOYMENTNAME);

        const string emptyPromptAgentName = "TestNoVersionAgentFromDotnetTests";
        try
        {
            await agentsClient.DeleteAgentAsync(emptyPromptAgentName);
        }
        catch (ClientResultException)
        {
            // We do not have the agent to begin with.
        }
        AgentVersion newAgentVersion = await agentsClient.CreateAgentVersionAsync(
            emptyPromptAgentName,
            new AgentVersionCreationOptions(emptyAgentDefinition)
            {
                Metadata = { ["delete_me"] = "please " },
            });
        Assert.That(newAgentVersion?.Id, Is.Not.Null.And.Not.Empty);

        AgentRecord retrievedAgent = await agentsClient.GetAgentAsync(emptyPromptAgentName);
        Assert.That(retrievedAgent?.Id, Is.EqualTo(newAgentVersion.Name));

        await agentsClient.DeleteAgentAsync(newAgentVersion.Name);

        AgentVersion agentVersion = await agentsClient.CreateAgentVersionAsync(AGENT_NAME, new AgentVersionCreationOptions(emptyAgentDefinition));
        Assert.That(AGENT_NAME, Is.EqualTo(agentVersion.Name));
        AgentVersion agentVersionObject_ = await agentsClient.GetAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Assert.That(AGENT_NAME, Is.EqualTo(agentVersionObject_.Name));
        Assert.That(agentVersion.Version, Is.EqualTo(agentVersionObject_.Version));
        Assert.That(agentVersion.Description, Is.Empty);
        Assert.That(agentVersion.Metadata, Is.Empty);
        await agentsClient.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        Assert.ThrowsAsync<ClientResultException>(async () => await agentsClient.GetAgentVersionAsync(agentVersion.Name, agentVersion.Version));
    }
}
