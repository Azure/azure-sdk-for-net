using NetApp.Tests.Helpers;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Net;
using System.Reflection;
using Xunit;
using System;
using System.Threading;
using Microsoft.Azure.Management.NetApp.Models;

namespace NetApp.Tests.ResourceTests
{
    public class MountTargetTests : TestBase
    {
        private const int delay = 5000;
        [Fact]
        public void ListMountTargets()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create two volumes under same pool
                ResourceUtils.CreateVolume(netAppMgmtClient, resourceGroup: ResourceUtils.resourceGroup, accountName: ResourceUtils.accountName1, poolName: ResourceUtils.poolName1, volumeName: ResourceUtils.volumeName1);

                // get the account list and check
                var volume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Single(volume.MountTargets);
                
                // clean up - delete the volumes, pool and account
                netAppMgmtClient.Volumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(10000);
                }
                WaitForVolumesDeleted(netAppMgmtClient, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);
                netAppMgmtClient.Pools.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);

                WaitForPoolsDeleted(netAppMgmtClient, ResourceUtils.resourceGroup, ResourceUtils.accountName1);                
                netAppMgmtClient.Accounts.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1);
            }
        }

        private void WaitForVolumesDeleted(AzureNetAppFilesManagementClient netAppMgmtClient, string resourceGroup = ResourceUtils.resourceGroup, string accountName = ResourceUtils.accountName1, string poolName = ResourceUtils.poolName1)
        {
            int count = 0;
            do
            {
                var volumes = netAppMgmtClient.Volumes.List(resourceGroup, accountName, poolName);
                var volumesList = ListNextLink<Volume>.GetAllResourcesByPollingNextLink(volumes, netAppMgmtClient.Volumes.ListNext);
                count = volumesList.Count;
                Thread.Sleep(5);
            } while (count > 0);
        }

        private void WaitForPoolsDeleted(AzureNetAppFilesManagementClient netAppMgmtClient, string resourceGroup = ResourceUtils.resourceGroup, string accountName = ResourceUtils.accountName1)
        {
            int count = 0;
            do
            {
                var pools = netAppMgmtClient.Pools.List(resourceGroup, accountName);
                var poolList = ListNextLink<CapacityPool>.GetAllResourcesByPollingNextLink(pools, netAppMgmtClient.Pools.ListNext);
                count = poolList.Count;
                Thread.Sleep(5);
            } while (count > 0);
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.MountTargetTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}
