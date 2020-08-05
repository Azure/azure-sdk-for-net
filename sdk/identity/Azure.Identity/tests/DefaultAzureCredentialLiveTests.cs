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

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None);

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);
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

            using (await CredentialTestHelpers.CreateRefreshTokenFixtureAsync(TestEnvironment, Mode, ExpectedServiceName, cloudName))
            {
                token = await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None);
            }

            Assert.IsNotNull(token.Token);
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

            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None);

            Assert.AreEqual(token.Token, expectedToken);
            Assert.AreEqual(token.ExpiresOn, expectedExpiresOn);
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

            Assert.CatchAsync<CredentialUnavailableException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None));
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

            Assert.CatchAsync<AuthenticationFailedException>(async () => await credential.GetTokenAsync(new TokenRequestContext(new[] {"https://vault.azure.net/.default"}), CancellationToken.None));
        }
    }
}
