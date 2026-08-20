// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.Fabric.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Fabric.Tests
{
    public class ModelFactoryTests
    {
        [Test]
        public void FabricCapacityPatchSupportsVersionOneCallShapes()
        {
            var sku = new FabricSku();
            var tags = new Dictionary<string, string>();

            FabricCapacityPatch patchWithNullMembers = ArmFabricModelFactory.FabricCapacityPatch(sku, tags, null);
            FabricCapacityPatch patchWithMembers = ArmFabricModelFactory.FabricCapacityPatch(sku, tags, new[] { "admin@contoso.com" });
            FabricCapacityUpdateProperties properties = ArmFabricModelFactory.FabricCapacityUpdateProperties();
            FabricCapacityPatch patchWithProperties = ArmFabricModelFactory.FabricCapacityPatchWithProperties(sku, tags, properties);

            Assert.IsNotNull(patchWithNullMembers);
            Assert.IsNull(patchWithNullMembers.Properties);
            CollectionAssert.AreEqual(new[] { "admin@contoso.com" }, patchWithMembers.FabricCapacityUpdateAdministrationMembers);
            Assert.AreSame(properties, patchWithProperties.Properties);
        }

        [Test]
        public void FabricCapacityUpdatePropertiesSupportsLegacyAndOverageCallShapes()
        {
            FabricCapacityUpdateProperties legacyProperties = ArmFabricModelFactory.FabricCapacityUpdateProperties(null);
            FabricCapacityUpdateProperties overageProperties = ArmFabricModelFactory.FabricCapacityUpdateProperties(null, null);

            Assert.IsNull(legacyProperties.Overage);
            Assert.IsNull(overageProperties.Overage);
        }

        [Test]
        public void FabricCapacityPropertiesSupportsLegacyAndOverageCallShapes()
        {
            FabricProvisioningState? provisioningState = null;
            FabricResourceState? state = null;

            FabricCapacityProperties legacyProperties = ArmFabricModelFactory.FabricCapacityProperties(provisioningState, state, null);
            FabricCapacityProperties overageProperties = ArmFabricModelFactory.FabricCapacityProperties(provisioningState, state, null, null);

            Assert.IsNull(legacyProperties.Overage);
            Assert.IsNull(overageProperties.Overage);
        }
    }
}
