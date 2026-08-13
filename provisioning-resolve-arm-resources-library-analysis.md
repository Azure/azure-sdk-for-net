# Provisioning resolveArmResources library change analysis

This report compares `origin/main` with the validation PR branch after regenerating all provisioning libraries with the `resolveArmResources` path.

For each library, resource identity is matched by the ARM resource type string used in generated `ProvisionableResource` constructors. A resource class rename means the ARM type stayed present but the generated C# resource class name changed.

Known caveat: model base-type changes may include unrelated generator behavior already present on `main`; this report records them separately from resource identity/name changes.

## Summary

| Library | Resources | ARM adds | ARM deletes | Resource renames | Model base changes | Direct setter changes | Notes |
| --- | ---: | ---: | ---: | ---: | ---: | ---: | --- |
| `Azure.Provisioning.Attestation` | 2 -> 2 | 0 | 0 | 1 | 0 | 0 | resource set unchanged; 1 resource class rename(s) |
| `Azure.Provisioning.Batch` | 8 -> 0 | 0 | 8 | 0 | 0 | 0 | resource set changed (+0/-8); model file churn A0/D122/R0 |
| `Azure.Provisioning.BotService` | 5 -> 5 | 0 | 0 | 3 | 2 | 0 | resource set unchanged; 3 resource class rename(s); 2 model base-type change(s); model file churn A1/D0/R0 |
| `Azure.Provisioning.Cdn` | 15 -> 15 | 0 | 0 | 13 | 7 | 0 | resource set unchanged; 13 resource class rename(s); 7 model base-type change(s); model file churn A4/D0/R0 |
| `Azure.Provisioning.Communication` | 7 -> 7 | 0 | 0 | 4 | 0 | 0 | resource set unchanged; 4 resource class rename(s) |
| `Azure.Provisioning.Compute` | 37 -> 34 | 0 | 3 | 10 | 25 | 0 | resource set changed (+0/-3); 10 resource class rename(s); 25 model base-type change(s); model file churn A10/D0/R0 |
| `Azure.Provisioning.ContainerInstance` | 4 -> 3 | 0 | 1 | 0 | 0 | 0 | resource set changed (+0/-1); model file churn A0/D9/R0 |
| `Azure.Provisioning.ContainerRegistry.Tasks` | 4 -> 4 | 0 | 0 | 4 | 0 | 0 | resource set unchanged; 4 resource class rename(s) |
| `Azure.Provisioning.ContainerService` | 12 -> 12 | 0 | 0 | 8 | 3 | 0 | resource set unchanged; 8 resource class rename(s); 3 model base-type change(s) |
| `Azure.Provisioning.CostManagement` | 9 -> 9 | 0 | 0 | 4 | 3 | 0 | resource set unchanged; 4 resource class rename(s); 3 model base-type change(s); model file churn A1/D0/R0 |
| `Azure.Provisioning.DomainRegistration` | 3 -> 3 | 0 | 0 | 1 | 0 | 0 | resource set unchanged; 1 resource class rename(s) |
| `Azure.Provisioning.DurableTask` | 5 -> 5 | 0 | 0 | 5 | 0 | 0 | resource set unchanged; 5 resource class rename(s) |
| `Azure.Provisioning.EventHubs` | 13 -> 0 | 0 | 13 | 0 | 0 | 0 | resource set changed (+0/-13); model file churn A0/D69/R0 |
| `Azure.Provisioning.FrontDoor` | 6 -> 0 | 0 | 6 | 0 | 0 | 0 | resource set changed (+0/-6); model file churn A0/D102/R0 |
| `Azure.Provisioning.IotHub` | 4 -> 4 | 1 | 1 | 2 | 0 | 0 | resource set changed (+1/-1); 2 resource class rename(s) |
| `Azure.Provisioning.KeyVault` | 7 -> 7 | 0 | 0 | 5 | 1 | 0 | resource set unchanged; 5 resource class rename(s); 1 model base-type change(s); model file churn A1/D0/R0 |
| `Azure.Provisioning.MachineLearning` | 41 -> 41 | 0 | 0 | 21 | 35 | 0 | resource set unchanged; 21 resource class rename(s); 35 model base-type change(s); model file churn A11/D0/R0 |
| `Azure.Provisioning.MySql` | 11 -> 11 | 0 | 0 | 10 | 0 | 0 | resource set unchanged; 10 resource class rename(s) |
| `Azure.Provisioning.OperationalInsights` | 12 -> 12 | 1 | 1 | 9 | 0 | 0 | resource set changed (+1/-1); 9 resource class rename(s); model file churn A0/D1/R0 |
| `Azure.Provisioning.RecoveryServices` | 4 -> 4 | 0 | 0 | 4 | 0 | 0 | resource set unchanged; 4 resource class rename(s) |
| `Azure.Provisioning.RecoveryServicesBackup` | 12 -> 12 | 0 | 0 | 12 | 3 | 0 | resource set unchanged; 12 resource class rename(s); 3 model base-type change(s); model file churn A1/D0/R0 |
| `Azure.Provisioning.Redis` | 7 -> 7 | 0 | 0 | 3 | 2 | 0 | resource set unchanged; 3 resource class rename(s); 2 model base-type change(s); model file churn A3/D0/R0 |
| `Azure.Provisioning.ResourceGraph` | 1 -> 1 | 0 | 0 | 0 | 0 | 0 | resource set unchanged |
| `Azure.Provisioning.Search` | 4 -> 4 | 0 | 0 | 2 | 0 | 0 | resource set unchanged; 2 resource class rename(s) |
| `Azure.Provisioning.ServiceFabric` | 6 -> 6 | 0 | 0 | 6 | 2 | 0 | resource set unchanged; 6 resource class rename(s); 2 model base-type change(s); model file churn A2/D0/R0 |
| `Azure.Provisioning.ServiceFabricManagedClusters` | 6 -> 6 | 0 | 0 | 6 | 1 | 0 | resource set unchanged; 6 resource class rename(s); 1 model base-type change(s); model file churn A1/D0/R0 |
| `Azure.Provisioning.ServiceNetworking` | 4 -> 4 | 0 | 0 | 3 | 0 | 0 | resource set unchanged; 3 resource class rename(s) |
| `Azure.Provisioning.StandbyPool` | 5 -> 5 | 0 | 0 | 5 | 0 | 0 | resource set unchanged; 5 resource class rename(s) |
| `Azure.Provisioning.TrafficManager` | 7 -> 0 | 0 | 7 | 0 | 0 | 0 | resource set changed (+0/-7); model file churn A0/D24/R0 |

