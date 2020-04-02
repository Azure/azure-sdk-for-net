// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    // These tests are intended to be only run live on an azure VM with managed identity enabled.
    public class ManagedIdentityCredentialImdsLiveTests : RecordedTestBase
    {
        public ManagedIdentityCredentialImdsLiveTests(bool isAsync) : base(isAsync)
        {
            Sanitizer = new IdentityRecordedTestSanitizer();
        }

        [NonParallelizable]
        [Test]
        public async Task ValidateImdsSystemAssignedIdentity()
        {
            if (string.IsNullOrEmpty(Recording.GetVariableFromEnvironment("IDENTITYTEST_IMDSTEST_ENABLE")))
            {
                Assert.Ignore();
            }

            var vaultUri = new Uri(Recording.GetVariableFromEnvironment("IDENTITYTEST_IMDSTEST_SYSTEMASSIGNEDVAULT"));

            var cred = CreateManagedIdentityCredential();

            // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
            var kvoptions = Recording.InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

            var kvclient = new SecretClient(vaultUri, cred, kvoptions);

            KeyVaultSecret secret = await kvclient.GetSecretAsync("identitytestsecret");

            Assert.IsNotNull(secret);
        }


        [NonParallelizable]
        [Test]
        public async Task ValidateImdsUserAssignedIdentity()
        {
            if (string.IsNullOrEmpty(Recording.GetVariableFromEnvironment("IDENTITYTEST_IMDSTEST_ENABLE")))
            {
                Assert.Ignore();
            }

            var vaultUri = new Uri(Recording.GetVariableFromEnvironment("IDENTITYTEST_IMDSTEST_USERASSIGNEDVAULT"));

            var clientId = Recording.GetVariableFromEnvironment("IDENTITYTEST_IMDSTEST_CLIENTID");

            var cred = CreateManagedIdentityCredential(clientId);

            // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
            var kvoptions = Recording.InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

            var kvclient = new SecretClient(vaultUri, cred, kvoptions);

            KeyVaultSecret secret = await kvclient.GetSecretAsync("identitytestsecret");

            Assert.IsNotNull(secret);
        }

        private ManagedIdentityCredential CreateManagedIdentityCredential(string clientId = null, TokenCredentialOptions options = null)
        {
            options = Recording.InstrumentClientOptions(options ?? new TokenCredentialOptions());

            var pipeline = CredentialPipeline.GetInstance(options);

            // if we're in playback mode we need to mock the ImdsAvailable call since we won't be able to open a connection
            var client = (Mode == RecordedTestMode.Playback) ? new MockManagedIdentityClient(pipeline, clientId) { ImdsAvailableFunc = _ => true } : new ManagedIdentityClient(pipeline, clientId);

            var cred = new ManagedIdentityCredential(pipeline, client);

            return cred;
        }
    }
}
