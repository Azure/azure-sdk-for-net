// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using NUnit.Framework;
using File = System.IO.File;

namespace Azure.AI.Inference.Tests
{
    public class ChatCompletionsClientTest: RecordedTestBase<InferenceClientTestEnvironment>
    {
        public enum TargetModel
        {
            MistralSmall,
            GitHubGpt4o,
            AoaiGpt4Turbo,
        }

        public enum ToolChoiceTestType
        {
            DoNotSpecifyToolChoice,
            UseAutoPresetToolChoice,
            UseNonePresetToolChoice,
            UseRequiredPresetToolChoice,
            UseFunctionByExplicitToolDefinitionForToolChoice,
            UseFunctionByImplicitToolDefinitionForToolChoice,
        }

        public enum ImageTestSourceKind
        {
            UsingInternetLocation,
            UsingStream,
            UsingBinaryData,
        }

        public ChatCompletionsClientTest(bool isAsync) : base(isAsync)
        {
            JsonPathSanitizers.Add("$.messages[*].content[*].image_url.url");
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        [RecordedTest]
        public async Task TestChatCompletions()
        {
            var mistralSmallEndpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var mistralSmallCredential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);

            var client = CreateClient(mistralSmallEndpoint, mistralSmallCredential, new AzureAIInferenceClientOptions());

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
        public async Task TestChatCompletionsWithEntraIdAuth()
        {
            var aoaiEndpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var entraIdCredential = TestEnvironment.Credential;

            CaptureRequestPayloadPolicy captureRequestPayloadPolicy = new CaptureRequestPayloadPolicy();
            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(captureRequestPayloadPolicy, HttpPipelinePosition.PerCall);

            BearerTokenAuthenticationPolicy tokenPolicy = new BearerTokenAuthenticationPolicy(entraIdCredential, new string[] { "https://cognitiveservices.azure.com/.default" });
            clientOptions.AddPolicy(tokenPolicy, HttpPipelinePosition.PerRetry);

            var client = CreateClient(aoaiEndpoint, entraIdCredential, clientOptions);

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
            };

            Response<ChatCompletions> response = null;
            try
            {
                response = await client.CompleteAsync(requestOptions);
            }
            catch (Exception ex)
            {
                var requestPayload = captureRequestPayloadPolicy._requestContent;
                var requestHeaders = captureRequestPayloadPolicy._requestHeaders;
                Assert.True(false, $"Request failed with the following exception:\n {ex}\n Request headers: {requestHeaders}\n Request payload: {requestPayload}");
            }

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

            var clientOptions = new AzureAIInferenceClientOptions();
            var client = CreateClient(mistralSmallEndpoint, mistralSmallCredential, clientOptions);

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("How many feet are in a mile?"),
                },
                MaxTokens = 512,
            };

            StreamingResponse<StreamingChatCompletionsUpdate> response = await client.CompleteStreamingAsync(requestOptions);
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
            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(captureRequestPayloadPolicy, HttpPipelinePosition.PerCall);

