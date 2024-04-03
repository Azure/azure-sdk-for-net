// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
    public async Task ChatToolSample()
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
            // Add the assistant message with tool calls to the conversation history
            ChatRequestAssistantMessage toolCallHistoryMessage = new(responseChoice.Message);
            chatCompletionsOptions.Messages.Add(toolCallHistoryMessage);

            // Add a new tool message for each tool call that is resolved
            foreach (ChatCompletionsToolCall toolCall in responseChoice.Message.ToolCalls)
            {
                chatCompletionsOptions.Messages.Add(GetToolCallResponseMessage(toolCall));
            }

            // Now make a new request with all the messages thus far, including the original
        }
        #endregion

        #region Snippet:ChatTools:UseToolChoice
        chatCompletionsOptions.ToolChoice = ChatCompletionsToolChoice.Auto; // let the model decide
        chatCompletionsOptions.ToolChoice = ChatCompletionsToolChoice.None; // don't call tools
        chatCompletionsOptions.ToolChoice = getWeatherTool; // only use the specified tool
        #endregion
    }

    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task StreamingChatToolSample()
    {
        string endpoint = "https://myaccount.openai.azure.com/";
        var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

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
            new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
        };

        var chatCompletionsOptions = new ChatCompletionsOptions()
        {
            DeploymentName = "gpt-35-turbo-1106",
            Messages = { new ChatRequestUserMessage("What's the weather like in Boston?") },
            Tools = { getWeatherTool },
        };

        #region Snippet:ChatTools:StreamingChatTools
        Dictionary<int, string> toolCallIdsByIndex = new();
        Dictionary<int, string> functionNamesByIndex = new();
        Dictionary<int, StringBuilder> functionArgumentBuildersByIndex = new();
        StringBuilder contentBuilder = new();

        await foreach (StreamingChatCompletionsUpdate chatUpdate
            in await client.GetChatCompletionsStreamingAsync(chatCompletionsOptions))
        {
            if (chatUpdate.ToolCallUpdate is StreamingFunctionToolCallUpdate functionToolCallUpdate)
            {
                if (functionToolCallUpdate.Id != null)
                {
                    toolCallIdsByIndex[functionToolCallUpdate.ToolCallIndex] = functionToolCallUpdate.Id;
                }
                if (functionToolCallUpdate.Name != null)
                {
                    functionNamesByIndex[functionToolCallUpdate.ToolCallIndex] = functionToolCallUpdate.Name;
                }
                if (functionToolCallUpdate.ArgumentsUpdate != null)
                {
                    StringBuilder argumentsBuilder
                        = functionArgumentBuildersByIndex.TryGetValue(
                            functionToolCallUpdate.ToolCallIndex,
                            out StringBuilder existingBuilder) ? existingBuilder : new StringBuilder();
                    argumentsBuilder.Append(functionToolCallUpdate.ArgumentsUpdate);
                    functionArgumentBuildersByIndex[functionToolCallUpdate.ToolCallIndex] = argumentsBuilder;
                }
            }
            if (chatUpdate.ContentUpdate != null)
            {
                contentBuilder.Append(chatUpdate.ContentUpdate);
            }
        }

        ChatRequestAssistantMessage assistantHistoryMessage = new(contentBuilder.ToString());
        foreach (KeyValuePair<int, string> indexIdPair in toolCallIdsByIndex)
        {
            assistantHistoryMessage.ToolCalls.Add(new ChatCompletionsFunctionToolCall(
                id: indexIdPair.Value,
                functionNamesByIndex[indexIdPair.Key],
                functionArgumentBuildersByIndex[indexIdPair.Key].ToString()));
        }
        chatCompletionsOptions.Messages.Add(assistantHistoryMessage);

        // Add request tool messages and proceed just like non-streaming
        #endregion
    }
}
