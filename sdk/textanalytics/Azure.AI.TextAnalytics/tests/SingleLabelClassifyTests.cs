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

        private static readonly List<string> s_batchConvenienceDocuments = new()
        {
            SingleLabelClassifyDocument1,
            SingleLabelClassifyDocument2,
        };

        private static List<TextDocumentInput> s_batchDocuments = new()
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

        [SetUp]
        public void TestSetup()
        {
            // These tests require a pre-trained, static resource,
            // which is currently only available in the public cloud.
            TestEnvironment.IgnoreIfNotPublicCloud();
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task SingleLabelClassifyBatchTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchDocuments,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task SingleLabelClassifyBatchWaitUntilStartedTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(
                WaitUntil.Started,
                s_batchDocuments,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName);
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
        public async Task SingleLabelClassifyBatchWithNameTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            SingleLabelClassifyOptions options = new SingleLabelClassifyOptions
            {
                DisplayName = "SingleLabelClassifyWithName",
            };

            ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchDocuments,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName,
                options);
            ValidateOperationProperties(operation);

            Assert.AreEqual("SingleLabelClassifyWithName", operation.DisplayName);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page.
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task SingleLabelClassifyBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            SingleLabelClassifyOptions options = new SingleLabelClassifyOptions()
            {
                IncludeStatistics = true
            };

            ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchDocuments,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName,
                options);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, includeStatistics: true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task SingleLabelClassifyBatchWithDisableServiceLogsTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            SingleLabelClassifyOptions options = new SingleLabelClassifyOptions()
            {
                DisableServiceLogs = true
            };

            ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchDocuments,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName,
                options);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task SingleLabelClassifyBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "",
            };

            ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(
                WaitUntil.Completed,
                documents,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName,
                "en");
            ValidateOperationProperties(operation);

            // Take the first page.
            ClassifyDocumentResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            Assert.IsFalse(resultCollection[0].HasError);
            Assert.IsTrue(resultCollection[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, resultCollection[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task SingleLabelClassifyBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchConvenienceDocuments,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task SingleLabelClassifyBatchConvenienceWaitUntilStartedTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(
                WaitUntil.Started,
                s_batchConvenienceDocuments,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName);
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
        public async Task SingleLabelClassifyBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            SingleLabelClassifyOptions options = new()
            {
                IncludeStatistics = true
            };

            ClassifyDocumentOperation operation = await client.SingleLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchConvenienceDocuments,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName,
                "en",
                options);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, includeStatistics: true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeOperationSingleLabelClassify()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>()
                {
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, s_batchConvenienceDocuments, batchActions);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult actionsResult = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyActionsResults = actionsResult.SingleLabelClassifyResults;
            Assert.IsNotNull(singleLabelClassifyActionsResults);

            ClassifyDocumentResultCollection resultCollection = singleLabelClassifyActionsResults.FirstOrDefault().DocumentsResults;
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [Ignore("Issue https://github.com/Azure/azure-sdk-for-net/issues/25152")]
        public async Task AnalyzeOperationSingleLabelClassifyWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, s_batchConvenienceDocuments, batchActions);
            Assert.IsTrue(operation.HasCompleted);

            // Take the first page
            AnalyzeActionsResult actionsResult = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyActionsResults = actionsResult.SingleLabelClassifyResults;
            Assert.IsNotNull(singleLabelClassifyActionsResults);

            IList<string> expected = new List<string> { "SingleLabelClassify", "SingleLabelClassifyWithDisabledServiceLogs" };
            CollectionAssert.AreEquivalent(expected, singleLabelClassifyActionsResults.Select(result => result.ActionName));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task StartSingleLabelClassifyBatchTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.StartSingleLabelClassifyAsync(
                s_batchDocuments,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName);
            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task StartSingleLabelClassifyBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.StartSingleLabelClassifyAsync(
                s_batchConvenienceDocuments,
                TestEnvironment.SingleClassificationProjectName,
                TestEnvironment.SingleClassificationDeploymentName);
            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(1, resultInPages.Count);

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        private void ValidateOperationProperties(ClassifyDocumentOperation operation)
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

        private void ValidateDocumentResult(ClassificationCategory? classification)
        {
            Assert.IsNotNull(classification);

            Assert.GreaterOrEqual(classification.Value.ConfidenceScore, 0);
            Assert.LessOrEqual(classification.Value.ConfidenceScore, 1);
            Assert.NotNull(classification.Value.Category);
        }

        private void ValidateBatchResult(ClassifyDocumentResultCollection results, bool includeStatistics = default)
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

                ValidateDocumentResult(result.ClassificationCategories.FirstOrDefault());
            }
        }
    }
}
