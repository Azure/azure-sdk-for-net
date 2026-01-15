// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class TextAnalyticsClientLiveTests : TextAnalyticsClientLiveTestBase
    {
        public TextAnalyticsClientLiveTests(bool isAsync, TextAnalyticsClientOptions.ServiceVersion serviceVersion)
            : base(isAsync, serviceVersion)
        {
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task TextWithEmoji()
        {
            TextAnalyticsClient client = GetClient();
            string document = "👨 Microsoft the company.";

            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(document, "en");

            Assert.That(entities.Count, Is.EqualTo(1));
            Assert.That(entities.FirstOrDefault().Text, Is.EqualTo("Microsoft"));
            Assert.That(entities.FirstOrDefault().Offset, Is.EqualTo(3));
            Assert.That(entities.FirstOrDefault().Length, Is.EqualTo(9));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task TextWithDiacriticsNFC()
        {
            TextAnalyticsClient client = GetClient();
            string document = "año Microsoft";

            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(document, "es");

            Assert.That(entities.Count, Is.EqualTo(1));
            Assert.That(entities.FirstOrDefault().Text, Is.EqualTo("Microsoft"));
            Assert.That(entities.FirstOrDefault().Offset, Is.EqualTo(4));
            Assert.That(entities.FirstOrDefault().Length, Is.EqualTo(9));
        }

        [RecordedTest]
        [ServiceVersion(Min = TextAnalyticsClientOptions.ServiceVersion.V3_1)]
        public async Task TextInKoreanNFC()
        {
            TextAnalyticsClient client = GetClient();
            string document = "아가 Bill Gates.";

            CategorizedEntityCollection entities = await client.RecognizeEntitiesAsync(document);

            Assert.That(entities.Count, Is.EqualTo(1));
            Assert.That(entities.FirstOrDefault().Text, Is.EqualTo("Bill Gates"));
            Assert.That(entities.FirstOrDefault().Offset, Is.EqualTo(3));
            Assert.That(entities.FirstOrDefault().Length, Is.EqualTo(10));
        }

        [RecordedTest]
        public async Task EntitiesCategories()
        {
            TextAnalyticsClient client = GetClient();
            const string document = "Bill Gates | Microsoft | New Mexico | 127.0.0.1";

            RecognizeEntitiesResultCollection response = await client.RecognizeEntitiesBatchAsync(new List<string>() { document }, "en");
            var entities = response.FirstOrDefault().Entities.ToList();

            Assert.That(entities.Count, Is.EqualTo(4));
            Assert.That(entities[0].Category, Is.EqualTo(EntityCategory.Person));
            Assert.That(entities[1].Category, Is.EqualTo(EntityCategory.Organization));
            Assert.That(entities[2].Category, Is.EqualTo(EntityCategory.Location));
            Assert.That(entities[3].Category, Is.EqualTo(EntityCategory.IPAddress));
        }

        [RecordedTest]
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
