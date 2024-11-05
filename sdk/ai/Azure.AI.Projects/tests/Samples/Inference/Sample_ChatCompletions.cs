// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.AI.Inference;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_ChatCompletions : SamplesBase<AIProjectsTestEnvironment>
{
    [Test]
    public void ChatCompletions()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        ChatCompletionsClient chatClient = new AIProjectClient(connectionString, new DefaultAzureCredential()).GetChatCompletionsClient();

        var requestOptions = new ChatCompletionsOptions()
        {
            Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
        };

        Response<ChatCompletions> response = chatClient.Complete(requestOptions);
        Console.WriteLine(response.Value.Content);
    }
}
