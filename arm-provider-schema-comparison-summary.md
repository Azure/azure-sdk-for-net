# ARM provider schema comparison summary

Validation run for Azure/typespec-azure#4851 using the local management emitter instrumentation.

## Overall

| Metric | Count |
|---|---:|
| Libraries regenerated | 217 |
| Libraries with identical summary counts | 121 |
| Libraries with resource ID set differences | 55 |
| Resource IDs present only in legacy snapshots | 223 |
| Resource IDs present only in resolveArmResources snapshots | 154 |

## Per-library counts

| Library | Legacy resources | resolveArmResources resources | Legacy methods | resolveArmResources methods | Legacy non-resources | resolveArmResources non-resources | Legacy-only resource IDs | resolve-only resource IDs |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
| Azure.ResourceManager.Advisor | 8 | 8 | 23 | 24 | 10 | 11 | 0 | 0 |
| Azure.ResourceManager.AgriculturePlatform | 1 | 1 | 7 | 7 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.AlertProcessingRules | 1 | 1 | 6 | 6 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.AlertRuleRecommendations | 0 | 0 | 0 | 0 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.AlertsManagement | 2 | 2 | 9 | 9 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.ApiCenter | 10 | 10 | 53 | 53 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ApiManagement | 102 | 102 | 629 | 629 | 7 | 7 | 1 | 1 |
| Azure.ResourceManager.AppComplianceAutomation | 5 | 5 | 27 | 27 | 7 | 7 | 0 | 0 |
| Azure.ResourceManager.AppConfiguration | 7 | 6 | 28 | 28 | 4 | 4 | 1 | 0 |
| Azure.ResourceManager.AppContainers | 41 | 41 | 180 | 181 | 5 | 5 | 0 | 0 |
| Azure.ResourceManager.ApplicationInsights | 6 | 4 | 69 | 17 | 3 | 55 | 2 | 0 |
| Azure.ResourceManager.AppNetwork | 2 | 2 | 12 | 12 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.AppService | 136 | 137 | 671 | 737 | 31 | 31 | 0 | 1 |
| Azure.ResourceManager.ArizeAIObservabilityEval | 1 | 1 | 6 | 6 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ArtifactSigning | 2 | 2 | 11 | 12 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.Astro | 1 | 1 | 6 | 6 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Attestation | 2 | 2 | 11 | 11 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.Authorization | 27 | 28 | 111 | 119 | 16 | 8 | 1 | 2 |
| Azure.ResourceManager.Automation | 25 | 33 | 170 | 171 | 2 | 2 | 0 | 8 |
| Azure.ResourceManager.Avs | 29 | 29 | 119 | 119 | 4 | 4 | 0 | 0 |
| Azure.ResourceManager.Batch | 8 | 9 | 38 | 44 | 4 | 4 | 0 | 1 |
| Azure.ResourceManager.Billing | 46 | 46 | 184 | 185 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.Billing.Trust | 2 | 2 | 9 | 9 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.BillingBenefits | 12 | 12 | 56 | 56 | 10 | 10 | 0 | 0 |
| Azure.ResourceManager.BotService | 5 | 5 | 28 | 28 | 4 | 6 | 0 | 0 |
| Azure.ResourceManager.CarbonOptimization | 0 | 0 | 0 | 0 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.Cdn | 20 | 20 | 132 | 133 | 10 | 10 | 0 | 0 |
| Azure.ResourceManager.CertificateRegistration | 3 | 3 | 21 | 21 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.Chaos | 15 | 15 | 60 | 61 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.CloudHealth | 6 | 6 | 32 | 42 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.CognitiveServices | 31 | 32 | 156 | 157 | 13 | 13 | 0 | 1 |
| Azure.ResourceManager.Communication | 7 | 7 | 38 | 38 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.Compute | 37 | 35 | 262 | 262 | 36 | 37 | 2 | 0 |
| Azure.ResourceManager.Compute.BulkActions | 4 | 4 | 32 | 32 | 17 | 17 | 0 | 0 |
| Azure.ResourceManager.Compute.Recommender | 2 | 2 | 4 | 4 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ComputeBulkActions | 1 | 2 | 7 | 8 | 9 | 8 | 0 | 1 |
| Azure.ResourceManager.ComputeFleet | 1 | 1 | 8 | 8 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ComputeLimit | 7 | 7 | 27 | 28 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ComputeSchedule | 2 | 2 | 19 | 19 | 15 | 15 | 0 | 0 |
| Azure.ResourceManager.ConfidentialLedger | 1 | 2 | 7 | 16 | 2 | 2 | 0 | 1 |
| Azure.ResourceManager.Confluent | 5 | 5 | 38 | 36 | 4 | 7 | 0 | 0 |
| Azure.ResourceManager.ConnectedCache | 4 | 6 | 30 | 42 | 1 | 1 | 0 | 2 |
| Azure.ResourceManager.Consumption | 4 | 4 | 7 | 7 | 25 | 25 | 0 | 0 |
| Azure.ResourceManager.ContainerInstance | 4 | 3 | 30 | 17 | 5 | 18 | 1 | 0 |
| Azure.ResourceManager.ContainerOrchestratorRuntime | 4 | 4 | 17 | 19 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ContainerRegistry | 15 | 15 | 78 | 78 | 2 | 2 | 1 | 1 |
| Azure.ResourceManager.ContainerRegistry.Tasks | 4 | 4 | 23 | 23 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.ContainerService | 21 | 21 | 102 | 105 | 4 | 5 | 0 | 0 |
| Azure.ResourceManager.ContainerServiceFleet | 8 | 8 | 41 | 43 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ContainerServicePreparedImgSpec | 2 | 2 | 9 | 9 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ContainerServiceSafeguards | 1 | 1 | 4 | 4 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.CosmosDB | 46 | 59 | 233 | 303 | 3 | 16 | 0 | 13 |
| Azure.ResourceManager.CosmosDBForPostgreSql | 9 | 9 | 33 | 33 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.CostManagement | 11 | 11 | 41 | 41 | 30 | 30 | 0 | 0 |
| Azure.ResourceManager.DatabaseWatcher | 5 | 5 | 23 | 23 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.DataBox | 1 | 1 | 11 | 11 | 6 | 7 | 0 | 0 |
| Azure.ResourceManager.DataBoxEdge | 19 | 20 | 74 | 75 | 2 | 2 | 0 | 1 |
| Azure.ResourceManager.Databricks | 5 | 5 | 23 | 23 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Datadog | 4 | 4 | 30 | 30 | 6 | 6 | 0 | 0 |
| Azure.ResourceManager.DataFactory | 13 | 13 | 101 | 101 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.DataMigration | 12 | 12 | 77 | 77 | 4 | 4 | 0 | 0 |
| Azure.ResourceManager.DataProtectionBackup | 9 | 12 | 59 | 62 | 8 | 12 | 0 | 3 |
| Azure.ResourceManager.Dell.Storage | 1 | 1 | 6 | 6 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.DependencyMap | 2 | 2 | 16 | 16 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.DesktopVirtualization | 17 | 17 | 97 | 97 | 0 | 1 | 0 | 0 |
| Azure.ResourceManager.DevCenter | 29 | 29 | 124 | 124 | 6 | 6 | 0 | 0 |
| Azure.ResourceManager.DevHub | 6 | 6 | 25 | 26 | 3 | 2 | 0 | 0 |
| Azure.ResourceManager.DeviceProvisioningServices | 4 | 5 | 21 | 22 | 1 | 2 | 0 | 1 |
| Azure.ResourceManager.DeviceRegistry | 13 | 16 | 69 | 89 | 1 | 2 | 0 | 2 |
| Azure.ResourceManager.DevOpsInfrastructure | 1 | 1 | 8 | 8 | 5 | 5 | 0 | 0 |
| Azure.ResourceManager.DevTestLabs | 21 | 21 | 130 | 130 | 0 | 2 | 15 | 15 |
| Azure.ResourceManager.DisconnectedOperations | 4 | 4 | 17 | 17 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.Discovery | 13 | 19 | 62 | 100 | 1 | 1 | 0 | 6 |
| Azure.ResourceManager.Dns | 15 | 2 | 63 | 17 | 2 | 1 | 13 | 0 |
| Azure.ResourceManager.DnsResolver | 10 | 10 | 55 | 55 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.DomainRegistration | 3 | 3 | 16 | 16 | 4 | 4 | 0 | 0 |
| Azure.ResourceManager.DomainServices | 2 | 2 | 12 | 12 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.DurableTask | 5 | 6 | 22 | 27 | 1 | 1 | 0 | 1 |
| Azure.ResourceManager.Dynatrace | 4 | 4 | 27 | 27 | 2 | 5 | 0 | 0 |
| Azure.ResourceManager.EdgeActions | 3 | 3 | 19 | 21 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.EdgeOrder | 3 | 3 | 15 | 15 | 6 | 6 | 0 | 0 |
| Azure.ResourceManager.EdgeZones | 1 | 1 | 4 | 4 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Education | 5 | 5 | 18 | 19 | 3 | 2 | 0 | 0 |
| Azure.ResourceManager.Elastic | 4 | 4 | 39 | 37 | 3 | 6 | 0 | 0 |
| Azure.ResourceManager.ElasticSan | 5 | 5 | 27 | 27 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.Enclave | 9 | 9 | 63 | 63 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.EventGrid | 32 | 27 | 173 | 163 | 14 | 17 | 5 | 0 |
| Azure.ResourceManager.EventHubs | 13 | 13 | 65 | 65 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.ExtendedLocations | 2 | 2 | 13 | 13 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Fabric | 1 | 1 | 9 | 9 | 4 | 4 | 0 | 0 |
| Azure.ResourceManager.FileShares | 4 | 4 | 17 | 17 | 4 | 4 | 0 | 0 |
| Azure.ResourceManager.FrontDoor | 6 | 0 | 35 | 0 | 3 | 38 | 6 | 0 |
| Azure.ResourceManager.Grafana | 7 | 7 | 35 | 35 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.GuestConfiguration | 4 | 0 | 24 | 0 | 3 | 27 | 4 | 0 |
| Azure.ResourceManager.HardwareSecurityModules | 3 | 3 | 24 | 24 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Hci | 30 | 30 | 134 | 134 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.Hci.Vm | 17 | 19 | 93 | 106 | 1 | 1 | 0 | 2 |
| Azure.ResourceManager.HDInsight | 4 | 10 | 50 | 51 | 6 | 7 | 0 | 6 |
| Azure.ResourceManager.HealthBot | 1 | 1 | 8 | 8 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.HealthcareApis | 10 | 10 | 43 | 43 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.HealthDataAIServices | 2 | 2 | 11 | 11 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.HorizonDB | 7 | 6 | 29 | 29 | 3 | 3 | 1 | 0 |
| Azure.ResourceManager.HybridCompute | 13 | 13 | 60 | 60 | 5 | 5 | 0 | 0 |
| Azure.ResourceManager.HybridConnectivity | 6 | 6 | 31 | 31 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.HybridNetwork | 13 | 13 | 82 | 82 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.ImageBuilder | 3 | 3 | 14 | 14 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ImpactReporting | 4 | 4 | 15 | 15 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.InformaticaDataManagement | 2 | 2 | 16 | 16 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.IotHub | 4 | 5 | 33 | 33 | 3 | 3 | 0 | 1 |
| Azure.ResourceManager.IotOperations | 12 | 12 | 50 | 50 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.KeyVault | 7 | 11 | 32 | 42 | 4 | 6 | 0 | 4 |
| Azure.ResourceManager.Kubernetes | 1 | 1 | 7 | 8 | 0 | 1 | 0 | 0 |
| Azure.ResourceManager.KubernetesConfiguration.Extensions | 1 | 1 | 5 | 6 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.KubernetesConfiguration.ExtensionTypes | 4 | 4 | 8 | 8 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.KubernetesConfiguration.FluxConfigurations | 1 | 1 | 5 | 6 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.KubernetesConfiguration.PrivateLinkScopes | 3 | 3 | 12 | 12 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.Kusto | 11 | 9 | 77 | 77 | 6 | 6 | 2 | 0 |
| Azure.ResourceManager.LambdaTestHyperExecute | 1 | 1 | 6 | 6 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.LargeInstance | 2 | 2 | 15 | 15 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.LoadTesting | 5 | 5 | 22 | 22 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.MachineLearning | 53 | 53 | 281 | 281 | 8 | 8 | 0 | 0 |
| Azure.ResourceManager.Maintenance | 8 | 8 | 28 | 29 | 9 | 8 | 0 | 0 |
| Azure.ResourceManager.ManagedApplications | 4 | 0 | 24 | 0 | 8 | 32 | 4 | 0 |
| Azure.ResourceManager.ManagedNetworkFabric | 26 | 27 | 205 | 250 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ManagedOps | 1 | 1 | 5 | 5 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.ManagedServiceIdentities | 3 | 3 | 11 | 11 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Maps | 4 | 4 | 20 | 20 | 1 | 3 | 0 | 0 |
| Azure.ResourceManager.Marketplace | 5 | 5 | 44 | 44 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.MongoCluster | 4 | 4 | 22 | 23 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.MongoDBAtlas | 3 | 3 | 16 | 16 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Monitor | 14 | 14 | 87 | 87 | 12 | 12 | 1 | 1 |
| Azure.ResourceManager.Monitor.PipelineGroups | 1 | 1 | 6 | 6 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Monitor.Slis | 1 | 1 | 4 | 4 | 0 | 1 | 0 | 0 |
| Azure.ResourceManager.Monitor.Workspaces | 3 | 9 | 22 | 48 | 1 | 1 | 0 | 6 |
| Azure.ResourceManager.MySql | 11 | 13 | 54 | 60 | 5 | 8 | 0 | 2 |
| Azure.ResourceManager.NapsterOmniagentApi | 1 | 1 | 8 | 8 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.NetApp | 17 | 26 | 115 | 170 | 9 | 9 | 0 | 9 |
| Azure.ResourceManager.Network | 140 | 0 | 741 | 0 | 35 | 776 | 140 | 0 |
| Azure.ResourceManager.NetworkCloud | 21 | 21 | 137 | 144 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.NetworkFunction | 2 | 2 | 11 | 11 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.NewRelicObservability | 3 | 3 | 30 | 30 | 5 | 5 | 0 | 0 |
| Azure.ResourceManager.Nginx | 5 | 5 | 25 | 24 | 1 | 2 | 0 | 0 |
| Azure.ResourceManager.NotificationHubs | 6 | 6 | 33 | 33 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.OnlineExperimentation | 3 | 3 | 12 | 12 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.OperationalInsights | 12 | 13 | 78 | 79 | 6 | 5 | 1 | 2 |
| Azure.ResourceManager.OracleDatabase | 25 | 25 | 109 | 111 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.PaloAltoNetworks.Ngfw | 14 | 14 | 91 | 91 | 5 | 5 | 0 | 0 |
| Azure.ResourceManager.Peering | 7 | 7 | 35 | 35 | 10 | 10 | 0 | 0 |
| Azure.ResourceManager.PineconeVectorDB | 1 | 1 | 6 | 6 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.PlanetaryComputer | 1 | 1 | 6 | 7 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.Playwright | 3 | 3 | 10 | 10 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.PolicyInsights | 3 | 8 | 11 | 38 | 40 | 40 | 0 | 5 |
| Azure.ResourceManager.PortalServicesCopilot | 1 | 1 | 4 | 4 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.PostgreSql | 15 | 15 | 67 | 67 | 7 | 7 | 0 | 0 |
| Azure.ResourceManager.PowerBIDedicated | 2 | 2 | 15 | 15 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.PowerPlatform | 4 | 4 | 18 | 18 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.PreviewAlertRule | 0 | 0 | 0 | 0 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.PrivateDns | 10 | 2 | 45 | 17 | 0 | 0 | 8 | 0 |
| Azure.ResourceManager.ProgramEnrollment | 1 | 1 | 6 | 6 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.PrometheusRuleGroups | 1 | 1 | 6 | 6 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.ProviderHub | 12 | 13 | 59 | 59 | 1 | 1 | 0 | 1 |
| Azure.ResourceManager.PureStorageBlock | 6 | 6 | 37 | 37 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Purview | 4 | 4 | 21 | 21 | 7 | 7 | 0 | 0 |
| Azure.ResourceManager.Quantum | 1 | 1 | 8 | 8 | 4 | 4 | 0 | 0 |
| Azure.ResourceManager.Qumulo | 1 | 1 | 6 | 6 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Quota | 11 | 13 | 32 | 40 | 1 | 3 | 0 | 2 |
| Azure.ResourceManager.RecoveryServices | 4 | 5 | 18 | 19 | 2 | 3 | 0 | 1 |
| Azure.ResourceManager.RecoveryServicesBackup | 12 | 27 | 46 | 71 | 16 | 24 | 0 | 15 |
| Azure.ResourceManager.RecoveryServicesDataReplication | 13 | 13 | 50 | 50 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.RecoveryServicesSiteRecovery | 24 | 25 | 133 | 137 | 17 | 17 | 0 | 1 |
| Azure.ResourceManager.RedHatOpenShift | 3 | 3 | 12 | 12 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Redis | 7 | 7 | 38 | 38 | 2 | 3 | 0 | 0 |
| Azure.ResourceManager.RedisEnterprise | 5 | 5 | 34 | 34 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.Relationships | 2 | 2 | 6 | 6 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Relay | 9 | 9 | 40 | 40 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.Reservations | 4 | 4 | 21 | 21 | 6 | 6 | 0 | 0 |
| Azure.ResourceManager.ResilienceManagement | 14 | 19 | 76 | 94 | 2 | 2 | 0 | 5 |
| Azure.ResourceManager.ResourceConnector | 1 | 1 | 9 | 9 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.ResourceGraph | 1 | 1 | 6 | 6 | 5 | 5 | 0 | 0 |
| Azure.ResourceManager.ResourceHealth | 6 | 6 | 18 | 18 | 8 | 8 | 0 | 0 |
| Azure.ResourceManager.Resources.Bicep | 0 | 0 | 0 | 0 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Resources.Deployments | 1 | 5 | 9 | 47 | 2 | 3 | 0 | 4 |
| Azure.ResourceManager.Resources.DeploymentStacks | 2 | 8 | 11 | 44 | 0 | 0 | 0 | 6 |
| Azure.ResourceManager.Resources.Policy | 9 | 20 | 40 | 82 | 6 | 6 | 0 | 11 |
| Azure.ResourceManager.ScVmm | 9 | 9 | 51 | 51 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Search | 4 | 4 | 24 | 24 | 5 | 5 | 0 | 0 |
| Azure.ResourceManager.SecretsStoreExtension | 2 | 2 | 12 | 12 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.SecurityCenter | 67 | 66 | 244 | 241 | 22 | 25 | 3 | 2 |
| Azure.ResourceManager.SecurityInsights | 41 | 41 | 163 | 159 | 10 | 14 | 0 | 0 |
| Azure.ResourceManager.SelfHelp | 5 | 5 | 14 | 14 | 5 | 5 | 0 | 0 |
| Azure.ResourceManager.SerialConsole | 1 | 1 | 4 | 5 | 5 | 4 | 0 | 0 |
| Azure.ResourceManager.ServiceBus | 14 | 14 | 68 | 68 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.ServiceFabric | 6 | 6 | 27 | 27 | 5 | 5 | 0 | 0 |
| Azure.ResourceManager.ServiceFabricManagedClusters | 6 | 6 | 48 | 57 | 6 | 8 | 0 | 0 |
| Azure.ResourceManager.ServiceGroups | 1 | 1 | 5 | 5 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.ServiceNetworking | 4 | 4 | 21 | 21 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.SignalR | 7 | 7 | 37 | 37 | 3 | 3 | 0 | 0 |
| Azure.ResourceManager.SiteManager | 3 | 3 | 15 | 15 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.Sphere | 7 | 7 | 44 | 44 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Sql | 127 | 128 | 524 | 532 | 13 | 13 | 2 | 3 |
| Azure.ResourceManager.SqlVirtualMachine | 3 | 3 | 21 | 21 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.StandbyPool | 5 | 5 | 18 | 18 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.Storage | 23 | 24 | 111 | 115 | 5 | 5 | 2 | 3 |
| Azure.ResourceManager.StorageActions | 1 | 1 | 8 | 8 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.StorageCache | 7 | 7 | 54 | 54 | 7 | 7 | 0 | 0 |
| Azure.ResourceManager.StorageDiscovery | 1 | 2 | 6 | 11 | 1 | 1 | 0 | 1 |
| Azure.ResourceManager.StorageMover | 7 | 7 | 34 | 34 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.StorageSync | 7 | 7 | 41 | 41 | 1 | 3 | 0 | 0 |
| Azure.ResourceManager.Subscription | 4 | 4 | 10 | 12 | 8 | 9 | 0 | 0 |
| Azure.ResourceManager.Support | 12 | 12 | 37 | 37 | 7 | 7 | 0 | 0 |
| Azure.ResourceManager.TenantActivityLogAlerts | 1 | 1 | 5 | 6 | 1 | 0 | 0 | 0 |
| Azure.ResourceManager.Terraform | 0 | 0 | 0 | 0 | 2 | 2 | 0 | 0 |
| Azure.ResourceManager.TrafficManager | 7 | 0 | 23 | 0 | 2 | 17 | 7 | 0 |
| Azure.ResourceManager.WebPubSub | 8 | 8 | 41 | 41 | 2 | 3 | 0 | 0 |
| Azure.ResourceManager.WeightsAndBiases | 1 | 1 | 6 | 6 | 1 | 1 | 0 | 0 |
| Azure.ResourceManager.WorkloadOrchestration | 21 | 21 | 114 | 116 | 0 | 0 | 0 | 0 |
| Azure.ResourceManager.WorkloadsSapVirtualInstance | 4 | 4 | 29 | 29 | 5 | 5 | 0 | 0 |

