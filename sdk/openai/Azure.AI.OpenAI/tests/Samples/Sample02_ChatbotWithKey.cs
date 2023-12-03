// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples
{
    public partial class Chatbot
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GetMultipleResponsesWithSubscriptionKey()
        {
            #region Snippet:GenerateMultipleChatbotResponsesWithSubscriptionKey
            // Replace with your Azure OpenAI key
            string key = "YOUR_AZURE_OPENAI_KEY";
            string endpoint = "https://myaccount.openai.azure.com/";
            var client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));

            CompletionsOptions completionsOptions = new()
            {
                DeploymentName = "text-davinci-003",
                Prompts =
                {
                    "How are you today?",
                    "What is Azure OpenAI?",
                    "Why do children love dinosaurs?",
                    "Generate a proof of Euler's identity",
                    "Describe in single words only the good things that come into your mind about your mother."
                },
            };

            Response<Completions> completionsResponse = client.GetCompletions(completionsOptions);

            foreach (Choice choice in completionsResponse.Value.Choices)
            {
                Console.WriteLine($"Response for prompt {choice.Index}: {choice.Text}");
            }
            #endregion
        }
    }
}
