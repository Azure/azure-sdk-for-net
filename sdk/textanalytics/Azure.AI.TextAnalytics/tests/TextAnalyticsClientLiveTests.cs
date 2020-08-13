// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.TextAnalytics.Samples;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientLiveTests : RecordedTestBase<TextAnalyticsTestEnvironment>
    {
        public TextAnalyticsClientLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new TextAnalyticsRecordedTestSanitizer();
        }

        public TextAnalyticsClient GetClient(AzureKeyCredential credential = default, TextAnalyticsClientOptions options = default)
        {
            string apiKey = TestEnvironment.ApiKey;
            credential ??= new AzureKeyCredential(apiKey);
            options ??= new TextAnalyticsClientOptions();
            return InstrumentClient (
                new TextAnalyticsClient(
                    new Uri(TestEnvironment.Endpoint),
                    credential,
                    Recording.InstrumentClientOptions(options))
            );
        }

        [Test]
        public async Task DetectLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "This is written in English.";

            DetectedLanguage language = await client.DetectLanguageAsync(document);

            Assert.IsNotNull(language.Name);
            Assert.IsNotNull(language.Iso6391Name);
            Assert.Greater(language.ConfidenceScore, 0.0);
        }

        [Test]
        public async Task DetectLanguageWithCountryHintTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Este documento está en español";

            DetectedLanguage language = await client.DetectLanguageAsync(document, "CO");

            Assert.IsNotNull(language.Name);
            Assert.IsNotNull(language.Iso6391Name);
            Assert.Greater(language.ConfidenceScore, 0.0);
        }

        [Test]
        public void DetectLanguageWithErrorCountryHintTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Este documento está en español";

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => client.DetectLanguageAsync(document, "COLOMBIA"));
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidCountryHint, ex.ErrorCode);
        }

        [Test]
        public async Task DetectLanguageWithNoneCountryHintTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Este documento está en español";

            DetectedLanguage language = await client.DetectLanguageAsync(document, DetectLanguageInput.None);
            Assert.IsNotNull(language.Name);
            Assert.IsNotNull(language.Iso6391Name);
            Assert.Greater(language.ConfidenceScore, 0.0);
        }

        [Test]
        public async Task DetectLanguageWithNoneDefaultCountryHintTest()
        {
            var options = new TextAnalyticsClientOptions()
            {
                DefaultCountryHint = DetectLanguageInput.None
            };

            TextAnalyticsClient client = GetClient(options: options);
            string document = "Este documento está en español";

            DetectedLanguage language = await client.DetectLanguageAsync(document, DetectLanguageInput.None);
            Assert.IsNotNull(language.Name);
            Assert.IsNotNull(language.Iso6391Name);
            Assert.Greater(language.ConfidenceScore, 0.0);
        }

        [Test]
        public async Task DetectLanguageBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Hello world",
                "Bonjour tout le monde",
                "Hola mundo"
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, options: new TextAnalyticsRequestOptions() { ModelVersion = "2019-10-01" });

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("French", results[1].PrimaryLanguage.Name);
            Assert.AreEqual("Spanish", results[2].PrimaryLanguage.Name);

            Assert.AreEqual(0, results[0].Statistics.CharacterCount);
            Assert.AreEqual(0, results[0].Statistics.TransactionCount);
            Assert.IsNull(results.Statistics);
        }

        [Test]
        public async Task DetectLanguageBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Hello world",
                "This is a test"
            };

            var options = new TextAnalyticsRequestOptions()
            {
                IncludeStatistics = true,
                ModelVersion = "2019-10-01"
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, "us", options);

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("English", results[1].PrimaryLanguage.Name);

            Assert.IsNotNull(results.Statistics);
            Assert.Greater(results.Statistics.DocumentCount, 0);
            Assert.Greater(results.Statistics.TransactionCount, 0);
            Assert.GreaterOrEqual(results.Statistics.InvalidDocumentCount, 0);
            Assert.GreaterOrEqual(results.Statistics.ValidDocumentCount, 0);

            Assert.IsNotNull(results[0].Statistics);
            Assert.Greater(results[0].Statistics.CharacterCount, 0);
            Assert.Greater(results[0].Statistics.TransactionCount, 0);
        }

        [Test]
        public async Task DetectLanguageBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<DetectLanguageInput>
            {
                new DetectLanguageInput("1", "Hello world")
                {
                     CountryHint = "us",
                },
                new DetectLanguageInput("2", "Bonjour tout le monde")
                {
                     CountryHint = "fr",
                },
                new DetectLanguageInput("3", "Hola mundo")
                {
                     CountryHint = "es",
                },
                new DetectLanguageInput("4", ":) :( :D")
                {
                     CountryHint = "us",
                }
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, options: new TextAnalyticsRequestOptions() { ModelVersion = "2019-10-01" });

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("French", results[1].PrimaryLanguage.Name);
            Assert.AreEqual("Spanish", results[2].PrimaryLanguage.Name);
            Assert.AreEqual("(Unknown)", results[3].PrimaryLanguage.Name);
        }

        [Test]
        public async Task DetectLanguageBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<DetectLanguageInput>
            {
                new DetectLanguageInput("1", "Hello world")
                {
                     CountryHint = "us",
                },
                new DetectLanguageInput("2", "Bonjour tout le monde")
                {
                     CountryHint = "fr",
                },
                new DetectLanguageInput("3", "Hola mundo")
                {
                     CountryHint = "es",
                },
                new DetectLanguageInput("4", ":) :( :D")
                {
                     CountryHint = "us",
                }
            };

            var options = new TextAnalyticsRequestOptions()
            {
                IncludeStatistics = true,
                ModelVersion = "2019-10-01"
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents, options: options);

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("French", results[1].PrimaryLanguage.Name);
            Assert.AreEqual("Spanish", results[2].PrimaryLanguage.Name);
            Assert.AreEqual("(Unknown)", results[3].PrimaryLanguage.Name);
            Assert.IsNotNull(results[0].Statistics);
            Assert.IsNotNull(results[0].Statistics.CharacterCount);
            Assert.IsNotNull(results[0].Statistics.TransactionCount);
        }

        [Test]
        public async Task DetectLanguageBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Hello world",
                "",
                "Hola mundo"
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(documents);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].PrimaryLanguage.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task AnalyzeSentimentTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "That was the best day of my life!";

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document);

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
            Assert.AreEqual("Positive", docSentiment.Sentences.FirstOrDefault().Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "El mejor test del mundo!";

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(document, "es");

            CheckAnalyzeSentimentProperties(docSentiment);
            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "That was the best day of my life!. I had a lot of fun at the park.",
                "I'm not sure how I feel about this product. It is complicated."
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents);

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "That was the best day of my life!. I had a lot of fun at the park.",
                "I'm not sure how I feel about this product. It is complicated."
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());

            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
        }

        [Test]
        public async Task AnalyzeSentimentBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Pike Place Market is my favorite Seattle attraction.  We had so much fun there.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Esta comida no me gusta. Siempre que la como me enfermo.")
                {
                     Language = "es",
                }
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents);

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Pike Place Market is my favorite Seattle attraction.  We had so much fun there.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Esta comida no me gusta. Siempre que la como me enfermo.")
                {
                     Language = "es",
                }
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (AnalyzeSentimentResult docs in results)
            {
                CheckAnalyzeSentimentProperties(docs.DocumentSentiment);
            }

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());

            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
        }

        [Test]
        public async Task AnalyzeSentimentBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "That was the best day of my life!",
                "",
                "I'm not sure how I feel about this product."
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(documents);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].DocumentSentiment.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task ExtractKeyPhrasesTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "My cat might need to see a veterinarian.";

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document);

            Assert.AreEqual(2, keyPhrases.Count);
            Assert.IsTrue(keyPhrases.Contains("cat"));
            Assert.IsTrue(keyPhrases.Contains("veterinarian"));
        }

        [Test]
        public async Task ExtractKeyPhrasesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Mi perro está en el veterinario";

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document, "es");

            Assert.AreEqual(2, keyPhrases.Count);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                 "",
                "My cat might need to see a veterinarian."
            };

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].KeyPhrases.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task ExtractKeyPhrasesWithWarningTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Anthony runs his own personal training business so thisisaverylongtokenwhichwillbetruncatedtoshowushowwarningsareemittedintheapi";

            KeyPhraseCollection keyPhrases = await client.ExtractKeyPhrasesAsync(document, "es");

            Assert.IsNotNull(keyPhrases.Warnings);
            Assert.GreaterOrEqual(keyPhrases.Warnings.Count, 0);
            Assert.AreEqual(TextAnalyticsWarningCode.LongWordsInDocument, keyPhrases.Warnings.FirstOrDefault().WarningCode.ToString());

            Assert.GreaterOrEqual(keyPhrases.Count, 1);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "My cat and my dog might need to see a veterinarian."
            };

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.AreEqual(3, result.KeyPhrases.Count());
            }
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "My cat and my dog might need to see a veterinarian."
            };

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.AreEqual(3, result.KeyPhrases.Count());
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput>
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

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents);

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.AreEqual(3, result.KeyPhrases.Count());
            }
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchWithSatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput>
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

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.AreEqual(3, result.KeyPhrases.Count());
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
        }

        [Test]
        public async Task RecognizeEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Microsoft was founded by Bill Gates and Paul Allen.";

            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(document);

            Assert.AreEqual(3, entities.Count);

            var entitiesList = new List<string> { "Bill Gates", "Microsoft", "Paul Allen" };
            foreach (CategorizedEntity entity in entities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Text));
                Assert.IsNotNull(entity.ConfidenceScore);
            }
        }

        [Test]
        public async Task RecognizeEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Microsoft fue fundado por Bill Gates y Paul Allen.";

            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(document, "es");

            Assert.AreEqual(3, entities.Count);
        }

        [Test]
        public async Task RecognizeEntitiesWithSubCategoryTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "I had a wonderful trip to Seattle last week.";

            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(document);

            Assert.GreaterOrEqual(entities.Count, 3);

            foreach (CategorizedEntity entity in entities)
            {
                if (entity.Text == "last week")
                    Assert.AreEqual("DateRange", entity.SubCategory);
            }
        }

        [Test]
        public async Task RecognizeEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                 "",
                "My cat might need to see a veterinarian."
            };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task RecognizeEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "My cat and my dog might need to see a veterinarian."
            };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents);

            foreach (RecognizeEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 1);
            }
        }

        [Test]
        public void RecognizeEntitiesBatchWithInvalidDocumentBatch()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "document 1",
                "document 2",
                "document 3",
                "document 4",
                "document 5",
                "document 6"
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.RecognizeEntitiesBatchAsync(documents));
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocumentBatch, ex.ErrorCode);
        }

        [Test]
        public async Task RecognizeEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "My cat and my dog might need to see a veterinarian."
            };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (RecognizeEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 1);
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
        }

        [Test]
        public async Task RecognizeEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput>
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

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents);

            foreach (RecognizeEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 1);
            }
        }

        [Test]
        public async Task RecognizeEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput>
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

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (RecognizeEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 1);
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Microsoft was founded by Bill Gates and Paul Allen.";

            LinkedEntityCollection linkedEntities = await client.RecognizeLinkedEntitiesAsync(document);

            Assert.AreEqual(3, linkedEntities.Count);

            var entitiesList = new List<string> { "Bill Gates", "Microsoft", "Paul Allen" };
            foreach (LinkedEntity entity in linkedEntities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Name));
                Assert.IsNotNull(entity.DataSource);
                Assert.IsNotNull(entity.DataSourceEntityId);
                Assert.IsNotNull(entity.Language);
                Assert.IsNotNull(entity.Url);
                Assert.IsNotNull(entity.Matches);
                Assert.IsNotNull(entity.Matches.First().ConfidenceScore);
                Assert.IsNotNull(entity.Matches.First().Text);
            }
        }

        [Test]
        public async Task RecognizeLinkedEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string document = "Microsoft fue fundado por Bill Gates y Paul Allen.";

            LinkedEntityCollection linkedEntities = await client.RecognizeLinkedEntitiesAsync(document, "es");

            Assert.GreaterOrEqual(linkedEntities.Count, 3);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "",
                "Pike place market is my favorite Seattle attraction.",
            };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public void RecognizeLinkedEntitiesBatchWithInvalidDocumentBatch()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Hello world",
                "Pike place market is my favorite Seattle attraction.",
                "I had a wonderful trip to Seattle last week and even visited the Space Needle 2 times!",
                "Unfortunately, it rained during my entire trip to Seattle. I didn't even get to visit the Space Needle",
                "This should fail!"
            };

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.RecognizeLinkedEntitiesBatchAsync(documents));
            Assert.AreEqual(400, ex.Status);
            Assert.AreEqual(TextAnalyticsErrorCode.InvalidDocumentBatch, ex.ErrorCode);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Pike place market is my favorite Seattle attraction.",
            };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents);

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Pike place market is my favorite Seattle attraction.",
            };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
                {
                     Language = "en",
                },
                new TextDocumentInput("3", "Pike place market is my favorite Seattle attraction.")
                {
                     Language = "en",
                }
            };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents);

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var documents = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "Microsoft was founded by Bill Gates and Paul Allen.")
                {
                     Language = "en",
                },
                new TextDocumentInput("3", "Pike place market is my favorite Seattle attraction.")
                {
                     Language = "en",
                }
            };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(documents, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
        }

        [Test]
        [Ignore("Tracked by issue: https://github.com/Azure/azure-sdk-for-net/issues/11571")]
        public async Task RecognizeEntitiesCategories()
        {
            TextAnalyticsClient client = GetClient();
            const string document = "Bill Gates | Microsoft | New Mexico | 800-102-1100 | help@microsoft.com | April 4, 1975 12:34 | April 4, 1975 | 12:34 | five seconds | 9 | third | 120% | €30 | 11m | 22 °C |" +
                "Software Engineer | Wedding | Microsoft Surface laptop | Coding | 127.0.0.1 | https://github.com/azure/azure-sdk-for-net";

            RecognizeEntitiesResultCollection response = await client.RecognizeEntitiesBatchAsync(new List<string>() { document }, "en", new TextAnalyticsRequestOptions() { ModelVersion = "2020-02-01" });
            var entities = response.FirstOrDefault().Entities.ToList();

            Assert.AreEqual(21, entities.Count);

            Assert.AreEqual(EntityCategory.Person, entities[0].Category);

            Assert.AreEqual(EntityCategory.Organization, entities[1].Category);

            Assert.AreEqual(EntityCategory.Location, entities[2].Category);

            Assert.AreEqual(EntityCategory.PhoneNumber, entities[3].Category);

            Assert.AreEqual(EntityCategory.Email, entities[4].Category);

            Assert.AreEqual(EntityCategory.DateTime, entities[5].Category);

            Assert.AreEqual(EntityCategory.DateTime, entities[6].Category);

            Assert.AreEqual(EntityCategory.DateTime, entities[7].Category);

            Assert.AreEqual(EntityCategory.DateTime, entities[8].Category);

            Assert.AreEqual(EntityCategory.Quantity, entities[9].Category);

            Assert.AreEqual(EntityCategory.Quantity, entities[10].Category);

            Assert.AreEqual(EntityCategory.Quantity, entities[11].Category);

            Assert.AreEqual(EntityCategory.Quantity, entities[12].Category);

            Assert.AreEqual(EntityCategory.Quantity, entities[13].Category);

            Assert.AreEqual(EntityCategory.Quantity, entities[14].Category);

            Assert.AreEqual(EntityCategory.PersonType, entities[15].Category);

            Assert.AreEqual(EntityCategory.Event, entities[16].Category);

            Assert.AreEqual(EntityCategory.Product, entities[17].Category);

            Assert.AreEqual(EntityCategory.Skill, entities[18].Category);

            Assert.AreEqual(EntityCategory.IPAddress, entities[19].Category);

            Assert.AreEqual(EntityCategory.Url, entities[20].Category);
        }

        [Test]
        public async Task RotateApiKey()
        {
            // Instantiate a client that will be used to call the service.
            string apiKey = TestEnvironment.ApiKey;
            var credential = new AzureKeyCredential(apiKey);
            TextAnalyticsClient client = GetClient(credential);

            string document = "Este documento está en español.";

            // Verify the credential works (i.e., doesn't throw)
            await client.DetectLanguageAsync(document);

            // Rotate the API key to an invalid value and make sure it fails
            credential.Update("Invalid");
            Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.DetectLanguageAsync(document));

            // Re-rotate the API key and make sure it succeeds again
            credential.Update(apiKey);
            await client.DetectLanguageAsync(document);
        }

        private void CheckAnalyzeSentimentProperties(DocumentSentiment doc)
        {
            Assert.IsNotNull(doc.ConfidenceScores.Positive);
            Assert.IsNotNull(doc.ConfidenceScores.Neutral);
            Assert.IsNotNull(doc.ConfidenceScores.Negative);
            Assert.IsTrue(CheckTotalConfidenceScoreValue(doc.ConfidenceScores));

            foreach (var sentence in doc.Sentences)
            {
                Assert.IsNotNull(sentence.Text);
                Assert.IsNotNull(sentence.ConfidenceScores.Positive);
                Assert.IsNotNull(sentence.ConfidenceScores.Neutral);
                Assert.IsNotNull(sentence.ConfidenceScores.Negative);
                Assert.IsTrue(CheckTotalConfidenceScoreValue(sentence.ConfidenceScores));
            }
        }

        private bool CheckTotalConfidenceScoreValue(SentimentConfidenceScores scores)
        {
            return scores.Positive + scores.Neutral + scores.Negative == 1d;
        }
    }
}
