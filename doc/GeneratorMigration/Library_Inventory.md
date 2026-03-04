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

- Total libraries: 405
- Management Plane (MPG): 229
  - Autorest/Swagger: 131
  - New Emitter (TypeSpec): 98
  - Old TypeSpec: 0
- Data Plane (DPG): 145
  - Autorest/Swagger: 55
  - New Emitter (TypeSpec): 37
  - Old TypeSpec: 4
- Provisioning: 31
  - Reflection-based generator: 31
  - TypeSpec-based generator: 0
- No generator: 49


## Data Plane Libraries (DPG) - Migrated to New Emitter

Libraries that provide client APIs for Azure services and have been migrated to the new TypeSpec emitter.

**Migration Status**: 37 / 41 (90.2%)

| Service | Library | New Emitter | Using SCM |
| ------- | ------- | ----------- | --------- |
| ai | Azure.AI.Agents.Persistent |  |  |
| ai | Azure.AI.Projects | âœ… | âœ… |
| ai | Azure.AI.Projects.OpenAI | âœ… | âœ… |
| anomalydetector | Azure.AI.AnomalyDetector | âœ… |  |
| appconfiguration | Azure.Data.AppConfiguration | âœ… |  |
| batch | Azure.Compute.Batch | âœ… |  |
| cognitivelanguage | Azure.AI.Language.Conversations | âœ… |  |
| cognitivelanguage | Azure.AI.Language.Conversations.Authoring |  |  |
| cognitivelanguage | Azure.AI.Language.QuestionAnswering.Authoring | âœ… |  |
| cognitivelanguage | Azure.AI.Language.QuestionAnswering.Inference | âœ… |  |
| cognitivelanguage | Azure.AI.Language.Text | âœ… |  |
| cognitivelanguage | Azure.AI.Language.Text.Authoring | âœ… |  |
| communication | Azure.Communication.JobRouter | âœ… |  |
| communication | Azure.Communication.Messages |  |  |
| communication | Azure.Communication.ProgrammableConnectivity | âœ… |  |
| confidentialledger | Azure.Security.CodeTransparency | âœ… |  |
| contentsafety | Azure.AI.ContentSafety | âœ… |  |
| contentunderstanding | Azure.AI.ContentUnderstanding | âœ… |  |
| devcenter | Azure.Developer.DevCenter | âœ… |  |
| documentintelligence | Azure.AI.DocumentIntelligence | âœ… |  |
| easm | Azure.Analytics.Defender.Easm | âœ… |  |
| eventgrid | Azure.Messaging.EventGrid.Namespaces | âœ… |  |
| eventgrid | Azure.Messaging.EventGrid.SystemEvents | âœ… |  |
| healthdataaiservices | Azure.Health.Deidentification | âœ… |  |
| keyvault | Azure.Security.KeyVault.Administration | âœ… |  |
| loadtestservice | Azure.Developer.LoadTesting | âœ… |  |
| monitor | Azure.Monitor.Ingestion | âœ… |  |
| monitor | Azure.Monitor.Query.Logs | âœ… |  |
| monitor | Azure.Monitor.Query.Metrics | âœ… |  |
| onlineexperimentation | Azure.Analytics.OnlineExperimentation | âœ… |  |
| openai | Azure.AI.OpenAI | âœ… | âœ… |
| planetarycomputer | Azure.Analytics.PlanetaryComputer | âœ… |  |
| purview | Azure.Analytics.Purview.DataMap | âœ… |  |
| schemaregistry | Azure.Data.SchemaRegistry | âœ… |  |
| search | Azure.Search.Documents | âœ… |  |
| template | Azure.Template | âœ… |  |
| transcription | Azure.AI.Speech.Transcription | âœ… | âœ… |
| translation | Azure.AI.Translation.Document |  |  |
| translation | Azure.AI.Translation.Text | âœ… |  |
| vision | Azure.AI.Vision.ImageAnalysis | âœ… |  |
| voicelive | Azure.AI.VoiceLive | âœ… |  |


## Data Plane Libraries (DPG) - Still on Swagger

