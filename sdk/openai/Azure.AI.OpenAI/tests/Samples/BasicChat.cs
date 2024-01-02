// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

public partial class BasicChat
{
    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task StreamingChatWithNonAzureOpenAI()
    {
        #region Snippet:SimpleChatResponse
        Uri azureOpenAIResourceUri = new("https://my-resource.openai.azure.com/");
        AzureKeyCredential azureOpenAIApiKey = new(Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY"));
        OpenAIClient client = new(azureOpenAIResourceUri, azureOpenAIApiKey);

        var chatCompletionsOptions = new ChatCompletionsOptions()
        {
            DeploymentName = "gpt-3.5-turbo", // Use DeploymentName for "model" with non-Azure clients
            Messages =
            {
                // The system message represents instructions or other guidance about how the assistant should behave
                new ChatRequestSystemMessage("You are a helpful assistant. You will talk like a pirate."),
                // User messages represent current or historical input from the end user
                new ChatRequestUserMessage("Can you help me?"),
                // Assistant messages represent historical responses from the assistant
                new ChatRequestAssistantMessage("Arrrr! Of course, me hearty! What can I do for ye?"),
                new ChatRequestUserMessage("What's the best way to train a parrot?"),
            }
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
        ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
        Console.WriteLine($"[{responseMessage.Role.ToString().ToUpperInvariant()}]: {responseMessage.Content}");
        #endregion
    }

    [Test]
    [Ignore("Only verifying that the sample builds")]
    public void UseAzureActiveDirectory()
    {
        #region Snippet:CreateOpenAIClientTokenCredential
        string endpoint = "https://myaccount.openai.azure.com/";
        var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());
        #endregion
    }
}
