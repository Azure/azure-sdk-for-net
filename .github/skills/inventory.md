# Copilot Skills Inventory

This document lists all available Copilot skills in the Azure SDK for .NET repository.

## MPG Migration Status

**98 management-plane packages** have been migrated to TypeSpec (MPG) on `main`:

<details>
<summary>Click to expand full list</summary>

| Service Directory | Package |
|---|---|
| advisor | Azure.ResourceManager.Advisor |
| agricultureplatform | Azure.ResourceManager.AgriculturePlatform |
| appcomplianceautomation | Azure.ResourceManager.AppComplianceAutomation |
| appconfiguration | Azure.ResourceManager.AppConfiguration |
| arizeaiobservabilityeval | Azure.ResourceManager.ArizeAIObservabilityEval |
| artifactsigning | Azure.ResourceManager.ArtifactSigning |
| astronomer | Azure.ResourceManager.Astro |
| attestation | Azure.ResourceManager.Attestation |
| avs | Azure.ResourceManager.Avs |
| azurelargeinstance | Azure.ResourceManager.LargeInstance |
| azurestackhci | Azure.ResourceManager.Hci.Vm |
| carbon | Azure.ResourceManager.CarbonOptimization |
| certificateregistration | Azure.ResourceManager.CertificateRegistration |
| chaos | Azure.ResourceManager.Chaos |
| cloudhealth | Azure.ResourceManager.CloudHealth |
| computefleet | Azure.ResourceManager.ComputeFleet |
| computelimit | Azure.ResourceManager.ComputeLimit |
| computerecommender | Azure.ResourceManager.Compute.Recommender |
| computeschedule | Azure.ResourceManager.ComputeSchedule |
| connectedcache | Azure.ResourceManager.ConnectedCache |
| containerorchestratorruntime | Azure.ResourceManager.ContainerOrchestratorRuntime |
| databasewatcher | Azure.ResourceManager.DatabaseWatcher |
| databox | Azure.ResourceManager.DataBox |
| dellstorage | Azure.ResourceManager.Dell.Storage |
| dependencymap | Azure.ResourceManager.DependencyMap |
| desktopvirtualization | Azure.ResourceManager.DesktopVirtualization |
| deviceprovisioningservices | Azure.ResourceManager.DeviceProvisioningServices |
| deviceregistry | Azure.ResourceManager.DeviceRegistry |
| devopsinfrastructure | Azure.ResourceManager.DevOpsInfrastructure |
| devtestlabs | Azure.ResourceManager.DevTestLabs |
| disconnectedoperations | Azure.ResourceManager.DisconnectedOperations |
| durabletask | Azure.ResourceManager.DurableTask |
| dynatrace | Azure.ResourceManager.Dynatrace |
| edgeactions | Azure.ResourceManager.EdgeActions |
| edgeorder | Azure.ResourceManager.EdgeOrder |
| edgezones | Azure.ResourceManager.EdgeZones |
| elastic | Azure.ResourceManager.Elastic |
| elasticsan | Azure.ResourceManager.ElasticSan |
| fabric | Azure.ResourceManager.Fabric |
| fileshares | Azure.ResourceManager.FileShares |
| fleet | Azure.ResourceManager.ContainerServiceFleet |
| grafana | Azure.ResourceManager.Grafana |
| guestconfiguration | Azure.ResourceManager.GuestConfiguration |
| hardwaresecuritymodules | Azure.ResourceManager.HardwareSecurityModules |
| healthbot | Azure.ResourceManager.HealthBot |
| healthdataaiservices | Azure.ResourceManager.HealthDataAIServices |
| hybridconnectivity | Azure.ResourceManager.HybridConnectivity |
| hybridkubernetes | Azure.ResourceManager.Kubernetes |
| impactreporting | Azure.ResourceManager.ImpactReporting |
| informaticadatamanagement | Azure.ResourceManager.InformaticaDataManagement |
| iotoperations | Azure.ResourceManager.IotOperations |
| keyvault | Azure.ResourceManager.KeyVault |
| lambdatesthyperexecute | Azure.ResourceManager.LambdaTestHyperExecute |
| loadtestservice | Azure.ResourceManager.LoadTesting |
| managedops | Azure.ResourceManager.ManagedOps |
| mongocluster | Azure.ResourceManager.MongoCluster |
| mongodbatlas | Azure.ResourceManager.MongoDBAtlas |
| mysql | Azure.ResourceManager.MySql |
| neonpostgres | Azure.ResourceManager.NeonPostgres |
| nginx | Azure.ResourceManager.Nginx |
| onlineexperimentation | Azure.ResourceManager.OnlineExperimentation |
| oracle | Azure.ResourceManager.OracleDatabase |
| paloaltonetworks.ngfw | Azure.ResourceManager.PaloAltoNetworks.Ngfw |
| peering | Azure.ResourceManager.Peering |
| pineconevectordb | Azure.ResourceManager.PineconeVectorDB |
| planetarycomputer | Azure.ResourceManager.PlanetaryComputer |
| playwright | Azure.ResourceManager.Playwright |
| portalservices | Azure.ResourceManager.PortalServicesCopilot |
| powerbidedicated | Azure.ResourceManager.PowerBIDedicated |
| purestorageblock | Azure.ResourceManager.PureStorageBlock |
| quantum | Azure.ResourceManager.Quantum |
| qumulo | Azure.ResourceManager.Qumulo |
| quota | Azure.ResourceManager.Quota |
| recoveryservices | Azure.ResourceManager.RecoveryServices |
| recoveryservices-datareplication | Azure.ResourceManager.RecoveryServicesDataReplication |
| resourceconnector | Azure.ResourceManager.ResourceConnector |
| resources | Azure.ResourceManager.Resources.Bicep |
| resources | Azure.ResourceManager.Resources.DeploymentStacks |
| secretsstoreextension | Azure.ResourceManager.SecretsStoreExtension |
| selfhelp | Azure.ResourceManager.SelfHelp |
| servicefabricmanagedclusters | Azure.ResourceManager.ServiceFabricManagedClusters |
| servicenetworking | Azure.ResourceManager.ServiceNetworking |
| signalr | Azure.ResourceManager.SignalR |
| sitemanager | Azure.ResourceManager.SiteManager |
| sphere | Azure.ResourceManager.Sphere |
| sqlvirtualmachine | Azure.ResourceManager.SqlVirtualMachine |
| standbypool | Azure.ResourceManager.StandbyPool |
| storageactions | Azure.ResourceManager.StorageActions |
| storagediscovery | Azure.ResourceManager.StorageDiscovery |
| storagemover | Azure.ResourceManager.StorageMover |
| storagesync | Azure.ResourceManager.StorageSync |
| terraform | Azure.ResourceManager.Terraform |
| trafficmanager | Azure.ResourceManager.TrafficManager |
| trustedsigning | Azure.ResourceManager.TrustedSigning |
| virtualenclaves | Azure.ResourceManager.VirtualEnclaves |
| weightsandbiases | Azure.ResourceManager.WeightsAndBiases |
| workloadorchestration | Azure.ResourceManager.WorkloadOrchestration |
| workloadssapvirtualinstance | Azure.ResourceManager.WorkloadsSapVirtualInstance |

