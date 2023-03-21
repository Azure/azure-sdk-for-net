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
    public class MultiLabelClassifyTests : TextAnalyticsClientLiveTestBase
    {
        public MultiLabelClassifyTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string MultiLabelClassifyDocument1 =
            "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist";

        private const string MultiLabelClassifyDocument2 =
            "David Schmidt, senior vice president--Food Safety, International Food Information Council (IFIC), Washington, D.C., discussed the physical activity component.";

        private static readonly List<string> s_multiLabelClassifyBatchConvenienceDocuments = new List<string>
        {
            MultiLabelClassifyDocument1,
            MultiLabelClassifyDocument2,
        };

        private static List<TextDocumentInput> s_multiLabelClassifyBatchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", MultiLabelClassifyDocument1)
            {
                 Language = "en",
            },
            new TextDocumentInput("2", MultiLabelClassifyDocument2)
            {
                 Language = "en",
            }
        };

        [RecordedTest]
        public async Task MultiLabelClassifyWithDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>() { new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName) { DisableServiceLogs = true } }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiLabelClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyActionsResults = resultCollection.MultiLabelClassifyResults;

            Assert.IsNotNull(multiLabelClassifyActionsResults);
            Assert.AreEqual(2, multiLabelClassifyActionsResults.FirstOrDefault().DocumentsResults.Count);
        }

        [RecordedTest]
        public async Task MultiLabelClassifyBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "",
            };
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>()
                {
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions, "en");
            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            List<MultiLabelClassifyActionResult> multiLabelClassifyActions = resultCollection.MultiLabelClassifyResults.ToList();

            Assert.AreEqual(1, multiLabelClassifyActions.Count);

            ClassifyDocumentResultCollection documentsResults = multiLabelClassifyActions[0].DocumentsResults;
            Assert.IsFalse(documentsResults[0].HasError);
            Assert.IsTrue(documentsResults[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, documentsResults[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        public async Task MultiLabelClassifyBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>()
                {
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiLabelClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyActionsResults = resultCollection.MultiLabelClassifyResults;
            ClassifyDocumentResultCollection multiLabelClassifyResults = multiLabelClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(multiLabelClassifyResults);
        }

        [RecordedTest]
        public async Task MultiLabelClassifyBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>()
                {
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiLabelClassifyBatchConvenienceDocuments, batchActions, "en", options);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyActionsResults = resultCollection.MultiLabelClassifyResults;
            ClassifyDocumentResultCollection multiLabelClassifyResults = multiLabelClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(multiLabelClassifyResults, includeStatistics: true);
        }

        [RecordedTest]
        public async Task MultiLabelClassifyBatchTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>()
                {
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiLabelClassifyBatchDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyActionsResults = resultCollection.MultiLabelClassifyResults;
            ClassifyDocumentResultCollection multiLabelClassifyResults = multiLabelClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(multiLabelClassifyResults);
        }

        [RecordedTest]
        public async Task MultiLabelClassifyBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>()
                {
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiLabelClassifyBatchDocuments, batchActions, options);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyActionsResults = resultCollection.MultiLabelClassifyResults;
            ClassifyDocumentResultCollection multiLabelClassifyResults = multiLabelClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(multiLabelClassifyResults, includeStatistics: true);
        }

        [RecordedTest]
        [Ignore("Issue https://github.com/Azure/azure-sdk-for-net/issues/25152")]
        public async Task MultiLabelClassifyWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>()
                {
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                    {
                        DisableServiceLogs = true,
                        ActionName = "MultiLabelClassifyWithDisabledServiceLogs"
                    },
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                    {
                        ActionName = "MultiLabelClassify"
                    }
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiLabelClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyActionsResults = resultCollection.MultiLabelClassifyResults;

            Assert.IsNotNull(multiLabelClassifyActionsResults);

            IList<string> expected = new List<string> { "MultiLabelClassify", "MultiLabelClassifyWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, multiLabelClassifyActionsResults.Select(result => result.ActionName));
        }

        [RecordedTest]
        public async Task StartMultiLabelClassify()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            ClassifyDocumentOperation operation = await client.StartMultiLabelClassifyAsync(s_multiLabelClassifyBatchDocuments, TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page.
            ClassifyDocumentResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection);
        }

        [RecordedTest]
        public async Task StartMultiLabelClassifyWithName()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            ClassifyDocumentOperation operation = await client.StartMultiLabelClassifyAsync(s_multiLabelClassifyBatchDocuments, TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName, new MultiLabelClassifyOptions
            {
                DisplayName = "StartMultiLabelClassifyWithName",
            });

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual("StartMultiLabelClassifyWithName", operation.DisplayName);

            // Take the first page.
            ClassifyDocumentResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task MultiLabelClassifyBatchConvenienceWithAutoDetectedLanguageTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.StartMultiLabelClassifyAsync(
                s_multiLabelClassifyBatchConvenienceDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName,
                "auto");
            await operation.WaitForCompletionAsync();

            // Take the first page.
            ClassifyDocumentResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection, isLanguageAutoDetected: true);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeOperationMultiLabelClassifyWithAutoDetectedLanguageTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            List<string> documents = s_multiLabelClassifyBatchConvenienceDocuments;
            TextAnalyticsActions actions = new()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>()
                {
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                },
                DisplayName = "MultiLabelClassifyWithAutoDetectedLanguage",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, actions, "auto");
            await operation.WaitForCompletionAsync();

            // Take the first page.
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<MultiLabelClassifyActionResult> actionResults = resultCollection.MultiLabelClassifyResults;
            Assert.IsNotNull(actionResults);

            ClassifyDocumentResultCollection results = actionResults.FirstOrDefault().DocumentsResults;
            ValidateSummaryBatchResult(results, isLanguageAutoDetected: true);
        }

        private void ValidateSummaryDocumentResult(ClassificationCategoryCollection classificationCollection)
        {
            Assert.IsNotNull(classificationCollection.Warnings);

            foreach (var classification in classificationCollection)
            {
                Assert.GreaterOrEqual(classification.ConfidenceScore, 0);
                Assert.LessOrEqual(classification.ConfidenceScore, 1);
                Assert.NotNull(classification.Category);
            }
        }

        private void ValidateSummaryBatchResult(
            ClassifyDocumentResultCollection results,
            bool includeStatistics = default,
            bool isLanguageAutoDetected = default)
        {
            Assert.AreEqual(results.ProjectName, TestEnvironment.MultiClassificationProjectName);
            Assert.AreEqual(results.DeploymentName, TestEnvironment.MultiClassificationDeploymentName);

            if (includeStatistics)
            {
                Assert.IsNotNull(results.Statistics);
                Assert.Greater(results.Statistics.DocumentCount, 0);
                Assert.Greater(results.Statistics.TransactionCount, 0);
                Assert.GreaterOrEqual(results.Statistics.InvalidDocumentCount, 0);
                Assert.GreaterOrEqual(results.Statistics.ValidDocumentCount, 0);
            }
            else
            {
                Assert.IsNull(results.Statistics);
            }

            foreach (ClassifyDocumentResult result in results)
            {
                Assert.That(result.Id, Is.Not.Null.And.Not.Empty);
                Assert.False(result.HasError);
                Assert.IsNotNull(result.Warnings);

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

                ValidateSummaryDocumentResult(result.ClassificationCategories);
            }
        }
    }
}
