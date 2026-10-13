# Provisioning resolveArmResources library change analysis

Baseline: upstream main `b1535bd1114`. Refreshed on 2026-10-13.

This report compares generated resource identities and class names after regeneration with main's npm dependencies: TypeSpec compiler 1.17.0, typespec-azure-resource-manager 0.73.0, and management emitter 1.0.0-alpha.20260929.3. Provisioning uses resolveArmResources, filtered to the selected TCGC models and methods before resource projection.

The .NET management generator is built from the same main source snapshot. Main's published management generator binary is incompatible with the updated shared generator (its InputOperation.Update method signature no longer exists). No local management npm links or ARM prerelease pins are used.

This source-reference setup is validated locally. Run `npm ci --prefix eng\packages\http-client-csharp-mgmt` before building provisioning on a clean checkout. Provisioning CI initialization is intentionally unchanged; it does not currently install these local management build prerequisites.

Existing custom-code resource names are preserved for the canonical projection of each input model. Additional projections of a shared model retain their distinct resolved names; customizations targeting those resolved names take precedence.

Resource identity is the literal ARM resource type in the generated ProvisionableResource constructor. Counts are distinct ARM resource types. Class-name sets are compared without discarding duplicate identities.

The inherited Batch spec override remains pinned to `4de3d49dac2214ca0d31bd0082ffafe27d564e67`, rather than main's `b680f68b60d1989b74c897978e9af63768d9941a`; Batch differences therefore include spec drift. Other libraries use their merged tsp-location.yaml pins.

This refreshed report does not analyze model base types, setters, or API compatibility. Prior findings and issue associations are historical, not revalidated conclusions for this run. Successful emission alone does not establish that every generated SDK builds or has compatible APIs.

## Summary

Libraries inventoried: **69**.

Regeneration completed for all inventoried libraries: the final full run passed 68 of 69, and Redis passed on retry after a transient metadata file-write failure. Missing or incorrect discovered resources are intentionally preserved for validation rather than repaired. Provisioning parent paths are retained separately from the serialized management graph.

| Library | ARM resource types | Adds | Deletes | Changed class-name sets |
| --- | --- | --- | --- | --- |
| `Azure.Provisioning.ApiManagement` | 100 -> 100 | 0 | 0 | 34 |
| `Azure.Provisioning.AppConfiguration` | 7 -> 6 | 0 | 1 | 2 |
| `Azure.Provisioning.ApplicationInsights` | 6 -> 4 | 0 | 2 | 2 |
| `Azure.Provisioning.AppNetwork` | 2 -> 2 | 0 | 0 | 0 |
| `Azure.Provisioning.Attestation` | 2 -> 2 | 0 | 0 | 1 |
| `Azure.Provisioning.Batch` | 8 -> 9 | 1 | 0 | 7 |
| `Azure.Provisioning.BotService` | 5 -> 5 | 0 | 0 | 3 |
| `Azure.Provisioning.Cdn` | 15 -> 15 | 0 | 0 | 12 |
| `Azure.Provisioning.CertificateRegistration` | 3 -> 3 | 0 | 0 | 2 |
| `Azure.Provisioning.CognitiveServices` | 28 -> 28 | 0 | 0 | 7 |
| `Azure.Provisioning.Communication` | 7 -> 7 | 0 | 0 | 3 |
| `Azure.Provisioning.Compute` | 37 -> 35 | 0 | 2 | 13 |
| `Azure.Provisioning.AppContainers` | 38 -> 38 | 0 | 0 | 15 |
| `Azure.Provisioning.ContainerInstance` | 4 -> 3 | 0 | 1 | 0 |
| `Azure.Provisioning.ContainerRegistry` | 10 -> 11 | 1 | 0 | 1 |
| `Azure.Provisioning.ContainerRegistry.Tasks` | 4 -> 4 | 0 | 0 | 4 |
| `Azure.Provisioning.ContainerService` | 12 -> 12 | 0 | 0 | 8 |
| `Azure.Provisioning.CosmosDB` | 46 -> 48 | 2 | 0 | 12 |
| `Azure.Provisioning.CostManagement` | 9 -> 9 | 0 | 0 | 4 |
| `Azure.Provisioning.DataBox` | 1 -> 1 | 0 | 0 | 1 |
| `Azure.Provisioning.Databricks` | 5 -> 5 | 0 | 0 | 5 |
| `Azure.Provisioning.DesktopVirtualization` | 17 -> 17 | 0 | 0 | 5 |
| `Azure.Provisioning.Dns` | 15 -> 2 | 0 | 13 | 0 |
| `Azure.Provisioning.DomainRegistration` | 3 -> 3 | 0 | 0 | 1 |
| `Azure.Provisioning.DurableTask` | 5 -> 5 | 0 | 0 | 5 |
| `Azure.Provisioning.Enclave` | 9 -> 9 | 0 | 0 | 9 |
| `Azure.Provisioning.EventGrid` | 32 -> 27 | 0 | 5 | 1 |
| `Azure.Provisioning.EventHubs` | 13 -> 13 | 0 | 0 | 4 |
| `Azure.Provisioning.Fabric` | 1 -> 1 | 0 | 0 | 0 |
| `Azure.Provisioning.FrontDoor` | 6 -> 0 | 0 | 6 | 0 |
| `Azure.Provisioning.HealthcareApis` | 10 -> 10 | 0 | 0 | 8 |
| `Azure.Provisioning.Kubernetes` | 1 -> 1 | 0 | 0 | 0 |
| `Azure.Provisioning.IotHub` | 4 -> 5 | 1 | 0 | 3 |
| `Azure.Provisioning.KeyVault` | 7 -> 7 | 0 | 0 | 1 |
| `Azure.Provisioning.KubernetesConfiguration.Extensions` | 1 -> 1 | 0 | 0 | 0 |
| `Azure.Provisioning.KubernetesConfiguration.ExtensionTypes` | 4 -> 4 | 0 | 0 | 0 |
| `Azure.Provisioning.KubernetesConfiguration.FluxConfigurations` | 1 -> 1 | 0 | 0 | 0 |
| `Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes` | 3 -> 3 | 0 | 0 | 2 |
| `Azure.Provisioning.Kusto` | 11 -> 9 | 0 | 2 | 8 |
| `Azure.Provisioning.LoadTesting` | 2 -> 2 | 0 | 0 | 2 |
| `Azure.Provisioning.MachineLearning` | 41 -> 42 | 1 | 0 | 21 |
| `Azure.Provisioning.Maps` | 4 -> 4 | 0 | 0 | 3 |
| `Azure.Provisioning.Monitor` | 18 -> 18 | 0 | 0 | 14 |
| `Azure.Provisioning.MySql` | 11 -> 11 | 0 | 0 | 10 |
| `Azure.Provisioning.Network` | 143 -> 0 | 0 | 143 | 0 |
| `Azure.Provisioning.OperationalInsights` | 12 -> 12 | 1 | 1 | 1 |
| `Azure.Provisioning.PostgreSql` | 13 -> 13 | 0 | 0 | 4 |
| `Azure.Provisioning.PrivateDns` | 10 -> 2 | 0 | 8 | 0 |
| `Azure.Provisioning.RecoveryServices` | 4 -> 5 | 1 | 0 | 4 |
| `Azure.Provisioning.RecoveryServicesBackup` | 12 -> 24 | 12 | 0 | 12 |
| `Azure.Provisioning.Redis` | 7 -> 7 | 0 | 0 | 0 |
| `Azure.Provisioning.RedisEnterprise` | 5 -> 5 | 0 | 0 | 1 |
| `Azure.Provisioning.ResourceGraph` | 1 -> 1 | 0 | 0 | 1 |
| `Azure.Provisioning.ResourceHealth` | 4 -> 4 | 0 | 0 | 1 |
| `Azure.Provisioning.Search` | 4 -> 4 | 0 | 0 | 0 |
| `Azure.Provisioning.SecurityCenter` | 63 -> 61 | 0 | 2 | 36 |
| `Azure.Provisioning.ServiceBus` | 14 -> 14 | 0 | 0 | 1 |
| `Azure.Provisioning.ServiceFabric` | 6 -> 6 | 0 | 0 | 6 |
| `Azure.Provisioning.ServiceFabricManagedClusters` | 6 -> 6 | 0 | 0 | 6 |
| `Azure.Provisioning.ServiceNetworking` | 4 -> 4 | 0 | 0 | 3 |
| `Azure.Provisioning.SignalR` | 7 -> 7 | 0 | 0 | 3 |
| `Azure.Provisioning.Sql` | 122 -> 120 | 1 | 3 | 12 |
| `Azure.Provisioning.StandbyPool` | 5 -> 5 | 0 | 0 | 5 |
| `Azure.Provisioning.Storage` | 21 -> 21 | 0 | 0 | 0 |
| `Azure.Provisioning.Subscription` | 3 -> 3 | 0 | 0 | 2 |
| `Azure.Provisioning.TrafficManager` | 7 -> 0 | 0 | 7 | 0 |
| `Azure.Provisioning.VerifiedId` | 1 -> 1 | 0 | 0 | 1 |
| `Azure.Provisioning.WebPubSub` | 8 -> 8 | 0 | 0 | 3 |
| `Azure.Provisioning.AppService` | 127 -> 128 | 1 | 0 | 4 |

## Local build and API export

Attempted **69** provisioning projects across **65** service directories: **26 passed, 39 failed**.

These results are diagnostic. Generation success is not build success. Per user direction, missing resources and incorrect generated surfaces are left unchanged. API listings were refreshed only where export succeeded; failed exports can leave the previous listings in place.

Commands use `eng\scripts\Export-API.ps1 <service> -ProjectListOverrideFile <scoped-project-list.props>`. Each override contains only the provisioning source projects for that service, with the same export flags as the repository script (including `RunApiCompat=false`).

| Service directory | Provisioning projects | Build/API export |
| --- | --- | --- |
| `apimanagement` | 1 | passed |
| `appconfiguration` | 1 | failed |
| `applicationinsights` | 1 | failed |
| `appnetwork` | 1 | passed |
| `attestation` | 1 | passed |
| `batch` | 1 | failed |
| `botservice` | 1 | passed |
| `cdn` | 1 | failed |
| `certificateregistration` | 1 | passed |
| `cognitiveservices` | 1 | failed |
| `communication` | 1 | passed |
| `compute` | 1 | failed |
| `containerapps` | 1 | failed |
| `containerinstance` | 1 | passed |
| `containerregistry` | 2 | failed |
| `containerservice` | 1 | failed |
| `cosmosdb` | 1 | failed |
| `costmanagement` | 1 | failed |
| `databox` | 1 | passed |
| `databricks` | 1 | failed |
| `desktopvirtualization` | 1 | failed |
| `dns` | 1 | failed |
| `domainregistration` | 1 | failed |
| `durabletask` | 1 | failed |
| `enclave` | 1 | passed |
| `eventgrid` | 1 | failed |
| `eventhub` | 1 | failed |
| `fabric` | 1 | passed |
| `frontdoor` | 1 | failed |
| `healthcareapis` | 1 | failed |
| `hybridkubernetes` | 1 | passed |
| `iothub` | 1 | passed |
| `keyvault` | 1 | passed |
| `kubernetesconfiguration` | 4 | passed |
| `kusto` | 1 | failed |
| `loadtestservice` | 1 | passed |
| `machinelearningservices` | 1 | failed |
| `maps` | 1 | failed |
| `monitor` | 1 | passed |
| `mysql` | 1 | failed |
| `network` | 1 | failed |
| `operationalinsights` | 1 | failed |
| `postgresql` | 1 | passed |
| `privatedns` | 1 | failed |
| `recoveryservices` | 1 | failed |
| `recoveryservices-backup` | 1 | passed |
| `redis` | 1 | failed |
| `redisenterprise` | 1 | failed |
| `resourcegraph` | 1 | passed |
| `resourcehealth` | 1 | passed |
| `search` | 1 | passed |
| `securitycenter` | 1 | failed |
| `servicebus` | 1 | passed |
| `servicefabric` | 1 | failed |
| `servicefabricmanagedclusters` | 1 | passed |
| `servicenetworking` | 1 | failed |
| `signalr` | 1 | failed |
| `sqlmanagement` | 1 | failed |
| `standbypool` | 1 | passed |
| `storage` | 1 | failed |
| `subscription` | 1 | passed |
| `trafficmanager` | 1 | passed |
| `verifiedid` | 1 | failed |
| `webpubsub` | 1 | failed |
| `websites` | 1 | failed |

### Compiler and analyzer failures

#### sdk/appconfiguration/Azure.Provisioning.AppConfiguration

- `CS0103`: The name 'ExpiresOn' does not exist in the current context (`sdk/appconfiguration/Azure.Provisioning.AppConfiguration/src/Custom/AppConfigurationSnapshot.cs`).
- `CS0103`: The name 'ResourceType' does not exist in the current context (`sdk/appconfiguration/Azure.Provisioning.AppConfiguration/src/Custom/AppConfigurationSnapshot.cs`).

#### sdk/applicationinsights/Azure.Provisioning.ApplicationInsights

