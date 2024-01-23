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
    public class AzureCliCredentialTests : CredentialTestBase<AzureCliCredentialOptions>
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
            };
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var testProcess = new TestProcess { Output = processOutput };
            return InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true), azCliOptions));
        }

        [Test]
        public async Task AuthenticateWithCliCredential(
            [Values(null, TenantIdHint)] string tenantId,
            [Values(true)] bool allowMultiTenantAuthentication,
            [Values(null, TenantId)] string explicitTenantId)
        {
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            var options = new AzureCliCredentialOptions { TenantId = explicitTenantId, AdditionallyAllowedTenants = { TenantIdHint } };
            string expectedTenantId = TenantIdResolverBase.Default.Resolve(explicitTenantId, context, TenantIdResolverBase.AllTenants);
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();

            var testProcess = new TestProcess { Output = processOutput };
            AzureCliCredential credential =
                InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true), options));
            AccessToken actualToken = await credential.GetTokenAsync(context);

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
        }

        [Test]
        public async Task AuthenticateWithCliCredential_expires_on()
        {
            var now = DateTimeOffset.UtcNow;
            DateTimeOffset expectedExpiresOn = new DateTimeOffset(now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, TimeSpan.Zero).AddHours(1);
            var (expectedToken1, processOutput1) = CredentialTestHelpers.CreateTokenForAzureCliExpiresOn(expectedExpiresOn, true);
            var (expectedToken2, processOutput2) = CredentialTestHelpers.CreateTokenForAzureCliExpiresOn(expectedExpiresOn, false);

            var testProcess = new TestProcess { Output = processOutput1 };
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            AccessToken actualToken1 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken1, actualToken1.Token, "The tokens should match.");
            Assert.AreEqual(expectedExpiresOn, actualToken1.ExpiresOn, "The expires on value should be the same for token1.");

            testProcess = new TestProcess { Output = processOutput2 };
            credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            AccessToken actualToken2 = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

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
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
        }

        private const string RefreshTokenExpiredError = "Azure CLI authentication failed due to an unknown error. ERROR: Get Token request returned http error: 400 and server response: {\"error\":\"invalid_grant\",\"error_description\":\"AADSTS70008: The provided authorization code or refresh token has expired due to inactivity. Send a new interactive authorization request for this user and resource.";

        public static IEnumerable<object[]> AzureCliExceptionScenarios()
        {
            // params
            // az thrown Exception message, expected message, expected  exception
            yield return new object[] { AzureCliCredential.WinAzureCLIError, AzureCliCredential.AzureCLINotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] { "az: command not found", AzureCliCredential.AzureCLINotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] { "az: not found", AzureCliCredential.AzureCLINotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] { AzureCliCredential.AzNotLogIn, AzureCliCredential.AzNotLogIn, typeof(CredentialUnavailableException) };
            yield return new object[] { RefreshTokenExpiredError, AzureCliCredential.InteractiveLoginRequired, typeof(CredentialUnavailableException) };
            yield return new object[] { AzureCliCredential.CLIInternalError, AzureCliCredential.InteractiveLoginRequired, typeof(CredentialUnavailableException) };
            yield return new object[] { "random unknown exception", AzureCliCredential.AzureCliFailedError + " " + AzureCliCredential.Troubleshoot + " random unknown exception", typeof(AuthenticationFailedException) };
            yield return new object[] { "AADSTS12345: Some AAD error. To re-authenticate, please run: az login", AzureCliCredential.AzureCliFailedError + " " + AzureCliCredential.Troubleshoot + " AADSTS12345: Some AAD error. To re-authenticate, please run: az login", typeof(AuthenticationFailedException) };
        }

        [Test]
        [TestCaseSource(nameof(AzureCliExceptionScenarios))]
        public void AuthenticateWithCliCredential_ExceptionScenarios(string errorMessage, string expectedMessage, Type exceptionType)
        {
            var testProcess = new TestProcess { Error = errorMessage };
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync(exceptionType, async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void AuthenticateWithCliCredential_CanceledByUser()
        {
            var cts = new CancellationTokenSource();
            var testProcess = new TestProcess { Timeout = 10000 };
            testProcess.Started += (o, e) => cts.Cancel();
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            Assert.CatchAsync<OperationCanceledException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), cts.Token));
        }

        [Test]
        public void ConfigureCliProcessTimeout_ProcessTimeout([Values(true, false)] bool isChainedCredential)
        {
            var testProcess = new TestProcess { Timeout = 10000 };
            AzureCliCredential credential = InstrumentClient(
                new AzureCliCredential(CredentialPipeline.GetInstance(null),
                    new TestProcessService(testProcess),
                    new AzureCliCredentialOptions() { ProcessTimeout = TimeSpan.Zero, IsChainedCredential = isChainedCredential }));

            Exception ex = null;
            if (isChainedCredential)
            {
                ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            }
            else
            {
                ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            }
            Assert.AreEqual(AzureCliCredential.AzureCliTimeoutError, ex.Message);
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyCtorTenantIdValidation(char testChar)
        {
            string tenantId = Guid.NewGuid().ToString();

            for (int i = 0; i < tenantId.Length; i++)
            {
                StringBuilder tenantIdBuilder = new StringBuilder(tenantId);

                tenantIdBuilder.Insert(i, testChar);

                Assert.Throws<ArgumentException>(() => new AzureCliCredential(new AzureCliCredentialOptions { TenantId = tenantIdBuilder.ToString() }), Validations.InvalidTenantIdErrorMessage);
            }
        }

        [TestCaseSource(nameof(NegativeTestCharacters))]
        public void VerifyGetTokenTenantIdValidation(char testChar)
        {
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential());

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
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential());

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
