// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.Inference.Telemetry;
using Azure.AI.Inference.Tests.Utilities;
using Azure.Core.Pipeline;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Azure.AI.Inference.Tests.Utilities.TelemetryUtils;
using System.Text.Json;

namespace Azure.AI.Inference.Tests
{
    [NonParallelizable]
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
            using var _ = ConfigureInstrumentation(true, traceContent);

            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var client = CreateClient(endpoint);
            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();

            object GetChoiceEventMessage(string content)
            {
                return traceContent ? new { content } : new { };
            }

            RecordedResponse expectedResponse = new RecordedResponse();
            switch (testType)
            {
                case TestType.Basic:
                    {
                        Response<ChatCompletions> response = await client.CompleteAsync(_requestOptions);
                        actListener.ValidateStartActivity(_requestOptions, endpoint, traceContent);
                        expectedResponse.Id = response.Value.Id;
                        expectedResponse.Model = response.Value.Model;
                        expectedResponse.FinishReasons = response.Value.Choices.Select(c => c.FinishReason.ToString()).ToArray();
                        expectedResponse.PromptTokens = response.Value.Usage?.PromptTokens;
                        expectedResponse.CompletionTokens = response.Value.Usage?.CompletionTokens;
                        expectedResponse.Choices = response.Value.Choices.Select(c =>
                            new { finish_reason = c.FinishReason?.ToString(), index = 0, message = GetChoiceEventMessage(c.Message.Content) }).ToArray();
                    }
                    break;
                case TestType.Streaming:
                    {
                        if (withUsage)
                        {
                            _requestStreamingOptions.AdditionalProperties["stream_options"] = BinaryData.FromString("""{"include_usage" : true}""");
                        }
                        StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(_requestStreamingOptions);

                        StringBuilder[] fullContent = new[] { new StringBuilder() };
                        expectedResponse.FinishReasons = new string[1];
                        await foreach (var update in response)
                        {
                            UpdateResponse(expectedResponse, update, fullContent);
                        }

                        expectedResponse.Choices = new[] {
                            new { finish_reason = expectedResponse.FinishReasons[0], index = 0, message = GetChoiceEventMessage(fullContent[0].ToString()) }
                        };

                        actListener.ValidateStartActivity(_requestStreamingOptions, endpoint, traceContent);
                    }
                    break;
            }

            actListener.ValidateResponse(expectedResponse, null, null);

            if (withUsage)
            {
                meterListener.ValidateUsage(_requestOptions.Model, expectedResponse.Model, endpoint);
            }
            else
            {
                meterListener.ValidateUsageIsNotReported();
            }

