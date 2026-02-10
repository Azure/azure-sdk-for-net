// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.Agents.Persistent;
using Azure.AI.Projects.Tests.Utils;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class AIAgentsTest : ProjectsClientTestBase
{
    public AIAgentsTest(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
    {
    }

    [TestCase]
    [RecordedTest]
    [Ignore("Agents API calls are not recorded")]
    public async Task AgentsTest()
    {
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

        AIProjectClient projectClient = GetTestClient();
        PersistentAgentsClient agentsClient = projectClient.GetPersistentAgentsClient();

        Console.WriteLine("Create an agent with a model deployment");
        PersistentAgent agent = await agentsClient.Administration.CreateAgentAsync(
            model: modelDeploymentName,
            name: "Math Tutor",
            instructions: "You are a personal math tutor. Write and run code to answer math questions."
        );
        Assert.NotNull(agent.Id);
        Assert.AreEqual(agent.Model, modelDeploymentName);
        Assert.AreEqual(agent.Name, "Math Tutor");
        Assert.AreEqual(agent.Instructions, "You are a personal math tutor. Write and run code to answer math questions.");

        await agentsClient.Administration.DeleteAgentAsync(agentId: agent.Id);
    }
}
