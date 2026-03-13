// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
    internal class VisualStudioCredentialTests : CredentialTestBase<VisualStudioCredentialOptions>
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
                AuthorityHost = config.AuthorityHost,
            };
            return InstrumentClient(new VisualStudioCredential(config.TenantId, default, fileSystem, new TestProcessService(testProcess, true), vsOptions));
        }

        protected virtual TokenCredential CreateCredential(IProcessService processService, IFileSystemService fileSystem, string tenantId = null, bool addTenantIdHint = false)
        {
            var options = new VisualStudioCredentialOptions();
            if (addTenantIdHint)
            {
                options.AdditionallyAllowedTenants.Add(TenantIdHint);
            }
            return InstrumentClient(new VisualStudioCredential(tenantId, default, fileSystem, processService, options));
        }

        protected virtual TokenCredential CreateCredentialWithTimeout(IProcessService processService, IFileSystemService fileSystem, TimeSpan timeout)
        {
            var options = new VisualStudioCredentialOptions { ProcessTimeout = timeout };
            return InstrumentClient(new VisualStudioCredential(default, default, fileSystem, processService, options));
        }

        protected virtual TokenCredential CreateCredentialWithChainedOption(IProcessService processService, IFileSystemService fileSystem, bool isChained)
        {
            var options = new VisualStudioCredentialOptions { IsChainedCredential = isChained };
            return InstrumentClient(new VisualStudioCredential(default, default, fileSystem, processService, options));
        }

        [Test]
        public async Task AuthenticateWithVsCredential([Values(null, TenantIdHint)] string tenantId, [Values(true)] bool allowMultiTenantAuthentication)
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess, true), fileSystem, TenantId, addTenantIdHint: true);
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
            var credential = CreateCredential(new TestProcessService(testProcess1, testProcess2), fileSystem);
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

            var credential = CreateCredential(testProcessFactory, fileSystem);
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
            var credential = CreateCredential(new TestProcessService(testProcess, true), fileSystem, TenantId, addTenantIdHint: true);
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

            var credential = CreateCredential(new TestProcessService(testProcess), fileSystem);
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

            var credential = CreateCredential(new TestProcessService(testProcess), fileSystem);
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
            var credential = CreateCredential(new TestProcessService(testProcess), fileSystem);
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_NoJsonFileFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess), new TestFileSystemService());
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_NoDirectoryFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var fileSystem = new TestFileSystemService { ReadAllHandler = s => throw new DirectoryNotFoundException() };
            var testProcess = new TestProcess { Output = processOutput };
            var credential = CreateCredential(new TestProcessService(testProcess), fileSystem);
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_BrokenJsonFileFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var fileSystem = new TestFileSystemService { ReadAllHandler = p => "{\"Some\": " };
            var credential = CreateCredential(new TestProcessService(testProcess), fileSystem);
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_IncorrectJsonFileFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var fileSystem = new TestFileSystemService { ReadAllHandler = p => "{\"Some\": false}" };
            var credential = CreateCredential(new TestProcessService(testProcess), fileSystem);
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_ProcessFailed()
        {
            var testProcess = new TestProcess { Error = "Some error" };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = CreateCredential(new TestProcessService(testProcess), fileSystem);
            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_ProcessReturnedInvalidJson()
        {
            var testProcess = new TestProcess { Output = "Not Json" };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = CreateCredential(new TestProcessService(testProcess), fileSystem);
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

            var credential = CreateCredential(testProcessFactory, fileSystem);
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
            var credential = CreateCredentialWithTimeout(processService, fileSystem, TimeSpan.Zero);
            var ex = Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default), CancellationToken.None));
            Assert.True(ex.Message.Contains("has failed to get access token in 0 seconds."));
        }

        [Test]
        public void GenericException_throws_CredentialUnavailableException_Always()
        {
            var testProcess = new TestProcess() { ExceptionOnStartHandler = p => throw new Exception("Test exception") };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = CreateCredential(new TestProcessService(testProcess), fileSystem);

            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void AuthenticationFailedException_throws_CredentialUnavailableException_Always()
        {
            var testProcess = new TestProcess() { ExceptionOnStartHandler = p => throw new AuthenticationFailedException("Test exception") };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = CreateCredential(new TestProcessService(testProcess), fileSystem);

            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void OperationCanceledException_throws_CredentialUnavailableException_WhenChained()
        {
            var testProcess = new TestProcess() { ExceptionOnStartHandler = p => throw new OperationCanceledException("Test exception") };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = CreateCredentialWithChainedOption(new TestProcessService(testProcess), fileSystem, isChained: true);

            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }

        [Test]
        public void GeneralExceptions_With_CertainErrors_throws_CredentialUnavailableException()
        {
            // The error message is defined inline to avoid including ": Error" in the test name,
            // which would be misinterpreted as a build error by the CI MSBuild log processor.
            string exceptionMessage = "TS003: Error, TS005: No accounts found.  Please go to Tools->Options->Azure Services Authentication, and add an account to be authenticated to Azure services during development.";
            var testProcess = new TestProcess() { ExceptionOnStartHandler = p => throw new InvalidOperationException(exceptionMessage) };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = CreateCredentialWithChainedOption(new TestProcessService(testProcess), fileSystem, isChained: false);

            Assert.ThrowsAsync<CredentialUnavailableException>(
                async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/" }), CancellationToken.None));
        }
    }
}