- `CS0759`: No defining declaration found for implementing declaration of partial method 'ApplicationInsightsComponent.DefineAdditionalProperties()' (`sdk/applicationinsights/Azure.Provisioning.ApplicationInsights/src/Custom/ApplicationInsightsComponent.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ApplicationInsightsWebTest.DefineAdditionalProperties()' (`sdk/applicationinsights/Azure.Provisioning.ApplicationInsights/src/Custom/ApplicationInsightsWebTest.cs`).

#### sdk/batch/Azure.Provisioning.Batch

- `AZC0012`: Type name 'Application' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'BatchApplication', 'ProvisioningApplication', 'ApplicationOptions' (`sdk/batch/Azure.Provisioning.Batch/src/Generated/Application.cs`).
- `AZC0012`: Type name 'Certificate' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'BatchCertificate', 'ProvisioningCertificate', 'CertificateOptions' (`sdk/batch/Azure.Provisioning.Batch/src/Generated/Certificate.cs`).
- `AZC0012`: Type name 'Pool' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'BatchPool', 'ProvisioningPool', 'PoolOptions' (`sdk/batch/Azure.Provisioning.Batch/src/Generated/Pool.cs`).

#### sdk/cdn/Azure.Provisioning.Cdn

- `AZC0012`: Type name 'Endpoint' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'CdnEndpoint', 'ProvisioningEndpoint', 'EndpointOptions' (`sdk/cdn/Azure.Provisioning.Cdn/src/Generated/Endpoint.cs`).
- `AZC0012`: Type name 'Route' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'CdnRoute', 'ProvisioningRoute', 'RouteOptions' (`sdk/cdn/Azure.Provisioning.Cdn/src/Generated/Route.cs`).
- `AZC0012`: Type name 'Rule' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'CdnRule', 'ProvisioningRule', 'RuleOptions' (`sdk/cdn/Azure.Provisioning.Cdn/src/Generated/Rule.cs`).
- `AZC0012`: Type name 'Secret' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'CdnSecret', 'ProvisioningSecret', 'SecretOptions' (`sdk/cdn/Azure.Provisioning.Cdn/src/Generated/Secret.cs`).

#### sdk/cognitiveservices/Azure.Provisioning.CognitiveServices

- `CS0246`: The type or namespace name 'CognitiveServicesPrivateEndpointConnection' could not be found (are you missing a using directive or an assembly reference?) (`sdk/cognitiveservices/Azure.Provisioning.CognitiveServices/src/Custom/Models/CognitiveServicesAccountProperties.cs`).

#### sdk/compute/Azure.Provisioning.Compute

- `AZC0012`: Type name 'Disk' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'ComputeDisk', 'ProvisioningDisk', 'DiskOptions' (`sdk/compute/Azure.Provisioning.Compute/src/Generated/Disk.cs`).
- `AZC0012`: Type name 'Image' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'ComputeImage', 'ProvisioningImage', 'ImageOptions' (`sdk/compute/Azure.Provisioning.Compute/src/Generated/Image.cs`).

#### sdk/containerapps/Azure.Provisioning.AppContainers

- `AZC0012`: Type name 'Job' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'AppContainersJob', 'ProvisioningJob', 'JobOptions' (`sdk/containerapps/Azure.Provisioning.AppContainers/src/Generated/Job.cs`).
- `AZC0012`: Type name 'Replica' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'AppContainersReplica', 'ProvisioningReplica', 'ReplicaOptions' (`sdk/containerapps/Azure.Provisioning.AppContainers/src/Generated/Replica.cs`).
- `AZC0012`: Type name 'Revision' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'AppContainersRevision', 'ProvisioningRevision', 'RevisionOptions' (`sdk/containerapps/Azure.Provisioning.AppContainers/src/Generated/Revision.cs`).
- `CS1591`: Missing XML comment for publicly visible type or member 'ContainerAppConnectedEnvironmentDaprComponent' (`sdk/containerapps/Azure.Provisioning.AppContainers/src/Custom/ContainerAppConnectedEnvironmentDaprComponent.cs`).
- `CS1591`: Missing XML comment for publicly visible type or member 'ContainerAppConnectedEnvironmentDaprComponent.ResourceVersions' (`sdk/containerapps/Azure.Provisioning.AppContainers/src/Custom/ContainerAppConnectedEnvironmentDaprComponent.cs`).
- `CS1591`: Missing XML comment for publicly visible type or member 'ContainerAppManagedEnvironmentDaprComponent' (`sdk/containerapps/Azure.Provisioning.AppContainers/src/Custom/ContainerAppManagedEnvironmentDaprComponent.cs`).
- `CS1591`: Missing XML comment for publicly visible type or member 'ContainerAppManagedEnvironmentDaprComponent.ResourceVersions' (`sdk/containerapps/Azure.Provisioning.AppContainers/src/Custom/ContainerAppManagedEnvironmentDaprComponent.cs`).

#### sdk/containerregistry/Azure.Provisioning.ContainerRegistry.Tasks

- `AZC0012`: Type name 'Run' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'TasksRun', 'ContainerRegistryRun', 'ProvisioningRun' (`sdk/containerregistry/Azure.Provisioning.ContainerRegistry.Tasks/src/Generated/Run.cs`).
- `AZC0012`: Type name 'Task' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'TasksTask', 'ContainerRegistryTask', 'ProvisioningTask' (`sdk/containerregistry/Azure.Provisioning.ContainerRegistry.Tasks/src/Generated/Task.cs`).

#### sdk/containerservice/Azure.Provisioning.ContainerService

- `AZC0012`: Type name 'Machine' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'ContainerServiceMachine', 'ProvisioningMachine', 'MachineOptions' (`sdk/containerservice/Azure.Provisioning.ContainerService/src/Generated/Machine.cs`).
- `AZC0012`: Type name 'Snapshot' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'ContainerServiceSnapshot', 'ProvisioningSnapshot', 'SnapshotOptions' (`sdk/containerservice/Azure.Provisioning.ContainerService/src/Generated/Snapshot.cs`).

#### sdk/cosmosdb/Azure.Provisioning.CosmosDB

- `CS0200`: Property or indexer 'BackupPolicyMigrationState.StartsOn' cannot be assigned to -- it is read only (`sdk/cosmosdb/Azure.Provisioning.CosmosDB/src/Custom/Models/BackupPolicyMigrationState.cs`).
- `CS0200`: Property or indexer 'CosmosDBAccount.Properties' cannot be assigned to -- it is read only (`sdk/cosmosdb/Azure.Provisioning.CosmosDB/src/Custom/CosmosDBAccount.cs`).

#### sdk/costmanagement/Azure.Provisioning.CostManagement

- `AZC0012`: Type name 'Alert' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'CostManagementAlert', 'ProvisioningAlert', 'AlertOptions' (`sdk/costmanagement/Azure.Provisioning.CostManagement/src/Generated/Alert.cs`).
- `AZC0012`: Type name 'Export' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'CostManagementExport', 'ProvisioningExport', 'ExportOptions' (`sdk/costmanagement/Azure.Provisioning.CostManagement/src/Generated/Export.cs`).
- `AZC0012`: Type name 'Setting' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'CostManagementSetting', 'ProvisioningSetting', 'SettingOptions' (`sdk/costmanagement/Azure.Provisioning.CostManagement/src/Generated/Setting.cs`).

#### sdk/databricks/Azure.Provisioning.Databricks

- `AZC0012`: Type name 'Workspace' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'DatabricksWorkspace', 'ProvisioningWorkspace', 'WorkspaceOptions' (`sdk/databricks/Azure.Provisioning.Databricks/src/Generated/Workspace.cs`).

#### sdk/desktopvirtualization/Azure.Provisioning.DesktopVirtualization

- `AZC0012`: Type name 'Application' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'DesktopVirtualizationApplication', 'ProvisioningApplication', 'ApplicationOptions' (`sdk/desktopvirtualization/Azure.Provisioning.DesktopVirtualization/src/Generated/Application.cs`).
- `AZC0012`: Type name 'Desktop' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'DesktopVirtualizationDesktop', 'ProvisioningDesktop', 'DesktopOptions' (`sdk/desktopvirtualization/Azure.Provisioning.DesktopVirtualization/src/Generated/Desktop.cs`).
- `AZC0012`: Type name 'Workspace' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'DesktopVirtualizationWorkspace', 'ProvisioningWorkspace', 'WorkspaceOptions' (`sdk/desktopvirtualization/Azure.Provisioning.DesktopVirtualization/src/Generated/Workspace.cs`).

#### sdk/dns/Azure.Provisioning.Dns

- `CS0246`: The type or namespace name 'DnsCaaRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/dns/Azure.Provisioning.Dns/src/Custom/DnsCaaRecord.cs`).
- `CS0246`: The type or namespace name 'DnsDSRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/dns/Azure.Provisioning.Dns/src/Custom/DnsDSRecord.cs`).
- `CS0246`: The type or namespace name 'DnsMXRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/dns/Azure.Provisioning.Dns/src/Custom/DnsMXRecord.cs`).
- `CS0246`: The type or namespace name 'DnsNSRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/dns/Azure.Provisioning.Dns/src/Custom/DnsNSRecord.cs`).
- `CS0246`: The type or namespace name 'DnsNaptrRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/dns/Azure.Provisioning.Dns/src/Custom/DnsNaptrRecord.cs`).
- `CS0246`: The type or namespace name 'DnsPtrRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/dns/Azure.Provisioning.Dns/src/Custom/DnsPtrRecord.cs`).
- `CS0246`: The type or namespace name 'DnsSoaRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/dns/Azure.Provisioning.Dns/src/Custom/DnsSoaRecord.cs`).
- `CS0246`: The type or namespace name 'DnsSrvRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/dns/Azure.Provisioning.Dns/src/Custom/DnsSrvRecord.cs`).
- `CS0246`: The type or namespace name 'DnsTlsaRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/dns/Azure.Provisioning.Dns/src/Custom/DnsTlsaRecord.cs`).
- `CS0246`: The type or namespace name 'DnsTxtRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/dns/Azure.Provisioning.Dns/src/Custom/DnsTxtRecord.cs`).

#### sdk/domainregistration/Azure.Provisioning.DomainRegistration

- `AZC0012`: Type name 'Domain' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'DomainRegistrationDomain', 'ProvisioningDomain', 'DomainOptions' (`sdk/domainregistration/Azure.Provisioning.DomainRegistration/src/Generated/Domain.cs`).

#### sdk/durabletask/Azure.Provisioning.DurableTask

- `AZC0012`: Type name 'Scheduler' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'DurableTaskScheduler', 'ProvisioningScheduler', 'SchedulerOptions' (`sdk/durabletask/Azure.Provisioning.DurableTask/src/Generated/Scheduler.cs`).

#### sdk/eventgrid/Azure.Provisioning.EventGrid

- `CS0029`: Cannot implicitly convert type 'Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridDomainPrivateEndpointConnection>' to 'Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnection>' (`sdk/eventgrid/Azure.Provisioning.EventGrid/src/Custom/EventGridNamespace.cs`).
- `CS0029`: Cannot implicitly convert type 'Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnection>' to 'Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridDomainPrivateEndpointConnection>' (`sdk/eventgrid/Azure.Provisioning.EventGrid/src/Custom/EventGridDomain.cs`).
- `CS0029`: Cannot implicitly convert type 'Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnection>' to 'Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridDomainPrivateEndpointConnection>' (`sdk/eventgrid/Azure.Provisioning.EventGrid/src/Custom/EventGridNamespace.cs`).
- `CS0029`: Cannot implicitly convert type 'Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnection>' to 'Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridDomainPrivateEndpointConnection>' (`sdk/eventgrid/Azure.Provisioning.EventGrid/src/Custom/EventGridTopic.cs`).
- `CS0029`: Cannot implicitly convert type 'Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridPrivateEndpointConnection>' to 'Azure.Provisioning.BicepList<Azure.Provisioning.EventGrid.EventGridDomainPrivateEndpointConnection>' (`sdk/eventgrid/Azure.Provisioning.EventGrid/src/Custom/PartnerNamespace.cs`).

#### sdk/eventhub/Azure.Provisioning.EventHubs

- `CS0103`: The name 'BicepIdentifier' does not exist in the current context (`sdk/eventhub/Azure.Provisioning.EventHubs/src/Custom/EventHubAuthorizationRule.cs`).
- `CS0103`: The name 'BicepIdentifier' does not exist in the current context (`sdk/eventhub/Azure.Provisioning.EventHubs/src/Custom/EventHubsNamespaceAuthorizationRule.cs`).

#### sdk/frontdoor/Azure.Provisioning.FrontDoor

- `CS1591`: Missing XML comment for publicly visible type or member 'FrontDoorResource' (`sdk/frontdoor/Azure.Provisioning.FrontDoor/src/Custom/FrontDoorResource.cs`).

#### sdk/healthcareapis/Azure.Provisioning.HealthcareApis

- `AZC0012`: Type name 'Workspace' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'HealthcareApisWorkspace', 'ProvisioningWorkspace', 'WorkspaceOptions' (`sdk/healthcareapis/Azure.Provisioning.HealthcareApis/src/Generated/Workspace.cs`).

#### sdk/kusto/Azure.Provisioning.Kusto

- `AZC0012`: Type name 'Cluster' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'KustoCluster', 'ProvisioningCluster', 'ClusterOptions' (`sdk/kusto/Azure.Provisioning.Kusto/src/Generated/Cluster.cs`).
- `AZC0012`: Type name 'Script' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'KustoScript', 'ProvisioningScript', 'ScriptOptions' (`sdk/kusto/Azure.Provisioning.Kusto/src/Generated/Script.cs`).

#### sdk/machinelearningservices/Azure.Provisioning.MachineLearning

- `AZC0012`: Type name 'Datastore' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'MachineLearningDatastore', 'ProvisioningDatastore', 'DatastoreOptions' (`sdk/machinelearningservices/Azure.Provisioning.MachineLearning/src/Generated/Datastore.cs`).
- `AZC0012`: Type name 'Registry' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'MachineLearningRegistry', 'ProvisioningRegistry', 'RegistryOptions' (`sdk/machinelearningservices/Azure.Provisioning.MachineLearning/src/Generated/Registry.cs`).
- `AZC0012`: Type name 'Schedule' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'MachineLearningSchedule', 'ProvisioningSchedule', 'ScheduleOptions' (`sdk/machinelearningservices/Azure.Provisioning.MachineLearning/src/Generated/Schedule.cs`).
- `AZC0012`: Type name 'Workspace' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'MachineLearningWorkspace', 'ProvisioningWorkspace', 'WorkspaceOptions' (`sdk/machinelearningservices/Azure.Provisioning.MachineLearning/src/Generated/Workspace.cs`).

#### sdk/maps/Azure.Provisioning.Maps

- `AZC0012`: Type name 'Creator' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'MapsCreator', 'ProvisioningCreator', 'CreatorOptions' (`sdk/maps/Azure.Provisioning.Maps/src/Generated/Creator.cs`).

#### sdk/mysql/Azure.Provisioning.MySql

- `AZC0012`: Type name 'Configuration' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'MySqlConfiguration', 'ProvisioningConfiguration', 'ConfigurationOptions' (`sdk/mysql/Azure.Provisioning.MySql/src/Generated/Configuration.cs`).
- `AZC0012`: Type name 'Database' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'MySqlDatabase', 'ProvisioningDatabase', 'DatabaseOptions' (`sdk/mysql/Azure.Provisioning.MySql/src/Generated/Database.cs`).
- `AZC0012`: Type name 'Maintenance' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'MySqlMaintenance', 'ProvisioningMaintenance', 'MaintenanceOptions' (`sdk/mysql/Azure.Provisioning.MySql/src/Generated/Maintenance.cs`).
- `AZC0012`: Type name 'Server' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'MySqlServer', 'ProvisioningServer', 'ServerOptions' (`sdk/mysql/Azure.Provisioning.MySql/src/Generated/Server.cs`).

#### sdk/network/Azure.Provisioning.Network

