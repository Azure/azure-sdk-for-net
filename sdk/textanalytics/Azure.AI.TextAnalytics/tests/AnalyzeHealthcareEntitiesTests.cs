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

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, s_batchDocuments);
            ValidateOperationProperties(operation);

            List<AnalyzeHealthcareEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            //Take the first page
            var resultCollection = resultInPages.FirstOrDefault();
            Assert.That(resultCollection.Count, Is.EqualTo(s_batchDocuments.Count));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, s_batchDocuments);
            ValidateOperationProperties(operation);

            List<AnalyzeHealthcareEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            //Take the first page
            var resultCollection = resultInPages.FirstOrDefault();
            Assert.That(resultCollection.Count, Is.EqualTo(s_batchDocuments.Count));

            AnalyzeHealthcareEntitiesResult result1 = resultCollection[0];

            Assert.That(result1.Entities.Count, Is.EqualTo(s_document1ExpectedEntitiesOutput.Count));
            Assert.That(result1.Id, Is.Not.Null);
            Assert.AreEqual("1", result1.Id);

            foreach (HealthcareEntity entity in result1.Entities)
            {
                Assert.That(s_document1ExpectedEntitiesOutput.Contains(entity.Text), Is.True);

                if (entity.Text == "ibuprofen")
                {
                    var linksList = new List<string> { "UMLS", "AOD", "ATC", "CCPSS", "CHV", "CSP", "DRUGBANK", "GS", "LCH_NW", "LNC", "MEDCIN", "MMSL", "MSH", "MTHSPL", "NCI", "NCI_CTRP", "NCI_DCP", "NCI_DTP", "NCI_FDA", "NCI_NCI-GLOSS", "NDDF", "PDQ", "RCD", "RXNORM", "SNM", "SNMI", "SNOMEDCT_US", "USP", "USPMG", "VANDF" };

                    foreach (EntityDataSource entityDataSource in entity.DataSources)
                        Assert.That(linksList.Contains(entityDataSource.Name), Is.True);
                }

                if (entity.Text == "100mg")
                {
                    Assert.That(entity.Offset, Is.EqualTo(18));
                    Assert.That(entity.Category, Is.EqualTo(HealthcareEntityCategory.Dosage));
                    Assert.That(entity.Length, Is.EqualTo(5));
                }
            }

            Assert.That(result1.EntityRelations.Count(), Is.EqualTo(2));
            foreach (HealthcareEntityRelation relation in result1.EntityRelations)
            {
                if (relation.RelationType == "DosageOfMedication")
                {
                    var role = relation.Roles.ElementAt(0);
                    Assert.That(relation.Roles, Is.Not.Null);
                    Assert.That(relation.Roles.Count(), Is.EqualTo(2));
                    Assert.That(role.Name, Is.EqualTo("Dosage"));
                    Assert.That(role.Entity.Text, Is.EqualTo("100mg"));
                    Assert.That(role.Entity.Offset, Is.EqualTo(18));
                    Assert.That(role.Entity.Category, Is.EqualTo(HealthcareEntityCategory.Dosage));
                    Assert.That(role.Entity.Length, Is.EqualTo(5));
                }
            }
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2023_04_01)]
        public async Task AnalyzeHealthcareEntitiesWithConfidenceScoreTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, s_batchDocuments);
            ValidateOperationProperties(operation);

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            AnalyzeHealthcareEntitiesResult result1 = resultCollection[0];
            Assert.That(result1.Entities.Count, Is.EqualTo(s_document1ExpectedEntitiesOutput.Count));
            Assert.That(result1.Id, Is.Not.Null);
            Assert.That(result1.Id, Is.EqualTo("1"));
            Assert.That(result1.EntityRelations.Count(), Is.EqualTo(2));

            foreach (HealthcareEntityRelation relation in result1.EntityRelations)
            {
                Assert.That(relation.ConfidenceScore, Is.GreaterThanOrEqualTo(0.0));
                Assert.That(relation.ConfidenceScore, Is.LessThanOrEqualTo(1.0));
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

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, batchDocuments);
            ValidateOperationProperties(operation);

            List<AnalyzeHealthcareEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            var resultCollection = resultInPages.FirstOrDefault();
            Assert.That(resultCollection.Count, Is.EqualTo(batchDocuments.Count));

            AnalyzeHealthcareEntitiesResult result1 = resultCollection[0];

            Assert.That(result1.Entities.Count, Is.EqualTo(expectedEntitiesOutput.Count));

            foreach (HealthcareEntity entity in result1.Entities)
            {
                Assert.That(expectedEntitiesOutput.Contains(entity.Text), Is.True);

                if (entity.Text == "Baby")
                {
                    var linksList = new List<string> { "UMLS", "AOD", "CCPSS", "CHV", "DXP", "LCH", "LCH_NW", "LNC", "MDR", "MSH", "NCI", "NCI_FDA", "NCI_NICHD", "SNOMEDCT_US" };

                    foreach (EntityDataSource entityDataSource in entity.DataSources)
                        Assert.That(linksList.Contains(entityDataSource.Name), Is.True);
                    Assert.That(entity.NormalizedText, Is.EqualTo("Infant"));
                }

                if (entity.Text == "Meningitis")
                {
                    Assert.That(entity.Offset, Is.EqualTo(24));
                    Assert.That(entity.Category, Is.EqualTo(HealthcareEntityCategory.Diagnosis));
                    Assert.That(entity.Length, Is.EqualTo(10));
                    Assert.That(entity.Assertion, Is.Not.Null);
                    Assert.That(entity.Assertion.Certainty.Value, Is.EqualTo(EntityCertainty.NegativePossible));
                }

                if (entity.Text == "Penicillin")
                {
                    Assert.That(entity.Category, Is.EqualTo(HealthcareEntityCategory.MedicationName));
                    Assert.That(entity.Length, Is.EqualTo(10));
                    Assert.That(entity.Assertion, Is.Not.Null);
                    Assert.That(entity.Assertion.Certainty.Value, Is.EqualTo(EntityCertainty.NeutralPossible));
                }
            }
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, s_batchConvenienceDocuments, "en");
            ValidateOperationProperties(operation);

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateBatchResult(resultCollection, expectedOutput);
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

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, documents);
            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            Assert.That(resultCollection[2].Id, Is.Not.Null);

            Assert.That(!resultCollection[0].HasError, Is.True);
            Assert.That(!resultCollection[1].HasError, Is.True);

            Assert.That(resultCollection[2].HasError, Is.True);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => resultCollection[2].Entities.GetType());
            Assert.That(resultCollection[2].Error.ErrorCode.ToString(), Is.EqualTo(TextAnalyticsErrorCode.InvalidDocument));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, s_batchConvenienceDocuments);
            ValidateOperationProperties(operation);

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateBatchResult(resultCollection, s_expectedBatchOutput);
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

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, s_batchConvenienceDocuments, "en", options);
            ValidateOperationProperties(operation);

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateBatchResult(resultCollection, expectedOutput, true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, s_batchDocuments);
            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedEntitiesOutput },
                { "2", s_document2ExpectedEntitiesOutput },
            };

            ValidateBatchResult(resultCollection, expectedOutput);
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

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, s_batchDocuments, options);
            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedEntitiesOutput },
                { "2", s_document2ExpectedEntitiesOutput },
            };

            ValidateBatchResult(resultCollection, expectedOutput, true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public async Task AnalyzeHealthcareEntitiesBatchWithNameTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions
            {
                DisplayName = "AnalyzeHealthcareEntitiesBatchWithNameTest",
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, s_batchDocuments, options);
            ValidateOperationProperties(operation);

            Assert.That(operation.DisplayName, Is.EqualTo("AnalyzeHealthcareEntitiesBatchWithNameTest"));

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedEntitiesOutput },
                { "2", s_document2ExpectedEntitiesOutput },
            };

            ValidateBatchResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public void AnalyzeHealthcareEntitiesBatchWithNameThrows()
        {
            TestDiagnostics = false;
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions
            {
                DisplayName = "AnalyzeHealthcareEntitiesBatchWithNameThrows",
            };

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Completed, s_batchDocuments, options));

            Assert.That(ex.Message, Is.EqualTo("AnalyzeHealthcareEntitiesOptions.DisplayName is not available in API version v3.1. Use service API version 2022-05-01 or newer."));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesPagination()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Started, s_batchDocuments);
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            ValidateOperationProperties(operation);

            // try async
            //There must be 1 page
            List<AnalyzeHealthcareEntitiesResultCollection> asyncPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(asyncPages.Count, Is.EqualTo(1));

            // First page should have 2 results
            Assert.That(asyncPages[0].Count, Is.EqualTo(2));

            // try sync
            //There must be 1 page
            List<AnalyzeHealthcareEntitiesResultCollection> pages = operation.GetValues().AsEnumerable().ToList();
            Assert.That(pages.Count, Is.EqualTo(1));

            // First page should have 2 results
            Assert.That(pages[0].Count, Is.EqualTo(2));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesBatchWaitUntilStartedTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Started, s_batchDocuments);
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            ValidateOperationProperties(operation);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeHealthcareEntitiesBatchConvenienceWaitUntilStartedTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.AnalyzeHealthcareEntitiesAsync(WaitUntil.Started, s_batchConvenienceDocuments);
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            ValidateOperationProperties(operation);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task StartAnalyzeHealthcareEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments);
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            ValidateOperationProperties(operation);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedEntitiesOutput },
                { "2", s_document2ExpectedEntitiesOutput },
            };

            List<AnalyzeHealthcareEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task StartAnalyzeHealthcareEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchConvenienceDocuments);
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            ValidateOperationProperties(operation);

            List<AnalyzeHealthcareEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            // Take the first page.
            AnalyzeHealthcareEntitiesResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, s_expectedBatchOutput);
        }

        private void ValidateDocumenResult(IReadOnlyCollection<HealthcareEntity> entities, List<string> minimumExpectedOutput)
        {
            Assert.That(entities.Count, Is.GreaterThanOrEqualTo(minimumExpectedOutput.Count));
            foreach (HealthcareEntity entity in entities)
            {
                Assert.That(entity.Text, Is.Not.Null.And.Not.Empty);
                Assert.That(entity.Category, Is.Not.Null);
                Assert.That(entity.ConfidenceScore, Is.GreaterThanOrEqualTo(0.0));
                Assert.That(entity.Offset, Is.GreaterThanOrEqualTo(0));
                Assert.That(entity.Length, Is.GreaterThan(0));

                if (entity.SubCategory != null)
                {
                    Assert.That(entity.SubCategory, Is.Not.Empty);
                }
            }
        }

        private void ValidateBatchResult(
            AnalyzeHealthcareEntitiesResultCollection results,
            Dictionary<string, List<string>> minimumExpectedOutput,
            bool includeStatistics = default)
        {
            Assert.That(results.ModelVersion, Is.Not.Null.And.Not.Empty);

            // TODO: https://github.com/Azure/azure-sdk-for-net/issues/31978.
            if (ServiceVersion is not TextAnalyticsClientOptions.ServiceVersion.V3_1)
            {
                if (includeStatistics)
                {
                    Assert.That(results.Statistics, Is.Not.Null);
                    Assert.That(results.Statistics.DocumentCount, Is.GreaterThan(0));
                    Assert.That(results.Statistics.TransactionCount, Is.GreaterThan(0));
                    Assert.That(results.Statistics.InvalidDocumentCount, Is.GreaterThanOrEqualTo(0));
                    Assert.That(results.Statistics.ValidDocumentCount, Is.GreaterThanOrEqualTo(0));
                }
                else
                    Assert.That(results.Statistics, Is.Null);
            }

            foreach (AnalyzeHealthcareEntitiesResult result in results)
            {
                Assert.That(result.Id, Is.Not.Null.And.Not.Empty);

                Assert.That(result.HasError, Is.False);

                //Even though statistics are not asked for, TA 5.0.0 shipped with Statistics default always present.
                Assert.That(result.Statistics, Is.Not.Null);

                // TODO: https://github.com/Azure/azure-sdk-for-net/issues/31978.
                if (ServiceVersion is not (TextAnalyticsClientOptions.ServiceVersion.V2022_05_01 or TextAnalyticsClientOptions.ServiceVersion.V3_1))
                {
                    if (includeStatistics)
                    {
                        Assert.That(result.Statistics.CharacterCount, Is.GreaterThanOrEqualTo(0));
                        Assert.That(result.Statistics.TransactionCount, Is.GreaterThan(0));
                    }
                    else
                    {
                        Assert.That(result.Statistics.CharacterCount, Is.EqualTo(0));
                        Assert.That(result.Statistics.TransactionCount, Is.EqualTo(0));
                    }
                }

                Assert.That(result.Warnings, Is.Not.Null);
                Assert.That(result.EntityRelations, Is.Not.Null);
                ValidateDocumenResult(result.Entities, minimumExpectedOutput[result.Id]);
            }
        }

        private void ValidateOperationProperties(AnalyzeHealthcareEntitiesOperation operation)
        {
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.CreatedOn, Is.Not.EqualTo(new DateTimeOffset()));
            // TODO: Re-enable this check (https://github.com/Azure/azure-sdk-for-net/issues/31855).
            // Assert.AreNotEqual(new DateTimeOffset(), operation.LastModified);

            if (operation.ExpiresOn.HasValue)
            {
                Assert.That(operation.ExpiresOn.Value, Is.Not.EqualTo(new DateTimeOffset()));
            }
        }
    }
}