Libraries that have not yet been migrated to the new TypeSpec emitter. Total: 55

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
| monitor | Azure.Monitor.OpenTelemetry.Exporter |
| monitor | Azure.Monitor.OpenTelemetry.LiveMetrics |
| personalizer | Azure.AI.Personalizer |
| purview | Azure.Analytics.Purview.Account |
| purview | Azure.Analytics.Purview.Administration |
| purview | Azure.Analytics.Purview.Catalog |
| purview | Azure.Analytics.Purview.Scanning |
| purview | Azure.Analytics.Purview.Sharing |
| purview | Azure.Analytics.Purview.Workflows |
| quantum | Azure.Quantum.Jobs |
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
| testservice | Azure.Data.TestService |
| textanalytics | Azure.AI.TextAnalytics |
| textanalytics | Azure.AI.TextAnalytics.Legacy.Shared |
| timeseriesinsights | Azure.IoT.TimeSeriesInsights |
| videoanalyzer | Azure.Media.VideoAnalyzer.Edge |
| webpubsub | Azure.Messaging.WebPubSub |


## Management Plane Libraries (MPG) - Migrated to New Emitter

Libraries that provide resource management APIs for Azure services and have been migrated to the new TypeSpec emitter.

**Migration Status**: 98 / 98 (100%)

