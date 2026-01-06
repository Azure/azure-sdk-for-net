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
        [RetryOnInternalServerError]
        public async Task AnalyzeOperationWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, batchDocuments, batchActions);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;

            Assert.That(keyPhrasesActionsResults, Is.Not.Null);
            Assert.That(keyPhrasesActionsResults.FirstOrDefault().DocumentsResults, Has.Count.EqualTo(2));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public async Task AnalyzeOperationTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, batchConvenienceDocuments, batchActions, "en");

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
            IReadOnlyCollection<ExtractiveSummarizeActionResult> extractiveSummarizeActionResults = resultCollection.ExtractiveSummarizeResults;

            Assert.Multiple(() =>
            {
                Assert.That(keyPhrasesActionsResults, Is.Not.Null);
                Assert.That(entitiesActionsResults, Is.Not.Null);
                Assert.That(piiActionsResults, Is.Not.Null);
                Assert.That(entityLinkingActionsResults, Is.Not.Null);
                Assert.That(analyzeSentimentActionsResults, Is.Not.Null);
                Assert.That(singleLabelClassifyResults, Is.Not.Null);
                Assert.That(multiLabelClassifyResults, Is.Not.Null);
                Assert.That(recognizeCustomEntitiesActionResults, Is.Not.Null);
                Assert.That(analyzeHealthcareEntitiesActionResults, Is.Not.Null);
                Assert.That(extractiveSummarizeActionResults, Is.Not.Null);
            });

            var keyPhrasesListId1 = new List<string> { "CEO", "SpaceX", "Elon Musk", "Tesla" };
            var keyPhrasesListId2 = new List<string> { "Tesla stock" };

            ExtractKeyPhrasesResultCollection keyPhrasesDocumentsResults = keyPhrasesActionsResults.FirstOrDefault().DocumentsResults;
            Assert.That(keyPhrasesDocumentsResults, Has.Count.EqualTo(2));

            foreach (string keyphrase in keyPhrasesDocumentsResults[0].KeyPhrases)
            {
                Assert.That(keyPhrasesListId1, Does.Contain(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesDocumentsResults[1].KeyPhrases)
            {
                Assert.That(keyPhrasesListId2, Does.Contain(keyphrase));
            }
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, batchDocuments, batchActions);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;

            Assert.That(keyPhrasesActionsResults, Is.Not.Null);

            ExtractKeyPhrasesResultCollection keyPhrasesDocumentsResults = keyPhrasesActionsResults.FirstOrDefault().DocumentsResults;
            Assert.Multiple(() =>
            {
                Assert.That(keyPhrasesDocumentsResults, Has.Count.EqualTo(2));

                Assert.That(operation.DisplayName, Is.EqualTo("AnalyzeOperationWithLanguageTest"));
            });

            var keyPhrasesListId1 = new List<string> { "Bill Gates", "Paul Allen", "Microsoft" };
            var keyPhrasesListId2 = new List<string> { "Mi", "gato", "perro", "veterinario" };

            foreach (string keyphrase in keyPhrasesDocumentsResults[0].KeyPhrases)
            {
                Assert.That(keyPhrasesListId1, Does.Contain(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesDocumentsResults[1].KeyPhrases)
            {
                Assert.That(keyPhrasesListId2, Does.Contain(keyphrase));
            }
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Started, batchDocuments, batchActions);

            Assert.Multiple(() =>
            {
                Assert.That(operation.ActionsFailed, Is.EqualTo(0));
                Assert.That(operation.ActionsSucceeded, Is.EqualTo(0));
                Assert.That(operation.ActionsInProgress, Is.EqualTo(0));
                Assert.That(operation.ActionsTotal, Is.EqualTo(0));
            });

            await operation.WaitForCompletionAsync();

            Assert.Multiple(() =>
            {
                Assert.That(operation.ActionsFailed, Is.EqualTo(0));
                Assert.That(operation.ActionsSucceeded, Is.EqualTo(5));
                Assert.That(operation.ActionsInProgress, Is.EqualTo(0));
                Assert.That(operation.ActionsTotal, Is.EqualTo(5));
            });

            ValidateOperationProperties(operation);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesActionsResults = resultCollection.RecognizeEntitiesResults;
            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesResults;
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesResults;
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults;

            Assert.Multiple(() =>
            {
                Assert.That(keyPhrasesActionsResults, Is.Not.Null);
                Assert.That(entitiesActionsResults, Is.Not.Null);
                Assert.That(piiActionsResults, Is.Not.Null);
                Assert.That(entityLinkingActionsResults, Is.Not.Null);
                Assert.That(analyzeSentimentActionsResults, Is.Not.Null);
                Assert.That(operation.DisplayName, Is.EqualTo("AnalyzeOperationWithMultipleTasks"));
            });

            // Keyphrases
            ExtractKeyPhrasesResultCollection keyPhrasesDocumentsResults = keyPhrasesActionsResults.FirstOrDefault().DocumentsResults;
            Assert.That(keyPhrasesDocumentsResults, Has.Count.EqualTo(2));

            var keyPhrasesListId1 = new List<string> { "Bill Gates", "Paul Allen", "Microsoft" };
            var keyPhrasesListId2 = new List<string> { "Mi", "gato", "perro", "veterinario" };

            foreach (string keyphrase in keyPhrasesDocumentsResults[0].KeyPhrases)
            {
                Assert.That(keyPhrasesListId1, Does.Contain(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesDocumentsResults[1].KeyPhrases)
            {
                Assert.That(keyPhrasesListId2, Does.Contain(keyphrase));
            }

            // Entities
            RecognizeEntitiesResultCollection entitiesDocumentsResults = entitiesActionsResults.FirstOrDefault().DocumentsResults;
            Assert.That(entitiesDocumentsResults, Has.Count.EqualTo(2));

            Assert.That(entitiesDocumentsResults[0].Entities, Has.Count.EqualTo(3));

            var entitiesList = new List<string> { "Bill Gates", "Microsoft", "Paul Allen" };
            foreach (CategorizedEntity entity in entitiesDocumentsResults[0].Entities)
            {
                Assert.Multiple(() =>
                {
                    Assert.That(entitiesList, Does.Contain(entity.Text));
                    Assert.That(entity.Category, Is.Not.Null);
                    Assert.That(entity.Offset, Is.Not.Null);
                    Assert.That(entity.ConfidenceScore, Is.Not.Null);
                });
            }

            // PII
            RecognizePiiEntitiesResultCollection piiDocumentsResults = piiActionsResults.FirstOrDefault().DocumentsResults;
            Assert.That(piiDocumentsResults, Has.Count.EqualTo(2));

            Assert.Multiple(() =>
            {
                Assert.That(piiDocumentsResults[0].Entities, Has.Count.EqualTo(3));
                Assert.That(piiDocumentsResults[0].Id, Is.Not.Null);
                Assert.That(piiDocumentsResults[0].Entities, Is.Not.Null);
                Assert.That(piiDocumentsResults[0].Error, Is.Not.Null);
            });

            // Entity Linking
            RecognizeLinkedEntitiesResultCollection entityLinkingDocumentsResults = entityLinkingActionsResults.FirstOrDefault().DocumentsResults;
            Assert.Multiple(() =>
            {
                // Disable because of bug https://github.com/Azure/azure-sdk-for-net/issues/22648
                //Assert.AreEqual(2, entityLinkingDocumentsResults.Count);

                Assert.That(entityLinkingDocumentsResults[0].Entities, Has.Count.EqualTo(3));
                Assert.That(entityLinkingDocumentsResults[0].Id, Is.Not.Null);
                Assert.That(entityLinkingDocumentsResults[0].Entities, Is.Not.Null);
                Assert.That(entityLinkingDocumentsResults[0].Error, Is.Not.Null);
            });

            foreach (LinkedEntity entity in entityLinkingDocumentsResults[0].Entities)
            {
                if (entity.Name == "Bill Gates")
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(entity.DataSourceEntityId, Is.EqualTo("Bill Gates"));
                        Assert.That(entity.DataSource, Is.EqualTo("Wikipedia"));
                    });
                }

                if (entity.Name == "Microsoft")
                {
                    Assert.Multiple(() =>
                    {
                        Assert.That(entity.DataSourceEntityId, Is.EqualTo("Microsoft"));
                        Assert.That(entity.DataSource, Is.EqualTo("Wikipedia"));
                    });
                }
            }

            // Analyze sentiment
            AnalyzeSentimentResultCollection analyzeSentimentDocumentsResults = analyzeSentimentActionsResults.FirstOrDefault().DocumentsResults;
            Assert.That(analyzeSentimentDocumentsResults, Has.Count.EqualTo(2));

            Assert.Multiple(() =>
            {
                Assert.That(analyzeSentimentDocumentsResults[0].DocumentSentiment.Sentiment, Is.EqualTo(TextSentiment.Neutral));
                Assert.That(analyzeSentimentDocumentsResults[1].DocumentSentiment.Sentiment, Is.EqualTo(TextSentiment.Neutral));
            });
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        [Ignore("issue: results in an internal server error | bug link: https://dev.azure.com/msazure/Cognitive%20Services/_workitems/edit/12413250")]
        public async Task AnalyzeOperationWithMultipleActionsOfSameType()
        {
            TestEnvironment.IgnoreIfNotPublicCloud();

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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Started, batchDocuments, batchActions);

            Assert.Multiple(() =>
            {
                Assert.That(operation.ActionsFailed, Is.EqualTo(0));
                Assert.That(operation.ActionsSucceeded, Is.EqualTo(0));
                Assert.That(operation.ActionsInProgress, Is.EqualTo(0));
                Assert.That(operation.ActionsTotal, Is.EqualTo(0));
            });

            await operation.WaitForCompletionAsync();

            Assert.Multiple(() =>
            {
                Assert.That(operation.ActionsFailed, Is.EqualTo(0));
                Assert.That(operation.ActionsSucceeded, Is.EqualTo(18));
                Assert.That(operation.ActionsInProgress, Is.EqualTo(0));
                Assert.That(operation.ActionsTotal, Is.EqualTo(18));
            });

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

            Assert.Multiple(() =>
            {
                Assert.That(keyPhrasesActionsResults, Is.Not.Null);
                Assert.That(entitiesActionsResults, Is.Not.Null);
                Assert.That(piiActionsResults, Is.Not.Null);
                Assert.That(entityLinkingActionsResults, Is.Not.Null);
                Assert.That(analyzeSentimentActionsResults, Is.Not.Null);
                Assert.That(recognizeCustomEntitiesResults, Is.Not.Null);
                Assert.That(singleLabelClassifyResults, Is.Not.Null);
                Assert.That(multiLabelClassifyResults, Is.Not.Null);
                Assert.That(analyzeHealthcareEntitiesActionResults, Is.Not.Null);
                Assert.That(operation.DisplayName, Is.EqualTo("AnalyzeOperationWithMultipleTasks"));
            });
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Started, documents, batchActions);
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.False);
                Assert.That(operation.HasValue, Is.False);
            });
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(operation.HasValue, Is.True);
            });

            // try async
            //There most be 2 pages as service limit is 20 documents per page
            List<AnalyzeActionsResult> asyncPages = operation.Value.ToEnumerableAsync().Result;
            Assert.That(asyncPages, Has.Count.EqualTo(2));

            Assert.Multiple(() =>
            {
                // First page should have 20 results
                Assert.That(asyncPages[0].ExtractKeyPhrasesResults.FirstOrDefault().DocumentsResults, Has.Count.EqualTo(20));

                // Second page should have remaining 3 results
                Assert.That(asyncPages[1].ExtractKeyPhrasesResults.FirstOrDefault().DocumentsResults, Has.Count.EqualTo(3));
            });

            // try sync
            //There most be 2 pages as service limit is 20 documents per page
            List<AnalyzeActionsResult> pages = operation.GetValues().AsEnumerable().ToList();
            Assert.That(pages, Has.Count.EqualTo(2));

            Assert.Multiple(() =>
            {
                // First page should have 20 results
                Assert.That(pages[0].ExtractKeyPhrasesResults.FirstOrDefault().DocumentsResults, Has.Count.EqualTo(20));

                // Second page should have remaining 3 results
                Assert.That(pages[1].ExtractKeyPhrasesResults.FirstOrDefault().DocumentsResults, Has.Count.EqualTo(3));
            });
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.AnalyzeActionsAsync(WaitUntil.Completed, documents, batchActions));
            Assert.That(ex.ErrorCode, Is.EqualTo(TextAnalyticsErrorCode.InvalidParameterValue));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, documents, batchActions, "en");

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            //Key phrases
            List<ExtractKeyPhrasesActionResult> keyPhrasesActions = resultCollection.ExtractKeyPhrasesResults.ToList();

            Assert.That(keyPhrasesActions, Has.Count.EqualTo(1));

            ExtractKeyPhrasesResultCollection documentsResults = keyPhrasesActions[0].DocumentsResults;
            Assert.Multiple(() =>
            {
                Assert.That(documentsResults[0].HasError, Is.False);
                Assert.That(documentsResults[1].HasError, Is.True);
                Assert.That(documentsResults[1].Error.ErrorCode.ToString(), Is.EqualTo(TextAnalyticsErrorCode.InvalidDocument));
            });
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, documents, batchActions, "en");

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesResults;

            Assert.That(piiActionsResults, Is.Not.Null);

            RecognizePiiEntitiesResultCollection piiDocumentsResults = piiActionsResults.FirstOrDefault().DocumentsResults;
            Assert.That(piiDocumentsResults, Has.Count.EqualTo(1));

            Assert.Multiple(() =>
            {
                Assert.That(piiDocumentsResults[0].Entities.RedactedText, Is.Not.Empty);

                Assert.That(piiDocumentsResults[0].HasError, Is.False);
                Assert.That(piiDocumentsResults[0].Entities, Has.Count.EqualTo(2));
            });
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, documents, batchActions, "en");

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesResults;

            Assert.That(piiActionsResults, Is.Not.Null);

            RecognizePiiEntitiesResultCollection piiDocumentsResults = piiActionsResults.FirstOrDefault().DocumentsResults;
            Assert.That(piiDocumentsResults, Has.Count.EqualTo(1));

            Assert.Multiple(() =>
            {
                Assert.That(piiDocumentsResults[0].Entities.RedactedText, Is.Not.Empty);

                Assert.That(piiDocumentsResults[0].HasError, Is.False);
                Assert.That(piiDocumentsResults[0].Entities, Has.Count.EqualTo(1));
            });
            Assert.That(piiDocumentsResults[0].Entities.FirstOrDefault().Category, Is.EqualTo(PiiEntityCategory.USSocialSecurityNumber));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, batchDocuments, batchActions, options);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            ExtractKeyPhrasesResultCollection documentsResults = resultCollection.ExtractKeyPhrasesResults.ElementAt(0).DocumentsResults;

            Assert.That(documentsResults, Is.Not.Null);

            Assert.That(documentsResults, Has.Count.EqualTo(3));

            Assert.Multiple(() =>
            {
                Assert.That(documentsResults.Statistics.DocumentCount, Is.EqualTo(3));
                Assert.That(documentsResults.Statistics.TransactionCount, Is.EqualTo(2));
                Assert.That(documentsResults.Statistics.ValidDocumentCount, Is.EqualTo(2));
                Assert.That(documentsResults.Statistics.InvalidDocumentCount, Is.EqualTo(1));

                Assert.That(documentsResults[0].Statistics.CharacterCount, Is.EqualTo(51));
                Assert.That(documentsResults[0].Statistics.TransactionCount, Is.EqualTo(1));
            });
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, batchConvenienceDocuments, batchActions);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesResults;
            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesActionsResults = resultCollection.RecognizeEntitiesResults;
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesResults;
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesResults;
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults;

            Assert.That(keyPhrasesActionsResults, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(keyPhrasesActionsResults.FirstOrDefault().DocumentsResults, Has.Count.EqualTo(2));

                Assert.That(entitiesActionsResults, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(entitiesActionsResults.FirstOrDefault().DocumentsResults, Has.Count.EqualTo(2));

                Assert.That(piiActionsResults, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(piiActionsResults.FirstOrDefault().DocumentsResults, Has.Count.EqualTo(2));

                Assert.That(entityLinkingActionsResults, Is.Not.Null);
            });
            Assert.Multiple(() =>
            {
                Assert.That(entityLinkingActionsResults.FirstOrDefault().DocumentsResults, Has.Count.EqualTo(2));

                Assert.That(analyzeSentimentActionsResults, Is.Not.Null);
            });
            Assert.That(analyzeSentimentActionsResults.FirstOrDefault().DocumentsResults, Has.Count.EqualTo(2));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, documents, batchActions);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentResults;

            Assert.That(analyzeSentimentActionsResults, Is.Not.Null);

            AnalyzeSentimentResultCollection analyzeSentimentDocumentsResults = analyzeSentimentActionsResults.FirstOrDefault().DocumentsResults;
            Assert.That(analyzeSentimentDocumentsResults, Has.Count.EqualTo(1));

            Assert.That(analyzeSentimentDocumentsResults[0].DocumentSentiment.Sentiment, Is.EqualTo(TextSentiment.Mixed));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public async Task AnalyzeOperationBatchWaitUntilStartedTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Started, batchDocuments, batchActions);
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.False);
                Assert.That(operation.HasValue, Is.False);
            });
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(operation.HasValue, Is.True);
            });
            ValidateOperationProperties(operation);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public async Task AnalyzeOperationBatchConvenienceWaitUntilStartedTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Started, batchConvenienceDocuments, batchActions);
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.False);
                Assert.That(operation.HasValue, Is.False);
            });
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(operation.HasValue, Is.True);
            });
            ValidateOperationProperties(operation);
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public async Task StartAnalyzeOperationBatchTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchDocuments, batchActions);
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.False);
                Assert.That(operation.HasValue, Is.False);
            });
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(operation.HasValue, Is.True);
            });
            ValidateOperationProperties(operation);

            // Take the first page.
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
            IReadOnlyCollection<ExtractiveSummarizeActionResult> extractiveSummarizeActionResults = resultCollection.ExtractiveSummarizeResults;

            Assert.Multiple(() =>
            {
                Assert.That(keyPhrasesActionsResults, Is.Not.Null);
                Assert.That(entitiesActionsResults, Is.Not.Null);
                Assert.That(piiActionsResults, Is.Not.Null);
                Assert.That(entityLinkingActionsResults, Is.Not.Null);
                Assert.That(analyzeSentimentActionsResults, Is.Not.Null);
                Assert.That(singleLabelClassifyResults, Is.Not.Null);
                Assert.That(multiLabelClassifyResults, Is.Not.Null);
                Assert.That(recognizeCustomEntitiesActionResults, Is.Not.Null);
                Assert.That(analyzeHealthcareEntitiesActionResults, Is.Not.Null);
                Assert.That(extractiveSummarizeActionResults, Is.Not.Null);
            });

            var keyPhrasesListId1 = new List<string> { "CEO", "SpaceX", "Elon Musk", "Tesla" };
            var keyPhrasesListId2 = new List<string> { "Tesla stock" };

            ExtractKeyPhrasesResultCollection keyPhrasesDocumentsResults = keyPhrasesActionsResults.FirstOrDefault().DocumentsResults;
            Assert.That(keyPhrasesDocumentsResults, Has.Count.EqualTo(2));

            foreach (string keyphrase in keyPhrasesDocumentsResults[0].KeyPhrases)
            {
                Assert.That(keyPhrasesListId1, Does.Contain(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesDocumentsResults[1].KeyPhrases)
            {
                Assert.That(keyPhrasesListId2, Does.Contain(keyphrase));
            }
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public async Task StartAnalyzeOperationBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchConvenienceDocuments, batchActions);
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.False);
                Assert.That(operation.HasValue, Is.False);
            });
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.GetValuesAsync()));
            await operation.WaitForCompletionAsync();
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(operation.HasValue, Is.True);
            });
            ValidateOperationProperties(operation);

            // Take the first page.
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
            IReadOnlyCollection<ExtractiveSummarizeActionResult> extractiveSummarizeActionResults = resultCollection.ExtractiveSummarizeResults;

            Assert.Multiple(() =>
            {
                Assert.That(keyPhrasesActionsResults, Is.Not.Null);
                Assert.That(entitiesActionsResults, Is.Not.Null);
                Assert.That(piiActionsResults, Is.Not.Null);
                Assert.That(entityLinkingActionsResults, Is.Not.Null);
                Assert.That(analyzeSentimentActionsResults, Is.Not.Null);
                Assert.That(singleLabelClassifyResults, Is.Not.Null);
                Assert.That(multiLabelClassifyResults, Is.Not.Null);
                Assert.That(recognizeCustomEntitiesActionResults, Is.Not.Null);
                Assert.That(analyzeHealthcareEntitiesActionResults, Is.Not.Null);
                Assert.That(extractiveSummarizeActionResults, Is.Not.Null);
            });

            var keyPhrasesListId1 = new List<string> { "CEO", "SpaceX", "Elon Musk", "Tesla" };
            var keyPhrasesListId2 = new List<string> { "Tesla stock" };

            ExtractKeyPhrasesResultCollection keyPhrasesDocumentsResults = keyPhrasesActionsResults.FirstOrDefault().DocumentsResults;
            Assert.That(keyPhrasesDocumentsResults, Has.Count.EqualTo(2));

            foreach (string keyphrase in keyPhrasesDocumentsResults[0].KeyPhrases)
            {
                Assert.That(keyPhrasesListId1, Does.Contain(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesDocumentsResults[1].KeyPhrases)
            {
                Assert.That(keyPhrasesListId2, Does.Contain(keyphrase));
            }
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            AnalyzeActionsOperation operation = await client.AnalyzeActionsAsync(WaitUntil.Completed, documents, batchActions);

            // Take the first page.
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizePiiEntitiesActionResult> recognizePiiEntitiesActionResults = resultCollection.RecognizePiiEntitiesResults;
            Assert.That(recognizePiiEntitiesActionResults, Has.Some.Matches<RecognizePiiEntitiesActionResult>(result => result.DocumentsResults.SelectMany(doc => doc.Entities).Any(e => e.Category == PiiEntityCategory.Person && e.Text == "Jane Doe")));

            IReadOnlyCollection<AnalyzeHealthcareEntitiesActionResult> analyzeHealthcareEntitiesActionResults = resultCollection.AnalyzeHealthcareEntitiesResults;
            Assert.That(analyzeHealthcareEntitiesActionResults, Has.Some.Matches<AnalyzeHealthcareEntitiesActionResult>(result => result.DocumentsResults.SelectMany(doc => doc.Entities).Any(e => e.Category == HealthcareEntityCategory.Dosage && e.Text == "100mg")));

            Assert.That(analyzeHealthcareEntitiesActionResults, Has.Some.Matches<AnalyzeHealthcareEntitiesActionResult>(result => result.DocumentsResults.SelectMany(doc => doc.Entities).Any(e => e.Category == HealthcareEntityCategory.MedicationName && e.Text == "ibuprofen")));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeActionsAsync(WaitUntil.Completed, batchDocuments, batchActions));
            Assert.That(ex.Message, Is.EqualTo("AnalyzeHealthcareEntitiesAction is not available in API version v3.1. Use service API version 2022-05-01 or newer."));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeActionsAsync(WaitUntil.Completed, batchDocuments, batchActions));
            Assert.That(ex.Message, Is.EqualTo("RecognizeCustomEntitiesAction is not available in API version v3.1. Use service API version 2022-05-01 or newer."));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeActionsAsync(WaitUntil.Completed, batchDocuments, batchActions));
            Assert.That(ex.Message, Is.EqualTo("SingleLabelClassifyAction is not available in API version v3.1. Use service API version 2022-05-01 or newer."));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
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

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeActionsAsync(WaitUntil.Completed, batchDocuments, batchActions));
            Assert.That(ex.Message, Is.EqualTo("MultiLabelClassifyAction is not available in API version v3.1. Use service API version 2022-05-01 or newer."));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public void AnalyzeOperationExtractiveSummarizeActionNotSupported()
        {
            TestDiagnostics = false;
            TextAnalyticsClient client = GetClient();
            TextAnalyticsActions batchActions = new()
            {
                ExtractiveSummarizeActions = new[]
                {
                    new ExtractiveSummarizeAction(),
                },
            };

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeActionsAsync(WaitUntil.Completed, batchDocuments, batchActions));
            Assert.That(ex.Message, Does.EndWith("Use service API version 2023-04-01 or newer."));
        }

        [RecordedTest]
        [RetryOnInternalServerError]
        [ServiceVersion(Max = TextAnalyticsClientOptions.ServiceVersion.V2022_05_01)]
        public void AnalyzeOperationAbstractiveSummarizeActionNotSupported()
        {
            TestDiagnostics = false;
            TextAnalyticsClient client = GetClient();
            TextAnalyticsActions batchActions = new()
            {
                AbstractiveSummarizeActions = new[]
                {
                    new AbstractiveSummarizeAction(),
                },
            };

            NotSupportedException ex = Assert.ThrowsAsync<NotSupportedException>(async () => await client.AnalyzeActionsAsync(WaitUntil.Completed, batchDocuments, batchActions));
            Assert.That(ex.Message, Does.EndWith("Use service API version 2023-04-01 or newer."));
        }

        private void ValidateOperationProperties(AnalyzeActionsOperation operation)
        {
            Assert.Multiple(() =>
            {
                Assert.That(operation.HasCompleted, Is.True);
                Assert.That(operation.CreatedOn, Is.Not.EqualTo(new DateTimeOffset()));
            });
            // TODO: Re-enable this check (https://github.com/Azure/azure-sdk-for-net/issues/31855).
            // Assert.AreNotEqual(new DateTimeOffset(), operation.LastModified);

            if (operation.ExpiresOn.HasValue)
            {
                Assert.That(operation.ExpiresOn.Value, Is.Not.EqualTo(new DateTimeOffset()));
            }
        }
    }
}
