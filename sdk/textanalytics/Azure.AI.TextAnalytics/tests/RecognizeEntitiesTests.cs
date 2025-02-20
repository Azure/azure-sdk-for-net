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
    public class RecognizeEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public RecognizeEntitiesTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string EnglishDocument1 = "Microsoft was founded by Bill Gates and Paul Allen.";
        private const string EnglishDocument2 = "My cat and my dog might need to see a veterinarian.";

        private const string SpanishDocument1 = "Microsoft fue fundado por Bill Gates y Paul Allen.";

        private static readonly List<string> s_batchConvenienceDocuments = new List<string>
        {
            EnglishDocument1,
            EnglishDocument2
        };

        private static readonly List<TextDocumentInput> s_batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", EnglishDocument1)
            {
                 Language = "en",
            },
            new TextDocumentInput("2", SpanishDocument1)
            {
                 Language = "es",
            }
        };

        private static readonly List<string> s_document1ExpectedOutput = new List<string>
        {
            "Microsoft",
            "Bill Gates",
            "Paul Allen"
        };

        private static readonly List<string> s_document2ExpectedOutput = new List<string>
        {
            "veterinarian"
        };

        private static readonly Dictionary<string, List<string>> s_expectedBatchOutput = new()
        {
            { "0", s_document1ExpectedOutput },
            { "1", s_document2ExpectedOutput },
        };

        [RecordedTest]
        public async Task RecognizeEntitiesWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(EnglishDocument1);

            ValidateInDocumenResult(entities, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(EnglishDocument1);

            ValidateInDocumenResult(entities, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(SpanishDocument1, "es");

            ValidateInDocumenResult(entities, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesWithSubCategoryTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "I had a wonderful trip to Seattle last week.";

            RecognizeEntitiesResultCollection result = await client.RecognizeEntitiesBatchAsync(new List<string>() { document });

            RecognizeEntitiesResult documentResult = result.FirstOrDefault();
            Assert.IsFalse(documentResult.HasError);
            Assert.GreaterOrEqual(documentResult.Entities.Count, 3);

            foreach (CategorizedEntity entity in documentResult.Entities)
            {
                if (entity.Text == "last week")
                    Assert.AreEqual("DateRange", entity.SubCategory);
            }
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                 "",
                "My cat might need to see a veterinarian."
            };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        public void RecognizeEntitiesBatchWithInvalidDocumentBatch()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "document 1",
                "document 2",
                "document 3",
                "document 4",
                "document 5",
                "document 6"
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.RecognizeEntitiesBatchAsync(documents));
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocumentBatch, ex.ErrorCode);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(s_batchConvenienceDocuments);

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsRequestOptions options = new TextAnalyticsRequestOptions { IncludeStatistics = true };
            TextAnalyticsClient client = GetClient();
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(s_batchConvenienceDocuments, "en", options);

            ValidateBatchDocumentsResult(results, expectedOutput, includeStatistics: true);

            // Assert the options classes since overloads were added and the original now instantiates a RecognizeEntitiesOptions.
            Assert.IsTrue(options.IncludeStatistics);
            Assert.IsNull(options.ModelVersion);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(s_batchDocuments);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedOutput },
                { "2", s_document1ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsRequestOptions options = new TextAnalyticsRequestOptions { IncludeStatistics = true };
            TextAnalyticsClient client = GetClient();
            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(s_batchDocuments, options);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedOutput },
                { "2", s_document1ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput, includeStatistics: true);

            // Assert the options classes since overloads were added and the original now instantiates a RecognizeEntitiesOptions.
            Assert.IsTrue(options.IncludeStatistics);
            Assert.IsNull(options.ModelVersion);
        }

        [RecordedTest]
        public void RecognizeEntitiesBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.RecognizeEntitiesBatchAsync(documents));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, ex.ErrorCode);
        }

        [RecordedTest]
        public async Task RecognizeEntitiesBatchWithNullTextTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput("1", null) };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents);
            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[0].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[0].Entities.Count());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        [Ignore("LRO not implemented")]
        public async Task RecognizeEntitiesWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>()
                {
                    new RecognizeEntitiesAction()
                    {
                        DisableServiceLogs = true,
                        ActionName = "RecognizeEntitiesWithDisabledServiceLogs"
                    },
                    new RecognizeEntitiesAction()
                    {
                        ActionName = "RecognizeEntities"
                    }
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_batchDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizeEntitiesActionResult> RecognizeEntitiesActionsResults = resultCollection.RecognizeEntitiesResults;

            Assert.IsNotNull(RecognizeEntitiesActionsResults);

            IList<string> expected = new List<string> { "RecognizeEntities", "RecognizeEntitiesWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, RecognizeEntitiesActionsResults.Select(result => result.ActionName));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task RecognizeEntitiesBatchDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(s_batchConvenienceDocuments, options: new TextAnalyticsRequestOptions { DisableServiceLogs = true });

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_0)]
        public void RecognizeEntitiesBatchDisableServiceLogsThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();
            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.RecognizeEntitiesBatchAsync(s_batchConvenienceDocuments, options: new TextAnalyticsRequestOptions { DisableServiceLogs = true }));
            Assert.AreEqual("TextAnalyticsRequestOptions.DisableServiceLogs is not available in API version v3.0. Use service API version v3.1 or newer.", ex.Message);
        }

        private void ValidateInDocumenResult(CategorizedEntityCollection entities, List<string> minimumExpectedOutput)
        {
            Assert.IsNotNull(entities.Warnings);
            Assert.GreaterOrEqual(entities.Count, minimumExpectedOutput.Count);
            foreach (CategorizedEntity entity in entities)
            {
                Assert.That(entity.Text, Is.Not.Null.And.Not.Empty);
                Assert.IsTrue(minimumExpectedOutput.Contains(entity.Text, StringComparer.OrdinalIgnoreCase));
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
            RecognizeEntitiesResultCollection results,
            Dictionary<string, List<string>> minimumExpectedOutput,
            bool includeStatistics = default)
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

            foreach (RecognizeEntitiesResult result in results)
            {
                Assert.That(result.Id, Is.Not.Null.And.Not.Empty);
                Assert.False(result.HasError);

                //Even though statistics are not asked for, TA 5.0.0 shipped with Statistics default always present.
                Assert.IsNotNull(result.Statistics);

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

                ValidateInDocumenResult(result.Entities, minimumExpectedOutput[result.Id]);
            }
        }
    }
}
