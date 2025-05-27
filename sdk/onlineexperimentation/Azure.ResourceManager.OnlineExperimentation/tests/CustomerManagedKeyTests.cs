// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.OnlineExperimentation.Models;

using NUnit.Framework;

namespace Azure.ResourceManager.OnlineExperimentation.Tests
{
    public class CustomerManagedKeyTests : OnlineExperimentationManagementTestBase
    {
        public CustomerManagedKeyTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task ReadOnlineExperimentWorkspace()
        {
            var experimentWorkspaceRead = await TestWorkspaceResource.GetAsync();

            Assert.IsTrue(experimentWorkspaceRead.Value.HasData);

            var workspaceResourceData = experimentWorkspaceRead.Value.Data;

            Assert.IsNotNull(workspaceResourceData.Properties.Endpoint);
            Assert.AreEqual(Uri.UriSchemeHttps, workspaceResourceData.Properties.Endpoint.Scheme);
        }

        [TestCase]
        [RecordedTest]
        public async Task EnableCustomerManagedKeyEncryption()
        {
            var workspaceResourceId = ResourceIdentifier.Parse(TestEnvironment.OnlineExperimentationWorkspaceResourceId);
            var workspaceResource = Client.GetOnlineExperimentationWorkspaceResource(workspaceResourceId);

            var keyEncryptionKeyUri = new Uri(TestEnvironment.CustomerManagedKeyUri);

            var partialUpdateData = new OnlineExperimentationWorkspacePatch
            {
                Properties = new()
                {
                    CustomerManagedKeyEncryption = new CustomerManagedKeyEncryption
                    {
                        KeyEncryptionKeyUri = keyEncryptionKeyUri,
                        KeyEncryptionKeyIdentity = new KeyEncryptionKeyIdentity
                        {
                            IdentityType = KeyEncryptionKeyIdentityType.SystemAssignedIdentity,
                            UserAssignedIdentityResourceId = null,
                        }
                    }
                }
            };

            await workspaceResource.UpdateAsync(WaitUntil.Completed, partialUpdateData);
        }
    }
}
