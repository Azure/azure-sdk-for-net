// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Core.Tests.Identity.Mock;
using Azure.Identity;
using Microsoft.Identity.Client;
using NUnit.Framework;
using MtlsBindingStrength = Microsoft.Identity.Client.AppConfig.MtlsBindingStrength;
using static Azure.Core.Tests.Identity.MsalManagedIdentityClientReflectionTests;

namespace Azure.Core.Tests.Identity
{
    [TestFixture(true)]
    [TestFixture(false)]
    [RunOnlyOnPlatforms(Windows = true)]
#if NETFRAMEWORK
    [Ignore("MSAL mTLS proof-of-possession configuration is not supported on .NET Framework.")]
#endif
    public class ManagedIdentityTenantFallbackTests : SyncAsyncTestBase
    {
        private const string Tenant = "11111111-1111-1111-1111-111111111111";
        private const string OtherTenant = "22222222-2222-2222-2222-222222222222";

        public ManagedIdentityTenantFallbackTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task FallsBackOnceAndPreservesContext()
        {
            using var cancellation = new CancellationTokenSource();
            TokenRequestContext context = CreateContext();
            var client = new TestMsalClient
            {
                Execute = (_, request, _) => request.IsProofOfPossessionEnabled
                    ? throw ManagedIdentityTenantErrorTests.CreateDenial()
                    : new ValueTask<AuthenticationResult>(AuthenticationResultFactory.Create(accessToken: "bearer-result"))
            };

            AuthenticationResult result = await Acquire(client, context, cancellation.Token);

            Assert.AreEqual("bearer-result", result.AccessToken);
            Assert.AreEqual(2, client.Attempts.Count);
            Attempt[] attempts = client.Attempts.ToArray();
            Assert.IsTrue(attempts[0].MtlsRequested);
            Assert.AreEqual(MtlsBindingStrength.KeyGuard, attempts[0].MinStrength);
            Assert.IsFalse(attempts[1].MtlsRequested);
            Assert.AreEqual(MtlsBindingStrength.None, attempts[1].MinStrength);
            Assert.IsFalse(attempts[1].Context.IsProofOfPossessionEnabled);
            Assert.IsNull(attempts[1].Context.ResourceRequestUri);
            Assert.IsNull(attempts[1].Context.ResourceRequestMethod);
            Assert.IsNull(attempts[1].Context.ProofOfPossessionNonce);
            Assert.AreSame(context.Scopes, attempts[1].Context.Scopes);
            Assert.AreEqual(context.TenantId, attempts[1].Context.TenantId);
            Assert.AreEqual(context.Claims, attempts[1].Context.Claims);
            Assert.AreEqual(context.ParentRequestId, attempts[1].Context.ParentRequestId);
            Assert.AreEqual(context.IsCaeEnabled, attempts[1].Context.IsCaeEnabled);
            Assert.AreEqual(cancellation.Token, attempts[1].CancellationToken);
            Assert.AreEqual(context.Claims, attempts[1].BuilderClaims);
            Assert.That(client.CreatedClients.ToArray(), Is.EqualTo(new[] { (true, true), (true, false) }));
            Assert.AreEqual(1, client.AttestationCalls);
            Assert.IsTrue(context.IsProofOfPossessionEnabled, "Do not mutate the caller's context.");
        }

