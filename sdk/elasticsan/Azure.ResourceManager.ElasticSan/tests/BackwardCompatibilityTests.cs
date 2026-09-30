// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager.ElasticSan.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.ElasticSan.Tests
{
    public class BackwardCompatibilityTests
    {
        private static readonly ResourceIdentifier ManagedById = new("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test/providers/Microsoft.Compute/virtualMachines/test");

        [Test]
        public void VolumeDataManagedByResourceIdBridgesManagedBy()
        {
            ElasticSanVolumeData data = new(100)
            {
                ManagedByResourceId = ManagedById
            };

            Assert.AreEqual(ManagedById, data.ManagedByResourceId);
            Assert.AreEqual(1, data.ManagedBy.Count);
            Assert.AreEqual(ManagedById, data.ManagedBy[0].ResourceIds[0]);

            data.ManagedByResourceId = null;

            Assert.IsNull(data.ManagedByResourceId);
            Assert.IsEmpty(data.ManagedBy);
        }

        [Test]
        public void VolumePatchManagedByResourceIdBridgesManagedBy()
        {
            ElasticSanVolumePatch patch = new()
            {
                ManagedByResourceId = ManagedById
            };

            Assert.AreEqual(ManagedById, patch.ManagedByResourceId);
            Assert.AreEqual(1, patch.ManagedBy.Count);
            Assert.AreEqual(ManagedById, patch.ManagedBy[0].ResourceIds[0]);

            patch.ManagedByResourceId = null;

            Assert.IsNull(patch.ManagedByResourceId);
            Assert.IsEmpty(patch.ManagedBy);
        }
    }
}
