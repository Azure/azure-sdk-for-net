// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Core.Tests.Identity.Mock;
using Azure.Identity;
using Microsoft.Identity.Client;
using NUnit.Framework;
using MsalManagedIdentitySource = Microsoft.Identity.Client.ManagedIdentity.ManagedIdentitySource;

namespace Azure.Core.Tests.Identity
{
    [NonParallelizable]
    public class MsalManagedIdentityClientTests : ClientTestBase
    {
        public MsalManagedIdentityClientTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        [TearDown]
        public void ResetMsalState()
        {
            ApplicationBase.ResetStateForTest();
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task CapabilityDiscoveryCancelsRetryDelayWithoutCachingResult(bool cancelCaller)
        {
            using var environment = new TestEnvVar(new()
            {
                { "MSI_ENDPOINT", null },
                { "MSI_SECRET", null },
                { "IDENTITY_ENDPOINT", null },
                { "IDENTITY_HEADER", null },
                { "IDENTITY_SERVER_THUMBPRINT", null },
                { "IMDS_ENDPOINT", null },
                { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null }
            });
            using var callerCts = new CancellationTokenSource(TimeSpan.FromSeconds(15));
            int requestCount = 0;
            var options = new TokenCredentialOptions
            {
                IsChainedCredential = true,
                Transport = new MockTransport(_ =>
                {
                    requestCount++;
                    if (cancelCaller)
                    {
                        callerCts.Cancel();
                    }

                    // MSAL waits ten seconds before retrying a 410 response unless discovery cancels the delay.
                    return new MockResponse(410);
                })
            };
            options.Retry.MaxRetries = 0;
            var client = new TestMsalManagedIdentityClient(new ManagedIdentityClientOptions
            {
                Options = options,
                Pipeline = CredentialPipeline.GetInstance(options),
                InitialImdsConnectionTimeout = TimeSpan.FromSeconds(1)
            });
            var context = new TokenRequestContext(MockScopes.Default, isProofOfPossessionEnabled: true);
            var stopwatch = Stopwatch.StartNew();

            if (cancelCaller)
            {
                Assert.CatchAsync<OperationCanceledException>(
                    async () => await client.GetManagedIdentityCapabilitiesCoreAsync(IsAsync, context, callerCts.Token));
            }
            else
            {
                var exception = Assert.ThrowsAsync<MsalServiceException>(
                    async () => await client.GetManagedIdentityCapabilitiesCoreAsync(IsAsync, context, callerCts.Token));
                Assert.AreEqual(MsalError.RequestTimeout, exception.ErrorCode);
                Assert.IsFalse(callerCts.IsCancellationRequested);
            }

            Assert.Less(stopwatch.Elapsed, TimeSpan.FromSeconds(5));
            Assert.AreEqual(1, requestCount);

            Environment.SetEnvironmentVariable("IDENTITY_ENDPOINT", "https://localhost/identity");
            Environment.SetEnvironmentVariable("IDENTITY_HEADER", "test-identity-header");
            var capabilities = await client.GetManagedIdentityCapabilitiesCoreAsync(IsAsync, context, CancellationToken.None);

            Assert.AreEqual(MsalManagedIdentitySource.AppService, capabilities.Source);
            Assert.AreEqual(1, requestCount);
        }

        private class TestMsalManagedIdentityClient : MsalManagedIdentityClient
        {
            public TestMsalManagedIdentityClient(ManagedIdentityClientOptions options) : base(options)
            {
            }

            protected override ValueTask<IManagedIdentityApplication> CreateClientCoreAsync(bool async, bool enableCae, bool enableMtlsPop, CancellationToken cancellationToken)
            {
                // Preserve MSAL-owned retries as in the mTLS path, but route HTTP through the mock transport.
                var application = ManagedIdentityApplicationBuilder.Create(ManagedIdentityId)
                    .WithHttpClientFactory(new HttpPipelineClientFactory(Pipeline.HttpPipeline, Pipeline.ClientOptions), true)
                    .Build();
                return new ValueTask<IManagedIdentityApplication>(application);
            }
        }
    }
}
