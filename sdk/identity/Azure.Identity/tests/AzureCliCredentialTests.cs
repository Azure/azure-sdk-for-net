// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
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
            var expectedToken = "mock-cli-access-token";
            var testProcess = new TestProcess { Output = $"{{ \"accessToken\": \"{expectedToken}\", \"expiresOn\": \"1900-01-01 00:00:00.123456\" }}" };
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken, actualToken.Token);
        }

        [Test]
        public async Task AuthenticateWithCliCredential_ExpiresIn()
        {
            var expectedToken = "mock-cli-access-token";
            var expectedTime = DateTimeOffset.Now.AddMinutes(30);
            var testProcess = new TestProcess { Output = $"{{ \"accessToken\": \"{expectedToken}\", \"expiresIn\": 1800 }}" };
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            AccessToken actualToken = await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default));

            Assert.AreEqual(expectedToken, actualToken.Token);
            Assert.LessOrEqual(expectedTime, actualToken.ExpiresOn);
        }

        [Test]
        public void AuthenticateWithCliCredential_InvalidJsonOutput([Values("", "{}", "{\"Some\": false}", "{\"accessToken\": \"token\"}", "{\"expiresOn\" : \"1900-01-01 00:00:00.123456\"}")] string jsonContent)
        {
            var testProcess = new TestProcess { Output = jsonContent };
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            Assert.CatchAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
        }

        [Test]
        public void AuthenticateWithCliCredential_AzureCliNotInstalled([Values("'az' is not recognized", "az: command not found", "az: not found")] string errorMessage)
        {
            string expectedMessage = "Azure CLI not installed";
            var testProcess = new TestProcess { Error = errorMessage };
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedMessage, ex.Message);
        }

        [Test]
        public void AuthenticateWithCliCredential_AzNotLogIn()
        {
            string expectedExMessage = $"Please run 'az login' to set up account";
            var testProcess = new TestProcess { Error = "Please run 'az login'" };
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
            Assert.AreEqual(expectedExMessage, ex.Message);
        }

        [Test]
        public void AuthenticateWithCliCredential_AzureCliUnknownError()
        {
            string mockResult = $"mock-result";
            var testProcess = new TestProcess { Error = mockResult };
            AzureCliCredential credential = InstrumentClient(new AzureCliCredential(CredentialPipeline.GetInstance(null), new TestProcessService(testProcess)));
            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default)));
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
