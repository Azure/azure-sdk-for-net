// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Azure.Identity;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using OpenAI;
using OpenAI.Responses;

namespace Azure.AI.Agents.Tests.Samples;

# region Snippet:Sample_CustomHeader_ImageGeneration
internal class HeaderPolicy(string image_deployment) : PipelinePolicy
{
    private const string image_deployment_header = "x-ms-oai-image-generation-deployment";

    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        message.Request.Headers.Add(image_deployment_header, image_deployment);
        ProcessNext(message, pipeline, currentIndex);
    }

    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        // Add your desired header name and value
        message.Request.Headers.Add(image_deployment_header, image_deployment);
        await ProcessNextAsync(message, pipeline, currentIndex);
    }
}
# endregion

public class Sample_ImageGeneration : AgentsTestBase
{
    [Test]
    [AsyncOnly]
    public async Task ImageGenerationAsync()
    {
        IgnoreSampleMayBe();
        #region Snippet:Sample_CreateClient_ImageGeneration
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var imageGenerationModelName = System.Environment.GetEnvironmentVariable("IMAGE_GENERATION_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var imageGenerationModelName = TestEnvironment.IMAGE_GENERATION_DEPLOYMENT_NAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());
        #endregion

        #region Snippet:Sample_CreateAgent_ImageGeneration_Async
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "Generate images based on user prompts.",
            Tools = {
                ResponseTool.CreateImageGenerationTool(
                    model: imageGenerationModelName,
                    quality: ImageGenerationToolQuality.Low,
                    size:ImageGenerationToolSize.W1024xH1024
                )
            }
        };
        AgentVersion agentVersion = await client.CreateAgentVersionAsync(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion

        #region Snippet:Sample_GetResponse_ImageGeneration_Async
        OpenAIClientOptions options = new();
        options.AddPolicy(new HeaderPolicy(imageGenerationModelName), PipelinePosition.PerCall);
        OpenAIClient openAIClient = client.GetOpenAIClient(options: options);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);

        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

        OpenAIResponse response = await responseClient.CreateResponseAsync(
            "Generate parody of Newton with apple.",
            responseOptions);
        #endregion
        #region Snippet:Sample_WaitForRun_ImageGeneration_Async
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed){
            await Task.Delay(TimeSpan.FromMilliseconds(500));
            response = await responseClient.GetResponseAsync(responseId:  response.Id);
        }
        #endregion
        #region Snippet:Sample_SaveImage_ImageGeneration
        foreach (ResponseItem item in response.OutputItems)
        {
            if (item is ImageGenerationCallResponseItem imageItem)
            {
                File.WriteAllBytes("newton.png", imageItem.ImageResultBytes.ToArray());
                Console.WriteLine($"Image downloaded and saved to: {Path.GetFullPath("newton.png")}");
            }
        }
        #endregion
        #region Snippet:Sample_Cleanup_ImageGeneration_Async
        await client.DeleteAgentVersionAsync(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    [Test]
    [SyncOnly]
    public void ImageGeneration()
    {
        IgnoreSampleMayBe();
#if SNIPPET
        var projectEndpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
        var imageGenerationModelName = System.Environment.GetEnvironmentVariable("IMAGE_GENERATION_DEPLOYMENT_NAME");
#else
        var projectEndpoint = TestEnvironment.PROJECT_ENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var imageGenerationModelName = TestEnvironment.IMAGE_GENERATION_DEPLOYMENT_NAME;
#endif
        AgentClient client = new(endpoint: new Uri(projectEndpoint), tokenProvider: new DefaultAzureCredential());

        #region Snippet:Sample_CreateAgent_ImageGeneration_Sync
        PromptAgentDefinition agentDefinition = new(model: modelDeploymentName)
        {
            Instructions = "Generate images based on user prompts.",
            Tools = {
                ResponseTool.CreateImageGenerationTool(
                    model: imageGenerationModelName,
                    quality: ImageGenerationToolQuality.Low,
                    size:ImageGenerationToolSize.W1024xH1024
                )
            }
        };
        AgentVersion agentVersion = client.CreateAgentVersion(
            agentName: "myAgent",
            options: new(agentDefinition));
        #endregion

        #region Snippet:Sample_GetResponse_ImageGeneration_Sync
        OpenAIClientOptions options = new();
        options.AddPolicy(new HeaderPolicy(imageGenerationModelName), PipelinePosition.PerCall);
        OpenAIClient openAIClient = client.GetOpenAIClient(options: options);
        OpenAIResponseClient responseClient = openAIClient.GetOpenAIResponseClient(modelDeploymentName);

        ResponseCreationOptions responseOptions = new();
        responseOptions.SetAgentReference(new AgentReference(name: agentVersion.Name));

        OpenAIResponse response = responseClient.CreateResponse(
            "Generate parody of Newton with apple.",
            responseOptions);
        #endregion
        #region Snippet:Sample_WaitForRun_ImageGeneration_Sync
        while (response.Status != ResponseStatus.Incomplete && response.Status != ResponseStatus.Failed && response.Status != ResponseStatus.Completed)
        {
            Thread.Sleep(TimeSpan.FromMilliseconds(500));
            response = responseClient.GetResponse(responseId: response.Id);
        }
        #endregion
        foreach (ResponseItem item in response.OutputItems)
        {
            if (item is ImageGenerationCallResponseItem imageItem)
            {
                File.WriteAllBytes("newton.png", imageItem.ImageResultBytes.ToArray());
                Console.WriteLine($"Image downloaded and saved to: {Path.GetFullPath("newton.png")}");
            }
        }
        #region Snippet:Sample_Cleanup_ImageGeneration_Sync
        client.DeleteAgentVersion(agentName: agentVersion.Name, agentVersion: agentVersion.Version);
        #endregion
    }

    public Sample_ImageGeneration(bool isAsync) : base(isAsync)
    { }
}