            var client = CreateClient(mistralSmallEndpoint, mistralSmallCredential, clientOptions);

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
                await client.CompleteAsync(requestOptions);
            }
            catch (Exception e)
            {
                exceptionThrown = true;
                Assert.IsTrue(e.Message.Contains("Extra inputs are not permitted"));
                Assert.IsTrue(captureRequestPayloadPolicy._requestContent.Contains("foo"));
                Assert.IsTrue(captureRequestPayloadPolicy._requestHeaders.ContainsKey("extra-parameters"));
                Assert.IsTrue(captureRequestPayloadPolicy._requestHeaders["extra-parameters"] == ExtraParameters.PassThrough);
            }
            Assert.IsTrue(exceptionThrown);

            exceptionThrown = false;
            try
            {
                 await client.CompleteAsync(requestOptions, ExtraParameters.PassThrough);
            }
            catch (Exception e)
            {
                exceptionThrown = true;
                Assert.IsTrue(e.Message.Contains("Extra inputs are not permitted"));
                Assert.IsTrue(captureRequestPayloadPolicy._requestContent.Contains("foo"));
            }
            Assert.IsTrue(exceptionThrown);

            /*
            // To be enabled once ExtraParameters is implemented in the service
            var response = await client.CompleteAsync(requestOptions, ExtraParameters.Drop);

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

        [RecordedTest]
        [TestCase(ToolChoiceTestType.DoNotSpecifyToolChoice, TargetModel.MistralSmall)]
        [TestCase(ToolChoiceTestType.UseAutoPresetToolChoice, TargetModel.MistralSmall)]
        [TestCase(ToolChoiceTestType.UseNonePresetToolChoice, TargetModel.MistralSmall)]
        [TestCase(ToolChoiceTestType.UseRequiredPresetToolChoice, TargetModel.MistralSmall, IgnoreReason = "Endpoint needs to be updated to support")]
        [TestCase(ToolChoiceTestType.UseFunctionByExplicitToolDefinitionForToolChoice, TargetModel.GitHubGpt4o)]
        [TestCase(ToolChoiceTestType.UseFunctionByImplicitToolDefinitionForToolChoice, TargetModel.GitHubGpt4o)]
        public async Task TestChatCompletionsFunctionToolHandling(ToolChoiceTestType toolChoiceType, TargetModel targetModel)
        {
            FunctionDefinition futureTemperatureFunction = new FunctionDefinition("get_future_temperature")
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

            ChatCompletionsToolDefinition functionToolDef = new ChatCompletionsToolDefinition(futureTemperatureFunction);

            var endpoint = targetModel switch
            {
                TargetModel.MistralSmall => new Uri(TestEnvironment.MistralSmallEndpoint),
                TargetModel.GitHubGpt4o => new Uri(TestEnvironment.GithubEndpoint),
                _ => throw new ArgumentException(nameof(targetModel)),
            };

            var credential = targetModel switch
            {
                TargetModel.MistralSmall => new AzureKeyCredential(TestEnvironment.MistralSmallApiKey),
                TargetModel.GitHubGpt4o => new AzureKeyCredential(TestEnvironment.GithubToken),
                _ => throw new ArgumentException(nameof(targetModel)),
            };

            var githubModelName = "gpt-4o";

            CaptureRequestPayloadPolicy captureRequestPayloadPolicy = new CaptureRequestPayloadPolicy();
            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(captureRequestPayloadPolicy, HttpPipelinePosition.PerCall);

            // Uncomment the following lines to enable enhanced log output
            // AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);
            // clientOptions.Diagnostics.IsLoggingContentEnabled = true;

            var client = CreateClient(endpoint, credential, clientOptions);

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What should I wear in Honolulu in 3 days?"),
                },
                MaxTokens = 512,
                Tools = { functionToolDef },
            };

            if (targetModel == TargetModel.GitHubGpt4o)
            {
                requestOptions.Model = githubModelName;
            }

            requestOptions.ToolChoice = toolChoiceType switch
            {
                ToolChoiceTestType.UseAutoPresetToolChoice => ChatCompletionsToolChoice.Auto,
                ToolChoiceTestType.UseNonePresetToolChoice => ChatCompletionsToolChoice.None,
                ToolChoiceTestType.UseRequiredPresetToolChoice => ChatCompletionsToolChoice.Required,
                ToolChoiceTestType.UseFunctionByExplicitToolDefinitionForToolChoice => new ChatCompletionsToolChoice(functionToolDef),
                ToolChoiceTestType.UseFunctionByImplicitToolDefinitionForToolChoice => functionToolDef,
                _ => null,
            };

            Response<ChatCompletions> response = null;
            try
            {
                response = await client.CompleteAsync(requestOptions);
            }
            catch (Exception ex)
            {
                var requestPayload = captureRequestPayloadPolicy._requestContent;
                var requestHeaders = captureRequestPayloadPolicy._requestHeaders;
                Assert.True(false, $"Request failed with the following exception:\n {ex}\n Request headers: {requestHeaders}\n Request payload: {requestPayload}");
            }

            Assert.That(response, Is.Not.Null);

            Assert.That(response.Value, Is.Not.Null);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);

            ChatChoice choice = response.Value.Choices[0];

            if (toolChoiceType == ToolChoiceTestType.UseNonePresetToolChoice)
            {
                Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
                Assert.That(choice.Message.ToolCalls, Is.Null.Or.Empty);
                // We finish the test here as there's no further exercise for 'none' beyond ensuring we didn't do what we
                // weren't meant to
                return;
            }
            else if (toolChoiceType == ToolChoiceTestType.UseAutoPresetToolChoice || toolChoiceType == ToolChoiceTestType.DoNotSpecifyToolChoice)
            {
                Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.ToolCalls));
                // and continue the test
            }
            else
            {
                Assert.That(choice.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
                // and continue the test, as we will have tool_calls
            }

            ChatResponseMessage message = choice.Message;
            Assert.That(message.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(message.Content, Is.Null.Or.Empty);
            Assert.That(message.ToolCalls, Is.Not.Null.Or.Empty);
            Assert.That(message.ToolCalls.Count, Is.EqualTo(1));
            ChatCompletionsToolCall functionToolCall = message.ToolCalls[0] as ChatCompletionsToolCall;
            Assert.That(functionToolCall, Is.Not.Null);
            Assert.That(functionToolCall.Name, Is.EqualTo(futureTemperatureFunction.Name));
            Assert.That(functionToolCall.Arguments, Is.Not.Null.Or.Empty);

            Dictionary<string, string> arguments
                = JsonConvert.DeserializeObject<Dictionary<string, string>>(functionToolCall.Arguments);
            Assert.That(arguments.ContainsKey("locationName"));
            Assert.That(arguments.ContainsKey("daysInAdvance"));

            ChatCompletionsOptions followupOptions = new()
            {
                Tools = { functionToolDef },
                MaxTokens = 512,
            };

            if (targetModel == TargetModel.GitHubGpt4o)
            {
                followupOptions.Model = githubModelName;
            }

            // Include all original messages
            foreach (ChatRequestMessage originalMessage in requestOptions.Messages)
            {
                followupOptions.Messages.Add(originalMessage);
            }

            // Add the tool call message just received back from the assistant
            followupOptions.Messages.Add(new ChatRequestAssistantMessage(choice.Message));

            // And also the tool message that resolves the tool call
            followupOptions.Messages.Add(new ChatRequestToolMessage(
                toolCallId: functionToolCall.Id,
                content: "31 celsius"));

            Response<ChatCompletions> followupResponse = null;
            try
            {
                followupResponse = await client.CompleteAsync(followupOptions);
            }
            catch (Exception ex)
            {
                var requestPayload = captureRequestPayloadPolicy._requestContent;
                var requestHeaders = captureRequestPayloadPolicy._requestHeaders;
                Assert.True(false, $"Request failed with the following exception:\n {ex}\n Request headers: {requestHeaders}\n Request payload: {requestPayload}");
            }

            Assert.That(followupResponse, Is.Not.Null);
            Assert.That(followupResponse.Value, Is.Not.Null);
            Assert.That(followupResponse.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(followupResponse.Value.Choices[0], Is.Not.Null);
            Assert.That(followupResponse.Value.Choices[0].Message, Is.Not.Null);
            Assert.That(followupResponse.Value.Choices[0].Message.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(followupResponse.Value.Choices[0].Message.Content, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [TestCase(ImageTestSourceKind.UsingInternetLocation)]
        [TestCase(ImageTestSourceKind.UsingStream)]
        [TestCase(ImageTestSourceKind.UsingBinaryData)]
        public async Task TestChatCompletionsWithImages(ImageTestSourceKind imageSourceKind)
        {
            var aoaiEndpoint = new Uri(TestEnvironment.AoaiEndpoint);
            // This isn't used currently, but is necessary because of the header handling for the generated client
            var aoaiKey = new AzureKeyCredential("foo");

            CaptureRequestPayloadPolicy captureRequestPayloadPolicy = new CaptureRequestPayloadPolicy();
            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(captureRequestPayloadPolicy, HttpPipelinePosition.PerCall);
            clientOptions.AddPolicy(new AddAoaiAuthHeaderPolicy(TestEnvironment), HttpPipelinePosition.PerCall);

            // Uncomment the following lines to enable enhanced log output
            // AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);
            // clientOptions.Diagnostics.IsLoggingContentEnabled = true;

            var client = CreateClient(aoaiEndpoint, aoaiKey, clientOptions);

            ChatMessageImageContentItem imageContentItem = imageSourceKind switch
            {
                ImageTestSourceKind.UsingInternetLocation => new(GetTestImageInternetUri(), ChatMessageImageDetailLevel.Low),
                ImageTestSourceKind.UsingStream => new(GetTestImageStream("image/jpg"), "image/jpg", ChatMessageImageDetailLevel.Low),
                ImageTestSourceKind.UsingBinaryData => new(GetTestImageData("image/jpg"), "image/jpg", ChatMessageImageDetailLevel.Low),
                _ => throw new ArgumentException(nameof(imageSourceKind)),
            };

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant that helps describe images."),
                    new ChatRequestUserMessage(
                        new ChatMessageTextContentItem("describe this image"),
                        imageContentItem),
                },
                MaxTokens = 2048,
            };

            Response<ChatCompletions> response = null;
            try
            {
                response = await client.CompleteAsync(requestOptions);
            }
            catch (Exception ex)
            {
                var requestPayload = captureRequestPayloadPolicy._requestContent;
                var requestHeaders = captureRequestPayloadPolicy._requestHeaders;
                Assert.True(false, $"Request failed with the following exception:\n {ex}\n Request headers: {requestHeaders}\n Request payload: {requestPayload}");
            }

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

        private class AddAoaiAuthHeaderPolicy : HttpPipelinePolicy
        {
            public InferenceClientTestEnvironment TestEnvironment { get; }
            public string Token { get; }

            public AddAoaiAuthHeaderPolicy(InferenceClientTestEnvironment testEnvironment)
            {
                TestEnvironment = testEnvironment;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", TestEnvironment.AoaiKey);

                ProcessNext(message, pipeline);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                // Add your desired header name and value
                message.Request.Headers.Add("api-key", TestEnvironment.AoaiKey);

                return ProcessNextAsync(message, pipeline);
            }
        }

        private ChatCompletionsClient CreateClient(Uri endpoint, AzureKeyCredential credential, AzureAIInferenceClientOptions clientOptions)
        {
            return InstrumentClient(new ChatCompletionsClient(endpoint, credential, InstrumentClientOptions(clientOptions)));
        }

        private ChatCompletionsClient CreateClient(Uri endpoint, TokenCredential credential, AzureAIInferenceClientOptions clientOptions)
        {
            return InstrumentClient(new ChatCompletionsClient(endpoint, credential, InstrumentClientOptions(clientOptions)));
        }

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }

        private Uri GetTestImageInternetUri()
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return new Uri("https://sanitized");
            }
            return new Uri("https://aka.ms/azsdk/azure-ai-inference/csharp/tests/juggling_balls.png");
        }

        private Stream GetTestImageStream(string mimeType)
        {
            if (Mode == RecordedTestMode.Playback)
            {
                return new MemoryStream();
            }
            return File.OpenRead(mimeType switch
            {
                "image/jpg" => TestEnvironment.TestImageJpgInputPath,
                _ => throw new ArgumentException(nameof(mimeType)),
            });
        }

        private BinaryData GetTestImageData(string mimeType)
            => BinaryData.FromStream(GetTestImageStream(mimeType));
        #endregion
    }
}
