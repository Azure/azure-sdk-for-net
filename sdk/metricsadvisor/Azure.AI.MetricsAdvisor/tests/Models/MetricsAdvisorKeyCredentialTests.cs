// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Tests
{
    public class MetricsAdvisorKeyCredentialTests : MockClientTestBase
    {
        public MetricsAdvisorKeyCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task MetricsAdvisorKeyCredentialSendsSecretInMetricsAdvisorClient()
        {
            MockResponse response = new MockResponse(200);
            response.SetContent("{}");

            MockTransport mockTransport = new MockTransport(response);

            string expectedSubscriptionKey = "fakeSubscriptionKey";
            string expectedApiKey = "fakeApiKey";
            MetricsAdvisorKeyCredential credential = new MetricsAdvisorKeyCredential(expectedSubscriptionKey, expectedApiKey);

            MetricsAdvisorClient client = CreateInstrumentedClient(mockTransport, credential);

            IAsyncEnumerator<MetricFeedback> asyncEnumerator = client.GetAllFeedbackAsync(FakeGuid).GetAsyncEnumerator();
            await asyncEnumerator.MoveNextAsync();

            MockRequest request = mockTransport.Requests.First();

            Assert.That(request.Headers.TryGetValue(Constants.SubscriptionAuthorizationHeader, out string subscriptionKey));
            Assert.That(request.Headers.TryGetValue(Constants.ApiAuthorizationHeader, out string apiKey));

            Assert.That(subscriptionKey, Is.EqualTo(expectedSubscriptionKey));
            Assert.That(apiKey, Is.EqualTo(expectedApiKey));
        }

        [Test]
        public async Task MetricsAdvisorKeyCredentialSendsSecretInMetricsAdvisorAdministrationClient()
        {
            MockResponse response = new MockResponse(204);
            MockTransport mockTransport = new MockTransport(response);

            string expectedSubscriptionKey = "fakeSubscriptionKey";
            string expectedApiKey = "fakeApiKey";
            MetricsAdvisorKeyCredential credential = new MetricsAdvisorKeyCredential(expectedSubscriptionKey, expectedApiKey);

            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport, credential);

            await adminClient.DeleteAlertConfigurationAsync(FakeGuid);

            MockRequest request = mockTransport.Requests.First();

            Assert.That(request.Headers.TryGetValue(Constants.SubscriptionAuthorizationHeader, out string subscriptionKey));
            Assert.That(request.Headers.TryGetValue(Constants.ApiAuthorizationHeader, out string apiKey));

            Assert.That(subscriptionKey, Is.EqualTo(expectedSubscriptionKey));
            Assert.That(apiKey, Is.EqualTo(expectedApiKey));
        }

        [Test]
        public async Task MetricsAdvisorKeyCredentialUpdatesSecret()
        {
            MockResponse response = new MockResponse(204);
            MockTransport mockTransport = new MockTransport(response);
            MetricsAdvisorKeyCredential credential = new MetricsAdvisorKeyCredential("fakeSubscriptionKey", "fakeApiKey");

            string expectedSubscriptionKey = "newFakeSubscriptionKey";
            string expectedApiKey = "newFakeApiKey";

            MetricsAdvisorAdministrationClient adminClient = CreateInstrumentedAdministrationClient(mockTransport, credential);

            credential.Update(expectedSubscriptionKey, expectedApiKey);

            await adminClient.DeleteAlertConfigurationAsync(FakeGuid);

            MockRequest request = mockTransport.Requests.First();

            Assert.That(request.Headers.TryGetValue(Constants.SubscriptionAuthorizationHeader, out string subscriptionKey));
            Assert.That(request.Headers.TryGetValue(Constants.ApiAuthorizationHeader, out string apiKey));

            Assert.That(subscriptionKey, Is.EqualTo(expectedSubscriptionKey));
            Assert.That(apiKey, Is.EqualTo(expectedApiKey));
        }
    }
}
