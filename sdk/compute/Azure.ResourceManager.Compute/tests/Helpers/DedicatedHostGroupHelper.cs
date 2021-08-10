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

        public static DedicatedHostGroupData GetBasicDedicatedHostGroup(Location location, int platformFaultDomainCount = 2)
        {
            return new DedicatedHostGroupData(location)
            {
                PlatformFaultDomainCount = platformFaultDomainCount
            };
        }
    }
}
