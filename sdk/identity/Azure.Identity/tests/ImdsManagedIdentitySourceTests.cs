﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ImdsManagedIdentitySourceTests : ClientTestBase
    {
        public ImdsManagedIdentitySourceTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task DefaultAzureCredentialProbeUses1secTimeoutWithNoRetries()
        {
            int callCount = 0;
            List<TimeSpan?> networkTimeouts = new();

            // the mock transport succeeds on the 2nd request to avoid long exponential back-offs,
            // but is sufficient to validate the initial timeout and retry behavior
            var mockTransport = MockTransport.FromMessageCallback(msg =>
            {
                callCount++;
                networkTimeouts.Add(msg.NetworkTimeout);
                return callCount > 1 ?
                 CreateMockResponse(200, "token").WithHeader("Content-Type", "application/json") :
                 CreateMockResponse(400, "Error").WithHeader("Content-Type", "application/json");
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
                Transport = mockTransport
            });

            //First request uses a 1 second timeout and no retries
            await cred.GetTokenAsync(new(new[] { "test" }));

            var expectedTimeouts = new TimeSpan?[] { TimeSpan.FromSeconds(1), null };
            CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
            networkTimeouts.Clear();

            await cred.GetTokenAsync(new(new[] { "test" }));

            expectedTimeouts = new TimeSpan?[] { null };
            CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
        }

        [Test]
        public async Task DefaultAzureCredentialUsesFirstRequestBehaviorUntilFirstResponse()
        {
            int callCount = 0;
            List<TimeSpan?> networkTimeouts = new();

            // the mock transport succeeds on the 2nd request to avoid long exponential back-offs,
            // but is sufficient to validate the initial timeout and retry behavior
            var mockTransport = MockTransport.FromMessageCallback(msg =>
            {
                callCount++;
                networkTimeouts.Add(msg.NetworkTimeout);
                return callCount switch
                {
                    1 => throw new TaskCanceledException(),
                    2 => CreateMockResponse(400, "Error").WithHeader("Content-Type", "application/json"),
                    _ => CreateMockResponse(200, "token").WithHeader("Content-Type", "application/json"),
                };
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
                Transport = mockTransport
            });

            //First request times out (throws TaskCancelledException) uses a 1 second timeout and no retries
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await cred.GetTokenAsync(new(new[] { "test" })));

            var expectedTimeouts = new TimeSpan?[] { TimeSpan.FromSeconds(1) };
            CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
            networkTimeouts.Clear();

            // Second request gets the expected probe response and should use the probe timeout on first request and default timeout on the retry
            await cred.GetTokenAsync(new(new[] { "test" }));

            expectedTimeouts = new TimeSpan?[] { TimeSpan.FromSeconds(1), null };
            CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
        }

        [Test]
        public void DefaultAzureCredentialRetryBehaviorIsOverriddenWithOptions()
        {
            int callCount = 0;
            List<TimeSpan?> networkTimeouts = new();

            var mockTransport = MockTransport.FromMessageCallback(msg =>
            {
                callCount++;
                networkTimeouts.Add(msg.NetworkTimeout);
                return callCount > 1 ?
                 CreateMockResponse(500, "Error").WithHeader("Content-Type", "application/json") :
                 CreateMockResponse(400, "Error").WithHeader("Content-Type", "application/json");
            });
            var credOptions = new DefaultAzureCredentialOptions
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
                RetryPolicy = new RetryPolicy(7, DelayStrategy.CreateFixedDelayStrategy(TimeSpan.Zero))
            };

            var cred = new DefaultAzureCredential(credOptions);

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new(new[] { "test" })));

            var expectedTimeouts = new TimeSpan?[] { TimeSpan.FromSeconds(1), null, null, null, null, null, null, null, null };
            CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
        }

        [Test]
        public void ManagedIdentityCredentialUsesDefaultTimeoutAndRetries()
        {
            int callCount = 0;
            List<TimeSpan?> networkTimeouts = new();

            var mockTransport = MockTransport.FromMessageCallback(msg =>
            {
                callCount++;
                networkTimeouts.Add(msg.NetworkTimeout);
                Assert.IsTrue(msg.Request.Headers.TryGetValue(ImdsManagedIdentitySource.metadataHeaderName, out _));
                return CreateMockResponse(500, "Error").WithHeader("Content-Type", "application/json");
            });

            var options = new TokenCredentialOptions() { Transport = mockTransport };
            options.Retry.MaxDelay = TimeSpan.Zero;

            var cred = new ManagedIdentityCredential(
                "testCLientId", options);

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new(new[] { "test" })));

            var expectedTimeouts = new TimeSpan?[] { null, null, null, null, null, null };
            CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
        }

        private MockResponse CreateMockResponse(int responseCode, string token)
        {
            var response = new MockResponse(responseCode);
            string jsonData = $"{{ \"access_token\": \"{token}\", \"expires_on\": \"3600\" }}";
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
            response.ContentStream = new MemoryStream(byteArray);
            return response;
        }
    }
}
