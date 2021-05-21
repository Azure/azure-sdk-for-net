// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;

namespace Sql.Tests
{
    public class DatabaseActivationScenarioTests
    {
        [Fact]
        public void TestPauseResumeDatabase()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                Server server = context.CreateServer(resourceGroup);
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create data warehouse
                string dbName = SqlManagementTestUtilities.GenerateName();
                var db1 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, new Database()
                {
                    Location = server.Location,
                    Sku = SqlTestConstants.DefaultDataWarehouseSku()
                });
                Assert.NotNull(db1);

                // Pause
                sqlClient.Databases.Pause(resourceGroup.Name, server.Name, dbName);
                // TODO: Get result and verify that status is now resumed - blocked by https://github.com/Azure/autorest/issues/2295

                // Resume
                sqlClient.Databases.Resume(resourceGroup.Name, server.Name, dbName);
                // TODO: Get result and verify that status is now resumed - blocked by https://github.com/Azure/autorest/issues/2295
            }
        }
    }
}