- `CS0246`: The type or namespace name 'CircuitConnectionStatus' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/PeerExpressRouteCircuitConnectionData.cs`).
- `CS0246`: The type or namespace name 'ExpressRouteConnection' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/ExpressRouteGateway.cs`).
- `CS0246`: The type or namespace name 'ExpressRouteLink' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/ExpressRoutePort.cs`).
- `CS0246`: The type or namespace name 'ExpressRouteLinkAdminState' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/ExpressRouteLinkData.cs`).
- `CS0246`: The type or namespace name 'ExpressRouteLinkConnectorType' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/ExpressRouteLinkData.cs`).
- `CS0246`: The type or namespace name 'ExpressRouteLinkMacSecConfig' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/ExpressRouteLinkData.cs`).
- `CS0246`: The type or namespace name 'FlowLogFormatType' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/FlowLogProperties.cs`).
- `CS0246`: The type or namespace name 'GatewayCustomBgpIPAddressIPConfiguration' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSiteLinkConnectionData.cs`).
- `CS0246`: The type or namespace name 'IPsecPolicy' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSiteLinkConnectionData.cs`).
- `CS0246`: The type or namespace name 'NetworkIPAllocationMethod' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/NetworkIPConfiguration.cs`).
- `CS0246`: The type or namespace name 'NetworkIPAllocationMethod' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VirtualNetworkApplianceIPConfiguration.cs`).
- `CS0246`: The type or namespace name 'NetworkIPVersion' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VirtualNetworkApplianceIPConfiguration.cs`).
- `CS0246`: The type or namespace name 'NetworkPrivateLinkServiceConnectionState' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/ApplicationGatewayPrivateEndpointConnection.cs`).
- `CS0246`: The type or namespace name 'NetworkPrivateLinkServiceConnectionState' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/NetworkPrivateLinkServiceConnection.cs`).
- `CS0246`: The type or namespace name 'NetworkPrivateLinkServiceConnectionState' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/NetworkPrivateEndpointConnection.cs`).
- `CS0246`: The type or namespace name 'NetworkProvisioningState' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/ExpressRouteLinkData.cs`).
- `CS0246`: The type or namespace name 'NetworkProvisioningState' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/PeerExpressRouteCircuitConnectionData.cs`).
- `CS0246`: The type or namespace name 'NetworkProvisioningState' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSiteLinkConnectionData.cs`).
- `CS0246`: The type or namespace name 'NetworkProvisioningState' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSiteLinkData.cs`).
- `CS0246`: The type or namespace name 'PeerExpressRouteCircuitConnection' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/ExpressRouteCircuitPeering.cs`).
- `CS0246`: The type or namespace name 'RoutingConfiguration' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/NetworkVirtualApplianceConnection.cs`).
- `CS0246`: The type or namespace name 'ScopeConnectionState' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/ManagementGroupNetworkManagerConnection.cs`).
- `CS0246`: The type or namespace name 'ScopeConnectionState' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/SubscriptionNetworkManagerConnection.cs`).
- `CS0246`: The type or namespace name 'TrafficAnalyticsConfigurationProperties' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/FlowLog.cs`).
- `CS0246`: The type or namespace name 'VirtualHubRoute' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VirtualHub.cs`).
- `CS0246`: The type or namespace name 'VirtualNetworkGatewayConnectionProtocol' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSiteLinkConnectionData.cs`).
- `CS0246`: The type or namespace name 'VpnConnectionStatus' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSiteLinkConnectionData.cs`).
- `CS0246`: The type or namespace name 'VpnLinkBgpSettings' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSiteLinkData.cs`).
- `CS0246`: The type or namespace name 'VpnLinkConnectionMode' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSiteLinkConnectionData.cs`).
- `CS0246`: The type or namespace name 'VpnLinkProviderProperties' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSiteLinkData.cs`).
- `CS0246`: The type or namespace name 'VpnSiteLink' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSite.cs`).
- `CS0246`: The type or namespace name 'VpnSiteLinkConnection' could not be found (are you missing a using directive or an assembly reference?) (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnConnection.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ApplicationGatewayEntraJwtValidationConfig.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/ApplicationGatewayEntraJwtValidationConfig.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ApplicationGatewayRewriteRuleSet.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/ApplicationGatewayRewriteRuleSet.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ApplicationSecurityGroup.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/ApplicationSecurityGroup.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'AzureFirewallApplicationRuleCollectionData.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/AzureFirewallApplicationRuleCollectionData.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'AzureFirewallNatRuleCollectionData.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/AzureFirewallNatRuleCollectionData.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'AzureFirewallNetworkRuleCollectionData.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/AzureFirewallNetworkRuleCollectionData.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'BackendAddressPool.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/BackendAddressPool.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ContainerNetworkInterface.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/ContainerNetworkInterface.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'CustomIPPrefix.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/CustomIPPrefix.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'CustomIPPrefixPropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/CustomIPPrefixPropertiesFormat.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'DdosCustomPolicyPropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/DdosCustomPolicyPropertiesFormat.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'DdosProtectionPlan.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/DdosProtectionPlan.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ExpressRouteCircuitPeering.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/ExpressRouteCircuitPeering.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ExpressRouteCircuitPeeringPropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/ExpressRouteCircuitPeeringPropertiesFormat.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ExpressRoutePort.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/ExpressRoutePort.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ExpressRoutePortPropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/ExpressRoutePort.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'FirewallPolicy.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/FirewallPolicy.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'FirewallPolicyDraft.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/FirewallPolicyDraft.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'FirewallPolicyRuleCollectionGroupDraft.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/FirewallPolicyRuleCollectionGroupDraft.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'FlowLog.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/FlowLog.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'FlowLogProperties.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/FlowLogProperties.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'InboundNatRule.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/InboundNatRule.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'LoadBalancer.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/LoadBalancer.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'LoadBalancerInboundNatPool.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/LoadBalancerInboundNatPool.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'LoadBalancingRule.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/LoadBalancingRule.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'LoadBalancingRuleProperties.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/LoadBalancingRuleProperties.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ManagedRuleSetRuleGroup.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/ManagedRuleSetRuleGroup.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'NatGateway.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/NatGateway.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'NatGatewayPropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/NatGatewayPropertiesFormat.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'NetworkIPConfiguration.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/NetworkIPConfiguration.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'NetworkInterface.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/NetworkInterface.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'NetworkInterfaceTapConfiguration.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/NetworkInterfaceTapConfiguration.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'NetworkPrivateEndpointConnection.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/NetworkPrivateEndpointConnection.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'NetworkSecurityGroup.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/NetworkSecurityGroup.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'NetworkVirtualAppliancePropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/NetworkVirtualAppliancePropertiesFormat.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'NetworkWatcher.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/NetworkWatcher.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'P2SConnectionConfiguration.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/P2SConnectionConfiguration.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'PolicySettings.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/PolicySettings.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'PolicySignaturesOverridesForIdps.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/PolicySignaturesOverridesForIdps.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'PrivateDnsZoneGroup.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/PrivateDnsZoneGroup.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'PrivateEndpoint.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/PrivateEndpoint.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'PrivateLinkService.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/PrivateLinkService.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'PropagatedRouteTable.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/PropagatedRouteTable.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'PublicIPAddress.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/PublicIPAddress.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'PublicIPPrefix.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/PublicIPPrefix.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'PublicIPPrefixPropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/PublicIPPrefixPropertiesFormat.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ResourceNavigationLink.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/ResourceNavigationLink.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'RoutePropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/RoutePropertiesFormat.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'RouteResource.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/RouteResource.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'RouteTable.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/RouteTable.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'SecurityRule.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/SecurityRule.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ServiceAssociationLink.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/ServiceAssociationLink.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ServiceEndpointPolicy.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/ServiceEndpointPolicy.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'ServiceEndpointPolicyDefinition.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/ServiceEndpointPolicyDefinition.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'SubnetPropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/SubnetPropertiesFormat.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'SubnetResource.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/SubnetResource.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VirtualHubProperties.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VirtualHubProperties.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VirtualNetwork.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/VirtualNetwork.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VirtualNetworkApplianceIPConfiguration.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VirtualNetworkApplianceIPConfiguration.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VirtualNetworkAppliancePropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/VirtualNetworkAppliance.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VirtualNetworkGatewayIPConfiguration.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VirtualNetworkGatewayIPConfiguration.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VirtualNetworkGatewayPolicyGroup.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VirtualNetworkGatewayPolicyGroup.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VirtualNetworkPeering.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/VirtualNetworkPeering.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VirtualNetworkPropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VirtualNetworkPropertiesFormat.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VirtualNetworkTap.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/VirtualNetworkTap.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VnetRoute.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VnetRoute.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VngClientConnectionConfiguration.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VngClientConnectionConfiguration.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VpnClientRevokedCertificate.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VpnClientRevokedCertificate.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VpnClientRootCertificate.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/VpnClientRootCertificate.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VpnConnection.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnConnection.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VpnConnectionProperties.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnConnection.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VpnLinkConnectionSharedKey.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnLinkConnectionSharedKey.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VpnSite.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSite.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'VpnSiteProperties.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/VpnSite.cs`).
- `CS0759`: No defining declaration found for implementing declaration of partial method 'WebApplicationFirewallPolicyPropertiesFormat.DefineAdditionalProperties()' (`sdk/network/Azure.Provisioning.Network/src/Custom/Models/WebApplicationFirewallPolicyPropertiesFormat.cs`).

#### sdk/operationalinsights/Azure.Provisioning.OperationalInsights

- `CS1591`: Missing XML comment for publicly visible type or member 'OperationalInsightsDataSource' (`sdk/operationalinsights/Azure.Provisioning.OperationalInsights/src/Custom/OperationalInsightsDataSource.cs`).
- `CS1591`: Missing XML comment for publicly visible type or member 'OperationalInsightsDataSource.ResourceVersions' (`sdk/operationalinsights/Azure.Provisioning.OperationalInsights/src/Custom/OperationalInsightsDataSource.cs`).

#### sdk/privatedns/Azure.Provisioning.PrivateDns

- `CS0246`: The type or namespace name 'PrivateDnsARecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/privatedns/Azure.Provisioning.PrivateDns/src/Custom/PrivateDnsARecord.cs`).
- `CS0246`: The type or namespace name 'PrivateDnsAaaaRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/privatedns/Azure.Provisioning.PrivateDns/src/Custom/PrivateDnsAaaaRecord.cs`).
- `CS0246`: The type or namespace name 'PrivateDnsMXRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/privatedns/Azure.Provisioning.PrivateDns/src/Custom/PrivateDnsMXRecord.cs`).
- `CS0246`: The type or namespace name 'PrivateDnsPtrRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/privatedns/Azure.Provisioning.PrivateDns/src/Custom/PrivateDnsPtrRecord.cs`).
- `CS0246`: The type or namespace name 'PrivateDnsSoaRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/privatedns/Azure.Provisioning.PrivateDns/src/Custom/PrivateDnsSoaRecord.cs`).
- `CS0246`: The type or namespace name 'PrivateDnsSrvRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/privatedns/Azure.Provisioning.PrivateDns/src/Custom/PrivateDnsSrvRecord.cs`).
- `CS0246`: The type or namespace name 'PrivateDnsTxtRecordInfo' could not be found (are you missing a using directive or an assembly reference?) (`sdk/privatedns/Azure.Provisioning.PrivateDns/src/Custom/PrivateDnsTxtRecord.cs`).

#### sdk/recoveryservices/Azure.Provisioning.RecoveryServices

- `AZC0012`: Type name 'Vaults' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'RecoveryServicesVaults', 'ProvisioningVaults', 'VaultsOptions' (`sdk/recoveryservices/Azure.Provisioning.RecoveryServices/src/Generated/Vaults.cs`).

#### sdk/redis/Azure.Provisioning.Redis

- `CS1061`: 'RedisProperties' does not contain a definition for 'PrivateEndpointConnectionResources' and no accessible extension method 'PrivateEndpointConnectionResources' accepting a first argument of type 'RedisProperties' could be found (are you missing a using directive or an assembly reference?) (`sdk/redis/Azure.Provisioning.Redis/src/Custom/RedisResource.cs`).

#### sdk/redisenterprise/Azure.Provisioning.RedisEnterprise

- `AZC0012`: Type name 'Migration' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'RedisEnterpriseMigration', 'ProvisioningMigration', 'MigrationOptions' (`sdk/redisenterprise/Azure.Provisioning.RedisEnterprise/src/Generated/Migration.cs`).

#### sdk/securitycenter/Azure.Provisioning.SecurityCenter

- `AZC0012`: Type name 'Assignment' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'SecurityCenterAssignment', 'ProvisioningAssignment', 'AssignmentOptions' (`sdk/securitycenter/Azure.Provisioning.SecurityCenter/src/Generated/Assignment.cs`).
- `AZC0012`: Type name 'Automation' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'SecurityCenterAutomation', 'ProvisioningAutomation', 'AutomationOptions' (`sdk/securitycenter/Azure.Provisioning.SecurityCenter/src/Generated/Automation.cs`).
- `AZC0012`: Type name 'Compliance' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'SecurityCenterCompliance', 'ProvisioningCompliance', 'ComplianceOptions' (`sdk/securitycenter/Azure.Provisioning.SecurityCenter/src/Generated/Compliance.cs`).
- `AZC0012`: Type name 'Pricing' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'SecurityCenterPricing', 'ProvisioningPricing', 'PricingOptions' (`sdk/securitycenter/Azure.Provisioning.SecurityCenter/src/Generated/Pricing.cs`).
- `AZC0012`: Type name 'Setting' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'SecurityCenterSetting', 'ProvisioningSetting', 'SettingOptions' (`sdk/securitycenter/Azure.Provisioning.SecurityCenter/src/Generated/Setting.cs`).
- `AZC0012`: Type name 'Standard' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'SecurityCenterStandard', 'ProvisioningStandard', 'StandardOptions' (`sdk/securitycenter/Azure.Provisioning.SecurityCenter/src/Generated/Standard.cs`).

#### sdk/servicefabric/Azure.Provisioning.ServiceFabric

- `AZC0012`: Type name 'Cluster' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'ServiceFabricCluster', 'ProvisioningCluster', 'ClusterOptions' (`sdk/servicefabric/Azure.Provisioning.ServiceFabric/src/Generated/Cluster.cs`).

#### sdk/servicenetworking/Azure.Provisioning.ServiceNetworking

- `AZC0012`: Type name 'Association' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'ServiceNetworkingAssociation', 'ProvisioningAssociation', 'AssociationOptions' (`sdk/servicenetworking/Azure.Provisioning.ServiceNetworking/src/Generated/Association.cs`).
- `AZC0012`: Type name 'Frontend' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'ServiceNetworkingFrontend', 'ProvisioningFrontend', 'FrontendOptions' (`sdk/servicenetworking/Azure.Provisioning.ServiceNetworking/src/Generated/Frontend.cs`).

#### sdk/signalr/Azure.Provisioning.SignalR

- `AZC0012`: Type name 'Replica' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'SignalRReplica', 'ProvisioningReplica', 'ReplicaOptions' (`sdk/signalr/Azure.Provisioning.SignalR/src/Generated/Replica.cs`).

#### sdk/sqlmanagement/Azure.Provisioning.Sql

- `CS1591`: Missing XML comment for publicly visible type or member 'IPv6FirewallRule' (`sdk/sqlmanagement/Azure.Provisioning.Sql/src/Custom/IPv6FirewallRule.cs`).
- `CS1591`: Missing XML comment for publicly visible type or member 'IPv6FirewallRule.ResourceVersions' (`sdk/sqlmanagement/Azure.Provisioning.Sql/src/Custom/IPv6FirewallRule.cs`).
- `CS1591`: Missing XML comment for publicly visible type or member 'SqlDistributedAvailabilityGroup' (`sdk/sqlmanagement/Azure.Provisioning.Sql/src/Custom/SqlDistributedAvailabilityGroup.cs`).
- `CS1591`: Missing XML comment for publicly visible type or member 'SqlDistributedAvailabilityGroup.ResourceVersions' (`sdk/sqlmanagement/Azure.Provisioning.Sql/src/Custom/SqlDistributedAvailabilityGroup.cs`).
- `CS1591`: Missing XML comment for publicly visible type or member 'SqlFirewallRule' (`sdk/sqlmanagement/Azure.Provisioning.Sql/src/Custom/SqlFirewallRule.cs`).
- `CS1591`: Missing XML comment for publicly visible type or member 'SqlFirewallRule.ResourceVersions' (`sdk/sqlmanagement/Azure.Provisioning.Sql/src/Custom/SqlFirewallRule.cs`).

#### sdk/storage/Azure.Provisioning.Storage

- `CS0200`: Property or indexer 'StorageTableAccessPolicy.StartsOn' cannot be assigned to -- it is read only (`sdk/storage/Azure.Provisioning.Storage/src/Custom/Models/StorageTableAccessPolicy.cs`).

#### sdk/verifiedid/Azure.Provisioning.VerifiedId

- `AZC0012`: Type name 'Authority' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'VerifiedIdAuthority', 'ProvisioningAuthority', 'AuthorityOptions' (`sdk/verifiedid/Azure.Provisioning.VerifiedId/src/Generated/Authority.cs`).

#### sdk/webpubsub/Azure.Provisioning.WebPubSub

- `AZC0012`: Type name 'Replica' is too generic and has high chance of collision with BCL types or types from other libraries. Consider renaming to: 'WebPubSubReplica', 'ProvisioningReplica', 'ReplicaOptions' (`sdk/webpubsub/Azure.Provisioning.WebPubSub/src/Generated/Replica.cs`).

#### sdk/websites/Azure.Provisioning.AppService

- `CS0109`: The member 'SiteAuthSettingsV2.FromExisting(string, string)' does not hide an accessible member. The new keyword is not required. (`sdk/websites/Azure.Provisioning.AppService/src/Custom/SiteAuthSettingsV2.cs`).
- `CS0246`: The type or namespace name 'WebSiteAuthSettingsV2' could not be found (are you missing a using directive or an assembly reference?) (`sdk/websites/Azure.Provisioning.AppService/src/Custom/SiteAuthSettingsV2.cs`).

