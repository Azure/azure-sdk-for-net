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

        [RecordedTest]
        public async Task RecognizeCustomEntitiesWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true, useStaticResource: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                }
            };

            var operation = await client.StartAnalyzeActionsAsync(new List<string> { EnglishDocument1 }, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            RecognizeCustomEntitiesResultCollection results = ExtractDocumentsResultsFromResponse(operation);
            RecognizeEntitiesResult firstResult = results.First();
            CategorizedEntityCollection entites = firstResult.Entities;
            ValidateInDocumentResult(entites, s_englishExpectedOutput1);
        }

        [RecordedTest]
        public async Task RecognizeCustomEntitiesTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                }
            };

            var operation = await client.StartAnalyzeActionsAsync(new List<string> { EnglishDocument1 }, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            RecognizeCustomEntitiesResultCollection results = ExtractDocumentsResultsFromResponse(operation);
            RecognizeEntitiesResult firstResult = results.First();
            CategorizedEntityCollection entites = firstResult.Entities;
            ValidateInDocumentResult(entites, s_englishExpectedOutput1);
        }

        [RecordedTest]
        public async Task RecognizeCustomEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                }
            };

            List<TextDocumentInput> documentsBatch = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", SpanishDocument1) { Language = "es" }
            };

            var operation = await client.StartAnalyzeActionsAsync(documentsBatch, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            RecognizeCustomEntitiesResultCollection results = ExtractDocumentsResultsFromResponse(operation);
            RecognizeEntitiesResult firstResult = results.First();
            CategorizedEntityCollection entites = firstResult.Entities;
            ValidateInDocumentResult(entites, s_spanishExpectedOutput1);
        }

        [RecordedTest]
        public async Task RecognizeCustomEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                 "",
                "My cat might need to see a veterinarian."
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                }
            };

            var operation = await client.StartAnalyzeActionsAsync(documents, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            var results = ExtractDocumentsResultsFromResponse(operation);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        public async Task RecognizeCustomEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            Dictionary<string, List<string>> expectedOutput = s_englishExpectedBatchOutput;
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                }
            };

            var operation = await client.StartAnalyzeActionsAsync(s_englishBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            var results = ExtractDocumentsResultsFromResponse(operation);

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        public async Task RecognizeCustomEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                }
            };

            var operation = await client.StartAnalyzeActionsAsync(s_batchDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            var results = ExtractDocumentsResultsFromResponse(operation);

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_englishExpectedOutput1 },
                { "2", s_spanishExpectedOutput1 },
            };

            ValidateBatchDocumentsResult(results, expectedOutput);
        }

        [RecordedTest]
        public void RecognizeCustomEntitiesBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            var documents = new List<TextDocumentInput> { new TextDocumentInput(null, "Hello world") };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                }
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartAnalyzeActionsAsync(documents, batchActions));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, ex.ErrorCode);
        }

        [RecordedTest]
        [Ignore("Issue https://github.com/Azure/azure-sdk-for-net/issues/25152")]
        public async Task RecognizeCustomEntitiesWithMultipleActions()
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

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_englishBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizeCustomEntitiesActionResult> RecognizeCustomEntitiesActionsResults = resultCollection.RecognizeCustomEntitiesResults;

            Assert.IsNotNull(RecognizeCustomEntitiesActionsResults);

            IList<string> expected = new List<string> { "RecognizeCustomEntities", "RecognizeCustomEntitiesWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, RecognizeCustomEntitiesActionsResults.Select(result => result.ActionName));
        }

        [RecordedTest]
        public async Task StartRecognizeCustomEntities()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            RecognizeCustomEntitiesOperation operation = await client.StartRecognizeCustomEntitiesAsync(s_batchDocuments, TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_englishExpectedOutput1 },
                { "2", s_spanishExpectedOutput1 },
            };

            ValidateBatchDocumentsResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        public async Task StartRecognizeCustomEntitiesWithName()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            RecognizeCustomEntitiesOperation operation = await client.StartRecognizeCustomEntitiesAsync(s_batchDocuments, TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName, new RecognizeCustomEntitiesOptions
            {
                DisplayName = "StartRecognizeCustomEntitiesWithName",
            });

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual("StartRecognizeCustomEntitiesWithName", operation.DisplayName);

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            var expectedOutput = new Dictionary<string, List<string>>()
            {
                { "1", s_englishExpectedOutput1 },
                { "2", s_spanishExpectedOutput1 },
            };

            ValidateBatchDocumentsResult(resultCollection, expectedOutput);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task RecognizeCustomEntitiesBatchConvenienceWithAutoDetectedLanguageTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            RecognizeCustomEntitiesOperation operation = await client.StartRecognizeCustomEntitiesAsync(
                s_englishBatchConvenienceDocuments,
                TestEnvironment.RecognizeCustomEntitiesProjectName,
                TestEnvironment.RecognizeCustomEntitiesDeploymentName,
                "auto");
            await operation.WaitForCompletionAsync();

            // Take the first page.
            RecognizeCustomEntitiesResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateBatchDocumentsResult(resultCollection, s_englishExpectedBatchOutput, isLanguageAutoDetected: true);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeOperationRecognizeCustomEntitiesWithAutoDetectedLanguageTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            List<string> documents = s_englishBatchConvenienceDocuments;
            Dictionary<string, List<string>> expectedOutput = s_englishExpectedBatchOutput;
            TextAnalyticsActions actions = new()
            {
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                },
                DisplayName = "RecognizeCustomEntitiesWithAutoDetectedLanguageTest",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, actions, "auto");
            await operation.WaitForCompletionAsync();

            // Take the first page.
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<RecognizeCustomEntitiesActionResult> actionResults = resultCollection.RecognizeCustomEntitiesResults;
            Assert.IsNotNull(actionResults);

            RecognizeCustomEntitiesResultCollection results = actionResults.FirstOrDefault().DocumentsResults;
            ValidateBatchDocumentsResult(results, expectedOutput, isLanguageAutoDetected: true);
        }

        private RecognizeCustomEntitiesResultCollection ExtractDocumentsResultsFromResponse(AnalyzeActionsOperation analyzeActionOperation)
        {
            var resultCollection = analyzeActionOperation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            var recognizeCustomEntitiesActionResult = resultCollection.RecognizeCustomEntitiesResults;
            var actionResult = recognizeCustomEntitiesActionResult.First();
            return actionResult.DocumentsResults;
        }

        private void ValidateInDocumentResult(CategorizedEntityCollection entities, List<string> minimumExpectedOutput)
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

                Assert.IsNotNull(entity.Resolutions);
            }
        }

        private void ValidateBatchDocumentsResult(
            RecognizeCustomEntitiesResultCollection results,
            Dictionary<string, List<string>> minimumExpectedOutput,
            bool includeStatistics = default,
            bool isLanguageAutoDetected = default)
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

                ValidateInDocumentResult(result.Entities, minimumExpectedOutput[result.Id]);
            }
        }
    }
}
