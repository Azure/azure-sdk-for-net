// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Nginx.Tests.Helpers
{
    internal static class ResourceDataHelper
    {
        public static void AssertTrackedResourceData(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.That(r2.Id, Is.EqualTo(r1.Id));
            Assert.That(r2.Name.ToLowerInvariant(), Is.EqualTo(r1.Name.ToLowerInvariant()));
            Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
            Assert.That(r2.Location, Is.EqualTo(r1.Location));
            Assert.That(r2.Tags, Is.EqualTo(r1.Tags));
        }

        public static void AssertResourceData(ResourceData r1, ResourceData r2)
        {
            Assert.That(r2.Id, Is.EqualTo(r1.Id));
            Assert.That(r2.Name.ToLowerInvariant(), Is.EqualTo(r1.Name.ToLowerInvariant()));
            Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
        }
    }
}
