// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.AI.Inference.Tests.Samples
{
    public class Sample7_ChatCompletionsWithTools : SamplesBase<InferenceClientTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ChatCompletionsWithToolsScenario()
        {
            #region Snippet:Azure_AI_Inference_ChatCompletionsWithToolsScenario
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);
#endif

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

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

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What should I wear in Honolulu in 3 days?"),
                },
                Tools = { functionToolDef },
            };

            Response<ChatCompletions> response = client.Complete(requestOptions);
            System.Console.WriteLine(response.Value.Choices[0].Message.Content);

            ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
            ChatCompletionsToolCall functionToolCall = responseMessage.ToolCalls[0] as ChatCompletionsToolCall;
#if !SNIPPET
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            ChatChoice choice = response.Value.Choices[0];
            Assert.That(responseMessage.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(responseMessage.Content, Is.Null.Or.Empty);
            Assert.That(responseMessage.ToolCalls, Is.Not.Null.Or.Empty);
            Assert.That(responseMessage.ToolCalls.Count, Is.EqualTo(1));
            Assert.That(functionToolCall, Is.Not.Null);
            Assert.That(functionToolCall.Name, Is.EqualTo(futureTemperatureFunction.Name));
            Assert.That(functionToolCall.Arguments, Is.Not.Null.Or.Empty);

            Dictionary<string, string> arguments
                = JsonConvert.DeserializeObject<Dictionary<string, string>>(functionToolCall.Arguments);
            Assert.That(arguments.ContainsKey("locationName"));
            Assert.That(arguments.ContainsKey("daysInAdvance"));
#endif

            ChatCompletionsOptions followupOptions = new()
            {
                Tools = { functionToolDef },
            };

            // Include all original messages
            foreach (ChatRequestMessage originalMessage in requestOptions.Messages)
            {
                followupOptions.Messages.Add(originalMessage);
            }

            // Add the tool call message just received back from the assistant
            followupOptions.Messages.Add(new ChatRequestAssistantMessage(responseMessage));

            // And also the tool message that resolves the tool call
            followupOptions.Messages.Add(new ChatRequestToolMessage(
                toolCallId: functionToolCall.Id,
                content: "31 celsius"));

            Response<ChatCompletions> followupResponse = client.Complete(followupOptions);
            System.Console.WriteLine(followupResponse.Value.Choices[0].Message.Content);
            #endregion

            Assert.That(followupResponse, Is.Not.Null);
            Assert.That(followupResponse.Value, Is.Not.Null);
            Assert.That(followupResponse.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(followupResponse.Value.Choices[0], Is.Not.Null);
            Assert.That(followupResponse.Value.Choices[0].Message, Is.Not.Null);
            Assert.That(followupResponse.Value.Choices[0].Message.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(followupResponse.Value.Choices[0].Message.Content, Is.Not.Null.Or.Empty);
        }

        [Test]
        [AsyncOnly]
        public async Task ChatCompletionsWithToolsScenarioAsync()
        {
            #region Snippet:Azure_AI_Inference_ChatCompletionsWithToolsScenarioAsync
#if SNIPPET
            var endpoint = new Uri(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_ENDPOINT"));
            var credential = new AzureKeyCredential(System.Environment.GetEnvironmentVariable("AZURE_AI_CHAT_KEY"));
#else
            var endpoint = new Uri(TestEnvironment.MistralSmallEndpoint);
            var credential = new AzureKeyCredential(TestEnvironment.MistralSmallApiKey);
#endif

            var client = new ChatCompletionsClient(endpoint, credential, new AzureAIInferenceClientOptions());

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

            var requestOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatRequestSystemMessage("You are a helpful assistant."),
                    new ChatRequestUserMessage("What should I wear in Honolulu in 3 days?"),
                },
                Tools = { functionToolDef },
            };

            Response<ChatCompletions> response = await client.CompleteAsync(requestOptions);
            System.Console.WriteLine(response.Value.Choices[0].Message.Content);

            ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
            ChatCompletionsToolCall functionToolCall = responseMessage.ToolCalls[0] as ChatCompletionsToolCall;
#if !SNIPPET
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Value, Is.InstanceOf<ChatCompletions>());
            Assert.That(response.Value.Id, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Created, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(response.Value.Choices.Count, Is.EqualTo(1));
            ChatChoice choice = response.Value.Choices[0];
            Assert.That(responseMessage.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(responseMessage.Content, Is.Null.Or.Empty);
            Assert.That(responseMessage.ToolCalls, Is.Not.Null.Or.Empty);
            Assert.That(responseMessage.ToolCalls.Count, Is.EqualTo(1));
            Assert.That(functionToolCall, Is.Not.Null);
            Assert.That(functionToolCall.Name, Is.EqualTo(futureTemperatureFunction.Name));
            Assert.That(functionToolCall.Arguments, Is.Not.Null.Or.Empty);

            Dictionary<string, string> arguments
                = JsonConvert.DeserializeObject<Dictionary<string, string>>(functionToolCall.Arguments);
            Assert.That(arguments.ContainsKey("locationName"));
            Assert.That(arguments.ContainsKey("daysInAdvance"));
#endif

            ChatCompletionsOptions followupOptions = new()
            {
                Tools = { functionToolDef },
            };

            // Include all original messages
            foreach (ChatRequestMessage originalMessage in requestOptions.Messages)
            {
                followupOptions.Messages.Add(originalMessage);
            }

            // Add the tool call message just received back from the assistant
            followupOptions.Messages.Add(new ChatRequestAssistantMessage(responseMessage));

            // And also the tool message that resolves the tool call
            followupOptions.Messages.Add(new ChatRequestToolMessage(
                toolCallId: functionToolCall.Id,
                content: "31 celsius"));

            Response<ChatCompletions> followupResponse = await client.CompleteAsync(followupOptions);
            System.Console.WriteLine(followupResponse.Value.Choices[0].Message.Content);
            #endregion

            Assert.That(followupResponse, Is.Not.Null);
            Assert.That(followupResponse.Value, Is.Not.Null);
            Assert.That(followupResponse.Value.Choices, Is.Not.Null.Or.Empty);
            Assert.That(followupResponse.Value.Choices[0], Is.Not.Null);
            Assert.That(followupResponse.Value.Choices[0].Message, Is.Not.Null);
            Assert.That(followupResponse.Value.Choices[0].Message.Role, Is.EqualTo(ChatRole.Assistant));
            Assert.That(followupResponse.Value.Choices[0].Message.Content, Is.Not.Null.Or.Empty);
        }
    }
}