## Per-library details

## sdk attestation Azure.Provisioning.Attestation[-1]

Resource count: **2 -> 2**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **1**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.Attestation/attestationProviders/privateEndpointConnections` | `AttestationPrivateEndpointConnection` | `AttestationProviderPrivateEndpointConnection` |

## sdk batch Azure.Provisioning.Batch[-1]

Resource count: **8 -> 0**. ARM resource types added/deleted: **+0/-8**. Resource class renames: **0**.

Deleted ARM resource types:
- `Microsoft.Batch/batchAccounts` was `BatchAccount`
- `Microsoft.Batch/batchAccounts/applications` was `BatchApplication`
- `Microsoft.Batch/batchAccounts/applications/versions` was `BatchApplicationPackage`
- `Microsoft.Batch/batchAccounts/detectors` was `BatchAccountDetector`
- `Microsoft.Batch/batchAccounts/networkSecurityPerimeterConfigurations` was `NetworkSecurityPerimeterConfiguration`
- `Microsoft.Batch/batchAccounts/pools` was `BatchAccountPool`
- `Microsoft.Batch/batchAccounts/privateEndpointConnections` was `BatchPrivateEndpointConnection`
- `Microsoft.Batch/batchAccounts/privateLinkResources` was `BatchPrivateLinkResource`

Model file churn: added **0**, deleted **122**, renamed **0**.

## sdk botservice Azure.Provisioning.BotService[-1]

Resource count: **5 -> 5**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **3**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.BotService/botServices/connections` | `BotConnectionSetting` | `ConnectionSetting` |
| `Microsoft.BotService/botServices/networkSecurityPerimeterConfigurations` | `BotServiceNetworkSecurityPerimeterConfiguration` | `NetworkSecurityPerimeterConfiguration` |
| `Microsoft.BotService/botServices/privateEndpointConnections` | `BotServicePrivateEndpointConnection` | `PrivateEndpointConnection` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `DirectLineSite` | `ProvisionableConstruct` | `BotChannelSite` |
| `WebChatSite` | `ProvisionableConstruct` | `BotChannelSite` |

Model file churn: added **1**, deleted **0**, renamed **0**.
- Added model `BotChannelSite.cs`

## sdk cdn Azure.Provisioning.Cdn[-1]

Resource count: **15 -> 15**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **13**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.Cdn/profiles/afdEndpoints` | `FrontDoorEndpoint` | `AFDEndpoint` |
| `Microsoft.Cdn/profiles/afdEndpoints/routes` | `FrontDoorRoute` | `Route` |
| `Microsoft.Cdn/profiles/customDomains` | `FrontDoorCustomDomain` | `AFDDomain` |
| `Microsoft.Cdn/profiles/endpoints` | `CdnEndpoint` | `Endpoint` |
| `Microsoft.Cdn/profiles/endpoints/customDomains` | `CdnCustomDomain` | `CustomDomain` |
| `Microsoft.Cdn/profiles/endpoints/originGroups` | `CdnOriginGroup` | `OriginGroup` |
| `Microsoft.Cdn/profiles/endpoints/origins` | `CdnOrigin` | `Origin` |
| `Microsoft.Cdn/profiles/originGroups` | `FrontDoorOriginGroup` | `AFDOriginGroup` |
| `Microsoft.Cdn/profiles/originGroups/origins` | `FrontDoorOrigin` | `AFDOrigin` |
| `Microsoft.Cdn/profiles/ruleSets` | `FrontDoorRuleSet` | `RuleSet` |
| `Microsoft.Cdn/profiles/ruleSets/rules` | `FrontDoorRule` | `Rule` |
| `Microsoft.Cdn/profiles/secrets` | `FrontDoorSecret` | `Secret` |
| `Microsoft.Cdn/profiles/securityPolicies` | `FrontDoorSecurityPolicy` | `SecurityPolicy` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `CdnRuleSetProperties` | `ProvisionableConstruct` | `FrontDoorStateProperties` |
| `CdnSecretProperties` | `ProvisionableConstruct` | `FrontDoorStateProperties` |
| `CdnSecurityPolicyProperties` | `ProvisionableConstruct` | `FrontDoorStateProperties` |
| `EndpointProperties` | `ProvisionableConstruct` | `EndpointPropertiesUpdateParameters` |
| `OriginGroupProperties` | `ProvisionableConstruct` | `OriginGroupUpdatePropertiesParameters` |
| `OriginProperties` | `ProvisionableConstruct` | `OriginUpdatePropertiesParameters` |
| `RateLimitRule` | `ProvisionableConstruct` | `CustomRule` |

Model file churn: added **4**, deleted **0**, renamed **0**.
- Added model `EndpointPropertiesUpdateParameters.cs`
- Added model `FrontDoorStateProperties.cs`
- Added model `OriginGroupUpdatePropertiesParameters.cs`
- Added model `OriginUpdatePropertiesParameters.cs`

## sdk communication Azure.Provisioning.Communication[-1]

Resource count: **7 -> 7**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **4**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.Communication/communicationServices/smtpUsernames` | `CommunicationSmtpUsername` | `SmtpUsernameResource` |
| `Microsoft.Communication/emailServices/domains` | `CommunicationDomain` | `DomainResource` |
| `Microsoft.Communication/emailServices/domains/suppressionLists` | `EmailSuppressionList` | `SuppressionListResource` |
| `Microsoft.Communication/emailServices/domains/suppressionLists/suppressionListAddresses` | `EmailSuppressionListAddress` | `SuppressionListAddressResource` |

