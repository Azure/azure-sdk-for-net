using NetApp.Tests.Helpers;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using Xunit;
using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.NetApp.Models;

namespace NetApp.Tests.ResourceTests
{
    public class SnapshotTests : TestBase
    {
        [Fact]
        public void CreateDeleteSnapshot()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the snapshot
                ResourceUtils.CreateSnapshot(netAppMgmtClient);

                // check snapshot exists
                var snapshotsBefore = netAppMgmtClient.Snapshots.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Single(snapshotsBefore);

                // delete the pool and check again
                netAppMgmtClient.Snapshots.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.snapshotName1);
                var snapshotsAfter = netAppMgmtClient.Snapshots.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Empty(snapshotsAfter);

                // cleanup - remove the account
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void ListSnapshots()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create two snapshots under same account
                ResourceUtils.CreateSnapshot(netAppMgmtClient);
                ResourceUtils.CreateSnapshot(netAppMgmtClient, ResourceUtils.snapshotName2, snapshotOnly: true);

                // get the account list and check
                var snapshots = netAppMgmtClient.Snapshots.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Equal(snapshots.ElementAt(0).Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1 + '/' + ResourceUtils.snapshotName1);
                Assert.Equal(snapshots.ElementAt(1).Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1 + '/' + ResourceUtils.snapshotName2);
                Assert.Equal(2, snapshots.Count());

                // clean up
                ResourceUtils.DeleteSnapshot(netAppMgmtClient, ResourceUtils.snapshotName2);
                ResourceUtils.DeleteSnapshot(netAppMgmtClient);
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void GetSnapshotByName()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the account and pool
                ResourceUtils.CreateSnapshot(netAppMgmtClient);

                // get and check the pool
                var snapshot = netAppMgmtClient.Snapshots.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.snapshotName1);
                Assert.Equal(snapshot.Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1 + '/' + ResourceUtils.snapshotName1);

                // clean up
                ResourceUtils.DeleteSnapshot(netAppMgmtClient);
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void DeleteVolumeWithSnapshotPresent()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the account and pool
                ResourceUtils.CreateSnapshot(netAppMgmtClient);

                // try and delete the account
                try
                {
                    netAppMgmtClient.Volumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                    Assert.True(false); // expecting exception
                }
                catch (Exception ex)
                {
                    Assert.Contains("Conflict", ex.Message);
                }

                // clean up
                ResourceUtils.DeleteSnapshot(netAppMgmtClient);
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void PatchSnapshot()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the account
                ResourceUtils.CreateSnapshot(netAppMgmtClient);

                var dict = new Dictionary<string, string>();
                dict.Add("Tag1", "Value1");

                // Now try and modify it
                var snapshotPatch = new SnapshotPatch()
                {
                    Tags = dict
                };

                var resource = netAppMgmtClient.Snapshots.Update(snapshotPatch, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.snapshotName1);
                Assert.True(resource.Tags.ToString().Contains("Tag1") && resource.Tags.ToString().Contains("Value1"));

                // cleanup - remove the account
                ResourceUtils.DeleteSnapshot(netAppMgmtClient);
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }
        
        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.SnapshotTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}
