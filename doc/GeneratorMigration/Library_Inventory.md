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


## Data Plane Libraries (DPG)

Libraries that provide client APIs for Azure services.

| Service | Library | New Emitter | Autorest |
| ------- | ------- | ----------- | -------- |
| agentserver | Azure.AI.AgentServer.AgentFramework |  |  |
| agentserver | Azure.AI.AgentServer.Contracts |  | ✓ |
| agentserver | Azure.AI.AgentServer.Core |  |  |
| agrifood | Azure.Verticals.AgriFood.Farming |  | ✓ |
| ai | Azure.AI.Agents.Persistent |  |  |
| ai | Azure.AI.Inference |  |  |
| ai | Azure.AI.Projects | ✓ |  |
| ai | Azure.AI.VoiceLive | ✓ |  |
| anomalydetector | Azure.AI.AnomalyDetector |  |  |
| appconfiguration | Azure.Data.AppConfiguration | ✓ |  |
| attestation | Azure.Security.Attestation |  | ✓ |
| batch | Azure.Compute.Batch |  |  |
| cloudmachine | Azure.Projects |  |  |
| cloudmachine | Azure.Projects.AI |  |  |
| cloudmachine | Azure.Projects.AI.Foundry |  |  |
| cloudmachine | Azure.Projects.Provisioning |  |  |
| cloudmachine | Azure.Projects.Tsp |  |  |
| cloudmachine | Azure.Projects.Web |  |  |
| cognitivelanguage | Azure.AI.Language.Conversations |  |  |
| cognitivelanguage | Azure.AI.Language.Conversations.Authoring |  |  |
| cognitivelanguage | Azure.AI.Language.QuestionAnswering |  | ✓ |
| cognitivelanguage | Azure.AI.Language.Text |  |  |
| cognitivelanguage | Azure.AI.Language.Text.Authoring |  |  |
| communication | Azure.Communication.AlphaIds |  | ✓ |
| communication | Azure.Communication.CallAutomation |  | ✓ |
| communication | Azure.Communication.CallingServer |  | ✓ |
| communication | Azure.Communication.Chat |  | ✓ |
| communication | Azure.Communication.Common |  |  |
| communication | Azure.Communication.Email |  | ✓ |
| communication | Azure.Communication.Identity |  | ✓ |
| communication | Azure.Communication.JobRouter |  |  |
| communication | Azure.Communication.Messages |  |  |
| communication | Azure.Communication.PhoneNumbers |  | ✓ |
| communication | Azure.Communication.ProgrammableConnectivity |  |  |
| communication | Azure.Communication.Rooms |  | ✓ |
| communication | Azure.Communication.ShortCodes |  | ✓ |
| communication | Azure.Communication.Sms |  | ✓ |
| confidentialledger | Azure.Security.CodeTransparency |  |  |
| confidentialledger | Azure.Security.ConfidentialLedger |  | ✓ |
| containerregistry | Azure.Containers.ContainerRegistry |  | ✓ |
| contentsafety | Azure.AI.ContentSafety |  |  |
| core | Azure.Core |  |  |
| core | Azure.Core.Amqp |  |  |
| core | Azure.Core.Experimental |  |  |
| core | Azure.Core.Expressions.DataFactory |  |  |
| core | Azure.Core.TestFramework |  | ✓ |
| devcenter | Azure.Developer.DevCenter |  |  |
| deviceupdate | Azure.IoT.DeviceUpdate |  | ✓ |
| digitaltwins | Azure.DigitalTwins.Core |  | ✓ |
| documentintelligence | Azure.AI.DocumentIntelligence | ✓ |  |
| easm | Azure.Analytics.Defender.Easm | ✓ |  |
| eventgrid | Azure.Messaging.EventGrid |  |  |
| eventgrid | Azure.Messaging.EventGrid.Namespaces | ✓ |  |
| eventgrid | Azure.Messaging.EventGrid.SystemEvents | ✓ |  |
| eventhub | Azure.Messaging.EventHubs |  |  |
| eventhub | Azure.Messaging.EventHubs.Processor |  |  |
| eventhub | Azure.Messaging.EventHubs.Shared |  |  |
| extensions | Azure.Extensions.AspNetCore.Configuration.Secrets |  |  |
| extensions | Azure.Extensions.AspNetCore.DataProtection.Blobs |  |  |
| extensions | Azure.Extensions.AspNetCore.DataProtection.Keys |  |  |
| face | Azure.AI.Vision.Face |  |  |
| formrecognizer | Azure.AI.FormRecognizer |  | ✓ |
| healthdataaiservices | Azure.Health.Deidentification | ✓ |  |
| healthinsights | Azure.Health.Insights.CancerProfiling |  |  |
| healthinsights | Azure.Health.Insights.ClinicalMatching |  |  |
| healthinsights | Azure.Health.Insights.RadiologyInsights |  |  |
| identity | Azure.Identity |  |  |
| identity | Azure.Identity.Broker |  |  |
| iot | Azure.IoT.Hub.Service |  | ✓ |
| keyvault | Azure.Security.KeyVault.Administration | ✓ |  |
| keyvault | Azure.Security.KeyVault.Certificates |  |  |
| keyvault | Azure.Security.KeyVault.Keys |  |  |
| keyvault | Azure.Security.KeyVault.Secrets |  |  |
| keyvault | Azure.Security.KeyVault.Shared |  |  |
| loadtestservice | Azure.Developer.LoadTesting |  |  |
| loadtestservice | Azure.Developer.Playwright |  |  |
| loadtestservice | Azure.Developer.Playwright.MSTest |  |  |
| loadtestservice | Azure.Developer.Playwright.NUnit |  |  |
| maps | Azure.Maps.Common |  |  |
| maps | Azure.Maps.Geolocation |  | ✓ |
| maps | Azure.Maps.Rendering |  | ✓ |
| maps | Azure.Maps.Routing |  | ✓ |
| maps | Azure.Maps.Search |  | ✓ |
| maps | Azure.Maps.TimeZones |  | ✓ |
| maps | Azure.Maps.Weather |  | ✓ |
| metricsadvisor | Azure.AI.MetricsAdvisor |  | ✓ |
| mixedreality | Azure.MixedReality.Authentication |  | ✓ |
| modelsrepository | Azure.IoT.ModelsRepository |  |  |
| monitor | Azure.Monitor.Ingestion | ✓ |  |
| monitor | Azure.Monitor.OpenTelemetry.AspNetCore |  |  |
| monitor | Azure.Monitor.OpenTelemetry.Exporter |  | ✓ |
| monitor | Azure.Monitor.OpenTelemetry.LiveMetrics |  | ✓ |
| monitor | Azure.Monitor.Query.Logs | ✓ |  |
| monitor | Azure.Monitor.Query.Metrics | ✓ |  |
| objectanchors | Azure.MixedReality.ObjectAnchors.Conversion |  | ✓ |
| onlineexperimentation | Azure.Analytics.OnlineExperimentation |  |  |
| openai | Azure.AI.OpenAI | ✓ |  |
| openai | Azure.AI.OpenAI.Assistants |  |  |
| personalizer | Azure.AI.Personalizer |  | ✓ |
| provisioning | Azure.Provisioning |  | ✓ |
| provisioning | Azure.Provisioning.AppConfiguration |  | ✓ |
| provisioning | Azure.Provisioning.AppContainers |  | ✓ |
| provisioning | Azure.Provisioning.ApplicationInsights |  | ✓ |
| provisioning | Azure.Provisioning.AppService |  | ✓ |
| provisioning | Azure.Provisioning.CognitiveServices |  | ✓ |
| provisioning | Azure.Provisioning.Communication |  | ✓ |
| provisioning | Azure.Provisioning.ContainerRegistry |  | ✓ |
| provisioning | Azure.Provisioning.ContainerService |  | ✓ |
| provisioning | Azure.Provisioning.CosmosDB |  | ✓ |
| provisioning | Azure.Provisioning.Deployment |  |  |
| provisioning | Azure.Provisioning.Dns |  |  |
| provisioning | Azure.Provisioning.EventGrid |  | ✓ |
| provisioning | Azure.Provisioning.EventHubs |  | ✓ |
| provisioning | Azure.Provisioning.FrontDoor |  | ✓ |
| provisioning | Azure.Provisioning.KeyVault |  | ✓ |
| provisioning | Azure.Provisioning.Kubernetes |  | ✓ |
| provisioning | Azure.Provisioning.KubernetesConfiguration |  | ✓ |
| provisioning | Azure.Provisioning.Kusto |  | ✓ |
| provisioning | Azure.Provisioning.Network |  | ✓ |
| provisioning | Azure.Provisioning.OperationalInsights |  | ✓ |
| provisioning | Azure.Provisioning.PostgreSql |  | ✓ |
| provisioning | Azure.Provisioning.Redis |  | ✓ |
| provisioning | Azure.Provisioning.RedisEnterprise |  | ✓ |
| provisioning | Azure.Provisioning.Search |  | ✓ |
| provisioning | Azure.Provisioning.ServiceBus |  | ✓ |
| provisioning | Azure.Provisioning.SignalR |  | ✓ |
| provisioning | Azure.Provisioning.Sql |  | ✓ |
| provisioning | Azure.Provisioning.Storage |  | ✓ |
| provisioning | Azure.Provisioning.WebPubSub |  | ✓ |
| purview | Azure.Analytics.Purview.Account |  | ✓ |
| purview | Azure.Analytics.Purview.Administration |  | ✓ |
| purview | Azure.Analytics.Purview.Catalog |  | ✓ |
| purview | Azure.Analytics.Purview.DataMap |  |  |
| purview | Azure.Analytics.Purview.Scanning |  | ✓ |
| purview | Azure.Analytics.Purview.Sharing |  | ✓ |
| purview | Azure.Analytics.Purview.Workflows |  | ✓ |
| quantum | Azure.Quantum.Jobs |  | ✓ |
| remoterendering | Azure.MixedReality.RemoteRendering |  | ✓ |
| schemaregistry | Azure.Data.SchemaRegistry | ✓ |  |
| search | Azure.Search.Documents |  | ✓ |
| servicebus | Azure.Messaging.ServiceBus |  |  |
| storage | Azure.Storage.Blobs |  | ✓ |
| storage | Azure.Storage.Blobs.Batch |  | ✓ |
| storage | Azure.Storage.Blobs.ChangeFeed |  |  |
| storage | Azure.Storage.Common |  |  |
| storage | Azure.Storage.DataMovement |  |  |
| storage | Azure.Storage.DataMovement.Blobs |  |  |
| storage | Azure.Storage.DataMovement.Files.Shares |  |  |
| storage | Azure.Storage.Files.DataLake |  | ✓ |
| storage | Azure.Storage.Files.Shares |  | ✓ |
| storage | Azure.Storage.Internal.Avro |  |  |
| storage | Azure.Storage.Queues |  | ✓ |
| synapse | Azure.Analytics.Synapse.AccessControl |  | ✓ |
| synapse | Azure.Analytics.Synapse.Artifacts |  | ✓ |
| synapse | Azure.Analytics.Synapse.ManagedPrivateEndpoints |  | ✓ |
| synapse | Azure.Analytics.Synapse.Monitoring |  | ✓ |
| synapse | Azure.Analytics.Synapse.Shared |  |  |
| synapse | Azure.Analytics.Synapse.Spark |  | ✓ |
| tables | Azure.Data.Tables |  | ✓ |
| template | Azure.Template |  | ✓ |
| textanalytics | Azure.AI.TextAnalytics |  | ✓ |
| textanalytics | Azure.AI.TextAnalytics.Legacy.Shared |  | ✓ |
| timeseriesinsights | Azure.IoT.TimeSeriesInsights |  | ✓ |
| translation | Azure.AI.Translation.Document |  |  |
| translation | Azure.AI.Translation.Text | ✓ |  |
| videoanalyzer | Azure.Media.VideoAnalyzer.Edge |  | ✓ |
| vision | Azure.AI.Vision.ImageAnalysis | ✓ |  |
| webpubsub | Azure.Messaging.WebPubSub |  | ✓ |
| webpubsub | Azure.Messaging.WebPubSub.Client |  |  |


