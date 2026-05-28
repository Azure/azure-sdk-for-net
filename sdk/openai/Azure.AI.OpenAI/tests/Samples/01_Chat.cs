// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Identity;
using OpenAI.Chat;
using System;
using System.Buffers;
using System.ClientModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

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
                // User messages represent user input, whether historical or the most recent input
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

    #region
    public class StreamingChatToolCallsBuilder
    {
        private readonly Dictionary<int, string> _indexToToolCallId = [];
        private readonly Dictionary<int, string> _indexToFunctionName = [];
        private readonly Dictionary<int, SequenceBuilder<byte>> _indexToFunctionArguments = [];

        public void Append(StreamingChatToolCallUpdate toolCallUpdate)
        {
            // Keep track of which tool call ID belongs to this update index.
            if (toolCallUpdate.ToolCallId != null)
            {
                _indexToToolCallId[toolCallUpdate.Index] = toolCallUpdate.ToolCallId;
            }

            // Keep track of which function name belongs to this update index.
            if (toolCallUpdate.FunctionName != null)
            {
                _indexToFunctionName[toolCallUpdate.Index] = toolCallUpdate.FunctionName;
            }

            // Keep track of which function arguments belong to this update index,
            // and accumulate the arguments as new updates arrive.
            if (toolCallUpdate.FunctionArgumentsUpdate != null && !toolCallUpdate.FunctionArgumentsUpdate.ToMemory().IsEmpty)
            {
                if (!_indexToFunctionArguments.TryGetValue(toolCallUpdate.Index, out SequenceBuilder<byte> argumentsBuilder))
                {
                    argumentsBuilder = new SequenceBuilder<byte>();
                    _indexToFunctionArguments[toolCallUpdate.Index] = argumentsBuilder;
                }

                argumentsBuilder.Append(toolCallUpdate.FunctionArgumentsUpdate);
            }
        }

        public IReadOnlyList<ChatToolCall> Build()
        {
            List<ChatToolCall> toolCalls = [];

            foreach (KeyValuePair<int, string> indexToToolCallIdPair in _indexToToolCallId)
            {
                ReadOnlySequence<byte> sequence = _indexToFunctionArguments[indexToToolCallIdPair.Key].Build();

                ChatToolCall toolCall = ChatToolCall.CreateFunctionToolCall(
                    id: indexToToolCallIdPair.Value,
                    functionName: _indexToFunctionName[indexToToolCallIdPair.Key],
                    functionArguments: BinaryData.FromBytes(sequence.ToArray()));

                toolCalls.Add(toolCall);
            }

            return toolCalls;
        }
    }
    #endregion

    #region
    public class SequenceBuilder<T>
    {
        private Segment _first;
        private Segment _last;

        public void Append(ReadOnlyMemory<T> data)
        {
            if (_first == null)
            {
                Debug.Assert(_last == null);
                _first = new Segment(data);
                _last = _first;
            }
            else
            {
                _last = _last!.Append(data);
            }
        }

        public ReadOnlySequence<T> Build()
        {
            if (_first == null)
            {
                Debug.Assert(_last == null);
                return ReadOnlySequence<T>.Empty;
            }

            if (_first == _last)
            {
                Debug.Assert(_first.Next == null);
                return new ReadOnlySequence<T>(_first.Memory);
            }

            return new ReadOnlySequence<T>(_first, 0, _last!, _last!.Memory.Length);
        }

        private sealed class Segment : ReadOnlySequenceSegment<T>
        {
            public Segment(ReadOnlyMemory<T> items) : this(items, 0)
            {
            }

            private Segment(ReadOnlyMemory<T> items, long runningIndex)
            {
                Debug.Assert(runningIndex >= 0);
                Memory = items;
                RunningIndex = runningIndex;
            }

            public Segment Append(ReadOnlyMemory<T> items)
            {
                long runningIndex;
                checked { runningIndex = RunningIndex + Memory.Length; }
                Segment segment = new(items, runningIndex);
                Next = segment;
                return segment;
            }
        }
    }
    #endregion

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
        StringBuilder contentBuilder = new();
        StreamingChatToolCallsBuilder toolCallsBuilder = new();

        foreach (StreamingChatCompletionUpdate streamingChatUpdate
            in chatClient.CompleteChatStreaming(conversationMessages, options))
        {
            foreach (ChatMessageContentPart contentPart in streamingChatUpdate.ContentUpdate)
            {
                contentBuilder.Append(contentPart.Text);
            }

            foreach (StreamingChatToolCallUpdate toolCallUpdate in streamingChatUpdate.ToolCallUpdates)
            {
                toolCallsBuilder.Append(toolCallUpdate);
            }
        }

        IReadOnlyList<ChatToolCall> toolCalls = toolCallsBuilder.Build();

        AssistantChatMessage assistantMessage = new AssistantChatMessage(toolCalls);
        if (contentBuilder.Length > 0)
        {
            assistantMessage.Content.Add(ChatMessageContentPart.CreateTextPart(contentBuilder.ToString()));
        }

        conversationMessages.Add(assistantMessage);

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
