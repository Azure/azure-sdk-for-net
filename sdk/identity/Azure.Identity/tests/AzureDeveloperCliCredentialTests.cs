// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
                AdditionallyAllowedTenantsCore = config.AdditionallyAllowedTenants,
                TenantId = config.TenantId,
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
            string expectedTenantId = TenantIdResolver.Resolve(explicitTenantId, context, TenantIdResolver.AllTenants);
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

        public override async Task VerifyAllowedTenantEnforcementAllCreds(AllowedTenantsTestParameters parameters)
        {
            Console.WriteLine(parameters.ToDebugString());

            var options = new AzureDeveloperCliCredentialOptions { TenantId = parameters.TenantId };

            foreach (var addlTenant in parameters.AdditionallyAllowedTenants)
            {
                options.AdditionallyAllowedTenants.Add(addlTenant);
            }

            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureDeveloperCli();
            var testProcess = new TestProcess { Output = processOutput };
            AzureDeveloperCliCredential credential =
                InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess, true), options));

            await AssertAllowedTenantIdsEnforcedAsync(parameters, credential);
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
            yield return new object[] { AzureDeveloperCliCredential.WinAzdCliError, AzureDeveloperCliCredential.AzdCliNotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] { "azd: command not found", AzureDeveloperCliCredential.AzdCliNotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] { "azd: not found", AzureDeveloperCliCredential.AzdCliNotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] { AzureDeveloperCliCredential.AzdNotLogIn, AzureDeveloperCliCredential.AzdNotLogIn, typeof(CredentialUnavailableException) };
            yield return new object[] { RefreshTokenExpiredError, AzureDeveloperCliCredential.InteractiveLoginRequired, typeof(CredentialUnavailableException) };
            yield return new object[] { AzureDeveloperCliCredential.AzdCLIInternalError, AzureDeveloperCliCredential.InteractiveLoginRequired, typeof(CredentialUnavailableException) };
            yield return new object[] { "random unknown exception", AzureDeveloperCliCredential.AzdCliFailedError + " " + AzureDeveloperCliCredential.Troubleshoot + " random unknown exception", typeof(AuthenticationFailedException) };
            yield return new object[] { "AADSTS12345: Some AAD error. To re-authenticate, please run: azd login", AzureDeveloperCliCredential.AzdCliFailedError + " " + AzureDeveloperCliCredential.Troubleshoot + " AADSTS12345: Some AAD error. To re-authenticate, please run: azd login", typeof(AuthenticationFailedException) };
        }

        [Test]
        [TestCaseSource(nameof(AzureDeveloperCliExceptionScenarios))]
        public void AuthenticateWithDeveloperCliCredential_ExceptionScenarios(string errorMessage, string expectedMessage, Type exceptionType)
        {
            var testProcess = new TestProcess { Error = errorMessage };
            AzureDeveloperCliCredential credential = InstrumentClient(new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync(exceptionType, async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedMessage, ex.Message);
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
        public void ConfigureCliProcessTimeout_ProcessTimeout()
        {
            var testProcess = new TestProcess { Timeout = 10000 };
            AzureDeveloperCliCredential credential = InstrumentClient(
                new AzureDeveloperCliCredential(CredentialPipeline.GetInstance(null),
                    new TestProcessService(testProcess),
                    new AzureDeveloperCliCredentialOptions() { AzdCliProcessTimeout = TimeSpan.Zero }));
            var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(AzureDeveloperCliCredential.AzdCliTimeoutError, ex.Message);
        }
    }
}
