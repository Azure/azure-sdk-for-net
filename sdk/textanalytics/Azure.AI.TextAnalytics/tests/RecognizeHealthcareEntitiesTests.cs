// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class RecognizeHealthcareEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public RecognizeHealthcareEntitiesTests(bool isAsync) : base(isAsync) { }

        private const string singleEnglish = "Subject is taking 100mg of ibuprofen twice daily";

        private static List<string> batchConvenienceDocuments = new List<string>
        {
            "Subject is taking 100mg of ibuprofen twice daily",
            "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure."
        };

        private static List<TextDocumentInput> batchDocuments = new List<TextDocumentInput>
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

        [Test]
        public async Task RecognizeHealthcareEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            HealthcareOperation operation = await client.StartHealthcareAsync(document);

            await operation.WaitForCompletionAsync();

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(1, resultCollection.Count);

            var entitiesList = new List<string> { "100mg", "ibuprofen", "twice daily" };
            foreach (DocumentHealthcareResult result in resultCollection)
            {
                foreach (HealthcareEntity entity in result.Entities)
                {
                    Assert.IsTrue(entitiesList.Contains(entity.Text));
                }
            }
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = singleEnglish;

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(new List<string>() { document }, "en");

            await operation.WaitForCompletionAsync();

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            foreach (DocumentHealthcareResult result in resultCollection)
            {
                Assert.AreEqual(3, result.Entities.Count);
                Assert.IsNotNull(result.Id);
            }
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesWithTopParameter()
        {
            TextAnalyticsClient client = GetClient();

            HealthcareOptions options = new HealthcareOptions()
            {
                Top = 1,
                Skip = 0,
                IncludeStatistics = true
            };

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(batchDocuments, options);

            await operation.WaitForCompletionAsync();

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(1, resultCollection.Count);
            Assert.AreEqual(3, resultCollection[0].Entities.Count);
            Assert.IsNotNull(resultCollection[0].Id);
            Assert.AreEqual("100mg", resultCollection[0].Entities.FirstOrDefault().Text);
            Assert.AreEqual("Dosage", resultCollection[0].Entities.FirstOrDefault().Category);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesWithSkipParameter()
        {
            TextAnalyticsClient client = GetClient();

            HealthcareOptions options = new HealthcareOptions()
            {
                Skip = 1
            };

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(batchDocuments, options);

            await operation.WaitForCompletionAsync();

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(1, resultCollection.Count);
            Assert.AreEqual(6, resultCollection[0].Entities.Count);
            Assert.IsNotNull(resultCollection[0].Id);
            Assert.AreEqual("rapid", resultCollection[0].Entities.FirstOrDefault().Text);
            Assert.AreEqual("SymptomOrSign", resultCollection[0].Entities.FirstOrDefault().Category);
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

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(documents);

            await operation.WaitForCompletionAsync();

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.IsNotNull(resultCollection[0].Id);
            Assert.IsNotNull(resultCollection[0].TextAnalyticsError);
            Assert.AreEqual("Document text is empty.", resultCollection[0].TextAnalyticsError.Message);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, resultCollection[0].TextAnalyticsError.ErrorCode.ToString());
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(documents);

            await operation.WaitForCompletionAsync();

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.AreEqual(resultCollection.Count(), 2);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchConvenienceDocuments;

            HealthcareOptions options = new HealthcareOptions()
            {
                IncludeStatistics = true
            };

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(documents, "en", options);

            await operation.WaitForCompletionAsync();

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.GreaterOrEqual(resultCollection.Count(), 2);

            Assert.Greater(resultCollection.Statistics.DocumentCount, 0);
            Assert.AreEqual(2, resultCollection.Statistics.DocumentCount);
            Assert.AreEqual(2, resultCollection.Statistics.TransactionCount);
            Assert.AreEqual(0, resultCollection.Statistics.InvalidDocumentCount);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = batchDocuments;

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(documents);

            await operation.WaitForCompletionAsync();

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.GreaterOrEqual(resultCollection.Count(), 2);
        }

        [Test]
        public async Task RecognizeHealthcareEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = batchDocuments;

            HealthcareOptions options = new HealthcareOptions()
            {
                IncludeStatistics = true
            };

            HealthcareOperation operation = await client.StartHealthcareBatchAsync(documents, options);

            await operation.WaitForCompletionAsync();

            RecognizeHealthcareEntitiesResultCollection resultCollection = operation.Value;

            Assert.GreaterOrEqual(resultCollection.Count(), 2);

            Assert.Greater(resultCollection.Statistics.DocumentCount, 0);
            Assert.AreEqual(2, resultCollection.Statistics.DocumentCount);
            Assert.AreEqual(2, resultCollection.Statistics.TransactionCount);
            Assert.AreEqual(0, resultCollection.Statistics.InvalidDocumentCount);
        }
    }
}
