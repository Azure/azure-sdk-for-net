// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI.Chat;
using Azure.AI.OpenAI;
using Azure.Core.Diagnostics;

namespace Azure.AI.Projects.Tests;

public class Sample_AzureOpenAI : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void AzureOpenAIChatCompletion()
    {
        #region Snippet:AI_Projects_AzureOpenAISync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());
        ChatClient chatClient = projectClient.GetAzureOpenAIChatClient(deploymentName: modelDeploymentName, connectionName: null, apiVersion: null);

        ChatCompletion result = chatClient.CompleteChat("List all the rainbow colors");
        Console.WriteLine(result.Content[0].Text);
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task AzureOpenAIChatCompletionAsync()
    {
        #region Snippet:AI_Projects_AzureOpenAIAsync
#if SNIPPET
        var endpoint = System.Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
        var modelDeploymentName = System.Environment.GetEnvironmentVariable("MODEL_DEPLOYMENT_NAME");
#else
        var endpoint = TestEnvironment.PROJECTENDPOINT;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
#endif
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        ChatClient chatClient = projectClient.GetAzureOpenAIChatClient(deploymentName: modelDeploymentName, connectionName: null, apiVersion: null);

        ChatCompletion result = await chatClient.CompleteChatAsync("List all the rainbow colors");
        Console.WriteLine(result.Content[0].Text);
        #endregion
    }
}
