// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.ModelReaderWriterTests.Models;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.Collections.Generic;
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

            Assert.That(model.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myNewVmId\"}]"));
            Assert.That(model.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId\"}"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myNewVmId\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(1));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo("myNewVmId"));

            AssertCommon(model, model2);
        }

        [Test]
        public void AddItemToNewArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);

            Assert.That(model.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"}]"));
            Assert.That(model.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"}]}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"}]"));
            Assert.That(model2.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));

            AssertCommon(model, model2);
        }

        [Test]
        public void AddPrimitivesToNewArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, 5);
            model.Patch.Append("$.newArray"u8, 10);

            Assert.That(model.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[5,10]"));
            Assert.That(model.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("5"));
            Assert.That(model.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("10"));
            Assert.That(model.Patch.GetInt32("$.newArray[0]"u8), Is.EqualTo(5));
            Assert.That(model.Patch.GetInt32("$.newArray[1]"u8), Is.EqualTo(10));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[5,10]}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[5,10]"));
            Assert.That(model2.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("5"));
            Assert.That(model2.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("10"));
            Assert.That(model2.Patch.GetInt32("$.newArray[0]"u8), Is.EqualTo(5));
            Assert.That(model2.Patch.GetInt32("$.newArray[1]"u8), Is.EqualTo(10));

            AssertCommon(model, model2);
        }

        [Test]
        public void ReplaceEntireArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "5"u8);
            model.Patch.Append("$.newArray"u8, "10"u8);

            Assert.That(model.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[5,10]"));
            Assert.That(model.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("5"));
            Assert.That(model.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("10"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[5,10]}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[5,10]"));
            Assert.That(model2.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("5"));
            Assert.That(model2.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("10"));

            AssertCommon(model, model2);

            model2.Patch.Set("$.newArray"u8, "[1,2,3]"u8);

            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[1,2,3]"));
            Assert.That(model2.Patch.GetInt32("$.newArray[0]"u8), Is.EqualTo(1));
            Assert.That(model2.Patch.GetInt32("$.newArray[1]"u8), Is.EqualTo(2));
            Assert.That(model2.Patch.GetInt32("$.newArray[2]"u8), Is.EqualTo(3));

            var data2 = ModelReaderWriter.Write(model2);
            Assert.That(
                data2.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[1,2,3]}"));

            var model3 = GetRoundTripModel(data2);

            Assert.That(model3.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[1,2,3]"));
            Assert.That(model3.Patch.GetInt32("$.newArray[0]"u8), Is.EqualTo(1));
            Assert.That(model3.Patch.GetInt32("$.newArray[1]"u8), Is.EqualTo(2));
            Assert.That(model3.Patch.GetInt32("$.newArray[2]"u8), Is.EqualTo(3));
        }

        [Test]
        public void AddItemToArrayThatIsNotEmpty()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId" });

            model.Patch.Append("$.properties.virtualMachines"u8, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { id = "myNewVmId" }, s_camelCaseOptions)));

            Assert.That(model.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myNewVmId\"}]"));
            Assert.That(model.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId\"}"));
            Assert.That(model.Patch.GetString("$.properties.virtualMachines[0].id"u8), Is.EqualTo("myNewVmId"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId\"},{\"id\":\"myNewVmId\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(2));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo("myExistingVmId"));
            Assert.That(model2.VirtualMachines[1].Id, Is.EqualTo("myNewVmId"));

            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myExistingVmId\"},{\"id\":\"myNewVmId\"}]"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId\"}"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId\"}"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[0].id"u8), Is.EqualTo("myExistingVmId"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[1].id"u8), Is.EqualTo("myNewVmId"));

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

            Assert.That(model.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myNewVmId1\"},{\"id\":\"myNewVmId2\"},{\"id\":\"myNewVmId3\"},{\"id\":\"myNewVmId4\"}]"));
            Assert.That(model.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId1\"}"));
            Assert.That(model.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId2\"}"));
            Assert.That(model.Patch.GetJson("$.properties.virtualMachines[2]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId3\"}"));
            Assert.That(model.Patch.GetJson("$.properties.virtualMachines[3]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId4\"}"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myNewVmId1\"},{\"id\":\"myNewVmId2\"},{\"id\":\"myNewVmId3\"},{\"id\":\"myNewVmId4\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(4));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo("myNewVmId1"));
            Assert.That(model2.VirtualMachines[1].Id, Is.EqualTo("myNewVmId2"));
            Assert.That(model2.VirtualMachines[2].Id, Is.EqualTo("myNewVmId3"));
            Assert.That(model2.VirtualMachines[3].Id, Is.EqualTo("myNewVmId4"));

            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myNewVmId1\"},{\"id\":\"myNewVmId2\"},{\"id\":\"myNewVmId3\"},{\"id\":\"myNewVmId4\"}]"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId1\"}"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId2\"}"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[2]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId3\"}"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[3]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId4\"}"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[0].id"u8), Is.EqualTo("myNewVmId1"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[1].id"u8), Is.EqualTo("myNewVmId2"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[2].id"u8), Is.EqualTo("myNewVmId3"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[3].id"u8), Is.EqualTo("myNewVmId4"));

            AssertCommon(model, model2);
        }

        [Test]
        public void ReplaceItemInArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);

            Assert.That(model.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"}]"));
            Assert.That(model.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"}]}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"}]"));
            Assert.That(model2.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));

            model2.Patch.Set("$.newArray[0]"u8, "{\"x\":\"value2\"}"u8);

            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value2\"}]"));
            Assert.That(model2.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));

            var data2 = ModelReaderWriter.Write(model2);
            Assert.That(
                data2.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value2\"}]}"));

            var model3 = GetRoundTripModel(data2);
            Assert.That(model3.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value2\"}]"));
            Assert.That(model3.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));

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
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(3));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo("myExistingVmId1"));
            Assert.That(model2.VirtualMachines[1].Id, Is.EqualTo("myExistingVmId2"));
            Assert.That(model2.VirtualMachines[2].Id, Is.EqualTo("myExistingVmId3"));

            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myExistingVmId2\"},{\"id\":\"myExistingVmId3\"}]"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId1\"}"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId2\"}"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[2]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId3\"}"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[0].id"u8), Is.EqualTo("myExistingVmId1"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[1].id"u8), Is.EqualTo("myExistingVmId2"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[2].id"u8), Is.EqualTo("myExistingVmId3"));

            model2.Patch.Set<WritableSubResource>("$.properties.virtualMachines[1]"u8, new WritableSubResource() { Id = "myNewVmId" });

            var data2 = ModelReaderWriter.Write(model2);
            Assert.That(
                data2.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId1\"},{\"id\":\"myNewVmId\"},{\"id\":\"myExistingVmId3\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model3 = GetRoundTripModel(data2);
            Assert.That(model3.VirtualMachines.Count, Is.EqualTo(3));
            Assert.That(model3.VirtualMachines[0].Id, Is.EqualTo("myExistingVmId1"));
            Assert.That(model3.VirtualMachines[1].Id, Is.EqualTo("myNewVmId"));
            Assert.That(model3.VirtualMachines[2].Id, Is.EqualTo("myExistingVmId3"));

            Assert.That(model3.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myNewVmId\"},{\"id\":\"myExistingVmId3\"}]"));
            Assert.That(model3.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId1\"}"));
            Assert.That(model3.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId\"}"));
            Assert.That(model3.Patch.GetJson("$.properties.virtualMachines[2]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId3\"}"));

            Assert.That(model3.Patch.GetString("$.properties.virtualMachines[0].id"u8), Is.EqualTo("myExistingVmId1"));
            Assert.That(model3.Patch.GetString("$.properties.virtualMachines[1].id"u8), Is.EqualTo("myNewVmId"));
            Assert.That(model3.Patch.GetString("$.properties.virtualMachines[2].id"u8), Is.EqualTo("myExistingVmId3"));
        }

        [Test]
        public void ValidateArrayIndexes()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId1" });

            var data = ModelReaderWriter.Write(model);

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(1));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo("myExistingVmId1"));

            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myExistingVmId1\"}]"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId1\"}"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[0].id"u8), Is.EqualTo("myExistingVmId1"));

            model2.Patch.Append("$.properties.virtualMachines"u8, new WritableSubResource() { Id = "myNewVmId1" });

            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myNewVmId1\"}]"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId1\"}"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[0].id"u8), Is.EqualTo("myExistingVmId1"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId1\"}"));
            Assert.That(model2.Patch.GetString("$.properties.virtualMachines[1].id"u8), Is.EqualTo("myNewVmId1"));

            var data2 = ModelReaderWriter.Write(model2);
            Assert.That(
                data2.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId1\"},{\"id\":\"myNewVmId1\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model3 = GetRoundTripModel(data2);
            Assert.That(model3.VirtualMachines.Count, Is.EqualTo(2));
            Assert.That(model3.VirtualMachines[0].Id, Is.EqualTo("myExistingVmId1"));
            Assert.That(model3.VirtualMachines[1].Id, Is.EqualTo("myNewVmId1"));

            Assert.That(model3.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myNewVmId1\"}]"));
            Assert.That(model3.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId1\"}"));
            Assert.That(model3.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId1\"}"));

            Assert.That(model3.Patch.GetString("$.properties.virtualMachines[0].id"u8), Is.EqualTo("myExistingVmId1"));
            Assert.That(model3.Patch.GetString("$.properties.virtualMachines[1].id"u8), Is.EqualTo("myNewVmId1"));
        }

        [Test]
        public void RemoveItemFromArrayClr()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId2" });

            model.Patch.Remove("$.properties.virtualMachines[0]"u8);

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId2\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(1));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo("myExistingVmId2"));

            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myExistingVmId2\"}]"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId2\"}"));

            AssertCommon(model, model2);
        }

        [Test]
        public void RemoveEntireExistingArray()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId2" });

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId1\"},{\"id\":\"myExistingVmId2\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(2));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo("myExistingVmId1"));
            Assert.That(model2.VirtualMachines[1].Id, Is.EqualTo("myExistingVmId2"));

            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myExistingVmId2\"}]"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId1\"}"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId2\"}"));

            model2.Patch.Remove("$.properties.virtualMachines"u8);

            var data2 = ModelReaderWriter.Write(model2);
            Assert.That(
                data2.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model3 = GetRoundTripModel(data2);

            Assert.That(model3.VirtualMachines.Count, Is.EqualTo(0));

            AssertCommon(model, model2);
        }

        [Test]
        public void RemoveInvalidIndexFromArrayClrDoesNothing()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId1" });
            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId2" });

            var ex = Assert.Throws<IndexOutOfRangeException>(() => model.Patch.Remove("$.properties.virtualMachines[4]"u8));
            Assert.That(ex!.Message, Is.EqualTo($"Cannot remove non-existing array item at path '$.properties.virtualMachines[4]'."));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId1\"},{\"id\":\"myExistingVmId2\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(2));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo("myExistingVmId1"));
            Assert.That(model2.VirtualMachines[1].Id, Is.EqualTo("myExistingVmId2"));

            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myExistingVmId1\"},{\"id\":\"myExistingVmId2\"}]"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId1\"}"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId2\"}"));

            AssertCommon(model, model2);
        }

        [Test]
        public void RemoveItemFromArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);

            Assert.That(model.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"}]"));
            Assert.That(model.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"}]}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"}]"));
            Assert.That(model2.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));

            model2.Patch.Remove("$.newArray[0]"u8);

            var data2 = ModelReaderWriter.Write(model2);
            Assert.That(
                data2.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[]}"));

            var model3 = GetRoundTripModel(data2);
            Assert.That(model3.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[]"));

            AssertCommon(model2, model3);
        }

        [Test]
        public void RemovePrimitiveFromArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, true);
            model.Patch.Append("$.newArray"u8, false);
            model.Patch.Append("$.newArray"u8, true);

            Assert.That(model.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[true,false,true]"));
            Assert.That(model.Patch.GetBoolean("$.newArray[0]"u8), Is.EqualTo(true));
            Assert.That(model.Patch.GetBoolean("$.newArray[1]"u8), Is.EqualTo(false));
            Assert.That(model.Patch.GetBoolean("$.newArray[2]"u8), Is.EqualTo(true));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[true,false,true]}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[true,false,true]"));
            Assert.That(model2.Patch.GetBoolean("$.newArray[0]"u8), Is.EqualTo(true));
            Assert.That(model2.Patch.GetBoolean("$.newArray[1]"u8), Is.EqualTo(false));
            Assert.That(model2.Patch.GetBoolean("$.newArray[2]"u8), Is.EqualTo(true));

            model2.Patch.Remove("$.newArray[1]"u8);

            var data2 = ModelReaderWriter.Write(model2);
            Assert.That(
                data2.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[true,true]}"));

            var model3 = GetRoundTripModel(data2);
            Assert.That(model3.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[true,true]"));
            Assert.That(model3.Patch.GetBoolean("$.newArray[0]"u8), Is.EqualTo(true));
            Assert.That(model3.Patch.GetBoolean("$.newArray[1]"u8), Is.EqualTo(true));

            AssertCommon(model2, model3);
        }

        [Test]
        public void RemoveItemFromArrayMulti()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);
            model.Patch.Append("$.newArray"u8, "{\"x\":\"value2\"}"u8);

            Assert.That(model.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"},{\"x\":\"value2\"}]"));
            Assert.That(model.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"},{\"x\":\"value2\"}]}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"},{\"x\":\"value2\"}]"));
            Assert.That(model2.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model2.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));

            model2.Patch.Remove("$.newArray[0]"u8);

            var data2 = ModelReaderWriter.Write(model2);
            Assert.That(
                data2.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value2\"}]}"));

            var model3 = GetRoundTripModel(data2);
            Assert.That(model3.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value2\"}]"));
            Assert.That(model3.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));

            AssertCommon(model2, model3);
        }

        [Test]
        public void RemoveMiddelItemFromArrayMulti()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);
            model.Patch.Append("$.newArray"u8, "{\"x\":\"value2\"}"u8);
            model.Patch.Append("$.newArray"u8, "{\"x\":\"value3\"}"u8);

            Assert.That(model.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"},{\"x\":\"value2\"},{\"x\":\"value3\"}]"));
            Assert.That(model.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));
            Assert.That(model.Patch.GetJson("$.newArray[2]"u8).ToString(), Is.EqualTo("{\"x\":\"value3\"}"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"},{\"x\":\"value2\"},{\"x\":\"value3\"}]}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"},{\"x\":\"value2\"},{\"x\":\"value3\"}]"));
            Assert.That(model2.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model2.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));
            Assert.That(model2.Patch.GetJson("$.newArray[2]"u8).ToString(), Is.EqualTo("{\"x\":\"value3\"}"));

            model2.Patch.Remove("$.newArray[1]"u8);

            var data2 = ModelReaderWriter.Write(model2);
            Assert.That(
                data2.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"},{\"x\":\"value3\"}]}"));

            var model3 = GetRoundTripModel(data2);
            Assert.That(model3.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"},{\"x\":\"value3\"}]"));
            Assert.That(model3.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model3.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("{\"x\":\"value3\"}"));

            AssertCommon(model2, model3);
        }

        [Test]
        public void AddPropertyToItemInArray()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId" });

            model.Patch.Set("$.properties.virtualMachines[0].newProperty"u8, "propertyValue");
            model.VirtualMachines[0].Patch.Set("$.newPropFromArrayItem"u8, "propertyValue");

            Assert.That(model.Patch.GetString("$.properties.virtualMachines[0].newProperty"u8), Is.EqualTo("propertyValue"));
            Assert.That(model.VirtualMachines[0].Patch.GetString("$.newPropFromArrayItem"u8), Is.EqualTo("propertyValue"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId\",\"newProperty\":\"propertyValue\",\"newPropFromArrayItem\":\"propertyValue\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(1));
            Assert.That(model2.VirtualMachines[0].Patch.GetString("$.newProperty"u8), Is.EqualTo("propertyValue"));
            Assert.That(model2.VirtualMachines[0].Patch.GetString("$.newPropFromArrayItem"u8), Is.EqualTo("propertyValue"));

            AssertCommon(model, model2);
        }

        [Test]
        public void ChangePropertyInItemInArray()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId" });

            model.Patch.Set("$.properties.virtualMachines[0].id"u8, "changedVmId");

            Assert.That(model.Patch.GetString("$.properties.virtualMachines[0].id"u8), Is.EqualTo("changedVmId"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"changedVmId\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(1));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo("changedVmId"));

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
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{},{\"id\":\"myExistingVmId2\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.VirtualMachines.Count, Is.EqualTo(2));
            Assert.That(model2.VirtualMachines[0].Id, Is.EqualTo(null));
            Assert.That(model2.VirtualMachines[1].Id, Is.EqualTo("myExistingVmId2"));

            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{},{\"id\":\"myExistingVmId2\"}]"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{}"));
            Assert.That(model2.Patch.GetJson("$.properties.virtualMachines[1]"u8).ToString(), Is.EqualTo("{\"id\":\"myExistingVmId2\"}"));

            AssertCommon(model, model2);
        }
        [Test]
        public void RemovePropertyFromItemInArray()
        {
            var model = GetInitialModel();

            model.Patch.Append("$.newArray"u8, "{\"x\":\"value1\"}"u8);
            model.Patch.Append("$.newArray"u8, "{\"x\":\"value2\"}"u8);

            Assert.That(model.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"},{\"x\":\"value2\"}]"));
            Assert.That(model.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("{\"x\":\"value2\"}"));

            model.Patch.Remove("$.newArray[1].x"u8);

            Assert.That(model.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"},{}]"));
            Assert.That(model.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("{}"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"newArray\":[{\"x\":\"value1\"},{}]}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson("$.newArray"u8).ToString(), Is.EqualTo("[{\"x\":\"value1\"},{}]"));
            Assert.That(model2.Patch.GetJson("$.newArray[0]"u8).ToString(), Is.EqualTo("{\"x\":\"value1\"}"));
            Assert.That(model2.Patch.GetJson("$.newArray[1]"u8).ToString(), Is.EqualTo("{}"));

            AssertCommon(model, model2);
        }

        [Test]
        public void GetPropertyFromUnknownArrayEntry()
        {
            var model = GetInitialModel();

            Assert.Throws<KeyNotFoundException>(() => model.Patch.GetString("$.properties.unknownArray[0].id"u8));
        }

        [Test]
        public void AddItemToRootArray()
        {
            var json = File.ReadAllText(TestData.GetLocation("AvailabilitySetData/List/JsonFormat.json")).TrimEnd();

            var model = ModelReaderWriter.Read<ListOfAset>(BinaryData.FromString(json), ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model, Is.Not.Null);
            Assert.That(model!.Items.Count, Is.EqualTo(2));
            Assert.That(model.Items[0].Name, Is.EqualTo("testAS-3375"));
            Assert.That(model.Items[1].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model.Patch.GetString("$[0].name"u8), Is.EqualTo("testAS-3375"));
            Assert.That(model.Patch.GetString("$[1].name"u8), Is.EqualTo("testAS-3376"));

            model.Patch.Append("$"u8, new AvailabilitySetData(AzureLocation.BrazilSouth)
            {
                Name = "testAS-3377",
                Id = "/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377",
                ResourceType = "Microsoft.Compute/availabilitySets",
            });

            var data = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);
            Assert.That(
                data.ToString(),
                Is.EqualTo("[{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3}},{\"name\":\"testAS-3376\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3376\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":6,\"platformFaultDomainCount\":4}},{\"name\":\"testAS-3377\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3377\",\"type\":\"Microsoft.Compute/availabilitySets\",\"location\":\"brazilsouth\",\"properties\":{}}]"));

            var model2 = ModelReaderWriter.Read<ListOfAset>(data, ModelReaderWriterOptions.Json, TestClientModelReaderWriterContext.Default);

            Assert.That(model2, Is.Not.Null);
            Assert.That(model2!.Items.Count, Is.EqualTo(3));
            Assert.That(model2.Items[0].Name, Is.EqualTo("testAS-3375"));
            Assert.That(model2.Items[1].Name, Is.EqualTo("testAS-3376"));
            Assert.That(model2.Items[2].Name, Is.EqualTo("testAS-3377"));
            Assert.That(model2.Patch.GetString("$[0].name"u8), Is.EqualTo("testAS-3375"));
            Assert.That(model2.Patch.GetString("$[1].name"u8), Is.EqualTo("testAS-3376"));
            Assert.That(model2.Patch.GetString("$[2].name"u8), Is.EqualTo("testAS-3377"));

            Assert.That(model2.Items[2].Location.ToString(), Is.EqualTo("brazilsouth"));
            Assert.That(model2.Patch.GetString("$[2].location"u8), Is.EqualTo("brazilsouth"));
        }

        [Test]
        public void DoubleSerializeArray()
        {
            var model = GetInitialModel();

            model.VirtualMachines.Add(new WritableSubResource() { Id = "myExistingVmId" });

            model.Patch.Append("$.properties.virtualMachines"u8, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(new { id = "myNewVmId" }, s_camelCaseOptions)));

            Assert.That(model.Patch.GetJson("$.properties.virtualMachines"u8).ToString(), Is.EqualTo("[{\"id\":\"myNewVmId\"}]"));
            Assert.That(model.Patch.GetJson("$.properties.virtualMachines[0]"u8).ToString(), Is.EqualTo("{\"id\":\"myNewVmId\"}"));
            Assert.That(model.Patch.GetString("$.properties.virtualMachines[0].id"u8), Is.EqualTo("myNewVmId"));

            Assert.That(
                ModelReaderWriter.Write(model).ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId\"},{\"id\":\"myNewVmId\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            Assert.That(
                ModelReaderWriter.Write(model).ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3,\"virtualMachines\":[{\"id\":\"myExistingVmId\"},{\"id\":\"myNewVmId\"}]},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));
        }
    }
}
