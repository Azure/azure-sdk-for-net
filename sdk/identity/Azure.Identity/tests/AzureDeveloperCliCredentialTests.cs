// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzureDeveloperCliCredentialTests : CredentialTestBase<AzureDeveloperCliCredentialOptions>
    {
        public AzureDeveloperCliCredentialTests(bool isAsync) : base(isAsync) { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var azdCliOptions = new AzureDeveloperCliCredentialOptions
            {
                Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }
            };
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzureDeveloperCli();
            var testProcess = new TestProcess { Output = processOutput };
            return InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true), azdCliOptions));
        }

        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            var azdCliOptions = new AzureDeveloperCliCredentialOptions
            {
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                TenantId = config.TenantId,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
                AuthorityHost = config.AuthorityHost,
            };
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzureDeveloperCli();
            var testProcess = new TestProcess { Output = processOutput };
            return InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true), azdCliOptions));
        }

        [Test]
        public async Task AuthenticateWithDeveloperCliCredential(
            [Values(null, TenantIdHint)] string tenantId,
            [Values(true)] bool allowMultiTenantAuthentication,
            [Values(null, TenantId)] string explicitTenantId)
        {
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            var options = new AzureDeveloperCliCredentialOptions { TenantId = explicitTenantId, AdditionallyAllowedTenants = { TenantIdHint } };
            string expectedTenantId = TenantIdResolverBase.Default.Resolve(explicitTenantId, context, TenantIdResolverBase.AllTenants);
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureDeveloperCli();

            var testProcess = new TestProcess { Output = processOutput };
            AzureDeveloperCliCredential credential =
                InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true), options));
            AccessToken actualToken = await credential.GetTokenAsync(context);

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.AreEqual(expectedExpiresOn, actualToken.ExpiresOn);

            var expectTenantId = expectedTenantId != null;
            if (expectTenantId)
            {
                Assert.That(testProcess.StartInfo.Arguments, Does.Contain($"-tenant-id {expectedTenantId}"));
            }
            else
            {
                Assert.That(testProcess.StartInfo.Arguments, Does.Not.Contain("-tenant-id"));
            }
        }

        [Test]
        public async Task AuthenticateWithDeveloperCliCredential_IncludesNoPromptFlag()
        {
            var context = new TokenRequestContext(new[] { Scope });
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureDeveloperCli();

            var testProcess = new TestProcess { Output = processOutput };
            AzureDeveloperCliCredential credential =
                InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true)));
            AccessToken actualToken = await credential.GetTokenAsync(context);

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.AreEqual(expectedExpiresOn, actualToken.ExpiresOn);
            Assert.That(testProcess.StartInfo.Arguments, Does.Contain("--no-prompt"));
        }

        [Test]
        public void AzureDeveloperCliCredential_ClaimsChallenge_NoTenant_ThrowsWithGuidance()
        {
            var claims = "test-claims-challenge";
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzureDeveloperCli();
            var testProcess = new TestProcess { Error = "AADSTS50076: MFA required" }; // Force InvalidOperationException path
            var credential = InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true)));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () =>
                await credential.GetTokenAsync(new TokenRequestContext([Scope], claims: claims)));

            Assert.That(ex.Message, Does.Contain("Azure Developer CLI authentication requires multi-factor authentication or additional claims."));
            Assert.That(ex.Message, Does.Contain("azd auth login"));
            Assert.That(ex.Message, Does.Not.Contain("--tenant-id"));
        }

        [Test]
        public void AzureDeveloperCliCredential_ClaimsChallenge_WithTenant_ThrowsWithGuidance()
        {
            var claims = "test-claims-challenge";
            var tenant = TenantId;
            var testProcess = new TestProcess { Error = "AADSTS50076: MFA required" };
            var credential = InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true), new AzureDeveloperCliCredentialOptions { TenantId = tenant }));

            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () =>
                await credential.GetTokenAsync(new TokenRequestContext([Scope], claims: claims)));

            Assert.That(ex.Message, Does.Contain($"azd auth login --tenant-id {tenant}"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("   ")]
        public async Task AzureDeveloperCliCredential_EmptyOrWhitespaceClaims_DoesNotIncludeClaimsArgument(string claims)
        {
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureDeveloperCli();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true)));

            var token = await credential.GetTokenAsync(new TokenRequestContext(new[] { Scope }, claims: claims));
            Assert.AreEqual(expectedToken, token.Token);
            Assert.AreEqual(expectedExpiresOn, token.ExpiresOn);
            Assert.That(testProcess.StartInfo.Arguments, Does.Not.Contain("--claims"));
        }

        [Test]
        public async Task AzureDeveloperCliCredential_ClaimsChallenge_Base64Encoded()
        {
            // Arrange
            var claimsJson = "{\"access_token\":{\"nbf\":1234567890}}"; // sample JSON claims challenge
            var base64 = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(claimsJson));
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureDeveloperCli();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true)));

            // Act
            var token = await credential.GetTokenAsync(new TokenRequestContext(new[] { Scope }, claims: claimsJson));

            // Assert
            Assert.AreEqual(expectedToken, token.Token);
            Assert.AreEqual(expectedExpiresOn, token.ExpiresOn);
            Assert.That(testProcess.StartInfo.Arguments, Does.Contain($"--claims {base64}"));
            Assert.That(testProcess.StartInfo.Arguments, Does.Not.Contain(claimsJson)); // ensure raw claims not present
        }

        [Test]
        public void AuthenticateWithCliCredential_InvalidJsonOutput(
            [Values("", "{}", "{\"Some\": false}", "{\"token\": \"token\"}", "{\"expiresOn\" : \"1900-01-01T00:00:00Z\"}")]
            string jsonContent)
        {
            var testProcess = new TestProcess { Output = jsonContent };
            AzureDeveloperCliCredential credential = InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
        }

        private const string RefreshTokenExpiredError = "Azure Developer CLI authentication failed due to an unknown error. ERROR: Get Token request returned http error: 400 and server response: {\"error\":\"invalid_grant\",\"error_description\":\"AADSTS70008: The provided authorization code or refresh token has expired due to inactivity. Send a new interactive authorization request for this user and resource.";

        public static IEnumerable<object[]> AzureDeveloperCliExceptionScenarios()
        {
            // params
            // azd thrown Exception message, expected message, expected  exception
            yield return new object[] {null, AzureDeveloperCliCredential.WinAzdCliError, AzureDeveloperCliCredential.AzdCliNotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] {null, "azd: command not found", AzureDeveloperCliCredential.AzdCliNotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] {null, "azd: not found", AzureDeveloperCliCredential.AzdCliNotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] {null, AzureDeveloperCliCredential.AzdNotLogIn, AzureDeveloperCliCredential.AzdNotLogIn, typeof(CredentialUnavailableException) };
            yield return new object[] {null, RefreshTokenExpiredError, AzureDeveloperCliCredential.InteractiveLoginRequired, typeof(CredentialUnavailableException) };
            yield return new object[] {null, AzureDeveloperCliCredential.AzdCLIInternalError, AzureDeveloperCliCredential.InteractiveLoginRequired, typeof(CredentialUnavailableException) };
            yield return new object[] {null, "random unknown exception", AzureDeveloperCliCredential.AzdCliFailedError + " " + AzureDeveloperCliCredential.Troubleshoot + " random unknown exception", typeof(AuthenticationFailedException) };
            yield return new object[] {GetExceptionAction(new AuthenticationFailedException("foo")), string.Empty, "foo", typeof(AuthenticationFailedException) };
            yield return new object[] {GetExceptionAction(new OperationCanceledException("foo")), string.Empty, "Azure Developer CLI authentication timed out.", typeof(AuthenticationFailedException) };
            yield return new object[] {null, "AADSTS12345: Some AAD error. To re-authenticate, please run: azd auth login", AzureDeveloperCliCredential.AzdCliFailedError + " " + AzureDeveloperCliCredential.Troubleshoot + " AADSTS12345: Some AAD error. To re-authenticate, please run: azd auth login", typeof(AuthenticationFailedException) };
        }

        public static IEnumerable<object[]> AzureDeveloperCliExceptionScenarios_IsChained()
        {
            // params
            // azd thrown Exception message, expected message, expected  exception
            yield return new object[] {null, AzureDeveloperCliCredential.WinAzdCliError, AzureDeveloperCliCredential.AzdCliNotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] {null, "azd: command not found", AzureDeveloperCliCredential.AzdCliNotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] {null, "azd: not found", AzureDeveloperCliCredential.AzdCliNotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] {null, AzureDeveloperCliCredential.AzdNotLogIn, AzureDeveloperCliCredential.AzdNotLogIn, typeof(CredentialUnavailableException) };
            yield return new object[] {null, RefreshTokenExpiredError, AzureDeveloperCliCredential.InteractiveLoginRequired, typeof(CredentialUnavailableException) };
            yield return new object[] {null, AzureDeveloperCliCredential.AzdCLIInternalError, AzureDeveloperCliCredential.InteractiveLoginRequired, typeof(CredentialUnavailableException) };
            yield return new object[] {null, "random unknown exception", AzureDeveloperCliCredential.AzdCliFailedError + " " + AzureDeveloperCliCredential.Troubleshoot + " random unknown exception", typeof(CredentialUnavailableException) };
            yield return new object[] {GetExceptionAction(new AuthenticationFailedException("foo")), string.Empty, "foo", typeof(CredentialUnavailableException) };
            yield return new object[] {GetExceptionAction(new OperationCanceledException("foo")), string.Empty, "Azure Developer CLI authentication timed out.", typeof(CredentialUnavailableException) };
            yield return new object[] {null, "AADSTS12345: Some AAD error. To re-authenticate, please run: azd auth login", AzureDeveloperCliCredential.AzdCliFailedError + " " + AzureDeveloperCliCredential.Troubleshoot + " AADSTS12345: Some AAD error. To re-authenticate, please run: azd auth login", typeof(CredentialUnavailableException) };
        }

        [Test]
        [TestCaseSource(nameof(AzureDeveloperCliExceptionScenarios))]
        public void AuthenticateWithDeveloperCliCredential_ExceptionScenarios(Action<object> exceptionOnStartHandler, string errorMessage, string expectedMessage, Type exceptionType)
        {
            var testProcess = new TestProcess { Error = errorMessage, ExceptionOnStartHandler = exceptionOnStartHandler };
            AzureDeveloperCliCredential credential = InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync(exceptionType, async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        [TestCaseSource(nameof(AzureDeveloperCliExceptionScenarios_IsChained))]
        public void AuthenticateWithDeveloperCliCredential_ExceptionScenarios_IsChained(Action<object> exceptionOnStartHandler, string errorMessage, string expectedMessage, Type exceptionType)
        {
            var testProcess = new TestProcess { Error = errorMessage, ExceptionOnStartHandler = exceptionOnStartHandler };
            AzureDeveloperCliCredential credential = InstrumentClient(new AzureDeveloperCliCredential(
                CredentialPipeline.GetInstance(null),
                new TestProcessService(testProcess),
                new AzureDeveloperCliCredentialOptions() { IsChainedCredential = true }));
            var ex = Assert.ThrowsAsync(exceptionType, async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.That(ex.Message, Does.Contain(expectedMessage));
        }

        [Test]
        public void AuthenticateWithDeveloperCliCredential_CanceledByUser()
        {
            var cts = new CancellationTokenSource();
            var testProcess = new TestProcess { Timeout = 10000 };
            testProcess.Started += (o, e) => cts.Cancel();
            AzureDeveloperCliCredential credential = InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            Assert.CatchAsync<OperationCanceledException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), cts.Token));
        }

        [Test]
        public void ConfigureCliProcessTimeout_ProcessTimeout([Values(true, false)] bool isChainedCredential)
        {
            var testProcess = new TestProcess { Timeout = 10000 };
            AzureDeveloperCliCredential credential = InstrumentClient(
                new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null),
                    new TestProcessService(testProcess),
                    new AzureDeveloperCliCredentialOptions() { ProcessTimeout = TimeSpan.Zero, IsChainedCredential = isChainedCredential }));
            Exception ex = null;
            if (isChainedCredential)
            {
                ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            }
            else
            {
                ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            }
            Assert.That(ex.Message, Does.Contain(AzureDeveloperCliCredential.AzdCliTimeoutError));
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyCtorTenantIdValidation(char testChar)
        {
            string tenantId = Guid.NewGuid().ToString();

            for (int i = 0; i < tenantId.Length; i++)
            {
                StringBuilder tenantIdBuilder = new StringBuilder(tenantId);

                tenantIdBuilder.Insert(i, testChar);

                Assert.Throws<ArgumentException>(() => new AzureDeveloperCliCredential(new AzureDeveloperCliCredentialOptions { TenantId = tenantIdBuilder.ToString() }), Validations.InvalidTenantIdErrorMessage);
            }
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyGetTokenTenantIdValidation(char testChar)
        {
            AzureDeveloperCliCredential credential = InstrumentClient(new AzureDeveloperCliCredential());

            string tenantId = Guid.NewGuid().ToString();

            for (int i = 0; i < tenantId.Length; i++)
            {
                StringBuilder tenantIdBuilder = new StringBuilder(tenantId);

                tenantIdBuilder.Insert(i, testChar);

                var tokenRequestContext = new TokenRequestContext(MockScopes.Default, tenantId: tenantIdBuilder.ToString());

                Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(tokenRequestContext), Validations.InvalidTenantIdErrorMessage);
            }
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyGetTokenScopeValidation(char testChar)
        {
            AzureDeveloperCliCredential credential = InstrumentClient(new AzureDeveloperCliCredential());

            string scope = MockScopes.Default.ToString();

            for (int i = 0; i < scope.Length; i++)
            {
                StringBuilder scopeBuilder = new StringBuilder(scope);

                scopeBuilder.Insert(i, testChar);

                var tokenRequestContext = new TokenRequestContext(new string[] { scopeBuilder.ToString() });

                Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(tokenRequestContext), ScopeUtilities.InvalidScopeMessage);
            }
        }
    }
}