## Libraries with resource ID set differences

| Library | Legacy-only resource IDs | resolve-only resource IDs |
|---|---:|---:|
| Azure.ResourceManager.ApiManagement | 1 | 1 |
| Azure.ResourceManager.AppConfiguration | 1 | 0 |
| Azure.ResourceManager.ApplicationInsights | 2 | 0 |
| Azure.ResourceManager.AppService | 0 | 1 |
| Azure.ResourceManager.Authorization | 1 | 2 |
| Azure.ResourceManager.Automation | 0 | 8 |
| Azure.ResourceManager.Batch | 0 | 1 |
| Azure.ResourceManager.CognitiveServices | 0 | 1 |
| Azure.ResourceManager.Compute | 2 | 0 |
| Azure.ResourceManager.ComputeBulkActions | 0 | 1 |
| Azure.ResourceManager.ConfidentialLedger | 0 | 1 |
| Azure.ResourceManager.ConnectedCache | 0 | 2 |
| Azure.ResourceManager.ContainerInstance | 1 | 0 |
| Azure.ResourceManager.ContainerRegistry | 1 | 1 |
| Azure.ResourceManager.CosmosDB | 0 | 13 |
| Azure.ResourceManager.DataBoxEdge | 0 | 1 |
| Azure.ResourceManager.DataProtectionBackup | 0 | 3 |
| Azure.ResourceManager.DeviceProvisioningServices | 0 | 1 |
| Azure.ResourceManager.DeviceRegistry | 0 | 2 |
| Azure.ResourceManager.DevTestLabs | 15 | 15 |
| Azure.ResourceManager.Discovery | 0 | 6 |
| Azure.ResourceManager.Dns | 13 | 0 |
| Azure.ResourceManager.DurableTask | 0 | 1 |
| Azure.ResourceManager.EventGrid | 5 | 0 |
| Azure.ResourceManager.FrontDoor | 6 | 0 |
| Azure.ResourceManager.GuestConfiguration | 4 | 0 |
| Azure.ResourceManager.Hci.Vm | 0 | 2 |
| Azure.ResourceManager.HDInsight | 0 | 6 |
| Azure.ResourceManager.HorizonDB | 1 | 0 |
| Azure.ResourceManager.IotHub | 0 | 1 |
| Azure.ResourceManager.KeyVault | 0 | 4 |
| Azure.ResourceManager.Kusto | 2 | 0 |
| Azure.ResourceManager.ManagedApplications | 4 | 0 |
| Azure.ResourceManager.Monitor | 1 | 1 |
| Azure.ResourceManager.Monitor.Workspaces | 0 | 6 |
| Azure.ResourceManager.MySql | 0 | 2 |
| Azure.ResourceManager.NetApp | 0 | 9 |
| Azure.ResourceManager.Network | 140 | 0 |
| Azure.ResourceManager.OperationalInsights | 1 | 2 |
| Azure.ResourceManager.PolicyInsights | 0 | 5 |
| Azure.ResourceManager.PrivateDns | 8 | 0 |
| Azure.ResourceManager.ProviderHub | 0 | 1 |
| Azure.ResourceManager.Quota | 0 | 2 |
| Azure.ResourceManager.RecoveryServices | 0 | 1 |
| Azure.ResourceManager.RecoveryServicesBackup | 0 | 15 |
| Azure.ResourceManager.RecoveryServicesSiteRecovery | 0 | 1 |
| Azure.ResourceManager.ResilienceManagement | 0 | 5 |
| Azure.ResourceManager.Resources.Deployments | 0 | 4 |
| Azure.ResourceManager.Resources.DeploymentStacks | 0 | 6 |
| Azure.ResourceManager.Resources.Policy | 0 | 11 |
| Azure.ResourceManager.SecurityCenter | 3 | 2 |
| Azure.ResourceManager.Sql | 2 | 3 |
| Azure.ResourceManager.Storage | 2 | 3 |
| Azure.ResourceManager.StorageDiscovery | 0 | 1 |
| Azure.ResourceManager.TrafficManager | 7 | 0 |
