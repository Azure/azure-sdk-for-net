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
    [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
    public class RecognizeCustomEntitiesTests : TextAnalyticsClientLiveTestBase
    {
        public RecognizeCustomEntitiesTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
           : base(isAsync, serviceVersion)
        {
        }

        private const string EnglishDocument1 = @"A recent report by the Government Accountability Office found a dramatic increase in oil.";
        private static readonly List<string> s_englishExpectedOutput1 = new List<string>
        {
            "recent",
            "Government",
            "Office",
            "Accountability",
            "dramatic",
            "oil",
        };

        private const string EnglishDocument2 = @"Capital Call #20 for Berkshire Multifamily.";
        private static readonly List<string> s_englishExpectedOutput2 = new List<string>
        {
            "Berkshire Multifamily",
        };

        private const string SpanishDocument1 = @"Un informe reciente de la Oficina de Responsabilidad del Gobierno encontró un aumento dramático en el petróleo.";
        private static readonly List<string> s_spanishExpectedOutput1 = new List<string>
        {
            "reciente",
            "Responsabilidad",
            "del",
            "Gobierno",
            "dramático",
            "petróleo",
        };

        private static readonly List<string> s_englishBatchConvenienceDocuments = new List<string>
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

        private static readonly Dictionary<string, List<string>> s_englishExpectedBatchOutput = new()
        {
            { "0", s_englishExpectedOutput1 },
            { "1", s_englishExpectedOutput2 },
        };

        [SetUp]
        public void TestSetup()
        {
            // These tests require a pre-trained, static resource,
            // which is currently only available in the public cloud.
            TestEnvironment.IgnoreIfNotPublicCloud();
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task RecognizeCustomEntitiesWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true, useStaticResource: true);

            RecognizeCustomEntitiesOperation operation = await client.RecognizeCustomEntitiesAsync(
                WaitUntil.Completed,
                new List<string> { EnglishDocument1 },
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName);
            ValidateOperationProperties(operation);

            List<RecognizeCustomEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = resultInPages.FirstOrDefault();
            RecognizeEntitiesResult firstResult = resultCollection.First();
            CategorizedEntityCollection entities = firstResult.Entities;
            ValidateDocumentResult(entities, s_englishExpectedOutput1);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task RecognizeCustomEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            RecognizeCustomEntitiesOperation operation = await client.RecognizeCustomEntitiesAsync(
                WaitUntil.Completed,
                s_batchDocuments,
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName);
            ValidateOperationProperties(operation);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_englishExpectedOutput1 },
                { "2", s_spanishExpectedOutput1 },
            };

            List<RecognizeCustomEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task RecognizeCustomEntitiesBatchWaitUntilStartedTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            RecognizeCustomEntitiesOperation operation = await client.RecognizeCustomEntitiesAsync(
                WaitUntil.Started,
                s_batchDocuments,
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName);
            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            ValidateOperationProperties(operation);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task RecognizeCustomEntitiesBatchWithNameTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            RecognizeCustomEntitiesOptions options = new RecognizeCustomEntitiesOptions
            {
                DisplayName = "StartRecognizeCustomEntitiesWithName",
            };

            RecognizeCustomEntitiesOperation operation = await client.RecognizeCustomEntitiesAsync(
                WaitUntil.Completed,
                s_batchDocuments,
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName,
                options);
            ValidateOperationProperties(operation);

            Assert.AreEqual("StartRecognizeCustomEntitiesWithName", operation.DisplayName);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_englishExpectedOutput1 },
                { "2", s_spanishExpectedOutput1 },
            };

            List<RecognizeCustomEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public void RecognizeCustomEntitiesBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            var documents = new List<TextDocumentInput> { new TextDocumentInput(null, "Hello world") };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                await client.RecognizeCustomEntitiesAsync(
                    WaitUntil.Completed,
                    documents,
                    TestEnvironment.RecognizeCustomEntitiesProjectName,
                    TestEnvironment.RecognizeCustomEntitiesDeploymentName));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, ex.ErrorCode);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task RecognizeCustomEntitiesBatchWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            List<TextDocumentInput> documentsBatch = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", SpanishDocument1) { Language = "es" }
            };

            RecognizeCustomEntitiesOperation operation = await client.RecognizeCustomEntitiesAsync(
                WaitUntil.Completed,
                documentsBatch,
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName);
            ValidateOperationProperties(operation);

            List<RecognizeCustomEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = resultInPages.FirstOrDefault();
            RecognizeEntitiesResult firstResult = resultCollection.First();
            CategorizedEntityCollection entities = firstResult.Entities;
            ValidateDocumentResult(entities, s_spanishExpectedOutput1);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task RecognizeCustomEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                 "",
                "My cat might need to see a veterinarian."
            };

            RecognizeCustomEntitiesOperation operation = await client.RecognizeCustomEntitiesAsync(
                WaitUntil.Completed,
                documents,
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName);
            ValidateOperationProperties(operation);

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            Assert.IsFalse(resultCollection[0].HasError);
            Assert.IsTrue(resultCollection[1].HasError);
            Assert.IsFalse(resultCollection[2].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, resultCollection[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task RecognizeCustomEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            RecognizeCustomEntitiesOperation operation = await client.RecognizeCustomEntitiesAsync(
                WaitUntil.Completed,
                s_englishBatchConvenienceDocuments,
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName);
            ValidateOperationProperties(operation);

            List<RecognizeCustomEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, s_englishExpectedBatchOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task RecognizeCustomEntitiesBatchConvenienceWaitUntilStartedTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            RecognizeCustomEntitiesOperation operation = await client.RecognizeCustomEntitiesAsync(
                WaitUntil.Started,
                s_englishBatchConvenienceDocuments,
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName);
            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            ValidateOperationProperties(operation);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeOperationRecognizeCustomEntities()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, s_englishBatchConvenienceDocuments, batchActions);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page.
            AnalyzeActionsResult actionsResult = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<RecognizeCustomEntitiesActionResult> recognizeCustomEntitiesActionsResults = actionsResult.RecognizeCustomEntitiesResults;
            Assert.IsNotNull(recognizeCustomEntitiesActionsResults);

            RecognizeCustomEntitiesResultCollection resultCollection = recognizeCustomEntitiesActionsResults.FirstOrDefault().DocumentsResults;
            ValidateBatchResult(resultCollection, s_englishExpectedBatchOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [Ignore("Issue https://github.com/Azure/azure-sdk-for-net/issues/25152")]
        public async Task AnalyzeOperationRecognizeCustomEntitiesWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                    {
                        DisableServiceLogs = true,
                        ActionName = "RecognizeCustomEntitiesWithDisabledServiceLogs"
                    },
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                    {
                        ActionName = "RecognizeCustomEntities"
                    }
                }
            };

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, s_englishBatchConvenienceDocuments, batchActions);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page.
            AnalyzeActionsResult actionsResult = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<RecognizeCustomEntitiesActionResult> recognizeCustomEntitiesActionsResults = actionsResult.RecognizeCustomEntitiesResults;
            Assert.IsNotNull(recognizeCustomEntitiesActionsResults);

            IList<string> expected = new List<string> { "RecognizeCustomEntities", "RecognizeCustomEntitiesWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, recognizeCustomEntitiesActionsResults.Select(result => result.ActionName));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task StartRecognizeCustomEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            RecognizeCustomEntitiesOperation operation = await client.StartRecognizeCustomEntitiesAsync(
                s_batchDocuments,
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName);
            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            ValidateOperationProperties(operation);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_englishExpectedOutput1 },
                { "2", s_spanishExpectedOutput1 },
            };

            List<RecognizeCustomEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task StartRecognizeCustomEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            RecognizeCustomEntitiesOperation operation = await client.StartRecognizeCustomEntitiesAsync(
                s_englishBatchConvenienceDocuments,
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName);
            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            ValidateOperationProperties(operation);

            List<RecognizeCustomEntitiesResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, s_englishExpectedBatchOutput);
        }

        private void ValidateOperationProperties(RecognizeCustomEntitiesOperation operation)
        {
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreNotEqual(new DateTimeOffset(), operation.CreatedOn);
            // TODO: Re-enable this check (https://github.com/Azure/azure-sdk-for-net/issues/31855).
            // Assert.AreNotEqual(new DateTimeOffset(), operation.LastModified);

            if (operation.ExpiresOn.HasValue)
            {
                Assert.AreNotEqual(new DateTimeOffset(), operation.ExpiresOn.Value);
            }
        }

        private void ValidateDocumentResult(CategorizedEntityCollection entities, List<string> minimumExpectedOutput)
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

        private void ValidateBatchResult(
            RecognizeCustomEntitiesResultCollection results,
            Dictionary<string, List<string>> minimumExpectedOutput,
            bool includeStatistics = default)
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

                ValidateDocumentResult(result.Entities, minimumExpectedOutput[result.Id]);
            }
        }
    }
}
