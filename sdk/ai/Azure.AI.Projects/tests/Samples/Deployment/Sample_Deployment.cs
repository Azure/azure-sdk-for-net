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
        Deployments deployments = projectClient.GetDeploymentsClient();

        Console.WriteLine("List all deployments:");
        foreach (var deployment in deployments.GetDeployments())
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        foreach (var deployment in deployments.GetDeployments(modelPublisher: modelPublisher))
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"Get a single deployment named `{modelDeploymentName}`:");
        var deploymentDetails = deployments.GetDeployment(modelDeploymentName);
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
        Deployments deployments = projectClient.GetDeploymentsClient();

        Console.WriteLine("List all deployments:");
        await foreach (var deployment in deployments.GetDeploymentsAsync())
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        await foreach (var deployment in deployments.GetDeploymentsAsync(modelPublisher: modelPublisher))
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"Get a single deployment named `{modelDeploymentName}`:");
        var deploymentDetails = deployments.GetDeploymentAsync(modelDeploymentName);
        Console.WriteLine(deploymentDetails);
        #endregion
    }
}
