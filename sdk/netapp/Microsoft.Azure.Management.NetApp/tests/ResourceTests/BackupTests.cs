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

namespace NetApp.Tests.ResourceTests
{
    public class AnfBackupTests : TestBase
    {
        private const int delay = 5000;
        [Fact]
        public void CreateDeleteBackup()
        {
            HttpMockServer.RecordsDirectory = GetSessionsDirectoryPath();
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var netAppMgmtClient = NetAppTestUtilities.GetNetAppManagementClient(context, new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                // create the Pool and account
                ResourceUtils.CreatePool(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1, location: ResourceUtils.backupLocation);
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
                var createVolume = ResourceUtils.CreateVolume(netAppMgmtClient, location: ResourceUtils.backupLocation, accountName: ResourceUtils.volumeBackupAccountName1, volumeName: ResourceUtils.backupVolumeName1, vnet: ResourceUtils.backupVnet, volumeOnly: true);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                var createGetVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
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

                var updatedVolume = netAppMgmtClient.Volumes.Update(volumePatch, ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
                //Get volume and check
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                var getVolume = netAppMgmtClient.Volumes.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
                Assert.NotNull(getVolume.DataProtection);
                Assert.NotNull(getVolume.DataProtection.Backup);
                Assert.NotNull(getVolume.DataProtection.Backup.VaultId);

                //create adhoc backup
                var backup = new Backup()
                {
                    Location = ResourceUtils.backupLocation,
                    Label = "sdkTestBackup1"
                };
                var createdBackup = netAppMgmtClient.Backups.Create(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName1, backup);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                Assert.NotNull(createdBackup);
                Assert.NotNull(createdBackup.Name);                
                Assert.Equal($"{ResourceUtils.volumeBackupAccountName1}/{ResourceUtils.poolName1}/{ResourceUtils.backupVolumeName1}/{ResourceUtils.backupName1}", createdBackup.Name);

                WaitForBackupSucceeded(netAppMgmtClient, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName1);

                //create second backup
                var backup2 = new Backup()
                {
                    Location = ResourceUtils.backupLocation,
                    Label = "sdkTestBackup1"
                };
                var createdBackup2 = netAppMgmtClient.Backups.Create(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName2, backup);
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }
                Assert.NotNull(createdBackup2);
                Assert.NotNull(createdBackup2.Name);
                Assert.Equal($"{ResourceUtils.volumeBackupAccountName1}/{ResourceUtils.poolName1}/{ResourceUtils.backupVolumeName1}/{ResourceUtils.backupName2}", createdBackup2.Name);

                WaitForBackupSucceeded(netAppMgmtClient, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName2);

                var getBackup = netAppMgmtClient.Backups.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName2);
                Assert.NotNull(getBackup);

                //Get Volume backup status
                var getBackupStatus = netAppMgmtClient.Backups.GetStatus(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
                Assert.NotNull(getBackupStatus);

                //Get by account backups
                var getAccountBackup2 = netAppMgmtClient.AccountBackups.Get(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1,  ResourceUtils.backupName2);
                Assert.NotNull(getAccountBackup2);
                Assert.NotNull(getAccountBackup2.Name);
                Assert.Equal($"{ResourceUtils.volumeBackupAccountName1}/{ResourceUtils.backupName2}", getAccountBackup2.Name);

                //Get List backups
                var getBackupList = netAppMgmtClient.Backups.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
                Assert.NotNull(getBackupList);
                Assert.Equal(2, getBackupList.Count());
                
                //Get List AccountBackups
                var getAccountBackupList = netAppMgmtClient.AccountBackups.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1);
                Assert.NotNull(getBackupList);
                Assert.Equal(2, getBackupList.Count());

                //Delete backup 1
                WaitForBackupDeleteSucceeded(netAppMgmtClient, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1, ResourceUtils.backupName1);

                //Get List backups
                getBackupList = netAppMgmtClient.Backups.List(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.poolName1, ResourceUtils.backupVolumeName1);
                Assert.NotNull(getBackupList);
                Assert.Single(getBackupList);

                // clean up 
                // Delete volume so we can delete last backup
                ResourceUtils.DeleteVolume(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1, volumeName: ResourceUtils.backupVolumeName1);
                //Delete last backup from AccountBackups
                netAppMgmtClient.AccountBackups.Delete(ResourceUtils.resourceGroup, ResourceUtils.volumeBackupAccountName1, ResourceUtils.backupName2);                
                ResourceUtils.DeletePool(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);
                ResourceUtils.DeleteAccount(netAppMgmtClient, accountName: ResourceUtils.volumeBackupAccountName1);

            }
        }

        private void WaitForBackupDeleteSucceeded(AzureNetAppFilesManagementClient netAppMgmtClient, string accountName = ResourceUtils.volumeBackupAccountName1, string poolName = ResourceUtils.poolName1, string volumeName = ResourceUtils.backupVolumeName1, string backupName = ResourceUtils.backupName1)
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

        private void WaitForBackupSucceeded(AzureNetAppFilesManagementClient netAppMgmtClient, string accountName = ResourceUtils.volumeBackupAccountName1, string poolName = ResourceUtils.poolName1, string volumeName = ResourceUtils.backupVolumeName1, string backupName = ResourceUtils.backupName1)
        {
            var maxDelay = TimeSpan.FromSeconds(45);
            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Playback")
            {
                maxDelay = TimeSpan.FromMilliseconds(500);
            }

            var delay = Backoff.DecorrelatedJitterBackoffV2(medianFirstRetryDelay: TimeSpan.FromSeconds(5), retryCount: 20)
                    .Select(s => TimeSpan.FromTicks(Math.Min(s.Ticks, maxDelay.Ticks))); // use jitter strategy in the retry algorithm to prevent retries bunching into further spikes of load, with ceiling on delays (for larger retrycount) 
            var policy = Policy
                .HandleResult<Backup>(b => !b.ProvisioningState.Equals("Succeeded")) // retry if Provisioning state is not Succeeded 
                .WaitAndRetry(delay);

            policy.Execute(() => 
            GetBackup(netAppMgmtClient, ResourceUtils.resourceGroup, accountName, poolName, volumeName, backupName)            
                );
        }

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