## Per-library details

## Azure.Provisioning.ApiManagement

Package: `sdk/apimanagement/Azure.Provisioning.ApiManagement`. Distinct ARM resource types: **100 -> 100**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.ApiManagement/gateways` | ApiGateway | ApiManagementGatewayResource |
| `Microsoft.ApiManagement/gateways/configConnections` | ApiGatewayConfigConnection | ApiManagementGatewayConfigConnectionResource |
| `Microsoft.ApiManagement/gateways/hostnameBindings` | GatewayHostnameBinding | GatewayHostnameBindingResource |
| `Microsoft.ApiManagement/locations/deletedservices` | ApiManagementDeletedService | DeletedServiceContract |
| `Microsoft.ApiManagement/service` | ApiManagementService | ApiManagementServiceResource |
| `Microsoft.ApiManagement/service/apiVersionSets` | ApiVersionSet | ServiceApiVersionSets |
| `Microsoft.ApiManagement/service/apis/diagnostics` | ApiDiagnostic | ApisDiagnostics |
| `Microsoft.ApiManagement/service/apis/issues` | ApiIssue | ApisIssues |
| `Microsoft.ApiManagement/service/apis/issues/attachments` | ApiIssueAttachment | IssueAttachmentContract |
| `Microsoft.ApiManagement/service/apis/issues/comments` | ApiIssueComment | IssueCommentContract |
| `Microsoft.ApiManagement/service/apis/operations` | ApiOperation | ApisOperations |
| `Microsoft.ApiManagement/service/apis/operations/policies` | ApiOperationPolicy | OperationsPolicies |
| `Microsoft.ApiManagement/service/apis/policies` | ApiPolicy | ApisPolicies |
| `Microsoft.ApiManagement/service/apis/releases` | ApiRelease | ApisReleases |
| `Microsoft.ApiManagement/service/apis/schemas` | ApiSchema | ApisSchemas |
| `Microsoft.ApiManagement/service/apis/tagDescriptions` | ApiTagDescription | TagDescriptionContract |
| `Microsoft.ApiManagement/service/authorizationServers` | ApiManagementAuthorizationServer | AuthorizationServerContract |
| `Microsoft.ApiManagement/service/caches` | ApiManagementCache | CacheContract |
| `Microsoft.ApiManagement/service/contentTypes` | ApiManagementContentType | ContentTypeContract |
| `Microsoft.ApiManagement/service/contentTypes/contentItems` | ApiManagementContentItem | ContentItemContract |
| `Microsoft.ApiManagement/service/gateways` | ApiManagementGateway | GatewayContract |
| `Microsoft.ApiManagement/service/gateways/certificateAuthorities` | ApiManagementGatewayCertificateAuthority | GatewayCertificateAuthorityContract |
| `Microsoft.ApiManagement/service/gateways/hostnameConfigurations` | ApiManagementGatewayHostnameConfiguration | GatewayHostnameConfigurationContract |
| `Microsoft.ApiManagement/service/identityProviders` | ApiManagementIdentityProvider | IdentityProviderContract |
| `Microsoft.ApiManagement/service/openidConnectProviders` | ApiManagementOpenIdConnectProvider | OpenidConnectProviderContract |
| `Microsoft.ApiManagement/service/portalRevisions` | ApiManagementPortalRevision | PortalRevisionContract |
| `Microsoft.ApiManagement/service/portalsettings` | ApiManagementPortalDelegationSetting, ApiManagementPortalSignInSetting, ApiManagementPortalSignUpSetting | PortalDelegationSettings, PortalSigninSettings, PortalSignupSettings |
| `Microsoft.ApiManagement/service/privateEndpointConnections` | ApiManagementPrivateEndpointConnection | ApiManagementServiceResourcePrivateEndpointConnection |
| `Microsoft.ApiManagement/service/privateLinkResources` | ApiManagementPrivateLinkResource | ApiManagementServiceResourcePrivateLinkResource |
| `Microsoft.ApiManagement/service/settings` | ApiManagementTenantSetting | TenantSettingsContract |
| `Microsoft.ApiManagement/service/templates` | ApiManagementEmailTemplate | EmailTemplateContract |
| `Microsoft.ApiManagement/service/tenant` | TenantAccessInfo | AccessInformationContract |
| `Microsoft.ApiManagement/service/users` | ApiManagementUser | UserContract |
| `Microsoft.ApiManagement/service/workspaceLinks` | ApiManagementWorkspaceLinks | ApiManagementWorkspaceLinksResource |

Multiple class names share these ARM resource types; all names are retained in the comparison rather than overwritten:

- `Microsoft.ApiManagement/service/portalsettings`

## Azure.Provisioning.AppConfiguration

Package: `sdk/appconfiguration/Azure.Provisioning.AppConfiguration`. Distinct ARM resource types: **7 -> 6**.

Removed ARM resource types:

- `Microsoft.AppConfiguration/configurationStores/snapshots`: `AppConfigurationSnapshot`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.AppConfiguration/configurationStores/privateLinkResources` | AppConfigurationPrivateLinkResource | PrivateLinkResource |
| `Microsoft.AppConfiguration/locations/deletedConfigurationStores` | DeletedAppConfigurationStore | DeletedConfigurationStore |

## Azure.Provisioning.ApplicationInsights

Package: `sdk/applicationinsights/Azure.Provisioning.ApplicationInsights`. Distinct ARM resource types: **6 -> 4**.

Removed ARM resource types:

- `Microsoft.Insights/components`: `ApplicationInsightsComponent`
- `Microsoft.Insights/webtests`: `ApplicationInsightsWebTest`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Insights/components/linkedStorageAccounts` | ComponentLinkedStorageAccounts | ComponentsLinkedStorageAccounts |
| `Microsoft.Insights/workbooks/revisions` | ApplicationInsightsWorkbookRevision | WorkbooksRevisions |

## Azure.Provisioning.AppNetwork

Package: `sdk/appnetwork/Azure.Provisioning.AppNetwork`. Distinct ARM resource types: **2 -> 2**.

Resource identities and class names are unchanged.

## Azure.Provisioning.Attestation

Package: `sdk/attestation/Azure.Provisioning.Attestation`. Distinct ARM resource types: **2 -> 2**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Attestation/attestationProviders/privateEndpointConnections` | AttestationPrivateEndpointConnection | AttestationProviderPrivateEndpointConnection |

## Azure.Provisioning.Batch

Package: `sdk/batch/Azure.Provisioning.Batch`. Distinct ARM resource types: **8 -> 9**.

Added ARM resource types:

- `Microsoft.Batch/batchAccounts/certificates`: `Certificate`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Batch/batchAccounts/applications` | BatchApplication | Application |
| `Microsoft.Batch/batchAccounts/applications/versions` | BatchApplicationPackage | ApplicationPackage |
| `Microsoft.Batch/batchAccounts/detectors` | BatchAccountDetector | DetectorResponse |
| `Microsoft.Batch/batchAccounts/networkSecurityPerimeterConfigurations` | NetworkSecurityPerimeterConfiguration | BatchAccountNetworkSecurityPerimeterConfiguration |
| `Microsoft.Batch/batchAccounts/pools` | BatchAccountPool | Pool |
| `Microsoft.Batch/batchAccounts/privateEndpointConnections` | BatchPrivateEndpointConnection | PrivateEndpointConnection |
| `Microsoft.Batch/batchAccounts/privateLinkResources` | BatchPrivateLinkResource | PrivateLinkResource |

## Azure.Provisioning.BotService

Package: `sdk/botservice/Azure.Provisioning.BotService`. Distinct ARM resource types: **5 -> 5**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.BotService/botServices/connections` | BotConnectionSetting | ConnectionSetting |
| `Microsoft.BotService/botServices/networkSecurityPerimeterConfigurations` | BotServiceNetworkSecurityPerimeterConfiguration | NetworkSecurityPerimeterConfiguration |
| `Microsoft.BotService/botServices/privateEndpointConnections` | BotServicePrivateEndpointConnection | PrivateEndpointConnection |

## Azure.Provisioning.Cdn

Package: `sdk/cdn/Azure.Provisioning.Cdn`. Distinct ARM resource types: **15 -> 15**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Cdn/profiles/afdEndpoints` | FrontDoorEndpoint | AFDEndpoint |
| `Microsoft.Cdn/profiles/afdEndpoints/routes` | FrontDoorRoute | Route |
| `Microsoft.Cdn/profiles/customDomains` | FrontDoorCustomDomain | AFDDomain |
| `Microsoft.Cdn/profiles/endpoints` | CdnEndpoint | Endpoint |
| `Microsoft.Cdn/profiles/endpoints/customDomains` | CdnCustomDomain | CustomDomain |
| `Microsoft.Cdn/profiles/endpoints/originGroups` | CdnOriginGroup | OriginGroup |
| `Microsoft.Cdn/profiles/originGroups` | FrontDoorOriginGroup | AFDOriginGroup |
| `Microsoft.Cdn/profiles/originGroups/origins` | FrontDoorOrigin | AFDOrigin |
| `Microsoft.Cdn/profiles/ruleSets` | FrontDoorRuleSet | RuleSet |
| `Microsoft.Cdn/profiles/ruleSets/rules` | FrontDoorRule | Rule |
| `Microsoft.Cdn/profiles/secrets` | FrontDoorSecret | Secret |
| `Microsoft.Cdn/profiles/securityPolicies` | FrontDoorSecurityPolicy | SecurityPolicy |

## Azure.Provisioning.CertificateRegistration

Package: `sdk/certificateregistration/Azure.Provisioning.CertificateRegistration`. Distinct ARM resource types: **3 -> 3**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.CertificateRegistration/certificateOrders/certificates` | AppServiceCertificate | AppServiceCertificateResource |
| `Microsoft.CertificateRegistration/certificateOrders/detectors` | AppServiceDetector | DetectorResponse |

## Azure.Provisioning.CognitiveServices

Package: `sdk/cognitiveservices/Azure.Provisioning.CognitiveServices`. Distinct ARM resource types: **28 -> 28**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.CognitiveServices/accounts/managedNetworks` | CognitiveServicesManagedNetworkSettings | ManagedNetworkSettingsPropertiesBasicResource |
| `Microsoft.CognitiveServices/accounts/managedNetworks/outboundRules` | CognitiveServicesOutboundRuleBasic | OutboundRuleBasicResource |
| `Microsoft.CognitiveServices/accounts/privateEndpointConnections` | CognitiveServicesPrivateEndpointConnection | PrivateEndpointConnection |
| `Microsoft.CognitiveServices/accounts/projects/applications` | CognitiveServicesAgentApplication | AgentApplication |
| `Microsoft.CognitiveServices/accounts/projects/capabilityHosts` | CognitiveServicesProjectScopedCapabilityHost | ProjectCapabilityHost |
| `Microsoft.CognitiveServices/quotaTiers` | CognitiveServicesQuotaTier | QuotaTier |
| `Microsoft.CognitiveServices/raiPolicy` | SubscriptionRaiPolicy | SubscriptionsRaiPolicy |

## Azure.Provisioning.Communication

Package: `sdk/communication/Azure.Provisioning.Communication`. Distinct ARM resource types: **7 -> 7**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Communication/communicationServices/smtpUsernames` | CommunicationSmtpUsername | SmtpUsernameResource |
| `Microsoft.Communication/emailServices/domains/suppressionLists` | EmailSuppressionList | SuppressionListResource |
| `Microsoft.Communication/emailServices/domains/suppressionLists/suppressionListAddresses` | EmailSuppressionListAddress | SuppressionListAddressResource |

## Azure.Provisioning.Compute

Package: `sdk/compute/Azure.Provisioning.Compute`. Distinct ARM resource types: **37 -> 35**.

Removed ARM resource types:

- `Microsoft.Compute/virtualMachineScaleSets/extensions`: `VirtualMachineScaleSetExtension`
- `Microsoft.Compute/virtualMachineScaleSets/virtualMachines/extensions`: `VirtualMachineScaleSetVmExtension`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Compute/diskAccesses/privateEndpointConnections` | ComputePrivateEndpointConnection | PrivateEndpointConnection |
| `Microsoft.Compute/disks` | ManagedDisk | Disk |
| `Microsoft.Compute/galleries/inVMAccessControlProfiles` | GalleryInVmAccessControlProfile | GalleryInVMAccessControlProfile |
| `Microsoft.Compute/galleries/inVMAccessControlProfiles/versions` | GalleryInVmAccessControlProfileVersion | GalleryInVMAccessControlProfileVersion |
| `Microsoft.Compute/images` | DiskImage | Image |
| `Microsoft.Compute/locations/publishers/artifacttypes/types/versions` | VirtualMachineExtensionImage | TypesVersions |
| `Microsoft.Compute/restorePointCollections` | RestorePointGroup | RestorePointCollection |
| `Microsoft.Compute/restorePointCollections/restorePoints/diskRestorePoints` | DiskRestorePoint | RestorePointsDiskRestorePoints |
| `Microsoft.Compute/sshPublicKeys` | SshPublicKey | SshPublicKeyResource |
| `Microsoft.Compute/virtualMachineScaleSets/lifecycleHookEvents` | VirtualMachineScaleSetLifecycleHookEvent | VMScaleSetLifecycleHookEvent |
| `Microsoft.Compute/virtualMachineScaleSets/rollingUpgrades` | VirtualMachineScaleSetRollingUpgrade | RollingUpgradeStatusInfo |
| `Microsoft.Compute/virtualMachineScaleSets/virtualMachines` | VirtualMachineScaleSetVm | VirtualMachineScaleSetVM |
| `Microsoft.Compute/virtualMachineScaleSets/virtualMachines/runCommands` | VirtualMachineScaleSetVmRunCommand | VirtualMachineScaleSetVirtualMachineRunCommand |

## Azure.Provisioning.AppContainers

Package: `sdk/containerapps/Azure.Provisioning.AppContainers`. Distinct ARM resource types: **38 -> 38**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.App/connectedEnvironments/daprComponents` | ContainerAppConnectedEnvironmentDaprComponent | ConnectedEnvironmentsDaprComponents |
| `Microsoft.App/containerApps/functions` | ContainerAppsFunction | ContainerAppsFunctions |
| `Microsoft.App/containerApps/revisions` | ContainerAppRevision | Revision |
| `Microsoft.App/containerApps/revisions/functions` | ContainerAppsRevisionFunction | RevisionsFunctions |
| `Microsoft.App/containerApps/revisions/replicas` | ContainerAppReplica | Replica |
| `Microsoft.App/jobs` | ContainerAppJob | Job |
| `Microsoft.App/jobs/detectorProperties` | ContainerAppJobDetectorProperty | ContainerAppJob |
| `Microsoft.App/jobs/executions` | ContainerAppJobExecution | JobExecution |
| `Microsoft.App/logicApps/workflows` | LogicAppWorkflowEnvelope | WorkflowEnvelope |
| `Microsoft.App/managedEnvironments` | ContainerAppManagedEnvironment | ManagedEnvironment |
| `Microsoft.App/managedEnvironments/daprComponents` | ContainerAppManagedEnvironmentDaprComponent | ManagedEnvironmentsDaprComponents |
| `Microsoft.App/managedEnvironments/daprComponents/resiliencyPolicies` | DaprComponentResiliencyPolicy | DaprComponentsResiliencyPolicies |
| `Microsoft.App/managedEnvironments/detectorProperties` | ContainerAppManagedEnvironmentDetectorResourceProperty | ContainerAppManagedEnvironment |
| `Microsoft.App/managedEnvironments/dotNetComponents` | DotNetComponent | ManagedEnvironmentsDotNetComponents |
| `Microsoft.App/sandboxGroups/vnetConnections` | SandboxGroupVnetConnection | VnetConnection |

