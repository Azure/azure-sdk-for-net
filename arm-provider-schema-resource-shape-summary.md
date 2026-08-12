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

| Library | Legacy resources | resolveArmResources resources | Legacy-only IDs | resolve-only IDs | Resource ID diffs | Type diffs | Parent diffs | Scope diffs | Read diffs | Create diffs |
| --- | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: |
| [Azure.ResourceManager.Advisor](sdk/advisor/Azure.ResourceManager.Advisor/arm-provider-schema-resource-shape-comparison.md) | 8 | 8 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 0 |
| [Azure.ResourceManager.AgriculturePlatform](sdk/agricultureplatform/Azure.ResourceManager.AgriculturePlatform/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.AlertProcessingRules](sdk/alertsmanagement/Azure.ResourceManager.AlertProcessingRules/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.AlertRuleRecommendations](sdk/alertsmanagement/Azure.ResourceManager.AlertRuleRecommendations/arm-provider-schema-resource-shape-comparison.md) ✅ | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.AlertsManagement](sdk/alertsmanagement/Azure.ResourceManager.AlertsManagement/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ApiCenter](sdk/apicenter/Azure.ResourceManager.ApiCenter/arm-provider-schema-resource-shape-comparison.md) ✅ | 10 | 10 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ApiManagement](sdk/apimanagement/Azure.ResourceManager.ApiManagement/arm-provider-schema-resource-shape-comparison.md) | 102 | 102 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 7 |
| [Azure.ResourceManager.AppComplianceAutomation](sdk/appcomplianceautomation/Azure.ResourceManager.AppComplianceAutomation/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.AppConfiguration](sdk/appconfiguration/Azure.ResourceManager.AppConfiguration/arm-provider-schema-resource-shape-comparison.md) | 7 | 6 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.AppContainers](sdk/containerapps/Azure.ResourceManager.AppContainers/arm-provider-schema-resource-shape-comparison.md) | 41 | 41 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 2 |
| [Azure.ResourceManager.ApplicationInsights](sdk/applicationinsights/Azure.ResourceManager.ApplicationInsights/arm-provider-schema-resource-shape-comparison.md) | 6 | 4 | 2 | 0 | 0 | 0 | 1 | 0 | 0 | 0 |
| [Azure.ResourceManager.AppNetwork](sdk/appnetwork/Azure.ResourceManager.AppNetwork/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.AppService](sdk/websites/Azure.ResourceManager.AppService/arm-provider-schema-resource-shape-comparison.md) | 136 | 137 | 0 | 1 | 0 | 0 | 4 | 0 | 0 | 1 |
| [Azure.ResourceManager.ArizeAIObservabilityEval](sdk/arizeaiobservabilityeval/Azure.ResourceManager.ArizeAIObservabilityEval/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ArtifactSigning](sdk/artifactsigning/Azure.ResourceManager.ArtifactSigning/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Astro](sdk/astronomer/Azure.ResourceManager.Astro/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Attestation](sdk/attestation/Azure.ResourceManager.Attestation/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Authorization](sdk/authorization/Azure.ResourceManager.Authorization/arm-provider-schema-resource-shape-comparison.md) | 27 | 28 | 1 | 1 | 0 | 0 | 2 | 3 | 0 | 0 |
| [Azure.ResourceManager.Automation](sdk/automation/Azure.ResourceManager.Automation/arm-provider-schema-resource-shape-comparison.md) | 25 | 33 | 0 | 8 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Avs](sdk/avs/Azure.ResourceManager.Avs/arm-provider-schema-resource-shape-comparison.md) ✅ | 29 | 29 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Batch](sdk/batch/Azure.ResourceManager.Batch/arm-provider-schema-resource-shape-comparison.md) | 8 | 8 | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Billing](sdk/billing/Azure.ResourceManager.Billing/arm-provider-schema-resource-shape-comparison.md) | 46 | 46 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 0 |
| [Azure.ResourceManager.Billing.Trust](sdk/billingtrust/Azure.ResourceManager.Billing.Trust/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.BillingBenefits](sdk/billingbenefits/Azure.ResourceManager.BillingBenefits/arm-provider-schema-resource-shape-comparison.md) ✅ | 12 | 12 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.BotService](sdk/botservice/Azure.ResourceManager.BotService/arm-provider-schema-resource-shape-comparison.md) | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.CarbonOptimization](sdk/carbon/Azure.ResourceManager.CarbonOptimization/arm-provider-schema-resource-shape-comparison.md) ✅ | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Cdn](sdk/cdn/Azure.ResourceManager.Cdn/arm-provider-schema-resource-shape-comparison.md) ✅ | 20 | 20 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.CertificateRegistration](sdk/certificateregistration/Azure.ResourceManager.CertificateRegistration/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Chaos](sdk/chaos/Azure.ResourceManager.Chaos/arm-provider-schema-resource-shape-comparison.md) ✅ | 15 | 15 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.CloudHealth](sdk/cloudhealth/Azure.ResourceManager.CloudHealth/arm-provider-schema-resource-shape-comparison.md) ✅ | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.CognitiveServices](sdk/cognitiveservices/Azure.ResourceManager.CognitiveServices/arm-provider-schema-resource-shape-comparison.md) | 31 | 31 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.Communication](sdk/communication/Azure.ResourceManager.Communication/arm-provider-schema-resource-shape-comparison.md) ✅ | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Compute](sdk/compute/Azure.ResourceManager.Compute/arm-provider-schema-resource-shape-comparison.md) | 37 | 35 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Compute.BulkActions](sdk/compute/Azure.ResourceManager.Compute.BulkActions/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Compute.Recommender](sdk/computerecommender/Azure.ResourceManager.Compute.Recommender/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ComputeBulkActions](sdk/computebulkactions/Azure.ResourceManager.ComputeBulkActions/arm-provider-schema-resource-shape-comparison.md) | 1 | 2 | 0 | 1 | 0 | 0 | 0 | 1 | 0 | 0 |
| [Azure.ResourceManager.ComputeFleet](sdk/computefleet/Azure.ResourceManager.ComputeFleet/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ComputeLimit](sdk/computelimit/Azure.ResourceManager.ComputeLimit/arm-provider-schema-resource-shape-comparison.md) ✅ | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ComputeSchedule](sdk/computeschedule/Azure.ResourceManager.ComputeSchedule/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ConfidentialLedger](sdk/confidentialledger/Azure.ResourceManager.ConfidentialLedger/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Confluent](sdk/confluent/Azure.ResourceManager.Confluent/arm-provider-schema-resource-shape-comparison.md) | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 5 |
| [Azure.ResourceManager.ConnectedCache](sdk/connectedcache/Azure.ResourceManager.ConnectedCache/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Consumption](sdk/consumption/Azure.ResourceManager.Consumption/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ContainerInstance](sdk/containerinstance/Azure.ResourceManager.ContainerInstance/arm-provider-schema-resource-shape-comparison.md) | 4 | 3 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ContainerOrchestratorRuntime](sdk/containerorchestratorruntime/Azure.ResourceManager.ContainerOrchestratorRuntime/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ContainerRegistry](sdk/containerregistry/Azure.ResourceManager.ContainerRegistry/arm-provider-schema-resource-shape-comparison.md) | 15 | 15 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 0 |
| [Azure.ResourceManager.ContainerRegistry.Tasks](sdk/containerregistry/Azure.ResourceManager.ContainerRegistry.Tasks/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ContainerService](sdk/containerservice/Azure.ResourceManager.ContainerService/arm-provider-schema-resource-shape-comparison.md) ✅ | 21 | 21 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ContainerServiceFleet](sdk/fleet/Azure.ResourceManager.ContainerServiceFleet/arm-provider-schema-resource-shape-comparison.md) ✅ | 8 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ContainerServicePreparedImgSpec](sdk/containerservicepreparedimgspec/Azure.ResourceManager.ContainerServicePreparedImgSpec/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ContainerServiceSafeguards](sdk/containerservicesafeguards/Azure.ResourceManager.ContainerServiceSafeguards/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.CosmosDB](sdk/cosmosdb/Azure.ResourceManager.CosmosDB/arm-provider-schema-resource-shape-comparison.md) | 46 | 49 | 0 | 3 | 0 | 0 | 0 | 0 | 0 | 2 |
| [Azure.ResourceManager.CosmosDBForPostgreSql](sdk/cosmosdbforpostgresql/Azure.ResourceManager.CosmosDBForPostgreSql/arm-provider-schema-resource-shape-comparison.md) ✅ | 9 | 9 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.CostManagement](sdk/costmanagement/Azure.ResourceManager.CostManagement/arm-provider-schema-resource-shape-comparison.md) ✅ | 11 | 11 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DatabaseWatcher](sdk/databasewatcher/Azure.ResourceManager.DatabaseWatcher/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DataBox](sdk/databox/Azure.ResourceManager.DataBox/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DataBoxEdge](sdk/databoxedge/Azure.ResourceManager.DataBoxEdge/arm-provider-schema-resource-shape-comparison.md) | 19 | 20 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Databricks](sdk/databricks/Azure.ResourceManager.Databricks/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Datadog](sdk/datadog/Azure.ResourceManager.Datadog/arm-provider-schema-resource-shape-comparison.md) | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 2 |
| [Azure.ResourceManager.DataFactory](sdk/datafactory/Azure.ResourceManager.DataFactory/arm-provider-schema-resource-shape-comparison.md) ✅ | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DataMigration](sdk/datamigration/Azure.ResourceManager.DataMigration/arm-provider-schema-resource-shape-comparison.md) ✅ | 12 | 12 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DataProtectionBackup](sdk/dataprotection/Azure.ResourceManager.DataProtectionBackup/arm-provider-schema-resource-shape-comparison.md) | 9 | 12 | 0 | 3 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Dell.Storage](sdk/dellstorage/Azure.ResourceManager.Dell.Storage/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DependencyMap](sdk/dependencymap/Azure.ResourceManager.DependencyMap/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DesktopVirtualization](sdk/desktopvirtualization/Azure.ResourceManager.DesktopVirtualization/arm-provider-schema-resource-shape-comparison.md) ✅ | 17 | 17 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DevCenter](sdk/devcenter/Azure.ResourceManager.DevCenter/arm-provider-schema-resource-shape-comparison.md) ✅ | 29 | 29 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DevHub](sdk/developerhub/Azure.ResourceManager.DevHub/arm-provider-schema-resource-shape-comparison.md) ✅ | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DeviceProvisioningServices](sdk/deviceprovisioningservices/Azure.ResourceManager.DeviceProvisioningServices/arm-provider-schema-resource-shape-comparison.md) | 4 | 5 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DeviceRegistry](sdk/deviceregistry/Azure.ResourceManager.DeviceRegistry/arm-provider-schema-resource-shape-comparison.md) ✅ | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DevOpsInfrastructure](sdk/devopsinfrastructure/Azure.ResourceManager.DevOpsInfrastructure/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DevTestLabs](sdk/devtestlabs/Azure.ResourceManager.DevTestLabs/arm-provider-schema-resource-shape-comparison.md) | 21 | 21 | 0 | 0 | 15 | 0 | 19 | 0 | 15 | 13 |
| [Azure.ResourceManager.DisconnectedOperations](sdk/disconnectedoperations/Azure.ResourceManager.DisconnectedOperations/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Discovery](sdk/discovery/Azure.ResourceManager.Discovery/arm-provider-schema-resource-shape-comparison.md) ✅ | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Dns](sdk/dns/Azure.ResourceManager.Dns/arm-provider-schema-resource-shape-comparison.md) | 15 | 2 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DnsResolver](sdk/dnsresolver/Azure.ResourceManager.DnsResolver/arm-provider-schema-resource-shape-comparison.md) ✅ | 10 | 10 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DomainRegistration](sdk/domainregistration/Azure.ResourceManager.DomainRegistration/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DomainServices](sdk/domainservices/Azure.ResourceManager.DomainServices/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DurableTask](sdk/durabletask/Azure.ResourceManager.DurableTask/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Dynatrace](sdk/dynatrace/Azure.ResourceManager.Dynatrace/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.EdgeActions](sdk/edgeactions/Azure.ResourceManager.EdgeActions/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.EdgeOrder](sdk/edgeorder/Azure.ResourceManager.EdgeOrder/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.EdgeZones](sdk/edgezones/Azure.ResourceManager.EdgeZones/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Education](sdk/education/Azure.ResourceManager.Education/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Elastic](sdk/elastic/Azure.ResourceManager.Elastic/arm-provider-schema-resource-shape-comparison.md) | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 4 |
| [Azure.ResourceManager.ElasticSan](sdk/elasticsan/Azure.ResourceManager.ElasticSan/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Enclave](sdk/enclave/Azure.ResourceManager.Enclave/arm-provider-schema-resource-shape-comparison.md) ✅ | 9 | 9 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.EventGrid](sdk/eventgrid/Azure.ResourceManager.EventGrid/arm-provider-schema-resource-shape-comparison.md) | 32 | 27 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.EventHubs](sdk/eventhub/Azure.ResourceManager.EventHubs/arm-provider-schema-resource-shape-comparison.md) | 13 | 11 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ExtendedLocations](sdk/extendedlocation/Azure.ResourceManager.ExtendedLocations/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Fabric](sdk/fabric/Azure.ResourceManager.Fabric/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.FileShares](sdk/fileshares/Azure.ResourceManager.FileShares/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.FrontDoor](sdk/frontdoor/Azure.ResourceManager.FrontDoor/arm-provider-schema-resource-shape-comparison.md) | 6 | 0 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Grafana](sdk/grafana/Azure.ResourceManager.Grafana/arm-provider-schema-resource-shape-comparison.md) | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.GuestConfiguration](sdk/guestconfiguration/Azure.ResourceManager.GuestConfiguration/arm-provider-schema-resource-shape-comparison.md) | 4 | 0 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.HardwareSecurityModules](sdk/hardwaresecuritymodules/Azure.ResourceManager.HardwareSecurityModules/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Hci](sdk/azurestackhci/Azure.ResourceManager.Hci/arm-provider-schema-resource-shape-comparison.md) ✅ | 30 | 30 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Hci.Vm](sdk/azurestackhci/Azure.ResourceManager.Hci.Vm/arm-provider-schema-resource-shape-comparison.md) ✅ | 17 | 17 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.HDInsight](sdk/hdinsight/Azure.ResourceManager.HDInsight/arm-provider-schema-resource-shape-comparison.md) | 4 | 10 | 0 | 6 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.HealthBot](sdk/healthbot/Azure.ResourceManager.HealthBot/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.HealthcareApis](sdk/healthcareapis/Azure.ResourceManager.HealthcareApis/arm-provider-schema-resource-shape-comparison.md) ✅ | 10 | 10 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.HealthDataAIServices](sdk/healthdataaiservices/Azure.ResourceManager.HealthDataAIServices/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.HorizonDB](sdk/horizondb/Azure.ResourceManager.HorizonDB/arm-provider-schema-resource-shape-comparison.md) | 7 | 6 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.HybridCompute](sdk/hybridcompute/Azure.ResourceManager.HybridCompute/arm-provider-schema-resource-shape-comparison.md) | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 |
| [Azure.ResourceManager.HybridConnectivity](sdk/hybridconnectivity/Azure.ResourceManager.HybridConnectivity/arm-provider-schema-resource-shape-comparison.md) ✅ | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.HybridNetwork](sdk/hybridnetwork/Azure.ResourceManager.HybridNetwork/arm-provider-schema-resource-shape-comparison.md) ✅ | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ImageBuilder](sdk/imagebuilder/Azure.ResourceManager.ImageBuilder/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ImpactReporting](sdk/impactreporting/Azure.ResourceManager.ImpactReporting/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.InformaticaDataManagement](sdk/informaticadatamanagement/Azure.ResourceManager.InformaticaDataManagement/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.IotHub](sdk/iothub/Azure.ResourceManager.IotHub/arm-provider-schema-resource-shape-comparison.md) | 4 | 5 | 0 | 1 | 0 | 0 | 1 | 0 | 0 | 0 |
| [Azure.ResourceManager.IotOperations](sdk/iotoperations/Azure.ResourceManager.IotOperations/arm-provider-schema-resource-shape-comparison.md) ✅ | 12 | 12 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.KeyVault](sdk/keyvault/Azure.ResourceManager.KeyVault/arm-provider-schema-resource-shape-comparison.md) ✅ | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Kubernetes](sdk/hybridkubernetes/Azure.ResourceManager.Kubernetes/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.KubernetesConfiguration.Extensions](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.Extensions/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.KubernetesConfiguration.PrivateLinkScopes](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.PrivateLinkScopes/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Kusto](sdk/kusto/Azure.ResourceManager.Kusto/arm-provider-schema-resource-shape-comparison.md) | 11 | 9 | 2 | 0 | 0 | 0 | 2 | 0 | 0 | 0 |
| [Azure.ResourceManager.LambdaTestHyperExecute](sdk/lambdatesthyperexecute/Azure.ResourceManager.LambdaTestHyperExecute/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.LargeInstance](sdk/azurelargeinstance/Azure.ResourceManager.LargeInstance/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.LoadTesting](sdk/loadtestservice/Azure.ResourceManager.LoadTesting/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.MachineLearning](sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/arm-provider-schema-resource-shape-comparison.md) ✅ | 53 | 53 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Maintenance](sdk/maintenance/Azure.ResourceManager.Maintenance/arm-provider-schema-resource-shape-comparison.md) ✅ | 8 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ManagedApplications](sdk/managedapplications/Azure.ResourceManager.ManagedApplications/arm-provider-schema-resource-shape-comparison.md) | 4 | 0 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ManagedNetworkFabric](sdk/managednetworkfabric/Azure.ResourceManager.ManagedNetworkFabric/arm-provider-schema-resource-shape-comparison.md) ✅ | 26 | 26 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ManagedOps](sdk/managedops/Azure.ResourceManager.ManagedOps/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ManagedServiceIdentities](sdk/managedserviceidentity/Azure.ResourceManager.ManagedServiceIdentities/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Maps](sdk/maps/Azure.ResourceManager.Maps/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Marketplace](sdk/marketplace/Azure.ResourceManager.Marketplace/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.MongoCluster](sdk/mongocluster/Azure.ResourceManager.MongoCluster/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.MongoDBAtlas](sdk/mongodbatlas/Azure.ResourceManager.MongoDBAtlas/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Monitor](sdk/monitor/Azure.ResourceManager.Monitor/arm-provider-schema-resource-shape-comparison.md) | 14 | 14 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 0 |
| [Azure.ResourceManager.Monitor.PipelineGroups](sdk/monitorpipelinegroups/Azure.ResourceManager.Monitor.PipelineGroups/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Monitor.Slis](sdk/monitor/Azure.ResourceManager.Monitor.Slis/arm-provider-schema-resource-shape-comparison.md) | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 |
| [Azure.ResourceManager.Monitor.Workspaces](sdk/monitor/Azure.ResourceManager.Monitor.Workspaces/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.MySql](sdk/mysql/Azure.ResourceManager.MySql/arm-provider-schema-resource-shape-comparison.md) | 11 | 11 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.NapsterOmniagentApi](sdk/napsteromniagentapi/Azure.ResourceManager.NapsterOmniagentApi/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.NetApp](sdk/netapp/Azure.ResourceManager.NetApp/arm-provider-schema-resource-shape-comparison.md) ✅ | 17 | 17 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Network](sdk/network/Azure.ResourceManager.Network/arm-provider-schema-resource-shape-comparison.md) | 140 | 0 | 140 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.NetworkCloud](sdk/networkcloud/Azure.ResourceManager.NetworkCloud/arm-provider-schema-resource-shape-comparison.md) ✅ | 21 | 21 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.NetworkFunction](sdk/networkfunction/Azure.ResourceManager.NetworkFunction/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.NewRelicObservability](sdk/newrelicobservability/Azure.ResourceManager.NewRelicObservability/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Nginx](sdk/nginx/Azure.ResourceManager.Nginx/arm-provider-schema-resource-shape-comparison.md) | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 4 |
| [Azure.ResourceManager.NotificationHubs](sdk/notificationhubs/Azure.ResourceManager.NotificationHubs/arm-provider-schema-resource-shape-comparison.md) ✅ | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.OnlineExperimentation](sdk/onlineexperimentation/Azure.ResourceManager.OnlineExperimentation/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.OperationalInsights](sdk/operationalinsights/Azure.ResourceManager.OperationalInsights/arm-provider-schema-resource-shape-comparison.md) | 12 | 12 | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.OracleDatabase](sdk/oracle/Azure.ResourceManager.OracleDatabase/arm-provider-schema-resource-shape-comparison.md) ✅ | 25 | 25 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PaloAltoNetworks.Ngfw](sdk/paloaltonetworks.ngfw/Azure.ResourceManager.PaloAltoNetworks.Ngfw/arm-provider-schema-resource-shape-comparison.md) ✅ | 14 | 14 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Peering](sdk/peering/Azure.ResourceManager.Peering/arm-provider-schema-resource-shape-comparison.md) ✅ | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PineconeVectorDB](sdk/pineconevectordb/Azure.ResourceManager.PineconeVectorDB/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PlanetaryComputer](sdk/planetarycomputer/Azure.ResourceManager.PlanetaryComputer/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Playwright](sdk/playwright/Azure.ResourceManager.Playwright/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PolicyInsights](sdk/policyinsights/Azure.ResourceManager.PolicyInsights/arm-provider-schema-resource-shape-comparison.md) | 3 | 8 | 0 | 5 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PortalServicesCopilot](sdk/portalservices/Azure.ResourceManager.PortalServicesCopilot/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PostgreSql](sdk/postgresql/Azure.ResourceManager.PostgreSql/arm-provider-schema-resource-shape-comparison.md) ✅ | 15 | 15 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PowerBIDedicated](sdk/powerbidedicated/Azure.ResourceManager.PowerBIDedicated/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PowerPlatform](sdk/powerplatform/Azure.ResourceManager.PowerPlatform/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PreviewAlertRule](sdk/alertsmanagement/Azure.ResourceManager.PreviewAlertRule/arm-provider-schema-resource-shape-comparison.md) ✅ | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PrivateDns](sdk/privatedns/Azure.ResourceManager.PrivateDns/arm-provider-schema-resource-shape-comparison.md) | 10 | 2 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ProgramEnrollment](sdk/programenrollment/Azure.ResourceManager.ProgramEnrollment/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PrometheusRuleGroups](sdk/alertsmanagement/Azure.ResourceManager.PrometheusRuleGroups/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ProviderHub](sdk/providerhub/Azure.ResourceManager.ProviderHub/arm-provider-schema-resource-shape-comparison.md) | 12 | 13 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PureStorageBlock](sdk/purestorageblock/Azure.ResourceManager.PureStorageBlock/arm-provider-schema-resource-shape-comparison.md) ✅ | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Purview](sdk/purview/Azure.ResourceManager.Purview/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Quantum](sdk/quantum/Azure.ResourceManager.Quantum/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Qumulo](sdk/qumulo/Azure.ResourceManager.Qumulo/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Quota](sdk/quota/Azure.ResourceManager.Quota/arm-provider-schema-resource-shape-comparison.md) | 11 | 11 | 0 | 0 | 0 | 0 | 2 | 2 | 0 | 2 |
| [Azure.ResourceManager.RecoveryServices](sdk/recoveryservices/Azure.ResourceManager.RecoveryServices/arm-provider-schema-resource-shape-comparison.md) | 4 | 5 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.RecoveryServicesBackup](sdk/recoveryservices-backup/Azure.ResourceManager.RecoveryServicesBackup/arm-provider-schema-resource-shape-comparison.md) | 12 | 24 | 0 | 12 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.RecoveryServicesDataReplication](sdk/recoveryservices-datareplication/Azure.ResourceManager.RecoveryServicesDataReplication/arm-provider-schema-resource-shape-comparison.md) ✅ | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.RecoveryServicesSiteRecovery](sdk/recoveryservices-siterecovery/Azure.ResourceManager.RecoveryServicesSiteRecovery/arm-provider-schema-resource-shape-comparison.md) | 24 | 25 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.RedHatOpenShift](sdk/redhatopenshift/Azure.ResourceManager.RedHatOpenShift/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Redis](sdk/redis/Azure.ResourceManager.Redis/arm-provider-schema-resource-shape-comparison.md) ✅ | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.RedisEnterprise](sdk/redisenterprise/Azure.ResourceManager.RedisEnterprise/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Relationships](sdk/relationships/Azure.ResourceManager.Relationships/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Relay](sdk/relay/Azure.ResourceManager.Relay/arm-provider-schema-resource-shape-comparison.md) ✅ | 9 | 9 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Reservations](sdk/reservations/Azure.ResourceManager.Reservations/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ResilienceManagement](sdk/azureresiliencemanagement/Azure.ResourceManager.ResilienceManagement/arm-provider-schema-resource-shape-comparison.md) | 14 | 14 | 0 | 0 | 0 | 0 | 0 | 12 | 0 | 0 |
| [Azure.ResourceManager.ResourceConnector](sdk/resourceconnector/Azure.ResourceManager.ResourceConnector/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ResourceGraph](sdk/resourcegraph/Azure.ResourceManager.ResourceGraph/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ResourceHealth](sdk/resourcehealth/Azure.ResourceManager.ResourceHealth/arm-provider-schema-resource-shape-comparison.md) | 6 | 6 | 0 | 0 | 0 | 0 | 1 | 1 | 0 | 0 |
| [Azure.ResourceManager.Resources.Bicep](sdk/resources/Azure.ResourceManager.Resources.Bicep/arm-provider-schema-resource-shape-comparison.md) ✅ | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Resources.Deployments](sdk/resources/Azure.ResourceManager.Resources.Deployments/arm-provider-schema-resource-shape-comparison.md) | 1 | 5 | 0 | 4 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Resources.DeploymentStacks](sdk/resources/Azure.ResourceManager.Resources.DeploymentStacks/arm-provider-schema-resource-shape-comparison.md) | 2 | 8 | 0 | 6 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Resources.Policy](sdk/resources/Azure.ResourceManager.Resources.Policy/arm-provider-schema-resource-shape-comparison.md) | 9 | 19 | 0 | 10 | 0 | 0 | 2 | 2 | 0 | 0 |
| [Azure.ResourceManager.ScVmm](sdk/arc-scvmm/Azure.ResourceManager.ScVmm/arm-provider-schema-resource-shape-comparison.md) ✅ | 9 | 9 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Search](sdk/search/Azure.ResourceManager.Search/arm-provider-schema-resource-shape-comparison.md) | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.SecretsStoreExtension](sdk/secretsstoreextension/Azure.ResourceManager.SecretsStoreExtension/arm-provider-schema-resource-shape-comparison.md) ✅ | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.SecurityCenter](sdk/securitycenter/Azure.ResourceManager.SecurityCenter/arm-provider-schema-resource-shape-comparison.md) | 67 | 66 | 3 | 2 | 0 | 0 | 4 | 8 | 0 | 0 |
| [Azure.ResourceManager.SecurityInsights](sdk/securityinsights/Azure.ResourceManager.SecurityInsights/arm-provider-schema-resource-shape-comparison.md) | 41 | 41 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 5 |
| [Azure.ResourceManager.SelfHelp](sdk/selfhelp/Azure.ResourceManager.SelfHelp/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.SerialConsole](sdk/serialconsole/Azure.ResourceManager.SerialConsole/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ServiceBus](sdk/servicebus/Azure.ResourceManager.ServiceBus/arm-provider-schema-resource-shape-comparison.md) ✅ | 14 | 14 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ServiceFabric](sdk/servicefabric/Azure.ResourceManager.ServiceFabric/arm-provider-schema-resource-shape-comparison.md) ✅ | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ServiceFabricManagedClusters](sdk/servicefabricmanagedclusters/Azure.ResourceManager.ServiceFabricManagedClusters/arm-provider-schema-resource-shape-comparison.md) ✅ | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ServiceGroups](sdk/servicegroups/Azure.ResourceManager.ServiceGroups/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ServiceNetworking](sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.SignalR](sdk/signalr/Azure.ResourceManager.SignalR/arm-provider-schema-resource-shape-comparison.md) ✅ | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.SiteManager](sdk/sitemanager/Azure.ResourceManager.SiteManager/arm-provider-schema-resource-shape-comparison.md) | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 |
| [Azure.ResourceManager.Sphere](sdk/sphere/Azure.ResourceManager.Sphere/arm-provider-schema-resource-shape-comparison.md) ✅ | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Sql](sdk/sqlmanagement/Azure.ResourceManager.Sql/arm-provider-schema-resource-shape-comparison.md) | 127 | 126 | 2 | 1 | 0 | 0 | 0 | 5 | 0 | 2 |
| [Azure.ResourceManager.SqlVirtualMachine](sdk/sqlvirtualmachine/Azure.ResourceManager.SqlVirtualMachine/arm-provider-schema-resource-shape-comparison.md) ✅ | 3 | 3 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.StandbyPool](sdk/standbypool/Azure.ResourceManager.StandbyPool/arm-provider-schema-resource-shape-comparison.md) ✅ | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Storage](sdk/storage/Azure.ResourceManager.Storage/arm-provider-schema-resource-shape-comparison.md) | 23 | 23 | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 2 |
| [Azure.ResourceManager.StorageActions](sdk/storageactions/Azure.ResourceManager.StorageActions/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.StorageCache](sdk/storagecache/Azure.ResourceManager.StorageCache/arm-provider-schema-resource-shape-comparison.md) ✅ | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.StorageDiscovery](sdk/storagediscovery/Azure.ResourceManager.StorageDiscovery/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.StorageMover](sdk/storagemover/Azure.ResourceManager.StorageMover/arm-provider-schema-resource-shape-comparison.md) ✅ | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.StorageSync](sdk/storagesync/Azure.ResourceManager.StorageSync/arm-provider-schema-resource-shape-comparison.md) ✅ | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Subscription](sdk/subscription/Azure.ResourceManager.Subscription/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Support](sdk/support/Azure.ResourceManager.Support/arm-provider-schema-resource-shape-comparison.md) | 12 | 12 | 0 | 0 | 0 | 0 | 3 | 3 | 0 | 0 |
| [Azure.ResourceManager.TenantActivityLogAlerts](sdk/alertsmanagement/Azure.ResourceManager.TenantActivityLogAlerts/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Terraform](sdk/terraform/Azure.ResourceManager.Terraform/arm-provider-schema-resource-shape-comparison.md) ✅ | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.TrafficManager](sdk/trafficmanager/Azure.ResourceManager.TrafficManager/arm-provider-schema-resource-shape-comparison.md) | 7 | 0 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.WebPubSub](sdk/webpubsub/Azure.ResourceManager.WebPubSub/arm-provider-schema-resource-shape-comparison.md) ✅ | 8 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.WeightsAndBiases](sdk/weightsandbiases/Azure.ResourceManager.WeightsAndBiases/arm-provider-schema-resource-shape-comparison.md) ✅ | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.WorkloadOrchestration](sdk/workloadorchestration/Azure.ResourceManager.WorkloadOrchestration/arm-provider-schema-resource-shape-comparison.md) ✅ | 21 | 21 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.WorkloadsSapVirtualInstance](sdk/workloadssapvirtualinstance/Azure.ResourceManager.WorkloadsSapVirtualInstance/arm-provider-schema-resource-shape-comparison.md) ✅ | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |

