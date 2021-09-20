// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests.samples
{
    public partial class RecognizeCustomEntitiesSamples : SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public void RecognizeCustomEntities()
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

            AnalyzeActionsOperation operation = client.StartAnalyzeActions(documents, actions);

            TimeSpan pollingInterval = new TimeSpan(1000);

            while (!operation.HasCompleted)
            {
                Thread.Sleep(pollingInterval);
                operation.UpdateStatus();

                Console.WriteLine($"Status: {operation.Status}");
                //If operation has not started, all other fields are null
                if (operation.Status != TextAnalyticsOperationStatus.NotStarted)
                {
                    Console.WriteLine($"Expires On: {operation.ExpiresOn}");
                    Console.WriteLine($"Last modified: {operation.LastModified}");
                    if (!string.IsNullOrEmpty(operation.DisplayName))
                        Console.WriteLine($"Display name: {operation.DisplayName}");
                    Console.WriteLine($"Total actions: {operation.ActionsTotal}");
                    Console.WriteLine($"  Succeeded actions: {operation.ActionsSucceeded}");
                    Console.WriteLine($"  Failed actions: {operation.ActionsFailed}");
                    Console.WriteLine($"  In progress actions: {operation.ActionsInProgress}");
                }
            }

            foreach (var result in operation.GetValues())
            {
                var results = result.RecognizeCustomEntitiesActionResult;
                foreach (var document in results)
                {
                    var entitiesInDocument = document.DocumentsResults[0].Entities;

                    Console.WriteLine($"Recognized {entitiesInDocument.Count} entities:");
                    foreach (CategorizedEntity entity in entitiesInDocument)
                    {
                        Console.WriteLine($"    Text: {entity.Text}");
                        Console.WriteLine($"    Offset: {entity.Offset}");
                        Console.WriteLine($"  Length: {entity.Length}");
                        Console.WriteLine($"    Category: {entity.Category}");
                        if (!string.IsNullOrEmpty(entity.SubCategory))
                            Console.WriteLine($"    SubCategory: {entity.SubCategory}");
                        Console.WriteLine($"    Confidence score: {entity.ConfidenceScore}");
                        Console.WriteLine("");
                    }
                }
            }
        }
    }
}
