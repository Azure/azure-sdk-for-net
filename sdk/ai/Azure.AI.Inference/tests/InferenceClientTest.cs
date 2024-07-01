// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests
{
    public class InferenceClientTest: RecordedTestBase<InferenceClientTestEnvironment>
    {
        public InferenceClientTest(bool isAsync) : base(isAsync, RecordedTestMode.Live)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        [RecordedTest]
        public async Task TestChatCompletions()
        {
            var mistralSmallEndpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var mistralSmallCredential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);

            // var client = CreateClient(endpoint, credential);
            var client = new ChatCompletionsClient(mistralSmallEndpoint, mistralSmallCredential, new ChatCompletionsClientOptions());

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
            };

            Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            ChatChoice choice = response.Value.Choices[0];
            Assert.That(choice.Index, Is.EqualTo(0));
            Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(choice.Message.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(choice.Message.Content, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        public async Task TestStreamingChatCompletions()
        {
            var mistralSmallEndpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var mistralSmallCredential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);

            // var client = CreateClient(endpoint, credential);
            var clientOptions = new ChatCompletionsClientOptions();
            var client = new ChatCompletionsClient(mistralSmallEndpoint, mistralSmallCredential, clientOptions);

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
                MaxTokens = 512,
            };

            StreamingResponse<StreamingChatCompletionsUpdate> response
                = await client.GetChatCompletionsStreamingAsync(requestOptions);
            Assert.That(response, Is.Not.Null);

            StringBuilder contentBuilder = new();
            string id = null;
            string model = null;
            bool gotRole = false;

            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                Assert.That(chatUpdate, Is.Not.Null);

                Assert.That(chatUpdate.Id, Is.Not.Null.Or.Empty);
                Assert.That(chatUpdate.Created, Is.GreaterThan(new DateTimeOffset(new DateTime(2023, 1, 1))));
                Assert.That(chatUpdate.Created, Is.LessThan(DateTimeOffset.UtcNow.AddDays(7)));

                if (!string.IsNullOrEmpty(chatUpdate.Id))
                {
                    Assert.That((id is null) || (id == chatUpdate.Id));
                    id = chatUpdate.Id;
                }
                if (!string.IsNullOrEmpty(chatUpdate.Model))
                {
                    Assert.That((model is null) || (model == chatUpdate.Model));
                    model = chatUpdate.Model;
                }
                if (chatUpdate.Role.HasValue)
                {
                    Assert.IsFalse(gotRole);
                    Assert.That(chatUpdate.Role.Value, Is.EqualTo(ChatRole.Assistant));
                    gotRole = true;
                }
                if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
                {
                    contentBuilder.Append(chatUpdate.ContentUpdate);
                }
            }

            Assert.IsTrue(!string.IsNullOrEmpty(id));
            Assert.IsTrue(!string.IsNullOrEmpty(model));
            Assert.IsTrue(gotRole);
            var result = contentBuilder.ToString();
            Assert.That(contentBuilder.ToString(), Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        public async Task TestSendModelExtras()
        {
            var mistralSmallEndpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var mistralSmallCredential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);

            CaptureRequestPayloadPolicy captureRequestPayloadPolicy = new CaptureRequestPayloadPolicy();
            ChatCompletionsClientOptions clientOptions = new ChatCompletionsClientOptions();
            clientOptions.AddPolicy(captureRequestPayloadPolicy, HttpPipelinePosition.PerCall);

            // var client = CreateClient(endpoint, credential);
            var client = new ChatCompletionsClient(mistralSmallEndpoint, mistralSmallCredential, clientOptions);
            List<ChatRequestMessage> messages = new List<ChatRequestMessage>
            {
                new ChatRequestSystemMessage("You are a helpful assistant."),
                new ChatRequestUserMessage("How many feet are in a mile?"),
            };
            Dictionary<string, BinaryData> additionalProperties = new Dictionary<string, BinaryData>() { { "foo", BinaryData.FromString("\"bar\"") } };

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
                AdditionalProperties = { { "foo", BinaryData.FromString("\"bar\"") } },
            };

            var exceptionThrown = false;
            try
            {
                 await client.CompleteAsync(requestOptions, UnknownParams.PassThrough);
            }
            catch (Exception e)
            {
                exceptionThrown = true;
                Assert.IsTrue(e.Message.Contains("Extra inputs are not permitted"));
                Assert.IsTrue(captureRequestPayloadPolicy._requestContent.Contains("foo"));
            }
            Assert.IsTrue(exceptionThrown);

            /*
            // To be enabled once UnknownParams is implemented in the service
            var response = await client.CompleteAsync(requestOptions, UnknownParams.Drop);

            Assert.IsTrue(captureRequestPayloadPolicy._requestContent.Contains("foo"));

            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            ChatChoice choice = response.Value.Choices[0];
            Assert.That(choice.Index, Is.EqualTo(0));
            Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(choice.Message.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(choice.Message.Content, Is.Not.Null.Or.Empty);
            */
        }

        #region Helpers
        private class CaptureRequestPayloadPolicy : HttpPipelinePolicy
        {
            public string _requestContent;
            public Dictionary<string, string> _requestHeaders;

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                var memStream = new MemoryStream();
                message.Request.Content.WriteTo(memStream, new System.Threading.CancellationToken());
                _requestContent = Encoding.UTF8.GetString(memStream.ToArray());

                _requestHeaders = message.Request.Headers.ToDictionary(a => a.Name, a => a.Value);

                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                var memStream = new MemoryStream();
                message.Request.Content.WriteTo(memStream, new System.Threading.CancellationToken());
                _requestContent = Encoding.UTF8.GetString(memStream.ToArray());

                _requestHeaders = message.Request.Headers.ToDictionary(a=>a.Name, a=>a.Value);

                return ProcessNextAsync(message, pipeline);
            }
        }

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
