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

        public TextAnalyticsClient GetClient(TextAnalyticsApiKeyCredential credential = default)
        {
            string apiKey = Recording.GetVariableFromEnvironment(ApiKeyEnvironmentVariable);
            credential ??= new TextAnalyticsApiKeyCredential(apiKey);
            return InstrumentClient (
                new TextAnalyticsClient(
                    new Uri(Recording.GetVariableFromEnvironment(EndpointEnvironmentVariable)),
                    credential,
                    Recording.InstrumentClientOptions(new TextAnalyticsClientOptions()))
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

            Assert.IsTrue(results[1].HasError);
            Assert.Throws<InvalidOperationException>(() => results[1].PrimaryLanguage.GetType());
        }

        [Test]
        public async Task AnalyzeSentimentTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "That was the best day of my life!";

            DocumentSentiment docSentiment = await client.AnalyzeSentimentAsync(input);

            Assert.AreEqual("Positive", docSentiment.Sentiment.ToString());
            Assert.IsNotNull(docSentiment.SentimentScores.Positive);
            Assert.IsNotNull(docSentiment.SentimentScores.Neutral);
            Assert.IsNotNull(docSentiment.SentimentScores.Negative);

            foreach (var sentence in docSentiment.Sentences)
            {
                Assert.AreEqual("Positive", sentence.Sentiment.ToString());
                Assert.IsNotNull(sentence.SentimentScores.Positive);
                Assert.IsNotNull(sentence.SentimentScores.Neutral);
                Assert.IsNotNull(sentence.SentimentScores.Negative);
                Assert.IsNotNull(sentence.Offset);
                Assert.IsNotNull(sentence.Length);
                Assert.AreEqual(input.Length, sentence.Length);
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

            Assert.IsTrue(results[1].HasError);
            Assert.Throws<InvalidOperationException>(() => results[1].DocumentSentiment.GetType());
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

            Assert.IsTrue(results[1].HasError);
            Assert.Throws<InvalidOperationException>(() => results[1].KeyPhrases.GetType());
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
                Assert.IsNotNull(entity.Score);
                Assert.IsNotNull(entity.Offset);
                Assert.IsNotNull(entity.Length);
                Assert.Greater(entity.Length, 0);
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
                    Assert.IsTrue(entity.SubCategory != EntitySubCategory.None);
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

            Assert.IsTrue(results[1].HasError);
            Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
        }

        [Test]
        public async Task RecognizePiiEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "A developer with SSN 555-55-5555 whose phone number is 800-102-1100 is building tools with our APIs.";

            Response<IReadOnlyCollection<PiiEntity>> response = await client.RecognizePiiEntitiesAsync(input);
            IReadOnlyCollection<PiiEntity> entities = response.Value;

            Assert.AreEqual(2, entities.Count);

            var entitiesList = new List<string> { "555-55-5555", " 800-102-1100 " };
            foreach (PiiEntity entity in entities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Text));
                Assert.IsNotNull(entity.Score);
                Assert.IsNotNull(entity.Offset);
                Assert.IsNotNull(entity.Length);
                Assert.Greater(entity.Length, 0);
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

            Assert.IsTrue(results[1].HasError);
            Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
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
                Assert.IsNotNull(entity.Id);
                Assert.IsNotNull(entity.Language);
                Assert.IsNotNull(entity.Url);
                Assert.IsNotNull(entity.Matches);
                Assert.IsNotNull(entity.Matches.First().Length);
                Assert.IsNotNull(entity.Matches.First().Offset);
                Assert.IsNotNull(entity.Matches.First().Score);
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

            Assert.IsTrue(results[1].HasError);
            Assert.Throws<InvalidOperationException>(() => results[1].Entities.GetType());
        }

        [Test]
        public async Task RecognizeEntitiesCategoriesSubCategories()
        {
            TextAnalyticsClient client = GetClient();
            const string input = "Bill Gates | Microsoft | New Mexico | 800-102-1100 | help@microsoft.com | April 4, 1975 12:34 | April 4, 1975 | 12:34 | five seconds | 9 | third | 120% | €30 | 11m | 22 °C";

            Response<IReadOnlyCollection<CategorizedEntity>> response = await client.RecognizeEntitiesAsync(input);
            List<CategorizedEntity> entities = response.Value.ToList();

            Assert.AreEqual(15, entities.Count);

            Assert.AreEqual(EntityCategory.Person, entities[0].Category);
            Assert.AreEqual(EntitySubCategory.None, entities[0].SubCategory);

            Assert.AreEqual(EntityCategory.Organization, entities[1].Category);
            Assert.AreEqual(EntitySubCategory.None, entities[1].SubCategory);

            Assert.AreEqual(EntityCategory.Location, entities[2].Category);
            Assert.AreEqual(EntitySubCategory.None, entities[2].SubCategory);

            Assert.AreEqual(EntityCategory.PhoneNumber, entities[3].Category);
            Assert.AreEqual(EntitySubCategory.None, entities[3].SubCategory);

            Assert.AreEqual(EntityCategory.Email, entities[4].Category);
            Assert.AreEqual(EntitySubCategory.None, entities[4].SubCategory);

            Assert.AreEqual(EntityCategory.DateTime, entities[5].Category);
            Assert.AreEqual(EntitySubCategory.None, entities[5].SubCategory);

            Assert.AreEqual(EntityCategory.DateTime, entities[6].Category);
            Assert.AreEqual(EntitySubCategory.Date, entities[6].SubCategory);

            Assert.AreEqual(EntityCategory.DateTime, entities[7].Category);
            Assert.AreEqual(EntitySubCategory.Time, entities[7].SubCategory);

            Assert.AreEqual(EntityCategory.DateTime, entities[8].Category);
            Assert.AreEqual(EntitySubCategory.Duration, entities[8].SubCategory);

            Assert.AreEqual(EntityCategory.Quantity, entities[9].Category);
            Assert.AreEqual(EntitySubCategory.Number, entities[9].SubCategory);

            Assert.AreEqual(EntityCategory.Quantity, entities[10].Category);
            Assert.AreEqual(EntitySubCategory.Ordinal, entities[10].SubCategory);

            Assert.AreEqual(EntityCategory.Quantity, entities[11].Category);
            Assert.AreEqual(EntitySubCategory.Percentage, entities[11].SubCategory);

            Assert.AreEqual(EntityCategory.Quantity, entities[12].Category);
            Assert.AreEqual(EntitySubCategory.Currency, entities[12].SubCategory);

            Assert.AreEqual(EntityCategory.Quantity, entities[13].Category);
            Assert.AreEqual(EntitySubCategory.Dimension, entities[13].SubCategory);

            Assert.AreEqual(EntityCategory.Quantity, entities[14].Category);
            Assert.AreEqual(EntitySubCategory.Temperature, entities[14].SubCategory);
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
