// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Batch.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Batch.Tests
{
    public class BatchVmConfigurationTests
    {
        [Test]
        public void ResiliencyZoneAllocationPolicyIsInitiallyNull()
        {
            var configuration = CreateConfiguration();

            Assert.That(configuration.ResiliencyZoneAllocationPolicy, Is.Null);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void ResiliencyZoneAllocationPolicyCanBeCleared(bool setPolicyFirst)
        {
            var configuration = CreateConfiguration();
            if (setPolicyFirst)
            {
                configuration.ResiliencyZoneAllocationPolicy = new ZoneAllocationPolicy { MaxZoneCount = 2 };
            }

            Assert.DoesNotThrow(() => configuration.ResiliencyZoneAllocationPolicy = null);
            Assert.That(configuration.ResiliencyZoneAllocationPolicy, Is.Null);
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(configuration));
            Assert.That(json.RootElement.TryGetProperty("resiliencyPolicy", out _), Is.False);
        }

        [Test]
        public void ResiliencyZoneAllocationPolicyCanBeReassignedAfterClearing()
        {
            var configuration = CreateConfiguration();
            configuration.ResiliencyZoneAllocationPolicy = new ZoneAllocationPolicy { MaxZoneCount = 2 };
            configuration.ResiliencyZoneAllocationPolicy = null;
            var policy = new ZoneAllocationPolicy { MaxZoneCount = 3 };

            configuration.ResiliencyZoneAllocationPolicy = policy;

            Assert.That(configuration.ResiliencyZoneAllocationPolicy, Is.SameAs(policy));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(configuration));
            Assert.That(json.RootElement.GetProperty("resiliencyPolicy").GetProperty("zoneAllocationPolicy").GetProperty("maxZoneCount").GetInt32(), Is.EqualTo(3));
        }

        [Test]
        public void DeserializedResiliencyZoneAllocationPolicyCanBeCleared()
        {
            var configuration = CreateConfiguration();
            configuration.ResiliencyZoneAllocationPolicy = new ZoneAllocationPolicy { MaxZoneCount = 2 };
            var deserialized = ModelReaderWriter.Read<BatchVmConfiguration>(ModelReaderWriter.Write(configuration));
            Assert.That(deserialized.ResiliencyZoneAllocationPolicy.MaxZoneCount, Is.EqualTo(2));

            deserialized.ResiliencyZoneAllocationPolicy = null;

            Assert.That(deserialized.ResiliencyZoneAllocationPolicy, Is.Null);
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(deserialized));
            Assert.That(json.RootElement.TryGetProperty("resiliencyPolicy", out _), Is.False);
        }

        [Test]
        public void HardwareVmSizePropertiesPreserveWireNames()
        {
            var configuration = CreateConfiguration();
            configuration.HardwareVmSizeProperties = new VmSizeProperties
            {
                VcpusAvailable = 2,
                VcpusPerCore = 1
            };

            using var json = JsonDocument.Parse(ModelReaderWriter.Write(configuration));
            var properties = json.RootElement.GetProperty("hardwareProfile").GetProperty("vmSizeProperties");
            Assert.That(properties.GetProperty("vCPUsAvailable").GetInt32(), Is.EqualTo(2));
            Assert.That(properties.GetProperty("vCPUsPerCore").GetInt32(), Is.EqualTo(1));
        }

        private static BatchVmConfiguration CreateConfiguration()
        {
            return new BatchVmConfiguration(new BatchImageReference(), "batch.node.ubuntu 22.04");
        }
    }
}
