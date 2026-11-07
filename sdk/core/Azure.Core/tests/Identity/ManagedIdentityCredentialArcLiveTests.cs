// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Identity.Client;
using NUnit.Framework;
namespace Azure.Core.Tests.Identity
{
    [LiveOnly]
    public class ManagedIdentityCredentialArcLiveTests : ManagedIdentityCredentialLiveTestBase
    {
        public ManagedIdentityCredentialArcLiveTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void ResetMsalState() => ApplicationBase.ResetStateForTest();

        [TearDown]
        public void ClearMsalState() => ApplicationBase.ResetStateForTest();

        [NonParallelizable]
        [Test]
        public async Task ValidateSystemAssignedIdentity()
        {
            if (string.IsNullOrEmpty(TestEnvironment.ArcEnable))
            {
                Assert.Ignore();
            }

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                var vaultUri = new Uri(TestEnvironment.SystemAssignedVault);

                var cred = new ManagedIdentityCredential(options: InstrumentClientOptions(new TokenCredentialOptions()));

                // Hard code service version or recorded tests will fail: https://github.com/Azure/azure-sdk-for-net/issues/10432
                var kvoptions = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));

                var kvclient = InstrumentClient(new SecretClient(vaultUri, cred, kvoptions));

                KeyVaultSecret secret = await kvclient.SetSecretAsync("identitytestsecret", "value");

                Assert.IsNotNull(secret);
            }
        }

        [NonParallelizable]
        [TestCase("ClientId")]
        [TestCase("ResourceId")]
        [TestCase("ObjectId")]
        public async Task ValidateUserAssignedIdentity(string identityType)
        {
            RequireArcUserAssignedIdentity();

            using (ReadOrRestoreManagedIdentityEnvironment())
            {
                ManagedIdentityId id = identityType switch
                {
                    "ClientId" => ManagedIdentityId.FromUserAssignedClientId(RequireSetting(TestEnvironment.ArcClientId, "IDENTITYTEST_ARCTEST_CLIENTID")),
                    "ResourceId" => ManagedIdentityId.FromUserAssignedResourceId(new ResourceIdentifier(
                        RequireSetting(TestEnvironment.ArcResourceId, "IDENTITYTEST_ARCTEST_RESOURCEID"))),
                    _ => ManagedIdentityId.FromUserAssignedObjectId(TestEnvironment.ArcObjectId)
                };
                var options = InstrumentClientOptions(new ManagedIdentityCredentialOptions(id));
                var credential = InstrumentClient(new ManagedIdentityCredential(options));

                await ValidateUserAssignedTokenAsync(credential);
            }
        }

        [NonParallelizable]
        [TestCase(false)]
        [TestCase(true)]
        public async Task ValidateDefaultAzureCredentialUserAssignedIdentity(bool useResourceId)
        {
            RequireArcUserAssignedIdentity();

            using (ReadOrRestoreManagedIdentityEnvironment())
            using (new TestEnvVar(new Dictionary<string, string>
            {
                { "AZURE_TOKEN_CREDENTIALS", "ManagedIdentityCredential" },
                { "AZURE_CLIENT_ID", null }
            }))
            {
                var options = InstrumentClientOptions(new DefaultAzureCredentialOptions());
                if (useResourceId)
                {
                    options.ManagedIdentityResourceId = new ResourceIdentifier(
                        RequireSetting(TestEnvironment.ArcResourceId, "IDENTITYTEST_ARCTEST_RESOURCEID"));
                }
                else
                {
                    options.ManagedIdentityClientId = RequireSetting(TestEnvironment.ArcClientId, "IDENTITYTEST_ARCTEST_CLIENTID");
                }
                var credential = InstrumentClient(new DefaultAzureCredential(options));

                await ValidateUserAssignedTokenAsync(credential);
            }
        }

        [NonParallelizable]
        [Test]
        public void ValidateUnattachedUserAssignedIdentity([Values(false, true)] bool useDefaultCredential)
        {
            RequireSetting(TestEnvironment.ArcEnable, "IDENTITYTEST_ARCTEST_ENABLE");
            string clientId = RequireSetting(TestEnvironment.ArcUnassignedClientId, "IDENTITYTEST_ARCTEST_UNASSIGNEDCLIENTID");

            using (ReadOrRestoreManagedIdentityEnvironment())
            using (new TestEnvVar("AZURE_TOKEN_CREDENTIALS", "ManagedIdentityCredential"))
            {
                TokenCredential credential = useDefaultCredential
                    ? new DefaultAzureCredential(InstrumentClientOptions(new DefaultAzureCredentialOptions { ManagedIdentityClientId = clientId }))
                    : new ManagedIdentityCredential(InstrumentClientOptions(new ManagedIdentityCredentialOptions(
                        ManagedIdentityId.FromUserAssignedClientId(clientId))));
                credential = InstrumentClient(credential);

                var ex = Assert.ThrowsAsync<AuthenticationFailedException>(async () =>
                    await credential.GetTokenAsync(new TokenRequestContext(new[] { TestEnvironment.KeyvaultScope }), default));

                Assert.That(ex.ToString(), Does.Contain("identity_not_found"));
            }
        }

        private void RequireArcUserAssignedIdentity()
        {
            RequireSetting(TestEnvironment.ArcEnable, "IDENTITYTEST_ARCTEST_ENABLE");
            RequireSetting(TestEnvironment.ArcObjectId, "IDENTITYTEST_ARCTEST_OBJECTID");
            RequireSetting(TestEnvironment.UserAssignedVault, "IDENTITYTEST_IMDSTEST_USERASSIGNEDVAULT");
        }

        private static string RequireSetting(string value, string name)
        {
            if (string.IsNullOrEmpty(value))
            {
                Assert.Ignore($"Set {name} to run this Arc live test.");
            }
            return value;
        }

        private async Task ValidateUserAssignedTokenAsync(TokenCredential credential)
        {
            AccessToken token = await credential.GetTokenAsync(new TokenRequestContext(new[] { TestEnvironment.KeyvaultScope }), default);
            Assert.AreEqual(TestEnvironment.ArcObjectId, TokenHelper.ParseAccountInfoFromToken(token.Token).ObjectId);

            var options = InstrumentClientOptions(new SecretClientOptions(SecretClientOptions.ServiceVersion.V7_0));
            var client = InstrumentClient(new SecretClient(new Uri(TestEnvironment.UserAssignedVault), credential, options));
            KeyVaultSecret secret = await client.GetSecretAsync("identitytestsecret");
            Assert.IsNotNull(secret);
        }
    }
}