## sdk compute Azure.Provisioning.Compute[-1]

Resource count: **37 -> 34**. ARM resource types added/deleted: **+0/-3**. Resource class renames: **10**.

Deleted ARM resource types:
- `Microsoft.Compute/virtualMachines/runCommands` was `VirtualMachineRunCommand`
- `Microsoft.Compute/virtualMachineScaleSets/extensions` was `VirtualMachineScaleSetExtension`
- `Microsoft.Compute/virtualMachineScaleSets/virtualMachines/extensions` was `VirtualMachineScaleSetVmExtension`

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.Compute/diskAccesses/privateEndpointConnections` | `ComputePrivateEndpointConnection` | `PrivateEndpointConnection` |
| `Microsoft.Compute/disks` | `ManagedDisk` | `Disk` |
| `Microsoft.Compute/images` | `DiskImage` | `Image` |
| `Microsoft.Compute/locations/publishers/artifacttypes/types/versions` | `VirtualMachineExtensionImage` | `TypesVersions` |
| `Microsoft.Compute/restorePointCollections` | `RestorePointGroup` | `RestorePointCollection` |
| `Microsoft.Compute/restorePointCollections/restorePoints/diskRestorePoints` | `DiskRestorePoint` | `RestorePointsDiskRestorePoints` |
| `Microsoft.Compute/sshPublicKeys` | `SshPublicKey` | `SshPublicKeyResource` |
| `Microsoft.Compute/virtualMachineScaleSets/lifecycleHookEvents` | `VirtualMachineScaleSetLifecycleHookEvent` | `VMScaleSetLifecycleHookEvent` |
| `Microsoft.Compute/virtualMachineScaleSets/rollingUpgrades` | `VirtualMachineScaleSetRollingUpgrade` | `RollingUpgradeStatusInfo` |
| `Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands` | `VirtualMachineScaleSetVmRunCommand` | `VirtualMachinesRunCommands` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `CapacityReservationInstanceViewWithName` | `ProvisionableConstruct` | `CapacityReservationInstanceView` |
| `ComputeSubResourceDataWithColocationStatus` | `ProvisionableConstruct` | `ComputeWriteableSubResourceData` |
| `DataDiskImageEncryption` | `ProvisionableConstruct` | `DiskImageEncryption` |
| `DedicatedHostInstanceViewWithName` | `ProvisionableConstruct` | `DedicatedHostInstanceView` |
| `DiskEncryptionSetParameters` | `ProvisionableConstruct` | `ComputeWriteableSubResourceData` |
| `DiskRestorePointAttributes` | `ProvisionableConstruct` | `ComputeSubResourceData` |
| `GalleryApplicationVersionPublishingProfile` | `ProvisionableConstruct` | `GalleryArtifactPublishingProfileBase` |
| `GalleryApplicationVersionSafetyProfile` | `ProvisionableConstruct` | `GalleryArtifactSafetyProfileBase` |
| `GalleryArtifactVersionFullSource` | `ProvisionableConstruct` | `GalleryArtifactVersionSource` |
| `GalleryDataDiskImage` | `ProvisionableConstruct` | `GalleryDiskImage` |
| `GalleryDiskImageSource` | `ProvisionableConstruct` | `GalleryArtifactVersionSource` |
| `GalleryImageVersionPublishingProfile` | `ProvisionableConstruct` | `GalleryArtifactPublishingProfileBase` |
| `GalleryImageVersionSafetyProfile` | `ProvisionableConstruct` | `GalleryArtifactSafetyProfileBase` |
| `GalleryInVmAccessControlProfileProperties` | `ProvisionableConstruct` | `GalleryResourceProfilePropertiesBase` |
| `GalleryInVmAccessControlProfileVersionProperties` | `ProvisionableConstruct` | `GalleryResourceProfileVersionPropertiesBase` |
| `GalleryOSDiskImage` | `ProvisionableConstruct` | `GalleryDiskImage` |
| `GalleryScriptParameter` | `ProvisionableConstruct` | `GenericGalleryParameter` |
| `GalleryScriptVersionPublishingProfile` | `ProvisionableConstruct` | `GalleryArtifactPublishingProfileBase` |
| `GalleryScriptVersionSafetyProfile` | `ProvisionableConstruct` | `GalleryArtifactSafetyProfileBase` |
| `ImageDataDisk` | `ProvisionableConstruct` | `ImageDisk` |
| `ImageOSDisk` | `ProvisionableConstruct` | `ImageDisk` |
| `ImageReference` | `ProvisionableConstruct` | `ComputeWriteableSubResourceData` |
| `OSDiskImageEncryption` | `ProvisionableConstruct` | `DiskImageEncryption` |
| `VirtualMachineManagedDisk` | `ProvisionableConstruct` | `ComputeWriteableSubResourceData` |
| `VirtualMachineNetworkInterfaceReference` | `ProvisionableConstruct` | `ComputeWriteableSubResourceData` |

Model file churn: added **10**, deleted **0**, renamed **0**.
- Added model `DiskImageEncryption.cs`
- Added model `GalleryArtifactPublishingProfileBase.cs`
- Added model `GalleryArtifactSafetyProfileBase.cs`
- Added model `GalleryArtifactVersionSource.cs`
- Added model `GalleryDiskImage.cs`
- Added model `GalleryResourceProfilePropertiesBase.cs`
- Added model `GalleryResourceProfileVersionPropertiesBase.cs`
- Added model `GenericGalleryParameter.cs`
- Added model `ImageDisk.cs`
- Added model `VirtualMachineScaleSetExtension.cs`

## sdk containerinstance Azure.Provisioning.ContainerInstance[-1]

Resource count: **4 -> 3**. ARM resource types added/deleted: **+0/-1**. Resource class renames: **0**.

Deleted ARM resource types:
- `Microsoft.ContainerInstance/containerGroups` was `ContainerGroup`

Model file churn: added **0**, deleted **9**, renamed **0**.
- Deleted model `ContainerGroupDnsConfiguration.cs`
- Deleted model `ContainerGroupIdentityAccessControl.cs`
- Deleted model `ContainerGroupIdentityAccessControlLevels.cs`
- Deleted model `ContainerGroupIdentityAccessLevel.cs`
- Deleted model `ContainerGroupInstanceView.cs`
- Deleted model `ContainerGroupProfileReferenceDefinition.cs`
- Deleted model `ContainerGroupPropertiesProperties.cs`
- Deleted model `ContainerGroupSecretReference.cs`
- Deleted model `StandbyPoolProfileDefinition.cs`

## sdk containerregistry Azure.Provisioning.ContainerRegistry.Tasks[-1]

Resource count: **4 -> 4**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **4**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.ContainerRegistry/registries/agentPools` | `ContainerRegistryAgentPool` | `AgentPool` |
| `Microsoft.ContainerRegistry/registries/runs` | `ContainerRegistryRun` | `Run` |
| `Microsoft.ContainerRegistry/registries/taskRuns` | `ContainerRegistryTaskRun` | `TaskRun` |
| `Microsoft.ContainerRegistry/registries/tasks` | `ContainerRegistryTask` | `Task` |

