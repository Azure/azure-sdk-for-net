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

        [Test]
        public async Task AnalyzeOperationWithAADTest()
        {
            TextAnalyticsClient client = GetClient(useTokenCredential: true);

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(batchDocuments, batchActions);

            await operation.WaitForCompletionAsync(PollingInterval);

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

        [Test]
        public async Task AnalyzeOperationTest()
        {
            TextAnalyticsClient client = GetClient();

            TextAnalyticsActions batchActions = new TextAnalyticsActions()
            {
                ExtractKeyPhrasesOptions = new List<ExtractKeyPhrasesOptions>() { new ExtractKeyPhrasesOptions() },
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(batchConvenienceDocuments, batchActions, "en");

            await operation.WaitForCompletionAsync(PollingInterval);

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

            var keyPhrasesListId1 = new List<string> { "CEO of SpaceX", "Elon Musk", "Tesla" };
            var keyPhrasesListId2 = new List<string> { "Tesla stock", "year" };

            foreach (string keyphrase in keyPhrasesResult[0].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId1.Contains(keyphrase));
            }

            foreach (string keyphrase in keyPhrasesResult[1].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId2.Contains(keyphrase));
            }
        }

        [Test]
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

            await operation.WaitForCompletionAsync(PollingInterval);

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

        [Test]
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
            Assert.AreEqual(0, operation.TotalActions);

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.AreEqual(0, operation.ActionsFailed);
            Assert.AreEqual(4, operation.ActionsSucceeded);
            Assert.AreEqual(0, operation.ActionsInProgress);
            Assert.AreEqual(4, operation.TotalActions);
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

        [Test]
        public async Task AnalyzeOperationWithPagination()
        {
            TextAnalyticsClient client = GetClient();

            List<string> documents = new ();

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

            await operation.WaitForCompletionAsync(PollingInterval);

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            await operation.WaitForCompletionAsync(PollingInterval);

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

        [Test]
        public async Task AnalyzeOperationBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure.",
                "",
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
                RecognizeEntitiesOptions = new List<RecognizeEntitiesOptions>()
                {
                    new RecognizeEntitiesOptions(),
                    new RecognizeEntitiesOptions()
                    {
                        ModelVersion = "InvalidVersion"
                    }
                },
                RecognizePiiEntitiesOptions = new List<RecognizePiiEntitiesOptions>()
                {
                    new RecognizePiiEntitiesOptions(),
                    new RecognizePiiEntitiesOptions()
                    {
                        ModelVersion = "InvalidVersion"
                    }
                },
                RecognizeLinkedEntitiesOptions = new List<RecognizeLinkedEntitiesOptions>()
                {
                    new RecognizeLinkedEntitiesOptions(),
                    new RecognizeLinkedEntitiesOptions()
                    {
                        ModelVersion = "InvalidVersion"
                    }
                },

                DisplayName = "AnalyzeOperationBatchWithErrorTest",
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(documents, batchActions, "en");

            await operation.WaitForCompletionAsync(PollingInterval);

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            //Key phrases
            var keyPhrasesActions = resultCollection.ExtractKeyPhrasesActionsResults.ToList();

            Assert.IsFalse(keyPhrasesActions[0].HasError);
            Assert.AreEqual(3, keyPhrasesActions[0].Result.Count);
            var kpEmptyDocument = keyPhrasesActions[0].Result.ElementAt(2);
            Assert.IsTrue(kpEmptyDocument.HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, kpEmptyDocument.Error.ErrorCode.ToString());

            Assert.IsTrue(keyPhrasesActions[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidRequest, keyPhrasesActions[1].Error.ErrorCode.ToString());

            // Entities
            var entitiesActions = resultCollection.RecognizeEntitiesActionsResults.ToList();

            Assert.IsFalse(entitiesActions[0].HasError);
            Assert.AreEqual(3, entitiesActions[0].Result.Count);
            var entitiesEmptyDocument = entitiesActions[0].Result.ElementAt(2);
            Assert.IsTrue(entitiesEmptyDocument.HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, entitiesEmptyDocument.Error.ErrorCode.ToString());

            Assert.IsTrue(entitiesActions[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidRequest, entitiesActions[1].Error.ErrorCode.ToString());

            // PII entities
            var piiEntitiesActions = resultCollection.RecognizePiiEntitiesActionsResults.ToList();

            Assert.IsFalse(piiEntitiesActions[0].HasError);
            Assert.AreEqual(3, piiEntitiesActions[0].Result.Count);
            var piiEntitiesEmptyDocument = piiEntitiesActions[0].Result.ElementAt(2);
            Assert.IsTrue(piiEntitiesEmptyDocument.HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, piiEntitiesEmptyDocument.Error.ErrorCode.ToString());

            Assert.IsTrue(piiEntitiesActions[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidRequest, piiEntitiesActions[1].Error.ErrorCode.ToString());

            // Entity Linking

            var linkedEntitiesActions = resultCollection.RecognizeLinkedEntitiesActionsResults.ToList();

            Assert.IsFalse(linkedEntitiesActions[0].HasError);
            Assert.AreEqual(3, linkedEntitiesActions[0].Result.Count);
            var linkedEntitiesEmptyDocument = linkedEntitiesActions[0].Result.ElementAt(2);
            Assert.IsTrue(linkedEntitiesEmptyDocument.HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocument, linkedEntitiesEmptyDocument.Error.ErrorCode.ToString());

            Assert.IsTrue(linkedEntitiesActions[1].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidRequest, linkedEntitiesActions[1].Error.ErrorCode.ToString());
        }

        [Test]
        public async Task AnalyzeOperationBatchWithAllErrorsTest()
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
                    {
                        ModelVersion = "InvalidVersion"
                    }
                }
            };

            AnalyzeBatchActionsOperation operation = await client.StartAnalyzeBatchActionsAsync(documents, batchActions, "en");
            await operation.WaitForCompletionAsync(PollingInterval);

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            //Key phrases
            var keyPhrasesActions = resultCollection.ExtractKeyPhrasesActionsResults.ToList();

            Assert.AreEqual(1, keyPhrasesActions.Count);
            Assert.IsTrue(keyPhrasesActions[0].HasError);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidRequest, keyPhrasesActions[0].Error.ErrorCode.ToString());
        }

        [Test]
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

            await operation.WaitForCompletionAsync(PollingInterval);

            //Take the first page
            AnalyzeBatchActionsResult resultCollection = operation.Value.ToEnumerableAsync().Result.FirstOrDefault();

            RecognizePiiEntitiesResultCollection result = resultCollection.RecognizePiiEntitiesActionsResults.ElementAt(0).Result;

            Assert.IsNotNull(result);

            Assert.AreEqual(1, result.Count);

            Assert.IsNotEmpty(result[0].Entities.RedactedText);

            Assert.IsFalse(result[0].HasError);
            Assert.AreEqual(2, result[0].Entities.Count);
        }

        [Test]
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

            await operation.WaitForCompletionAsync(PollingInterval);

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
    }
}