            meterListener.ValidateDuration(_requestOptions.Model, expectedResponse.Model, endpoint, null);
        }

        [RecordedTest]
        [TestCase(TestType.Basic)]
        [TestCase(TestType.Streaming)]
        public async Task TestBadChatResponse(TestType testType)
        {
            using var _ = ConfigureInstrumentation(true, false);

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
                Assert.Fail("The exception was not thrown.");
            }
            catch (RequestFailedException ex)
            {
                actListener.ValidateResponse(null, "400", ex.Message);
                meterListener.ValidateDuration(_requestStreamingOptions.Model, null, endpoint, "400");
            }
        }

        [RecordedTest]
        [TestCase(TestType.Basic)]
        [TestCase(TestType.Streaming)]
        public async Task TestMultipleChoices(TestType testType)
        {
            using var _ = ConfigureInstrumentation(true, true);

            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var client = CreateClient(endpoint);
            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();

            RecordedResponse expectedResponse = new RecordedResponse();
            switch (testType)
            {
                case TestType.Basic:
                    {
                        _requestOptions.AdditionalProperties["n"] = BinaryData.FromString("2");
                        Response<ChatCompletions> response = await client.CompleteAsync(_requestOptions);
                        actListener.ValidateStartActivity(_requestOptions, endpoint, true);
                        expectedResponse.Id = response.Value.Id;
                        expectedResponse.Model = response.Value.Model;
                        expectedResponse.FinishReasons = response.Value.Choices.Select(c => c.FinishReason.ToString()).ToArray();
                        expectedResponse.PromptTokens = response.Value.Usage?.PromptTokens;
                        expectedResponse.CompletionTokens = response.Value.Usage?.CompletionTokens;
                        expectedResponse.Choices = response.Value.Choices.Select(c =>
                            new { finish_reason = c.FinishReason?.ToString(), index = c.Index, message = new { content = c.Message.Content } }).ToArray();
                    }
                    break;
                case TestType.Streaming:
                    {
                        _requestStreamingOptions.AdditionalProperties["stream_options"] = BinaryData.FromString("""{"include_usage" : true}""");
                        _requestStreamingOptions.AdditionalProperties["n"] = BinaryData.FromString("2");
                        StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(_requestStreamingOptions);

                        StringBuilder[] fullContent = new[] { new StringBuilder() };
                        expectedResponse.FinishReasons = new string[1];
                        await foreach (var update in response)
                        {
                            // Multiple choices are not reported for streaming calls so we can only validate the first one.
                            // If it's fixed, this test will fail and will need to be updated
                            Assert.Null(update.Choices);
                            UpdateResponse(expectedResponse, update, fullContent);
                        }

                        expectedResponse.Choices = new[] {
                            new { finish_reason = expectedResponse.FinishReasons[0], index = 0, message = new { content = fullContent[0].ToString() } },
                            // new { finish_reason = expectedResponse.FinishReasons[1], index = 0, message = new { content = fullContent[1].ToString() } }
                        };

                        actListener.ValidateStartActivity(_requestStreamingOptions, endpoint, true);
                    }
                    break;
            }

            actListener.ValidateResponse(expectedResponse, null, null);

            meterListener.ValidateUsage(_requestOptions.Model, expectedResponse.Model, endpoint);
            meterListener.ValidateDuration(_requestOptions.Model, expectedResponse.Model, endpoint, null);
        }

        [RecordedTest]
        [TestCase(TestType.Basic)]
        [TestCase(TestType.Streaming)]
        public async Task TestToolCalls(TestType testType)
        {
            using var _ = ConfigureInstrumentation(true, true);

            var endpoint = new Uri(TestEnvironment.GithubEndpoint);
            var client = CreateClient(endpoint);
            using var actListener = new ValidatingActivityListener();
            using var meterListener = new ValidatingMeterListener();

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What should I wear in Honolulu and Seattle in 3 days?"),
                },
                Model = "gpt-4o",
                Temperature = 1,
                Tools = { new ChatCompletionsFunctionToolDefinition(GetFutureTemperatureFunction()) },
                ToolChoice = ChatCompletionsToolChoice.Required,
                AdditionalProperties = { ["n"] = BinaryData.FromString("2") }
            };

            RecordedResponse expectedResponse = new RecordedResponse();
            switch (testType)
            {
                case TestType.Basic:
                    {
                        Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);

                        Assert.AreEqual(2, response.Value.Choices.Count);
                        foreach (var choice in response.Value.Choices)
                        {
                            // TODO: stop is returned along with the tool calls
                            // Assert.AreEqual(CompletionsFinishReason.ToolCalls, choice.FinishReason,
                            //   $"Unexpected finish reason - '{choice.FinishReason}', content - '{choice.Message.Content }'");

                            Assert.NotNull(choice.Message.ToolCalls);
                            Assert.AreEqual(2, choice.Message.ToolCalls.Count);
                        }

                        actListener.ValidateStartActivity(requestOptions, endpoint, true);
                        expectedResponse.Id = response.Value.Id;
                        expectedResponse.Model = response.Value.Model;
                        expectedResponse.FinishReasons = response.Value.Choices.Select(c => c.FinishReason.ToString()).ToArray();
                        expectedResponse.PromptTokens = response.Value.Usage?.PromptTokens;
                        expectedResponse.CompletionTokens = response.Value.Usage?.CompletionTokens;
                        expectedResponse.Choices = response.Value.Choices.Select(c => new {
                            finish_reason = c.FinishReason?.ToString(),
                            index = c.Index,
                            message = new { content = c.Message.Content, tool_calls = GetToolCalls(c.Message.ToolCalls) }
                        }).ToArray();
                    }
                    break;
                case TestType.Streaming:
                    {
                        requestOptions.AdditionalProperties["stream_options"] = BinaryData.FromString("""{"include_usage" : true}""");
                        StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(requestOptions);

                        StringBuilder[] fullContent = new[] { new StringBuilder() };
                        StringBuilder[] toolArgs = new[] { new StringBuilder(), new StringBuilder() };
                        string[] toolNames = new string[2];
                        string[] toolTypes = new string[2];
                        string[] toolCallIds = new string[2];
                        expectedResponse.FinishReasons = new string[1];
                        await foreach (var update in response)
                        {
                            // Multiple choices are not reported for streaming calls so we can only validate the first one.
                            // If it's fixed, this test will fail and will need to be updated
                            Assert.Null(update.Choices);
                            UpdateResponse(expectedResponse, update, fullContent);

                            if (update.ToolCallUpdate != null)
                            {
                                var index = update.ToolCallUpdate.ToolCallIndex;
                                toolCallIds[index] ??= update.ToolCallUpdate.Id;
                                toolTypes[index] ??= update.ToolCallUpdate.Type;
                                toolNames[index] ??= (update.ToolCallUpdate as StreamingFunctionToolCallUpdate)?.Name;
                                toolArgs[index].Append((update.ToolCallUpdate as StreamingFunctionToolCallUpdate)?.ArgumentsUpdate);
                            }
                        }

                        int toolCallsCount = (toolCallIds[0] != null ? 1 : 0) + (toolCallIds[1] != null ? 1 : 0);
                        Assert.AreEqual(2, toolCallsCount);
                        expectedResponse.Choices = new[] {
                            new { finish_reason = expectedResponse.FinishReasons[0], index = 0,
                                message = new { content = fullContent[0].ToString(), tool_calls = GetToolCalls(toolNames, toolTypes, toolCallIds, toolArgs) }
                        } };

                        actListener.ValidateStartActivity(requestOptions, endpoint, true);
                    }
                    break;
            }

            actListener.ValidateResponse(expectedResponse, null, null);

            meterListener.ValidateUsage(_requestOptions.Model, expectedResponse.Model, endpoint);
            meterListener.ValidateDuration(_requestOptions.Model, expectedResponse.Model, endpoint, null);
        }

        #region Helpers
        private ChatCompletionsClient CreateClient(Uri endpoint)
        {
            return InstrumentClient(
                new ChatCompletionsClient(
                    endpoint,
                    new AzureKeyCredential(TestEnvironment.GithubToken),
                    InstrumentClientOptions(new ChatCompletionsClientOptions())));
        }

        private object GetToolCalls(IEnumerable<ChatCompletionsToolCall> calls)
        {
            List<object> toolsCalls = new List<object>();
            foreach (ChatCompletionsToolCall call in calls)
            {
                toolsCalls.Add(new
                {
                    id = call.Id,
                    type = call.Type,
                    function = new
                    {
                        name = (call as ChatCompletionsFunctionToolCall)?.Name,
                        arguments = (call as ChatCompletionsFunctionToolCall)?.Arguments
                    },
                });
            }

            return toolsCalls;
        }

        private object GetToolCalls(string[] toolNames, string[] toolTypes, string[] toolIds, StringBuilder[] toolArgs)
        {
            List<object> toolsCalls = new List<object>();
            for (int i = 0; i < toolNames.Length; i++)
            {
                toolsCalls.Add(new
                {
                    id = toolIds[i],
                    type = toolTypes[i],
                    function = new
                    {
                        name = toolNames[i],
                        arguments = toolArgs[i].ToString()
                    },
                });
            }

            return toolsCalls;
        }

        private void UpdateResponse(RecordedResponse expectedResponse, StreamingChatCompletionsUpdate update, StringBuilder[] fullContents)
        {
            if (update.Id != null)
            {
                expectedResponse.Id = update.Id;
            }

            if (update.Model != null)
            {
                expectedResponse.Model = update.Model;
            }

            if (update.FinishReason != null)
            {
                expectedResponse.FinishReasons[0] = update.FinishReason.ToString();
            }

            if (update.ContentUpdate != null)
            {
                fullContents[0].Append(update.ContentUpdate);
            }

            if (update.Choices != null)
            {
                foreach (var choice in update.Choices)
                {
                    if (choice.FinishReason != null)
                    {
                        expectedResponse.FinishReasons[choice.Index] = choice.FinishReason.ToString();
                    }

                    if (choice.Delta?.Content != null)
                    {
                        fullContents[choice.Index].Append(choice.Delta?.Content);
                    }
                }
            }

            if (update.Usage != null)
            {
                expectedResponse.PromptTokens = update.Usage.PromptTokens;
                expectedResponse.CompletionTokens = update.Usage.CompletionTokens;
            }
        }

        private FunctionDefinition GetFutureTemperatureFunction() => new FunctionDefinition("get_future_temperature")
            {
                Description = "requests the anticipated future temperature at a provided location to help inform "
                    + "advice about topics like choice of attire",
                Parameters = BinaryData.FromObjectAsJson(new
                {
                    Type = "object",
                    Properties = new
                    {
                        LocationName = new
                        {
                            Type = "string",
                            Description = "the name or brief description of a location for weather information"
                        },
                        DaysInAdvance = new
                        {
                            Type = "integer",
                            Description = "the number of days in the future for which to retrieve weather information"
                        }
                    }
                },
                new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase })
            };

        private class AddAoaiAuthHeaderPolicy : HttpPipelinePolicy
        {
            public string AoaiKey { get; }

            public AddAoaiAuthHeaderPolicy(string key)
            {
                AoaiKey = key;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", AoaiKey);

                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", AoaiKey);

                return ProcessNextAsync(message, pipeline);
            }
        }
        #endregion
    }
}
