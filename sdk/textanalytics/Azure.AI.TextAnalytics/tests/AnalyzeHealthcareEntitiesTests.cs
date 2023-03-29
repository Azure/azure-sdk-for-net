// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
    public class AnalyzeHealthcareEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public AnalyzeHealthcareEntitiesTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private static List<string> s_batchConvenienceDocuments = new List<string>
        {
            "Subject is taking 100mg of ibuprofen twice daily",
            "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure."
        };

        private static List<TextDocumentInput> s_batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", "Subject is taking 100mg of ibuprofen twice daily")
            {
                 Language = "en",
            },
            new TextDocumentInput("2", "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure.")
            {
                 Language = "en",
            }
        };

        private static readonly List<string> s_document1ExpectedEntitiesOutput = new List<string>
        {
            "ibuprofen",
            "100mg",
            "twice daily"
        };

        private static readonly List<string> s_document2ExpectedEntitiesOutput = new List<string>
        {
            "rapid",
            "irregular heartbeat",
            "delirium",
            "panic",
            "psychosis",
            "heart failure"
        };

        private static readonly Dictionary<string, List<string>> s_expectedBatchOutput = new()
        {
            { "0", s_document1ExpectedEntitiesOutput },
            { "1", s_document2ExpectedEntitiesOutput },
        };

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments);

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            List<AnalyzeHealthcareEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            //Take the first page
            var resultCollection = resultInPages.FirstOrDefault();
            Assert.AreEqual(s_batchDocuments.Count, resultCollection.Count);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments);

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            List<AnalyzeHealthcareEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            //Take the first page
            var resultCollection = resultInPages.FirstOrDefault();
            Assert.AreEqual(s_batchDocuments.Count, resultCollection.Count);

            AnalyzeHealthcareEntitiesResult result1 = resultCollection[0];

            Assert.AreEqual(s_document1ExpectedEntitiesOutput.Count, result1.Entities.Count);
            Assert.IsNotNull(result1.Id);
            Assert.AreEqual("1", result1.Id);

            foreach (HealthcareEntity entity in result1.Entities)
            {
                Assert.IsTrue(s_document1ExpectedEntitiesOutput.Contains(entity.Text));

                if (entity.Text == "ibuprofen")
                {
                    var linksList = new List<string> { "UMLS", "AOD", "ATC", "CCPSS", "CHV", "CSP", "DRUGBANK", "GS", "LCH_NW", "LNC", "MEDCIN", "MMSL", "MSH", "MTHSPL", "NCI", "NCI_CTRP", "NCI_DCP", "NCI_DTP", "NCI_FDA", "NCI_NCI-GLOSS", "NDDF", "PDQ", "RCD", "RXNORM", "SNM", "SNMI", "SNOMEDCT_US", "USP", "USPMG", "VANDF" };

                    foreach (EntityDataSource entityDataSource in entity.DataSources)
                        Assert.IsTrue(linksList.Contains(entityDataSource.Name));
                }

                if (entity.Text == "100mg")
                {
                    Assert.AreEqual(18, entity.Offset);
                    Assert.AreEqual(HealthcareEntityCategory.Dosage, entity.Category);
                    Assert.AreEqual(5, entity.Length);
                }
            }

            Assert.AreEqual(2, result1.EntityRelations.Count());
            foreach (HealthcareEntityRelation relation in result1.EntityRelations)
            {
                if (relation.RelationType == "DosageOfMedication")
                {
                    var role = relation.Roles.ElementAt(0);
                    Assert.IsNotNull(relation.Roles);
                    Assert.AreEqual(2, relation.Roles.Count());
                    Assert.AreEqual("Dosage", role.Name);
                    Assert.AreEqual("100mg", role.Entity.Text);
                    Assert.AreEqual(18, role.Entity.Offset);
                    Assert.AreEqual(HealthcareEntityCategory.Dosage, role.Entity.Category);
                    Assert.AreEqual(5, role.Entity.Length);
                }
            }

            Assert.IsNull(result1.FhirBundle);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeHealthcareEntitiesWithConfidenceScoreTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments);
            await operation.WaitForCompletionAsync();
            ValidateOperationProperties(operation);

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            AnalyzeHealthcareEntitiesResult result1 = resultCollection[0];
            Assert.AreEqual(s_document1ExpectedEntitiesOutput.Count, result1.Entities.Count);
            Assert.IsNotNull(result1.Id);
            Assert.AreEqual("1", result1.Id);
            Assert.AreEqual(2, result1.EntityRelations.Count());

            foreach (HealthcareEntityRelation relation in result1.EntityRelations)
            {
                Assert.GreaterOrEqual(relation.ConfidenceScore, 0.0);
                Assert.LessOrEqual(relation.ConfidenceScore, 1.0);
            }
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesTestWithAssertions()
        {
            TextAnalyticsClient client = GetClient();

            IReadOnlyCollection<string> batchDocuments = new List<string>() { "Baby not likely to have Meningitis. in case of fever in the mother, consider Penicillin for the baby too." };

            IReadOnlyCollection<string> expectedEntitiesOutput = new List<string>
            {
                "Baby",
                "Meningitis",
                "fever",
                "mother",
                "Penicillin",
                "baby"
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(batchDocuments);

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            List<AnalyzeHealthcareEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            var resultCollection = resultInPages.FirstOrDefault();
            Assert.AreEqual(batchDocuments.Count, resultCollection.Count);

            AnalyzeHealthcareEntitiesResult result1 = resultCollection[0];

            Assert.AreEqual(expectedEntitiesOutput.Count, result1.Entities.Count);

            foreach (HealthcareEntity entity in result1.Entities)
            {
                Assert.IsTrue(expectedEntitiesOutput.Contains(entity.Text));

                if (entity.Text == "Baby")
                {
                    var linksList = new List<string> { "UMLS", "AOD", "CCPSS", "CHV", "DXP", "LCH", "LCH_NW", "LNC", "MDR", "MSH", "NCI", "NCI_FDA", "NCI_NICHD", "SNOMEDCT_US" };

                    foreach (EntityDataSource entityDataSource in entity.DataSources)
                        Assert.IsTrue(linksList.Contains(entityDataSource.Name));
                    Assert.AreEqual("Infant", entity.NormalizedText);
                }

                if (entity.Text == "Meningitis")
                {
                    Assert.AreEqual(24, entity.Offset);
                    Assert.AreEqual(HealthcareEntityCategory.Diagnosis, entity.Category);
                    Assert.AreEqual(10, entity.Length);
                    Assert.IsNotNull(entity.Assertion);
                    Assert.AreEqual(EntityCertainty.NegativePossible, entity.Assertion.Certainty.Value);
                }

                if (entity.Text == "Penicillin")
                {
                    Assert.AreEqual(HealthcareEntityCategory.MedicationName, entity.Category);
                    Assert.AreEqual(10, entity.Length);
                    Assert.IsNotNull(entity.Assertion);
                    Assert.AreEqual(EntityCertainty.NeutralPossible, entity.Assertion.Certainty.Value);
                }
            }
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchConvenienceDocuments, "en");

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateBatchDocumentsResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure.",
                "",
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents);

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            Assert.IsNotNull(resultCollection[2].Id);

            Assert.IsTrue(!resultCollection[0].HasError);
            Assert.IsTrue(!resultCollection[1].HasError);

            Assert.IsTrue(resultCollection[2].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => resultCollection[2].Entities.GetType());
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, resultCollection[2].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchConvenienceDocuments);

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateBatchDocumentsResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions();

            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/31978.
            if (ServiceVersion is not TextAnalyticsClientOptions.ServiceVersion.V3_1)
            {
                options.IncludeStatistics = true;
            }

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchConvenienceDocuments, "en", options);

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateBatchDocumentsResult(resultCollection, expectedOutput, true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments);

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedEntitiesOutput },
                { "2", s_document2ExpectedEntitiesOutput },
            };

            ValidateBatchDocumentsResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions();

            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/31978.
            if (ServiceVersion is not TextAnalyticsClientOptions.ServiceVersion.V3_1)
            {
                options.IncludeStatistics = true;
            }

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments, options);

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedEntitiesOutput },
                { "2", s_document2ExpectedEntitiesOutput },
            };

            ValidateBatchDocumentsResult(resultCollection, expectedOutput, true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public async Task AnalyzeHealthcareEntitiesBatchWithNameTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments, new AnalyzeHealthcareEntitiesOptions
            {
                DisplayName = "AnalyzeHealthcareEntitiesBatchWithNameTest",
            });

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);
            Assert.AreEqual("AnalyzeHealthcareEntitiesBatchWithNameTest", operation.DisplayName);

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedEntitiesOutput },
                { "2", s_document2ExpectedEntitiesOutput },
            };

            ValidateBatchDocumentsResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public void AnalyzeHealthcareEntitiesBatchWithNameThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments, new AnalyzeHealthcareEntitiesOptions
            {
                DisplayName = "AnalyzeHealthcareEntitiesBatchWithNameThrows",
            }));

            Assert.AreEqual("AnalyzeHealthcareEntitiesOptions.DisplayName is not available in API version v3.1. Use service API version 2022-05-01 or newer.", ex.Message);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesPagination()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments);

            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            ValidateOperationProperties(operation);

            // try async
            //There must be 1 page
            List<AnalyzeHealthcareEntitiesResultCollection> asyncPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, asyncPages.Count);

            // First page should have 2 results
            Assert.AreEqual(2, asyncPages[0].Count);

            // try sync
            //There must be 1 page
            List<AnalyzeHealthcareEntitiesResultCollection> pages = operation.GetValues().AsEnumerable().ToList();
            Assert.AreEqual(1, pages.Count);

            // First page should have 2 results
            Assert.AreEqual(2, pages[0].Count);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeHealthcareEntitiesBatchWithFhirVersionTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments, new AnalyzeHealthcareEntitiesOptions
            {
                FhirVersion = FhirVersion.V4_0_1,
                DocumentType = HealthcareDocumentType.DischargeSummary
            });

            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            List<AnalyzeHealthcareEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            var resultCollection = resultInPages.FirstOrDefault();
            Assert.AreEqual(s_batchDocuments.Count, resultCollection.Count);

            // Check the FHIR bundle.
            Assert.IsNotNull(resultCollection[0].FhirBundle);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public void AnalyzeHealthcareEntitiesBatchWithFhirVersionThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments, new AnalyzeHealthcareEntitiesOptions
            {
                FhirVersion = FhirVersion.V4_0_1,
            }));

            Assert.That(ex.Message.EndsWith("Use service API version 2022-10-01-preview or newer."));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public void AnalyzeHealthcareEntitiesBatchWithDocumentTypeThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments, new AnalyzeHealthcareEntitiesOptions
            {
                DocumentType = HealthcareDocumentType.DischargeSummary
            }));

            Assert.That(ex.Message.EndsWith("Use service API version 2022-10-01-preview or newer."));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeHealthcareEntitiesBatchConvenienceWithAutoDetectedLanguageTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchConvenienceDocuments, "auto");
            await operation.WaitForCompletionAsync();

            ValidateOperationProperties(operation);

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateBatchDocumentsResult(resultCollection, s_expectedBatchOutput, isLanguageAutoDetected: true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeOperationAnalyzeHealthcareEntitiesWithAutoDetectedLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            List<string> documents = s_batchConvenienceDocuments;
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            TextAnalyticsActions actions = new()
            {
                AnalyzeHealthcareEntitiesActions = new List<AnalyzeHealthcareEntitiesAction>() { new AnalyzeHealthcareEntitiesAction() },
                DisplayName = "AnalyzeHealthcareEntitiesWithAutoDetectedLanguage",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, actions, "auto");
            await operation.WaitForCompletionAsync();

            // Take the first page.
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<AnalyzeHealthcareEntitiesActionResult> actionResults = resultCollection.AnalyzeHealthcareEntitiesResults;
            Assert.IsNotNull(actionResults);

            AnalyzeHealthcareEntitiesResultCollection results = actionResults.FirstOrDefault().DocumentsResults;
            ValidateBatchDocumentsResult(results, expectedOutput, isLanguageAutoDetected: true);
        }

        private void ValidateInDocumenResult(IReadOnlyCollection<HealthcareEntity> entities, List<string> minimumExpectedOutput)
        {
            Assert.GreaterOrEqual(entities.Count, minimumExpectedOutput.Count);
            foreach (HealthcareEntity entity in entities)
            {
                Assert.That(entity.Text, Is.Not.Null.And.Not.Empty);
                Assert.IsNotNull(entity.Category);
                Assert.GreaterOrEqual(entity.ConfidenceScore, 0.0);
                Assert.GreaterOrEqual(entity.Offset, 0);
                Assert.Greater(entity.Length, 0);

                if (entity.SubCategory != null)
                {
                    Assert.IsNotEmpty(entity.SubCategory);
                }
            }
        }

        private void ValidateBatchDocumentsResult(
            AnalyzeHealthcareEntitiesResultCollection results,
            Dictionary<string, List<string>> minimumExpectedOutput,
            bool includeStatistics = default,
            bool isLanguageAutoDetected = default)
        {
            Assert.That(results.ModelVersion, Is.Not.Null.And.Not.Empty);

            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/31978.
            if (ServiceVersion is not TextAnalyticsClientOptions.ServiceVersion.V3_1)
            {
                if (includeStatistics)
                {
                    Assert.IsNotNull(results.Statistics);
                    Assert.Greater(results.Statistics.DocumentCount, 0);
                    Assert.Greater(results.Statistics.TransactionCount, 0);
                    Assert.GreaterOrEqual(results.Statistics.InvalidDocumentCount, 0);
                    Assert.GreaterOrEqual(results.Statistics.ValidDocumentCount, 0);
                }
                else
                    Assert.IsNull(results.Statistics);
            }

            foreach (AnalyzeHealthcareEntitiesResult result in results)
            {
                Assert.That(result.Id, Is.Not.Null.And.Not.Empty);

                Assert.False(result.HasError);

                //Even though statistics are not asked for, TA 5.0.0 shipped with Statistics default always present.
                Assert.IsNotNull(result.Statistics);

                // TODO: https://github.com/Azure/azure-sdk-for-net/issues/31978.
                if (ServiceVersion is not (TextAnalyticsClientOptions.ServiceVersion.V2022_05_01 or TextAnalyticsClientOptions.ServiceVersion.V3_1))
                {
                    if (includeStatistics)
                    {
                        Assert.GreaterOrEqual(result.Statistics.CharacterCount, 0);
                        Assert.Greater(result.Statistics.TransactionCount, 0);
                    }
                    else
                    {
                        Assert.AreEqual(0, result.Statistics.CharacterCount);
                        Assert.AreEqual(0, result.Statistics.TransactionCount);
                    }
                }

                if (isLanguageAutoDetected)
                {
                    Assert.That(result.DetectedLanguage, Is.Not.Null.And.Not.Empty);
                }
                else
                {
                    Assert.IsNull(result.DetectedLanguage);
                }

                Assert.IsNotNull(result.Warnings);
                Assert.IsNotNull(result.EntityRelations);
                ValidateInDocumenResult(result.Entities, minimumExpectedOutput[result.Id]);
            }
        }

        private void ValidateOperationProperties(AnalyzeHealthcareEntitiesOperation operation)
        {
            Assert.AreNotEqual(new DateTimeOffset(), operation.CreatedOn);
            // TODO: Re-enable this check (https://github.com/Azure/azure-sdk-for-net/issues/31855).
            // Assert.AreNotEqual(new DateTimeOffset(), operation.LastModified);

            if (operation.ExpiresOn.HasValue)
            {
                Assert.AreNotEqual(new DateTimeOffset(), operation.ExpiresOn.Value);
            }
        }
    }
}