## Azure.Provisioning.ContainerInstance

Package: `sdk/containerinstance/Azure.Provisioning.ContainerInstance`. Distinct ARM resource types: **4 -> 3**.

Removed ARM resource types:

- `Microsoft.ContainerInstance/containerGroups`: `ContainerGroup`

## Azure.Provisioning.ContainerRegistry

Package: `sdk/containerregistry/Azure.Provisioning.ContainerRegistry`. Distinct ARM resource types: **10 -> 11**.

Added ARM resource types:

- `Microsoft.ContainerRegistry/registries/packages/archives/versions`: `ArchivesVersions`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.ContainerRegistry/registries/privateLinkResources` | ContainerRegistryPrivateLinkResource | RegistryMyPrivateLinkResource |

## Azure.Provisioning.ContainerRegistry.Tasks

Package: `sdk/containerregistry/Azure.Provisioning.ContainerRegistry.Tasks`. Distinct ARM resource types: **4 -> 4**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.ContainerRegistry/registries/agentPools` | ContainerRegistryAgentPool | AgentPool |
| `Microsoft.ContainerRegistry/registries/runs` | ContainerRegistryRun | Run |
| `Microsoft.ContainerRegistry/registries/taskRuns` | ContainerRegistryTaskRun | TaskRun |
| `Microsoft.ContainerRegistry/registries/tasks` | ContainerRegistryTask | Task |

## Azure.Provisioning.ContainerService

Package: `sdk/containerservice/Azure.Provisioning.ContainerService`. Distinct ARM resource types: **12 -> 12**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.ContainerService/managedClusters` | ContainerServiceManagedCluster | ManagedCluster |
| `Microsoft.ContainerService/managedClusters/agentPools` | ContainerServiceAgentPool | AgentPool |
| `Microsoft.ContainerService/managedClusters/agentPools/machines` | ContainerServiceMachine | Machine |
| `Microsoft.ContainerService/managedClusters/maintenanceConfigurations` | ContainerServiceMaintenanceConfiguration | MaintenanceConfiguration |
| `Microsoft.ContainerService/managedClusters/managedNamespaces` | ManagedClusterNamespace | ManagedNamespace |
| `Microsoft.ContainerService/managedClusters/privateEndpointConnections` | ContainerServicePrivateEndpointConnection | PrivateEndpointConnection |
| `Microsoft.ContainerService/managedClusters/trustedAccessRoleBindings` | ContainerServiceTrustedAccessRoleBinding | TrustedAccessRoleBinding |
| `Microsoft.ContainerService/snapshots` | AgentPoolSnapshot | Snapshot |

## Azure.Provisioning.CosmosDB

Package: `sdk/cosmosdb/Azure.Provisioning.CosmosDB`. Distinct ARM resource types: **46 -> 48**.

Added ARM resource types:

- `Microsoft.DocumentDB/cassandraClusters/backups`: `CassandraClusterBackup`
- `Microsoft.DocumentDB/cassandraClusters/commands`: `CassandraClusterCommand`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.DocumentDB/databaseAccounts/cassandraRoleAssignments` | CassandraRoleAssignment | CassandraRoleAssignmentResource |
| `Microsoft.DocumentDB/databaseAccounts/cassandraRoleDefinitions` | CassandraRoleDefinition | CassandraRoleDefinitionResource |
| `Microsoft.DocumentDB/databaseAccounts/gremlinRoleAssignments` | GremlinRoleAssignment | GremlinRoleAssignmentResource |
| `Microsoft.DocumentDB/databaseAccounts/gremlinRoleDefinitions` | GremlinRoleDefinition | GremlinRoleDefinitionResource |
| `Microsoft.DocumentDB/databaseAccounts/mongoMIRoleAssignments` | MongoMIRoleAssignment | MongoMIRoleAssignmentResource |
| `Microsoft.DocumentDB/databaseAccounts/mongoMIRoleDefinitions` | MongoMIRoleDefinition | MongoMIRoleDefinitionResource |
| `Microsoft.DocumentDB/databaseAccounts/privateLinkResources` | CosmosDBPrivateLinkResource | PrivateLinkResource |
| `Microsoft.DocumentDB/fleets` | CosmosDBFleet | FleetResource |
| `Microsoft.DocumentDB/fleets/fleetspaces` | CosmosDBFleetspace | FleetspaceResource |
| `Microsoft.DocumentDB/fleets/fleetspaces/fleetspaceAccounts` | CosmosDBFleetspaceAccount | FleetspaceAccountResource |
| `Microsoft.DocumentDB/locations` | CosmosDBLocation | LocationGetResult |
| `Microsoft.DocumentDB/locations/restorableDatabaseAccounts` | RestorableCosmosDBAccount | RestorableDatabaseAccountGetResult |

## Azure.Provisioning.CostManagement

Package: `sdk/costmanagement/Azure.Provisioning.CostManagement`. Distinct ARM resource types: **9 -> 9**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.CostManagement/alerts` | CostManagementAlert | Alert |
| `Microsoft.CostManagement/costAllocationRules` | CostAllocationRule | ExternalResourceCostAllocationRuleDefinition |
| `Microsoft.CostManagement/exports` | CostManagementExport | Export |
| `Microsoft.CostManagement/settings` | CostManagementSetting | Setting |

## Azure.Provisioning.DataBox

Package: `sdk/databox/Azure.Provisioning.DataBox`. Distinct ARM resource types: **1 -> 1**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.DataBox/jobs` | DataBoxJob | JobResource |

## Azure.Provisioning.Databricks

Package: `sdk/databricks/Azure.Provisioning.Databricks`. Distinct ARM resource types: **5 -> 5**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Databricks/accessConnectors` | DatabricksAccessConnector | AccessConnector |
| `Microsoft.Databricks/workspaces` | DatabricksWorkspace | Workspace |
| `Microsoft.Databricks/workspaces/privateEndpointConnections` | DatabricksPrivateEndpointConnection | PrivateEndpointConnection |
| `Microsoft.Databricks/workspaces/privateLinkResources` | DatabricksPrivateLinkResource | GroupIdInformation |
| `Microsoft.Databricks/workspaces/virtualNetworkPeerings` | DatabricksVirtualNetworkPeering | VirtualNetworkPeering |

## Azure.Provisioning.DesktopVirtualization

Package: `sdk/desktopvirtualization/Azure.Provisioning.DesktopVirtualization`. Distinct ARM resource types: **17 -> 17**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.DesktopVirtualization/applicationGroups` | VirtualApplicationGroup | ApplicationGroup |
| `Microsoft.DesktopVirtualization/applicationGroups/applications` | VirtualApplication | Application |
| `Microsoft.DesktopVirtualization/applicationGroups/desktops` | VirtualDesktop | Desktop |
| `Microsoft.DesktopVirtualization/hostPools/msixPackages` | MsixPackage | MSIXPackage |
| `Microsoft.DesktopVirtualization/workspaces` | VirtualWorkspace | Workspace |

## Azure.Provisioning.Dns

Package: `sdk/dns/Azure.Provisioning.Dns`. Distinct ARM resource types: **15 -> 2**.

Removed ARM resource types:

- `Microsoft.Network/dnsZones/A`: `DnsARecord`
- `Microsoft.Network/dnsZones/AAAA`: `DnsAaaaRecord`
- `Microsoft.Network/dnsZones/CAA`: `DnsCaaRecord`
- `Microsoft.Network/dnsZones/CNAME`: `DnsCnameRecord`
- `Microsoft.Network/dnsZones/DS`: `DnsDSRecord`
- `Microsoft.Network/dnsZones/MX`: `DnsMXRecord`
- `Microsoft.Network/dnsZones/NAPTR`: `DnsNaptrRecord`
- `Microsoft.Network/dnsZones/NS`: `DnsNSRecord`
- `Microsoft.Network/dnsZones/PTR`: `DnsPtrRecord`
- `Microsoft.Network/dnsZones/SOA`: `DnsSoaRecord`
- `Microsoft.Network/dnsZones/SRV`: `DnsSrvRecord`
- `Microsoft.Network/dnsZones/TLSA`: `DnsTlsaRecord`
- `Microsoft.Network/dnsZones/TXT`: `DnsTxtRecord`

## Azure.Provisioning.DomainRegistration

Package: `sdk/domainregistration/Azure.Provisioning.DomainRegistration`. Distinct ARM resource types: **3 -> 3**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.DomainRegistration/domains` | AppServiceDomain | Domain |

## Azure.Provisioning.DurableTask

Package: `sdk/durabletask/Azure.Provisioning.DurableTask`. Distinct ARM resource types: **5 -> 5**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.DurableTask/schedulers` | DurableTaskScheduler | Scheduler |
| `Microsoft.DurableTask/schedulers/privateEndpointConnections` | DurableTaskPrivateEndpointConnection | SchedulerPrivateEndpointConnection |
| `Microsoft.DurableTask/schedulers/privateLinkResources` | DurableTaskSchedulerPrivateLinkResource | SchedulerSchedulerPrivateLinkResource |
| `Microsoft.DurableTask/schedulers/retentionPolicies` | DurableTaskRetentionPolicy | RetentionPolicy |
| `Microsoft.DurableTask/schedulers/taskHubs` | DurableTaskHub | TaskHub |

## Azure.Provisioning.Enclave

Package: `sdk/enclave/Azure.Provisioning.Enclave`. Distinct ARM resource types: **9 -> 9**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Mission/approvals` | VirtualEnclaveApproval | ApprovalResource |
| `Microsoft.Mission/communities` | VirtualEnclaveCommunity | CommunityResource |
| `Microsoft.Mission/communities/communityEndpoints` | VirtualEnclaveCommunityEndpoint | CommunityEndpointResource |
| `Microsoft.Mission/communities/dedicatedHubs` | VirtualEnclaveDedicatedHub | DedicatedHubResource |
| `Microsoft.Mission/communities/transitHubs` | VirtualEnclaveTransitHub | TransitHubResource |
| `Microsoft.Mission/enclaveConnections` | VirtualEnclaveConnection | EnclaveConnectionResource |
| `Microsoft.Mission/virtualEnclaves` | VirtualEnclave | EnclaveResource |
| `Microsoft.Mission/virtualEnclaves/enclaveEndpoints` | VirtualEnclaveEndpoint | EnclaveEndpointResource |
| `Microsoft.Mission/virtualEnclaves/workloads` | VirtualEnclaveWorkload | WorkloadResource |

## Azure.Provisioning.EventGrid

Package: `sdk/eventgrid/Azure.Provisioning.EventGrid`. Distinct ARM resource types: **32 -> 27**.

Removed ARM resource types:

- `Microsoft.EventGrid/domains/networkSecurityPerimeterConfigurations`: `DomainNetworkSecurityPerimeterConfiguration`
- `Microsoft.EventGrid/domains/privateEndpointConnections`: `EventGridDomainPrivateEndpointConnection`
- `Microsoft.EventGrid/partnerNamespaces/privateEndpointConnections`: `EventGridPartnerNamespacePrivateEndpointConnection`
- `Microsoft.EventGrid/topics/networkSecurityPerimeterConfigurations`: `TopicNetworkSecurityPerimeterConfiguration`
- `Microsoft.EventGrid/topics/privateEndpointConnections`: `EventGridTopicPrivateEndpointConnection`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.EventGrid/topicTypes` | TopicType | TopicTypeInfo |

## Azure.Provisioning.EventHubs

Package: `sdk/eventhub/Azure.Provisioning.EventHubs`. Distinct ARM resource types: **13 -> 13**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.EventHub/namespaces/authorizationRules` | EventHubsNamespaceAuthorizationRule | NamespacesAuthorizationRules |
| `Microsoft.EventHub/namespaces/disasterRecoveryConfigs/authorizationRules` | EventHubsDisasterRecoveryAuthorizationRule | DisasterRecoveryConfigsAuthorizationRules |
| `Microsoft.EventHub/namespaces/eventhubs/authorizationRules` | EventHubAuthorizationRule | EventhubsAuthorizationRules |
| `Microsoft.EventHub/namespaces/networkSecurityPerimeterConfigurations` | EventHubsNetworkSecurityPerimeterConfiguration | NetworkSecurityPerimeterConfiguration |

## Azure.Provisioning.Fabric

Package: `sdk/fabric/Azure.Provisioning.Fabric`. Distinct ARM resource types: **1 -> 1**.

Resource identities and class names are unchanged.

## Azure.Provisioning.FrontDoor

Package: `sdk/frontdoor/Azure.Provisioning.FrontDoor`. Distinct ARM resource types: **6 -> 0**.

Removed ARM resource types:

- `Microsoft.Network/FrontDoorWebApplicationFirewallPolicies`: `FrontDoorWebApplicationFirewallPolicy`
- `Microsoft.Network/NetworkExperimentProfiles`: `FrontDoorNetworkExperimentProfile`
- `Microsoft.Network/NetworkExperimentProfiles/Experiments`: `FrontDoorExperiment`
- `Microsoft.Network/frontDoors`: `FrontDoorResource`
- `Microsoft.Network/frontDoors/frontendEndpoints`: `FrontendEndpoint`
- `Microsoft.Network/frontDoors/rulesEngines`: `FrontDoorRulesEngine`

## Azure.Provisioning.HealthcareApis

Package: `sdk/healthcareapis/Azure.Provisioning.HealthcareApis`. Distinct ARM resource types: **10 -> 10**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.HealthcareApis/services` | HealthcareApisService | ServicesDescription |
| `Microsoft.HealthcareApis/services/privateEndpointConnections` | HealthcareApisServicePrivateEndpointConnection | ServicesPrivateEndpointConnections |
| `Microsoft.HealthcareApis/services/privateLinkResources` | HealthcareApisServicePrivateLinkResource | ServicesPrivateLinkResources |
| `Microsoft.HealthcareApis/workspaces` | HealthcareApisWorkspace | Workspace |
| `Microsoft.HealthcareApis/workspaces/iotconnectors` | HealthcareApisIotConnector | IotConnector |
| `Microsoft.HealthcareApis/workspaces/iotconnectors/fhirdestinations` | HealthcareApisIotFhirDestination | IotFhirDestination |
| `Microsoft.HealthcareApis/workspaces/privateEndpointConnections` | HealthcareApisWorkspacePrivateEndpointConnection | WorkspacesPrivateEndpointConnections |
| `Microsoft.HealthcareApis/workspaces/privateLinkResources` | HealthcareApisWorkspacePrivateLinkResource | WorkspacesPrivateLinkResources |

## Azure.Provisioning.Kubernetes

Package: `sdk/hybridkubernetes/Azure.Provisioning.Kubernetes`. Distinct ARM resource types: **1 -> 1**.

Resource identities and class names are unchanged.

## Azure.Provisioning.IotHub

Package: `sdk/iothub/Azure.Provisioning.IotHub`. Distinct ARM resource types: **4 -> 5**.

Added ARM resource types:

- `Microsoft.Devices/IotHubs/jobs`: `IotHubJob`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Devices/IotHubs` | IotHubDescription | IotHub |
| `Microsoft.Devices/IotHubs/certificates` | IotHubCertificateDescription | CertificateDescription |
| `Microsoft.Devices/iotHubs/privateEndpointConnections` | IotHubPrivateEndpointConnection | IotHubsPrivateEndpointConnections |

## Azure.Provisioning.KeyVault

Package: `sdk/keyvault/Azure.Provisioning.KeyVault`. Distinct ARM resource types: **7 -> 7**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.KeyVault/locations/deletedVaults` | DeletedKeyVault | DeletedVault |

## Azure.Provisioning.KubernetesConfiguration.Extensions

