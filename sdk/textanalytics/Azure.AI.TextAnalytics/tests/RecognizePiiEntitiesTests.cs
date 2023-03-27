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
    [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
    public class RecognizePiiEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public RecognizePiiEntitiesTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string EnglishDocument1 = "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs. They work at Microsoft";
        private const string EnglishDocument2 = "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check";

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
            new TextDocumentInput("2", EnglishDocument2)
            {
                 Language = "en",
            }
        };

        private static readonly List<string> s_document1ExpectedOutput = new List<string>
        {
            "859-98-0987",
            "800-102-1100",
            "Microsoft",
            "developer"
        };

        private static readonly List<string> s_document2ExpectedOutput = new List<string>
        {
            "111000025"
        };

        private static readonly Dictionary<string, List<string>> s_expectedBatchOutput = new()
        {
            { "0", s_document1ExpectedOutput },
            { "1", s_document2ExpectedOutput },
        };

        [RecordedTest]
        public async Task RecognizePiiEntitiesWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(EnglishDocument1);

            ValidateInDocumenResult(entities, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizePiiEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(EnglishDocument1);

            ValidateInDocumenResult(entities, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizePiiEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(EnglishDocument1, "en");

            ValidateInDocumenResult(entities, s_document1ExpectedOutput);
        }

        [RecordedTest]
        public async Task RecognizePiiEntitiesWithDomainTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "I work at Microsoft and my email is atest@microsoft.com";

            PiiEntityCollection entities = await client.RecognizePiiEntitiesAsync(document, "en", new RecognizePiiEntitiesOptions() { DomainFilter = PiiEntityDomain.ProtectedHealthInformation } );

            ValidateInDocumenResult(entities, new List<string>() { "atest@microsoft.com", "Microsoft" });
        }

        [RecordedTest]
        public async Task RecognizePiiEntitiesWithCategoriesTest()
        {
            TextAnalyticsClient client = GetClient();
            PiiEntityCollection entities;

            entities = await client.RecognizePiiEntitiesAsync(EnglishDocument1, "en", new RecognizePiiEntitiesOptions() { CategoriesFilter = { PiiEntityCategory.PhoneNumber} });
            ValidateInDocumenResult(entities, new List<string>() { "800-102-1100" });

            entities = await client.RecognizePiiEntitiesAsync(EnglishDocument1, "en", new RecognizePiiEntitiesOptions() { CategoriesFilter = { PiiEntityCategory.PhoneNumber, PiiEntityCategory.Organization } });
            ValidateInDocumenResult(entities, new List<string>() { "800-102-1100", "Microsoft" });

            entities = await client.RecognizePiiEntitiesAsync(EnglishDocument1, "en", new RecognizePiiEntitiesOptions() { CategoriesFilter = { PiiEntityCategory.ABARoutingNumber } });
            Assert.AreEqual(0, entities.Count);
        }

        [RecordedTest]
        public async Task RecognizePiiEntitiesWithResultCategoriesTest()
        {
            TextAnalyticsClient client = GetClient();

            PiiEntityCollection originalEntities = await client.RecognizePiiEntitiesAsync(EnglishDocument1);

            List<PiiEntityCategory> piiCategories = new();
            foreach (var entity in originalEntities)
            {
                piiCategories.Add(entity.Category);
            }

            PiiEntityCollection newEntities = await client.RecognizePiiEntitiesAsync(EnglishDocument1, "en", new RecognizePiiEntitiesOptions() { CategoriesFilter = piiCategories });
            ValidateInDocumenResult(newEntities, s_document1ExpectedOutput);
        }

        [RecordedTest]
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

        [RecordedTest]
        public async Task RecognizePiiEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(s_batchConvenienceDocuments);

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        public async Task RecognizePiiEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(s_batchConvenienceDocuments, "en", new RecognizePiiEntitiesOptions { IncludeStatistics = true });

            ValidateBatchDocumentsResult(results, expectedOutput, includeStatistics: true);
        }

        [RecordedTest]
        public async Task RecognizePiiEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(s_batchDocuments);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedOutput },
                { "2", s_document2ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        public async Task RecognizePiiEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(s_batchDocuments, new RecognizePiiEntitiesOptions { IncludeStatistics = true });

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_document1ExpectedOutput },
                { "2", s_document2ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput, includeStatistics: true);
        }

        [RecordedTest]
        public async Task RecognizePiiEntitiesBatchWithDomainTest()
        {
            TextAnalyticsClient client = GetClient();

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(s_batchDocuments, new RecognizePiiEntitiesOptions() { DomainFilter = PiiEntityDomain.ProtectedHealthInformation });

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", new List<string>() { "800-102-1100", "800-102-1100", "Microsoft" } },
                { "2", s_document2ExpectedOutput },
            };

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        public async Task RecognizePiiEntitiesBatchWitCategoryTest()
        {
            TextAnalyticsClient client = GetClient();

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(s_batchDocuments, new RecognizePiiEntitiesOptions() { CategoriesFilter = { PiiEntityCategory.PhoneNumber } });

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", new List<string>() { "800-102-1100" } },
                { "2", new List<string>() { "111000025" } },
            };

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        [RecordedTest]
        [Ignore("LRO not implemented")]
        public async Task RecognizePiiEntitiesWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>()
                {
                    new RecognizePiiEntitiesAction()
                    {
                        DisableServiceLogs = true,
                        ActionName = "RecognizePiiEntitiesWithDisabledServiceLogs"
                    },
                    new RecognizePiiEntitiesAction()
                    {
                        ActionName = "RecognizePiiEntities"
                    }
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_batchDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizePiiEntitiesActionResult> RecognizePiiEntitiesActionsResults = resultCollection.RecognizePiiEntitiesResults;

            Assert.IsNotNull(RecognizePiiEntitiesActionsResults);

            IList<string> expected = new List<string> { "RecognizePiiEntities", "RecognizePiiEntitiesWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, RecognizePiiEntitiesActionsResults.Select(result => result.ActionName));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeOperationRecognizePiiEntitiesWithAutoDetectedLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            List<string> documents = s_batchConvenienceDocuments;
            Dictionary<string, List<string>> expectedOutput = s_expectedBatchOutput;
            TextAnalyticsActions actions = new()
            {
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { new RecognizePiiEntitiesAction() },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, actions, "auto");
            await operation.WaitForCompletionAsync();

            // Take the first page.
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> actionResults = resultCollection.RecognizePiiEntitiesResults;
            Assert.IsNotNull(actionResults);

            RecognizePiiEntitiesResultCollection results = actionResults.FirstOrDefault().DocumentsResults;
            ValidateBatchDocumentsResult(results, expectedOutput, isLanguageAutoDetected: true);
        }

        private void ValidateInDocumenResult(PiiEntityCollection entities, List<string> minimumExpectedOutput)
        {
            Assert.IsNotNull(entities.Warnings);
            Assert.That(entities.RedactedText, Is.Not.Null.And.Not.Empty);
            Assert.GreaterOrEqual(entities.Count, minimumExpectedOutput.Count);
            foreach (PiiEntity entity in entities)
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
            foreach (var text in minimumExpectedOutput)
            {
                Assert.IsTrue(entities.Any(e => e.Text == text));
            }
        }

        private void ValidateBatchDocumentsResult(
            RecognizePiiEntitiesResultCollection results,
            Dictionary<string, List<string>> minimumExpectedOutput,
            bool includeStatistics = default,
            bool isLanguageAutoDetected = default)
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

            foreach (RecognizePiiEntitiesResult result in results)
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

                if (isLanguageAutoDetected)
                {
                    Assert.IsNotNull(result.DetectedLanguage);
                    Assert.That(result.DetectedLanguage.Value.Name, Is.Not.Null.And.Not.Empty);
                    Assert.That(result.DetectedLanguage.Value.Iso6391Name, Is.Not.Null.And.Not.Empty);
                    Assert.GreaterOrEqual(result.DetectedLanguage.Value.ConfidenceScore, 0.0);
                    Assert.LessOrEqual(result.DetectedLanguage.Value.ConfidenceScore, 1.0);
                    Assert.IsNotNull(result.DetectedLanguage.Value.Warnings);
                    Assert.IsEmpty(result.DetectedLanguage.Value.Warnings);
                }
                else
                {
                    Assert.IsNull(result.DetectedLanguage);
                }

                ValidateInDocumenResult(result.Entities, minimumExpectedOutput[result.Id]);
            }
        }
    }
}
