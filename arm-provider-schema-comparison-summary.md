# ARM provider schema comparison progress

Generated comparison reports for 195 SDK libraries with paired `arm-provider-schema.legacy.json` and `arm-provider-schema.resolve-arm-resources.json` snapshots.

## Overall summary

| Metric | Count |
| --- | ---: |
| Libraries processed | 195 |
| No requested-axis differences | 86 |
| Resource ID pattern coverage differences | 49 |
| Hierarchy differences | 18 |
| Resource model differences | 16 |
| CRUD operation differences | 40 |
| List/action operation differences | 83 |

## Resource ID pattern mismatch ranking

Resource ID pattern mismatches count patterns present on only one side of the comparison: `legacy-only + resolveArmResources-only`. Libraries are sorted by the total mismatch count descending.

| Category | Libraries |
| --- | ---: |
| No resource ID pattern mismatches | 146 |
| 1-2 mismatches | 23 |
| 3-9 mismatches | 23 |
| 10+ mismatches | 3 |

| Rank | Library | Total mismatches | Legacy-only | `resolveArmResources`-only | Report |
| ---: | --- | ---: | ---: | ---: | --- |
| 1 | `Azure.ResourceManager.Network` | 140 | 140 | 0 | [report](sdk/network/Azure.ResourceManager.Network/arm-provider-schema-comparison.md) |
| 2 | `Azure.ResourceManager.DevTestLabs` | 30 | 15 | 15 | [report](sdk/devtestlabs/Azure.ResourceManager.DevTestLabs/arm-provider-schema-comparison.md) |
| 3 | `Azure.ResourceManager.Resources.Policy` | 11 | 0 | 11 | [report](sdk/resources/Azure.ResourceManager.Resources.Policy/arm-provider-schema-comparison.md) |
| 4 | `Azure.ResourceManager.Automation` | 9 | 0 | 9 | [report](sdk/automation/Azure.ResourceManager.Automation/arm-provider-schema-comparison.md) |
| 5 | `Azure.ResourceManager.NetApp` | 9 | 0 | 9 | [report](sdk/netapp/Azure.ResourceManager.NetApp/arm-provider-schema-comparison.md) |
| 6 | `Azure.ResourceManager.RecoveryServicesBackup` | 9 | 0 | 9 | [report](sdk/recoveryservices-backup/Azure.ResourceManager.RecoveryServicesBackup/arm-provider-schema-comparison.md) |
| 7 | `Azure.ResourceManager.TrafficManager` | 7 | 7 | 0 | [report](sdk/trafficmanager/Azure.ResourceManager.TrafficManager/arm-provider-schema-comparison.md) |
| 8 | `Azure.ResourceManager.HDInsight` | 6 | 0 | 6 | [report](sdk/hdinsight/Azure.ResourceManager.HDInsight/arm-provider-schema-comparison.md) |
| 9 | `Azure.ResourceManager.Monitor.Workspaces` | 6 | 0 | 6 | [report](sdk/monitor/Azure.ResourceManager.Monitor.Workspaces/arm-provider-schema-comparison.md) |
| 10 | `Azure.ResourceManager.Resources.DeploymentStacks` | 6 | 0 | 6 | [report](sdk/resources/Azure.ResourceManager.Resources.DeploymentStacks/arm-provider-schema-comparison.md) |
| 11 | `Azure.ResourceManager.SecurityCenter` | 6 | 4 | 2 | [report](sdk/securitycenter/Azure.ResourceManager.SecurityCenter/arm-provider-schema-comparison.md) |
| 12 | `Azure.ResourceManager.FrontDoor` | 6 | 6 | 0 | [report](sdk/frontdoor/Azure.ResourceManager.FrontDoor/arm-provider-schema-comparison.md) |
| 13 | `Azure.ResourceManager.ResilienceManagement` | 5 | 0 | 5 | [report](sdk/azureresiliencemanagement/Azure.ResourceManager.ResilienceManagement/arm-provider-schema-comparison.md) |
| 14 | `Azure.ResourceManager.Sql` | 5 | 2 | 3 | [report](sdk/sqlmanagement/Azure.ResourceManager.Sql/arm-provider-schema-comparison.md) |
| 15 | `Azure.ResourceManager.Storage` | 5 | 2 | 3 | [report](sdk/storage/Azure.ResourceManager.Storage/arm-provider-schema-comparison.md) |
| 16 | `Azure.ResourceManager.CosmosDB` | 5 | 3 | 2 | [report](sdk/cosmosdb/Azure.ResourceManager.CosmosDB/arm-provider-schema-comparison.md) |
| 17 | `Azure.ResourceManager.AppService` | 5 | 4 | 1 | [report](sdk/websites/Azure.ResourceManager.AppService/arm-provider-schema-comparison.md) |
| 18 | `Azure.ResourceManager.EventGrid` | 5 | 5 | 0 | [report](sdk/eventgrid/Azure.ResourceManager.EventGrid/arm-provider-schema-comparison.md) |
| 19 | `Azure.ResourceManager.KeyVault` | 4 | 0 | 4 | [report](sdk/keyvault/Azure.ResourceManager.KeyVault/arm-provider-schema-comparison.md) |
| 20 | `Azure.ResourceManager.Resources.Deployments` | 4 | 0 | 4 | [report](sdk/resources/Azure.ResourceManager.Resources.Deployments/arm-provider-schema-comparison.md) |
| 21 | `Azure.ResourceManager.PolicyInsights` | 4 | 2 | 2 | [report](sdk/policyinsights/Azure.ResourceManager.PolicyInsights/arm-provider-schema-comparison.md) |
| 22 | `Azure.ResourceManager.GuestConfiguration` | 4 | 4 | 0 | [report](sdk/guestconfiguration/Azure.ResourceManager.GuestConfiguration/arm-provider-schema-comparison.md) |
| 23 | `Azure.ResourceManager.DataProtectionBackup` | 3 | 0 | 3 | [report](sdk/dataprotection/Azure.ResourceManager.DataProtectionBackup/arm-provider-schema-comparison.md) |
| 24 | `Azure.ResourceManager.OperationalInsights` | 3 | 1 | 2 | [report](sdk/operationalinsights/Azure.ResourceManager.OperationalInsights/arm-provider-schema-comparison.md) |
| 25 | `Azure.ResourceManager.Monitor` | 3 | 2 | 1 | [report](sdk/monitor/Azure.ResourceManager.Monitor/arm-provider-schema-comparison.md) |
| 26 | `Azure.ResourceManager.AppContainers` | 3 | 3 | 0 | [report](sdk/containerapps/Azure.ResourceManager.AppContainers/arm-provider-schema-comparison.md) |
| 27 | `Azure.ResourceManager.ConnectedCache` | 2 | 0 | 2 | [report](sdk/connectedcache/Azure.ResourceManager.ConnectedCache/arm-provider-schema-comparison.md) |
| 28 | `Azure.ResourceManager.DeviceRegistry` | 2 | 0 | 2 | [report](sdk/deviceregistry/Azure.ResourceManager.DeviceRegistry/arm-provider-schema-comparison.md) |
| 29 | `Azure.ResourceManager.Hci.Vm` | 2 | 0 | 2 | [report](sdk/azurestackhci/Azure.ResourceManager.Hci.Vm/arm-provider-schema-comparison.md) |
| 30 | `Azure.ResourceManager.ApiManagement` | 2 | 1 | 1 | [report](sdk/apimanagement/Azure.ResourceManager.ApiManagement/arm-provider-schema-comparison.md) |
| 31 | `Azure.ResourceManager.ContainerRegistry` | 2 | 1 | 1 | [report](sdk/containerregistry/Azure.ResourceManager.ContainerRegistry/arm-provider-schema-comparison.md) |
| 32 | `Azure.ResourceManager.Compute` | 2 | 2 | 0 | [report](sdk/compute/Azure.ResourceManager.Compute/arm-provider-schema-comparison.md) |
| 33 | `Azure.ResourceManager.Kusto` | 2 | 2 | 0 | [report](sdk/kusto/Azure.ResourceManager.Kusto/arm-provider-schema-comparison.md) |
| 34 | `Azure.ResourceManager.Batch` | 1 | 0 | 1 | [report](sdk/batch/Azure.ResourceManager.Batch/arm-provider-schema-comparison.md) |
| 35 | `Azure.ResourceManager.CognitiveServices` | 1 | 0 | 1 | [report](sdk/cognitiveservices/Azure.ResourceManager.CognitiveServices/arm-provider-schema-comparison.md) |
| 36 | `Azure.ResourceManager.Compute.BulkActions` | 1 | 0 | 1 | [report](sdk/compute/Azure.ResourceManager.Compute.BulkActions/arm-provider-schema-comparison.md) |
| 37 | `Azure.ResourceManager.ComputeBulkActions` | 1 | 0 | 1 | [report](sdk/computebulkactions/Azure.ResourceManager.ComputeBulkActions/arm-provider-schema-comparison.md) |
| 38 | `Azure.ResourceManager.ConfidentialLedger` | 1 | 0 | 1 | [report](sdk/confidentialledger/Azure.ResourceManager.ConfidentialLedger/arm-provider-schema-comparison.md) |
| 39 | `Azure.ResourceManager.DataBoxEdge` | 1 | 0 | 1 | [report](sdk/databoxedge/Azure.ResourceManager.DataBoxEdge/arm-provider-schema-comparison.md) |
| 40 | `Azure.ResourceManager.DeviceProvisioningServices` | 1 | 0 | 1 | [report](sdk/deviceprovisioningservices/Azure.ResourceManager.DeviceProvisioningServices/arm-provider-schema-comparison.md) |
| 41 | `Azure.ResourceManager.IotHub` | 1 | 0 | 1 | [report](sdk/iothub/Azure.ResourceManager.IotHub/arm-provider-schema-comparison.md) |
| 42 | `Azure.ResourceManager.MySql` | 1 | 0 | 1 | [report](sdk/mysql/Azure.ResourceManager.MySql/arm-provider-schema-comparison.md) |
| 43 | `Azure.ResourceManager.ProviderHub` | 1 | 0 | 1 | [report](sdk/providerhub/Azure.ResourceManager.ProviderHub/arm-provider-schema-comparison.md) |
| 44 | `Azure.ResourceManager.RecoveryServices` | 1 | 0 | 1 | [report](sdk/recoveryservices/Azure.ResourceManager.RecoveryServices/arm-provider-schema-comparison.md) |
| 45 | `Azure.ResourceManager.RecoveryServicesSiteRecovery` | 1 | 0 | 1 | [report](sdk/recoveryservices-siterecovery/Azure.ResourceManager.RecoveryServicesSiteRecovery/arm-provider-schema-comparison.md) |
| 46 | `Azure.ResourceManager.StorageDiscovery` | 1 | 0 | 1 | [report](sdk/storagediscovery/Azure.ResourceManager.StorageDiscovery/arm-provider-schema-comparison.md) |
| 47 | `Azure.ResourceManager.AppConfiguration` | 1 | 1 | 0 | [report](sdk/appconfiguration/Azure.ResourceManager.AppConfiguration/arm-provider-schema-comparison.md) |
| 48 | `Azure.ResourceManager.ContainerInstance` | 1 | 1 | 0 | [report](sdk/containerinstance/Azure.ResourceManager.ContainerInstance/arm-provider-schema-comparison.md) |
| 49 | `Azure.ResourceManager.HorizonDB` | 1 | 1 | 0 | [report](sdk/horizondb/Azure.ResourceManager.HorizonDB/arm-provider-schema-comparison.md) |

