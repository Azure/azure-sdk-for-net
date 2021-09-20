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
    public class ClassifyCustomCategoryTests : TextAnalyticsClientLiveTestBase
    {
        public ClassifyCustomCategoryTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string ClassifyCustomCategoryDocument1 =
            "TempString";

        private const string ClassifyCustomCategoryDocument2 =
            "TempString";

        private static readonly List<string> s_classifyCustomCategoryBatchConvenienceDocuments = new List<string>
        {
            ClassifyCustomCategoryDocument1,
            ClassifyCustomCategoryDocument2
        };

        private static List<TextDocumentInput> s_classifyCustomCategoryBatchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", ClassifyCustomCategoryDocument1)
            {
                 Language = "en",
            },
            new TextDocumentInput("2", ClassifyCustomCategoryDocument2)
            {
                 Language = "en",
            }
        };

        [RecordedTest]
        public async Task ClassifyCustomCategoryWithDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoryActions = new List<ClassifyCustomCategoryAction>() { new ClassifyCustomCategoryAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName) { DisableServiceLogs = true } }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_classifyCustomCategoryBatchConvenienceDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ClassifyCustomCategoryActionResult> classifyCustomCategoryActionsResults = resultCollection.ClassifyCustomCategoryResults;

            Assert.IsNotNull(classifyCustomCategoryActionsResults);
            //TODO: depends on test example
            //Assert.AreEqual(2, extractSummaryActionsResults.FirstOrDefault().DocumentsResults.Count);
        }

        [RecordedTest]
        public async Task ClassifyCustomCategoryBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "",
            };
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoryActions = new List<ClassifyCustomCategoryAction>()
                {
                    new ClassifyCustomCategoryAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions, "en");
            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            List<ClassifyCustomCategoryActionResult> classifyCustomCategoryActions = resultCollection.ClassifyCustomCategoryResults.ToList();

            Assert.AreEqual(1, classifyCustomCategoryActions.Count);

            ClassifyCustomCategoryResultCollection documentsResults = classifyCustomCategoryActions[0].DocumentsResults;
            Assert.IsFalse(documentsResults[0].HasError);
            Assert.IsTrue(documentsResults[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, documentsResults[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        public async Task ClassifyCustomCategoryBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoryActions = new List<ClassifyCustomCategoryAction>()
                {
                    new ClassifyCustomCategoryAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_classifyCustomCategoryBatchConvenienceDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ClassifyCustomCategoryActionResult> classifyCustomCategoryActionsResults = resultCollection.ClassifyCustomCategoryResults;
            ClassifyCustomCategoryResultCollection classifyCustomCategoryResults = classifyCustomCategoryActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(classifyCustomCategoryResults);
        }

        [RecordedTest]
        public async Task ClassifyCustomCategoryBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoryActions = new List<ClassifyCustomCategoryAction>()
                {
                    new ClassifyCustomCategoryAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_classifyCustomCategoryBatchConvenienceDocuments, batchActions, "en", options);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ClassifyCustomCategoryActionResult> classifyCustomCategoryActionsResults = resultCollection.ClassifyCustomCategoryResults;
            ClassifyCustomCategoryResultCollection classifyCustomCategoryResults = classifyCustomCategoryActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(classifyCustomCategoryResults, includeStatistics : true);
        }

        [RecordedTest]
        public async Task ClassifyCustomCategoryBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoryActions = new List<ClassifyCustomCategoryAction>()
                {
                    new ClassifyCustomCategoryAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_classifyCustomCategoryBatchDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ClassifyCustomCategoryActionResult> classifyCustomCategoryActionsResults = resultCollection.ClassifyCustomCategoryResults;
            ClassifyCustomCategoryResultCollection classifyCustomCategoryResults = classifyCustomCategoryActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(classifyCustomCategoryResults);
        }

        [RecordedTest]
        public async Task ClassifyCustomCategoryBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoryActions = new List<ClassifyCustomCategoryAction>()
                {
                    new ClassifyCustomCategoryAction(TestEnvironment.ProjectName, TestEnvironment.DeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_classifyCustomCategoryBatchDocuments, batchActions, options);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ClassifyCustomCategoryActionResult> classifyCustomCategoryActionsResults = resultCollection.ClassifyCustomCategoryResults;
            ClassifyCustomCategoryResultCollection classifyCustomCategoryResults = classifyCustomCategoryActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(classifyCustomCategoryResults, includeStatistics: true);
        }

        private void ValidateSummaryDocumentResult(DocumentClassification classification)
        {
            Assert.GreaterOrEqual(classification.ConfidenceScore, 0);
            Assert.LessOrEqual(classification.ConfidenceScore, 1);
            Assert.NotNull(classification.Category);
        }

        private void ValidateSummaryBatchResult(ClassifyCustomCategoryResultCollection results, bool includeStatistics = false)
        {
            Assert.Equals(results.ProjectName, TestEnvironment.ProjectName);
            Assert.Equals(results.DeploymentName, TestEnvironment.DeploymentName);

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

            foreach (ClassifyCustomCategoryResult result in results)
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

                ValidateSummaryDocumentResult(result.DocumentClassification);
            }
        }
    }
}
