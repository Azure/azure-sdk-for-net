// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Testing;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection;
using Azure.Core;
using Azure.Identity.Tests.Mock;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialTests: ClientTestBase
    {
        public ManagedIdentityCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ResetManagedIdenityClient()
        {
            typeof(ManagedIdentityClient).GetField("s_msiType", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, 0);
            typeof(ManagedIdentityClient).GetField("s_endpoint", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, null);
        }

        [Test]
        [Ignore("This test can only be run from an environment where managed identity is enabled")]
        public async Task GetSystemTokenLiveAsync()
        {
            var credential = new ManagedIdentityCredential();

            var token = await credential.GetTokenAsync(new string[] { "https://management.azure.com//.default" });

            Assert.IsNotNull(token.Token);
        }
        [NonParallelizable]
        [Test]
        public async Task VerifyImdsRequestMockAsync()
        {
            using (new TestEnvVar("MSI_ENDPOINT", null))
            using (new TestEnvVar("MSI_SECRET", null))
            {
                var response = new MockResponse(200);

                var expectedToken = "mock-msi-access-token";

                response.SetContent($"{{ \"access_token\": \"{expectedToken}\", \"expires_on\": \"3600\" }}");

                var mockTransport = new MockTransport(response, response);

                var options = new IdentityClientOptions() { Transport = mockTransport };

                var client = InstrumentClient(new ManagedIdentityClient(options));

                AccessToken actualToken = await client.AuthenticateAsync(MockScopes.Default);

                Assert.AreEqual(expectedToken, actualToken.Token);

                MockRequest request = mockTransport.Requests[mockTransport.Requests.Count - 1];

                string query = request.UriBuilder.Query;

                Assert.IsTrue(query.Contains("api-version=2018-02-01"));

                Assert.IsTrue(query.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));

                Assert.IsTrue(request.Headers.TryGetValue("Metadata", out string metadataValue));

                Assert.AreEqual("true", metadataValue);
            }
        }
    }
}
