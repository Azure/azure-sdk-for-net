// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
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
        public void ReadingAbsentLegacyPropertyDoesNotCreateProperties()
        {
            var patch = new NetworkCloudClusterPatch();

            ServicePrincipalInformation legacyPrincipal = patch.ClusterServicePrincipal;

            Assert.That(legacyPrincipal, Is.Null);
            using JsonDocument document = Serialize(patch);
            Assert.That(document.RootElement.TryGetProperty("properties", out _), Is.False);
        }

        [Test]
        public void ReassigningLegacyConversionPreservesOmittedValues()
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

            Assert.That(threshold.EnumerateObject().MoveNext(), Is.False);
        }

        [Test]
        public void ReassigningLegacyUpdateStrategyPreservesOmittedValues()
        {
            var patch = new NetworkCloudClusterPatch
            {
                UpdateStrategyPatch = new ClusterUpdateStrategyPatch()
            };

            ClusterUpdateStrategy legacyStrategy = patch.UpdateStrategy;

            Assert.That(legacyStrategy.StrategyType, Is.EqualTo(default(ClusterUpdateStrategyType)));
            Assert.That(legacyStrategy.ThresholdType, Is.EqualTo(default(ValidationThresholdType)));
            Assert.That(legacyStrategy.ThresholdValue, Is.Zero);

            patch.UpdateStrategy = legacyStrategy;

            using JsonDocument document = Serialize(patch);
            Assert.That(
                document.RootElement
                    .GetProperty("properties")
                    .GetProperty("updateStrategy")
                    .EnumerateObject()
                    .MoveNext(),
                Is.False);
        }

        [Test]
        public void LegacyRackConversionPreservesOmittedRackSlots()
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

            using JsonDocument document = Serialize(patch);
            JsonElement serializedRack = document.RootElement
                .GetProperty("properties")
                .GetProperty("aggregatorOrSingleRackDefinition");
            Assert.That(
                serializedRack
                    .GetProperty("bareMetalMachineConfigurationData")[0]
                    .TryGetProperty("rackSlot", out _),
                Is.False);
            Assert.That(
                serializedRack
                    .GetProperty("storageApplianceConfigurationData")[0]
                    .TryGetProperty("rackSlot", out _),
                Is.False);
        }

        [Test]
        public void InPlaceLegacyServicePrincipalEditIsSerialized()
        {
            var patch = new NetworkCloudClusterPatch
            {
                ClusterServicePrincipalPatch = new ServicePrincipalInformationPatch
                {
                    Password = "old-password"
                }
            };

            patch.ClusterServicePrincipal.Password = "new-password";

            using JsonDocument document = Serialize(patch);
            Assert.That(
                document.RootElement
                    .GetProperty("properties")
                    .GetProperty("clusterServicePrincipal")
                    .GetProperty("password")
                    .GetString(),
                Is.EqualTo("new-password"));
        }

        [Test]
        public void ReadingLegacyPropertyPreservesAssignedPatchIdentityAndEdits()
        {
            var principal = new ServicePrincipalInformationPatch
            {
                Password = "old-password"
            };
            var patch = new NetworkCloudClusterPatch
            {
                ClusterServicePrincipalPatch = principal
            };

            ServicePrincipalInformation legacyPrincipal = patch.ClusterServicePrincipal;
            principal.Password = "patch-password";

            Assert.That(patch.ClusterServicePrincipalPatch, Is.SameAs(principal));
            Assert.That(legacyPrincipal.Password, Is.EqualTo("patch-password"));

            using JsonDocument document = Serialize(patch);
            Assert.That(
                document.RootElement
                    .GetProperty("properties")
                    .GetProperty("clusterServicePrincipal")
                    .GetProperty("password")
                    .GetString(),
                Is.EqualTo("patch-password"));
        }

        [Test]
        public void InPlaceLegacyVirtualMachineCredentialsEditIsSerialized()
        {
            var patch = new NetworkCloudVirtualMachinePatch
            {
                VmImageRepositoryCredentialsPatch = new ImageRepositoryCredentialsPatch
                {
                    Password = "old-password"
                }
            };

            patch.VmImageRepositoryCredentials.Password = "new-password";

            using JsonDocument document = Serialize(patch);
            Assert.That(
                document.RootElement
                    .GetProperty("properties")
                    .GetProperty("vmImageRepositoryCredentials")
                    .GetProperty("password")
                    .GetString(),
                Is.EqualTo("new-password"));
        }

        [Test]
        public void InPlaceLegacyRackAndNestedCredentialEditsAreSerialized()
        {
            var rackPatch = new NetworkCloudRackDefinitionPatch
            {
                RackLocation = "old-location"
            };
            rackPatch.BareMetalMachineConfigurationData.Add(new BareMetalMachineConfigurationPatch
            {
                BmcCredentials = new AdministrativeCredentialsPatch
                {
                    Password = "old-password"
                }
            });
            var patch = new NetworkCloudClusterPatch();
            patch.ComputeRackDefinitionsPatch.Add(rackPatch);

            NetworkCloudRackDefinition legacyRack = patch.ComputeRackDefinitions[0];
            legacyRack.RackLocation = "new-location";
            legacyRack.BareMetalMachineConfigurationData[0].BmcCredentials.Password = "new-password";

            using JsonDocument document = Serialize(patch);
            JsonElement serializedRack = document.RootElement
                .GetProperty("properties")
                .GetProperty("computeRackDefinitions")[0];
            Assert.That(serializedRack.GetProperty("rackLocation").GetString(), Is.EqualTo("new-location"));
            Assert.That(
                serializedRack
                    .GetProperty("bareMetalMachineConfigurationData")[0]
                    .GetProperty("bmcCredentials")
                    .GetProperty("password")
                    .GetString(),
                Is.EqualTo("new-password"));
        }

        [Test]
        public void RetainedLegacyBareMetalMachineCollectionRemainsLiveAfterPatchAttachment()
        {
            var rack = new NetworkCloudRackDefinition(
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ManagedNetworkFabric/networkRacks/rack"),
                "rack-serial",
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.NetworkCloud/rackSkus/rackSku"));
            IList<BareMetalMachineConfiguration> configurations = rack.BareMetalMachineConfigurationData;
            var patch = new NetworkCloudClusterPatch
            {
                AggregatorOrSingleRackDefinition = rack
            };

            configurations.Add(
                new BareMetalMachineConfiguration(
                    new AdministrativeCredentials("password", "username"),
                    "00:11:22:33:44:55",
                    "00:11:22:33:44:66",
                    1,
                    "machine-serial"));

            Assert.That(rack.BareMetalMachineConfigurationData, Is.SameAs(configurations));
            Assert.That(patch.AggregatorOrSingleRackDefinitionPatch.BareMetalMachineConfigurationData, Has.Count.EqualTo(1));
            using JsonDocument document = Serialize(patch);
            JsonElement machines = document.RootElement
                .GetProperty("properties")
                .GetProperty("aggregatorOrSingleRackDefinition")
                .GetProperty("bareMetalMachineConfigurationData");
            Assert.That(machines.GetArrayLength(), Is.EqualTo(1));
            Assert.That(machines[0].GetProperty("serialNumber").GetString(), Is.EqualTo("machine-serial"));
        }

        [Test]
        public void RetainedLegacyStorageApplianceCollectionRemainsLiveAfterPatchAttachment()
        {
            var rack = new NetworkCloudRackDefinition(
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ManagedNetworkFabric/networkRacks/rack"),
                "rack-serial",
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.NetworkCloud/rackSkus/rackSku"));
            IList<StorageApplianceConfiguration> configurations = rack.StorageApplianceConfigurationData;
            var patch = new NetworkCloudClusterPatch
            {
                AggregatorOrSingleRackDefinition = rack
            };

            configurations.Add(
                new StorageApplianceConfiguration(
                    new AdministrativeCredentials("password", "username"),
                    2,
                    "appliance-serial"));

            Assert.That(rack.StorageApplianceConfigurationData, Is.SameAs(configurations));
            Assert.That(patch.AggregatorOrSingleRackDefinitionPatch.StorageApplianceConfigurationData, Has.Count.EqualTo(1));
            using JsonDocument document = Serialize(patch);
            JsonElement appliances = document.RootElement
                .GetProperty("properties")
                .GetProperty("aggregatorOrSingleRackDefinition")
                .GetProperty("storageApplianceConfigurationData");
            Assert.That(appliances.GetArrayLength(), Is.EqualTo(1));
            Assert.That(appliances[0].GetProperty("serialNumber").GetString(), Is.EqualTo("appliance-serial"));
        }

        [Test]
        public void UntouchedLegacyRackCollectionsRemainOmittedAfterPatchAttachment()
        {
            var rack = new NetworkCloudRackDefinition(
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ManagedNetworkFabric/networkRacks/rack"),
                "rack-serial",
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.NetworkCloud/rackSkus/rackSku"));
            var patch = new NetworkCloudClusterPatch
            {
                AggregatorOrSingleRackDefinition = rack
            };

            using JsonDocument document = Serialize(patch);
            JsonElement serializedRack = document.RootElement
                .GetProperty("properties")
                .GetProperty("aggregatorOrSingleRackDefinition");
            Assert.That(serializedRack.TryGetProperty("bareMetalMachineConfigurationData", out _), Is.False);
            Assert.That(serializedRack.TryGetProperty("storageApplianceConfigurationData", out _), Is.False);
        }

        [Test]
        public void ExplicitlyClearedLegacyRackCollectionRemainsDefinedAfterPatchAttachment()
        {
            var rack = new NetworkCloudRackDefinition(
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ManagedNetworkFabric/networkRacks/rack"),
                "rack-serial",
                new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.NetworkCloud/rackSkus/rackSku"));
            rack.BareMetalMachineConfigurationData.Clear();
            var patch = new NetworkCloudClusterPatch
            {
                AggregatorOrSingleRackDefinition = rack
            };

            using JsonDocument document = Serialize(patch);
            JsonElement serializedRack = document.RootElement
                .GetProperty("properties")
                .GetProperty("aggregatorOrSingleRackDefinition");
            Assert.That(serializedRack.GetProperty("bareMetalMachineConfigurationData").GetArrayLength(), Is.Zero);
            Assert.That(serializedRack.TryGetProperty("storageApplianceConfigurationData", out _), Is.False);
        }

        [Test]
        public void PatchCollectionAdditionAfterLegacyReadIsSerialized()
        {
            var rackPatch = new NetworkCloudRackDefinitionPatch();
            var patch = new NetworkCloudClusterPatch
            {
                AggregatorOrSingleRackDefinitionPatch = rackPatch
            };

            _ = patch.AggregatorOrSingleRackDefinition;
            rackPatch.BareMetalMachineConfigurationData.Add(
                new BareMetalMachineConfigurationPatch
                {
                    MachineName = "new-machine"
                });

            using JsonDocument document = Serialize(patch);
            JsonElement machines = document.RootElement
                .GetProperty("properties")
                .GetProperty("aggregatorOrSingleRackDefinition")
                .GetProperty("bareMetalMachineConfigurationData");
            Assert.That(machines.GetArrayLength(), Is.EqualTo(1));
            Assert.That(machines[0].GetProperty("machineName").GetString(), Is.EqualTo("new-machine"));
        }

        [Test]
        public void PatchCollectionRemovalAndReplacementAfterLegacyReadAreSerialized()
        {
            var rackPatch = new NetworkCloudRackDefinitionPatch();
            rackPatch.StorageApplianceConfigurationData.Add(
                new StorageApplianceConfigurationPatch
                {
                    StorageApplianceName = "remove"
                });
            rackPatch.StorageApplianceConfigurationData.Add(
                new StorageApplianceConfigurationPatch
                {
                    StorageApplianceName = "replace"
                });
            var patch = new NetworkCloudClusterPatch
            {
                AggregatorOrSingleRackDefinitionPatch = rackPatch
            };

            _ = patch.AggregatorOrSingleRackDefinition;
            rackPatch.StorageApplianceConfigurationData.RemoveAt(0);
            rackPatch.StorageApplianceConfigurationData[0] = new StorageApplianceConfigurationPatch
            {
                StorageApplianceName = "replacement"
            };

            using JsonDocument document = Serialize(patch);
            JsonElement appliances = document.RootElement
                .GetProperty("properties")
                .GetProperty("aggregatorOrSingleRackDefinition")
                .GetProperty("storageApplianceConfigurationData");
            Assert.That(appliances.GetArrayLength(), Is.EqualTo(1));
            Assert.That(appliances[0].GetProperty("storageApplianceName").GetString(), Is.EqualTo("replacement"));
        }

        [Test]
        public void LegacyRackListUsesNetworkRackIdForIdentity()
        {
            var firstId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ManagedNetworkFabric/networkRacks/first");
            var secondId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ManagedNetworkFabric/networkRacks/second");
            var patch = new NetworkCloudClusterPatch();
            patch.ComputeRackDefinitionsPatch.Add(new NetworkCloudRackDefinitionPatch
            {
                NetworkRackId = firstId,
                RackSerialNumber = "duplicate"
            });
            patch.ComputeRackDefinitionsPatch.Add(new NetworkCloudRackDefinitionPatch
            {
                NetworkRackId = secondId,
                RackSerialNumber = "duplicate"
            });
            IList<NetworkCloudRackDefinition> legacyRacks = patch.ComputeRackDefinitions;
            NetworkCloudRackDefinition secondRack = legacyRacks[1];

            bool removed = legacyRacks.Remove(secondRack);

            Assert.That(removed, Is.True);
            Assert.That(legacyRacks, Has.Count.EqualTo(1));
            Assert.That(legacyRacks[0].NetworkRackId, Is.EqualTo(firstId));
        }

        [Test]
        public void LegacyRackListHandlesNullEntriesExplicitly()
        {
            var patch = new NetworkCloudClusterPatch();
            patch.ComputeRackDefinitionsPatch.Add(null);
            IList<NetworkCloudRackDefinition> legacyRacks = patch.ComputeRackDefinitions;

            Assert.That(legacyRacks.Contains(null), Is.True);
            Assert.That(legacyRacks.Remove(null), Is.True);
            Assert.That(legacyRacks, Is.Empty);
        }

        [Test]
        public void LegacyRackListRecognizesMappedRackAfterIdEdit()
        {
            var originalId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ManagedNetworkFabric/networkRacks/original");
            var newId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ManagedNetworkFabric/networkRacks/new");
            var patch = new NetworkCloudClusterPatch();
            IList<NetworkCloudRackDefinition> legacyRacks = patch.ComputeRackDefinitions;
            var rack = new NetworkCloudRackDefinition(originalId, "serial", new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/providers/Microsoft.NetworkCloud/rackSkus/rackSku"));
            legacyRacks.Add(rack);

            rack.NetworkRackId = newId;

            Assert.That(legacyRacks.Contains(rack), Is.True);
            Assert.That(legacyRacks.Remove(rack), Is.True);
            Assert.That(legacyRacks, Is.Empty);
        }

        [Test]
        public void LegacyRackListRecognizesMappedSparseRack()
        {
            var patch = new NetworkCloudClusterPatch();
            patch.ComputeRackDefinitionsPatch.Add(new NetworkCloudRackDefinitionPatch());
            IList<NetworkCloudRackDefinition> legacyRacks = patch.ComputeRackDefinitions;
            NetworkCloudRackDefinition sparseRack = legacyRacks[0];

            Assert.That(sparseRack.NetworkRackId, Is.Null);
            Assert.That(legacyRacks.Contains(sparseRack), Is.True);
            Assert.That(legacyRacks.Remove(sparseRack), Is.True);
            Assert.That(legacyRacks, Is.Empty);
        }

        [Test]
        public void LegacyRoundTripPreservesUnknownProperties()
        {
            BinaryData data = BinaryData.FromString(
                """
                {
                  "properties": {
                    "computeDeploymentThreshold": {
                      "futureThresholdOption": true
                    }
                  }
                }
                """);
            NetworkCloudClusterPatch patch = ModelReaderWriter.Read<NetworkCloudClusterPatch>(
                data,
                ModelReaderWriterOptions.Json,
                AzureResourceManagerNetworkCloudContext.Default);

            patch.ComputeDeploymentThreshold = patch.ComputeDeploymentThreshold;

            BinaryData serialized = ModelReaderWriter.Write(
                patch,
                ModelReaderWriterOptions.Json,
                AzureResourceManagerNetworkCloudContext.Default);
            using JsonDocument document = JsonDocument.Parse(serialized);
            Assert.That(
                document.RootElement
                    .GetProperty("properties")
                    .GetProperty("computeDeploymentThreshold")
                    .GetProperty("futureThresholdOption")
                    .GetBoolean(),
                Is.True);
        }

        private static JsonDocument Serialize<T>(T model)
        {
            BinaryData data = ModelReaderWriter.Write(model, WireOptions, AzureResourceManagerNetworkCloudContext.Default);
            return JsonDocument.Parse(data);
        }
    }
}
