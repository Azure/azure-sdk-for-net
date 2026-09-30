// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Diagnostics;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Tests;
using NUnit.Framework;

namespace Azure.Security.KeyVault.Secrets.Tests
{
    [NonParallelizable]
    public class TenantTokenBindingCredentialTests : SyncAsyncPolicyTestBase
    {
        private const string Tenant = "11111111-1111-1111-1111-111111111111";
        private const string OtherTenant = "22222222-2222-2222-2222-222222222222";
        private const string BearerType = "Bearer";
        private const string DenialMessage = "AADSTS3921996: Tenant is not allowed to receive a bound token using attested certificate.";
        private static readonly Uri VaultUri = new("https://test.vault.azure.net");
        private static readonly string Challenge = $"{BearerType} authorization=\"https://login.microsoftonline.com/{Tenant}\", resource=\"https://vault.azure.net\"";

        public TenantTokenBindingCredentialTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUp() => ChallengeBasedAuthenticationPolicy.ClearCache();

        [TestCase("AADSTS3921996")]
        [TestCase(DenialMessage)]
        [TestCase("ManagedIdentityCredential authentication failed: AADSTS3921996: Tenant not allowed.")]
        [TestCase("Original exception:\r\nAADSTS3921996: Tenant not allowed.\r\nTrace ID: test")]
        [TestCase("(AADSTS3921996)")]
        [TestCase("AADSTS39219960 is not the code; AADSTS3921996 is.")]
        [TestCase("""{"error_description":"AADSTS3921996: Tenant not allowed."}""")]
        public void MatchesExactTenantDenialCode(string message)
        {
            Assert.IsTrue(TenantTokenBindingCredential.IsTenantNotAllowedForBoundToken(message));
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase("{")]
        [TestCase("null")]
        [TestCase("[]")]
        [TestCase("42")]
        [TestCase("""{"error_codes":3921996}""")]
        [TestCase("""{"error_codes":null}""")]
        [TestCase("""{"error_codes":[]}""")]
        [TestCase("""{"error_codes":["3921996"]}""")]
        [TestCase("""{"error_codes":[true]}""")]
        [TestCase("""{"error_codes":[2147483648]}""")]
        [TestCase("""{"error_codes":[3921996.5]}""")]
        [TestCase("""{"error_codes":[392196]}""")]
        [TestCase("""{"error_codes":[3921996,1000604]}""")]
        [TestCase("""{"error_codes":[3921996],"error_codes":[3921996]}""")]
        [TestCase("""{"error":{"error_codes":[3921996]}}""")]
        [TestCase("""{"error":"MtlsMsiTenantNotAllowedForBoundToken"}""")]
        [TestCase("Tenant is not allowed to receive a bound token using attested certificate.")]
        [TestCase("AADSTS39219960: Different error.")]
        [TestCase("AADSTS3921996suffix")]
        [TestCase("prefixAADSTS3921996")]
        [TestCase("_AADSTS3921996")]
        [TestCase("AADSTS3921996_")]
        [TestCase("AADSTS3921996\u0660")]
        [TestCase("\u00e9AADSTS3921996")]
        [TestCase("aadsts3921996")]
        [TestCase("AADSTS1000604: Invalid request parameters.")]
        public void RejectsMessagesWithoutExactTenantDenialCode(string message)
        {
            Assert.IsFalse(TenantTokenBindingCredential.IsTenantNotAllowedForBoundToken(message));
        }

        [TestCase("direct")]
        [TestCase("managed")]
        [TestCase("selected")]
        [TestCase("probe")]
        [TestCase("aggregate")]
        [TestCase("opaque-inner-chain")]
        [TestCase("wrapped-aggregate")]
        [TestCase("nested-unavailable-aggregate")]
        public async Task RecognizesCredentialExceptionWrappers(string wrapper)
        {
            var inner = DenyingCredential(WrapDenial(wrapper));
            var credential = new TenantTokenBindingCredential(inner);

            AccessToken token = await Acquire(credential, Context());

            Assert.AreEqual("bearer-result", token.Token);
            Assert.That(inner.Contexts.Select(c => c.IsProofOfPossessionEnabled), Is.EqualTo(new[] { true, false }));
            Assert.IsFalse(credential.GetEffectiveRequestContext(Context()).IsProofOfPossessionEnabled);
        }

