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
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(batchDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesResult = resultCollection.RecognizeEntitiesActionsResults;

            ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.ExtractKeyPhrasesActionsResults.ElementAt(0).Result;

            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiResult = resultCollection.RecognizePiiEntitiesActionsResults;

            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> elResult = resultCollection.RecognizeLinkedEntitiesActionsResults;

            Assert.IsNotNull(keyPhrasesResult);
            Assert.IsNotNull(entitiesResult);
            Assert.IsNotNull(piiResult);
            Assert.IsNotNull(elResult);

            Assert.AreEqual(2, keyPhrasesResult.Count);
        }

        [RecordedTest]
        public async Task AnalyzeOperationTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(batchConvenienceDocuments, batchActions, "en");

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            IReadOnlyCollection<RecognizeEntitiesActionResult> entitiesResult = resultCollection.RecognizeEntitiesActionsResults;

            IReadOnlyCollection<ExtractKeyPhrasesActionResult> keyPhrasesResult = resultCollection.ExtractKeyPhrasesActionsResults;

            IReadOnlyCollection<RecognizePiiEntitiesActionResult> piiResult = resultCollection.RecognizePiiEntitiesActionsResults;

            IReadOnlyCollection<RecognizeLinkedEntitiesActionResult> elResult = resultCollection.RecognizeLinkedEntitiesActionsResults;

            Assert.IsNotNull(keyPhrasesResult);
            Assert.IsNotNull(entitiesResult);
            Assert.IsNotNull(piiResult);
            Assert.IsNotNull(elResult);

            var keyPhrasesListId1 = new List<string> { "CEO of SpaceX", "Elon Musk", "Tesla" };
            var keyPhrasesListId2 = new List<string> { "Tesla stock", "year" };

            var keyPhrases = keyPhrasesResult.FirstOrDefault().Result;
            Assert.AreEqual(2, keyPhrases.Count);

            foreach (string keyphrase in keyPhrases[0].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId1.Contains(keyphrase));
            }

            foreach (string keyphrase in keyPhrases[1].KeyPhrases)
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
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
                DisplayName = "AnalyzeOperationWithLanguageTest"
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(batchDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.ExtractKeyPhrasesActionsResults.ElementAt(0).Result;

            Assert.IsNotNull(keyPhrasesResult);

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
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
                RecognizeEntitiesOptions = new List<RecognizeEntitiesOptions>() { new RecognizeEntitiesOptions() },
                RecognizePiiEntitiesOptions = new List<RecognizePiiEntitiesOptions>() { new RecognizePiiEntitiesOptions() },
                RecognizeLinkedEntitiesOptions = new List<RecognizeLinkedEntitiesOptions>() { new RecognizeLinkedEntitiesOptions() },
                DisplayName = "AnalyzeOperationWithMultipleTasks"
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(batchDocuments, batchActions);

            Assert.AreEqual(0, operation.ActionsFailed);
            Assert.AreEqual(0, operation.ActionsSucceeded);
            Assert.AreEqual(0, operation.ActionsInProgress);
            Assert.AreEqual(0, operation.ActionsTotal);

            await operation.WaitForCompletionAsync();

            Assert.AreEqual(0, operation.ActionsFailed);
            Assert.AreEqual(4, operation.ActionsSucceeded);
            Assert.AreEqual(0, operation.ActionsInProgress);
            Assert.AreEqual(4, operation.ActionsTotal);
            Assert.AreNotEqual(new DateTimeOffset(), operation.CreatedOn);
            Assert.AreNotEqual(new DateTimeOffset(), operation.LastModified);
            Assert.AreNotEqual(new DateTimeOffset(), operation.ExpiresOn);

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            RecognizeEntitiesResultCollection entitiesResult = resultCollection.RecognizeEntitiesActionsResults.ElementAt(0).Result;

            ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.ExtractKeyPhrasesActionsResults.ElementAt(0).Result;

            RecognizePiiEntitiesResultCollection piiResult = resultCollection.RecognizePiiEntitiesActionsResults.ElementAt(0).Result;

            RecognizeLinkedEntitiesResultCollection entityLinkingResult = resultCollection.RecognizeLinkedEntitiesActionsResults.ElementAt(0).Result;

            Assert.IsNotNull(keyPhrasesResult);
            Assert.IsNotNull(entitiesResult);
            Assert.IsNotNull(piiResult);
            Assert.IsNotNull(entityLinkingResult);
            Assert.AreEqual("AnalyzeOperationWithMultipleTasks", operation.DisplayName);

            // Keyphrases
            Assert.AreEqual(2, keyPhrasesResult.Count);

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

            // Entities
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

            Assert.AreEqual(2, entitiesResult.Count);

            Assert.AreEqual(3, entitiesResult[0].Entities.Count);
            Assert.IsNotNull(entitiesResult[0].Id);
            Assert.IsNotNull(entitiesResult[0].Entities);
            Assert.IsNotNull(entitiesResult[0].Error);

            // Entity Linking

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
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
                DisplayName = "AnalyzeOperationWithPagination",
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(documents, batchActions);

            Assert.IsFalse(operation.HasCompleted);
            Assert.IsFalse(operation.HasValue);

            Assert.ThrowsAsync<InvalidOperationException>(async () => await Task.Run(() => operation.Value));
            Assert.Throws<InvalidOperationException>(() => operation.GetValues());

            await operation.WaitForCompletionAsync();

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            // try async
            //There most be 2 pages as service limit is 20 documents per page
            List<AnalyzeBatchActionsResult> asyncPages = operation.Value.ToEnumerableAsync().Result;
            Assert.AreEqual(2, asyncPages.Count);

            // First page should have 20 results
            Assert.AreEqual(20, asyncPages[0].ExtractKeyPhrasesActionsResults.FirstOrDefault().Result.Count);

            // Second page should have remaining 3 results
            Assert.AreEqual(3, asyncPages[1].ExtractKeyPhrasesActionsResults.FirstOrDefault().Result.Count);

            // try sync
            //There most be 2 pages as service limit is 20 documents per page
            List<AnalyzeBatchActionsResult> pages = operation.GetValues().AsEnumerable().ToList();
            Assert.AreEqual(2, pages.Count);

            // First page should have 20 results
            Assert.AreEqual(20, pages[0].ExtractKeyPhrasesActionsResults.FirstOrDefault().Result.Count);

            // Second page should have remaining 3 results
            Assert.AreEqual(3, pages[1].ExtractKeyPhrasesActionsResults.FirstOrDefault().Result.Count);
        }

        [RecordedTest]
        public void AnalyzeOperationBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily"
            };
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>()
                {
                    new ExtractKeyPhrasesOptions(),
                    new ExtractKeyPhrasesOptions()
                    {
                        ModelVersion = "InvalidVersion"
                    }
                },

                DisplayName = "AnalyzeOperationBatchWithErrorTest",
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () => await client.StartAnalyzeBatchActionsAsync(documents, batchActions));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidRequest, ex.ErrorCode);
        }

        [RecordedTest]
        public async Task AnalyzeOperationBatchWithErrorsInDocumentTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "",
            };
            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>()
                {
                    new ExtractKeyPhrasesOptions()
                }
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(documents, batchActions, "en");
            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            //Key phrases
            var keyPhrasesActions = resultCollection.ExtractKeyPhrasesActionsResults.ToList();

            Assert.AreEqual(1, keyPhrasesActions.Count);

            var results = keyPhrasesActions[0].Result;
            Assert.IsFalse(results[0].HasError);
            Assert.IsTrue(results[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, results[1].Error.ErrorCode.ToString());
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/20984")]
        public async Task AnalyzeOperationBatchWithPHIDomain()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "A patient with medical id 12345678 whose phone number is 800-102-1100 is going under heart surgery",
            };

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                RecognizePiiEntitiesOptions = new List<RecognizePiiEntitiesOptions>() { new RecognizePiiEntitiesOptions() { DomainFilter = PiiEntityDomainType.ProtectedHealthInformation } },
                DisplayName = "AnalyzeOperationWithPHIDomain",
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(documents, batchActions, "en");

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            RecognizePiiEntitiesResultCollection result = resultCollection.RecognizePiiEntitiesActionsResults.ElementAt(0).Result;

            Assert.IsNotNull(result);

            Assert.AreEqual(1, result.Count);

            Assert.IsNotEmpty(result[0].Entities.RedactedText);

            Assert.IsFalse(result[0].HasError);
            Assert.AreEqual(2, result[0].Entities.Count);
        }

        [RecordedTest]
        public async Task AnalyzeOperationBatchWithStatisticsTest()
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
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
                DisplayName = "AnalyzeOperationTest",
            };

            AnalyzeBatchActionsOptions options = new AnalyzeBatchActionsOptions()
            {
                IncludeStatistics = true
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(batchDocuments, batchActions, options);

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

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
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() { DisableServiceLogs = true } },
                RecognizeEntitiesOptions = new List<RecognizeEntitiesOptions>() { new RecognizeEntitiesOptions() { DisableServiceLogs = true } },
                RecognizePiiEntitiesOptions = new List<RecognizePiiEntitiesOptions>() { new RecognizePiiEntitiesOptions() { DisableServiceLogs = false } },
                RecognizeLinkedEntitiesOptions = new List<RecognizeLinkedEntitiesOptions>() { new RecognizeLinkedEntitiesOptions() { DisableServiceLogs = true } },
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(batchConvenienceDocuments, batchActions);

            await operation.WaitForCompletionAsync();

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.ExtractKeyPhrasesActionsResults.FirstOrDefault().Result;
            RecognizeEntitiesResultCollection entitiesResult = resultCollection.RecognizeEntitiesActionsResults.FirstOrDefault().Result;
            RecognizePiiEntitiesResultCollection piiResult = resultCollection.RecognizePiiEntitiesActionsResults.FirstOrDefault().Result;
            RecognizeLinkedEntitiesResultCollection entityLinkingResult = resultCollection.RecognizeLinkedEntitiesActionsResults.FirstOrDefault().Result;

            Assert.IsNotNull(keyPhrasesResult);
            Assert.AreEqual(2, keyPhrasesResult.Count);

            Assert.IsNotNull(entitiesResult);
            Assert.AreEqual(2, keyPhrasesResult.Count);

            Assert.IsNotNull(piiResult);
            Assert.AreEqual(2, keyPhrasesResult.Count);

            Assert.IsNotNull(entityLinkingResult);
            Assert.AreEqual(2, keyPhrasesResult.Count);
        }
    }
}
