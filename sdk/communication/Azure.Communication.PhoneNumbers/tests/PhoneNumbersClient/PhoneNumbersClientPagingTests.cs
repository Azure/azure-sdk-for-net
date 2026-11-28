// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.PhoneNumbers.Tests
{
    [TestFixture(true)]
    [TestFixture(false)]
    public class PhoneNumbersClientPagingTests
    {
        private const string Endpoint = "https://resource.communication.azure.com";
        private readonly bool _isAsync;

        public PhoneNumbersClientPagingTests(bool isAsync)
        {
            _isAsync = isAsync;
        }

        [TestCase("https://attacker.example/path?opaque=1&skip=1")]
        [TestCase("https://resource.communication.azure.com.attacker.example/path?opaque=1&skip=1")]
        [TestCase("https://resource.communication.azure.com@attacker.example/path?opaque=1&skip=1")]
        [TestCase("https://resource.communication.azure.com:8443/phoneNumbers?opaque=1&skip=1")]
        [TestCase("http://resource.communication.azure.com/phoneNumbers?opaque=1&skip=1")]
        public void RejectsForeignContinuationBeforeAuthentication(string continuationToken)
        {
            int tokenRequests = 0;
            var credential = new MockCredential { GetTokenCallback = (_, _) => tokenRequests++ };
            var transport = CreateTransport();
            var client = CreateClient(credential, transport);

            var exception = Assert.ThrowsAsync<InvalidOperationException>(async () => await ReadPagesAsync(client, continuationToken));

            Assert.That(exception, Has.Message.Contains("configured endpoint"));
            Assert.That(tokenRequests, Is.Zero);
            Assert.That(transport.Requests, Is.Empty);
        }

        [TestCase("https://resource.communication.azure.com/phoneNumbers?opaque=1&skip=1")]
        [TestCase("https://RESOURCE.communication.azure.com/phoneNumbers?opaque=1&skip=1")]
        [TestCase("https://resource.communication.azure.com:443/phoneNumbers?opaque=1&skip=1")]
        [TestCase("/phoneNumbers?opaque=1&skip=1")]
        public async Task AllowsSameOriginContinuation(string continuationToken)
        {
            var transport = CreateTransport();
            var client = CreateClient(new MockCredential(), transport);

            Assert.That(await ReadPagesAsync(client, continuationToken), Is.EqualTo(1));

            var request = transport.SingleRequest;
            Assert.That(request.Uri.ToUri().GetLeftPart(UriPartial.Authority), Is.EqualTo(Endpoint));
            Assert.That(request.Uri.ToUri().AbsolutePath, Is.EqualTo("/phoneNumbers"));
            Assert.That(request.Uri.ToUri().Query, Is.EqualTo("?opaque=1&skip=1"));
            Assert.That(request.Headers.TryGetValue("Authorization", out string? authorization), Is.True);
            Assert.That(authorization, Does.StartWith("Bearer TEST TOKEN "));
        }

        [TestCase(null)]
        [TestCase("")]
        public async Task AllowsInitialPage(string? continuationToken)
        {
            int tokenRequests = 0;
            var credential = new MockCredential { GetTokenCallback = (_, _) => tokenRequests++ };
            var transport = CreateTransport();
            var client = CreateClient(credential, transport);

            Assert.That(await ReadPagesAsync(client, continuationToken), Is.EqualTo(1));

            Assert.That(tokenRequests, Is.EqualTo(1));
            Assert.That(transport.SingleRequest.Uri.ToUri().GetLeftPart(UriPartial.Authority), Is.EqualTo(Endpoint));
        }

        [Test]
        public void RejectsForeignServiceNextLinkWithoutSendingCachedToken()
        {
            int tokenRequests = 0;
            var credential = new MockCredential { GetTokenCallback = (_, _) => tokenRequests++ };
            var transport = CreateTransport(
                new MockResponse(200).SetContent(JsonSerializer.Serialize(new
                {
                    phoneNumbers = Array.Empty<object>(),
                    nextLink = "https://attacker.example/path?opaque=1&skip=1"
                })),
                new MockResponse(200).SetContent("{\"phoneNumbers\":[]}"));
            var client = CreateClient(credential, transport);

            var exception = Assert.ThrowsAsync<InvalidOperationException>(async () => await ReadPagesAsync(client));

            Assert.That(exception, Has.Message.Contains("configured endpoint"));
            Assert.That(tokenRequests, Is.EqualTo(1));
            Assert.That(transport.Requests, Has.Count.EqualTo(1));
            Assert.That(transport.SingleRequest.Uri.ToUri().GetLeftPart(UriPartial.Authority), Is.EqualTo(Endpoint));
        }

        [Test]
        public async Task FollowsSameOriginServiceNextLink()
        {
            var transport = CreateTransport(
                new MockResponse(200).SetContent(JsonSerializer.Serialize(new
                {
                    phoneNumbers = Array.Empty<object>(),
                    nextLink = Endpoint + "/phoneNumbers?opaque=1&skip=1"
                })),
                new MockResponse(200).SetContent("{\"phoneNumbers\":[]}"));
            var client = CreateClient(new MockCredential(), transport);

            Assert.That(await ReadPagesAsync(client), Is.EqualTo(2));

            Assert.That(transport.Requests, Has.Count.EqualTo(2));
            foreach (var request in transport.Requests)
            {
                Assert.That(request.Uri.ToUri().GetLeftPart(UriPartial.Authority), Is.EqualTo(Endpoint));
                Assert.That(request.Headers.TryGetValue("Authorization", out string? authorization), Is.True);
                Assert.That(authorization, Does.StartWith("Bearer TEST TOKEN "));
            }
        }

        [Test]
        public async Task AllowsConfiguredCustomEndpointPort()
        {
            const string customEndpoint = Endpoint + ":8443";
            var transport = CreateTransport();
            var client = CreateClient(new MockCredential(), transport, customEndpoint);

            Assert.That(await ReadPagesAsync(client, customEndpoint + "/phoneNumbers?opaque=1&skip=1"), Is.EqualTo(1));

            Assert.That(transport.SingleRequest.Uri.ToUri().Port, Is.EqualTo(8443));
        }

        private static MockTransport CreateTransport(params MockResponse[] responses)
        {
            return new MockTransport(responses.Length == 0
                ? new[] { new MockResponse(200).SetContent("{\"phoneNumbers\":[]}") }
                : responses);
        }

        private static PhoneNumbersClient CreateClient(MockCredential credential, MockTransport transport, string endpoint = Endpoint)
        {
            var options = new PhoneNumbersClientOptions { Transport = transport };
            options.Retry.MaxRetries = 0;
            return new PhoneNumbersClient(new Uri(endpoint), credential, options);
        }

        private async Task<int> ReadPagesAsync(PhoneNumbersClient client, string? continuationToken = null)
        {
            int pages = 0;
            if (_isAsync)
            {
                await foreach (var page in client.GetPurchasedPhoneNumbersAsync().AsPages(continuationToken))
                {
                    pages++;
                }
            }
            else
            {
                foreach (var page in client.GetPurchasedPhoneNumbers().AsPages(continuationToken))
                {
                    pages++;
                }
            }
            return pages;
        }
    }
}
