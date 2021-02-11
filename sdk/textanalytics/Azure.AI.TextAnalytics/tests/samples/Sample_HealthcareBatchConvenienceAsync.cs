// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
        public async Task HealthcareBatchConvenienceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSampleHealthcareBatchConvenienceAsync
            string document = "Subject is taking 100mg of ibuprofen twice daily";

            var list = new List<string>();

            for (int i = 0; i < 6; i++)
            {
                list.Add(document);
            };

            AnalyzeHealthcareEntitiesOperation healthOperation = await client.StartAnalyzeHealthcareEntitiesAsync(list, "en", new AnalyzeHealthcareEntitiesOptions() { IncludeStatistics = true } );

            await healthOperation.WaitForCompletionAsync();

            await foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in healthOperation.Value)
            {
                Console.WriteLine($"Results of Azure Text Analytics \"Healthcare Async\" Model, version: \"{documentsInPage.ModelVersion}\"");
                Console.WriteLine("");

                foreach (AnalyzeHealthcareEntitiesResult entitiesInDoc in documentsInPage)
                {
                    if (!entitiesInDoc.HasError)
                    {
                        foreach (var entity in entitiesInDoc.Entities)
                        {
                            Console.WriteLine($"    Entity: {entity.Text}");
                            Console.WriteLine($"    Category: {entity.Category}");
                            Console.WriteLine($"    Offset: {entity.Offset}");
                            Console.WriteLine($"    Length: {entity.Length}");
                            Console.WriteLine($"    Links:");

                            foreach (EntityDataSource entityDataSource in entity.DataSources)
                            {
                                Console.WriteLine($"        Entity ID in Data Source: {entityDataSource.EntityId}");
                                Console.WriteLine($"        DataSource: {entityDataSource.Name}");
                            }
                        }
                    }
                }

                Console.WriteLine($"Request statistics:");
                Console.WriteLine($"    Document Count: {documentsInPage.Statistics.DocumentCount}");
                Console.WriteLine($"    Valid Document Count: {documentsInPage.Statistics.ValidDocumentCount}");
                Console.WriteLine($"    Transaction Count: {documentsInPage.Statistics.TransactionCount}");
                Console.WriteLine($"    Invalid Document Count: {documentsInPage.Statistics.InvalidDocumentCount}");
                Console.WriteLine("");
            }
        }

        #endregion
    }
}
