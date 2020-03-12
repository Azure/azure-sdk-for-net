// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientLiveTests : RecordedTestBase
    {
        public const string EndpointEnvironmentVariable = "TEXT_ANALYTICS_ENDPOINT";
        public const string ApiKeyEnvironmentVariable = "TEXT_ANALYTICS_API_KEY";

        public TextAnalyticsClientLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new TextAnalyticsRecordedTestSanitizer();
            Matcher = new RecordMatcher(Sanitizer);
        }

        public TextAnalyticsClient GetClient(TextAnalyticsApiKeyCredential credential = default, TextAnalyticsClientOptions options = default)
        {
            string apiKey = Recording.GetVariableFromEnvironment(ApiKeyEnvironmentVariable);
            credential ??= new TextAnalyticsApiKeyCredential(apiKey);
            options ??= new TextAnalyticsClientOptions();
            return InstrumentClient (
                new TextAnalyticsClient(
                    new Uri(Recording.GetVariableFromEnvironment(EndpointEnvironmentVariable)),
                    credential,
                    Recording.InstrumentClientOptions(options))
            );
        }

        [Test]
        public async Task DetectLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "This is written in English.";

            DetectedLanguage language = await client.DetectLanguageAsync(input);

            Assert.AreEqual("English", language.Name);
            Assert.AreEqual("en", language.Iso6391Name);
            Assert.AreEqual(1.0, language.Score);
        }

        [Test]
        public async Task DetectLanguageWithCountryHintTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "Este documento está en español";

            DetectedLanguage language = await client.DetectLanguageAsync(input, "CO");

            Assert.AreEqual("Spanish", language.Name);
        }

        [Test]
        public void DetectLanguageWithErrorCountryHintTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "Este documento está en español";

            RequestFailedException ex = Assert.ThrowsAsync<RequestFailedException>(() => client.DetectLanguageAsync(input, "COLOMBIA"));
            Assert.AreEqual("InvalidCountryHint", ex.ErrorCode);
        }

        [Test]
        public async Task DetectLanguageWithNoneCountryHintTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "Este documento está en español";

            DetectedLanguage language = await client.DetectLanguageAsync(input, DetectLanguageInput.None);
            Assert.AreEqual("Spanish", language.Name);
        }

        [Test]
        public async Task DetectLanguageWithNoneDefaultCountryHintTest()
        {
            var options = new TextAnalyticsClientOptions()
            {
                DefaultCountryHint = DetectLanguageInput.None
            };

            TextAnalyticsClient client = GetClient(options: options);
            string input = "Este documento está en español";

            DetectedLanguage language = await client.DetectLanguageAsync(input, DetectLanguageInput.None);
            Assert.AreEqual("Spanish", language.Name);
        }

        [Test]
        public async Task DetectLanguageBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "Hello world",
                "Bonjour tout le monde",
                "Hola mundo"
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(inputs);

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("French", results[1].PrimaryLanguage.Name);
            Assert.AreEqual("Spanish", results[2].PrimaryLanguage.Name);
        }

        [Test]
        public async Task DetectLanguageBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "Hello world",
                "This is a test"
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(inputs, "us", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("English", results[1].PrimaryLanguage.Name);
            Assert.IsNotNull(results[0].Statistics);
            Assert.IsNotNull(results[0].Statistics.GraphemeCount);
            Assert.IsNotNull(results[0].Statistics.TransactionCount);
        }

        [Test]
        public async Task DetectLanguageBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<DetectLanguageInput>
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

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(inputs);

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("French", results[1].PrimaryLanguage.Name);
            Assert.AreEqual("Spanish", results[2].PrimaryLanguage.Name);
            Assert.AreEqual("English", results[3].PrimaryLanguage.Name);
        }

        [Test]
        public async Task DetectLanguageBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<DetectLanguageInput>
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

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            Assert.AreEqual("English", results[0].PrimaryLanguage.Name);
            Assert.AreEqual("French", results[1].PrimaryLanguage.Name);
            Assert.AreEqual("Spanish", results[2].PrimaryLanguage.Name);
            Assert.AreEqual("English", results[3].PrimaryLanguage.Name);
            Assert.IsNotNull(results[0].Statistics);
            Assert.IsNotNull(results[0].Statistics.GraphemeCount);
            Assert.IsNotNull(results[0].Statistics.TransactionCount);
        }

        [Test]
        public async Task DetectLanguageBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "Hello world",
                "",
                "Hola mundo"
            };

            DetectLanguageResultCollection results = await client.DetectLanguageBatchAsync(inputs);

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
            string input = "That was the best day of my life!";

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(input);

            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
            Assert.IsNotNull(docSentiment.ConfidenceScores.Positive);
            Assert.IsNotNull(docSentiment.ConfidenceScores.Neutral);
            Assert.IsNotNull(docSentiment.ConfidenceScores.Negative);

            foreach (var sentence in docSentiment.Sentences)
            {
                Assert.AreEqual("Positive", sentence.Sentiment.ToString());
                Assert.IsNotNull(sentence.ConfidenceScores.Positive);
                Assert.IsNotNull(sentence.ConfidenceScores.Neutral);
                Assert.IsNotNull(sentence.ConfidenceScores.Negative);
                Assert.IsNotNull(sentence.GraphemeOffset);
                Assert.IsNotNull(sentence.GraphemeLength);
                Assert.Greater(sentence.GraphemeLength, 0);
            }
        }

        [Test]
        public async Task AnalyzeSentimentWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "El mejor test del mundo!";

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(input, "es");

            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
        }

        [Test]
        public async Task AnalyzeSentimentBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "That was the best day of my life!. I had a lot of fun at the park.",
                "I'm not sure how I feel about this product. It is complicated."
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(inputs);

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());

            foreach (AnalyzeSentimentResult docs in results)
            {
                DocumentSentiment docSentiment = docs.DocumentSentiment;
                Assert.IsNotNull(docSentiment.ConfidenceScores.Positive);
                Assert.IsNotNull(docSentiment.ConfidenceScores.Neutral);
                Assert.IsNotNull(docSentiment.ConfidenceScores.Negative);

                foreach (var sentence in docSentiment.Sentences)
                {
                    Assert.IsNotNull(sentence.ConfidenceScores.Positive);
                    Assert.IsNotNull(sentence.ConfidenceScores.Neutral);
                    Assert.IsNotNull(sentence.ConfidenceScores.Negative);
                    Assert.IsNotNull(sentence.GraphemeOffset);
                    Assert.IsNotNull(sentence.GraphemeLength);
                }
            }
        }

        [Test]
        public async Task AnalyzeSentimentBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "That was the best day of my life!. I had a lot of fun at the park.",
                "I'm not sure how I feel about this product. It is complicated."
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(inputs, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

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
            var inputs = new List<TextDocumentInput>
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

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(inputs);

            Assert.AreEqual("Positive", results[0].DocumentSentiment.Sentiment.ToString());
            Assert.AreEqual("Negative", results[1].DocumentSentiment.Sentiment.ToString());

            foreach (AnalyzeSentimentResult docs in results)
            {
                DocumentSentiment docSentiment = docs.DocumentSentiment;
                Assert.IsNotNull(docSentiment.ConfidenceScores.Positive);
                Assert.IsNotNull(docSentiment.ConfidenceScores.Neutral);
                Assert.IsNotNull(docSentiment.ConfidenceScores.Negative);

                foreach (var sentence in docSentiment.Sentences)
                {
                    Assert.IsNotNull(sentence.ConfidenceScores.Positive);
                    Assert.IsNotNull(sentence.ConfidenceScores.Neutral);
                    Assert.IsNotNull(sentence.ConfidenceScores.Negative);
                    Assert.IsNotNull(sentence.GraphemeOffset);
                    Assert.IsNotNull(sentence.GraphemeLength);
                }
            }
        }

        [Test]
        public async Task AnalyzeSentimentBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<TextDocumentInput>
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

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });

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
            var inputs = new List<string>
            {
                "That was the best day of my life!",
                "",
                "I'm not sure how I feel about this product."
            };

            AnalyzeSentimentResultCollection results = await client.AnalyzeSentimentBatchAsync(inputs);

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
            string input = "My cat might need to see a veterinarian.";

            Response<IReadOnlyCollection<string>> response = await client.ExtractKeyPhrasesAsync(input);
            IReadOnlyCollection<string> keyPhrases = response.Value;

            Assert.AreEqual(2, keyPhrases.Count);
            Assert.IsTrue(keyPhrases.Contains("cat"));
            Assert.IsTrue(keyPhrases.Contains("veterinarian"));
        }

        [Test]
        public async Task ExtractKeyPhrasesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "Mi perro está en el veterinario";

            Response<IReadOnlyCollection<string>> response = await client.ExtractKeyPhrasesAsync(input, "es");
            IReadOnlyCollection<string> keyPhrases = response.Value;

            Assert.AreEqual(2, keyPhrases.Count);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                 "",
                "My cat might need to see a veterinarian."
            };

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(inputs);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].KeyPhrases.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "My cat and my dog might need to see a veterinarian."
            };

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(inputs);

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.AreEqual(3, result.KeyPhrases.Count());
            }
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "My cat and my dog might need to see a veterinarian."
            };

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(inputs, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

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
            var inputs = new List<TextDocumentInput>
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

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(inputs);

            foreach (ExtractKeyPhrasesResult result in results)
            {
                Assert.AreEqual(3, result.KeyPhrases.Count());
            }
        }

        [Test]
        public async Task ExtractKeyPhrasesBatchWithSatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<TextDocumentInput>
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

            ExtractKeyPhrasesResultCollection results = await client.ExtractKeyPhrasesBatchAsync(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });

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
            string input = "Microsoft was founded by Bill Gates and Paul Allen.";

            Response<IReadOnlyCollection<CategorizedEntity>> response = await client.RecognizeEntitiesAsync(input);
            IReadOnlyCollection<CategorizedEntity> entities = response.Value;

            Assert.AreEqual(3, entities.Count);

            var entitiesList = new List<string> { "Bill Gates", "Microsoft", "Paul Allen" };
            foreach (CategorizedEntity entity in entities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Text));
                Assert.IsNotNull(entity.ConfidenceScore);
                Assert.IsNotNull(entity.GraphemeOffset);
                Assert.IsNotNull(entity.GraphemeLength);
                Assert.Greater(entity.GraphemeLength, 0);
            }
        }

        [Test]
        public async Task RecognizeEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "Microsoft fue fundado por Bill Gates y Paul Allen.";

            Response<IReadOnlyCollection<CategorizedEntity>> response = await client.RecognizeEntitiesAsync(input, "es");
            IReadOnlyCollection<CategorizedEntity> entities = response.Value;

            Assert.AreEqual(3, entities.Count);
        }

        [Test]
        public async Task RecognizeEntitiesWithSubCategoryTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "I had a wonderful trip to Seattle last week.";

            Response<IReadOnlyCollection<CategorizedEntity>> response = await client.RecognizeEntitiesAsync(input);
            IReadOnlyCollection<CategorizedEntity> entities = response.Value;

            Assert.AreEqual(2, entities.Count);

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
            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                 "",
                "My cat might need to see a veterinarian."
            };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(inputs);

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
            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "My cat and my dog might need to see a veterinarian."
            };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(inputs);

            foreach (RecognizeEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 1);
            }
        }

        [Test]
        public async Task RecognizeEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "My cat and my dog might need to see a veterinarian."
            };

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(inputs, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

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
            var inputs = new List<TextDocumentInput>
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

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(inputs);

            foreach (RecognizeEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 1);
            }
        }

        [Test]
        public async Task RecognizeEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<TextDocumentInput>
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

            RecognizeEntitiesResultCollection results = await client.RecognizeEntitiesBatchAsync(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });

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
        public async Task RecognizePiiEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "A developer with SSN 555-55-5555 whose phone number is 800-102-1100 is building tools with our APIs.";

            Response<IReadOnlyCollection<PiiEntity>> response = await client.RecognizePiiEntitiesAsync(input);
            IReadOnlyCollection<PiiEntity> entities = response.Value;

            Assert.AreEqual(2, entities.Count);

            var entitiesList = new List<string> { "555-55-5555", "800-102-1100" };
            foreach (PiiEntity entity in entities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Text));
                Assert.IsNotNull(entity.ConfidenceScore);
                Assert.IsNotNull(entity.GraphemeOffset);
                Assert.IsNotNull(entity.GraphemeLength);
                Assert.Greater(entity.GraphemeLength, 0);
            }
        }

        [Test]
        public async Task RecognizePiiEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "A developer with SSN 555-55-5555 whose phone number is 800-102-1100 is building tools with our APIs.";

            Response<IReadOnlyCollection<PiiEntity>> response = await client.RecognizePiiEntitiesAsync(input, "en");
            IReadOnlyCollection<PiiEntity> entities = response.Value;

            Assert.AreEqual(2, entities.Count);
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.",
                "",
                "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.",
            };

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(inputs);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.",
                "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check."
            };

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(inputs);

            foreach (RecognizePiiEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.",
                "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check."
            };

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(inputs, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (RecognizePiiEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }

            Assert.IsNotNull(results.Statistics.DocumentCount);
            Assert.IsNotNull(results.Statistics.InvalidDocumentCount);
            Assert.IsNotNull(results.Statistics.TransactionCount);
            Assert.IsNotNull(results.Statistics.ValidDocumentCount);
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.")
                {
                     Language = "en",
                }
            };

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(inputs);

            foreach (RecognizePiiEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }
        }

        [Test]
        public async Task RecognizePiiEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<TextDocumentInput>
            {
                new TextDocumentInput("1", "A developer with SSN 555-55-5555 whose phone number is 555-555-5555 is building tools with our APIs.")
                {
                     Language = "en",
                },
                new TextDocumentInput("2", "Your ABA number - 111000025 - is the first 9 digits in the lower left hand corner of your personal check.")
                {
                     Language = "en",
                }
            };

            RecognizePiiEntitiesResultCollection results = await client.RecognizePiiEntitiesBatchAsync(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });

            foreach (RecognizePiiEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
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
            string input = "Microsoft was founded by Bill Gates and Paul Allen.";

            Response<IReadOnlyCollection<LinkedEntity>> response = await client.RecognizeLinkedEntitiesAsync(input);
            IReadOnlyCollection<LinkedEntity> linkedEntities = response.Value;

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
                Assert.IsNotNull(entity.Matches.First().GraphemeLength);
                Assert.IsNotNull(entity.Matches.First().GraphemeOffset);
                Assert.IsNotNull(entity.Matches.First().ConfidenceScore);
                Assert.IsNotNull(entity.Matches.First().Text);
            }
        }

        [Test]
        public async Task RecognizeLinkedEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "Microsoft fue fundado por Bill Gates y Paul Allen.";

            Response<IReadOnlyCollection<LinkedEntity>> response = await client.RecognizeLinkedEntitiesAsync(input, "es");
            IReadOnlyCollection<LinkedEntity> linkedEntities = response.Value;

            Assert.AreEqual(3, linkedEntities.Count);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchWithErrorTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "",
                "Pike place market is my favorite Seattle attraction.",
            };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(inputs);

            Assert.IsTrue(!results[0].HasError);
            Assert.IsTrue(!results[2].HasError);

            var exceptionMessage = "Cannot access result for document 1, due to error InvalidDocument: Document text is empty.";
            Assert.IsTrue(results[1].HasError);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
            Assert.AreEqual(exceptionMessage, ex.Message);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchConvenienceTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Pike place market is my favorite Seattle attraction.",
            };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(inputs);

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchConvenienceWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<string>
            {
                "Microsoft was founded by Bill Gates and Paul Allen.",
                "Pike place market is my favorite Seattle attraction.",
            };

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(inputs, "en", new TextAnalyticsRequestOptions { IncludeStatistics = true });

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
            var inputs = new List<TextDocumentInput>
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

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(inputs);

            foreach (RecognizeLinkedEntitiesResult result in results)
            {
                Assert.GreaterOrEqual(result.Entities.Count(), 2);
            }
        }

        [Test]
        public async Task RecognizeLinkedEntitiesBatchWithStatisticsTest()
        {
            TextAnalyticsClient client = GetClient();
            var inputs = new List<TextDocumentInput>
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

            RecognizeLinkedEntitiesResultCollection results = await client.RecognizeLinkedEntitiesBatchAsync(inputs, new TextAnalyticsRequestOptions { IncludeStatistics = true });

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
        public async Task RecognizeEntitiesCategories()
        {
            TextAnalyticsClient client = GetClient();
            const string input = "Bill Gates | Microsoft | New Mexico | 800-102-1100 | help@microsoft.com | April 4, 1975 12:34 | April 4, 1975 | 12:34 | five seconds | 9 | third | 120% | €30 | 11m | 22 °C |" +
                "Software Engineer | Wedding | Microsoft Surface laptop | Coding | 127.0.0.1 | https://github.com/azure/azure-sdk-for-net";

            Response <IReadOnlyCollection<CategorizedEntity>> response = await client.RecognizeEntitiesAsync(input);
            List<CategorizedEntity> entities = response.Value.ToList();

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
            string apiKey = Recording.GetVariableFromEnvironment(ApiKeyEnvironmentVariable);
            var credential = new TextAnalyticsApiKeyCredential(apiKey);
            TextAnalyticsClient client = GetClient(credential);

            string input = "Este documento está en español.";

            // Verify the credential works (i.e., doesn't throw)
            await client.DetectLanguageAsync(input);

            // Rotate the API key to an invalid value and make sure it fails
            credential.UpdateCredential("Invalid");
            Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.DetectLanguageAsync(input));

            // Re-rotate the API key and make sure it succeeds again
            credential.UpdateCredential(apiKey);
            await client.DetectLanguageAsync(input);
        }

        [Test]
        public void ThrowExceptionTest()
        {
            TextAnalyticsClient client = GetClient();
            var input = new List<string>();

            Assert.ThrowsAsync<RequestFailedException>(() => client.DetectLanguageBatchAsync(input));
        }
    }
}
