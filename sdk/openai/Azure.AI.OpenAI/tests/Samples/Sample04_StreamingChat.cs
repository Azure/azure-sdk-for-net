// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples
{
    public partial class StreamingChat
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task StreamingChatWithNonAzureOpenAI()
        {
            #region Snippet:StreamChatMessages
            string nonAzureOpenAIApiKey = "your-api-key-from-platform.openai.com";
            var client = new OpenAIClient(nonAzureOpenAIApiKey, new OpenAIClientOptions()
            {
                DefaultDeploymentOrModelName = "gpt-3.5-turbo",
            });
            new OpenAIClient("foo");
            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                Messages =
                {
                    new ChatMessage(ChatRole.System, "You are a helpful assistant. You will talk like a pirate."),
                    new ChatMessage(ChatRole.User, "Can you help me?"),
                    new ChatMessage(ChatRole.Assistant, "Arrrr! Of course, me hearty! What can I do for ye?"),
                    new ChatMessage(ChatRole.User, "What's the best way to train a parrot?"),
                }
            };

            Response<StreamingChatCompletions> response = await client.GetChatCompletionsStreamingAsync(chatCompletionsOptions);
            using StreamingChatCompletions streamingChatCompletions = response.Value;

            await foreach (StreamingChatChoice choice in streamingChatCompletions.GetChoicesStreaming())
            {
                await foreach (ChatMessage message in choice.GetMessageStreaming())
                {
                    Console.Write(message.Content);
                }
                Console.WriteLine();
            }
            #endregion
        }
    }
}
