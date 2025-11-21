# Azure SDK for .NET Libraries Inventory

## Summary

- Total libraries: 395
- Management Plane (MPG): 226
  - Autorest/Swagger: 160
  - New Emitter (TypeSpec): 24
  - Old TypeSpec: 42
- Data Plane (DPG): 169
  - Autorest/Swagger: 87
  - New Emitter (TypeSpec): 16
  - Old TypeSpec: 17
- No generator: 49


## Data Plane Libraries (DPG) - Migrated to New Emitter

Libraries that provide client APIs for Azure services and have been migrated to the new TypeSpec emitter.

**Migration Status**: 16 / 169 (9.5%)

| Service | Library | New Emitter |
| ------- | ------- | ----------- |
| agentserver | Azure.AI.AgentServer.AgentFramework |  |
| agentserver | Azure.AI.AgentServer.Core |  |
| ai | Azure.AI.Agents.Persistent |  |
| ai | Azure.AI.Inference |  |
| ai | Azure.AI.Projects | <span style="color:green">✓</span> |
| ai | Azure.AI.VoiceLive | <span style="color:green">✓</span> |
| anomalydetector | Azure.AI.AnomalyDetector |  |
| appconfiguration | Azure.Data.AppConfiguration | <span style="color:green">✓</span> |
| batch | Azure.Compute.Batch |  |
| cloudmachine | Azure.Projects |  |
| cloudmachine | Azure.Projects.AI |  |
| cloudmachine | Azure.Projects.AI.Foundry |  |
| cloudmachine | Azure.Projects.Provisioning |  |
| cloudmachine | Azure.Projects.Tsp |  |
| cloudmachine | Azure.Projects.Web |  |
| cognitivelanguage | Azure.AI.Language.Conversations |  |
| cognitivelanguage | Azure.AI.Language.Conversations.Authoring |  |
| cognitivelanguage | Azure.AI.Language.Text |  |
| cognitivelanguage | Azure.AI.Language.Text.Authoring |  |
| communication | Azure.Communication.Common |  |
| communication | Azure.Communication.JobRouter |  |
| communication | Azure.Communication.Messages |  |
| communication | Azure.Communication.ProgrammableConnectivity |  |
| confidentialledger | Azure.Security.CodeTransparency |  |
| contentsafety | Azure.AI.ContentSafety |  |
| core | Azure.Core |  |
| core | Azure.Core.Amqp |  |
| core | Azure.Core.Experimental |  |
| core | Azure.Core.Expressions.DataFactory |  |
| devcenter | Azure.Developer.DevCenter |  |
| documentintelligence | Azure.AI.DocumentIntelligence | <span style="color:green">✓</span> |
| easm | Azure.Analytics.Defender.Easm | <span style="color:green">✓</span> |
| eventgrid | Azure.Messaging.EventGrid |  |
| eventgrid | Azure.Messaging.EventGrid.Namespaces | <span style="color:green">✓</span> |
| eventgrid | Azure.Messaging.EventGrid.SystemEvents | <span style="color:green">✓</span> |
| eventhub | Azure.Messaging.EventHubs |  |
| eventhub | Azure.Messaging.EventHubs.Processor |  |
| eventhub | Azure.Messaging.EventHubs.Shared |  |
| extensions | Azure.Extensions.AspNetCore.Configuration.Secrets |  |
| extensions | Azure.Extensions.AspNetCore.DataProtection.Blobs |  |
| extensions | Azure.Extensions.AspNetCore.DataProtection.Keys |  |
| face | Azure.AI.Vision.Face |  |
| healthdataaiservices | Azure.Health.Deidentification | <span style="color:green">✓</span> |
| healthinsights | Azure.Health.Insights.CancerProfiling |  |
| healthinsights | Azure.Health.Insights.ClinicalMatching |  |
| healthinsights | Azure.Health.Insights.RadiologyInsights |  |
| identity | Azure.Identity |  |
| identity | Azure.Identity.Broker |  |
| keyvault | Azure.Security.KeyVault.Administration | <span style="color:green">✓</span> |
| keyvault | Azure.Security.KeyVault.Certificates |  |
| keyvault | Azure.Security.KeyVault.Keys |  |
| keyvault | Azure.Security.KeyVault.Secrets |  |
| keyvault | Azure.Security.KeyVault.Shared |  |
| loadtestservice | Azure.Developer.LoadTesting |  |
| loadtestservice | Azure.Developer.Playwright |  |
| loadtestservice | Azure.Developer.Playwright.MSTest |  |
| loadtestservice | Azure.Developer.Playwright.NUnit |  |
| maps | Azure.Maps.Common |  |
| modelsrepository | Azure.IoT.ModelsRepository |  |
| monitor | Azure.Monitor.Ingestion | <span style="color:green">✓</span> |
| monitor | Azure.Monitor.OpenTelemetry.AspNetCore |  |
| monitor | Azure.Monitor.Query.Logs | <span style="color:green">✓</span> |
| monitor | Azure.Monitor.Query.Metrics | <span style="color:green">✓</span> |
| onlineexperimentation | Azure.Analytics.OnlineExperimentation |  |
| openai | Azure.AI.OpenAI | <span style="color:green">✓</span> |
| openai | Azure.AI.OpenAI.Assistants |  |
| provisioning | Azure.Provisioning.Deployment |  |
| provisioning | Azure.Provisioning.Dns |  |
| purview | Azure.Analytics.Purview.DataMap |  |
| schemaregistry | Azure.Data.SchemaRegistry | <span style="color:green">✓</span> |
| servicebus | Azure.Messaging.ServiceBus |  |
| storage | Azure.Storage.Blobs.ChangeFeed |  |
| storage | Azure.Storage.Common |  |
| storage | Azure.Storage.DataMovement |  |
| storage | Azure.Storage.DataMovement.Blobs |  |
| storage | Azure.Storage.DataMovement.Files.Shares |  |
| storage | Azure.Storage.Internal.Avro |  |
| synapse | Azure.Analytics.Synapse.Shared |  |
| translation | Azure.AI.Translation.Document |  |
| translation | Azure.AI.Translation.Text | <span style="color:green">✓</span> |
| vision | Azure.AI.Vision.ImageAnalysis | <span style="color:green">✓</span> |
| webpubsub | Azure.Messaging.WebPubSub.Client |  |