| Service | Library | New Emitter |
| ------- | ------- | ----------- |
| advisor | Azure.ResourceManager.Advisor | âœ… |
| agricultureplatform | Azure.ResourceManager.AgriculturePlatform | âœ… |
| appcomplianceautomation | Azure.ResourceManager.AppComplianceAutomation | âœ… |
| appconfiguration | Azure.ResourceManager.AppConfiguration | âœ… |
| arizeaiobservabilityeval | Azure.ResourceManager.ArizeAIObservabilityEval | âœ… |
| artifactsigning | Azure.ResourceManager.ArtifactSigning | âœ… |
| astronomer | Azure.ResourceManager.Astro | âœ… |
| attestation | Azure.ResourceManager.Attestation | âœ… |
| avs | Azure.ResourceManager.Avs | âœ… |
| azurelargeinstance | Azure.ResourceManager.LargeInstance | âœ… |
| azurestackhci | Azure.ResourceManager.Hci.Vm | âœ… |
| carbon | Azure.ResourceManager.CarbonOptimization | âœ… |
| certificateregistration | Azure.ResourceManager.CertificateRegistration | âœ… |
| chaos | Azure.ResourceManager.Chaos | âœ… |
| cloudhealth | Azure.ResourceManager.CloudHealth | âœ… |
| computefleet | Azure.ResourceManager.ComputeFleet | âœ… |
| computelimit | Azure.ResourceManager.ComputeLimit | âœ… |
| computerecommender | Azure.ResourceManager.Compute.Recommender | âœ… |
| computeschedule | Azure.ResourceManager.ComputeSchedule | âœ… |
| connectedcache | Azure.ResourceManager.ConnectedCache | âœ… |
| containerorchestratorruntime | Azure.ResourceManager.ContainerOrchestratorRuntime | âœ… |
| databasewatcher | Azure.ResourceManager.DatabaseWatcher | âœ… |
| databox | Azure.ResourceManager.DataBox | âœ… |
| dellstorage | Azure.ResourceManager.Dell.Storage | âœ… |
| dependencymap | Azure.ResourceManager.DependencyMap | âœ… |
| desktopvirtualization | Azure.ResourceManager.DesktopVirtualization | âœ… |
| deviceprovisioningservices | Azure.ResourceManager.DeviceProvisioningServices | âœ… |
| deviceregistry | Azure.ResourceManager.DeviceRegistry | âœ… |
| devopsinfrastructure | Azure.ResourceManager.DevOpsInfrastructure | âœ… |
| devtestlabs | Azure.ResourceManager.DevTestLabs | âœ… |
| disconnectedoperations | Azure.ResourceManager.DisconnectedOperations | âœ… |
| durabletask | Azure.ResourceManager.DurableTask | âœ… |
| dynatrace | Azure.ResourceManager.Dynatrace | âœ… |
| edgeactions | Azure.ResourceManager.EdgeActions | âœ… |
| edgeorder | Azure.ResourceManager.EdgeOrder | âœ… |
| edgezones | Azure.ResourceManager.EdgeZones | âœ… |
| elastic | Azure.ResourceManager.Elastic | âœ… |
| elasticsan | Azure.ResourceManager.ElasticSan | âœ… |
| fabric | Azure.ResourceManager.Fabric | âœ… |
| fileshares | Azure.ResourceManager.FileShares | âœ… |
| fleet | Azure.ResourceManager.ContainerServiceFleet | âœ… |
| grafana | Azure.ResourceManager.Grafana | âœ… |
| guestconfiguration | Azure.ResourceManager.GuestConfiguration | âœ… |
| hardwaresecuritymodules | Azure.ResourceManager.HardwareSecurityModules | âœ… |
| healthbot | Azure.ResourceManager.HealthBot | âœ… |
| healthdataaiservices | Azure.ResourceManager.HealthDataAIServices | âœ… |
| hybridconnectivity | Azure.ResourceManager.HybridConnectivity | âœ… |
| hybridkubernetes | Azure.ResourceManager.Kubernetes | âœ… |
| impactreporting | Azure.ResourceManager.ImpactReporting | âœ… |
| informaticadatamanagement | Azure.ResourceManager.InformaticaDataManagement | âœ… |
| iotoperations | Azure.ResourceManager.IotOperations | âœ… |
| keyvault | Azure.ResourceManager.KeyVault | âœ… |
| lambdatesthyperexecute | Azure.ResourceManager.LambdaTestHyperExecute | âœ… |
| loadtestservice | Azure.ResourceManager.LoadTesting | âœ… |
| managedops | Azure.ResourceManager.ManagedOps | âœ… |
| mongocluster | Azure.ResourceManager.MongoCluster | âœ… |
| mongodbatlas | Azure.ResourceManager.MongoDBAtlas | âœ… |
| mysql | Azure.ResourceManager.MySql | âœ… |
| neonpostgres | Azure.ResourceManager.NeonPostgres | âœ… |
| nginx | Azure.ResourceManager.Nginx | âœ… |
| onlineexperimentation | Azure.ResourceManager.OnlineExperimentation | âœ… |
| oracle | Azure.ResourceManager.OracleDatabase | âœ… |
| paloaltonetworks.ngfw | Azure.ResourceManager.PaloAltoNetworks.Ngfw | âœ… |
| peering | Azure.ResourceManager.Peering | âœ… |
| pineconevectordb | Azure.ResourceManager.PineconeVectorDB | âœ… |
| planetarycomputer | Azure.ResourceManager.PlanetaryComputer | âœ… |
| playwright | Azure.ResourceManager.Playwright | âœ… |
| portalservices | Azure.ResourceManager.PortalServicesCopilot | âœ… |
| powerbidedicated | Azure.ResourceManager.PowerBIDedicated | âœ… |
| purestorageblock | Azure.ResourceManager.PureStorageBlock | âœ… |
| quantum | Azure.ResourceManager.Quantum | âœ… |
| qumulo | Azure.ResourceManager.Qumulo | âœ… |
| quota | Azure.ResourceManager.Quota | âœ… |
| recoveryservices | Azure.ResourceManager.RecoveryServices | âœ… |
| recoveryservices-datareplication | Azure.ResourceManager.RecoveryServicesDataReplication | âœ… |
| resourceconnector | Azure.ResourceManager.ResourceConnector | âœ… |
| resources | Azure.ResourceManager.Resources.Bicep | âœ… |
| resources | Azure.ResourceManager.Resources.DeploymentStacks | âœ… |
| secretsstoreextension | Azure.ResourceManager.SecretsStoreExtension | âœ… |
| selfhelp | Azure.ResourceManager.SelfHelp | âœ… |
| servicefabricmanagedclusters | Azure.ResourceManager.ServiceFabricManagedClusters | âœ… |
| servicenetworking | Azure.ResourceManager.ServiceNetworking | âœ… |
| signalr | Azure.ResourceManager.SignalR | âœ… |
| sitemanager | Azure.ResourceManager.SiteManager | âœ… |
| sphere | Azure.ResourceManager.Sphere | âœ… |
| sqlvirtualmachine | Azure.ResourceManager.SqlVirtualMachine | âœ… |
| standbypool | Azure.ResourceManager.StandbyPool | âœ… |
| storageactions | Azure.ResourceManager.StorageActions | âœ… |
| storagediscovery | Azure.ResourceManager.StorageDiscovery | âœ… |
| storagemover | Azure.ResourceManager.StorageMover | âœ… |
| storagesync | Azure.ResourceManager.StorageSync | âœ… |
| terraform | Azure.ResourceManager.Terraform | âœ… |
| trafficmanager | Azure.ResourceManager.TrafficManager | âœ… |
| trustedsigning | Azure.ResourceManager.TrustedSigning | âœ… |
| virtualenclaves | Azure.ResourceManager.VirtualEnclaves | âœ… |
| weightsandbiases | Azure.ResourceManager.WeightsAndBiases | âœ… |
| workloadorchestration | Azure.ResourceManager.WorkloadOrchestration | âœ… |
| workloadssapvirtualinstance | Azure.ResourceManager.WorkloadsSapVirtualInstance | âœ… |


