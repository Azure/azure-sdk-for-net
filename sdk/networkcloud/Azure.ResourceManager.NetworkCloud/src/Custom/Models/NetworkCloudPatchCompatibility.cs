// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // NOTE: These helpers translate between the classic (pre-1.4.0) model shapes and the
    // generated "*Patch" model shapes introduced for API version 2026-07-01. The wire format
    // for both shapes is identical (same JSON property names), so these conversions are lossless
    // and are used to preserve the public property types on NetworkCloudClusterPatch and
    // NetworkCloudVirtualMachinePatch for backward compatibility.
    internal static class NetworkCloudPatchCompatibility
    {
        public static AdministrativeCredentials ToClassic(AdministrativeCredentialsPatch value)
        {
            return value is null ? null : new AdministrativeCredentials(value.Password, value.Username, null);
        }

        public static AdministrativeCredentialsPatch ToPatch(AdministrativeCredentials value)
        {
            return value is null ? null : new AdministrativeCredentialsPatch(value.Password, value.Username, null);
        }

        public static BareMetalMachineConfiguration ToClassic(BareMetalMachineConfigurationPatch value)
        {
            if (value is null)
            {
                return null;
            }
            return new BareMetalMachineConfiguration(value.BmcConnectionString, ToClassic(value.BmcCredentials), value.BmcMacAddress, value.BootMacAddress, value.MachineDetails, value.MachineName, value.RackSlot ?? default, value.SerialNumber, null);
        }

        public static BareMetalMachineConfigurationPatch ToPatch(BareMetalMachineConfiguration value)
        {
            if (value is null)
            {
                return null;
            }
            return new BareMetalMachineConfigurationPatch(value.BmcConnectionString, ToPatch(value.BmcCredentials), value.BmcMacAddress, value.BootMacAddress, value.MachineDetails, value.MachineName, value.RackSlot, value.SerialNumber, null);
        }

        public static StorageApplianceConfiguration ToClassic(StorageApplianceConfigurationPatch value)
        {
            if (value is null)
            {
                return null;
            }
            return new StorageApplianceConfiguration(ToClassic(value.AdminCredentials), value.RackSlot ?? default, value.SerialNumber, value.StorageApplianceName, null);
        }

        public static StorageApplianceConfigurationPatch ToPatch(StorageApplianceConfiguration value)
        {
            if (value is null)
            {
                return null;
            }
            return new StorageApplianceConfigurationPatch(ToPatch(value.AdminCredentials), value.RackSlot, value.SerialNumber, value.StorageApplianceName, null);
        }

        public static NetworkCloudRackDefinition ToClassic(NetworkCloudRackDefinitionPatch value)
        {
            if (value is null)
            {
                return null;
            }
            IList<BareMetalMachineConfiguration> bareMetalMachineConfigurationData = value.BareMetalMachineConfigurationData.Select(ToClassic).ToList();
            IList<StorageApplianceConfiguration> storageApplianceConfigurationData = value.StorageApplianceConfigurationData.Select(ToClassic).ToList();
            return new NetworkCloudRackDefinition(value.AvailabilityZone, bareMetalMachineConfigurationData, value.NetworkRackId, value.RackLocation, value.RackSerialNumber, value.RackSkuId, storageApplianceConfigurationData, null);
        }

        public static NetworkCloudRackDefinitionPatch ToPatch(NetworkCloudRackDefinition value)
        {
            if (value is null)
            {
                return null;
            }
            IList<BareMetalMachineConfigurationPatch> bareMetalMachineConfigurationData = value.BareMetalMachineConfigurationData.Select(ToPatch).ToList();
            IList<StorageApplianceConfigurationPatch> storageApplianceConfigurationData = value.StorageApplianceConfigurationData.Select(ToPatch).ToList();
            return new NetworkCloudRackDefinitionPatch(value.AvailabilityZone, bareMetalMachineConfigurationData, value.NetworkRackId, value.RackLocation, value.RackSerialNumber, value.RackSkuId, storageApplianceConfigurationData, null);
        }

        public static ServicePrincipalInformation ToClassic(ServicePrincipalInformationPatch value)
        {
            return value is null ? null : new ServicePrincipalInformation(value.ApplicationId, value.Password, value.PrincipalId, value.TenantId, null);
        }

        public static ServicePrincipalInformationPatch ToPatch(ServicePrincipalInformation value)
        {
            return value is null ? null : new ServicePrincipalInformationPatch(value.ApplicationId, value.Password, value.PrincipalId, value.TenantId, null);
        }

        public static ValidationThreshold ToClassic(ValidationThresholdPatch value)
        {
            return value is null ? null : new ValidationThreshold(value.Grouping ?? default, value.ThresholdType ?? default, value.Value ?? default, null);
        }

        public static ValidationThresholdPatch ToPatch(ValidationThreshold value)
        {
            return value is null ? null : new ValidationThresholdPatch(value.Grouping, value.ThresholdType, value.Value, null);
        }

        public static ClusterSecretArchive ToClassic(ClusterSecretArchivePatch value)
        {
            return value is null ? null : new ClusterSecretArchive(value.KeyVaultId, value.UseKeyVault, null);
        }

        public static ClusterSecretArchivePatch ToPatch(ClusterSecretArchive value)
        {
            return value is null ? null : new ClusterSecretArchivePatch(value.KeyVaultId, value.UseKeyVault, null);
        }

        public static ClusterUpdateStrategy ToClassic(ClusterUpdateStrategyPatch value)
        {
            return value is null ? null : new ClusterUpdateStrategy(value.MaxUnavailable, value.StrategyType ?? default, value.ThresholdType ?? default, value.ThresholdValue ?? default, value.WaitTimeMinutes, null);
        }

        public static ClusterUpdateStrategyPatch ToPatch(ClusterUpdateStrategy value)
        {
            return value is null ? null : new ClusterUpdateStrategyPatch(value.MaxUnavailable, value.StrategyType, value.ThresholdType, value.ThresholdValue, value.WaitTimeMinutes, null);
        }

        public static ImageRepositoryCredentials ToClassic(ImageRepositoryCredentialsPatch value)
        {
            return value is null ? null : new ImageRepositoryCredentials(value.Password, value.RegistryUriString, value.Username, null);
        }

        public static ImageRepositoryCredentialsPatch ToPatch(ImageRepositoryCredentials value)
        {
            return value is null ? null : new ImageRepositoryCredentialsPatch(value.Password, value.RegistryUriString, value.Username, null);
        }
    }
}
