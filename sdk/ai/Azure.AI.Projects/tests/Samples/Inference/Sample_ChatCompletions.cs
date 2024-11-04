// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.AI.Inference;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;
public class Sample_ChatCompletions
{
    [Test]
    public void ChatCompletions()
    {
        var connectionString = Environment.GetEnvironmentVariable("AZURE_AI_CONNECTION_STRING");
        InferenceClient client = new AIProjectClient(connectionString, new DefaultAzureCredential()).GetInferenceClient();

        ChatCompletionsClient chatClient = client.GetChatCompletionsClient();

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
