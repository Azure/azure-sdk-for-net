// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class DedicatedHostGroupHelper
    {
        public static void AssertGroup(DedicatedHostGroupData group1, DedicatedHostGroupData group2)
        {
            Assert.AreEqual(group1.Id, group2.Id);
            Assert.AreEqual(group1.Name, group2.Name);
            Assert.AreEqual(group1.Type, group2.Type);
            Assert.AreEqual(group1.Location, group2.Location);
            Assert.AreEqual(group1.PlatformFaultDomainCount, group2.PlatformFaultDomainCount);
            Assert.AreEqual(group1.SupportAutomaticPlacement, group2.SupportAutomaticPlacement);
        }

        public static void AssertHost(DedicatedHostData host1, DedicatedHostData host2)
        {
            Assert.AreEqual(host1.Id, host2.Id);
            Assert.AreEqual(host1.Name, host2.Name);
            Assert.AreEqual(host1.Type, host2.Type);
            Assert.AreEqual(host1.Sku.Name, host2.Sku.Name);
            Assert.AreEqual(host1.Sku.Tier, host2.Sku.Tier);
            Assert.AreEqual(host1.Sku.Capacity, host2.Sku.Capacity);
            Assert.AreEqual(host1.PlatformFaultDomain, host2.PlatformFaultDomain);
        }

        public static DedicatedHostGroupData GetBasicDedicatedHostGroup(Location location, int platformFaultDomainCount = 2)
        {
            return new DedicatedHostGroupData(location)
            {
                PlatformFaultDomainCount = platformFaultDomainCount
            };
        }

        public static DedicatedHostData GetBasicDedicatedHost(Location location, string skuName, int platformFaultDomain)
        {
            return new DedicatedHostData(location, new Models.Sku()
            {
                Name = skuName
            })
            {
                PlatformFaultDomain = platformFaultDomain
            };
        }
    }
}
