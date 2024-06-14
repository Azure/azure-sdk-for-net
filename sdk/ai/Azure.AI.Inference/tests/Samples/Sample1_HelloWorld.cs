// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.Collections.Generic;
using Azure.Identity;

namespace Azure.AI.Inference.Tests.Samples
{
    public partial class InferenceSamples: SamplesBase<InferenceClientTestEnvironment>
    {
        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/Samples/Sample1.HelloWorld.cs to write samples. */
        [Test]
        [SyncOnly]
        public void Scenario()
        {
            #region Snippet:Azure_AI_Inference_Scenario
            Console.WriteLine("Hello, world!");
            #endregion

            #region Snippet:Azure_AI_Inference_Scenario2
            var endpoint = new Uri(Environment.GetEnvironmentVariable("AOAI_CHAT_COMPLETIONS_ENDPOINT"));
            var credential = new DefaultAzureCredential();

            var client = new ChatCompletionsClient(endpoint, credential);

            var response = client.Complete(messages: new List<ChatRequestMessage>
            {
                new ChatRequestSystemMessage("You are a helpful assistant."),
                new ChatRequestUserMessage(BinaryData.FromString("How many feet are in a mile?"))
            });

            Console.WriteLine(response.Value.Choices.First().Message);
            #endregion
        }
    }
}
