// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    [RunOnlyOnPlatforms(Windows = true)]
    public class VisualStudioCredentialTests : ClientTestBase
    {
        public VisualStudioCredentialTests(bool isAsync) : base(isAsync) { }

        [Test]
        public async Task AuthenticateWithVsCredential()
        {
            var fileSystem = CreateTestFileSystem();
            var (expectedToken, expectedExpiresOn, processOutput) = CreateTestToken();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            var token = await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None);

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);
        }

        [Test]
        public async Task AuthenticateWithVsCredential_FirstProcessFail()
        {
            var fileSystem = CreateTestFileSystem(0, 1);
            var (expectedToken, expectedExpiresOn, processOutput) = CreateTestToken();
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
            var fileSystem = CreateTestFileSystem(2, 1, 0);
            var (expectedToken, expectedExpiresOn, processOutput) = CreateTestToken();
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
            var fileSystem = CreateTestFileSystem(0, 1);
            var (_, _, processOutput) = CreateTestToken();
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
            var fileSystem = CreateTestFileSystem();
            var testProcess = new TestProcess { Timeout = 10000 };
            testProcess.Started += (o, e) => cts.Cancel();

            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.CatchAsync<OperationCanceledException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), cts.Token));
        }

        [Test]
        public void AuthenticateWithVsCredential_NoVsInstalled()
        {
            var fileSystem = CreateTestFileSystem();
            fileSystem.FileExistsHandler = p => false;

            var (_, _, processOutput) = CreateTestToken();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_NoJsonFileFound()
        {
            var (_, _, processOutput) = CreateTestToken();
            var testProcess = new TestProcess { Output = processOutput };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, new TestFileSystemService(), new TestProcessService(testProcess)));
            Assert.ThrowsAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_BrokenJsonFileFound()
        {
            var (_, _, processOutput) = CreateTestToken();
            var testProcess = new TestProcess { Output = processOutput };
            var fileSystem = new TestFileSystemService { ReadAllHandler = p => "{\"Some\": false}" };
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        [Test]
        public void AuthenticateWithVsCredential_ProcessFailed()
        {
            var testProcess = new TestProcess { Error = "Some error" };
            var fileSystem = CreateTestFileSystem();
            var credential = InstrumentClient(new VisualStudioCredential(default, default, fileSystem, new TestProcessService(testProcess)));
            Assert.ThrowsAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[]{"https://vault.azure.net/"}), CancellationToken.None));
        }

        private (string token, DateTimeOffset expiresOn, string json) CreateTestToken()
        {
            var expiresOnString = DateTimeOffset.Now.AddHours(0.5).ToUniversalTime().ToString("s");
            var expiresOn = DateTimeOffset.Parse(expiresOnString);
            var token = Guid.NewGuid().ToString();
            var json = $"{{ \"access_token\": \"{token}\", \"expires_on\": \"{expiresOnString}\" }}";
            return (token, expiresOn, json);
        }

        private TestFileSystemService CreateTestFileSystem(params int[] preferences)
        {
            var sb = new StringBuilder();
            var paths = new List<string>();

            for (var i = 0; i < preferences.Length || i == 0; i++)
            {
                var preference = preferences.Length > 0 ? preferences[i] : 0;
                if (i > 0)
                {
                    sb.Append(", ");
                }

                paths.Add($"c:\\VS{preference}\\service.exe");
                sb.Append($"{{\"Path\": \"c:\\\\VS{preference}\\\\service.exe\", \"Arguments\": [\"{preference}\"], \"Preference\": {preference}}}");
            }

            var json = $"{{ \"TokenProviders\": [{sb}] }}";
            return new TestFileSystemService
            {
                FileExistsHandler = p => paths.Contains(p),
                ReadAllHandler = p => json
            };
        }
    }
}
