// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    [LiveOnly]
    public partial class TextAnalyticsSamples: SamplesBase<TextAnalyticsTestEnvironment>
    {
        [Test]
        public async Task HealthcareAsyncPagination()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSampleHealthcareAsyncPagination
            string document = @"RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM | CORONARY ARTERY DISEASE.";

            var list = new List<string>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(document);
            };

            HealthcareOptions options = new HealthcareOptions()
            {
                Top = 2
            };

            HealthcareOperation healthOperation = await client.StartHealthcareBatchAsync(list, "en", options);

            AsyncPageable<DocumentHealthcareResult> results = client.GetHealthcareEntities(healthOperation);

            Console.WriteLine($"Results of Azure Text Analytics \"Healthcare Async\"");
            Console.WriteLine("");

            int resultCount = 0;
            await foreach (DocumentHealthcareResult result in results)
            {
                resultCount += 1;
            }

            Console.WriteLine("resultCount " + resultCount);
        }

        #endregion
    }
}
