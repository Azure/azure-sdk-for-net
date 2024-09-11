// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Inference.Telemetry;
using Azure.AI.Inference.Tests.Utilities;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.AI.Inference.Tests
{
    public class InferenceClientTelemetryTest : RecordedTestBase<InferenceClientTestEnvironment>
    {
        private ChatCompletionsOptions m_requestOptions, m_requestStreamingOptions;

        public InferenceClientTelemetryTest(bool isAsync) : base(isAsync)
        { }

        public enum TestType
        {
            Basic,
            Streaming
        };

        [SetUp]
        public void Setup()
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
                MaxTokens = 10
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
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableSwitchName, "1");
        }

        [RecordedTest]
        [TestCase(TestType.Basic)]
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
                case TestType.Basic:
                    {
                        Response<ChatCompletions> response = await client.CompleteAsync(m_requestOptions);
                        recordedResponse = new SingleRecordedResponse(response);
                    }
                    break;
                case TestType.Streaming:
                    {
                        StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(m_requestStreamingOptions);
                        recordedResponse = await GetStreamingResponse(response);
                    }
                    break;
            }
            // If we recorded response, the model tag may have changed and
            // we have to set model according to response.
            // For example, for gpt models the version is appended as a suffix.
            if (recordedResponse is StreamingRecordedResponse)
            {
                m_requestStreamingOptions.Model = recordedResponse.Model;
                actListener.ValidateStartActivity(m_requestStreamingOptions, endpoint);
            }
            else
            {
                m_requestOptions.Model = recordedResponse.Model;
                actListener.ValidateStartActivity(m_requestOptions, endpoint);
            }
            actListener.ValidateResponseEvents(recordedResponse);
            // TODO: When we will support usage tags on streaming
            // always set them and check.
            meterListener.ValidateTags(recordedResponse.Model, endpoint,
                testType == TestType.Basic);
            meterListener.VaidateDuration(recordedResponse.Model, endpoint);
        }

        [RecordedTest]
        [TestCase(TestType.Basic)]
        [TestCase(TestType.Streaming)]
        public async Task TestBadChatResponse(TestType testType)
        {
            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var client = CreateClient(endpoint);
            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();
            // Set the non existing model.
            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What is the capital of France?"),
                },
                Model = "6b6b217e-6ed3-11ef-9135-8c1645fec84b"
            };
            m_requestStreamingOptions.Model = "6b6b217e-6ed3-11ef-9135-8c1645fec84b";
            try
            {
                switch (testType)
                {
                    case TestType.Basic: await client.CompleteAsync(requestOptions);
                        break;
                    case TestType.Streaming: await client.CompleteStreamingAsync(m_requestStreamingOptions);
                        break;
                };
                Assert.True(false, "The exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.That(ex is RequestFailedException, $"The exception was of wrong type {ex.GetType()}");
                actListener.ValidateErrorTag("400", ex.Message);
            }
        }

        #region Helpers
        private static async Task<StreamingRecordedResponse> GetStreamingResponse(StreamingResponse<StreamingChatCompletionsUpdate> response)
        {
            var recordedResponse = new StreamingRecordedResponse();
            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                recordedResponse.Update(chatUpdate);
            }
            return recordedResponse;
        }

        private ChatCompletionsClient CreateClient(Uri endpoint)
        {
            return InstrumentClient(
                new ChatCompletionsClient(
                    endpoint,
                    new AzureKeyCredential(TestEnvironment.GithubToken),
                    InstrumentClientOptions(new ChatCompletionsClientOptions())));
        }
        #endregion
    }
}