## Libraries with resource-shape differences

| Library | Total diff signals | Legacy-only IDs | resolve-only IDs | Resource ID diffs | Type diffs | Parent diffs | Scope diffs | Read diffs | Create diffs |
| --- | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: |
| [Azure.ResourceManager.Network](sdk/network/Azure.ResourceManager.Network/arm-provider-schema-resource-shape-comparison.md) | 140 | 140 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DevTestLabs](sdk/devtestlabs/Azure.ResourceManager.DevTestLabs/arm-provider-schema-resource-shape-comparison.md) | 62 | 0 | 0 | 15 | 0 | 19 | 0 | 15 | 13 |
| [Azure.ResourceManager.SecurityCenter](sdk/securitycenter/Azure.ResourceManager.SecurityCenter/arm-provider-schema-resource-shape-comparison.md) | 17 | 3 | 2 | 0 | 0 | 4 | 8 | 0 | 0 |
| [Azure.ResourceManager.Resources.Policy](sdk/resources/Azure.ResourceManager.Resources.Policy/arm-provider-schema-resource-shape-comparison.md) | 14 | 0 | 10 | 0 | 0 | 2 | 2 | 0 | 0 |
| [Azure.ResourceManager.Dns](sdk/dns/Azure.ResourceManager.Dns/arm-provider-schema-resource-shape-comparison.md) | 13 | 13 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.RecoveryServicesBackup](sdk/recoveryservices-backup/Azure.ResourceManager.RecoveryServicesBackup/arm-provider-schema-resource-shape-comparison.md) | 12 | 0 | 12 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ResilienceManagement](sdk/azureresiliencemanagement/Azure.ResourceManager.ResilienceManagement/arm-provider-schema-resource-shape-comparison.md) | 12 | 0 | 0 | 0 | 0 | 0 | 12 | 0 | 0 |
| [Azure.ResourceManager.Sql](sdk/sqlmanagement/Azure.ResourceManager.Sql/arm-provider-schema-resource-shape-comparison.md) | 10 | 2 | 1 | 0 | 0 | 0 | 5 | 0 | 2 |
| [Azure.ResourceManager.ApiManagement](sdk/apimanagement/Azure.ResourceManager.ApiManagement/arm-provider-schema-resource-shape-comparison.md) | 9 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 7 |
| [Azure.ResourceManager.Automation](sdk/automation/Azure.ResourceManager.Automation/arm-provider-schema-resource-shape-comparison.md) | 8 | 0 | 8 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PrivateDns](sdk/privatedns/Azure.ResourceManager.PrivateDns/arm-provider-schema-resource-shape-comparison.md) | 8 | 8 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Authorization](sdk/authorization/Azure.ResourceManager.Authorization/arm-provider-schema-resource-shape-comparison.md) | 7 | 1 | 1 | 0 | 0 | 2 | 3 | 0 | 0 |
| [Azure.ResourceManager.TrafficManager](sdk/trafficmanager/Azure.ResourceManager.TrafficManager/arm-provider-schema-resource-shape-comparison.md) | 7 | 7 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.AppService](sdk/websites/Azure.ResourceManager.AppService/arm-provider-schema-resource-shape-comparison.md) | 6 | 0 | 1 | 0 | 0 | 4 | 0 | 0 | 1 |
| [Azure.ResourceManager.FrontDoor](sdk/frontdoor/Azure.ResourceManager.FrontDoor/arm-provider-schema-resource-shape-comparison.md) | 6 | 6 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.HDInsight](sdk/hdinsight/Azure.ResourceManager.HDInsight/arm-provider-schema-resource-shape-comparison.md) | 6 | 0 | 6 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Quota](sdk/quota/Azure.ResourceManager.Quota/arm-provider-schema-resource-shape-comparison.md) | 6 | 0 | 0 | 0 | 0 | 2 | 2 | 0 | 2 |
| [Azure.ResourceManager.Resources.DeploymentStacks](sdk/resources/Azure.ResourceManager.Resources.DeploymentStacks/arm-provider-schema-resource-shape-comparison.md) | 6 | 0 | 6 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Storage](sdk/storage/Azure.ResourceManager.Storage/arm-provider-schema-resource-shape-comparison.md) | 6 | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 2 |
| [Azure.ResourceManager.Support](sdk/support/Azure.ResourceManager.Support/arm-provider-schema-resource-shape-comparison.md) | 6 | 0 | 0 | 0 | 0 | 3 | 3 | 0 | 0 |
| [Azure.ResourceManager.Confluent](sdk/confluent/Azure.ResourceManager.Confluent/arm-provider-schema-resource-shape-comparison.md) | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 5 |
| [Azure.ResourceManager.CosmosDB](sdk/cosmosdb/Azure.ResourceManager.CosmosDB/arm-provider-schema-resource-shape-comparison.md) | 5 | 0 | 3 | 0 | 0 | 0 | 0 | 0 | 2 |
| [Azure.ResourceManager.EventGrid](sdk/eventgrid/Azure.ResourceManager.EventGrid/arm-provider-schema-resource-shape-comparison.md) | 5 | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.PolicyInsights](sdk/policyinsights/Azure.ResourceManager.PolicyInsights/arm-provider-schema-resource-shape-comparison.md) | 5 | 0 | 5 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.SecurityInsights](sdk/securityinsights/Azure.ResourceManager.SecurityInsights/arm-provider-schema-resource-shape-comparison.md) | 5 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 5 |
| [Azure.ResourceManager.AppContainers](sdk/containerapps/Azure.ResourceManager.AppContainers/arm-provider-schema-resource-shape-comparison.md) | 4 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 2 |
| [Azure.ResourceManager.Elastic](sdk/elastic/Azure.ResourceManager.Elastic/arm-provider-schema-resource-shape-comparison.md) | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 4 |
| [Azure.ResourceManager.GuestConfiguration](sdk/guestconfiguration/Azure.ResourceManager.GuestConfiguration/arm-provider-schema-resource-shape-comparison.md) | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Kusto](sdk/kusto/Azure.ResourceManager.Kusto/arm-provider-schema-resource-shape-comparison.md) | 4 | 2 | 0 | 0 | 0 | 2 | 0 | 0 | 0 |
| [Azure.ResourceManager.ManagedApplications](sdk/managedapplications/Azure.ResourceManager.ManagedApplications/arm-provider-schema-resource-shape-comparison.md) | 4 | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Nginx](sdk/nginx/Azure.ResourceManager.Nginx/arm-provider-schema-resource-shape-comparison.md) | 4 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 4 |
| [Azure.ResourceManager.Resources.Deployments](sdk/resources/Azure.ResourceManager.Resources.Deployments/arm-provider-schema-resource-shape-comparison.md) | 4 | 0 | 4 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ApplicationInsights](sdk/applicationinsights/Azure.ResourceManager.ApplicationInsights/arm-provider-schema-resource-shape-comparison.md) | 3 | 2 | 0 | 0 | 0 | 1 | 0 | 0 | 0 |
| [Azure.ResourceManager.DataProtectionBackup](sdk/dataprotection/Azure.ResourceManager.DataProtectionBackup/arm-provider-schema-resource-shape-comparison.md) | 3 | 0 | 3 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Advisor](sdk/advisor/Azure.ResourceManager.Advisor/arm-provider-schema-resource-shape-comparison.md) | 2 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 0 |
| [Azure.ResourceManager.Batch](sdk/batch/Azure.ResourceManager.Batch/arm-provider-schema-resource-shape-comparison.md) | 2 | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Billing](sdk/billing/Azure.ResourceManager.Billing/arm-provider-schema-resource-shape-comparison.md) | 2 | 0 | 0 | 0 | 0 | 2 | 0 | 0 | 0 |
| [Azure.ResourceManager.Compute](sdk/compute/Azure.ResourceManager.Compute/arm-provider-schema-resource-shape-comparison.md) | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.ComputeBulkActions](sdk/computebulkactions/Azure.ResourceManager.ComputeBulkActions/arm-provider-schema-resource-shape-comparison.md) | 2 | 0 | 1 | 0 | 0 | 0 | 1 | 0 | 0 |
| [Azure.ResourceManager.ContainerRegistry](sdk/containerregistry/Azure.ResourceManager.ContainerRegistry/arm-provider-schema-resource-shape-comparison.md) | 2 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 0 |
| [Azure.ResourceManager.Datadog](sdk/datadog/Azure.ResourceManager.Datadog/arm-provider-schema-resource-shape-comparison.md) | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 2 |
| [Azure.ResourceManager.EventHubs](sdk/eventhub/Azure.ResourceManager.EventHubs/arm-provider-schema-resource-shape-comparison.md) | 2 | 2 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.IotHub](sdk/iothub/Azure.ResourceManager.IotHub/arm-provider-schema-resource-shape-comparison.md) | 2 | 0 | 1 | 0 | 0 | 1 | 0 | 0 | 0 |
| [Azure.ResourceManager.Monitor](sdk/monitor/Azure.ResourceManager.Monitor/arm-provider-schema-resource-shape-comparison.md) | 2 | 0 | 0 | 1 | 0 | 0 | 0 | 1 | 0 |
| [Azure.ResourceManager.OperationalInsights](sdk/operationalinsights/Azure.ResourceManager.OperationalInsights/arm-provider-schema-resource-shape-comparison.md) | 2 | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.RecoveryServices](sdk/recoveryservices/Azure.ResourceManager.RecoveryServices/arm-provider-schema-resource-shape-comparison.md) | 2 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.ResourceHealth](sdk/resourcehealth/Azure.ResourceManager.ResourceHealth/arm-provider-schema-resource-shape-comparison.md) | 2 | 0 | 0 | 0 | 0 | 1 | 1 | 0 | 0 |
| [Azure.ResourceManager.AppConfiguration](sdk/appconfiguration/Azure.ResourceManager.AppConfiguration/arm-provider-schema-resource-shape-comparison.md) | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.BotService](sdk/botservice/Azure.ResourceManager.BotService/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.CognitiveServices](sdk/cognitiveservices/Azure.ResourceManager.CognitiveServices/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.ContainerInstance](sdk/containerinstance/Azure.ResourceManager.ContainerInstance/arm-provider-schema-resource-shape-comparison.md) | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DataBoxEdge](sdk/databoxedge/Azure.ResourceManager.DataBoxEdge/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.DeviceProvisioningServices](sdk/deviceprovisioningservices/Azure.ResourceManager.DeviceProvisioningServices/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Grafana](sdk/grafana/Azure.ResourceManager.Grafana/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.HorizonDB](sdk/horizondb/Azure.ResourceManager.HorizonDB/arm-provider-schema-resource-shape-comparison.md) | 1 | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.HybridCompute](sdk/hybridcompute/Azure.ResourceManager.HybridCompute/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 |
| [Azure.ResourceManager.Monitor.Slis](sdk/monitor/Azure.ResourceManager.Monitor.Slis/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 |
| [Azure.ResourceManager.MySql](sdk/mysql/Azure.ResourceManager.MySql/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.ProviderHub](sdk/providerhub/Azure.ResourceManager.ProviderHub/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.RecoveryServicesSiteRecovery](sdk/recoveryservices-siterecovery/Azure.ResourceManager.RecoveryServicesSiteRecovery/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 0 |
| [Azure.ResourceManager.Search](sdk/search/Azure.ResourceManager.Search/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 0 | 0 | 0 | 0 | 0 | 0 | 1 |
| [Azure.ResourceManager.SiteManager](sdk/sitemanager/Azure.ResourceManager.SiteManager/arm-provider-schema-resource-shape-comparison.md) | 1 | 0 | 0 | 0 | 0 | 0 | 1 | 0 | 0 |