</details>

To regenerate this list, run:
```powershell
Get-ChildItem -Recurse -Path "sdk" -Filter "tsp-location.yaml" | ForEach-Object {
    $content = Get-Content $_.FullName -Raw
    if ($content -match "http-client-csharp-mgmt") {
        $rel = $_.FullName -replace [regex]::Escape((Get-Location).Path + "\"), ""
        $parts = $rel -split "[/\\]"; "$($parts[1]) | $($parts[2])"
    }
} | Sort-Object
```

## PR Review & CI

| Skill | Description |
|---|---|
| [azure-sdk-mgmt-pr-review](azure-sdk-mgmt-pr-review/SKILL.md) | Review Azure SDK management-plane pull requests, check naming conventions, API compatibility, and code quality. |
| [mpg-migration-pr-review](mpg-migration-pr-review/SKILL.md) | Review Azure SDK management-plane migration PRs (Swagger/AutoRest → TypeSpec). Checks customization quality, TypeSpec decorator usage, and migration-specific anti-patterns on top of the standard mgmt PR review. |
| [mgmt-review-comment-resolution](mgmt-review-comment-resolution/SKILL.md) | Resolve review comments on Azure management-plane .NET SDK PRs. Handles renaming types/properties, changing property types, and other API surface adjustments by updating TypeSpec client.tsp and regenerating. |
| [analyze-ci-failures](analyze-ci-failures/SKILL.md) | Analyze CI failures on Azure SDK for .NET pull requests and post a comment with how-to-fix instructions. Use when a PR has failing checks, CI is red, or someone asks for help fixing CI. |
| [pre-commit-checks](pre-commit-checks/SKILL.md) | Pre-commit validation checks for azure-sdk-for-net. Runs dotnet format, exports public API listings, updates snippets, and regenerates code as needed. |

## Migration & Breaking Changes

| Skill | Description |
|---|---|
| [mpg-sdk-migration](mpg-sdk-migration/SKILL.md) | Migrate an Azure management-plane .NET SDK from Swagger/AutoRest to TypeSpec-based generation. Use when asked to migrate a service, do MPG migration, update spec, or bring SDK to latest TypeSpec. |
| [mitigate-breaking-changes](mitigate-breaking-changes/SKILL.md) | Patterns and techniques for mitigating breaking changes during Azure management-plane SDK migration from Swagger/AutoRest to TypeSpec. Covers SDK-side customizations (partial classes, CodeGenType, CodeGenSuppress) and TypeSpec decorator customizations (clientName, access, markAsPageable, alternateType). |

## Code Generation & Testing

| Skill | Description |
|---|---|
| [bump-mgmt-base-version](bump-mgmt-base-version/SKILL.md) | Bump the http-client-csharp base dependency version in http-client-csharp-mgmt. Updates emitter (npm) and generator (NuGet) references, rebuilds, and regenerates test projects. |
| [csharp-azure-spector-coverage-gaps](csharp-azure-spector-coverage-gaps/SKILL.md) | Discovers and implements gaps in Spector test coverage for the Azure C# HTTP client emitter. Use when asked to find missing Spector scenarios, add Spector test coverage, or implement a specific Spector spec for the Azure C# emitter. |
| [provisioning-library-regeneration](provisioning-library-regeneration/SKILL.md) | Regenerate Azure.Provisioning.* libraries to add new resources or features. Use when adding new resource types, enum values, or API versions to provisioning libraries. |
