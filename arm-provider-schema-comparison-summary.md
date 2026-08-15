# ARM provider schema comparison progress

Generated comparison reports for 217 SDK libraries with paired `arm-provider-schema.legacy.json` and `arm-provider-schema.resolve-arm-resources.json` snapshots.

This run filters `resolveArmResources` output to the TCGC code model before comparison: resources whose model is absent from TCGC are removed, and methods absent from TCGC are removed from resources and non-resource methods.

Resource ID pattern summary metrics below normalize path variable names before comparison, so `{name}` and `{labName}` are treated as the same resource identity.

## Overall summary

| Metric | Count |
| --- | ---: |
| Libraries processed | 217 |
| No requested-axis differences after path-variable normalization | 142 |
| Normalized resource ID pattern coverage differences | 38 |
| Raw resource ID differences removed by variable-name normalization | 5 |
| Resource type / hierarchy differences after normalization | 0 |
| Resource model differences after normalization | 0 |
| CRUD operation differences after normalization | 19 |
| List/action operation differences after normalization | 59 |
| Non-resource method differences after normalization | 27 |

## Impact of TCGC filtering vs previous unfiltered run

This compares the filtered snapshots in this commit with the unfiltered snapshots from the previous commit on the same PR branch.

| Metric | Unfiltered overlap | Filtered overlap | Delta |
| --- | ---: | ---: | ---: |
| Libraries processed | 217 | 217 | 0 |
| No requested-axis differences after path-variable normalization | 103 | 142 | +39 |
| Normalized resource ID pattern coverage differences | 51 | 38 | -13 |
| Raw resource ID differences removed by variable-name normalization | 5 | 5 | 0 |
| Resource type / hierarchy differences after normalization | 0 | 0 | 0 |
| Resource model differences after normalization | 4 | 0 | -4 |
| CRUD operation differences after normalization | 33 | 19 | -14 |
| List/action operation differences after normalization | 83 | 59 | -24 |
| Non-resource method differences after normalization | 51 | 27 | -24 |

## Change from previous validation PR

Previous PR #60620 had 195 libraries with paired snapshots. This run has 217; 194 overlap, 23 are new in this run, and 1 was only in the previous PR.

| Metric | Previous overlap | Current filtered overlap | Delta |
| --- | ---: | ---: | ---: |
| Libraries processed | 194 | 194 | 0 |
| No requested-axis differences after path-variable normalization | 82 | 126 | +44 |
| Normalized resource ID pattern coverage differences | 46 | 35 | -11 |
| Raw resource ID differences removed by variable-name normalization | 4 | 4 | 0 |
| Resource type / hierarchy differences after normalization | 11 | 0 | -11 |
| Resource model differences after normalization | 5 | 0 | -5 |
| CRUD operation differences after normalization | 41 | 19 | -22 |
| List/action operation differences after normalization | 82 | 54 | -28 |
| Non-resource method differences after normalization | 51 | 20 | -31 |

## Normalized resource ID pattern mismatch ranking

Resource ID pattern mismatches count patterns present on only one side after replacing every path variable segment with `{}`. Libraries are sorted by the normalized mismatch count descending.

| Category | Libraries |
| --- | ---: |
| No normalized resource ID pattern mismatches | 179 |
| 1-2 mismatches | 18 |
| 3-9 mismatches | 16 |
| 10+ mismatches | 4 |