        [TestCase("AADSTS39219960")]
        [TestCase("Tenant not eligible.")]
        [TestCase("""{"error_codes":[3921996]}""")]
        public void UnrecognizedCredentialMessageDoesNotRememberFallback(string message)
        {
            var error = new AuthenticationFailedException("Managed identity failed.", new Exception(message));
            var inner = DenyingCredential(error);
            var credential = new TenantTokenBindingCredential(inner);

            Exception actual = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await Acquire(credential, Context()));

            Assert.AreSame(error, actual);
            Assert.AreEqual(1, inner.Contexts.Count);
            Assert.IsTrue(credential.GetEffectiveRequestContext(Context()).IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task PreservesContextAndCancellationInBearerAcquisition()
        {
            using var cancellation = new CancellationTokenSource();
            var inner = DenyingCredential(WrapDenial("managed"));
            var credential = new TenantTokenBindingCredential(inner);
            TokenRequestContext context = Context();

            _ = await Acquire(credential, context, cancellation.Token);

            TokenRequestContext fallback = inner.Contexts.Last();
            Assert.AreSame(context.Scopes, fallback.Scopes);
            Assert.AreEqual(context.TenantId, fallback.TenantId);
            Assert.AreEqual(context.Claims, fallback.Claims);
            Assert.AreEqual(context.ParentRequestId, fallback.ParentRequestId);
            Assert.AreEqual(context.IsCaeEnabled, fallback.IsCaeEnabled);
            Assert.IsFalse(fallback.IsProofOfPossessionEnabled);
            Assert.IsNull(fallback.ProofOfPossessionNonce);
            Assert.IsNull(fallback.ResourceRequestUri);
            Assert.IsNull(fallback.ResourceRequestMethod);
            Assert.That(inner.Cancellations, Is.All.EqualTo(cancellation.Token));
            Assert.IsTrue(context.IsProofOfPossessionEnabled);
        }

        [TestCase(null)]
        [TestCase(Tenant)]
        public async Task RemembersDenialAcrossRenewalsAndResources(string tenant)
        {
            var inner = DenyingCredential(WrapDenial("managed"));
            var credential = new TenantTokenBindingCredential(inner);
            _ = await Acquire(credential, Context(tenant));
            _ = await Acquire(credential, Context(tenant, claims: """{"refresh":"claims"}"""));
            _ = await Acquire(credential, Context(tenant, scope: "https://managedhsm.azure.net/.default"));

            Assert.That(inner.Contexts.Select(c => c.IsProofOfPossessionEnabled), Is.EqualTo(new[] { true, false, false, false }));
        }

        [Test]
        public async Task DoesNotDisableOtherTenantsOrClients()
        {
            var inner = new CallbackCredential((context, _) =>
            {
                if (context.TenantId == Tenant && context.IsProofOfPossessionEnabled)
                {
                    throw WrapDenial("managed");
                }
                return new ValueTask<AccessToken>(Token(context.IsProofOfPossessionEnabled));
            });
            var credential = new TenantTokenBindingCredential(inner);
            _ = await Acquire(credential, Context());
            _ = await Acquire(credential, Context(OtherTenant));
            Assert.IsTrue(inner.Contexts.Last().IsProofOfPossessionEnabled);

            var anotherClient = new TenantTokenBindingCredential(inner);
            _ = await Acquire(anotherClient, Context());
            Assert.IsTrue(inner.Contexts.ToArray()[3].IsProofOfPossessionEnabled);
            Assert.IsTrue(credential.GetEffectiveRequestContext(Context(null)).IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task DoesNotDowngradeSuccessfulPopAcquisition()
        {
            var inner = new CallbackCredential((context, _) => new ValueTask<AccessToken>(Token(true)));
            var credential = new TenantTokenBindingCredential(inner);
            AccessToken token = await Acquire(credential, Context());
            Assert.AreEqual("mtls_pop", token.TokenType);
            Assert.AreEqual(1, inner.Contexts.Count);
            Assert.IsTrue(credential.GetEffectiveRequestContext(Context()).IsProofOfPossessionEnabled);
        }

        [Test]
        public void DoesNotFallbackWhenPopWasNotRequested()
        {
            Exception error = WrapDenial("managed");
            var inner = new CallbackCredential((_, _) => throw error);
            var credential = new TenantTokenBindingCredential(inner);

            Exception actual = Assert.ThrowsAsync<AuthenticationFailedException>(
                async () => await Acquire(credential, new TokenRequestContext(["https://vault.azure.net/.default"], tenantId: Tenant)));

            Assert.AreSame(error, actual);
            Assert.AreEqual(1, inner.Contexts.Count);
            Assert.IsTrue(credential.GetEffectiveRequestContext(Context()).IsProofOfPossessionEnabled);
        }

        [TestCase("strength")]
        [TestCase("network")]
        [TestCase("scope")]
        [TestCase("server")]
        [TestCase("mismatch")]
        [TestCase("arbitrary-wrapper")]
        [TestCase("mixed-aggregate")]
        [TestCase("unavailable-only")]
        [TestCase("raw-denial")]
        [TestCase("network-denial")]
        [TestCase("request-failed-denial")]
        [TestCase("wrapped-cancellation")]
        [TestCase("nested-cancellation")]
        [TestCase("raw-aggregate")]
        [TestCase("wrapped-aggregate-denial")]
        [TestCase("aggregate-summary-denial")]
        [TestCase("mixed-unavailable-aggregate")]
        [TestCase("nested-mixed-aggregate")]
        [TestCase("unavailable-with-diagnostic")]
        [TestCase("ancestor-summary-denial")]
        [TestCase("mixed-opaque-terminal")]
        [TestCase("mixed-nested-terminal-aggregate")]
        [TestCase("mixed-cancellation-aggregate")]
        public void PreservesUnrelatedFailures(string kind)
        {
            Exception error = kind switch
            {
                "strength" => new AuthenticationFailedException("Failed.", new Exception("Insufficient strength.")),
                "network" => new System.IO.IOException("Network failure."),
                "scope" => new AuthenticationFailedException("Failed.", new Exception("AADSTS70011: Invalid scope.")),
                "server" => new AuthenticationFailedException("Failed.", new Exception("Internal server error.")),
                "mismatch" => new RequestFailedException(401, "[MtlsCnfClaimRequestDataValidationFailed]"),
                "arbitrary-wrapper" => new Exception("AADSTS3921996", Denial()),
                "mixed-aggregate" => new CredentialUnavailableException("Failed.", new AggregateException(
                    new CredentialUnavailableException("Denied.", Denial()),
                    new AuthenticationFailedException("Unrelated failure."))),
                "raw-denial" => Denial(),
                "network-denial" => new System.IO.IOException(DenialMessage),
                "request-failed-denial" => new RequestFailedException(401, DenialMessage),
                "wrapped-cancellation" => new AuthenticationFailedException(DenialMessage, new OperationCanceledException()),
                "nested-cancellation" => new AuthenticationFailedException("Failed.", new Exception(DenialMessage, new OperationCanceledException())),
                "raw-aggregate" => new AggregateException(WrapDenial("probe"), new Exception("Unrelated failure.")),
                "wrapped-aggregate-denial" => new AuthenticationFailedException(DenialMessage, new AggregateException(Denial())),
                "aggregate-summary-denial" => new CredentialUnavailableException(DenialMessage,
                    new AggregateException(new CredentialUnavailableException("Unavailable."))),
                "mixed-unavailable-aggregate" => new CredentialUnavailableException("Failed.", new AggregateException(
                    WrapDenial("probe"),
                    new CredentialUnavailableException("Failed.", new AuthenticationFailedException("AADSTS70011: Invalid scope.")))),
                "nested-mixed-aggregate" => new AuthenticationFailedException(DenialMessage,
                    new CredentialUnavailableException("Failed.", new AggregateException(WrapDenial("probe"), new AuthenticationFailedException("Unrelated failure.")))),
                "unavailable-with-diagnostic" => new CredentialUnavailableException("Unavailable.", new System.IO.FileNotFoundException("Provider configuration missing.")),
                "ancestor-summary-denial" => new AuthenticationFailedException(DenialMessage,
                    new CredentialUnavailableException("All sources unavailable.", new AggregateException(new CredentialUnavailableException("Unavailable.")))),
                "mixed-opaque-terminal" => new CredentialUnavailableException("Failed.", new AggregateException(
                    WrapDenial("probe"),
                    new CredentialUnavailableException("Unavailable.", new Exception("Diagnostic.", new AuthenticationFailedException("Unrelated failure."))))),
                "mixed-nested-terminal-aggregate" => new CredentialUnavailableException("Failed.", new AggregateException(
                    WrapDenial("probe"),
                    new CredentialUnavailableException("Unavailable.", new AuthenticationFailedException("Unrelated failure.",
                        new CredentialUnavailableException("Unavailable.", new AggregateException(new CredentialUnavailableException("Unavailable."))))))),
                "mixed-cancellation-aggregate" => new CredentialUnavailableException("Failed.", new AggregateException(
                    WrapDenial("probe"), new CredentialUnavailableException("Unavailable.", new OperationCanceledException()))),
                _ => new CredentialUnavailableException("Unavailable.", new AggregateException(new CredentialUnavailableException("Unavailable.")))
            };
            var inner = new CallbackCredential((_, _) => throw error);
            var credential = new TenantTokenBindingCredential(inner);

            Exception actual = Assert.CatchAsync<Exception>(async () => await Acquire(credential, Context()));

            Assert.AreSame(error, actual);
            Assert.AreEqual(1, inner.Contexts.Count);
            Assert.IsTrue(credential.GetEffectiveRequestContext(Context()).IsProofOfPossessionEnabled);
        }

        [Test]
        public void PropagatesBearerFailureWithoutLooping()
        {
            Exception error = WrapDenial("managed");
            var inner = new CallbackCredential((_, _) => throw error);
            var credential = new TenantTokenBindingCredential(inner);

            Exception actual = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await Acquire(credential, Context()));

            Assert.AreSame(error, actual);
            Assert.That(inner.Contexts.Select(c => c.IsProofOfPossessionEnabled), Is.EqualTo(new[] { true, false }));
            Assert.IsFalse(credential.GetEffectiveRequestContext(Context()).IsProofOfPossessionEnabled);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void CancellationDoesNotStartFallback(bool returnDenial)
        {
            using var cancellation = new CancellationTokenSource();
            var inner = new CallbackCredential((_, token) =>
            {
                cancellation.Cancel();
                if (returnDenial)
                {
                    throw WrapDenial("managed");
                }
                token.ThrowIfCancellationRequested();
                throw new AssertionException("Expected cancellation.");
            });
            var credential = new TenantTokenBindingCredential(inner);

            var error = Assert.CatchAsync<OperationCanceledException>(async () => await Acquire(credential, Context(), cancellation.Token));

            Assert.AreEqual(cancellation.Token, error.CancellationToken);
            Assert.AreEqual(1, inner.Contexts.Count);
            Assert.IsTrue(credential.GetEffectiveRequestContext(Context()).IsProofOfPossessionEnabled);
        }

        [Test]
        public void CancellationDuringFallbackPropagates()
        {
            using var cancellation = new CancellationTokenSource();
            var inner = new CallbackCredential((context, token) =>
            {
                if (context.IsProofOfPossessionEnabled)
                {
                    throw WrapDenial("managed");
                }
                cancellation.Cancel();
                token.ThrowIfCancellationRequested();
                throw new AssertionException("Expected cancellation.");
            });
            var credential = new TenantTokenBindingCredential(inner);
            _ = Assert.CatchAsync<OperationCanceledException>(async () => await Acquire(credential, Context(), cancellation.Token));
            Assert.AreEqual(2, inner.Contexts.Count);
        }

        [Test]
        public async Task ConcurrentDenialsHaveBoundedAcquisitions()
        {
            var entered = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var release = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            int popAttempts = 0;
            var inner = new CallbackCredential(async (context, _) =>
            {
                if (context.IsProofOfPossessionEnabled)
                {
                    if (Interlocked.Increment(ref popAttempts) == 2)
                    {
                        entered.TrySetResult(true);
                    }
                    await release.Task;
                    throw WrapDenial("managed");
                }
                return Token(false);
            });
            var credential = new TenantTokenBindingCredential(inner);
            Task<AccessToken> first = Task.Run(async () => await Acquire(credential, Context()));
            Task<AccessToken> second = Task.Run(async () => await Acquire(credential, Context()));
            try
            {
                Assert.AreSame(entered.Task, await Task.WhenAny(entered.Task, Task.Delay(TimeSpan.FromSeconds(10))));
            }
            finally
            {
                release.TrySetResult(true);
                await Task.WhenAll(first, second);
            }

            Assert.AreEqual(4, inner.Contexts.Count);
            _ = await Acquire(credential, Context());
            Assert.AreEqual(2, popAttempts);
            Assert.IsFalse(inner.Contexts.Last().IsProofOfPossessionEnabled);
        }

        [TestCase("none")]
        [TestCase("file")]
        [TestCase("json")]
        [TestCase("process")]
        [TestCase("opaque")]
        [TestCase("nested")]
        [TestCase("opaque-aadsts")]
        public async Task ChainedCredentialCanRecoverFromUnavailableAggregate(string cause)
        {
            Exception diagnostic = cause switch
            {
                "none" => null,
                "file" => new System.IO.FileNotFoundException("Provider configuration missing."),
                "json" => new System.Text.Json.JsonException("Provider configuration invalid."),
                "process" => new System.ComponentModel.Win32Exception("Credential process unavailable."),
                "opaque" => new Exception("Provider unavailable."),
                "nested" => new Exception("Provider unavailable.", new InvalidOperationException("Provider not configured.")),
                "opaque-aadsts" => new Exception("AADSTS70011: Invalid scope."),
                _ => throw new ArgumentException("Unknown cause.", nameof(cause))
            };
            var unavailable = new CallbackCredential((_, _) => throw new CredentialUnavailableException("Unavailable.", diagnostic));
            var managedIdentity = DenyingCredential(WrapDenial("probe"));
            var chain = new ChainedTokenCredential(unavailable, managedIdentity);
            var credential = new TenantTokenBindingCredential(chain);

            AccessToken result = await Acquire(credential, Context());

            Assert.AreEqual("bearer-result", result.Token);
            Assert.That(managedIdentity.Contexts.Select(c => c.IsProofOfPossessionEnabled), Is.EqualTo(new[] { true, false }));
            Assert.IsFalse(credential.GetEffectiveRequestContext(Context()).IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task SecretClientUsesRememberedBearerModeAndPreservesWriteContent()
        {
            var inner = DenyingCredential(WrapDenial("managed"));
            int requests = 0;
            var transport = new MockTransport(request =>
            {
                if (requests++ == 0)
                {
                    Assert.IsNull(request.Content);
                    return new MockResponse(401).WithHeader("WWW-Authenticate", Challenge);
                }
                Assert.IsNotNull(request.Content);
                Assert.IsFalse(request.Headers.Contains("x-ms-tokenboundauth"));
                Assert.IsTrue(request.Headers.TryGetValue("Authorization", out string auth));
                Assert.AreEqual($"{BearerType} bearer-result", auth);
                return Success();
            });
            var client = new SecretClient(VaultUri, inner, new SecretClientOptions { Transport = transport });
            for (int i = 0; i < 3; i++)
            {
                KeyVaultSecret secret = IsAsync
                    ? await client.SetSecretAsync("secret", "value")
                    : client.SetSecret("secret", "value");
                Assert.AreEqual("value", secret.Value);
            }

            Assert.That(inner.Contexts.Select(c => c.IsProofOfPossessionEnabled), Is.EqualTo(new[] { true, false, false, false }));
            Assert.AreEqual(4, requests);
        }

        [Test]
        public async Task CaeReauthorizationRetainsBearerMode()
        {
            var inner = DenyingCredential(WrapDenial("managed"));
            string claims = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes("""{"access_token":{}}"""));
            string cae = $"{BearerType} authorization_uri=\"https://login.microsoftonline.com/{Tenant}\", error=\"insufficient_claims\", claims=\"{claims}\"";
            var transport = new MockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", Challenge),
                new MockResponse(401).WithHeader("WWW-Authenticate", cae),
                Success());
            var client = new SecretClient(VaultUri, inner, new SecretClientOptions { Transport = transport });

            _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");

            Assert.That(inner.Contexts.Select(c => c.IsProofOfPossessionEnabled), Is.EqualTo(new[] { true, false, false }));
            Assert.AreEqual("""{"access_token":{}}""", inner.Contexts.Last().Claims);
            Assert.IsFalse(transport.Requests.Last().Headers.Contains("x-ms-tokenboundauth"));
        }

        [Test]
        public async Task CertificateMismatchRetryDoesNotActivateBearerFallback()
        {
            var inner = new CallbackCredential((context, _) => new ValueTask<AccessToken>(Token(true)));
            var transport = new MockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", Challenge),
                new MockResponse(401).WithJson("""{"error":{"message":"[MtlsCnfClaimRequestDataValidationFailed]"}}"""),
                Success());
            var options = new SecretClientOptions { Transport = transport };
            options.Retry.MaxRetries = 1;
            options.Retry.Delay = TimeSpan.Zero;
            var client = new SecretClient(VaultUri, inner, options);

            _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");

            Assert.That(inner.Contexts.Select(c => c.IsProofOfPossessionEnabled), Is.All.True);
            Assert.AreEqual(3, transport.Requests.Count);
            Assert.IsTrue(transport.Requests.Last().Headers.Contains("x-ms-tokenboundauth"));
        }

        [Test]
        public void TransportExceptionCannotTriggerCredentialFallback()
        {
            var inner = new CallbackCredential((_, _) => new ValueTask<AccessToken>(Token(true)));
            int requests = 0;
            var error = WrapDenial("managed");
            var transport = new MockTransport(_ => requests++ == 0
                ? new MockResponse(401).WithHeader("WWW-Authenticate", Challenge)
                : throw error);
            var client = new SecretClient(VaultUri, inner, new SecretClientOptions { Transport = transport });

            Exception actual = Assert.ThrowsAsync<AuthenticationFailedException>(async () =>
            {
                _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");
            });

            Assert.AreSame(error, actual);
            Assert.AreEqual(1, inner.Contexts.Count);
            Assert.IsTrue(inner.Contexts.Single().IsProofOfPossessionEnabled);
        }

        [Test]
        public async Task TokenRenewalFallbackRemovesPreviouslyBoundHeader()
        {
            int popCalls = 0;
            var inner = new CallbackCredential((context, _) =>
            {
                if (context.IsProofOfPossessionEnabled && Interlocked.Increment(ref popCalls) > 1)
                {
                    throw WrapDenial("managed");
                }
                return new ValueTask<AccessToken>(Token(context.IsProofOfPossessionEnabled));
            });
            var boundHeaders = new ConcurrentQueue<bool>();
            int requests = 0;
            var transport = new MockTransport(request =>
            {
                boundHeaders.Enqueue(request.Headers.Contains("x-ms-tokenboundauth"));
                return requests++ == 0
                    ? new MockResponse(401).WithHeader("WWW-Authenticate", Challenge)
                    : Success();
            });
            var client = new SecretClient(VaultUri, inner, new SecretClientOptions { Transport = transport });
            for (int i = 0; i < 3; i++)
            {
                _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");
            }

            Assert.That(boundHeaders, Is.EqualTo(new[] { false, true, false, false }));
            Assert.That(inner.Contexts.Select(c => c.IsProofOfPossessionEnabled), Is.EqualTo(new[] { true, true, false, false }));
        }

        [Test]
        public async Task SecretClientKeepsValidBearerTokensCachedAfterFallback()
        {
            var inner = new CallbackCredential((context, _) =>
                context.IsProofOfPossessionEnabled
                    ? throw WrapDenial("managed")
                    : new ValueTask<AccessToken>(new AccessToken("bearer-result", DateTimeOffset.UtcNow.AddHours(1))));
            int requests = 0;
            var transport = new MockTransport(request =>
            {
                if (requests++ == 0)
                {
                    return new MockResponse(401).WithHeader("WWW-Authenticate", Challenge);
                }
                Assert.IsFalse(request.Headers.Contains("x-ms-tokenboundauth"));
                Assert.IsTrue(request.Headers.TryGetValue("Authorization", out string authorization));
                Assert.AreEqual($"{BearerType} bearer-result", authorization);
                return Success();
            });
            var client = new SecretClient(VaultUri, inner, new SecretClientOptions { Transport = transport });

            _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");
            _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");
            int acquisitions = inner.Contexts.Count;

            _ = IsAsync ? await client.GetSecretAsync("another-secret") : client.GetSecret("another-secret");
            _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");

            Assert.AreEqual(acquisitions, inner.Contexts.Count);
            Assert.That(inner.Contexts.Skip(1).Select(c => c.IsProofOfPossessionEnabled), Is.All.False);
            Assert.AreEqual(5, requests);
        }

        [Test]
        public async Task BackgroundRenewalDenialSwitchesNewRequestsToBearer()
        {
            var bearerStarted = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var releaseBearer = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            var bearerFinished = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            int popCalls = 0;
            int bearerCalls = 0;
            var inner = new CallbackCredential(async (context, _) =>
            {
                if (context.IsProofOfPossessionEnabled)
                {
                    if (Interlocked.Increment(ref popCalls) > 1)
                    {
                        throw WrapDenial("managed");
                    }
                    return new AccessToken("bound-result", DateTimeOffset.UtcNow.AddHours(1), DateTimeOffset.UtcNow.AddMinutes(-1), "mtls_pop");
                }

                if (Interlocked.Increment(ref bearerCalls) == 1)
                {
                    bearerStarted.TrySetResult(true);
                    await releaseBearer.Task;
                    bearerFinished.TrySetResult(true);
                }
                return new AccessToken("bearer-result", DateTimeOffset.UtcNow.AddHours(1));
            });
            var authorizations = new ConcurrentQueue<string>();
            var boundHeaders = new ConcurrentQueue<bool>();
            int requests = 0;
            var transport = new MockTransport(request =>
            {
                request.Headers.TryGetValue("Authorization", out string authorization);
                authorizations.Enqueue(authorization);
                boundHeaders.Enqueue(request.Headers.Contains("x-ms-tokenboundauth"));
                return requests++ == 0
                    ? new MockResponse(401).WithHeader("WWW-Authenticate", Challenge)
                    : Success();
            });
            var client = new SecretClient(VaultUri, inner, new SecretClientOptions { Transport = transport });

            try
            {
                _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");
                _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");
                Assert.AreSame(bearerStarted.Task, await Task.WhenAny(bearerStarted.Task, Task.Delay(TimeSpan.FromSeconds(10))));

                // The background bearer acquisition is still pending, but the denial is already remembered.
                _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");

                Assert.AreEqual($"{BearerType} bearer-result", authorizations.Last());
                Assert.IsFalse(boundHeaders.Last());
                Assert.AreEqual(2, popCalls);
                Assert.AreEqual(2, bearerCalls);
            }
            finally
            {
                releaseBearer.TrySetResult(true);
                if (bearerStarted.Task.IsCompleted)
                {
                    Assert.AreSame(bearerFinished.Task, await Task.WhenAny(bearerFinished.Task, Task.Delay(TimeSpan.FromSeconds(10))));
                }
            }
        }

        [Test]
        public void ServiceRejectionOfBearerStillFails()
        {
            var inner = DenyingCredential(WrapDenial("managed"));
            var transport = new MockTransport(
                new MockResponse(401).WithHeader("WWW-Authenticate", Challenge),
                new MockResponse(403).WithJson("""{"error":{"code":"Forbidden","message":"Access denied."}}"""));
            var client = new SecretClient(VaultUri, inner, new SecretClientOptions { Transport = transport });

            var error = Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                _ = IsAsync ? await client.GetSecretAsync("secret") : client.GetSecret("secret");
            });

            Assert.AreEqual(403, error.Status);
            Assert.AreEqual(2, transport.Requests.Count);
        }