Package: `sdk/kubernetesconfiguration/Azure.Provisioning.KubernetesConfiguration.Extensions`. Distinct ARM resource types: **1 -> 1**.

Resource identities and class names are unchanged.

## Azure.Provisioning.KubernetesConfiguration.ExtensionTypes

Package: `sdk/kubernetesconfiguration/Azure.Provisioning.KubernetesConfiguration.ExtensionTypes`. Distinct ARM resource types: **4 -> 4**.

Resource identities and class names are unchanged.

## Azure.Provisioning.KubernetesConfiguration.FluxConfigurations

Package: `sdk/kubernetesconfiguration/Azure.Provisioning.KubernetesConfiguration.FluxConfigurations`. Distinct ARM resource types: **1 -> 1**.

Resource identities and class names are unchanged.

## Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes

Package: `sdk/kubernetesconfiguration/Azure.Provisioning.KubernetesConfiguration.PrivateLinkScopes`. Distinct ARM resource types: **3 -> 3**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.KubernetesConfiguration/privateLinkScopes/privateEndpointConnections` | KubernetesConfigurationPrivateEndpointConnection | KubernetesConfigurationPrivateLinkScopePrivateEndpointConnection |
| `Microsoft.KubernetesConfiguration/privateLinkScopes/privateLinkResources` | KubernetesConfigurationPrivateLinkResource | PrivateLinkResource |

## Azure.Provisioning.Kusto

Package: `sdk/kusto/Azure.Provisioning.Kusto`. Distinct ARM resource types: **11 -> 9**.

Removed ARM resource types:

- `Microsoft.Kusto/clusters/databases`: `KustoDatabase`
- `Microsoft.Kusto/clusters/databases/dataConnections`: `KustoDataConnection`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Kusto/clusters` | KustoCluster | Cluster |
| `Microsoft.Kusto/clusters/attachedDatabaseConfigurations` | KustoAttachedDatabaseConfiguration | AttachedDatabaseConfiguration |
| `Microsoft.Kusto/clusters/databases/principalAssignments` | KustoDatabasePrincipalAssignment | DatabasePrincipalAssignment |
| `Microsoft.Kusto/clusters/databases/scripts` | KustoScript | Script |
| `Microsoft.Kusto/clusters/managedPrivateEndpoints` | KustoManagedPrivateEndpoint | ManagedPrivateEndpoint |
| `Microsoft.Kusto/clusters/principalAssignments` | KustoClusterPrincipalAssignment | ClusterPrincipalAssignment |
| `Microsoft.Kusto/clusters/privateEndpointConnections` | KustoPrivateEndpointConnection | PrivateEndpointConnection |
| `Microsoft.Kusto/clusters/privateLinkResources` | KustoPrivateLinkResource | PrivateLinkResource |

## Azure.Provisioning.LoadTesting

Package: `sdk/loadtestservice/Azure.Provisioning.LoadTesting`. Distinct ARM resource types: **2 -> 2**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.LoadTestService/loadTests` | LoadTestingResource | LoadTestResource |
| `Microsoft.LoadTestService/locations/quotas` | LoadTestingQuota | QuotaResource |

## Azure.Provisioning.MachineLearning

Package: `sdk/machinelearningservices/Azure.Provisioning.MachineLearning`. Distinct ARM resource types: **41 -> 42**.

Added ARM resource types:

- `Microsoft.MachineLearningServices/workspaces/managedNetworks/outboundRules`: `ManagedNetworkOutboundRuleBasic`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.MachineLearningServices/registries` | MachineLearningRegistry | Registry |
| `Microsoft.MachineLearningServices/registries/components` | MachineLearningRegistryComponentContainer | MachineLearninRegistryComponentContainer |
| `Microsoft.MachineLearningServices/registries/components/versions` | MachineLearningRegistryComponentVersion | MachineLearninRegistryComponentVersion |
| `Microsoft.MachineLearningServices/workspaces` | MachineLearningWorkspace | Workspace |
| `Microsoft.MachineLearningServices/workspaces/batchEndpoints` | MachineLearningBatchEndpoint | BatchEndpoint |
| `Microsoft.MachineLearningServices/workspaces/batchEndpoints/deployments` | MachineLearningBatchDeployment | BatchDeployment |
| `Microsoft.MachineLearningServices/workspaces/computes` | MachineLearningCompute | ComputeResource |
| `Microsoft.MachineLearningServices/workspaces/connections` | MachineLearningWorkspaceConnection | WorkspaceConnectionPropertiesV2BasicResource |
| `Microsoft.MachineLearningServices/workspaces/datastores` | MachineLearningDatastore | Datastore |
| `Microsoft.MachineLearningServices/workspaces/featuresets` | MachineLearningFeatureSetContainer | FeaturesetContainer |
| `Microsoft.MachineLearningServices/workspaces/featuresets/versions` | MachineLearningFeatureSetVersion | FeaturesetVersion |
| `Microsoft.MachineLearningServices/workspaces/featuresets/versions/features` | MachineLearningFeature | VersionsFeatures |
| `Microsoft.MachineLearningServices/workspaces/featurestoreEntities` | MachineLearningFeatureStoreEntityContainer | FeaturestoreEntityContainer |
| `Microsoft.MachineLearningServices/workspaces/featurestoreEntities/versions` | MachineLearningFeaturestoreEntityVersion | FeaturestoreEntityVersion |
| `Microsoft.MachineLearningServices/workspaces/jobs` | MachineLearningJob | JobBase |
| `Microsoft.MachineLearningServices/workspaces/marketplaceSubscriptions` | MachineLearningMarketplaceSubscription | MarketplaceSubscription |
| `Microsoft.MachineLearningServices/workspaces/onlineEndpoints` | MachineLearningOnlineEndpoint | OnlineEndpoint |
| `Microsoft.MachineLearningServices/workspaces/onlineEndpoints/deployments` | MachineLearningOnlineDeployment | OnlineDeployment |
| `Microsoft.MachineLearningServices/workspaces/privateEndpointConnections` | MachineLearningPrivateEndpointConnection | PrivateEndpointConnection |
| `Microsoft.MachineLearningServices/workspaces/schedules` | MachineLearningSchedule | Schedule |
| `Microsoft.MachineLearningServices/workspaces/serverlessEndpoints` | MachineLearningServerlessEndpoint | ServerlessEndpoint |

## Azure.Provisioning.Maps

Package: `sdk/maps/Azure.Provisioning.Maps`. Distinct ARM resource types: **4 -> 4**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Maps/accounts/creators` | MapsCreator | Creator |
| `Microsoft.Maps/accounts/privateEndpointConnections` | MapsPrivateEndpointConnection | MapsAccountPrivateEndpointConnection |
| `Microsoft.Maps/accounts/privateLinkResources` | MapsPrivateLinkResource | PrivateLinkResource |

## Azure.Provisioning.Monitor

Package: `sdk/monitor/Azure.Provisioning.Monitor`. Distinct ARM resource types: **18 -> 18**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Insights/actionGroups` | ActionGroup | ActionGroupResource |
| `Microsoft.Insights/activityLogAlerts` | ActivityLogAlert | ActivityLogAlertResource |
| `Microsoft.Insights/autoscalesettings` | AutoscaleSetting | AutoscaleSettingResource |
| `Microsoft.Insights/dataCollectionEndpoints` | DataCollectionEndpoint | DataCollectionEndpointResource |
| `Microsoft.Insights/dataCollectionRules` | DataCollectionRule | DataCollectionRuleResource |
| `Microsoft.Insights/logprofiles` | LogProfile | LogProfileResource |
| `Microsoft.Insights/metricAlerts` | MetricAlert | MetricAlertResource |
| `Microsoft.Insights/privateLinkScopes` | MonitorPrivateLinkScope | AzureMonitorPrivateLinkScope |
| `Microsoft.Insights/privateLinkScopes/privateEndpointConnections` | MonitorPrivateEndpointConnection | AzureMonitorPrivateLinkScopePrivateEndpointConnection |
| `Microsoft.Insights/privateLinkScopes/privateLinkResources` | MonitorPrivateLinkResource | AzureMonitorPrivateLinkScopePrivateLinkResource |
| `Microsoft.Insights/privateLinkScopes/scopedResources` | MonitorPrivateLinkScopedResource | ScopedResource |
| `Microsoft.Insights/scheduledQueryRules` | ScheduledQueryRule | ScheduledQueryRuleResource |
| `Microsoft.Insights/tenantActionGroups` | TenantActionGroupResource | ManagementGroupTenantActionGroupResource |
| `microsoft.insights/diagnosticSettings` | ServiceDiagnosticSetting | ServiceDiagnosticSettingsResource |

## Azure.Provisioning.MySql

