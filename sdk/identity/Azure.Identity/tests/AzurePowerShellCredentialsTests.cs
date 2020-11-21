﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class AzurePowerShellCredentialsTests : ClientTestBase
    {
        public AzurePowerShellCredentialsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task AuthenticateWithAzurePowerShellCredential()
        {
            var (expectedToken, expectedExpiresOn) = CredentialTestHelpers.CreateTokenForAzurePowerShell(new TimeSpan(30));

            var testProcess = new TestProcess { Output = expectedToken };
            AzurePowerShellCredential credential = InstrumentClient(new AzurePowerShellCredential
                (new AzurePowerShellCredentialOptions() ,CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.AreEqual(expectedExpiresOn, actualToken.ExpiresOn);
        }

        [Test]
        public void AuthenticateWithAzurePowerShellCredential_PwshNotInstalled([Values("'pwsh' is not recognized", "pwsh: command not found", "pwsh: not found")] string errorMessage)
        {
            string expectedMessage = "PowerShell is not installed.";
            var testProcess = new TestProcess { Error = errorMessage };
            AzurePowerShellCredential credential = InstrumentClient(new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true)]
        public void AuthenticateWithAzurePowerShellCredential_PowerShellNotInstalled([Values("'powershell' is not recognized", "powershell: command not found", "powershell: not found")] string errorMessage)
        {
            string expectedMessage = "PowerShell is not installed.";
            var testProcess = new TestProcess { Error = errorMessage };
            AzurePowerShellCredential credential = InstrumentClient(new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(){UseLegacyPowerShell = true}, CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void AuthenticateWithAzurePowerShellCredential_AzurePowerShellModuleNotInstalled([Values("NoAzAccountModule")] string message)
        {
            string expectedMessage = "Az.Accounts module is not installed.";
            var testProcess = new TestProcess { Output = message };
            AzurePowerShellCredential credential = InstrumentClient(new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void AuthenticateWithAzurePowerShellCredential_AzurePowerShellNoContext([Values("NoContext")] string message)
        {
            string expectedMessage = "Please run 'Connect-AzAccount' to set up account.";
            var testProcess = new TestProcess { Output = message };
            AzurePowerShellCredential credential = InstrumentClient(new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void AuthenticateWithAzurePowerShellCredential_AzurePowerShellUnknownError()
        {
            string mockResult = "mock-result";
            var testProcess = new TestProcess { Error = mockResult };
            AzurePowerShellCredential credential = InstrumentClient(new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
        }

        [Test]
        public void AuthenticateWithAzurePowerShellCredential_CanceledByUser()
        {
            var cts = new CancellationTokenSource();
            var testProcess = new TestProcess { Timeout = 10000 };
            testProcess.Started += (o, e) => cts.Cancel();
            AzurePowerShellCredential credential = InstrumentClient(new AzurePowerShellCredential(new AzurePowerShellCredentialOptions(), CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            Assert.CatchAsync<OperationCanceledException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), cts.Token));
        }


        [Test]
        public void ValidateConstructorOverload1()
        {
            // tests the AzurePowerShellCredential constructor overload
            // public AzurePowerShellCredential(AzurePowerShellCredentialOptions options)

            // null
            var credential = new AzurePowerShellCredential(null);

            AssertOptionsHonored(new AzurePowerShellCredentialOptions(), credential);

            // with options
            var options = new AzurePowerShellCredentialOptions() {UseLegacyPowerShell = true};

            credential = new AzurePowerShellCredential(options);

            AssertOptionsHonored(options, credential);
        }

        public void AssertOptionsHonored(AzurePowerShellCredentialOptions options, AzurePowerShellCredential credential)
        {
            Assert.AreEqual(options.UseLegacyPowerShell, credential.UseLegacyPowerShell);
        }
    }
}
