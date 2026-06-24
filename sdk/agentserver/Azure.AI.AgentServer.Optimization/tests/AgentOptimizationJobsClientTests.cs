// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.AI.AgentServer.Optimization.Tests;

/// <summary>
/// Smoke tests for the TypeSpec-generated AgentOptimizationJobs client.
/// </summary>
public class AgentOptimizationJobsClientTests
{
    [Test]
    public void ProjectsClient_CanInstantiate()
    {
        var options = new ProjectsClientOptions();
        Assert.That(options, Is.Not.Null);
    }

    [Test]
    public void OptimizationJobInputs_CanCreateWithAgent()
    {
        var agent = new OptimizationAgentDefinition("my-agent");
        var inputs = new OptimizationJobInputs(agent);

        Assert.That(inputs.Agent, Is.Not.Null);
        Assert.That(inputs.Agent.AgentName, Is.EqualTo("my-agent"));
    }

    [Test]
    public void OptimizationOptions_CanCreate()
    {
        var options = new OptimizationOptions();
        Assert.That(options.Strategies, Is.Not.Null);
    }

    [Test]
    public void DatasetItem_CanCreateWithNameAndQuery()
    {
        var item = new DatasetItem("task-1", "What is the weather?");
        Assert.That(item.Name, Is.EqualTo("task-1"));
        Assert.That(item.Query, Is.EqualTo("What is the weather?"));
    }

    [Test]
    public void EvaluationCriterion_CanCreateWithNameAndInstruction()
    {
        var criterion = new EvaluationCriterion("relevance", "Is the answer relevant?");
        Assert.That(criterion.Name, Is.EqualTo("relevance"));
        Assert.That(criterion.Instruction, Is.EqualTo("Is the answer relevant?"));
    }
}
