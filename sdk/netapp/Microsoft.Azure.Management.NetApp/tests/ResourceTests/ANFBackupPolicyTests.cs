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
using Newtonsoft.Json;
using System.Threading;

namespace NetApp.Tests.ResourceTests
{
    public class ANFBackupPolicyTests : TestBase
    {
        private const int delay = 5000;
        [Fact]
        public void CreateDeleteBackupPolicy()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });                
                //create account
                ResourceUtils.CreateAccount(netAppMgmtClient, location: ResourceUtils.backupLocation, accountName: ResourceUtils.volumeBackupAccountName1);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                // create the backupPolicy                
                var backupPolicy = CreateBackupPolicy(ResourceUtils.backupLocation, ResourceUtils.backupPolicyName1);
                var backupPoliciesBefore = netAppMgmtClient.BackupPolicies.Create(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1, backupPolicy);

                // check backupPolicy exists
                var backupPolciesBefore = netAppMgmtClient.BackupPolicies.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1);
                Assert.Single(backupPolciesBefore);
                
                var resultBackupPolicy = netAppMgmtClient.BackupPolicies.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1);
                Assert.Equal($"{ResourceUtils.volumeBackupAccountName1}/{ResourceUtils.backupPolicyName1}", resultBackupPolicy.Name);
                // delete the backupPolicy and check again
                netAppMgmtClient.BackupPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                var backupPoliciesAfter = netAppMgmtClient.BackupPolicies.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1);
                Assert.Empty(backupPoliciesAfter);

                // cleanup - remove the resources                
                netAppMgmtClient.BackupPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1);
                ResourceUtils.DeleteAccount(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);
            }
        }

        [Fact]
        public void ListBackupPolices()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                ResourceUtils.CreateAccount(netAppMgmtClient, location: ResourceUtils.backupLocation, accountName: ResourceUtils.volumeBackupAccountName1);
                // create two backupPolicies under same account
                var backupPolicy1 = CreateBackupPolicy(ResourceUtils.backupLocation, ResourceUtils.backupPolicyName1);
                var backupPolicy2 = CreateBackupPolicy(ResourceUtils.backupLocation, ResourceUtils.backupPolicyName2);
                var resultbackupPolicy1 = netAppMgmtClient.BackupPolicies.Create(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1, backupPolicy1);
                var resultbackupPolicy2  = netAppMgmtClient.BackupPolicies.Create(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName2, backupPolicy2);

                // get the backupPolicy list and check
                var backupPolicies = netAppMgmtClient.BackupPolicies.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1);
                Assert.Equal($"{ResourceUtils.volumeBackupAccountName1}/{ResourceUtils.backupPolicyName1}", backupPolicies.ElementAt(0).Name );
                Assert.Equal($"{ResourceUtils.volumeBackupAccountName1}/{ResourceUtils.backupPolicyName2}", backupPolicies.ElementAt(1).Name);
                Assert.Equal(2, backupPolicies.Count());
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                // clean up
                netAppMgmtClient.BackupPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1);
                netAppMgmtClient.BackupPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName2);
                ResourceUtils.DeleteAccount(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);
            }
        }

        [Fact]
        public void GetBackupPolicyByName()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            { 
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });

                //Create account
                ResourceUtils.CreateAccount(netAppMgmtClient, location: ResourceUtils.backupLocation, accountName: ResourceUtils.volumeBackupAccountName1);
                var backupPolicy = CreateBackupPolicy(ResourceUtils.backupLocation, ResourceUtils.backupPolicyName1);

                // create the backupPolicy                               
                var createBackupPolicy = netAppMgmtClient.BackupPolicies.Create(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1, backupPolicy);
            
                var resultBackupPolicy = netAppMgmtClient.BackupPolicies.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1);
                Assert.Equal($"{ResourceUtils.volumeBackupAccountName1}/{ResourceUtils.backupPolicyName1}", resultBackupPolicy.Name);
                Assert.Equal(createBackupPolicy.Name, resultBackupPolicy.Name);

                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }

                // cleanup - remove the resources
                netAppMgmtClient.BackupPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1);
                ResourceUtils.DeletePool(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);
                ResourceUtils.DeleteAccount(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);
            }
        }

        [Fact(Skip ="BackupPolicy service side bug causes this to fail, re-enable when fixed")]
        //[Fact]
        public void CreateVolumeWithBackupPolicy()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                // create the Pool and account
                ResourceUtils.CreatePool(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1, location: ResourceUtils.backupLocation);
                // create the backupPolicy
                var backupPolicy = CreateBackupPolicy(ResourceUtils.backupLocation, ResourceUtils.backupPolicyName1);
                var createBackupPolicy = netAppMgmtClient.BackupPolicies.Create(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1, backupPolicy);
                
                //Get vault 
                var vaultsList = netAppMgmtClient.Vaults.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1);
                Assert.NotEmpty(vaultsList);
                string vaultID = vaultsList.ElementAt(0).Id;
                
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                // Create volume 
                //var createVolume = ResourceUtils.CreateBackedupVolume(netAppMgmtClient, location: ResourceUtils.backupLocation, accountName:ResourceUtils.volumeBackupAccountName1, vnet: ResourceUtils.backupVnet, backupPolicyId: null, backupVaultId: vaultID);
                var createVolume = ResourceUtils.CreateVolume(netAppMgmtClient, location: ResourceUtils.backupLocation, accountName: ResourceUtils.volumeBackupAccountName1, volumeName: ResourceUtils.backupVolumeName1, vnet: ResourceUtils.backupVnet, volumeOnly: true);
                Assert.Equal("Succeeded", createVolume.ProvisioningState);
                //Get volume and check
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                var createGetVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
                Assert.Equal("Succeeded", createGetVolume.ProvisioningState);
                // Now try and modify the backuppolicy
                var patchBackupPolicy = new BackupPolicyPatch()
                {
                    DailyBackupsToKeep = 1
                };

                var resultbackupPolicy = netAppMgmtClient.BackupPolicies.Update(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1, patchBackupPolicy);

                //check volume again
                createGetVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
                Assert.Equal("Succeeded", createGetVolume.ProvisioningState);

                // Now try and set dataprotection on the volume
                var dataProtection = new VolumePatchPropertiesDataProtection
                {
                    Backup = new VolumeBackupProperties {PolicyEnforced = true, BackupEnabled = true, BackupPolicyId = createBackupPolicy.Id, VaultId = vaultID }
                };
                var volumePatch = new VolumePatch()
                {
                    DataProtection = dataProtection
                };

                // patch and enable backups 
                var updatedVolume = netAppMgmtClient.Volumes.Update(volumePatch, ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
                
                //Get volume and check
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                var getVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
                Assert.NotNull(getVolume.DataProtection);
                Assert.NotNull(getVolume.DataProtection.Backup);
                Assert.NotNull(getVolume.DataProtection.Backup.BackupPolicyId);
                Assert.Equal(createBackupPolicy.Id, getVolume.DataProtection.Backup.BackupPolicyId);
                
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }

                // Try and disable backups
                var disableDataProtection = new VolumePatchPropertiesDataProtection
                {
                    Backup = new VolumeBackupProperties { BackupEnabled = false, VaultId = vaultID }
                };
                var disableVolumePatch = new VolumePatch()
                {
                    DataProtection = disableDataProtection
                };

                // patch
                var disabledBackupVolume = netAppMgmtClient.Volumes.Update(disableVolumePatch, ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                var getDisabledVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);

                //check
                Assert.NotNull(getDisabledVolume.DataProtection);
                Assert.NotNull(getDisabledVolume.DataProtection.Backup);
                Assert.False(getDisabledVolume.DataProtection.Backup.BackupEnabled);

                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                // clean up                
                ResourceUtils.DeleteVolume(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1, volumeName: ResourceUtils.backupVolumeName1);
                netAppMgmtClient.BackupPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1);
                ResourceUtils.DeletePool(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);
                ResourceUtils.DeleteAccount(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);
            }
        }


        [Fact]
        public void PatchBackupPolicy()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                //Create acccount
                
                ResourceUtils.CreateAccount(netAppMgmtClient, location: ResourceUtils.backupLocation, accountName: ResourceUtils.volumeBackupAccountName1);
                //create the backupPolicy
                var backupPolicy = CreateBackupPolicy(ResourceUtils.backupLocation, ResourceUtils.backupPolicyName1);
                var createBackupPolicy = netAppMgmtClient.BackupPolicies.Create(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1, backupPolicy);
                
                // Now try and modify it                
                var patchBackupPolicy = new BackupPolicyPatch()
                {                    
                     DailyBackupsToKeep = 1                    
                };

                var resultbackupPolicy = netAppMgmtClient.BackupPolicies.Update(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1, patchBackupPolicy);
                Assert.NotNull(resultbackupPolicy);                               
                Assert.NotNull(resultbackupPolicy.DailyBackupsToKeep);
                Assert.Equal(patchBackupPolicy.DailyBackupsToKeep, resultbackupPolicy.DailyBackupsToKeep);
                
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                // cleanup
                netAppMgmtClient.BackupPolicies.Delete(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPolicyName1);
                ResourceUtils.DeletePool(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);
                ResourceUtils.DeleteAccount(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);
            }
        }

        private static BackupPolicy CreateBackupPolicy(string location , string name = "")
        {
            // Create basic policy records with a selection of data
            BackupPolicy testBackupPolicy = new BackupPolicy(location: location, name: name)
            {                
                Enabled = true,
                DailyBackupsToKeep = 4,
                WeeklyBackupsToKeep = 3,
                MonthlyBackupsToKeep = 2,
                YearlyBackupsToKeep = 1
            };

            return testBackupPolicy;
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.ANFBackupPolicyTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}
