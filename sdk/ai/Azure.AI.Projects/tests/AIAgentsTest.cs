// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.AI.Agents.Persistent;
using Azure.AI.Projects.Tests.Utils;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class AIAgentsTest : ProjectsClientTestBase
{
    public AIAgentsTest(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task AgentsGetPersistentClient()
    {
        AIProjectClient projectClient = new AIProjectClient(new(TestEnvironment.PROJECT_ENDPOINT), new MockTokenCredential());
        PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();
        Assert.That(agentsClient, Is.Not.Null);
    }

    [TestCase]
    // We cannot instrument PersistentAgentsClient as it is created through AIProjectClient connection and
    // it is not using SCM pipeline. We also do not have an options exposed to inject custom interceptor.
    [LiveOnly]
    public async Task AgentsTest()
    {
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

        AIProjectClient projectClient = GetTestProjectClient();
        PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();

        Console.WriteLine("Create an agent with a model deployment");
        PersistentAgent agent = await agentsClient.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        Assert.That(agent.Id, Is.Not.Null);
        Assert.That(agent.Model, Is.EqualTo(modelDeploymentName));
        Assert.That(agent.Name, Is.EqualTo("Math Tutor"));
        Assert.That(agent.Instructions, Is.EqualTo("You are a personal math tutor. Write and run code to answer math questions."));

        await agentsClient.Administration.DeleteAgentAsync(agentId: agent.Id);
    }
}