## sdk containerservice Azure.Provisioning.ContainerService[-1]

Resource count: **12 -> 12**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **8**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.ContainerService/managedClusters` | `ContainerServiceManagedCluster` | `ManagedCluster` |
| `Microsoft.ContainerService/managedClusters/agentPools` | `ContainerServiceAgentPool` | `AgentPool` |
| `Microsoft.ContainerService/managedClusters/agentPools/machines` | `ContainerServiceMachine` | `Machine` |
| `Microsoft.ContainerService/managedClusters/maintenanceConfigurations` | `ContainerServiceMaintenanceConfiguration` | `MaintenanceConfiguration` |
| `Microsoft.ContainerService/managedClusters/managedNamespaces` | `ManagedClusterNamespace` | `ManagedNamespace` |
| `Microsoft.ContainerService/managedClusters/privateEndpointConnections` | `ContainerServicePrivateEndpointConnection` | `PrivateEndpointConnection` |
| `Microsoft.ContainerService/managedClusters/trustedAccessRoleBindings` | `ContainerServiceTrustedAccessRoleBinding` | `TrustedAccessRoleBinding` |
| `Microsoft.ContainerService/snapshots` | `AgentPoolSnapshot` | `Snapshot` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `ManagedClusterAddonProfileIdentity` | `ProvisionableConstruct` | `ContainerServiceUserAssignedIdentity` |
| `ManagedClusterAgentPoolProfile` | `ProvisionableConstruct` | `ManagedClusterAgentPoolProfileProperties` |
| `MeshUpgradeProfileProperties` | `ProvisionableConstruct` | `MeshRevision` |

## sdk costmanagement Azure.Provisioning.CostManagement[-1]

Resource count: **9 -> 9**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **4**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.CostManagement/alerts` | `CostManagementAlert` | `Alert` |
| `Microsoft.CostManagement/costAllocationRules` | `CostAllocationRule` | `ExternalResourceCostAllocationRuleDefinition` |
| `Microsoft.CostManagement/exports` | `CostManagementExport` | `Export` |
| `Microsoft.CostManagement/settings` | `CostManagementSetting` | `Setting` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `ExportProperties` | `ProvisionableConstruct` | `CommonExportProperties` |
| `SourceCostAllocationEntity` | `ProvisionableConstruct` | `CostAllocationEntity` |
| `TargetCostAllocationEntity` | `ProvisionableConstruct` | `CostAllocationEntity` |

Model file churn: added **1**, deleted **0**, renamed **0**.
- Added model `CostAllocationEntity.cs`

## sdk domainregistration Azure.Provisioning.DomainRegistration[-1]

Resource count: **3 -> 3**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **1**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.DomainRegistration/domains` | `AppServiceDomain` | `Domain` |

## sdk durabletask Azure.Provisioning.DurableTask[-1]

Resource count: **5 -> 5**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **5**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.DurableTask/schedulers` | `DurableTaskScheduler` | `Scheduler` |
| `Microsoft.DurableTask/schedulers/privateEndpointConnections` | `DurableTaskPrivateEndpointConnection` | `SchedulerPrivateEndpointConnection` |
| `Microsoft.DurableTask/schedulers/privateLinkResources` | `DurableTaskSchedulerPrivateLinkResource` | `SchedulerSchedulerPrivateLinkResource` |
| `Microsoft.DurableTask/schedulers/retentionPolicies` | `DurableTaskRetentionPolicy` | `RetentionPolicy` |
| `Microsoft.DurableTask/schedulers/taskHubs` | `DurableTaskHub` | `TaskHub` |

## sdk eventhub Azure.Provisioning.EventHubs[-1]

Resource count: **13 -> 0**. ARM resource types added/deleted: **+0/-13**. Resource class renames: **0**.

Deleted ARM resource types:
- `Microsoft.EventHub/clusters` was `EventHubsCluster`
- `Microsoft.EventHub/namespaces` was `EventHubsNamespace`
- `Microsoft.EventHub/namespaces/applicationGroups` was `EventHubsApplicationGroup`
- `Microsoft.EventHub/namespaces/authorizationRules` was `EventHubsNamespaceAuthorizationRule`
- `Microsoft.EventHub/namespaces/disasterRecoveryConfigs` was `EventHubsDisasterRecovery`
- `Microsoft.EventHub/namespaces/disasterRecoveryConfigs/authorizationRules` was `EventHubsDisasterRecoveryAuthorizationRule`
- `Microsoft.EventHub/namespaces/eventhubs` was `EventHub`
- `Microsoft.EventHub/namespaces/eventhubs/authorizationRules` was `EventHubAuthorizationRule`
- `Microsoft.EventHub/namespaces/eventhubs/consumergroups` was `EventHubsConsumerGroup`
- `Microsoft.EventHub/namespaces/networkRuleSets` was `EventHubsNetworkRuleSet`
- `Microsoft.EventHub/namespaces/networkSecurityPerimeterConfigurations` was `EventHubsNetworkSecurityPerimeterConfiguration`
- `Microsoft.EventHub/namespaces/privateEndpointConnections` was `EventHubsPrivateEndpointConnection`
- `Microsoft.EventHub/namespaces/schemagroups` was `EventHubsSchemaGroup`

