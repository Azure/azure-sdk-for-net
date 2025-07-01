// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using NUnit.Framework;

namespace Azure.Provisioning.PostgreSql.Tests
{
    public class PostgreSqlFlexibleServerTests
    {
        [TestCase]
        public void TestStorageSizeInGB()
        {
            var infra = new Infrastructure();
            var server = new PostgreSqlFlexibleServer("testServer", "2024-08-01");
            server.StorageSizeInGB = 100;
            server.Storage.StorageSizeInGB = 64;
            server.Storage.AutoGrow = StorageAutoGrow.Disabled;

            infra.Add(server);
            var plan = infra.Build();

            var bicep = plan.Compile().Values.First();
            Assert.AreEqual("""
                @description('The location for the resource(s) to be deployed.')
                param location string = resourceGroup().location

                resource testServer 'Microsoft.DBforPostgreSQL/flexibleServers@2024-08-01' = {
                  name: take('testserver-${uniqueString(resourceGroup().id)}', 63)
                  location: location
                  properties: {
                    storage: {
                      storageSizeGB: 64
                      autoGrow: 'Disabled'
                    }
                  }
                }
                """, bicep);
        }
    }
}
