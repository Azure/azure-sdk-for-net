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
    public class ClassifyCustomCategoriesTests : TextAnalyticsClientLiveTestBase
    {
        public ClassifyCustomCategoriesTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private const string ClassifyCustomCategoriesDocument1 =
            "I need a reservation for an indoor restaurant in China. Please don't stop the music. Play music and add it to my playlist";

        private const string ClassifyCustomCategoriesDocument2 =
            "David Schmidt, senior vice president--Food Safety, International Food Information Council (IFIC), Washington, D.C., discussed the physical activity component.";

        private static readonly List<string> s_classifyCustomCategoriesBatchConvenienceDocuments = new List<string>
        {
            ClassifyCustomCategoriesDocument1,
            ClassifyCustomCategoriesDocument2
        };

        private static List<TextDocumentInput> s_classifyCustomCategoriesBatchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", ClassifyCustomCategoriesDocument1)
            {
                 Language = "en",
            },
            new TextDocumentInput("2", ClassifyCustomCategoriesDocument2)
            {
                 Language = "en",
            }
        };

        [RecordedTest]
        public async Task ClassifyCustomCategoriesWithDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoriesActions = new List<ClassifyCustomCategoriesAction>() { new ClassifyCustomCategoriesAction(TestEnvironment.MultiCategoriesProjectName, TestEnvironment.MultiCategoriesDeploymentName) { DisableServiceLogs = true } }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_classifyCustomCategoriesBatchConvenienceDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ClassifyCustomCategoriesActionResult> classifyCustomCategoriesActionsResults = resultCollection.ClassifyCustomCategoriesResults;

            Assert.IsNotNull(classifyCustomCategoriesActionsResults);
            Assert.AreEqual(2, classifyCustomCategoriesActionsResults.FirstOrDefault().DocumentsResults.Count);
        }

        [RecordedTest]
        public async Task ClassifyCustomCategoriesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "",
            };
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoriesActions = new List<ClassifyCustomCategoriesAction>()
                {
                    new ClassifyCustomCategoriesAction(TestEnvironment.MultiCategoriesProjectName, TestEnvironment.MultiCategoriesDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions, "en");
            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            List<ClassifyCustomCategoriesActionResult> classifyCustomCategoriesActions = resultCollection.ClassifyCustomCategoriesResults.ToList();

            Assert.AreEqual(1, classifyCustomCategoriesActions.Count);

            ClassifyCustomCategoriesResultCollection documentsResults = classifyCustomCategoriesActions[0].DocumentsResults;
            Assert.IsFalse(documentsResults[0].HasError);
            Assert.IsTrue(documentsResults[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, documentsResults[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        public async Task ClassifyCustomCategoriesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoriesActions = new List<ClassifyCustomCategoriesAction>()
                {
                    new ClassifyCustomCategoriesAction(TestEnvironment.MultiCategoriesProjectName, TestEnvironment.MultiCategoriesDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_classifyCustomCategoriesBatchConvenienceDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ClassifyCustomCategoriesActionResult> classifyCustomCategoriesActionsResults = resultCollection.ClassifyCustomCategoriesResults;
            ClassifyCustomCategoriesResultCollection classifyCustomCategoriesResults = classifyCustomCategoriesActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(classifyCustomCategoriesResults);
        }

        [RecordedTest]
        public async Task ClassifyCustomCategoriesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoriesActions = new List<ClassifyCustomCategoriesAction>()
                {
                    new ClassifyCustomCategoriesAction(TestEnvironment.MultiCategoriesProjectName, TestEnvironment.MultiCategoriesDeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_classifyCustomCategoriesBatchConvenienceDocuments, batchActions, "en", options);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ClassifyCustomCategoriesActionResult> classifyCustomCategoriesActionsResults = resultCollection.ClassifyCustomCategoriesResults;
            ClassifyCustomCategoriesResultCollection classifyCustomCategoriesResults = classifyCustomCategoriesActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(classifyCustomCategoriesResults, includeStatistics: true);
        }

        [RecordedTest]
        public async Task ClassifyCustomCategoriesBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoriesActions = new List<ClassifyCustomCategoriesAction>()
                {
                    new ClassifyCustomCategoriesAction(TestEnvironment.MultiCategoriesProjectName, TestEnvironment.MultiCategoriesDeploymentName)
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_classifyCustomCategoriesBatchDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ClassifyCustomCategoriesActionResult> classifyCustomCategoriesActionsResults = resultCollection.ClassifyCustomCategoriesResults;
            ClassifyCustomCategoriesResultCollection classifyCustomCategoriesResults = classifyCustomCategoriesActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(classifyCustomCategoriesResults);
        }

        [RecordedTest]
        public async Task ClassifyCustomCategoriesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ClassifyCustomCategoriesActions = new List<ClassifyCustomCategoriesAction>()
                {
                    new ClassifyCustomCategoriesAction(TestEnvironment.MultiCategoriesProjectName, TestEnvironment.MultiCategoriesDeploymentName)
                }
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(s_classifyCustomCategoriesBatchDocuments, batchActions, options);

            await operation.WaitForCompletionAsync();

            // Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ClassifyCustomCategoriesActionResult> classifyCustomCategoriesActionsResults = resultCollection.ClassifyCustomCategoriesResults;
            ClassifyCustomCategoriesResultCollection classifyCustomCategoriesResults = classifyCustomCategoriesActionsResults.FirstOrDefault().DocumentsResults;

            ValidateSummaryBatchResult(classifyCustomCategoriesResults, includeStatistics: true);
        }

        private void ValidateSummaryDocumentResult(DocumentClassificationCollection classificationCollection)
        {
            Assert.IsNotNull(classificationCollection.Warnings);

            foreach (var classification in classificationCollection)
            {
                Assert.GreaterOrEqual(classification.ConfidenceScore, 0);
                Assert.LessOrEqual(classification.ConfidenceScore, 1);
                Assert.NotNull(classification.Category);
            }
        }

        private void ValidateSummaryBatchResult(ClassifyCustomCategoriesResultCollection results, bool includeStatistics = false)
        {
            Assert.AreEqual(results.ProjectName, TestEnvironment.MultiCategoriesProjectName);
            Assert.AreEqual(results.DeploymentName, TestEnvironment.MultiCategoriesDeploymentName);

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

            foreach (ClassifyCustomCategoriesResult result in results)
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

                ValidateSummaryDocumentResult(result.DocumentClassifications);
            }
        }
    }
}
