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
        public async Task Sample7_AnalyzeHealthcareEntitiesBatchConvenienceAsync()
        {
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;

            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsSampleHealthcareBatchConvenienceAsync
            string document1 = @"RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM | CORONARY ARTERY DISEASE | Signed | DIS | \
                                Admission Date: 5/22/2001 Report Status: Signed Discharge Date: 4/24/2001 ADMISSION DIAGNOSIS: CORONARY ARTERY DISEASE. \
                                HISTORY OF PRESENT ILLNESS: The patient is a 54-year-old gentleman with a history of progressive angina over the past several months. \
                                The patient had a cardiac catheterization in July of this year revealing total occlusion of the RCA and 50% left main disease ,\
                                with a strong family history of coronary artery disease with a brother dying at the age of 52 from a myocardial infarction and \
                                another brother who is status post coronary artery bypass grafting. The patient had a stress echocardiogram done on July , 2001 , \
                                which showed no wall motion abnormalities , but this was a difficult study due to body habitus. The patient went for six minutes with \
                                minimal ST depressions in the anterior lateral leads , thought due to fatigue and wrist pain , his anginal equivalent. Due to the patient's \
                                increased symptoms and family history and history left main disease with total occasional of his RCA was referred for revascularization with open heart surgery.";

            string document2 = "Prescribed 100mg ibuprofen, taken twice daily.";

            List<TextDocumentInput> batchInput = new List<TextDocumentInput>()
            {
                new TextDocumentInput("1", document1)
                { Language = "en" },
                new TextDocumentInput("2", document2)
                { Language = "en" },
                new TextDocumentInput("3", string.Empty)
            };
            var options = new AnalyzeHealthcareEntitiesOptions { IncludeStatistics = true };

            AnalyzeHealthcareEntitiesOperation healthOperation = await client.StartAnalyzeHealthcareEntitiesAsync(batchInput, options);

            await healthOperation.WaitForCompletionAsync();

            Console.WriteLine($"Created On   : {healthOperation.CreatedOn}");
            Console.WriteLine($"Expires On   : {healthOperation.ExpiresOn}");
            Console.WriteLine($"Id           : {healthOperation.Id}");
            Console.WriteLine($"Status       : {healthOperation.Status}");
            Console.WriteLine($"Last Modified: {healthOperation.LastModified}");

            int i = 0;

            await foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in healthOperation.Value)
            {
                Console.WriteLine($"Results of Azure Text Analytics \"Healthcare Async\" Model, version: \"{documentsInPage.ModelVersion}\"");
                Console.WriteLine("");

                TextDocumentInput document = batchInput[i++];

                Console.WriteLine($"On document (Id={document.Id}, Language=\"{document.Language}\"):");

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
                    else
                    {
                        Console.WriteLine("  Error!");
                        Console.WriteLine($"  Document error code: {entitiesInDoc.Error.ErrorCode}.");
                        Console.WriteLine($"  Message: {entitiesInDoc.Error.Message}");
                    }

                    Console.WriteLine($"Batch operation statistics:");
                    Console.WriteLine($"  Document count: {entitiesInDoc.Statistics.CharacterCount}");
                    Console.WriteLine($"  Valid document count: {entitiesInDoc.Statistics.TransactionCount}");
                    Console.WriteLine("");
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
