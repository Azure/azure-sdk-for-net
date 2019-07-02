using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialTests
    {
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

                var credential = new ManagedIdentityCredential(options: options);

                AccessToken actualToken = await credential.GetTokenAsync(MockScopes.Default);

                Assert.AreEqual(expectedToken, actualToken.Token);

                MockRequest request = mockTransport.Requests[mockTransport.Requests.Count - 1];

                string query = request.UriBuilder.Query;

                Assert.IsTrue(query.Contains("api-version=2018-02-01"));

                Assert.IsTrue(query.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));

                Assert.IsTrue(request.Headers.TryGetValue("Metadata", out string metadataValue));

                Assert.AreEqual("true", metadataValue);
            }
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyImdsRequestWithClientIdMockAsync()
        {
            using (new TestEnvVar("MSI_ENDPOINT", null))
            using (new TestEnvVar("MSI_SECRET", null))
            {
                var response = new MockResponse(200);

                var expectedToken = "mock-msi-access-token";

                response.SetContent($"{{ \"access_token\": \"{expectedToken}\", \"expires_on\": \"3600\" }}");

                var mockTransport = new MockTransport(response, response);

                var options = new IdentityClientOptions() { Transport = mockTransport };

                var credential = new ManagedIdentityCredential(clientId: "mock-client-id", options: options);

                AccessToken actualToken = await credential.GetTokenAsync(MockScopes.Default);

                Assert.AreEqual(expectedToken, actualToken.Token);

                MockRequest request = mockTransport.Requests[mockTransport.Requests.Count - 1];

                string query = request.UriBuilder.Query;

                Assert.IsTrue(query.Contains("api-version=2018-02-01"));

                Assert.IsTrue(query.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));

                Assert.IsTrue(query.Contains($"client_id=mock-client-id"));

                Assert.IsTrue(request.Headers.TryGetValue("Metadata", out string metadataValue));

                Assert.AreEqual("true", metadataValue);
            }
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyAppServiceMsiRequestMockAsync()
        {
            using (new TestEnvVar("MSI_ENDPOINT", "https://mock.msi.endpoint/"))
            using (new TestEnvVar("MSI_SECRET", "mock-msi-secret"))
            {
                var response = new MockResponse(200);

                var expectedToken = "mock-msi-access-token";

                response.SetContent($"{{ \"access_token\": \"{expectedToken}\", \"expires_on\": \"{DateTimeOffset.UtcNow.ToString()}\" }}");

                var mockTransport = new MockTransport(response);

                var options = new IdentityClientOptions() { Transport = mockTransport };

                var credential = new ManagedIdentityCredential(options: options);

                AccessToken actualToken = await credential.GetTokenAsync(MockScopes.Default);

                Assert.AreEqual(expectedToken, actualToken.Token);

                MockRequest request = mockTransport.Requests[0];

                Assert.IsTrue(request.UriBuilder.ToString().StartsWith("https://mock.msi.endpoint/"));

                string query = request.UriBuilder.Query;

                Assert.IsTrue(query.Contains("api-version=2017-09-01"));

                Assert.IsTrue(query.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));

                Assert.IsTrue(request.Headers.TryGetValue("secret", out string actSecretValue));

                Assert.AreEqual("mock-msi-secret", actSecretValue);
            }
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyAppServiceMsiRequestWithClientIdMockAsync()
        {
            using (new TestEnvVar("MSI_ENDPOINT", "https://mock.msi.endpoint/"))
            using (new TestEnvVar("MSI_SECRET", "mock-msi-secret"))
            {
                var response = new MockResponse(200);

                var expectedToken = "mock-msi-access-token";

                response.SetContent($"{{ \"access_token\": \"{expectedToken}\", \"expires_on\": \"{DateTimeOffset.UtcNow.ToString()}\" }}");

                var mockTransport = new MockTransport(response);

                var options = new IdentityClientOptions() { Transport = mockTransport };

                var credential = new ManagedIdentityCredential(clientId: "mock-client-id", options: options);

                AccessToken actualToken = await credential.GetTokenAsync(MockScopes.Default);

                Assert.AreEqual(expectedToken, actualToken.Token);

                MockRequest request = mockTransport.Requests[0];

                Assert.IsTrue(request.UriBuilder.ToString().StartsWith("https://mock.msi.endpoint/"));

                string query = request.UriBuilder.Query;

                Assert.IsTrue(query.Contains("api-version=2017-09-01"));

                Assert.IsTrue(query.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));

                Assert.IsTrue(query.Contains($"client_id=mock-client-id"));

                Assert.IsTrue(request.Headers.TryGetValue("secret", out string actSecretValue));

                Assert.AreEqual("mock-msi-secret", actSecretValue);
            }
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyCloudShellMsiRequestMockAsync()
        {
            using (new TestEnvVar("MSI_ENDPOINT", "https://mock.msi.endpoint/"))
            using (new TestEnvVar("MSI_SECRET", null))
            {
                var response = new MockResponse(200);

                var expectedToken = "mock-msi-access-token";

                response.SetContent($"{{ \"access_token\": \"{expectedToken}\", \"expires_on\": {(DateTimeOffset.UtcNow + TimeSpan.FromSeconds(3600)).ToUnixTimeSeconds()} }}");

                var mockTransport = new MockTransport(response);

                var options = new IdentityClientOptions() { Transport = mockTransport };

                var credential = new ManagedIdentityCredential(options: options);

                AccessToken actualToken = await credential.GetTokenAsync(MockScopes.Default);

                Assert.AreEqual(expectedToken, actualToken.Token);

                MockRequest request = mockTransport.Requests[0];

                Assert.IsTrue(request.UriBuilder.ToString().StartsWith("https://mock.msi.endpoint/"));

                Assert.IsTrue(request.Content.TryComputeLength(out long contentLen));

                var content = new byte[contentLen];

                MemoryStream contentBuff = new MemoryStream(content);

                request.Content.WriteTo(contentBuff, default);

                string body = Encoding.UTF8.GetString(content);

                Assert.IsTrue(body.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));

                Assert.IsTrue(request.Headers.TryGetValue("Metadata", out string actMetadata));

                Assert.AreEqual("true", actMetadata);
            }
        }

        [NonParallelizable]
        [Test]
        public async Task VerifyCloudShellMsiRequestWithClientIdMockAsync()
        {
            using (new TestEnvVar("MSI_ENDPOINT", "https://mock.msi.endpoint/"))
            using (new TestEnvVar("MSI_SECRET", null))
            {
                var response = new MockResponse(200);

                var expectedToken = "mock-msi-access-token";

                response.SetContent($"{{ \"access_token\": \"{expectedToken}\", \"expires_on\": {(DateTimeOffset.UtcNow + TimeSpan.FromSeconds(3600)).ToUnixTimeSeconds()} }}");

                var mockTransport = new MockTransport(response);

                var options = new IdentityClientOptions() { Transport = mockTransport };

                var credential = new ManagedIdentityCredential(clientId: "mock-client-id", options: options);

                AccessToken actualToken = await credential.GetTokenAsync(MockScopes.Default);

                Assert.AreEqual(expectedToken, actualToken.Token);

                MockRequest request = mockTransport.Requests[0];

                Assert.IsTrue(request.UriBuilder.ToString().StartsWith("https://mock.msi.endpoint/"));

                Assert.IsTrue(request.Content.TryComputeLength(out long contentLen));

                var content = new byte[contentLen];

                MemoryStream contentBuff = new MemoryStream(content);

                request.Content.WriteTo(contentBuff, default);

                string body = Encoding.UTF8.GetString(content);

                Assert.IsTrue(body.Contains($"resource={Uri.EscapeDataString(ScopeUtilities.ScopesToResource(MockScopes.Default))}"));

                Assert.IsTrue(body.Contains($"client_id=mock-client-id"));

                Assert.IsTrue(request.Headers.TryGetValue("Metadata", out string actMetadata));

                Assert.AreEqual("true", actMetadata);
            }
        }
    }
}
