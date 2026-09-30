// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // These helpers preserve the pre-1.4.0 property types while the generated properties expose
    // PATCH-specific models. The classic models proxy the original PATCH instances so both public
    // views retain object identity, field presence, unknown data, and in-place edits.
    internal static class NetworkCloudPatchCompatibility
    {
        public static AdministrativeCredentials ToClassic(AdministrativeCredentialsPatch value)
        {
            if (value is null)
            {
                return null;
            }
            if (NetworkCloudLegacyPatchMap<AdministrativeCredentials, AdministrativeCredentialsPatch>.TryGetLegacy(value, out AdministrativeCredentials legacy))
            {
                return legacy;
            }

            legacy = new AdministrativeCredentials(value.Password, value.Username, value.CompatibilityAdditionalBinaryDataProperties)
            {
                CompatibilityPatch = value
            };
            NetworkCloudLegacyPatchMap<AdministrativeCredentials, AdministrativeCredentialsPatch>.Register(legacy, value);
            return legacy;
        }

        public static AdministrativeCredentialsPatch ToPatch(AdministrativeCredentials value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<AdministrativeCredentials, AdministrativeCredentialsPatch>.TryGetPatch(value, out AdministrativeCredentialsPatch patch)
                ? patch
                : Register(value, new AdministrativeCredentialsPatch(value.Password, value.Username, value.CompatibilityAdditionalBinaryDataProperties), static (legacy, patch) => legacy.CompatibilityPatch = patch);
        }

        public static BareMetalMachineConfiguration ToClassic(BareMetalMachineConfigurationPatch value)
        {
            if (value is null)
            {
                return null;
            }
            if (NetworkCloudLegacyPatchMap<BareMetalMachineConfiguration, BareMetalMachineConfigurationPatch>.TryGetLegacy(value, out BareMetalMachineConfiguration legacy))
            {
                return legacy;
            }

            legacy = new BareMetalMachineConfiguration(value.BmcConnectionString, ToClassic(value.BmcCredentials), value.BmcMacAddress, value.BootMacAddress, value.MachineDetails, value.MachineName, value.RackSlot ?? default, value.SerialNumber, value.CompatibilityAdditionalBinaryDataProperties)
            {
                CompatibilityPatch = value
            };
            NetworkCloudLegacyPatchMap<BareMetalMachineConfiguration, BareMetalMachineConfigurationPatch>.Register(legacy, value);
            return legacy;
        }

        public static BareMetalMachineConfigurationPatch ToPatch(BareMetalMachineConfiguration value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<BareMetalMachineConfiguration, BareMetalMachineConfigurationPatch>.TryGetPatch(value, out BareMetalMachineConfigurationPatch patch)
                ? patch
                : Register(value, new BareMetalMachineConfigurationPatch(value.BmcConnectionString, ToPatch(value.BmcCredentials), value.BmcMacAddress, value.BootMacAddress, value.MachineDetails, value.MachineName, value.RackSlot, value.SerialNumber, value.CompatibilityAdditionalBinaryDataProperties), static (legacy, patch) => legacy.CompatibilityPatch = patch);
        }

        public static StorageApplianceConfiguration ToClassic(StorageApplianceConfigurationPatch value)
        {
            if (value is null)
            {
                return null;
            }
            if (NetworkCloudLegacyPatchMap<StorageApplianceConfiguration, StorageApplianceConfigurationPatch>.TryGetLegacy(value, out StorageApplianceConfiguration legacy))
            {
                return legacy;
            }

            legacy = new StorageApplianceConfiguration(ToClassic(value.AdminCredentials), value.RackSlot ?? default, value.SerialNumber, value.StorageApplianceName, value.CompatibilityAdditionalBinaryDataProperties)
            {
                CompatibilityPatch = value
            };
            NetworkCloudLegacyPatchMap<StorageApplianceConfiguration, StorageApplianceConfigurationPatch>.Register(legacy, value);
            return legacy;
        }

        public static StorageApplianceConfigurationPatch ToPatch(StorageApplianceConfiguration value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<StorageApplianceConfiguration, StorageApplianceConfigurationPatch>.TryGetPatch(value, out StorageApplianceConfigurationPatch patch)
                ? patch
                : Register(value, new StorageApplianceConfigurationPatch(ToPatch(value.AdminCredentials), value.RackSlot, value.SerialNumber, value.StorageApplianceName, value.CompatibilityAdditionalBinaryDataProperties), static (legacy, patch) => legacy.CompatibilityPatch = patch);
        }

        public static NetworkCloudRackDefinition ToClassic(NetworkCloudRackDefinitionPatch value)
        {
            if (value is null)
            {
                return null;
            }
            if (NetworkCloudLegacyPatchMap<NetworkCloudRackDefinition, NetworkCloudRackDefinitionPatch>.TryGetLegacy(value, out NetworkCloudRackDefinition legacy))
            {
                return legacy;
            }

            legacy = new NetworkCloudRackDefinition(
                value.AvailabilityZone,
                new NetworkCloudLegacyModelList<BareMetalMachineConfiguration, BareMetalMachineConfigurationPatch>(value.BareMetalMachineConfigurationData, ToClassic, ToPatch),
                value.NetworkRackId,
                value.RackLocation,
                value.RackSerialNumber,
                value.RackSkuId,
                new NetworkCloudLegacyModelList<StorageApplianceConfiguration, StorageApplianceConfigurationPatch>(value.StorageApplianceConfigurationData, ToClassic, ToPatch),
                value.CompatibilityAdditionalBinaryDataProperties)
            {
                CompatibilityPatch = value
            };
            NetworkCloudLegacyPatchMap<NetworkCloudRackDefinition, NetworkCloudRackDefinitionPatch>.Register(legacy, value);
            return legacy;
        }

        public static NetworkCloudRackDefinitionPatch ToPatch(NetworkCloudRackDefinition value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<NetworkCloudRackDefinition, NetworkCloudRackDefinitionPatch>.TryGetPatch(value, out NetworkCloudRackDefinitionPatch patch)
                ? patch
                : Register(
                    value,
                    new NetworkCloudRackDefinitionPatch(
                        value.AvailabilityZone,
                        Convert(value.BareMetalMachineConfigurationData, ToPatch),
                        value.NetworkRackId,
                        value.RackLocation,
                        value.RackSerialNumber,
                        value.RackSkuId,
                        Convert(value.StorageApplianceConfigurationData, ToPatch),
                        value.CompatibilityAdditionalBinaryDataProperties),
                    static (legacy, patch) => legacy.CompatibilityPatch = patch);
        }

        public static ServicePrincipalInformation ToClassic(ServicePrincipalInformationPatch value)
        {
            if (value is null)
            {
                return null;
            }
            if (NetworkCloudLegacyPatchMap<ServicePrincipalInformation, ServicePrincipalInformationPatch>.TryGetLegacy(value, out ServicePrincipalInformation legacy))
            {
                return legacy;
            }

            legacy = new ServicePrincipalInformation(value.ApplicationId, value.Password, value.PrincipalId, value.TenantId, value.CompatibilityAdditionalBinaryDataProperties)
            {
                CompatibilityPatch = value
            };
            NetworkCloudLegacyPatchMap<ServicePrincipalInformation, ServicePrincipalInformationPatch>.Register(legacy, value);
            return legacy;
        }

        public static ServicePrincipalInformationPatch ToPatch(ServicePrincipalInformation value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<ServicePrincipalInformation, ServicePrincipalInformationPatch>.TryGetPatch(value, out ServicePrincipalInformationPatch patch)
                ? patch
                : Register(value, new ServicePrincipalInformationPatch(value.ApplicationId, value.Password, value.PrincipalId, value.TenantId, value.CompatibilityAdditionalBinaryDataProperties), static (legacy, patch) => legacy.CompatibilityPatch = patch);
        }

        public static ValidationThreshold ToClassic(ValidationThresholdPatch value)
        {
            if (value is null)
            {
                return null;
            }
            if (NetworkCloudLegacyPatchMap<ValidationThreshold, ValidationThresholdPatch>.TryGetLegacy(value, out ValidationThreshold legacy))
            {
                return legacy;
            }

            legacy = new ValidationThreshold(value.Grouping ?? default, value.ThresholdType ?? default, value.Value ?? default, value.CompatibilityAdditionalBinaryDataProperties)
            {
                CompatibilityPatch = value
            };
            NetworkCloudLegacyPatchMap<ValidationThreshold, ValidationThresholdPatch>.Register(legacy, value);
            return legacy;
        }

        public static ValidationThresholdPatch ToPatch(ValidationThreshold value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<ValidationThreshold, ValidationThresholdPatch>.TryGetPatch(value, out ValidationThresholdPatch patch)
                ? patch
                : Register(value, new ValidationThresholdPatch(value.Grouping, value.ThresholdType, value.Value, value.CompatibilityAdditionalBinaryDataProperties), static (legacy, patch) => legacy.CompatibilityPatch = patch);
        }

        public static ClusterSecretArchive ToClassic(ClusterSecretArchivePatch value)
        {
            if (value is null)
            {
                return null;
            }
            if (NetworkCloudLegacyPatchMap<ClusterSecretArchive, ClusterSecretArchivePatch>.TryGetLegacy(value, out ClusterSecretArchive legacy))
            {
                return legacy;
            }

            legacy = new ClusterSecretArchive(value.KeyVaultId, value.UseKeyVault, value.CompatibilityAdditionalBinaryDataProperties)
            {
                CompatibilityPatch = value
            };
            NetworkCloudLegacyPatchMap<ClusterSecretArchive, ClusterSecretArchivePatch>.Register(legacy, value);
            return legacy;
        }

        public static ClusterSecretArchivePatch ToPatch(ClusterSecretArchive value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<ClusterSecretArchive, ClusterSecretArchivePatch>.TryGetPatch(value, out ClusterSecretArchivePatch patch)
                ? patch
                : Register(value, new ClusterSecretArchivePatch(value.KeyVaultId, value.UseKeyVault, value.CompatibilityAdditionalBinaryDataProperties), static (legacy, patch) => legacy.CompatibilityPatch = patch);
        }

        public static ClusterUpdateStrategy ToClassic(ClusterUpdateStrategyPatch value)
        {
            if (value is null)
            {
                return null;
            }
            if (NetworkCloudLegacyPatchMap<ClusterUpdateStrategy, ClusterUpdateStrategyPatch>.TryGetLegacy(value, out ClusterUpdateStrategy legacy))
            {
                return legacy;
            }

            legacy = new ClusterUpdateStrategy(value.MaxUnavailable, value.StrategyType ?? default, value.ThresholdType ?? default, value.ThresholdValue ?? default, value.WaitTimeMinutes, value.CompatibilityAdditionalBinaryDataProperties)
            {
                CompatibilityPatch = value
            };
            NetworkCloudLegacyPatchMap<ClusterUpdateStrategy, ClusterUpdateStrategyPatch>.Register(legacy, value);
            return legacy;
        }

        public static ClusterUpdateStrategyPatch ToPatch(ClusterUpdateStrategy value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<ClusterUpdateStrategy, ClusterUpdateStrategyPatch>.TryGetPatch(value, out ClusterUpdateStrategyPatch patch)
                ? patch
                : Register(value, new ClusterUpdateStrategyPatch(value.MaxUnavailable, value.StrategyType, value.ThresholdType, value.ThresholdValue, value.WaitTimeMinutes, value.CompatibilityAdditionalBinaryDataProperties), static (legacy, patch) => legacy.CompatibilityPatch = patch);
        }

        public static ImageRepositoryCredentials ToClassic(ImageRepositoryCredentialsPatch value)
        {
            if (value is null)
            {
                return null;
            }
            if (NetworkCloudLegacyPatchMap<ImageRepositoryCredentials, ImageRepositoryCredentialsPatch>.TryGetLegacy(value, out ImageRepositoryCredentials legacy))
            {
                return legacy;
            }

            legacy = new ImageRepositoryCredentials(value.Password, value.RegistryUriString, value.Username, value.CompatibilityAdditionalBinaryDataProperties)
            {
                CompatibilityPatch = value
            };
            NetworkCloudLegacyPatchMap<ImageRepositoryCredentials, ImageRepositoryCredentialsPatch>.Register(legacy, value);
            return legacy;
        }

        public static ImageRepositoryCredentialsPatch ToPatch(ImageRepositoryCredentials value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<ImageRepositoryCredentials, ImageRepositoryCredentialsPatch>.TryGetPatch(value, out ImageRepositoryCredentialsPatch patch)
                ? patch
                : Register(value, new ImageRepositoryCredentialsPatch(value.Password, value.RegistryUriString, value.Username, value.CompatibilityAdditionalBinaryDataProperties), static (legacy, patch) => legacy.CompatibilityPatch = patch);
        }

        private static IList<TPatch> Convert<TLegacy, TPatch>(IList<TLegacy> values, System.Func<TLegacy, TPatch> convert)
        {
            var result = new List<TPatch>(values.Count);
            foreach (TLegacy value in values)
            {
                result.Add(convert(value));
            }
            return result;
        }

        private static TPatch Register<TLegacy, TPatch>(
            TLegacy legacy,
            TPatch patch,
            Action<TLegacy, TPatch> attach)
            where TLegacy : class
            where TPatch : class
        {
            NetworkCloudLegacyPatchMap<TLegacy, TPatch>.Register(legacy, patch);
            attach(legacy, patch);
            return patch;
        }
    }
}
