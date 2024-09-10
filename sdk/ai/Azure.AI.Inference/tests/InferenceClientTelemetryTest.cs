// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Inference.Telemetry;
using Azure.AI.Inference.Tests.Utilities;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Azure.AI.Inference.Tests
{
    public class InferenceClientTelemetryTest : RecordedTestBase<InferenceClientTestEnvironment>
    {
        private ChatCompletionsOptions m_requestOptions, m_requestStreamingOptions;

        public InferenceClientTelemetryTest(bool isAsync) : base(isAsync)
        { }

        [SetUp]
        public void setup()
        {
            m_requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What is the capital of France?"),
                },
                Model = "gpt-4o",
                Temperature = 1,
                MaxTokens = 10,
                AdditionalProperties = { { "top_p", BinaryData.FromObjectAsJson(0.9) } }
            };
            m_requestStreamingOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                     new ChatRequestUserMessage(
                         "Give me 5 good reasons why I should exercise every day."),
                },
                Model = "gpt-4o"
            };
            Environment.SetEnvironmentVariable(OpenTelemetryScope.ENABLE_ENV, "1");
        }

        public enum TestType
        {
            Plane,
            Streaming
        };

        private ChatCompletionsClient CreateClient(Uri endpoint)
        {
            return InstrumentClient(
                new ChatCompletionsClient(
                    endpoint,
                    new AzureKeyCredential(TestEnvironment.GithubToken),
                    InstrumentClientOptions(new ChatCompletionsClientOptions())));
        }

        private static async Task<StreamingRecordedResponse> getStreamingResponse(StreamingResponse<StreamingChatCompletionsUpdate> response)
        {
            var recordedResponse = new StreamingRecordedResponse();
            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                recordedResponse.Update(chatUpdate);
            }
            return recordedResponse;
        }

        [RecordedTest]
        [TestCase(TestType.Plane)]
        [TestCase(TestType.Streaming)]
        public async Task TestGoodChatResponse(TestType testType)
        {
            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var client = CreateClient(endpoint);
            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();
            AbstractRecordedResponse recordedResponse = null;
            switch (testType)
            {
                case TestType.Plane:
                    {
                        Response<ChatCompletions> response = await client.CompleteAsync(m_requestOptions);
                        recordedResponse = new SingleRecordedResponse(response);
                    }
                    break;
                case TestType.Streaming:
                    {
                        StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(m_requestStreamingOptions);
                        recordedResponse = await getStreamingResponse(response);
                    }
                    break;
            }
            // If we recorded response, the model tag may have changed and
            // we have to set model according to response.
            // For example, for gpt models the version is appended as a suffix.
            if (recordedResponse is StreamingRecordedResponse)
            {
                m_requestStreamingOptions.Model = recordedResponse.Model;
                actListener.validateStartActivity(m_requestStreamingOptions, endpoint);
            }
            else
            {
                m_requestOptions.Model = recordedResponse.Model;
                actListener.validateStartActivity(m_requestOptions, endpoint);
            }
            actListener.validateResponseEvents(recordedResponse);
            // TODO: When we will support usage tags on streaming
            // always set them and check.
            meterListener.ValidateTags(recordedResponse.Model, endpoint,
                testType == TestType.Plane);
            meterListener.VaidateDuration(recordedResponse.Model, endpoint);
        }

        [RecordedTest]
        [TestCase(TestType.Plane)]
        [TestCase(TestType.Streaming)]
        public async Task TestBadChatResponse(TestType testType)
        {
            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var client = CreateClient(endpoint);
            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();
            // Set the non existing model.
            m_requestOptions.Model = "6b6b217e-6ed3-11ef-9135-8c1645fec84b";
            m_requestStreamingOptions.Model = "6b6b217e-6ed3-11ef-9135-8c1645fec84b";
            try
            {
                switch (testType)
                {
                    case TestType.Plane: await client.CompleteAsync(m_requestOptions);
                        break;
                    case TestType.Streaming: await client.CompleteStreamingAsync(m_requestStreamingOptions);
                        break;
                };
                Assert.True(false, "The exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.That(ex is RequestFailedException, $"The exception was of wrong type {ex.GetType()}");
                // Our recrding infrastructure interpret the error as 500, while
                // it will be shown as AggregationException if we will run
                // on pure Client.
                actListener.validateErrorTag("400", ex.Message);
            }
        }
    }
}
