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

        private static readonly List<string> s_batchConvenienceDocuments = new()
        {
            MultiLabelClassifyDocument1,
            MultiLabelClassifyDocument2,
        };

        private static List<TextDocumentInput> s_batchDocuments = new()
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

        [SetUp]
        public void TestSetup()
        {
            // These tests require a pre-trained, static resource,
            // which is currently only available in the public cloud.
            TestEnvironment.IgnoreIfNotPublicCloud();
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task MultiLabelClassifyBatchTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task MultiLabelClassifyBatchWaitUntilStartedTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(
                WaitUntil.Started,
                s_batchDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName);
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            ValidateOperationProperties(operation);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task MultiLabelClassifyBatchWithNameTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            MultiLabelClassifyOptions options = new MultiLabelClassifyOptions()
            {
                DisplayName = "MultiLabelClassifyWithName",
            };

            ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName,
                options);
            ValidateOperationProperties(operation);

            Assert.That(operation.DisplayName, Is.EqualTo("MultiLabelClassifyWithName"));

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            // Take the first page.
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task MultiLabelClassifyBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            MultiLabelClassifyOptions options = new MultiLabelClassifyOptions()
            {
                IncludeStatistics = true
            };

            ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName,
                options);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, includeStatistics: true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task MultiLabelClassifyBatchWithDisableServiceLogsTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            MultiLabelClassifyOptions options = new MultiLabelClassifyOptions()
            {
                DisableServiceLogs = true
            };

            ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName,
                options);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task MultiLabelClassifyBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "",
            };

            ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(
                WaitUntil.Completed,
                documents,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName,
                "en");
            ValidateOperationProperties(operation);

            // Take the first page.
            ClassifyDocumentResultCollection resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            Assert.That(resultCollection[0].HasError, Is.False);
            Assert.That(resultCollection[1].HasError, Is.True);
            Assert.That(resultCollection[1].Error.ErrorCode.ToString(), Is.EqualTo(TextAnalyticsErrorCode.InvalidDocument));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task MultiLabelClassifyBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchConvenienceDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task MultiLabelClassifyBatchConvenienceWaitUntilStartedTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(
                WaitUntil.Started,
                s_batchConvenienceDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName);
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            ValidateOperationProperties(operation);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task MultiLabelClassifyBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            MultiLabelClassifyOptions options = new()
            {
                IncludeStatistics = true
            };

            ClassifyDocumentOperation operation = await client.MultiLabelClassifyAsync(
                WaitUntil.Completed,
                s_batchConvenienceDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName,
                "en",
                options);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection, includeStatistics: true);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task AnalyzeOperationMultiLabelClassify()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>()
                {
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, s_batchDocuments, batchActions);
            Assert.That(operation.HasCompleted, Is.True);

            // Take the first page
            AnalyzeActionsResult actionsResult = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyActionResults = actionsResult.MultiLabelClassifyResults;
            Assert.That(multiLabelClassifyActionResults, Is.Not.Null);

            ClassifyDocumentResultCollection resultCollection = multiLabelClassifyActionResults.FirstOrDefault().DocumentsResults;
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [Ignore("Issue https://github.com/Azure/azure-sdk-for-net/issues/25152")]
        public async Task AnalyzeOperationMultiLabelClassifyWithMultipleActions()
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, s_batchConvenienceDocuments, batchActions);
            Assert.That(operation.HasCompleted, Is.True);

            // Take the first page
            AnalyzeActionsResult actionsResult = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyActionResults = actionsResult.MultiLabelClassifyResults;
            Assert.That(multiLabelClassifyActionResults, Is.Not.Null);

            IList<string> expected = new List<string> { "MultiLabelClassify", "MultiLabelClassifyWithDisabledServiceLogs" };
            Assert.That(multiLabelClassifyActionResults.Select(result => result.ActionName), Is.EquivalentTo(expected));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task StartMultiLabelClassifyBatchTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.StartMultiLabelClassifyAsync(
                s_batchDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName);
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        public async Task StartMultiLabelClassifyBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            ClassifyDocumentOperation operation = await client.StartMultiLabelClassifyAsync(
                s_batchConvenienceDocuments,
                TestEnvironment.MultiClassificationProjectName,
                TestEnvironment.MultiClassificationDeploymentName);
            Assert.That(operation.HasCompleted, Is.False);
            Assert.That(operation.HasValue, Is.False);
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.HasValue, Is.True);
            ValidateOperationProperties(operation);

            List<ClassifyDocumentResultCollection> resultInPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(resultInPages.Count, Is.EqualTo(1));

            // Take the first page
            ClassifyDocumentResultCollection resultCollection = resultInPages.FirstOrDefault();
            ValidateBatchResult(resultCollection);
        }

        private void ValidateOperationProperties(ClassifyDocumentOperation operation)
        {
            Assert.That(operation.HasCompleted, Is.True);
            Assert.That(operation.CreatedOn, Is.Not.EqualTo(new DateTimeOffset()));
            // TODO: Re-enable this check (https://github.com/Azure/azure-sdk-for-net/issues/31855).
            // Assert.AreNotEqual(new DateTimeOffset(), operation.LastModified);

            if (operation.ExpiresOn.HasValue)
            {
                Assert.That(operation.ExpiresOn.Value, Is.Not.EqualTo(new DateTimeOffset()));
            }
        }

        private void ValidateDocumentResult(ClassificationCategoryCollection classificationCollection)
        {
            Assert.That(classificationCollection.Warnings, Is.Not.Null);

            foreach (var classification in classificationCollection)
            {
                Assert.That(classification.ConfidenceScore, Is.GreaterThanOrEqualTo(0));
                Assert.That(classification.ConfidenceScore, Is.LessThanOrEqualTo(1));
                Assert.That(classification.Category, Is.Not.Null);
            }
        }

        private void ValidateBatchResult(ClassifyDocumentResultCollection results, bool includeStatistics = default)
        {
            Assert.That(TestEnvironment.MultiClassificationProjectName, Is.EqualTo(results.ProjectName));
            Assert.That(TestEnvironment.MultiClassificationDeploymentName, Is.EqualTo(results.DeploymentName));

            if (includeStatistics)
            {
                Assert.That(results.Statistics, Is.Not.Null);
                Assert.That(results.Statistics.DocumentCount, Is.GreaterThan(0));
                Assert.That(results.Statistics.TransactionCount, Is.GreaterThan(0));
                Assert.That(results.Statistics.InvalidDocumentCount, Is.GreaterThanOrEqualTo(0));
                Assert.That(results.Statistics.ValidDocumentCount, Is.GreaterThanOrEqualTo(0));
            }
            else
            {
                Assert.That(results.Statistics, Is.Null);
            }

            foreach (ClassifyDocumentResult result in results)
            {
                Assert.That(result.Id, Is.Not.Null.And.Not.Empty);
                Assert.That(result.HasError, Is.False);
                Assert.That(result.Warnings, Is.Not.Null);

                if (includeStatistics)
                {
                    Assert.That(result.Statistics.CharacterCount, Is.GreaterThanOrEqualTo(0));
                    Assert.That(result.Statistics.TransactionCount, Is.GreaterThan(0));
                }
                else
                {
                    Assert.That(result.Statistics.CharacterCount, Is.EqualTo(0));
                    Assert.That(result.Statistics.TransactionCount, Is.EqualTo(0));
                }

                ValidateDocumentResult(result.ClassificationCategories);
            }
        }
    }
}
