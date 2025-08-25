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
using Azure.AI.Projects.Tests.Utils;

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

        AIProjectClient projectClient = GetTestClient();

        if (IsAsync)
        {
            await DeploymentTestAsync(projectClient, modelDeploymentName, modelPublisher);
        }
        else
        {
            DeploymentTestSync(projectClient, modelDeploymentName, modelPublisher);
        }
    }

    public void DeploymentTestSync(AIProjectClient projectClient, string modelDeploymentName, string modelPublisher)
    {
        Console.WriteLine("List all deployments:");
        foreach (AssetDeployment deployment in projectClient.Deployments.GetDeployments())
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        foreach (AssetDeployment deployment in projectClient.Deployments.GetDeployments(modelPublisher: modelPublisher))
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
        ModelDeployment deploymentDetails = (ModelDeployment) projectClient.Deployments.GetDeployment(modelDeploymentName);
        Console.WriteLine(deploymentDetails);
    }
    public async Task DeploymentTestAsync(AIProjectClient projectClient, string modelDeploymentName, string modelPublisher)
    {
        Console.WriteLine("List all deployments:");
        await foreach (AssetDeployment deployment in projectClient.Deployments.GetDeploymentsAsync())
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        await foreach (AssetDeployment deployment in projectClient.Deployments.GetDeploymentsAsync(modelPublisher: modelPublisher))
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
        ModelDeployment deploymentDetails = (ModelDeployment) await projectClient.Deployments.GetDeploymentAsync(modelDeploymentName);
        Console.WriteLine(deploymentDetails);
    }
}