        [Test]
        public async Task WarningIsEmittedOnceWithoutSensitiveDetails()
        {
            ConcurrentQueue<string> warnings = new();
            using var listener = new AzureEventSourceListener((data, message) =>
            {
                if (data.EventSource.Name == "Azure-Security-KeyVault-Secrets-Authentication" && data.EventId == 1)
                {
                    warnings.Enqueue(message);
                }
            }, EventLevel.Warning);
            var credential = new TenantTokenBindingCredential(DenyingCredential(WrapDenial("managed")));

            _ = await Acquire(credential, Context());
            _ = await Acquire(credential, Context());

            Assert.AreEqual(1, warnings.Count);
            Assert.That(warnings.Single(), Does.Not.Contain(Tenant).And.Not.Contain("bearer-result"));
        }

        private Task<AccessToken> Acquire(TokenCredential credential, TokenRequestContext context, CancellationToken cancellationToken = default) =>
            IsAsync
                ? credential.GetTokenAsync(context, cancellationToken).AsTask()
                : Task.FromResult(credential.GetToken(context, cancellationToken));

        private static CallbackCredential DenyingCredential(Exception denial) => new((context, _) =>
            context.IsProofOfPossessionEnabled ? throw denial : new ValueTask<AccessToken>(Token(false)));