## Management Plane Libraries (MPG) - Still on Swagger

Libraries that have not yet been migrated to the new TypeSpec emitter. Total: 131

| Service | Library |
| ------- | ------- |
| agrifood | Azure.ResourceManager.AgFoodPlatform |
| alertsmanagement | Azure.ResourceManager.AlertsManagement |
| analysisservices | Azure.ResourceManager.Analysis |
| apicenter | Azure.ResourceManager.ApiCenter |
| apimanagement | Azure.ResourceManager.ApiManagement |
| applicationinsights | Azure.ResourceManager.ApplicationInsights |
| appplatform | Azure.ResourceManager.AppPlatform |
| arc-scvmm | Azure.ResourceManager.ScVmm |
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
| devcenter | Azure.ResourceManager.DevCenter |
| deviceupdate | Azure.ResourceManager.DeviceUpdate |
| devspaces | Azure.ResourceManager.DevSpaces |
| digitaltwins | Azure.ResourceManager.DigitalTwins |
| dns | Azure.ResourceManager.Dns |
| dnsresolver | Azure.ResourceManager.DnsResolver |
| eventgrid | Azure.ResourceManager.EventGrid |
| eventhub | Azure.ResourceManager.EventHubs |
| extendedlocation | Azure.ResourceManager.ExtendedLocations |
| fluidrelay | Azure.ResourceManager.FluidRelay |
| frontdoor | Azure.ResourceManager.FrontDoor |
| graphservices | Azure.ResourceManager.GraphServices |
| hdinsight | Azure.ResourceManager.HDInsight |
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
| migrationassessment | Azure.ResourceManager.Migration.Assessment |
| migrationdiscoverysap | Azure.ResourceManager.MigrationDiscoverySap |
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
| policyinsights | Azure.ResourceManager.PolicyInsights |
| postgresql | Azure.ResourceManager.PostgreSql |
| privatedns | Azure.ResourceManager.PrivateDns |
| providerhub | Azure.ResourceManager.ProviderHub |
| purview | Azure.ResourceManager.Purview |
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
| search | Azure.ResourceManager.Search |
| securitycenter | Azure.ResourceManager.SecurityCenter |
| securitydevops | Azure.ResourceManager.SecurityDevOps |
| securityinsights | Azure.ResourceManager.SecurityInsights |
| servicebus | Azure.ResourceManager.ServiceBus |
| servicefabric | Azure.ResourceManager.ServiceFabric |
| servicegroups | Azure.ResourceManager.ServiceGroups |
| servicelinker | Azure.ResourceManager.ServiceLinker |
| springappdiscovery | Azure.ResourceManager.SpringAppDiscovery |
| sqlmanagement | Azure.ResourceManager.Sql |
| storage | Azure.ResourceManager.Storage |
| storagecache | Azure.ResourceManager.StorageCache |
| storagepool | Azure.ResourceManager.StoragePool |
| streamanalytics | Azure.ResourceManager.StreamAnalytics |
| subscription | Azure.ResourceManager.Subscription |
| support | Azure.ResourceManager.Support |
| synapse | Azure.ResourceManager.Synapse |
| voiceservices | Azure.ResourceManager.VoiceServices |
| webpubsub | Azure.ResourceManager.WebPubSub |
| websites | Azure.ResourceManager.AppService |
| workloadmonitor | Azure.ResourceManager.WorkloadMonitor |
| workloads | Azure.ResourceManager.Workloads |


## Provisioning Libraries

Libraries that provide infrastructure-as-code capabilities for Azure services. These libraries allow you to declaratively specify Azure infrastructure natively in .NET and generate Bicep templates for deployment.

