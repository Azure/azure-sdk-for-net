// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples;

public partial class LegacyCompletions
{
    [TestCase(true, Ignore = "Only verifying that the sample builds")]
    public async Task GetCompletionsFromAzureOrNonAzureOpenAIAsync(bool useAzureOpenAI)
    {
        #region Snippet:UseAzureOrNonAzureOpenAIForCompletions
        #region Snippet:MakeClientWithAzureOrNonAzureOpenAI
        OpenAIClient client = useAzureOpenAI
            ? new OpenAIClient(
                new Uri("https://your-azure-openai-resource.com/"),
                new AzureKeyCredential("your-azure-openai-resource-api-key"))
            : new OpenAIClient("your-api-key-from-platform.openai.com");
        #endregion

        Response<Completions> response = await client.GetCompletionsAsync(new CompletionsOptions()
        {
            DeploymentName = "text-davinci-003", // assumes a matching model deployment or model name
            Prompts = { "Hello, world!" },
        });

        foreach (Choice choice in response.Value.Choices)
        {
            Console.WriteLine(choice.Text);
        }
        #endregion
    }
}
