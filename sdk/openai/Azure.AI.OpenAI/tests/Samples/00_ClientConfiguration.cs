// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.IO;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using OpenAI.Audio;
using OpenAI.Chat;

namespace Azure.AI.OpenAI.Samples;

public partial class AzureOpenAISamples
{
    [Test]
    [Ignore("Only for sample compilation validation")]
    public void CreateAnAzureOpenAIClient()
    {
        #region Snippet:ConfigureClient:WithAOAITopLevelClient
        string keyFromEnvironment = Environment.GetEnvironmentVariable("AZURE_OPENAI_API_KEY");

        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new AzureKeyCredential(keyFromEnvironment));
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");
        #endregion
    }

    [Test]
    [Ignore("Only for sample compilation validation")]
    public void CreateAnAzureOpenAIClientWithEntra()
    {
        #region Snippet:ConfigureClient:WithEntra
        AzureOpenAIClient azureClient = new(
            new Uri("https://your-azure-openai-resource.com"),
            new DefaultAzureCredential());
        ChatClient chatClient = azureClient.GetChatClient("my-gpt-35-turbo-deployment");
        #endregion
    }
}
