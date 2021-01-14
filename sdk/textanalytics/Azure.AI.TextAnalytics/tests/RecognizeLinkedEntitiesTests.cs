// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class RecognizeLinkedEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public RecognizeLinkedEntitiesTests(bool isAsync) : base(isAsync) { }

        private const string EnglishDocument1 = "Microsoft was founded by Bill Gates and Paul Allen.";
        private const string EnglishDocument2 = "Pike place market is my favorite Seattle attraction.";

        private const string SpanishDocument1 = "Microsoft fue fundado por Bill Gates y Paul Allen.";

        private static readonly List<string> s_batchConvenienceDocuments = new List<string>
        {
            EnglishDocument1,
            EnglishDocument2,
        };

        private static readonly List<TextDocumentInput> s_batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", EnglishDocument1)
            {
                 Language = "en",
            },
            new TextDocumentInput("3", SpanishDocument1)
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
            "Pike Place Market",
            "Seattle"
        };

        [Test]
        public async Task RecognizeLinkedEntitiesWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            LinkedEntityCollection linkedEntities = await client.RecognizeLinkedEntitiesAsync(EnglishDocument1);

            ValidateInDocumenResult(linkedEntities, s_document1ExpectedOutput);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            LinkedEntityCollection linkedEntities = await client.RecognizeLinkedEntitiesAsync(EnglishDocument1);

            ValidateInDocumenResult(linkedEntities, s_document1ExpectedOutput);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            LinkedEntityCollection linkedEntities = await client.RecognizeLinkedEntitiesAsync(SpanishDocument1, "es");

            ValidateInDocumenResult(linkedEntities, s_document1ExpectedOutput);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "",
                "Pike place market is my favorite Seattle attraction.",
            };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public void RecognizeLinkedEntitiesBatchWithInvalidDocumentBatch()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Hello world",
                "Pike place market is my favorite Seattle attraction.",
                "I had a wonderful trip to Seattle last week and even visited the Space Needle 2 times!",
                "Unfortunately, it rained during my entire trip to Seattle. I didn't even get to visit the Space Needle",
                "This should fail!"
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.RecognizeLinkedEntitiesBatchAsync(documents));
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocumentBatch, ex.ErrorCode);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(s_batchConvenienceDocuments);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "0", s_document1ExpectedOutput },
                { "1", s_document2ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(s_batchConvenienceDocuments, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "0", s_document1ExpectedOutput },
                { "1", s_document2ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput, includeStatistics: true);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(s_batchDocuments);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedOutput },
                { "3", s_document1ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(s_batchDocuments, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedOutput },
                { "3", s_document1ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput, includeStatistics: true);
        }

        [Test]
        public void RecognizeLinkedEntitiesBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.RecognizeLinkedEntitiesBatchAsync(documents));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, ex.ErrorCode);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchWithNullTextTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput> { new TextDocumentInput("1", null) };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents);
            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[0].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[0].Entities.Count());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        private void ValidateInDocumenResult(LinkedEntityCollection entities, List<string> minimumExpectedOutput)
        {
            Assert.IsNotNull(entities.Warnings);
            Assert.GreaterOrEqual(entities.Count, minimumExpectedOutput.Count);
            foreach (LinkedEntity entity in entities)
            {
                Assert.That(entity.Name, Is.Not.Null.And.Not.Empty);
                Assert.That(entity.Language, Is.Not.Null.And.Not.Empty);
                Assert.That(entity.DataSource, Is.Not.Null.And.Not.Empty);
                Assert.IsNotNull(entity.Url);

                if (entity.DataSourceEntityId != null)
                {
                    Assert.IsNotEmpty(entity.DataSourceEntityId);
                }

                if (entity.BingEntitySearchApiId != null)
                {
                    Assert.IsNotEmpty(entity.BingEntitySearchApiId);
                }

                Assert.GreaterOrEqual(entity.Matches.Count(), 1);
                foreach (LinkedEntityMatch match in entity.Matches)
                {
                    Assert.That(match.Text, Is.Not.Null.And.Not.Empty);
                    Assert.IsTrue(minimumExpectedOutput.Contains(match.Text, StringComparer.OrdinalIgnoreCase));
                    Assert.GreaterOrEqual(match.ConfidenceScore, 0.0);
                    Assert.GreaterOrEqual(match.Offset, 0);
                }
            }
        }

        private void ValidateBatchDocumentsResult(RecognizeLinkedEntitiesResultCollection results, Dictionary<string, List<string>> minimumExpectedOutput, bool includeStatistics = default)
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

            foreach (RecognizeLinkedEntitiesResult entitiesInDocument in results)
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

                ValidateInDocumenResult(entitiesInDocument.Entities, minimumExpectedOutput[entitiesInDocument.Id]);
            }
        }
    }
}
