// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using Azure.Identity;
using OpenAI.Chat;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    public void CreateAnAzureOpenAIClient()
    {
        #region Snippet:ConfigureClient:WithAOAITopLevelClient
        string keyFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new ApiKeyCredential(keyFromEnvironment));
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");
        #endregion
    }

    public void CreateAnAzureOpenAIClientWithEntra()
    {
        #region Snippet:ConfigureClient:WithEntra
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-4o-mini-deployment");
        #endregion
    }

    public void UseAzureGovernment()
    {
        #region Snippet:ConfigureClient:GovernmentAudience
        AzureOpenAIClientOptions options = new()
        {
            Audience = AzureOpenAIAudience.AzureGovernment,
        };
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential(),
            options);
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-4o-mini-deployment");
        #endregion
    }

    public void UseCustomAuthorizationScope()
    {
        #region Snippet:ConfigureClient:CustomAudience
        AzureOpenAIClientOptions optionsWithCustomAudience = new()
        {
            Audience = "https://cognitiveservices.azure.com/.default",
        };
        #endregion

        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential(),
            optionsWithCustomAudience);
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-4o-mini-deployment");
    }
}
