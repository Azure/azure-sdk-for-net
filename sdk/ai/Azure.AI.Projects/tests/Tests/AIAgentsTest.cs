// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Agents.Persistent;
using Azure.Identity;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class AIAgentsTest : RecordedTestBase<AIProjectsTestEnvironment>
{
    public AIAgentsTest(bool isAsync) : base(isAsync)
    {
        TestDiagnostics = false;
    }

    [RecordedTest]
    public void AgentsTestSync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();

        Console.WriteLine("Create an agent with a model deployment");
        PersistentAgent agent = agentsClient.Administration.CreateAgent(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        Assert.NotNull(agent.Id);
        Assert.That(agent.Model == modelDeploymentName);
        Assert.That(agent.Name == "Math Tutor");
        Assert.That(agent.Instructions == "You are a personal math tutor. Write and run code to answer math questions.");

        agentsClient.Administration.DeleteAgent(agentId: agent.Id);
    }

    [RecordedTest]
    public async Task AgentsTestAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();

        Console.WriteLine("Create an agent with a model deployment");
        PersistentAgent agent = await agentsClient.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        Assert.NotNull(agent.Id);
        Assert.That(agent.Model == modelDeploymentName);
        Assert.That(agent.Name == "Math Tutor");
        Assert.That(agent.Instructions == "You are a personal math tutor. Write and run code to answer math questions.");

        await agentsClient.Administration.DeleteAgentAsync(agentId: agent.Id);
    }
}
