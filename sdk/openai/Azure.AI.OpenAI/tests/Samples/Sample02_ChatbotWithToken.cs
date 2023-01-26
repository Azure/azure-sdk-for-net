// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.AI.OpenAI.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples
{
    public partial class Chatbot
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GetChatbotResponsesWithToken()
        {
            #region Snippet:GenerateChatbotResponsesWithToken
            string endpoint = "http://myaccount.openai.azure.com/";
            OpenAIClient client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

            List<string> examplePrompts = new(){
                "How are you today?",
                "What is Azure OpenAI?",
                "Why do children love dinosaurs?",
                "Generate a proof of Euler's identity",
                "Describe in single words only the good things that come into your mind about your mother.",
            };

            foreach (var prompt in examplePrompts)
            {
                Console.Write($"Input: {prompt}");
                var request = new CompletionsOptions();
                request.Prompt.Add(prompt);

                Completions completion = client.GetCompletions("myModelDeployment", request);
                var response = completion.Choices[0].Text;
                Console.WriteLine($"Chatbot: {response}");
            }
            #endregion
        }
    }
}
