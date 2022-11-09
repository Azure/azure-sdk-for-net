// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
    public class SingleLabelClassifyTests : TextAnalyticsClientLiveTestBase
    {
        public SingleLabelClassifyTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string SingleLabelClassifyDocument1 =
            "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist";

        private const string SingleLabelClassifyDocument2 =
            "David Schmidt, senior vice president--Food Safety, International Food Information Council (IFIC), Washington, D.C., discussed the physical activity component.";

        private static readonly List<string> s_singleLabelClassifyBatchConvenienceDocuments = new List<string>
        {
            SingleLabelClassifyDocument1,
            SingleLabelClassifyDocument2,
        };

        private static List<TextDocumentInput> s_singleLabelClassifyBatchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", SingleLabelClassifyDocument1)
            {
                 Language = "en",
            },
            new TextDocumentInput("2", SingleLabelClassifyDocument2)
            {
                 Language = "en",
            }
        };

        [RecordedTest]
        public async Task SingleLabelClassifyWithDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>() { new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName) { DisableServiceLogs = true } }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleLabelClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyActionsResults = resultCollection.SingleLabelClassifyResults;

            Assert.IsNotNull(singleLabelClassifyActionsResults);
            Assert.AreEqual(2, singleLabelClassifyActionsResults.FirstOrDefault().DocumentsResults.Count);
        }

        [RecordedTest]
        public async Task SingleLabelClassifyBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "",
            };
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>()
                {
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions, "en");
            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            List<SingleLabelClassifyActionResult> singleLabelClassifyActions = resultCollection.SingleLabelClassifyResults.ToList();

            Assert.AreEqual(1, singleLabelClassifyActions.Count);

            ClassifyDocumentResultCollection documentsResults = singleLabelClassifyActions[0].DocumentsResults;
            Assert.IsFalse(documentsResults[0].HasError);
            Assert.IsTrue(documentsResults[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, documentsResults[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        public async Task SingleLabelClassifyBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>()
                {
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleLabelClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyActionsResults = resultCollection.SingleLabelClassifyResults;
            ClassifyDocumentResultCollection singleLabelClassifyResults = singleLabelClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(singleLabelClassifyResults);
        }

        [RecordedTest]
        public async Task SingleLabelClassifyBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>()
                {
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleLabelClassifyBatchConvenienceDocuments, batchActions, "en", options);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyActionsResults = resultCollection.SingleLabelClassifyResults;
            ClassifyDocumentResultCollection singleLabelClassifyResults = singleLabelClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(singleLabelClassifyResults, includeStatistics : true);
        }

        [RecordedTest]
        public async Task SingleLabelClassifyBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>()
                {
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleLabelClassifyBatchDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyActionsResults = resultCollection.SingleLabelClassifyResults;
            ClassifyDocumentResultCollection singleLabelClassifyResults = singleLabelClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(singleLabelClassifyResults);
        }

        [RecordedTest]
        public async Task SingleLabelClassifyBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>()
                {
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleLabelClassifyBatchDocuments, batchActions, options);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyActionsResults = resultCollection.SingleLabelClassifyResults;
            ClassifyDocumentResultCollection singleLabelClassifyResults = singleLabelClassifyActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(singleLabelClassifyResults, includeStatistics: true);
        }

        [RecordedTest]
        [Ignore("Issue https://github.com/Azure/azure-sdk-for-net/issues/25152")]
        public async Task SingleLabelClassifyWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>()
                {
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                    {
                        DisableServiceLogs = true,
                        ActionName = "SingleLabelClassifyWithDisabledServiceLogs"
                    },
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                    {
                        ActionName = "SingleLabelClassify"
                    }
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_singleLabelClassifyBatchConvenienceDocuments, batchActions);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyActionsResults = resultCollection.SingleLabelClassifyResults;

            Assert.IsNotNull(singleLabelClassifyActionsResults);

            IList<string> expected = new List<string> { "SingleLabelClassify", "SingleLabelClassifyWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, singleLabelClassifyActionsResults.Select(result => result.ActionName));
        }

        [RecordedTest]
        public async Task StartSingleLabelClassify()
        {
            TextAnalyticsClient client = GetClient();
            ClassifyDocumentOperation operation = await client.StartSingleLabelClassifyAsync(s_singleLabelClassifyBatchDocuments, TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName);

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page.
            ClassifyDocumentResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection);
        }

        [RecordedTest]
        public async Task StartSingleLabelClassifyWithName()
        {
            TextAnalyticsClient client = GetClient();
            ClassifyDocumentOperation operation = await client.StartSingleLabelClassifyAsync(s_singleLabelClassifyBatchDocuments, TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName, new SingleLabelClassifyOptions
            {
                DisplayName = "StartSingleLabelClassifyWithName",
            });

            await PollUntilTimeout(operation);
            Assert.IsTrue(operation.HasCompleted);
            Assert.AreEqual("StartSingleLabelClassifyWithName", operation.DisplayName);

            // Take the first page.
            ClassifyDocumentResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            ValidateSummaryBatchResult(resultCollection);
        }

        private void ValidateSummaryDocumentResult(ClassificationCategory? classification)
        {
            Assert.IsNotNull(classification);

            Assert.GreaterOrEqual(classification.Value.ConfidenceScore, 0);
            Assert.LessOrEqual(classification.Value.ConfidenceScore, 1);
            Assert.NotNull(classification.Value.Category);
        }

        private void ValidateSummaryBatchResult(ClassifyDocumentResultCollection results, bool includeStatistics = false)
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

                ValidateSummaryDocumentResult(result.ClassificationCategories.FirstOrDefault());
            }
        }
    }
}
