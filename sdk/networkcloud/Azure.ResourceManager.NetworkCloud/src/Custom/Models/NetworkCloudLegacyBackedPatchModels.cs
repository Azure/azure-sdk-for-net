// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

#pragma warning disable SA1402 // Compatibility bridge types share state and are maintained together.
#pragma warning disable SA1649 // The file intentionally contains the complete compatibility bridge.

namespace Azure.ResourceManager.NetworkCloud.Models
{
    internal static class NetworkCloudLegacyPatchMap<TLegacy, TPatch>
        where TLegacy : class
        where TPatch : class
    {
        private static readonly ConditionalWeakTable<TLegacy, PatchHolder> s_patches = new();

        public static void Register(TLegacy legacy, TPatch patch)
        {
            s_patches.Remove(legacy);
            s_patches.Add(legacy, new PatchHolder(patch));
        }

        public static bool TryGetPatch(TLegacy legacy, out TPatch patch)
        {
            if (s_patches.TryGetValue(legacy, out PatchHolder holder))
            {
                patch = holder.Patch;
                return true;
            }

            patch = null;
            return false;
        }

        private sealed class PatchHolder
        {
            public PatchHolder(TPatch patch)
            {
                Patch = patch;
            }

            public TPatch Patch { get; }
        }
    }

    internal static class NetworkCloudLegacyPatchSynchronization
    {
        public static bool HasChanged<T>(T value, ref T snapshot)
        {
            if (EqualityComparer<T>.Default.Equals(value, snapshot))
            {
                return false;
            }

            snapshot = value;
            return true;
        }

        public static void SynchronizeList<TLegacy, TPatch>(
            IList<TPatch> patches,
            IList<TLegacy> legacyItems,
            Func<TLegacy, TPatch> toPatch)
            where TLegacy : class
            where TPatch : class
        {
            bool matches = patches.Count == legacyItems.Count;
            for (int i = 0; matches && i < patches.Count; i++)
            {
                matches = ReferenceEquals(patches[i], toPatch(legacyItems[i]));
            }

            if (matches)
            {
                return;
            }

            patches.Clear();
            foreach (TLegacy legacyItem in legacyItems)
            {
                patches.Add(toPatch(legacyItem));
            }
        }
    }

    internal sealed class LegacyBackedAdministrativeCredentialsPatch : AdministrativeCredentialsPatch
    {
        private string _password;
        private string _username;

        public LegacyBackedAdministrativeCredentialsPatch(AdministrativeCredentialsPatch patch)
            : base(patch.Password, patch.Username, patch.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = new AdministrativeCredentials(
                patch.Password,
                patch.Username,
                patch.CompatibilityAdditionalBinaryDataProperties);
            Initialize();
        }

        public LegacyBackedAdministrativeCredentialsPatch(AdministrativeCredentials legacy)
            : base(legacy.Password, legacy.Username, legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = legacy;
            Initialize();
        }