| Rank | Library | Total normalized mismatches | Legacy-only | `resolveArmResources`-only | Raw mismatch count | Report |
| ---: | --- | ---: | ---: | ---: | ---: | --- |
| 1 | `Azure.ResourceManager.Network` | 140 | 140 | 0 | 140 | [report](sdk/network/Azure.ResourceManager.Network/arm-provider-schema-comparison.md) |
| 2 | `Azure.ResourceManager.Dns` | 13 | 13 | 0 | 13 | [report](sdk/dns/Azure.ResourceManager.Dns/arm-provider-schema-comparison.md) |
| 3 | `Azure.ResourceManager.RecoveryServicesBackup` | 12 | 0 | 12 | 12 | [report](sdk/recoveryservices-backup/Azure.ResourceManager.RecoveryServicesBackup/arm-provider-schema-comparison.md) |
| 4 | `Azure.ResourceManager.Resources.Policy` | 10 | 0 | 10 | 10 | [report](sdk/resources/Azure.ResourceManager.Resources.Policy/arm-provider-schema-comparison.md) |
| 5 | `Azure.ResourceManager.PrivateDns` | 8 | 8 | 0 | 8 | [report](sdk/privatedns/Azure.ResourceManager.PrivateDns/arm-provider-schema-comparison.md) |
| 6 | `Azure.ResourceManager.Automation` | 8 | 0 | 8 | 8 | [report](sdk/automation/Azure.ResourceManager.Automation/arm-provider-schema-comparison.md) |
| 7 | `Azure.ResourceManager.TrafficManager` | 7 | 7 | 0 | 7 | [report](sdk/trafficmanager/Azure.ResourceManager.TrafficManager/arm-provider-schema-comparison.md) |
| 8 | `Azure.ResourceManager.FrontDoor` | 6 | 6 | 0 | 6 | [report](sdk/frontdoor/Azure.ResourceManager.FrontDoor/arm-provider-schema-comparison.md) |
| 9 | `Azure.ResourceManager.HDInsight` | 6 | 0 | 6 | 6 | [report](sdk/hdinsight/Azure.ResourceManager.HDInsight/arm-provider-schema-comparison.md) |
| 10 | `Azure.ResourceManager.Resources.DeploymentStacks` | 6 | 0 | 6 | 6 | [report](sdk/resources/Azure.ResourceManager.Resources.DeploymentStacks/arm-provider-schema-comparison.md) |
| 11 | `Azure.ResourceManager.EventGrid` | 5 | 5 | 0 | 5 | [report](sdk/eventgrid/Azure.ResourceManager.EventGrid/arm-provider-schema-comparison.md) |
| 12 | `Azure.ResourceManager.SecurityCenter` | 5 | 3 | 2 | 5 | [report](sdk/securitycenter/Azure.ResourceManager.SecurityCenter/arm-provider-schema-comparison.md) |
| 13 | `Azure.ResourceManager.PolicyInsights` | 5 | 0 | 5 | 5 | [report](sdk/policyinsights/Azure.ResourceManager.PolicyInsights/arm-provider-schema-comparison.md) |
| 14 | `Azure.ResourceManager.GuestConfiguration` | 4 | 4 | 0 | 4 | [report](sdk/guestconfiguration/Azure.ResourceManager.GuestConfiguration/arm-provider-schema-comparison.md) |
| 15 | `Azure.ResourceManager.ManagedApplications` | 4 | 4 | 0 | 4 | [report](sdk/managedapplications/Azure.ResourceManager.ManagedApplications/arm-provider-schema-comparison.md) |
| 16 | `Azure.ResourceManager.Storage` | 4 | 2 | 2 | 4 | [report](sdk/storage/Azure.ResourceManager.Storage/arm-provider-schema-comparison.md) |
| 17 | `Azure.ResourceManager.Resources.Deployments` | 4 | 0 | 4 | 4 | [report](sdk/resources/Azure.ResourceManager.Resources.Deployments/arm-provider-schema-comparison.md) |
| 18 | `Azure.ResourceManager.Sql` | 3 | 2 | 1 | 3 | [report](sdk/sqlmanagement/Azure.ResourceManager.Sql/arm-provider-schema-comparison.md) |
| 19 | `Azure.ResourceManager.CosmosDB` | 3 | 0 | 3 | 3 | [report](sdk/cosmosdb/Azure.ResourceManager.CosmosDB/arm-provider-schema-comparison.md) |
| 20 | `Azure.ResourceManager.DataProtectionBackup` | 3 | 0 | 3 | 3 | [report](sdk/dataprotection/Azure.ResourceManager.DataProtectionBackup/arm-provider-schema-comparison.md) |
| 21 | `Azure.ResourceManager.ApplicationInsights` | 2 | 2 | 0 | 2 | [report](sdk/applicationinsights/Azure.ResourceManager.ApplicationInsights/arm-provider-schema-comparison.md) |
| 22 | `Azure.ResourceManager.Compute` | 2 | 2 | 0 | 2 | [report](sdk/compute/Azure.ResourceManager.Compute/arm-provider-schema-comparison.md) |
| 23 | `Azure.ResourceManager.EventHubs` | 2 | 2 | 0 | 2 | [report](sdk/eventhub/Azure.ResourceManager.EventHubs/arm-provider-schema-comparison.md) |
| 24 | `Azure.ResourceManager.Kusto` | 2 | 2 | 0 | 2 | [report](sdk/kusto/Azure.ResourceManager.Kusto/arm-provider-schema-comparison.md) |
| 25 | `Azure.ResourceManager.Authorization` | 2 | 1 | 1 | 3 | [report](sdk/authorization/Azure.ResourceManager.Authorization/arm-provider-schema-comparison.md) |
| 26 | `Azure.ResourceManager.Batch` | 2 | 1 | 1 | 2 | [report](sdk/batch/Azure.ResourceManager.Batch/arm-provider-schema-comparison.md) |
| 27 | `Azure.ResourceManager.OperationalInsights` | 2 | 1 | 1 | 2 | [report](sdk/operationalinsights/Azure.ResourceManager.OperationalInsights/arm-provider-schema-comparison.md) |
| 28 | `Azure.ResourceManager.AppConfiguration` | 1 | 1 | 0 | 1 | [report](sdk/appconfiguration/Azure.ResourceManager.AppConfiguration/arm-provider-schema-comparison.md) |
| 29 | `Azure.ResourceManager.ContainerInstance` | 1 | 1 | 0 | 1 | [report](sdk/containerinstance/Azure.ResourceManager.ContainerInstance/arm-provider-schema-comparison.md) |
| 30 | `Azure.ResourceManager.HorizonDB` | 1 | 1 | 0 | 1 | [report](sdk/horizondb/Azure.ResourceManager.HorizonDB/arm-provider-schema-comparison.md) |
| 31 | `Azure.ResourceManager.AppService` | 1 | 0 | 1 | 1 | [report](sdk/websites/Azure.ResourceManager.AppService/arm-provider-schema-comparison.md) |
| 32 | `Azure.ResourceManager.ComputeBulkActions` | 1 | 0 | 1 | 1 | [report](sdk/computebulkactions/Azure.ResourceManager.ComputeBulkActions/arm-provider-schema-comparison.md) |
| 33 | `Azure.ResourceManager.DataBoxEdge` | 1 | 0 | 1 | 1 | [report](sdk/databoxedge/Azure.ResourceManager.DataBoxEdge/arm-provider-schema-comparison.md) |
| 34 | `Azure.ResourceManager.DeviceProvisioningServices` | 1 | 0 | 1 | 1 | [report](sdk/deviceprovisioningservices/Azure.ResourceManager.DeviceProvisioningServices/arm-provider-schema-comparison.md) |
| 35 | `Azure.ResourceManager.IotHub` | 1 | 0 | 1 | 1 | [report](sdk/iothub/Azure.ResourceManager.IotHub/arm-provider-schema-comparison.md) |
| 36 | `Azure.ResourceManager.ProviderHub` | 1 | 0 | 1 | 1 | [report](sdk/providerhub/Azure.ResourceManager.ProviderHub/arm-provider-schema-comparison.md) |
| 37 | `Azure.ResourceManager.RecoveryServices` | 1 | 0 | 1 | 1 | [report](sdk/recoveryservices/Azure.ResourceManager.RecoveryServices/arm-provider-schema-comparison.md) |
| 38 | `Azure.ResourceManager.RecoveryServicesSiteRecovery` | 1 | 0 | 1 | 1 | [report](sdk/recoveryservices-siterecovery/Azure.ResourceManager.RecoveryServicesSiteRecovery/arm-provider-schema-comparison.md) |

