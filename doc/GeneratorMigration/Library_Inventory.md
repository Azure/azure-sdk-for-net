# Azure SDK for .NET Libraries Inventory

> **Auto-generated** by `Library_Inventory` on 2026-04-03 19:07:48 UTC.
> Run that script to refresh this file.

## Table of Contents

- [Summary](#summary)
- [Data Plane Libraries (DPG) - Migrated to New Emitter](#data-plane-libraries-dpg---migrated-to-new-emitter)
- [Data Plane Libraries (DPG) - Still on Swagger](#data-plane-libraries-dpg---still-on-swagger)
- [Management Plane Libraries (MPG) - Migrated to New Emitter](#management-plane-libraries-mpg---migrated-to-new-emitter)
- [Management Plane Libraries (MPG) - Still on Swagger](#management-plane-libraries-mpg---still-on-swagger)
- [Provisioning Libraries](#provisioning-libraries)
- [Libraries with No Generator](#libraries-with-no-generator)


## Summary

- Total libraries: 398
- Management Plane (MPG): 232
  - Autorest/Swagger: 102
  - New Emitter (TypeSpec): 130
  - Old TypeSpec: 0
- Data Plane (DPG): 128
  - Autorest/Swagger: 37
  - New Emitter (TypeSpec): 40
  - Old TypeSpec: 3
- Provisioning: 38
  - Reflection-based generator: 34
  - TypeSpec-based generator: 2
  - No generator: 2
- No generator: 48


## Data Plane Libraries (DPG) - Migrated to New Emitter

Libraries that provide client APIs for Azure services and have been migrated to the new TypeSpec emitter.

**Migration Status**: 40 / 43 (93%)

| Service | Library | New Emitter | Using SCM |
| ------- | ------- | ----------- | --------- |
| agentserver | Azure.AI.AgentServer.Responses | ✅ | ✅ |
| ai | Azure.AI.Agents.Persistent |  |  |
| ai | Azure.AI.Extensions.OpenAI | ✅ | ✅ |
| ai | Azure.AI.Projects | ✅ | ✅ |
| ai | Azure.AI.Projects.Agents | ✅ | ✅ |
| anomalydetector | Azure.AI.AnomalyDetector | ✅ |  |
| appconfiguration | Azure.Data.AppConfiguration | ✅ |  |
| batch | Azure.Compute.Batch | ✅ |  |
| cognitivelanguage | Azure.AI.Language.Conversations | ✅ |  |
| cognitivelanguage | Azure.AI.Language.Conversations.Authoring | ✅ |  |
| cognitivelanguage | Azure.AI.Language.QuestionAnswering.Authoring | ✅ |  |
| cognitivelanguage | Azure.AI.Language.QuestionAnswering.Inference | ✅ |  |
| cognitivelanguage | Azure.AI.Language.Text | ✅ |  |
| cognitivelanguage | Azure.AI.Language.Text.Authoring | ✅ |  |
| communication | Azure.Communication.JobRouter | ✅ |  |
| communication | Azure.Communication.Messages |  |  |
| confidentialledger | Azure.Security.CodeTransparency | ✅ |  |
| contentsafety | Azure.AI.ContentSafety | ✅ |  |
| contentunderstanding | Azure.AI.ContentUnderstanding | ✅ |  |
| devcenter | Azure.Developer.DevCenter | ✅ |  |
| documentintelligence | Azure.AI.DocumentIntelligence | ✅ |  |
| easm | Azure.Analytics.Defender.Easm | ✅ |  |
| eventgrid | Azure.Messaging.EventGrid.Namespaces | ✅ |  |
| eventgrid | Azure.Messaging.EventGrid.SystemEvents | ✅ |  |
| healthdataaiservices | Azure.Health.Deidentification | ✅ |  |
| keyvault | Azure.Security.KeyVault.Administration | ✅ |  |
| loadtestservice | Azure.Developer.LoadTesting | ✅ |  |
| monitor | Azure.Monitor.Ingestion | ✅ |  |
| monitor | Azure.Monitor.OpenTelemetry.Exporter | ✅ |  |
| monitor | Azure.Monitor.Query.Logs | ✅ |  |
| monitor | Azure.Monitor.Query.Metrics | ✅ |  |
| onlineexperimentation | Azure.Analytics.OnlineExperimentation | ✅ |  |
| openai | Azure.AI.OpenAI | ✅ | ✅ |
| planetarycomputer | Azure.Analytics.PlanetaryComputer | ✅ |  |
| purview | Azure.Analytics.Purview.DataMap | ✅ |  |
| schemaregistry | Azure.Data.SchemaRegistry | ✅ |  |
| search | Azure.Search.Documents | ✅ |  |
| template | Azure.Template | ✅ |  |
| transcription | Azure.AI.Speech.Transcription | ✅ | ✅ |
| translation | Azure.AI.Translation.Document |  |  |
| translation | Azure.AI.Translation.Text | ✅ |  |
| vision | Azure.AI.Vision.ImageAnalysis | ✅ |  |
| voicelive | Azure.AI.VoiceLive | ✅ |  |


## Data Plane Libraries (DPG) - Still on Swagger

Libraries that have not yet been migrated to the new TypeSpec emitter. Total: 37

| Service | Library |
| ------- | ------- |
| agrifood | Azure.Verticals.AgriFood.Farming |
| attestation | Azure.Security.Attestation |
| cognitivelanguage | Azure.AI.Language.QuestionAnswering |
| communication | Azure.Communication.AlphaIds |
| communication | Azure.Communication.CallAutomation |
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
| digitaltwins | Azure.DigitalTwins.Core |
| formrecognizer | Azure.AI.FormRecognizer |
| maps | Azure.Maps.Geolocation |
| maps | Azure.Maps.Rendering |
| maps | Azure.Maps.Routing |
| maps | Azure.Maps.Search |
| maps | Azure.Maps.TimeZones |
| maps | Azure.Maps.Weather |
| personalizer | Azure.AI.Personalizer |
| purview | Azure.Analytics.Purview.Sharing |
| purview | Azure.Analytics.Purview.Workflows |
| storage | Azure.Storage.Blobs |
| storage | Azure.Storage.Blobs.Batch |
| storage | Azure.Storage.Files.DataLake |
| storage | Azure.Storage.Files.Shares |
| storage | Azure.Storage.Queues |
| synapse | Azure.Analytics.Synapse.Artifacts |
| tables | Azure.Data.Tables |
| textanalytics | Azure.AI.TextAnalytics |
| textanalytics | Azure.AI.TextAnalytics.Legacy.Shared |
| timeseriesinsights | Azure.IoT.TimeSeriesInsights |
| webpubsub | Azure.Messaging.WebPubSub |


## Management Plane Libraries (MPG) - Migrated to New Emitter

Libraries that provide resource management APIs for Azure services and have been migrated to the new TypeSpec emitter.

**Migration Status**: 130 / 130 (100%)

| Service | Library | New Emitter |
| ------- | ------- | ----------- |
| advisor | Azure.ResourceManager.Advisor | ✅ |
| agricultureplatform | Azure.ResourceManager.AgriculturePlatform | ✅ |
| apicenter | Azure.ResourceManager.ApiCenter | ✅ |
| appcomplianceautomation | Azure.ResourceManager.AppComplianceAutomation | ✅ |
| appconfiguration | Azure.ResourceManager.AppConfiguration | ✅ |
| appnetwork | Azure.ResourceManager.AppNetwork | ✅ |
| arizeaiobservabilityeval | Azure.ResourceManager.ArizeAIObservabilityEval | ✅ |
| artifactsigning | Azure.ResourceManager.ArtifactSigning | ✅ |
| astronomer | Azure.ResourceManager.Astro | ✅ |
| attestation | Azure.ResourceManager.Attestation | ✅ |
| avs | Azure.ResourceManager.Avs | ✅ |
| azurelargeinstance | Azure.ResourceManager.LargeInstance | ✅ |
| azurestackhci | Azure.ResourceManager.Hci.Vm | ✅ |
| batch | Azure.ResourceManager.Batch | ✅ |
| botservice | Azure.ResourceManager.BotService | ✅ |
| carbon | Azure.ResourceManager.CarbonOptimization | ✅ |
| certificateregistration | Azure.ResourceManager.CertificateRegistration | ✅ |
| chaos | Azure.ResourceManager.Chaos | ✅ |
| cloudhealth | Azure.ResourceManager.CloudHealth | ✅ |
| communication | Azure.ResourceManager.Communication | ✅ |
| computefleet | Azure.ResourceManager.ComputeFleet | ✅ |
| computelimit | Azure.ResourceManager.ComputeLimit | ✅ |
| computerecommender | Azure.ResourceManager.Compute.Recommender | ✅ |
| computeschedule | Azure.ResourceManager.ComputeSchedule | ✅ |
| confidentialledger | Azure.ResourceManager.ConfidentialLedger | ✅ |
| confluent | Azure.ResourceManager.Confluent | ✅ |
| connectedcache | Azure.ResourceManager.ConnectedCache | ✅ |
| containerorchestratorruntime | Azure.ResourceManager.ContainerOrchestratorRuntime | ✅ |
| containerregistry | Azure.ResourceManager.ContainerRegistry | ✅ |
| containerregistry | Azure.ResourceManager.ContainerRegistry.Tasks | ✅ |
| containerservice | Azure.ResourceManager.ContainerService | ✅ |
| databasewatcher | Azure.ResourceManager.DatabaseWatcher | ✅ |
| databox | Azure.ResourceManager.DataBox | ✅ |
| datadog | Azure.ResourceManager.Datadog | ✅ |
| dataprotection | Azure.ResourceManager.DataProtectionBackup | ✅ |
| dellstorage | Azure.ResourceManager.Dell.Storage | ✅ |
| dependencymap | Azure.ResourceManager.DependencyMap | ✅ |
| desktopvirtualization | Azure.ResourceManager.DesktopVirtualization | ✅ |
| devcenter | Azure.ResourceManager.DevCenter | ✅ |
| deviceprovisioningservices | Azure.ResourceManager.DeviceProvisioningServices | ✅ |
| deviceregistry | Azure.ResourceManager.DeviceRegistry | ✅ |
| devopsinfrastructure | Azure.ResourceManager.DevOpsInfrastructure | ✅ |
| devtestlabs | Azure.ResourceManager.DevTestLabs | ✅ |
| disconnectedoperations | Azure.ResourceManager.DisconnectedOperations | ✅ |
| domainregistration | Azure.ResourceManager.DomainRegistration | ✅ |
| durabletask | Azure.ResourceManager.DurableTask | ✅ |
| dynatrace | Azure.ResourceManager.Dynatrace | ✅ |
| edgeactions | Azure.ResourceManager.EdgeActions | ✅ |
| edgeorder | Azure.ResourceManager.EdgeOrder | ✅ |
| edgezones | Azure.ResourceManager.EdgeZones | ✅ |
| elastic | Azure.ResourceManager.Elastic | ✅ |
| elasticsan | Azure.ResourceManager.ElasticSan | ✅ |
| eventhub | Azure.ResourceManager.EventHubs | ✅ |
| fabric | Azure.ResourceManager.Fabric | ✅ |
| fileshares | Azure.ResourceManager.FileShares | ✅ |
| fleet | Azure.ResourceManager.ContainerServiceFleet | ✅ |
| grafana | Azure.ResourceManager.Grafana | ✅ |
| guestconfiguration | Azure.ResourceManager.GuestConfiguration | ✅ |
| hardwaresecuritymodules | Azure.ResourceManager.HardwareSecurityModules | ✅ |
| healthbot | Azure.ResourceManager.HealthBot | ✅ |
| healthdataaiservices | Azure.ResourceManager.HealthDataAIServices | ✅ |
| hybridconnectivity | Azure.ResourceManager.HybridConnectivity | ✅ |
| hybridkubernetes | Azure.ResourceManager.Kubernetes | ✅ |
| impactreporting | Azure.ResourceManager.ImpactReporting | ✅ |
| informaticadatamanagement | Azure.ResourceManager.InformaticaDataManagement | ✅ |
| iotoperations | Azure.ResourceManager.IotOperations | ✅ |
| keyvault | Azure.ResourceManager.KeyVault | ✅ |
| kubernetesconfiguration | Azure.ResourceManager.KubernetesConfiguration.Extensions | ✅ |
| kubernetesconfiguration | Azure.ResourceManager.KubernetesConfiguration.PrivateLinkScopes | ✅ |
| lambdatesthyperexecute | Azure.ResourceManager.LambdaTestHyperExecute | ✅ |
| loadtestservice | Azure.ResourceManager.LoadTesting | ✅ |
| managedops | Azure.ResourceManager.ManagedOps | ✅ |
| maps | Azure.ResourceManager.Maps | ✅ |
| mongocluster | Azure.ResourceManager.MongoCluster | ✅ |
| mongodbatlas | Azure.ResourceManager.MongoDBAtlas | ✅ |
| mysql | Azure.ResourceManager.MySql | ✅ |
| networkcloud | Azure.ResourceManager.NetworkCloud | ✅ |
| networkfunction | Azure.ResourceManager.NetworkFunction | ✅ |
| newrelicobservability | Azure.ResourceManager.NewRelicObservability | ✅ |
| nginx | Azure.ResourceManager.Nginx | ✅ |
| notificationhubs | Azure.ResourceManager.NotificationHubs | ✅ |
| onlineexperimentation | Azure.ResourceManager.OnlineExperimentation | ✅ |
| oracle | Azure.ResourceManager.OracleDatabase | ✅ |
| paloaltonetworks.ngfw | Azure.ResourceManager.PaloAltoNetworks.Ngfw | ✅ |
| peering | Azure.ResourceManager.Peering | ✅ |
| pineconevectordb | Azure.ResourceManager.PineconeVectorDB | ✅ |
| planetarycomputer | Azure.ResourceManager.PlanetaryComputer | ✅ |
| playwright | Azure.ResourceManager.Playwright | ✅ |
| portalservices | Azure.ResourceManager.PortalServicesCopilot | ✅ |
| powerbidedicated | Azure.ResourceManager.PowerBIDedicated | ✅ |
| purestorageblock | Azure.ResourceManager.PureStorageBlock | ✅ |
| purview | Azure.ResourceManager.Purview | ✅ |
| quantum | Azure.ResourceManager.Quantum | ✅ |
| qumulo | Azure.ResourceManager.Qumulo | ✅ |
| quota | Azure.ResourceManager.Quota | ✅ |
| recoveryservices | Azure.ResourceManager.RecoveryServices | ✅ |
| recoveryservices-backup | Azure.ResourceManager.RecoveryServicesBackup | ✅ |
| recoveryservices-datareplication | Azure.ResourceManager.RecoveryServicesDataReplication | ✅ |
| redisenterprise | Azure.ResourceManager.RedisEnterprise | ✅ |
| relationships | Azure.ResourceManager.Relationships | ✅ |
| relay | Azure.ResourceManager.Relay | ✅ |
| resourceconnector | Azure.ResourceManager.ResourceConnector | ✅ |
| resources | Azure.ResourceManager.Resources.Bicep | ✅ |
| resources | Azure.ResourceManager.Resources.DeploymentStacks | ✅ |
| resources | Azure.ResourceManager.Resources.Policy | ✅ |
| search | Azure.ResourceManager.Search | ✅ |
| secretsstoreextension | Azure.ResourceManager.SecretsStoreExtension | ✅ |
| selfhelp | Azure.ResourceManager.SelfHelp | ✅ |
| servicebus | Azure.ResourceManager.ServiceBus | ✅ |
| servicefabricmanagedclusters | Azure.ResourceManager.ServiceFabricManagedClusters | ✅ |
| servicenetworking | Azure.ResourceManager.ServiceNetworking | ✅ |
| signalr | Azure.ResourceManager.SignalR | ✅ |
| sitemanager | Azure.ResourceManager.SiteManager | ✅ |
| sphere | Azure.ResourceManager.Sphere | ✅ |
| sqlvirtualmachine | Azure.ResourceManager.SqlVirtualMachine | ✅ |
| standbypool | Azure.ResourceManager.StandbyPool | ✅ |
| storage | Azure.ResourceManager.Storage | ✅ |
| storageactions | Azure.ResourceManager.StorageActions | ✅ |
| storagediscovery | Azure.ResourceManager.StorageDiscovery | ✅ |
| storagemover | Azure.ResourceManager.StorageMover | ✅ |
| storagesync | Azure.ResourceManager.StorageSync | ✅ |
| support | Azure.ResourceManager.Support | ✅ |
| terraform | Azure.ResourceManager.Terraform | ✅ |
| trafficmanager | Azure.ResourceManager.TrafficManager | ✅ |
| trustedsigning | Azure.ResourceManager.TrustedSigning | ✅ |
| virtualenclaves | Azure.ResourceManager.VirtualEnclaves | ✅ |
| webpubsub | Azure.ResourceManager.WebPubSub | ✅ |
| weightsandbiases | Azure.ResourceManager.WeightsAndBiases | ✅ |
| workloadorchestration | Azure.ResourceManager.WorkloadOrchestration | ✅ |
| workloadssapvirtualinstance | Azure.ResourceManager.WorkloadsSapVirtualInstance | ✅ |


## Management Plane Libraries (MPG) - Still on Swagger

Libraries that have not yet been migrated to the new TypeSpec emitter. Total: 102

| Service | Library |
| ------- | ------- |
| agrifood | Azure.ResourceManager.AgFoodPlatform |
| alertsmanagement | Azure.ResourceManager.AlertsManagement |
| analysisservices | Azure.ResourceManager.Analysis |
| apimanagement | Azure.ResourceManager.ApiManagement |
| applicationinsights | Azure.ResourceManager.ApplicationInsights |
| arc-scvmm | Azure.ResourceManager.ScVmm |
| authorization | Azure.ResourceManager.Authorization |
| automanage | Azure.ResourceManager.Automanage |
| automation | Azure.ResourceManager.Automation |
| azurestackhci | Azure.ResourceManager.Hci |
| billing | Azure.ResourceManager.Billing |
| billingbenefits | Azure.ResourceManager.BillingBenefits |
| blueprint | Azure.ResourceManager.Blueprint |
| cdn | Azure.ResourceManager.Cdn |
| changeanalysis | Azure.ResourceManager.ChangeAnalysis |
| cognitiveservices | Azure.ResourceManager.CognitiveServices |
| compute | Azure.ResourceManager.Compute |
| connectedvmwarevsphere | Azure.ResourceManager.ConnectedVMwarevSphere |
| consumption | Azure.ResourceManager.Consumption |
| containerapps | Azure.ResourceManager.AppContainers |
| containerinstance | Azure.ResourceManager.ContainerInstance |
| cosmosdb | Azure.ResourceManager.CosmosDB |
| cosmosdbforpostgresql | Azure.ResourceManager.CosmosDBForPostgreSql |
| costmanagement | Azure.ResourceManager.CostManagement |
| customer-insights | Azure.ResourceManager.CustomerInsights |
| databoxedge | Azure.ResourceManager.DataBoxEdge |
| datafactory | Azure.ResourceManager.DataFactory |
| datalake-analytics | Azure.ResourceManager.DataLakeAnalytics |
| datalake-store | Azure.ResourceManager.DataLakeStore |
| datamigration | Azure.ResourceManager.DataMigration |
| datashare | Azure.ResourceManager.DataShare |
| defendereasm | Azure.ResourceManager.DefenderEasm |
| deviceupdate | Azure.ResourceManager.DeviceUpdate |
| devspaces | Azure.ResourceManager.DevSpaces |
| digitaltwins | Azure.ResourceManager.DigitalTwins |
| dns | Azure.ResourceManager.Dns |
| dnsresolver | Azure.ResourceManager.DnsResolver |
| eventgrid | Azure.ResourceManager.EventGrid |
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
| marketplace | Azure.ResourceManager.Marketplace |
| marketplaceordering | Azure.ResourceManager.MarketplaceOrdering |
| migrationassessment | Azure.ResourceManager.Migration.Assessment |
| migrationdiscoverysap | Azure.ResourceManager.MigrationDiscoverySap |
| monitor | Azure.ResourceManager.Monitor |
| netapp | Azure.ResourceManager.NetApp |
| network | Azure.ResourceManager.Network |
| openenergyplatform | Azure.ResourceManager.EnergyServices |
| operationalinsights | Azure.ResourceManager.OperationalInsights |
| orbital | Azure.ResourceManager.Orbital |
| policyinsights | Azure.ResourceManager.PolicyInsights |
| postgresql | Azure.ResourceManager.PostgreSql |
| privatedns | Azure.ResourceManager.PrivateDns |
| providerhub | Azure.ResourceManager.ProviderHub |
| recoveryservices-siterecovery | Azure.ResourceManager.RecoveryServicesSiteRecovery |
| redis | Azure.ResourceManager.Redis |
| reservations | Azure.ResourceManager.Reservations |
| resourcegraph | Azure.ResourceManager.ResourceGraph |
| resourcehealth | Azure.ResourceManager.ResourceHealth |
| resourcemanager | Azure.ResourceManager |
| resourcemover | Azure.ResourceManager.ResourceMover |
| resources | Azure.ResourceManager.Resources |
| resources | Azure.ResourceManager.Resources.Deployments |
| securitycenter | Azure.ResourceManager.SecurityCenter |
| securitydevops | Azure.ResourceManager.SecurityDevOps |
| securityinsights | Azure.ResourceManager.SecurityInsights |
| servicefabric | Azure.ResourceManager.ServiceFabric |
| servicegroups | Azure.ResourceManager.ServiceGroups |
| servicelinker | Azure.ResourceManager.ServiceLinker |
| springappdiscovery | Azure.ResourceManager.SpringAppDiscovery |
| sqlmanagement | Azure.ResourceManager.Sql |
| storagecache | Azure.ResourceManager.StorageCache |
| storagepool | Azure.ResourceManager.StoragePool |
| streamanalytics | Azure.ResourceManager.StreamAnalytics |
| subscription | Azure.ResourceManager.Subscription |
| synapse | Azure.ResourceManager.Synapse |
| voiceservices | Azure.ResourceManager.VoiceServices |
| websites | Azure.ResourceManager.AppService |
| workloadmonitor | Azure.ResourceManager.WorkloadMonitor |
| workloads | Azure.ResourceManager.Workloads |


## Provisioning Libraries

Libraries that provide infrastructure-as-code capabilities for Azure services. These libraries allow you to declaratively specify Azure infrastructure natively in .NET and generate Bicep templates for deployment.

**Migration Status**: 2 / 38 migrated to TypeSpec-based generator

| Service | Library | Mgmt Peer Library | Generator |
| ------- | ------- | ----------------- | --------- |
| apimanagement | Azure.Provisioning.ApiManagement | Azure.ResourceManager.ApiManagement | Reflection |
| appconfiguration | Azure.Provisioning.AppConfiguration | Azure.ResourceManager.AppConfiguration ✅ | Reflection |
| applicationinsights | Azure.Provisioning.ApplicationInsights | Azure.ResourceManager.ApplicationInsights | Reflection |
| batch | Azure.Provisioning.Batch | Azure.ResourceManager.Batch ✅ | TypeSpec ✅ |
| cdn | Azure.Provisioning.Cdn | Azure.ResourceManager.Cdn | Reflection |
| cognitiveservices | Azure.Provisioning.CognitiveServices | Azure.ResourceManager.CognitiveServices | Reflection |
| communication | Azure.Provisioning.Communication | Azure.ResourceManager.Communication ✅ | Reflection |
| compute | Azure.Provisioning.Compute | Azure.ResourceManager.Compute | Reflection |
| containerapps | Azure.Provisioning.AppContainers | Azure.ResourceManager.AppContainers | Reflection |
| containerregistry | Azure.Provisioning.ContainerRegistry | Azure.ResourceManager.ContainerRegistry ✅ | Reflection |
| containerservice | Azure.Provisioning.ContainerService | Azure.ResourceManager.ContainerService ✅ | TypeSpec ✅ |
| cosmosdb | Azure.Provisioning.CosmosDB | Azure.ResourceManager.CosmosDB | Reflection |
| datafactory | Azure.Provisioning.DataFactory | Azure.ResourceManager.DataFactory | Reflection |
| dns | Azure.Provisioning.Dns | Azure.ResourceManager.Dns | None |
| eventgrid | Azure.Provisioning.EventGrid | Azure.ResourceManager.EventGrid | Reflection |
| eventhub | Azure.Provisioning.EventHubs | Azure.ResourceManager.EventHubs ✅ | Reflection |
| frontdoor | Azure.Provisioning.FrontDoor | Azure.ResourceManager.FrontDoor | Reflection |
| hybridkubernetes | Azure.Provisioning.Kubernetes | Azure.ResourceManager.Kubernetes ✅ | Reflection |
| keyvault | Azure.Provisioning.KeyVault | Azure.ResourceManager.KeyVault ✅ | Reflection |
| kubernetesconfiguration | Azure.Provisioning.KubernetesConfiguration | Azure.ResourceManager.KubernetesConfiguration | Reflection |
| kusto | Azure.Provisioning.Kusto | Azure.ResourceManager.Kusto | Reflection |
| monitor | Azure.Provisioning.Monitor | Azure.ResourceManager.Monitor | Reflection |
| network | Azure.Provisioning.Network | Azure.ResourceManager.Network | Reflection |
| operationalinsights | Azure.Provisioning.OperationalInsights | Azure.ResourceManager.OperationalInsights | Reflection |
| postgresql | Azure.Provisioning.PostgreSql | Azure.ResourceManager.PostgreSql | Reflection |
| privatedns | Azure.Provisioning.PrivateDns | Azure.ResourceManager.PrivateDns | Reflection |
| provisioning | Azure.Provisioning | Azure.ResourceManager<br>Azure.ResourceManager.Resources<br>Azure.ResourceManager.Authorization<br>Azure.ResourceManager.ManagedServiceIdentities | Reflection |
| provisioning | Azure.Provisioning.Deployment | Azure.ResourceManager<br>Azure.ResourceManager.Resources | None |
| redis | Azure.Provisioning.Redis | Azure.ResourceManager.Redis | Reflection |
| redisenterprise | Azure.Provisioning.RedisEnterprise | Azure.ResourceManager.RedisEnterprise ✅ | Reflection |
| search | Azure.Provisioning.Search | Azure.ResourceManager.Search ✅ | Reflection |
| securitycenter | Azure.Provisioning.SecurityCenter | Azure.ResourceManager.SecurityCenter | Reflection |
| servicebus | Azure.Provisioning.ServiceBus | Azure.ResourceManager.ServiceBus ✅ | Reflection |
| signalr | Azure.Provisioning.SignalR | Azure.ResourceManager.SignalR ✅ | Reflection |
| sqlmanagement | Azure.Provisioning.Sql | Azure.ResourceManager.Sql | Reflection |
| storage | Azure.Provisioning.Storage | Azure.ResourceManager.Storage ✅ | Reflection |
| webpubsub | Azure.Provisioning.WebPubSub | Azure.ResourceManager.WebPubSub ✅ | Reflection |
| websites | Azure.Provisioning.AppService | Azure.ResourceManager.AppService | Reflection |


## Libraries with No Generator

Libraries with no generator have neither autorest.md nor tsp-location.yaml files. Total: 48

| Service | Library |
| ------- | ------- |
| agentserver | Azure.AI.AgentServer.Core |
| agentserver | Azure.AI.AgentServer.Invocations |
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
| storage | Azure.Storage.DataMovement.Blobs.Files.Shares |
| storage | Azure.Storage.DataMovement.Files.Shares |
| storage | Azure.Storage.Internal.Avro |
| tools | Azure.GeneratorAgent |
| tools | Azure.SdkAnalyzers |
| webpubsub | Azure.Messaging.WebPubSub.Client |
