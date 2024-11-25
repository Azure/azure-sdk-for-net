// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.AI.OpenAI.Chat;
using Azure.Identity;
using OpenAI.Chat;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public void OnYourDataSearch()
    {
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");

        #region Snippet:ChatUsingYourOwnData
        // Extension methods to use data sources with options are subject to SDK surface changes. Suppress the
        // warning to acknowledge and this and use the subject-to-change AddDataSource method.
        #pragma warning disable AOAI001

        ChatCompletionOptions options = new();
        options.AddDataSource(new AzureSearchChatDataSource()
        {
            Endpoint = new Uri("https://your-search-resource.search.windows.net"),
            IndexName = "contoso-products-index",
            Authentication = DataSourceAuthentication.FromApiKey(
                Environment.GetEnvironmentVariable("OYD_SEARCH_KEY")),
        });

        ChatCompletion completion = chatClient.CompleteChat(
            [
                new UserChatMessage("What are the best-selling Contoso products this month?"),
            ],
            options);

        ChatMessageContext onYourDataContext = completion.GetMessageContext();

        if (onYourDataContext?.Intent is not null)
        {
            Console.WriteLine($"Intent: {onYourDataContext.Intent}");
        }
        foreach (ChatCitation citation in onYourDataContext?.Citations ?? [])
        {
            Console.WriteLine($"Citation: {citation.Content}");
        }
        #endregion
    }
}
