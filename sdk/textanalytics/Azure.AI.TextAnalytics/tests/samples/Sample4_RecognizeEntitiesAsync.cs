﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples
    {
        [Test]
        public async Task RecognizeEntitiesAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            // Instantiate a client that will be used to call the service.
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:RecognizeEntitiesAsync
            string document = "Microsoft was founded by Bill Gates and Paul Allen.";

            Response<IReadOnlyCollection<CategorizedEntity>> entities = await client.RecognizeEntitiesAsync(document);

            Console.WriteLine($"Recognized {entities.Value.Count} entities:");
            foreach (CategorizedEntity entity in entities.Value)
            {
                Console.WriteLine($"Text: {entity.Text}, Category: {entity.Category}, SubCategory: {entity.SubCategory}, Confidence score: {entity.ConfidenceScore}");
            }
            #endregion
        }
    }
}
