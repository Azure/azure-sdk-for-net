// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.Azure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Xunit;

namespace Sql.Tests
{
    public class FailoverGroupCrudScenarioTests
    {
        [Fact]
        public void TestCrudFailoverGroup()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create primary and partner servers
                //
                var sourceServer = context.CreateServer(resourceGroup);
                var targetServer = context.CreateServer(resourceGroup, location: TestEnvironmentUtilities.DefaultSecondaryLocationId);

                // Create a failover group
                //
                string failoverGroupName = SqlManagementTestUtilities.GenerateName();
                var fgInput = new FailoverGroup()
                {
                    ReadOnlyEndpoint = new FailoverGroupReadOnlyEndpoint()
                    {
                        FailoverPolicy = ReadOnlyEndpointFailoverPolicy.Disabled,
                    },
                    ReadWriteEndpoint = new FailoverGroupReadWriteEndpoint()
                    {
                        FailoverPolicy = ReadWriteEndpointFailoverPolicy.Manual,
                    },
                    PartnerServers = new List<PartnerInfo>()
                    {
                        new PartnerInfo() { Id = targetServer.Id },
                    },
                    Databases = new List<string>(),
                };
                var failoverGroup = sqlClient.FailoverGroups.CreateOrUpdate(resourceGroup.Name, sourceServer.Name, failoverGroupName, fgInput);
                SqlManagementTestUtilities.ValidateFailoverGroup(fgInput, failoverGroup, failoverGroupName);

                var failoverGroupOnPartner = sqlClient.FailoverGroups.Get(resourceGroup.Name, targetServer.Name, failoverGroupName);
                Assert.NotNull(failoverGroupOnPartner);

                // Update a few settings
                //
                var fgPatchInput = new FailoverGroupUpdate
                {
                    ReadOnlyEndpoint = new FailoverGroupReadOnlyEndpoint
                    {
                        FailoverPolicy = ReadOnlyEndpointFailoverPolicy.Enabled
                    },
                    ReadWriteEndpoint = new FailoverGroupReadWriteEndpoint
                    {
                        FailoverPolicy = ReadWriteEndpointFailoverPolicy.Automatic,
                        FailoverWithDataLossGracePeriodMinutes = 120
                    },
                    Tags = new Dictionary<string, string> { { "tag1", "value1" } }
                };
                
                var failoverGroupUpdated2 = sqlClient.FailoverGroups.Update(resourceGroup.Name, sourceServer.Name, failoverGroupName, fgPatchInput);

                // Set expectations and verify update
                //
                fgInput.ReadWriteEndpoint = fgPatchInput.ReadWriteEndpoint;
                fgInput.ReadOnlyEndpoint = fgPatchInput.ReadOnlyEndpoint;
                fgInput.Tags = fgPatchInput.Tags;
                SqlManagementTestUtilities.ValidateFailoverGroup(fgInput, failoverGroupUpdated2, failoverGroupName);

                // Create a database in the primary server
                //
                string databaseName = "testdb";
                var dbInput = new Database()
                {
                    Location = sourceServer.Location
                };
                Database database = sqlClient.Databases.CreateOrUpdate(resourceGroup.Name, sourceServer.Name, databaseName, dbInput);
                Assert.NotNull(database);

                // Update failover group to add database and change read-write endpoint's failover policy.
                //
                var fgUpdateInput = new FailoverGroup()
                {
                    ReadOnlyEndpoint = new FailoverGroupReadOnlyEndpoint()
                    {
                        FailoverPolicy = ReadOnlyEndpointFailoverPolicy.Disabled,
                    },
                    ReadWriteEndpoint = new FailoverGroupReadWriteEndpoint()
                    {
                        FailoverPolicy = ReadWriteEndpointFailoverPolicy.Manual,
                    },
                    PartnerServers = new List<PartnerInfo>()
                    {
                        new PartnerInfo() { Id = targetServer.Id },
                    },
                    Databases = new List<string>()
                    {
                        database.Id,
                    },
                };
                failoverGroup = sqlClient.FailoverGroups.CreateOrUpdate(resourceGroup.Name, sourceServer.Name, failoverGroupName, fgUpdateInput);
                SqlManagementTestUtilities.ValidateFailoverGroup(fgUpdateInput, failoverGroup, failoverGroupName);

                // List failover groups on the secondary server and verify
                //
                var failoverGroupsOnSecondary = sqlClient.FailoverGroups.ListByServer(resourceGroup.Name, targetServer.Name);
                Assert.NotNull(failoverGroupsOnSecondary);
                Assert.Equal(1, failoverGroupsOnSecondary.Count());

                var primaryDatabase = sqlClient.Databases.Get(resourceGroup.Name, sourceServer.Name, databaseName);

                // A brief wait may be needed until the secondary database is fully created
                Database secondaryDatabase = new Database();

                SqlManagementTestUtilities.ExecuteWithRetry(() =>
                {
                    secondaryDatabase = sqlClient.Databases.Get(resourceGroup.Name, targetServer.Name, databaseName);
                }, 
                TimeSpan.FromMinutes(2), TimeSpan.FromSeconds(5),
                (CloudException e) => 
                {
                    return e.Response.StatusCode == HttpStatusCode.NotFound;
                });

                Assert.NotNull(primaryDatabase.FailoverGroupId);
                Assert.NotNull(secondaryDatabase.FailoverGroupId);

                // Failover failover group
                //
                failoverGroup = sqlClient.FailoverGroups.Failover(resourceGroup.Name, targetServer.Name, failoverGroupName);

                // Get failover group on the new secondary server and verify its replication role
                //
                var failoverGroupOnSecondary = sqlClient.FailoverGroups.Get(resourceGroup.Name, sourceServer.Name, failoverGroupName);
                Assert.Equal(FailoverGroupReplicationRole.Secondary, failoverGroupOnSecondary.ReplicationRole);
                Assert.Equal(FailoverGroupReplicationRole.Primary, failoverGroupOnSecondary.PartnerServers.First().ReplicationRole);

                // Delete failover group and verify that databases are removed from the failover group
                //
                sqlClient.FailoverGroups.Delete(resourceGroup.Name, targetServer.Name, failoverGroupName);
                primaryDatabase = sqlClient.Databases.Get(resourceGroup.Name, targetServer.Name, databaseName);
                secondaryDatabase = sqlClient.Databases.Get(resourceGroup.Name, sourceServer.Name, databaseName);
                Assert.Null(primaryDatabase.FailoverGroupId);
                Assert.Null(secondaryDatabase.FailoverGroupId);
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.FailoverGroups.Get(resourceGroup.Name, sourceServer.Name, failoverGroupName));
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.FailoverGroups.Get(resourceGroup.Name, targetServer.Name, failoverGroupName));
            }
        }
    }
}
