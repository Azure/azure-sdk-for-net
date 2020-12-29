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

        private const string SingleEnglish = "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.";

        private static readonly List<string> s_batchConvenienceDocuments = new List<string>
        {
            "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs.",
            "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check."
        };

        private static readonly List<TextDocumentInput> s_batchDocuments = new List<TextDocumentInput>
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
        public async Task RecognizePiiEntitiesWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(SingleEnglish);

            ValidateInDocumenResult(entities, 2);
        }

        [Test]
        public async Task RecognizePiiEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(SingleEnglish);

            ValidateInDocumenResult(entities, 2);
        }

        [Test]
        public async Task RecognizePiiEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(SingleEnglish, "en");

            ValidateInDocumenResult(entities, 2);
        }

        [Test]
        public async Task RecognizePiiEntitiesWithDomainTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "I work at Microsoft and my email is atest@microsoft.com";

            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(document, "en", new RecognizePiiEntitiesOptions() { DomainFilter = PiiEntityDomainType.ProtectedHealthInformation } );

            ValidateInDocumenResult(entities, 1);
            Assert.AreEqual("atest@microsoft.com", entities.FirstOrDefault().Text);
            Assert.AreEqual(EntityCategory.Email, entities.FirstOrDefault().Category);
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
            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(s_batchConvenienceDocuments);

            ValidateBatchDocumentsResult(results);
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(s_batchConvenienceDocuments, "en", new RecognizePiiEntitiesOptions { IncludeStatistics = true });

            ValidateBatchDocumentsResult(results, includeStatistics: true);
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(s_batchDocuments);

            ValidateBatchDocumentsResult(results);
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(s_batchDocuments, new RecognizePiiEntitiesOptions { IncludeStatistics = true });

            ValidateBatchDocumentsResult(results, includeStatistics: true);
        }

        private void ValidateInDocumenResult(PiiEntityCollection entities, int minCount = 1)
        {
            Assert.IsNotNull(entities.Warnings);
            Assert.That(entities.RedactedText, Is.Not.Null.And.Not.Empty);
            Assert.GreaterOrEqual(entities.Count, minCount);
            foreach (PiiEntity entity in entities)
            {
                Assert.That(entity.Text, Is.Not.Null.And.Not.Empty);
                Assert.IsNotNull(entity.Category);
                Assert.GreaterOrEqual(entity.ConfidenceScore, 0.0);
                Assert.GreaterOrEqual(entity.Offset, 0);

                if (entity.SubCategory != null)
                {
                    Assert.IsNotEmpty(entity.SubCategory);
                }
            }
        }

        private void ValidateBatchDocumentsResult(RecognizePiiEntitiesResultCollection results, bool includeStatistics = default)
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

            foreach (RecognizePiiEntitiesResult entitiesInDocument in results)
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

                ValidateInDocumenResult(entitiesInDocument.Entities);
            }
        }
    }
}
