// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Compute.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class AvailabilitySetHelper
    {
        public static void AssertAvailabilitySet(AvailabilitySetData set1, AvailabilitySetData set2)
        {
            Assert.AreEqual(set1.Name, set2.Name);
            Assert.AreEqual(set1.Id, set2.Id);
            Assert.AreEqual(set1.Type, set2.Type);
            Assert.AreEqual(set1.Location, set2.Location);
            Assert.AreEqual(set1.Tags, set2.Tags);
            Assert.AreEqual(set1.PlatformFaultDomainCount, set2.PlatformFaultDomainCount);
            Assert.AreEqual(set1.PlatformUpdateDomainCount, set2.PlatformUpdateDomainCount);
            Assert.AreEqual(set1.ProximityPlacementGroup, set2.ProximityPlacementGroup);
            Assert.AreEqual(set1.ProximityPlacementGroup?.Id, set2.ProximityPlacementGroup?.Id);
        }

        public static AvailabilitySetData GetBasicAvailabilitySetData(Location location, IDictionary<string, string> tags = null)
        {
            var set = new AvailabilitySetData(location);
            foreach (var kv in tags)
            {
                set.Tags.Add(kv);
            }
            return set;
        }
    }
}
