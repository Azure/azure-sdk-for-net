// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

#pragma warning disable SA1402 // Compatibility model customizations are maintained together.
#pragma warning disable SA1649 // The file intentionally contains the complete compatibility bridge.

namespace Azure.ResourceManager.NetworkCloud.Models
{
    internal static class NetworkCloudLegacyPatchMap<TLegacy, TPatch>
        where TLegacy : class
        where TPatch : class
    {
        private static readonly ConditionalWeakTable<TLegacy, PatchHolder> s_patches = new();
        private static readonly ConditionalWeakTable<TPatch, LegacyHolder> s_legacyModels = new();

        public static void Register(TLegacy legacy, TPatch patch)
        {
            s_patches.Remove(legacy);
            s_patches.Add(legacy, new PatchHolder(patch));
            s_legacyModels.Remove(patch);
            s_legacyModels.Add(patch, new LegacyHolder(legacy));
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

        public static bool TryGetLegacy(TPatch patch, out TLegacy legacy)
        {
            if (s_legacyModels.TryGetValue(patch, out LegacyHolder holder))
            {
                legacy = holder.Legacy;
                return true;
            }

            legacy = null;
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

        private sealed class LegacyHolder
        {
            public LegacyHolder(TLegacy legacy)
            {
                Legacy = legacy;
            }

            public TLegacy Legacy { get; }
        }
    }

    // The ChangeTrackingList base preserves undefined collection state for generated serialization,
    // while the IList implementation provides a live classic view over the PATCH collection.
    internal sealed class NetworkCloudLegacyModelList<TLegacy, TPatch> : ChangeTrackingList<TLegacy>, IList<TLegacy>, IReadOnlyList<TLegacy>
        where TLegacy : class
        where TPatch : class
    {
        private readonly IList<TPatch> _inner;
        private readonly Func<TPatch, TLegacy> _toLegacy;
        private readonly Func<TLegacy, TPatch> _toPatch;

        public NetworkCloudLegacyModelList(
            IList<TPatch> inner,
            Func<TPatch, TLegacy> toLegacy,
            Func<TLegacy, TPatch> toPatch)
        {
            _inner = inner;
            _toLegacy = toLegacy;
            _toPatch = toPatch;
            SynchronizeDefinition();
        }

        public IList<TPatch> PatchItems => _inner;

        public new TLegacy this[int index]
        {
            get => _toLegacy(_inner[index]);
            set
            {
                _inner[index] = _toPatch(value);
                MarkDefined();
            }
        }

        public new int Count => _inner.Count;

        TLegacy IReadOnlyList<TLegacy>.this[int index] => _toLegacy(_inner[index]);

        int IReadOnlyCollection<TLegacy>.Count => _inner.Count;

        public new bool IsReadOnly => _inner.IsReadOnly;

        public new void Add(TLegacy item)
        {
            _inner.Add(_toPatch(item));
            MarkDefined();
        }

        public new void Clear()
        {
            _inner.Clear();
            MarkDefined();
        }

        public new bool Contains(TLegacy item) => IndexOf(item) >= 0;

        public new void CopyTo(TLegacy[] array, int arrayIndex)
        {
            for (int i = 0; i < _inner.Count; i++)
            {
                array[arrayIndex + i] = _toLegacy(_inner[i]);
            }
        }

        public new IEnumerator<TLegacy> GetEnumerator()
        {
            foreach (TPatch item in _inner)
            {
                yield return _toLegacy(item);
            }
        }

        public new int IndexOf(TLegacy item)
        {
            TPatch patch = _toPatch(item);
            for (int i = 0; i < _inner.Count; i++)
            {
                if (ReferenceEquals(_inner[i], patch))
                {
                    return i;
                }
            }
            return -1;
        }

        public new void Insert(int index, TLegacy item)
        {
            _inner.Insert(index, _toPatch(item));
            MarkDefined();
        }

        public new bool Remove(TLegacy item)
        {
            int index = IndexOf(item);
            if (index < 0)
            {
                return false;
            }
            _inner.RemoveAt(index);
            MarkDefined();
            return true;
        }

        public new void RemoveAt(int index)
        {
            _inner.RemoveAt(index);
            MarkDefined();
        }

        IEnumerator<TLegacy> IEnumerable<TLegacy>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void SynchronizeDefinition()
        {
            if (Optional.IsCollectionDefined(_inner))
            {
                MarkDefined();
            }
        }

        private void MarkDefined()
        {
            if (IsUndefined)
            {
                base.Clear();
            }
        }
    }

    public partial class AdministrativeCredentials
    {
        private string _compatibilityPassword;
        private string _compatibilityUsername;

        internal AdministrativeCredentialsPatch CompatibilityPatch { get; set; }

        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;

        /// <summary> The password of the administrator of the device used during initialization. </summary>
        [CodeGenMember("Password")]
        public string Password
        {
            get => CompatibilityPatch is null ? _compatibilityPassword : CompatibilityPatch.Password;
            set
            {
                _compatibilityPassword = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.Password = value;
                }
            }
        }

        /// <summary> The username of the administrator of the device used during initialization. </summary>
        [CodeGenMember("Username")]
        public string Username
        {
            get => CompatibilityPatch is null ? _compatibilityUsername : CompatibilityPatch.Username;
            set
            {
                _compatibilityUsername = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.Username = value;
                }
            }
        }
    }

