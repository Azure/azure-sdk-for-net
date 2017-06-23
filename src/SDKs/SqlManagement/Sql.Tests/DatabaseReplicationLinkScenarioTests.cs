﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class DatabaseReplicationLinkScenarioTests
    {
        [Fact]
        public void TestCreateDeleteReplicationLinks()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewResourceGroup(suiteName, "TestCreateDeleteReplicationLinks", testPrefix, (resClient, sqlClient, resourceGroup) =>
            {
                string databaseName = "testdb";
                Dictionary<string, string> tags = new Dictionary<string, string>();

                //Create a server and a database
                var v12Server = SqlManagementTestUtilities.CreateServer(sqlClient, resourceGroup, testPrefix);

                var dbInput = new Database()
                {
                    Location = v12Server.Location
                };
                var database = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, v12Server.Name, databaseName, dbInput);

                // Create another server
                var v12Server2 = SqlManagementTestUtilities.CreateServer(sqlClient, resourceGroup, testPrefix);

                // Create another database as an online secondary of the first database
                var dbInput2 = new Database()
                {
                    Location = v12Server2.Location,
                    CreateMode = CreateMode.OnlineSecondary,
                    SourceDatabaseId = database.Id
                };
                var database2 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, v12Server2.Name, databaseName, dbInput2);

                // Get replication link name
                var replicationLinks = sqlClient.Databases.ListReplicationLinks(resourceGroup.Name, v12Server2.Name, databaseName);
                string replicationLinkId = replicationLinks.First().Name;
                
                // Delete replication link and verify that no more links are returned
                sqlClient.Databases.DeleteReplicationLink(resourceGroup.Name, v12Server2.Name, databaseName, replicationLinkId); replicationLinks = sqlClient.Databases.ListReplicationLinks(resourceGroup.Name, v12Server2.Name, databaseName);
                replicationLinks = sqlClient.Databases.ListReplicationLinks(resourceGroup.Name, v12Server2.Name, databaseName);
                Assert.True(replicationLinks.Count() == 0);
            });
        }

        [Fact]
        public void TestGetListFailoverReplicationLink()
        {
            string testPrefix = "sqlcrudtest-";
            string suiteName = this.GetType().FullName;
            SqlManagementTestUtilities.RunTestInNewResourceGroup(suiteName, "TestGetListFailoverReplicationLink", testPrefix, (resClient, sqlClient, resourceGroup) =>
            {
                string databaseName = "testdb";
                Dictionary<string, string> tags = new Dictionary<string, string>();

                //Create a server and a database
                var v12Server = SqlManagementTestUtilities.CreateServer(sqlClient, resourceGroup, testPrefix);

                var dbInput = new Database()
                {
                    Location = v12Server.Location
                };
                var database = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, v12Server.Name, databaseName, dbInput);

                // Create another server
                var v12Server2 = SqlManagementTestUtilities.CreateServer(sqlClient, resourceGroup, testPrefix);

                // Create another database as an online secondary of the first database
                var dbInput2 = new Database()
                {
                    Location = v12Server2.Location,
                    CreateMode = CreateMode.OnlineSecondary,
                    SourceDatabaseId = database.Id
                };
                var database2 = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, v12Server2.Name, databaseName, dbInput2);

                // Verify there is one Link, get replication link id
                var replicationLinks = sqlClient.Databases.ListReplicationLinks(resourceGroup.Name, v12Server2.Name, databaseName);
                Assert.True(replicationLinks.Count() == 1);
                string replicationLinkId = replicationLinks.First().Name;

                // Verify Get replication link
                var replicationLink = sqlClient.Databases.GetReplicationLink(resourceGroup.Name, v12Server2.Name, databaseName, replicationLinkId);

                // Verify that the second database has a replicationLink to the first, with the first being the primary and the second being the secondary
                Assert.True(replicationLink.PartnerServer == v12Server.Name);
                Assert.True(replicationLink.PartnerDatabase == databaseName);
                Assert.True(replicationLink.PartnerRole == ReplicationRole.Primary);
                Assert.True(replicationLink.Role == ReplicationRole.Secondary);

                // Failover Replication Link
                sqlClient.Databases.FailoverReplicationLink(resourceGroup.Name, v12Server2.Name, databaseName, replicationLinkId);

                // Verify Replication Link after Failover
                replicationLink = sqlClient.Databases.GetReplicationLink(resourceGroup.Name, v12Server2.Name, databaseName, replicationLinkId);

                // Verify that Primary and Secondary have switched
                Assert.True(replicationLink.PartnerRole == ReplicationRole.Secondary);
                Assert.True(replicationLink.Role == ReplicationRole.Primary);
            });
        }
    }
}
