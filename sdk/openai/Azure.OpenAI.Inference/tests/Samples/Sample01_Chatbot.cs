// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.OpenAI.Inference.Models;

namespace Azure.OpenAI.Inference.Tests.Samples
{
    public partial class Chatbot
    {
        public void GetChatbotResponses()
        {
            // Replace with your Azure subscription key
            string key = "YOUR_AZURE_KEY";
            string endpoint = "http://myaccount.openai.azure.com/";
            OpenAIClient client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));

            #region Snippet:GenerateChatbotResponses
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
                var request = new CompletionsRequest();
                request.Prompt.Add(prompt);

                Completion completion = client.Completions("myModelDeployment", request);
                var response = completion.Choices[0].Text;
                Console.WriteLine($"Chatbot: {response}");
            }
            #endregion
        }
    }
}