        private static AccessToken Token(bool bound) =>
            new(bound ? "bound-result" : "bearer-result", DateTimeOffset.MinValue, null, bound ? "mtls_pop" : BearerType);

        private static MockResponse Success() => new(200)
        {
            ContentStream = new KeyVaultSecret("secret", "value").ToStream()
        };

        private static Exception Denial() => new(DenialMessage);

        private static Exception WrapDenial(string wrapper) => wrapper switch
        {
            "direct" => new AuthenticationFailedException(DenialMessage),
            "managed" => new AuthenticationFailedException("Managed identity failed.", Denial()),
            "selected" => new AuthenticationFailedException("Selected credential failed.", new AuthenticationFailedException("Managed identity failed.", Denial())),
            "probe" => new CredentialUnavailableException("Probe acquisition failed.", Denial()),
            "aggregate" => new CredentialUnavailableException("All sources unavailable.", new AggregateException(
                new CredentialUnavailableException("Environment unavailable."),
                new CredentialUnavailableException("Probe acquisition failed.", Denial()))),
            "opaque-inner-chain" => new AuthenticationFailedException("Failed.", new Exception("Managed identity failed.", Denial())),
            "wrapped-aggregate" => new AuthenticationFailedException("Selected credential failed.", WrapDenial("aggregate")),
            "nested-unavailable-aggregate" => new CredentialUnavailableException("All sources unavailable.",
                new AggregateException(new CredentialUnavailableException("Environment unavailable."), WrapDenial("aggregate"))),
            _ => throw new ArgumentException("Unknown wrapper.", nameof(wrapper))
        };

