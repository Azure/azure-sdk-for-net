// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Nginx.Tests.Helpers
{
    internal class ResourceDataHelper
    {
        public static void AssertTrackedResourceData(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
            Assert.AreEqual(r1.Location, r2.Location);
            Assert.AreEqual(r1.Tags, r2.Tags);
        }

        public static void AssertResourceData(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }
    }
}
