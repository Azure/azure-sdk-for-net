# ARM resource shape comparison summary

This summary compares only resource-shape fields from the current filtered snapshots: resource ID, ARM resource type, parent, scope, Read lifecycle operations, and Create lifecycle operations. Other operations and metadata are intentionally ignored.

Resource rows are matched by normalized resource ID, where path parameter names are ignored. Exact resource-ID differences are still counted separately.

## Overall

| Metric | Count |
| --- | ---: |
| Libraries processed | 217 |
| Libraries with no resource-shape differences | 155 |
| Libraries with resource-shape differences | 62 |
| Legacy resources | 2247 |
| resolveArmResources resources | 2113 |
| Matching normalized resource IDs | 2039 |
| Legacy-only normalized resource IDs | 208 |
| resolveArmResources-only normalized resource IDs | 73 |
| Exact resource ID differences on matched resources | 18 |
| ARM resource type differences | 0 |
| Parent differences | 47 |
| Scope differences | 40 |
| Read lifecycle differences | 18 |
| Create lifecycle differences | 57 |

## Per-library summary

| Library | Legacy resources | resolveArmResources resources | Legacy-only IDs | resolve-only IDs | Resource ID diffs | Type diffs | Parent diffs | Scope diffs | Read diffs | Create diffs | Report |
| --- | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: | --- |
| `Azure.ResourceManager.Advisor` | 8 | 8 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 0 | [report](sdk/advisor/Azure.ResourceManager.Advisor/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AgriculturePlatform` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/agricultureplatform/Azure.ResourceManager.AgriculturePlatform/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AlertProcessingRules` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.AlertProcessingRules/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AlertRuleRecommendations` | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.AlertRuleRecommendations/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AlertsManagement` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.AlertsManagement/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ApiCenter` | 10 | 10 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/apicenter/Azure.ResourceManager.ApiCenter/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ApiManagement` | 102 | 102 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 7 | [report](sdk/apimanagement/Azure.ResourceManager.ApiManagement/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AppComplianceAutomation` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/appcomplianceautomation/Azure.ResourceManager.AppComplianceAutomation/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AppConfiguration` | 7 | 6 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/appconfiguration/Azure.ResourceManager.AppConfiguration/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AppContainers` | 41 | 41 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 2 | [report](sdk/containerapps/Azure.ResourceManager.AppContainers/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ApplicationInsights` | 6 | 4 | 2 | 0 | 0 | 0 | 1 | 0 | 0 | 0 | [report](sdk/applicationinsights/Azure.ResourceManager.ApplicationInsights/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AppNetwork` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/appnetwork/Azure.ResourceManager.AppNetwork/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AppService` | 136 | 137 | 0 | 1 | 0 | 0 | 4 | 0 | 0 | 1 | [report](sdk/websites/Azure.ResourceManager.AppService/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ArizeAIObservabilityEval` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/arizeaiobservabilityeval/Azure.ResourceManager.ArizeAIObservabilityEval/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ArtifactSigning` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/artifactsigning/Azure.ResourceManager.ArtifactSigning/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Astro` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/astronomer/Azure.ResourceManager.Astro/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Attestation` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/attestation/Azure.ResourceManager.Attestation/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Authorization` | 27 | 28 | 1 | 1 | 0 | 0 | 2 | 3 | 0 | 0 | [report](sdk/authorization/Azure.ResourceManager.Authorization/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Automation` | 25 | 33 | 0 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/automation/Azure.ResourceManager.Automation/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Avs` | 29 | 29 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/avs/Azure.ResourceManager.Avs/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Batch` | 8 | 8 | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/batch/Azure.ResourceManager.Batch/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Billing` | 46 | 46 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 0 | [report](sdk/billing/Azure.ResourceManager.Billing/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Billing.Trust` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/billingtrust/Azure.ResourceManager.Billing.Trust/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.BillingBenefits` | 12 | 12 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/billingbenefits/Azure.ResourceManager.BillingBenefits/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.BotService` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/botservice/Azure.ResourceManager.BotService/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.CarbonOptimization` | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/carbon/Azure.ResourceManager.CarbonOptimization/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Cdn` | 20 | 20 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/cdn/Azure.ResourceManager.Cdn/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.CertificateRegistration` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/certificateregistration/Azure.ResourceManager.CertificateRegistration/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Chaos` | 15 | 15 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/chaos/Azure.ResourceManager.Chaos/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.CloudHealth` | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/cloudhealth/Azure.ResourceManager.CloudHealth/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.CognitiveServices` | 31 | 31 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/cognitiveservices/Azure.ResourceManager.CognitiveServices/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Communication` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/communication/Azure.ResourceManager.Communication/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Compute` | 37 | 35 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/compute/Azure.ResourceManager.Compute/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Compute.BulkActions` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/compute/Azure.ResourceManager.Compute.BulkActions/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Compute.Recommender` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/computerecommender/Azure.ResourceManager.Compute.Recommender/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ComputeBulkActions` | 1 | 2 | 0 | 1 | 0 | 0 | 0 | 1 | 0 | 0 | [report](sdk/computebulkactions/Azure.ResourceManager.ComputeBulkActions/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ComputeFleet` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/computefleet/Azure.ResourceManager.ComputeFleet/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ComputeLimit` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/computelimit/Azure.ResourceManager.ComputeLimit/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ComputeSchedule` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/computeschedule/Azure.ResourceManager.ComputeSchedule/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ConfidentialLedger` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/confidentialledger/Azure.ResourceManager.ConfidentialLedger/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Confluent` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 5 | [report](sdk/confluent/Azure.ResourceManager.Confluent/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ConnectedCache` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/connectedcache/Azure.ResourceManager.ConnectedCache/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Consumption` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/consumption/Azure.ResourceManager.Consumption/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ContainerInstance` | 4 | 3 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/containerinstance/Azure.ResourceManager.ContainerInstance/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ContainerOrchestratorRuntime` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/containerorchestratorruntime/Azure.ResourceManager.ContainerOrchestratorRuntime/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ContainerRegistry` | 15 | 15 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 0 | [report](sdk/containerregistry/Azure.ResourceManager.ContainerRegistry/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ContainerRegistry.Tasks` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/containerregistry/Azure.ResourceManager.ContainerRegistry.Tasks/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ContainerService` | 21 | 21 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/containerservice/Azure.ResourceManager.ContainerService/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ContainerServiceFleet` | 8 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/fleet/Azure.ResourceManager.ContainerServiceFleet/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ContainerServicePreparedImgSpec` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/containerservicepreparedimgspec/Azure.ResourceManager.ContainerServicePreparedImgSpec/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ContainerServiceSafeguards` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/containerservicesafeguards/Azure.ResourceManager.ContainerServiceSafeguards/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.CosmosDB` | 46 | 49 | 0 | 3 | 0 | 0 | 0 | 0 | 0 | 2 | [report](sdk/cosmosdb/Azure.ResourceManager.CosmosDB/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.CosmosDBForPostgreSql` | 9 | 9 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/cosmosdbforpostgresql/Azure.ResourceManager.CosmosDBForPostgreSql/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.CostManagement` | 11 | 11 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/costmanagement/Azure.ResourceManager.CostManagement/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DatabaseWatcher` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/databasewatcher/Azure.ResourceManager.DatabaseWatcher/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DataBox` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/databox/Azure.ResourceManager.DataBox/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DataBoxEdge` | 19 | 20 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/databoxedge/Azure.ResourceManager.DataBoxEdge/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Databricks` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/databricks/Azure.ResourceManager.Databricks/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Datadog` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 2 | [report](sdk/datadog/Azure.ResourceManager.Datadog/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DataFactory` | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/datafactory/Azure.ResourceManager.DataFactory/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DataMigration` | 12 | 12 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/datamigration/Azure.ResourceManager.DataMigration/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DataProtectionBackup` | 9 | 12 | 0 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/dataprotection/Azure.ResourceManager.DataProtectionBackup/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Dell.Storage` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/dellstorage/Azure.ResourceManager.Dell.Storage/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DependencyMap` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/dependencymap/Azure.ResourceManager.DependencyMap/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DesktopVirtualization` | 17 | 17 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/desktopvirtualization/Azure.ResourceManager.DesktopVirtualization/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DevCenter` | 29 | 29 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/devcenter/Azure.ResourceManager.DevCenter/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DevHub` | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/developerhub/Azure.ResourceManager.DevHub/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DeviceProvisioningServices` | 4 | 5 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/deviceprovisioningservices/Azure.ResourceManager.DeviceProvisioningServices/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DeviceRegistry` | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/deviceregistry/Azure.ResourceManager.DeviceRegistry/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DevOpsInfrastructure` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/devopsinfrastructure/Azure.ResourceManager.DevOpsInfrastructure/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DevTestLabs` | 21 | 21 | 0 | 0 | 15 | 0 | 19 | 0 | 15 | 13 | [report](sdk/devtestlabs/Azure.ResourceManager.DevTestLabs/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DisconnectedOperations` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/disconnectedoperations/Azure.ResourceManager.DisconnectedOperations/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Discovery` | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/discovery/Azure.ResourceManager.Discovery/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Dns` | 15 | 2 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/dns/Azure.ResourceManager.Dns/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DnsResolver` | 10 | 10 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/dnsresolver/Azure.ResourceManager.DnsResolver/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DomainRegistration` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/domainregistration/Azure.ResourceManager.DomainRegistration/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DomainServices` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/domainservices/Azure.ResourceManager.DomainServices/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DurableTask` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/durabletask/Azure.ResourceManager.DurableTask/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Dynatrace` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/dynatrace/Azure.ResourceManager.Dynatrace/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.EdgeActions` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/edgeactions/Azure.ResourceManager.EdgeActions/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.EdgeOrder` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/edgeorder/Azure.ResourceManager.EdgeOrder/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.EdgeZones` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/edgezones/Azure.ResourceManager.EdgeZones/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Education` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/education/Azure.ResourceManager.Education/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Elastic` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 4 | [report](sdk/elastic/Azure.ResourceManager.Elastic/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ElasticSan` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/elasticsan/Azure.ResourceManager.ElasticSan/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Enclave` | 9 | 9 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/enclave/Azure.ResourceManager.Enclave/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.EventGrid` | 32 | 27 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/eventgrid/Azure.ResourceManager.EventGrid/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.EventHubs` | 13 | 11 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/eventhub/Azure.ResourceManager.EventHubs/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ExtendedLocations` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/extendedlocation/Azure.ResourceManager.ExtendedLocations/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Fabric` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/fabric/Azure.ResourceManager.Fabric/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.FileShares` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/fileshares/Azure.ResourceManager.FileShares/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.FrontDoor` | 6 | 0 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/frontdoor/Azure.ResourceManager.FrontDoor/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Grafana` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/grafana/Azure.ResourceManager.Grafana/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.GuestConfiguration` | 4 | 0 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/guestconfiguration/Azure.ResourceManager.GuestConfiguration/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HardwareSecurityModules` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/hardwaresecuritymodules/Azure.ResourceManager.HardwareSecurityModules/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Hci` | 30 | 30 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/azurestackhci/Azure.ResourceManager.Hci/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Hci.Vm` | 17 | 17 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/azurestackhci/Azure.ResourceManager.Hci.Vm/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HDInsight` | 4 | 10 | 0 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/hdinsight/Azure.ResourceManager.HDInsight/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HealthBot` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/healthbot/Azure.ResourceManager.HealthBot/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HealthcareApis` | 10 | 10 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/healthcareapis/Azure.ResourceManager.HealthcareApis/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HealthDataAIServices` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/healthdataaiservices/Azure.ResourceManager.HealthDataAIServices/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HorizonDB` | 7 | 6 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/horizondb/Azure.ResourceManager.HorizonDB/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HybridCompute` | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 | [report](sdk/hybridcompute/Azure.ResourceManager.HybridCompute/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HybridConnectivity` | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/hybridconnectivity/Azure.ResourceManager.HybridConnectivity/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HybridNetwork` | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/hybridnetwork/Azure.ResourceManager.HybridNetwork/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ImageBuilder` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/imagebuilder/Azure.ResourceManager.ImageBuilder/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ImpactReporting` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/impactreporting/Azure.ResourceManager.ImpactReporting/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.InformaticaDataManagement` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/informaticadatamanagement/Azure.ResourceManager.InformaticaDataManagement/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.IotHub` | 4 | 5 | 0 | 1 | 0 | 0 | 1 | 0 | 0 | 0 | [report](sdk/iothub/Azure.ResourceManager.IotHub/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.IotOperations` | 12 | 12 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/iotoperations/Azure.ResourceManager.IotOperations/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.KeyVault` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/keyvault/Azure.ResourceManager.KeyVault/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Kubernetes` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/hybridkubernetes/Azure.ResourceManager.Kubernetes/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.KubernetesConfiguration.Extensions` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.Extensions/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.KubernetesConfiguration.PrivateLinkScopes` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.PrivateLinkScopes/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Kusto` | 11 | 9 | 2 | 0 | 0 | 0 | 2 | 0 | 0 | 0 | [report](sdk/kusto/Azure.ResourceManager.Kusto/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.LambdaTestHyperExecute` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/lambdatesthyperexecute/Azure.ResourceManager.LambdaTestHyperExecute/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.LargeInstance` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/azurelargeinstance/Azure.ResourceManager.LargeInstance/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.LoadTesting` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/loadtestservice/Azure.ResourceManager.LoadTesting/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.MachineLearning` | 53 | 53 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Maintenance` | 8 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/maintenance/Azure.ResourceManager.Maintenance/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ManagedApplications` | 4 | 0 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/managedapplications/Azure.ResourceManager.ManagedApplications/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ManagedNetworkFabric` | 26 | 26 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/managednetworkfabric/Azure.ResourceManager.ManagedNetworkFabric/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ManagedOps` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/managedops/Azure.ResourceManager.ManagedOps/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ManagedServiceIdentities` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/managedserviceidentity/Azure.ResourceManager.ManagedServiceIdentities/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Maps` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/maps/Azure.ResourceManager.Maps/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Marketplace` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/marketplace/Azure.ResourceManager.Marketplace/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.MongoCluster` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/mongocluster/Azure.ResourceManager.MongoCluster/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.MongoDBAtlas` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/mongodbatlas/Azure.ResourceManager.MongoDBAtlas/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Monitor` | 14 | 14 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 0 | [report](sdk/monitor/Azure.ResourceManager.Monitor/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Monitor.PipelineGroups` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/monitorpipelinegroups/Azure.ResourceManager.Monitor.PipelineGroups/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Monitor.Slis` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 | [report](sdk/monitor/Azure.ResourceManager.Monitor.Slis/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Monitor.Workspaces` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/monitor/Azure.ResourceManager.Monitor.Workspaces/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.MySql` | 11 | 11 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/mysql/Azure.ResourceManager.MySql/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.NapsterOmniagentApi` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/napsteromniagentapi/Azure.ResourceManager.NapsterOmniagentApi/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.NetApp` | 17 | 17 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/netapp/Azure.ResourceManager.NetApp/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Network` | 140 | 0 | 140 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/network/Azure.ResourceManager.Network/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.NetworkCloud` | 21 | 21 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/networkcloud/Azure.ResourceManager.NetworkCloud/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.NetworkFunction` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/networkfunction/Azure.ResourceManager.NetworkFunction/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.NewRelicObservability` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/newrelicobservability/Azure.ResourceManager.NewRelicObservability/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Nginx` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 4 | [report](sdk/nginx/Azure.ResourceManager.Nginx/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.NotificationHubs` | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/notificationhubs/Azure.ResourceManager.NotificationHubs/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.OnlineExperimentation` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/onlineexperimentation/Azure.ResourceManager.OnlineExperimentation/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.OperationalInsights` | 12 | 12 | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/operationalinsights/Azure.ResourceManager.OperationalInsights/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.OracleDatabase` | 25 | 25 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/oracle/Azure.ResourceManager.OracleDatabase/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PaloAltoNetworks.Ngfw` | 14 | 14 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/paloaltonetworks.ngfw/Azure.ResourceManager.PaloAltoNetworks.Ngfw/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Peering` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/peering/Azure.ResourceManager.Peering/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PineconeVectorDB` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/pineconevectordb/Azure.ResourceManager.PineconeVectorDB/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PlanetaryComputer` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/planetarycomputer/Azure.ResourceManager.PlanetaryComputer/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Playwright` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/playwright/Azure.ResourceManager.Playwright/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PolicyInsights` | 3 | 8 | 0 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/policyinsights/Azure.ResourceManager.PolicyInsights/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PortalServicesCopilot` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/portalservices/Azure.ResourceManager.PortalServicesCopilot/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PostgreSql` | 15 | 15 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/postgresql/Azure.ResourceManager.PostgreSql/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PowerBIDedicated` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/powerbidedicated/Azure.ResourceManager.PowerBIDedicated/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PowerPlatform` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/powerplatform/Azure.ResourceManager.PowerPlatform/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PreviewAlertRule` | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.PreviewAlertRule/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PrivateDns` | 10 | 2 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/privatedns/Azure.ResourceManager.PrivateDns/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ProgramEnrollment` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/programenrollment/Azure.ResourceManager.ProgramEnrollment/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PrometheusRuleGroups` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.PrometheusRuleGroups/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ProviderHub` | 12 | 13 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/providerhub/Azure.ResourceManager.ProviderHub/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PureStorageBlock` | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/purestorageblock/Azure.ResourceManager.PureStorageBlock/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Purview` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/purview/Azure.ResourceManager.Purview/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Quantum` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/quantum/Azure.ResourceManager.Quantum/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Qumulo` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/qumulo/Azure.ResourceManager.Qumulo/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Quota` | 11 | 11 | 0 | 0 | 0 | 0 | 2 | 2 | 0 | 2 | [report](sdk/quota/Azure.ResourceManager.Quota/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.RecoveryServices` | 4 | 5 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/recoveryservices/Azure.ResourceManager.RecoveryServices/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.RecoveryServicesBackup` | 12 | 24 | 0 | 12 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/recoveryservices-backup/Azure.ResourceManager.RecoveryServicesBackup/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.RecoveryServicesDataReplication` | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/recoveryservices-datareplication/Azure.ResourceManager.RecoveryServicesDataReplication/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.RecoveryServicesSiteRecovery` | 24 | 25 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/recoveryservices-siterecovery/Azure.ResourceManager.RecoveryServicesSiteRecovery/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.RedHatOpenShift` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/redhatopenshift/Azure.ResourceManager.RedHatOpenShift/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Redis` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/redis/Azure.ResourceManager.Redis/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.RedisEnterprise` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/redisenterprise/Azure.ResourceManager.RedisEnterprise/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Relationships` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/relationships/Azure.ResourceManager.Relationships/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Relay` | 9 | 9 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/relay/Azure.ResourceManager.Relay/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Reservations` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/reservations/Azure.ResourceManager.Reservations/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ResilienceManagement` | 14 | 14 | 0 | 0 | 0 | 0 | 0 | 12 | 0 | 0 | [report](sdk/azureresiliencemanagement/Azure.ResourceManager.ResilienceManagement/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ResourceConnector` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/resourceconnector/Azure.ResourceManager.ResourceConnector/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ResourceGraph` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/resourcegraph/Azure.ResourceManager.ResourceGraph/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ResourceHealth` | 6 | 6 | 0 | 0 | 0 | 0 | 1 | 1 | 0 | 0 | [report](sdk/resourcehealth/Azure.ResourceManager.ResourceHealth/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Resources.Bicep` | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/resources/Azure.ResourceManager.Resources.Bicep/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Resources.Deployments` | 1 | 5 | 0 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/resources/Azure.ResourceManager.Resources.Deployments/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Resources.DeploymentStacks` | 2 | 8 | 0 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/resources/Azure.ResourceManager.Resources.DeploymentStacks/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Resources.Policy` | 9 | 19 | 0 | 10 | 0 | 0 | 2 | 2 | 0 | 0 | [report](sdk/resources/Azure.ResourceManager.Resources.Policy/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ScVmm` | 9 | 9 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/arc-scvmm/Azure.ResourceManager.ScVmm/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Search` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/search/Azure.ResourceManager.Search/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SecretsStoreExtension` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/secretsstoreextension/Azure.ResourceManager.SecretsStoreExtension/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SecurityCenter` | 67 | 66 | 3 | 2 | 0 | 0 | 4 | 8 | 0 | 0 | [report](sdk/securitycenter/Azure.ResourceManager.SecurityCenter/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SecurityInsights` | 41 | 41 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 5 | [report](sdk/securityinsights/Azure.ResourceManager.SecurityInsights/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SelfHelp` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/selfhelp/Azure.ResourceManager.SelfHelp/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SerialConsole` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/serialconsole/Azure.ResourceManager.SerialConsole/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ServiceBus` | 14 | 14 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/servicebus/Azure.ResourceManager.ServiceBus/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ServiceFabric` | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/servicefabric/Azure.ResourceManager.ServiceFabric/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ServiceFabricManagedClusters` | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/servicefabricmanagedclusters/Azure.ResourceManager.ServiceFabricManagedClusters/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ServiceGroups` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/servicegroups/Azure.ResourceManager.ServiceGroups/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ServiceNetworking` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SignalR` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/signalr/Azure.ResourceManager.SignalR/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SiteManager` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 | [report](sdk/sitemanager/Azure.ResourceManager.SiteManager/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Sphere` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/sphere/Azure.ResourceManager.Sphere/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Sql` | 127 | 126 | 2 | 1 | 0 | 0 | 0 | 5 | 0 | 2 | [report](sdk/sqlmanagement/Azure.ResourceManager.Sql/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SqlVirtualMachine` | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/sqlvirtualmachine/Azure.ResourceManager.SqlVirtualMachine/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.StandbyPool` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/standbypool/Azure.ResourceManager.StandbyPool/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Storage` | 23 | 23 | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 2 | [report](sdk/storage/Azure.ResourceManager.Storage/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.StorageActions` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/storageactions/Azure.ResourceManager.StorageActions/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.StorageCache` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/storagecache/Azure.ResourceManager.StorageCache/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.StorageDiscovery` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/storagediscovery/Azure.ResourceManager.StorageDiscovery/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.StorageMover` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/storagemover/Azure.ResourceManager.StorageMover/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.StorageSync` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/storagesync/Azure.ResourceManager.StorageSync/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Subscription` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/subscription/Azure.ResourceManager.Subscription/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Support` | 12 | 12 | 0 | 0 | 0 | 0 | 3 | 3 | 0 | 0 | [report](sdk/support/Azure.ResourceManager.Support/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.TenantActivityLogAlerts` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.TenantActivityLogAlerts/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Terraform` | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/terraform/Azure.ResourceManager.Terraform/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.TrafficManager` | 7 | 0 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/trafficmanager/Azure.ResourceManager.TrafficManager/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.WebPubSub` | 8 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/webpubsub/Azure.ResourceManager.WebPubSub/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.WeightsAndBiases` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/weightsandbiases/Azure.ResourceManager.WeightsAndBiases/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.WorkloadOrchestration` | 21 | 21 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/workloadorchestration/Azure.ResourceManager.WorkloadOrchestration/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.WorkloadsSapVirtualInstance` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/workloadssapvirtualinstance/Azure.ResourceManager.WorkloadsSapVirtualInstance/arm-provider-schema-resource-shape-comparison.md) |

## Libraries with resource-shape differences

| Library | Total diff signals | Legacy-only IDs | resolve-only IDs | Resource ID diffs | Type diffs | Parent diffs | Scope diffs | Read diffs | Create diffs | Report |
| --- | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: | --- |
| `Azure.ResourceManager.Network` | 140 | 140 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/network/Azure.ResourceManager.Network/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DevTestLabs` | 62 | 0 | 0 | 15 | 0 | 19 | 0 | 15 | 13 | [report](sdk/devtestlabs/Azure.ResourceManager.DevTestLabs/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SecurityCenter` | 17 | 3 | 2 | 0 | 0 | 4 | 8 | 0 | 0 | [report](sdk/securitycenter/Azure.ResourceManager.SecurityCenter/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Resources.Policy` | 14 | 0 | 10 | 0 | 0 | 2 | 2 | 0 | 0 | [report](sdk/resources/Azure.ResourceManager.Resources.Policy/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Dns` | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/dns/Azure.ResourceManager.Dns/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.RecoveryServicesBackup` | 12 | 0 | 12 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/recoveryservices-backup/Azure.ResourceManager.RecoveryServicesBackup/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ResilienceManagement` | 12 | 0 | 0 | 0 | 0 | 0 | 12 | 0 | 0 | [report](sdk/azureresiliencemanagement/Azure.ResourceManager.ResilienceManagement/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Sql` | 10 | 2 | 1 | 0 | 0 | 0 | 5 | 0 | 2 | [report](sdk/sqlmanagement/Azure.ResourceManager.Sql/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ApiManagement` | 9 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 7 | [report](sdk/apimanagement/Azure.ResourceManager.ApiManagement/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Automation` | 8 | 0 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/automation/Azure.ResourceManager.Automation/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PrivateDns` | 8 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/privatedns/Azure.ResourceManager.PrivateDns/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Authorization` | 7 | 1 | 1 | 0 | 0 | 2 | 3 | 0 | 0 | [report](sdk/authorization/Azure.ResourceManager.Authorization/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.TrafficManager` | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/trafficmanager/Azure.ResourceManager.TrafficManager/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AppService` | 6 | 0 | 1 | 0 | 0 | 4 | 0 | 0 | 1 | [report](sdk/websites/Azure.ResourceManager.AppService/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.FrontDoor` | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/frontdoor/Azure.ResourceManager.FrontDoor/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HDInsight` | 6 | 0 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/hdinsight/Azure.ResourceManager.HDInsight/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Quota` | 6 | 0 | 0 | 0 | 0 | 2 | 2 | 0 | 2 | [report](sdk/quota/Azure.ResourceManager.Quota/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Resources.DeploymentStacks` | 6 | 0 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/resources/Azure.ResourceManager.Resources.DeploymentStacks/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Storage` | 6 | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 2 | [report](sdk/storage/Azure.ResourceManager.Storage/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Support` | 6 | 0 | 0 | 0 | 0 | 3 | 3 | 0 | 0 | [report](sdk/support/Azure.ResourceManager.Support/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Confluent` | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 5 | [report](sdk/confluent/Azure.ResourceManager.Confluent/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.CosmosDB` | 5 | 0 | 3 | 0 | 0 | 0 | 0 | 0 | 2 | [report](sdk/cosmosdb/Azure.ResourceManager.CosmosDB/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.EventGrid` | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/eventgrid/Azure.ResourceManager.EventGrid/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.PolicyInsights` | 5 | 0 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/policyinsights/Azure.ResourceManager.PolicyInsights/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SecurityInsights` | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 5 | [report](sdk/securityinsights/Azure.ResourceManager.SecurityInsights/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AppContainers` | 4 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 2 | [report](sdk/containerapps/Azure.ResourceManager.AppContainers/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Elastic` | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 4 | [report](sdk/elastic/Azure.ResourceManager.Elastic/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.GuestConfiguration` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/guestconfiguration/Azure.ResourceManager.GuestConfiguration/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Kusto` | 4 | 2 | 0 | 0 | 0 | 2 | 0 | 0 | 0 | [report](sdk/kusto/Azure.ResourceManager.Kusto/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ManagedApplications` | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/managedapplications/Azure.ResourceManager.ManagedApplications/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Nginx` | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 4 | [report](sdk/nginx/Azure.ResourceManager.Nginx/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Resources.Deployments` | 4 | 0 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/resources/Azure.ResourceManager.Resources.Deployments/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ApplicationInsights` | 3 | 2 | 0 | 0 | 0 | 1 | 0 | 0 | 0 | [report](sdk/applicationinsights/Azure.ResourceManager.ApplicationInsights/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DataProtectionBackup` | 3 | 0 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/dataprotection/Azure.ResourceManager.DataProtectionBackup/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Advisor` | 2 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 0 | [report](sdk/advisor/Azure.ResourceManager.Advisor/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Batch` | 2 | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/batch/Azure.ResourceManager.Batch/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Billing` | 2 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 0 | [report](sdk/billing/Azure.ResourceManager.Billing/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Compute` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/compute/Azure.ResourceManager.Compute/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ComputeBulkActions` | 2 | 0 | 1 | 0 | 0 | 0 | 1 | 0 | 0 | [report](sdk/computebulkactions/Azure.ResourceManager.ComputeBulkActions/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ContainerRegistry` | 2 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 0 | [report](sdk/containerregistry/Azure.ResourceManager.ContainerRegistry/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Datadog` | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 2 | [report](sdk/datadog/Azure.ResourceManager.Datadog/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.EventHubs` | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/eventhub/Azure.ResourceManager.EventHubs/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.IotHub` | 2 | 0 | 1 | 0 | 0 | 1 | 0 | 0 | 0 | [report](sdk/iothub/Azure.ResourceManager.IotHub/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Monitor` | 2 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 0 | [report](sdk/monitor/Azure.ResourceManager.Monitor/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.OperationalInsights` | 2 | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/operationalinsights/Azure.ResourceManager.OperationalInsights/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.RecoveryServices` | 2 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/recoveryservices/Azure.ResourceManager.RecoveryServices/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ResourceHealth` | 2 | 0 | 0 | 0 | 0 | 1 | 1 | 0 | 0 | [report](sdk/resourcehealth/Azure.ResourceManager.ResourceHealth/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.AppConfiguration` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/appconfiguration/Azure.ResourceManager.AppConfiguration/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.BotService` | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/botservice/Azure.ResourceManager.BotService/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.CognitiveServices` | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/cognitiveservices/Azure.ResourceManager.CognitiveServices/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ContainerInstance` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/containerinstance/Azure.ResourceManager.ContainerInstance/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DataBoxEdge` | 1 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/databoxedge/Azure.ResourceManager.DataBoxEdge/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.DeviceProvisioningServices` | 1 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/deviceprovisioningservices/Azure.ResourceManager.DeviceProvisioningServices/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Grafana` | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/grafana/Azure.ResourceManager.Grafana/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HorizonDB` | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/horizondb/Azure.ResourceManager.HorizonDB/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.HybridCompute` | 1 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 | [report](sdk/hybridcompute/Azure.ResourceManager.HybridCompute/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Monitor.Slis` | 1 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 | [report](sdk/monitor/Azure.ResourceManager.Monitor.Slis/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.MySql` | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/mysql/Azure.ResourceManager.MySql/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.ProviderHub` | 1 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/providerhub/Azure.ResourceManager.ProviderHub/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.RecoveryServicesSiteRecovery` | 1 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | [report](sdk/recoveryservices-siterecovery/Azure.ResourceManager.RecoveryServicesSiteRecovery/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.Search` | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 | [report](sdk/search/Azure.ResourceManager.Search/arm-provider-schema-resource-shape-comparison.md) |
| `Azure.ResourceManager.SiteManager` | 1 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 | [report](sdk/sitemanager/Azure.ResourceManager.SiteManager/arm-provider-schema-resource-shape-comparison.md) |