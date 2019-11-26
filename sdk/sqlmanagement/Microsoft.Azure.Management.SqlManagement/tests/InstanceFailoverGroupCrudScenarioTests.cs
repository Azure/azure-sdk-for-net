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

                // Names of pre-existing ManagedInstances
                string sourceManagedInstanceName = "tdstage-haimb-dont-delete-3";
                string targetManagedInstanceName = "threat-detection-test-1";
                string sourceResourceGroup = "testclrg";
                string targetResourceGroup = "testclrg";

                // Create server 
                var sourceManagedInstance = sqlClient.ManagedInstances.Get(sourceResourceGroup, sourceManagedInstanceName);

                // Create second server
                var targetManagedInstance = sqlClient.ManagedInstances.Get(targetResourceGroup, targetManagedInstanceName);

                // Create database only required parameters
                string mdbName = "database1";
                var mdb1 = sqlClient.ManagedDatabases.CreateOrUpdate(sourceResourceGroup, sourceManagedInstance.Name, mdbName, new ManagedDatabase()
                {
                    Location = sourceManagedInstance.Location,
                });
                Assert.NotNull(mdb1);

                // Create a failover group
                string instanceFailoverGroupName = SqlManagementTestUtilities.GenerateName();
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
                var instanceFailoverGroup = sqlClient.InstanceFailoverGroups.CreateOrUpdate(sourceResourceGroup, sourceManagedInstance.Location, instanceFailoverGroupName, fgInput);
                SqlManagementTestUtilities.ValidateInstanceFailoverGroup(fgInput, instanceFailoverGroup, instanceFailoverGroupName);

                var pePrimaryDatabase = sqlClient.ManagedDatabases.Get(sourceResourceGroup, sourceManagedInstance.Name, mdbName);

                // A brief wait may be needed until the secondary for the pre-existing database is created
                ManagedDatabase peSecondaryDatabase = new ManagedDatabase();

                SqlManagementTestUtilities.ExecuteWithRetry(() =>
                {
                    peSecondaryDatabase = sqlClient.ManagedDatabases.Get(targetResourceGroup, targetManagedInstance.Name, mdbName);
                },
                TimeSpan.FromMinutes(2), TimeSpan.FromSeconds(5),
                (CloudException e) =>
                {
                    return e.Response.StatusCode == HttpStatusCode.NotFound;
                });

                // Update a few settings
                var fgSetInput = new InstanceFailoverGroup()
                {
                    ReadOnlyEndpoint = new InstanceFailoverGroupReadOnlyEndpoint
                    {
                        FailoverPolicy = ReadOnlyEndpointFailoverPolicy.Enabled
                    },
                    ReadWriteEndpoint = new InstanceFailoverGroupReadWriteEndpoint
                    {
                        FailoverPolicy = ReadWriteEndpointFailoverPolicy.Automatic,
                        FailoverWithDataLossGracePeriodMinutes = 120
                    },
                    PartnerRegions = new List<PartnerRegionInfo>(){
                        new PartnerRegionInfo() { Location = instanceFailoverGroup.PartnerRegions.FirstOrDefault().Location },
                    },
                    ManagedInstancePairs = new List<ManagedInstancePairInfo>()
                    {
                        new ManagedInstancePairInfo() { PrimaryManagedInstanceId = instanceFailoverGroup.ManagedInstancePairs.FirstOrDefault().PrimaryManagedInstanceId,
                            PartnerManagedInstanceId = instanceFailoverGroup.ManagedInstancePairs.FirstOrDefault().PartnerManagedInstanceId },
                    },
                };

                var instanceFailoverGroupUpdated2 = sqlClient.InstanceFailoverGroups.CreateOrUpdate(sourceResourceGroup, sourceManagedInstance.Location, instanceFailoverGroupName, fgSetInput);

                // Set expectations and verify update
                fgInput.ReadWriteEndpoint = fgSetInput.ReadWriteEndpoint;
                fgInput.ReadOnlyEndpoint = fgSetInput.ReadOnlyEndpoint;
                SqlManagementTestUtilities.ValidateInstanceFailoverGroup(fgInput, instanceFailoverGroupUpdated2, instanceFailoverGroupName);

                // Failover failover group
                sqlClient.InstanceFailoverGroups.Failover(targetResourceGroup, targetManagedInstance.Location, instanceFailoverGroupName);
                instanceFailoverGroup = sqlClient.InstanceFailoverGroups.Get(targetResourceGroup, targetManagedInstance.Location, instanceFailoverGroupName);

                // Get failover group on the new secondary server and verify its replication role
                Assert.Equal(sourceManagedInstance.Id, instanceFailoverGroup.ManagedInstancePairs.FirstOrDefault().PartnerManagedInstanceId);
                Assert.Equal(targetManagedInstance.Id, instanceFailoverGroup.ManagedInstancePairs.FirstOrDefault().PrimaryManagedInstanceId);

                // Delete failover group
                sqlClient.InstanceFailoverGroups.Delete(targetResourceGroup, targetManagedInstance.Location, instanceFailoverGroupName);
                Assert.Throws<Microsoft.Rest.Azure.CloudException>(() => sqlClient.InstanceFailoverGroups.Get(sourceResourceGroup, sourceManagedInstance.Location, instanceFailoverGroupName));

                //Delete the managed database
                sqlClient.ManagedDatabases.Delete(sourceResourceGroup, sourceManagedInstance.Name, mdbName);
                sqlClient.ManagedDatabases.Delete(targetResourceGroup, targetManagedInstance.Name, mdbName);
            }
        }
    }
}