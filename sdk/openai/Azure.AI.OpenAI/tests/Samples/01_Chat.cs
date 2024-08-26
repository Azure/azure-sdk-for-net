// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Identity;
using OpenAI.Chat;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public void BasicChat()
    {
        #region Snippet:SimpleChatResponse
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");

        ChatCompletion completion = chatClient.CompleteChat(
            [
                // System messages represent instructions or other guidance about how the assistant should behave
                new SystemChatMessage("You are a helpful assistant that talks like a pirate."),
                // User messages represent user input, whether historical or the most recen tinput
                new UserChatMessage("Hi, can you help me?"),
                // Assistant messages in a request represent conversation history for responses
                new AssistantChatMessage("Arrr! Of course, me hearty! What can I do for ye?"),
                new UserChatMessage("What's the best way to train a parrot?"),
            ]);

        Console.WriteLine($"{completion.Role}: {completion.Content[0].Text}");
        #endregion
    }

    public void StreamingChat()
    {
        #region Snippet:StreamChatMessages
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");

        CollectionResult<StreamingChatCompletionUpdate> completionUpdates = chatClient.CompleteChatStreaming(
            [
                new SystemChatMessage("You are a helpful assistant that talks like a pirate."),
                new UserChatMessage("Hi, can you help me?"),
                new AssistantChatMessage("Arrr! Of course, me hearty! What can I do for ye?"),
                new UserChatMessage("What's the best way to train a parrot?"),
            ]);

        foreach (StreamingChatCompletionUpdate completionUpdate in completionUpdates)
        {
            foreach (ChatMessageContentPart contentPart in completionUpdate.ContentUpdate)
            {
                Console.Write(contentPart.Text);
            }
        }
        #endregion
    }

    public void ChatWithTools()
    {
        #region Snippet:ChatTools:DefineTool
        static string GetCurrentLocation()
        {
            // Call the location API here.
            return "San Francisco";
        }

        static string GetCurrentWeather(string location, string unit = "celsius")
        {
            // Call the weather API here.
            return $"31 {unit}";
        }

        ChatTool getCurrentLocationTool = ChatTool.CreateFunctionTool(
            functionName: nameof(GetCurrentLocation),
            functionDescription: "Get the user's current location"
        );

        ChatTool getCurrentWeatherTool = ChatTool.CreateFunctionTool(
            functionName: nameof(GetCurrentWeather),
            functionDescription: "Get the current weather in a given location",
            functionParameters: BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                    "location": {
                        "type": "string",
                        "description": "The city and state, e.g. Boston, MA"
                    },
                    "unit": {
                        "type": "string",
                        "enum": [ "celsius", "fahrenheit" ],
                        "description": "The temperature unit to use. Infer this from the specified location."
                    }
                },
                "required": [ "location" ]
            }
            """)
        );
        #endregion

        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");

        #region Snippet:ChatTools:RequestWithFunctions
        ChatCompletionOptions options = new()
        {
            Tools = { getCurrentLocationTool, getCurrentWeatherTool },
        };

        List<ChatMessage> conversationMessages =
            [
                new UserChatMessage("What's the weather like in Boston?"),
            ];
        ChatCompletion completion = chatClient.CompleteChat(conversationMessages);
        #endregion

        #region Snippet:ChatTools:HandleToolCalls
        // Purely for convenience and clarity, this standalone local method handles tool call responses.
        string GetToolCallContent(ChatToolCall toolCall)
        {
            if (toolCall.FunctionName == getCurrentWeatherTool.FunctionName)
            {
                // Validate arguments before using them; it's not always guaranteed to be valid JSON!
                try
                {
                    using JsonDocument argumentsDocument = JsonDocument.Parse(toolCall.FunctionArguments);
                    if (!argumentsDocument.RootElement.TryGetProperty("location", out JsonElement locationElement))
                    {
                        // Handle missing required "location" argument
                    }
                    else
                    {
                        string location = locationElement.GetString();
                        if (argumentsDocument.RootElement.TryGetProperty("unit", out JsonElement unitElement))
                        {
                            return GetCurrentWeather(location, unitElement.GetString());
                        }
                        else
                        {
                            return GetCurrentWeather(location);
                        }
                    }
                }
                catch (JsonException)
                {
                    // Handle the JsonException (bad arguments) here
                }
            }
            // Handle unexpected tool calls
            throw new NotImplementedException();
        }

        if (completion.FinishReason == ChatFinishReason.ToolCalls)
        {
            // Add a new assistant message to the conversation history that includes the tool calls
            conversationMessages.Add(new AssistantChatMessage(completion));

            foreach (ChatToolCall toolCall in completion.ToolCalls)
            {
                conversationMessages.Add(new ToolChatMessage(toolCall.Id, GetToolCallContent(toolCall)));
            }

            // Now make a new request with all the messages thus far, including the original
        }
        #endregion
    }

    public void StreamingChatToolCalls()
    {
        static string GetCurrentLocation()
        {
            // Call the location API here.
            return "San Francisco";
        }

        static string GetCurrentWeather(string location, string unit = "celsius")
        {
            // Call the weather API here.
            return $"31 {unit}";
        }

        ChatTool getCurrentLocationTool = ChatTool.CreateFunctionTool(
            functionName: nameof(GetCurrentLocation),
            functionDescription: "Get the user's current location"
        );

        ChatTool getCurrentWeatherTool = ChatTool.CreateFunctionTool(
            functionName: nameof(GetCurrentWeather),
            functionDescription: "Get the current weather in a given location",
            functionParameters: BinaryData.FromString("""
            {
                "type": "object",
                "properties": {
                    "location": {
                        "type": "string",
                        "description": "The city and state, e.g. Boston, MA"
                    },
                    "unit": {
                        "type": "string",
                        "enum": [ "celsius", "fahrenheit" ],
                        "description": "The temperature unit to use. Infer this from the specified location."
                    }
                },
                "required": [ "location" ]
            }
            """)
        );

        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");

        ChatCompletionOptions options = new()
        {
            Tools = { getCurrentLocationTool, getCurrentWeatherTool },
        };

        List<ChatMessage> conversationMessages =
            [
                new UserChatMessage("What's the weather like in Boston?"),
            ];

        #region Snippet:ChatTools:StreamingChatTools
        Dictionary<int, string> toolCallIdsByIndex = [];
        Dictionary<int, string> functionNamesByIndex = [];
        Dictionary<int, StringBuilder> functionArgumentBuildersByIndex = [];
        StringBuilder contentBuilder = new();

        foreach (StreamingChatCompletionUpdate streamingChatUpdate
            in chatClient.CompleteChatStreaming(conversationMessages, options))
        {
            foreach (ChatMessageContentPart contentPart in streamingChatUpdate.ContentUpdate)
            {
                contentBuilder.Append(contentPart.Text);
            }
            foreach (StreamingChatToolCallUpdate toolCallUpdate in streamingChatUpdate.ToolCallUpdates)
            {
                if (!string.IsNullOrEmpty(toolCallUpdate.Id))
                {
                    toolCallIdsByIndex[toolCallUpdate.Index] = toolCallUpdate.Id;
                }
                if (!string.IsNullOrEmpty(toolCallUpdate.FunctionName))
                {
                    functionNamesByIndex[toolCallUpdate.Index] = toolCallUpdate.FunctionName;
                }
                if (!string.IsNullOrEmpty(toolCallUpdate.FunctionArgumentsUpdate))
                {
                    StringBuilder argumentsBuilder
                        = functionArgumentBuildersByIndex.TryGetValue(toolCallUpdate.Index, out StringBuilder existingBuilder)
                            ? existingBuilder
                            : new();
                    argumentsBuilder.Append(toolCallUpdate.FunctionArgumentsUpdate);
                    functionArgumentBuildersByIndex[toolCallUpdate.Index] = argumentsBuilder;
                }
            }
        }

        List<ChatToolCall> toolCalls = [];
        foreach (KeyValuePair<int, string> indexToIdPair in toolCallIdsByIndex)
        {
            toolCalls.Add(ChatToolCall.CreateFunctionToolCall(
                indexToIdPair.Value,
                functionNamesByIndex[indexToIdPair.Key],
                functionArgumentBuildersByIndex[indexToIdPair.Key].ToString()));
        }

        conversationMessages.Add(new AssistantChatMessage(toolCalls, contentBuilder.ToString()));

        // Placeholder: each tool call must be resolved, like in the non-streaming case
        string GetToolCallOutput(ChatToolCall toolCall) => null;

        foreach (ChatToolCall toolCall in toolCalls)
        {
            conversationMessages.Add(new ToolChatMessage(toolCall.Id, GetToolCallOutput(toolCall)));
        }

        // Repeat with the history and all tool call resolution messages added
        #endregion
    }
}
