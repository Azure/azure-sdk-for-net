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
        public void SummarizeText()
        {
            #region Snippet:SummarizeText
            string endpoint = "https://myaccount.openai.azure.com/";
            OpenAIClient client = new OpenAIClient(new Uri(endpoint), "myDeploymentId", new DefaultAzureCredential());

            string textToSummarize = @"
                Two independent experiments reported their results this morning at CERN, Europe's high-energy physics laboratory near Geneva in Switzerland. Both show convincing evidence of a new boson particle weighing around 125 gigaelectronvolts, which so far fits predictions of the Higgs previously made by theoretical physicists.

                ""As a layman I would say: 'I think we have it'. Would you agree?"" Rolf-Dieter Heuer, CERN's director-general, asked the packed auditorium. The physicists assembled there burst into applause.
            :";

            string summarizationPrompt = @$"
                Summarize the following text.

                Text:
                """"""
                {textToSummarize}
                """"""

                Summary:
            ";

            Console.Write($"Input: {summarizationPrompt}");
            CompletionsOptions completionsOptions = new CompletionsOptions("text-davinci-002");
            completionsOptions.Prompt.Add(summarizationPrompt);

            Response<Completions> completionsResponse = client.GetCompletions("myModelDeployment", completionsOptions);
            string completion = completionsResponse.Value.Choices[0].Text;
            Console.WriteLine($"Summarization: {completion}");
            #endregion
        }
    }
}