**Migration Status**: 0 / 31 migrated to TypeSpec-based generator

| Service | Library | Mgmt Peer Library | Generator |
| ------- | ------- | ----------------- | --------- |
| provisioning | Azure.Provisioning | Azure.ResourceManager<br>Azure.ResourceManager.Resources<br>Azure.ResourceManager.Authorization<br>Azure.ResourceManager.ManagedServiceIdentities | Reflection |
| provisioning | Azure.Provisioning.AppConfiguration | Azure.ResourceManager.AppConfiguration âœ… | Reflection |
| provisioning | Azure.Provisioning.AppContainers | Azure.ResourceManager.AppContainers | Reflection |
| provisioning | Azure.Provisioning.ApplicationInsights | Azure.ResourceManager.ApplicationInsights | Reflection |
| provisioning | Azure.Provisioning.AppService | Azure.ResourceManager.AppService | Reflection |
| provisioning | Azure.Provisioning.CognitiveServices | Azure.ResourceManager.CognitiveServices | Reflection |
| provisioning | Azure.Provisioning.Communication | Azure.ResourceManager.Communication | Reflection |
| provisioning | Azure.Provisioning.ContainerRegistry | Azure.ResourceManager.ContainerRegistry | Reflection |
| provisioning | Azure.Provisioning.ContainerService | Azure.ResourceManager.ContainerService | Reflection |
| provisioning | Azure.Provisioning.CosmosDB | Azure.ResourceManager.CosmosDB | Reflection |
| provisioning | Azure.Provisioning.Deployment | Azure.ResourceManager<br>Azure.ResourceManager.Resources | Reflection |
| provisioning | Azure.Provisioning.Dns | Azure.ResourceManager.Dns | Reflection |
| provisioning | Azure.Provisioning.EventGrid | Azure.ResourceManager.EventGrid | Reflection |
| provisioning | Azure.Provisioning.EventHubs | Azure.ResourceManager.EventHubs | Reflection |
| provisioning | Azure.Provisioning.FrontDoor | Azure.ResourceManager.FrontDoor | Reflection |
| provisioning | Azure.Provisioning.KeyVault | Azure.ResourceManager.KeyVault âœ… | Reflection |
| provisioning | Azure.Provisioning.Kubernetes | Azure.ResourceManager.Kubernetes âœ… | Reflection |
| provisioning | Azure.Provisioning.KubernetesConfiguration | Azure.ResourceManager.KubernetesConfiguration | Reflection |
| provisioning | Azure.Provisioning.Kusto | Azure.ResourceManager.Kusto | Reflection |
| provisioning | Azure.Provisioning.Network | Azure.ResourceManager.Network | Reflection |
| provisioning | Azure.Provisioning.OperationalInsights | Azure.ResourceManager.OperationalInsights | Reflection |
| provisioning | Azure.Provisioning.PostgreSql | Azure.ResourceManager.PostgreSql | Reflection |
| provisioning | Azure.Provisioning.PrivateDns | Azure.ResourceManager.PrivateDns | Reflection |
| provisioning | Azure.Provisioning.Redis | Azure.ResourceManager.Redis | Reflection |
| provisioning | Azure.Provisioning.RedisEnterprise | Azure.ResourceManager.RedisEnterprise | Reflection |
| provisioning | Azure.Provisioning.Search | Azure.ResourceManager.Search | Reflection |
| provisioning | Azure.Provisioning.ServiceBus | Azure.ResourceManager.ServiceBus | Reflection |
| provisioning | Azure.Provisioning.SignalR | Azure.ResourceManager.SignalR âœ… | Reflection |
| provisioning | Azure.Provisioning.Sql | Azure.ResourceManager.Sql | Reflection |
| provisioning | Azure.Provisioning.Storage | Azure.ResourceManager.Storage | Reflection |
| provisioning | Azure.Provisioning.WebPubSub | Azure.ResourceManager.WebPubSub | Reflection |


## Libraries with No Generator

Libraries with no generator have neither autorest.md nor tsp-location.yaml files. Total: 49

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
| tools | Azure.GeneratorAgent |
| tools | Azure.SdkAnalyzers |
| webpubsub | Azure.Messaging.WebPubSub.Client |
