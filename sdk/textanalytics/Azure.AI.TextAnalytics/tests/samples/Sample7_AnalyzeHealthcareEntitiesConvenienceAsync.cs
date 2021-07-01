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
        public async Task AnalyzeHealthcareEntitiesConvenienceAsync()
        {
            // create a text analytics client
            string endpoint = TestEnvironment.Endpoint;
            string apiKey = TestEnvironment.ApiKey;
            var client = new TextAnalyticsClient(new Uri(endpoint), new AzureKeyCredential(apiKey));

            #region Snippet:TextAnalyticsAnalyzeHealthcareEntitiesConvenienceAsyncAll
            #region Snippet:TextAnalyticsAnalyzeHealthcareEntitiesConvenienceAsync
            // get input documents
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

            // prepare analyze operation input
            List<string> batchInput = new List<string>()
            {
                document1,
                document2
            };

            // start analysis process
            AnalyzeHealthcareEntitiesOperation healthOperation = await client.StartAnalyzeHealthcareEntitiesAsync(batchInput);
            await healthOperation.WaitForCompletionAsync();
            #endregion Snippet:TextAnalyticsAnalyzeHealthcareEntitiesConvenienceAsync

            #region Snippet:TextAnalyticsSampleHealthcareOperationStatus
            // view operation status
            Console.WriteLine($"Created On   : {healthOperation.CreatedOn}");
            Console.WriteLine($"Expires On   : {healthOperation.ExpiresOn}");
            Console.WriteLine($"Status       : {healthOperation.Status}");
            Console.WriteLine($"Last Modified: {healthOperation.LastModified}");
            #endregion Snippet:TextAnalyticsSampleHealthcareOperationStatus

            #region Snippet:TextAnalyticsSampleHealthcareConvenienceAsyncViewResults
            // view operation results
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
                            // view recognized healthcare entities
                            Console.WriteLine($"  Entity: {entity.Text}");
                            Console.WriteLine($"  Category: {entity.Category}");
                            Console.WriteLine($"  Offset: {entity.Offset}");
                            Console.WriteLine($"  Length: {entity.Length}");
                            Console.WriteLine($"  NormalizedText: {entity.NormalizedText}");
                            Console.WriteLine($"  Links:");

                            // view entity data sources
                            foreach (EntityDataSource entityDataSource in entity.DataSources)
                            {
                                Console.WriteLine($"    Entity ID in Data Source: {entityDataSource.EntityId}");
                                Console.WriteLine($"    DataSource: {entityDataSource.Name}");
                            }

                            // view assertion
                            if (entity.Assertion != null)
                            {
                                Console.WriteLine($"  Assertions:");

                                if (entity.Assertion?.Association != null)
                                {
                                    Console.WriteLine($"    Association: {entity.Assertion?.Association}");
                                }

                                if (entity.Assertion?.Certainty != null)
                                {
                                    Console.WriteLine($"    Certainty: {entity.Assertion?.Certainty}");
                                }
                                if (entity.Assertion?.Conditionality != null)
                                {
                                    Console.WriteLine($"    Conditionality: {entity.Assertion?.Conditionality}");
                                }
                            }
                        }

                        Console.WriteLine($"  We found {entitiesInDoc.EntityRelations.Count} relations in the current document:");
                        Console.WriteLine("");

                        // view recognized healthcare relations
                        foreach (HealthcareEntityRelation relations in entitiesInDoc.EntityRelations)
                        {
                            Console.WriteLine($"    Relation: {relations.RelationType}");
                            Console.WriteLine($"    For this relation there are {relations.Roles.Count} roles");

                            // view relation roles
                            foreach (HealthcareEntityRelationRole role in relations.Roles)
                            {
                                Console.WriteLine($"      Role Name: {role.Name}");

                                Console.WriteLine($"      Associated Entity Text: {role.Entity.Text}");
                                Console.WriteLine($"      Associated Entity Category: {role.Entity.Category}");
                                Console.WriteLine("");
                            }

                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        Console.WriteLine("  Error!");
                        Console.WriteLine($"  Document error code: {entitiesInDoc.Error.ErrorCode}.");
                        Console.WriteLine($"  Message: {entitiesInDoc.Error.Message}");
                    }

                    Console.WriteLine("");
                }
            }
            #endregion Snippet:TextAnalyticsSampleHealthcareConvenienceAsyncViewResults

            #endregion Snippet:TextAnalyticsAnalyzeHealthcareEntitiesConvenienceAsyncAll
        }
    }
}
