// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sql.Tests
{
    public class EncryptionProtectorScenarioTests
    {
        [Fact]
        public void TestUpdateEncryptionProtector()
        {
            string testPrefix = "sqlencprotest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestWithTdeByokSetup(suiteName, "TestUpdateEncryptionProtector", testPrefix, (resClient, sqlClient, resourceGroup, server, keyBundle) =>
            {
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
                sqlClient.Servers.CreateOrUpdateEncryptionProtector(resourceGroup.Name, server.Name, new EncryptionProtector()
                {
                    ServerKeyName = serverKeyName,
                    ServerKeyType = "AzureKeyVault"
                });

                EncryptionProtector encProtector1 = sqlClient.Servers.GetEncryptionProtector(resourceGroup.Name, server.Name);
                Assert.Equal("AzureKeyVault", encProtector1.ServerKeyType);
                Assert.Equal(serverKeyName, encProtector1.ServerKeyName);

                // Update to Service Managed
                sqlClient.Servers.CreateOrUpdateEncryptionProtector(resourceGroup.Name, server.Name, new EncryptionProtector()
                {
                    ServerKeyName = "ServiceManaged",
                    ServerKeyType = "ServiceManaged"
                });

                EncryptionProtector encProtector2 = sqlClient.Servers.GetEncryptionProtector(resourceGroup.Name, server.Name);
                Assert.Equal("ServiceManaged", encProtector2.ServerKeyType);
                Assert.Equal("ServiceManaged", encProtector2.ServerKeyName);
            });
        }
    }
}