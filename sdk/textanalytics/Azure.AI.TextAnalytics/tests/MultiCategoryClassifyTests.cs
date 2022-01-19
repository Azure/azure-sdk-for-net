// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_2_Preview_2)]
    public class MultiCategoryClassifyTests : TextAnalyticsClientLiveTestBase
    {
        public MultiCategoryClassifyTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string MultiCategoryClassifyDocument1 =
            "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist";

        private const string MultiCategoryClassifyDocument2 =
            "David Schmidt, senior vice president--Food Safety, International Food Information Council (IFIC), Washington, D.C., discussed the physical activity component.";

        private static readonly List<string> s_multiCategoryClassifyBatchConvenienceDocuments = new List<string>
        {
            MultiCategoryClassifyDocument1,
            MultiCategoryClassifyDocument2
        };

        private static List<TextDocumentInput> s_multiCategoryClassifyBatchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", MultiCategoryClassifyDocument1)
            {
                 Language = "en",
            },
            new TextDocumentInput("2", MultiCategoryClassifyDocument2)
            {
                 Language = "en",
            }
        };

        [RecordedTest]
        public async Task MultiCategoryClassifyWithDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiCategoryClassifyActions = new List<MultiCategoryClassifyAction>() { new MultiCategoryClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName) { DisableServiceLogs = true } }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiCategoryClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiCategoryClassifyActionResult> multiCategoryClassifyActionsResults = resultCollection.MultiCategoryClassifyResults;

            Assert.IsNotNull(multiCategoryClassifyActionsResults);
            Assert.AreEqual(2, multiCategoryClassifyActionsResults.FirstOrDefault().DocumentsResults.Count);
        }

        [RecordedTest]
        public async Task MultiCategoryClassifyBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "",
            };
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiCategoryClassifyActions = new List<MultiCategoryClassifyAction>()
                {
                    new MultiCategoryClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions, "en");
            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            List<MultiCategoryClassifyActionResult> multiCategoryClassifyActions = resultCollection.MultiCategoryClassifyResults.ToList();

            Assert.AreEqual(1, multiCategoryClassifyActions.Count);

            MultiCategoryClassifyResultCollection documentsResults = multiCategoryClassifyActions[0].DocumentsResults;
            Assert.IsFalse(documentsResults[0].HasError);
            Assert.IsTrue(documentsResults[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, documentsResults[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        public async Task MultiCategoryClassifyBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiCategoryClassifyActions = new List<MultiCategoryClassifyAction>()
                {
                    new MultiCategoryClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiCategoryClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiCategoryClassifyActionResult> multiCategoryClassifyActionsResults = resultCollection.MultiCategoryClassifyResults;
            MultiCategoryClassifyResultCollection multiCategoryClassifyResults = multiCategoryClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(multiCategoryClassifyResults);
        }

        [RecordedTest]
        public async Task MultiCategoryClassifyBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiCategoryClassifyActions = new List<MultiCategoryClassifyAction>()
                {
                    new MultiCategoryClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiCategoryClassifyBatchConvenienceDocuments, batchActions, "en", options);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiCategoryClassifyActionResult> multiCategoryClassifyActionsResults = resultCollection.MultiCategoryClassifyResults;
            MultiCategoryClassifyResultCollection multiCategoryClassifyResults = multiCategoryClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(multiCategoryClassifyResults, includeStatistics: true);
        }

        [RecordedTest]
        public async Task MultiCategoryClassifyBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiCategoryClassifyActions = new List<MultiCategoryClassifyAction>()
                {
                    new MultiCategoryClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiCategoryClassifyBatchDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiCategoryClassifyActionResult> multiCategoryClassifyActionsResults = resultCollection.MultiCategoryClassifyResults;
            MultiCategoryClassifyResultCollection multiCategoryClassifyResults = multiCategoryClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(multiCategoryClassifyResults);
        }

        [RecordedTest]
        public async Task MultiCategoryClassifyBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiCategoryClassifyActions = new List<MultiCategoryClassifyAction>()
                {
                    new MultiCategoryClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiCategoryClassifyBatchDocuments, batchActions, options);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiCategoryClassifyActionResult> multiCategoryClassifyActionsResults = resultCollection.MultiCategoryClassifyResults;
            MultiCategoryClassifyResultCollection multiCategoryClassifyResults = multiCategoryClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(multiCategoryClassifyResults, includeStatistics: true);
        }

        [RecordedTest]
        [Ignore("Issue https://github.com/Azure/azure-sdk-for-net/issues/25152")]
        public async Task MultiCategoryClassifyWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiCategoryClassifyActions = new List<MultiCategoryClassifyAction>()
                {
                    new MultiCategoryClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                    {
                        DisableServiceLogs = true,
                        ActionName = "MultiCategoryClassifyWithDisabledServiceLogs"
                    },
                    new MultiCategoryClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                    {
                        ActionName = "MultiCategoryClassify"
                    }
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_multiCategoryClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<MultiCategoryClassifyActionResult> multiCategoryClassifyActionsResults = resultCollection.MultiCategoryClassifyResults;

            Assert.IsNotNull(multiCategoryClassifyActionsResults);

            IList<string> expected = new List<string> { "MultiCategoryClassify", "MultiCategoryClassifyWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, multiCategoryClassifyActionsResults.Select(result => result.ActionName));
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

        private void ValidateSummaryBatchResult(MultiCategoryClassifyResultCollection results, bool includeStatistics = false)
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

            foreach (MultiCategoryClassifyResult result in results)
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

                ValidateSummaryDocumentResult(result.Classifications);
            }
        }
    }
}
