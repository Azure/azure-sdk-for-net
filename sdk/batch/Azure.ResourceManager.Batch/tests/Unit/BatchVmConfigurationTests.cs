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
        [TestCase(false)]
        [TestCase(true)]
        public void ResiliencyZoneAllocationPolicyCanBeCleared(bool setPolicyFirst)
        {
            var configuration = CreateConfiguration();
            Assert.That(configuration.ResiliencyZoneAllocationPolicy, Is.Null);
            if (setPolicyFirst)
            {
                var policy = new ZoneAllocationPolicy { MaxZoneCount = 2 };
                configuration.ResiliencyZoneAllocationPolicy = policy;
                Assert.That(configuration.ResiliencyZoneAllocationPolicy, Is.SameAs(policy));
            }

            Assert.DoesNotThrow(() => configuration.ResiliencyZoneAllocationPolicy = null);

            Assert.That(configuration.ResiliencyZoneAllocationPolicy, Is.Null);
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(configuration, new ModelReaderWriterOptions("W")));
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
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(configuration, new ModelReaderWriterOptions("W")));
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
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(deserialized, new ModelReaderWriterOptions("W")));
            Assert.That(json.RootElement.TryGetProperty("resiliencyPolicy", out _), Is.False);
        }

        private static BatchVmConfiguration CreateConfiguration()
        {
            return new BatchVmConfiguration(new BatchImageReference(), "batch.node.ubuntu 22.04");
        }
    }
}
