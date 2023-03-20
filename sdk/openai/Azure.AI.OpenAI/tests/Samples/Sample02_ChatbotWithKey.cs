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
            var client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key), new OpenAIClientOptions()
            {
                DefaultDeploymentOrModelName = "myModelDeploymentId",
            });

            List<string> examplePrompts = new(){
                "How are you today?",
                "What is Azure OpenAI?",
                "Why do children love dinosaurs?",
                "Generate a proof of Euler's identity",
                "Describe in single words only the good things that come into your mind about your mother.",
            };

            foreach (string prompt in examplePrompts)
            {
                Console.Write($"Input: {prompt}");
                CompletionsOptions completionsOptions = new CompletionsOptions();
                completionsOptions.Prompts.Add(prompt);

                Response<Completions> completionsResponse = client.GetCompletions(completionsOptions);
                string completion = completionsResponse.Value.Choices[0].Text;
                Console.WriteLine($"Chatbot: {completion}");
            }
            #endregion
        }
    }
}
