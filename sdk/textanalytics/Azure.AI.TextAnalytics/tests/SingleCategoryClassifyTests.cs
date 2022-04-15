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
    public class SingleCategoryClassifyTests : TextAnalyticsClientLiveTestBase
    {
        public SingleCategoryClassifyTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string SingleCategoryClassifyDocument1 =
            "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist";

        private const string SingleCategoryClassifyDocument2 =
            "David Schmidt, senior vice president--Food Safety, International Food Information Council (IFIC), Washington, D.C., discussed the physical activity component.";

        private static readonly List<string> s_singleCategoryClassifyBatchConvenienceDocuments = new List<string>
        {
            SingleCategoryClassifyDocument1,
            SingleCategoryClassifyDocument2
        };

        private static List<TextDocumentInput> s_singleCategoryClassifyBatchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", SingleCategoryClassifyDocument1)
            {
                 Language = "en",
            },
            new TextDocumentInput("2", SingleCategoryClassifyDocument2)
            {
                 Language = "en",
            }
        };

        [RecordedTest]
        public async Task SingleCategoryClassifyWithDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleCategoryClassifyActions = new List<SingleCategoryClassifyAction>() { new SingleCategoryClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName) { DisableServiceLogs = true } }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleCategoryClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<SingleCategoryClassifyActionResult> singleCategoryClassifyActionsResults = resultCollection.SingleCategoryClassifyResults;

            Assert.IsNotNull(singleCategoryClassifyActionsResults);
            Assert.AreEqual(2, singleCategoryClassifyActionsResults.FirstOrDefault().DocumentsResults.Count);
        }

        [RecordedTest]
        public async Task SingleCategoryClassifyBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "",
            };
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleCategoryClassifyActions = new List<SingleCategoryClassifyAction>()
                {
                    new SingleCategoryClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions, "en");
            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            List<SingleCategoryClassifyActionResult> singleCategoryClassifyActions = resultCollection.SingleCategoryClassifyResults.ToList();

            Assert.AreEqual(1, singleCategoryClassifyActions.Count);

            SingleCategoryClassifyResultCollection documentsResults = singleCategoryClassifyActions[0].DocumentsResults;
            Assert.IsFalse(documentsResults[0].HasError);
            Assert.IsTrue(documentsResults[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, documentsResults[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        public async Task SingleCategoryClassifyBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleCategoryClassifyActions = new List<SingleCategoryClassifyAction>()
                {
                    new SingleCategoryClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleCategoryClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<SingleCategoryClassifyActionResult> singleCategoryClassifyActionsResults = resultCollection.SingleCategoryClassifyResults;
            SingleCategoryClassifyResultCollection singleCategoryClassifyResults = singleCategoryClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(singleCategoryClassifyResults);
        }

        [RecordedTest]
        public async Task SingleCategoryClassifyBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleCategoryClassifyActions = new List<SingleCategoryClassifyAction>()
                {
                    new SingleCategoryClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleCategoryClassifyBatchConvenienceDocuments, batchActions, "en", options);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<SingleCategoryClassifyActionResult> singleCategoryClassifyActionsResults = resultCollection.SingleCategoryClassifyResults;
            SingleCategoryClassifyResultCollection singleCategoryClassifyResults = singleCategoryClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(singleCategoryClassifyResults, includeStatistics : true);
        }

        [RecordedTest]
        public async Task SingleCategoryClassifyBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleCategoryClassifyActions = new List<SingleCategoryClassifyAction>()
                {
                    new SingleCategoryClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleCategoryClassifyBatchDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<SingleCategoryClassifyActionResult> singleCategoryClassifyActionsResults = resultCollection.SingleCategoryClassifyResults;
            SingleCategoryClassifyResultCollection singleCategoryClassifyResults = singleCategoryClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(singleCategoryClassifyResults);
        }

        [RecordedTest]
        public async Task SingleCategoryClassifyBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleCategoryClassifyActions = new List<SingleCategoryClassifyAction>()
                {
                    new SingleCategoryClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleCategoryClassifyBatchDocuments, batchActions, options);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<SingleCategoryClassifyActionResult> singleCategoryClassifyActionsResults = resultCollection.SingleCategoryClassifyResults;
            SingleCategoryClassifyResultCollection singleCategoryClassifyResults = singleCategoryClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(singleCategoryClassifyResults, includeStatistics: true);
        }

        [RecordedTest]
        [Ignore("Issue https://github.com/Azure/azure-sdk-for-net/issues/25152")]
        public async Task SingleCategoryClassifyWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleCategoryClassifyActions = new List<SingleCategoryClassifyAction>()
                {
                    new SingleCategoryClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                    {
                        DisableServiceLogs = true,
                        ActionName = "SingleCategoryClassifyWithDisabledServiceLogs"
                    },
                    new SingleCategoryClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                    {
                        ActionName = "SingleCategoryClassify"
                    }
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleCategoryClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<SingleCategoryClassifyActionResult> singleCategoryClassifyActionsResults = resultCollection.SingleCategoryClassifyResults;

            Assert.IsNotNull(singleCategoryClassifyActionsResults);

            IList<string> expected = new List<string> { "SingleCategoryClassify", "SingleCategoryClassifyWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, singleCategoryClassifyActionsResults.Select(result => result.ActionName));
        }
        private void ValidateSummaryDocumentResult(ClassificationCategory classification)
        {
            Assert.GreaterOrEqual(classification.ConfidenceScore, 0);
            Assert.LessOrEqual(classification.ConfidenceScore, 1);
            Assert.NotNull(classification.Category);
        }

        private void ValidateSummaryBatchResult(SingleCategoryClassifyResultCollection results, bool includeStatistics = false)
        {
            Assert.AreEqual(results.ProjectName, TestEnvironment.SingleClassificationProjectName);
            Assert.AreEqual(results.DeploymentName, TestEnvironment.SingleClassificationDeploymentName);

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

            foreach (SingleCategoryClassifyResult result in results)
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

                ValidateSummaryDocumentResult(result.Classification);
            }
        }
    }
}