## Per-library progress

| Library | Report | Summary |
| --- | --- | --- |
| `Azure.ResourceManager.Advisor` | [report](sdk/advisor/Azure.ResourceManager.Advisor/arm-provider-schema-comparison.md) | Only one requested-axis difference: `resolveArmResources` adds one subscription-scoped list operation, and that addition makes sense. |
| `Azure.ResourceManager.AgriculturePlatform` | [report](sdk/agricultureplatform/Azure.ResourceManager.AgriculturePlatform/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.AlertProcessingRules` | [report](sdk/alertsmanagement/Azure.ResourceManager.AlertProcessingRules/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ApiCenter` | [report](sdk/apicenter/Azure.ResourceManager.ApiCenter/arm-provider-schema-comparison.md) | 4 list/action operation differences. |
| `Azure.ResourceManager.ApiManagement` | [report](sdk/apimanagement/Azure.ResourceManager.ApiManagement/arm-provider-schema-comparison.md) | 1 legacy-only and 1 resolve-only resource ID patterns; 3 resource model differences; 5 CRUD operation differences; 17 list/action operation differences. |
| `Azure.ResourceManager.AppComplianceAutomation` | [report](sdk/appcomplianceautomation/Azure.ResourceManager.AppComplianceAutomation/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.AppConfiguration` | [report](sdk/appconfiguration/Azure.ResourceManager.AppConfiguration/arm-provider-schema-comparison.md) | 1 legacy-only and 0 resolve-only resource ID patterns; 2 list/action operation differences. |
| `Azure.ResourceManager.AppNetwork` | [report](sdk/appnetwork/Azure.ResourceManager.AppNetwork/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.ArizeAIObservabilityEval` | [report](sdk/arizeaiobservabilityeval/Azure.ResourceManager.ArizeAIObservabilityEval/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ArtifactSigning` | [report](sdk/artifactsigning/Azure.ResourceManager.ArtifactSigning/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Astro` | [report](sdk/astronomer/Azure.ResourceManager.Astro/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Attestation` | [report](sdk/attestation/Azure.ResourceManager.Attestation/arm-provider-schema-comparison.md) | 1 hierarchy difference. |
| `Azure.ResourceManager.Automation` | [report](sdk/automation/Azure.ResourceManager.Automation/arm-provider-schema-comparison.md) | 0 legacy-only and 9 resolve-only resource ID patterns; 5 list/action operation differences. |
| `Azure.ResourceManager.Avs` | [report](sdk/avs/Azure.ResourceManager.Avs/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.LargeInstance` | [report](sdk/azurelargeinstance/Azure.ResourceManager.LargeInstance/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ResilienceManagement` | [report](sdk/azureresiliencemanagement/Azure.ResourceManager.ResilienceManagement/arm-provider-schema-comparison.md) | 0 legacy-only and 5 resolve-only resource ID patterns; 4 list/action operation differences. |
| `Azure.ResourceManager.Hci` | [report](sdk/azurestackhci/Azure.ResourceManager.Hci/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.Hci.Vm` | [report](sdk/azurestackhci/Azure.ResourceManager.Hci.Vm/arm-provider-schema-comparison.md) | 0 legacy-only and 2 resolve-only resource ID patterns; 2 CRUD operation differences; 1 list/action operation difference. |
| `Azure.ResourceManager.Batch` | [report](sdk/batch/Azure.ResourceManager.Batch/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns; 1 resource model difference; 1 CRUD operation difference; 1 list/action operation difference. |
| `Azure.ResourceManager.Billing` | [report](sdk/billing/Azure.ResourceManager.Billing/arm-provider-schema-comparison.md) | 5 list/action operation differences. |
| `Azure.ResourceManager.BillingBenefits` | [report](sdk/billingbenefits/Azure.ResourceManager.BillingBenefits/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.BotService` | [report](sdk/botservice/Azure.ResourceManager.BotService/arm-provider-schema-comparison.md) | 3 resource model differences; 1 CRUD operation difference; 1 list/action operation difference. |
| `Azure.ResourceManager.CarbonOptimization` | [report](sdk/carbon/Azure.ResourceManager.CarbonOptimization/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Cdn` | [report](sdk/cdn/Azure.ResourceManager.Cdn/arm-provider-schema-comparison.md) | 1 CRUD operation difference. |
| `Azure.ResourceManager.CertificateRegistration` | [report](sdk/certificateregistration/Azure.ResourceManager.CertificateRegistration/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.Chaos` | [report](sdk/chaos/Azure.ResourceManager.Chaos/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.CloudHealth` | [report](sdk/cloudhealth/Azure.ResourceManager.CloudHealth/arm-provider-schema-comparison.md) | 5 CRUD operation differences. |
| `Azure.ResourceManager.CognitiveServices` | [report](sdk/cognitiveservices/Azure.ResourceManager.CognitiveServices/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns; 23 hierarchy differences; 1 CRUD operation difference; 1 list/action operation difference. |
| `Azure.ResourceManager.Communication` | [report](sdk/communication/Azure.ResourceManager.Communication/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Compute` | [report](sdk/compute/Azure.ResourceManager.Compute/arm-provider-schema-comparison.md) | 2 legacy-only and 0 resolve-only resource ID patterns; 2 resource model differences; 2 list/action operation differences. |
| `Azure.ResourceManager.Compute.BulkActions` | [report](sdk/compute/Azure.ResourceManager.Compute.BulkActions/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns. |
| `Azure.ResourceManager.ComputeBulkActions` | [report](sdk/computebulkactions/Azure.ResourceManager.ComputeBulkActions/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns; 1 hierarchy difference. |
| `Azure.ResourceManager.ComputeFleet` | [report](sdk/computefleet/Azure.ResourceManager.ComputeFleet/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ComputeLimit` | [report](sdk/computelimit/Azure.ResourceManager.ComputeLimit/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.Compute.Recommender` | [report](sdk/computerecommender/Azure.ResourceManager.Compute.Recommender/arm-provider-schema-comparison.md) | 1 resource model difference. |
| `Azure.ResourceManager.ComputeSchedule` | [report](sdk/computeschedule/Azure.ResourceManager.ComputeSchedule/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ConfidentialLedger` | [report](sdk/confidentialledger/Azure.ResourceManager.ConfidentialLedger/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns; 1 list/action operation difference. |
| `Azure.ResourceManager.Confluent` | [report](sdk/confluent/Azure.ResourceManager.Confluent/arm-provider-schema-comparison.md) | 5 CRUD operation differences; 3 list/action operation differences. |
| `Azure.ResourceManager.ConnectedCache` | [report](sdk/connectedcache/Azure.ResourceManager.ConnectedCache/arm-provider-schema-comparison.md) | 0 legacy-only and 2 resolve-only resource ID patterns. |
| `Azure.ResourceManager.Consumption` | [report](sdk/consumption/Azure.ResourceManager.Consumption/arm-provider-schema-comparison.md) | 1 hierarchy difference; 1 resource model difference. |
| `Azure.ResourceManager.AppContainers` | [report](sdk/containerapps/Azure.ResourceManager.AppContainers/arm-provider-schema-comparison.md) | 3 legacy-only and 0 resolve-only resource ID patterns; 3 CRUD operation differences; 4 list/action operation differences. |
| `Azure.ResourceManager.ContainerInstance` | [report](sdk/containerinstance/Azure.ResourceManager.ContainerInstance/arm-provider-schema-comparison.md) | 1 legacy-only and 0 resolve-only resource ID patterns. |
| `Azure.ResourceManager.ContainerOrchestratorRuntime` | [report](sdk/containerorchestratorruntime/Azure.ResourceManager.ContainerOrchestratorRuntime/arm-provider-schema-comparison.md) | 2 CRUD operation differences. |
| `Azure.ResourceManager.ContainerRegistry` | [report](sdk/containerregistry/Azure.ResourceManager.ContainerRegistry/arm-provider-schema-comparison.md) | 1 legacy-only and 1 resolve-only resource ID patterns. |
| `Azure.ResourceManager.ContainerRegistry.Tasks` | [report](sdk/containerregistry/Azure.ResourceManager.ContainerRegistry.Tasks/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ContainerService` | [report](sdk/containerservice/Azure.ResourceManager.ContainerService/arm-provider-schema-comparison.md) | 2 list/action operation differences. |
| `Azure.ResourceManager.CosmosDB` | [report](sdk/cosmosdb/Azure.ResourceManager.CosmosDB/arm-provider-schema-comparison.md) | 3 legacy-only and 2 resolve-only resource ID patterns; 2 CRUD operation differences; 2 list/action operation differences. |
| `Azure.ResourceManager.CosmosDBForPostgreSql` | [report](sdk/cosmosdbforpostgresql/Azure.ResourceManager.CosmosDBForPostgreSql/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.CostManagement` | [report](sdk/costmanagement/Azure.ResourceManager.CostManagement/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.DatabaseWatcher` | [report](sdk/databasewatcher/Azure.ResourceManager.DatabaseWatcher/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.DataBox` | [report](sdk/databox/Azure.ResourceManager.DataBox/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.DataBoxEdge` | [report](sdk/databoxedge/Azure.ResourceManager.DataBoxEdge/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns. |
| `Azure.ResourceManager.Datadog` | [report](sdk/datadog/Azure.ResourceManager.Datadog/arm-provider-schema-comparison.md) | 2 CRUD operation differences. |
| `Azure.ResourceManager.DataFactory` | [report](sdk/datafactory/Azure.ResourceManager.DataFactory/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.DataMigration` | [report](sdk/datamigration/Azure.ResourceManager.DataMigration/arm-provider-schema-comparison.md) | 4 hierarchy differences. |
| `Azure.ResourceManager.DataProtectionBackup` | [report](sdk/dataprotection/Azure.ResourceManager.DataProtectionBackup/arm-provider-schema-comparison.md) | 0 legacy-only and 3 resolve-only resource ID patterns; 6 hierarchy differences; 1 CRUD operation difference. |
| `Azure.ResourceManager.Dell.Storage` | [report](sdk/dellstorage/Azure.ResourceManager.Dell.Storage/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.DependencyMap` | [report](sdk/dependencymap/Azure.ResourceManager.DependencyMap/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.DesktopVirtualization` | [report](sdk/desktopvirtualization/Azure.ResourceManager.DesktopVirtualization/arm-provider-schema-comparison.md) | 2 list/action operation differences. |
| `Azure.ResourceManager.DevCenter` | [report](sdk/devcenter/Azure.ResourceManager.DevCenter/arm-provider-schema-comparison.md) | 1 resource model difference; 1 list/action operation difference. |
| `Azure.ResourceManager.DeviceProvisioningServices` | [report](sdk/deviceprovisioningservices/Azure.ResourceManager.DeviceProvisioningServices/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns. |
| `Azure.ResourceManager.DeviceRegistry` | [report](sdk/deviceregistry/Azure.ResourceManager.DeviceRegistry/arm-provider-schema-comparison.md) | 0 legacy-only and 2 resolve-only resource ID patterns; 1 resource model difference; 2 CRUD operation differences; 2 list/action operation differences. |
| `Azure.ResourceManager.DevOpsInfrastructure` | [report](sdk/devopsinfrastructure/Azure.ResourceManager.DevOpsInfrastructure/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.DevTestLabs` | [report](sdk/devtestlabs/Azure.ResourceManager.DevTestLabs/arm-provider-schema-comparison.md) | 15 legacy-only and 15 resolve-only resource ID patterns; 5 list/action operation differences. |
| `Azure.ResourceManager.DisconnectedOperations` | [report](sdk/disconnectedoperations/Azure.ResourceManager.DisconnectedOperations/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Dns` | [report](sdk/dns/Azure.ResourceManager.Dns/arm-provider-schema-comparison.md) | 13 CRUD operation differences; 14 list/action operation differences. |
| `Azure.ResourceManager.DnsResolver` | [report](sdk/dnsresolver/Azure.ResourceManager.DnsResolver/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.DomainRegistration` | [report](sdk/domainregistration/Azure.ResourceManager.DomainRegistration/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.DurableTask` | [report](sdk/durabletask/Azure.ResourceManager.DurableTask/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Dynatrace` | [report](sdk/dynatrace/Azure.ResourceManager.Dynatrace/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.EdgeActions` | [report](sdk/edgeactions/Azure.ResourceManager.EdgeActions/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.EdgeOrder` | [report](sdk/edgeorder/Azure.ResourceManager.EdgeOrder/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.EdgeZones` | [report](sdk/edgezones/Azure.ResourceManager.EdgeZones/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Elastic` | [report](sdk/elastic/Azure.ResourceManager.Elastic/arm-provider-schema-comparison.md) | 4 CRUD operation differences; 1 list/action operation difference. |
| `Azure.ResourceManager.ElasticSan` | [report](sdk/elasticsan/Azure.ResourceManager.ElasticSan/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.EventGrid` | [report](sdk/eventgrid/Azure.ResourceManager.EventGrid/arm-provider-schema-comparison.md) | 5 legacy-only and 0 resolve-only resource ID patterns; 1 hierarchy difference; 2 list/action operation differences. |
| `Azure.ResourceManager.EventHubs` | [report](sdk/eventhub/Azure.ResourceManager.EventHubs/arm-provider-schema-comparison.md) | 2 resource model differences; 1 CRUD operation difference; 3 list/action operation differences. |
| `Azure.ResourceManager.ExtendedLocations` | [report](sdk/extendedlocation/Azure.ResourceManager.ExtendedLocations/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Fabric` | [report](sdk/fabric/Azure.ResourceManager.Fabric/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.FileShares` | [report](sdk/fileshares/Azure.ResourceManager.FileShares/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ContainerServiceFleet` | [report](sdk/fleet/Azure.ResourceManager.ContainerServiceFleet/arm-provider-schema-comparison.md) | 2 CRUD operation differences. |
| `Azure.ResourceManager.FrontDoor` | [report](sdk/frontdoor/Azure.ResourceManager.FrontDoor/arm-provider-schema-comparison.md) | 6 legacy-only and 0 resolve-only resource ID patterns. |
| `Azure.ResourceManager.Grafana` | [report](sdk/grafana/Azure.ResourceManager.Grafana/arm-provider-schema-comparison.md) | 1 CRUD operation difference; 1 list/action operation difference. |
| `Azure.ResourceManager.GuestConfiguration` | [report](sdk/guestconfiguration/Azure.ResourceManager.GuestConfiguration/arm-provider-schema-comparison.md) | 4 legacy-only and 0 resolve-only resource ID patterns. |
| `Azure.ResourceManager.HardwareSecurityModules` | [report](sdk/hardwaresecuritymodules/Azure.ResourceManager.HardwareSecurityModules/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.HDInsight` | [report](sdk/hdinsight/Azure.ResourceManager.HDInsight/arm-provider-schema-comparison.md) | 0 legacy-only and 6 resolve-only resource ID patterns; 1 CRUD operation difference; 1 list/action operation difference. |
| `Azure.ResourceManager.HealthBot` | [report](sdk/healthbot/Azure.ResourceManager.HealthBot/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.HealthcareApis` | [report](sdk/healthcareapis/Azure.ResourceManager.HealthcareApis/arm-provider-schema-comparison.md) | 3 CRUD operation differences; 1 list/action operation difference. |
| `Azure.ResourceManager.HealthDataAIServices` | [report](sdk/healthdataaiservices/Azure.ResourceManager.HealthDataAIServices/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.HorizonDB` | [report](sdk/horizondb/Azure.ResourceManager.HorizonDB/arm-provider-schema-comparison.md) | 1 legacy-only and 0 resolve-only resource ID patterns; 2 list/action operation differences. |
| `Azure.ResourceManager.HybridCompute` | [report](sdk/hybridcompute/Azure.ResourceManager.HybridCompute/arm-provider-schema-comparison.md) | 1 hierarchy difference; 1 list/action operation difference. |
| `Azure.ResourceManager.HybridConnectivity` | [report](sdk/hybridconnectivity/Azure.ResourceManager.HybridConnectivity/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Kubernetes` | [report](sdk/hybridkubernetes/Azure.ResourceManager.Kubernetes/arm-provider-schema-comparison.md) | 1 CRUD operation difference. |
| `Azure.ResourceManager.HybridNetwork` | [report](sdk/hybridnetwork/Azure.ResourceManager.HybridNetwork/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ImpactReporting` | [report](sdk/impactreporting/Azure.ResourceManager.ImpactReporting/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.InformaticaDataManagement` | [report](sdk/informaticadatamanagement/Azure.ResourceManager.InformaticaDataManagement/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.IotHub` | [report](sdk/iothub/Azure.ResourceManager.IotHub/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns; 1 list/action operation difference. |
| `Azure.ResourceManager.IotOperations` | [report](sdk/iotoperations/Azure.ResourceManager.IotOperations/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.KeyVault` | [report](sdk/keyvault/Azure.ResourceManager.KeyVault/arm-provider-schema-comparison.md) | 0 legacy-only and 4 resolve-only resource ID patterns. |
| `Azure.ResourceManager.KubernetesConfiguration.Extensions` | [report](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.Extensions/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.KubernetesConfiguration.PrivateLinkScopes` | [report](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.PrivateLinkScopes/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Kusto` | [report](sdk/kusto/Azure.ResourceManager.Kusto/arm-provider-schema-comparison.md) | 2 legacy-only and 0 resolve-only resource ID patterns; 3 list/action operation differences. |
| `Azure.ResourceManager.LambdaTestHyperExecute` | [report](sdk/lambdatesthyperexecute/Azure.ResourceManager.LambdaTestHyperExecute/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.LoadTesting` | [report](sdk/loadtestservice/Azure.ResourceManager.LoadTesting/arm-provider-schema-comparison.md) | 1 hierarchy difference; 1 resource model difference; 1 list/action operation difference. |
| `Azure.ResourceManager.MachineLearning` | [report](sdk/machinelearningservices/Azure.ResourceManager.MachineLearning/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.Maintenance` | [report](sdk/maintenance/Azure.ResourceManager.Maintenance/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.ManagedNetworkFabric` | [report](sdk/managednetworkfabric/Azure.ResourceManager.ManagedNetworkFabric/arm-provider-schema-comparison.md) | 1 resource model difference; 12 list/action operation differences. |
| `Azure.ResourceManager.ManagedOps` | [report](sdk/managedops/Azure.ResourceManager.ManagedOps/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ManagedServiceIdentities` | [report](sdk/managedserviceidentity/Azure.ResourceManager.ManagedServiceIdentities/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Maps` | [report](sdk/maps/Azure.ResourceManager.Maps/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Marketplace` | [report](sdk/marketplace/Azure.ResourceManager.Marketplace/arm-provider-schema-comparison.md) | 3 list/action operation differences. |
| `Azure.ResourceManager.MongoCluster` | [report](sdk/mongocluster/Azure.ResourceManager.MongoCluster/arm-provider-schema-comparison.md) | 1 CRUD operation difference; 1 list/action operation difference. |
| `Azure.ResourceManager.MongoDBAtlas` | [report](sdk/mongodbatlas/Azure.ResourceManager.MongoDBAtlas/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Monitor` | [report](sdk/monitor/Azure.ResourceManager.Monitor/arm-provider-schema-comparison.md) | 2 legacy-only and 1 resolve-only resource ID patterns; 3 list/action operation differences. |
| `Azure.ResourceManager.Monitor.Slis` | [report](sdk/monitor/Azure.ResourceManager.Monitor.Slis/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Monitor.Workspaces` | [report](sdk/monitor/Azure.ResourceManager.Monitor.Workspaces/arm-provider-schema-comparison.md) | 0 legacy-only and 6 resolve-only resource ID patterns; 1 list/action operation difference. |
| `Azure.ResourceManager.Monitor.PipelineGroups` | [report](sdk/monitorpipelinegroups/Azure.ResourceManager.Monitor.PipelineGroups/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.MySql` | [report](sdk/mysql/Azure.ResourceManager.MySql/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns; 1 CRUD operation difference; 1 list/action operation difference. |
| `Azure.ResourceManager.NapsterOmniagentApi` | [report](sdk/napsteromniagentapi/Azure.ResourceManager.NapsterOmniagentApi/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.NetApp` | [report](sdk/netapp/Azure.ResourceManager.NetApp/arm-provider-schema-comparison.md) | 0 legacy-only and 9 resolve-only resource ID patterns; 1 CRUD operation difference; 3 list/action operation differences. |
| `Azure.ResourceManager.Network` | [report](sdk/network/Azure.ResourceManager.Network/arm-provider-schema-comparison.md) | 140 legacy-only and 0 resolve-only resource ID patterns. |
| `Azure.ResourceManager.NetworkCloud` | [report](sdk/networkcloud/Azure.ResourceManager.NetworkCloud/arm-provider-schema-comparison.md) | 3 CRUD operation differences; 1 list/action operation difference. |
| `Azure.ResourceManager.NetworkFunction` | [report](sdk/networkfunction/Azure.ResourceManager.NetworkFunction/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.NewRelicObservability` | [report](sdk/newrelicobservability/Azure.ResourceManager.NewRelicObservability/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Nginx` | [report](sdk/nginx/Azure.ResourceManager.Nginx/arm-provider-schema-comparison.md) | 4 CRUD operation differences; 1 list/action operation difference. |
| `Azure.ResourceManager.NotificationHubs` | [report](sdk/notificationhubs/Azure.ResourceManager.NotificationHubs/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.OnlineExperimentation` | [report](sdk/onlineexperimentation/Azure.ResourceManager.OnlineExperimentation/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.OperationalInsights` | [report](sdk/operationalinsights/Azure.ResourceManager.OperationalInsights/arm-provider-schema-comparison.md) | 1 legacy-only and 2 resolve-only resource ID patterns; 1 CRUD operation difference; 2 list/action operation differences. |
| `Azure.ResourceManager.OracleDatabase` | [report](sdk/oracle/Azure.ResourceManager.OracleDatabase/arm-provider-schema-comparison.md) | 3 hierarchy differences; 2 list/action operation differences. |
| `Azure.ResourceManager.PaloAltoNetworks.Ngfw` | [report](sdk/paloaltonetworks.ngfw/Azure.ResourceManager.PaloAltoNetworks.Ngfw/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Peering` | [report](sdk/peering/Azure.ResourceManager.Peering/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.PineconeVectorDB` | [report](sdk/pineconevectordb/Azure.ResourceManager.PineconeVectorDB/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.PlanetaryComputer` | [report](sdk/planetarycomputer/Azure.ResourceManager.PlanetaryComputer/arm-provider-schema-comparison.md) | 1 CRUD operation difference. |
| `Azure.ResourceManager.Playwright` | [report](sdk/playwright/Azure.ResourceManager.Playwright/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.PolicyInsights` | [report](sdk/policyinsights/Azure.ResourceManager.PolicyInsights/arm-provider-schema-comparison.md) | 2 legacy-only and 2 resolve-only resource ID patterns; 1 list/action operation difference. |
| `Azure.ResourceManager.PortalServicesCopilot` | [report](sdk/portalservices/Azure.ResourceManager.PortalServicesCopilot/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.PostgreSql` | [report](sdk/postgresql/Azure.ResourceManager.PostgreSql/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.PowerBIDedicated` | [report](sdk/powerbidedicated/Azure.ResourceManager.PowerBIDedicated/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.PrivateDns` | [report](sdk/privatedns/Azure.ResourceManager.PrivateDns/arm-provider-schema-comparison.md) | 8 CRUD operation differences; 1 list/action operation difference. |
| `Azure.ResourceManager.ProgramEnrollment` | [report](sdk/programenrollment/Azure.ResourceManager.ProgramEnrollment/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ProviderHub` | [report](sdk/providerhub/Azure.ResourceManager.ProviderHub/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns; 1 list/action operation difference. |
| `Azure.ResourceManager.PureStorageBlock` | [report](sdk/purestorageblock/Azure.ResourceManager.PureStorageBlock/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Purview` | [report](sdk/purview/Azure.ResourceManager.Purview/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.Quantum` | [report](sdk/quantum/Azure.ResourceManager.Quantum/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Qumulo` | [report](sdk/qumulo/Azure.ResourceManager.Qumulo/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Quota` | [report](sdk/quota/Azure.ResourceManager.Quota/arm-provider-schema-comparison.md) | 2 hierarchy differences; 2 CRUD operation differences; 1 list/action operation difference. |
| `Azure.ResourceManager.RecoveryServicesBackup` | [report](sdk/recoveryservices-backup/Azure.ResourceManager.RecoveryServicesBackup/arm-provider-schema-comparison.md) | 0 legacy-only and 9 resolve-only resource ID patterns; 3 resource model differences; 1 CRUD operation difference; 1 list/action operation difference. |
| `Azure.ResourceManager.RecoveryServicesDataReplication` | [report](sdk/recoveryservices-datareplication/Azure.ResourceManager.RecoveryServicesDataReplication/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.RecoveryServicesSiteRecovery` | [report](sdk/recoveryservices-siterecovery/Azure.ResourceManager.RecoveryServicesSiteRecovery/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns; 2 CRUD operation differences; 1 list/action operation difference. |
| `Azure.ResourceManager.RecoveryServices` | [report](sdk/recoveryservices/Azure.ResourceManager.RecoveryServices/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns; 1 hierarchy difference; 1 resource model difference; 1 CRUD operation difference; 1 list/action operation difference. |
| `Azure.ResourceManager.RedHatOpenShift` | [report](sdk/redhatopenshift/Azure.ResourceManager.RedHatOpenShift/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Redis` | [report](sdk/redis/Azure.ResourceManager.Redis/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.RedisEnterprise` | [report](sdk/redisenterprise/Azure.ResourceManager.RedisEnterprise/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Relationships` | [report](sdk/relationships/Azure.ResourceManager.Relationships/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Relay` | [report](sdk/relay/Azure.ResourceManager.Relay/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Reservations` | [report](sdk/reservations/Azure.ResourceManager.Reservations/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.ResourceConnector` | [report](sdk/resourceconnector/Azure.ResourceManager.ResourceConnector/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ResourceGraph` | [report](sdk/resourcegraph/Azure.ResourceManager.ResourceGraph/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ResourceHealth` | [report](sdk/resourcehealth/Azure.ResourceManager.ResourceHealth/arm-provider-schema-comparison.md) | 1 hierarchy difference; 2 list/action operation differences. |
| `Azure.ResourceManager.Resources.Bicep` | [report](sdk/resources/Azure.ResourceManager.Resources.Bicep/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Resources.DeploymentStacks` | [report](sdk/resources/Azure.ResourceManager.Resources.DeploymentStacks/arm-provider-schema-comparison.md) | 0 legacy-only and 6 resolve-only resource ID patterns. |
| `Azure.ResourceManager.Resources.Deployments` | [report](sdk/resources/Azure.ResourceManager.Resources.Deployments/arm-provider-schema-comparison.md) | 0 legacy-only and 4 resolve-only resource ID patterns; 1 list/action operation difference. |
| `Azure.ResourceManager.Resources.Policy` | [report](sdk/resources/Azure.ResourceManager.Resources.Policy/arm-provider-schema-comparison.md) | 0 legacy-only and 11 resolve-only resource ID patterns; 2 hierarchy differences; 2 list/action operation differences. |
| `Azure.ResourceManager.Search` | [report](sdk/search/Azure.ResourceManager.Search/arm-provider-schema-comparison.md) | 1 CRUD operation difference; 1 list/action operation difference. |
| `Azure.ResourceManager.SecretsStoreExtension` | [report](sdk/secretsstoreextension/Azure.ResourceManager.SecretsStoreExtension/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.SecurityCenter` | [report](sdk/securitycenter/Azure.ResourceManager.SecurityCenter/arm-provider-schema-comparison.md) | 4 legacy-only and 2 resolve-only resource ID patterns; 8 hierarchy differences; 1 CRUD operation difference; 11 list/action operation differences. |
| `Azure.ResourceManager.SecurityInsights` | [report](sdk/securityinsights/Azure.ResourceManager.SecurityInsights/arm-provider-schema-comparison.md) | 1 resource model difference; 5 CRUD operation differences; 2 list/action operation differences. |
| `Azure.ResourceManager.SelfHelp` | [report](sdk/selfhelp/Azure.ResourceManager.SelfHelp/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ServiceBus` | [report](sdk/servicebus/Azure.ResourceManager.ServiceBus/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ServiceFabric` | [report](sdk/servicefabric/Azure.ResourceManager.ServiceFabric/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.ServiceFabricManagedClusters` | [report](sdk/servicefabricmanagedclusters/Azure.ResourceManager.ServiceFabricManagedClusters/arm-provider-schema-comparison.md) | 2 list/action operation differences. |
| `Azure.ResourceManager.ServiceGroups` | [report](sdk/servicegroups/Azure.ResourceManager.ServiceGroups/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.ServiceNetworking` | [report](sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.SignalR` | [report](sdk/signalr/Azure.ResourceManager.SignalR/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.SiteManager` | [report](sdk/sitemanager/Azure.ResourceManager.SiteManager/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Sphere` | [report](sdk/sphere/Azure.ResourceManager.Sphere/arm-provider-schema-comparison.md) | 2 list/action operation differences. |
| `Azure.ResourceManager.Sql` | [report](sdk/sqlmanagement/Azure.ResourceManager.Sql/arm-provider-schema-comparison.md) | 2 legacy-only and 3 resolve-only resource ID patterns; 5 hierarchy differences; 5 resource model differences; 2 CRUD operation differences; 12 list/action operation differences. |
| `Azure.ResourceManager.SqlVirtualMachine` | [report](sdk/sqlvirtualmachine/Azure.ResourceManager.SqlVirtualMachine/arm-provider-schema-comparison.md) | 1 list/action operation difference. |
| `Azure.ResourceManager.StandbyPool` | [report](sdk/standbypool/Azure.ResourceManager.StandbyPool/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Storage` | [report](sdk/storage/Azure.ResourceManager.Storage/arm-provider-schema-comparison.md) | 2 legacy-only and 3 resolve-only resource ID patterns; 2 CRUD operation differences; 2 list/action operation differences. |
| `Azure.ResourceManager.StorageActions` | [report](sdk/storageactions/Azure.ResourceManager.StorageActions/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.StorageCache` | [report](sdk/storagecache/Azure.ResourceManager.StorageCache/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.StorageDiscovery` | [report](sdk/storagediscovery/Azure.ResourceManager.StorageDiscovery/arm-provider-schema-comparison.md) | 0 legacy-only and 1 resolve-only resource ID patterns; 1 list/action operation difference. |
| `Azure.ResourceManager.StorageMover` | [report](sdk/storagemover/Azure.ResourceManager.StorageMover/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.StorageSync` | [report](sdk/storagesync/Azure.ResourceManager.StorageSync/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.Subscription` | [report](sdk/subscription/Azure.ResourceManager.Subscription/arm-provider-schema-comparison.md) | 2 list/action operation differences. |
| `Azure.ResourceManager.Support` | [report](sdk/support/Azure.ResourceManager.Support/arm-provider-schema-comparison.md) | 3 hierarchy differences. |
| `Azure.ResourceManager.Terraform` | [report](sdk/terraform/Azure.ResourceManager.Terraform/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.TrafficManager` | [report](sdk/trafficmanager/Azure.ResourceManager.TrafficManager/arm-provider-schema-comparison.md) | 7 legacy-only and 0 resolve-only resource ID patterns. |
| `Azure.ResourceManager.VirtualEnclaves` | [report](sdk/virtualenclaves/Azure.ResourceManager.VirtualEnclaves/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.WebPubSub` | [report](sdk/webpubsub/Azure.ResourceManager.WebPubSub/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.AppService` | [report](sdk/websites/Azure.ResourceManager.AppService/arm-provider-schema-comparison.md) | 4 legacy-only and 1 resolve-only resource ID patterns; 81 hierarchy differences; 39 resource model differences; 1 CRUD operation difference; 42 list/action operation differences. |
| `Azure.ResourceManager.WeightsAndBiases` | [report](sdk/weightsandbiases/Azure.ResourceManager.WeightsAndBiases/arm-provider-schema-comparison.md) | No requested-axis differences. |
| `Azure.ResourceManager.WorkloadOrchestration` | [report](sdk/workloadorchestration/Azure.ResourceManager.WorkloadOrchestration/arm-provider-schema-comparison.md) | 2 list/action operation differences. |
| `Azure.ResourceManager.WorkloadsSapVirtualInstance` | [report](sdk/workloadssapvirtualinstance/Azure.ResourceManager.WorkloadsSapVirtualInstance/arm-provider-schema-comparison.md) | No requested-axis differences. |
