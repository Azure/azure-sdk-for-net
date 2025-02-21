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
        ChatClient chatClient = client.GetOpenAIChatClient("gpt-4o-mini");

        ChatCompletion completion = chatClient.CompleteChat(
            [
                new SystemChatMessage("You are a helpful assistant."),
                new UserChatMessage("List all the colors of the rainbow"),
            ]);

        Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");
    }
}