        [TestCase(null)]
        [TestCase(Tenant)]
        public async Task RemembersDenialAcrossTokenAcquisitions(string tenant)
        {
            var client = DenyingClient();
            TokenRequestContext context = CreateContext(tenant);
            _ = await Acquire(client, context);
            _ = await Acquire(client, CreateContext(tenant, claims: """{"new":"claims"}"""));
            _ = await Acquire(client, CreateContext(tenant, resource: "https://storage.azure.com/.default"));

            Assert.AreEqual(4, client.Attempts.Count);
            Assert.AreEqual(1, client.Attempts.Count(attempt => attempt.MtlsRequested));
            Assert.IsFalse(client.GetEffectiveRequestContext(context).IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task DoesNotDisableAnotherTenantOrCredential()
        {
            var client = DenyingClient();
            _ = await Acquire(client, CreateContext());
            Assert.IsTrue(client.GetEffectiveRequestContext(CreateContext(OtherTenant)).IsProofOfPossessionEnabled);
            Assert.IsTrue(client.GetEffectiveRequestContext(CreateContext(null)).IsProofOfPossessionEnabled);

            var otherIdentity = new TestMsalClient("33333333-3333-3333-3333-333333333333");
            var recreatedCredential = new TestMsalClient();
            Assert.IsTrue(otherIdentity.GetEffectiveRequestContext(CreateContext()).IsProofOfPossessionEnabled);
            Assert.IsTrue(recreatedCredential.GetEffectiveRequestContext(CreateContext()).IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task SuccessfulAcquisitionDoesNotRecordDenial()
        {
            var client = new TestMsalClient();
            _ = await Acquire(client, CreateContext());
            Assert.AreEqual(1, client.Attempts.Count);
            Assert.IsTrue(client.GetEffectiveRequestContext(CreateContext()).IsProofOfPossessionEnabled);
        }

        [Test]
        [NonParallelizable]
        public async Task EmitsOneWarningWithoutTenantOrTokenDetails()
        {
            ConcurrentQueue<string> warnings = new();
            using var listener = new AzureEventSourceListener((eventData, message) =>
            {
                if (eventData.EventSource.Name == "Azure-Identity" &&
                    message.StartsWith("The token service denied attested token issuance", StringComparison.Ordinal))
                {
                    warnings.Enqueue(message);
                }
            }, EventLevel.Warning);
            var client = DenyingClient();

            _ = await Acquire(client, CreateContext());
            _ = await Acquire(client, CreateContext());

            Assert.AreEqual(1, warnings.Count);
            Assert.That(warnings.Single(), Does.Not.Contain(Tenant).And.Not.Contain("bearer-result"));
        }

        [TestCase(false, false, true, true)]
        [TestCase(true, true, true, true)]
        [TestCase(true, false, false, true)]
        [TestCase(true, false, true, false)]
        public void DoesNotFallbackUnlessMtlsWasActuallyAttempted(
            bool requested, bool disabled, bool capable, bool extensionPresent)
        {
            var denial = ManagedIdentityTenantErrorTests.CreateDenial();
            var client = new TestMsalClient(disabled: disabled)
            {
                ExtensionPresent = extensionPresent,
                Execute = (_, _, _) => throw denial
            };
            TokenRequestContext context = requested ? CreateContext() : new TokenRequestContext(MockScopes.Default, tenantId: Tenant);

            Exception actual = Assert.ThrowsAsync<MsalServiceException>(async () => await Acquire(client, context, capable: capable));

            Assert.AreSame(denial, actual);
            Assert.AreEqual(1, client.Attempts.Count);
            Assert.IsFalse(client.Attempts.Single().MtlsRequested);
            Assert.IsTrue(client.GetEffectiveRequestContext(CreateContext()).IsProofOfPossessionEnabled);
        }

        [TestCase("strength")]
        [TestCase("network")]
        [TestCase("scope")]
        [TestCase("server")]
        [TestCase("mismatch")]
        public void PreservesOtherFailures(string kind)
        {
            Exception failure = kind switch
            {
                "strength" => new MsalClientException(MsalError.MinStrengthNotMet, "Insufficient strength."),
                "network" => new System.IO.IOException("Network failure."),
                "scope" => new MsalServiceException("invalid_scope", "Invalid scope.", 400),
                "server" => ManagedIdentityTenantErrorTests.CreateDenial(500),
                _ => new MsalServiceException("invalid_client", "[MtlsCnfClaimRequestDataValidationFailed]", 401)
            };
            var client = new TestMsalClient { Execute = (_, _, _) => throw failure };

            Exception actual = Assert.CatchAsync<Exception>(async () => await Acquire(client, CreateContext()));

            Assert.AreSame(failure, actual);
            Assert.AreEqual(1, client.Attempts.Count);
            Assert.IsTrue(client.GetEffectiveRequestContext(CreateContext()).IsProofOfPossessionEnabled);
        }

        [Test]
        public void PropagatesBearerFailureWithoutLooping()
        {
            var denial = ManagedIdentityTenantErrorTests.CreateDenial();
            var client = new TestMsalClient { Execute = (_, _, _) => throw denial };

            Exception actual = Assert.ThrowsAsync<MsalServiceException>(async () => await Acquire(client, CreateContext()));

            Assert.AreSame(denial, actual);
            Assert.AreEqual(2, client.Attempts.Count);
            Assert.IsFalse(client.GetEffectiveRequestContext(CreateContext()).IsProofOfPossessionEnabled);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void CancellationBeforeFallbackDoesNotRecordDenial(bool returnServiceError)
        {
            using var cancellation = new CancellationTokenSource();
            var client = new TestMsalClient
            {
                Execute = (_, _, token) =>
                {
                    cancellation.Cancel();
                    if (returnServiceError)
                    {
                        throw ManagedIdentityTenantErrorTests.CreateDenial();
                    }
                    token.ThrowIfCancellationRequested();
                    throw new AssertionException("Cancellation should throw.");
                }
            };

            var actual = Assert.CatchAsync<OperationCanceledException>(async () => await Acquire(client, CreateContext(), cancellation.Token));

            Assert.AreEqual(cancellation.Token, actual.CancellationToken);
            Assert.AreEqual(1, client.Attempts.Count);
            Assert.IsTrue(client.GetEffectiveRequestContext(CreateContext()).IsProofOfPossessionEnabled);
        }

        [Test]
        public void CancellationDuringBearerAcquisitionStopsTheOperation()
        {
            using var cancellation = new CancellationTokenSource();
            var client = new TestMsalClient
            {
                Execute = (_, context, token) =>
                {
                    if (context.IsProofOfPossessionEnabled)
                    {
                        throw ManagedIdentityTenantErrorTests.CreateDenial();
                    }
                    cancellation.Cancel();
                    token.ThrowIfCancellationRequested();
                    throw new AssertionException("Cancellation should throw.");
                }
            };

            var actual = Assert.CatchAsync<OperationCanceledException>(async () => await Acquire(client, CreateContext(), cancellation.Token));
            Assert.AreEqual(cancellation.Token, actual.CancellationToken);
            Assert.AreEqual(2, client.Attempts.Count);
        }

        [Test]
        public async Task ConcurrentDenialsRemainBounded()
        {
            var entered = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var release = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            int popAttempts = 0;
            var client = new TestMsalClient
            {
                Execute = async (_, context, token) =>
                {
                    if (context.IsProofOfPossessionEnabled)
                    {
                        if (Interlocked.Increment(ref popAttempts) == 2)
                        {
                            entered.TrySetResult(true);
                        }
                        await release.Task;
                        throw ManagedIdentityTenantErrorTests.CreateDenial();
                    }
                    return AuthenticationResultFactory.Create(accessToken: "bearer-result");
                }
            };

            Task<AuthenticationResult> first = Task.Run(async () => await Acquire(client, CreateContext()));
            Task<AuthenticationResult> second = Task.Run(async () => await Acquire(client, CreateContext()));
            try
            {
                Assert.AreSame(entered.Task, await Task.WhenAny(entered.Task, Task.Delay(TimeSpan.FromSeconds(10))), "Both PoP attempts should be in flight.");
            }
            finally
            {
                release.TrySetResult(true);
                await Task.WhenAll(first, second);
            }

            Assert.AreEqual(4, client.Attempts.Count);
            _ = await Acquire(client, CreateContext());
            Assert.AreEqual(2, popAttempts);
            Assert.IsFalse(client.Attempts.Last().MtlsRequested);
        }

        [TestCase(false)]
        [TestCase(true)]
        [NonParallelizable]
        public async Task RememberedDenialSkipsCapabilityDiscoveryOnCredentialRenewal(bool chained)
        {
            using var environment = new TestEnvVar(new()
            {
                { "MSI_ENDPOINT", null },
                { "MSI_SECRET", null },
                { "IDENTITY_ENDPOINT", null },
                { "IDENTITY_HEADER", null },
                { "AZURE_POD_IDENTITY_AUTHORITY_HOST", null },
                { "AZURE_FEDERATED_TOKEN_FILE", null }
            });
            var msal = DenyingClient();
            var transport = new MockTransport(new MockResponse(400).WithJson("""{"error":"invalid_request","error_description":"Metadata header required."}"""));
            var options = new TokenCredentialOptions { Transport = transport, IsChainedCredential = chained };
            var client = new ManagedIdentityClient(new ManagedIdentityClientOptions
            {
                ManagedIdentityId = ManagedIdentityId.SystemAssigned,
                Options = options,
                Pipeline = CredentialPipeline.GetInstance(options),
                MsalManagedIdentityClientOverride = msal
            });
            var credential = new ManagedIdentityCredential(client);
            for (int i = 0; i < 2; i++)
            {
                AccessToken token = IsAsync
                    ? await credential.GetTokenAsync(CreateContext(), default)
                    : credential.GetToken(CreateContext(), default);
                Assert.AreEqual("bearer-result", token.Token);
            }

            Assert.AreEqual(1, msal.CapabilityCalls);
            Assert.AreEqual(3, msal.Attempts.Count);
            Assert.AreEqual(chained ? 1 : 0, transport.Requests.Count);
        }

        private Task<AuthenticationResult> Acquire(TestMsalClient client, TokenRequestContext context, CancellationToken token = default, bool capable = true) =>
            IsAsync
                ? client.AcquireTokenForManagedIdentityAsync(context, capable, token).AsTask()
                : Task.FromResult(client.AcquireTokenForManagedIdentity(context, capable, token));

        private static TestMsalClient DenyingClient() => new()
        {
            Execute = (_, context, _) => context.IsProofOfPossessionEnabled
                ? throw ManagedIdentityTenantErrorTests.CreateDenial()
                : new ValueTask<AuthenticationResult>(AuthenticationResultFactory.Create(accessToken: "bearer-result"))
        };

        private static TokenRequestContext CreateContext(string tenant = Tenant, string claims = """{"access_token":{}}""", string resource = "https://vault.azure.net/.default") =>
            new([resource],
                parentRequestId: "request-correlation",
                claims: claims,
                tenantId: tenant,
                isCaeEnabled: true,
                isProofOfPossessionEnabled: true,
                proofOfPossessionNonce: "nonce",
                requestUri: new Uri("https://vault.vault.azure.net/secrets/secret"),
                requestMethod: "GET");

        private record Attempt(TokenRequestContext Context, bool MtlsRequested, MtlsBindingStrength MinStrength, string BuilderClaims, CancellationToken CancellationToken);

        private class TestMsalClient : MsalManagedIdentityClient
        {
            public TestMsalClient(string identity = null, bool disabled = false)
                : base(new ManagedIdentityClientOptions
                {
                    ManagedIdentityId = identity == null ? Azure.Identity.ManagedIdentityId.SystemAssigned : Azure.Identity.ManagedIdentityId.FromUserAssignedClientId(identity),
                    DisableMtlsProofOfPossession = disabled
                })
            {
            }

            public ConcurrentQueue<Attempt> Attempts { get; } = new();
            public ConcurrentQueue<(bool Cae, bool Pop)> CreatedClients { get; } = new();
            public Func<AcquireTokenForManagedIdentityParameterBuilder, TokenRequestContext, CancellationToken, ValueTask<AuthenticationResult>> Execute { get; set; }
            public bool ExtensionPresent { get; set; } = true;
            public int AttestationCalls;
            public int CapabilityCalls;

            protected override ValueTask<IManagedIdentityApplication> CreateClientCoreAsync(bool async, bool enableCae, bool enableMtlsPop, CancellationToken cancellationToken)
            {
                CreatedClients.Enqueue((enableCae, enableMtlsPop));
                IManagedIdentityApplication client = ManagedIdentityApplicationBuilder.Create(ManagedIdentityId).Build();
                return new(client);
            }

            protected override Func<AcquireTokenForManagedIdentityParameterBuilder, AcquireTokenForManagedIdentityParameterBuilder> ResolveAttestationSupport() =>
                ExtensionPresent ? builder =>
                {
                    Interlocked.Increment(ref AttestationCalls);
                    return builder;
                }
            : null;

            public override ValueTask<Microsoft.Identity.Client.ManagedIdentity.ManagedIdentityCapabilities> GetManagedIdentityCapabilitiesCoreAsync(
                bool async, TokenRequestContext context, CancellationToken cancellationToken)
            {
                Interlocked.Increment(ref CapabilityCalls);
                return new(MockMsalManagedIdentityClient.CreateCapabilities(
                    Microsoft.Identity.Client.ManagedIdentity.ManagedIdentitySource.Imds, MtlsBindingStrength.KeyGuard));
            }

            protected override ValueTask<AuthenticationResult> ExecuteTokenRequestAsync(
                bool async, AcquireTokenForManagedIdentityParameterBuilder builder, TokenRequestContext context, CancellationToken cancellationToken)
            {
                Attempts.Enqueue(new Attempt(context,
                    GetCommonParameter<bool>(builder, "IsMtlsPopRequested"),
                    GetCommonParameter<MtlsBindingStrength>(builder, "MtlsPopMinStrength"),
                    GetCommonParameter<string>(builder, "Claims"),
                    cancellationToken));
                ValueTask<AuthenticationResult> result = Execute?.Invoke(builder, context, cancellationToken)
                    ?? new ValueTask<AuthenticationResult>(AuthenticationResultFactory.Create(accessToken: "success"));
#pragma warning disable AZC0102 // Match MSAL's blocking execution for the synchronous test path.
                return async ? result : new ValueTask<AuthenticationResult>(result.AsTask().GetAwaiter().GetResult());
#pragma warning restore AZC0102
            }
        }
    }
}
