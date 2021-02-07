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
using System.Threading;
using System.ComponentModel;

namespace NetApp.Tests.ResourceTests
{
    public class VolumeTests : TestBase
    {
        private const int delay = 10000;
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
                // check DP properties exist but unassigned because
                // dataprotection volume was not created
                Assert.Null(resource.VolumeType);
                Assert.Null(resource.DataProtection);

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
                var  protocolTypes = new List<string>() { "NFSv3" };

                var resource = ResourceUtils.CreateVolume(netAppMgmtClient, protocolTypes: protocolTypes,  tags: dict, exportPolicy: exportPolicy);
                Assert.Equal(exportPolicy.ToString(), resource.ExportPolicy.ToString());
                Assert.Equal(protocolTypes, resource.ProtocolTypes);
                Assert.True(resource.Tags.ContainsKey("Tag2"));
                Assert.Equal("Value2", resource.Tags["Tag2"]);

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
                //Assert.Equal(volumes.ElementAt(1).Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1);
                //Assert.Equal(volumes.ElementAt(0).Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName2);
                Assert.Contains(volumes, item => item.Name == $"{ResourceUtils.accountName1}/{ResourceUtils.poolName1}/{ResourceUtils.volumeName1}");
                Assert.Contains(volumes, item => item.Name == $"{ResourceUtils.accountName1}/{ResourceUtils.poolName1}/{ResourceUtils.volumeName2}");
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
                var response = netAppMgmtClient.NetAppResource.CheckNameAvailability(ResourceUtils.location, ResourceUtils.accountName1, CheckNameResourceTypes.MicrosoftNetAppNetAppAccounts, ResourceUtils.resourceGroup);
                Assert.True(response.IsAvailable);

                // now check file path availability
                response = netAppMgmtClient.NetAppResource.CheckFilePathAvailability(ResourceUtils.location, ResourceUtils.volumeName1, CheckNameResourceTypes.MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes, ResourceUtils.resourceGroup);
                Assert.True(response.IsAvailable);

                // create the volume
                var volume = ResourceUtils.CreateVolume(netAppMgmtClient);

                // check volume resource name - should be unavailable after its creation
                var resourceName = ResourceUtils.accountName1 + '/' + ResourceUtils.poolName1 + '/' + ResourceUtils.volumeName1;

                response = netAppMgmtClient.NetAppResource.CheckNameAvailability(ResourceUtils.location, resourceName, CheckNameResourceTypes.MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes, ResourceUtils.resourceGroup);
                Assert.False(response.IsAvailable);

                // now check file path availability again
                response = netAppMgmtClient.NetAppResource.CheckFilePathAvailability(ResourceUtils.location, ResourceUtils.volumeName1, CheckNameResourceTypes.MicrosoftNetAppNetAppAccountsCapacityPoolsVolumes, ResourceUtils.resourceGroup);
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

                Assert.True(updatedVolume.Tags.ContainsKey("Tag2"));
                Assert.Equal("Value2", updatedVolume.Tags["Tag2"]);

                // cleanup
                ResourceUtils.DeleteVolume(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        private void WaitForReplicationStatus(AzureNetAppFilesManagementClient netAppMgmtClient, string targetState)
        {
            ReplicationStatus replicationStatus;
            int attempts = 0;
            do
            {
                replicationStatus = netAppMgmtClient.Volumes.ReplicationStatusMethod(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);
                Thread.Sleep(1);
            } while (replicationStatus.MirrorState != targetState);
            //sometimes they dont sync up right away
            if (!replicationStatus.Healthy.Value)
            {
                do
                {
                    replicationStatus = netAppMgmtClient.Volumes.ReplicationStatusMethod(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);
                    attempts++;
                    if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                    {
                        Thread.Sleep(1000);
                    }
                } while (replicationStatus.Healthy.Value || attempts == 10);
            }
            Assert.True(replicationStatus.Healthy);
        }

        private void WaitForSucceeded(AzureNetAppFilesManagementClient netAppMgmtClient, string accountName = ResourceUtils.accountName1, string poolName = ResourceUtils.poolName1, string volumeName = ResourceUtils.volumeName1)
        {
            Volume sourceVolume;
            Volume  dpVolume;
            do
            {
                sourceVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.repResourceGroup, accountName, poolName, volumeName);
                dpVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);

                Thread.Sleep(1);
            } while ((sourceVolume.ProvisioningState != "Succeeded") || (dpVolume.ProvisioningState != "Succeeded"));
        }

