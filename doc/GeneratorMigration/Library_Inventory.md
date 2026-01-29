# Azure SDK for .NET Libraries Inventory

## Table of Contents

- [Summary](#summary)
- [Data Plane Libraries (DPG) - Migrated to New Emitter](#data-plane-libraries-dpg---migrated-to-new-emitter)
- [Data Plane Libraries (DPG) - Still on Swagger](#data-plane-libraries-dpg---still-on-swagger)
- [Management Plane Libraries (MPG) - Migrated to New Emitter](#management-plane-libraries-mpg---migrated-to-new-emitter)
- [Management Plane Libraries (MPG) - Still on Swagger](#management-plane-libraries-mpg---still-on-swagger)
- [Provisioning Libraries](#provisioning-libraries)
- [Libraries with No Generator](#libraries-with-no-generator)


## Summary

- Total libraries: 403
- Management Plane (MPG): 229
  - Autorest/Swagger: 150
  - New Emitter (TypeSpec): 76
  - Old TypeSpec: 3
- Data Plane (DPG): 143
  - Autorest/Swagger: 58
  - New Emitter (TypeSpec): 27
  - Old TypeSpec: 11
- Provisioning: 31
  - Custom reflection-based generator: 31
- No generator: 47


## Data Plane Libraries (DPG) - Migrated to New Emitter

Libraries that provide client APIs for Azure services and have been migrated to the new TypeSpec emitter.

**Migration Status**: 27 / 38 (71.1%)

| Service | Library | New Emitter |
| ------- | ------- | ----------- |
| ai | Azure.AI.Agents.Persistent |  |
| ai | Azure.AI.Projects | ✅ |
| ai | Azure.AI.VoiceLive | ✅ |
| anomalydetector | Azure.AI.AnomalyDetector |  |
| appconfiguration | Azure.Data.AppConfiguration | ✅ |
| batch | Azure.Compute.Batch | ✅ |
| cognitivelanguage | Azure.AI.Language.Conversations |  |
| cognitivelanguage | Azure.AI.Language.Conversations.Authoring |  |
| cognitivelanguage | Azure.AI.Language.QuestionAnswering.Authoring | ✅ |
| cognitivelanguage | Azure.AI.Language.QuestionAnswering.Inference | ✅ |
| cognitivelanguage | Azure.AI.Language.Text |  |
| cognitivelanguage | Azure.AI.Language.Text.Authoring |  |
| communication | Azure.Communication.JobRouter |  |
| communication | Azure.Communication.Messages |  |
| communication | Azure.Communication.ProgrammableConnectivity |  |
| confidentialledger | Azure.Security.CodeTransparency | ✅ |
| contentsafety | Azure.AI.ContentSafety |  |
| contentunderstanding | Azure.AI.ContentUnderstanding | ✅ |
| devcenter | Azure.Developer.DevCenter | ✅ |
| documentintelligence | Azure.AI.DocumentIntelligence | ✅ |
| easm | Azure.Analytics.Defender.Easm | ✅ |
| eventgrid | Azure.Messaging.EventGrid.Namespaces | ✅ |
| eventgrid | Azure.Messaging.EventGrid.SystemEvents | ✅ |
| healthdataaiservices | Azure.Health.Deidentification | ✅ |
| keyvault | Azure.Security.KeyVault.Administration | ✅ |
| loadtestservice | Azure.Developer.LoadTesting | ✅ |
| monitor | Azure.Monitor.Ingestion | ✅ |
| monitor | Azure.Monitor.Query.Logs | ✅ |
| monitor | Azure.Monitor.Query.Metrics | ✅ |
| onlineexperimentation | Azure.Analytics.OnlineExperimentation | ✅ |
| openai | Azure.AI.OpenAI | ✅ |
| planetarycomputer | Azure.Analytics.PlanetaryComputer | ✅ |
| purview | Azure.Analytics.Purview.DataMap | ✅ |
| schemaregistry | Azure.Data.SchemaRegistry | ✅ |
| template | Azure.Template | ✅ |
| translation | Azure.AI.Translation.Document |  |
| translation | Azure.AI.Translation.Text | ✅ |
| vision | Azure.AI.Vision.ImageAnalysis | ✅ |


## Data Plane Libraries (DPG) - Still on Swagger

Libraries that have not yet been migrated to the new TypeSpec emitter. Total: 58

| Service | Library |
| ------- | ------- |
| agentserver | Azure.AI.AgentServer.Contracts |
| agrifood | Azure.Verticals.AgriFood.Farming |
| attestation | Azure.Security.Attestation |
| cognitivelanguage | Azure.AI.Language.QuestionAnswering |
| communication | Azure.Communication.AlphaIds |
| communication | Azure.Communication.CallAutomation |
| communication | Azure.Communication.CallingServer |
| communication | Azure.Communication.Chat |
| communication | Azure.Communication.Email |
| communication | Azure.Communication.Identity |
| communication | Azure.Communication.PhoneNumbers |
| communication | Azure.Communication.Rooms |
| communication | Azure.Communication.ShortCodes |
| communication | Azure.Communication.Sms |
| confidentialledger | Azure.Security.ConfidentialLedger |
| containerregistry | Azure.Containers.ContainerRegistry |
| core | Azure.Core.TestFramework |
| deviceupdate | Azure.IoT.DeviceUpdate |
| digitaltwins | Azure.DigitalTwins.Core |
| formrecognizer | Azure.AI.FormRecognizer |
| iot | Azure.IoT.Hub.Service |
| maps | Azure.Maps.Geolocation |
| maps | Azure.Maps.Rendering |
| maps | Azure.Maps.Routing |
| maps | Azure.Maps.Search |
| maps | Azure.Maps.TimeZones |
| maps | Azure.Maps.Weather |
| metricsadvisor | Azure.AI.MetricsAdvisor |
| mixedreality | Azure.MixedReality.Authentication |
| monitor | Azure.Monitor.OpenTelemetry.Exporter |
| monitor | Azure.Monitor.OpenTelemetry.LiveMetrics |
| objectanchors | Azure.MixedReality.ObjectAnchors.Conversion |
| personalizer | Azure.AI.Personalizer |
| purview | Azure.Analytics.Purview.Account |
| purview | Azure.Analytics.Purview.Administration |
| purview | Azure.Analytics.Purview.Catalog |
| purview | Azure.Analytics.Purview.Scanning |
| purview | Azure.Analytics.Purview.Sharing |
| purview | Azure.Analytics.Purview.Workflows |
| quantum | Azure.Quantum.Jobs |
| remoterendering | Azure.MixedReality.RemoteRendering |
| search | Azure.Search.Documents |
| storage | Azure.Storage.Blobs |
| storage | Azure.Storage.Blobs.Batch |
| storage | Azure.Storage.Files.DataLake |
| storage | Azure.Storage.Files.Shares |
| storage | Azure.Storage.Queues |
| synapse | Azure.Analytics.Synapse.AccessControl |
| synapse | Azure.Analytics.Synapse.Artifacts |
| synapse | Azure.Analytics.Synapse.ManagedPrivateEndpoints |
| synapse | Azure.Analytics.Synapse.Monitoring |
| synapse | Azure.Analytics.Synapse.Spark |
| tables | Azure.Data.Tables |
| textanalytics | Azure.AI.TextAnalytics |
| textanalytics | Azure.AI.TextAnalytics.Legacy.Shared |
| timeseriesinsights | Azure.IoT.TimeSeriesInsights |
| videoanalyzer | Azure.Media.VideoAnalyzer.Edge |
| webpubsub | Azure.Messaging.WebPubSub |


## Management Plane Libraries (MPG) - Migrated to New Emitter

Libraries that provide resource management APIs for Azure services and have been migrated to the new TypeSpec emitter.

**Migration Status**: 76 / 79 (96.2%)

| Service | Library | New Emitter |
| ------- | ------- | ----------- |
| advisor | Azure.ResourceManager.Advisor | ✅ |
| agricultureplatform | Azure.ResourceManager.AgriculturePlatform | ✅ |
| arizeaiobservabilityeval | Azure.ResourceManager.ArizeAIObservabilityEval | ✅ |
| astronomer | Azure.ResourceManager.Astro | ✅ |
| avs | Azure.ResourceManager.Avs | ✅ |
| azurelargeinstance | Azure.ResourceManager.LargeInstance | ✅ |
| azurestackhci | Azure.ResourceManager.Hci.Vm | ✅ |
| carbon | Azure.ResourceManager.CarbonOptimization | ✅ |
| chaos | Azure.ResourceManager.Chaos | ✅ |
| cloudhealth | Azure.ResourceManager.CloudHealth | ✅ |
| computefleet | Azure.ResourceManager.ComputeFleet | ✅ |
| computelimit | Azure.ResourceManager.ComputeLimit | ✅ |
| computerecommender | Azure.ResourceManager.Compute.Recommender | ✅ |
| computeschedule | Azure.ResourceManager.ComputeSchedule | ✅ |
| connectedcache | Azure.ResourceManager.ConnectedCache | ✅ |
| containerorchestratorruntime | Azure.ResourceManager.ContainerOrchestratorRuntime | ✅ |
| databasewatcher | Azure.ResourceManager.DatabaseWatcher | ✅ |
| databox | Azure.ResourceManager.DataBox | ✅ |
| dellstorage | Azure.ResourceManager.Dell.Storage | ✅ |
| dependencymap | Azure.ResourceManager.DependencyMap | ✅ |
| deviceprovisioningservices | Azure.ResourceManager.DeviceProvisioningServices |  |
| deviceregistry | Azure.ResourceManager.DeviceRegistry | ✅ |
| devopsinfrastructure | Azure.ResourceManager.DevOpsInfrastructure | ✅ |
| disconnectedoperations | Azure.ResourceManager.DisconnectedOperations | ✅ |
| durabletask | Azure.ResourceManager.DurableTask | ✅ |
| dynatrace | Azure.ResourceManager.Dynatrace | ✅ |
| edgeactions | Azure.ResourceManager.EdgeActions | ✅ |
| edgeorder | Azure.ResourceManager.EdgeOrder | ✅ |
| edgezones | Azure.ResourceManager.EdgeZones | ✅ |
| elastic | Azure.ResourceManager.Elastic | ✅ |
| elasticsan | Azure.ResourceManager.ElasticSan | ✅ |
| fabric | Azure.ResourceManager.Fabric | ✅ |
| fileshares | Azure.ResourceManager.FileShares | ✅ |
| grafana | Azure.ResourceManager.Grafana | ✅ |
| hardwaresecuritymodules | Azure.ResourceManager.HardwareSecurityModules | ✅ |
| healthbot | Azure.ResourceManager.HealthBot | ✅ |
| healthdataaiservices | Azure.ResourceManager.HealthDataAIServices | ✅ |
| hybridconnectivity | Azure.ResourceManager.HybridConnectivity | ✅ |
| hybridkubernetes | Azure.ResourceManager.Kubernetes | ✅ |
| impactreporting | Azure.ResourceManager.ImpactReporting | ✅ |
| informaticadatamanagement | Azure.ResourceManager.InformaticaDataManagement | ✅ |
| iotoperations | Azure.ResourceManager.IotOperations | ✅ |
| keyvault | Azure.ResourceManager.KeyVault | ✅ |
| lambdatesthyperexecute | Azure.ResourceManager.LambdaTestHyperExecute | ✅ |
| mongocluster | Azure.ResourceManager.MongoCluster | ✅ |
| mongodbatlas | Azure.ResourceManager.MongoDBAtlas | ✅ |
| mysql | Azure.ResourceManager.MySql | ✅ |
| neonpostgres | Azure.ResourceManager.NeonPostgres | ✅ |
| nginx | Azure.ResourceManager.Nginx | ✅ |
| onlineexperimentation | Azure.ResourceManager.OnlineExperimentation | ✅ |
| oracle | Azure.ResourceManager.OracleDatabase | ✅ |
| paloaltonetworks.ngfw | Azure.ResourceManager.PaloAltoNetworks.Ngfw | ✅ |
| pineconevectordb | Azure.ResourceManager.PineconeVectorDB | ✅ |
| planetarycomputer | Azure.ResourceManager.PlanetaryComputer | ✅ |
| playwright | Azure.ResourceManager.Playwright | ✅ |
| portalservices | Azure.ResourceManager.PortalServicesCopilot | ✅ |
| purestorageblock | Azure.ResourceManager.PureStorageBlock | ✅ |
| qumulo | Azure.ResourceManager.Qumulo | ✅ |
| quota | Azure.ResourceManager.Quota | ✅ |
| recoveryservices | Azure.ResourceManager.RecoveryServices |  |
| recoveryservices-datareplication | Azure.ResourceManager.RecoveryServicesDataReplication | ✅ |
| resourceconnector | Azure.ResourceManager.ResourceConnector | ✅ |
| resources | Azure.ResourceManager.Resources.Bicep | ✅ |
| secretsstoreextension | Azure.ResourceManager.SecretsStoreExtension | ✅ |
| selfhelp | Azure.ResourceManager.SelfHelp | ✅ |
| servicefabricmanagedclusters | Azure.ResourceManager.ServiceFabricManagedClusters | ✅ |
| servicenetworking | Azure.ResourceManager.ServiceNetworking | ✅ |
| sitemanager | Azure.ResourceManager.SiteManager |  |
| standbypool | Azure.ResourceManager.StandbyPool | ✅ |
| storageactions | Azure.ResourceManager.StorageActions | ✅ |
| storagediscovery | Azure.ResourceManager.StorageDiscovery | ✅ |
| storagemover | Azure.ResourceManager.StorageMover | ✅ |
| storagesync | Azure.ResourceManager.StorageSync | ✅ |
| terraform | Azure.ResourceManager.Terraform | ✅ |
| trustedsigning | Azure.ResourceManager.TrustedSigning | ✅ |
| virtualenclaves | Azure.ResourceManager.VirtualEnclaves | ✅ |
| weightsandbiases | Azure.ResourceManager.WeightsAndBiases | ✅ |
| workloadorchestration | Azure.ResourceManager.WorkloadOrchestration | ✅ |
| workloadssapvirtualinstance | Azure.ResourceManager.WorkloadsSapVirtualInstance | ✅ |


## Management Plane Libraries (MPG) - Still on Swagger

Libraries that have not yet been migrated to the new TypeSpec emitter. Total: 150

| Service | Library |
| ------- | ------- |
| agrifood | Azure.ResourceManager.AgFoodPlatform |
| alertsmanagement | Azure.ResourceManager.AlertsManagement |
| analysisservices | Azure.ResourceManager.Analysis |
| anyscale | Azure.ResourceManager.Anyscale |
| apicenter | Azure.ResourceManager.ApiCenter |
| apimanagement | Azure.ResourceManager.ApiManagement |
| appcomplianceautomation | Azure.ResourceManager.AppComplianceAutomation |
| appconfiguration | Azure.ResourceManager.AppConfiguration |
| applicationinsights | Azure.ResourceManager.ApplicationInsights |
| appplatform | Azure.ResourceManager.AppPlatform |
| arc-scvmm | Azure.ResourceManager.ScVmm |
| attestation | Azure.ResourceManager.Attestation |
| authorization | Azure.ResourceManager.Authorization |
| automanage | Azure.ResourceManager.Automanage |
| automation | Azure.ResourceManager.Automation |
| azurestackhci | Azure.ResourceManager.Hci |
| batch | Azure.ResourceManager.Batch |
| billing | Azure.ResourceManager.Billing |
| billingbenefits | Azure.ResourceManager.BillingBenefits |
| blueprint | Azure.ResourceManager.Blueprint |
| botservice | Azure.ResourceManager.BotService |
| cdn | Azure.ResourceManager.Cdn |
| changeanalysis | Azure.ResourceManager.ChangeAnalysis |
| cognitiveservices | Azure.ResourceManager.CognitiveServices |
| communication | Azure.ResourceManager.Communication |
| compute | Azure.ResourceManager.Compute |
| confidentialledger | Azure.ResourceManager.ConfidentialLedger |
| confluent | Azure.ResourceManager.Confluent |
| connectedvmwarevsphere | Azure.ResourceManager.ConnectedVMwarevSphere |
| consumption | Azure.ResourceManager.Consumption |
| containerapps | Azure.ResourceManager.AppContainers |
| containerinstance | Azure.ResourceManager.ContainerInstance |
| containerregistry | Azure.ResourceManager.ContainerRegistry |
| containerservice | Azure.ResourceManager.ContainerService |
| cosmosdb | Azure.ResourceManager.CosmosDB |
| cosmosdbforpostgresql | Azure.ResourceManager.CosmosDBForPostgreSql |
| costmanagement | Azure.ResourceManager.CostManagement |
| customer-insights | Azure.ResourceManager.CustomerInsights |
| databoxedge | Azure.ResourceManager.DataBoxEdge |
| datadog | Azure.ResourceManager.Datadog |
| datafactory | Azure.ResourceManager.DataFactory |
| datalake-analytics | Azure.ResourceManager.DataLakeAnalytics |
| datalake-store | Azure.ResourceManager.DataLakeStore |
| datamigration | Azure.ResourceManager.DataMigration |
| dataprotection | Azure.ResourceManager.DataProtectionBackup |
| datashare | Azure.ResourceManager.DataShare |
| defendereasm | Azure.ResourceManager.DefenderEasm |
| desktopvirtualization | Azure.ResourceManager.DesktopVirtualization |
| devcenter | Azure.ResourceManager.DevCenter |
| deviceupdate | Azure.ResourceManager.DeviceUpdate |
| devspaces | Azure.ResourceManager.DevSpaces |
| devtestlabs | Azure.ResourceManager.DevTestLabs |
| digitaltwins | Azure.ResourceManager.DigitalTwins |
| dns | Azure.ResourceManager.Dns |
| dnsresolver | Azure.ResourceManager.DnsResolver |
| eventgrid | Azure.ResourceManager.EventGrid |
| eventhub | Azure.ResourceManager.EventHubs |
| extendedlocation | Azure.ResourceManager.ExtendedLocations |
| fleet | Azure.ResourceManager.ContainerServiceFleet |
| fluidrelay | Azure.ResourceManager.FluidRelay |
| frontdoor | Azure.ResourceManager.FrontDoor |
| graphservices | Azure.ResourceManager.GraphServices |
| guestconfiguration | Azure.ResourceManager.GuestConfiguration |
| hdinsight | Azure.ResourceManager.HDInsight |
| hdinsightcontainers | Azure.ResourceManager.HDInsight.Containers |
| healthcareapis | Azure.ResourceManager.HealthcareApis |
| hybridaks | Azure.ResourceManager.HybridContainerService |
| hybridcompute | Azure.ResourceManager.HybridCompute |
| hybridnetwork | Azure.ResourceManager.HybridNetwork |
| iot | Azure.ResourceManager.IotFirmwareDefense |
| iotcentral | Azure.ResourceManager.IotCentral |
| iothub | Azure.ResourceManager.IotHub |
| kubernetesconfiguration | Azure.ResourceManager.KubernetesConfiguration |
| kusto | Azure.ResourceManager.Kusto |
| labservices | Azure.ResourceManager.LabServices |
| loadtestservice | Azure.ResourceManager.LoadTesting |
| logic | Azure.ResourceManager.Logic |
| machinelearningcompute | Azure.ResourceManager.MachineLearningCompute |
| machinelearningservices | Azure.ResourceManager.MachineLearning |
| maintenance | Azure.ResourceManager.Maintenance |
| managednetwork | Azure.ResourceManager.ManagedNetwork |
| managednetworkfabric | Azure.ResourceManager.ManagedNetworkFabric |
| managedserviceidentity | Azure.ResourceManager.ManagedServiceIdentities |
| managedservices | Azure.ResourceManager.ManagedServices |
| managementpartner | Azure.ResourceManager.ManagementPartner |
| maps | Azure.ResourceManager.Maps |
| marketplace | Azure.ResourceManager.Marketplace |
| marketplaceordering | Azure.ResourceManager.MarketplaceOrdering |
| mediaservices | Azure.ResourceManager.Media |
| migrationassessment | Azure.ResourceManager.Migration.Assessment |
| migrationdiscoverysap | Azure.ResourceManager.MigrationDiscoverySap |
| mixedreality | Azure.ResourceManager.MixedReality |
| mobilenetwork | Azure.ResourceManager.MobileNetwork |
| monitor | Azure.ResourceManager.Monitor |
| netapp | Azure.ResourceManager.NetApp |
| network | Azure.ResourceManager.Network |
| networkanalytics | Azure.ResourceManager.NetworkAnalytics |
| networkcloud | Azure.ResourceManager.NetworkCloud |
| networkfunction | Azure.ResourceManager.NetworkFunction |
| newrelicobservability | Azure.ResourceManager.NewRelicObservability |
| notificationhubs | Azure.ResourceManager.NotificationHubs |
| openenergyplatform | Azure.ResourceManager.EnergyServices |
| operationalinsights | Azure.ResourceManager.OperationalInsights |
| orbital | Azure.ResourceManager.Orbital |
| peering | Azure.ResourceManager.Peering |
| policyinsights | Azure.ResourceManager.PolicyInsights |
| postgresql | Azure.ResourceManager.PostgreSql |
| powerbidedicated | Azure.ResourceManager.PowerBIDedicated |
| privatedns | Azure.ResourceManager.PrivateDns |
| providerhub | Azure.ResourceManager.ProviderHub |
| purview | Azure.ResourceManager.Purview |
| quantum | Azure.ResourceManager.Quantum |
| recoveryservices-backup | Azure.ResourceManager.RecoveryServicesBackup |
| recoveryservices-siterecovery | Azure.ResourceManager.RecoveryServicesSiteRecovery |
| redis | Azure.ResourceManager.Redis |
| redisenterprise | Azure.ResourceManager.RedisEnterprise |
| relay | Azure.ResourceManager.Relay |
| reservations | Azure.ResourceManager.Reservations |
| resourcegraph | Azure.ResourceManager.ResourceGraph |
| resourcehealth | Azure.ResourceManager.ResourceHealth |
| resourcemanager | Azure.ResourceManager |
| resourcemover | Azure.ResourceManager.ResourceMover |
| resources | Azure.ResourceManager.Resources |
| resources | Azure.ResourceManager.Resources.Deployments |
| resources | Azure.ResourceManager.Resources.DeploymentStacks |
| search | Azure.ResourceManager.Search |
| securitycenter | Azure.ResourceManager.SecurityCenter |
| securitydevops | Azure.ResourceManager.SecurityDevOps |
| securityinsights | Azure.ResourceManager.SecurityInsights |
| servicebus | Azure.ResourceManager.ServiceBus |
| servicefabric | Azure.ResourceManager.ServiceFabric |
| servicelinker | Azure.ResourceManager.ServiceLinker |
| signalr | Azure.ResourceManager.SignalR |
| sphere | Azure.ResourceManager.Sphere |
| springappdiscovery | Azure.ResourceManager.SpringAppDiscovery |
| sqlmanagement | Azure.ResourceManager.Sql |
| sqlvirtualmachine | Azure.ResourceManager.SqlVirtualMachine |
| storage | Azure.ResourceManager.Storage |
| storagecache | Azure.ResourceManager.StorageCache |
| storagepool | Azure.ResourceManager.StoragePool |
| streamanalytics | Azure.ResourceManager.StreamAnalytics |
| subscription | Azure.ResourceManager.Subscription |
| support | Azure.ResourceManager.Support |
| synapse | Azure.ResourceManager.Synapse |
| trafficmanager | Azure.ResourceManager.TrafficManager |
| voiceservices | Azure.ResourceManager.VoiceServices |
| webpubsub | Azure.ResourceManager.WebPubSub |
| websites | Azure.ResourceManager.AppService |
| workloadmonitor | Azure.ResourceManager.WorkloadMonitor |
| workloads | Azure.ResourceManager.Workloads |


## Provisioning Libraries

Libraries that provide infrastructure-as-code capabilities for Azure services using a custom reflection-based generator. These libraries allow you to declaratively specify Azure infrastructure natively in .NET and generate Bicep templates for deployment.

**Note**: Unlike other Azure SDK libraries, Provisioning libraries use a custom reflection-based generator that analyzes Azure Resource Manager SDK types to produce strongly-typed infrastructure definition APIs.

Total: 31

| Service | Library |
| ------- | ------- |
| provisioning | Azure.Provisioning |
| provisioning | Azure.Provisioning.AppConfiguration |
| provisioning | Azure.Provisioning.AppContainers |
| provisioning | Azure.Provisioning.ApplicationInsights |
| provisioning | Azure.Provisioning.AppService |
| provisioning | Azure.Provisioning.CognitiveServices |
| provisioning | Azure.Provisioning.Communication |
| provisioning | Azure.Provisioning.ContainerRegistry |
| provisioning | Azure.Provisioning.ContainerService |
| provisioning | Azure.Provisioning.CosmosDB |
| provisioning | Azure.Provisioning.Deployment |
| provisioning | Azure.Provisioning.Dns |
| provisioning | Azure.Provisioning.EventGrid |
| provisioning | Azure.Provisioning.EventHubs |
| provisioning | Azure.Provisioning.FrontDoor |
| provisioning | Azure.Provisioning.KeyVault |
| provisioning | Azure.Provisioning.Kubernetes |
| provisioning | Azure.Provisioning.KubernetesConfiguration |
| provisioning | Azure.Provisioning.Kusto |
| provisioning | Azure.Provisioning.Network |
| provisioning | Azure.Provisioning.OperationalInsights |
| provisioning | Azure.Provisioning.PostgreSql |
| provisioning | Azure.Provisioning.PrivateDns |
| provisioning | Azure.Provisioning.Redis |
| provisioning | Azure.Provisioning.RedisEnterprise |
| provisioning | Azure.Provisioning.Search |
| provisioning | Azure.Provisioning.ServiceBus |
| provisioning | Azure.Provisioning.SignalR |
| provisioning | Azure.Provisioning.Sql |
| provisioning | Azure.Provisioning.Storage |
| provisioning | Azure.Provisioning.WebPubSub |


## Libraries with No Generator

Libraries with no generator have neither autorest.md nor tsp-location.yaml files. Total: 47

| Service | Library |
| ------- | ------- |
| agentserver | Azure.AI.AgentServer.AgentFramework |
| agentserver | Azure.AI.AgentServer.Core |
| ai | Azure.AI.Inference |
| cloudmachine | Azure.Projects |
| cloudmachine | Azure.Projects.AI |
| cloudmachine | Azure.Projects.AI.Foundry |
| cloudmachine | Azure.Projects.Provisioning |
| cloudmachine | Azure.Projects.Tsp |
| cloudmachine | Azure.Projects.Web |
| communication | Azure.Communication.Common |
| core | Azure.Core |
| core | Azure.Core.Amqp |
| core | Azure.Core.Experimental |
| core | Azure.Core.Expressions.DataFactory |
| eventgrid | Azure.Messaging.EventGrid |
| eventhub | Azure.Messaging.EventHubs |
| eventhub | Azure.Messaging.EventHubs.Processor |
| eventhub | Azure.Messaging.EventHubs.Shared |
| extensions | Azure.Extensions.AspNetCore.Configuration.Secrets |
| extensions | Azure.Extensions.AspNetCore.DataProtection.Blobs |
| extensions | Azure.Extensions.AspNetCore.DataProtection.Keys |
| face | Azure.AI.Vision.Face |
| healthinsights | Azure.Health.Insights.CancerProfiling |
| healthinsights | Azure.Health.Insights.ClinicalMatching |
| healthinsights | Azure.Health.Insights.RadiologyInsights |
| identity | Azure.Identity |
| identity | Azure.Identity.Broker |
| keyvault | Azure.Security.KeyVault.Certificates |
| keyvault | Azure.Security.KeyVault.Keys |
| keyvault | Azure.Security.KeyVault.Secrets |
| keyvault | Azure.Security.KeyVault.Shared |
| loadtestservice | Azure.Developer.Playwright |
| loadtestservice | Azure.Developer.Playwright.MSTest |
| loadtestservice | Azure.Developer.Playwright.NUnit |
| maps | Azure.Maps.Common |
| modelsrepository | Azure.IoT.ModelsRepository |
| monitor | Azure.Monitor.OpenTelemetry.AspNetCore |
| openai | Azure.AI.OpenAI.Assistants |
| servicebus | Azure.Messaging.ServiceBus |
| storage | Azure.Storage.Blobs.ChangeFeed |
| storage | Azure.Storage.Common |
| storage | Azure.Storage.DataMovement |
| storage | Azure.Storage.DataMovement.Blobs |
| storage | Azure.Storage.DataMovement.Files.Shares |
| storage | Azure.Storage.Internal.Avro |
| synapse | Azure.Analytics.Synapse.Shared |
| webpubsub | Azure.Messaging.WebPubSub.Client |
