// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;

namespace Sql.Tests
{
    public class EncryptionProtectorScenarioTests
    {
        [Fact(Skip = "Needs to be rerecorded with new version of KeyVault")]
        public void TestUpdateEncryptionProtector()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = sqlClient.Servers.CreateOrUpdate(
                    resourceGroup.Name, 
                    serverName: SqlManagementTestUtilities.GenerateName(),
                    parameters: new Server
                {
                    AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
                    AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
                    Location = resourceGroup.Location,
                    Identity = new ResourceIdentity()
                    {
                        Type = IdentityType.SystemAssigned
                    }
                });

                var keyBundle = SqlManagementTestUtilities.CreateKeyVaultKeyWithServerAccess(context, resourceGroup, server);

                // Create server key
                string serverKeyName = SqlManagementTestUtilities.GetServerKeyNameFromKeyBundle(keyBundle);
                string serverKeyUri = keyBundle.Key.Kid;
                var serverKey = sqlClient.ServerKeys.CreateOrUpdate(resourceGroup.Name, server.Name, serverKeyName, new ServerKey()
                {
                    ServerKeyType = "AzureKeyVault",
                    Uri = serverKeyUri
                });
                SqlManagementTestUtilities.ValidateServerKey(serverKey, serverKeyName, "AzureKeyVault", serverKeyUri);

                // Update to Key Vault
                sqlClient.EncryptionProtectors.CreateOrUpdate(resourceGroup.Name, server.Name, new EncryptionProtector()
                {
                    ServerKeyName = serverKeyName,
                    ServerKeyType = "AzureKeyVault"
                });

                EncryptionProtector encProtector1 = sqlClient.EncryptionProtectors.Get(resourceGroup.Name, server.Name);
                Assert.Equal("AzureKeyVault", encProtector1.ServerKeyType);
                Assert.Equal(serverKeyName, encProtector1.ServerKeyName);

                // Update to Service Managed
                sqlClient.EncryptionProtectors.CreateOrUpdate(resourceGroup.Name, server.Name, new EncryptionProtector()
                {
                    ServerKeyName = "ServiceManaged",
                    ServerKeyType = "ServiceManaged"
                });

                EncryptionProtector encProtector2 = sqlClient.EncryptionProtectors.Get(resourceGroup.Name, server.Name);
                Assert.Equal("ServiceManaged", encProtector2.ServerKeyType);
                Assert.Equal("ServiceManaged", encProtector2.ServerKeyName);
            }
        }
    }
}