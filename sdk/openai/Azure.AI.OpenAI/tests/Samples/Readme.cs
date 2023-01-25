// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.AI.OpenAI.Models;
using NUnit.Framework;

namespace Azure.AI.OpenAI.Tests.Samples
{
    internal class Readme
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void CastingToSpecificType()
        {
            #region Snippet:Azure_OpenAI_GetSecret
            string endpoint = "http://myaccount.openai.azure.com/";
            string key = "myKey";

            OpenAIClient client = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(key));
            CompletionsRequest completionsRequest = new CompletionsRequest();
            completionsRequest.Prompt.Add("Hello world");
            completionsRequest.Prompt.Add("running over the same old ground");
            Completion response = client.Completions("myModelDeployment", completionsRequest);

            foreach (Choice choice in response.Choices)
            {
                Console.WriteLine(choice.Text);
            }
            #endregion Snippet:Azure_OpenAI_GetSecret
        }
    }
}
