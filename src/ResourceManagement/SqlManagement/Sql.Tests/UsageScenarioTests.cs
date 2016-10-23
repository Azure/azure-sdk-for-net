using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class UsageScenarioTests
    {
        [Fact]
        public void TestGetUsageData()
        {
            string testPrefix = "sqlcrudtest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestCreate", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Get server metrics
                IEnumerable<ServerMetric> serverMetrics = sqlClient.ServerUsages.ListByServer(resourceGroup.Name, server.Name);
                Assert.True(serverMetrics.Count(s => s.ResourceName == server.Name) > 1);

                // Create a database and get metrics
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);
                IEnumerable<DatabaseMetric> databaseMetrics = sqlClient.DatabaseUsages.ListByDatabase(resourceGroup.Name, server.Name, dbName);
                Assert.True(databaseMetrics.Where(db => db.ResourceName == dbName).Count() == 1);
            });
        }
    }
}
