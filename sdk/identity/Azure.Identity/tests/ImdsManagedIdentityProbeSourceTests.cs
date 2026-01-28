// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ImdsManagedIdentityProbeSourceTests : ClientTestBase
    {
        public ImdsManagedIdentityProbeSourceTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task DefaultAzureCredentialSkipsImdsProbeWhenMICredIsConfiguredViaEnv()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TOKEN_CREDENTIALS", "ManagedIdentityCredential" },
                { "IDENTITY_ENDPOINT", "http://localhost:12345/token" },
                { "IDENTITY_HEADER", "test-header-value" },
            }))
            {
                List<string> requestUris = new();
                List<TimeSpan?> networkTimeouts = new();

                var mockTransport = MockTransport.FromMessageCallback(msg =>
                {
                    requestUris.Add(msg.Request.Uri.ToString());
                    networkTimeouts.Add(msg.NetworkTimeout);

                    // All requests should have the X-IDENTITY-HEADER for App Service MI
                    bool hasIdentityHeader = msg.Request.Headers.TryGetValue("X-IDENTITY-HEADER", out _);
                    Assert.IsTrue(hasIdentityHeader, $"Request to {msg.Request.Uri} should have X-IDENTITY-HEADER");

                    return CreateMockResponse(200, "token");
                });

                var cred = new DefaultAzureCredential(new DefaultAzureCredentialOptions
                {
                    ExcludeAzureCliCredential = true,
                    ExcludeAzureDeveloperCliCredential = true,
                    ExcludeAzurePowerShellCredential = true,
                    ExcludeEnvironmentCredential = true,
                    ExcludeSharedTokenCacheCredential = true,
                    ExcludeVisualStudioCodeCredential = true,
                    ExcludeVisualStudioCredential = true,
                    ExcludeWorkloadIdentityCredential = true,
                    Transport = mockTransport,
                    IsForceRefreshEnabled = true
                });

                await cred.GetTokenAsync(new(new[] { "test" }));

                // Verify that IMDS endpoint (169.254.169.254) was NOT contacted
                Assert.That(requestUris.All(uri => !uri.Contains("169.254.169.254")), Is.True,
                    "IMDS endpoint should not be contacted when IDENTITY_ENDPOINT and IDENTITY_HEADER are set");

                // Verify all requests went to the configured IDENTITY_ENDPOINT
                Assert.That(requestUris.All(uri => uri.Contains("localhost:12345")), Is.True,
                    "All requests should go to the configured IDENTITY_ENDPOINT");

                // Verify no network timeouts were set (no probing behavior)
                Assert.That(networkTimeouts.All(t => t == null), Is.True,
                    "No network timeouts should be set when using App Service MI");
            }
        }

        [Test]
        public async Task DefaultAzureCredentialSkipsImdsProbeWhenMICredIsConfiguredViaCustomEnv()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "MY_CUSTOM_ENV_VAR", "ManagedIdentityCredential" },
                { "IDENTITY_ENDPOINT", "http://localhost:12345/token" },
                { "IDENTITY_HEADER", "test-header-value" },
            }))
            {
                List<string> requestUris = new();
                List<TimeSpan?> networkTimeouts = new();

                var mockTransport = MockTransport.FromMessageCallback(msg =>
                {
                    requestUris.Add(msg.Request.Uri.ToString());
                    networkTimeouts.Add(msg.NetworkTimeout);

                    // All requests should have the X-IDENTITY-HEADER for App Service MI
                    bool hasIdentityHeader = msg.Request.Headers.TryGetValue("X-IDENTITY-HEADER", out _);
                    Assert.IsTrue(hasIdentityHeader, $"Request to {msg.Request.Uri} should have X-IDENTITY-HEADER");

                    return CreateMockResponse(200, "token");
                });

                var cred = new DefaultAzureCredential("MY_CUSTOM_ENV_VAR", new DefaultAzureCredentialOptions
                {
                    ExcludeAzureCliCredential = true,
                    ExcludeAzureDeveloperCliCredential = true,
                    ExcludeAzurePowerShellCredential = true,
                    ExcludeEnvironmentCredential = true,
                    ExcludeSharedTokenCacheCredential = true,
                    ExcludeVisualStudioCodeCredential = true,
                    ExcludeVisualStudioCredential = true,
                    ExcludeWorkloadIdentityCredential = true,
                    Transport = mockTransport,
                    IsForceRefreshEnabled = true
                });

                await cred.GetTokenAsync(new(new[] { "test" }));

                // Verify that IMDS endpoint (169.254.169.254) was NOT contacted
                Assert.That(requestUris.All(uri => !uri.Contains("169.254.169.254")), Is.True,
                    "IMDS endpoint should not be contacted when IDENTITY_ENDPOINT and IDENTITY_HEADER are set");

                // Verify all requests went to the configured IDENTITY_ENDPOINT
                Assert.That(requestUris.All(uri => uri.Contains("localhost:12345")), Is.True,
                    "All requests should go to the configured IDENTITY_ENDPOINT");

                // Verify no network timeouts were set (no probing behavior)
                Assert.That(networkTimeouts.All(t => t == null), Is.True,
                    "No network timeouts should be set when using App Service MI");
            }
        }

        [Test]
        public void ManagedIdentityCredentialRespectsCancellationToken()
        {
            int callCount = 0;

            var mockTransport = MockTransport.FromMessageCallback(msg =>
            {
                Task.Delay(1000).GetAwaiter().GetResult();
                callCount++;
                return CreateMockResponse(500, "Error").WithHeader("Content-Type", "application/json");
            });

            var options = new TokenCredentialOptions() { Transport = mockTransport };
            options.Retry.MaxDelay = TimeSpan.FromSeconds(1);

            var cred = new ManagedIdentityCredential(
                "testCLientId", options);

            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.Zero);
            var ex = Assert.CatchAsync(async () => await cred.GetTokenAsync(new(new[] { "test" }), cts.Token));
            Assert.IsTrue(ex is TaskCanceledException || ex is OperationCanceledException, "Expected TaskCanceledException or OperationCanceledException but got " + ex.GetType().ToString());

            // Default number of retries is 5, so we should just ensure we have less than that.
            // Timing on some platforms makes this test somewhat non-deterministic, so we just ensure we have less than 2 calls.
            Assert.Less(callCount, 2);
        }

        private MockResponse CreateMockResponse(int responseCode, string token)
        {
            var response = new MockResponse(responseCode);
            string jsonData = $"{{ \"access_token\": \"{token}\", \"expires_on\": \"{DateTimeOffset.UtcNow.AddHours(2).ToUnixTimeSeconds()}\" }}";
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
            response.ContentStream = new MemoryStream(byteArray);
            return response;
        }
    }
}
