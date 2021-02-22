// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class RecognizeHealthcareEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public RecognizeHealthcareEntitiesTests(bool isAsync) : base(isAsync) { }

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

        [Test]
        public async Task RecognizeHealthcareEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments);

            await operation.WaitForCompletionAsync(PollingInterval);

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
                    Assert.IsTrue(entity.RelatedEntities.Count == 1);

                    var relatedEntity = entity.RelatedEntities.FirstOrDefault().Key;

                    Assert.AreEqual("ibuprofen", relatedEntity.Text);
                    Assert.AreEqual("MedicationName", relatedEntity.Category);
                    Assert.AreEqual(9, relatedEntity.Length);
                    Assert.AreEqual(27, relatedEntity.Offset);
                    Assert.AreEqual(1.0, relatedEntity.ConfidenceScore);
                    Assert.AreEqual(HealthcareEntityRelationType.DosageOfMedication, entity.RelatedEntities.FirstOrDefault().Value);
                }
            }
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchConvenienceDocuments, "en");

            await operation.WaitForCompletionAsync(PollingInterval);

            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "0", s_document1ExpectedEntitiesOutput },
                { "1", s_document2ExpectedEntitiesOutput },
            };

            ValidateBatchDocumentsResult(resultCollection, expectedOutput);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure.",
                "",
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(documents);

            await operation.WaitForCompletionAsync(PollingInterval);

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

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchConvenienceDocuments);

            await operation.WaitForCompletionAsync(PollingInterval);

            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "0", s_document1ExpectedEntitiesOutput },
                { "1", s_document2ExpectedEntitiesOutput },
            };

            ValidateBatchDocumentsResult(resultCollection, expectedOutput);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchConvenienceDocuments, "en", options);

            await operation.WaitForCompletionAsync(PollingInterval);

            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeHealthcareEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "0", s_document1ExpectedEntitiesOutput },
                { "1", s_document2ExpectedEntitiesOutput },
            };

            ValidateBatchDocumentsResult(resultCollection, expectedOutput, true);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments);

            await operation.WaitForCompletionAsync(PollingInterval);

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

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOptions options = new AnalyzeHealthcareEntitiesOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments, options);

            await operation.WaitForCompletionAsync(PollingInterval);

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

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchWithCancellation()
        {
            TextAnalyticsClient client = GetClient();
            string document = @"RECORD #333582770390100 | MH | 85986313 | | 054351 | 2/14/2001 12:00:00 AM | CORONARY ARTERY DISEASE | Signed | DIS |";

            var batchDocuments = new List<string>();

            for (var i = 0; i < 10; i++)
            {
                batchDocuments.Add(document);
            }

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(batchDocuments, "en");

            await operation.CancelAsync();

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());
            Assert.IsTrue(ex.Message.Contains("The operation was canceled so no value is available."));

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.AreEqual(200, operation.GetRawResponse().Status);
            Assert.AreEqual(TextAnalyticsOperationStatus.Cancelled, operation.Status);

            try
            {
                Assert.IsNull(operation.Value);
            }
            catch (RequestFailedException exception)
            {
                Assert.IsTrue(exception.Message.Contains("The operation was canceled so no value is available."));
            }
        }

        [Test]
        public async Task AnalyzeHealthcareEntitiesPagination()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeHealthcareEntitiesOperation operation = await client.StartAnalyzeHealthcareEntitiesAsync(s_batchDocuments);

            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.Throws<InvalidOperationException>(() => operation.GetValues());

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            ValidateOperationProperties(operation);

            // try async
            //There most be 1 page
            List<AnalyzeHealthcareEntitiesResultCollection> asyncPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, asyncPages.Count);

            // First page should have 2 results
            Assert.AreEqual(2, asyncPages[0].Count);

            // try sync
            //There most be 1 page
            List<AnalyzeHealthcareEntitiesResultCollection> pages = operation.GetValues().AsEnumerable().ToList();
            Assert.AreEqual(1, pages.Count);

            // First page should have 2 results
            Assert.AreEqual(2, pages[0].Count);
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

        private void ValidateBatchDocumentsResult(AnalyzeHealthcareEntitiesResultCollection results, Dictionary<string, List<string>> minimumExpectedOutput, bool includeStatistics = default)
        {
            Assert.That(results.ModelVersion, Is.Not.Null.And.Not.Empty);

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

            foreach (AnalyzeHealthcareEntitiesResult entitiesInDocument in results)
            {
                Assert.That(entitiesInDocument.Id, Is.Not.Null.And.Not.Empty);

                Assert.False(entitiesInDocument.HasError);

                //Even though statistics are not asked for, TA 5.0.0 shipped with Statistics default always present.
                Assert.IsNotNull(entitiesInDocument.Statistics);

                if (includeStatistics)
                {
                    Assert.GreaterOrEqual(entitiesInDocument.Statistics.CharacterCount, 0);
                    Assert.Greater(entitiesInDocument.Statistics.TransactionCount, 0);
                }
                else
                {
                    Assert.AreEqual(0, entitiesInDocument.Statistics.CharacterCount);
                    Assert.AreEqual(0, entitiesInDocument.Statistics.TransactionCount);
                }

                Assert.IsNotNull(entitiesInDocument.Warnings);
                ValidateInDocumenResult(entitiesInDocument.Entities, minimumExpectedOutput[entitiesInDocument.Id]);
            }
        }

        private void ValidateOperationProperties(AnalyzeHealthcareEntitiesOperation operation)
        {
            Assert.AreNotEqual(new DateTimeOffset(), operation.CreatedOn);
            Assert.AreNotEqual(new DateTimeOffset(), operation.LastModified);

            if (operation.ExpiresOn.HasValue)
            {
                Assert.AreNotEqual(new DateTimeOffset(), operation.ExpiresOn.Value);
            }
        }
    }
}
