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

public partial class ChatTools
{
    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task LegacyChatFunctions()
    {
        string endpoint = "https://myaccount.openai.azure.com/";
        var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

        #region Snippet:ChatTools:DefineTool
        var getWeatherTool = new ChatCompletionsFunctionToolDefinition()
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

        #region Snippet:ChatTools:RequestWithFunctions
        var chatCompletionsOptions = new ChatCompletionsOptions()
        {
            DeploymentName = "gpt-35-turbo-1106",
            Messages = { new ChatRequestUserMessage("What's the weather like in Boston?") },
            Tools = { getWeatherTool },
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
        #endregion

        #region Snippet:ChatTools:HandleToolCalls
        // Purely for convenience and clarity, this standalone local method handles tool call responses.
        ChatRequestToolMessage GetToolCallResponseMessage(ChatCompletionsToolCall toolCall)
        {
            var functionToolCall = toolCall as ChatCompletionsFunctionToolCall;
            if (functionToolCall?.Name == getWeatherTool.Name)
            {
                // Validate and process the JSON arguments for the function call
                string unvalidatedArguments = functionToolCall.Arguments;
                var functionResultData = (object)null; // GetYourFunctionResultData(unvalidatedArguments);
                // Here, replacing with an example as if returned from "GetYourFunctionResultData"
                functionResultData = "31 celsius";
                return new ChatRequestToolMessage(functionResultData.ToString(), toolCall.Id);
            }
            else
            {
                // Handle other or unexpected calls
                throw new NotImplementedException();
            }
        }
        #endregion

        #region Snippet:ChatTools:HandleResponseWithToolCalls
        ChatChoice responseChoice = response.Value.Choices[0];
        if (responseChoice.FinishReason == CompletionsFinishReason.ToolCalls)
        {
            List<ChatRequestToolMessage> toolCallResolutionMessages = new();
            foreach (ChatCompletionsToolCall toolCall in responseChoice.Message.ToolCalls)
            {
                toolCallResolutionMessages.Add(GetToolCallResponseMessage(toolCall));
            }

            // Include the ToolCall message from the assistant in the conversation history, too
            var toolCallHistoryMessage = new ChatRequestAssistantMessage(responseChoice.Message.Content);
            foreach (ChatCompletionsToolCall requestedToolCall in responseChoice.Message.ToolCalls)
            {
                toolCallHistoryMessage.ToolCalls.Add(requestedToolCall);
            }

            // Now make a new request using all the messages, including the original
            chatCompletionsOptions.Messages.Add(toolCallHistoryMessage);
            foreach (ChatRequestToolMessage resolutionMessage in toolCallResolutionMessages)
            {
                chatCompletionsOptions.Messages.Add(resolutionMessage);
            }
        }
        #endregion

        #region Snippet:ChatTools:UseToolChoice
        chatCompletionsOptions.ToolChoice = ChatCompletionsToolChoice.Auto; // let the model decide
        chatCompletionsOptions.ToolChoice = ChatCompletionsToolChoice.None; // don't call tools
        chatCompletionsOptions.ToolChoice = getWeatherTool; // only use the specified tool
        #endregion
    }
}