## Data Plane Libraries (DPG) - Still on Swagger

Libraries that have not yet been migrated to the new TypeSpec emitter. Total: 87

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
| provisioning | Azure.Provisioning.Redis |
| provisioning | Azure.Provisioning.RedisEnterprise |
| provisioning | Azure.Provisioning.Search |
| provisioning | Azure.Provisioning.ServiceBus |
| provisioning | Azure.Provisioning.SignalR |
| provisioning | Azure.Provisioning.Sql |
| provisioning | Azure.Provisioning.Storage |
| provisioning | Azure.Provisioning.WebPubSub |
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
| template | Azure.Template |
| textanalytics | Azure.AI.TextAnalytics |
| textanalytics | Azure.AI.TextAnalytics.Legacy.Shared |
| timeseriesinsights | Azure.IoT.TimeSeriesInsights |
| videoanalyzer | Azure.Media.VideoAnalyzer.Edge |
| webpubsub | Azure.Messaging.WebPubSub |


## Management Plane Libraries (MPG) - Migrated to New Emitter

Libraries that provide resource management APIs for Azure services and have been migrated to the new TypeSpec emitter.

**Migration Status**: 24 / 226 (10.6%)

| Service | Library | New Emitter |
| ------- | ------- | ----------- |
| agricultureplatform | Azure.ResourceManager.AgriculturePlatform | <span style="color:green">✓</span> |
| arizeaiobservabilityeval | Azure.ResourceManager.ArizeAIObservabilityEval | <span style="color:green">✓</span> |
| avs | Azure.ResourceManager.Avs |  |
| azurestackhci | Azure.ResourceManager.Hci.Vm |  |
| carbon | Azure.ResourceManager.CarbonOptimization |  |
| chaos | Azure.ResourceManager.Chaos |  |
| cloudhealth | Azure.ResourceManager.CloudHealth | <span style="color:green">✓</span> |
| computefleet | Azure.ResourceManager.ComputeFleet |  |
| computelimit | Azure.ResourceManager.ComputeLimit | <span style="color:green">✓</span> |
| computerecommender | Azure.ResourceManager.Compute.Recommender | <span style="color:green">✓</span> |
| computeschedule | Azure.ResourceManager.ComputeSchedule |  |
| connectedcache | Azure.ResourceManager.ConnectedCache | <span style="color:green">✓</span> |
| containerorchestratorruntime | Azure.ResourceManager.ContainerOrchestratorRuntime |  |
| databasewatcher | Azure.ResourceManager.DatabaseWatcher | <span style="color:green">✓</span> |
| databox | Azure.ResourceManager.DataBox |  |
| dellstorage | Azure.ResourceManager.Dell.Storage | <span style="color:green">✓</span> |
| dependencymap | Azure.ResourceManager.DependencyMap | <span style="color:green">✓</span> |
| deviceprovisioningservices | Azure.ResourceManager.DeviceProvisioningServices |  |
| deviceregistry | Azure.ResourceManager.DeviceRegistry | <span style="color:green">✓</span> |
| devopsinfrastructure | Azure.ResourceManager.DevOpsInfrastructure |  |
| disconnectedoperations | Azure.ResourceManager.DisconnectedOperations |  |
| durabletask | Azure.ResourceManager.DurableTask | <span style="color:green">✓</span> |
| elastic | Azure.ResourceManager.Elastic |  |
| elasticsan | Azure.ResourceManager.ElasticSan |  |
| fabric | Azure.ResourceManager.Fabric |  |
| grafana | Azure.ResourceManager.Grafana |  |
| hardwaresecuritymodules | Azure.ResourceManager.HardwareSecurityModules |  |
| healthdataaiservices | Azure.ResourceManager.HealthDataAIServices | <span style="color:green">✓</span> |
| hybridconnectivity | Azure.ResourceManager.HybridConnectivity |  |
| hybridkubernetes | Azure.ResourceManager.Kubernetes | <span style="color:green">✓</span> |
| impactreporting | Azure.ResourceManager.ImpactReporting |  |
| informaticadatamanagement | Azure.ResourceManager.InformaticaDataManagement | <span style="color:green">✓</span> |
| iotoperations | Azure.ResourceManager.IotOperations |  |
| lambdatesthyperexecute | Azure.ResourceManager.LambdaTestHyperExecute | <span style="color:green">✓</span> |
| mongocluster | Azure.ResourceManager.MongoCluster |  |
| mongodbatlas | Azure.ResourceManager.MongoDBAtlas |  |
| mysql | Azure.ResourceManager.MySql |  |
| neonpostgres | Azure.ResourceManager.NeonPostgres |  |
| onlineexperimentation | Azure.ResourceManager.OnlineExperimentation |  |
| oracle | Azure.ResourceManager.OracleDatabase |  |
| paloaltonetworks.ngfw | Azure.ResourceManager.PaloAltoNetworks.Ngfw | <span style="color:green">✓</span> |
| pineconevectordb | Azure.ResourceManager.PineconeVectorDB | <span style="color:green">✓</span> |
| planetarycomputer | Azure.ResourceManager.PlanetaryComputer | <span style="color:green">✓</span> |
| playwright | Azure.ResourceManager.Playwright | <span style="color:green">✓</span> |
| portalservices | Azure.ResourceManager.PortalServicesCopilot | <span style="color:green">✓</span> |
| purestorageblock | Azure.ResourceManager.PureStorageBlock |  |
| qumulo | Azure.ResourceManager.Qumulo |  |
| quota | Azure.ResourceManager.Quota |  |
| recoveryservices | Azure.ResourceManager.RecoveryServices |  |
| recoveryservices-datareplication | Azure.ResourceManager.RecoveryServicesDataReplication |  |
| resources | Azure.ResourceManager.Resources.Bicep |  |
| secretsstoreextension | Azure.ResourceManager.SecretsStoreExtension |  |
| selfhelp | Azure.ResourceManager.SelfHelp |  |
| servicefabricmanagedclusters | Azure.ResourceManager.ServiceFabricManagedClusters |  |
| servicenetworking | Azure.ResourceManager.ServiceNetworking |  |
| sitemanager | Azure.ResourceManager.SiteManager |  |
| standbypool | Azure.ResourceManager.StandbyPool |  |
| storageactions | Azure.ResourceManager.StorageActions | <span style="color:green">✓</span> |
| storagediscovery | Azure.ResourceManager.StorageDiscovery | <span style="color:green">✓</span> |
| storagemover | Azure.ResourceManager.StorageMover |  |
| terraform | Azure.ResourceManager.Terraform |  |
| trustedsigning | Azure.ResourceManager.TrustedSigning | <span style="color:green">✓</span> |
| virtualenclaves | Azure.ResourceManager.VirtualEnclaves |  |
| weightsandbiases | Azure.ResourceManager.WeightsAndBiases | <span style="color:green">✓</span> |
| workloadorchestration | Azure.ResourceManager.WorkloadOrchestration |  |
| workloadssapvirtualinstance | Azure.ResourceManager.WorkloadsSapVirtualInstance |  |


