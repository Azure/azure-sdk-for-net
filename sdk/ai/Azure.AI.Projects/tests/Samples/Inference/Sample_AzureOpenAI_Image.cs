// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI.Images;

namespace Azure.AI.Projects.Tests;

public class Sample_AzureOpenAI_Image : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void AzureOpenAIImage()
    {
        #region Snippet:AI_Projects_AzureOpenAIImageSync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionName = "";
        try
        {
            connectionName = TestEnvironment.CONNECTIONNAME;
        }
        catch
        {
            connectionName = null;
        }

#endif
        Console.WriteLine("Create the Azure OpenAI image client");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ImageClient imageClient = projectClient.GetAzureOpenAIImageClient(deploymentName: modelDeploymentName, connectionName: connectionName, apiVersion: null);

        Console.WriteLine("Generate an image");
        GeneratedImage result = imageClient.GenerateImage("A sunset over a mountain range");

        Console.WriteLine("Save the image to a file");
        byte[] imageData = result.ImageBytes.ToArray();
        System.IO.File.WriteAllBytes("sunset.png", imageData);
        Console.WriteLine($"Image saved as sunset.png ({imageData.Length} bytes)");
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task AzureOpenAIImageAsync()
    {
        #region Snippet:AI_Projects_AzureOpenAIImageAsync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var connectionName = System.Environment.GetEnvironmentVariable("CONNECTION_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionName = "";
        try
        {
            connectionName = TestEnvironment.CONNECTIONNAME;
        }
        catch
        {
            connectionName = null;
        }

#endif
        Console.WriteLine("Create the Azure OpenAI image client");
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ImageClient imageClient = projectClient.GetAzureOpenAIImageClient(deploymentName: modelDeploymentName, connectionName: connectionName, apiVersion: null);

        Console.WriteLine("Generate an image");
        GeneratedImage result = await imageClient.GenerateImageAsync("A sunset over a mountain range");

        Console.WriteLine("Save the image to a file");
        byte[] imageData = result.ImageBytes.ToArray();
        System.IO.File.WriteAllBytes("sunset.png", imageData);
        Console.WriteLine($"Image saved as sunset.png ({imageData.Length} bytes)");
        #endregion
    }
}