## Largest improvements from TCGC filtering

| Library | Unfiltered mismatches | Filtered mismatches | Delta | Current report |
| --- | ---: | ---: | ---: | --- |
| `Azure.ResourceManager.CosmosDB` | 13 | 3 | -10 | [report](sdk/cosmosdb/Azure.ResourceManager.CosmosDB/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.NetApp` | 9 | 0 | -9 | [report](sdk/netapp/Azure.ResourceManager.NetApp/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Discovery` | 6 | 0 | -6 | [report](sdk/discovery/Azure.ResourceManager.Discovery/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Monitor.Workspaces` | 6 | 0 | -6 | [report](sdk/monitor/Azure.ResourceManager.Monitor.Workspaces/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.ResilienceManagement` | 5 | 0 | -5 | [report](sdk/azureresiliencemanagement/Azure.ResourceManager.ResilienceManagement/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.KeyVault` | 4 | 0 | -4 | [report](sdk/keyvault/Azure.ResourceManager.KeyVault/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.RecoveryServicesBackup` | 15 | 12 | -3 | [report](sdk/recoveryservices-backup/Azure.ResourceManager.RecoveryServicesBackup/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.ConnectedCache` | 2 | 0 | -2 | [report](sdk/connectedcache/Azure.ResourceManager.ConnectedCache/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.DeviceRegistry` | 2 | 0 | -2 | [report](sdk/deviceregistry/Azure.ResourceManager.DeviceRegistry/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Hci.Vm` | 2 | 0 | -2 | [report](sdk/azurestackhci/Azure.ResourceManager.Hci.Vm/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.MySql` | 2 | 0 | -2 | [report](sdk/mysql/Azure.ResourceManager.MySql/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Quota` | 2 | 0 | -2 | [report](sdk/quota/Azure.ResourceManager.Quota/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Sql` | 5 | 3 | -2 | [report](sdk/sqlmanagement/Azure.ResourceManager.Sql/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.CognitiveServices` | 1 | 0 | -1 | [report](sdk/cognitiveservices/Azure.ResourceManager.CognitiveServices/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.ConfidentialLedger` | 1 | 0 | -1 | [report](sdk/confidentialledger/Azure.ResourceManager.ConfidentialLedger/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.DurableTask` | 1 | 0 | -1 | [report](sdk/durabletask/Azure.ResourceManager.DurableTask/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.OperationalInsights` | 3 | 2 | -1 | [report](sdk/operationalinsights/Azure.ResourceManager.OperationalInsights/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Resources.Policy` | 11 | 10 | -1 | [report](sdk/resources/Azure.ResourceManager.Resources.Policy/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Storage` | 5 | 4 | -1 | [report](sdk/storage/Azure.ResourceManager.Storage/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.StorageDiscovery` | 1 | 0 | -1 | [report](sdk/storagediscovery/Azure.ResourceManager.StorageDiscovery/arm-provider-schema-comparison.md) |

## Remaining regressions vs previous validation PR

| Library | Previous PR mismatches | Current filtered mismatches | Delta | Current report |
| --- | ---: | ---: | ---: | --- |
| `Azure.ResourceManager.Dns` | 0 | 13 | +13 | [report](sdk/dns/Azure.ResourceManager.Dns/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.PrivateDns` | 0 | 8 | +8 | [report](sdk/privatedns/Azure.ResourceManager.PrivateDns/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.RecoveryServicesBackup` | 9 | 12 | +3 | [report](sdk/recoveryservices-backup/Azure.ResourceManager.RecoveryServicesBackup/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.EventHubs` | 0 | 2 | +2 | [report](sdk/eventhub/Azure.ResourceManager.EventHubs/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Batch` | 1 | 2 | +1 | [report](sdk/batch/Azure.ResourceManager.Batch/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.PolicyInsights` | 4 | 5 | +1 | [report](sdk/policyinsights/Azure.ResourceManager.PolicyInsights/arm-provider-schema-comparison.md) |

## New libraries in this run

| Library | Total normalized mismatches | Legacy-only | `resolveArmResources`-only | Report |
| --- | ---: | ---: | ---: | --- |
| `Azure.ResourceManager.ManagedApplications` | 4 | 4 | 0 | [report](sdk/managedapplications/Azure.ResourceManager.ManagedApplications/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.ApplicationInsights` | 2 | 2 | 0 | [report](sdk/applicationinsights/Azure.ResourceManager.ApplicationInsights/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Authorization` | 2 | 1 | 1 | [report](sdk/authorization/Azure.ResourceManager.Authorization/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.AlertRuleRecommendations` | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.AlertRuleRecommendations/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.AlertsManagement` | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.AlertsManagement/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Billing.Trust` | 0 | 0 | 0 | [report](sdk/billingtrust/Azure.ResourceManager.Billing.Trust/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.ContainerServicePreparedImgSpec` | 0 | 0 | 0 | [report](sdk/containerservicepreparedimgspec/Azure.ResourceManager.ContainerServicePreparedImgSpec/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.ContainerServiceSafeguards` | 0 | 0 | 0 | [report](sdk/containerservicesafeguards/Azure.ResourceManager.ContainerServiceSafeguards/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Databricks` | 0 | 0 | 0 | [report](sdk/databricks/Azure.ResourceManager.Databricks/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.DevHub` | 0 | 0 | 0 | [report](sdk/developerhub/Azure.ResourceManager.DevHub/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Discovery` | 0 | 0 | 0 | [report](sdk/discovery/Azure.ResourceManager.Discovery/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.DomainServices` | 0 | 0 | 0 | [report](sdk/domainservices/Azure.ResourceManager.DomainServices/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Education` | 0 | 0 | 0 | [report](sdk/education/Azure.ResourceManager.Education/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.Enclave` | 0 | 0 | 0 | [report](sdk/enclave/Azure.ResourceManager.Enclave/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.ImageBuilder` | 0 | 0 | 0 | [report](sdk/imagebuilder/Azure.ResourceManager.ImageBuilder/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes` | 0 | 0 | 0 | [report](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations` | 0 | 0 | 0 | [report](sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.PowerPlatform` | 0 | 0 | 0 | [report](sdk/powerplatform/Azure.ResourceManager.PowerPlatform/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.PreviewAlertRule` | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.PreviewAlertRule/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.PrometheusRuleGroups` | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.PrometheusRuleGroups/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.ScVmm` | 0 | 0 | 0 | [report](sdk/arc-scvmm/Azure.ResourceManager.ScVmm/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.SerialConsole` | 0 | 0 | 0 | [report](sdk/serialconsole/Azure.ResourceManager.SerialConsole/arm-provider-schema-comparison.md) |
| `Azure.ResourceManager.TenantActivityLogAlerts` | 0 | 0 | 0 | [report](sdk/alertsmanagement/Azure.ResourceManager.TenantActivityLogAlerts/arm-provider-schema-comparison.md) |

## Previous-only libraries

| Library | Previous report |
| --- | --- |
| `Azure.ResourceManager.VirtualEnclaves` | Previous PR #60620 only; no paired snapshots were generated in this run. |