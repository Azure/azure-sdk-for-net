// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using OpenAI.Chat;
using OpenAI.Embeddings;

namespace Azure.Projects.AI
{
    /// <summary>
    /// The chat processor for the OpenAI Chat Completions endpoint.
    /// </summary>
    public class ChatRunner
    {
        /// <summary>
        /// Vector db.
        /// </summary>
        public EmbeddingsStore? VectorDb { get; set; }

        /// <summary>
        /// Tools to call.
        /// </summary>
        public ChatTools Tools { get; protected set; }

        private readonly ChatClient _chat;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatRunner"/> class.
        /// </summary>
        /// <param name="chat"></param>
        public ChatRunner(ChatClient chat)
        {
            _chat = chat;
            Tools = new ChatTools();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChatRunner"/> class.
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="embeddings"></param>
        public ChatRunner(ChatClient chat, EmbeddingClient? embeddings)
        {
            _chat = chat;
            Tools = new ChatTools(embeddings);
            if (embeddings != null)
            {
                VectorDb = new MemoryEmbeddingsStore(embeddings);
            }
        }

        /// <summary>
        /// Takes a turn in the chat conversation.
        /// </summary>
        /// <param name="conversation"></param>
        /// <param name="prompt"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<ChatCompletion> TakeTurnAsync(List<ChatMessage> conversation, string prompt)
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
                    await OnToolCalls(conversation, completion).ConfigureAwait(false);
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
            var related = VectorDb.FindRelated(prompt);
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
                ChatCompletion completion = _chat.CompleteChat(conversation, Tools.ToOptions(prompt));
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
        protected virtual async Task OnToolCalls(List<ChatMessage> conversation, ChatCompletion completion)
        {
            if (Tools == null)
                throw new InvalidOperationException("No tools defined.");

            // for some reason I am getting tool calls for tools that dont exist.
            var toolResults = await Tools.CallAllWithErrors(completion.ToolCalls).ConfigureAwait(false);
            if (toolResults.Failed != null)
            {
                OnToolError(toolResults.Failed, conversation, completion);
            }
            else
            {
                conversation.Add(completion);
                conversation.AddRange(toolResults.Messages);
            }
        }

        /// <summary>
        /// Handles the error when a tool call fails.
        /// </summary>
        /// <param name="failed"></param>
        /// <param name="conversation"></param>
        /// <param name="completion"></param>
        protected virtual void OnToolError(List<string> failed, List<ChatMessage> conversation, ChatCompletion completion)
        {
            failed.ForEach(toolName => Console.WriteLine($"Failed to call tool: {toolName}"));
            conversation.Add(ChatMessage.CreateUserMessage("don't call tools that dont exist"));
        }
    }
}
