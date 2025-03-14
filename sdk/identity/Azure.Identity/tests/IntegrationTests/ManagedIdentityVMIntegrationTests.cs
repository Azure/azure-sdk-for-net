// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class ManagedIdentityVMIntegrationTests : IdentityRecordedTestBase
    {
        public ManagedIdentityVMIntegrationTests(bool isAsync) : base(isAsync)
        { }

        [Test]
        [LiveOnly]
        [RunOnlyOnPlatforms(SelfHostedAgent = true)]
        [Category("IdentityVM")]
        [TestCase(ManagedIdentityIdType.SystemAssigned)]
        [TestCase(ManagedIdentityIdType.ClientId)]
        [TestCase(ManagedIdentityIdType.ObjectId)]
        // This test leverages the test app found in Azure.Identity\integration\WebApp
        // It validates that ManagedIdentityCredential can acquire a token in an actual Azure Web App environment
        public async Task GetManagedIdentityToken(ManagedIdentityIdType idType)
        {
            ManagedIdentityId managedIdentityId = idType switch
            {
                ManagedIdentityIdType.ClientId => ManagedIdentityId.FromUserAssignedClientId(TestEnvironment.VMUserAssignedManagedIdentityClientId),
                ManagedIdentityIdType.ObjectId => ManagedIdentityId.FromUserAssignedObjectId(TestEnvironment.VMUserAssignedManagedIdentityObjectId),
                _ => ManagedIdentityId.SystemAssigned
            };
            ManagedIdentityCredentialOptions options = new ManagedIdentityCredentialOptions(managedIdentityId);

            var cred = new ManagedIdentityCredential(options);
            var token = await cred.GetTokenAsync(new(CredentialTestHelpers.DefaultScope));
            Assert.NotNull(token.Token);

            var cred2 = new ManagedIdentityCredential(managedIdentityId);
            token = await cred2.GetTokenAsync(new(CredentialTestHelpers.DefaultScope));
            Assert.NotNull(token.Token);
        }

        public enum ManagedIdentityIdType
        {
            SystemAssigned,
            ClientId,
            ObjectId
        }
    }
}
