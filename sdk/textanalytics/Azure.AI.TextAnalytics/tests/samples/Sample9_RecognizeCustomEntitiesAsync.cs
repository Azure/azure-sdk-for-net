// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests.samples
{
    public partial class RecognizeCustomEntitiesSamples : SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public async Task RecognizeCustomEntitiesAsync()
        {
            // Create a text analytics client.
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            // Get input document.
            var documents = new List<string>() { @"There are so many ways of arranging a deck of cards that, after shuffling it, 
                                                   it's almost guaranteed that the resulting sequence of cards has never appeared in the history of humanity." };

            //prepare actions
            var actions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction("<project-name>", "<deployment-name>")
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, actions);

            await operation.WaitForCompletionAsync();

            await foreach (var result in operation.Value)
            {
                var results = result.RecognizeCustomEntitiesActionResult;
            }
        }
    }
}
