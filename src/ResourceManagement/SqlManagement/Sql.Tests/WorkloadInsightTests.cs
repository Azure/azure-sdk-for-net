using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class WorkloadInsightTests
    {
        [Fact]
        public void TestGetServiceTierAdvisors()
        {
            string testPrefix = "sqlstatest-";
            string testName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewV12Server(testName, "TestGetServiceTierAdvisors", testPrefix, (resClient, sqlClient, resourceGroup, server) =>
            {
                // Create a database.
                string dbName = SqlManagementTestUtilities.GenerateName();
                var dbInput = new Database()
                {
                    Location = server.Location
                };
                sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, server.Name, dbName, dbInput);

                // Get the ServiceTierAdvisor list and verify that the list is not empty.
                IEnumerable<ServiceTierAdvisor> staList = sqlClient.Databases.ListServiceTierAdvisors(resourceGroup.Name, server.Name, dbName);
                Assert.True(staList.Count() > 0);
            });
        }
    }
}
