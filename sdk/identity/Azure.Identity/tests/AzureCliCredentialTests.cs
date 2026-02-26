// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    internal class AzureCliCredentialTests : CredentialTestBase<AzureCliCredentialOptions>
    {
        public AzureCliCredentialTests(bool isAsync) : base(isAsync) { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var azCliOptions = new AzureCliCredentialOptions
            {
                Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }
            };
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var testProcess = new TestProcess { Output = processOutput };
            return InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true), azCliOptions));
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            var azCliOptions = new AzureCliCredentialOptions
            {
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                TenantId = config.TenantId,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
                AuthorityHost = config.AuthorityHost,
            };
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var testProcess = new TestProcess { Output = processOutput };
            return InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true), azCliOptions));
        }

        #region Virtual Factory Methods
        protected virtual TokenCredential CreateCredential(IProcessService processService, string tenantId = null, string subscription = null, bool addTenantIdHint = false)
        {
            var options = new AzureCliCredentialOptions { TenantId = tenantId };
            if (addTenantIdHint)
            {
                options.AdditionallyAllowedTenants.Add(TenantIdHint);
            }
            if (subscription != null)
            {
                options.Subscription = subscription;
            }
            return InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), processService, options));
        }

        protected virtual TokenCredential CreateCredentialWithTimeout(IProcessService processService, TimeSpan timeout, bool isChained = false)
        {
            var options = new AzureCliCredentialOptions { ProcessTimeout = timeout, IsChainedCredential = isChained };
            return InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), processService, options));
        }

        protected virtual TokenCredential CreateCredentialWithChainedOption(IProcessService processService, bool isChained)
        {
            var options = new AzureCliCredentialOptions { IsChainedCredential = isChained };
            return InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), processService, options));
        }

        protected virtual TokenCredential CreateBareCredential()
        {
            return InstrumentClient(new AzureCliCredential());
        }

        /// <summary>
        /// Creates a credential with only a tenant ID for construction validation tests.
        /// No instrumentation needed since the credential is never used to get a token.
        /// </summary>
        protected virtual void CreateCredentialForTenantValidation(string tenantId)
        {
            new AzureCliCredential(new AzureCliCredentialOptions { TenantId = tenantId });
        }

        /// <summary>
        /// Returns the expected exception type for error scenarios.
        /// Base: AuthenticationFailedException when not chained, CredentialUnavailableException when chained.
        /// </summary>
        protected Type GetExpectedExceptionType(bool isChained)
            => isChained ? typeof(CredentialUnavailableException) : typeof(AuthenticationFailedException);

        protected virtual bool IsChainedCredentialSupported => true;
        #endregion

        [Test]
        public async Task AuthenticateWithCliCredential(
            [Values(null, TenantIdHint)] string tenantId,
            [Values(null, "1a7eed92-726e-46c0-b21d-a3db74b3b58c", "My Subscription Name -_")] string subscription,
            [Values(true)] bool allowMultiTenantAuthentication,
            [Values(null, TenantId)] string explicitTenantId)
        {
            var context = new TokenRequestContext([Scope], tenantId: tenantId);
            string expectedTenantId = TenantIdResolverBase.Default.Resolve(explicitTenantId, context, TenantIdResolverBase.AllTenants);
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();

            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess, true), tenantId: explicitTenantId, subscription: subscription, addTenantIdHint: true);
            AccessToken actualToken = await credential.GetTokenAsync(context, default);

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.AreEqual(expectedExpiresOn, actualToken.ExpiresOn);

            var expectTenantId = expectedTenantId != null;
            if (expectTenantId)
            {
                Assert.That(testProcess.StartInfo.Arguments, Does.Contain($"-tenant {expectedTenantId}"));
            }
            else
            {
                Assert.That(testProcess.StartInfo.Arguments, Does.Not.Contain("-tenant"));
            }

            if (subscription != null)
            {
                Assert.That(testProcess.StartInfo.Arguments, Does.Contain($"--subscription \"{subscription}\""));
            }
            else
            {
                Assert.That(testProcess.StartInfo.Arguments, Does.Not.Contain("--subscription"));
            }
        }

        [Test]
        public virtual void AzureCliCredentialOptionsValidatesSubscriptionOption()
        {
            Assert.Throws<ArgumentException>(() => new AzureCliCredentialOptions { Subscription = "My Subscription Name with a quote \"" });
            new AzureCliCredentialOptions { Subscription = "My Subscription Name -_" };
            new AzureCliCredentialOptions { Subscription = Guid.NewGuid().ToString() };
        }

        [Test]
        public async Task AuthenticateWithCliCredential_expires_on()
        {
            var now = DateTimeOffset.UtcNow;
            DateTimeOffset expectedExpiresOn = new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, TimeSpan.Zero).AddHours(1);
            var (expectedToken1, processOutput1) = CredentialTestHelpers.CreateTokenForAzureCliExpiresOn(expectedExpiresOn, true);
            var (expectedToken2, processOutput2) = CredentialTestHelpers.CreateTokenForAzureCliExpiresOn(expectedExpiresOn, false);

            var testProcess = new TestProcess { Output = processOutput1 };
            var credential = CreateCredential(new TestProcessService(testProcess));
            AccessToken actualToken1 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(expectedToken1, actualToken1.Token, "The tokens should match.");
            Assert.AreEqual(expectedExpiresOn, actualToken1.ExpiresOn, "The expires on value should be the same for token1.");

            testProcess = new TestProcess { Output = processOutput2 };
            credential = CreateCredential(new TestProcessService(testProcess));
            AccessToken actualToken2 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default);

            Assert.AreEqual(expectedToken2, actualToken2.Token);
            Assert.AreEqual(expectedExpiresOn, actualToken2.ExpiresOn, "The expires on value should be the same for token2.");

            Assert.AreEqual(actualToken1.ExpiresOn, actualToken2.ExpiresOn);
        }

        [Test]
        public void AuthenticateWithCliCredential_InvalidJsonOutput(
            [Values("", "{}", "{\"Some\": false}", "{\"accessToken\": \"token\"}", "{\"expiresOn\" : \"1900-01-01 00:00:00.123456\"}")]
            string jsonContent)
        {
            var testProcess = new TestProcess { Output = jsonContent };
            var credential = CreateCredential(new TestProcessService(testProcess));
            Assert.ThrowsAsync(GetExpectedExceptionType(false),
                async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
        }

        private const string RefreshTokenExpiredError = "Azure CLI authentication failed due to an unknown error. ERROR: Get Token request returned http error: 400 and server response: {\"error\":\"invalid_grant\",\"error_description\":\"AADSTS70008: The provided authorization code or refresh token has expired due to inactivity. Send a new interactive authorization request for this user and resource.";

        public static IEnumerable<object[]> AzureCliExceptionScenarios()
        {
            // params
            // az thrown Exception message, expected message, expected  exception isChained
            yield return new object[] { null, AzureCliCredential.WinAzureCLIError, AzureCliCredential.AzureCLINotInstalled, true };
            yield return new object[] { null, "az: command not found", AzureCliCredential.AzureCLINotInstalled, true };
            yield return new object[] { null, "az: not found", AzureCliCredential.AzureCLINotInstalled, true };
            yield return new object[] { null, AzureCliCredential.AzNotLogIn, AzureCliCredential.AzNotLogIn, true };
            yield return new object[] { null, RefreshTokenExpiredError, AzureCliCredential.InteractiveLoginRequired, true };
            yield return new object[] { null, AzureCliCredential.CLIInternalError, AzureCliCredential.InteractiveLoginRequired, true };
            yield return new object[] { null, "random unknown exception", AzureCliCredential.AzureCliFailedError + " " + AzureCliCredential.Troubleshoot + " random unknown exception", false };
            yield return new object[] { GetExceptionAction(new AuthenticationFailedException("foo")), string.Empty, "foo", false };
            yield return new object[] { GetExceptionAction(new OperationCanceledException("foo")), string.Empty, "Azure CLI authentication timed out.", false };
            yield return new object[] { null, "AADSTS12345: Some AAD error. To re-authenticate, please run: az login", AzureCliCredential.AzureCliFailedError + " " + AzureCliCredential.Troubleshoot + " AADSTS12345: Some AAD error. To re-authenticate, please run: az login", false };
        }

        public static IEnumerable<object[]> AzureCliExceptionScenarios_IsChained()
        {
            // params
            // az thrown Exception message, expected message, expected  exception isChained
            yield return new object[] { null, AzureCliCredential.WinAzureCLIError, AzureCliCredential.AzureCLINotInstalled, true };
            yield return new object[] { null, "az: command not found", AzureCliCredential.AzureCLINotInstalled, true };
            yield return new object[] { null, "az: not found", AzureCliCredential.AzureCLINotInstalled, true };
            yield return new object[] { null, AzureCliCredential.AzNotLogIn, AzureCliCredential.AzNotLogIn, true };
            yield return new object[] { null, RefreshTokenExpiredError, AzureCliCredential.InteractiveLoginRequired, true };
            yield return new object[] { null, AzureCliCredential.CLIInternalError, AzureCliCredential.InteractiveLoginRequired, true };
            yield return new object[] { null, "random unknown exception", AzureCliCredential.AzureCliFailedError + " " + AzureCliCredential.Troubleshoot + " random unknown exception", true };
            yield return new object[] { GetExceptionAction(new AuthenticationFailedException("foo")), string.Empty, "foo", true };
            yield return new object[] { GetExceptionAction(new OperationCanceledException("foo")), string.Empty, "Azure CLI authentication timed out.", true };
            yield return new object[] { null, "AADSTS12345: Some AAD error. To re-authenticate, please run: az login", AzureCliCredential.AzureCliFailedError + " " + AzureCliCredential.Troubleshoot + " AADSTS12345: Some AAD error. To re-authenticate, please run: az login", true };
        }

        [Test]
        [TestCaseSource(nameof(AzureCliExceptionScenarios))]
        public void AuthenticateWithCliCredential_ExceptionScenarios(Action<object> exceptionOnStartHandler, string errorMessage, string expectedMessage, bool isChained)
        {
            var testProcess = new TestProcess { Error = errorMessage, ExceptionOnStartHandler = exceptionOnStartHandler };
            var credential = CreateCredential(new TestProcessService(testProcess));
            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(isChained),
                async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain(expectedMessage));
        }

        [Test]
        [TestCaseSource(nameof(AzureCliExceptionScenarios_IsChained))]
        public void AuthenticateWithCliCredential_ExceptionScenarios_IsChained(Action<object> exceptionOnStartHandler, string errorMessage, string expectedMessage, bool isChained)
        {
            if (!IsChainedCredentialSupported)
            {
                Assert.Ignore("ConfigurableCredential with CredentialSource does not support chained credential scenarios.");
            }
            var testProcess = new TestProcess { Error = errorMessage, ExceptionOnStartHandler = exceptionOnStartHandler };
            var credential = CreateCredentialWithChainedOption(new TestProcessService(testProcess), isChained: true);
            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(isChained),
                async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain(expectedMessage));
        }

        [Test]
        public void AuthenticateWithCliCredential_CanceledByUser()
        {
            var cts = new CancellationTokenSource();
            var testProcess = new TestProcess { Timeout = 10000 };
            testProcess.Started += (o, e) => cts.Cancel();
            var credential = CreateCredential(new TestProcessService(testProcess));
            var ex = Assert.CatchAsync<Exception>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), cts.Token));
            Assert.That(ex.Message, Does.Contain("canceled").IgnoreCase);
        }

        [Test]
        public void ConfigureCliProcessTimeout_ProcessTimeout([Values(true, false)] bool isChainedCredential)
        {
            if (!IsChainedCredentialSupported && isChainedCredential)
            {
                Assert.Ignore("ConfigurableCredential with CredentialSource does not support chained credential scenarios.");
            }
            var testProcess = new TestProcess { Timeout = 10000 };
            var credential = CreateCredentialWithTimeout(new TestProcessService(testProcess), TimeSpan.Zero, isChainedCredential);
            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(isChainedCredential),
                async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), default));
            Assert.That(ex.Message, Does.Contain(AzureCliCredential.AzureCliTimeoutError));
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyCtorTenantIdValidation(char testChar)
        {
            string tenantId = Guid.NewGuid().ToString();

            for (int i = 0; i < tenantId.Length; i++)
            {
                StringBuilder tenantIdBuilder = new StringBuilder(tenantId);

                tenantIdBuilder.Insert(i, testChar);

                Assert.Throws<ArgumentException>(() => CreateCredentialForTenantValidation(tenantIdBuilder.ToString()), Validations.InvalidTenantIdErrorMessage);
            }
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyGetTokenTenantIdValidation(char testChar)
        {
            var credential = CreateBareCredential();

            string tenantId = Guid.NewGuid().ToString();

            for (int i = 0; i < tenantId.Length; i++)
            {
                StringBuilder tenantIdBuilder = new StringBuilder(tenantId);

                tenantIdBuilder.Insert(i, testChar);

                var tokenRequestContext = new TokenRequestContext(MockScopes.Default, tenantId: tenantIdBuilder.ToString());

                Assert.ThrowsAsync(GetExpectedExceptionType(false),
                    async () => await credential.GetTokenAsync(tokenRequestContext, default), Validations.InvalidTenantIdErrorMessage);
            }
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyGetTokenScopeValidation(char testChar)
        {
            var credential = CreateBareCredential();

            string scope = MockScopes.Default.ToString();

            for (int i = 0; i < scope.Length; i++)
            {
                StringBuilder scopeBuilder = new StringBuilder(scope);

                scopeBuilder.Insert(i, testChar);

                var tokenRequestContext = new TokenRequestContext(new string[] { scopeBuilder.ToString() });

                Assert.ThrowsAsync(GetExpectedExceptionType(false),
                    async () => await credential.GetTokenAsync(tokenRequestContext, default), ScopeUtilities.InvalidScopeMessage);
            }
        }

        [Test]
        public void AuthenticateWithCliCredential_ClaimsChallenge_NoTenant_ThrowsWithGuidance()
        {
            // Arrange: claims challenge provided, no tenant specified
            var claims = "test-claims-challenge";

            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess, true));

            // Act + Assert
            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(false),
                async () => await credential.GetTokenAsync(new TokenRequestContext([Scope], claims: claims), default));

            Assert.That(ex.Message, Does.Contain("Azure CLI authentication requires multi-factor authentication or additional claims."));
            Assert.That(ex.Message, Does.Contain($"az login --claims-challenge {claims}"));
            // Should not include a tenant switch when tenant is not resolved
            Assert.That(ex.Message, Does.Not.Contain("--tenant"));
        }

        [Test]
        public void AuthenticateWithCliCredential_ClaimsChallenge_WithTenant_ThrowsWithGuidance()
        {
            // Arrange: claims challenge provided with tenant
            var claims = "test-claims-challenge";

            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess, true), tenantId: TenantId);

            // Act + Assert
            var ex = Assert.ThrowsAsync(GetExpectedExceptionType(false),
                async () => await credential.GetTokenAsync(new TokenRequestContext([Scope], claims: claims), default));

            Assert.That(ex.Message, Does.Contain("Azure CLI authentication requires multi-factor authentication or additional claims."));
            Assert.That(ex.Message, Does.Contain($"az login --tenant {TenantId} --claims-challenge {claims}"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public async Task AuthenticateWithCliCredential_EmptyOrWhitespaceClaims_DoesNotTriggerGuidance(string claims)
        {
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess, true));

            var token = await credential.GetTokenAsync(new TokenRequestContext(new[] { Scope }, claims: claims), default);
            Assert.AreEqual(expectedToken, token.Token);
            Assert.AreEqual(expectedExpiresOn, token.ExpiresOn);
        }
    }
}
