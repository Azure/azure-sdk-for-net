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

            DetectLanguageResult result = await client.DetectLanguageAsync(input);
            DetectedLanguage language = result.PrimaryLanguage;

            Assert.AreEqual("English", language.Name);
            Assert.AreEqual("en", language.Iso6391Name);
            Assert.AreEqual(1.0, language.Score);
        }

        [Test]
        public async Task DetectLanguageWithCountryHintTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "Este documento está en español";

            DetectLanguageResult result = await client.DetectLanguageAsync(input, "CO");
            DetectedLanguage language = result.PrimaryLanguage;

            Assert.AreEqual("Spanish", language.Name);
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
        public async Task ExtractKeyPhrasesTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "My cat might need to see a veterinarian.";

            IList<string> keyPhrases = (IList<string>)await client.ExtractKeyPhrasesAsync(input);

            Assert.AreEqual(2, keyPhrases.Count);
            Assert.IsTrue(keyPhrases.Contains("cat"));
            Assert.IsTrue(keyPhrases.Contains("veterinarian"));
        }

        [Test]
        public async Task ExtractKeyPhrasesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "Mi perro está en el veterinario";

            IList<string> keyPhrases = (IList<string>)await client.ExtractKeyPhrasesAsync(input, "es");

            Assert.AreEqual(2, keyPhrases.Count);
        }

        [Test]
        public async Task RecognizeEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "Microsoft was founded by Bill Gates and Paul Allen.";

            IReadOnlyCollection<CategorizedEntity> entities = (IReadOnlyCollection<CategorizedEntity>)await client.RecognizeEntitiesAsync(input);

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

            IReadOnlyCollection<CategorizedEntity> entities = (IReadOnlyCollection<CategorizedEntity>)await client.RecognizeEntitiesAsync(input, "es");

            Assert.AreEqual(3, entities.Count);
        }

        [Test]
        public async Task RecognizeEntitiesWithSubCategoryTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "I had a wonderful trip to Seattle last week.";

            IReadOnlyCollection<CategorizedEntity> entities = (IReadOnlyCollection<CategorizedEntity>)await client.RecognizeEntitiesAsync(input);

            Assert.AreEqual(2, entities.Count);

            foreach (CategorizedEntity entity in entities)
            {
                if (entity.Text == "last week")
                    Assert.IsTrue(entity.SubCategory != EntitySubCategory.None);
            }
        }

        [Test]
        public async Task RecognizePiiEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "A developer with SSN 555-55-5555 whose phone number is 800-102-1100 is building tools with our APIs.";

            IReadOnlyCollection<CategorizedEntity> entities = (IReadOnlyCollection<CategorizedEntity>)await client.RecognizePiiEntitiesAsync(input);

            Assert.AreEqual(2, entities.Count);

            var entitiesList = new List<string> { "555-55-5555", " 800-102-1100 " };
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
        public async Task RecognizePiiEntitiesWithLanguageTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "A developer with SSN 555-55-5555 whose phone number is 800-102-1100 is building tools with our APIs.";

            IReadOnlyCollection<CategorizedEntity> entities = (IReadOnlyCollection<CategorizedEntity>)await client.RecognizePiiEntitiesAsync(input, "en");

            Assert.AreEqual(2, entities.Count);
        }

        [Test]
        public async Task RecognizeLinkedEntitiesTest()
        {
            TextAnalyticsClient client = GetClient();
            string input = "Microsoft was founded by Bill Gates and Paul Allen.";

            IList<LinkedEntity> linkedEntities = (IList<LinkedEntity>)await client.RecognizeLinkedEntitiesAsync(input);

            Assert.AreEqual(3, linkedEntities.Count);

            var entitiesList = new List<string> { "Bill Gates", "Microsoft", "Paul Allen" };
            foreach (LinkedEntity entity in linkedEntities)
            {
                Assert.IsTrue(entitiesList.Contains(entity.Name));
                Assert.IsNotNull(entity.DataSource);
                Assert.IsNotNull(entity.Id);
                Assert.IsNotNull(entity.Language);
                Assert.IsNotNull(entity.Uri);
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

            IList<LinkedEntity> linkedEntities = (IList<LinkedEntity>)await client.RecognizeLinkedEntitiesAsync(input, "es");

            Assert.AreEqual(3, linkedEntities.Count);
        }

        [Test]
        public async Task RecognizeEntitiesCategoriesSubCategories()
        {
            TextAnalyticsClient client = GetClient();
            const string input = "Bill Gates | Microsoft | New Mexico | 800-102-1100 | help@microsoft.com | April 4, 1975 12:34 | April 4, 1975 | 12:34 | five seconds | 9 | third | 120% | €30 | 11m | 22 °C";

            IList<CategorizedEntity> entities = (IList<CategorizedEntity>)await client.RecognizeEntitiesAsync(input);

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
    }
}
