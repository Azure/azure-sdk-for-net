using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace NetApp.Tests.Helpers
{
    public class ResourceUtils
    {
        public const long gibibyte = 1024L * 1024L * 1024L;

        public const string vnet = "sdk-net-tests-rg-cys-vnet";
        public const string subsId = "0661b131-4a11-479b-96bf-2f95acca2f73";
        public const string location = "westcentralus";
        public const string resourceGroup = "sdk-net-tests-rg-cys";
        public const string accountName1 = "sdk-net-tests-acc-1";
        public const string accountName2 = "sdk-net-tests-acc-2";
        public const string poolName1 = "sdk-net-tests-pool-1";
        public const string poolName2 = "sdk-net-tests-pool-2";
        public const string volumeName1 = "sdk-net-tests-vol-1";
        public const string volumeName2 = "sdk-net-tests-vol-2";
        public const string snapshotName1 = "sdk-net-tests-snap-1";
        public const string snapshotName2 = "sdk-net-tests-snap-2";

        public static ActiveDirectory activeDirectory = new ActiveDirectory()
        {
            Username = "sdkuser",
            Password = "sdkpass",
            Domain = "sdkdomain",
            Dns = "127.0.0.1",
            SmbServerName = "SDKSMBServerName",
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

        public static NetAppAccount CreateAccount(AzureNetAppFilesManagementClient netAppMgmtClient, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, object tags = null, ActiveDirectory activeDirectory = null)
        {
            // request reference example
            // az netappfiles account update -g --account-name cli-lf-acc2  --active-directories '[{"username": "aduser", "password": "aduser", "smbservername": "SMBSERVER", "dns": "1.2.3.4", "domain": "westcentralus"}]' -l westus2

            var activeDirectories = new List<ActiveDirectory> { activeDirectory };

            var netAppAccount = new NetAppAccount()
            {
                Location = location,
                Tags = tags,
                // current limitations of active directories make this problematic
                // omitting tests on active directory properties for now
                //ActiveDirectories = activeDirectories
                ActiveDirectories = null
            };

            var resource = netAppMgmtClient.Accounts.CreateOrUpdate(netAppAccount, resourceGroup, accountName);
            Assert.Equal(resource.Name, accountName);

            Thread.Sleep(delay); // some robustness against ARM caching

            return resource;
        }

        public static CapacityPool CreatePool(AzureNetAppFilesManagementClient netAppMgmtClient, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, object tags = null, bool poolOnly = false)
        {
            if (!poolOnly)
            {
                CreateAccount(netAppMgmtClient, accountName);
            }

            var pool = new CapacityPool
            {
                Location = location,
                Size = 4398046511104,
                ServiceLevel = "Premium",
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

            Thread.Sleep(delay); // some robustness against ARM caching

            return resource;
        }

        public static Volume CreateVolume(AzureNetAppFilesManagementClient netAppMgmtClient, string volumeName = volumeName1, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, List<string> protocolTypes = null, object tags = null, VolumePropertiesExportPolicy exportPolicy = null, bool volumeOnly = false, string snapshotId = null)
        {
            if (!volumeOnly)
            {
                CreatePool(netAppMgmtClient, poolName, accountName);
            }
            var defaultProtocolType = new List<string>() { "NFSv3" };
            var volumeProtocolTypes = protocolTypes == null ? defaultProtocolType : protocolTypes;

            var volume = new Volume
            {
                Location = location,
                UsageThreshold = 100 * gibibyte,
                ProtocolTypes = volumeProtocolTypes,
                CreationToken = volumeName,
                SubnetId = "/subscriptions/" + subsId + "/resourceGroups/" + resourceGroup + "/providers/Microsoft.Network/virtualNetworks/" + vnet + "/subnets/default",
                Tags = tags,
                ExportPolicy = exportPolicy,
                SnapshotId = snapshotId
            };

            var resource = netAppMgmtClient.Volumes.CreateOrUpdate(volume, resourceGroup, accountName, poolName, volumeName);
            Assert.Equal(resource.Name, accountName + '/' + poolName + '/' + volumeName);

            Thread.Sleep(delay); // some robustness against ARM caching

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
                    FileSystemId = volume?.FileSystemId
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
                Thread.Sleep(delay);

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
                Thread.Sleep(delay);

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
                Thread.Sleep(delay);

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