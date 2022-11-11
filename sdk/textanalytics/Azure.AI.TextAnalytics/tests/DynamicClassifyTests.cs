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
    [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
    public class DynamicClassifyTests : TextAnalyticsClientLiveTestBase
    {
        public DynamicClassifyTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string ClassifyDocument0 =
            "The WHO is issuing a warning about Monkey Pox.";

        private const string ClassifyDocument1 =
            "Mo Salah plays in Liverpool FC in England.";

        private static readonly List<string> s_categories = new()
        {
            "Health",
            "Politics",
            "Music",
            "Sports"
        };

        private static readonly List<string> s_batchConvenienceDocuments = new()
        {
            ClassifyDocument0,
            ClassifyDocument1
        };

        private static readonly List<TextDocumentInput> s_batchDocuments = new()
        {
            new TextDocumentInput("0", ClassifyDocument0),
            new TextDocumentInput("1", ClassifyDocument1)
        };

        #region Simple Tests

        [RecordedTest]
        public async Task DynamicClassifyTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = ClassifyDocument1;
            DynamicClassifyOptions options = new(s_categories);

            ClassificationCategoryCollection classificationCategories = await client.DynamicClassifyAsync(document, options);

            ValidateDocumentResult(classificationCategories, ClassificationType.Multi);
        }

        [RecordedTest]
        public async Task DynamicClassifyWithDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();
            string document = ClassifyDocument1;
            DynamicClassifyOptions options = new(s_categories) { DisableServiceLogs = true };

            ClassificationCategoryCollection classificationCategories = await client.DynamicClassifyAsync(document, options);

            ValidateDocumentResult(classificationCategories, ClassificationType.Multi);
        }

        #endregion

        #region Batch Convenience Tests

        [RecordedTest]
        public async Task DynamicClassifyBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            List<string> documents = s_batchConvenienceDocuments;
            DynamicClassifyOptions options = new(s_categories);

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);

            ValidateBatchDocumentsResult(results, ClassificationType.Multi);
        }

        [RecordedTest]
        public async Task DynamicClassifyBatchConvenienceWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            List<string> documents = new()
            {
                ClassifyDocument1,
                string.Empty
            };
            DynamicClassifyOptions options = new(s_categories);

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);

            Assert.IsTrue(!results[0].HasError);
            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].ClassificationCategories.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        public async Task DynamicClassifyBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            List<string> documents = s_batchConvenienceDocuments;
            DynamicClassifyOptions options = new(s_categories) { IncludeStatistics = true };

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);

            ValidateBatchDocumentsResult(results, ClassificationType.Multi, includeStatistics: true);
            Assert.AreEqual(documents.Count, results.Statistics.DocumentCount);
        }

        [RecordedTest]
        public async Task DynamicClassifyBatchConvenienceWithDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();
            List<string> documents = s_batchConvenienceDocuments;
            DynamicClassifyOptions options = new(s_categories) { DisableServiceLogs = true };

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);

            ValidateBatchDocumentsResult(results, ClassificationType.Multi);
        }

        #endregion

        #region Batch Tests

        [RecordedTest]
        public async Task DynamicClassifyBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = s_batchDocuments;
            DynamicClassifyOptions options = new(s_categories);

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);

            ValidateBatchDocumentsResult(results, ClassificationType.Multi);
        }

        [RecordedTest]
        public async Task DynamicClassifyBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = new()
            {
                new TextDocumentInput("0", ClassifyDocument1),
                new TextDocumentInput("1", string.Empty)
            };
            DynamicClassifyOptions options = new(s_categories);

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);

            Assert.IsTrue(!results[0].HasError);
            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].ClassificationCategories.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        public async Task DynamicClassifyBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = s_batchDocuments;
            DynamicClassifyOptions options = new(s_categories) { IncludeStatistics = true };

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);

            ValidateBatchDocumentsResult(results, ClassificationType.Multi, includeStatistics: true);
            Assert.AreEqual(documents.Count, results.Statistics.DocumentCount);
        }

        [RecordedTest]
        public async Task DynamicClassifyBatchWithDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = s_batchDocuments;
            DynamicClassifyOptions options = new(s_categories) { DisableServiceLogs = true };

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);

            ValidateBatchDocumentsResult(results, ClassificationType.Multi);
        }

        [RecordedTest]
        public void DynamicClassifyBatchWithNullIdTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = new() { new TextDocumentInput(null, "Hello world") };
            DynamicClassifyOptions options = new(s_categories);

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.DynamicClassifyBatchAsync(documents, options));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, ex.ErrorCode);
        }

        [RecordedTest]
        public async Task DynamicClassifyBatchWithNullTextTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = new() { new TextDocumentInput("1", null) };
            DynamicClassifyOptions options = new(s_categories);

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);
            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[0].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[0].ClassificationCategories.Count());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [RecordedTest]
        public async Task DynamicClassifyBatchWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);
            List<TextDocumentInput> documents = s_batchDocuments;
            DynamicClassifyOptions options = new(s_categories);

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);

            ValidateBatchDocumentsResult(results, ClassificationType.Multi);
        }

        [RecordedTest]
        public async Task DynamicClassifyBatchWithSingleClassificationTypeTest()
        {
            TextAnalyticsClient client = GetClient();
            List<TextDocumentInput> documents = s_batchDocuments;
            DynamicClassifyOptions options = new(s_categories) { ClassificationType = ClassificationType.Single };

            DynamicClassifyDocumentResultCollection results = await client.DynamicClassifyBatchAsync(documents, options);

            ValidateBatchDocumentsResult(results, ClassificationType.Single);
        }

        #endregion

        private static void ValidateDocumentResult(
            ClassificationCategoryCollection classificationCategories,
            ClassificationType classificationType)
        {
            Assert.IsNotNull(classificationCategories.Warnings);

            if (classificationType== ClassificationType.Single)
            {
                Assert.AreEqual(1, classificationCategories.Count);
            }
            else if (classificationType == ClassificationType.Multi)
            {
                Assert.AreEqual(s_categories.Count, classificationCategories.Count);
            }

            foreach (ClassificationCategory classification in classificationCategories)
            {
                Assert.GreaterOrEqual(classification.ConfidenceScore, 0);
                Assert.LessOrEqual(classification.ConfidenceScore, 1);
                Assert.NotNull(classification.Category);
            }
        }

        private static void ValidateBatchDocumentsResult(
            DynamicClassifyDocumentResultCollection results,
            ClassificationType classificationType,
            bool includeStatistics = default)
        {
            Assert.That(results.ModelVersion, Is.Not.Null.And.Not.Empty);

            if (includeStatistics)
            {
                Assert.IsNotNull(results.Statistics);
                Assert.Greater(results.Statistics.DocumentCount, 0);
                Assert.GreaterOrEqual(results.Statistics.TransactionCount, 0);
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

                // Even though statistics are not asked for, TA 5.0.0 shipped with Statistics default always present.
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

                ValidateDocumentResult(result.ClassificationCategories, classificationType);
            }
        }
    }
}
