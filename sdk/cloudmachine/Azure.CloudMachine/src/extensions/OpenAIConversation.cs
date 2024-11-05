// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.CloudMachine.OpenAI.Embeddings;
using OpenAI.Chat;

namespace Azure.CloudMachine.OpenAI.Chat;

/// <summary>
/// A helper class for managing a conversation with the OpenAI chat API.
/// </summary>
public class OpenAIConversation
{
    internal EmbeddingsVectorbase Vectors { get; }
    internal ChatClient Chat { get; }
    internal ChatCompletionOptions Options { get; }

    /// <summary>
    /// The collection of ChatMessages that make up the conversation.
    /// </summary>
    public List<ChatMessage> Prompt { get; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenAIConversation"/> class.
    /// </summary>
    /// <param name="vectors"></param>
    /// <param name="chat"></param>
    /// <param name="options"></param>
    public OpenAIConversation(EmbeddingsVectorbase vectors, ChatClient chat, ChatCompletionOptions options)
    {
        Vectors = vectors;
        Chat = chat;
        Options = options;
    }

    /// <summary>
    /// Adds a fact to the conversation.
    /// </summary>
    /// <param name="fact"></param>
    public virtual void AddFact(string fact)
    {
        Vectors.Add(fact);
    }

    /// <summary>
    /// Sends a message to the model and processes the response.
    /// </summary>
    /// <param name="message"></param>
    public virtual void Say(string message)
    {
        IEnumerable<VectorbaseEntry> relatedItems = Vectors.Find(message);
        foreach (VectorbaseEntry relatedItem in relatedItems)
        {
            Prompt.Add(ChatMessage.CreateSystemMessage(relatedItem.Data.ToString()));
        }
        Prompt.Add(ChatMessage.CreateUserMessage(message));
        CallOpenAI();
    }

    /// <summary>
    /// Sends a message to the model and processes the response.
    /// </summary>
    /// <param name="message"></param>
    public virtual void Say(UserChatMessage message)
    {
        foreach (ChatMessageContentPart contentPart in message.Content)
        {
            if (contentPart.Kind == ChatMessageContentPartKind.Text)
            {
                IEnumerable<VectorbaseEntry> relatedItems = Vectors.Find(contentPart.Text);
                foreach (VectorbaseEntry relatedItem in relatedItems)
                {
                    Prompt.Add(ChatMessage.CreateSystemMessage(relatedItem.Data.ToString()));
                }
            }
        }
        Prompt.Add(message);
        CallOpenAI();
    }

    /// <summary>
    /// Handles tool calls in the completion.
    /// </summary>
    /// <param name="completion"></param>
    /// <returns></returns>
    public virtual bool OnToolCall(ChatCompletion completion)
    {
        // TODO: figure out why the model is returning bogus tool call results.
        // prompt.Add(new AssistantChatMessage(completion));
        // IEnumerable<ToolChatMessage> callResults = tools.CallAll(completion.ToolCalls);
        // prompt.AddRange(callResults);
        return true;
    }

    /// <summary>
    /// Handler which is invoked when the token limit is reached.
    /// </summary>
    /// <param name="completion"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public virtual bool OnTokenLimitReached(ChatCompletion completion)
    {
        throw new InvalidOperationException("Incomplete model output due to MaxTokens parameter or token limit exceeded.");
    }

    /// <summary>
    /// Handler which is invoked when the content filter is triggered.
    /// </summary>
    /// <param name="completion"></param>
    /// <returns></returns>
    public virtual bool OnContentFilter(ChatCompletion completion)
    {
        Prompt.Add(new AssistantChatMessage(completion));
        return false;
    }

    /// <summary>
    /// Handler which is invoked when the conversation is stopped.
    /// </summary>
    /// <param name="completion"></param>
    /// <returns></returns>
    public virtual bool OnConversationStopped(ChatCompletion completion)
    {
        Prompt.Add(new AssistantChatMessage(completion));
        return false;
    }

    /// <summary>
    /// Handler which is invoked when the finish reason is unknown.
    /// </summary>
    /// <param name="completion"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public virtual bool OnUnknownFinishReason(ChatCompletion completion)
    {
        throw new NotImplementedException("Unknown finish reason.");
    }

    private void CallOpenAI()
    {
        bool requiresAction;
        do
        {
            var completion = Chat.CompleteChat(Prompt, Options).Value;
            switch (completion.FinishReason)
            {
                case ChatFinishReason.ToolCalls:
                    requiresAction = OnToolCall(completion);
                    break;
                case ChatFinishReason.Length:
                    requiresAction = OnTokenLimitReached(completion);
                    break;
                case ChatFinishReason.ContentFilter:
                    requiresAction = OnContentFilter(completion);
                    break;
                case ChatFinishReason.Stop:
                    requiresAction = OnConversationStopped(completion);
                    break;
                default:
                    requiresAction = OnUnknownFinishReason(completion);
                    break;
            }
        } while (requiresAction);
    }
}
