// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

public partial class StreamingChat
{
    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task LegacyChatFunctions()
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
        var conversationMessages = new List<ChatRequestMessage>()
        {
            new ChatRequestUserMessage("What is the weather like in Boston?"),
        };

        var chatCompletionsOptions = new ChatCompletionsOptions()
        {
            DeploymentName = "gpt-35-turbo-0613",
        };
        foreach (ChatRequestMessage chatMessage in conversationMessages)
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
            conversationMessages.Add(new ChatRequestAssistantMessage(responseChoice.Message.Content)
            {
                FunctionCall = responseChoice.Message.FunctionCall,
            });

            if (responseChoice.Message.FunctionCall.Name == "get_current_weather")
            {
                // Validate and process the JSON arguments for the function call
                string unvalidatedArguments = responseChoice.Message.FunctionCall.Arguments;
                var functionResultData = (object)null; // GetYourFunctionResultData(unvalidatedArguments);
                // Here, replacing with an example as if returned from GetYourFunctionResultData
                functionResultData = "31 degrees celsius";
                // Serialize the result data from the function into a new chat message with the 'Function' role,
                // then add it to the messages after the first User message and initial response FunctionCall
                var functionResponseMessage = new ChatRequestFunctionMessage(
                    name: responseChoice.Message.FunctionCall.Name,
                    content: JsonSerializer.Serialize(
                        functionResultData,
                        new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }));
                conversationMessages.Add(functionResponseMessage);
                // Now make a new request using all three messages in conversationMessages
            }
        }
        #endregion

        #region Snippet::ChatFunctions::StreamingFunctions
        string functionName = null;
        StringBuilder contentBuilder = new();
        StringBuilder functionArgumentsBuilder = new();
        ChatRole? streamedRole = default;
        CompletionsFinishReason? finishReason = default;

        await foreach (StreamingChatCompletionsUpdate update
            in client.GetChatCompletionsStreaming(chatCompletionsOptions))
        {
            functionName ??= update.FunctionName;
            streamedRole ??= update.Role;
            finishReason ??= update.FinishReason;
            contentBuilder.Append(update.ContentUpdate);
            functionArgumentsBuilder.Append(update.FunctionArgumentsUpdate);
        }

        if (finishReason == CompletionsFinishReason.FunctionCall)
        {
            string lastContent = contentBuilder.ToString();
            string unvalidatedArguments = functionArgumentsBuilder.ToString();
            ChatRequestAssistantMessage chatMessageForHistory = new(contentBuilder.ToString())
            {
                FunctionCall = new(functionName, unvalidatedArguments),
            };
            conversationMessages.Add(chatMessageForHistory);

            // Handle from here just like the non-streaming case
        }
        #endregion

        #region Snippet::ChatFunctions::UseFunctionCall
        chatCompletionsOptions.FunctionCall = FunctionDefinition.Auto; // let the model decide
        chatCompletionsOptions.FunctionCall = FunctionDefinition.None; // don't call functions
        chatCompletionsOptions.FunctionCall = getWeatherFuntionDefinition; // use only the specified function
        #endregion
    }
}
