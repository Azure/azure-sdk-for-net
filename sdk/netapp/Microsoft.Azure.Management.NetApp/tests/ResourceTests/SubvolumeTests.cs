using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.Resources;
using NetApp.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using System.Net;
using System.IO;
using System.Reflection;

namespace NetApp.Tests.ResourceTests
{
    public class SubvolumeTests : TestBase
    {
        [Fact]
        public void CreateDeleteSubvolume()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create a volume, get all and check
                var resource = ResourceUtils.CreateVolume(netAppMgmtClient, enableSubvolumes: EnableSubvolumes.Enabled);
                //Assert.Equal(ResourceUtils.defaultExportPolicy.ToString(), resource.ExportPolicy.ToString());
                //Assert.Null(resource.Tags);
                // check DP properties exist but unassigned because
                // dataprotection volume was not created
                Assert.Null(resource.VolumeType);
                Assert.Null(resource.DataProtection);

                var volumesBefore = netAppMgmtClient.Volumes.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);
                Assert.Single(volumesBefore);

                SubvolumeInfo subvolumeInfo = new SubvolumeInfo();
                subvolumeInfo.Path = "/subvolume1";
                subvolumeInfo.Size = 5;

                // create subvolume
                var subvol = netAppMgmtClient.Subvolumes.Create(subvolumeInfo, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume1");
                var getSubvolume = netAppMgmtClient.Subvolumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume1");
                Assert.NotNull(getSubvolume);

                // cleanup
                netAppMgmtClient.Subvolumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume1");
                netAppMgmtClient.Volumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }
        [Fact]
        public void ListSubvolumes()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create a volume, get all and check
                var resource = ResourceUtils.CreateVolume(netAppMgmtClient, enableSubvolumes: EnableSubvolumes.Enabled);
                //Assert.Equal(ResourceUtils.defaultExportPolicy.ToString(), resource.ExportPolicy.ToString());
                //Assert.Null(resource.Tags);
                // check DP properties exist but unassigned because
                // dataprotection volume was not created
                Assert.Null(resource.VolumeType);
                Assert.Null(resource.DataProtection);

                var volumesBefore = netAppMgmtClient.Volumes.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);
                Assert.Single(volumesBefore);
                
                // create subvolume
                SubvolumeInfo subvolumeInfo = new SubvolumeInfo();
                subvolumeInfo.Path = "/subvolume1";
                subvolumeInfo.Size = 5;
                                
                var subvol = netAppMgmtClient.Subvolumes.Create(subvolumeInfo, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume1");
                Assert.NotNull(subvol);
                var getSubVolume = netAppMgmtClient.Subvolumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume1");
                Assert.NotNull(getSubVolume);

                // List subvolumes
                var getSubVolumesList = netAppMgmtClient.Subvolumes.ListByVolume(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.NotNull(getSubVolumesList);
                Assert.Single(getSubVolumesList);

                // create subvolume2
                SubvolumeInfo subvolumeInfo2 = new SubvolumeInfo();
                subvolumeInfo2.Path = "/subvolume2";
                subvolumeInfo2.Size = 5;

                var subvol2 = netAppMgmtClient.Subvolumes.Create(subvolumeInfo2, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume2");
                Assert.NotNull(subvol2);
                var getSubVolume2 = netAppMgmtClient.Subvolumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume2");
                Assert.NotNull(getSubVolume2);
                
                // List subvolumes
                getSubVolumesList = netAppMgmtClient.Subvolumes.ListByVolume(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.NotNull(getSubVolumesList);
                Assert.Equal(2, getSubVolumesList.Count());

                // cleanup
                netAppMgmtClient.Subvolumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume2");
                netAppMgmtClient.Subvolumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume1");                
                netAppMgmtClient.Volumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void GetMetadata()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create a volume, get all and check
                var resource = ResourceUtils.CreateVolume(netAppMgmtClient, enableSubvolumes: EnableSubvolumes.Enabled);
                //Assert.Equal(ResourceUtils.defaultExportPolicy.ToString(), resource.ExportPolicy.ToString());
                //Assert.Null(resource.Tags);
                // check DP properties exist but unassigned because
                // dataprotection volume was not created
                Assert.Null(resource.VolumeType);
                Assert.Null(resource.DataProtection);

                var volumesBefore = netAppMgmtClient.Volumes.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);
                Assert.Single(volumesBefore);

                SubvolumeInfo subvolumeInfo = new SubvolumeInfo();
                subvolumeInfo.Path = "/subvolume1";
                subvolumeInfo.Size = 5;

                // create subvolume
                var subvol = netAppMgmtClient.Subvolumes.Create(subvolumeInfo, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume1");
                Assert.NotNull(subvol);
                var getSubVolume = netAppMgmtClient.Subvolumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume1");
                Assert.NotNull(getSubVolume);

                var getSubVolumeMetaData = netAppMgmtClient.Subvolumes.GetMetadata(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume1");
                Assert.NotNull(getSubVolumeMetaData);

                // cleanup
                netAppMgmtClient.Subvolumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, "subvolume1");
                netAppMgmtClient.Volumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }
        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.SubvolumeTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }

    }
}
