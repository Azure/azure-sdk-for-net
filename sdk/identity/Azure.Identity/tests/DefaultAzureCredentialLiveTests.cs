// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class DefaultAzureCredentialLiveTests : RecordedTestBase<IdentityTestEnvironment>
    {
        private const string ExpectedServiceName = "VS Code Azure";

        public DefaultAzureCredentialLiveTests(bool isAsync) : base(isAsync)
        {
            Matcher.ExcludeHeaders.Add("Content-Length");
            Matcher.ExcludeHeaders.Add("client-request-id");
            Matcher.ExcludeHeaders.Add("x-client-OS");
            Matcher.ExcludeHeaders.Add("x-client-SKU");
            Matcher.ExcludeHeaders.Add("x-client-CPU");

            Sanitizer = new IdentityRecordedTestSanitizer();
            TestDiagnostics = false;
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true)] // VisualStudioCredential works only on Windows
        public async Task DefaultAzureCredential_UseVisualStudioCredential()
        {
            var options = Recording.InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
            });

            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };

            var factory = new TestDefaultAzureCredentialFactory(options, fileSystem, new TestProcessService(testProcess), default);
            var credential = InstrumentClient(new DefaultAzureCredential(factory, options));

            AccessToken token;
            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                token = await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None);
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);

            Assert.AreEqual(2, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(VisualStudioCredential)}.{nameof(VisualStudioCredential.GetToken)}", scopes[1].Name);
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true, OSX = true)] // Comment this attribute to run this tests on Linux with Libsecret enabled
        public async Task DefaultAzureCredential_UseVisualStudioCodeCredential()
        {
            var options = Recording.InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                VisualStudioCodeTenantId = TestEnvironment.TestTenantId
            });

            var cloudName = Guid.NewGuid().ToString();
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment, cloudName);
            var process = new TestProcess { Error = "Error" };

            var factory = new TestDefaultAzureCredentialFactory(options, fileSystem, new TestProcessService(process), default);
            var credential = InstrumentClient(new DefaultAzureCredential(factory, options));

            AccessToken token;
            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (await CredentialTestHelpers.CreateRefreshTokenFixtureAsync(TestEnvironment, Mode, ExpectedServiceName, cloudName))
            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                token = await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None);
                scopes = diagnosticListener.Scopes;
            }

            Assert.IsNotNull(token.Token);

            Assert.AreEqual(2, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(VisualStudioCodeCredential)}.{nameof(VisualStudioCodeCredential.GetToken)}", scopes[1].Name);
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true, OSX = true)] // Comment this attribute to run this tests on Linux with Libsecret enabled
        public async Task DefaultAzureCredential_UseVisualStudioCodeCredential_ParallelCalls()
        {
            var options = Recording.InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                VisualStudioCodeTenantId = TestEnvironment.TestTenantId
            });

            var cloudName = Guid.NewGuid().ToString();
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment, cloudName);
            var processService = new TestProcessService { CreateHandler = psi => new TestProcess { Error = "Error" }};

            var factory = new TestDefaultAzureCredentialFactory(options, fileSystem, processService, default);
            var credential = InstrumentClient(new DefaultAzureCredential(factory, options));

            var tasks = new List<Task<AccessToken>>();
            using (await CredentialTestHelpers.CreateRefreshTokenFixtureAsync(TestEnvironment, Mode, ExpectedServiceName, cloudName))
            {
                for (int i = 0; i < 10; i++)
                {
                    tasks.Add(Task.Run(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None)));
                }

                await Task.WhenAll(tasks);
            }

            foreach (Task<AccessToken> task in tasks)
            {
                Assert.IsNotNull(task.Result.Token);
            }
        }

        [Test]
        public async Task DefaultAzureCredential_UseAzureCliCredential()
        {
            var options = Recording.InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                VisualStudioCodeTenantId = TestEnvironment.TestTenantId
            });

            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var testProcess = new TestProcess { Output = processOutput };
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", null);
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment);

            var factory = new TestDefaultAzureCredentialFactory(options, fileSystem, new TestProcessService(testProcess), vscAdapter);
            var credential = InstrumentClient(new DefaultAzureCredential(factory, options));

            AccessToken token;
            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                token = await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None);
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);

            Assert.AreEqual(2, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(AzureCliCredential)}.{nameof(AzureCliCredential.GetToken)}", scopes[1].Name);
        }

        [Test]
        public async Task DefaultAzureCredential_UseAzureCliCredential_ParallelCalls()
        {
            var options = Recording.InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                VisualStudioCodeTenantId = TestEnvironment.TestTenantId
            });

            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var processService = new TestProcessService { CreateHandler = psi => new TestProcess { Output = processOutput }};
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", null);
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment);

            var factory = new TestDefaultAzureCredentialFactory(options, fileSystem, processService, vscAdapter);
            var credential = InstrumentClient(new DefaultAzureCredential(factory, options));

            var tasks = new List<Task<AccessToken>>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None)));
            }

            await Task.WhenAll(tasks);

            foreach (Task<AccessToken> task in tasks)
            {
                Assert.AreEqual(task.Result.Token, expectedToken);
                Assert.AreEqual(task.Result.ExpiresOn, expectedExpiresOn);
            }
        }

        [Test]
        public void DefaultAzureCredential_AllCredentialsHaveFailed_CredentialUnavailableException()
        {
            var options = Recording.InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeSharedTokenCacheCredential = true,
            });

            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", "{}");
            var factory = new TestDefaultAzureCredentialFactory(options, new TestFileSystemService(), new TestProcessService(new TestProcess { Error = "'az' is not recognized" }), vscAdapter);
            var credential = InstrumentClient(new DefaultAzureCredential(factory, options));

            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                Assert.CatchAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None));
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(4, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(VisualStudioCredential)}.{nameof(VisualStudioCredential.GetToken)}", scopes[1].Name);
            Assert.AreEqual($"{nameof(VisualStudioCodeCredential)}.{nameof(VisualStudioCodeCredential.GetToken)}", scopes[2].Name);
            Assert.AreEqual($"{nameof(AzureCliCredential)}.{nameof(AzureCliCredential.GetToken)}", scopes[3].Name);
        }

        [Test]
        public void DefaultAzureCredential_AllCredentialsHaveFailed_AuthenticationFailedException()
        {
            var options = Recording.InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
            });

            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", null);
            var factory = new TestDefaultAzureCredentialFactory(options, new TestFileSystemService(), new TestProcessService(new TestProcess { Error = "Error" }), vscAdapter);
            var credential = InstrumentClient(new DefaultAzureCredential(factory, options));

            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                Assert.CatchAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None));
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(5, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(ManagedIdentityCredential)}.{nameof(ManagedIdentityCredential.GetToken)}", scopes[1].Name);
            Assert.AreEqual($"{nameof(VisualStudioCredential)}.{nameof(VisualStudioCredential.GetToken)}", scopes[2].Name);
            Assert.AreEqual($"{nameof(VisualStudioCodeCredential)}.{nameof(VisualStudioCodeCredential.GetToken)}", scopes[3].Name);
            Assert.AreEqual($"{nameof(AzureCliCredential)}.{nameof(AzureCliCredential.GetToken)}", scopes[4].Name);
        }
    }
}
