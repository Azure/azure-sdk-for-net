// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;

#pragma warning disable SA1402 // Compatibility serialization adapters are maintained together.
#pragma warning disable SA1649 // The file intentionally contains the complete serialization bridge.

namespace Azure.ResourceManager.NetworkCloud.Models
{
    internal static class NetworkCloudLegacySerialization
    {
        public static void WriteProperties<T>(Utf8JsonWriter writer, T legacy, ModelReaderWriterOptions options)
        {
            BinaryData data = ModelReaderWriter.Write(legacy, options, AzureResourceManagerNetworkCloudContext.Default);
            using JsonDocument document = JsonDocument.Parse(data);
            foreach (JsonProperty property in document.RootElement.EnumerateObject())
            {
                property.WriteTo(writer);
            }
        }
    }

    internal sealed class LegacySerializingAdministrativeCredentialsPatch : AdministrativeCredentialsPatch
    {
        private readonly AdministrativeCredentials _legacy;

        public LegacySerializingAdministrativeCredentialsPatch(AdministrativeCredentials legacy)
            : base(legacy.Password, legacy.Username, legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            _legacy = legacy;
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => NetworkCloudLegacySerialization.WriteProperties(writer, _legacy, options);
    }

    internal sealed class LegacySerializingBareMetalMachineConfigurationPatch : BareMetalMachineConfigurationPatch
    {
        private readonly BareMetalMachineConfiguration _legacy;

        public LegacySerializingBareMetalMachineConfigurationPatch(BareMetalMachineConfiguration legacy)
            : base(
                legacy.BmcConnectionString,
                NetworkCloudPatchCompatibility.ToPatch(legacy.BmcCredentials),
                legacy.BmcMacAddress,
                legacy.BootMacAddress,
                legacy.MachineDetails,
                legacy.MachineName,
                legacy.RackSlot,
                legacy.SerialNumber,
                legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            _legacy = legacy;
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => NetworkCloudLegacySerialization.WriteProperties(writer, _legacy, options);
    }

    internal sealed class LegacySerializingStorageApplianceConfigurationPatch : StorageApplianceConfigurationPatch
    {
        private readonly StorageApplianceConfiguration _legacy;

        public LegacySerializingStorageApplianceConfigurationPatch(StorageApplianceConfiguration legacy)
            : base(
                NetworkCloudPatchCompatibility.ToPatch(legacy.AdminCredentials),
                legacy.RackSlot,
                legacy.SerialNumber,
                legacy.StorageApplianceName,
                legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            _legacy = legacy;
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => NetworkCloudLegacySerialization.WriteProperties(writer, _legacy, options);
    }

    internal sealed class LegacySerializingNetworkCloudRackDefinitionPatch : NetworkCloudRackDefinitionPatch
    {
        private readonly NetworkCloudRackDefinition _legacy;

        public LegacySerializingNetworkCloudRackDefinitionPatch(NetworkCloudRackDefinition legacy)
            : base(
                legacy.AvailabilityZone,
                legacy.CompatibilityBareMetalMachineConfigurationDataPatch,
                legacy.NetworkRackId,
                legacy.RackLocation,
                legacy.RackSerialNumber,
                legacy.RackSkuId,
                legacy.CompatibilityStorageApplianceConfigurationDataPatch,
                legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            _legacy = legacy;
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => NetworkCloudLegacySerialization.WriteProperties(writer, _legacy, options);
    }

    internal sealed class LegacySerializingServicePrincipalInformationPatch : ServicePrincipalInformationPatch
    {
        private readonly ServicePrincipalInformation _legacy;

        public LegacySerializingServicePrincipalInformationPatch(ServicePrincipalInformation legacy)
            : base(legacy.ApplicationId, legacy.Password, legacy.PrincipalId, legacy.TenantId, legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            _legacy = legacy;
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => NetworkCloudLegacySerialization.WriteProperties(writer, _legacy, options);
    }

    internal sealed class LegacySerializingValidationThresholdPatch : ValidationThresholdPatch
    {
        private readonly ValidationThreshold _legacy;

        public LegacySerializingValidationThresholdPatch(ValidationThreshold legacy)
            : base(legacy.Grouping, legacy.ThresholdType, legacy.Value, legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            _legacy = legacy;
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => NetworkCloudLegacySerialization.WriteProperties(writer, _legacy, options);
    }

    internal sealed class LegacySerializingClusterSecretArchivePatch : ClusterSecretArchivePatch
    {
        private readonly ClusterSecretArchive _legacy;

        public LegacySerializingClusterSecretArchivePatch(ClusterSecretArchive legacy)
            : base(legacy.KeyVaultId, legacy.UseKeyVault, legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            _legacy = legacy;
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => NetworkCloudLegacySerialization.WriteProperties(writer, _legacy, options);
    }

    internal sealed class LegacySerializingClusterUpdateStrategyPatch : ClusterUpdateStrategyPatch
    {
        private readonly ClusterUpdateStrategy _legacy;

        public LegacySerializingClusterUpdateStrategyPatch(ClusterUpdateStrategy legacy)
            : base(
                legacy.MaxUnavailable,
                legacy.StrategyType,
                legacy.ThresholdType,
                legacy.ThresholdValue,
                legacy.WaitTimeMinutes,
                legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            _legacy = legacy;
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => NetworkCloudLegacySerialization.WriteProperties(writer, _legacy, options);
    }

    internal sealed class LegacySerializingImageRepositoryCredentialsPatch : ImageRepositoryCredentialsPatch
    {
        private readonly ImageRepositoryCredentials _legacy;

        public LegacySerializingImageRepositoryCredentialsPatch(ImageRepositoryCredentials legacy)
            : base(legacy.Password, legacy.RegistryUriString, legacy.Username, legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            _legacy = legacy;
        }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => NetworkCloudLegacySerialization.WriteProperties(writer, _legacy, options);
    }
}
