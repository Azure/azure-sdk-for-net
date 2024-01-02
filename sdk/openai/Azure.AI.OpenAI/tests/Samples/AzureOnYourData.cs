// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

public partial class AzureOnYourData
{
    [Test]
    [Ignore("Only verifying that the sample builds")]
    public async Task ChatUsingYourOwnData()
    {
        string endpoint = "https://myaccount.openai.azure.com/";
        var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

        #region Snippet:ChatUsingYourOwnData
        AzureCognitiveSearchChatExtensionConfiguration contosoExtensionConfig = new()
        {
            SearchEndpoint = new Uri("https://your-contoso-search-resource.search.windows.net"),
            Authentication = new OnYourDataApiKeyAuthenticationOptions("<your Cognitive Search resource API key>"),
        };

        ChatCompletionsOptions chatCompletionsOptions = new()
        {
            DeploymentName = "gpt-35-turbo-0613",
            Messages =
            {
                new ChatRequestSystemMessage(
                    "You are a helpful assistant that answers questions about the Contoso product database."),
                new ChatRequestUserMessage("What are the best-selling Contoso products this month?")
            },

            // The addition of AzureChatExtensionsOptions enables the use of Azure OpenAI capabilities that add to
            // the behavior of Chat Completions, here the "using your own data" feature to supplement the context
            // with information from an Azure Cognitive Search resource with documents that have been indexed.
            AzureExtensionsOptions = new AzureChatExtensionsOptions()
            {
                Extensions = { contosoExtensionConfig }
            }
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(chatCompletionsOptions);
        ChatResponseMessage message = response.Value.Choices[0].Message;

        // The final, data-informed response still appears in the ChatMessages as usual
        Console.WriteLine($"{message.Role}: {message.Content}");

        // Responses that used extensions will also have Context information that includes special Tool messages
        // to explain extension activity and provide supplemental information like citations.
        Console.WriteLine($"Citations and other information:");

        foreach (ChatResponseMessage contextMessage in message.AzureExtensionsContext.Messages)
        {
            // Note: citations and other extension payloads from the "tool" role are often encoded JSON documents
            // and need to be parsed as such; that step is omitted here for brevity.
            Console.WriteLine($"{contextMessage.Role}: {contextMessage.Content}");
        }
        #endregion
    }
}
