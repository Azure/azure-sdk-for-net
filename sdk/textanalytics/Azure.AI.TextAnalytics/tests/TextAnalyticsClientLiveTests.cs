// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
