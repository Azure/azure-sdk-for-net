// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class RecognizePiiEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public RecognizePiiEntitiesTests(bool isAsync) : base(isAsync) { }

        private const string singleEnglish = "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.";

        private static List<string> batchConvenienceDocuments = new List<string>
        {
            "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.",
            "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check."
        };

        private static List<TextDocumentInput> batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.")
            {
                 Language = "en",
            },
            new TextDocumentInput("2", "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.")
            {
                 Language = "en",
            }
        };

        [Test]
        public async Task RecognizePiiEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(document);

            Assert.AreEqual(2, entities.Count);
            Assert.IsNotNull(entities.RedactedText);

            var entitiesList = new List<string> { "859-98-0987", "800-102-1100" };
            foreach (PiiEntity entity in entities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Text));
            }
        }

        [Test]
        public async Task RecognizePiiEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(document, "en");

            Assert.AreEqual(2, entities.Count);
            Assert.IsNotNull(entities.RedactedText);
        }

        [Test]
        public async Task RecognizePiiEntitiesWithDomainTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "I work at Microsoft and my email is atest@microsoft.com";

            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(document, "en", new RecognizePiiEntitiesOptions() { DomainFilter = PiiEntityDomainType.ProtectedHealthInformation } );

            Assert.AreEqual(1, entities.Count);
            Assert.AreEqual("atest@microsoft.com", entities.FirstOrDefault().Text);
            Assert.AreEqual(EntityCategory.Email, entities.FirstOrDefault().Category);
            Assert.IsNotNull(entities.RedactedText);
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.",
                "",
                "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.",
            };

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(documents);

            Assert.IsFalse(results[0].HasError);
            Assert.IsFalse(results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(documents);

            foreach (RecognizePiiEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(documents, "en", new RecognizePiiEntitiesOptions { IncludeStatistics = true });

            foreach (RecognizePiiEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }

            Assert.Greater(results.Statistics.DocumentCount, 0);
            Assert.AreEqual(0, results.Statistics.InvalidDocumentCount);
            Assert.Greater(results.Statistics.TransactionCount, 0);
            Assert.Greater(results.Statistics.ValidDocumentCount, 0);
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(documents);

            foreach (RecognizePiiEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(documents, new RecognizePiiEntitiesOptions { IncludeStatistics = true });

            foreach (RecognizePiiEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }

            Assert.Greater(results.Statistics.DocumentCount, 0);
            Assert.AreEqual(0, results.Statistics.InvalidDocumentCount);
            Assert.Greater(results.Statistics.TransactionCount, 0);
            Assert.Greater(results.Statistics.ValidDocumentCount, 0);
        }
    }
}
