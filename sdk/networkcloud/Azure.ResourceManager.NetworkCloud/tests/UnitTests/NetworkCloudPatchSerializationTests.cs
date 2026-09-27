// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.NetworkCloud.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.NetworkCloud.Tests
{
    public class NetworkCloudPatchSerializationTests
    {
        private static readonly ModelReaderWriterOptions WireOptions = new ModelReaderWriterOptions("W");

        [Test]
        public void EmptyClusterPatchOmitsProperties()
        {
            var patch = new NetworkCloudClusterPatch();

            using JsonDocument document = Serialize(patch);

            Assert.That(document.RootElement.TryGetProperty("properties", out _), Is.False);
        }

        [Test]
        public void SparsePatchModelsDoNotSerializeDefaultValues()
        {
            var patch = new NetworkCloudClusterPatch
            {
                ComputeDeploymentThresholdPatch = new ValidationThresholdPatch(),
                UpdateStrategyPatch = new ClusterUpdateStrategyPatch(),
                RuntimeProtectionConfiguration = new RuntimeProtectionConfigurationPatch()
            };

            using JsonDocument document = Serialize(patch);
            JsonElement properties = document.RootElement.GetProperty("properties");

            Assert.That(properties.GetProperty("computeDeploymentThreshold").EnumerateObject().MoveNext(), Is.False);
            Assert.That(properties.GetProperty("updateStrategy").EnumerateObject().MoveNext(), Is.False);
            Assert.That(properties.GetProperty("runtimeProtectionConfiguration").EnumerateObject().MoveNext(), Is.False);
        }

        [Test]
        public void SparseVirtualMachineCredentialsDoNotSerializeUnsetFields()
        {
            var patch = new NetworkCloudVirtualMachinePatch
            {
                VmImageRepositoryCredentialsPatch = new ImageRepositoryCredentialsPatch()
            };

            using JsonDocument document = Serialize(patch);
            JsonElement credentials = document.RootElement
                .GetProperty("properties")
                .GetProperty("vmImageRepositoryCredentials");

            Assert.That(credentials.EnumerateObject().MoveNext(), Is.False);
        }

        [Test]
        public void ReadingLegacyPropertyDoesNotChangeSparseSerialization()
        {
            var patch = new NetworkCloudClusterPatch
            {
                ComputeDeploymentThresholdPatch = new ValidationThresholdPatch()
            };

            ValidationThreshold legacyThreshold = patch.ComputeDeploymentThreshold;

            Assert.That(legacyThreshold.Value, Is.Zero);
            using JsonDocument document = Serialize(patch);
            Assert.That(
                document.RootElement
                    .GetProperty("properties")
                    .GetProperty("computeDeploymentThreshold")
                    .EnumerateObject()
                    .MoveNext(),
                Is.False);
        }

        [Test]
        public void AssigningLegacyConversionMaterializesRequiredDefaults()
        {
            var patch = new NetworkCloudClusterPatch
            {
                ComputeDeploymentThresholdPatch = new ValidationThresholdPatch()
            };

            patch.ComputeDeploymentThreshold = patch.ComputeDeploymentThreshold;

            using JsonDocument document = Serialize(patch);
            JsonElement threshold = document.RootElement
                .GetProperty("properties")
                .GetProperty("computeDeploymentThreshold");

            Assert.That(threshold.GetProperty("grouping").GetString(), Is.EqualTo(default(ValidationThresholdGrouping).ToString()));
            Assert.That(threshold.GetProperty("type").GetString(), Is.EqualTo(default(ValidationThresholdType).ToString()));
            Assert.That(threshold.GetProperty("value").GetInt64(), Is.Zero);
        }

        [Test]
        public void LegacyUpdateStrategyConversionMaterializesRequiredDefaults()
        {
            var patch = new NetworkCloudClusterPatch
            {
                UpdateStrategyPatch = new ClusterUpdateStrategyPatch()
            };

            ClusterUpdateStrategy legacyStrategy = patch.UpdateStrategy;

            Assert.That(legacyStrategy.StrategyType, Is.EqualTo(default(ClusterUpdateStrategyType)));
            Assert.That(legacyStrategy.ThresholdType, Is.EqualTo(default(ValidationThresholdType)));
            Assert.That(legacyStrategy.ThresholdValue, Is.Zero);
        }

        [Test]
        public void LegacyRackConversionMaterializesRequiredRackSlots()
        {
            var rackPatch = new NetworkCloudRackDefinitionPatch();
            rackPatch.BareMetalMachineConfigurationData.Add(new BareMetalMachineConfigurationPatch());
            rackPatch.StorageApplianceConfigurationData.Add(new StorageApplianceConfigurationPatch());
            var patch = new NetworkCloudClusterPatch
            {
                AggregatorOrSingleRackDefinitionPatch = rackPatch
            };

            NetworkCloudRackDefinition legacyRack = patch.AggregatorOrSingleRackDefinition;

            Assert.That(legacyRack.BareMetalMachineConfigurationData[0].RackSlot, Is.Zero);
            Assert.That(legacyRack.StorageApplianceConfigurationData[0].RackSlot, Is.Zero);
        }

        private static JsonDocument Serialize<T>(T model)
        {
            BinaryData data = ModelReaderWriter.Write(model, WireOptions, AzureResourceManagerNetworkCloudContext.Default);
            return JsonDocument.Parse(data);
        }
    }
}
