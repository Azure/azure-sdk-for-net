// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI.Chat;
using Azure.Identity;
using Azure.AI.Projects.Tests.Utils;

namespace Azure.AI.Projects.Tests;

public class AzureOpenAI_ChatTest : ProjectsClientTestBase
{
    public AzureOpenAI_ChatTest(bool isAsync) : base(isAsync)//, RecordedTestMode.Record)
    {
    }

    [TestCase]
    [RecordedTest]
    [Ignore("Calls to AzureOpenAIClient are not recorded yet")]
    public async Task AzureOpenAI_ChatTestAsync()
    {
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        var connectionName = TestEnvironment.AOAICONNECTIONNAME;

        Console.WriteLine("Create the Azure OpenAI chat client");
        AIProjectClient projectClient = GetTestClient();
        AzureOpenAIClient azureOpenAIClient = (AzureOpenAIClient)projectClient.GetOpenAIClient(connectionName: connectionName, apiVersion: null);
        ChatClient chatClient = azureOpenAIClient.GetChatClient(deploymentName: modelDeploymentName);

        Console.WriteLine("Complete a chat");
        ChatCompletion result = await chatClient.CompleteChatAsync("How many feet are in a mile?");
        Console.WriteLine(result.Content[0].Text);
        var contains = new[] { "5280", "5,280", "five thousand two hundred eighty", "five thousand two hundred and eighty" };
        Assert.That(contains.Any(item => result.Content[0].Text.Contains(item)), "The response should contain the number of feet in a mile.");
    }

    [TestCase]
    [RecordedTest]
    [Ignore("Calls to AzureOpenAIClient are not recorded yet")]
    public async Task AzureOpenAI_ChatTest_NoConnection()
    {
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

        Console.WriteLine("Create the Azure OpenAI chat client");
        AIProjectClient projectClient = GetTestClient();
        AzureOpenAIClient azureOpenAIClient = (AzureOpenAIClient)projectClient.GetOpenAIClient(connectionName: null, apiVersion: null);
        ChatClient chatClient = azureOpenAIClient.GetChatClient(deploymentName: modelDeploymentName);

        Console.WriteLine("Complete a chat");
        ChatCompletion result = await chatClient.CompleteChatAsync("How many feet are in a mile?");
        Console.WriteLine(result.Content[0].Text);
        var contains = new[] { "5280", "5,280", "five thousand two hundred eighty", "five thousand two hundred and eighty" };
        Assert.That(contains.Any(item => result.Content[0].Text.Contains(item)), "The response should contain the number of feet in a mile.");
    }
}
