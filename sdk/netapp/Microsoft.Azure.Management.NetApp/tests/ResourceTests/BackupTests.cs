using NetApp.Tests.Helpers;
using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.NetApp.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using Xunit;
using Microsoft.Rest.Azure;
using Polly;
using Polly.Contrib.WaitAndRetry;
using System.Threading.Tasks;

namespace NetApp.Tests.ResourceTests
{
    public class AnfBackupTests : TestBase
    {
        private const int delay = 5000;
        //[Fact(Skip = "Backup service side bug (Networking) causes this to fail, re-enable when fixed")]
        [Fact]
        public void CreateDeleteBackup()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                // create the Pool and account
                ResourceUtils.CreatePool(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1, poolName: ResourceUtils.backupPoolName1, location: ResourceUtils.backupLocation);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                //Get vault 
                var vaultsList = netAppMgmtClient.Vaults.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1);
                Assert.NotEmpty(vaultsList);
                string vaultID = vaultsList.ElementAt(0).Id;

                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                // Create volume 
                var createVolume = ResourceUtils.CreateVolume(netAppMgmtClient, location: ResourceUtils.backupLocation, accountName: ResourceUtils.volumeBackupAccountName1, poolName: ResourceUtils.backupPoolName1, volumeName: ResourceUtils.backupVolumeName1, vnet: ResourceUtils.backupVnet, volumeOnly: true);
                Assert.NotNull(createVolume);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                var createGetVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1);
                Assert.Equal("Succeeded", createGetVolume.ProvisioningState);
                //volume update with backup setting                
                var dataProtection = new VolumePatchPropertiesDataProtection
                {
                    Backup = new VolumeBackupProperties { BackupEnabled = true, VaultId = vaultID }
                };
                var volumePatch = new VolumePatch()
                {
                    DataProtection = dataProtection
                };

                var updatedVolume = netAppMgmtClient.Volumes.Update(volumePatch, ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1);
                //Get volume and check
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                var getVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1);
                Assert.NotNull(getVolume.DataProtection);
                Assert.NotNull(getVolume.DataProtection.Backup);
                Assert.NotNull(getVolume.DataProtection.Backup.VaultId);

                //create adhoc backup
                var backup = new Backup()
                {
                    Location = ResourceUtils.backupLocation,
                    Label = "sdkTestBackup1"
                };
                var createdBackup = netAppMgmtClient.Backups.Create(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName1, backup);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                Assert.NotNull(createdBackup);
                Assert.NotNull(createdBackup.Name);                
                Assert.Equal($"{ResourceUtils.volumeBackupAccountName1}/{ResourceUtils.backupPoolName1}/{ResourceUtils.backupVolumeName1}/{ResourceUtils.backupName1}", createdBackup.Name);

                WaitForBackupSucceeded(netAppMgmtClient, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName1);

                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                //create second backup
                var backup2 = new Backup()
                {
                    Location = ResourceUtils.backupLocation,
                    Label = "sdkTestBackup1"
                };
                var createdBackup2 = netAppMgmtClient.Backups.Create(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName2, backup);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                Assert.NotNull(createdBackup2);
                Assert.NotNull(createdBackup2.Name);
                Assert.Equal($"{ResourceUtils.volumeBackupAccountName1}/{ResourceUtils.backupPoolName1}/{ResourceUtils.backupVolumeName1}/{ResourceUtils.backupName2}", createdBackup2.Name);

                WaitForBackupSucceeded(netAppMgmtClient, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName2);

                var getBackup = netAppMgmtClient.Backups.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName2);
                Assert.NotNull(getBackup);

                //Get Volume backup status
                var getBackupStatus = netAppMgmtClient.Backups.GetStatus(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1);
                Assert.NotNull(getBackupStatus);

                //Get by account backups
                var getAccountBackup2 = netAppMgmtClient.AccountBackups.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1,  ResourceUtils.backupName2);
                Assert.NotNull(getAccountBackup2);
                Assert.NotNull(getAccountBackup2.Name);
                Assert.Equal($"{ResourceUtils.volumeBackupAccountName1}/{ResourceUtils.backupName2}", getAccountBackup2.Name);

                //Get List backups
                var getBackupList = netAppMgmtClient.Backups.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1);
                Assert.NotNull(getBackupList);
                Assert.Equal(2, getBackupList.Count());
                
                //Get List AccountBackups
                var getAccountBackupList = netAppMgmtClient.AccountBackups.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1);
                Assert.NotNull(getBackupList);
                Assert.Equal(2, getBackupList.Count());

                //Delete backup 1
                WaitForBackupDeleteSucceeded(netAppMgmtClient, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName1);

                //Get List backups
                getBackupList = netAppMgmtClient.Backups.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupPoolName1, ResourceUtils.backupVolumeName1);
                Assert.NotNull(getBackupList);
                Assert.Single(getBackupList);

                // clean up 
                // Delete volume so we can delete last backup
                ResourceUtils.DeleteVolume(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1, poolName: ResourceUtils.backupPoolName1 , volumeName: ResourceUtils.backupVolumeName1);
                //Delete last backup from AccountBackups
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                netAppMgmtClient.AccountBackups.Delete(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupName2);
                ResourceUtils.DeletePool(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1, poolName: ResourceUtils.backupPoolName1);
                ResourceUtils.DeleteAccount(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);

            }
        }

        private void WaitForBackupDeleteSucceeded(AzureNetAppFilesManagementClient netAppMgmtClient, string accountName = ResourceUtils.volumeBackupAccountName1, string poolName = ResourceUtils.backupPoolName1, string volumeName = ResourceUtils.backupVolumeName1, string backupName = ResourceUtils.backupName1)
        {
            var maxDelay = TimeSpan.FromSeconds(45);
            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Playback")
            {
                maxDelay = TimeSpan.FromMilliseconds(500);
            }
            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(5), retryCount: 5)
                .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount) 

            var policy = Policy
                .Handle<CloudException>() // retry if delete is not Succeeded, sometimes timeout in backend calls cause 'Max retry attempts exceeded.' in RP, second attempt usually succeds
                .WaitAndRetry(delay);

            policy.Execute(() =>
                netAppMgmtClient.Backups.Delete(ResourceUtils.resourceGroup, accountName, poolName, volumeName, backupName)
                );
        }

        private void WaitForBackupSucceeded(AzureNetAppFilesManagementClient netAppMgmtClient, string accountName = ResourceUtils.volumeBackupAccountName1, string poolName = ResourceUtils.backupPoolName1, string volumeName = ResourceUtils.backupVolumeName1, string backupName = ResourceUtils.backupName1)
        {
            var maxDelay = TimeSpan.FromSeconds(45);
            int count = 0;
            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Playback")
            {
                maxDelay = TimeSpan.FromMilliseconds(500);
            }

            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(5), retryCount: 50)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount) 
            var retryPolicy = Policy
                .HandleResult<Backup>(b => !(b.ProvisioningState.Equals("Succeeded") || b.ProvisioningState.Equals("Failed"))) // retry if Provisioning state is not Succeeded 
                .WaitAndRetry(delay);

            var fallbackPolicy = Policy
                .HandleResult<Backup>(b => (!b.ProvisioningState.Equals("Succeeded") || b.ProvisioningState.Equals("Failed"))) // Fail the test run if Provisioning state is not Succeeded by now
                .Fallback<Backup>(b =>  
                {
                    var backup = GetBackup(netAppMgmtClient, ResourceUtils.resourceGroup, accountName, poolName, volumeName, backupName);
                    throw new Exception($"Provision state {backup.ProvisioningState} after {count} retires waiting for backup Provisioning state to be Succeeded");
                });
            
            var f = fallbackPolicy.Wrap(retryPolicy)
                    .Execute(() =>
                    {
                        count++;
                        return GetBackup(netAppMgmtClient, ResourceUtils.resourceGroup, accountName, poolName, volumeName, backupName);
                    }
                );

            //policy.Execute(() => 
            //    GetBackup(netAppMgmtClient, ResourceUtils.resourceGroup, accountName, poolName, volumeName, backupName)
            //    );            
        }

        //private void WaitForBackupSucceededFailed(AzureNetAppFilesManagementClient netAppMgmtClient, string accountName = ResourceUtils.volumeBackupAccountName1, string poolName = ResourceUtils.backupPoolName1, string volumeName = ResourceUtils.backupVolumeName1, string backupName = ResourceUtils.backupName1)
        //{
        //    var maxDelay = TimeSpan.FromSeconds(120);
        //    int count = 0;
        //    if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Playback")
        //    {
        //        maxDelay = TimeSpan.FromMilliseconds(500);
        //    }

        //    var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(5), retryCount: 50)
        //            .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount) 
        //    var retryPolicy = Policy
        //        .HandleResult<Backup>(b => !(b.ProvisioningState.Equals("Succeeded") || b.ProvisioningState.Equals("Failed"))) // retry if Provisioning state is not Succeeded 
        //        .WaitAndRetry(delay);

        //    var fallbackPolicy = Policy
        //        .HandleResult<Backup>(b => (!b.ProvisioningState.Equals("Succeeded"))) // Fail the test run if Provisioning state is not Succeeded by now                 
        //        .Fallback<Backup>(b =>
        //                .Fallback<Backup>(
        //                    {
        //                        throw new Exception($"Max retires {count} waiting for backup Provisioning state to be Succeeded");
        //                    }),
        //            fallbackAction: () =>
        //            {
        //                var backup = GetBackup(netAppMgmtClient, ResourceUtils.resourceGroup, accountName, poolName, volumeName, backupName);
        //                if (backup.ProvisioningState == "Failed")
        //                {
        //                    throw new Exception($"Provisioning state Failed after {count} retries");
        //                }
        //                else
        //                {
        //                    throw new Exception("Max retires waiting for backup Provisioning state to be Succeeded");
        //                }
        //            }
        //         );
                            
        //    var r = fallbackPolicy.Wrap(retryPolicy)
        //            .Execute(() =>
        //                {
        //                    count++;
        //                    return GetBackup(netAppMgmtClient, ResourceUtils.resourceGroup, accountName, poolName, volumeName, backupName);
        //                }
        //        );

        //    //policy.Execute(() => 
        //    //    GetBackup(netAppMgmtClient, ResourceUtils.resourceGroup, accountName, poolName, volumeName, backupName)
        //    //    );            
        //}

        private Backup GetBackup(AzureNetAppFilesManagementClient netAppMgmtClient, string resourceGroup, string accountName, string poolName, string volumeName, string backupName)
        {
            var backup = netAppMgmtClient.Backups.Get(ResourceUtils.resourceGroup, accountName, poolName, volumeName, backupName);
            return backup;
        }

        private static string GetSessionsDirectoryPath()
        {
            string executingAssemblyPath = typeof(NetApp.Tests.ResourceTests.AnfBackupTests).GetTypeInfo().Assembly.Location;
            return Path.Combine(Path.GetDirectoryName(executingAssemblyPath), "SessionRecords");
        }
    }
}
