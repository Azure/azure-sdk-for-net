// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;

namespace Sql.Tests
{
    public class ManagedInstanceEncryptionProtectorScenarioTests
    {
        [Fact(Skip = "Cannot automate: KeyVaultErrorException : Operation returned an invalid status code 'Forbidden'")]
        public void TestUpdateEncryptionProtector()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();
                ResourceManagementClient resourceClient = context.GetClient<ResourceManagementClient>();
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                string resourceGroupName = resourceGroup.Name;

                ManagedInstance managedInstance = context.CreateManagedInstance(resourceGroup, new ManagedInstance() 
                { 
                    Identity = new ResourceIdentity()
                    {
                        Type = IdentityType.SystemAssignedUserAssigned,
                        UserAssignedIdentities = ManagedInstanceTestUtilities.UserIdentity
                    },
                    PrimaryUserAssignedIdentityId = ManagedInstanceTestUtilities.UAMI
                });
                managedInstance = sqlClient.ManagedInstances.Get(resourceGroupName, managedInstance.Name);

                var keyBundle = SqlManagementTestUtilities.CreateKeyVaultKeyWithManagedInstanceAccess(context, resourceGroup, managedInstance);

                // Create server key
                string serverKeyName = SqlManagementTestUtilities.GetServerKeyNameFromKeyBundle(keyBundle);
                string serverKeyUri = keyBundle.Key.Kid;
                var managedInstanceKey = sqlClient.ManagedInstanceKeys.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, serverKeyName, new ManagedInstanceKey()
                {
                    ServerKeyType = "AzureKeyVault",
                    Uri = serverKeyUri
                });
                SqlManagementTestUtilities.ValidateManagedInstanceKey(managedInstanceKey, serverKeyName, "AzureKeyVault", serverKeyUri);

                // Update to Key Vault
                sqlClient.ManagedInstanceEncryptionProtectors.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, new ManagedInstanceEncryptionProtector()
                {
                    ServerKeyName = serverKeyName,
                    ServerKeyType = "AzureKeyVault"
                });

                ManagedInstanceEncryptionProtector encProtector1 = sqlClient.ManagedInstanceEncryptionProtectors.Get(resourceGroup.Name, managedInstance.Name);
                Assert.Equal("AzureKeyVault", encProtector1.ServerKeyType);
                Assert.Equal(serverKeyName, encProtector1.ServerKeyName);

                // Update to Service Managed
                sqlClient.ManagedInstanceEncryptionProtectors.CreateOrUpdate(resourceGroup.Name, managedInstance.Name, new ManagedInstanceEncryptionProtector()
                {
                    ServerKeyName = "ServiceManaged",
                    ServerKeyType = "ServiceManaged"
                });

                ManagedInstanceEncryptionProtector encProtector2 = sqlClient.ManagedInstanceEncryptionProtectors.Get(resourceGroup.Name, managedInstance.Name);
                Assert.Equal("ServiceManaged", encProtector2.ServerKeyType);
                Assert.Equal("ServiceManaged", encProtector2.ServerKeyName);
            }
        }
    }
}