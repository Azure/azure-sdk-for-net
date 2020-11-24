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

        private const string singleEnglish = "Microsoft was founded by Bill Gates and Paul Allen.";
        private const string singleSpanish = "Microsoft fue fundado por Bill Gates y Paul Allen.";

        private static List<string> batchConvenienceDocuments = new List<string>
        {
            "Microsoft was founded by Bill Gates and Paul Allen.",
            "Pike place market is my favorite Seattle attraction.",
        };

        private static List<TextDocumentInput> batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
            {
                 Language = "en",
            },
            new TextDocumentInput("3", "Pike place market is my favorite Seattle attraction.")
            {
                 Language = "en",
            }
        };

        [Test]
        public async Task RecognizeLinkedEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            LinkedEntityCollection linkedEntities = await client.RecognizeLinkedEntitiesAsync(document);

            Assert.AreEqual(3, linkedEntities.Count);

            var entitiesList = new List<string> { "Bill Gates", "Microsoft", "Paul Allen" };
            foreach (LinkedEntity entity in linkedEntities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Name));
                Assert.IsNotNull(entity.DataSource);
                Assert.IsNotNull(entity.DataSourceEntityId);
                Assert.IsNotNull(entity.Language);
                Assert.IsNotNull(entity.Url);
                Assert.IsNotNull(entity.Matches);
                Assert.IsNotNull(entity.BingEntitySearchApiId);

                LinkedEntityMatch match = entity.Matches.First();
                Assert.IsNotNull(match.ConfidenceScore);
                Assert.IsNotNull(match.Text);
            }
        }

        [Test]
        public async Task RecognizeLinkedEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleSpanish;

            LinkedEntityCollection linkedEntities = await client.RecognizeLinkedEntitiesAsync(document, "es");

            Assert.GreaterOrEqual(linkedEntities.Count, 3);
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
            var documents = batchConvenienceDocuments;

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents);

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents);

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
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
    }
}
