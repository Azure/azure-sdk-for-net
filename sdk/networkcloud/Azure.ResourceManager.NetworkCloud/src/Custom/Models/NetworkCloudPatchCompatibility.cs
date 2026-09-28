// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.NetworkCloud.Models
{
    // These helpers preserve the pre-1.4.0 property types while the generated properties expose
    // PATCH-specific models. Legacy-backed PATCH models retain field presence and unknown data,
    // and synchronize in-place edits made through the classic models during serialization.
    internal static class NetworkCloudPatchCompatibility
    {
        public static AdministrativeCredentials ToClassic(AdministrativeCredentialsPatch value)
        {
            return value switch
            {
                null => null,
                LegacyBackedAdministrativeCredentialsPatch backed => backed.Legacy,
                _ => new LegacyBackedAdministrativeCredentialsPatch(value).Legacy
            };
        }

        public static AdministrativeCredentialsPatch ToPatch(AdministrativeCredentials value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<AdministrativeCredentials, AdministrativeCredentialsPatch>.TryGetPatch(value, out AdministrativeCredentialsPatch patch)
                ? patch
                : new LegacyBackedAdministrativeCredentialsPatch(value);
        }

        public static BareMetalMachineConfiguration ToClassic(BareMetalMachineConfigurationPatch value)
        {
            return value switch
            {
                null => null,
                LegacyBackedBareMetalMachineConfigurationPatch backed => backed.Legacy,
                _ => new LegacyBackedBareMetalMachineConfigurationPatch(value).Legacy
            };
        }

        public static BareMetalMachineConfigurationPatch ToPatch(BareMetalMachineConfiguration value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<BareMetalMachineConfiguration, BareMetalMachineConfigurationPatch>.TryGetPatch(value, out BareMetalMachineConfigurationPatch patch)
                ? patch
                : new LegacyBackedBareMetalMachineConfigurationPatch(value);
        }

        public static StorageApplianceConfiguration ToClassic(StorageApplianceConfigurationPatch value)
        {
            return value switch
            {
                null => null,
                LegacyBackedStorageApplianceConfigurationPatch backed => backed.Legacy,
                _ => new LegacyBackedStorageApplianceConfigurationPatch(value).Legacy
            };
        }

        public static StorageApplianceConfigurationPatch ToPatch(StorageApplianceConfiguration value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<StorageApplianceConfiguration, StorageApplianceConfigurationPatch>.TryGetPatch(value, out StorageApplianceConfigurationPatch patch)
                ? patch
                : new LegacyBackedStorageApplianceConfigurationPatch(value);
        }

        public static NetworkCloudRackDefinition ToClassic(NetworkCloudRackDefinitionPatch value)
        {
            return value switch
            {
                null => null,
                LegacyBackedNetworkCloudRackDefinitionPatch backed => backed.Legacy,
                _ => new LegacyBackedNetworkCloudRackDefinitionPatch(value).Legacy
            };
        }

        public static NetworkCloudRackDefinitionPatch ToPatch(NetworkCloudRackDefinition value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<NetworkCloudRackDefinition, NetworkCloudRackDefinitionPatch>.TryGetPatch(value, out NetworkCloudRackDefinitionPatch patch)
                ? patch
                : new LegacyBackedNetworkCloudRackDefinitionPatch(value);
        }

        public static ServicePrincipalInformation ToClassic(ServicePrincipalInformationPatch value)
        {
            return value switch
            {
                null => null,
                LegacyBackedServicePrincipalInformationPatch backed => backed.Legacy,
                _ => new LegacyBackedServicePrincipalInformationPatch(value).Legacy
            };
        }

        public static ServicePrincipalInformationPatch ToPatch(ServicePrincipalInformation value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<ServicePrincipalInformation, ServicePrincipalInformationPatch>.TryGetPatch(value, out ServicePrincipalInformationPatch patch)
                ? patch
                : new LegacyBackedServicePrincipalInformationPatch(value);
        }

        public static ValidationThreshold ToClassic(ValidationThresholdPatch value)
        {
            return value switch
            {
                null => null,
                LegacyBackedValidationThresholdPatch backed => backed.Legacy,
                _ => new LegacyBackedValidationThresholdPatch(value).Legacy
            };
        }

        public static ValidationThresholdPatch ToPatch(ValidationThreshold value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<ValidationThreshold, ValidationThresholdPatch>.TryGetPatch(value, out ValidationThresholdPatch patch)
                ? patch
                : new LegacyBackedValidationThresholdPatch(value);
        }

        public static ClusterSecretArchive ToClassic(ClusterSecretArchivePatch value)
        {
            return value switch
            {
                null => null,
                LegacyBackedClusterSecretArchivePatch backed => backed.Legacy,
                _ => new LegacyBackedClusterSecretArchivePatch(value).Legacy
            };
        }

        public static ClusterSecretArchivePatch ToPatch(ClusterSecretArchive value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<ClusterSecretArchive, ClusterSecretArchivePatch>.TryGetPatch(value, out ClusterSecretArchivePatch patch)
                ? patch
                : new LegacyBackedClusterSecretArchivePatch(value);
        }

        public static ClusterUpdateStrategy ToClassic(ClusterUpdateStrategyPatch value)
        {
            return value switch
            {
                null => null,
                LegacyBackedClusterUpdateStrategyPatch backed => backed.Legacy,
                _ => new LegacyBackedClusterUpdateStrategyPatch(value).Legacy
            };
        }

        public static ClusterUpdateStrategyPatch ToPatch(ClusterUpdateStrategy value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<ClusterUpdateStrategy, ClusterUpdateStrategyPatch>.TryGetPatch(value, out ClusterUpdateStrategyPatch patch)
                ? patch
                : new LegacyBackedClusterUpdateStrategyPatch(value);
        }

        public static ImageRepositoryCredentials ToClassic(ImageRepositoryCredentialsPatch value)
        {
            return value switch
            {
                null => null,
                LegacyBackedImageRepositoryCredentialsPatch backed => backed.Legacy,
                _ => new LegacyBackedImageRepositoryCredentialsPatch(value).Legacy
            };
        }

        public static ImageRepositoryCredentialsPatch ToPatch(ImageRepositoryCredentials value)
        {
            if (value is null)
            {
                return null;
            }
            return NetworkCloudLegacyPatchMap<ImageRepositoryCredentials, ImageRepositoryCredentialsPatch>.TryGetPatch(value, out ImageRepositoryCredentialsPatch patch)
                ? patch
                : new LegacyBackedImageRepositoryCredentialsPatch(value);
        }
    }
}