Model file churn: added **0**, deleted **69**, renamed **0**.

## sdk frontdoor Azure.Provisioning.FrontDoor[-1]

Resource count: **6 -> 0**. ARM resource types added/deleted: **+0/-6**. Resource class renames: **0**.

Deleted ARM resource types:
- `Microsoft.Network/frontDoors` was `FrontDoorResource`
- `Microsoft.Network/frontDoors/frontendEndpoints` was `FrontendEndpoint`
- `Microsoft.Network/frontDoors/rulesEngines` was `FrontDoorRulesEngine`
- `Microsoft.Network/FrontDoorWebApplicationFirewallPolicies` was `FrontDoorWebApplicationFirewallPolicy`
- `Microsoft.Network/NetworkExperimentProfiles` was `FrontDoorNetworkExperimentProfile`
- `Microsoft.Network/NetworkExperimentProfiles/Experiments` was `FrontDoorExperiment`

Model file churn: added **0**, deleted **102**, renamed **0**.

## sdk iothub Azure.Provisioning.IotHub[-1]

Resource count: **4 -> 4**. ARM resource types added/deleted: **+1/-1**. Resource class renames: **2**.

Added ARM resource types:
- `Microsoft.Devices/IotHubs/jobs` -> `IotHubDescription`

Deleted ARM resource types:
- `Microsoft.Devices/IotHubs` was `IotHubDescription`

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.Devices/IotHubs/certificates` | `IotHubCertificateDescription` | `CertificateDescription` |
| `Microsoft.Devices/iotHubs/privateEndpointConnections` | `IotHubPrivateEndpointConnection` | `IotHubsPrivateEndpointConnections` |

## sdk keyvault Azure.Provisioning.KeyVault[-1]

Resource count: **7 -> 7**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **5**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.KeyVault/locations/deletedVaults` | `DeletedKeyVault` | `DeletedVault` |
| `Microsoft.KeyVault/managedHSMs/privateEndpointConnections` | `ManagedHsmPrivateEndpointConnection` | `MhsmPrivateEndpointConnection` |
| `Microsoft.KeyVault/vaults` | `KeyVaultService` | `Vault` |
| `Microsoft.KeyVault/vaults/privateEndpointConnections` | `KeyVaultPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `Microsoft.KeyVault/vaults/secrets` | `KeyVaultSecret` | `Secret` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `SecretAttributes` | `ProvisionableConstruct` | `SecretBaseAttributes` |

Model file churn: added **1**, deleted **0**, renamed **0**.
- Added model `SecretBaseAttributes.cs`

## sdk machinelearningservices Azure.Provisioning.MachineLearning[-1]

Resource count: **41 -> 41**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **21**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.MachineLearningServices/registries` | `MachineLearningRegistry` | `Registry` |
| `Microsoft.MachineLearningServices/registries/components` | `MachineLearningRegistryComponentContainer` | `MachineLearninRegistryComponentContainer` |
| `Microsoft.MachineLearningServices/registries/components/versions` | `MachineLearningRegistryComponentVersion` | `MachineLearninRegistryComponentVersion` |
| `Microsoft.MachineLearningServices/workspaces` | `MachineLearningWorkspace` | `Workspace` |
| `Microsoft.MachineLearningServices/workspaces/batchEndpoints` | `MachineLearningBatchEndpoint` | `BatchEndpoint` |
| `Microsoft.MachineLearningServices/workspaces/batchEndpoints/deployments` | `MachineLearningBatchDeployment` | `BatchDeployment` |
| `Microsoft.MachineLearningServices/workspaces/computes` | `MachineLearningCompute` | `ComputeResource` |
| `Microsoft.MachineLearningServices/workspaces/connections` | `MachineLearningWorkspaceConnection` | `WorkspaceConnectionPropertiesV2BasicResource` |
| `Microsoft.MachineLearningServices/workspaces/datastores` | `MachineLearningDatastore` | `Datastore` |
| `Microsoft.MachineLearningServices/workspaces/featuresets` | `MachineLearningFeatureSetContainer` | `FeaturesetContainer` |
| `Microsoft.MachineLearningServices/workspaces/featuresets/versions` | `MachineLearningFeatureSetVersion` | `FeaturesetVersion` |
| `Microsoft.MachineLearningServices/workspaces/featuresets/versions/features` | `MachineLearningFeature` | `VersionsFeatures` |
| `Microsoft.MachineLearningServices/workspaces/featurestoreEntities` | `MachineLearningFeatureStoreEntityContainer` | `FeaturestoreEntityContainer` |
| `Microsoft.MachineLearningServices/workspaces/featurestoreEntities/versions` | `MachineLearningFeaturestoreEntityVersion` | `FeaturestoreEntityVersion` |
| `Microsoft.MachineLearningServices/workspaces/jobs` | `MachineLearningJob` | `JobBase` |
| `Microsoft.MachineLearningServices/workspaces/marketplaceSubscriptions` | `MachineLearningMarketplaceSubscription` | `MarketplaceSubscription` |
| `Microsoft.MachineLearningServices/workspaces/onlineEndpoints` | `MachineLearningOnlineEndpoint` | `OnlineEndpoint` |
| `Microsoft.MachineLearningServices/workspaces/onlineEndpoints/deployments` | `MachineLearningOnlineDeployment` | `OnlineDeployment` |
| `Microsoft.MachineLearningServices/workspaces/privateEndpointConnections` | `MachineLearningPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `Microsoft.MachineLearningServices/workspaces/schedules` | `MachineLearningSchedule` | `Schedule` |
| `Microsoft.MachineLearningServices/workspaces/serverlessEndpoints` | `MachineLearningServerlessEndpoint` | `ServerlessEndpoint` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `CapabilityHostProperties` | `ProvisionableConstruct` | `MachineLearningResourceBase` |
| `ClassificationTrainingSettings` | `ProvisionableConstruct` | `MachineLearningTrainingSettings` |
| `ForecastingTrainingSettings` | `ProvisionableConstruct` | `MachineLearningTrainingSettings` |
| `ImageModelDistributionSettingsClassification` | `ProvisionableConstruct` | `ImageModelDistributionSettings` |
| `ImageModelDistributionSettingsObjectDetection` | `ProvisionableConstruct` | `ImageModelDistributionSettings` |
| `ImageModelSettingsClassification` | `ProvisionableConstruct` | `ImageModelSettings` |
| `ImageModelSettingsObjectDetection` | `ProvisionableConstruct` | `ImageModelSettings` |
| `MachineLearningBatchDeploymentProperties` | `ProvisionableConstruct` | `MachineLearningEndpointDeploymentProperties` |
| `MachineLearningBatchEndpointProperties` | `ProvisionableConstruct` | `MachineLearningEndpointProperties` |
| `MachineLearningCodeContainerProperties` | `ProvisionableConstruct` | `MachineLearningAssetContainer` |
| `MachineLearningCodeVersionProperties` | `ProvisionableConstruct` | `MachineLearningAssetBase` |
| `MachineLearningComponentContainerProperties` | `ProvisionableConstruct` | `MachineLearningAssetContainer` |
| `MachineLearningComponentVersionProperties` | `ProvisionableConstruct` | `MachineLearningAssetBase` |
| `MachineLearningDataContainerProperties` | `ProvisionableConstruct` | `MachineLearningAssetContainer` |
| `MachineLearningDatastoreProperties` | `ProvisionableConstruct` | `MachineLearningResourceBase` |
| `MachineLearningDataVersionProperties` | `ProvisionableConstruct` | `MachineLearningAssetBase` |
| `MachineLearningDeploymentResourceConfiguration` | `ProvisionableConstruct` | `MachineLearningResourceConfiguration` |
| `MachineLearningEnvironmentContainerProperties` | `ProvisionableConstruct` | `MachineLearningAssetContainer` |
| `MachineLearningEnvironmentVersionProperties` | `ProvisionableConstruct` | `MachineLearningAssetBase` |
| `MachineLearningFeatureProperties` | `ProvisionableConstruct` | `MachineLearningResourceBase` |
| `MachineLearningFeatureSetContainerProperties` | `ProvisionableConstruct` | `MachineLearningAssetContainer` |
| `MachineLearningFeatureSetVersionProperties` | `ProvisionableConstruct` | `MachineLearningAssetBase` |
| `MachineLearningFeatureStoreEntityContainerProperties` | `ProvisionableConstruct` | `MachineLearningAssetContainer` |
| `MachineLearningFeatureStoreEntityVersionProperties` | `ProvisionableConstruct` | `MachineLearningAssetBase` |
| `MachineLearningJobProperties` | `ProvisionableConstruct` | `MachineLearningResourceBase` |
| `MachineLearningJobResourceConfiguration` | `ProvisionableConstruct` | `MachineLearningResourceConfiguration` |
| `MachineLearningModelContainerProperties` | `ProvisionableConstruct` | `MachineLearningAssetContainer` |
| `MachineLearningModelVersionProperties` | `ProvisionableConstruct` | `MachineLearningAssetBase` |
| `MachineLearningOnlineDeploymentProperties` | `ProvisionableConstruct` | `MachineLearningEndpointDeploymentProperties` |
| `MachineLearningOnlineEndpointProperties` | `ProvisionableConstruct` | `MachineLearningEndpointProperties` |
| `MachineLearningScheduleProperties` | `ProvisionableConstruct` | `MachineLearningResourceBase` |
| `NlpVerticalFeaturizationSettings` | `ProvisionableConstruct` | `MachineLearningFeaturizationSettings` |
| `RegistryPrivateEndpoint` | `ProvisionableConstruct` | `PrivateEndpointBase` |
| `RegressionTrainingSettings` | `ProvisionableConstruct` | `MachineLearningTrainingSettings` |
| `TableVerticalFeaturizationSettings` | `ProvisionableConstruct` | `MachineLearningFeaturizationSettings` |

Model file churn: added **11**, deleted **0**, renamed **0**.
- Added model `ImageModelDistributionSettings.cs`
- Added model `ImageModelSettings.cs`
- Added model `MachineLearningAssetBase.cs`
- Added model `MachineLearningAssetContainer.cs`
- Added model `MachineLearningEndpointDeploymentProperties.cs`
- Added model `MachineLearningEndpointProperties.cs`
- Added model `MachineLearningFeaturizationSettings.cs`
- Added model `MachineLearningResourceBase.cs`
- Added model `MachineLearningResourceConfiguration.cs`
- Added model `MachineLearningTrainingSettings.cs`
- Added model `PrivateEndpointBase.cs`

## sdk mysql Azure.Provisioning.MySql[-1]

Resource count: **11 -> 11**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **10**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.DBforMySQL/flexibleServers` | `MySqlFlexibleServer` | `Server` |
| `Microsoft.DBforMySQL/flexibleServers/administrators` | `MySqlFlexibleServerAadAdministrator` | `AzureADAdministrator` |
| `Microsoft.DBforMySQL/flexibleServers/backups` | `MySqlFlexibleServerBackup` | `ServerBackup` |
| `Microsoft.DBforMySQL/flexibleServers/backupsV2` | `MySqlFlexibleServerBackupV2` | `ServerBackupV2` |
| `Microsoft.DBforMySQL/flexibleServers/configurations` | `MySqlFlexibleServerConfiguration` | `Configuration` |
| `Microsoft.DBforMySQL/flexibleServers/databases` | `MySqlFlexibleServerDatabase` | `Database` |
| `Microsoft.DBforMySQL/flexibleServers/firewallRules` | `MySqlFlexibleServerFirewallRule` | `FirewallRule` |
| `Microsoft.DBforMySQL/flexibleServers/maintenances` | `MySqlFlexibleServerMaintenance` | `Maintenance` |
| `Microsoft.DBforMySQL/flexibleServers/privateEndpointConnections` | `MySqlFlexibleServersPrivateEndpointConnection` | `ServerPrivateEndpointConnection` |
| `Microsoft.DBforMySQL/locations/capabilitySets` | `MySqlFlexibleServersCapability` | `LocationsCapabilitySets` |

