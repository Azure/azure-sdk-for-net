// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// #nullable disable

using System;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI.Chat;

namespace Azure.AI.Projects.Tests;

public class Sample_AzureOpenAI_Chat : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    [SyncOnly]
    public void AzureOpenAIChatCompletion()
    {
        #region Snippet:AI_Projects_AzureOpenAIChatSync
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
            connectionName = TestEnvironment.AOAICONNECTIONNAME;
        }
        catch
        {
            connectionName = null;
        }

#endif
        Console.WriteLine("Create the Azure OpenAI chat client");
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        AzureOpenAIClient azureOpenAIClient = (AzureOpenAIClient)projectClient.GetOpenAIClient(connectionName: connectionName, apiVersion: null);
        ChatClient chatClient = azureOpenAIClient.GetChatClient(deploymentName: modelDeploymentName);

        Console.WriteLine("Complete a chat");
        ChatCompletion result = chatClient.CompleteChat("List all the rainbow colors");
        Console.WriteLine(result.Content[0].Text);
        #endregion
    }

    [Test]
    [AsyncOnly]
    public async Task AzureOpenAIChatCompletionAsync()
    {
        #region Snippet:AI_Projects_AzureOpenAIChatAsync
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
            connectionName = TestEnvironment.AOAICONNECTIONNAME;
        }
        catch
        {
            connectionName = null;
        }
#endif
        Console.WriteLine("Create the Azure OpenAI chat client");
        AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
        AzureOpenAIClient azureOpenAIClient = (AzureOpenAIClient)projectClient.GetOpenAIClient(connectionName: connectionName, apiVersion: null);
        ChatClient chatClient = azureOpenAIClient.GetChatClient(deploymentName: modelDeploymentName);

        Console.WriteLine("Complete a chat");
        ChatCompletion result = await chatClient.CompleteChatAsync("List all the rainbow colors");
        Console.WriteLine(result.Content[0].Text);
        #endregion
    }
}
