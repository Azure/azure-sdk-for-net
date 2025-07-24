// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal partial class AvailabilitySetDataTests
    {
        [Test]
        public void AddItemToArrayThatIsEmpty()
        {
            var model = GetInitialModel();

            model.Patch.Set("properties/virtualMachines/-"u8, "{\"id\":\"myNewVmId\"}"u8);

            Assert.AreEqual("{\"id\":\"myNewVmId\"}"u8.ToArray(), model.Patch.GetJson("properties/virtualMachines/-"u8).ToArray());

            var data = WriteModifiedModel(model, "virtualMachines", "[{\"id\":\"myNewVmId\"}]");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(1, model2.VirtualMachines.Count);
            Assert.AreEqual("myNewVmId", model2.VirtualMachines[0].Id);

            AssertCommon(model, model2);
        }

        [Test]
        public void ReplaceEntireArray()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void AddItemToArrayThatIsNotEmpty()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void AddTwoItemsToArray()
        {
            var model = GetInitialModel();

            model.Patch.Set("properties/virtualMachines/-"u8, "{\"id\":\"myNewVmId1\"}"u8);
            model.Patch.Set("properties/virtualMachines/-"u8, new WritableSubResource() { Id = "myNewVmId2" });
            model.Patch.Set("properties/virtualMachines/-"u8, new { id = "myNewVmId3" });
            model.Patch.Set("properties/virtualMachines/-"u8, new { Id = "myNewVmId4" });

            Assert.AreEqual("{\"id\":\"myNewVmId1\"},{\"id\":\"myNewVmId2\"},{\"id\":\"myNewVmId3\"},{\"id\":\"myNewVmId4\"}"u8.ToArray(), model.Patch.GetJson("properties/virtualMachines/-"u8).ToArray());
            Assert.AreEqual("{\"id\":\"myNewVmId1\"}"u8.ToArray(), model.Patch.GetJson("properties/virtualMachines/0"u8).ToArray());
            Assert.AreEqual("{\"id\":\"myNewVmId2\"}"u8.ToArray(), model.Patch.GetJson("properties/virtualMachines/1"u8).ToArray());
            Assert.AreEqual("{\"id\":\"myNewVmId3\"}"u8.ToArray(), model.Patch.GetJson("properties/virtualMachines/2"u8).ToArray());
            Assert.AreEqual("{\"id\":\"myNewVmId4\"}"u8.ToArray(), model.Patch.GetJson("properties/virtualMachines/3"u8).ToArray());

            var data = WriteModifiedModel(model, "virtualMachines", "[{\"id\":\"myNewVmId1\"},{\"id\":\"myNewVmId2\"},{\"id\":\"myNewVmId3\"},{\"id\":\"myNewVmId4\"}]");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(4, model2.VirtualMachines.Count);
            Assert.AreEqual("myNewVmId1", model2.VirtualMachines[0].Id);
            Assert.AreEqual("myNewVmId2", model2.VirtualMachines[1].Id);
            Assert.AreEqual("myNewVmId3", model2.VirtualMachines[2].Id);
            Assert.AreEqual("myNewVmId4", model2.VirtualMachines[3].Id);

            AssertCommon(model, model2);
        }

        [Test]
        public void ReplaceItemInArray()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void RemoveItemFromArray()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void AddPropertyToItemInArray()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void ChangePropertyInItemInArray()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void RemovePropertyFromItemInArray()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void GetPropertyFromUnknownArrayEntry()
        {
            Assert.Fail("Not implemented");
        }

        [Test]
        public void AddItemToRootArray()
        {
            Assert.Fail("Not implemented");
        }
    }
}
