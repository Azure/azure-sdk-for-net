// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.AI.TextAnalytics.Tests
{
    public class AuthenticationTests : ClientTestBase
    {
        public AuthenticationTests(bool async) : base(async)
        {
        }

        [Test]
        public async Task RotateSubscriptionKey()
        {
            string endpoint = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_ENDPOINT");
            string subscriptionKey = Environment.GetEnvironmentVariable("TEXT_ANALYTICS_SUBSCRIPTION_KEY");

            // Instantiate a client that will be used to call the service.
            var credential = new TextAnalyticsSubscriptionKeyCredential(subscriptionKey);
            var client = new TextAnalyticsClient(new Uri(endpoint), credential);

            string input = "Este documento está en español.";

            // Verify the credential works (i.e., doesn't throw)
            await client.DetectLanguageAsync(input);

            // Rotate the subscription key to an invalid value and make sure it fails
            credential.UpdateCredential("Invalid");
            Assert.ThrowsAsync<RequestFailedException>(
                   async () => await client.DetectLanguageAsync(input));

            // Re-rotate the subscription key and make sure it succeeds again
            credential.UpdateCredential(subscriptionKey);
            await client.DetectLanguageAsync(input);
        }
    }
}
