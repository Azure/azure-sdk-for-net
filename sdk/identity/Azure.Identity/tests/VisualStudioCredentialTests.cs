// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [RunOnlyOnPlatforms(Windows = true)] // VisualStudioCredential works only on Windows
    public class VisualStudioCredentialTests : CredentialTestBase<VisualStudioCredentialOptions>
    {
        public VisualStudioCredentialTests(bool isAsync) : base(isAsync) { }

        public override TokenCredential GetTokenCredential(TokenCredentialOptions options)
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var vsOptions = new VisualStudioCredentialOptions
            {
                Diagnostics = { IsAccountIdentifierLoggingEnabled = options.Diagnostics.IsAccountIdentifierLoggingEnabled }
            };
            return InstrumentClient(new VisualStudioCredential(TenantId, default, fileSystem, new TestProcessService(testProcess, true), vsOptions));
        }
        public override TokenCredential GetTokenCredential(CommonCredentialTestConfig config)
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var vsOptions = new VisualStudioCredentialOptions
            {
                AdditionallyAllowedTenants = config.AdditionallyAllowedTenants,
                IsUnsafeSupportLoggingEnabled = config.IsUnsafeSupportLoggingEnabled,
            };
            return InstrumentClient(new VisualStudioCredential(config.TenantId, default, fileSystem, new TestProcessService(testProcess, true), vsOptions));
        }

        [Test]
        public async Task AuthenticateWithVsCredential([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var options = new VisualStudioCredentialOptions() { AdditionallyAllowedTenants = { TenantIdHint } };
            var credential = InstrumentClient(new VisualStudioCredential(TenantId, default, fileSystem, new TestProcessService(testProcess, true), options));
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolverBase.Default.Resolve(TenantId, context, TenantIdResolverBase.AllTenants);

            var token = await credential.GetTokenAsync(context, default);

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);
            if (expectedTenantId != null)
            {
                Assert.That(testProcess.StartInfo.Arguments, Does.Contain(expectedTenantId));
            }
        }

        [Test]
        public async Task AuthenticateWithVsCredential_FirstProcessFail()
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio(0, 1);
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess1 = new TestProcess { Error = "Error" };
            var testProcess2 = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess1, testProcess2)));
            var token = await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None);

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);
        }

        [Test]
        public async Task AuthenticateWithVsCredential_RespectPreferences()
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio(2, 1, 0);
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess1 = new TestProcess { Error = "Error" };
            var testProcess2 = new TestProcess { Output = processOutput };
            var testProcessFactory = new TestProcessService
            {
                CreateHandler = pi =>
                {
                    switch (pi.Arguments.First())
                    {
                        case '0':
                            return testProcess1;
                        case '1':
                            return testProcess2;
                        case '2':
                            Assert.Fail("Process with preference 2 is called out of order");
                            return default;
                        default:
                            Assert.Fail("Unexpected Value");
                            return default;
                    }
                }
            };

            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, testProcessFactory));
            var token = await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None);

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);
        }

        [Test]
        public async Task AuthenticateWithVsCredential_ArgumentOrder([Values(null, TenantIdHint)] string tenantId)
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio(2064);
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var options = new VisualStudioCredentialOptions() { AdditionallyAllowedTenants = { TenantIdHint } };
            var credential = InstrumentClient(new VisualStudioCredential(TenantId, default, fileSystem, new TestProcessService(testProcess, true), options));
            var context = new TokenRequestContext(new[] { Scope }, tenantId: tenantId);
            expectedTenantId = TenantIdResolverBase.Default.Resolve(TenantId, context, TenantIdResolverBase.AllTenants);

            var token = await credential.GetTokenAsync(context, default);

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);

            // Ensure that the argument from the json file comes first
            Assert.That(testProcess.StartInfo.Arguments, Does.StartWith("2064"));

            // If a TenantId was provided check that it is present
            if (expectedTenantId != null)
            {
                Assert.That(testProcess.StartInfo.Arguments, Does.Contain(expectedTenantId));
            }
        }

        [Test]
        public void AuthenticateWithVsCredential_CanceledOnFileCheck()
        {
            var cts = new CancellationTokenSource();
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio(0, 1);
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };

            fileSystem.FileExistsHandler = p =>
            {
                cts.Cancel();
                return false;
            };

            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.CatchAsync<OperationCanceledException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), cts.Token));
        }

        [Test]
        public void AuthenticateWithVsCredential_CanceledOnProcessRun()
        {
            var cts = new CancellationTokenSource();
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var testProcess = new TestProcess { Timeout = 10000 };
            testProcess.Started += (o, e) => cts.Cancel();

            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.CatchAsync<OperationCanceledException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), cts.Token));
        }

        [Test]
        public void AuthenticateWithVsCredential_NoVsInstalled()
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            fileSystem.FileExistsHandler = p => false;

            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_NoJsonFileFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, new TestFileSystemService(), new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_NoDirectoryFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var fileSystem = new TestFileSystemService { ReadAllHandler = s => throw new DirectoryNotFoundException() };
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_BrokenJsonFileFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var fileSystem = new TestFileSystemService { ReadAllHandler = p => "{\"Some\": " };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_IncorrectJsonFileFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var fileSystem = new TestFileSystemService { ReadAllHandler = p => "{\"Some\": false}" };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_ProcessFailed([Values(true, false)] bool isChainedCredential)
        {
            var testProcess = new TestProcess { Error = "Some error" };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess), new VisualStudioCredentialOptions { IsChainedCredential = isChainedCredential }));
            if (isChainedCredential)
            {
                Assert.ThrowsAsync<CredentialUnavailableException>(
                    async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
            }
            else
            {
                Assert.ThrowsAsync<AuthenticationFailedException>(
                    async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
            }
        }

        [Test]
        public void AuthenticateWithVsCredential_ProcessReturnedInvalidJson()
        {
            var testProcess = new TestProcess { Output = "Not Json" };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_CredentialUnavailableExceptionPassThrough()
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio(0, 1);
            var testProcess1 = new TestProcess { Error = "Error" };
            var testProcess2 = new TestProcess { Output = "Output" };
            var testProcessFactory = new TestProcessService(testProcess1, testProcess2);

            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, testProcessFactory));
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AdfsTenantThrowsCredentialUnavailable()
        {
            var options = new VisualStudioCredentialOptions { TenantId = "adfs", Transport = new MockTransport() };

            VisualStudioCredential credential = InstrumentClient(new VisualStudioCredential(options));

            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/.default" }), CancellationToken.None));
        }

        [Test]
        public void ConfigureVisualStudioProcessTimeout_ProcessTimeout()
        {
            var testProcess = new TestProcess { Timeout = 10000 };
            var processService = new TestProcessService(testProcess);
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio(0, 1);
            VisualStudioCredential credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, processService, new VisualStudioCredentialOptions() { ProcessTimeout = TimeSpan.Zero }));
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), CancellationToken.None));
            Assert.True(ex.Message.Contains("has failed to get access token in 0 seconds."));
        }

        [Test]
        public void GenericException_throws_CredentialUnavailableException_WhenChained([Values(true, false)] bool isChainedCredential)
        {
            var testProcess = new TestProcess() { ExceptionOnStartHandler = p => throw new Exception("Test exception") };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess), new VisualStudioCredentialOptions { IsChainedCredential = isChainedCredential }));

            if (isChainedCredential)
            {
                Assert.ThrowsAsync<CredentialUnavailableException>(
                    async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
            }
            else
            {
                Assert.ThrowsAsync<AuthenticationFailedException>(
                    async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
            }
        }
    }
}
