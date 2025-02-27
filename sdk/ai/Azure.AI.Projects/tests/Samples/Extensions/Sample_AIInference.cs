// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.AI.Inference;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests;

public class Sample_AIInference : SamplesBase<AIProjectsTestEnvironment>
{
        [Test]
        public void InferenceChatCompletion()
        {
            var connectionString = TestEnvironment.AzureAICONNECTIONSTRING;
            var modelDeploymentName = TestEnvironment.MODELDEPLOYMENTNAME;
            AIProjectClient client = new AIProjectClient(connectionString);
            var chatClient = client.GetChatCompletionsClient();

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
