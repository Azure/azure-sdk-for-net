// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    public class FlexProfileAndSkuZoneDetailsTests
    {
        [Test]
        public void FlexPreferredVmSizeSerializesToFlexProfile()
        {
            var data = new VirtualMachineData(AzureLocation.WestUS2) { FlexPreferredVmSize = "Standard_D4s_v5" };
            var patch = new VirtualMachinePatch { FlexPreferredVmSize = "Standard_D8s_v5" };

            Assert.AreEqual("Standard_D4s_v5", GetFlexProfile(data).GetProperty("preferredVMSize").GetString());
            Assert.AreEqual("Standard_D8s_v5", GetFlexProfile(patch).GetProperty("preferredVMSize").GetString());
        }

        [TestCase(false)]
        [TestCase(true)]
        public void VirtualMachineFlexPreferredVmSizeCanBeCleared(bool deserialize)
        {
            var data = deserialize
                ? ModelReaderWriter.Read<VirtualMachineData>(BinaryData.FromString(
                    "{\"location\":\"westus2\",\"properties\":{\"flexProfile\":{\"preferredVMSize\":\"Standard_D4s_v5\"}}}"))
                : new VirtualMachineData(AzureLocation.WestUS2) { FlexPreferredVmSize = "Standard_D4s_v5" };

            Assert.AreEqual("Standard_D4s_v5", data.FlexPreferredVmSize);
            data.FlexPreferredVmSize = "Standard_D8s_v5";
            Assert.AreEqual("Standard_D8s_v5", GetFlexProfile(data).GetProperty("preferredVMSize").GetString());

            data.FlexPreferredVmSize = null;
            data.HardwareProfile = new VirtualMachineHardwareProfile { VmSize = "Standard_D4s_v5" };

            Assert.IsNull(data.FlexPreferredVmSize);
            using var document = JsonDocument.Parse(ModelReaderWriter.Write(data, new ModelReaderWriterOptions("W")));
            var properties = document.RootElement.GetProperty("properties");
            Assert.IsFalse(properties.TryGetProperty("flexProfile", out _));
            Assert.AreEqual("Standard_D4s_v5", properties.GetProperty("hardwareProfile").GetProperty("vmSize").GetString());

            data.FlexPreferredVmSize = "Standard_D4s_v5";
            Assert.AreEqual("Standard_D4s_v5", GetFlexProfile(data).GetProperty("preferredVMSize").GetString());
        }

        [TestCase(false)]
        [TestCase(true)]
        public void VirtualMachinePatchFlexPreferredVmSizeCanBeCleared(bool deserialize)
        {
            var patch = deserialize
                ? ModelReaderWriter.Read<VirtualMachinePatch>(BinaryData.FromString(
                    "{\"properties\":{\"flexProfile\":{\"preferredVMSize\":\"Standard_D4s_v5\"}}}"))
                : new VirtualMachinePatch { FlexPreferredVmSize = "Standard_D4s_v5" };

            Assert.AreEqual("Standard_D4s_v5", patch.FlexPreferredVmSize);
            patch.FlexPreferredVmSize = "Standard_D8s_v5";
            Assert.AreEqual("Standard_D8s_v5", GetFlexProfile(patch).GetProperty("preferredVMSize").GetString());

            patch.FlexPreferredVmSize = null;

            Assert.IsNull(patch.FlexPreferredVmSize);
            AssertFlexProfileIsOmitted(patch);

            patch.FlexPreferredVmSize = "Standard_D4s_v5";
            Assert.AreEqual("Standard_D4s_v5", GetFlexProfile(patch).GetProperty("preferredVMSize").GetString());
        }

        [Test]
        public void UnsetFlexPreferredVmSizeCanBeCleared()
        {
            var data = new VirtualMachineData(AzureLocation.WestUS2);
            var patch = new VirtualMachinePatch();

            data.FlexPreferredVmSize = null;
            data.FlexPreferredVmSize = null;
            patch.FlexPreferredVmSize = null;
            patch.FlexPreferredVmSize = null;

            Assert.IsNull(data.FlexPreferredVmSize);
            Assert.IsNull(patch.FlexPreferredVmSize);
            AssertFlexProfileIsOmitted(data);
            AssertFlexProfileIsOmitted(patch);
        }

        [Test]
        public void SkuZoneDetailsReadsName()
        {
            var json = BinaryData.FromString("{\"Name\":[\"1\",\"2\"],\"capabilities\":[]}");

            var details = ModelReaderWriter.Read<ComputeResourceSkuZoneDetails>(json);

            CollectionAssert.AreEqual(new[] { "1", "2" }, details.Name);
        }

        [Test]
        public void SkuZoneDetailsRoundTripsName()
        {
            var original = ModelReaderWriter.Read<ComputeResourceSkuZoneDetails>(BinaryData.FromString("{\"Name\":[\"3\"]}"));

            var roundTripped = ModelReaderWriter.Read<ComputeResourceSkuZoneDetails>(ModelReaderWriter.Write(original));

            CollectionAssert.AreEqual(new[] { "3" }, roundTripped.Name);
        }

        private static JsonElement GetFlexProfile<T>(T model) where T : IPersistableModel<T>
        {
            using var document = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            return document.RootElement.GetProperty("properties").GetProperty("flexProfile").Clone();
        }

        private static void AssertFlexProfileIsOmitted<T>(T model) where T : IPersistableModel<T>
        {
            using var document = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            Assert.IsFalse(document.RootElement.GetProperty("properties").TryGetProperty("flexProfile", out _));
        }
    }
}
