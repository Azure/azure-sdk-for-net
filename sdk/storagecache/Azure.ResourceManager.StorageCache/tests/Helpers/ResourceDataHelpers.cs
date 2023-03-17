// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Network;
using Azure.ResourceManager.Storage;
using Azure.ResourceManager.Storage.Models;
using Azure.ResourceManager.StorageCache.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.StorageCache.Tests.Helpers
{
    public static class ResourceDataHelpers
    {
        public static IDictionary<string, string> ReplaceWith(this IDictionary<string, string> dest, IDictionary<string, string> src)
        {
            dest.Clear();
            foreach (var kv in src)
            {
                dest.Add(kv);
            }

            return dest;
        }
        public static void AssertTrackedResourceData(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region Vnet_subnet
        public static VirtualNetworkData GetVietualNetworkData(string subnetName)
        {
            var vnet = new VirtualNetworkData()
            {
                Location = AzureLocation.EastUS,
                AddressPrefixes= { "10.0.0.0/16", },
                DhcpOptionsDnsServers= { "10.1.1.1", "10.1.2.4" },
                Subnets= {new SubnetData() { Name = subnetName, AddressPrefixes = { "10.0.0.0/24" } } }
            };
            return vnet;
        }

        public static SubnetData GetSubnetData(string subnetName)
        {
            var subnet = new SubnetData()
            {
                Name = subnetName,
                AddressPrefix = "10.0.1.0/24"
            };
            return subnet;
        }
        #endregion

        #region StorageCacheData
        public static void AssertStorageCacheData(StorageCacheData data1, StorageCacheData data2)
        {
            AssertTrackedResourceData(data1, data2);
            Assert.AreEqual(data1.Tags, data2.Tags);
            Assert.AreEqual(data1.CacheSizeGB, data2.CacheSizeGB);
            Assert.AreEqual(data1.MountAddresses, data2.MountAddresses);
        }

        public static StorageCacheData GetStorageCacheData(ResourceIdentifier subnetID)
        {
            var data = new StorageCacheData(AzureLocation.EastUS)
            {
                Sku = new StorageCacheSkuInfo()
                {
                    Name = "Standard_2G",
                },
                CacheSizeGB = 3072,
                Identity = new ManagedServiceIdentity(ManagedServiceIdentityType.SystemAssigned),
                Subnet = subnetID
            };
            return data;
        }
        #endregion

        #region StorageTargetData
        public static void AssertStorageTargetData(StorageTargetData data1, StorageTargetData data2)
        {
            Assert.AreEqual(data1.Name, data2.Name);
            Assert.AreEqual(data1.Id, data2.Id);
            Assert.AreEqual(data1.ResourceType, data2.ResourceType);
            Assert.AreEqual(data1.TargetType, data2.TargetType);
            Assert.AreEqual(data1.Clfs, data2.Clfs);
            Assert.AreEqual(data1.State, data2.State);
            Assert.AreEqual(data1.BlobNfs, data2.BlobNfs);
            Assert.AreEqual(data1.Junctions, data2.Junctions);
        }
        public static StorageTargetData GetStorageTargetData()
        {
            var data = new StorageTargetData()
            {
                /*Clfs = new ClfsTarget()
                {
                    Target = new ResourceIdentifier("storage container")
                }*/
                TargetType = StorageTargetType.BlobNfs,
                BlobNfs = new BlobNfsTarget()
                {
                    Target = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourcegroups/deleteme0316/providers/Microsoft.Storage/storageAccounts/storagetargettest/blobServices/default/containers/teststoragetarget"),
                    UsageModel = "WRITE_WORKLOAD_15"
                },
            };
            return data;
        }
        #endregion

        #region StorageAccountBlobContainer
        public static StorageAccountCreateOrUpdateContent GetContent()
        {
            var content = new StorageAccountCreateOrUpdateContent(new StorageSku(StorageSkuName.StandardLrs), StorageKind.BlobStorage, AzureLocation.EastUS)
            {
                AccessTier = StorageAccountAccessTier.Hot
            };
            return content;
        }
        #endregion
    }
}
