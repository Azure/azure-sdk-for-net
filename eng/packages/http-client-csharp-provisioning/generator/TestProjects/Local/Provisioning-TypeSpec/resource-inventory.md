# Azure.Provisioning.ProvisioningTypeSpec ARM resources

Resources: 17

Parent resource and Has scope describe public properties (including inherited properties), not deployment scope kinds.

| Resource | ARM resource type | Parent resource | Has scope | Default API version |
| --- | --- | --- | --- | --- |
| ConfigurationStore | ProvisioningTypeSpec/configurationStores | - | No | 2024-05-01 |
| ConfigurationStorePrivateLinkResource | ProvisioningTypeSpec/configurationStores/privateLinkResources | ConfigurationStore | No | 2024-05-01 |
| DiscriminatedResourceProfile | ProvisioningTypeSpec/configurationStores/discriminatedResourceProfiles | ConfigurationStore | No | 2024-05-01 |
| ExtensionAssignment | ProvisioningTypeSpec/extensionAssignments | - | Yes | 2024-05-01 |
| Item | ProvisioningTypeSpec/configurationStores/items | ConfigurationStore | No | 2024-05-01 |
| KeyValue | ProvisioningTypeSpec/configurationStores/keyValues | ConfigurationStore | No | 2024-05-01 |
| LatestStableResource | ProvisioningTypeSpec/latestStableResources | - | No | 2024-05-01 |
| LegacySingleton | ProvisioningTypeSpec/legacySingletons | - | No | 2024-05-01 |
| OrphanedSingleton | ProvisioningTypeSpec/unmodeledParents/orphanedSingletons | - | No | 2024-05-01 |
| PreviewRetainedResource | ProvisioningTypeSpec/previewRetainedResources | - | No | 2024-05-01 |
| Profile | ProvisioningTypeSpec/configurationStores/profiles | ConfigurationStore | No | 2024-05-01 |
| ProfileRevision | ProvisioningTypeSpec/configurationStores/profiles/revisions | Profile | No | 2024-05-01 |
| ResourceProfile | ProvisioningTypeSpec/configurationStores/resourceProfiles | ConfigurationStore | No | 2024-05-01 |
| ResourceProfileRevision | ProvisioningTypeSpec/configurationStores/resourceProfiles/revisions | ResourceProfile | No | 2024-05-01 |
| SingletonSetting | ProvisioningTypeSpec/configurationStores/settings | ConfigurationStore | No | 2024-05-01 |
| SpecializedResourceProfile | ProvisioningTypeSpec/configurationStores/discriminatedResourceProfiles | ConfigurationStore | No | 2024-05-01 |
| VersionedResource | ProvisioningTypeSpec/versionedResources | - | No | 2024-05-01 |
