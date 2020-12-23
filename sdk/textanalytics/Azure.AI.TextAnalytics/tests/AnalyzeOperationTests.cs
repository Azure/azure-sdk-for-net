// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Models;
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

            AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
            {
                KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
            };

            AnalyzeOperation operation = await client.StartAnalyzeOperationBatchAsync(batchConvenienceDocuments, operationOptions);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeOperationResult resultCollection = operation.Value;

            IReadOnlyList<EntityRecognitionTasksItem> entityRecognitionTasksItemCollection = resultCollection.Tasks.EntityRecognitionTasks;
            IReadOnlyList<EntityRecognitionPiiTasksItem> entityRecognitionPiiTasksItemCollection = resultCollection.Tasks.EntityRecognitionPiiTasks;
            ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

            Assert.IsNotNull(keyPhrasesResult);
            Assert.IsNotNull(entityRecognitionTasksItemCollection);
            Assert.IsNotNull(entityRecognitionPiiTasksItemCollection);

            Assert.AreEqual(2, keyPhrasesResult.Count);
        }

        [Test]
        public async Task AnalyzeOperationTest()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
            {
                KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
            };

            AnalyzeOperation operation = await client.StartAnalyzeOperationBatchAsync(batchConvenienceDocuments, operationOptions, "en");

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeOperationResult resultCollection = operation.Value;

            IReadOnlyList<EntityRecognitionTasksItem> entityRecognitionTasksItemCollection = resultCollection.Tasks.EntityRecognitionTasks;
            IReadOnlyList<EntityRecognitionPiiTasksItem> entityRecognitionPiiTasksItemCollection = resultCollection.Tasks.EntityRecognitionPiiTasks;

            ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

            Assert.IsNotNull(keyPhrasesResult);
            Assert.IsNotNull(entityRecognitionTasksItemCollection);
            Assert.IsNotNull(entityRecognitionPiiTasksItemCollection);

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

            AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
                {
                KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
                DisplayName = "AnalyzeOperationWithLanguageTest"
            };

            AnalyzeOperation operation = await client.StartAnalyzeOperationBatchAsync(batchDocuments, operationOptions);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeOperationResult resultCollection = operation.Value;

            ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

            Assert.IsNotNull(keyPhrasesResult);

            Assert.AreEqual(2, keyPhrasesResult.Count);

            Assert.AreEqual("AnalyzeOperationWithLanguageTest", resultCollection.DisplayName);

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
        public async Task AnalyzeOperationWithMultipleTasks()
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

            AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
            {
                KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
                EntitiesTaskParameters = new EntitiesTaskParameters(),
                PiiTaskParameters = new PiiTaskParameters(),
                DisplayName = "AnalyzeOperationWithMultipleTasks"
            };

            AnalyzeOperation operation = await client.StartAnalyzeOperationBatchAsync(batchDocuments, operationOptions);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeOperationResult resultCollection = operation.Value;

            RecognizeEntitiesResultCollection entitiesResult = resultCollection.Tasks.EntityRecognitionTasks[0].Results;

            ExtractKeyPhrasesResultCollection keyPhrasesResult = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

            RecognizePiiEntitiesResultCollection piiResult = resultCollection.Tasks.EntityRecognitionPiiTasks[0].Results;

            Assert.IsNotNull(keyPhrasesResult);
            Assert.IsNotNull(entitiesResult);
            Assert.IsNotNull(piiResult);
            Assert.AreEqual("AnalyzeOperationWithMultipleTasks", resultCollection.DisplayName);

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
        }

        [Test]
        [Ignore("Will add this once the pagination is implemented for AnalyzeOperation - https://github.com/Azure/azure-sdk-for-net/issues/16958")]
        public async Task AnalyzeOperationWithSkipParameter()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
            {
                KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
                DisplayName = "AnalyzeOperationWithSkipParameter",
                //Skip = 1
            };

            AnalyzeOperation operation = await client.StartAnalyzeOperationBatchAsync(batchConvenienceDocuments, operationOptions, "en");

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeOperationResult resultCollection = operation.Value;

            ExtractKeyPhrasesResultCollection result = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

            Assert.IsNotNull(result);

            Assert.AreEqual(1, result.Count);

            var keyPhrasesListId2 = new List<string> { "Tesla stock", "year" };

            foreach (string keyphrase in result[0].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId2.Contains(keyphrase));
            }
        }

        [Test]
        [Ignore("Will add this once the pagination is implemented for AnalyzeOperation - https://github.com/Azure/azure-sdk-for-net/issues/16958")]
        public async Task AnalyzeOperationWithTopParameter()
        {
            TextAnalyticsClient client = GetClient();

            AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
            {
                KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
                DisplayName = "AnalyzeOperationWithSkipParameter",
                //Top = 1
            };

            AnalyzeOperation operation = await client.StartAnalyzeOperationBatchAsync(batchConvenienceDocuments, operationOptions, "en");

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeOperationResult resultCollection = operation.Value;

            ExtractKeyPhrasesResultCollection result = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

            Assert.IsNotNull(result);

            Assert.AreEqual(1, result.Count);

            var keyPhrasesListId1 = new List<string> { "CEO of SpaceX", "Elon Musk", "Tesla" };

            foreach (string keyphrase in result[0].KeyPhrases)
            {
                Assert.IsTrue(keyPhrasesListId1.Contains(keyphrase));
            }
        }

        [Test]
        [Ignore("Will add this once the pagination is implemented for AnalyzeOperation - https://github.com/Azure/azure-sdk-for-net/issues/16958")]
        public async Task AnalyzeOperationBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "Subject is taking 100mg of ibuprofen twice daily",
                "Can cause rapid or irregular heartbeat, delirium, panic, psychosis, and heart failure.",
                "",
            };

            AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
            {
                KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
                DisplayName = "AnalyzeOperationBatchWithErrorTest",
                //Skip = 1
            };

            await Task.Run(() => {
                RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(async () =>
                {
                   AnalyzeOperation operation = await client.StartAnalyzeOperationBatchAsync(documents, operationOptions, "en");
                });

                Assert.IsTrue(ex.ErrorCode.Equals("InvalidArgument"));
                Assert.IsTrue(ex.Status.Equals(400));
            });
        }

        [Test]
        public async Task AnalyzeOperationBatchWithPHIDomain()
        {
            TextAnalyticsClient client = GetClient();

            var documents = new List<string>
            {
                "A patient with medical id 12345678 whose phone number is 800-102-1100 is going under heart surgery",
            };

            AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
            {
                PiiTaskParameters = new PiiTaskParameters()
                {
                    Domain = PiiTaskParametersDomain.Phi
                },
                DisplayName = "AnalyzeOperationWithPHIDomain"
            };

            AnalyzeOperation operation = await client.StartAnalyzeOperationBatchAsync(documents, operationOptions, "en");

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeOperationResult resultCollection = operation.Value;

            RecognizePiiEntitiesResultCollection result = resultCollection.Tasks.EntityRecognitionPiiTasks[0].Results;;

            Assert.IsNotNull(result);

            Assert.AreEqual(1, result.Count);

            // TODO - Update this once the service starts returning RedactedText
            //var redactedText = string.Empty;
            //Assert.AreEqual(redactedText, result[0].Entities.RedactedText);

            Assert.IsFalse(result[0].HasError);
            Assert.AreEqual(2, result[0].Entities.Count);
        }

        [Test]
        [Ignore("The statstics is not being returned from the service - https://github.com/Azure/azure-sdk-for-net/issues/16839")]
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
                }
            };

            AnalyzeOperationOptions operationOptions = new AnalyzeOperationOptions()
            {
                KeyPhrasesTaskParameters = new KeyPhrasesTaskParameters(),
                DisplayName = "AnalyzeOperationTest",
                IncludeStatistics = true
            };

            AnalyzeOperation operation = await client.StartAnalyzeOperationBatchAsync(batchDocuments, operationOptions);

            await operation.WaitForCompletionAsync(PollingInterval);

            AnalyzeOperationResult resultCollection = operation.Value;

            ExtractKeyPhrasesResultCollection result = resultCollection.Tasks.KeyPhraseExtractionTasks[0].Results;

            Assert.IsNotNull(result);

            Assert.AreEqual(2, result.Count);

            // TODO - Update this once service start returning statistics.
            // TODO - Add Other request level statistics.
            Assert.AreEqual(0, result[0].Statistics.CharacterCount);
            Assert.AreEqual(0, result[0].Statistics.TransactionCount);
        }
    }
}
