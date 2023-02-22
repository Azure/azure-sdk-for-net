// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Samples
{
    public partial class TextAnalyticsSamples : TextAnalyticsSampleBase
    {
        [Test]
        public void AnalyzeHealthcareEntities()
        {
            Uri endpoint = new(TestEnvironment.Endpoint);
            AzureKeyCredential credential = new(TestEnvironment.ApiKey);
            TextAnalyticsClient client = new(endpoint, credential, CreateSampleOptions());

            string documentA =
                "RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM |"
                + " CORONARY ARTERY DISEASE | Signed | DIS |"
                + Environment.NewLine
                + " Admission Date: 5/22/2001 Report Status: Signed Discharge Date: 4/24/2001"
                + " ADMISSION DIAGNOSIS: CORONARY ARTERY DISEASE."
                + Environment.NewLine
                + " HISTORY OF PRESENT ILLNESS: The patient is a 54-year-old gentleman with a history of progressive"
                + " angina over the past several months. The patient had a cardiac catheterization in July of this"
                + " year revealing total occlusion of the RCA and 50% left main disease, with a strong family history"
                + " of coronary artery disease with a brother dying at the age of 52 from a myocardial infarction and"
                + " another brother who is status post coronary artery bypass grafting. The patient had a stress"
                + " echocardiogram done on July, 2001, which showed no wall motion abnormalities, but this was a"
                + " difficult study due to body habitus. The patient went for six minutes with minimal ST depressions"
                + " in the anterior lateral leads, thought due to fatigue and wrist pain, his anginal equivalent. Due"
                + " to the patient'sincreased symptoms and family history and history left main disease with total"
                + " occasional of his RCA was referred for revascularization with open heart surgery.";

            string documentB = "Prescribed 100mg ibuprofen, taken twice daily.";

            // Prepare the input of the text analysis operation. You can add multiple documents to this list and
            // perform the same operation on all of them simultaneously.
            List<TextDocumentInput> batchedDocuments = new()
            {
                new TextDocumentInput("1", documentA)
                {
                    Language = "en"
                },
                new TextDocumentInput("2", documentB)
                {
                    Language = "en"
                },
            };

            AnalyzeHealthcareEntitiesOptions options = new()
            {
                IncludeStatistics = true
            };

            // Perform the text analysis operation.
            AnalyzeHealthcareEntitiesOperation operation = client.StartAnalyzeHealthcareEntities(batchedDocuments, options);
            operation.WaitForCompletion();

            Console.WriteLine($"The operation has completed.");
            Console.WriteLine();

            // View the operation status.
            Console.WriteLine($"Created On   : {operation.CreatedOn}");
            Console.WriteLine($"Expires On   : {operation.ExpiresOn}");
            Console.WriteLine($"Id           : {operation.Id}");
            Console.WriteLine($"Status       : {operation.Status}");
            Console.WriteLine($"Last Modified: {operation.LastModified}");
            Console.WriteLine();

            // View the operation results.
            foreach (AnalyzeHealthcareEntitiesResultCollection documentsInPage in operation.GetValues())
            {
                Console.WriteLine($"Analyze Healthcare Entities, model version: \"{documentsInPage.ModelVersion}\"");
                Console.WriteLine();

                int i = 0;

                foreach (AnalyzeHealthcareEntitiesResult documentResult in documentsInPage)
                {
                    TextDocumentInput document = batchedDocuments[i++];
                    Console.WriteLine($"Result for document with Id = \"{document.Id}\" and Language = \"{document.Language}\":");

                    if (documentResult.HasError)
                    {
                        Console.WriteLine($"  Error!");
                        Console.WriteLine($"  Document error code: {documentResult.Error.ErrorCode}");
                        Console.WriteLine($"  Message: {documentResult.Error.Message}");
                        continue;
                    }

                    Console.WriteLine($"  Recognized the following {documentResult.Entities.Count} healthcare entities:");
                    Console.WriteLine();

                    // View the healthcare entities that were recognized.
                    foreach (HealthcareEntity entity in documentResult.Entities)
                    {
                        Console.WriteLine($"  Entity: {entity.Text}");
                        Console.WriteLine($"  Category: {entity.Category}");
                        Console.WriteLine($"  Offset: {entity.Offset}");
                        Console.WriteLine($"  Length: {entity.Length}");
                        Console.WriteLine($"  NormalizedText: {entity.NormalizedText}");
                        Console.WriteLine($"  Links:");

                        // View the entity data sources.
                        foreach (EntityDataSource entityDataSource in entity.DataSources)
                        {
                            Console.WriteLine($"    Entity ID in Data Source: {entityDataSource.EntityId}");
                            Console.WriteLine($"    DataSource: {entityDataSource.Name}");
                        }

                        // View the entity assertions.
                        if (entity.Assertion is not null)
                        {
                            Console.WriteLine($"  Assertions:");

                            if (entity.Assertion?.Association is not null)
                            {
                                Console.WriteLine($"    Association: {entity.Assertion?.Association}");
                            }

                            if (entity.Assertion?.Certainty is not null)
                            {
                                Console.WriteLine($"    Certainty: {entity.Assertion?.Certainty}");
                            }

                            if (entity.Assertion?.Conditionality is not null)
                            {
                                Console.WriteLine($"    Conditionality: {entity.Assertion?.Conditionality}");
                            }
                        }
                    }

                    Console.WriteLine($"  We found {documentResult.EntityRelations.Count} relations in the current document:");
                    Console.WriteLine();

                    // View the healthcare entity relations that were recognized.
                    foreach (HealthcareEntityRelation relation in documentResult.EntityRelations)
                    {
                        Console.WriteLine($"    Relation: {relation.RelationType}");
                        if (relation.ConfidenceScore is not null)
                        {
                            Console.WriteLine($"    ConfidenceScore: {relation.ConfidenceScore}");
                        }
                        Console.WriteLine($"    For this relation there are {relation.Roles.Count} roles");

                        // View the relation roles.
                        foreach (HealthcareEntityRelationRole role in relation.Roles)
                        {
                            Console.WriteLine($"      Role Name: {role.Name}");

                            Console.WriteLine($"      Associated Entity Text: {role.Entity.Text}");
                            Console.WriteLine($"      Associated Entity Category: {role.Entity.Category}");
                            Console.WriteLine();
                        }

                        Console.WriteLine();
                    }

                    // View the statistics associated with the current document.
                    Console.WriteLine($"  Document statistics:");
                    Console.WriteLine($"    Character count (in Unicode graphemes): {documentResult.Statistics.CharacterCount}");
                    Console.WriteLine($"    Transaction count: {documentResult.Statistics.TransactionCount}");
                    Console.WriteLine();
                }

                // View the statistics associated with the documents in the current page.
                Console.WriteLine($"Batch operation statistics:");
                Console.WriteLine($"  Document Count: {documentsInPage.Statistics.DocumentCount}");
                Console.WriteLine($"  Valid document count: {documentsInPage.Statistics.ValidDocumentCount}");
                Console.WriteLine($"  Invalid document count: {documentsInPage.Statistics.InvalidDocumentCount}");
                Console.WriteLine($"  Transaction count: {documentsInPage.Statistics.TransactionCount}");
            }
        }
    }
}
