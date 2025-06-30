// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_Deployment : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void DeploymentExample()
    {
        #region Snippet:AI_Projects_DeploymentExampleSync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var modelPublisher = System.Environment.GetEnvironmentVariable("MODEL_PUBLISHER");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var modelPublisher = TestEnvironment.MODELPUBLISHER;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

        Console.WriteLine("List all deployments:");
        foreach (Deployment deployment in projectClient.Deployments.GetDeployments())
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        foreach (Deployment deployment in projectClient.Deployments.GetDeployments(modelPublisher: modelPublisher))
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
        ModelDeployment deploymentDetails = projectClient.Deployments.GetModelDeployment(modelDeploymentName);
        Console.WriteLine(deploymentDetails);
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task DeploymentExampleAsync()
    {
        #region Snippet:AI_Projects_DeploymentExampleAsync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("DEPLOYMENT_NAME");
        var modelPublisher = System.Environment.GetEnvironmentVariable("MODEL_PUBLISHER");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var modelPublisher = TestEnvironment.MODELPUBLISHER;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

        Console.WriteLine("List all deployments:");
        await foreach (Deployment deployment in projectClient.Deployments.GetDeploymentsAsync())
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        await foreach (Deployment deployment in projectClient.Deployments.GetDeploymentsAsync(modelPublisher: modelPublisher))
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
        ModelDeployment deploymentDetails = await projectClient.Deployments.GetModelDeploymentAsync(modelDeploymentName);
        Console.WriteLine(deploymentDetails);
        #endregion
    }
}
