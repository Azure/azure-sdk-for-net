# Azure.Provisioning.ProvisioningTypeSpec.Preview ARM resources

Resources: 17

Parent resource and Has scope describe public properties (including inherited properties), not deployment scope kinds.

| Resource | ARM resource type | Parent resource | Has scope | Default API version |
| --- | --- | --- | --- | --- |
| ConfigurationStore | ProvisioningTypeSpec/configurationStores | - | No | 2024-03-01-preview |
| ConfigurationStorePrivateLinkResource | ProvisioningTypeSpec/configurationStores/privateLinkResources | ConfigurationStore | No | 2024-03-01-preview |
| DiscriminatedResourceProfile | ProvisioningTypeSpec/configurationStores/discriminatedResourceProfiles | ConfigurationStore | No | 2024-03-01-preview |
| ExtensionAssignment | ProvisioningTypeSpec/extensionAssignments | - | Yes | 2024-03-01-preview |
| Item | ProvisioningTypeSpec/configurationStores/items | ConfigurationStore | No | 2024-03-01-preview |
| KeyValue | ProvisioningTypeSpec/configurationStores/keyValues | ConfigurationStore | No | 2024-03-01-preview |
| LegacySingleton | ProvisioningTypeSpec/legacySingletons | - | No | 2024-03-01-preview |
| OrphanedSingleton | ProvisioningTypeSpec/unmodeledParents/orphanedSingletons | - | No | 2024-03-01-preview |
| PreviewOnlyResource | ProvisioningTypeSpec/previewOnlyResources | - | No | 2024-03-01-preview |
| PreviewRetainedResource | ProvisioningTypeSpec/previewRetainedResources | - | No | 2024-03-01-preview |
| Profile | ProvisioningTypeSpec/configurationStores/profiles | ConfigurationStore | No | 2024-03-01-preview |
| ProfileRevision | ProvisioningTypeSpec/configurationStores/profiles/revisions | Profile | No | 2024-03-01-preview |
| ResourceProfile | ProvisioningTypeSpec/configurationStores/resourceProfiles | ConfigurationStore | No | 2024-03-01-preview |
| ResourceProfileRevision | ProvisioningTypeSpec/configurationStores/resourceProfiles/revisions | ResourceProfile | No | 2024-03-01-preview |
| SingletonSetting | ProvisioningTypeSpec/configurationStores/settings | ConfigurationStore | No | 2024-03-01-preview |
| SpecializedResourceProfile | ProvisioningTypeSpec/configurationStores/discriminatedResourceProfiles | ConfigurationStore | No | 2024-03-01-preview |
| VersionedResource | ProvisioningTypeSpec/versionedResources | - | No | 2024-03-01-preview |