## sdk operationalinsights Azure.Provisioning.OperationalInsights[-1]

Resource count: **12 -> 12**. ARM resource types added/deleted: **+1/-1**. Resource class renames: **9**.

Added ARM resource types:
- `Microsoft.OperationalInsights/workspaces/operations` -> `WorkspacesOperations`

Deleted ARM resource types:
- `Microsoft.OperationalInsights/workspaces/dataSources` was `OperationalInsightsDataSource`

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.OperationalInsights/clusters` | `OperationalInsightsCluster` | `Cluster` |
| `Microsoft.OperationalInsights/queryPacks/queries` | `LogAnalyticsQuery` | `LogAnalyticsQueryPackQuery` |
| `Microsoft.OperationalInsights/workspaces` | `OperationalInsightsWorkspace` | `Workspace` |
| `Microsoft.OperationalInsights/workspaces/dataExports` | `OperationalInsightsDataExport` | `DataExport` |
| `Microsoft.OperationalInsights/workspaces/linkedServices` | `OperationalInsightsLinkedService` | `LinkedService` |
| `Microsoft.OperationalInsights/workspaces/linkedStorageAccounts` | `OperationalInsightsLinkedStorageAccounts` | `WorkspacesLinkedStorageAccounts` |
| `Microsoft.OperationalInsights/workspaces/savedSearches` | `OperationalInsightsSavedSearch` | `SavedSearch` |
| `Microsoft.OperationalInsights/workspaces/summaryLogs` | `OperationalInsightsSummaryLogs` | `WorkspacesSummaryLogs` |
| `Microsoft.OperationalInsights/workspaces/tables` | `OperationalInsightsTable` | `WorkspacesTables` |

Model file churn: added **0**, deleted **1**, renamed **0**.
- Deleted model `OperationalInsightsDataSourceKind.cs`

## sdk recoveryservices-backup Azure.Provisioning.RecoveryServicesBackup[-1]

Resource count: **12 -> 12**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **12**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.RecoveryServices/vaults/backupconfig` | `BackupResourceVaultConfig` | `BackupResourceVaultConfigResource` |
| `Microsoft.RecoveryServices/vaults/backupEncryptionConfigs` | `BackupResourceEncryptionConfigExtended` | `BackupResourceEncryptionConfigExtendedResource` |
| `Microsoft.RecoveryServices/vaults/backupEngines` | `BackupEngine` | `BackupEngineBaseResource` |
| `Microsoft.RecoveryServices/vaults/backupFabrics/backupProtectionIntent` | `BackupProtectionIntent` | `ProtectionIntentResource` |
| `Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers` | `BackupProtectionContainer` | `ProtectionContainerResource` |
| `Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems` | `BackupProtectedItem` | `ProtectedItemResource` |
| `Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/recoveryPoints` | `BackupRecoveryPoint` | `RecoveryPointResource` |
| `Microsoft.RecoveryServices/vaults/backupJobs` | `BackupJob` | `JobResource` |
| `Microsoft.RecoveryServices/vaults/backupPolicies` | `BackupProtectionPolicy` | `ProtectionPolicyResource` |
| `Microsoft.RecoveryServices/vaults/backupResourceGuardProxies` | `ResourceGuardProxy` | `ResourceGuardProxyBaseResource` |
| `Microsoft.RecoveryServices/vaults/backupstorageconfig` | `BackupResourceConfig` | `BackupResourceConfigResource` |
| `Microsoft.RecoveryServices/vaults/privateEndpointConnections` | `BackupPrivateEndpointConnection` | `PrivateEndpointConnectionResource` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `BackupResourceEncryptionConfigExtendedProperties` | `ProvisionableConstruct` | `BackupResourceEncryptionConfig` |
| `IaasVmHealthDetails` | `ProvisionableConstruct` | `ResourceHealthDetails` |
| `RecoveryPointTierInformationV2` | `ProvisionableConstruct` | `RecoveryPointTierInformation` |

