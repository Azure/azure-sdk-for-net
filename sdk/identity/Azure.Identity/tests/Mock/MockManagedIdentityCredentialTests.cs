// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Azure.Core.Testing;
using Azure.Core;

namespace Azure.Identity.Tests.Mock
{
    public class MockManagedIdentityCredentialTests
    {
        [Test]
        public async Task CancellationTokenHonoredAsync()
        {
            var credential = new ManagedIdentityCredential();

            credential._client(new MockManagedIdentityClient());

            var cancellation = new CancellationTokenSource();

            Task<AccessToken> getTokenComplete = credential.GetTokenAsync(MockScopes.Default, cancellation.Token);

            cancellation.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(async () => await getTokenComplete, "failed to cancel GetToken call");

            await Task.CompletedTask;
        }
        
        [Test]
        public async Task ScopesHonoredAsync()
        {
            var credential = new ManagedIdentityCredential();

            credential._client(new MockManagedIdentityClient());

            AccessToken defaultScopeToken = await credential.GetTokenAsync(MockScopes.Default);

            Assert.IsTrue(new MockToken(defaultScopeToken.Token).HasField("scopes", MockScopes.Default.ToString()));
        }

        [Test]
        public async Task VerifyMSIRequest()
        {
            var pingResponse = new MockResponse(400);

            var response = new MockResponse(200);

            var expectedToken = "mock-msi-access-token";

            response.SetContent($"{{ \"access_token\": \"{expectedToken}\", \"expires_in\": 3600 }}");

            var mockTransport = new MockTransport(pingResponse, response);

            var options = new IdentityClientOptions() { Transport = mockTransport };

            var credential = new ManagedIdentityCredential(options: options);

            AccessToken actualToken = await credential.GetTokenAsync(MockScopes.Default);

            Assert.AreEqual(expectedToken, actualToken.Token);

            MockRequest request = mockTransport.Requests[1];

            string query = request.UriBuilder.Query;

            Assert.IsTrue(query.Contains("api-version=2018-02-01"));

            Assert.IsTrue(query.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));

            Assert.IsTrue(request.Headers.TryGetValue("Metadata", out string metadataValue));

            Assert.AreEqual("true", metadataValue);
        }
    }
}
