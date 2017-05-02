// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class FailoverGroupCrudScenarioTests
    {
        public static string DefaultPrimaryLocation
        {
            get
            {
                return "North Europe";
            }
        }

        public static string DefaultSecondaryLocation
        {
            get
            {
                return "SouthEast Asia";
            }
        }

        private Server CreateServer(SqlManagementClient sqlClient, ResourceGroup resourceGroup, string serverPrefix, string location)
        {
            string login = "dummylogin";
            string password = "Un53cuRE!";
            string version12 = "12.0";
            string serverName = SqlManagementTestUtilities.GenerateName(serverPrefix);
            Dictionary<string, string> tags = new Dictionary<string, string>();

            var v12Server = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, serverName, new Microsoft.Azure.Management.Sql.Models.Server()
            {
                AdministratorLogin = login,
                AdministratorLoginPassword = password,
                Version = version12,
                Tags = tags,
                Location = location,
            });
            SqlManagementTestUtilities.ValidateServer(v12Server, serverName, login, version12, tags, location);
            return v12Server;
        }

        [Fact]
        public void TestCreateDeleteFailoverGroup()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewResourceGroup(suiteName, "TestCreateDeleteFailoverGroup", testPrefix, (resClient, sqlClient, resourceGroup) =>
            {
                // Create primary and partner servers
                //
                Server primaryServer = CreateServer(sqlClient, resourceGroup, testPrefix, DefaultPrimaryLocation);
                Server partnerServer = CreateServer(sqlClient, resourceGroup, testPrefix, DefaultSecondaryLocation);

                // Create a failover group
                //
                string failoverGroupName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var fgInput = new FailoverGroup()
                {
                    ReadOnlyEndpoint = new FailoverGroupReadOnlyEndpoint()
                    {
                        FailoverPolicy = "Disabled",
                    },
                    ReadWriteEndpoint = new FailoverGroupReadWriteEndpoint()
                    {
                        FailoverPolicy = "Automatic",
                        FailoverWithDataLossGracePeriodMinutes = 120,
                    },
                    PartnerServers = new List<PartnerInfo>()
                    {
                        new PartnerInfo() { Id = partnerServer.Id },
                    },
                    Databases = new List<string>(),
                };
                var failoverGroup = sqlClient.FailoverGroups.CreateOrUpdate(resourceGroup.Name, primaryServer.Name, failoverGroupName, fgInput);
                SqlManagementTestUtilities.ValidateFailoverGroup(fgInput, failoverGroup, failoverGroupName);

                var failoverGroupOnPartner = sqlClient.FailoverGroups.Get(resourceGroup.Name, partnerServer.Name, failoverGroupName);
                Assert.NotNull(failoverGroupOnPartner);

                // Delete failover group and verify
                //
                sqlClient.FailoverGroups.Delete(resourceGroup.Name, primaryServer.Name, failoverGroupName);
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.FailoverGroups.Get(resourceGroup.Name, primaryServer.Name, failoverGroupName));
            });
        }

        [Fact]
        public void TestUpdateFailoverGroup()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewResourceGroup(suiteName, "TestUpdateFailoverGroup", testPrefix, (resClient, sqlClient, resourceGroup) =>
            {
                // Create primary and partner servers
                //
                Server primaryServer = CreateServer(sqlClient, resourceGroup, testPrefix, DefaultPrimaryLocation);
                Server partnerServer = CreateServer(sqlClient, resourceGroup, testPrefix, DefaultSecondaryLocation);

                // Create a failover group
                //
                string failoverGroupName = SqlManagementTestUtilities.GenerateName(testPrefix);
                var fgInput = new FailoverGroup()
                {
                    ReadOnlyEndpoint = new FailoverGroupReadOnlyEndpoint()
                    {
                        FailoverPolicy = "Disabled",
                    },
                    ReadWriteEndpoint = new FailoverGroupReadWriteEndpoint()
                    {
                        FailoverPolicy = "Automatic",
                        FailoverWithDataLossGracePeriodMinutes = 120,
                    },
                    PartnerServers = new List<PartnerInfo>()
                    {
                        new PartnerInfo() { Id = partnerServer.Id },
                    },
                    Databases = new List<string>(),
                };
                var failoverGroup = sqlClient.FailoverGroups.CreateOrUpdate(resourceGroup.Name, primaryServer.Name, failoverGroupName, fgInput);
                SqlManagementTestUtilities.ValidateFailoverGroup(fgInput, failoverGroup, failoverGroupName);

                // Create a database in the primary server
                //
                string databaseName = "testdb";
                var dbInput = new Database()
                {
                    Location = primaryServer.Location
                };
                Database database = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, primaryServer.Name, databaseName, dbInput);

                // Update failover group to add database and change Read-write failover policy.
                //
                var fgUpdateInput = new FailoverGroup()
                {
                    ReadOnlyEndpoint = new FailoverGroupReadOnlyEndpoint()
                    {
                        FailoverPolicy = "Disabled",
                    },
                    ReadWriteEndpoint = new FailoverGroupReadWriteEndpoint()
                    {
                        FailoverPolicy = "Manual",
                    },
                    PartnerServers = new List<PartnerInfo>()
                    {
                        new PartnerInfo() { Id = partnerServer.Id },
                    },
                    Databases = new List<string>()
                    {
                        database.Id,
                    },
                };
                failoverGroup = sqlClient.FailoverGroups.CreateOrUpdate(resourceGroup.Name, primaryServer.Name, failoverGroupName, fgUpdateInput);
                SqlManagementTestUtilities.ValidateFailoverGroup(fgUpdateInput, failoverGroup, failoverGroupName);

                var sourceDatabase = sqlClient.Databases.Get(resourceGroup.Name, primaryServer.Name, databaseName);
                var targetDatabase = sqlClient.Databases.Get(resourceGroup.Name, partnerServer.Name, databaseName);
                Assert.NotNull(sourceDatabase.FailoverGroupId);
                Assert.NotNull(targetDatabase.FailoverGroupId);

                // Delete failover group and verify that databases are removed from failover group
                //
                sqlClient.FailoverGroups.Delete(resourceGroup.Name, primaryServer.Name, failoverGroupName);
                sourceDatabase = sqlClient.Databases.Get(resourceGroup.Name, primaryServer.Name, databaseName);
                targetDatabase = sqlClient.Databases.Get(resourceGroup.Name, partnerServer.Name, databaseName);
                Assert.Null(sourceDatabase.FailoverGroupId);
                Assert.Null(targetDatabase.FailoverGroupId);
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.FailoverGroups.Get(resourceGroup.Name, primaryServer.Name, failoverGroupName));
            });
        }
    }
}
