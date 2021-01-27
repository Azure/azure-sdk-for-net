using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace NetApp.Tests.Helpers
{
    public class ResourceUtils
    {
        public const long gibibyte = 1024L * 1024L * 1024L;

        private const string remoteSuffix = "-R";
        public const string vnet = "sdknettestqa2vnet464";        
        public const string backupVnet = "sdknettestqa2vnet464euap";
        public const string repVnet = "sdktestqa2vnet464";
        //public const string remoteVnet = repVnet + remoteSuffix;
        public const string remoteVnet = "sdktestqa2vnet464east-R";
        //public const string subsId = "8f38cfec-0ecd-413a-892e-2494f77a3b56";
        //public const string subsId = "0661B131-4A11-479B-96BF-2F95ACCA2F73";
        public const string subsId = "69a75bda-882e-44d5-8431-63421204132a";
        public const string location = "westus2";
        //public const string location = "eastus2euap";
        //public const string remoteLocation = "southcentralus";
        public const string remoteLocation = "eastus";
        //public const string backupLocation = "westus2";
        //public const string backupLocation = "westus2"; //"westusstage";
        public const string backupLocation = "eastus2euap"; //"westusstage";
        public const string resourceGroup = "sdk-net-test-qa2";
        //public const string resourceGroup = "ab_sdk_test_rg";
        public const string repResourceGroup = "sdk-test-qa2";
        public const string remoteResourceGroup = repResourceGroup + remoteSuffix;
        public const string accountName1 = "sdk-net-tests-acc-208";
        public const string accountName1Repl = "sdk-net-tests-acc-20b";
        public const string remoteAccountName1 = accountName1Repl + remoteSuffix;
        public const string accountName2 = "sdk-net-tests-acc-21";
        public const string poolName1 = "sdk-net-tests-pool-201";
        public const string poolName1Repl = "sdk-net-tests-pool-10b";
        public const string remotePoolName1 = poolName1Repl + remoteSuffix;
        public const string poolName2 = "sdk-net-tests-pool-211";
        public const string volumeName1 = "sdk-net-tests-vol-2101";
        
        public const string volumeBackupAccountName1 = "sdk-net-tests-acc-211v";
        public const string backupVolumeName1 = "sdk-net-tests-vol-2108";

        public const string volumeName1Repl = "sdk-net-tests-vol-1000b";
        public const string remoteVolumeName1 = volumeName1Repl + remoteSuffix;
        public const string volumeName2 = "sdk-net-tests-vol-1001";
        public const string snapshotName1 = "sdk-net-tests-snap-11";
        public const string snapshotName2 = "sdk-net-tests-snap-12";
        public const string snapshotPolicyName1 = "sdk-net-tests-snapshotPolicy-1";
        public const string snapshotPolicyName2 = "sdk-net-tests-snapshotPolicy-2";
        public const string backupPolicyName1 = "sdk-net-tests-backupPolicy-105a";
        public const string backupPolicyName2 = "sdk-net-tests-backupPolicy-105b";
        //public const string backupVaultId = "cbsvault";

        public static ActiveDirectory activeDirectory = new ActiveDirectory()
        {
            Username = "sdkuser",
            Password = "sdkpass",
            Domain = "sdkdomain",
            Dns = "192.0.2.2",
            SmbServerName = "SDKSMBSeNa",
        };

        public static ActiveDirectory activeDirectory2 = new ActiveDirectory()
        {
            Username = "sdkuser1",
            Password = "sdkpass1",
            Domain = "sdkdomain",
            Dns = "192.0.2.1",
            SmbServerName = "SDKSMBSeNa",
        };

        public static ExportPolicyRule defaultExportPolicyRule = new ExportPolicyRule()
        {
            RuleIndex = 1,
            UnixReadOnly = false,
            UnixReadWrite = true,
            Cifs = false,
            Nfsv3 = true,
            Nfsv41 = false,
            AllowedClients = "0.0.0.0/0"
        };

        public static IList<ExportPolicyRule> defaultExportPolicyRuleList = new List<ExportPolicyRule>()
        {
            defaultExportPolicyRule
        };

        public static VolumePropertiesExportPolicy defaultExportPolicy = new VolumePropertiesExportPolicy()
        {
            Rules = defaultExportPolicyRuleList
        };

        private const int delay = 5000;
        private const int retryAttempts = 4;

        public static NetAppAccount CreateAccount(AzureNetAppFilesManagementClient netAppMgmtClient, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, IDictionary<string, string> tags = default(IDictionary<string, string>), ActiveDirectory activeDirectory = null)
        {
            // request reference example
            // az netappfiles account update -g --account-name cli-lf-acc2  --active-directories '[{"username": "aduser", "password": "aduser", "smbservername": "SMBSERVER", "dns": "1.2.3.4", "domain": "westcentralus"}]' -l westus2

            var activeDirectories = activeDirectory != null ? new List <ActiveDirectory> { activeDirectory } : new List<ActiveDirectory>();

            var netAppAccount = new NetAppAccount()
            {
                Location = location,
                Tags = tags,
                ActiveDirectories = activeDirectories
            };

            var resource = netAppMgmtClient.Accounts.CreateOrUpdate(netAppAccount, resourceGroup, accountName);
            Assert.Equal(resource.Name, accountName);

            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
            {
                Thread.Sleep(delay); // some robustness against ARM caching
            }

            return resource;
        }

        public static CapacityPool CreatePool(AzureNetAppFilesManagementClient netAppMgmtClient, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, IDictionary<string, string> tags = default(IDictionary<string, string>), bool poolOnly = false, string serviceLevel = "Premium")
        {
            if (!poolOnly)
            {
                CreateAccount(netAppMgmtClient, accountName, resourceGroup: resourceGroup, location: location, tags: tags);
            }

            var pool = new CapacityPool
            {
                Location = location,
                Size = 4398046511104,
                ServiceLevel = serviceLevel,
                Tags = tags
            };

            CapacityPool resource;
            try
            {
                resource = netAppMgmtClient.Pools.CreateOrUpdate(pool, resourceGroup, accountName, poolName);
            }
            catch
            {
                // try one more time
                resource = netAppMgmtClient.Pools.CreateOrUpdate(pool, resourceGroup, accountName, poolName);
            }
            Assert.Equal(resource.Name, accountName + '/' + poolName);

            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
            {
                Thread.Sleep(delay); // some robustness against ARM caching
            }

            return resource;
        }

        public static Volume CreateVolume(AzureNetAppFilesManagementClient netAppMgmtClient, string volumeName = volumeName1, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, List<string> protocolTypes = null, IDictionary<string, string> tags = default(IDictionary<string, string>), VolumePropertiesExportPolicy exportPolicy = null, string vnet = vnet, bool volumeOnly = false, string snapshotId = null, string snapshotPolicyId = null)
        {
            if (!volumeOnly)
            {
                CreatePool(netAppMgmtClient, poolName, accountName, resourceGroup: resourceGroup, location: location);
            }
            var defaultProtocolType = new List<string>() { "NFSv3" };
            var volumeProtocolTypes = protocolTypes == null ? defaultProtocolType : protocolTypes;
            var volume = new Volume
            {
                Location = location,
                UsageThreshold = 100 * gibibyte,
                ProtocolTypes = volumeProtocolTypes,
                CreationToken = volumeName,
                SubnetId = "/subscriptions/" + netAppMgmtClient.SubscriptionId + "/resourceGroups/" + resourceGroup + "/providers/Microsoft.Network/virtualNetworks/" + vnet + "/subnets/default",
                Tags = tags,
                ExportPolicy = exportPolicy,
                SnapshotId = snapshotId,                
            };
            if (snapshotPolicyId != null)
            {
                var volumDataProtection = new VolumePropertiesDataProtection
                {
                    Snapshot = new VolumeSnapshotProperties(snapshotPolicyId)
                };
                volume.DataProtection = volumDataProtection;
            }

            var resource = netAppMgmtClient.Volumes.CreateOrUpdate(volume, resourceGroup, accountName, poolName, volumeName);
            Assert.Equal(resource.Name, accountName + '/' + poolName + '/' + volumeName);

            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
            {
                Thread.Sleep(delay); // some robustness against ARM caching
            }

            return resource;
        }

        public static Volume CreateDpVolume(AzureNetAppFilesManagementClient netAppMgmtClient, Volume sourceVolume, string volumeName = remoteVolumeName1, string poolName = remotePoolName1, string accountName = remoteAccountName1, string resourceGroup = remoteResourceGroup, string location = location, List<string> protocolTypes = null, IDictionary<string, string> tags = default(IDictionary<string, string>), VolumePropertiesExportPolicy exportPolicy = null, bool volumeOnly = false, string snapshotId = null)
        {
            if (!volumeOnly)
            {
                CreatePool(netAppMgmtClient, poolName, accountName, resourceGroup: resourceGroup, location: remoteLocation);
            }
            var defaultProtocolType = new List<string>() { "NFSv3" };
            var volumeProtocolTypes = protocolTypes == null ? defaultProtocolType : protocolTypes;
            var replication = new ReplicationObject
            {
                EndpointType = "dst",
                RemoteVolumeResourceId = sourceVolume.Id,
                ReplicationSchedule = "_10minutely"
            };
            var dataProtection = new VolumePropertiesDataProtection
            {
                Replication = replication
            };

            var volume = new Volume
            {
                Location = remoteLocation,
                UsageThreshold = 100 * gibibyte,
                ProtocolTypes = volumeProtocolTypes,
                CreationToken = volumeName,
                //SubnetId = "/subscriptions/" + subsId + "/resourceGroups/" + resourceGroup + "/providers/Microsoft.Network/virtualNetworks/" + remoteVnet + "/subnets/default",
                SubnetId = "/subscriptions/" + netAppMgmtClient.SubscriptionId + "/resourceGroups/" + resourceGroup + "/providers/Microsoft.Network/virtualNetworks/" + remoteVnet + "/subnets/default",
                Tags = tags,
                ExportPolicy = exportPolicy,
                SnapshotId = snapshotId,
                VolumeType = "DataProtection",
                DataProtection = dataProtection
            };
            
            var resource = netAppMgmtClient.Volumes.CreateOrUpdate(volume, resourceGroup, accountName, poolName, volumeName);
            Assert.Equal(resource.Name, accountName + '/' + poolName + '/' + volumeName);

            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
            {
                Thread.Sleep(delay); // some robustness against ARM caching
            }

            return resource;
        }

        public static Volume CreateBackedupVolume(AzureNetAppFilesManagementClient netAppMgmtClient, string volumeName = volumeName1, string poolName = poolName1, string accountName = volumeBackupAccountName1, string resourceGroup = resourceGroup, string location = backupLocation, List<string> protocolTypes = null, IDictionary<string, string> tags = default(IDictionary<string, string>), VolumePropertiesExportPolicy exportPolicy = null, bool volumeOnly = false, string vnet = backupVnet, string backupPolicyId = null, string backupVaultId = null)
        {
            if (!volumeOnly)
            {
                CreatePool(netAppMgmtClient, poolName, accountName, resourceGroup: resourceGroup, location: location);
            }
            var defaultProtocolType = new List<string>() { "NFSv3" };
            var volumeProtocolTypes = protocolTypes == null ? defaultProtocolType : protocolTypes;

            var dataProtection = new VolumePropertiesDataProtection
            {
                Backup = new VolumeBackupProperties {BackupEnabled = true, BackupPolicyId = backupPolicyId, VaultId = backupVaultId }
            };

            var volume = new Volume
            {
                Location = location,
                UsageThreshold = 100 * gibibyte,
                ProtocolTypes = volumeProtocolTypes,
                CreationToken = volumeName,                
                SubnetId = "/subscriptions/" + netAppMgmtClient.SubscriptionId + "/resourceGroups/" + resourceGroup + "/providers/Microsoft.Network/virtualNetworks/" + backupVnet + "/subnets/default",
                Tags = tags,
                ExportPolicy = exportPolicy,
                VolumeType = "DataProtection",
                DataProtection = dataProtection
            };

            var resource = netAppMgmtClient.Volumes.CreateOrUpdate(volume, resourceGroup, accountName, poolName, volumeName);
            Assert.Equal(resource.Name, accountName + '/' + poolName + '/' + volumeName);

            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
            {
                Thread.Sleep(delay); // some robustness against ARM caching
            }

            return resource;
        }


        public static void CreateSnapshot(AzureNetAppFilesManagementClient netAppMgmtClient, string snapshotName = snapshotName1, string volumeName = volumeName1, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, bool snapshotOnly = false)
        {
            Volume volume = null;
            var snapshot = new Snapshot();

            if (!snapshotOnly)
            {
                volume = CreateVolume(netAppMgmtClient, volumeName, poolName, accountName);

                snapshot = new Snapshot
                {
                    Location = location,
                };
            }
            else
            {
                // for those tests where snapshotOnly is true, no filesystem id will be available
                // use this opportunity to test snapshot creation with no filesystem id provided
                // for these cases it should use the name in the resource id
                snapshot = new Snapshot
                {
                    Location = location,
                };
            }
            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
            {
                Thread.Sleep(delay); // some robustness against ARM caching
            }
            var resource = netAppMgmtClient.Snapshots.Create(snapshot, resourceGroup, accountName, poolName, volumeName, snapshotName);
            Assert.Equal(resource.Name, accountName + '/' + poolName + '/' + volumeName + '/' + snapshotName);
        }

        public static void DeleteAccount(AzureNetAppFilesManagementClient netAppMgmtClient, string accountName = accountName1, string resourceGroup = resourceGroup, bool deep = false)
        {
            if (deep)
            {
                // find and delete all nested resources - not implemented
            }

            // now delete the account
            netAppMgmtClient.Accounts.Delete(resourceGroup, accountName);
        }

        public static void DeletePool(AzureNetAppFilesManagementClient netAppMgmtClient, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, bool deep = false)
        {
            bool retry = true;
            int co = 0;

            if (deep)
            {
                // find and delete all nested resources - not implemented
            }

            // now delete the pool - with retry for test robustness due to
            //   - ARM caching (ARM continues to tidy up even after the awaited async op
            //     has returned)
            //   - other async actions in RP/SDE/NRP
            // e.g. snapshot deletion might not be complete and therefore pool has child resource
            while (retry == true)
            {
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }

                try
                {
                    netAppMgmtClient.Pools.Delete(resourceGroup, accountName, poolName);
                    retry = false;
                }
                catch
                {
                    co++;
                    if (co > retryAttempts)
                    {
                        retry = false;
                    }
                }
            }
        }

        public static void DeleteVolume(AzureNetAppFilesManagementClient netAppMgmtClient, string volumeName = volumeName1, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, bool deep = false)
        {
            bool retry = true;
            int co = 0;

            if (deep)
            {
                // find and delete all nested resources - not implemented
            }

            // now delete the volume - with retry for test robustness due to
            //   - ARM caching (ARM continues to tidy up even after the awaited async op
            //     has returned)
            //   - other async actions in RP/SDE/NRP
            // e.g. snapshot deletion might not be complete and therefore volume has child resource
            while (retry == true)
            {
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }

                try
                {
                    netAppMgmtClient.Volumes.Delete(resourceGroup, accountName, poolName, volumeName);
                    retry = false;
                }
                catch
                {
                    co++;
                    if (co > retryAttempts)
                    {
                        retry = false;
                    }
                }
            }
        }

        public static void DeleteSnapshot(AzureNetAppFilesManagementClient netAppMgmtClient, string snapshotName = snapshotName1, string volumeName = volumeName1, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, bool deep = false)
        {
            bool retry = true;
            int co = 0;

            if (deep)
            {
                // find and delete all nested resources - not implemented
            }

            // now delete the snapshot - with retry for test robustness due to
            //   - ARM caching (ARM continues to tidy up even after the awaited async op
            //     has returned)
            //   - other async actions in RP/SDE/NRP
            // e.g. snapshot deletion might fail if the actual creation is not complete at 
            // all levels
            while (retry == true)
            {
                if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") == "Record")
                {
                    Thread.Sleep(delay);
                }

                try
                {
                    netAppMgmtClient.Snapshots.Delete(resourceGroup, accountName, poolName, volumeName, snapshotName);
                    retry = false;
                }
                catch
                {
                    co++;
                    if (co > retryAttempts)
                    {
                        retry = false;
                    }
                }
            }
        }
    }
}