Model file churn: added **1**, deleted **0**, renamed **0**.
- Added model `BackupResourceEncryptionConfig.cs`

## sdk recoveryservices Azure.Provisioning.RecoveryServices[-1]

Resource count: **4 -> 4**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **4**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.RecoveryServices/locations/deletedVaults` | `RecoveryServicesDeletedVault` | `LocationsDeletedVaults` |
| `Microsoft.RecoveryServices/vaults` | `RecoveryServicesVault` | `Vaults` |
| `Microsoft.RecoveryServices/vaults/extendedInformation` | `RecoveryServicesVaultExtendedInfo` | `VaultExtendedInfoResource` |
| `Microsoft.RecoveryServices/vaults/privateLinkResources` | `RecoveryServicesPrivateLinkResource` | `PrivateLinkResource` |

## sdk redis Azure.Provisioning.Redis[-1]

Resource count: **7 -> 7**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **3**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.Cache/redis/linkedServers` | `RedisLinkedServerWithProperty` | `RedisLinkedServers` |
| `Microsoft.Cache/redis/patchSchedules` | `RedisPatchSchedule` | `RedisPatchSchedules` |
| `Microsoft.Cache/redis/privateEndpointConnections` | `RedisPrivateEndpointConnection` | `RedisResourcePrivateEndpointConnection` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `RedisLinkedServerProperties` | `ProvisionableConstruct` | `RedisLinkedServerCreateProperties` |
| `RedisProperties` | `ProvisionableConstruct` | `RedisCreateProperties` |

Model file churn: added **3**, deleted **0**, renamed **0**.
- Added model `RedisCommonProperties.cs`
- Added model `RedisCreateProperties.cs`
- Added model `RedisLinkedServerCreateProperties.cs`

## sdk resourcegraph Azure.Provisioning.ResourceGraph[-1]

