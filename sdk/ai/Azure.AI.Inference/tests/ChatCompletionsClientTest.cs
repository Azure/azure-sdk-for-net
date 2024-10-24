﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
            UsingFilePath
        }

        public ChatCompletionsClientTest(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
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
            ChatCompletions result = response.Value;
            Assert.That(result.Id, Is.Not.Null.Or.Empty);
            Assert.That(result.Created, Is.Not.Null.Or.Empty);
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
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
            ChatCompletions result = response.Value;
            Assert.That(result.Id, Is.Not.Null.Or.Empty);
            Assert.That(result.Created, Is.Not.Null.Or.Empty);
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        public async Task TestStreamingChatCompletions()
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
                MaxTokens = 512,
            };

            StreamingResponse<StreamingChatCompletionsUpdate> response = null;
            try
            {
                response = await client.CompleteStreamingAsync(requestOptions);
            }
            catch (Exception ex)
            {
                var requestPayload = captureRequestPayloadPolicy._requestContent;
                var requestHeaders = captureRequestPayloadPolicy._requestHeaders;
                Assert.True(false, $"Request failed with the following exception:\n {ex}\n Request headers: {requestHeaders}\n Request payload: {requestPayload}");
            }

            Assert.That(response, Is.Not.Null);

            StringBuilder contentBuilder = new();
            string id = null;
            string model = null;
            bool gotRole = false;

            // await ProcessStreamingResponse(response, messages);

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
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            ChatCompletions result = response.Value;
            Assert.That(result.Id, Is.Not.Null.Or.Empty);
            Assert.That(result.Created, Is.Not.Null.Or.Empty);

            if (toolChoiceType == ToolChoiceTestType.UseNonePresetToolChoice)
            {
                Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
                Assert.That(result.ToolCalls, Is.Null.Or.Empty);
                // We finish the test here as there's no further exercise for 'none' beyond ensuring we didn't do what we
                // weren't meant to
                return;
            }
            else if (toolChoiceType == ToolChoiceTestType.UseAutoPresetToolChoice || toolChoiceType == ToolChoiceTestType.DoNotSpecifyToolChoice)
            {
                Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.ToolCalls));
                // and continue the test
            }
            else
            {
                Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
                // and continue the test, as we will have tool_calls
            }

            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Null.Or.Empty);
            Assert.That(result.ToolCalls, Is.Not.Null.Or.Empty);
            Assert.That(result.ToolCalls.Count, Is.EqualTo(1));
            ChatCompletionsToolCall functionToolCall = result.ToolCalls[0] as ChatCompletionsToolCall;
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
            followupOptions.Messages.Add(new ChatRequestAssistantMessage(result));

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
            var requestPayload1 = captureRequestPayloadPolicy._requestContent;

            Assert.That(followupResponse, Is.Not.Null);
            Assert.That(followupResponse.Value, Is.Not.Null);
            Assert.That(followupResponse.Value.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(followupResponse.Value.Content, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        [TestCase(ImageTestSourceKind.UsingInternetLocation)]
        [TestCase(ImageTestSourceKind.UsingStream)]
        [TestCase(ImageTestSourceKind.UsingBinaryData)]
        [TestCase(ImageTestSourceKind.UsingFilePath)]
        public async Task TestChatCompletionsWithImages(ImageTestSourceKind imageSourceKind)
        {
            if (imageSourceKind == ImageTestSourceKind.UsingFilePath && Mode == RecordedTestMode.Playback)
            {
                Assert.Inconclusive("Unable to run test with file path in playback mode.");
            }

            var aoaiEndpoint = new Uri(TestEnvironment.AoaiEndpoint);
            var aoaiKey = new AzureKeyCredential(TestEnvironment.AoaiKey);

            CaptureRequestPayloadPolicy captureRequestPayloadPolicy = new CaptureRequestPayloadPolicy();
            AzureAIInferenceClientOptions clientOptions = new AzureAIInferenceClientOptions();
            clientOptions.AddPolicy(captureRequestPayloadPolicy, HttpPipelinePosition.PerCall);

            // Uncomment the following lines to enable enhanced log output
            // AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.Verbose);
            // clientOptions.Diagnostics.IsLoggingContentEnabled = true;

            var client = CreateClient(aoaiEndpoint, aoaiKey, clientOptions);

            ChatMessageImageContentItem imageContentItem = imageSourceKind switch
            {
                ImageTestSourceKind.UsingInternetLocation => new(GetTestImageInternetUri(), ChatMessageImageDetailLevel.Low),
                ImageTestSourceKind.UsingStream => new(GetTestImageStream("image/jpg"), "image/jpg", ChatMessageImageDetailLevel.Low),
                ImageTestSourceKind.UsingBinaryData => new(GetTestImageData("image/jpg"), "image/jpg", ChatMessageImageDetailLevel.Low),
                ImageTestSourceKind.UsingFilePath => new(TestEnvironment.TestImageJpgInputPath, "image/jpg", ChatMessageImageDetailLevel.Low),
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
            ChatCompletions result = response.Value;
            Assert.That(result.Id, Is.Not.Null.Or.Empty);
            Assert.That(result.Created, Is.Not.Null.Or.Empty);
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);
        }

        [RecordedTest]
        public async Task TestChatCompletionsUserAgent()
        {
            var mistralSmallEndpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var mistralSmallCredential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);

            var clientOptions = new AzureAIInferenceClientOptions();
            CaptureRequestPayloadPolicy captureRequestPayloadPolicy = new CaptureRequestPayloadPolicy();
            clientOptions.AddPolicy(captureRequestPayloadPolicy, HttpPipelinePosition.PerCall);
            AddAppIdPolicy addAppIdPolicy = new AddAppIdPolicy("MyAppId");
            clientOptions.AddPolicy(addAppIdPolicy, HttpPipelinePosition.PerCall);

            var client = CreateClient(mistralSmallEndpoint, mistralSmallCredential, clientOptions);

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
            ChatCompletions result = response.Value;
            Assert.That(result.Id, Is.Not.Null.Or.Empty);
            Assert.That(result.Created, Is.Not.Null.Or.Empty);
            Assert.That(result.FinishReason, Is.EqualTo(CompletionsFinishReason.Stopped));
            Assert.That(result.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(result.Content, Is.Not.Null.Or.Empty);

            string userAgent = null;
            captureRequestPayloadPolicy._requestHeaders.TryGetValue("User-Agent", out userAgent);
            Assert.That(userAgent, Is.Not.Null.Or.Empty);
            Assert.That(userAgent.StartsWith("MyAppId"));
        }

        [RecordedTest]
        [TestCase(ToolChoiceTestType.DoNotSpecifyToolChoice, TargetModel.MistralSmall)]
        [TestCase(ToolChoiceTestType.UseAutoPresetToolChoice, TargetModel.MistralSmall)]
        [TestCase(ToolChoiceTestType.UseNonePresetToolChoice, TargetModel.MistralSmall)]
        [TestCase(ToolChoiceTestType.UseRequiredPresetToolChoice, TargetModel.MistralSmall, IgnoreReason = "Endpoint needs to be updated to support")]
        [TestCase(ToolChoiceTestType.UseFunctionByExplicitToolDefinitionForToolChoice, TargetModel.GitHubGpt4o)]
        [TestCase(ToolChoiceTestType.UseFunctionByExplicitToolDefinitionForToolChoice, TargetModel.AoaiGpt4Turbo)]
        [TestCase(ToolChoiceTestType.UseFunctionByImplicitToolDefinitionForToolChoice, TargetModel.GitHubGpt4o)]
        public async Task TestChatCompletionsFunctionToolHandlingWithStreaming(ToolChoiceTestType toolChoiceType, TargetModel targetModel)
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
                TargetModel.AoaiGpt4Turbo => new Uri(TestEnvironment.AoaiEndpoint),
                _ => throw new ArgumentException(nameof(targetModel)),
            };

            var credential = targetModel switch
            {
                TargetModel.MistralSmall => new AzureKeyCredential(TestEnvironment.MistralSmallApiKey),
                TargetModel.GitHubGpt4o => new AzureKeyCredential(TestEnvironment.GithubToken),
                TargetModel.AoaiGpt4Turbo => new AzureKeyCredential(TestEnvironment.AoaiKey),
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

            #region
            var messages = new List<ChatRequestMessage>()
            {
                new ChatRequestSystemMessage("You are a helpful assistant."),
                new ChatRequestUserMessage("What should I wear in Honolulu in 3 days?"),
            };

            var requestOptions = new ChatCompletionsOptions(messages)
            {
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
            #endregion

            #region

            StreamingResponse<StreamingChatCompletionsUpdate> response = null;
            string requestPayload = null;
            Dictionary<string, string> requestHeaders = null;
            try
            {
                response = await client.CompleteStreamingAsync(requestOptions);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Request failed with the following exception:\n {ex}\n Request headers: {requestHeaders}\n Request payload: {requestPayload}");
            }
            finally
            {
                requestPayload = captureRequestPayloadPolicy._requestContent;
                requestHeaders = captureRequestPayloadPolicy._requestHeaders;
            }

            await ProcessStreamingResponse(response, messages);

            if (toolChoiceType == ToolChoiceTestType.UseNonePresetToolChoice)
            {
                Assert.That(messages.Count == 3);
                // We finish the test here as there's no further exercise for 'none' beyond ensuring we didn't do what we
                // weren't meant to
                return;
            }

            ChatCompletionsOptions followupOptions = new ChatCompletionsOptions(messages)
            {
                Tools = { functionToolDef },
                MaxTokens = 512,
            };

            if (targetModel == TargetModel.GitHubGpt4o)
            {
                followupOptions.Model = githubModelName;
            }

            try
            {
                response = await client.CompleteStreamingAsync(followupOptions);
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Request failed with the following exception:\n {ex}\n Request headers: {requestHeaders}\n Request payload: {requestPayload}");
            }
            finally
            {
                requestPayload = captureRequestPayloadPolicy._requestContent;
                requestHeaders = captureRequestPayloadPolicy._requestHeaders;
            }

            await ProcessStreamingResponse(response, messages);
            #endregion

            Assert.That(messages.Count() > 4);

            #region
            foreach (ChatRequestMessage requestMessage in messages)
            {
                switch (requestMessage)
                {
                    case ChatRequestSystemMessage systemMessage:
                        Console.WriteLine($"[SYSTEM]:");
                        Console.WriteLine($"{systemMessage.Content}");
                        Console.WriteLine();
                        break;

                    case ChatRequestUserMessage userMessage:
                        Console.WriteLine($"[USER]:");
                        Console.WriteLine($"{userMessage.Content}");
                        Console.WriteLine();
                        break;

                    case ChatRequestAssistantMessage assistantMessage:
                        Console.WriteLine($"[ASSISTANT]:");
                        Console.WriteLine($"{assistantMessage.Content}");
                        Console.WriteLine();
                        break;

                    case ChatRequestToolMessage:
                        // Do not print any tool messages; let the assistant summarize the tool results instead.
                        break;

                    default:
                        break;
                }
            }
            #endregion
        }

        #region Helpers
        private class CaptureRequestPayloadPolicy : HttpPipelinePolicy
        {
            public string _requestContent;
            public Dictionary<string, string> _requestHeaders;

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                ProcessNext(message, pipeline);

                var memStream = new MemoryStream();
                message.Request.Content.WriteTo(memStream, new System.Threading.CancellationToken());
                _requestContent = Encoding.UTF8.GetString(memStream.ToArray());

                _requestHeaders = message.Request.Headers.ToDictionary(a => a.Name, a => a.Value);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                var task = ProcessNextAsync(message, pipeline);

                var memStream = new MemoryStream();
                message.Request.Content.WriteTo(memStream, new System.Threading.CancellationToken());
                _requestContent = Encoding.UTF8.GetString(memStream.ToArray());

                _requestHeaders = message.Request.Headers.ToDictionary(a => a.Name, a => a.Value);

                return task;
            }
        }

        private class AddAppIdPolicy : HttpPipelinePolicy
        {
            private string AppId { get; }

            public AddAppIdPolicy(string appId)
            {
                AppId = appId;
            }

            public override void Process(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                ProcessNext(message, pipeline);

                UpdateHeader(message);
            }

            public override ValueTask ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                var task = ProcessNextAsync(message, pipeline);

                UpdateHeader(message);

                return task;
            }

            private void UpdateHeader(HttpMessage message)
            {
                if (message.Request.Headers.TryGetValue("User-Agent", out string currentHeader) == false)
                {
                    // Add your desired header name and value
                    message.Request.Headers.Add("User-Agent", AppId);
                }
                else
                {
                    message.Request.Headers.SetValue("User-Agent", $"{AppId} {currentHeader}");
                }
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

        private async Task ProcessStreamingResponse(StreamingResponse<StreamingChatCompletionsUpdate> response, List<ChatRequestMessage> messages)
        {
            string toolCallId = null;
            string functionName = null;
            StringBuilder functionArguments = null;
            StringBuilder contentBuilder = new();

            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                // Accumulate the text content as new updates arrive.
                contentBuilder.Append(chatUpdate.ContentUpdate);

                // Build the tool calls as new updates arrive.
                StreamingChatResponseToolCallUpdate toolCallUpdate = chatUpdate.ToolCallUpdate;

                if (toolCallUpdate != null)
                {
                    if (toolCallUpdate.Id != null)
                    {
                        toolCallId = toolCallUpdate.Id;
                    }

                    // Keep track of which function name belongs to this update id.
                    if (toolCallUpdate.Function.Name is not null)
                    {
                        functionName = toolCallUpdate.Function.Name;
                    }

                    // Keep track of which function arguments belong to this update index,
                    // and accumulate the arguments string as new updates arrive.
                    if (toolCallUpdate.Function.Arguments is not null)
                    {
                        functionArguments ??= new StringBuilder();
                        functionArguments.Append(toolCallUpdate.Function.Arguments);
                    }
                }

                if (chatUpdate.FinishReason == CompletionsFinishReason.Stopped || chatUpdate.FinishReason == CompletionsFinishReason.ToolCalls)
                {
                    ProcessToolArguments(messages, contentBuilder, functionArguments, toolCallId, functionName);
                }
                else if (chatUpdate.FinishReason == CompletionsFinishReason.TokenLimitReached)
                {
                    throw new NotImplementedException("Incomplete model output due to MaxTokens parameter or token limit exceeded.");
                }
                else if (chatUpdate.FinishReason == CompletionsFinishReason.ContentFiltered)
                {
                    throw new NotImplementedException("Omitted content due to a content filter flag.");
                }
            }
        }

        private async Task ProcessMultiToolStreamingResponse(StreamingResponse<StreamingChatCompletionsUpdate> response, List<ChatRequestMessage> messages)
        {
            Dictionary<string, string> idToFunctionName = new Dictionary<string, string>();
            Dictionary<string, StringBuilder> idToFunctionArguments = new Dictionary<string, StringBuilder>();
            StringBuilder contentBuilder = new();

            await foreach (StreamingChatCompletionsUpdate chatUpdate in response)
            {
                // Accumulate the text content as new updates arrive.
                contentBuilder.Append(chatUpdate.ContentUpdate);

                // Build the tool calls as new updates arrive.
                StreamingChatResponseToolCallUpdate toolCallUpdate = chatUpdate.ToolCallUpdate;

                if (toolCallUpdate != null)
                {
                    // Keep track of which function name belongs to this update id.
                    if (toolCallUpdate.Function.Name is not null)
                    {
                        idToFunctionName[toolCallUpdate.Id] = toolCallUpdate.Function.Name;
                    }

                    // Keep track of which function arguments belong to this update index,
                    // and accumulate the arguments string as new updates arrive.
                    if (toolCallUpdate.Function.Arguments is not null)
                    {
                        StringBuilder argumentsBuilder
                            = idToFunctionArguments.TryGetValue(toolCallUpdate.Id, out StringBuilder existingBuilder)
                                ? existingBuilder
                                : new StringBuilder();
                        argumentsBuilder.Append(toolCallUpdate.Function.Arguments);
                        idToFunctionArguments[toolCallUpdate.Id] = argumentsBuilder;
                    }
                }

                if (chatUpdate.FinishReason == CompletionsFinishReason.Stopped)
                {
                    // Add the assistant message to the conversation history.
                    messages.Add(new ChatRequestAssistantMessage(contentBuilder.ToString()));
                }
                else if (chatUpdate.FinishReason == CompletionsFinishReason.ToolCalls)
                {
                    // First, collect the accumulated function arguments into complete tool calls to be processed
                    List<ChatCompletionsToolCall> toolCalls = new();
                    foreach (var id in idToFunctionName.Keys)
                    {
                        ChatCompletionsToolCall toolCall = ChatCompletionsToolCall.CreateFunctionToolCall(
                            id,
                            idToFunctionName[id],
                            idToFunctionArguments[id].ToString());

                        toolCalls.Add(toolCall);
                    }

                    // Next, add the assistant message with tool calls to the conversation history.
                    string content = contentBuilder.Length > 0 ? contentBuilder.ToString() : null;
                    messages.Add(new ChatRequestAssistantMessage(toolCalls, content));

                    // Then, add a new tool message for each tool call to be resolved.
                    foreach (ChatCompletionsToolCall toolCall in toolCalls)
                    {
                        switch (toolCall.Name)
                        {
                            case "get_future_temperature":
                                {
                                    // The arguments that the model wants to use to call the function are specified as a
                                    // stringified JSON object based on the schema defined in the tool definition. Note that
                                    // the model may hallucinate arguments too. Consequently, it is important to do the
                                    // appropriate parsing and validation before calling the function.
                                    using JsonDocument argumentsJson = JsonDocument.Parse(toolCall.Arguments);
                                    bool hasLocation = argumentsJson.RootElement.TryGetProperty("locationName", out JsonElement location);
                                    bool hasDaysInAdvance = argumentsJson.RootElement.TryGetProperty("daysInAdvance", out JsonElement daysInAdvance);

                                    if (!hasLocation)
                                    {
                                        throw new ArgumentNullException(nameof(location), "The location argument is required.");
                                    }
                                    else if (!hasDaysInAdvance)
                                    {
                                        throw new ArgumentNullException(nameof(daysInAdvance), "The daysInAdvance argument is required.");
                                    }

                                    messages.Add(new ChatRequestToolMessage(
                                        toolCallId: toolCall.Id,
                                        content: "31 celsius"));
                                    break;
                                }
                            default:
                                {
                                    // Handle other unexpected calls.
                                    throw new NotImplementedException();
                                }
                        }
                    }
                }
                else if (chatUpdate.FinishReason == CompletionsFinishReason.TokenLimitReached)
                {
                    throw new NotImplementedException("Incomplete model output due to MaxTokens parameter or token limit exceeded.");
                }
                else if (chatUpdate.FinishReason == CompletionsFinishReason.ContentFiltered)
                {
                    throw new NotImplementedException("Omitted content due to a content filter flag.");
                }
            }
        }

        private void ProcessToolArguments(List<ChatRequestMessage> messages, StringBuilder contentBuilder, StringBuilder functionArguments, string toolId, string toolName)
        {
            if (toolId is null && toolName is null)
            {
                string content = contentBuilder.Length > 0 ? contentBuilder.ToString() : null;
                messages.Add(new ChatRequestAssistantMessage(content));
            }
            else
            {
                // First, collect the accumulated function arguments into complete tool calls to be processed
                ChatCompletionsToolCall toolCall = ChatCompletionsToolCall.CreateFunctionToolCall(
                    toolId,
                    toolName,
                    functionArguments.ToString());

                // Next, add the assistant message with tool calls to the conversation history.
                string content = contentBuilder.Length > 0 ? contentBuilder.ToString() : null;
                messages.Add(new ChatRequestAssistantMessage(new List<ChatCompletionsToolCall>() { toolCall }, content));

                // Then, add a new tool message for each tool call to be resolved.
                switch (toolCall.Name)
                {
                    case "get_future_temperature":
                        {
                            // The arguments that the model wants to use to call the function are specified as a
                            // stringified JSON object based on the schema defined in the tool definition. Note that
                            // the model may hallucinate arguments too. Consequently, it is important to do the
                            // appropriate parsing and validation before calling the function.
                            using JsonDocument argumentsJson = JsonDocument.Parse(toolCall.Arguments);
                            bool hasLocation = argumentsJson.RootElement.TryGetProperty("locationName", out JsonElement location);
                            bool hasDaysInAdvance = argumentsJson.RootElement.TryGetProperty("daysInAdvance", out JsonElement daysInAdvance);

                            if (!hasLocation)
                            {
                                throw new ArgumentNullException(nameof(location), "The location argument is required.");
                            }
                            else if (!hasDaysInAdvance)
                            {
                                throw new ArgumentNullException(nameof(daysInAdvance), "The daysInAdvance argument is required.");
                            }

                            messages.Add(new ChatRequestToolMessage(
                                toolCallId: toolCall.Id,
                                content: "31 celsius"));
                            break;
                        }
                    default:
                        {
                            // Handle other unexpected calls.
                            throw new NotImplementedException();
                        }
                }
            }
        }

        #endregion
    }
}