## Management Plane Libraries (MPG) - Still on Swagger

Libraries that have not yet been migrated to the new TypeSpec emitter. Total: 160

| Service | Library |
| ------- | ------- |
| advisor | Azure.ResourceManager.Advisor |
| agrifood | Azure.ResourceManager.AgFoodPlatform |
| alertsmanagement | Azure.ResourceManager.AlertsManagement |
| analysisservices | Azure.ResourceManager.Analysis |
| apicenter | Azure.ResourceManager.ApiCenter |
| apimanagement | Azure.ResourceManager.ApiManagement |
| appcomplianceautomation | Azure.ResourceManager.AppComplianceAutomation |
| appconfiguration | Azure.ResourceManager.AppConfiguration |
| applicationinsights | Azure.ResourceManager.ApplicationInsights |
| appplatform | Azure.ResourceManager.AppPlatform |
| arc-scvmm | Azure.ResourceManager.ScVmm |
| astronomer | Azure.ResourceManager.Astro |
| attestation | Azure.ResourceManager.Attestation |
| authorization | Azure.ResourceManager.Authorization |
| automanage | Azure.ResourceManager.Automanage |
| automation | Azure.ResourceManager.Automation |
| azurelargeinstance | Azure.ResourceManager.LargeInstance |
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
| dynatrace | Azure.ResourceManager.Dynatrace |
| edgeorder | Azure.ResourceManager.EdgeOrder |
| edgezones | Azure.ResourceManager.EdgeZones |
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
| healthbot | Azure.ResourceManager.HealthBot |
| healthcareapis | Azure.ResourceManager.HealthcareApis |
| hybridaks | Azure.ResourceManager.HybridContainerService |
| hybridcompute | Azure.ResourceManager.HybridCompute |
| hybridnetwork | Azure.ResourceManager.HybridNetwork |
| iot | Azure.ResourceManager.IotFirmwareDefense |
| iotcentral | Azure.ResourceManager.IotCentral |
| iothub | Azure.ResourceManager.IotHub |
| keyvault | Azure.ResourceManager.KeyVault |
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
| nginx | Azure.ResourceManager.Nginx |
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
| resourceconnector | Azure.ResourceManager.ResourceConnector |
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
| storagesync | Azure.ResourceManager.StorageSync |
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
| provisioning | Azure.Provisioning.Deployment |
| provisioning | Azure.Provisioning.Dns |
| servicebus | Azure.Messaging.ServiceBus |
| storage | Azure.Storage.Blobs.ChangeFeed |
| storage | Azure.Storage.Common |
| storage | Azure.Storage.DataMovement |
| storage | Azure.Storage.DataMovement.Blobs |
| storage | Azure.Storage.DataMovement.Files.Shares |
| storage | Azure.Storage.Internal.Avro |
| synapse | Azure.Analytics.Synapse.Shared |
| webpubsub | Azure.Messaging.WebPubSub.Client |
