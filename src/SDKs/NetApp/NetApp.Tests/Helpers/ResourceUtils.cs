using Microsoft.Azure.Management.NetApp;
using Microsoft.Azure.Management.NetApp.Models;
using System.Threading;
using Xunit;

namespace NetApp.Tests.Helpers
{
    public class ResourceUtils
    {
        public const long gibibyte = 1024L * 1024L * 1024L;

        protected const string subsId = "0661b131-4a11-479b-96bf-2f95acca2f73";
        protected const string vnet = "sdk-tests-rg-vnet";
        public const string location = "eastus";
        public const string resourceGroup = "sdk-tests-rg";
        public const string accountName1 = "sdk-tests-acc1";
        public const string accountName2 = "sdk-tests-acc2";
        public const string poolName1 = "sdk-tests-pool1";
        public const string poolName2 = "sdk-tests-pool2";
        public const string volumeName1 = "sdk-tests-vol1";
        public const string volumeName2 = "sdk-tests-vol2";
        public const string snapshotName1 = "sdk-tests-snap1";
        public const string snapshotName2 = "sdk-tests-snap2";

        private const int delay = 5000;
        private const int retryAttempts = 3;

        public static void CreateAccount(AzureNetAppFilesManagementClient netAppMgmtClient, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location)
        {
            var netAppAccount = new NetAppAccount()
            {
                Location = location,
            };

            var resource = netAppMgmtClient.Accounts.CreateOrUpdate(netAppAccount, resourceGroup, accountName);
            Assert.Equal(resource.Name, accountName);

            Thread.Sleep(delay); // some robustness against ARM caching
        }

        public static CapacityPool CreatePool(AzureNetAppFilesManagementClient netAppMgmtClient, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, bool poolOnly = false)
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

        public static Volume CreateVolume(AzureNetAppFilesManagementClient netAppMgmtClient, string volumeName = volumeName1, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, bool volumeOnly = false)
        {
            if (!volumeOnly)
            {
                CreatePool(netAppMgmtClient, poolName, accountName);
            }

            var volume = new Volume
            {
                Location = location,
                UsageThreshold = 100 * gibibyte,
                ServiceLevel = "Premium",
                CreationToken = volumeName,
                SubnetId = "/subscriptions/" + subsId + "/resourceGroups/" + resourceGroup + "/providers/Microsoft.Network/virtualNetworks/" + vnet + "/subnets/default"
            };

            var resource = netAppMgmtClient.Volumes.CreateOrUpdate(volume, resourceGroup, accountName, poolName, volumeName);
            Assert.Equal(resource.Name, accountName + '/' + poolName + '/' + volumeName);

            Thread.Sleep(delay); // some robustness against ARM caching

            return resource;
        }

        public static void CreateSnapshot(AzureNetAppFilesManagementClient netAppMgmtClient, string snapshotName = snapshotName1, string volumeName = volumeName1, string poolName = poolName1, string accountName = accountName1, string resourceGroup = resourceGroup, string location = location, bool snapshotOnly = false)
        {
            Volume volume = null;

            if (!snapshotOnly)
            {
                volume = CreateVolume(netAppMgmtClient, volumeName, poolName, accountName);
            }
            else
            {
                volume = netAppMgmtClient.Volumes.Get(resourceGroup, accountName, poolName, volumeName);
            }

            var snapshot = new Snapshot
            {
                Location = location,
                FileSystemId = volume?.FileSystemId
            };

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

            // now delete the pool - with retry for test robustness due to ARM caching
            // (arm continues to tidy up even after the awaited async op has returned)
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

            // now delete the volume - with retry for test robustness due to ARM caching
            // (arm continues to tidy up even after the awaited async op has returned)
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

            // now delete the snapshot - with retry for test robustness due to ARM caching
            // (arm continues to tidy up even after the awaited async op has returned)
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