        public AdministrativeCredentials Legacy { get; }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.Password, ref _password))
            {
                Password = Legacy.Password;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.Username, ref _username))
            {
                Username = Legacy.Username;
            }
            base.JsonModelWriteCore(writer, options);
        }

        private void Initialize()
        {
            _password = Legacy.Password;
            _username = Legacy.Username;
            NetworkCloudLegacyPatchMap<AdministrativeCredentials, AdministrativeCredentialsPatch>.Register(Legacy, this);
        }
    }

    internal sealed class LegacyBackedBareMetalMachineConfigurationPatch : BareMetalMachineConfigurationPatch
    {
        private AdministrativeCredentials _bmcCredentials;
        private string _bmcMacAddress;
        private string _bootMacAddress;
        private string _machineDetails;
        private string _machineName;
        private long _rackSlot;
        private string _serialNumber;

        public LegacyBackedBareMetalMachineConfigurationPatch(BareMetalMachineConfigurationPatch patch)
            : base(
                patch.BmcConnectionString,
                patch.BmcCredentials,
                patch.BmcMacAddress,
                patch.BootMacAddress,
                patch.MachineDetails,
                patch.MachineName,
                patch.RackSlot,
                patch.SerialNumber,
                patch.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = new BareMetalMachineConfiguration(
                patch.BmcConnectionString,
                NetworkCloudPatchCompatibility.ToClassic(patch.BmcCredentials),
                patch.BmcMacAddress,
                patch.BootMacAddress,
                patch.MachineDetails,
                patch.MachineName,
                patch.RackSlot ?? default,
                patch.SerialNumber,
                patch.CompatibilityAdditionalBinaryDataProperties);
            BmcCredentials = NetworkCloudPatchCompatibility.ToPatch(Legacy.BmcCredentials);
            Initialize();
        }

        public LegacyBackedBareMetalMachineConfigurationPatch(BareMetalMachineConfiguration legacy)
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
            Legacy = legacy;
            Initialize();
        }

        public BareMetalMachineConfiguration Legacy { get; }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (!ReferenceEquals(Legacy.BmcCredentials, _bmcCredentials))
            {
                _bmcCredentials = Legacy.BmcCredentials;
                BmcCredentials = NetworkCloudPatchCompatibility.ToPatch(Legacy.BmcCredentials);
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.BmcMacAddress, ref _bmcMacAddress))
            {
                BmcMacAddress = Legacy.BmcMacAddress;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.BootMacAddress, ref _bootMacAddress))
            {
                BootMacAddress = Legacy.BootMacAddress;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.MachineDetails, ref _machineDetails))
            {
                MachineDetails = Legacy.MachineDetails;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.MachineName, ref _machineName))
            {
                MachineName = Legacy.MachineName;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.RackSlot, ref _rackSlot))
            {
                RackSlot = Legacy.RackSlot;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.SerialNumber, ref _serialNumber))
            {
                SerialNumber = Legacy.SerialNumber;
            }
            base.JsonModelWriteCore(writer, options);
        }

        private void Initialize()
        {
            _bmcCredentials = Legacy.BmcCredentials;
            _bmcMacAddress = Legacy.BmcMacAddress;
            _bootMacAddress = Legacy.BootMacAddress;
            _machineDetails = Legacy.MachineDetails;
            _machineName = Legacy.MachineName;
            _rackSlot = Legacy.RackSlot;
            _serialNumber = Legacy.SerialNumber;
            NetworkCloudLegacyPatchMap<BareMetalMachineConfiguration, BareMetalMachineConfigurationPatch>.Register(Legacy, this);
        }
    }

    internal sealed class LegacyBackedStorageApplianceConfigurationPatch : StorageApplianceConfigurationPatch
    {
        private AdministrativeCredentials _adminCredentials;
        private long _rackSlot;
        private string _serialNumber;
        private string _storageApplianceName;

        public LegacyBackedStorageApplianceConfigurationPatch(StorageApplianceConfigurationPatch patch)
            : base(
                patch.AdminCredentials,
                patch.RackSlot,
                patch.SerialNumber,
                patch.StorageApplianceName,
                patch.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = new StorageApplianceConfiguration(
                NetworkCloudPatchCompatibility.ToClassic(patch.AdminCredentials),
                patch.RackSlot ?? default,
                patch.SerialNumber,
                patch.StorageApplianceName,
                patch.CompatibilityAdditionalBinaryDataProperties);
            AdminCredentials = NetworkCloudPatchCompatibility.ToPatch(Legacy.AdminCredentials);
            Initialize();
        }

        public LegacyBackedStorageApplianceConfigurationPatch(StorageApplianceConfiguration legacy)
            : base(
                NetworkCloudPatchCompatibility.ToPatch(legacy.AdminCredentials),
                legacy.RackSlot,
                legacy.SerialNumber,
                legacy.StorageApplianceName,
                legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = legacy;
            Initialize();
        }

        public StorageApplianceConfiguration Legacy { get; }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (!ReferenceEquals(Legacy.AdminCredentials, _adminCredentials))
            {
                _adminCredentials = Legacy.AdminCredentials;
                AdminCredentials = NetworkCloudPatchCompatibility.ToPatch(Legacy.AdminCredentials);
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.RackSlot, ref _rackSlot))
            {
                RackSlot = Legacy.RackSlot;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.SerialNumber, ref _serialNumber))
            {
                SerialNumber = Legacy.SerialNumber;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.StorageApplianceName, ref _storageApplianceName))
            {
                StorageApplianceName = Legacy.StorageApplianceName;
            }
            base.JsonModelWriteCore(writer, options);
        }

        private void Initialize()
        {
            _adminCredentials = Legacy.AdminCredentials;
            _rackSlot = Legacy.RackSlot;
            _serialNumber = Legacy.SerialNumber;
            _storageApplianceName = Legacy.StorageApplianceName;
            NetworkCloudLegacyPatchMap<StorageApplianceConfiguration, StorageApplianceConfigurationPatch>.Register(Legacy, this);
        }
    }

    internal sealed class LegacyBackedNetworkCloudRackDefinitionPatch : NetworkCloudRackDefinitionPatch
    {
        private string _availabilityZone;
        private ResourceIdentifier _networkRackId;
        private string _rackLocation;
        private string _rackSerialNumber;
        private ResourceIdentifier _rackSkuId;

        public LegacyBackedNetworkCloudRackDefinitionPatch(NetworkCloudRackDefinitionPatch patch)
            : base(
                patch.AvailabilityZone,
                patch.BareMetalMachineConfigurationData,
                patch.NetworkRackId,
                patch.RackLocation,
                patch.RackSerialNumber,
                patch.RackSkuId,
                patch.StorageApplianceConfigurationData,
                patch.CompatibilityAdditionalBinaryDataProperties)
        {
            var bareMetalMachines = new List<BareMetalMachineConfiguration>();
            foreach (BareMetalMachineConfigurationPatch item in patch.BareMetalMachineConfigurationData)
            {
                bareMetalMachines.Add(NetworkCloudPatchCompatibility.ToClassic(item));
            }

            var storageAppliances = new List<StorageApplianceConfiguration>();
            foreach (StorageApplianceConfigurationPatch item in patch.StorageApplianceConfigurationData)
            {
                storageAppliances.Add(NetworkCloudPatchCompatibility.ToClassic(item));
            }

            Legacy = new NetworkCloudRackDefinition(
                patch.AvailabilityZone,
                bareMetalMachines,
                patch.NetworkRackId,
                patch.RackLocation,
                patch.RackSerialNumber,
                patch.RackSkuId,
                storageAppliances,
                patch.CompatibilityAdditionalBinaryDataProperties);
            SynchronizeCollections();
            Initialize();
        }

        public LegacyBackedNetworkCloudRackDefinitionPatch(NetworkCloudRackDefinition legacy)
            : base(
                legacy.AvailabilityZone,
                ConvertBareMetalMachines(legacy.BareMetalMachineConfigurationData),
                legacy.NetworkRackId,
                legacy.RackLocation,
                legacy.RackSerialNumber,
                legacy.RackSkuId,
                ConvertStorageAppliances(legacy.StorageApplianceConfigurationData),
                legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = legacy;
            Initialize();
        }

        public NetworkCloudRackDefinition Legacy { get; }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.AvailabilityZone, ref _availabilityZone))
            {
                AvailabilityZone = Legacy.AvailabilityZone;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.NetworkRackId, ref _networkRackId))
            {
                NetworkRackId = Legacy.NetworkRackId;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.RackLocation, ref _rackLocation))
            {
                RackLocation = Legacy.RackLocation;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.RackSerialNumber, ref _rackSerialNumber))
            {
                RackSerialNumber = Legacy.RackSerialNumber;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.RackSkuId, ref _rackSkuId))
            {
                RackSkuId = Legacy.RackSkuId;
            }
            SynchronizeCollections();
            base.JsonModelWriteCore(writer, options);
        }

        private static IList<BareMetalMachineConfigurationPatch> ConvertBareMetalMachines(
            IList<BareMetalMachineConfiguration> legacyItems)
        {
            var patches = new List<BareMetalMachineConfigurationPatch>();
            foreach (BareMetalMachineConfiguration item in legacyItems)
            {
                patches.Add(NetworkCloudPatchCompatibility.ToPatch(item));
            }
            return patches;
        }

        private static IList<StorageApplianceConfigurationPatch> ConvertStorageAppliances(
            IList<StorageApplianceConfiguration> legacyItems)
        {
            var patches = new List<StorageApplianceConfigurationPatch>();
            foreach (StorageApplianceConfiguration item in legacyItems)
            {
                patches.Add(NetworkCloudPatchCompatibility.ToPatch(item));
            }
            return patches;
        }

        private void Initialize()
        {
            _availabilityZone = Legacy.AvailabilityZone;
            _networkRackId = Legacy.NetworkRackId;
            _rackLocation = Legacy.RackLocation;
            _rackSerialNumber = Legacy.RackSerialNumber;
            _rackSkuId = Legacy.RackSkuId;
            NetworkCloudLegacyPatchMap<NetworkCloudRackDefinition, NetworkCloudRackDefinitionPatch>.Register(Legacy, this);
        }

        private void SynchronizeCollections()
        {
            NetworkCloudLegacyPatchSynchronization.SynchronizeList(
                BareMetalMachineConfigurationData,
                Legacy.BareMetalMachineConfigurationData,
                NetworkCloudPatchCompatibility.ToPatch);
            NetworkCloudLegacyPatchSynchronization.SynchronizeList(
                StorageApplianceConfigurationData,
                Legacy.StorageApplianceConfigurationData,
                NetworkCloudPatchCompatibility.ToPatch);
        }
    }

    internal sealed class LegacyBackedServicePrincipalInformationPatch : ServicePrincipalInformationPatch
    {
        private string _applicationId;
        private string _password;
        private string _principalId;
        private string _tenantId;

        public LegacyBackedServicePrincipalInformationPatch(ServicePrincipalInformationPatch patch)
            : base(
                patch.ApplicationId,
                patch.Password,
                patch.PrincipalId,
                patch.TenantId,
                patch.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = new ServicePrincipalInformation(
                patch.ApplicationId,
                patch.Password,
                patch.PrincipalId,
                patch.TenantId,
                patch.CompatibilityAdditionalBinaryDataProperties);
            Initialize();
        }

        public LegacyBackedServicePrincipalInformationPatch(ServicePrincipalInformation legacy)
            : base(
                legacy.ApplicationId,
                legacy.Password,
                legacy.PrincipalId,
                legacy.TenantId,
                legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = legacy;
            Initialize();
        }

        public ServicePrincipalInformation Legacy { get; }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.ApplicationId, ref _applicationId))
            {
                ApplicationId = Legacy.ApplicationId;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.Password, ref _password))
            {
                Password = Legacy.Password;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.PrincipalId, ref _principalId))
            {
                PrincipalId = Legacy.PrincipalId;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.TenantId, ref _tenantId))
            {
                TenantId = Legacy.TenantId;
            }
            base.JsonModelWriteCore(writer, options);
        }

        private void Initialize()
        {
            _applicationId = Legacy.ApplicationId;
            _password = Legacy.Password;
            _principalId = Legacy.PrincipalId;
            _tenantId = Legacy.TenantId;
            NetworkCloudLegacyPatchMap<ServicePrincipalInformation, ServicePrincipalInformationPatch>.Register(Legacy, this);
        }
    }

    internal sealed class LegacyBackedValidationThresholdPatch : ValidationThresholdPatch
    {
        private ValidationThresholdGrouping _grouping;
        private ValidationThresholdType _thresholdType;
        private long _value;

        public LegacyBackedValidationThresholdPatch(ValidationThresholdPatch patch)
            : base(
                patch.Grouping,
                patch.ThresholdType,
                patch.Value,
                patch.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = new ValidationThreshold(
                patch.Grouping ?? default,
                patch.ThresholdType ?? default,
                patch.Value ?? default,
                patch.CompatibilityAdditionalBinaryDataProperties);
            Initialize();
        }

        public LegacyBackedValidationThresholdPatch(ValidationThreshold legacy)
            : base(
                legacy.Grouping,
                legacy.ThresholdType,
                legacy.Value,
                legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = legacy;
            Initialize();
        }

        public ValidationThreshold Legacy { get; }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.Grouping, ref _grouping))
            {
                Grouping = Legacy.Grouping;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.ThresholdType, ref _thresholdType))
            {
                ThresholdType = Legacy.ThresholdType;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.Value, ref _value))
            {
                Value = Legacy.Value;
            }
            base.JsonModelWriteCore(writer, options);
        }

        private void Initialize()
        {
            _grouping = Legacy.Grouping;
            _thresholdType = Legacy.ThresholdType;
            _value = Legacy.Value;
            NetworkCloudLegacyPatchMap<ValidationThreshold, ValidationThresholdPatch>.Register(Legacy, this);
        }
    }

    internal sealed class LegacyBackedClusterSecretArchivePatch : ClusterSecretArchivePatch
    {
        private ResourceIdentifier _keyVaultId;
        private ClusterSecretArchiveEnabled? _useKeyVault;

        public LegacyBackedClusterSecretArchivePatch(ClusterSecretArchivePatch patch)
            : base(patch.KeyVaultId, patch.UseKeyVault, patch.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = new ClusterSecretArchive(
                patch.KeyVaultId,
                patch.UseKeyVault,
                patch.CompatibilityAdditionalBinaryDataProperties);
            Initialize();
        }

        public LegacyBackedClusterSecretArchivePatch(ClusterSecretArchive legacy)
            : base(legacy.KeyVaultId, legacy.UseKeyVault, legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = legacy;
            Initialize();
        }

        public ClusterSecretArchive Legacy { get; }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.KeyVaultId, ref _keyVaultId))
            {
                KeyVaultId = Legacy.KeyVaultId;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.UseKeyVault, ref _useKeyVault))
            {
                UseKeyVault = Legacy.UseKeyVault;
            }
            base.JsonModelWriteCore(writer, options);
        }

        private void Initialize()
        {
            _keyVaultId = Legacy.KeyVaultId;
            _useKeyVault = Legacy.UseKeyVault;
            NetworkCloudLegacyPatchMap<ClusterSecretArchive, ClusterSecretArchivePatch>.Register(Legacy, this);
        }
    }

    internal sealed class LegacyBackedClusterUpdateStrategyPatch : ClusterUpdateStrategyPatch
    {
        private long? _maxUnavailable;
        private ClusterUpdateStrategyType _strategyType;
        private ValidationThresholdType _thresholdType;
        private long _thresholdValue;
        private long? _waitTimeMinutes;

        public LegacyBackedClusterUpdateStrategyPatch(ClusterUpdateStrategyPatch patch)
            : base(
                patch.MaxUnavailable,
                patch.StrategyType,
                patch.ThresholdType,
                patch.ThresholdValue,
                patch.WaitTimeMinutes,
                patch.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = new ClusterUpdateStrategy(
                patch.MaxUnavailable,
                patch.StrategyType ?? default,
                patch.ThresholdType ?? default,
                patch.ThresholdValue ?? default,
                patch.WaitTimeMinutes,
                patch.CompatibilityAdditionalBinaryDataProperties);
            Initialize();
        }

        public LegacyBackedClusterUpdateStrategyPatch(ClusterUpdateStrategy legacy)
            : base(
                legacy.MaxUnavailable,
                legacy.StrategyType,
                legacy.ThresholdType,
                legacy.ThresholdValue,
                legacy.WaitTimeMinutes,
                legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = legacy;
            Initialize();
        }

        public ClusterUpdateStrategy Legacy { get; }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.MaxUnavailable, ref _maxUnavailable))
            {
                MaxUnavailable = Legacy.MaxUnavailable;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.StrategyType, ref _strategyType))
            {
                StrategyType = Legacy.StrategyType;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.ThresholdType, ref _thresholdType))
            {
                ThresholdType = Legacy.ThresholdType;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.ThresholdValue, ref _thresholdValue))
            {
                ThresholdValue = Legacy.ThresholdValue;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.WaitTimeMinutes, ref _waitTimeMinutes))
            {
                WaitTimeMinutes = Legacy.WaitTimeMinutes;
            }
            base.JsonModelWriteCore(writer, options);
        }

        private void Initialize()
        {
            _maxUnavailable = Legacy.MaxUnavailable;
            _strategyType = Legacy.StrategyType;
            _thresholdType = Legacy.ThresholdType;
            _thresholdValue = Legacy.ThresholdValue;
            _waitTimeMinutes = Legacy.WaitTimeMinutes;
            NetworkCloudLegacyPatchMap<ClusterUpdateStrategy, ClusterUpdateStrategyPatch>.Register(Legacy, this);
        }
    }

    internal sealed class LegacyBackedImageRepositoryCredentialsPatch : ImageRepositoryCredentialsPatch
    {
        private string _password;
        private string _registryUriString;
        private string _username;

        public LegacyBackedImageRepositoryCredentialsPatch(ImageRepositoryCredentialsPatch patch)
            : base(
                patch.Password,
                patch.RegistryUriString,
                patch.Username,
                patch.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = new ImageRepositoryCredentials(
                patch.Password,
                patch.RegistryUriString,
                patch.Username,
                patch.CompatibilityAdditionalBinaryDataProperties);
            Initialize();
        }

        public LegacyBackedImageRepositoryCredentialsPatch(ImageRepositoryCredentials legacy)
            : base(
                legacy.Password,
                legacy.RegistryUriString,
                legacy.Username,
                legacy.CompatibilityAdditionalBinaryDataProperties)
        {
            Legacy = legacy;
            Initialize();
        }

        public ImageRepositoryCredentials Legacy { get; }

        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.Password, ref _password))
            {
                Password = Legacy.Password;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.RegistryUriString, ref _registryUriString))
            {
                RegistryUriString = Legacy.RegistryUriString;
            }
            if (NetworkCloudLegacyPatchSynchronization.HasChanged(Legacy.Username, ref _username))
            {
                Username = Legacy.Username;
            }
            base.JsonModelWriteCore(writer, options);
        }

        private void Initialize()
        {
            _password = Legacy.Password;
            _registryUriString = Legacy.RegistryUriString;
            _username = Legacy.Username;
            NetworkCloudLegacyPatchMap<ImageRepositoryCredentials, ImageRepositoryCredentialsPatch>.Register(Legacy, this);
        }
    }

    public partial class AdministrativeCredentials
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class AdministrativeCredentialsPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class BareMetalMachineConfiguration
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class BareMetalMachineConfigurationPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class StorageApplianceConfiguration
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class StorageApplianceConfigurationPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class NetworkCloudRackDefinition
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class NetworkCloudRackDefinitionPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ServicePrincipalInformation
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ServicePrincipalInformationPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ValidationThreshold
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ValidationThresholdPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ClusterSecretArchive
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ClusterSecretArchivePatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ClusterUpdateStrategy
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ClusterUpdateStrategyPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ImageRepositoryCredentials
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ImageRepositoryCredentialsPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }
}
