// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.OpenAI.Inference.Models;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.OpenAI.Inference.Tests.Samples
{
    public partial class Chatbot
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void SummarizeText()
        {
            #region Snippet:SummarizeText
            string endpoint = "http://myaccount.openai.azure.com/";
            string textToSummarize = @"
                Two independent experiments reported their results this morning at CERN, Europe's high-energy physics laboratory near Geneva in Switzerland. Both show convincing evidence of a new boson particle weighing around 125 gigaelectronvolts, which so far fits predictions of the Higgs previously made by theoretical physicists.

                ""As a layman I would say: 'I think we have it'. Would you agree?"" Rolf-Dieter Heuer, CERN's director-general, asked the packed auditorium. The physicists assembled there burst into applause.
            :";
            OpenAIClient client = new OpenAIClient(new Uri(endpoint), new DefaultAzureCredential());

            string summarizationPrompt = @$"
                Summarize the following text.

                Text:
                """"""
                {textToSummarize}
                """"""

                Summary:
            ";

            Console.Write($"Input: {summarizationPrompt}");
            var request = new CompletionsRequest();
            request.Prompt.Add(summarizationPrompt);

            Completion completion = client.Completions("myModelDeployment", request);
            var response = completion.Choices[0].Text;
            Console.WriteLine($"Summarization: {response}");
            #endregion
        }
    }
}
