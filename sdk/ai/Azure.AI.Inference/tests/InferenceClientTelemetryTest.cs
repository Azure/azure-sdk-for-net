// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Inference.Telemetry;
using Azure.AI.Inference.Tests.Utilities;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.Inference.Tests
{
    public class InferenceClientTelemetryTest : RecordedTestBase<InferenceClientTestEnvironment>
    {
        private ChatCompletionsOptions _requestOptions, _requestStreamingOptions;

        public InferenceClientTelemetryTest(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        public enum TestType
        {
            Basic,
            Streaming
        };

        [SetUp]
        public void Setup()
        {
            _requestOptions = new ChatCompletionsOptions()
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
            _requestStreamingOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage(
                        "Give me 5 good reasons why I should exercise every day."),
                },
                Model = "gpt-4o"
            };
        }

        [RecordedTest]
        [TestCase(TestType.Basic, true, true)]
        [TestCase(TestType.Basic, false, true)]
        [TestCase(TestType.Streaming, true, false)]
        [TestCase(TestType.Streaming, false, true)]
        [TestCase(TestType.Streaming, true, true)]
        public async Task TestGoodChatResponse(
            TestType testType,
            bool traceContent,
            bool withUsage
            )
        {
            if (testType == TestType.Basic)
                Assert.True(withUsage, "The Basic test cannot be without tag usage. Please correct the test.");
            using var _ = new TestAppContextSwitch(OpenTelemetryConstants.AppContextSwitch, "true");
            Environment.SetEnvironmentVariable(OpenTelemetryConstants.EnvironmentVariableTraceContents, traceContent.ToString());
            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var client = CreateClient(endpoint);
            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();
            AbstractRecordedResponse recordedResponse = null;
            switch (testType)
            {
                case TestType.Basic:
                    {
                        Response<ChatCompletions> response = await client.CompleteAsync(_requestOptions);
                        recordedResponse = new SingleRecordedResponse(response, traceContent);
                    }
                    break;
                case TestType.Streaming:
                    {
                        if (withUsage)
                        {
                            _requestStreamingOptions.AdditionalProperties["stream_options"] = BinaryData.FromObjectAsJson(
                                    new Dictionary<string, bool>() { { "include_usage", true } });
                        }
                        StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(_requestStreamingOptions);
                        recordedResponse = await GetStreamingResponse(response, traceContent);
                    }
                    break;
            }
            // If we recorded response, the model tag may have changed and
            // we have to set model according to response.
            // For example, for gpt models the version is appended as a suffix.
            if (recordedResponse is StreamingRecordedResponse)
            {
                _requestStreamingOptions.Model = recordedResponse.Model;
                actListener.ValidateStartActivity(_requestStreamingOptions, endpoint, traceContent);
            }
            else
            {
                _requestOptions.Model = recordedResponse.Model;
                actListener.ValidateStartActivity(_requestOptions, endpoint, traceContent);
            }
            actListener.ValidateResponseEvents(recordedResponse, traceContent);
            meterListener.ValidateTags(recordedResponse.Model, endpoint, withUsage);
            meterListener.VaidateDuration(recordedResponse.Model, endpoint);
        }

        [RecordedTest]
        [TestCase(TestType.Basic)]
        [TestCase(TestType.Streaming)]
        public async Task TestBadChatResponse(TestType testType)
        {
            using var _ = new TestAppContextSwitch(OpenTelemetryConstants.AppContextSwitch, "true");
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
            _requestStreamingOptions.Model = "6b6b217e-6ed3-11ef-9135-8c1645fec84b";
            try
            {
                switch (testType)
                {
                    case TestType.Basic: await client.CompleteAsync(requestOptions);
                        break;
                    case TestType.Streaming: await client.CompleteStreamingAsync(_requestStreamingOptions);
                        break;
                };
                Assert.True(false, "The exception was not thrown.");
            }
            catch (Exception ex)
            {
                Assert.That(ex is RequestFailedException, $"The exception was of wrong type {ex.GetType()}");
                actListener.ValidateErrorTag("400", ex.Message);
                meterListener.VaidateDuration(_requestStreamingOptions.Model, endpoint, "400");
            }
        }

        #region Helpers
        private static async Task<StreamingRecordedResponse> GetStreamingResponse(StreamingResponse<StreamingChatCompletionsUpdate> response, bool traceContent)
        {
            var recordedResponse = new StreamingRecordedResponse(traceContent);
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