    public partial class AdministrativeCredentialsPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class BareMetalMachineConfiguration
    {
        private string _compatibilityBmcConnectionString;
        private AdministrativeCredentials _compatibilityBmcCredentials;
        private string _compatibilityBmcMacAddress;
        private string _compatibilityBootMacAddress;
        private string _compatibilityMachineDetails;
        private string _compatibilityMachineName;
        private long _compatibilityRackSlot;
        private string _compatibilitySerialNumber;

        internal BareMetalMachineConfigurationPatch CompatibilityPatch { get; set; }

        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;

        /// <summary> The connection string for the baseboard management controller including IP address and protocol. </summary>
        [CodeGenMember("BmcConnectionString")]
        public string BmcConnectionString
        {
            get => CompatibilityPatch is null ? _compatibilityBmcConnectionString : CompatibilityPatch.BmcConnectionString;
            private set => _compatibilityBmcConnectionString = value;
        }

        /// <summary> The credentials of the baseboard management controller on this bare metal machine. </summary>
        [CodeGenMember("BmcCredentials")]
        public AdministrativeCredentials BmcCredentials
        {
            get => CompatibilityPatch is null ? _compatibilityBmcCredentials : NetworkCloudPatchCompatibility.ToClassic(CompatibilityPatch.BmcCredentials);
            set
            {
                _compatibilityBmcCredentials = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.BmcCredentials = NetworkCloudPatchCompatibility.ToPatch(value);
                }
            }
        }