## Management Plane Libraries (MPG)

Libraries that provide resource management APIs for Azure services.

| Service | Library | New Emitter | Autorest |
| ------- | ------- | ----------- | -------- |
| advisor | Azure.ResourceManager.Advisor |  | ✓ |
| agricultureplatform | Azure.ResourceManager.AgriculturePlatform | ✓ |  |
| agrifood | Azure.ResourceManager.AgFoodPlatform |  | ✓ |
| alertsmanagement | Azure.ResourceManager.AlertsManagement |  | ✓ |
| analysisservices | Azure.ResourceManager.Analysis |  | ✓ |
| apicenter | Azure.ResourceManager.ApiCenter |  | ✓ |
| apimanagement | Azure.ResourceManager.ApiManagement |  | ✓ |
| appcomplianceautomation | Azure.ResourceManager.AppComplianceAutomation |  | ✓ |
| appconfiguration | Azure.ResourceManager.AppConfiguration |  | ✓ |
| applicationinsights | Azure.ResourceManager.ApplicationInsights |  | ✓ |
| appplatform | Azure.ResourceManager.AppPlatform |  | ✓ |
| arc-scvmm | Azure.ResourceManager.ScVmm |  | ✓ |
| arizeaiobservabilityeval | Azure.ResourceManager.ArizeAIObservabilityEval | ✓ |  |
| astronomer | Azure.ResourceManager.Astro |  | ✓ |
| attestation | Azure.ResourceManager.Attestation |  | ✓ |
| authorization | Azure.ResourceManager.Authorization |  | ✓ |
| automanage | Azure.ResourceManager.Automanage |  | ✓ |
| automation | Azure.ResourceManager.Automation |  | ✓ |
| avs | Azure.ResourceManager.Avs |  |  |
| azurelargeinstance | Azure.ResourceManager.LargeInstance |  | ✓ |
| azurestackhci | Azure.ResourceManager.Hci |  | ✓ |
| azurestackhci | Azure.ResourceManager.Hci.Vm |  |  |
| batch | Azure.ResourceManager.Batch |  | ✓ |
| billing | Azure.ResourceManager.Billing |  | ✓ |
| billingbenefits | Azure.ResourceManager.BillingBenefits |  | ✓ |
| blueprint | Azure.ResourceManager.Blueprint |  | ✓ |
| botservice | Azure.ResourceManager.BotService |  | ✓ |
| carbon | Azure.ResourceManager.CarbonOptimization |  |  |
| cdn | Azure.ResourceManager.Cdn |  | ✓ |
| changeanalysis | Azure.ResourceManager.ChangeAnalysis |  | ✓ |
| chaos | Azure.ResourceManager.Chaos |  |  |
| cloudhealth | Azure.ResourceManager.CloudHealth | ✓ |  |
| cognitiveservices | Azure.ResourceManager.CognitiveServices |  | ✓ |
| communication | Azure.ResourceManager.Communication |  | ✓ |
| compute | Azure.ResourceManager.Compute |  | ✓ |
| computefleet | Azure.ResourceManager.ComputeFleet |  |  |
| computelimit | Azure.ResourceManager.ComputeLimit | ✓ |  |
| computerecommender | Azure.ResourceManager.Compute.Recommender | ✓ |  |
| computeschedule | Azure.ResourceManager.ComputeSchedule |  |  |
| confidentialledger | Azure.ResourceManager.ConfidentialLedger |  | ✓ |
| confluent | Azure.ResourceManager.Confluent |  | ✓ |
| connectedcache | Azure.ResourceManager.ConnectedCache | ✓ |  |
| connectedvmwarevsphere | Azure.ResourceManager.ConnectedVMwarevSphere |  | ✓ |
| consumption | Azure.ResourceManager.Consumption |  | ✓ |
| containerapps | Azure.ResourceManager.AppContainers |  | ✓ |
| containerinstance | Azure.ResourceManager.ContainerInstance |  | ✓ |
| containerorchestratorruntime | Azure.ResourceManager.ContainerOrchestratorRuntime |  |  |
| containerregistry | Azure.ResourceManager.ContainerRegistry |  | ✓ |
| containerservice | Azure.ResourceManager.ContainerService |  | ✓ |
| cosmosdb | Azure.ResourceManager.CosmosDB |  | ✓ |
| cosmosdbforpostgresql | Azure.ResourceManager.CosmosDBForPostgreSql |  | ✓ |
| costmanagement | Azure.ResourceManager.CostManagement |  | ✓ |
| customer-insights | Azure.ResourceManager.CustomerInsights |  | ✓ |
| databasewatcher | Azure.ResourceManager.DatabaseWatcher | ✓ |  |
| databox | Azure.ResourceManager.DataBox |  |  |
| databoxedge | Azure.ResourceManager.DataBoxEdge |  | ✓ |
| datadog | Azure.ResourceManager.Datadog |  | ✓ |
| datafactory | Azure.ResourceManager.DataFactory |  | ✓ |
| datalake-analytics | Azure.ResourceManager.DataLakeAnalytics |  | ✓ |
| datalake-store | Azure.ResourceManager.DataLakeStore |  | ✓ |
| datamigration | Azure.ResourceManager.DataMigration |  | ✓ |
| dataprotection | Azure.ResourceManager.DataProtectionBackup |  | ✓ |
| datashare | Azure.ResourceManager.DataShare |  | ✓ |
| defendereasm | Azure.ResourceManager.DefenderEasm |  | ✓ |
| dellstorage | Azure.ResourceManager.Dell.Storage | ✓ |  |
| dependencymap | Azure.ResourceManager.DependencyMap | ✓ |  |
| desktopvirtualization | Azure.ResourceManager.DesktopVirtualization |  | ✓ |
| devcenter | Azure.ResourceManager.DevCenter |  | ✓ |
| deviceprovisioningservices | Azure.ResourceManager.DeviceProvisioningServices |  |  |
| deviceregistry | Azure.ResourceManager.DeviceRegistry | ✓ |  |
| deviceupdate | Azure.ResourceManager.DeviceUpdate |  | ✓ |
| devopsinfrastructure | Azure.ResourceManager.DevOpsInfrastructure |  |  |
| devspaces | Azure.ResourceManager.DevSpaces |  | ✓ |
| devtestlabs | Azure.ResourceManager.DevTestLabs |  | ✓ |
| digitaltwins | Azure.ResourceManager.DigitalTwins |  | ✓ |
| disconnectedoperations | Azure.ResourceManager.DisconnectedOperations |  |  |
| dns | Azure.ResourceManager.Dns |  | ✓ |
| dnsresolver | Azure.ResourceManager.DnsResolver |  | ✓ |
| durabletask | Azure.ResourceManager.DurableTask | ✓ |  |
| dynatrace | Azure.ResourceManager.Dynatrace |  | ✓ |
| edgeorder | Azure.ResourceManager.EdgeOrder |  | ✓ |
| edgezones | Azure.ResourceManager.EdgeZones |  | ✓ |
| elastic | Azure.ResourceManager.Elastic |  |  |
| elasticsan | Azure.ResourceManager.ElasticSan |  |  |
| eventgrid | Azure.ResourceManager.EventGrid |  | ✓ |
| eventhub | Azure.ResourceManager.EventHubs |  | ✓ |
| extendedlocation | Azure.ResourceManager.ExtendedLocations |  | ✓ |
| fabric | Azure.ResourceManager.Fabric |  |  |
| fleet | Azure.ResourceManager.ContainerServiceFleet |  | ✓ |
| fluidrelay | Azure.ResourceManager.FluidRelay |  | ✓ |
| frontdoor | Azure.ResourceManager.FrontDoor |  | ✓ |
| grafana | Azure.ResourceManager.Grafana |  |  |
| graphservices | Azure.ResourceManager.GraphServices |  | ✓ |
| guestconfiguration | Azure.ResourceManager.GuestConfiguration |  | ✓ |
| hardwaresecuritymodules | Azure.ResourceManager.HardwareSecurityModules |  |  |
| hdinsight | Azure.ResourceManager.HDInsight |  | ✓ |
| hdinsightcontainers | Azure.ResourceManager.HDInsight.Containers |  | ✓ |
| healthbot | Azure.ResourceManager.HealthBot |  | ✓ |
| healthcareapis | Azure.ResourceManager.HealthcareApis |  | ✓ |
| healthdataaiservices | Azure.ResourceManager.HealthDataAIServices | ✓ |  |
| hybridaks | Azure.ResourceManager.HybridContainerService |  | ✓ |
| hybridcompute | Azure.ResourceManager.HybridCompute |  | ✓ |
| hybridconnectivity | Azure.ResourceManager.HybridConnectivity |  |  |
| hybridkubernetes | Azure.ResourceManager.Kubernetes | ✓ |  |
| hybridnetwork | Azure.ResourceManager.HybridNetwork |  | ✓ |
| impactreporting | Azure.ResourceManager.ImpactReporting |  |  |
| informaticadatamanagement | Azure.ResourceManager.InformaticaDataManagement | ✓ |  |
| iot | Azure.ResourceManager.IotFirmwareDefense |  | ✓ |
| iotcentral | Azure.ResourceManager.IotCentral |  | ✓ |
| iothub | Azure.ResourceManager.IotHub |  | ✓ |
| iotoperations | Azure.ResourceManager.IotOperations |  |  |
| keyvault | Azure.ResourceManager.KeyVault |  | ✓ |
| kubernetesconfiguration | Azure.ResourceManager.KubernetesConfiguration |  | ✓ |
| kusto | Azure.ResourceManager.Kusto |  | ✓ |
| labservices | Azure.ResourceManager.LabServices |  | ✓ |
| lambdatesthyperexecute | Azure.ResourceManager.LambdaTestHyperExecute | ✓ |  |
| loadtestservice | Azure.ResourceManager.LoadTesting |  | ✓ |
| logic | Azure.ResourceManager.Logic |  | ✓ |
| machinelearningcompute | Azure.ResourceManager.MachineLearningCompute |  | ✓ |
| machinelearningservices | Azure.ResourceManager.MachineLearning |  | ✓ |
| maintenance | Azure.ResourceManager.Maintenance |  | ✓ |
| managednetwork | Azure.ResourceManager.ManagedNetwork |  | ✓ |
| managednetworkfabric | Azure.ResourceManager.ManagedNetworkFabric |  | ✓ |
| managedserviceidentity | Azure.ResourceManager.ManagedServiceIdentities |  | ✓ |
| managedservices | Azure.ResourceManager.ManagedServices |  | ✓ |
| managementpartner | Azure.ResourceManager.ManagementPartner |  | ✓ |
| maps | Azure.ResourceManager.Maps |  | ✓ |
| marketplace | Azure.ResourceManager.Marketplace |  | ✓ |
| marketplaceordering | Azure.ResourceManager.MarketplaceOrdering |  | ✓ |
| mediaservices | Azure.ResourceManager.Media |  | ✓ |
| migrationassessment | Azure.ResourceManager.Migration.Assessment |  | ✓ |
| migrationdiscoverysap | Azure.ResourceManager.MigrationDiscoverySap |  | ✓ |
| mixedreality | Azure.ResourceManager.MixedReality |  | ✓ |
| mobilenetwork | Azure.ResourceManager.MobileNetwork |  | ✓ |
| mongocluster | Azure.ResourceManager.MongoCluster |  |  |
| mongodbatlas | Azure.ResourceManager.MongoDBAtlas |  |  |
| monitor | Azure.ResourceManager.Monitor |  | ✓ |
| mysql | Azure.ResourceManager.MySql |  |  |
| neonpostgres | Azure.ResourceManager.NeonPostgres |  |  |
| netapp | Azure.ResourceManager.NetApp |  | ✓ |
| network | Azure.ResourceManager.Network |  | ✓ |
| networkanalytics | Azure.ResourceManager.NetworkAnalytics |  | ✓ |
| networkcloud | Azure.ResourceManager.NetworkCloud |  | ✓ |
| networkfunction | Azure.ResourceManager.NetworkFunction |  | ✓ |
| newrelicobservability | Azure.ResourceManager.NewRelicObservability |  | ✓ |
| nginx | Azure.ResourceManager.Nginx |  | ✓ |
| notificationhubs | Azure.ResourceManager.NotificationHubs |  | ✓ |
| onlineexperimentation | Azure.ResourceManager.OnlineExperimentation |  |  |
| openenergyplatform | Azure.ResourceManager.EnergyServices |  | ✓ |
| operationalinsights | Azure.ResourceManager.OperationalInsights |  | ✓ |
| oracle | Azure.ResourceManager.OracleDatabase |  |  |
| orbital | Azure.ResourceManager.Orbital |  | ✓ |
| paloaltonetworks.ngfw | Azure.ResourceManager.PaloAltoNetworks.Ngfw | ✓ |  |
| peering | Azure.ResourceManager.Peering |  | ✓ |
| pineconevectordb | Azure.ResourceManager.PineconeVectorDB | ✓ |  |
| planetarycomputer | Azure.ResourceManager.PlanetaryComputer | ✓ |  |
| playwright | Azure.ResourceManager.Playwright | ✓ |  |
| policyinsights | Azure.ResourceManager.PolicyInsights |  | ✓ |
| portalservices | Azure.ResourceManager.PortalServicesCopilot | ✓ |  |
| postgresql | Azure.ResourceManager.PostgreSql |  | ✓ |
| powerbidedicated | Azure.ResourceManager.PowerBIDedicated |  | ✓ |
| privatedns | Azure.ResourceManager.PrivateDns |  | ✓ |
| providerhub | Azure.ResourceManager.ProviderHub |  | ✓ |
| purestorageblock | Azure.ResourceManager.PureStorageBlock |  |  |
| purview | Azure.ResourceManager.Purview |  | ✓ |
| quantum | Azure.ResourceManager.Quantum |  | ✓ |
| qumulo | Azure.ResourceManager.Qumulo |  |  |
| quota | Azure.ResourceManager.Quota |  |  |
| recoveryservices | Azure.ResourceManager.RecoveryServices |  |  |
| recoveryservices-backup | Azure.ResourceManager.RecoveryServicesBackup |  | ✓ |
| recoveryservices-datareplication | Azure.ResourceManager.RecoveryServicesDataReplication |  |  |
| recoveryservices-siterecovery | Azure.ResourceManager.RecoveryServicesSiteRecovery |  | ✓ |
| redis | Azure.ResourceManager.Redis |  | ✓ |
| redisenterprise | Azure.ResourceManager.RedisEnterprise |  | ✓ |
| relay | Azure.ResourceManager.Relay |  | ✓ |
| reservations | Azure.ResourceManager.Reservations |  | ✓ |
| resourceconnector | Azure.ResourceManager.ResourceConnector |  | ✓ |
| resourcegraph | Azure.ResourceManager.ResourceGraph |  | ✓ |
| resourcehealth | Azure.ResourceManager.ResourceHealth |  | ✓ |
| resourcemanager | Azure.ResourceManager |  | ✓ |
| resourcemover | Azure.ResourceManager.ResourceMover |  | ✓ |
| resources | Azure.ResourceManager.Resources |  | ✓ |
| resources | Azure.ResourceManager.Resources.Bicep |  |  |
| resources | Azure.ResourceManager.Resources.Deployments |  | ✓ |
| resources | Azure.ResourceManager.Resources.DeploymentStacks |  | ✓ |
| search | Azure.ResourceManager.Search |  | ✓ |
| secretsstoreextension | Azure.ResourceManager.SecretsStoreExtension |  |  |
| securitycenter | Azure.ResourceManager.SecurityCenter |  | ✓ |
| securitydevops | Azure.ResourceManager.SecurityDevOps |  | ✓ |
| securityinsights | Azure.ResourceManager.SecurityInsights |  | ✓ |
| selfhelp | Azure.ResourceManager.SelfHelp |  |  |
| servicebus | Azure.ResourceManager.ServiceBus |  | ✓ |
| servicefabric | Azure.ResourceManager.ServiceFabric |  | ✓ |
| servicefabricmanagedclusters | Azure.ResourceManager.ServiceFabricManagedClusters |  |  |
| servicelinker | Azure.ResourceManager.ServiceLinker |  | ✓ |
| servicenetworking | Azure.ResourceManager.ServiceNetworking |  |  |
| signalr | Azure.ResourceManager.SignalR |  | ✓ |
| sitemanager | Azure.ResourceManager.SiteManager |  |  |
| sphere | Azure.ResourceManager.Sphere |  | ✓ |
| springappdiscovery | Azure.ResourceManager.SpringAppDiscovery |  | ✓ |
| sqlmanagement | Azure.ResourceManager.Sql |  | ✓ |
| sqlvirtualmachine | Azure.ResourceManager.SqlVirtualMachine |  | ✓ |
| standbypool | Azure.ResourceManager.StandbyPool |  |  |
| storage | Azure.ResourceManager.Storage |  | ✓ |
| storageactions | Azure.ResourceManager.StorageActions | ✓ |  |
| storagecache | Azure.ResourceManager.StorageCache |  | ✓ |
| storagediscovery | Azure.ResourceManager.StorageDiscovery | ✓ |  |
| storagemover | Azure.ResourceManager.StorageMover |  |  |
| storagepool | Azure.ResourceManager.StoragePool |  | ✓ |
| storagesync | Azure.ResourceManager.StorageSync |  | ✓ |
| streamanalytics | Azure.ResourceManager.StreamAnalytics |  | ✓ |
| subscription | Azure.ResourceManager.Subscription |  | ✓ |
| support | Azure.ResourceManager.Support |  | ✓ |
| synapse | Azure.ResourceManager.Synapse |  | ✓ |
| terraform | Azure.ResourceManager.Terraform |  |  |
| trafficmanager | Azure.ResourceManager.TrafficManager |  | ✓ |
| trustedsigning | Azure.ResourceManager.TrustedSigning | ✓ |  |
| virtualenclaves | Azure.ResourceManager.VirtualEnclaves |  |  |
| voiceservices | Azure.ResourceManager.VoiceServices |  | ✓ |
| webpubsub | Azure.ResourceManager.WebPubSub |  | ✓ |
| websites | Azure.ResourceManager.AppService |  | ✓ |
| weightsandbiases | Azure.ResourceManager.WeightsAndBiases | ✓ |  |
| workloadmonitor | Azure.ResourceManager.WorkloadMonitor |  | ✓ |
| workloadorchestration | Azure.ResourceManager.WorkloadOrchestration |  |  |
| workloads | Azure.ResourceManager.Workloads |  | ✓ |
| workloadssapvirtualinstance | Azure.ResourceManager.WorkloadsSapVirtualInstance |  |  |


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
