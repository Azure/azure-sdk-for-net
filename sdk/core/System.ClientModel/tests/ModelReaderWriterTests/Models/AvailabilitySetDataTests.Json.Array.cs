// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal partial class AvailabilitySetDataTests
    {
        private static readonly JsonSerializerOptions s_camelCaseOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        [Test]
        public void AddItemToExistingArrayThatIsEmpty()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"myNewVmId\"}"u8);

            Assert.AreEqual("[{\"id\":\"myNewVmId\"}]", model.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId\"}", model.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myNewVmId\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(1, model2.VirtualMachines.Count);
            Assert.AreEqual("myNewVmId", model2.VirtualMachines[0].Id);

            AssertCommon(model, model2);
        }

        [Test]
        public void AddItemToNewArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);

            Assert.AreEqual("[{\"x\":\"value1\"}]", model.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model.Patch.GetJson("$.newArray[0]"u8).ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"}]}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("[{\"x\":\"value1\"}]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model2.Patch.GetJson("$.newArray[0]"u8).ToString());

            AssertCommon(model, model2);
        }

        [Test]
        public void AddPrimitivesToNewArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, 5);
            model.Patch.Append("$.newArray"u8, 10);

            Assert.AreEqual("[5,10]", model.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("5", model.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("10", model.Patch.GetJson("$.newArray[1]"u8).ToString());
            Assert.AreEqual(5, model.Patch.GetInt32("$.newArray[0]"u8));
            Assert.AreEqual(10, model.Patch.GetInt32("$.newArray[1]"u8));

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[5,10]}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("[5,10]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("5", model2.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("10", model2.Patch.GetJson("$.newArray[1]"u8).ToString());
            Assert.AreEqual(5, model2.Patch.GetInt32("$.newArray[0]"u8));
            Assert.AreEqual(10, model2.Patch.GetInt32("$.newArray[1]"u8));

            AssertCommon(model, model2);
        }

        [Test]
        public void ReplaceEntireArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "5"u8);
            model.Patch.Append("$.newArray"u8, "10"u8);

            Assert.AreEqual("[5,10]", model.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("5", model.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("10", model.Patch.GetJson("$.newArray[1]"u8).ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[5,10]}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("[5,10]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("5", model2.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("10", model2.Patch.GetJson("$.newArray[1]"u8).ToString());

            AssertCommon(model, model2);

            model2.Patch.Set("$.newArray"u8, "[1,2,3]"u8);

            Assert.AreEqual("[1,2,3]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual(1, model2.Patch.GetInt32("$.newArray[0]"u8));
            Assert.AreEqual(2, model2.Patch.GetInt32("$.newArray[1]"u8));
            Assert.AreEqual(3, model2.Patch.GetInt32("$.newArray[2]"u8));

            var data2 = ModelReaderWriter.Write(model2);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[1,2,3]}",
                data2.ToString());

            var model3 = GetRoundTripModel(data2);

            Assert.AreEqual("[1,2,3]", model3.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual(1, model3.Patch.GetInt32("$.newArray[0]"u8));
            Assert.AreEqual(2, model3.Patch.GetInt32("$.newArray[1]"u8));
            Assert.AreEqual(3, model3.Patch.GetInt32("$.newArray[2]"u8));
        }

        [Test]
        public void AddItemToArrayThatIsNotEmpty()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId" });

            model.Patch.Append("$.properties.virtualMachines"u8, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { id = "myNewVmId" }, s_camelCaseOptions)));

            Assert.AreEqual("[{\"id\":\"myNewVmId\"}]", model.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId\"}", model.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("myNewVmId", model.Patch.GetString("$.properties.virtualMachines[0].id"u8));

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId\"},{\"id\":\"myNewVmId\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(2, model2.VirtualMachines.Count);
            Assert.AreEqual("myExistingVmId", model2.VirtualMachines[0].Id);
            Assert.AreEqual("myNewVmId", model2.VirtualMachines[1].Id);

            Assert.AreEqual("[{\"id\":\"myExistingVmId\"},{\"id\":\"myNewVmId\"}]", model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId\"}", model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId\"}", model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString());
            Assert.AreEqual("myExistingVmId", model2.Patch.GetString("$.properties.virtualMachines[0].id"u8));
            Assert.AreEqual("myNewVmId", model2.Patch.GetString("$.properties.virtualMachines[1].id"u8));

            AssertCommon(model, model2);
        }

        [Test]
        public void AddMultipleItemsToExistingArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.properties.virtualMachines"u8, "{\"id\":\"myNewVmId1\"}"u8);
            model.Patch.Append("$.properties.virtualMachines"u8, new WritableSubResource() { Id = "myNewVmId2" });
            model.Patch.Append("$.properties.virtualMachines"u8, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { id = "myNewVmId3" }, s_camelCaseOptions)));
            model.Patch.Append("$.properties.virtualMachines"u8, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { Id = "myNewVmId4" }, s_camelCaseOptions)));

            Assert.AreEqual("[{\"id\":\"myNewVmId1\"},{\"id\":\"myNewVmId2\"},{\"id\":\"myNewVmId3\"},{\"id\":\"myNewVmId4\"}]", model.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId1\"}", model.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId2\"}", model.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId3\"}", model.Patch.GetJson("$.properties.virtualMachines[2]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId4\"}", model.Patch.GetJson("$.properties.virtualMachines[3]"u8).ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myNewVmId1\"},{\"id\":\"myNewVmId2\"},{\"id\":\"myNewVmId3\"},{\"id\":\"myNewVmId4\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(4, model2.VirtualMachines.Count);
            Assert.AreEqual("myNewVmId1", model2.VirtualMachines[0].Id);
            Assert.AreEqual("myNewVmId2", model2.VirtualMachines[1].Id);
            Assert.AreEqual("myNewVmId3", model2.VirtualMachines[2].Id);
            Assert.AreEqual("myNewVmId4", model2.VirtualMachines[3].Id);

            Assert.AreEqual("[{\"id\":\"myNewVmId1\"},{\"id\":\"myNewVmId2\"},{\"id\":\"myNewVmId3\"},{\"id\":\"myNewVmId4\"}]", model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId1\"}", model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId2\"}", model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId3\"}", model2.Patch.GetJson("$.properties.virtualMachines[2]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId4\"}", model2.Patch.GetJson("$.properties.virtualMachines[3]"u8).ToString());
            Assert.AreEqual("myNewVmId1", model2.Patch.GetString("$.properties.virtualMachines[0].id"u8));
            Assert.AreEqual("myNewVmId2", model2.Patch.GetString("$.properties.virtualMachines[1].id"u8));
            Assert.AreEqual("myNewVmId3", model2.Patch.GetString("$.properties.virtualMachines[2].id"u8));
            Assert.AreEqual("myNewVmId4", model2.Patch.GetString("$.properties.virtualMachines[3].id"u8));

            AssertCommon(model, model2);
        }

        [Test]
        public void ReplaceItemInArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);

            Assert.AreEqual("[{\"x\":\"value1\"}]", model.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model.Patch.GetJson("$.newArray[0]"u8).ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"}]}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("[{\"x\":\"value1\"}]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model2.Patch.GetJson("$.newArray[0]"u8).ToString());

            model2.Patch.Set("$.newArray[0]"u8, "{\"x\":\"value2\"}"u8);

            Assert.AreEqual("[{\"x\":\"value2\"}]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value2\"}", model2.Patch.GetJson("$.newArray[0]"u8).ToString());

            var data2 = ModelReaderWriter.Write(model2);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value2\"}]}",
                data2.ToString());

            var model3 = GetRoundTripModel(data2);
            Assert.AreEqual("[{\"x\":\"value2\"}]", model3.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value2\"}", model3.Patch.GetJson("$.newArray[0]"u8).ToString());

            AssertCommon(model, model2);
        }

        [Test]
        public void ReplaceItemInArrayClr()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId2" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId3" });

            var data = ModelReaderWriter.Write(model);

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(3, model2.VirtualMachines.Count);
            Assert.AreEqual("myExistingVmId1", model2.VirtualMachines[0].Id);
            Assert.AreEqual("myExistingVmId2", model2.VirtualMachines[1].Id);
            Assert.AreEqual("myExistingVmId3", model2.VirtualMachines[2].Id);

            Assert.AreEqual("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myExistingVmId2\"},{\"id\":\"myExistingVmId3\"}]", model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId1\"}", model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId2\"}", model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId3\"}", model2.Patch.GetJson("$.properties.virtualMachines[2]"u8).ToString());
            Assert.AreEqual("myExistingVmId1", model2.Patch.GetString("$.properties.virtualMachines[0].id"u8));
            Assert.AreEqual("myExistingVmId2", model2.Patch.GetString("$.properties.virtualMachines[1].id"u8));
            Assert.AreEqual("myExistingVmId3", model2.Patch.GetString("$.properties.virtualMachines[2].id"u8));

            model2.Patch.Set<WritableSubResource>("$.properties.virtualMachines[1]"u8, new WritableSubResource() { Id = "myNewVmId" });

            var data2 = ModelReaderWriter.Write(model2);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId1\"},{\"id\":\"myNewVmId\"},{\"id\":\"myExistingVmId3\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data2.ToString());

            var model3 = GetRoundTripModel(data2);
            Assert.AreEqual(3, model3.VirtualMachines.Count);
            Assert.AreEqual("myExistingVmId1", model3.VirtualMachines[0].Id);
            Assert.AreEqual("myNewVmId", model3.VirtualMachines[1].Id);
            Assert.AreEqual("myExistingVmId3", model3.VirtualMachines[2].Id);

            Assert.AreEqual("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myNewVmId\"},{\"id\":\"myExistingVmId3\"}]", model3.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId1\"}", model3.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId\"}", model3.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId3\"}", model3.Patch.GetJson("$.properties.virtualMachines[2]"u8).ToString());

            Assert.AreEqual("myExistingVmId1", model3.Patch.GetString("$.properties.virtualMachines[0].id"u8));
            Assert.AreEqual("myNewVmId", model3.Patch.GetString("$.properties.virtualMachines[1].id"u8));
            Assert.AreEqual("myExistingVmId3", model3.Patch.GetString("$.properties.virtualMachines[2].id"u8));
        }

        [Test]
        public void ValidateArrayIndexes()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId1" });

            var data = ModelReaderWriter.Write(model);

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(1, model2.VirtualMachines.Count);
            Assert.AreEqual("myExistingVmId1", model2.VirtualMachines[0].Id);

            Assert.AreEqual("[{\"id\":\"myExistingVmId1\"}]", model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId1\"}", model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("myExistingVmId1", model2.Patch.GetString("$.properties.virtualMachines[0].id"u8));

            model2.Patch.Append("$.properties.virtualMachines"u8, new WritableSubResource() { Id = "myNewVmId1" });

            Assert.AreEqual("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myNewVmId1\"}]", model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId1\"}", model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("myExistingVmId1", model2.Patch.GetString("$.properties.virtualMachines[0].id"u8));
            Assert.AreEqual("{\"id\":\"myNewVmId1\"}", model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString());
            Assert.AreEqual("myNewVmId1", model2.Patch.GetString("$.properties.virtualMachines[1].id"u8));

            var data2 = ModelReaderWriter.Write(model2);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId1\"},{\"id\":\"myNewVmId1\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data2.ToString());

            var model3 = GetRoundTripModel(data2);
            Assert.AreEqual(2, model3.VirtualMachines.Count);
            Assert.AreEqual("myExistingVmId1", model3.VirtualMachines[0].Id);
            Assert.AreEqual("myNewVmId1", model3.VirtualMachines[1].Id);

            Assert.AreEqual("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myNewVmId1\"}]", model3.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId1\"}", model3.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId1\"}", model3.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString());

            Assert.AreEqual("myExistingVmId1", model3.Patch.GetString("$.properties.virtualMachines[0].id"u8));
            Assert.AreEqual("myNewVmId1", model3.Patch.GetString("$.properties.virtualMachines[1].id"u8));
        }

        [Test]
        public void RemoveItemFromArrayClr()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId2" });

            model.Patch.Remove("$.properties.virtualMachines[0]"u8);

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId2\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(1, model2.VirtualMachines.Count);
            Assert.AreEqual("myExistingVmId2", model2.VirtualMachines[0].Id);

            Assert.AreEqual("[{\"id\":\"myExistingVmId2\"}]", model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId2\"}", model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());

            AssertCommon(model, model2);
        }

        [Test]
        public void RemoveEntireExistingArray()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId2" });

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId1\"},{\"id\":\"myExistingVmId2\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(2, model2.VirtualMachines.Count);
            Assert.AreEqual("myExistingVmId1", model2.VirtualMachines[0].Id);
            Assert.AreEqual("myExistingVmId2", model2.VirtualMachines[1].Id);

            Assert.AreEqual("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myExistingVmId2\"}]", model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId1\"}", model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId2\"}", model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString());

            model2.Patch.Remove("$.properties.virtualMachines"u8);

            var data2 = ModelReaderWriter.Write(model2);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data2.ToString());

            var model3 = GetRoundTripModel(data2);

            Assert.AreEqual(0, model3.VirtualMachines.Count);

            AssertCommon(model, model2);
        }

        [Test]
        public void RemoveInvalidIndexFromArrayClrDoesNothing()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId2" });

            var ex = Assert.Throws<IndexOutOfRangeException>(() => model.Patch.Remove("$.properties.virtualMachines[4]"u8));
            Assert.AreEqual($"Cannot remove non-existing array item at path '$.properties.virtualMachines[4]'.", ex!.Message);

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId1\"},{\"id\":\"myExistingVmId2\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(2, model2.VirtualMachines.Count);
            Assert.AreEqual("myExistingVmId1", model2.VirtualMachines[0].Id);
            Assert.AreEqual("myExistingVmId2", model2.VirtualMachines[1].Id);

            Assert.AreEqual("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myExistingVmId2\"}]", model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId1\"}", model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId2\"}", model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString());

            AssertCommon(model, model2);
        }

        [Test]
        public void RemoveItemFromArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);

            Assert.AreEqual("[{\"x\":\"value1\"}]", model.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model.Patch.GetJson("$.newArray[0]"u8).ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"}]}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("[{\"x\":\"value1\"}]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model2.Patch.GetJson("$.newArray[0]"u8).ToString());

            model2.Patch.Remove("$.newArray[0]"u8);

            var data2 = ModelReaderWriter.Write(model2);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[]}",
                data2.ToString());

            var model3 = GetRoundTripModel(data2);
            Assert.AreEqual("[]", model3.Patch.GetJson("$.newArray"u8).ToString());

            AssertCommon(model2, model3);
        }

        [Test]
        public void RemovePrimitiveFromArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, true);
            model.Patch.Append("$.newArray"u8, false);
            model.Patch.Append("$.newArray"u8, true);

            Assert.AreEqual("[true,false,true]", model.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual(true, model.Patch.GetBoolean("$.newArray[0]"u8));
            Assert.AreEqual(false, model.Patch.GetBoolean("$.newArray[1]"u8));
            Assert.AreEqual(true, model.Patch.GetBoolean("$.newArray[2]"u8));

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[true,false,true]}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("[true,false,true]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual(true, model2.Patch.GetBoolean("$.newArray[0]"u8));
            Assert.AreEqual(false, model2.Patch.GetBoolean("$.newArray[1]"u8));
            Assert.AreEqual(true, model2.Patch.GetBoolean("$.newArray[2]"u8));

            model2.Patch.Remove("$.newArray[1]"u8);

            var data2 = ModelReaderWriter.Write(model2);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[true,true]}",
                data2.ToString());

            var model3 = GetRoundTripModel(data2);
            Assert.AreEqual("[true,true]", model3.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual(true, model3.Patch.GetBoolean("$.newArray[0]"u8));
            Assert.AreEqual(true, model3.Patch.GetBoolean("$.newArray[1]"u8));

            AssertCommon(model2, model3);
        }

        [Test]
        public void RemoveItemFromArrayMulti()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);
            model.Patch.Append("$.newArray"u8, "{\"x\":\"value2\"}"u8);

            Assert.AreEqual("[{\"x\":\"value1\"},{\"x\":\"value2\"}]", model.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("{\"x\":\"value2\"}", model.Patch.GetJson("$.newArray[1]"u8).ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"},{\"x\":\"value2\"}]}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("[{\"x\":\"value1\"},{\"x\":\"value2\"}]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model2.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("{\"x\":\"value2\"}", model2.Patch.GetJson("$.newArray[1]"u8).ToString());

            model2.Patch.Remove("$.newArray[0]"u8);

            var data2 = ModelReaderWriter.Write(model2);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value2\"}]}",
                data2.ToString());

            var model3 = GetRoundTripModel(data2);
            Assert.AreEqual("[{\"x\":\"value2\"}]", model3.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value2\"}", model3.Patch.GetJson("$.newArray[0]"u8).ToString());

            AssertCommon(model2, model3);
        }

        [Test]
        public void RemoveMiddelItemFromArrayMulti()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);
            model.Patch.Append("$.newArray"u8, "{\"x\":\"value2\"}"u8);
            model.Patch.Append("$.newArray"u8, "{\"x\":\"value3\"}"u8);

            Assert.AreEqual("[{\"x\":\"value1\"},{\"x\":\"value2\"},{\"x\":\"value3\"}]", model.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("{\"x\":\"value2\"}", model.Patch.GetJson("$.newArray[1]"u8).ToString());
            Assert.AreEqual("{\"x\":\"value3\"}", model.Patch.GetJson("$.newArray[2]"u8).ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"},{\"x\":\"value2\"},{\"x\":\"value3\"}]}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("[{\"x\":\"value1\"},{\"x\":\"value2\"},{\"x\":\"value3\"}]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model2.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("{\"x\":\"value2\"}", model2.Patch.GetJson("$.newArray[1]"u8).ToString());
            Assert.AreEqual("{\"x\":\"value3\"}", model2.Patch.GetJson("$.newArray[2]"u8).ToString());

            model2.Patch.Remove("$.newArray[1]"u8);

            var data2 = ModelReaderWriter.Write(model2);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"},{\"x\":\"value3\"}]}",
                data2.ToString());

            var model3 = GetRoundTripModel(data2);
            Assert.AreEqual("[{\"x\":\"value1\"},{\"x\":\"value3\"}]", model3.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model3.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("{\"x\":\"value3\"}", model3.Patch.GetJson("$.newArray[1]"u8).ToString());

            AssertCommon(model2, model3);
        }

        [Test]
        public void AddPropertyToItemInArray()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId" });

            model.Patch.Set("$.properties.virtualMachines[0].newProperty"u8, "propertyValue");
            model.VirtualMachines[0].Patch.Set("$.newPropFromArrayItem"u8, "propertyValue");

            Assert.AreEqual("propertyValue", model.Patch.GetString("$.properties.virtualMachines[0].newProperty"u8));
            Assert.AreEqual("propertyValue", model.VirtualMachines[0].Patch.GetString("$.newPropFromArrayItem"u8));

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId\",\"newProperty\":\"propertyValue\",\"newPropFromArrayItem\":\"propertyValue\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(1, model2.VirtualMachines.Count);
            Assert.AreEqual("propertyValue", model2.VirtualMachines[0].Patch.GetString("$.newProperty"u8));
            Assert.AreEqual("propertyValue", model2.VirtualMachines[0].Patch.GetString("$.newPropFromArrayItem"u8));

            AssertCommon(model, model2);
        }

        [Test]
        public void ChangePropertyInItemInArray()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId" });

            model.Patch.Set("$.properties.virtualMachines[0].id"u8, "changedVmId");

            Assert.AreEqual("changedVmId", model.Patch.GetString("$.properties.virtualMachines[0].id"u8));

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"changedVmId\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(1, model2.VirtualMachines.Count);
            Assert.AreEqual("changedVmId", model2.VirtualMachines[0].Id);

            AssertCommon(model, model2);
        }

        [Test]
        public void RemovePropertyFromItemInArrayClr()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId2" });

            model.Patch.Remove("$.properties.virtualMachines[0].id"u8);

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{},{\"id\":\"myExistingVmId2\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(2, model2.VirtualMachines.Count);
            Assert.AreEqual(null, model2.VirtualMachines[0].Id);
            Assert.AreEqual("myExistingVmId2", model2.VirtualMachines[1].Id);

            Assert.AreEqual("[{},{\"id\":\"myExistingVmId2\"}]", model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{}", model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("{\"id\":\"myExistingVmId2\"}", model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString());

            AssertCommon(model, model2);
        }
        [Test]
        public void RemovePropertyFromItemInArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);
            model.Patch.Append("$.newArray"u8, "{\"x\":\"value2\"}"u8);

            Assert.AreEqual("[{\"x\":\"value1\"},{\"x\":\"value2\"}]", model.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("{\"x\":\"value2\"}", model.Patch.GetJson("$.newArray[1]"u8).ToString());

            model.Patch.Remove("$.newArray[1].x"u8);

            Assert.AreEqual("[{\"x\":\"value1\"},{}]", model.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("{}", model.Patch.GetJson("$.newArray[1]"u8).ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"},{}]}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("[{\"x\":\"value1\"},{}]", model2.Patch.GetJson("$.newArray"u8).ToString());
            Assert.AreEqual("{\"x\":\"value1\"}", model2.Patch.GetJson("$.newArray[0]"u8).ToString());
            Assert.AreEqual("{}", model2.Patch.GetJson("$.newArray[1]"u8).ToString());

            AssertCommon(model, model2);
        }

        [Test]
        public void GetPropertyFromUnknownArrayEntry()
        {
            var model = GetInitialModel();

            Assert.Throws<InvalidOperationException>(() => model.Patch.GetString("$.properties.unknownArray[0].id"u8));
        }

        [Test]
        public void AddItemToRootArray()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/List/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<ListOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model);
            Assert.AreEqual(2, model!.Items.Count);
            Assert.AreEqual("testAS-3375", model.Items[0].Name);
            Assert.AreEqual("testAS-3376", model.Items[1].Name);
            Assert.AreEqual("testAS-3375", model.Patch.GetString("$[0].name"u8));
            Assert.AreEqual("testAS-3376", model.Patch.GetString("$[1].name"u8));

            model.Patch.Append("$"u8, new AvailabilitySetData(AzureLocation.BrazilSouth)
            {
                Name = "testAS-3377",
                Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377",
                ResourceType = "Microsoft.Compute/availabilitySets",
            });

            var data = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
            Assert.AreEqual(
                "[{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3}},{\"name\":\"testAS-3376\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3376\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":6,\"platformFaultDomainCount\":4}},{\"name\":\"testAS-3377\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377\",\"type\":\"Microsoft.Compute/availabilitySets\",\"location\":\"brazilsouth\",\"properties\":{}}]",
                data.ToString());

            var model2 = ModelReaderWriter.Read<ListOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.IsNotNull(model2);
            Assert.AreEqual(3, model2!.Items.Count);
            Assert.AreEqual("testAS-3375", model2.Items[0].Name);
            Assert.AreEqual("testAS-3376", model2.Items[1].Name);
            Assert.AreEqual("testAS-3377", model2.Items[2].Name);
            Assert.AreEqual("testAS-3375", model2.Patch.GetString("$[0].name"u8));
            Assert.AreEqual("testAS-3376", model2.Patch.GetString("$[1].name"u8));
            Assert.AreEqual("testAS-3377", model2.Patch.GetString("$[2].name"u8));

            Assert.AreEqual("brazilsouth", model2.Items[2].Location.ToString());
            Assert.AreEqual("brazilsouth", model2.Patch.GetString("$[2].location"u8));
        }

        [Test]
        public void DoubleSerializeArray()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId" });

            model.Patch.Append("$.properties.virtualMachines"u8, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { id = "myNewVmId" }, s_camelCaseOptions)));

            Assert.AreEqual("[{\"id\":\"myNewVmId\"}]", model.Patch.GetJson("$.properties.virtualMachines"u8).ToString());
            Assert.AreEqual("{\"id\":\"myNewVmId\"}", model.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString());
            Assert.AreEqual("myNewVmId", model.Patch.GetString("$.properties.virtualMachines[0].id"u8));

            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId\"},{\"id\":\"myNewVmId\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                ModelReaderWriter.Write(model).ToString());

            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId\"},{\"id\":\"myNewVmId\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                ModelReaderWriter.Write(model).ToString());
        }
    }
}
