// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [RunOnlyOnPlatforms(Windows = true)] // VisualStudioCredential works only on Windows
    public class VisualStudioCredentialTests : ClientTestBase
    {
        public VisualStudioCredentialTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task AuthenticateWithVsCredential()
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            var token = await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None);

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);
        }

        [Test]
        public async Task AuthenticateWithVsCredential_FirstProcessFail()
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio(0, 1);
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess1 = new TestProcess { Error = "Error" };
            var testProcess2 = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess1, testProcess2)));
            var token = await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None);

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
                    switch (pi.Arguments.Last())
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
            var token = await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None);

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);
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
            Assert.CatchAsync<OperationCanceledException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), cts.Token));
        }

        [Test]
        public void AuthenticateWithVsCredential_CanceledOnProcessRun()
        {
            var cts = new CancellationTokenSource();
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var testProcess = new TestProcess { Timeout = 10000 };
            testProcess.Started += (o, e) => cts.Cancel();

            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.CatchAsync<OperationCanceledException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), cts.Token));
        }

        [Test]
        public void AuthenticateWithVsCredential_NoVsInstalled()
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            fileSystem.FileExistsHandler = p => false;

            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_NoJsonFileFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, new TestFileSystemService(), new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_NoDirectoryFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var fileSystem = new TestFileSystemService { ReadAllHandler = s => throw new DirectoryNotFoundException() };
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_BrokenJsonFileFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var fileSystem = new TestFileSystemService { ReadAllHandler = p => "{\"Some\": " };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_IncorrectJsonFileFound()
        {
            var (_, _, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };
            var fileSystem = new TestFileSystemService { ReadAllHandler = p => "{\"Some\": false}" };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_ProcessFailed()
        {
            var testProcess = new TestProcess { Error = "Some error" };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_ProcessReturnedInvalidJson()
        {
            var testProcess = new TestProcess { Output = "Not Json" };
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_CredentialUnavailableExceptionPassThrough()
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio(0, 1);
            var testProcess1 = new TestProcess { Error = "Error" };
            var testProcess2 = new TestProcess { Output = "Output" };
            var testProcessFactory = new TestProcessService(testProcess1, testProcess2);

            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, testProcessFactory));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AdfsTenantThrowsCredentialUnavailable()
        {
            var options = new VisualStudioCredentialOptions { TenantId = "adfs", Transport = new MockTransport() };

            VisualStudioCredential credential = InstrumentClient(new VisualStudioCredential(options));

            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] { "https://vault.azure.net/.default" }), CancellationToken.None));
        }
    }
}
