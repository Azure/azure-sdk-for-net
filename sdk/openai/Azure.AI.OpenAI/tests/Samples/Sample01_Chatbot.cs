// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
            #region Snippet:CreateOpenAIClientTokenCredential
            string endpoint = "https://myaccount.openai.azure.com/";
            var client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential(), new OpenAIClientOptions()
            {
                DefaultDeploymentOrModelName = "myDeploymentId",
            });
            #endregion

            string prompt = "What is Azure OpenAI?";
            Console.Write($"Input: {prompt}");

            Response<Completions> completionsResponse = client.GetCompletions(prompt);
            string completion = completionsResponse.Value.Choices[0].Text;
            Console.WriteLine($"Chatbot: {completion}");
            #endregion
        }
    }
}
