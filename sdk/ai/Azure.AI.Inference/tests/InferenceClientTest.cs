// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests
{
    public class InferenceClientTest: RecordedTestBase<InferenceClientTestEnvironment>
    {
        public InferenceClientTest(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        [RecordedTest]
        public async Task TestOperation()
        {
            var endpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);

            // var client = CreateClient(endpoint, credential);
            var client = new ChatCompletionsClient(endpoint, credential, new ChatCompletionsClientOptions());

            var response = await client.CompleteAsync(messages: new List<ChatRequestMessage>
            {
                new ChatRequestSystemMessage("You are a helpful assistant."),
                new ChatRequestUserMessage(BinaryData.FromObjectAsJson("How many feet are in a mile?"))
            });

            Assert.False(String.IsNullOrEmpty(response?.Value?.Choices?.First()?.Message?.Content));
        }

        #region Helpers
        private ChatCompletionsClient CreateClient(Uri endpoint, AzureKeyCredential credential)
        {
            return InstrumentClient(new ChatCompletionsClient(endpoint, credential, InstrumentClientOptions(new ChatCompletionsClientOptions())));
        }

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion
    }
}
