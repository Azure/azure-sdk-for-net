// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Security.KeyVault.Secrets;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityCredentialImdsLiveTests : RecordedTestBase
    {
        public ManagedIdentityCredentialImdsLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            Sanitizer = new IdentityRecordedTestSanitizer();
        }

        [SetUp]
        public void ResetManagedIdenityClient()
        {
            typeof(ManagedIdentityClient).GetField("s_msiType", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, 0);
            typeof(ManagedIdentityClient).GetField("s_endpoint", BindingFlags.NonPublic | BindingFlags.Static).SetValue(null, null);
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

            var credoptions = Recording.InstrumentClientOptions(new TokenCredentialOptions());

            var cred = new ManagedIdentityCredential(options: credoptions);

            var kvoptions = Recording.InstrumentClientOptions(new SecretClientOptions());

            var kvclient = InstrumentClient(new SecretClient(vaultUri, cred, kvoptions));

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

            var credoptions = Recording.InstrumentClientOptions(new TokenCredentialOptions());

            var cred = InstrumentClient(new ManagedIdentityCredential(clientId: clientId, options: credoptions));

            var kvoptions = Recording.InstrumentClientOptions(new SecretClientOptions());

            var kvclient = new SecretClient(vaultUri, cred, kvoptions);

            KeyVaultSecret secret = await kvclient.GetSecretAsync("identitytestsecret");

            Assert.IsNotNull(secret);
        }
    }
}
