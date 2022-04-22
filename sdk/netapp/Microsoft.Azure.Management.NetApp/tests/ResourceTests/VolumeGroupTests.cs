using NetApp.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.IO;
using System.Reflection;
using System.Net;
using System.Linq;
using System.Threading;

namespace NetApp.Tests.ResourceTests
{
    public class VolumeGroupTests: TestBase
    {
        private const int delay = 10000;

        [Fact(Skip = "Service side bug not released yet")]        
        public void CreateDeleteVolumeGroup()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                // create a volumeGroup, get all and check
                var createResource = ResourceUtils.CreateVolumeGroup(netAppMgmtClient);
                Assert.NotNull(createResource);
                var poolName = string.Empty;
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(30000);
                }
                var getResource = netAppMgmtClient.VolumeGroups.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.volumeGroupName1);
                Assert.NotNull(createResource);

                //try cleanup of volumes
                foreach (var volumeGroupVolume in getResource.Volumes)
                {
                    poolName = volumeGroupVolume.CapacityPoolResourceId;
                    var volumeName = volumeGroupVolume.Name.Split(@"/").Last();
                    netAppMgmtClient.Volumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, poolName, volumeName);
                }
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                //try cleanup
                netAppMgmtClient.VolumeGroups.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.volumeGroupName1);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                netAppMgmtClient.Pools.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, poolName);
                netAppMgmtClient.Accounts.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1);
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.VolumeGroupTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}
