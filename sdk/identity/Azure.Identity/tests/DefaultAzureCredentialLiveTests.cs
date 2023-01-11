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
    public class DefaultAzureCredentialLiveTests : IdentityRecordedTestBase
    {
        private const string ExpectedServiceName = "VS Code Azure";

        public DefaultAzureCredentialLiveTests(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        [RecordedTest]
        [RunOnlyOnPlatforms(Windows = true)] // VisualStudioCredential works only on Windows
        public async Task DefaultAzureCredential_UseVisualStudioCredential()
        {
            var options = InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                ExcludeAzureCliCredential = true,
                ExcludeAzureDeveloperCliCredential = true,
                ExcludeVisualStudioCodeCredential = false,
            });

            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var testProcess = new TestProcess { Output = processOutput };

            var factory = new TestDefaultAzureCredentialFactory(options, fileSystem, new TestProcessService(testProcess), default);
            var credential = InstrumentClient(new DefaultAzureCredential(factory));

            AccessToken token;
            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                token = await credential.GetTokenAsync(new TokenRequestContext(new[] {TestEnvironment.KeyvaultScope}), CancellationToken.None);
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);

            Assert.AreEqual(2, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(VisualStudioCredential)}.{nameof(VisualStudioCredential.GetToken)}", scopes[1].Name);
        }

        [RecordedTest]
        [RunOnlyOnPlatforms(Windows = true, OSX = true, ContainerNames = new[] { "ubuntu_netcore_keyring" })]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/27263")]
        public async Task DefaultAzureCredential_UseVisualStudioCodeCredential()
        {
            var options = InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeVisualStudioCredential = true,
                ExcludeAzureCliCredential = true,
                ExcludeAzureDeveloperCliCredential = true,
                ExcludeVisualStudioCodeCredential = false,
                VisualStudioCodeTenantId = TestEnvironment.IdentityTenantId
            });

            var cloudName = Guid.NewGuid().ToString();
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment, cloudName);
            var process = new TestProcess { Error = "Error" };

            var factory = new TestDefaultAzureCredentialFactory(options, fileSystem, new TestProcessService(process), default);
            var credential = InstrumentClient(new DefaultAzureCredential(factory));

            AccessToken token;
            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (await CredentialTestHelpers.CreateRefreshTokenFixtureAsync(TestEnvironment, Mode, ExpectedServiceName, cloudName))
            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                token = await credential.GetTokenAsync(new TokenRequestContext(new[] {TestEnvironment.KeyvaultScope}), CancellationToken.None);
                scopes = diagnosticListener.Scopes;
            }

            Assert.IsNotNull(token.Token);

            Assert.AreEqual(2, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(VisualStudioCodeCredential)}.{nameof(VisualStudioCodeCredential.GetToken)}", scopes[1].Name);
        }

        [RecordedTest]
        [RunOnlyOnPlatforms(Windows = true, OSX = true, ContainerNames = new[] { "ubuntu_netcore_keyring" })]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/27263")]
        public async Task DefaultAzureCredential_UseVisualStudioCodeCredential_ParallelCalls()
        {
            var options = InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeAzureCliCredential = true,
                ExcludeAzureDeveloperCliCredential = true,
                ExcludeVisualStudioCodeCredential = false,
                VisualStudioCodeTenantId = TestEnvironment.IdentityTenantId
            });

            var cloudName = Guid.NewGuid().ToString();
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment, cloudName);
            var processService = new TestProcessService { CreateHandler = psi => new TestProcess { Error = "Error" }};

            var factory = new TestDefaultAzureCredentialFactory(options, fileSystem, processService, default);
            var credential = InstrumentClient(new DefaultAzureCredential(factory));

            var tasks = new List<Task<AccessToken>>();
            using (await CredentialTestHelpers.CreateRefreshTokenFixtureAsync(TestEnvironment, Mode, ExpectedServiceName, cloudName))
            {
                for (int i = 0; i < 10; i++)
                {
                    tasks.Add(Task.Run(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {TestEnvironment.KeyvaultScope}), CancellationToken.None)));
                }

                await Task.WhenAll(tasks);
            }

            foreach (Task<AccessToken> task in tasks)
            {
                Assert.IsNotNull(task.Result.Token);
            }
        }

        [RecordedTest]
        public async Task DefaultAzureCredential_UseAzureCliCredential()
        {
            var options = InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeVisualStudioCodeCredential = false,
                VisualStudioCodeTenantId = TestEnvironment.IdentityTenantId
            });

            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var (expectedTokenAzd, expectedExpiresOnAzd, processOutputAzd) = CredentialTestHelpers.CreateTokenForAzureDeveloperCli();
            var testProcess = new TestProcess { Output = processOutput };
            var testProcessAzd = new TestProcess { Output = processOutputAzd };
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "AzureCloud", null);
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment);

            var factory = new TestDefaultAzureCredentialFactory(options, fileSystem, new TestProcessService(testProcess), vscAdapter);
            var credential = InstrumentClient(new DefaultAzureCredential(factory));

            var factoryAzd = new TestDefaultAzureCredentialFactory(options, fileSystem, new TestProcessService(testProcessAzd), vscAdapter);
            var credentialAzd = InstrumentClient(new DefaultAzureCredential(factoryAzd));

            AccessToken token;
            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            AccessToken tokenAzd;
            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopesAzd;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                token = await credential.GetTokenAsync(new TokenRequestContext(new[] {TestEnvironment.KeyvaultScope}), CancellationToken.None);
                scopes = diagnosticListener.Scopes;
            }

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                tokenAzd = await credential.GetTokenAsync(new TokenRequestContext(new[] {TestEnvironment.KeyvaultScope}), CancellationToken.None);
                scopesAzd = diagnosticListener.Scopes;
            }

            
            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);

            Assert.AreEqual(tokenAzd.Token, expectedTokenAzd);
            Assert.AreEqual(tokenAzd.ExpiresOn, expectedExpiresOnAzd);

            Assert.AreEqual(2, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(AzureCliCredential)}.{nameof(AzureCliCredential.GetToken)}", scopes[1].Name);

            Assert.AreEqual(2, scopesAzd.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopesAzd[0].Name);
            Assert.AreEqual($"{nameof(AzureDeveloperCliCredential)}.{nameof(AzureDeveloperCliCredential.GetToken)}", scopesAzd[1].Name);
        }

        [RecordedTest]
        [Ignore("https://github.com/Azure/azure-sdk-for-net/issues/27020")]
        public async Task DefaultAzureCredential_UseAzureCliCredential_ParallelCalls()
        {
            var options = InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeVisualStudioCodeCredential = false,
                VisualStudioCodeTenantId = TestEnvironment.IdentityTenantId
            });

            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var (expectedTokenAzd, expectedExpiresOnAzd, processOutputAzd) = CredentialTestHelpers.CreateTokenForAzureDeveloperCli();
            var processService = new TestProcessService { CreateHandler = psi => new TestProcess { Output = processOutput }};
            var processServiceAzd = new TestProcessService { CreateHandler = psi => new TestProcess { Output = processOutputAzd }};
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "AzureCloud", null);
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment);

            var factory = new TestDefaultAzureCredentialFactory(options, fileSystem, processService, vscAdapter);
            var credential = InstrumentClient(new DefaultAzureCredential(factory));

            var factoryAzd = new TestDefaultAzureCredentialFactory(options, fileSystem, processServiceAzd, vscAdapter);
            var credentialAzd = InstrumentClient(new DefaultAzureCredential(factoryAzd));

            var tasks = new List<Task<AccessToken>>();
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Run(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {TestEnvironment.KeyvaultScope}), CancellationToken.None)));
            }

            await Task.WhenAll(tasks);

            foreach (Task<AccessToken> task in tasks)
            {
                Assert.AreEqual(task.Result.Token, expectedToken);
                Assert.AreEqual(task.Result.ExpiresOn, expectedExpiresOn);
            }

            var tasksAzd = new List<Task<AccessToken>>();
            for (int i = 0; i < 10; i++)
            {
                tasksAzd.Add(Task.Run(async () => await credentialAzd.GetTokenAsync(new TokenRequestContext(new[] {TestEnvironment.KeyvaultScope}), CancellationToken.None)));
            }

            await Task.WhenAll(tasksAzd);

            foreach (Task<AccessToken> task in tasksAzd)
            {
                Assert.AreEqual(task.Result.Token, expectedTokenAzd);
                Assert.AreEqual(task.Result.ExpiresOn, expectedExpiresOnAzd);
            }
        }

        [RecordedTest]
        public void DefaultAzureCredential_AllCredentialsHaveFailed_CredentialUnavailableException()
        {
            var options = InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                ExcludeVisualStudioCodeCredential = false,
            });

            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "AzureCloud", "{}");
            var factory = new TestDefaultAzureCredentialFactory(options, new TestFileSystemService(), new TestProcessService(new TestProcess { Error = "'az' is not recognized" }, new TestProcess{Error = "'PowerShell' is not recognized"}, new TestProcess{Error = "'PowerShell' is not recognized"}), vscAdapter);
            var credential = InstrumentClient(new DefaultAzureCredential(factory));

            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                Assert.CatchAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {TestEnvironment.KeyvaultScope}), CancellationToken.None));
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(6, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(VisualStudioCredential)}.{nameof(VisualStudioCredential.GetToken)}", scopes[1].Name);
            Assert.AreEqual($"{nameof(VisualStudioCodeCredential)}.{nameof(VisualStudioCodeCredential.GetToken)}", scopes[2].Name);
            Assert.AreEqual($"{nameof(AzureCliCredential)}.{nameof(AzureCliCredential.GetToken)}", scopes[3].Name);
            Assert.AreEqual($"{nameof(AzureDeveloperCliCredential)}.{nameof(AzureDeveloperCliCredential.GetToken)}", scopes[4].Name);
            Assert.AreEqual($"{nameof(AzurePowerShellCredential)}.{nameof(AzurePowerShellCredential.GetToken)}", scopes[5].Name);
        }

        [RecordedTest]
        public void DefaultAzureCredential_AllCredentialsHaveFailed_FirstAuthenticationFailedException()
        {
            var options = InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeVisualStudioCodeCredential = false,
            });

            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "AzureCloud", null);
            var factory = new TestDefaultAzureCredentialFactory(options, new TestFileSystemService(), new TestProcessService(new TestProcess { Error = "Error" }), vscAdapter);
            var credential = InstrumentClient(new DefaultAzureCredential(factory));

            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                Assert.CatchAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None));
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(5, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(VisualStudioCredential)}.{nameof(VisualStudioCredential.GetToken)}", scopes[1].Name);
            Assert.AreEqual($"{nameof(VisualStudioCodeCredential)}.{nameof(VisualStudioCodeCredential.GetToken)}", scopes[2].Name);
            Assert.AreEqual($"{nameof(AzureCliCredential)}.{nameof(AzureCliCredential.GetToken)}", scopes[3].Name);
            Assert.AreEqual($"{nameof(AzureDeveloperCliCredential)}.{nameof(AzureDeveloperCliCredential.GetToken)}", scopes[4].Name);
        }

        [RecordedTest]
        public void DefaultAzureCredential_AllCredentialsHaveFailed_LastAuthenticationFailedException()
        {
            var options = InstrumentClientOptions(new DefaultAzureCredentialOptions
            {
                ExcludeEnvironmentCredential = true,
                ExcludeInteractiveBrowserCredential = true,
                ExcludeSharedTokenCacheCredential = true,
                ExcludeManagedIdentityCredential = true,
                ExcludeVisualStudioCodeCredential = false,
            });

            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "AzureCloud", null);
            var factory = new TestDefaultAzureCredentialFactory(options, new TestFileSystemService(), new TestProcessService(new TestProcess { Error = "Error" }), vscAdapter);
            var credential = InstrumentClient(new DefaultAzureCredential(factory));

            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                Assert.CatchAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {TestEnvironment.KeyvaultScope}), CancellationToken.None));
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(5, scopes.Count);
            Assert.AreEqual($"{nameof(DefaultAzureCredential)}.{nameof(DefaultAzureCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(VisualStudioCredential)}.{nameof(VisualStudioCredential.GetToken)}", scopes[1].Name);
            Assert.AreEqual($"{nameof(VisualStudioCodeCredential)}.{nameof(VisualStudioCodeCredential.GetToken)}", scopes[2].Name);
            Assert.AreEqual($"{nameof(AzureCliCredential)}.{nameof(AzureCliCredential.GetToken)}", scopes[3].Name);
            Assert.AreEqual($"{nameof(AzureDeveloperCliCredential)}.{nameof(AzureDeveloperCliCredential.GetToken)}", scopes[4].Name);
        }
    }
}
