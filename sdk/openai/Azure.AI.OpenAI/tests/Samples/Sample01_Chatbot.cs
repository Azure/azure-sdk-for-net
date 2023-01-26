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
        public void GetChatbotResponse()
        {
            #region Snippet:GenerateChatbotResponse
            string endpoint = "http://myaccount.openai.azure.com/";
            OpenAIClient client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential(), "myDeploymentId");

            string prompt = "What is Azure OpenAI?";
            Console.Write($"Input: {prompt}");

            Completion completion = client.Completions(prompt);
            var response = completion.Choices[0].Text;
            Console.WriteLine($"Chatbot: {response}");
            #endregion
        }
    }
}