        [Fact]
        public void CreateDpVolume()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                                
                // create the source volume
                var sourceVolume = ResourceUtils.CreateVolume(netAppMgmtClient, resourceGroup: ResourceUtils.repResourceGroup, vnet: ResourceUtils.repVnet, volumeName: ResourceUtils.volumeName1Repl, 
                    accountName: ResourceUtils.accountName1Repl, poolName: ResourceUtils.poolName1Repl);

                sourceVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.repResourceGroup, ResourceUtils.accountName1Repl, ResourceUtils.poolName1Repl, ResourceUtils.volumeName1Repl);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay); // some robustness against ARM caching
                }
                // create the data protection volume from the source
                var dpVolume = ResourceUtils.CreateDpVolume(netAppMgmtClient, sourceVolume);
                Assert.Equal(ResourceUtils.remoteVolumeName1, dpVolume.Name.Substring(dpVolume.Name.LastIndexOf('/') + 1));
                Assert.NotNull(dpVolume.DataProtection);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(30000);
                }

                var getDPVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);
                var authorizeRequest = new AuthorizeRequest
                {
                    RemoteVolumeResourceId = dpVolume.Id
                };

                netAppMgmtClient.Volumes.AuthorizeReplication(ResourceUtils.repResourceGroup, ResourceUtils.accountName1Repl, ResourceUtils.poolName1Repl, ResourceUtils.volumeName1Repl, authorizeRequest);

                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(30000);
                }
                WaitForSucceeded(netAppMgmtClient, accountName: ResourceUtils.accountName1Repl, poolName: ResourceUtils.poolName1Repl, volumeName: ResourceUtils.volumeName1Repl);

                WaitForReplicationStatus(netAppMgmtClient, "Mirrored");

                netAppMgmtClient.Volumes.BreakReplication(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);

                WaitForReplicationStatus(netAppMgmtClient, "Broken");

                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(30000);
                }

                // sync to the test

                WaitForSucceeded(netAppMgmtClient, accountName: ResourceUtils.accountName1Repl, poolName: ResourceUtils.poolName1Repl, volumeName: ResourceUtils.volumeName1Repl);

                // resync 
                netAppMgmtClient.Volumes.ResyncReplication(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);

                WaitForReplicationStatus(netAppMgmtClient, "Mirrored");

                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(30000);
                }

                // break again

                netAppMgmtClient.Volumes.BreakReplication(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);

                WaitForReplicationStatus(netAppMgmtClient, "Broken");

                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(30000);
                }

                // delete the data protection object
                //  - initiate delete replication on destination, this then releases on source, both resulting in object deletion
                netAppMgmtClient.Volumes.DeleteReplication(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);

                var replicationFound = true; // because it was previously present
                while (replicationFound)
                {
                    try
                    {
                        var replicationStatus = netAppMgmtClient.Volumes.ReplicationStatusMethod(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);
                    }
                    catch
                    {
                        // an exception means the replication was not found
                        // i.e. it has been deleted
                        // ok without checking it could have been for another reason
                        // but then the delete below will fail
                        replicationFound = false;
                    }
                    
                    Thread.Sleep(1);
                }

                // seems the volumes are not always in a terminal state here so check again
                // and ensure the replication objects are removed
                do
                {
                    sourceVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.repResourceGroup, ResourceUtils.accountName1Repl, ResourceUtils.poolName1Repl, ResourceUtils.volumeName1Repl);
                    dpVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);

                    Thread.Sleep(1);
                } while ((sourceVolume.ProvisioningState != "Succeeded") || (dpVolume.ProvisioningState != "Succeeded") || (sourceVolume.DataProtection.Replication != null) || (dpVolume.DataProtection.Replication != null));

                // now proceed with the delete of the volumes
                netAppMgmtClient.Volumes.Delete(ResourceUtils.remoteResourceGroup, ResourceUtils.remoteAccountName1, ResourceUtils.remotePoolName1, ResourceUtils.remoteVolumeName1);
                netAppMgmtClient.Volumes.Delete(ResourceUtils.repResourceGroup, ResourceUtils.accountName1Repl, ResourceUtils.poolName1Repl, ResourceUtils.volumeName1Repl);

                // cleanup pool and account
                ResourceUtils.DeletePool(netAppMgmtClient, resourceGroup: ResourceUtils.repResourceGroup, accountName: ResourceUtils.accountName1Repl, poolName: ResourceUtils.poolName1Repl);
                ResourceUtils.DeletePool(netAppMgmtClient, ResourceUtils.remotePoolName1, ResourceUtils.remoteAccountName1, ResourceUtils.remoteResourceGroup);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(30000);
                }
                ResourceUtils.DeleteAccount(netAppMgmtClient, accountName: ResourceUtils.accountName1Repl, resourceGroup: ResourceUtils.repResourceGroup);
                ResourceUtils.DeleteAccount(netAppMgmtClient, ResourceUtils.remoteAccountName1, ResourceUtils.remoteResourceGroup);
            }
        }

        [Fact]
        public void ChangePoolForVolume()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                // create the volume
                var volume = ResourceUtils.CreateVolume(netAppMgmtClient);
                // create the other pool
                var secondPool = ResourceUtils.CreatePool(netAppMgmtClient, ResourceUtils.poolName2, accountName: ResourceUtils.accountName1, resourceGroup: ResourceUtils.resourceGroup, location: ResourceUtils.location, poolOnly: true, serviceLevel: ServiceLevel.Standard);

                Assert.Equal("Premium", volume.ServiceLevel);
                Assert.Equal(100 * ResourceUtils.gibibyte, volume.UsageThreshold);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(30000);
                }
                var poolChangeRequest = new PoolChangeRequest() { NewPoolResourceId = secondPool.Id };
                //Change pools
                netAppMgmtClient.Volumes.PoolChange(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName1, ResourceUtils.volumeName1, poolChangeRequest);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(30000);
                }
                // retrieve the volume and check 
                var volume2 = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.accountName1, ResourceUtils.poolName2, ResourceUtils.volumeName1);
                Assert.Equal(volume2.Name, ResourceUtils.accountName1 + '/' + ResourceUtils.poolName2 + '/' + ResourceUtils.volumeName1);
                                
                // cleanup
                ResourceUtils.DeleteVolume(netAppMgmtClient, volumeName: ResourceUtils.volumeName1, accountName: ResourceUtils.accountName1, poolName: ResourceUtils.poolName2);
                ResourceUtils.DeletePool(netAppMgmtClient);
                ResourceUtils.DeletePool(netAppMgmtClient, poolName: ResourceUtils.poolName2);
                ResourceUtils.DeleteAccount(netAppMgmtClient);
            }
        }

        [Fact]
        public void LongListVolumes()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                //get list of volumnes                
                var volumesPage = netAppMgmtClient.Volumes.List("sara-systemic", "Sara-Systemic-NA", "Sara-Systemic-CP");
                // Get all resources by polling on next page link
                var volumeResponseList = ListNextLink<Volume>.GetAllResourcesByPollingNextLink(volumesPage, netAppMgmtClient.Volumes.ListNext);
                var volumesList = new List<Volume>();

                foreach (var volume in volumeResponseList)
                {
                    volumesList.Add(volume);
                }

                Assert.Equal(166, volumesList.Count());

            }
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.VolumeTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }

    }
}

