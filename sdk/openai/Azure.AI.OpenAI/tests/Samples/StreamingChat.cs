// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

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
            DeploymentName = "gpt-3.5-turbo", // Use DeploymentName for "model" with non-Azure clients
            Messages =
            {
                new ChatRequestSystemMessage("You are a helpful assistant. You will talk like a pirate."),
                new ChatRequestUserMessage("Can you help me?"),
                new ChatRequestAssistantMessage("Arrrr! Of course, me hearty! What can I do for ye?"),
                new ChatRequestUserMessage("What's the best way to train a parrot?"),
            }
        };

        await foreach (StreamingChatCompletionsUpdate chatUpdate in client.GetChatCompletionsStreaming(chatCompletionsOptions))
        {
            if (chatUpdate.Role.HasValue)
            {
                Console.Write($"{chatUpdate.Role.Value.ToString().ToUpperInvariant()}: ");
            }
            if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
            {
                Console.Write(chatUpdate.ContentUpdate);
            }
        }
        #endregion
    }

    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task StreamingChatWithMultipleChoices()
    {
        string nonAzureOpenAIApiKey = "your-api-key-from-platform.openai.com";
        var client = new OpenAIClient(nonAzureOpenAIApiKey, new OpenAIClientOptions());
        (object, string Text)[] textBoxes = new (object, string)[4];

        #region Snippet:StreamChatMessagesWithMultipleChoices
        // A ChoiceCount > 1 will feature multiple, parallel, independent text generations arriving on the
        // same response. This may be useful when choosing between multiple candidates for a single request.
        var chatCompletionsOptions = new ChatCompletionsOptions()
        {
            Messages = { new ChatRequestUserMessage("Write a limerick about bananas.") },
            ChoiceCount = 4
        };

        await foreach (StreamingChatCompletionsUpdate chatUpdate
            in client.GetChatCompletionsStreaming(chatCompletionsOptions))
        {
            // Choice-specific information like Role and ContentUpdate will also provide a ChoiceIndex that allows
            // StreamingChatCompletionsUpdate data for independent choices to be appropriately separated.
            if (chatUpdate.ChoiceIndex.HasValue)
            {
                int choiceIndex = chatUpdate.ChoiceIndex.Value;
                if (chatUpdate.Role.HasValue)
                {
                    textBoxes[choiceIndex].Text += $"{chatUpdate.Role.Value.ToString().ToUpperInvariant()}: ";
                }
                if (!string.IsNullOrEmpty(chatUpdate.ContentUpdate))
                {
                    textBoxes[choiceIndex].Text += chatUpdate.ContentUpdate;
                }
            }
        }
        #endregion
    }
}
