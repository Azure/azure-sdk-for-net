// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Sql.Tests
{
    public class ServerKeyScenarioTests
    {
        [Fact]
        public void TestCreateUpdateDropServerKey()
        {
            string testPrefix = "sqlserverkeytest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestWithTdeByokSetup(suiteName, "TestCreateUpdateDropServerKey", testPrefix, (resClient, sqlClient, resourceGroup, server, keyBundle) =>
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

                // Validate key exists by getting key
                var key1 = sqlClient.ServerKeys.Get(resourceGroup.Name, server.Name, serverKeyName);
                SqlManagementTestUtilities.ValidateServerKey(key1, serverKeyName, "AzureKeyVault", serverKeyUri);

                // Validate key exists by listing keys
                var keyList = sqlClient.ServerKeys.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(2, keyList.Count());

                // Delete key
                sqlClient.ServerKeys.Delete(resourceGroup.Name, server.Name, serverKeyName);

                // Validate key is gone by listing keys
                var keyList2 = sqlClient.ServerKeys.ListByServer(resourceGroup.Name, server.Name);
                Assert.Equal(1, keyList2.Count());
            });
        }
    }
}