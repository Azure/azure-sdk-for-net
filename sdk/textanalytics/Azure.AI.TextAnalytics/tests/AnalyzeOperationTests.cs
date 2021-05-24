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
    public class AnalyzeOperationTests : TextAnalyticsClientLiveTestBase
    {
        public AnalyzeOperationTests(bool isAsync) : base(isAsync) { }

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

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesActionsResults;

            Assert.IsNotNull(keyPhrasesActionsResults);
            Assert.AreEqual(2, keyPhrasesActionsResults.FirstOrDefault().Result.Count);
        }

        [RecordedTest]
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

            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesActionsResults = resultCollection.RecognizeEntitiesActionsResults;
            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesActionsResults;
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesActionsResults;
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesActionsResults;
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentActionsResults;

            Assert.IsNotNull(keyPhrasesActionsResults);
            Assert.IsNotNull(entitiesActionsResults);
            Assert.IsNotNull(piiActionsResults);
            Assert.IsNotNull(entityLinkingActionsResults);
            Assert.IsNotNull(analyzeSentimentActionsResults);

            var keyPhrasesListId1 = new List<string> { "CEO of SpaceX", "Elon Musk", "Tesla" };
            var keyPhrasesListId2 = new List<string> { "Tesla stock", "year" };

            ExtractKeyPhrasesResultCollection keyPhrasesResult = keyPhrasesActionsResults.FirstOrDefault().Result;
            Assert.AreEqual(2, keyPhrasesResult.Count);

            foreach (string keyphrase in keyPhrasesResult[0].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId1.Contains(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesResult[1].KeyPhrases)
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

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesActionsResults;

            Assert.IsNotNull(keyPhrasesActionsResults);

            ExtractKeyPhrasesResultCollection keyPhrasesResult = keyPhrasesActionsResults.FirstOrDefault().Result;
            Assert.AreEqual(2, keyPhrasesResult.Count);

            Assert.AreEqual("AnalyzeOperationWithLanguageTest", operation.DisplayName);

            var keyPhrasesListId1 = new List<string> { "Bill Gates", "Paul Allen", "Microsoft" };
            var keyPhrasesListId2 = new List<string> { "gato", "perro", "veterinario" };

            foreach (string keyphrase in keyPhrasesResult[0].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId1.Contains(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesResult[1].KeyPhrases)
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
            Assert.AreNotEqual(new DateTimeOffset(), operation.CreatedOn);
            Assert.AreNotEqual(new DateTimeOffset(), operation.LastModified);
            Assert.AreNotEqual(new DateTimeOffset(), operation.ExpiresOn);

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesActionsResults = resultCollection.RecognizeEntitiesActionsResults;
            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesActionsResults;
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesActionsResults;
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesActionsResults;
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentActionsResults;

            Assert.IsNotNull(keyPhrasesActionsResults);
            Assert.IsNotNull(entitiesActionsResults);
            Assert.IsNotNull(piiActionsResults);
            Assert.IsNotNull(entityLinkingActionsResults);
            Assert.AreEqual("AnalyzeOperationWithMultipleTasks", operation.DisplayName);

            // Keyphrases
            ExtractKeyPhrasesResultCollection keyPhrasesResults = keyPhrasesActionsResults.FirstOrDefault().Result;
            Assert.AreEqual(2, keyPhrasesResults.Count);

            var keyPhrasesListId1 = new List<string> { "Bill Gates", "Paul Allen", "Microsoft" };
            var keyPhrasesListId2 = new List<string> { "gato", "perro", "veterinario" };

            foreach (string keyphrase in keyPhrasesResults[0].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId1.Contains(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesResults[1].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId2.Contains(keyphrase));
            }

            // Entities
            RecognizeEntitiesResultCollection entitiesResult = entitiesActionsResults.FirstOrDefault().Result;
            Assert.AreEqual(2, entitiesResult.Count);

            Assert.AreEqual(3, entitiesResult[0].Entities.Count);

            var entitiesList = new List<string> { "Bill Gates", "Microsoft", "Paul Allen" };
            foreach (CategorizedEntity entity in entitiesResult[0].Entities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Text));
                Assert.IsNotNull(entity.Category);
                Assert.IsNotNull(entity.Offset);
                Assert.IsNotNull(entity.ConfidenceScore);
            }

            // PII
            RecognizePiiEntitiesResultCollection piiResult = piiActionsResults.FirstOrDefault().Result;
            Assert.AreEqual(2, piiResult.Count);

            Assert.AreEqual(3, piiResult[0].Entities.Count);
            Assert.IsNotNull(piiResult[0].Id);
            Assert.IsNotNull(piiResult[0].Entities);
            Assert.IsNotNull(piiResult[0].Error);

            // Entity Linking
            RecognizeLinkedEntitiesResultCollection entityLinkingResult = entityLinkingActionsResults.FirstOrDefault().Result;
            Assert.AreEqual(2, entityLinkingResult.Count);

            Assert.AreEqual(3, entityLinkingResult[0].Entities.Count);
            Assert.IsNotNull(entityLinkingResult[0].Id);
            Assert.IsNotNull(entityLinkingResult[0].Entities);
            Assert.IsNotNull(entityLinkingResult[0].Error);

            foreach (LinkedEntity entity in entityLinkingResult[0].Entities)
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
            AnalyzeSentimentResultCollection analyzeSentimentResult = analyzeSentimentActionsResults.FirstOrDefault().Result;
            Assert.AreEqual(2, analyzeSentimentResult.Count);

            Assert.AreEqual(TextSentiment.Neutral, analyzeSentimentResult[0].DocumentSentiment.Sentiment);
            Assert.AreEqual(TextSentiment.Neutral, analyzeSentimentResult[1].DocumentSentiment.Sentiment);
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
            Assert.Throws<InvalidOperationException>(() => operation.GetValues());

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            // try async
            //There most be 2 pages as service limit is 20 documents per page
            List<AnalyzeActionsResult> asyncPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(2, asyncPages.Count);

            // First page should have 20 results
            Assert.AreEqual(20, asyncPages[0].ExtractKeyPhrasesActionsResults.FirstOrDefault().Result.Count);

            // Second page should have remaining 3 results
            Assert.AreEqual(3, asyncPages[1].ExtractKeyPhrasesActionsResults.FirstOrDefault().Result.Count);

            // try sync
            //There most be 2 pages as service limit is 20 documents per page
            List<AnalyzeActionsResult> pages = operation.GetValues().AsEnumerable().ToList();
            Assert.AreEqual(2, pages.Count);

            // First page should have 20 results
            Assert.AreEqual(20, pages[0].ExtractKeyPhrasesActionsResults.FirstOrDefault().Result.Count);

            // Second page should have remaining 3 results
            Assert.AreEqual(3, pages[1].ExtractKeyPhrasesActionsResults.FirstOrDefault().Result.Count);
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
                    new ExtractKeyPhrasesAction(),
                    new ExtractKeyPhrasesAction()
                    {
                        ModelVersion = "InvalidVersion"
                    }
                },

                DisplayName = "AnalyzeOperationBatchWithErrorTest",
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartAnalyzeActionsAsync(documents, batchActions));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidRequest, ex.ErrorCode);
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
            List<ExtractKeyPhrasesActionResult> keyPhrasesActions = resultCollection.ExtractKeyPhrasesActionsResults.ToList();

            Assert.AreEqual(1, keyPhrasesActions.Count);

            ExtractKeyPhrasesResultCollection results = keyPhrasesActions[0].Result;
            Assert.IsFalse(results[0].HasError);
            Assert.IsTrue(results[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, results[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/20984")]
        public async Task AnalyzeOperationWithPHIDomain()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "A patient with medical id 12345678 whose phone number is 800-102-1100 is going under heart surgery",
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { new RecognizePiiEntitiesAction() { DomainFilter = PiiEntityDomainType.ProtectedHealthInformation } },
                DisplayName = "AnalyzeOperationWithPHIDomain",
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(documents, batchActions, "en");

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesActionsResults;

            Assert.IsNotNull(piiActionsResults);

            RecognizePiiEntitiesResultCollection piiResult = piiActionsResults.FirstOrDefault().Result;
            Assert.AreEqual(1, piiResult.Count);

            Assert.IsNotEmpty(piiResult[0].Entities.RedactedText);

            Assert.IsFalse(piiResult[0].HasError);
            Assert.AreEqual(2, piiResult[0].Entities.Count);
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

            ExtractKeyPhrasesResultCollection result = resultCollection.ExtractKeyPhrasesActionsResults.ElementAt(0).Result;

            Assert.IsNotNull(result);

            Assert.AreEqual(3, result.Count);

            Assert.AreEqual(3, result.Statistics.DocumentCount);
            Assert.AreEqual(2, result.Statistics.TransactionCount);
            Assert.AreEqual(2, result.Statistics.ValidDocumentCount);
            Assert.AreEqual(1, result.Statistics.InvalidDocumentCount);

            Assert.AreEqual(51, result[0].Statistics.CharacterCount);
            Assert.AreEqual(1, result[0].Statistics.TransactionCount);
        }

        [RecordedTest]
        public async Task AnalyzeOperationAllActionsAndDisableServiceLogs ()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesActions = new List<ExtractKeyPhrasesAction>() { new ExtractKeyPhrasesAction() { DisableServiceLogs = true } },
                RecognizeEntitiesActions = new List<RecognizeEntitiesAction>() { new RecognizeEntitiesAction() { DisableServiceLogs = true } },
                RecognizePiiEntitiesActions = new List<RecognizePiiEntitiesAction>() { new RecognizePiiEntitiesAction() { DisableServiceLogs = false } },
                RecognizeLinkedEntitiesActions = new List<RecognizeLinkedEntitiesAction>() { new RecognizeLinkedEntitiesAction() { DisableServiceLogs = true } },
                AnalyzeSentimentActions = new List<AnalyzeSentimentAction>() { new AnalyzeSentimentAction() { DisableServiceLogs = true } },
            };

            AnalyzeActionsOperation operation = await client.StartAnalyzeActionsAsync(batchConvenienceDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesActionsResults = resultCollection.ExtractKeyPhrasesActionsResults;
            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesActionsResults = resultCollection.RecognizeEntitiesActionsResults;
            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiActionsResults = resultCollection.RecognizePiiEntitiesActionsResults;
            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> entityLinkingActionsResults = resultCollection.RecognizeLinkedEntitiesActionsResults;
            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentActionsResults;

            Assert.IsNotNull(keyPhrasesActionsResults);
            Assert.AreEqual(2, keyPhrasesActionsResults.FirstOrDefault().Result.Count);

            Assert.IsNotNull(entitiesActionsResults);
            Assert.AreEqual(2, entitiesActionsResults.FirstOrDefault().Result.Count);

            Assert.IsNotNull(piiActionsResults);
            Assert.AreEqual(2, piiActionsResults.FirstOrDefault().Result.Count);

            Assert.IsNotNull(entityLinkingActionsResults);
            Assert.AreEqual(2, entityLinkingActionsResults.FirstOrDefault().Result.Count);

            Assert.IsNotNull(analyzeSentimentActionsResults);
            Assert.AreEqual(2, analyzeSentimentActionsResults.FirstOrDefault().Result.Count);
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

            IReadOnlyCollection<AnalyzeSentimentActionResult> analyzeSentimentActionsResults = resultCollection.AnalyzeSentimentActionsResults;

            Assert.IsNotNull(analyzeSentimentActionsResults);

            AnalyzeSentimentResultCollection analyzeSentimentResult = analyzeSentimentActionsResults.FirstOrDefault().Result;
            Assert.AreEqual(1, analyzeSentimentResult.Count);

            Assert.AreEqual(TextSentiment.Mixed, analyzeSentimentResult[0].DocumentSentiment.Sentiment);
        }
    }
}
