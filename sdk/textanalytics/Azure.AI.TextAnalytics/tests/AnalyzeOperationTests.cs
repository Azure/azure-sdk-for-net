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
    [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
    public class AnalyzeOperationTests : TextAnalyticsClientLiveTestBase
    {
        public AnalyzeOperationTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        private static List<string> batchConvenienceDocuments = new List<string>
        {
            "Elon Musk is the CEO of SpaceX and Tesla.",
            "Tesla stock is up by 400% this year."
        };

        private static List<TextDocumentInput> batchDocuments = new List<TextDocumentInput>
        {
            new TextDocumentInput("1", "Elon Musk is the CEO of SpaceX and Tesla.")
            {
                 Language = "en",
            },
            new TextDocumentInput("2", "Tesla stock is up by 400% this year.")
            {
                 Language = "en",
            }
        };

        [RecordedTest]
        public async Task AnalyzeOperationWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;

            Assert.IsNotNull(keyPhrasesActionsResults);
            Assert.AreEqual(2, keyPhrasesActionsResults.FirstOrDefault().DocumentsResults.Count);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public async Task AnalyzeOperationTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchConvenienceDocuments, batchActions, "en");

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesActionsResults = resultCollection.RecognizeEntitiesResults;
            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesResults;
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesResults;
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults;
            IReadOnlyCollection<RecognizeCustomEntitiesActionResult> recognizeCustomEntitiesActionResults = resultCollection.RecognizeCustomEntitiesResults;
            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyResults = resultCollection.SingleLabelClassifyResults;
            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyResults = resultCollection.MultiLabelClassifyResults;
            IReadOnlyCollection<AnalyzeHealthcareEntitiesActionResult> analyzeHealthcareEntitiesActionResults = resultCollection.AnalyzeHealthcareEntitiesResults;
            IReadOnlyCollection<ExtractSummaryActionResult> extractSummaryActionResults = resultCollection.ExtractSummaryResults;

            Assert.IsNotNull(keyPhrasesActionsResults);
            Assert.IsNotNull(entitiesActionsResults);
            Assert.IsNotNull(piiActionsResults);
            Assert.IsNotNull(entityLinkingActionsResults);
            Assert.IsNotNull(analyzeSentimentActionsResults);
            Assert.IsNotNull(singleLabelClassifyResults);
            Assert.IsNotNull(multiLabelClassifyResults);
            Assert.IsNotNull(recognizeCustomEntitiesActionResults);
            Assert.IsNotNull(analyzeHealthcareEntitiesActionResults);
            Assert.IsNotNull(extractSummaryActionResults);

            var keyPhrasesListId1 = new List<string> { "CEO", "SpaceX", "Elon Musk", "Tesla" };
            var keyPhrasesListId2 = new List<string> { "Tesla stock" };

            ExtractKeyPhrasesResultCollection keyPhrasesDocumentsResults = keyPhrasesActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(2, keyPhrasesDocumentsResults.Count);

            foreach (string keyphrase in keyPhrasesDocumentsResults[0].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId1.Contains(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesDocumentsResults[1].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId2.Contains(keyphrase));
            }
        }

        [RecordedTest]
        public async Task AnalyzeOperationWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();

            var batchDocuments = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Mi perro y mi gato tienen que ir al veterinario.")
                {
                     Language = "es",
                }
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
                DisplayName = "AnalyzeOperationWithLanguageTest"
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;

            Assert.IsNotNull(keyPhrasesActionsResults);

            ExtractKeyPhrasesResultCollection keyPhrasesDocumentsResults = keyPhrasesActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(2, keyPhrasesDocumentsResults.Count);

            Assert.AreEqual("AnalyzeOperationWithLanguageTest", operation.DisplayName);

            var keyPhrasesListId1 = new List<string> { "Bill Gates", "Paul Allen", "Microsoft" };
            var keyPhrasesListId2 = new List<string> { "Mi", "gato", "perro", "veterinario" };

            foreach (string keyphrase in keyPhrasesDocumentsResults[0].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId1.Contains(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesDocumentsResults[1].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId2.Contains(keyphrase));
            }
        }

        [RecordedTest]
        public async Task AnalyzeOperationWithMultipleActions()
        {
            TextAnalyticsClient client = GetClient();

            var batchDocuments = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Mi perro y mi gato tienen que ir al veterinario.")
                {
                     Language = "es",
                }
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { new RecognizeEntitiesAction() },
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { new RecognizePiiEntitiesAction() },
                RecognizeLinkedEntitiesActions = new List<RecognizeLinkedEntitiesAction>() { new RecognizeLinkedEntitiesAction() },
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { new AnalyzeSentimentAction() },
                DisplayName = "AnalyzeOperationWithMultipleTasks"
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchDocuments, batchActions);

            Assert.AreEqual(0, operation.ActionsFailed);
            Assert.AreEqual(0, operation.ActionsSucceeded);
            Assert.AreEqual(0, operation.ActionsInProgress);
            Assert.AreEqual(0, operation.ActionsTotal);

            await operation.WaitForCompletionAsync();

            Assert.AreEqual(0, operation.ActionsFailed);
            Assert.AreEqual(5, operation.ActionsSucceeded);
            Assert.AreEqual(0, operation.ActionsInProgress);
            Assert.AreEqual(5, operation.ActionsTotal);

            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesActionsResults = resultCollection.RecognizeEntitiesResults;
            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesResults;
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesResults;
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults;

            Assert.IsNotNull(keyPhrasesActionsResults);
            Assert.IsNotNull(entitiesActionsResults);
            Assert.IsNotNull(piiActionsResults);
            Assert.IsNotNull(entityLinkingActionsResults);
            Assert.IsNotNull(analyzeSentimentActionsResults);
            Assert.AreEqual("AnalyzeOperationWithMultipleTasks", operation.DisplayName);

            // Keyphrases
            ExtractKeyPhrasesResultCollection keyPhrasesDocumentsResults = keyPhrasesActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(2, keyPhrasesDocumentsResults.Count);

            var keyPhrasesListId1 = new List<string> { "Bill Gates", "Paul Allen", "Microsoft" };
            var keyPhrasesListId2 = new List<string> { "Mi", "gato", "perro", "veterinario" };

            foreach (string keyphrase in keyPhrasesDocumentsResults[0].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId1.Contains(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesDocumentsResults[1].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId2.Contains(keyphrase));
            }

            // Entities
            RecognizeEntitiesResultCollection entitiesDocumentsResults = entitiesActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(2, entitiesDocumentsResults.Count);

            Assert.AreEqual(3, entitiesDocumentsResults[0].Entities.Count);

            var entitiesList = new List<string> { "Bill Gates", "Microsoft", "Paul Allen" };
            foreach (CategorizedEntity entity in entitiesDocumentsResults[0].Entities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Text));
                Assert.IsNotNull(entity.Category);
                Assert.IsNotNull(entity.Offset);
                Assert.IsNotNull(entity.ConfidenceScore);
            }

            // PII
            RecognizePiiEntitiesResultCollection piiDocumentsResults = piiActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(2, piiDocumentsResults.Count);

            Assert.AreEqual(3, piiDocumentsResults[0].Entities.Count);
            Assert.IsNotNull(piiDocumentsResults[0].Id);
            Assert.IsNotNull(piiDocumentsResults[0].Entities);
            Assert.IsNotNull(piiDocumentsResults[0].Error);

            // Entity Linking
            RecognizeLinkedEntitiesResultCollection entityLinkingDocumentsResults = entityLinkingActionsResults.FirstOrDefault().DocumentsResults;
            // Disable because of bug https://github.com/Azure/azure-sdk-for-net/issues/22648
            //Assert.AreEqual(2, entityLinkingDocumentsResults.Count);

            Assert.AreEqual(3, entityLinkingDocumentsResults[0].Entities.Count);
            Assert.IsNotNull(entityLinkingDocumentsResults[0].Id);
            Assert.IsNotNull(entityLinkingDocumentsResults[0].Entities);
            Assert.IsNotNull(entityLinkingDocumentsResults[0].Error);

            foreach (LinkedEntity entity in entityLinkingDocumentsResults[0].Entities)
            {
                if (entity.Name == "Bill Gates")
                {
                    Assert.AreEqual("Bill Gates", entity.DataSourceEntityId);
                    Assert.AreEqual("Wikipedia", entity.DataSource);
                }

                if (entity.Name == "Microsoft")
                {
                    Assert.AreEqual("Microsoft", entity.DataSourceEntityId);
                    Assert.AreEqual("Wikipedia", entity.DataSource);
                }
            }

            // Analyze sentiment
            AnalyzeSentimentResultCollection analyzeSentimentDocumentsResults = analyzeSentimentActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(2, analyzeSentimentDocumentsResults.Count);

            Assert.AreEqual(TextSentiment.Neutral, analyzeSentimentDocumentsResults[0].DocumentSentiment.Sentiment);
            Assert.AreEqual(TextSentiment.Neutral, analyzeSentimentDocumentsResults[1].DocumentSentiment.Sentiment);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        [Ignore("issue: results in an internal server error | bug link: https://dev.azure.com/msazure/Cognitive%20Services/_workitems/edit/12413250")]
        public async Task AnalyzeOperationWithMultipleActionsOfSameType()
        {
            TextAnalyticsClient client = GetClient(useStaticResource: true);

            var batchDocuments = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Mi perro y mi gato tienen que ir al veterinario.")
                {
                     Language = "es",
                }
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>()
                {
                    new ExtractKeyPhrasesAction()
                    { ActionName = "DisableServaiceLogsTrue", DisableServiceLogs = true },
                    new ExtractKeyPhrasesAction()
                    { ActionName = "DisableServiceLogsFalse" },
                },
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>()
                {
                    new RecognizeEntitiesAction()
                    { ActionName = "DisableServiceLogsTrue", DisableServiceLogs = true },
                    new RecognizeEntitiesAction()
                    { ActionName = "DisableServiceLogsFalse" },
                },
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>()
                {
                    new RecognizePiiEntitiesAction()
                    { ActionName = "DisableServiceLogsTrue", DisableServiceLogs = true },
                    new RecognizePiiEntitiesAction()
                    { ActionName = "DisableServiceLogsFalse" },
                },
                RecognizeLinkedEntitiesActions = new List<RecognizeLinkedEntitiesAction>()
                {
                    new RecognizeLinkedEntitiesAction()
                    { ActionName = "DisableServiceLogsTrue", DisableServiceLogs = true },
                    new RecognizeLinkedEntitiesAction()
                    { ActionName = "DisableServiceLogsFalse" },
                },
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>()
                {
                    new AnalyzeSentimentAction()
                    { ActionName = "DisableServiceLogsTrue", DisableServiceLogs = true },
                    new AnalyzeSentimentAction()
                    { ActionName = "DisableServiceLogsFalse" },
                },
                RecognizeCustomEntitiesActions = new List<RecognizeCustomEntitiesAction>()
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                    { ActionName = "DisableServiceLogsTrue", DisableServiceLogs = true },
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName)
                    { ActionName = "DisableServiceLogsFalse" },
                },
                SingleLabelClassifyActions = new List<SingleLabelClassifyAction>()
                {
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                    { ActionName = "DisableServiceLogsTrue", DisableServiceLogs = true },
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName)
                    { ActionName = "DisableServiceLogsFalse" },
                },
                MultiLabelClassifyActions = new List<MultiLabelClassifyAction>()
                {
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                    { ActionName = "DisableServiceLogsTrue", DisableServiceLogs = true },
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName)
                    { ActionName = "DisableServiceLogsFalse" },
                },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchDocuments, batchActions);

            Assert.AreEqual(0, operation.ActionsFailed);
            Assert.AreEqual(0, operation.ActionsSucceeded);
            Assert.AreEqual(0, operation.ActionsInProgress);
            Assert.AreEqual(0, operation.ActionsTotal);

            await operation.WaitForCompletionAsync();

            Assert.AreEqual(0, operation.ActionsFailed);
            Assert.AreEqual(18, operation.ActionsSucceeded);
            Assert.AreEqual(0, operation.ActionsInProgress);
            Assert.AreEqual(18, operation.ActionsTotal);

            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesActionsResults = resultCollection.RecognizeEntitiesResults;
            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesResults;
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesResults;
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults;
            IReadOnlyCollection<RecognizeCustomEntitiesActionResult> recognizeCustomEntitiesResults = resultCollection.RecognizeCustomEntitiesResults;
            IReadOnlyCollection<SingleLabelClassifyActionResult> singleLabelClassifyResults = resultCollection.SingleLabelClassifyResults;
            IReadOnlyCollection<MultiLabelClassifyActionResult> multiLabelClassifyResults = resultCollection.MultiLabelClassifyResults;
            IReadOnlyCollection<AnalyzeHealthcareEntitiesActionResult> analyzeHealthcareEntitiesActionResults = resultCollection.AnalyzeHealthcareEntitiesResults;

            Assert.IsNotNull(keyPhrasesActionsResults);
            Assert.IsNotNull(entitiesActionsResults);
            Assert.IsNotNull(piiActionsResults);
            Assert.IsNotNull(entityLinkingActionsResults);
            Assert.IsNotNull(analyzeSentimentActionsResults);
            Assert.IsNotNull(recognizeCustomEntitiesResults);
            Assert.IsNotNull(singleLabelClassifyResults);
            Assert.IsNotNull(multiLabelClassifyResults);
            Assert.IsNotNull(analyzeHealthcareEntitiesActionResults);
            Assert.AreEqual("AnalyzeOperationWithMultipleTasks", operation.DisplayName);
        }

        [RecordedTest]
        public async Task AnalyzeOperationWithPagination()
        {
            TextAnalyticsClient client = GetClient();

            List<string> documents = new();

            for (int i = 0; i < 23; i++)
            {
                documents.Add("Elon Musk is the CEO of SpaceX and Tesla.");
            }

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
                DisplayName = "AnalyzeOperationWithPagination",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions);

            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            // try async
            //There most be 2 pages as service limit is 20 documents per page
            List<AnalyzeActionsResult> asyncPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(2, asyncPages.Count);

            // First page should have 20 results
            Assert.AreEqual(20, asyncPages[0].ExtractKeyPhrasesResults.FirstOrDefault().DocumentsResults.Count);

            // Second page should have remaining 3 results
            Assert.AreEqual(3, asyncPages[1].ExtractKeyPhrasesResults.FirstOrDefault().DocumentsResults.Count);

            // try sync
            //There most be 2 pages as service limit is 20 documents per page
            List<AnalyzeActionsResult> pages = operation.GetValues().AsEnumerable().ToList();
            Assert.AreEqual(2, pages.Count);

            // First page should have 20 results
            Assert.AreEqual(20, pages[0].ExtractKeyPhrasesResults.FirstOrDefault().DocumentsResults.Count);

            // Second page should have remaining 3 results
            Assert.AreEqual(3, pages[1].ExtractKeyPhrasesResults.FirstOrDefault().DocumentsResults.Count);
        }

        [RecordedTest]
        public void AnalyzeOperationWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily"
            };
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>()
                {
                    new ExtractKeyPhrasesAction()
                    {
                        ModelVersion = "InvalidVersion"
                    }
                },

                DisplayName = "AnalyzeOperationBatchWithErrorTest",
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartAnalyzeActionsAsync(documents, batchActions));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidParameterValue, ex.ErrorCode);
        }

        [RecordedTest]
        public async Task AnalyzeOperationWithErrorsInDocumentTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "",
            };
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>()
                {
                    new ExtractKeyPhrasesAction()
                }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions, "en");
            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            //Key phrases
            List<ExtractKeyPhrasesActionResult> keyPhrasesActions = resultCollection.ExtractKeyPhrasesResults.ToList();

            Assert.AreEqual(1, keyPhrasesActions.Count);

            ExtractKeyPhrasesResultCollection documentsResults = keyPhrasesActions[0].DocumentsResults;
            Assert.IsFalse(documentsResults[0].HasError);
            Assert.IsTrue(documentsResults[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, documentsResults[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        public async Task AnalyzeOperationWithPHIDomain()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "A patient with medical id 12345678 whose phone number is 800-102-1100 is going under heart surgery",
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { new RecognizePiiEntitiesAction() { DomainFilter = PiiEntityDomain.ProtectedHealthInformation } },
                DisplayName = "AnalyzeOperationWithPHIDomain",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions, "en");

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesResults;

            Assert.IsNotNull(piiActionsResults);

            RecognizePiiEntitiesResultCollection piiDocumentsResults = piiActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(1, piiDocumentsResults.Count);

            Assert.IsNotEmpty(piiDocumentsResults[0].Entities.RedactedText);

            Assert.IsFalse(piiDocumentsResults[0].HasError);
            Assert.AreEqual(2, piiDocumentsResults[0].Entities.Count);
        }

        [RecordedTest]
        public async Task AnalyzeOperationWithPiiCategories()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "A developer with SSN 859-98-0987 whose phone number is 800-102-1100 is building tools with our APIs. They work at Microsoft.",
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { new RecognizePiiEntitiesAction() { CategoriesFilter = { PiiEntityCategory.USSocialSecurityNumber } } },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions, "en");

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesResults;

            Assert.IsNotNull(piiActionsResults);

            RecognizePiiEntitiesResultCollection piiDocumentsResults = piiActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(1, piiDocumentsResults.Count);

            Assert.IsNotEmpty(piiDocumentsResults[0].Entities.RedactedText);

            Assert.IsFalse(piiDocumentsResults[0].HasError);
            Assert.AreEqual(1, piiDocumentsResults[0].Entities.Count);
            Assert.AreEqual(PiiEntityCategory.USSocialSecurityNumber, piiDocumentsResults[0].Entities.FirstOrDefault().Category);
        }

        [RecordedTest]
        public async Task AnalyzeOperationWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();

            var batchDocuments = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Mi perro y mi gato tienen que ir al veterinario.")
                {
                     Language = "es",
                },
                new TextDocumentInput("3", "")
                {
                     Language = "es",
                }
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
                DisplayName = "AnalyzeOperationTest",
            };

            AnalyzeActionsOptions options = new AnalyzeActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchDocuments, batchActions, options);

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            ExtractKeyPhrasesResultCollection documentsResults = resultCollection.ExtractKeyPhrasesResults.ElementAt(0).DocumentsResults;

            Assert.IsNotNull(documentsResults);

            Assert.AreEqual(3, documentsResults.Count);

            Assert.AreEqual(3, documentsResults.Statistics.DocumentCount);
            Assert.AreEqual(2, documentsResults.Statistics.TransactionCount);
            Assert.AreEqual(2, documentsResults.Statistics.ValidDocumentCount);
            Assert.AreEqual(1, documentsResults.Statistics.InvalidDocumentCount);

            Assert.AreEqual(51, documentsResults[0].Statistics.CharacterCount);
            Assert.AreEqual(1, documentsResults[0].Statistics.TransactionCount);
        }

        [RecordedTest]
        public async Task AnalyzeOperationAllActionsAndDisableServiceLogs()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() { DisableServiceLogs = true } },
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { new RecognizeEntitiesAction() { DisableServiceLogs = true } },
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { new RecognizePiiEntitiesAction() { DisableServiceLogs = false } },
                RecognizeLinkedEntitiesActions = new List<RecognizeLinkedEntitiesAction>() { new RecognizeLinkedEntitiesAction() { DisableServiceLogs = true } },
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { new AnalyzeSentimentAction() { DisableServiceLogs = true } }
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchConvenienceDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;
            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesActionsResults = resultCollection.RecognizeEntitiesResults;
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesResults;
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesResults;
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults;

            Assert.IsNotNull(keyPhrasesActionsResults);
            Assert.AreEqual(2, keyPhrasesActionsResults.FirstOrDefault().DocumentsResults.Count);

            Assert.IsNotNull(entitiesActionsResults);
            Assert.AreEqual(2, entitiesActionsResults.FirstOrDefault().DocumentsResults.Count);

            Assert.IsNotNull(piiActionsResults);
            Assert.AreEqual(2, piiActionsResults.FirstOrDefault().DocumentsResults.Count);

            Assert.IsNotNull(entityLinkingActionsResults);
            Assert.AreEqual(2, entityLinkingActionsResults.FirstOrDefault().DocumentsResults.Count);

            Assert.IsNotNull(analyzeSentimentActionsResults);
            Assert.AreEqual(2, analyzeSentimentActionsResults.FirstOrDefault().DocumentsResults.Count);
        }

        [RecordedTest]
        public async Task AnalyzeOperationAnalyzeSentimentWithOpinionMining()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "The park was clean and pretty. The bathrooms and restaurant were not clean.",
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { new AnalyzeSentimentAction() { IncludeOpinionMining = true } },
                DisplayName = "AnalyzeOperationWithOpinionMining",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions);

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults;

            Assert.IsNotNull(analyzeSentimentActionsResults);

            AnalyzeSentimentResultCollection analyzeSentimentDocumentsResults = analyzeSentimentActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(1, analyzeSentimentDocumentsResults.Count);

            Assert.AreEqual(TextSentiment.Mixed, analyzeSentimentDocumentsResults[0].DocumentSentiment.Sentiment);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public async Task AnalyzeOperationAnalyzeHealthcareEntities()
        {
            TextAnalyticsClient client = GetClient();

            List<string> documents = new()
            {
                "Prescribed 100mg ibuprofen to Jane Doe, taken twice daily.",
            };

            TextAnalyticsActions batchActions = new()
            {
                RecognizePiiEntitiesActions = new[]
                {
                    new RecognizePiiEntitiesAction(),
                },
                AnalyzeHealthcareEntitiesActions = new[]
                {
                    new AnalyzeHealthcareEntitiesAction(),
                },
                DisplayName = "AnalyzeOperationAnalyzeHealthcareEntities",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions);
            await operation.WaitForCompletionAsync();

            // Take the first page.
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults = resultCollection.RecognizePiiEntitiesResults;
            Assert.That(recognizePiiEntitiesActionResults, Has.Some.Matches<RecognizePiiEntitiesActionResult>(result => result.DocumentsResults.SelectMany(doc => doc.Entities).Any(e => e.Category == PiiEntityCategory.Person && e.Text == "Jane Doe")));

            IReadOnlyCollection<AnalyzeHealthcareEntitiesActionResult> analyzeHealthcareEntitiesActionResults = resultCollection.AnalyzeHealthcareEntitiesResults;
            Assert.That(analyzeHealthcareEntitiesActionResults, Has.Some.Matches<AnalyzeHealthcareEntitiesActionResult>(result => result.DocumentsResults.SelectMany(doc => doc.Entities).Any(e => e.Category == HealthcareEntityCategory.Dosage && e.Text == "100mg")));

            Assert.That(analyzeHealthcareEntitiesActionResults, Has.Some.Matches<AnalyzeHealthcareEntitiesActionResult>(result => result.DocumentsResults.SelectMany(doc => doc.Entities).Any(e => e.Category == HealthcareEntityCategory.MedicationName && e.Text == "ibuprofen")));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeOperationAnalyzeHealthcareEntitiesWithFhirVersion()
        {
            TextAnalyticsClient client = GetClient();

            List<string> documents = new()
            {
                "Prescribed 100mg ibuprofen to Jane Doe, taken twice daily.",
            };

            TextAnalyticsActions batchActions = new()
            {
                AnalyzeHealthcareEntitiesActions = new[]
                {
                    new AnalyzeHealthcareEntitiesAction(new AnalyzeHealthcareEntitiesOptions()
                    {
                        FhirVersion = FhirVersion.V4_0_1,
                        DocumentType = HealthcareDocumentType.DischargeSummary
                    }),
                },
                DisplayName = "AnalyzeOperationAnalyzeHealthcareEntitiesWithFhirVersion",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions);
            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<AnalyzeHealthcareEntitiesActionResult> analyzeHealthcareEntitiesActionResults = resultCollection.AnalyzeHealthcareEntitiesResults;
            Assert.IsNotNull(analyzeHealthcareEntitiesActionResults);

            AnalyzeHealthcareEntitiesResultCollection analyzeHealthcareEntitiesDocumentsResults = analyzeHealthcareEntitiesActionResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(1, analyzeHealthcareEntitiesDocumentsResults.Count);
            Assert.IsNotNull(analyzeHealthcareEntitiesDocumentsResults[0].FhirBundle);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeOperationExtractSummary()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Extractive summarization extracts sentences that collectively represent the most important or relevant information within the original content."
                + " Abstractive summarization generates a summary with concise, coherent sentences or words which are not simply extract sentences from the original document."
                + " These features are designed to shorten content that could be considered too long to read.",
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractSummaryActions = new List<ExtractSummaryAction>() { new ExtractSummaryAction() { MaxSentenceCount = 2 } },
                DisplayName = "AnalyzeOperationExtractSummary",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions);
            await operation.WaitForCompletionAsync();

            // Take the first page.
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<ExtractSummaryActionResult> extractSummaryActionsResults = resultCollection.ExtractSummaryResults;
            Assert.IsNotNull(extractSummaryActionsResults);

            ExtractSummaryResultCollection extractSummaryDocumentsResults = extractSummaryActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(1, extractSummaryDocumentsResults.Count);

            Assert.AreEqual(2, extractSummaryDocumentsResults[0].Sentences.Count);
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_10_01_Preview)]
        public async Task AnalyzeOperationAbstractSummary()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Extractive summarization extracts sentences that collectively represent the most important or relevant information within the original content."
                + " Abstractive summarization generates a summary with concise, coherent sentences or words which are not simply extract sentences from the original document."
                + " These features are designed to shorten content that could be considered too long to read.",
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                AbstractSummaryActions = new List<AbstractSummaryAction>() { new AbstractSummaryAction() { SentenceCount = 2 } },
                DisplayName = "AnalyzeOperationAbstractSummary",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions);
            await operation.WaitForCompletionAsync();

            // Take the first page.
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();
            IReadOnlyCollection<AbstractSummaryActionResult> abstractSummaryActionsResults = resultCollection.AbstractSummaryResults;
            Assert.IsNotNull(abstractSummaryActionsResults);

            AbstractSummaryResultCollection abstractSummaryDocumentsResults = abstractSummaryActionsResults.FirstOrDefault().DocumentsResults;
            Assert.AreEqual(1, abstractSummaryDocumentsResults.Count);

            AbstractSummaryResult result = abstractSummaryDocumentsResults[0];
            Assert.Greater(result.Summaries.Count, 0);

            AbstractiveSummary summary = result.Summaries.FirstOrDefault();
            Assert.IsNotNull(summary);
            Assert.That(summary.Text, Is.Not.Null.And.Not.Empty);
            Assert.Less(summary.Text.Length, documents[0].Length);
            Assert.IsNotNull(summary.Contexts);
            Assert.Greater(summary.Contexts.Count, 0);
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public void AnalyzeOperationAnalyzeHealthcareEntitiesActionNotSupported()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new()
            {
                AnalyzeHealthcareEntitiesActions = new[]
                {
                    new AnalyzeHealthcareEntitiesAction(),
                },
            };

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeActionsAsync(batchDocuments, batchActions));
            Assert.AreEqual("AnalyzeHealthcareEntitiesAction is not available in API version v3.1. Use service API version 2022-05-01 or newer.", ex.Message);
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public void AnalyzeOperationMultiLabelClassifyActionNotSupported()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new()
            {
                MultiLabelClassifyActions = new[]
                {
                    new MultiLabelClassifyAction(TestEnvironment.MultiClassificationProjectName, TestEnvironment.MultiClassificationDeploymentName),
                },
            };

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeActionsAsync(batchDocuments, batchActions));
            Assert.AreEqual("MultiLabelClassifyAction is not available in API version v3.1. Use service API version 2022-05-01 or newer.", ex.Message);
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public void AnalyzeOperationRecognizeCustomEntitiesActionNotSupported()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new()
            {
                RecognizeCustomEntitiesActions = new[]
                {
                    new RecognizeCustomEntitiesAction(TestEnvironment.RecognizeCustomEntitiesProjectName, TestEnvironment.RecognizeCustomEntitiesDeploymentName),
                },
            };

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeActionsAsync(batchDocuments, batchActions));
            Assert.AreEqual("RecognizeCustomEntitiesAction is not available in API version v3.1. Use service API version 2022-05-01 or newer.", ex.Message);
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public void AnalyzeOperationSingleLabelClassifyActionNotSupported()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient(useStaticResource: true);

            TextAnalyticsActions batchActions = new()
            {
                SingleLabelClassifyActions = new[]
                {
                    new SingleLabelClassifyAction(TestEnvironment.SingleClassificationProjectName, TestEnvironment.SingleClassificationDeploymentName),
                },
            };

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeActionsAsync(batchDocuments, batchActions));
            Assert.AreEqual("SingleLabelClassifyAction is not available in API version v3.1. Use service API version 2022-05-01 or newer.", ex.Message);
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public void AnalyzeOperationExtractSummaryActionNotSupported()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new()
            {
                ExtractSummaryActions = new[]
                {
                    new ExtractSummaryAction(),
                },
            };

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.StartAnalyzeActionsAsync(batchDocuments, batchActions));
            Assert.That(ex.Message.EndsWith("Use service API version 2022-10-01-preview or newer."));
        }

        [RecordedTest]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public void AnalyzeOperationWithDefaultLanguageThrows()
        {
            TestDiagnostics = false;

            TextAnalyticsClient client = GetClient();
            List<string> documents = new()
            {
                "The park was clean and pretty. The bathrooms and restaurant were not clean.",
            };
            AnalyzeActionsOptions options = new()
            {
                AutoDetectionDefaultLanguage = "en"
            };
            TextAnalyticsActions actions = new()
            {
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { new AnalyzeSentimentAction() }
            };

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(
                async () => await client.StartAnalyzeActionsAsync(documents, actions, "auto", options));

            Assert.That(ex.Message.EndsWith("Use service API version 2022-10-01-preview or newer."));
        }

        private void ValidateOperationProperties(AnalyzeActionsOperation operation)
        {
            Assert.AreNotEqual(new DateTimeOffset(), operation.CreatedOn);
            // TODO: Re-enable this check (https://github.com/Azure/azure-sdk-for-net/issues/31855).
            // Assert.AreNotEqual(new DateTimeOffset(), operation.LastModified);

            if (operation.ExpiresOn.HasValue)
            {
                Assert.AreNotEqual(new DateTimeOffset(), operation.ExpiresOn.Value);
            }
        }
    }
}
