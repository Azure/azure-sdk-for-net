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

namespace Azure.AI.Projects.Tests;

public class Sample_Deployment : SamplesBase<AIProjectsTestEnvironment>
{
    private static void EnableSystemClientModelDebugging()
    {
        // Enable System.ClientModel diagnostics
        ActivitySource.AddActivityListener(new ActivityListener
        {
            ShouldListenTo = _ => true,
            Sample = (ref ActivityCreationOptions<ActivityContext> options) => ActivitySamplingResult.AllData,
            ActivityStarted = activity => Console.WriteLine($"Started: {activity.DisplayName}"),
            ActivityStopped = activity => Console.WriteLine($"Stopped: {activity.DisplayName} - Duration: {activity.Duration}")
        });
    }

    private static AIProjectClient CreateDebugClient(string endpoint)
    {
        var options = new AIProjectClientOptions();

        // Add custom pipeline policy for debugging
        options.AddPolicy(new DebugPipelinePolicy(), PipelinePosition.PerCall);

        return new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential(), options);
    }

    // Custom pipeline policy for debugging System.ClientModel requests
    private class DebugPipelinePolicy : PipelinePolicy
    {
        public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int index)
        {
            Console.WriteLine($"Request: {message.Request.Method} {message.Request.Uri}");

            ProcessNext(message, pipeline, index);

            Console.WriteLine($"Response: {message.Response?.Status} {message.Response?.ReasonPhrase}");
        }

        public override ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int index)
        {
            Console.WriteLine($"Async Request: {message.Request.Method} {message.Request.Uri}");

            var result = ProcessNextAsync(message, pipeline, index);

            Console.WriteLine($"Async Response: {message.Response?.Status} {message.Response?.ReasonPhrase}");

            return result;
        }
    }

    [Test]
    [SyncOnly]
    public void DeploymentExample()
    {
        #region Snippet:AI_Projects_DeploymentExampleSync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var modelPublisher = System.Environment.GetEnvironmentVariable("MODEL_PUBLISHER");

        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var modelPublisher = TestEnvironment.MODELPUBLISHER;

        // Enable debugging for System.ClientModel
        Sample_Deployment.EnableSystemClientModelDebugging();

        // Create client with debugging enabled
        AIProjectClient projectClient = Sample_Deployment.CreateDebugClient(endpoint);
#endif

        Console.WriteLine("List all deployments:");
        foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeployments())
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeployments(modelPublisher: modelPublisher))
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
        ModelDeployment deploymentDetails = (ModelDeployment)projectClient.Deployments.GetDeployment(modelDeploymentName);
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
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var modelPublisher = System.Environment.GetEnvironmentVariable("MODEL_PUBLISHER");

        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var modelPublisher = TestEnvironment.MODELPUBLISHER;

        // Enable debugging for System.ClientModel
        Sample_Deployment.EnableSystemClientModelDebugging();

        // Create client with debugging enabled
        AIProjectClient projectClient = Sample_Deployment.CreateDebugClient(endpoint);
#endif

        Console.WriteLine("List all deployments:");
        await foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeploymentsAsync())
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"List all deployments by the model publisher `{modelPublisher}`:");
        await foreach (AIProjectDeployment deployment in projectClient.Deployments.GetDeploymentsAsync(modelPublisher: modelPublisher))
        {
            Console.WriteLine(deployment);
        }

        Console.WriteLine($"Get a single model deployment named `{modelDeploymentName}`:");
        ModelDeployment deploymentDetails = (ModelDeployment)await projectClient.Deployments.GetDeploymentAsync(modelDeploymentName);
        Console.WriteLine(deploymentDetails);
        #endregion
    }
}
