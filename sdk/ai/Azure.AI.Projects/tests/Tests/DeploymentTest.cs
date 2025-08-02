// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Diagnostics;
using Azure.Identity;

namespace Azure.AI.Projects.Tests;

public class DeploymentTest : RecordedTestBase<AIProjectsTestEnvironment>
{
    public DeploymentTest(bool isAsync) : base(isAsync)
    {
        TestDiagnostics = false;
    }

    [RecordedTest]
    public void DeploymentTestSync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var modelPublisher = TestEnvironment.MODELPUBLISHER;

        // Create client with debugging enabled
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

        Console.WriteLine("List all deployments:");
        bool isEmpty = true;
        foreach (AssetDeployment deployment in projectClient.Deployments.Get())
        {
            Console.WriteLine(deployment);
            isEmpty = false;
            TestBase.ValidateDeployment(deployment);
        }
        Assert.False(isEmpty, "There should be at least one deployment in the project.");

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        isEmpty = true;
        foreach (AssetDeployment deployment in projectClient.Deployments.Get(modelPublisher: modelPublisher))
        {
            Console.WriteLine(deployment);
            isEmpty = false;
            TestBase.ValidateDeployment(deployment);
        }
        Assert.False(isEmpty, "There should be at least one deployment for the model publisher.");

        Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
        ModelDeployment deploymentDetails = projectClient.Deployments.GetModelDeployment(modelDeploymentName);
        TestBase.ValidateDeployment(deploymentDetails);
        Console.WriteLine(deploymentDetails);
    }

    [RecordedTest]
    public async Task DeploymentTestAsync()
    {
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var modelPublisher = TestEnvironment.MODELPUBLISHER;

        // Create client with debugging enabled
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

        Console.WriteLine("List all deployments:");
        await foreach (AssetDeployment deployment in projectClient.Deployments.GetAsync())
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        await foreach (AssetDeployment deployment in projectClient.Deployments.GetAsync(modelPublisher: modelPublisher))
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
        ModelDeployment deploymentDetails = await projectClient.Deployments.GetModelDeploymentAsync(modelDeploymentName);
        Console.WriteLine(deploymentDetails);
    }
}