Package: `sdk/mysql/Azure.Provisioning.MySql`. Distinct ARM resource types: **11 -> 11**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.DBforMySQL/flexibleServers` | MySqlFlexibleServer | Server |
| `Microsoft.DBforMySQL/flexibleServers/administrators` | MySqlFlexibleServerAadAdministrator | AzureADAdministrator |
| `Microsoft.DBforMySQL/flexibleServers/backups` | MySqlFlexibleServerBackup | ServerBackup |
| `Microsoft.DBforMySQL/flexibleServers/backupsV2` | MySqlFlexibleServerBackupV2 | ServerBackupV2 |
| `Microsoft.DBforMySQL/flexibleServers/configurations` | MySqlFlexibleServerConfiguration | Configuration |
| `Microsoft.DBforMySQL/flexibleServers/databases` | MySqlFlexibleServerDatabase | Database |
| `Microsoft.DBforMySQL/flexibleServers/firewallRules` | MySqlFlexibleServerFirewallRule | FirewallRule |
| `Microsoft.DBforMySQL/flexibleServers/maintenances` | MySqlFlexibleServerMaintenance | Maintenance |
| `Microsoft.DBforMySQL/flexibleServers/privateEndpointConnections` | MySqlFlexibleServersPrivateEndpointConnection | ServerPrivateEndpointConnection |
| `Microsoft.DBforMySQL/locations/capabilitySets` | MySqlFlexibleServersCapability | LocationsCapabilitySets |

## Azure.Provisioning.Network

Package: `sdk/network/Azure.Provisioning.Network`. Distinct ARM resource types: **143 -> 0**.

Removed ARM resource types:

- `Microsoft.Compute/virtualMachineScaleSets/virtualMachines/networkInterfaces`: `VirtualMachineScaleSetNetworkInterface`
- `Microsoft.Compute/virtualMachineScaleSets/virtualMachines/networkInterfaces/ipConfigurations`: `VirtualMachineScaleSetNetworkInterfaceIPConfiguration`
- `Microsoft.Compute/virtualMachineScaleSets/virtualMachines/networkInterfaces/ipconfigurations/publicipaddresses`: `VirtualMachineScaleSetNetworkInterfaceIPConfigurationPublicIPAddress`
- `Microsoft.Network/ApplicationGatewayWebApplicationFirewallPolicies`: `WebApplicationFirewallPolicy`
- `Microsoft.Network/ExpressRoutePorts`: `ExpressRoutePort`
- `Microsoft.Network/ExpressRoutePorts/links`: `ExpressRouteLink`
- `Microsoft.Network/ExpressRoutePortsLocations`: `ExpressRoutePortsLocation`
- `Microsoft.Network/IpAllocations`: `IPAllocation`
- `Microsoft.Network/applicationGatewayAvailableSslOptions`: `ApplicationGatewayAvailableSslOptionsInfo`
- `Microsoft.Network/applicationGateways`: `ApplicationGateway`
- `Microsoft.Network/applicationGateways/privateEndpointConnections`: `ApplicationGatewayPrivateEndpointConnection`
- `Microsoft.Network/applicationSecurityGroups`: `ApplicationSecurityGroup`
- `Microsoft.Network/applicationSecurityGroups/addressPrefixSets`: `AddressPrefixSet`
- `Microsoft.Network/authenticationPolicies`: `IdentityIntegrationAuthenticationPolicy`
- `Microsoft.Network/azureFirewalls`: `AzureFirewall`
- `Microsoft.Network/azureWebCategories`: `AzureWebCategory`
- `Microsoft.Network/bastionHosts`: `BastionHost`
- `Microsoft.Network/cloudServiceSlots`: `CloudServiceSwap`
- `Microsoft.Network/connections`: `VirtualNetworkGatewayConnection`
- `Microsoft.Network/customIpPrefixes`: `CustomIPPrefix`
- `Microsoft.Network/ddosCustomPolicies`: `DdosCustomPolicy`
- `Microsoft.Network/ddosProtectionPlans`: `DdosProtectionPlan`
- `Microsoft.Network/dscpConfigurations`: `DscpConfiguration`
- `Microsoft.Network/expressRouteCircuits`: `ExpressRouteCircuit`
- `Microsoft.Network/expressRouteCircuits/authorizations`: `ExpressRouteCircuitAuthorization`
- `Microsoft.Network/expressRouteCircuits/peerings`: `ExpressRouteCircuitPeering`
- `Microsoft.Network/expressRouteCircuits/peerings/connections`: `ExpressRouteCircuitConnection`
- `Microsoft.Network/expressRouteCircuits/peerings/peerConnections`: `PeerExpressRouteCircuitConnection`
- `Microsoft.Network/expressRouteCrossConnections`: `ExpressRouteCrossConnection`
- `Microsoft.Network/expressRouteCrossConnections/peerings`: `ExpressRouteCrossConnectionPeering`
- `Microsoft.Network/expressRouteGateways`: `ExpressRouteGateway`
- `Microsoft.Network/expressRouteGateways/expressRouteConnections`: `ExpressRouteConnection`
- `Microsoft.Network/expressRouteLags`: `ExpressRouteLag`
- `Microsoft.Network/expressRoutePorts/authorizations`: `ExpressRoutePortAuthorization`
- `Microsoft.Network/expressRouteProviderPorts`: `ExpressRouteProviderPort`
- `Microsoft.Network/firewallPolicies`: `FirewallPolicy`
- `Microsoft.Network/firewallPolicies/firewallPolicyDrafts`: `FirewallPolicyDraft`
- `Microsoft.Network/firewallPolicies/kubeSelectorGroups`: `FirewallPolicyKubeSelectorGroup`
- `Microsoft.Network/firewallPolicies/ruleCollectionGroups`: `FirewallPolicyRuleCollectionGroup`
- `Microsoft.Network/firewallPolicies/ruleCollectionGroups/ruleCollectionGroupDrafts`: `FirewallPolicyRuleCollectionGroupDraft`
- `Microsoft.Network/firewallPolicies/signatureOverrides`: `PolicySignaturesOverridesForIdps`
- `Microsoft.Network/firstPartyServiceTags`: `FirstPartyServiceTag`
- `Microsoft.Network/interconnectGroups`: `InterconnectGroup`
- `Microsoft.Network/interconnectGroups/subgroups`: `InterconnectGroupSubgroup`
- `Microsoft.Network/ipGroups`: `IPGroup`
- `Microsoft.Network/loadBalancers`: `LoadBalancer`
- `Microsoft.Network/loadBalancers/backendAddressPools`: `BackendAddressPool`
- `Microsoft.Network/loadBalancers/frontendIPConfigurations`: `FrontendIPConfiguration`
- `Microsoft.Network/loadBalancers/inboundNatRules`: `InboundNatRule`
- `Microsoft.Network/loadBalancers/loadBalancingRules`: `LoadBalancingRule`
- `Microsoft.Network/loadBalancers/outboundRules`: `OutboundRule`
- `Microsoft.Network/loadBalancers/probes`: `ProbeResource`
- `Microsoft.Network/localNetworkGateways`: `LocalNetworkGateway`
- `Microsoft.Network/locations/applicationGatewayWafDynamicManifests`: `ApplicationGatewayWafDynamicManifest`
- `Microsoft.Network/natGateways`: `NatGateway`
- `Microsoft.Network/networkInterfaces`: `NetworkInterface`
- `Microsoft.Network/networkInterfaces/ipConfigurations`: `NetworkInterfaceIPConfiguration`
- `Microsoft.Network/networkInterfaces/tapConfigurations`: `NetworkInterfaceTapConfiguration`
- `Microsoft.Network/networkManagerConnections`: `NetworkManagerConnection`
- `Microsoft.Network/networkManagers`: `NetworkManager`
- `Microsoft.Network/networkManagers/commits`: `NetworkManagerConfigurationCommit`
- `Microsoft.Network/networkManagers/connectivityConfigurations`: `ConnectivityConfiguration`
- `Microsoft.Network/networkManagers/ipamPools`: `IpamPool`
- `Microsoft.Network/networkManagers/ipamPools/staticCidrs`: `StaticCidr`
- `Microsoft.Network/networkManagers/networkGroups`: `NetworkGroup`
- `Microsoft.Network/networkManagers/networkGroups/staticMembers`: `NetworkGroupStaticMember`
- `Microsoft.Network/networkManagers/routingConfigurations`: `NetworkManagerRoutingConfiguration`
- `Microsoft.Network/networkManagers/routingConfigurations/ruleCollections`: `NetworkManagerRoutingRules`
- `Microsoft.Network/networkManagers/routingConfigurations/ruleCollections/rules`: `NetworkManagerRoutingRule`
- `Microsoft.Network/networkManagers/scopeConnections`: `ScopeConnection`
- `Microsoft.Network/networkManagers/securityAdminConfigurations`: `SecurityAdminConfiguration`
- `Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections`: `AdminRuleGroup`
- `Microsoft.Network/networkManagers/securityAdminConfigurations/ruleCollections/rules`: `BaseAdminRule`
- `Microsoft.Network/networkManagers/securityUserConfigurations`: `NetworkManagerSecurityUserConfiguration`
- `Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections`: `NetworkManagerSecurityUserRules`
- `Microsoft.Network/networkManagers/securityUserConfigurations/ruleCollections/rules`: `NetworkManagerSecurityUserRule`
- `Microsoft.Network/networkManagers/verifierWorkspaces`: `NetworkVerifierWorkspace`
- `Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisIntents`: `ReachabilityAnalysisIntent`
- `Microsoft.Network/networkManagers/verifierWorkspaces/reachabilityAnalysisRuns`: `ReachabilityAnalysisRun`
- `Microsoft.Network/networkProfiles`: `NetworkProfile`
- `Microsoft.Network/networkSecurityGroups`: `NetworkSecurityGroup`
- `Microsoft.Network/networkSecurityGroups/defaultSecurityRules`: `DefaultSecurityRule`
- `Microsoft.Network/networkSecurityGroups/securityRules`: `SecurityRule`
- `Microsoft.Network/networkSecurityPerimeters`: `NetworkSecurityPerimeter`
- `Microsoft.Network/networkSecurityPerimeters/linkReferences`: `NetworkSecurityPerimeterLinkReference`
- `Microsoft.Network/networkSecurityPerimeters/links`: `NetworkSecurityPerimeterLink`
- `Microsoft.Network/networkSecurityPerimeters/loggingConfigurations`: `NetworkSecurityPerimeterLoggingConfiguration`
- `Microsoft.Network/networkSecurityPerimeters/profiles`: `NetworkSecurityPerimeterProfile`
- `Microsoft.Network/networkSecurityPerimeters/profiles/accessRules`: `NetworkSecurityPerimeterAccessRule`
- `Microsoft.Network/networkSecurityPerimeters/resourceAssociations`: `NetworkSecurityPerimeterAssociation`
- `Microsoft.Network/networkVirtualApplianceSkus`: `NetworkVirtualApplianceSku`
- `Microsoft.Network/networkVirtualAppliances`: `NetworkVirtualAppliance`
- `Microsoft.Network/networkVirtualAppliances/inboundSecurityRules`: `InboundSecurityRule`
- `Microsoft.Network/networkVirtualAppliances/networkVirtualApplianceConnections`: `NetworkVirtualApplianceConnection`
- `Microsoft.Network/networkVirtualAppliances/virtualApplianceSites`: `VirtualApplianceSite`
- `Microsoft.Network/networkWatchers`: `NetworkWatcher`
- `Microsoft.Network/networkWatchers/connectionAnalyzers`: `ConnectionAnalyzer`
- `Microsoft.Network/networkWatchers/connectionMonitors`: `ConnectionMonitor`
- `Microsoft.Network/networkWatchers/flowLogs`: `FlowLog`
- `Microsoft.Network/networkWatchers/packetCaptures`: `PacketCapture`
- `Microsoft.Network/p2svpnGateways`: `P2SVpnGateway`
- `Microsoft.Network/privateEndpoints`: `PrivateEndpoint`
- `Microsoft.Network/privateEndpoints/privateDnsZoneGroups`: `PrivateDnsZoneGroup`
- `Microsoft.Network/privateLinkServices`: `PrivateLinkService`
- `Microsoft.Network/privateLinkServices/privateEndpointConnections`: `NetworkPrivateEndpointConnection`
- `Microsoft.Network/publicIPAddresses`: `PublicIPAddress`
- `Microsoft.Network/publicIPPrefixes`: `PublicIPPrefix`
- `Microsoft.Network/routeFilters`: `RouteFilter`
- `Microsoft.Network/routeFilters/routeFilterRules`: `RouteFilterRule`
- `Microsoft.Network/routeTables`: `RouteTable`
- `Microsoft.Network/routeTables/routes`: `RouteResource`
- `Microsoft.Network/securityPartnerProviders`: `SecurityPartnerProvider`
- `Microsoft.Network/serviceEndpointPolicies`: `ServiceEndpointPolicy`
- `Microsoft.Network/serviceEndpointPolicies/serviceEndpointPolicyDefinitions`: `ServiceEndpointPolicyDefinition`
- `Microsoft.Network/serviceGateways`: `ServiceGateway`
- `Microsoft.Network/virtualHubs`: `VirtualHub`
- `Microsoft.Network/virtualHubs/bgpConnections`: `BgpConnection`
- `Microsoft.Network/virtualHubs/connectionPolicies`: `ConnectionPolicy`
- `Microsoft.Network/virtualHubs/hubRouteTables`: `HubRouteTable`
- `Microsoft.Network/virtualHubs/hubVirtualNetworkConnections`: `HubVirtualNetworkConnection`
- `Microsoft.Network/virtualHubs/ipConfigurations`: `HubIPConfiguration`
- `Microsoft.Network/virtualHubs/routeMaps`: `RouteMap`
- `Microsoft.Network/virtualHubs/routeTables`: `VirtualHubRouteTableV2`
- `Microsoft.Network/virtualHubs/routingIntent`: `RoutingIntent`
- `Microsoft.Network/virtualNetworkAppliances`: `VirtualNetworkAppliance`
- `Microsoft.Network/virtualNetworkGateways`: `VirtualNetworkGateway`
- `Microsoft.Network/virtualNetworkGateways/natRules`: `VirtualNetworkGatewayNatRule`
- `Microsoft.Network/virtualNetworkTaps`: `VirtualNetworkTap`
- `Microsoft.Network/virtualNetworks`: `VirtualNetwork`
- `Microsoft.Network/virtualNetworks/subnets`: `SubnetResource`
- `Microsoft.Network/virtualNetworks/virtualNetworkPeerings`: `VirtualNetworkPeering`
- `Microsoft.Network/virtualRouters`: `VirtualRouter`
- `Microsoft.Network/virtualRouters/peerings`: `VirtualRouterPeering`
- `Microsoft.Network/virtualWans`: `VirtualWan`
- `Microsoft.Network/vpnGateways`: `VpnGateway`
- `Microsoft.Network/vpnGateways/natRules`: `VpnGatewayNatRule`
- `Microsoft.Network/vpnGateways/vpnConnections`: `VpnConnection`
- `Microsoft.Network/vpnGateways/vpnConnections/vpnLinkConnections`: `VpnSiteLinkConnection`
- `Microsoft.Network/vpnGateways/vpnConnections/vpnLinkConnections/sharedKeys`: `VpnLinkConnectionSharedKey`
- `Microsoft.Network/vpnServerConfigurations`: `VpnServerConfiguration`
- `Microsoft.Network/vpnServerConfigurations/configurationPolicyGroups`: `VpnServerConfigurationPolicyGroup`
- `Microsoft.Network/vpnSites`: `VpnSite`
- `Microsoft.Network/vpnSites/vpnSiteLinks`: `VpnSiteLink`

## Azure.Provisioning.OperationalInsights

Package: `sdk/operationalinsights/Azure.Provisioning.OperationalInsights`. Distinct ARM resource types: **12 -> 12**.

Added ARM resource types:

- `Microsoft.OperationalInsights/workspaces/operations`: `WorkspacesOperations`

Removed ARM resource types:

- `Microsoft.OperationalInsights/workspaces/dataSources`: `OperationalInsightsDataSource`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.OperationalInsights/workspaces/summaryLogs` | OperationalInsightsSummaryLogs | WorkspacesSummaryLogs |

## Azure.Provisioning.PostgreSql

Package: `sdk/postgresql/Azure.Provisioning.PostgreSql`. Distinct ARM resource types: **13 -> 13**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.DBforPostgreSQL/flexibleServers/administrators` | PostgreSqlFlexibleServerMicrosoftEntraAdministrator | AdministratorMicrosoftEntra |
| `Microsoft.DBforPostgreSQL/flexibleServers/ltrBackupOperations` | PostgreSqlLtrServerBackupOperation | FlexibleServersLtrBackupOperations |
| `Microsoft.DBforPostgreSQL/flexibleServers/privateLinkResources` | PostgreSqlFlexibleServersPrivateLinkResource | PrivateLinkResource |
| `Microsoft.DBforPostgreSQL/flexibleServers/tuningOptions` | PostgreSqlFlexibleServerTuningOption | TuningOptions |

## Azure.Provisioning.PrivateDns

Package: `sdk/privatedns/Azure.Provisioning.PrivateDns`. Distinct ARM resource types: **10 -> 2**.

Removed ARM resource types:

- `Microsoft.Network/privateDnsZones/A`: `PrivateDnsARecord`
- `Microsoft.Network/privateDnsZones/AAAA`: `PrivateDnsAaaaRecord`
- `Microsoft.Network/privateDnsZones/CNAME`: `PrivateDnsCnameRecord`
- `Microsoft.Network/privateDnsZones/MX`: `PrivateDnsMXRecord`
- `Microsoft.Network/privateDnsZones/PTR`: `PrivateDnsPtrRecord`
- `Microsoft.Network/privateDnsZones/SOA`: `PrivateDnsSoaRecord`
- `Microsoft.Network/privateDnsZones/SRV`: `PrivateDnsSrvRecord`
- `Microsoft.Network/privateDnsZones/TXT`: `PrivateDnsTxtRecord`

## Azure.Provisioning.RecoveryServices

Package: `sdk/recoveryservices/Azure.Provisioning.RecoveryServices`. Distinct ARM resource types: **4 -> 5**.

Added ARM resource types:

- `Microsoft.RecoveryServices/locations/deletedVaults/operations`: `DeletedVaultsOperations`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.RecoveryServices/locations/deletedVaults` | RecoveryServicesDeletedVault | LocationsDeletedVaults |
| `Microsoft.RecoveryServices/vaults` | RecoveryServicesVault | Vaults |
| `Microsoft.RecoveryServices/vaults/extendedInformation` | RecoveryServicesVaultExtendedInfo | VaultExtendedInfoResource |
| `Microsoft.RecoveryServices/vaults/privateLinkResources` | RecoveryServicesPrivateLinkResource | PrivateLinkResource |

## Azure.Provisioning.RecoveryServicesBackup

Package: `sdk/recoveryservices-backup/Azure.Provisioning.RecoveryServicesBackup`. Distinct ARM resource types: **12 -> 24**.

Added ARM resource types:

- `Microsoft.RecoveryServices/vaults/backupCrossTenantVaultMappings/backupFabrics/protectionContainers/protectedItems`: `ProtectedItemFromCrossTenantVault`
- `Microsoft.RecoveryServices/vaults/backupCrossTenantVaultMappings/backupFabrics/protectionContainers/protectedItems/operationResults`: `ProtectedItemOperationResultsFromCrossTenantVault`
- `Microsoft.RecoveryServices/vaults/backupCrossTenantVaultMappings/backupFabrics/protectionContainers/protectedItems/recoveryPoints`: `CrossTenantVaultRecoveryPoints`
- `Microsoft.RecoveryServices/vaults/backupCrossTenantVaultMappings/backupJobs`: `BackupJobsFromCrossTenantVault`
- `Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/operationResults`: `ProtectionContainersOperationResults`
- `Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/operationResults`: `ProtectedItemsOperationResults`
- `Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/operationsStatus`: `ProtectedItemsOperationsStatus`
- `Microsoft.RecoveryServices/vaults/backupJobs/operationResults`: `BackupJobsOperationResults`
- `Microsoft.RecoveryServices/vaults/backupPolicies/operationResults`: `BackupPoliciesOperationResults`
- `Microsoft.RecoveryServices/vaults/backupstorageconfig/operationResults`: `BackupstorageconfigOperationResults`
- `Microsoft.RecoveryServices/vaults/backupstorageconfig/operationStatus`: `BackupstorageconfigOperationStatus`
- `Microsoft.RecoveryServices/vaults/privateEndpointConnections/operationsStatus`: `PrivateEndpointConnectionsOperationsStatus`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.RecoveryServices/vaults/backupEncryptionConfigs` | BackupResourceEncryptionConfigExtended | BackupResourceEncryptionConfigExtendedResource |
| `Microsoft.RecoveryServices/vaults/backupEngines` | BackupEngine | BackupEngineBaseResource |
| `Microsoft.RecoveryServices/vaults/backupFabrics/backupProtectionIntent` | BackupProtectionIntent | ProtectionIntentResource |
| `Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers` | BackupProtectionContainer | ProtectionContainerResource |
| `Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems` | BackupProtectedItem | ProtectedItemResource |
| `Microsoft.RecoveryServices/vaults/backupFabrics/protectionContainers/protectedItems/recoveryPoints` | BackupRecoveryPoint | RecoveryPointResource |
| `Microsoft.RecoveryServices/vaults/backupJobs` | BackupJob | JobResource |
| `Microsoft.RecoveryServices/vaults/backupPolicies` | BackupProtectionPolicy | ProtectionPolicyResource |
| `Microsoft.RecoveryServices/vaults/backupResourceGuardProxies` | ResourceGuardProxy | ResourceGuardProxyBaseResource |
| `Microsoft.RecoveryServices/vaults/backupconfig` | BackupResourceVaultConfig | BackupResourceVaultConfigResource |
| `Microsoft.RecoveryServices/vaults/backupstorageconfig` | BackupResourceConfig | BackupResourceConfigResource |
| `Microsoft.RecoveryServices/vaults/privateEndpointConnections` | BackupPrivateEndpointConnection | PrivateEndpointConnectionResource |

## Azure.Provisioning.Redis

Package: `sdk/redis/Azure.Provisioning.Redis`. Distinct ARM resource types: **7 -> 7**.

Resource identities and class names are unchanged.

## Azure.Provisioning.RedisEnterprise

Package: `sdk/redisenterprise/Azure.Provisioning.RedisEnterprise`. Distinct ARM resource types: **5 -> 5**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Cache/redisEnterprise/migrations` | RedisEnterpriseMigration | Migration |