Resource count: **1 -> 1**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **0**.

No resource identity/name/setter/base-type pattern found; changes are limited to generated implementation/model content.

## sdk search Azure.Provisioning.Search[-1]

Resource count: **4 -> 4**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **2**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.Search/searchServices/privateEndpointConnections` | `SearchPrivateEndpointConnection` | `PrivateEndpointConnection` |
| `Microsoft.Search/searchServices/sharedPrivateLinkResources` | `SharedSearchServicePrivateLink` | `SharedPrivateLinkResource` |

## sdk servicefabric Azure.Provisioning.ServiceFabric[-1]

Resource count: **6 -> 6**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **6**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.ServiceFabric/clusters` | `ServiceFabricCluster` | `Cluster` |
| `Microsoft.ServiceFabric/clusters/applications` | `ServiceFabricApplication` | `ApplicationResource` |
| `Microsoft.ServiceFabric/clusters/applications/services` | `ServiceFabricService` | `ServiceResource` |
| `Microsoft.ServiceFabric/clusters/applicationTypes` | `ServiceFabricApplicationType` | `ApplicationTypeResource` |
| `Microsoft.ServiceFabric/clusters/applicationTypes/versions` | `ServiceFabricApplicationTypeVersion` | `ApplicationTypeVersionResource` |
| `Microsoft.ServiceFabric/locations/unsupportedVmSizes` | `ServiceFabricVmSizeResource` | `LocationsUnsupportedVmSizes` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `ApplicationResourceProperties` | `ProvisionableConstruct` | `ApplicationResourceUpdateProperties` |
| `ServiceResourceProperties` | `ProvisionableConstruct` | `ServiceResourcePropertiesBase` |

Model file churn: added **2**, deleted **0**, renamed **0**.
- Added model `ApplicationResourceUpdateProperties.cs`
- Added model `ServiceResourcePropertiesBase.cs`

## sdk servicefabricmanagedclusters Azure.Provisioning.ServiceFabricManagedClusters[-1]

Resource count: **6 -> 6**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **6**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.ServiceFabric/managedClusters` | `ServiceFabricManagedCluster` | `ManagedCluster` |
| `Microsoft.ServiceFabric/managedClusters/applications` | `ServiceFabricManagedApplication` | `ApplicationResource` |
| `Microsoft.ServiceFabric/managedClusters/applications/services` | `ServiceFabricManagedService` | `ServiceResource` |
| `Microsoft.ServiceFabric/managedClusters/applicationTypes` | `ServiceFabricManagedApplicationType` | `ApplicationTypeResource` |
| `Microsoft.ServiceFabric/managedClusters/applicationTypes/versions` | `ServiceFabricManagedApplicationTypeVersion` | `ApplicationTypeVersionResource` |
| `Microsoft.ServiceFabric/managedClusters/nodeTypes` | `ServiceFabricManagedNodeType` | `NodeType` |

Model base-type changes:

| Model | Old base | New base |
| --- | --- | --- |
| `ManagedServiceProperties` | `ProvisionableConstruct` | `ManagedServiceBaseProperties` |

Model file churn: added **1**, deleted **0**, renamed **0**.
- Added model `ManagedServiceBaseProperties.cs`

## sdk servicenetworking Azure.Provisioning.ServiceNetworking[-1]

Resource count: **4 -> 4**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **3**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.ServiceNetworking/trafficControllers/associations` | `TrafficControllerAssociation` | `Association` |
| `Microsoft.ServiceNetworking/trafficControllers/frontends` | `TrafficControllerFrontend` | `Frontend` |
| `Microsoft.ServiceNetworking/trafficControllers/securityPolicies` | `ApplicationGatewayForContainersSecurityPolicy` | `SecurityPolicy` |

## sdk standbypool Azure.Provisioning.StandbyPool[-1]

Resource count: **5 -> 5**. ARM resource types added/deleted: **+0/-0**. Resource class renames: **5**.

Resource class renames by unchanged ARM type:

| ARM resource type | Old class | New class |
| --- | --- | --- |
| `Microsoft.StandbyPool/standbyContainerGroupPools` | `StandbyContainerGroupPool` | `StandbyContainerGroupPoolResource` |
| `Microsoft.StandbyPool/standbyContainerGroupPools/runtimeViews` | `StandbyContainerGroupPoolRuntimeView` | `StandbyContainerGroupPoolRuntimeViewResource` |
| `Microsoft.StandbyPool/standbyVirtualMachinePools` | `StandbyVirtualMachinePool` | `StandbyVirtualMachinePoolResource` |
| `Microsoft.StandbyPool/standbyVirtualMachinePools/runtimeViews` | `StandbyVirtualMachinePoolRuntimeView` | `StandbyVirtualMachinePoolRuntimeViewResource` |
| `Microsoft.StandbyPool/standbyVirtualMachinePools/standbyVirtualMachines` | `StandbyVirtualMachine` | `StandbyVirtualMachineResource` |

## sdk trafficmanager Azure.Provisioning.TrafficManager[-1]

Resource count: **7 -> 0**. ARM resource types added/deleted: **+0/-7**. Resource class renames: **0**.

Deleted ARM resource types:
- `Microsoft.Network/trafficManagerGeographicHierarchies` was `TrafficManagerGeographicHierarchy`
- `Microsoft.Network/trafficmanagerprofiles` was `TrafficManagerProfile`
- `Microsoft.Network/trafficmanagerprofiles/AzureEndpoints` was `AzureEndpointTrafficManagerEndpoint`
- `Microsoft.Network/trafficmanagerprofiles/ExternalEndpoints` was `ExternalEndpointTrafficManagerEndpoint`
- `Microsoft.Network/trafficmanagerprofiles/heatMaps` was `TrafficManagerHeatMap`
- `Microsoft.Network/trafficmanagerprofiles/NestedEndpoints` was `NestedEndpointTrafficManagerEndpoint`
- `Microsoft.Network/trafficManagerUserMetricsKeys` was `TrafficManagerUserMetrics`

Model file churn: added **0**, deleted **24**, renamed **0**.
