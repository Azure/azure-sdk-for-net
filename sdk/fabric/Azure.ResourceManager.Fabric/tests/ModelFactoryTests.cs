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
            CollectionAssert.AreEqual(new[] { "admin@contoso.com" }, patchWithMembers.FabricCapacityUpdateAdministrationMembers);
            Assert.AreSame(properties, patchWithProperties.Properties);
        }
    }
}