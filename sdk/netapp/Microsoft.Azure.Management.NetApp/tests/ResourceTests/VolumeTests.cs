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
using System.Collections.Generic;

namespace NetApp.Tests.ResourceTests
{
    public class VolumeTests : TestBase
    {
        public static ExportPolicyRule exportPolicyRule = new ExportPolicyRule()
        {
            RuleIndex = 1,
            UnixReadOnly = false,
            UnixReadWrite = true,
            Cifs = false,
            Nfsv3 = true,
            Nfsv41 = false,
            AllowedClients = "1.2.3.0/24"
        };

        public static IList<ExportPolicyRule> exportPolicyRuleList = new List<ExportPolicyRule>()
        {
            exportPolicyRule
        };

        public static VolumePropertiesExportPolicy exportPolicy = new VolumePropertiesExportPolicy()
        {
            Rules = exportPolicyRuleList
        };

        public static VolumePatchPropertiesExportPolicy exportPatchPolicy = new VolumePatchPropertiesExportPolicy()
        {
            Rules = exportPolicyRuleList
        };

        [Fact]
        public void CreateDeleteVolume()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create a volume, get all and check
                var resource = ResourceUtils.CreateVolume(netAppMgmtClient);
                Assert.Equal(ResourceUtils.defaultExportPolicy.ToString(), resource.ExportPolicy.ToString());
                Assert.Null(resource.Tags);

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
        public void CreateVolumeWithProperties()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create a volume with tags and export policy
                var dict = new Dictionary<string, string>();
                dict.Add("Tag2", "Value2");
                var  protocolTypes = new List<string>() { "NFSv3", "NFSv4.1" };

                var resource = ResourceUtils.CreateVolume(netAppMgmtClient, protocolTypes: protocolTypes,  tags: dict, exportPolicy: exportPolicy);
                Assert.Equal(exportPolicy.ToString(), resource.ExportPolicy.ToString());
                Assert.Equal(protocolTypes, resource.ProtocolTypes);
                Assert.True(resource.Tags.ToString().Contains("Tag2") && resource.Tags.ToString().Contains("Value2"));

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
            using (MockContext context = MockContext.Start(this.GetType()))
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
            using (MockContext context = MockContext.Start(this.GetType()))
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
            using (MockContext context = MockContext.Start(this.GetType()))
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
                    Assert.Contains("was not found", ex.Message);
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
            using (MockContext context = MockContext.Start(this.GetType()))
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
                    Assert.Contains("not found", ex.Message);
                }

                // cleanup - remove the account
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void CreateVolumePoolNotFound()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
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
                    Assert.Contains("not found", ex.Message);
                }

                // cleanup - remove the account
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void DeletePoolWithVolumePresent()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
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
                    Assert.Contains("Can not delete resource before nested resources are deleted", ex.Message);
                }

                // clean up
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void CheckAvailability()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // check account resource name - should be available
                var response = netAppMgmtClient.CheckNameAvailability(ResourceUtils.location, ResourceUtils.accountName1, CheckNameResourceTypes.MicrosoftNetAppNetAppAccounts, ResourceUtils.resourceGroup);
                Assert.True(response.IsAvailable);

                // now check file path availability
                response = netAppMgmtClient.CheckFilePathAvailability(ResourceUtils.location, ResourceUtils.volumeName1, CheckNameResourceTypes.MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes, ResourceUtils.resourceGroup);
                Assert.True(response.IsAvailable);

                // create the volume
                var volume = ResourceUtils.CreateVolume(netAppMgmtClient);

                // check volume resource name - should be unavailable after its creation
                var resourceName = ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1;

                response = netAppMgmtClient.CheckNameAvailability(ResourceUtils.location, resourceName, CheckNameResourceTypes.MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes, ResourceUtils.resourceGroup);
                Assert.False(response.IsAvailable);

                // now check file path availability again
                response = netAppMgmtClient.CheckFilePathAvailability(ResourceUtils.location, ResourceUtils.volumeName1, CheckNameResourceTypes.MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes, ResourceUtils.resourceGroup);
                Assert.False(response.IsAvailable);

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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the volume
                var oldVolume = ResourceUtils.CreateVolume(netAppMgmtClient);
                Assert.Equal("Premium", oldVolume.ServiceLevel);
                Assert.Equal(100 * ResourceUtils.gibibyte, oldVolume.UsageThreshold);

                // The returned volume contains some items which cnanot be part of the payload, such as baremetaltenant, therefore create a new object selectively from the old one
                var volume = new Volume
                {
                    Location = oldVolume.Location,
                    ServiceLevel = oldVolume.ServiceLevel,
                    CreationToken = oldVolume.CreationToken,
                    SubnetId = oldVolume.SubnetId,
                };
                // update
                volume.UsageThreshold = 2 * oldVolume.UsageThreshold;

                var updatedVolume = netAppMgmtClient.Volumes.CreateOrUpdate(volume, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Equal("Premium", updatedVolume.ServiceLevel); // didn't attempt to change - it would be rejected
                Assert.Equal(100 * ResourceUtils.gibibyte * 2, updatedVolume.UsageThreshold);

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
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                
                // create the volume
                var volume = ResourceUtils.CreateVolume(netAppMgmtClient);
                Assert.Equal("Premium", volume.ServiceLevel);
                Assert.Equal(100 * ResourceUtils.gibibyte, volume.UsageThreshold);
                Assert.Equal(ResourceUtils.defaultExportPolicy.ToString(), volume.ExportPolicy.ToString());
                Assert.Null(volume.Tags);

                // create a volume with tags and export policy
                var dict = new Dictionary<string, string>();
                dict.Add("Tag2", "Value2");

                // Now try and modify it
                var volumePatch = new VolumePatch()
                {
                    UsageThreshold = 2 * volume.UsageThreshold,
                    Tags = dict,
                    ExportPolicy = exportPatchPolicy
                };

                // patch
                var updatedVolume = netAppMgmtClient.Volumes.Update(volumePatch, ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1);
                Assert.Equal("Premium", updatedVolume.ServiceLevel); // didn't attempt to change - it would be rejected
                Assert.Equal(200 * ResourceUtils.gibibyte, updatedVolume.UsageThreshold);
                Assert.Equal(exportPolicy.ToString(), updatedVolume.ExportPolicy.ToString());
                Assert.True(updatedVolume.Tags.ToString().Contains("Tag2") && updatedVolume.Tags.ToString().Contains("Value2"));

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
