// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.OneDP.Tests;

public class Sample_Deployment : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void DeploymentExample()
    {
        #region Snippet:DeploymentExampleSync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var deploymentName = System.Environment.GetEnvironmentVariable("DEPLOYMENT_NAME");
        var modelPublisher = System.Environment.GetEnvironmentVariable("MODEL_PUBLISHER");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var deploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
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

        Console.WriteLine($"Get a single deployment named `{deploymentName}`:");
        var deploymentDetails = deployments.GetDeployment(deploymentName);
        Console.WriteLine(deploymentDetails);
        #endregion
    }
}
