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

        [TestCase("Name")]
        [TestCase("name")]
        public void SkuZoneDetailsReadsNameWithEitherCasing(string propertyName)
        {
            var json = BinaryData.FromString($"{{\"{propertyName}\":[\"1\",\"2\"],\"capabilities\":[]}}");

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
    }
}
