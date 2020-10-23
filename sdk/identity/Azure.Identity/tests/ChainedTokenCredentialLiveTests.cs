// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.Tests;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ChainedTokenCredentialLiveTests : RecordedTestBase<IdentityTestEnvironment>
    {
        private const string ExpectedServiceName = "VS Code Azure";

        public ChainedTokenCredentialLiveTests(bool isAsync) : base(isAsync)
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
        public async Task ChainedTokenCredential_UseVisualStudioCredential()
        {
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudio();
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForVisualStudio();
            var processService = new TestProcessService(new TestProcess { Output = processOutput });

            var miCredential = new ManagedIdentityCredential(EnvironmentVariables.ClientId);
            var vsCredential = new VisualStudioCredential(default, default, fileSystem, processService);
            var credential = InstrumentClient(new ChainedTokenCredential(miCredential, vsCredential));

            AccessToken token;
            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                token = await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None);
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);

            Assert.AreEqual(1, scopes.Count);
            Assert.AreEqual($"{nameof(VisualStudioCredential)}.{nameof(VisualStudioCredential.GetToken)}", scopes[0].Name);
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true, OSX = true, ContainerNames = new[] { "ubuntu_netcore_keyring" })]
        public async Task ChainedTokenCredential_UseVisualStudioCodeCredential()
        {
            var cloudName = Guid.NewGuid().ToString();
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment, cloudName);
            var processService = new TestProcessService(new TestProcess { Error = "Error" });

            var vscOptions = InstrumentClientOptions(new VisualStudioCodeCredentialOptions { TenantId = TestEnvironment.TestTenantId });

            var miCredential = new ManagedIdentityCredential(EnvironmentVariables.ClientId);
            var vsCredential = new VisualStudioCredential(default, default, fileSystem, processService);
            var vscCredential = new VisualStudioCodeCredential(vscOptions, default, default, fileSystem, default);

            var credential = InstrumentClient(new ChainedTokenCredential(miCredential, vsCredential, vscCredential));

            AccessToken token;
            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (await CredentialTestHelpers.CreateRefreshTokenFixtureAsync(TestEnvironment, Mode, ExpectedServiceName, cloudName))
            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                token = await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None);
                scopes = diagnosticListener.Scopes;
            }

            Assert.IsNotNull(token.Token);

            Assert.AreEqual(1, scopes.Count);
            Assert.AreEqual($"{nameof(VisualStudioCodeCredential)}.{nameof(VisualStudioCodeCredential.GetToken)}", scopes[0].Name);
        }

        [Test]
        [RunOnlyOnPlatforms(Windows = true, OSX = true, ContainerNames = new[] { "ubuntu_netcore_keyring" })]
        public async Task ChainedTokenCredential_UseVisualStudioCodeCredential_ParallelCalls()
        {
            var cloudName = Guid.NewGuid().ToString();
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment, cloudName);
            var processService = new TestProcessService { CreateHandler = psi => new TestProcess { Error = "Error" }};

            var vscOptions = InstrumentClientOptions(new VisualStudioCodeCredentialOptions { TenantId = TestEnvironment.TestTenantId });

            var miCredential = new ManagedIdentityCredential(EnvironmentVariables.ClientId);
            var vsCredential = new VisualStudioCredential(default, default, fileSystem, processService);
            var vscCredential = new VisualStudioCodeCredential(vscOptions, default, default, fileSystem, default);
            var credential = InstrumentClient(new ChainedTokenCredential(miCredential, vsCredential, vscCredential));

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
        public async Task ChainedTokenCredential_UseAzureCliCredential()
        {
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", null);
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment);
            var processService = new TestProcessService(new TestProcess { Output = processOutput });

            var miCredential = new ManagedIdentityCredential(EnvironmentVariables.ClientId);
            var vsCredential = new VisualStudioCredential(default, default, fileSystem, processService);
            var vscCredential = new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions { TenantId = TestEnvironment.TestTenantId }, default, default, fileSystem, vscAdapter);
            var azureCliCredential = new AzureCliCredential(CredentialPipeline.GetInstance(null), processService);

            var credential = InstrumentClient(new ChainedTokenCredential(miCredential, vsCredential, vscCredential, azureCliCredential));

            AccessToken token;
            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;

            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                token = await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None);
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);

            Assert.AreEqual(1, scopes.Count);
            Assert.AreEqual($"{nameof(AzureCliCredential)}.{nameof(AzureCliCredential.GetToken)}", scopes[0].Name);
        }

        [Test]
        public async Task ChainedTokenCredential_UseAzureCliCredential_ParallelCalls()
        {
            var (expectedToken, expectedExpiresOn, processOutput) = CredentialTestHelpers.CreateTokenForAzureCli();
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", null);
            var fileSystem = CredentialTestHelpers.CreateFileSystemForVisualStudioCode(TestEnvironment);
            var processService = new TestProcessService { CreateHandler = psi => new TestProcess { Output = processOutput }};

            var miCredential = new ManagedIdentityCredential(EnvironmentVariables.ClientId);
            var vsCredential = new VisualStudioCredential(default, default, fileSystem, processService);
            var vscCredential = new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions { TenantId = TestEnvironment.TestTenantId }, default, default, fileSystem, vscAdapter);
            var azureCliCredential = new AzureCliCredential(CredentialPipeline.GetInstance(null), processService);

            var credential = InstrumentClient(new ChainedTokenCredential(miCredential, vsCredential, vscCredential, azureCliCredential));

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
        public void ChainedTokenCredential_AllCredentialsHaveFailed_CredentialUnavailableException()
        {
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", "{}");

            var fileSystem = new TestFileSystemService();
            var processService = new TestProcessService(new TestProcess { Error = "'az' is not recognized" });

            var vsCredential = new VisualStudioCredential(default, default, fileSystem, processService);
            var vscCredential = new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions { TenantId = TestEnvironment.TestTenantId }, default, default, fileSystem, vscAdapter);
            var azureCliCredential = new AzureCliCredential(CredentialPipeline.GetInstance(null), processService);

            var credential = InstrumentClient(new ChainedTokenCredential(vsCredential, vscCredential, azureCliCredential));

            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;
            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                Assert.CatchAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None));
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(3, scopes.Count);
            Assert.AreEqual($"{nameof(VisualStudioCredential)}.{nameof(VisualStudioCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(VisualStudioCodeCredential)}.{nameof(VisualStudioCodeCredential.GetToken)}", scopes[1].Name);
            Assert.AreEqual($"{nameof(AzureCliCredential)}.{nameof(AzureCliCredential.GetToken)}", scopes[2].Name);
        }

        [Test]
        [NonParallelizable]
        public void ChainedTokenCredential_AllCredentialsHaveFailed_FirstAuthenticationFailedException()
        {
            using var endpoint = new TestEnvVar("MSI_ENDPOINT", "abc");

            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", null);
            var fileSystem = new TestFileSystemService();
            var processService = new TestProcessService(new TestProcess {Error = "Error"});

            var miCredential = new ManagedIdentityCredential(EnvironmentVariables.ClientId);
            var vsCredential = new VisualStudioCredential(default, default, fileSystem, processService);
            var vscCredential = new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions { TenantId = TestEnvironment.TestTenantId }, default, default, fileSystem, vscAdapter);
            var azureCliCredential = new AzureCliCredential(CredentialPipeline.GetInstance(null), processService);

            var credential = InstrumentClient(new ChainedTokenCredential(miCredential, vsCredential, vscCredential, azureCliCredential));

            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;
            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                Assert.CatchAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None));
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(1, scopes.Count);
            Assert.AreEqual($"{nameof(ManagedIdentityCredential)}.{nameof(ManagedIdentityCredential.GetToken)}", scopes[0].Name);
        }

        [Test]
        public void ChainedTokenCredential_AllCredentialsHaveFailed_LastAuthenticationFailedException()
        {
            var vscAdapter = new TestVscAdapter(ExpectedServiceName, "Azure", null);
            var fileSystem = new TestFileSystemService();
            var processService = new TestProcessService(new TestProcess {Error = "Error"});

            var miCredential = new ManagedIdentityCredential(EnvironmentVariables.ClientId);
            var vsCredential = new VisualStudioCredential(default, default, fileSystem, processService);
            var vscCredential = new VisualStudioCodeCredential(new VisualStudioCodeCredentialOptions { TenantId = TestEnvironment.TestTenantId }, default, default, fileSystem, vscAdapter);
            var azureCliCredential = new AzureCliCredential(CredentialPipeline.GetInstance(null), processService);

            var credential = InstrumentClient(new ChainedTokenCredential(miCredential, vsCredential, vscCredential, azureCliCredential));

            List<ClientDiagnosticListener.ProducedDiagnosticScope> scopes;
            using (ClientDiagnosticListener diagnosticListener = new ClientDiagnosticListener(s => s.StartsWith("Azure.Identity")))
            {
                Assert.CatchAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None));
                scopes = diagnosticListener.Scopes;
            }

            Assert.AreEqual(4, scopes.Count);
            Assert.AreEqual($"{nameof(ManagedIdentityCredential)}.{nameof(ManagedIdentityCredential.GetToken)}", scopes[0].Name);
            Assert.AreEqual($"{nameof(VisualStudioCredential)}.{nameof(VisualStudioCredential.GetToken)}", scopes[1].Name);
            Assert.AreEqual($"{nameof(VisualStudioCodeCredential)}.{nameof(VisualStudioCodeCredential.GetToken)}", scopes[2].Name);
            Assert.AreEqual($"{nameof(AzureCliCredential)}.{nameof(AzureCliCredential.GetToken)}", scopes[3].Name);
        }
    }
}
