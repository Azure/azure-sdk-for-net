// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Core.Tests.Identity.Mock;
using NUnit.Framework;

using Azure.Identity;
namespace Azure.Core.Tests.Identity
{
    public class ImdsManagedIdentityProbeSourceTests : ClientTestBase
    {
        public ImdsManagedIdentityProbeSourceTests(bool isAsync) : base(isAsync)
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
                return msg.Request.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out string val) && val == "true" ?
                 CreateMockResponse(200, "token").WithHeader("Content-Type", "application/json") :
                 CreateMockResponse(400, "Error").WithHeader("Content-Type", "application/json");
            });

            var cred = CreateDefaultAzureCredentialWithMockMsal(new DefaultAzureCredentialOptions
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
        public async Task DefaultAzureCredentialDoesNotProbeAndAttemptsRetriesWhenMICredIsConfiguredViaEnv()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TOKEN_CREDENTIALS", "ManagedIdentityCredential" },
            }))
            {
                int callCount = 0;
                List<TimeSpan?> networkTimeouts = new();

                var mockTransport = MockTransport.FromMessageCallback(msg =>
                {
                    callCount++;
                    networkTimeouts.Add(msg.NetworkTimeout);
                    // Validate that there is no probe request (which does not have the Metadata header)
                    Assert.IsTrue(msg.Request.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out string val) && val == "true");
                    return callCount switch
                    {
                        < 6 => CreateMockResponse(500, "{ \"Error\": \"Some error occurred\" }").WithHeader("Content-Type", "application/json"),
                        _ => CreateMockResponse(200, "token").WithHeader("Content-Type", "application/json")
                    };
                });

                var cred = CreateDefaultAzureCredentialWithMockMsal(new DefaultAzureCredentialOptions
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
                    IsForceRefreshEnabled = true,
                    Retry = { Delay = TimeSpan.Zero }
                });

                // When ManagedIdentityCredential is configured via environment variable, there are no timeouts and retries are performed
                await cred.GetTokenAsync(new(new[] { "test" }));

                var expectedTimeouts = new TimeSpan?[] { null, null, null, null, null, null };
                CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
                networkTimeouts.Clear();

                await cred.GetTokenAsync(new(new[] { "test" }));

                expectedTimeouts = new TimeSpan?[] { null };
                CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
            }
        }

        [Test]
        public async Task DefaultAzureCredentialDoesNotProbeAndAttemptsRetriesWhenMICredIsConfiguredViaCustomEnv()
        {
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "MY_CUSTOM_ENV_VAR", "ManagedIdentityCredential" },
            }))
            {
                int callCount = 0;
                List<TimeSpan?> networkTimeouts = new();

                var mockTransport = MockTransport.FromMessageCallback(msg =>
                {
                    callCount++;
                    networkTimeouts.Add(msg.NetworkTimeout);
                    // Validate that there is no probe request (which does not have the Metadata header)
                    Assert.IsTrue(msg.Request.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out string val) && val == "true", "Expected Metadata header with value 'true'");
                    return callCount switch
                    {
                        < 6 => CreateMockResponse(500, "{ \"Error\": \"Some error occurred\" }").WithHeader("Content-Type", "application/json"),
                        _ => CreateMockResponse(200, "token").WithHeader("Content-Type", "application/json")
                    };
                });

                var cred = CreateDefaultAzureCredentialWithMockMsal(new DefaultAzureCredentialOptions
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
                    IsForceRefreshEnabled = true,
                    Retry = { Delay = TimeSpan.Zero }
                }, "MY_CUSTOM_ENV_VAR");

                // First request validates that there are no network timeouts and retries are performed
                await cred.GetTokenAsync(new(new[] { "test" }));

                var expectedTimeouts = new TimeSpan?[] { null, null, null, null, null, null };
                CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
                networkTimeouts.Clear();

                await cred.GetTokenAsync(new(new[] { "test" }));

                expectedTimeouts = new TimeSpan?[] { null };
                CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
            }
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
                Debug.WriteLine($"Call count: {callCount}, Has Metadata Header: {msg.Request.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out string val2)}");
                Console.WriteLine($"Call count: {callCount}, Has Metadata Header: {msg.Request.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out val2)}");
                return callCount switch
                {
                    1 => throw new TaskCanceledException(),
                    _ => msg.Request.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out string val) && val == "true" ?
                        CreateMockResponse(200, "token").WithHeader("Content-Type", "application/json") :
                        CreateMockResponse(400, "Error").WithHeader("Content-Type", "application/json")
                };
            });

            var cred = CreateDefaultAzureCredentialWithMockMsal(new DefaultAzureCredentialOptions
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
                return msg.Request.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out string val) && val == "true" ?
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
                IsForceRefreshEnabled = true,
                RetryPolicy = new RetryPolicy(7, DelayStrategy.CreateFixedDelayStrategy(TimeSpan.Zero))
            };

            var cred = CreateDefaultAzureCredentialWithMockMsal(credOptions);

            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await cred.GetTokenAsync(new(new[] { "test" })));

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
                Assert.IsTrue(msg.Request.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out _));
                return CreateMockResponse(500, "Error").WithHeader("Content-Type", "application/json");
            });

            var options = new TokenCredentialOptions() { Transport = mockTransport };
            options.Retry.MaxDelay = TimeSpan.Zero;

            var cred = CreateManagedIdentityCredentialWithMockMsal("testCLientId", options);

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new(new[] { "test" })));

            var expectedTimeouts = new TimeSpan?[] { null, null, null, null, null, null };
            CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
        }

        [Test]
        public void ManagedIdentityCredentialRetryBehaviorIsOverriddenWithOptions()
        {
            int callCount = 0;
            List<TimeSpan?> networkTimeouts = new();

            var mockTransport = MockTransport.FromMessageCallback(msg =>
            {
                callCount++;
                networkTimeouts.Add(msg.NetworkTimeout);
                Assert.IsTrue(msg.Request.Headers.TryGetValue(ImdsManagedIdentityProbeSource.metadataHeaderName, out _));
                return CreateMockResponse(500, "Error").WithHeader("Content-Type", "application/json");
            });

            var options = new TokenCredentialOptions()
            {
                Transport = mockTransport,
                RetryPolicy = new RetryPolicy(1, DelayStrategy.CreateFixedDelayStrategy(TimeSpan.Zero))
            };
            options.Retry.MaxDelay = TimeSpan.Zero;

            var cred = CreateManagedIdentityCredentialWithMockMsal("testCLientId", options);

            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await cred.GetTokenAsync(new(new[] { "test" })));

            var expectedTimeouts = new TimeSpan?[] { null, null };
            CollectionAssert.AreEqual(expectedTimeouts, networkTimeouts);
        }

        [Test]
        public void ManagedIdentityCredentialRespectsCancellationToken()
        {
            int callCount = 0;

            var mockTransport = MockTransport.FromMessageCallback(msg =>
            {
                if (msg.CancellationToken.IsCancellationRequested)
                {
                    throw new OperationCanceledException(msg.CancellationToken);
                }

                Task.Delay(1000, msg.CancellationToken).GetAwaiter().GetResult();
                callCount++;
                return CreateMockResponse(500, "Error").WithHeader("Content-Type", "application/json");
            });

            var options = new TokenCredentialOptions() { Transport = mockTransport };
            options.Retry.MaxDelay = TimeSpan.FromSeconds(1);

            var cred = CreateManagedIdentityCredentialWithMockMsal("testCLientId", options);

            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.Zero);
            var ex = Assert.CatchAsync(async () => await cred.GetTokenAsync(new(new[] { "test" }), cts.Token));
            bool hasCancellation = ex is TaskCanceledException || ex is OperationCanceledException;
            for (Exception current = ex; !hasCancellation && current != null; current = current.InnerException)
            {
                hasCancellation = current is TaskCanceledException || current is OperationCanceledException;
            }
            Assert.IsTrue(hasCancellation || ex is AuthenticationFailedException,
                "Expected cancellation or wrapped authentication failure but got " + ex.GetType().ToString());

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

        private static ManagedIdentityCredential CreateManagedIdentityCredentialWithMockMsal(string clientId, TokenCredentialOptions options)
        {
            var miOptions = new ManagedIdentityClientOptions
            {
                Pipeline = CredentialPipeline.GetInstance(options, IsManagedIdentityCredential: true),
                ManagedIdentityId = string.IsNullOrEmpty(clientId) ? ManagedIdentityId.SystemAssigned : ManagedIdentityId.FromUserAssignedClientId(clientId),
                Options = options
            };

            miOptions.MsalManagedIdentityClientOverride = new MockMsalManagedIdentityClient(miOptions);
            return new ManagedIdentityCredential(new ManagedIdentityClient(miOptions));
        }

        private static DefaultAzureCredential CreateDefaultAzureCredentialWithMockMsal(DefaultAzureCredentialOptions options, string customEnvironmentVariableName = null)
        {
            var factory = string.IsNullOrEmpty(customEnvironmentVariableName)
                ? new ProbeTestDefaultAzureCredentialFactory(options)
                : new ProbeTestDefaultAzureCredentialFactory(options, customEnvironmentVariableName);

            return new DefaultAzureCredential(factory);
        }

        private sealed class ProbeTestDefaultAzureCredentialFactory : DefaultAzureCredentialFactory
        {
            public ProbeTestDefaultAzureCredentialFactory(DefaultAzureCredentialOptions options)
                : base(options)
            {
            }

            public ProbeTestDefaultAzureCredentialFactory(DefaultAzureCredentialOptions options, string customEnvironmentVariableName)
                : base(options, customEnvironmentVariableName)
            {
            }

            public override TokenCredential CreateManagedIdentityCredential(bool isChained = true)
            {
                var options = Options.Clone<DefaultAzureCredentialOptions>();
                options.IsChainedCredential = isChained;

                var miOptions = new ManagedIdentityClientOptions
                {
                    Pipeline = CredentialPipeline.GetInstance(options, IsManagedIdentityCredential: true),
                    Options = options,
                    InitialImdsConnectionTimeout = TimeSpan.FromSeconds(1),
                    ExcludeTokenExchangeManagedIdentitySource = options.ExcludeWorkloadIdentityCredential,
                    IsForceRefreshEnabled = options.IsForceRefreshEnabled,
                    ManagedIdentityId = options.ManagedIdentityClientId != null
                        ? ManagedIdentityId.FromUserAssignedClientId(options.ManagedIdentityClientId)
                        : options.ManagedIdentityResourceId != null
                            ? ManagedIdentityId.FromUserAssignedResourceId(options.ManagedIdentityResourceId)
                            : ManagedIdentityId.SystemAssigned
                };

                miOptions.MsalManagedIdentityClientOverride = new MockMsalManagedIdentityClient(miOptions);
                return new ManagedIdentityCredential(new ManagedIdentityClient(miOptions));
            }
        }
    }
}
