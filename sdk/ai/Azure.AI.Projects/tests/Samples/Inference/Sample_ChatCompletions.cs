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
    /*
    Instructions:
    1. If you are using a Serverless connection, you need to set the environment variable "USE_SERVERLESS_CONNECTION" to "true".
    2. If this environment variable is not set, the default connection type (AzureAI services) will be used.
    */

    [Test]
    public void ChatCompletions()
    {
        var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
        var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;

        ChatCompletionsClient chatClient = new AIProjectClient(connectionString, new DefaultAzureCredential()).GetChatCompletionsClient();

        var requestOptions = new ChatCompletionsOptions()
        {
            Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
            Model = modelDeploymentName
        };

        Response<ChatCompletions> response = chatClient.Complete(requestOptions);
        Console.WriteLine(response.Value.Content);
    }
}