        /// <summary> The MAC address of the BMC for this machine. </summary>
        [CodeGenMember("BmcMacAddress")]
        public string BmcMacAddress
        {
            get => CompatibilityPatch is null ? _compatibilityBmcMacAddress : CompatibilityPatch.BmcMacAddress;
            set
            {
                _compatibilityBmcMacAddress = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.BmcMacAddress = value;
                }
            }
        }

        /// <summary> The MAC address associated with the PXE NIC card. </summary>
        [CodeGenMember("BootMacAddress")]
        public string BootMacAddress
        {
            get => CompatibilityPatch is null ? _compatibilityBootMacAddress : CompatibilityPatch.BootMacAddress;
            set
            {
                _compatibilityBootMacAddress = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.BootMacAddress = value;
                }
            }
        }

        /// <summary> The free-form additional information about the machine, e.g. an asset tag. </summary>
        [CodeGenMember("MachineDetails")]
        public string MachineDetails
        {
            get => CompatibilityPatch is null ? _compatibilityMachineDetails : CompatibilityPatch.MachineDetails;
            set
            {
                _compatibilityMachineDetails = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.MachineDetails = value;
                }
            }
        }

        /// <summary> The user-provided name for the bare metal machine created from this specification. </summary>
        [CodeGenMember("MachineName")]
        public string MachineName
        {
            get => CompatibilityPatch is null ? _compatibilityMachineName : CompatibilityPatch.MachineName;
            set
            {
                _compatibilityMachineName = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.MachineName = value;
                }
            }
        }

        /// <summary> The slot the physical machine is in the rack based on the BOM configuration. </summary>
        [CodeGenMember("RackSlot")]
        public long RackSlot
        {
            get => CompatibilityPatch is null ? _compatibilityRackSlot : CompatibilityPatch.RackSlot ?? default;
            set
            {
                _compatibilityRackSlot = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.RackSlot = value;
                }
            }
        }

        /// <summary> The serial number of the machine. </summary>
        [CodeGenMember("SerialNumber")]
        public string SerialNumber
        {
            get => CompatibilityPatch is null ? _compatibilitySerialNumber : CompatibilityPatch.SerialNumber;
            set
            {
                _compatibilitySerialNumber = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.SerialNumber = value;
                }
            }
        }
    }

    public partial class BareMetalMachineConfigurationPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class StorageApplianceConfiguration
    {
        private AdministrativeCredentials _compatibilityAdminCredentials;
        private long _compatibilityRackSlot;
        private string _compatibilitySerialNumber;
        private string _compatibilityStorageApplianceName;

        internal StorageApplianceConfigurationPatch CompatibilityPatch { get; set; }

        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;

        /// <summary> The credentials of the administrative interface on this storage appliance. </summary>
        [CodeGenMember("AdminCredentials")]
        public AdministrativeCredentials AdminCredentials
        {
            get => CompatibilityPatch is null ? _compatibilityAdminCredentials : NetworkCloudPatchCompatibility.ToClassic(CompatibilityPatch.AdminCredentials);
            set
            {
                _compatibilityAdminCredentials = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.AdminCredentials = NetworkCloudPatchCompatibility.ToPatch(value);
                }
            }
        }

        /// <summary> The slot that storage appliance is in the rack based on the BOM configuration. </summary>
        [CodeGenMember("RackSlot")]
        public long RackSlot
        {
            get => CompatibilityPatch is null ? _compatibilityRackSlot : CompatibilityPatch.RackSlot ?? default;
            set
            {
                _compatibilityRackSlot = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.RackSlot = value;
                }
            }
        }

        /// <summary> The serial number of the appliance. </summary>
        [CodeGenMember("SerialNumber")]
        public string SerialNumber
        {
            get => CompatibilityPatch is null ? _compatibilitySerialNumber : CompatibilityPatch.SerialNumber;
            set
            {
                _compatibilitySerialNumber = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.SerialNumber = value;
                }
            }
        }

        /// <summary> The user-provided name for the storage appliance. </summary>
        [CodeGenMember("StorageApplianceName")]
        public string StorageApplianceName
        {
            get => CompatibilityPatch is null ? _compatibilityStorageApplianceName : CompatibilityPatch.StorageApplianceName;
            set
            {
                _compatibilityStorageApplianceName = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.StorageApplianceName = value;
                }
            }
        }
    }

    public partial class StorageApplianceConfigurationPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class NetworkCloudRackDefinition
    {
        private string _compatibilityAvailabilityZone;
        private NetworkCloudLegacyModelList<BareMetalMachineConfiguration, BareMetalMachineConfigurationPatch> _compatibilityBareMetalMachineConfigurationData;
        private ResourceIdentifier _compatibilityNetworkRackId;
        private string _compatibilityRackLocation;
        private string _compatibilityRackSerialNumber;
        private ResourceIdentifier _compatibilityRackSkuId;
        private NetworkCloudLegacyModelList<StorageApplianceConfiguration, StorageApplianceConfigurationPatch> _compatibilityStorageApplianceConfigurationData;

        internal NetworkCloudRackDefinitionPatch CompatibilityPatch { get; set; }

        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;

        internal IList<BareMetalMachineConfigurationPatch> CompatibilityBareMetalMachineConfigurationDataPatch => _compatibilityBareMetalMachineConfigurationData.PatchItems;

        internal IList<StorageApplianceConfigurationPatch> CompatibilityStorageApplianceConfigurationDataPatch => _compatibilityStorageApplianceConfigurationData.PatchItems;

        /// <summary> The zone name used for this rack when created. </summary>
        [CodeGenMember("AvailabilityZone")]
        public string AvailabilityZone
        {
            get => CompatibilityPatch is null ? _compatibilityAvailabilityZone : CompatibilityPatch.AvailabilityZone;
            set
            {
                _compatibilityAvailabilityZone = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.AvailabilityZone = value;
                }
            }
        }

        /// <summary> The unordered list of bare metal machine configuration. </summary>
        [CodeGenMember("BareMetalMachineConfigurationData")]
        public IList<BareMetalMachineConfiguration> BareMetalMachineConfigurationData
        {
            get
            {
                _compatibilityBareMetalMachineConfigurationData.SynchronizeDefinition();
                return _compatibilityBareMetalMachineConfigurationData;
            }
            private set => _compatibilityBareMetalMachineConfigurationData =
                value as NetworkCloudLegacyModelList<BareMetalMachineConfiguration, BareMetalMachineConfigurationPatch>
                ?? new NetworkCloudLegacyModelList<BareMetalMachineConfiguration, BareMetalMachineConfigurationPatch>(
                    NetworkCloudPatchCompatibility.ToPatchList(value, NetworkCloudPatchCompatibility.ToPatch),
                    NetworkCloudPatchCompatibility.ToClassic,
                    NetworkCloudPatchCompatibility.ToPatch);
        }

        /// <summary> The resource ID of the network rack that matches this rack definition. </summary>
        [CodeGenMember("NetworkRackId")]
        public ResourceIdentifier NetworkRackId
        {
            get => CompatibilityPatch is null ? _compatibilityNetworkRackId : CompatibilityPatch.NetworkRackId;
            set
            {
                _compatibilityNetworkRackId = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.NetworkRackId = value;
                }
            }
        }

        /// <summary> The free-form description of the rack's location. </summary>
        [CodeGenMember("RackLocation")]
        public string RackLocation
        {
            get => CompatibilityPatch is null ? _compatibilityRackLocation : CompatibilityPatch.RackLocation;
            set
            {
                _compatibilityRackLocation = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.RackLocation = value;
                }
            }
        }

        /// <summary> The unique identifier for the rack within Network Cloud cluster. </summary>
        [CodeGenMember("RackSerialNumber")]
        public string RackSerialNumber
        {
            get => CompatibilityPatch is null ? _compatibilityRackSerialNumber : CompatibilityPatch.RackSerialNumber;
            set
            {
                _compatibilityRackSerialNumber = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.RackSerialNumber = value;
                }
            }
        }

        /// <summary> The resource ID of the sku for the rack being added. </summary>
        [CodeGenMember("RackSkuId")]
        public ResourceIdentifier RackSkuId
        {
            get => CompatibilityPatch is null ? _compatibilityRackSkuId : CompatibilityPatch.RackSkuId;
            set
            {
                _compatibilityRackSkuId = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.RackSkuId = value;
                }
            }
        }

        /// <summary> The list of storage appliance configuration data for this rack. </summary>
        [CodeGenMember("StorageApplianceConfigurationData")]
        public IList<StorageApplianceConfiguration> StorageApplianceConfigurationData
        {
            get
            {
                _compatibilityStorageApplianceConfigurationData.SynchronizeDefinition();
                return _compatibilityStorageApplianceConfigurationData;
            }
            private set => _compatibilityStorageApplianceConfigurationData =
                value as NetworkCloudLegacyModelList<StorageApplianceConfiguration, StorageApplianceConfigurationPatch>
                ?? new NetworkCloudLegacyModelList<StorageApplianceConfiguration, StorageApplianceConfigurationPatch>(
                    NetworkCloudPatchCompatibility.ToPatchList(value, NetworkCloudPatchCompatibility.ToPatch),
                    NetworkCloudPatchCompatibility.ToClassic,
                    NetworkCloudPatchCompatibility.ToPatch);
        }
    }

    public partial class NetworkCloudRackDefinitionPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ServicePrincipalInformation
    {
        private string _compatibilityApplicationId;
        private string _compatibilityPassword;
        private string _compatibilityPrincipalId;
        private string _compatibilityTenantId;

        internal ServicePrincipalInformationPatch CompatibilityPatch { get; set; }

        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;

        /// <summary> The application ID, also known as client ID, of the service principal. </summary>
        [CodeGenMember("ApplicationId")]
        public string ApplicationId
        {
            get => CompatibilityPatch is null ? _compatibilityApplicationId : CompatibilityPatch.ApplicationId;
            set
            {
                _compatibilityApplicationId = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.ApplicationId = value;
                }
            }
        }

        /// <summary> The password of the service principal. </summary>
        [CodeGenMember("Password")]
        public string Password
        {
            get => CompatibilityPatch is null ? _compatibilityPassword : CompatibilityPatch.Password;
            set
            {
                _compatibilityPassword = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.Password = value;
                }
            }
        }

        /// <summary> The principal ID, also known as the object ID, of the service principal. </summary>
        [CodeGenMember("PrincipalId")]
        public string PrincipalId
        {
            get => CompatibilityPatch is null ? _compatibilityPrincipalId : CompatibilityPatch.PrincipalId;
            set
            {
                _compatibilityPrincipalId = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.PrincipalId = value;
                }
            }
        }

        /// <summary> The tenant ID of the tenant in which the service principal is created. </summary>
        [CodeGenMember("TenantId")]
        public string TenantId
        {
            get => CompatibilityPatch is null ? _compatibilityTenantId : CompatibilityPatch.TenantId;
            set
            {
                _compatibilityTenantId = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.TenantId = value;
                }
            }
        }
    }

    public partial class ServicePrincipalInformationPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ValidationThreshold
    {
        private ValidationThresholdGrouping _compatibilityGrouping;
        private ValidationThresholdType _compatibilityThresholdType;
        private long _compatibilityValue;

        internal ValidationThresholdPatch CompatibilityPatch { get; set; }

        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;

        /// <summary> Selection of how the type evaluation is applied to the cluster calculation. </summary>
        [CodeGenMember("Grouping")]
        public ValidationThresholdGrouping Grouping
        {
            get => CompatibilityPatch is null ? _compatibilityGrouping : CompatibilityPatch.Grouping ?? default;
            set
            {
                _compatibilityGrouping = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.Grouping = value;
                }
            }
        }

        /// <summary> Selection of how the threshold should be evaluated. </summary>
        [CodeGenMember("ThresholdType")]
        public ValidationThresholdType ThresholdType
        {
            get => CompatibilityPatch is null ? _compatibilityThresholdType : CompatibilityPatch.ThresholdType ?? default;
            set
            {
                _compatibilityThresholdType = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.ThresholdType = value;
                }
            }
        }

        /// <summary> The numeric threshold value. </summary>
        [CodeGenMember("Value")]
        public long Value
        {
            get => CompatibilityPatch is null ? _compatibilityValue : CompatibilityPatch.Value ?? default;
            set
            {
                _compatibilityValue = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.Value = value;
                }
            }
        }
    }

    public partial class ValidationThresholdPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ClusterSecretArchive
    {
        private ResourceIdentifier _compatibilityKeyVaultId;
        private ClusterSecretArchiveEnabled? _compatibilityUseKeyVault;

        internal ClusterSecretArchivePatch CompatibilityPatch { get; set; }

        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;

        /// <summary> The resource ID of the key vault to archive the secrets of the cluster. </summary>
        [CodeGenMember("KeyVaultId")]
        public ResourceIdentifier KeyVaultId
        {
            get => CompatibilityPatch is null ? _compatibilityKeyVaultId : CompatibilityPatch.KeyVaultId;
            set
            {
                _compatibilityKeyVaultId = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.KeyVaultId = value;
                }
            }
        }

        /// <summary> The indicator if the specified key vault should be used. </summary>
        [CodeGenMember("UseKeyVault")]
        public ClusterSecretArchiveEnabled? UseKeyVault
        {
            get => CompatibilityPatch is null ? _compatibilityUseKeyVault : CompatibilityPatch.UseKeyVault;
            set
            {
                _compatibilityUseKeyVault = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.UseKeyVault = value;
                }
            }
        }
    }

    public partial class ClusterSecretArchivePatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ClusterUpdateStrategy
    {
        private long? _compatibilityMaxUnavailable;
        private ClusterUpdateStrategyType _compatibilityStrategyType;
        private ValidationThresholdType _compatibilityThresholdType;
        private long _compatibilityThresholdValue;
        private long? _compatibilityWaitTimeMinutes;

        internal ClusterUpdateStrategyPatch CompatibilityPatch { get; set; }

        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;

        /// <summary> The maximum number of worker nodes that can be offline within the increment of update. </summary>
        [CodeGenMember("MaxUnavailable")]
        public long? MaxUnavailable
        {
            get => CompatibilityPatch is null ? _compatibilityMaxUnavailable : CompatibilityPatch.MaxUnavailable;
            set
            {
                _compatibilityMaxUnavailable = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.MaxUnavailable = value;
                }
            }
        }

        /// <summary> The strategy for updating the cluster. </summary>
        [CodeGenMember("StrategyType")]
        public ClusterUpdateStrategyType StrategyType
        {
            get => CompatibilityPatch is null ? _compatibilityStrategyType : CompatibilityPatch.StrategyType ?? default;
            set
            {
                _compatibilityStrategyType = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.StrategyType = value;
                }
            }
        }

        /// <summary> Selection of how the threshold should be evaluated. </summary>
        [CodeGenMember("ThresholdType")]
        public ValidationThresholdType ThresholdType
        {
            get => CompatibilityPatch is null ? _compatibilityThresholdType : CompatibilityPatch.ThresholdType ?? default;
            set
            {
                _compatibilityThresholdType = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.ThresholdType = value;
                }
            }
        }

        /// <summary> The numeric threshold value. </summary>
        [CodeGenMember("ThresholdValue")]
        public long ThresholdValue
        {
            get => CompatibilityPatch is null ? _compatibilityThresholdValue : CompatibilityPatch.ThresholdValue ?? default;
            set
            {
                _compatibilityThresholdValue = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.ThresholdValue = value;
                }
            }
        }

        /// <summary> The time to wait between the increments of update defined by the strategy. </summary>
        [CodeGenMember("WaitTimeMinutes")]
        public long? WaitTimeMinutes
        {
            get => CompatibilityPatch is null ? _compatibilityWaitTimeMinutes : CompatibilityPatch.WaitTimeMinutes;
            set
            {
                _compatibilityWaitTimeMinutes = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.WaitTimeMinutes = value;
                }
            }
        }
    }

    public partial class ClusterUpdateStrategyPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }

    public partial class ImageRepositoryCredentials
    {
        private string _compatibilityPassword;
        private string _compatibilityRegistryUriString;
        private string _compatibilityUsername;

        internal ImageRepositoryCredentialsPatch CompatibilityPatch { get; set; }

        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;

        /// <summary> The password or token used to access an image in the target repository. </summary>
        [CodeGenMember("Password")]
        public string Password
        {
            get => CompatibilityPatch is null ? _compatibilityPassword : CompatibilityPatch.Password;
            set
            {
                _compatibilityPassword = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.Password = value;
                }
            }
        }

        /// <summary> The URL of the authentication server used to validate the repository credentials. </summary>
        [CodeGenMember("RegistryUriString")]
        public string RegistryUriString
        {
            get => CompatibilityPatch is null ? _compatibilityRegistryUriString : CompatibilityPatch.RegistryUriString;
            set
            {
                _compatibilityRegistryUriString = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.RegistryUriString = value;
                }
            }
        }

        /// <summary> The username used to access an image in the target repository. </summary>
        [CodeGenMember("Username")]
        public string Username
        {
            get => CompatibilityPatch is null ? _compatibilityUsername : CompatibilityPatch.Username;
            set
            {
                _compatibilityUsername = value;
                if (CompatibilityPatch is not null)
                {
                    CompatibilityPatch.Username = value;
                }
            }
        }
    }

    public partial class ImageRepositoryCredentialsPatch
    {
        internal IDictionary<string, BinaryData> CompatibilityAdditionalBinaryDataProperties => _additionalBinaryDataProperties;
    }
}
