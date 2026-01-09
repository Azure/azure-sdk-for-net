// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class DeploymentTest : ProjectsClientTestBase
{
    public DeploymentTest(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
    {
    }

    [RecordedTest]
    public async Task AIDeploymentTest()
    {
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var modelPublisher = TestEnvironment.MODELPUBLISHER;

        AIProjectClient projectClient = GetTestProjectClient();

        Console.WriteLine("List all deployments:");
        await foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeploymentsAsync())
        {
            ValidateDeployment(deployment);
        }

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        await foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeploymentsAsync(modelPublisher: modelPublisher))
        {
            ValidateDeployment(deployment);
        }

        Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
        ModelDeployment deploymentDetails = (ModelDeployment)await projectClient.Deployments.GetDeploymentAsync(modelDeploymentName);
        ValidateDeployment(deploymentDetails);
    }
}