        private static TokenRequestContext Context(string tenant = Tenant, string claims = """{"access_token":{}}""", string scope = "https://vault.azure.net/.default") =>
            new([scope], parentRequestId: "correlation", claims: claims, tenantId: tenant,
                isCaeEnabled: true, isProofOfPossessionEnabled: true, proofOfPossessionNonce: "nonce",
                requestUri: new Uri("https://test.vault.azure.net/secrets/secret"), requestMethod: "GET");

        private sealed class CallbackCredential : TokenCredential
        {
            private readonly Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> _callback;
            public ConcurrentQueue<TokenRequestContext> Contexts { get; } = new();
            public ConcurrentQueue<CancellationToken> Cancellations { get; } = new();

            public CallbackCredential(Func<TokenRequestContext, CancellationToken, ValueTask<AccessToken>> callback)
            {
                _callback = callback;
            }

            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
#pragma warning disable AZC0102 // Allow the synchronous test credential to wait for deterministic concurrency gates.
                return GetTokenAsync(requestContext, cancellationToken).AsTask().GetAwaiter().GetResult();
#pragma warning restore AZC0102
            }

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
            {
                Contexts.Enqueue(requestContext);
                Cancellations.Enqueue(cancellationToken);
                return _callback(requestContext, cancellationToken);
            }
        }
    }
}
