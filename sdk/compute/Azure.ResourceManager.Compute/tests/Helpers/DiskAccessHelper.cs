// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Helpers
{
    public static class DiskAccessHelper
    {
        public static void AssertDiskAccess(DiskAccessData access1, DiskAccessData access2)
        {
            Assert.AreEqual(access1.Id, access2.Id);
            Assert.AreEqual(access1.Name, access2.Name);
            Assert.AreEqual(access1.Type, access2.Type);
            Assert.AreEqual(access1.Location, access2.Location);
            Assert.AreEqual(access1.Tags, access2.Tags);
        }

        public static DiskAccessData GetEmptyDiskAccess(Location location)
        {
            return new DiskAccessData(location);
        }
    }
}
