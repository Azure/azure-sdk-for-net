using NetApp.Tests.Helpers;
using Microsoft.Azure.Management.NetApp.Models;
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

namespace NetApp.Tests.ResourceTests
{
    public class VolumeTests : TestBase
    {
        [Fact]
        public void CreateDeleteVolume()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create a volume, get all and check
                ResourceUtils.CreateVolume(netAppMgmtClient);
                var volumesBefore = netAppMgmtClient.Volumes.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);
                Assert.Single(volumesBefore);

                // delete the volume and check again
                netAppMgmtClient.Volumes.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                var volumesAfter = netAppMgmtClient.Volumes.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);
                Assert.Empty(volumesAfter);

                // cleanup
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void ListVolumes()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create two volumes under same pool
                ResourceUtils.CreateVolume(netAppMgmtClient);
                ResourceUtils.CreateVolume(netAppMgmtClient, ResourceUtils.volumeName2, volumeOnly: true);

                // get the account list and check
                var volumes = netAppMgmtClient.Volumes.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);
                Assert.Equal(volumes.ElementAt(0).Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1);
                Assert.Equal(volumes.ElementAt(1).Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName2);
                Assert.Equal(2, volumes.Count());

                // clean up - delete the two volumes, the pool and the account
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeleteVolume(netAppMgmtClient, ResourceUtils.volumeName2);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void GetVolumeByName()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the volume
                ResourceUtils.CreateVolume(netAppMgmtClient);

                // retrieve it
                var volume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Equal(volume.Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1);

                // clean up - delete the volume, pool and account
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void GetVolumeByNameNotFound()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create volume
                ResourceUtils.CreatePool(netAppMgmtClient);

                // try and get a volume in the pool - none have been created yet
                try
                {
                    var volume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                    Assert.True(false); // expecting exception
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }

                // cleanup
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void GetVolumeByNamePoolNotFound()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                ResourceUtils.CreateAccount(netAppMgmtClient);

                // try and create a volume before the pool exist
                try
                {
                    var volume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                    Assert.True(false); // expecting exception
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }

                // cleanup - remove the account
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void CreateVolumePoolNotFound()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                ResourceUtils.CreateAccount(netAppMgmtClient);

                // try and create a volume before the pool exist
                try
                {
                    ResourceUtils.CreateVolume(netAppMgmtClient, volumeOnly: true);
                    Assert.True(false); // expecting exception
                }
                catch (Exception ex)
                {
                    Assert.Contains("NotFound", ex.Message);
                }

                // cleanup - remove the account
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void DeletePoolWithVolumePresent()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the account and pool
                ResourceUtils.CreateVolume(netAppMgmtClient);

                var poolsBefore = netAppMgmtClient.Pools.List(ResourceUtils.resourceGroup, ResourceUtils.accountName1);
                Assert.Single(poolsBefore);

                // try and delete the pool
                try
                {
                    netAppMgmtClient.Pools.Delete(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1);
                    Assert.True(false); // expecting exception
                }
                catch (Exception ex)
                {
                    Assert.Contains("Conflict", ex.Message);
                }

                // clean up
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void UpdateVolume()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the volume
                var volume = ResourceUtils.CreateVolume(netAppMgmtClient);
                Assert.Equal("Premium", volume.ServiceLevel);
                //Assert.Equal(100 * ResourceUtils.gibibyte, volume.UsageThreshold);

                // update
                volume.ServiceLevel = "Standard";
                //volume.UsageThreshold = 100 * ResourceUtils.gibibyte * 2;
                var updatedVolume = netAppMgmtClient.Volumes.CreateOrUpdate(volume, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Equal("Standard", updatedVolume.ServiceLevel);
                //Assert.Equal(100 * ResourceUtils.gibibyte * 2, updatedVolume.UsageThreshold);

                // cleanup
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }
        
        [Fact]
        public void PatchVolume()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                
                // create the volume
                var volume = ResourceUtils.CreateVolume(netAppMgmtClient);
                Assert.Equal("Premium", volume.ServiceLevel);

                // Now try and modify it
                var volumePatch = new VolumePatch()
                {
                    ServiceLevel = "Standard"
                };

                // patch
                var updatedVolume = netAppMgmtClient.Volumes.Update(volumePatch, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Equal("Standard", updatedVolume.ServiceLevel);

                // cleanup
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.VolumeTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}