## Azure.Provisioning.ResourceGraph

Package: `sdk/resourcegraph/Azure.Provisioning.ResourceGraph`. Distinct ARM resource types: **1 -> 1**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.ResourceGraph/queries` | ResourceGraphQuery | GraphQueryResource |

## Azure.Provisioning.ResourceHealth

Package: `sdk/resourcehealth/Azure.Provisioning.ResourceHealth`. Distinct ARM resource types: **4 -> 4**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.ResourceHealth/emergingIssues` | ServiceEmergingIssue | EmergingIssuesGetResult |

## Azure.Provisioning.Search

Package: `sdk/search/Azure.Provisioning.Search`. Distinct ARM resource types: **4 -> 4**.

Resource identities and class names are unchanged.

## Azure.Provisioning.SecurityCenter

Package: `sdk/securitycenter/Azure.Provisioning.SecurityCenter`. Distinct ARM resource types: **63 -> 61**.

Removed ARM resource types:

- `Microsoft.Security/locations`: `SecurityCenterLocation`
- `Microsoft.Security/mdeOnboardings`: `MdeOnboarding`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Security/alertsSuppressionRules` | SecurityAlertsSuppressionRule | AlertsSuppressionRule |
| `Microsoft.Security/apiCollections` | ApiCollection | ExternalResourceApiCollection |
| `Microsoft.Security/assessments` | SecurityAssessment | SecurityAssessmentResponsesScopeParameterSecurityAssessmentResponse |
| `Microsoft.Security/assignments` | SecurityCenterAssignment | Assignment |
| `Microsoft.Security/automations` | SecurityAutomation | Automation |
| `Microsoft.Security/compliances` | SecurityCompliance | Compliance |
| `Microsoft.Security/iotSecuritySolutions` | IotSecuritySolution | IoTSecuritySolutionModel |
| `Microsoft.Security/iotSecuritySolutions/analyticsModels` | IotSecuritySolutionAnalyticsModel | IoTSecuritySolutionAnalyticsModel |
| `Microsoft.Security/iotSecuritySolutions/analyticsModels/aggregatedAlerts` | IotSecurityAggregatedAlert | IoTSecurityAggregatedAlert |
| `Microsoft.Security/iotSecuritySolutions/analyticsModels/aggregatedRecommendations` | IotSecurityAggregatedRecommendation | IoTSecurityAggregatedRecommendation |
| `Microsoft.Security/locations/alerts` | SecurityAlert | LocationsAlerts |
| `Microsoft.Security/locations/allowedConnections` | SecurityCenterAllowedConnection | AllowedConnectionsResource |
| `Microsoft.Security/locations/tasks` | SecurityTask | LocationsTasks |
| `Microsoft.Security/locations/topologies` | SecurityTopology | TopologyResource |
| `Microsoft.Security/pricings` | SecurityCenterPricing | Pricing |
| `Microsoft.Security/pricings/securityOperators` | SecurityOperator | PricingsSecurityOperators |
| `Microsoft.Security/privateLinks` | SecurityCenterPrivateLinkResource | PrivateLinkResource |
| `Microsoft.Security/privateLinks/privateEndpointConnections` | SecurityCenterPrivateEndpointConnection | SecurityCenterPrivateLinkResourcePrivateEndpointConnection |
| `Microsoft.Security/privateLinks/privateLinkResources` | PrivateLinkGroup | PrivateLinkGroupResource |
| `Microsoft.Security/secureScores` | SecureScore | SecureScoreItem |
| `Microsoft.Security/securityConnectors/devops` | DevOpsConfiguration | SecurityConnectorsDevops |
| `Microsoft.Security/securityConnectors/devops/azureDevOpsOrgs` | AzureDevOpsOrg | DevopsAzureDevOpsOrgs |
| `Microsoft.Security/securityConnectors/devops/azureDevOpsOrgs/projects` | AzureDevOpsProject | AzureDevOpsOrgsProjects |
| `Microsoft.Security/securityConnectors/devops/azureDevOpsOrgs/projects/repos` | AzureDevOpsRepository | ProjectsRepos |
| `Microsoft.Security/securityConnectors/devops/gitHubOwners` | GitHubOwner | DevopsGitHubOwners |
| `Microsoft.Security/securityConnectors/devops/gitHubOwners/repos` | GitHubRepository | GitHubOwnersRepos |
| `Microsoft.Security/securityConnectors/devops/gitLabGroups` | GitLabGroup | DevopsGitLabGroups |
| `Microsoft.Security/securityConnectors/devops/gitLabGroups/projects` | GitLabProject | GitLabGroupsProjects |
| `Microsoft.Security/sensitivitySettings` | SensitivitySetting | GetSensitivitySettingsResponse |
| `Microsoft.Security/settings` | SecuritySetting | Setting |
| `Microsoft.Security/sqlVulnerabilityAssessments/baselineRules` | SqlVulnerabilityAssessmentBaselineRule | RuleResults |
| `Microsoft.Security/sqlVulnerabilityAssessments/scans` | SqlVulnerabilityAssessmentScan | ScanV2 |
| `Microsoft.Security/sqlVulnerabilityAssessments/scans/scanResults` | SqlVulnerabilityAssessmentScanResult | ScanResult |
| `Microsoft.Security/standardAssignments` | StandardAssignment | ResourceIdScopeParameterStandardAssignment |
| `Microsoft.Security/standards` | SecurityCenterStandard | Standard |
| `Microsoft.Security/workspaceSettings` | SecurityWorkspaceSetting | WorkspaceSetting |

## Azure.Provisioning.ServiceBus

Package: `sdk/servicebus/Azure.Provisioning.ServiceBus`. Distinct ARM resource types: **14 -> 14**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.ServiceBus/namespaces/networkSecurityPerimeterConfigurations` | ServiceBusNetworkSecurityPerimeterConfiguration | NetworkSecurityPerimeterConfiguration |

## Azure.Provisioning.ServiceFabric

Package: `sdk/servicefabric/Azure.Provisioning.ServiceFabric`. Distinct ARM resource types: **6 -> 6**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.ServiceFabric/clusters` | ServiceFabricCluster | Cluster |
| `Microsoft.ServiceFabric/clusters/applicationTypes` | ServiceFabricApplicationType | ApplicationTypeResource |
| `Microsoft.ServiceFabric/clusters/applicationTypes/versions` | ServiceFabricApplicationTypeVersion | ApplicationTypeVersionResource |
| `Microsoft.ServiceFabric/clusters/applications` | ServiceFabricApplication | ApplicationResource |
| `Microsoft.ServiceFabric/clusters/applications/services` | ServiceFabricService | ServiceResource |
| `Microsoft.ServiceFabric/locations/unsupportedVmSizes` | ServiceFabricVmSizeResource | LocationsUnsupportedVmSizes |

## Azure.Provisioning.ServiceFabricManagedClusters

Package: `sdk/servicefabricmanagedclusters/Azure.Provisioning.ServiceFabricManagedClusters`. Distinct ARM resource types: **6 -> 6**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.ServiceFabric/managedClusters` | ServiceFabricManagedCluster | ManagedCluster |
| `Microsoft.ServiceFabric/managedClusters/applicationTypes` | ServiceFabricManagedApplicationType | ApplicationTypeResource |
| `Microsoft.ServiceFabric/managedClusters/applicationTypes/versions` | ServiceFabricManagedApplicationTypeVersion | ApplicationTypeVersionResource |
| `Microsoft.ServiceFabric/managedClusters/applications` | ServiceFabricManagedApplication | ApplicationResource |
| `Microsoft.ServiceFabric/managedClusters/applications/services` | ServiceFabricManagedService | ServiceResource |
| `Microsoft.ServiceFabric/managedClusters/nodeTypes` | ServiceFabricManagedNodeType | NodeType |

## Azure.Provisioning.ServiceNetworking

Package: `sdk/servicenetworking/Azure.Provisioning.ServiceNetworking`. Distinct ARM resource types: **4 -> 4**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.ServiceNetworking/trafficControllers/associations` | TrafficControllerAssociation | Association |
| `Microsoft.ServiceNetworking/trafficControllers/frontends` | TrafficControllerFrontend | Frontend |
| `Microsoft.ServiceNetworking/trafficControllers/securityPolicies` | ApplicationGatewayForContainersSecurityPolicy | SecurityPolicy |

## Azure.Provisioning.SignalR

Package: `sdk/signalr/Azure.Provisioning.SignalR`. Distinct ARM resource types: **7 -> 7**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.SignalRService/signalR/replicas` | SignalRReplica | Replica |
| `Microsoft.SignalRService/signalR/replicas/sharedPrivateLinkResources` | SignalRReplicaSharedPrivateLinkResource | SignalRSharedPrivateLink |
| `Microsoft.SignalRService/signalR/sharedPrivateLinkResources` | SignalRSharedPrivateLink | SignalRSharedPrivateLinkResources |

## Azure.Provisioning.Sql

Package: `sdk/sqlmanagement/Azure.Provisioning.Sql`. Distinct ARM resource types: **122 -> 120**.

Added ARM resource types:

- `Microsoft.Sql/servers/databases/extensions`: `ImportExportExtensionsOperationResult`

Removed ARM resource types:

- `Microsoft.Sql/managedInstances/distributedAvailabilityGroups`: `SqlDistributedAvailabilityGroup`
- `Microsoft.Sql/servers/firewallRules`: `SqlFirewallRule`
- `Microsoft.Sql/servers/ipv6FirewallRules`: `IPv6FirewallRule`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Sql/instancePools/operations` | SqlInstancePoolOperation | InstancePoolOperation |
| `Microsoft.Sql/locations/deletedServers` | DeletedServer | LocationsDeletedServers |
| `Microsoft.Sql/locations/timeZones` | SqlTimeZone | LocationsTimeZones |
| `Microsoft.Sql/locations/usages` | SubscriptionUsage | LocationsUsages |
| `Microsoft.Sql/managedInstances/databases/restoreDetails` | ManagedDatabaseRestoreDetail | ManagedDatabaseRestoreDetailsResult |
| `Microsoft.Sql/servers/automaticTuning` | SqlServerAutomaticTuning | ServerAutomaticTuning |
| `Microsoft.Sql/servers/databases/automaticTuning` | SqlDatabaseAutomaticTuning | DatabaseAutomaticTuning |
| `Microsoft.Sql/servers/databases/dataWarehouseUserActivities` | DataWarehouseUserActivity | DataWarehouseUserActivities |
| `Microsoft.Sql/servers/databases/maintenanceWindowOptions` | MaintenanceWindowOption | MaintenanceWindowOptions |
| `Microsoft.Sql/servers/jobAgents/jobs/versions` | SqlServerJobVersion | JobsVersions |
| `Microsoft.Sql/servers/networkSecurityPerimeterConfigurations` | SqlNetworkSecurityPerimeterConfiguration | NetworkSecurityPerimeterConfiguration |
| `Microsoft.Sql/servers/privateLinkResources` | SqlPrivateLinkResource | PrivateLinkResource |

## Azure.Provisioning.StandbyPool

Package: `sdk/standbypool/Azure.Provisioning.StandbyPool`. Distinct ARM resource types: **5 -> 5**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.StandbyPool/standbyContainerGroupPools` | StandbyContainerGroupPool | StandbyContainerGroupPoolResource |
| `Microsoft.StandbyPool/standbyContainerGroupPools/runtimeViews` | StandbyContainerGroupPoolRuntimeView | StandbyContainerGroupPoolRuntimeViewResource |
| `Microsoft.StandbyPool/standbyVirtualMachinePools` | StandbyVirtualMachinePool | StandbyVirtualMachinePoolResource |
| `Microsoft.StandbyPool/standbyVirtualMachinePools/runtimeViews` | StandbyVirtualMachinePoolRuntimeView | StandbyVirtualMachinePoolRuntimeViewResource |
| `Microsoft.StandbyPool/standbyVirtualMachinePools/standbyVirtualMachines` | StandbyVirtualMachine | StandbyVirtualMachineResource |

## Azure.Provisioning.Storage

Package: `sdk/storage/Azure.Provisioning.Storage`. Distinct ARM resource types: **21 -> 21**.

Resource identities and class names are unchanged.

## Azure.Provisioning.Subscription

Package: `sdk/subscription/Azure.Provisioning.Subscription`. Distinct ARM resource types: **3 -> 3**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Subscription/aliases` | SubscriptionAlias | SubscriptionAliasResponse |
| `Microsoft.Subscription/policies` | BillingAccountPolicy, TenantPolicy | ExternalResourceBillingAccountPoliciesResponse, GetTenantPolicyResponse |

Multiple class names share these ARM resource types; all names are retained in the comparison rather than overwritten:

- `Microsoft.Subscription/policies`

## Azure.Provisioning.TrafficManager

Package: `sdk/trafficmanager/Azure.Provisioning.TrafficManager`. Distinct ARM resource types: **7 -> 0**.

Removed ARM resource types:

- `Microsoft.Network/trafficManagerGeographicHierarchies`: `TrafficManagerGeographicHierarchy`
- `Microsoft.Network/trafficManagerUserMetricsKeys`: `TrafficManagerUserMetrics`
- `Microsoft.Network/trafficmanagerprofiles`: `TrafficManagerProfile`
- `Microsoft.Network/trafficmanagerprofiles/AzureEndpoints`: `AzureEndpointTrafficManagerEndpoint`
- `Microsoft.Network/trafficmanagerprofiles/ExternalEndpoints`: `ExternalEndpointTrafficManagerEndpoint`
- `Microsoft.Network/trafficmanagerprofiles/NestedEndpoints`: `NestedEndpointTrafficManagerEndpoint`
- `Microsoft.Network/trafficmanagerprofiles/heatMaps`: `TrafficManagerHeatMap`

## Azure.Provisioning.VerifiedId

Package: `sdk/verifiedid/Azure.Provisioning.VerifiedId`. Distinct ARM resource types: **1 -> 1**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.VerifiedId/authorities` | VerifiedIdAuthority | Authority |

## Azure.Provisioning.WebPubSub

Package: `sdk/webpubsub/Azure.Provisioning.WebPubSub`. Distinct ARM resource types: **8 -> 8**.

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.SignalRService/webPubSub/customCertificates` | WebPubSubCustomCertificate | CustomCertificate |
| `Microsoft.SignalRService/webPubSub/customDomains` | WebPubSubCustomDomain | CustomDomain |
| `Microsoft.SignalRService/webPubSub/replicas` | WebPubSubReplica | Replica |

## Azure.Provisioning.AppService

Package: `sdk/websites/Azure.Provisioning.AppService`. Distinct ARM resource types: **127 -> 128**.

Added ARM resource types:

- `Microsoft.Web/serverfarms/virtualNetworkConnections/routes`: `AppServiceVirtualNetworkRoute`

Changed class names for unchanged ARM resource types:

| ARM resource type | Main class names | Validation class names |
| --- | --- | --- |
| `Microsoft.Web/hostingEnvironments/capacities` | AppServiceEnvironmentAddress | AddressResponse |
| `Microsoft.Web/serverfarms/hybridConnectionPlanLimits` | HybridConnectionLimit | HybridConnectionLimits |
| `Microsoft.Web/sites/config` | LogsSiteConfig, SlotConfigNames, WebSiteAuthSettingsV2, WebSiteConfig | LogsSiteConfig, SlotConfigNames, WebSiteConfig |
| `Microsoft.Web/staticSites/builds` | StaticSiteBuild | StaticSiteBuildARMResource |

Multiple class names share these ARM resource types; all names are retained in the comparison rather than overwritten:

- `Microsoft.Web/hostingEnvironments/configurations`
- `Microsoft.Web/sites/config`
- `Microsoft.Web/sites/slots/config`
