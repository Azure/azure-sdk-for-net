// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples
{
    public partial class StreamingChat
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task ChatFunctions()
        {
            string endpoint = "https://myaccount.openai.azure.com/";
            var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

            #region Snippet:ChatFunctions:DefineFunction
            var getWeatherFuntionDefinition = new FunctionDefinition()
            {
                Name = "get_current_weather",
                Description = "Get the current weather in a given location",
                Parameters = BinaryData.FromObjectAsJson(
                new
                {
                    Type = "object",
                    Properties = new
                    {
                        Location = new
                        {
                            Type = "string",
                            Description = "The city and state, e.g. San Francisco, CA",
                        },
                        Unit = new
                        {
                            Type = "string",
                            Enum = new[] { "celsius", "fahrenheit" },
                        }
                    },
                    Required = new[] { "location" },
                },
                new JsonSerializerOptions() {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
            };
            #endregion

            #region Snippet:ChatFunctions:RequestWithFunctions
            var conversationMessages = new List<ChatMessage>()
            {
                new(ChatRole.User, "What is the weather like in Boston?"),
            };

            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                DeploymentName = "gpt-35-turbo-0613",
            };
            foreach (ChatMessage chatMessage in conversationMessages)
            {
                chatCompletionsOptions.Messages.Add(chatMessage);
            }
            chatCompletionsOptions.Functions.Add(getWeatherFuntionDefinition);

            Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
            #endregion

            #region Snippet:ChatFunctions:HandleFunctionCall
            ChatChoice responseChoice = response.Value.Choices[0];
            if (responseChoice.FinishReason == CompletionsFinishReason.FunctionCall)
            {
                // Include the FunctionCall message in the conversation history
                conversationMessages.Add(responseChoice.Message);

                if (responseChoice.Message.FunctionCall.Name == "get_current_weather")
                {
                    // Validate and process the JSON arguments for the function call
                    string unvalidatedArguments = responseChoice.Message.FunctionCall.Arguments;
                    var functionResultData = (object)null; // GetYourFunctionResultData(unvalidatedArguments);
                    // Here, replacing with an example as if returned from GetYourFunctionResultData
                    functionResultData = new
                    {
                        Temperature = 31,
                        Unit = "celsius",
                    };
                    // Serialize the result data from the function into a new chat message with the 'Function' role,
                    // then add it to the messages after the first User message and initial response FunctionCall
                    var functionResponseMessage = new ChatMessage(
                        ChatRole.Function,
                        JsonSerializer.Serialize(
                            functionResultData,
                            new JsonSerializerOptions() {  PropertyNamingPolicy = JsonNamingPolicy.CamelCase }))
                    {
                        Name = responseChoice.Message.FunctionCall.Name
                    };
                    conversationMessages.Add(functionResponseMessage);
                    // Now make a new request using all three messages in conversationMessages
                }
            }
            #endregion
        }
    }
}
