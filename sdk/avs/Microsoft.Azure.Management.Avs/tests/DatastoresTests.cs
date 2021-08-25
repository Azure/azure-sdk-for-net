// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Avs;
using Microsoft.Azure.Management.Avs.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Avs.Tests
{
    public class DatastoresTests : TestBase
    {
        [Fact]
        public void DatastoresAll()
        {
            using var context = MockContext.Start(this.GetType());
            string rgName = "mock-avs-fct-dogfood-conveyor-eastus";
            string cloudName = "fct-mock-eastus-15";
            string clusterName = "Cluster-1";

            using var avsClient = context.GetServiceClient<AvsClient>();

            var datastoreName = "fct-mock-datastore-1";
            var datastore = avsClient.Datastores.CreateOrUpdate(rgName, cloudName, clusterName, datastoreName, new Datastore {
                DiskPoolVolume = new DiskPoolVolume {
                    TargetId = "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/resourceGroupName/providers/Microsoft.StoragePool/diskPools/diskPoolName/iscsiTargets/targetName",
                    LunName = "mock-lun-name",
                    MountOption = "MOUNT"
                }
            });

            avsClient.Datastores.List(rgName, cloudName, clusterName);

            avsClient.Datastores.Get(rgName, cloudName, clusterName, datastoreName);

            avsClient.Datastores.Delete(rgName, cloudName, clusterName, datastoreName);
        }
    }
}