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
    public class InstanceFailoverGroupCrudScenarioTests
    {
        [Fact]
        public void TestCrudInstanceFailoverGroup()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                //find names of MI on cluster
                string resourceGroup = "testclrg";
                string managedInstanceName = "sqlmi-msfeb18-failovertest-11-bc";
                string managedInstanceName2 = "sqlmi-msfeb18-ppmslightup-10-bc";

                //Get MI
                var sourceManagedInstance = sqlClient.ManagedInstances.Get(resourceGroup, managedInstanceName);

                // Get partner MI                
                var targetManagedInstance = sqlClient.ManagedInstances.Get(resourceGroup, managedInstanceName2);

                // Create database only required parameters
                //
                string mdbName = SqlManagementTestUtilities.GenerateName();
                var mDB = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup, sourceManagedInstance.Name, mdbName, new ManagedDatabase()
                {
                    Location = sourceManagedInstance.Location,
                });
                Assert.NotNull(mDB);
                Assert.Null(mDB.FailoverGroupId);

                // Create a failover group
                //
                string InstanceFailoverGroupName = SqlManagementTestUtilities.GenerateName();
                var fgInput = new InstanceFailoverGroup()
                {
                    ReadOnlyEndpoint = new InstanceFailoverGroupReadOnlyEndpoint()
                    {
                        FailoverPolicy = ReadOnlyEndpointFailoverPolicy.Disabled,
                    },
                    ReadWriteEndpoint = new InstanceFailoverGroupReadWriteEndpoint()
                    {
                        FailoverPolicy = ReadWriteEndpointFailoverPolicy.Manual,
                    },
                    PartnerRegions = new List<PartnerRegionInfo>(){
                        new PartnerRegionInfo() { Location = targetManagedInstance.Location },
                    },
                    ManagedInstancePairs = new List<ManagedInstancePairInfo>()
                    {
                        new ManagedInstancePairInfo() { PrimaryManagedInstanceId = sourceManagedInstance.Id, PartnerManagedInstanceId = targetManagedInstance.Id },
                    },
                };
                var InstanceFailoverGroup = sqlClient.InstanceFailoverGroups.CreateOrUpdate(resourceGroup, sourceManagedInstance.Location, InstanceFailoverGroupName, fgInput);
                SqlManagementTestUtilities.ValidateInstanceFailoverGroup(fgInput, InstanceFailoverGroup, InstanceFailoverGroupName);

                ////var InstanceFailoverGroupOnPartner = sqlClient.InstanceFailoverGroups.Get(resourceGroup, targetManagedInstance.Location, InstanceFailoverGroupName);
                ////Assert.NotNull(InstanceFailoverGroupOnPartner);

                // A brief wait may be needed until the secondary for the pre-existing database is created
                ManagedDatabase mDBsecondary = new ManagedDatabase();

                SqlManagementTestUtilities.ExecuteWithRetry(() =>
                {
                    mDBsecondary = sqlClient.ManagedDatabases.Get(resourceGroup, targetManagedInstance.Name, mdbName);
                },
                TimeSpan.FromMinutes(2), TimeSpan.FromSeconds(5),
                (CloudException e) =>
                {
                    return e.Response.StatusCode == HttpStatusCode.NotFound;
                });
                Assert.NotNull(mDB.FailoverGroupId);
                Assert.NotNull(mDBsecondary.FailoverGroupId);

                // Update a few settings
                //
                var fgPatchInput = new InstanceFailoverGroup()
                {
                    ReadOnlyEndpoint = new InstanceFailoverGroupReadOnlyEndpoint
                    {
                        FailoverPolicy = ReadOnlyEndpointFailoverPolicy.Enabled
                    },
                    ReadWriteEndpoint = new InstanceFailoverGroupReadWriteEndpoint
                    {
                        FailoverPolicy = ReadWriteEndpointFailoverPolicy.Automatic,
                        FailoverWithDataLossGracePeriodMinutes = 120
                    }
                };

                var InstanceFailoverGroupUpdated2 = sqlClient.InstanceFailoverGroups.CreateOrUpdate(resourceGroup, sourceManagedInstance.Location, InstanceFailoverGroupName, fgPatchInput);

                // Set expectations and verify update
                //
                fgInput.ReadWriteEndpoint = fgPatchInput.ReadWriteEndpoint;
                fgInput.ReadOnlyEndpoint = fgPatchInput.ReadOnlyEndpoint;
                SqlManagementTestUtilities.ValidateInstanceFailoverGroup(fgInput, InstanceFailoverGroupUpdated2, InstanceFailoverGroupName);

                ////// Create a database in the primary server
                //////
                ////string databaseName = "testdb";
                ////var dbInput = new ManagedDatabase()
                ////{
                ////    Location = sourceManagedInstance.Location
                ////};
                ////ManagedDatabase database = sqlClient.ManagedDatabases.CreateOrUpdate(resourceGroup, sourceManagedInstance.Location, databaseName, dbInput);
                ////Assert.NotNull(database);

                ////var primaryDatabase = sqlClient.ManagedDatabases.Get(resourceGroup, sourceManagedInstance.Location, databaseName);

                ////// A brief wait may be needed until the secondary database is fully created
                ////ManagedDatabase secondaryDatabase = new ManagedDatabase();

                ////SqlManagementTestUtilities.ExecuteWithRetry(() =>
                ////{
                ////    secondaryDatabase = sqlClient.ManagedDatabases.Get(resourceGroup, targetManagedInstance.Name, databaseName);
                ////},
                ////TimeSpan.FromMinutes(2), TimeSpan.FromSeconds(5),
                ////(CloudException e) =>
                ////{
                ////    return e.Response.StatusCode == HttpStatusCode.NotFound;
                ////});

                ////Assert.NotNull(primaryDatabase.FailoverGroupId);
                ////Assert.NotNull(secondaryDatabase.FailoverGroupId);

                // Failover failover group
                //
                InstanceFailoverGroup = sqlClient.InstanceFailoverGroups.Failover(resourceGroup, targetManagedInstance.Name, InstanceFailoverGroupName);

                // Get failover group on the new secondary server and verify its replication role
                //
                var InstanceFailoverGroupOnSecondary = sqlClient.InstanceFailoverGroups.Get(resourceGroup, sourceManagedInstance.Location, InstanceFailoverGroupName);
                Assert.Equal(InstanceFailoverGroupReplicationRole.Secondary, InstanceFailoverGroupOnSecondary.ReplicationRole);
                Assert.Equal(InstanceFailoverGroupReplicationRole.Primary, InstanceFailoverGroupOnSecondary.PartnerRegions.FirstOrDefault().ReplicationRole);
                Assert.Equal(targetManagedInstance.Id, InstanceFailoverGroupOnSecondary.ManagedInstancePairs.FirstOrDefault().PrimaryManagedInstanceId);
                Assert.Equal(sourceManagedInstance.Id, InstanceFailoverGroupOnSecondary.ManagedInstancePairs.FirstOrDefault().PartnerManagedInstanceId);

                // Delete failover group and verify that databases are removed from the failover group
                //
                sqlClient.InstanceFailoverGroups.Delete(resourceGroup, targetManagedInstance.Name, InstanceFailoverGroupName);
                Assert.Null(mDB.FailoverGroupId);
                Assert.Null(mDBsecondary.FailoverGroupId);
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.InstanceFailoverGroups.Get(resourceGroup, sourceManagedInstance.Location, InstanceFailoverGroupName));
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.InstanceFailoverGroups.Get(resourceGroup, targetManagedInstance.Name, InstanceFailoverGroupName));

                sqlClient.ManagedDatabases.Delete(resourceGroup, sourceManagedInstance.Name, mdbName);
                sqlClient.ManagedDatabases.Delete(resourceGroup, targetManagedInstance.Name, mdbName);
            }
        }
    }
}