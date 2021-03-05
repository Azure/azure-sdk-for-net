// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzureCliCredentialTests : ClientTestBase
    {
        public AzureCliCredentialTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task AuthenticateWithCliCredential()
        {
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();

            var testProcess = new TestProcess { Output = processOutput };
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.AreEqual(expectedExpiresOn, actualToken.ExpiresOn);
        }

        [Test]
        public async Task AuthenticateWithCliCredential_ExpiresIn()
        {
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCliExpiresIn(1800);

            var testProcess = new TestProcess { Output = processOutput };
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.LessOrEqual(expectedExpiresOn, actualToken.ExpiresOn);
        }

        [Test]
        public void AuthenticateWithCliCredential_InvalidJsonOutput([Values("", "{}", "{\"Some\": false}", "{\"accessToken\": \"token\"}", "{\"expiresOn\" : \"1900-01-01 00:00:00.123456\"}")] string jsonContent)
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
            yield return new object[] { "'az' is not recognized", AzureCliCredential.AzureCLINotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] { "az: command not found", AzureCliCredential.AzureCLINotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] { "az: not found", AzureCliCredential.AzureCLINotInstalled, typeof(CredentialUnavailableException) };
            yield return new object[] { "Please run 'az login'", AzureCliCredential.AzNotLogIn, typeof(CredentialUnavailableException) };
            yield return new object[] { RefreshTokenExpiredError, AzureCliCredential.InteractiveLoginRequired, typeof(CredentialUnavailableException) };
            yield return new object[] { "random unknown exception", AzureCliCredential.AzureCliFailedError + " random unknown exception", typeof(AuthenticationFailedException) };
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
    }
}
