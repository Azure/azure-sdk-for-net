// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace Azure.Projects.OpenAI
{
    /// <summary>
    /// The chat processor for the OpenAI Chat Completions endpoint.
    /// </summary>
    public class ChatProcessor
    {
        /// <summary>
        /// Vector db. A change that will be reverted.
        /// </summary>
        public EmbeddingsVectorbase? VectorDb { get; set; }

        /// <summary>
        /// Tools to call.
        /// </summary>
        public ChatTools? Tools { get; set; }

        private readonly ChatClient _chat;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatProcessor"/> class.
        /// </summary>
        /// <param name="chat"></param>
        public ChatProcessor(ChatClient chat)
        {
            _chat = chat;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatProcessor"/> class.
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="embeddings"></param>
        /// <param name="tools"></param>
        public ChatProcessor(ChatClient chat, EmbeddingClient? embeddings, ChatTools? tools = default)
        {
            Tools = tools;
            _chat = chat;
            if (embeddings != null)
            {
                VectorDb = new(embeddings);
            }
        }

        /// <summary>
        /// Takes a turn in the chat conversation.
        /// </summary>
        /// <param name="conversation"></param>
        /// <param name="prompt"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ChatCompletion TakeTurn(List<ChatMessage> conversation, string prompt)
        {
            OnGround(conversation, prompt);

            conversation.Add(ChatMessage.CreateUserMessage(prompt));

        complete:
            ChatCompletion completion = OnComplete(conversation, prompt);

            switch (completion.FinishReason)
            {
                case ChatFinishReason.Stop:
                    OnStop(conversation, completion);
                    return completion;
                case ChatFinishReason.Length:
                    OnLength(conversation, completion);
                    goto complete;
                case ChatFinishReason.ToolCalls:
                    OnToolCalls(conversation, completion);
                    goto complete;
                default:
                    //case ChatFinishReason.ContentFilter:
                    //case ChatFinishReason.FunctionCall:
                    throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Grounds the conversation with the vector db.
        /// </summary>
        /// <param name="conversation"></param>
        /// <param name="prompt"></param>
        protected virtual void OnGround(List<ChatMessage> conversation, string prompt)
        {
            if (VectorDb == null) return;
            var related = VectorDb.Find(prompt);
            conversation.Add(related);
        }

        /// <summary>
        /// Completes the chat conversation.
        /// </summary>
        /// <param name="conversation"></param>
        /// <param name="prompt"></param>
        /// <returns></returns>
        protected virtual ChatCompletion OnComplete(List<ChatMessage> conversation, string prompt)
        {
            if (Tools != null)
            {
                ChatCompletion completion = _chat.CompleteChat(conversation, Tools.ToOptions());
                return completion;
            }
            else
            {
                ChatCompletion completion = _chat.CompleteChat(conversation);
                return completion;
            }
        }

        /// <summary>
        /// Stops the conversation.
        /// </summary>
        /// <param name="conversation"></param>
        /// <param name="completion"></param>
        protected virtual void OnStop(List<ChatMessage> conversation, ChatCompletion completion)
        {
            conversation.Add(completion);
        }

        /// <summary>
        /// Trims the conversation to half its size.
        /// </summary>
        /// <param name="conversation"></param>
        /// <param name="completion"></param>
        protected virtual void OnLength(List<ChatMessage> conversation, ChatCompletion completion)
        {
            conversation.RemoveRange(0, conversation.Count / 2);
        }

        /// <summary>
        /// Calls the tools.
        /// </summary>
        /// <param name="conversation"></param>
        /// <param name="completion"></param>
        protected virtual void OnToolCalls(List<ChatMessage> conversation, ChatCompletion completion)
        {
            if (Tools == null)
                throw new InvalidOperationException("No tools defined.");
            conversation.Add(completion);
            IEnumerable<ToolChatMessage> toolResults = Tools.CallAll(completion.ToolCalls);
            conversation.AddRange(toolResults);
        }
    }
}
