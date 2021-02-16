// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientLiveTests : TextAnalyticsClientLiveTestBase
    {
        public TextAnalyticsClientLiveTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task TextWithEmoji()
        {
            TextAnalyticsClient client = GetClient();
            string document = "👨 Microsoft the company.";

            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(document, "en");

            Assert.AreEqual(1, entities.Count);
            Assert.AreEqual("Microsoft", entities.FirstOrDefault().Text);
            Assert.AreEqual(3, entities.FirstOrDefault().Offset);
            Assert.AreEqual(9, entities.FirstOrDefault().Length);
        }

        [Test]
        public async Task TextWithStringIndexType()
        {
            TextAnalyticsClient client = GetClient();
            string document = "👨 Microsoft the company.";

            RecognizeEntitiesResultCollection responseWithUnicodeCodePoint = await client.RecognizeEntitiesBatchAsync(new List<string>() { document }, "en", new TextAnalyticsRequestOptions() { StringIndexType = StringIndexType.UnicodeCodePoint });
            RecognizeEntitiesResultCollection responseWithUtf16CodeUnit = await client.RecognizeEntitiesBatchAsync(new List<string>() { document }, "en");

            var entitiesWithUnicodeCodePoint = responseWithUnicodeCodePoint.FirstOrDefault().Entities;
            var entitiesWithUtf16CodeUnit = responseWithUtf16CodeUnit.FirstOrDefault().Entities;

            Assert.AreEqual(1, entitiesWithUnicodeCodePoint.Count);
            Assert.AreEqual("Microsoft", entitiesWithUnicodeCodePoint.FirstOrDefault().Text);
            Assert.AreEqual(2, entitiesWithUnicodeCodePoint.FirstOrDefault().Offset);
            Assert.AreEqual(9, entitiesWithUnicodeCodePoint.FirstOrDefault().Length);

            Assert.AreEqual(1, entitiesWithUtf16CodeUnit.Count);
            Assert.AreEqual("Microsoft", entitiesWithUtf16CodeUnit.FirstOrDefault().Text);
            Assert.AreEqual(3, entitiesWithUtf16CodeUnit.FirstOrDefault().Offset);
            Assert.AreEqual(9, entitiesWithUtf16CodeUnit.FirstOrDefault().Length);
        }

        [Test]
        public async Task TextWithDiacriticsNFC()
        {
            TextAnalyticsClient client = GetClient();
            string document = "año Microsoft";

            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(document, "es");

            Assert.AreEqual(1, entities.Count);
            Assert.AreEqual("Microsoft", entities.FirstOrDefault().Text);
            Assert.AreEqual(4, entities.FirstOrDefault().Offset);
            Assert.AreEqual(9, entities.FirstOrDefault().Length);
        }

        [Test]
        public async Task TextInKoreanNFC()
        {
            TextAnalyticsClient client = GetClient();
            string document = "아가 Bill Gates.";

            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(document);

            Assert.AreEqual(1, entities.Count);
            Assert.AreEqual("Bill Gates", entities.FirstOrDefault().Text);
            Assert.AreEqual(3, entities.FirstOrDefault().Offset);
            Assert.AreEqual(10, entities.FirstOrDefault().Length);
        }

        [Test]
        public async Task EntitiesCategories()
        {
            TextAnalyticsClient client = GetClient();
            const string document = "Bill Gates | Microsoft | New Mexico";

            RecognizeEntitiesResultCollection response = await client.RecognizeEntitiesBatchAsync(new List<string>() { document }, "en", new TextAnalyticsRequestOptions() { ModelVersion = "2020-02-01" });
            var entities = response.FirstOrDefault().Entities.ToList();

            Assert.AreEqual(3, entities.Count);

            Assert.AreEqual(EntityCategory.Person, entities[0].Category);

            Assert.AreEqual(EntityCategory.Organization, entities[1].Category);

            Assert.AreEqual(EntityCategory.Location, entities[2].Category);
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
    }
}
