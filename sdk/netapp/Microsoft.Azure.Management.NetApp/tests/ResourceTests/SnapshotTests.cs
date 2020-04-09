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
using Microsoft.Rest.Azure;

namespace NetApp.Tests.ResourceTests
{
    public class SnapshotTests : TestBase
    {
        [Fact]
        public void CreateDeleteSnapshot()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the snapshot
                ResourceUtils.CreateSnapshot(netAppMgmtClient);

                // check snapshot exists
                var snapshotsBefore = netAppMgmtClient.Snapshots.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Single(snapshotsBefore);
                // check date created has been set to something
                // can't check exact times becausefails in playback mode
                Assert.True(true);
                Assert.NotNull(snapshotsBefore.First().Created);

                // delete the snapshot and check again
                netAppMgmtClient.Snapshots.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.snapshotName1);
                var snapshotsAfter = netAppMgmtClient.Snapshots.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Empty(snapshotsAfter);

                // cleanup - remove the resources
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void ListSnapshots()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create two snapshots under same account
                ResourceUtils.CreateSnapshot(netAppMgmtClient);
                ResourceUtils.CreateSnapshot(netAppMgmtClient, ResourceUtils.snapshotName2, snapshotOnly: true);

                // get the volume list and check
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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the snapshot
                ResourceUtils.CreateSnapshot(netAppMgmtClient);

                // get and check the snapshot
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
        public void CreateVolumeFromSnapshot()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the snapshot
                ResourceUtils.CreateSnapshot(netAppMgmtClient);

                // get and check the snapshot
                var snapshot = netAppMgmtClient.Snapshots.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.snapshotName1);
                ResourceUtils.CreateVolume(netAppMgmtClient, ResourceUtils.volumeName2, volumeOnly: true, snapshotId: snapshot.SnapshotId);
                // name assertion is performed in the volume create

                // clean up
                ResourceUtils.DeleteSnapshot(netAppMgmtClient);
                ResourceUtils.DeleteVolume(netAppMgmtClient, ResourceUtils.volumeName2);
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        /*
         * the RP functionality is not stable enough for this test as it stands
         * commenting out for now
        [Fact]
        public void DeleteVolumeWithSnapshotPresent()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the snapshot
                ResourceUtils.CreateSnapshot(netAppMgmtClient);

                // try and delete the volume
                try
                {
                    netAppMgmtClient.Volumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                    Assert.True(true);
                }
                catch (Exception)
                {
                    // not expecting exception with the Delete
                    // it should work even though there were nested snapshots
                    Assert.True(false);
                }

                // clean up
                ResourceUtils.DeleteSnapshot(netAppMgmtClient);
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }
        */

        [Fact]
        public void PatchSnapshot()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the snapshot
                ResourceUtils.CreateSnapshot(netAppMgmtClient);

                var dict = new Dictionary<string, string>();
                dict.Add("Tag1", "Value1");

                // Now try and modify it
                //SnapshotPatch object was removed and not supported 
                var snapshotPatch = new object();
                var exception = Record.Exception(() => netAppMgmtClient.Snapshots.Update(snapshotPatch, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.snapshotName1));
                Assert.NotNull(exception);
                Assert.IsType<CloudException>(exception);
                Assert.Contains("Patch operation is not supported", exception.Message);

                // cleanup
                ResourceUtils.DeleteSnapshot(netAppMgmtClient);
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void RevertVolumeToSnapshot()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the snapshot
                ResourceUtils.CreateSnapshot(netAppMgmtClient);

                // get and check the snapshot
                var snapshot = netAppMgmtClient.Snapshots.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.snapshotName1);
                Assert.Equal(snapshot.Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1 + '/' + ResourceUtils.snapshotName1);

                // create the second snapshot
                ResourceUtils.CreateSnapshot(netAppMgmtClient,volumeName:ResourceUtils.volumeName1, snapshotName: ResourceUtils.snapshotName2);

                var snapshot2 = netAppMgmtClient.Snapshots.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, ResourceUtils.snapshotName2);
                Assert.Equal(snapshot2.Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1 + '/' + ResourceUtils.snapshotName2);

                var volume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                var snapshotsBefore = netAppMgmtClient.Snapshots.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Equal(2, snapshotsBefore.Count());
                //Revert the volume
                netAppMgmtClient.Volumes.Revert(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, new VolumeRevert(snapshot2.SnapshotId));
                
                var snapshotsAfter = netAppMgmtClient.Snapshots.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Equal(ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1, volume.Name);
                
                // clean up
                foreach (var snap in snapshotsAfter)
                {
                    var snapName = snap.Name.Substring(snap.Name.LastIndexOf('/') + 1);
                    ResourceUtils.DeleteSnapshot(netAppMgmtClient, snapName);
                }
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
