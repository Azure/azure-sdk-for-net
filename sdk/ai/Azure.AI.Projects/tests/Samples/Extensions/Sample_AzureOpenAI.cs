// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.AI.OpenAI;
using Azure.Core.TestFramework;
using NUnit.Framework;
using OpenAI.Chat;

namespace Azure.AI.Projects.Tests;

public class Sample_AzureOpenAI : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public void AzureOpenAIChatCompletion()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        AIProjectClient client = new AIProjectClient(connectionString);
        ChatClient chatClient = client.GetAzureOpenAIChatClient("gpt-4o-mini");

        ChatCompletion result = chatClient.CompleteChat("List all the rainbow colors");
        Console.WriteLine(result.Content[0].Text);
    }

    [Test]
    public void ThrowsWhenNoConnection()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
        AIProjectClient client = new AIProjectClient(connectionString);

        var ex = Assert.Throws<InvalidOperationException>(() =>
        {
            ChatClient chatClient = client.GetAzureOpenAIChatClient("gpt-4o-mini");
        });

        Assert.AreEqual(
            $"No connections found for '{ConnectionType.AzureOpenAI}'. At least one connection is required. Please add a new connection in the Azure AI Foundry portal by following the instructions here: https://aka.ms/azsdk/azure-ai-projects/how-to/connections-add",
            ex.Message);
        Console.WriteLine(ex.Message);
    }
}
