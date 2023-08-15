// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
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
            var client = new OpenAIClient(nonAzureOpenAIApiKey, new OpenAIClientOptions());
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

            Response<StreamingChatCompletions> response = await client.GetChatCompletionsStreamingAsync(
                deploymentOrModelName: "gpt-3.5-turbo",
                chatCompletionsOptions);
            using StreamingChatCompletions streamingChatCompletions = response.Value;

            Dictionary<int, StringBuilder> choices = new();

            await foreach (ChatCompletionsChunk chunk in streamingChatCompletions.GetChatCompletionsChunks())
            {
                foreach (ChatChoiceChunk choice in chunk.Choices)
                {
                    if (!choices.ContainsKey(choice.Index))
                    {
                        choices[choice.Index] = new();
                    }
                    var builder = choices[choice.Index];
                    ChatMessageDelta delta = choice.Delta;

                    if (delta.Content != null)
                    {
                        builder.Append(delta.Content);
                    }
                    if (choice.FinishReason.HasValue)
                    {
                        Console.WriteLine($"Choice[{choice.Index}]");
                        Console.Write(builder.ToString());
                        Console.WriteLine($"Finish Reason: ${choice.FinishReason.Value}");
                    }
                }
            }
            #endregion
        }
    }
}
