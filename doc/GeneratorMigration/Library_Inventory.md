# Azure SDK for .NET Libraries Inventory

## Summary

- Total libraries: 414
- Management Plane (Swagger): 165
- Management Plane (TSP-Old): 49
- Management Plane (TypeSpec - @azure-typespec/http-client-csharp): 0
- Management Plane (TypeSpec - @azure-typespec/http-client-csharp-mgmt): 10
- Management Plane (TypeSpec - @typespec/http-client-csharp): 0
- Management Plane (TypeSpec - Unknown TypeSpec Generator: eng/emitter-package.json): 0
- Data Plane (Swagger): 115
- Data Plane (TSP-Old): 26
- Data Plane (TypeSpec - @azure-typespec/http-client-csharp): 8
- Data Plane (TypeSpec - @azure-typespec/http-client-csharp-mgmt): 0
- Data Plane (TypeSpec - @typespec/http-client-csharp): 2
- Data Plane (TypeSpec - Unknown TypeSpec Generator: eng/emitter-package.json): 1
- No generator: 38


## Data Plane Libraries using TypeSpec (@azure-typespec/http-client-csharp)

TypeSpec with @azure-typespec/http-client-csharp generator is detected by the presence of a tsp-location.yaml file with an emitterPackageJsonPath value referencing @azure-typespec/http-client-csharp, or through special handling for specific libraries. Total: 8

| Service | Library | Path |
| ------- | ------- | ---- |
| ai | Azure.AI.VoiceLive | sdk/ai/Azure.AI.VoiceLive |
| appconfiguration | Azure.Data.AppConfiguration | sdk/appconfiguration/Azure.Data.AppConfiguration |
| eventgrid | Azure.Messaging.EventGrid.Namespaces | sdk/eventgrid/Azure.Messaging.EventGrid.Namespaces |
| eventgrid | Azure.Messaging.EventGrid.SystemEvents | sdk/eventgrid/Azure.Messaging.EventGrid.SystemEvents |
| healthdataaiservices | Azure.Health.Deidentification | sdk/healthdataaiservices/Azure.Health.Deidentification |
| keyvault | Azure.Security.KeyVault.Administration | sdk/keyvault/Azure.Security.KeyVault.Administration |
| monitor | Azure.Monitor.Ingestion | sdk/monitor/Azure.Monitor.Ingestion |
| schemaregistry | Azure.Data.SchemaRegistry | sdk/schemaregistry/Azure.Data.SchemaRegistry |


## Data Plane Libraries using TypeSpec (@typespec/http-client-csharp)

TypeSpec with @typespec/http-client-csharp generator is detected by the presence of a tsp-location.yaml file with an emitterPackageJsonPath value referencing @typespec/http-client-csharp, or through special handling for specific libraries. Total: 2

| Service | Library | Path |
| ------- | ------- | ---- |
| ai | Azure.AI.Projects | sdk/ai/Azure.AI.Projects |
| openai | Azure.AI.OpenAI | sdk/openai/Azure.AI.OpenAI |


## Data Plane Libraries using TypeSpec (Unknown TypeSpec Generator: eng/emitter-package.json)

TypeSpec with Unknown TypeSpec Generator: eng/emitter-package.json generator is detected by the presence of a tsp-location.yaml file with an emitterPackageJsonPath value referencing Unknown TypeSpec Generator: eng/emitter-package.json, or through special handling for specific libraries. Total: 1

| Service | Library | Path |
| ------- | ------- | ---- |
| ai | Azure.AI.Agents.Persistent | sdk/ai/Azure.AI.Agents.Persistent |


## Data Plane Libraries using TypeSpec (Old Generator)

TypeSpec with old generator is detected by the presence of a tsp-location.yaml file without an emitterPackageJsonPath value, tspconfig.yaml file, tsp directory, or *.tsp files. Total: 26

| Service | Library | Path |
| ------- | ------- | ---- |
| ai | Azure.AI.Inference | sdk/ai/Azure.AI.Inference |
| anomalydetector | Azure.AI.AnomalyDetector | sdk/anomalydetector/Azure.AI.AnomalyDetector |
| batch | Azure.Compute.Batch | sdk/batch/Azure.Compute.Batch |
| cognitivelanguage | Azure.AI.Language.Conversations | sdk/cognitivelanguage/Azure.AI.Language.Conversations |
| cognitivelanguage | Azure.AI.Language.Conversations.Authoring | sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring |
| cognitivelanguage | Azure.AI.Language.Text | sdk/cognitivelanguage/Azure.AI.Language.Text |
| cognitivelanguage | Azure.AI.Language.Text.Authoring | sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring |
| communication | Azure.Communication.JobRouter | sdk/communication/Azure.Communication.JobRouter |
| communication | Azure.Communication.Messages | sdk/communication/Azure.Communication.Messages |
| communication | Azure.Communication.ProgrammableConnectivity | sdk/communication/Azure.Communication.ProgrammableConnectivity |
| confidentialledger | Azure.Security.CodeTransparency | sdk/confidentialledger/Azure.Security.CodeTransparency |
| contentsafety | Azure.AI.ContentSafety | sdk/contentsafety/Azure.AI.ContentSafety |
| devcenter | Azure.Developer.DevCenter | sdk/devcenter/Azure.Developer.DevCenter |
| documentintelligence | Azure.AI.DocumentIntelligence | sdk/documentintelligence/Azure.AI.DocumentIntelligence |
| easm | Azure.Analytics.Defender.Easm | sdk/easm/Azure.Analytics.Defender.Easm |
| face | Azure.AI.Vision.Face | sdk/face/Azure.AI.Vision.Face |
| healthinsights | Azure.Health.Insights.CancerProfiling | sdk/healthinsights/Azure.Health.Insights.CancerProfiling |
| healthinsights | Azure.Health.Insights.ClinicalMatching | sdk/healthinsights/Azure.Health.Insights.ClinicalMatching |
| healthinsights | Azure.Health.Insights.RadiologyInsights | sdk/healthinsights/Azure.Health.Insights.RadiologyInsights |
| loadtestservice | Azure.Developer.LoadTesting | sdk/loadtestservice/Azure.Developer.LoadTesting |
| onlineexperimentation | Azure.Analytics.OnlineExperimentation | sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation |
| openai | Azure.AI.OpenAI.Assistants | sdk/openai/Azure.AI.OpenAI.Assistants |
| purview | Azure.Analytics.Purview.DataMap | sdk/purview/Azure.Analytics.Purview.DataMap |
| translation | Azure.AI.Translation.Document | sdk/translation/Azure.AI.Translation.Document |
| translation | Azure.AI.Translation.Text | sdk/translation/Azure.AI.Translation.Text |
| vision | Azure.AI.Vision.ImageAnalysis | sdk/vision/Azure.AI.Vision.ImageAnalysis |


## Data Plane Libraries using Swagger

Total: 115

| Service | Library | Path |
| ------- | ------- | ---- |
| agrifood | Azure.Verticals.AgriFood.Farming | sdk/agrifood/Azure.Verticals.AgriFood.Farming |
| attestation | Azure.Security.Attestation | sdk/attestation/Azure.Security.Attestation |
| cognitivelanguage | Azure.AI.Language.QuestionAnswering | sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering |
| cognitiveservices | AnomalyDetector | sdk/cognitiveservices/AnomalyDetector |
| cognitiveservices | FormRecognizer | sdk/cognitiveservices/FormRecognizer |
| cognitiveservices | Knowledge.QnAMaker | sdk/cognitiveservices/Knowledge.QnAMaker |
| cognitiveservices | Language.LUIS.Authoring | sdk/cognitiveservices/Language.LUIS.Authoring |
| cognitiveservices | Language.LUIS.Runtime | sdk/cognitiveservices/Language.LUIS.Runtime |
| cognitiveservices | Language.SpellCheck | sdk/cognitiveservices/Language.SpellCheck |
| cognitiveservices | Language.TextAnalytics | sdk/cognitiveservices/Language.TextAnalytics |
| cognitiveservices | Personalizer | sdk/cognitiveservices/Personalizer |
| cognitiveservices | Search.BingAutoSuggest | sdk/cognitiveservices/Search.BingAutoSuggest |
| cognitiveservices | Search.BingCustomImageSearch | sdk/cognitiveservices/Search.BingCustomImageSearch |
| cognitiveservices | Search.BingCustomSearch | sdk/cognitiveservices/Search.BingCustomSearch |
| cognitiveservices | Search.BingEntitySearch | sdk/cognitiveservices/Search.BingEntitySearch |
| cognitiveservices | Search.BingImageSearch | sdk/cognitiveservices/Search.BingImageSearch |
| cognitiveservices | Search.BingLocalSearch | sdk/cognitiveservices/Search.BingLocalSearch |
| cognitiveservices | Search.BingNewsSearch | sdk/cognitiveservices/Search.BingNewsSearch |
| cognitiveservices | Search.BingVideoSearch | sdk/cognitiveservices/Search.BingVideoSearch |
| cognitiveservices | Search.BingVisualSearch | sdk/cognitiveservices/Search.BingVisualSearch |
| cognitiveservices | Search.BingWebSearch | sdk/cognitiveservices/Search.BingWebSearch |
| cognitiveservices | Vision.ComputerVision | sdk/cognitiveservices/Vision.ComputerVision |
| cognitiveservices | Vision.ContentModerator | sdk/cognitiveservices/Vision.ContentModerator |
| cognitiveservices | Vision.CustomVision.Prediction | sdk/cognitiveservices/Vision.CustomVision.Prediction |
| cognitiveservices | Vision.CustomVision.Training | sdk/cognitiveservices/Vision.CustomVision.Training |
| cognitiveservices | Vision.Face | sdk/cognitiveservices/Vision.Face |
| communication | Azure.Communication.AlphaIds | sdk/communication/Azure.Communication.AlphaIds |
| communication | Azure.Communication.CallAutomation | sdk/communication/Azure.Communication.CallAutomation |
| communication | Azure.Communication.CallingServer | sdk/communication/Azure.Communication.CallingServer |
| communication | Azure.Communication.Chat | sdk/communication/Azure.Communication.Chat |
| communication | Azure.Communication.Email | sdk/communication/Azure.Communication.Email |
| communication | Azure.Communication.Identity | sdk/communication/Azure.Communication.Identity |
| communication | Azure.Communication.PhoneNumbers | sdk/communication/Azure.Communication.PhoneNumbers |
| communication | Azure.Communication.Rooms | sdk/communication/Azure.Communication.Rooms |
| communication | Azure.Communication.ShortCodes | sdk/communication/Azure.Communication.ShortCodes |
| communication | Azure.Communication.Sms | sdk/communication/Azure.Communication.Sms |
| confidentialledger | Azure.Security.ConfidentialLedger | sdk/confidentialledger/Azure.Security.ConfidentialLedger |
| containerregistry | Azure.Containers.ContainerRegistry | sdk/containerregistry/Azure.Containers.ContainerRegistry |
| core | Azure.Core.Expressions.DataFactory | sdk/core/Azure.Core.Expressions.DataFactory |
| core | Azure.Core.TestFramework | sdk/core/Azure.Core.TestFramework |
| deviceupdate | Azure.IoT.DeviceUpdate | sdk/deviceupdate/Azure.IoT.DeviceUpdate |
| digitaltwins | Azure.DigitalTwins.Core | sdk/digitaltwins/Azure.DigitalTwins.Core |
| eventgrid | Azure.Messaging.EventGrid | sdk/eventgrid/Azure.Messaging.EventGrid |
| formrecognizer | Azure.AI.FormRecognizer | sdk/formrecognizer/Azure.AI.FormRecognizer |
| iot | Azure.IoT.Hub.Service | sdk/iot/Azure.IoT.Hub.Service |
| loadtestservice | Azure.Developer.Playwright | sdk/loadtestservice/Azure.Developer.Playwright |
| maps | Azure.Maps.Common | sdk/maps/Azure.Maps.Common |
| maps | Azure.Maps.Geolocation | sdk/maps/Azure.Maps.Geolocation |
| maps | Azure.Maps.Rendering | sdk/maps/Azure.Maps.Rendering |
| maps | Azure.Maps.Routing | sdk/maps/Azure.Maps.Routing |
| maps | Azure.Maps.Search | sdk/maps/Azure.Maps.Search |
| maps | Azure.Maps.TimeZones | sdk/maps/Azure.Maps.TimeZones |
| maps | Azure.Maps.Weather | sdk/maps/Azure.Maps.Weather |
| metricsadvisor | Azure.AI.MetricsAdvisor | sdk/metricsadvisor/Azure.AI.MetricsAdvisor |
| mixedreality | Azure.MixedReality.Authentication | sdk/mixedreality/Azure.MixedReality.Authentication |
| monitor | Azure.Monitor.OpenTelemetry.Exporter | sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter |
| monitor | Azure.Monitor.OpenTelemetry.LiveMetrics | sdk/monitor/Azure.Monitor.OpenTelemetry.LiveMetrics |
| monitor | Azure.Monitor.Query | sdk/monitor/Azure.Monitor.Query |
| objectanchors | Azure.MixedReality.ObjectAnchors.Conversion | sdk/objectanchors/Azure.MixedReality.ObjectAnchors.Conversion |
| personalizer | Azure.AI.Personalizer | sdk/personalizer/Azure.AI.Personalizer |
| provisioning | Azure.Provisioning | sdk/provisioning/Azure.Provisioning |
| provisioning | Azure.Provisioning.AppConfiguration | sdk/provisioning/Azure.Provisioning.AppConfiguration |
| provisioning | Azure.Provisioning.AppContainers | sdk/provisioning/Azure.Provisioning.AppContainers |
| provisioning | Azure.Provisioning.ApplicationInsights | sdk/provisioning/Azure.Provisioning.ApplicationInsights |
| provisioning | Azure.Provisioning.AppService | sdk/provisioning/Azure.Provisioning.AppService |
| provisioning | Azure.Provisioning.CognitiveServices | sdk/provisioning/Azure.Provisioning.CognitiveServices |
| provisioning | Azure.Provisioning.Communication | sdk/provisioning/Azure.Provisioning.Communication |
| provisioning | Azure.Provisioning.ContainerRegistry | sdk/provisioning/Azure.Provisioning.ContainerRegistry |
| provisioning | Azure.Provisioning.ContainerService | sdk/provisioning/Azure.Provisioning.ContainerService |
| provisioning | Azure.Provisioning.CosmosDB | sdk/provisioning/Azure.Provisioning.CosmosDB |
| provisioning | Azure.Provisioning.EventGrid | sdk/provisioning/Azure.Provisioning.EventGrid |
| provisioning | Azure.Provisioning.EventHubs | sdk/provisioning/Azure.Provisioning.EventHubs |
| provisioning | Azure.Provisioning.KeyVault | sdk/provisioning/Azure.Provisioning.KeyVault |
| provisioning | Azure.Provisioning.Kubernetes | sdk/provisioning/Azure.Provisioning.Kubernetes |
| provisioning | Azure.Provisioning.KubernetesConfiguration | sdk/provisioning/Azure.Provisioning.KubernetesConfiguration |
| provisioning | Azure.Provisioning.Kusto | sdk/provisioning/Azure.Provisioning.Kusto |
| provisioning | Azure.Provisioning.Network | sdk/provisioning/Azure.Provisioning.Network |
| provisioning | Azure.Provisioning.OperationalInsights | sdk/provisioning/Azure.Provisioning.OperationalInsights |
| provisioning | Azure.Provisioning.PostgreSql | sdk/provisioning/Azure.Provisioning.PostgreSql |
| provisioning | Azure.Provisioning.Redis | sdk/provisioning/Azure.Provisioning.Redis |
| provisioning | Azure.Provisioning.RedisEnterprise | sdk/provisioning/Azure.Provisioning.RedisEnterprise |
| provisioning | Azure.Provisioning.Search | sdk/provisioning/Azure.Provisioning.Search |
| provisioning | Azure.Provisioning.ServiceBus | sdk/provisioning/Azure.Provisioning.ServiceBus |
| provisioning | Azure.Provisioning.SignalR | sdk/provisioning/Azure.Provisioning.SignalR |
| provisioning | Azure.Provisioning.Sql | sdk/provisioning/Azure.Provisioning.Sql |
| provisioning | Azure.Provisioning.Storage | sdk/provisioning/Azure.Provisioning.Storage |
| provisioning | Azure.Provisioning.WebPubSub | sdk/provisioning/Azure.Provisioning.WebPubSub |
| purview | Azure.Analytics.Purview.Account | sdk/purview/Azure.Analytics.Purview.Account |
| purview | Azure.Analytics.Purview.Administration | sdk/purview/Azure.Analytics.Purview.Administration |
| purview | Azure.Analytics.Purview.Catalog | sdk/purview/Azure.Analytics.Purview.Catalog |
| purview | Azure.Analytics.Purview.Scanning | sdk/purview/Azure.Analytics.Purview.Scanning |
| purview | Azure.Analytics.Purview.Sharing | sdk/purview/Azure.Analytics.Purview.Sharing |
| purview | Azure.Analytics.Purview.Workflows | sdk/purview/Azure.Analytics.Purview.Workflows |
| quantum | Azure.Quantum.Jobs | sdk/quantum/Azure.Quantum.Jobs |
| remoterendering | Azure.MixedReality.RemoteRendering | sdk/remoterendering/Azure.MixedReality.RemoteRendering |
| search | Azure.Search.Documents | sdk/search/Azure.Search.Documents |
| storage | Azure.Storage.Blobs | sdk/storage/Azure.Storage.Blobs |
| storage | Azure.Storage.Blobs.Batch | sdk/storage/Azure.Storage.Blobs.Batch |
| storage | Azure.Storage.Common | sdk/storage/Azure.Storage.Common |
| storage | Azure.Storage.Files.DataLake | sdk/storage/Azure.Storage.Files.DataLake |
| storage | Azure.Storage.Files.Shares | sdk/storage/Azure.Storage.Files.Shares |
| storage | Azure.Storage.Queues | sdk/storage/Azure.Storage.Queues |
| synapse | Azure.Analytics.Synapse.AccessControl | sdk/synapse/Azure.Analytics.Synapse.AccessControl |
| synapse | Azure.Analytics.Synapse.Artifacts | sdk/synapse/Azure.Analytics.Synapse.Artifacts |
| synapse | Azure.Analytics.Synapse.ManagedPrivateEndpoints | sdk/synapse/Azure.Analytics.Synapse.ManagedPrivateEndpoints |
| synapse | Azure.Analytics.Synapse.Monitoring | sdk/synapse/Azure.Analytics.Synapse.Monitoring |
| synapse | Azure.Analytics.Synapse.Spark | sdk/synapse/Azure.Analytics.Synapse.Spark |
| tables | Azure.Data.Tables | sdk/tables/Azure.Data.Tables |
| template | .content | sdk/template/.content |
| template | Azure.Template | sdk/template/Azure.Template |
| textanalytics | Azure.AI.TextAnalytics | sdk/textanalytics/Azure.AI.TextAnalytics |
| textanalytics | Azure.AI.TextAnalytics.Legacy.Shared | sdk/textanalytics/Azure.AI.TextAnalytics.Legacy.Shared |
| timeseriesinsights | Azure.IoT.TimeSeriesInsights | sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights |
| videoanalyzer | Azure.Media.VideoAnalyzer.Edge | sdk/videoanalyzer/Azure.Media.VideoAnalyzer.Edge |
| webpubsub | Azure.Messaging.WebPubSub | sdk/webpubsub/Azure.Messaging.WebPubSub |


## Management Plane Libraries using TypeSpec (@azure-typespec/http-client-csharp-mgmt)

TypeSpec with @azure-typespec/http-client-csharp-mgmt generator is detected by the presence of a tsp-location.yaml file with an emitterPackageJsonPath value referencing @azure-typespec/http-client-csharp-mgmt, or through special handling for specific libraries. Total: 10

| Service | Library | Path |
| ------- | ------- | ---- |
| arizeaiobservabilityeval | Azure.ResourceManager.ArizeAIObservabilityEval | sdk/arizeaiobservabilityeval/Azure.ResourceManager.ArizeAIObservabilityEval |
| computerecommender | Azure.ResourceManager.Compute.Recommender | sdk/computerecommender/Azure.ResourceManager.Compute.Recommender |
| dellstorage | Azure.ResourceManager.Dell.Storage | sdk/dellstorage/Azure.ResourceManager.Dell.Storage |
| hybridkubernetes | Azure.ResourceManager.Kubernetes | sdk/hybridkubernetes/Azure.ResourceManager.Kubernetes |
| lambdatesthyperexecute | Azure.ResourceManager.LambdaTestHyperExecute | sdk/lambdatesthyperexecute/Azure.ResourceManager.LambdaTestHyperExecute |
| pineconevectordb | Azure.ResourceManager.PineconeVectorDB | sdk/pineconevectordb/Azure.ResourceManager.PineconeVectorDB |
| planetarycomputer | Azure.ResourceManager.PlanetaryComputer | sdk/planetarycomputer/Azure.ResourceManager.PlanetaryComputer |
| portalservices | Azure.ResourceManager.PortalServicesCopilot | sdk/portalservices/Azure.ResourceManager.PortalServicesCopilot |
| storageactions | Azure.ResourceManager.StorageActions | sdk/storageactions/Azure.ResourceManager.StorageActions |
| storagediscovery | Azure.ResourceManager.StorageDiscovery | sdk/storagediscovery/Azure.ResourceManager.StorageDiscovery |
| weightsandbiases | Azure.ResourceManager.WeightsAndBiases | sdk/weightsandbiases/Azure.ResourceManager.WeightsAndBiases |


## Management Plane Libraries using TypeSpec (Old Generator)

TypeSpec with old generator is detected by the presence of a tsp-location.yaml file without an emitterPackageJsonPath value, tspconfig.yaml file, tsp directory, or *.tsp files. Total: 49

| Service | Library | Path |
| ------- | ------- | ---- |
| agricultureplatform | Azure.ResourceManager.AgriculturePlatform | sdk/agricultureplatform/Azure.ResourceManager.AgriculturePlatform |
| avs | Azure.ResourceManager.Avs | sdk/avs/Azure.ResourceManager.Avs |
| azurestackhci | Azure.ResourceManager.Hci.Vm | sdk/azurestackhci/Azure.ResourceManager.Hci.Vm |
| carbon | Azure.ResourceManager.CarbonOptimization | sdk/carbon/Azure.ResourceManager.CarbonOptimization |
| chaos | Azure.ResourceManager.Chaos | sdk/chaos/Azure.ResourceManager.Chaos |
| cloudhealth | Azure.ResourceManager.CloudHealth | sdk/cloudhealth/Azure.ResourceManager.CloudHealth |
| computefleet | Azure.ResourceManager.ComputeFleet | sdk/computefleet/Azure.ResourceManager.ComputeFleet |
| computeschedule | Azure.ResourceManager.ComputeSchedule | sdk/computeschedule/Azure.ResourceManager.ComputeSchedule |
| connectedcache | Azure.ResourceManager.ConnectedCache | sdk/connectedcache/Azure.ResourceManager.ConnectedCache |
| containerorchestratorruntime | Azure.ResourceManager.ContainerOrchestratorRuntime | sdk/containerorchestratorruntime/Azure.ResourceManager.ContainerOrchestratorRuntime |
| databasewatcher | Azure.ResourceManager.DatabaseWatcher | sdk/databasewatcher/Azure.ResourceManager.DatabaseWatcher |
| databox | Azure.ResourceManager.DataBox | sdk/databox/Azure.ResourceManager.DataBox |
| dependencymap | Azure.ResourceManager.DependencyMap | sdk/dependencymap/Azure.ResourceManager.DependencyMap |
| deviceprovisioningservices | Azure.ResourceManager.DeviceProvisioningServices | sdk/deviceprovisioningservices/Azure.ResourceManager.DeviceProvisioningServices |
| deviceregistry | Azure.ResourceManager.DeviceRegistry | sdk/deviceregistry/Azure.ResourceManager.DeviceRegistry |
| devopsinfrastructure | Azure.ResourceManager.DevOpsInfrastructure | sdk/devopsinfrastructure/Azure.ResourceManager.DevOpsInfrastructure |
| disconnectedoperations | Azure.ResourceManager.DisconnectedOperations | sdk/disconnectedoperations/Azure.ResourceManager.DisconnectedOperations |
| durabletask | Azure.ResourceManager.DurableTask | sdk/durabletask/Azure.ResourceManager.DurableTask |
| elasticsan | Azure.ResourceManager.ElasticSan | sdk/elasticsan/Azure.ResourceManager.ElasticSan |
| fabric | Azure.ResourceManager.Fabric | sdk/fabric/Azure.ResourceManager.Fabric |
| grafana | Azure.ResourceManager.Grafana | sdk/grafana/Azure.ResourceManager.Grafana |
| hardwaresecuritymodules | Azure.ResourceManager.HardwareSecurityModules | sdk/hardwaresecuritymodules/Azure.ResourceManager.HardwareSecurityModules |
| healthdataaiservices | Azure.ResourceManager.HealthDataAIServices | sdk/healthdataaiservices/Azure.ResourceManager.HealthDataAIServices |
| hybridconnectivity | Azure.ResourceManager.HybridConnectivity | sdk/hybridconnectivity/Azure.ResourceManager.HybridConnectivity |
| informaticadatamanagement | Azure.ResourceManager.InformaticaDataManagement | sdk/informaticadatamanagement/Azure.ResourceManager.InformaticaDataManagement |
| iotoperations | Azure.ResourceManager.IotOperations | sdk/iotoperations/Azure.ResourceManager.IotOperations |
| mongocluster | Azure.ResourceManager.MongoCluster | sdk/mongocluster/Azure.ResourceManager.MongoCluster |
| mongodbatlas | Azure.ResourceManager.MongoDBAtlas | sdk/mongodbatlas/Azure.ResourceManager.MongoDBAtlas |
| neonpostgres | Azure.ResourceManager.NeonPostgres | sdk/neonpostgres/Azure.ResourceManager.NeonPostgres |
| onlineexperimentation | Azure.ResourceManager.OnlineExperimentation | sdk/onlineexperimentation/Azure.ResourceManager.OnlineExperimentation |
| oracle | Azure.ResourceManager.OracleDatabase | sdk/oracle/Azure.ResourceManager.OracleDatabase |
| playwright | Azure.ResourceManager.Playwright | sdk/playwright/Azure.ResourceManager.Playwright |
| purestorageblock | Azure.ResourceManager.PureStorageBlock | sdk/purestorageblock/Azure.ResourceManager.PureStorageBlock |
| quota | Azure.ResourceManager.Quota | sdk/quota/Azure.ResourceManager.Quota |
| recoveryservices | Azure.ResourceManager.RecoveryServices | sdk/recoveryservices/Azure.ResourceManager.RecoveryServices |
| recoveryservices-datareplication | Azure.ResourceManager.RecoveryServicesDataReplication | sdk/recoveryservices-datareplication/Azure.ResourceManager.RecoveryServicesDataReplication |
| resources | Azure.ResourceManager.Resources.Bicep | sdk/resources/Azure.ResourceManager.Resources.Bicep |
| secretsstoreextension | Azure.ResourceManager.SecretsStoreExtension | sdk/secretsstoreextension/Azure.ResourceManager.SecretsStoreExtension |
| selfhelp | Azure.ResourceManager.SelfHelp | sdk/selfhelp/Azure.ResourceManager.SelfHelp |
| servicefabricmanagedclusters | Azure.ResourceManager.ServiceFabricManagedClusters | sdk/servicefabricmanagedclusters/Azure.ResourceManager.ServiceFabricManagedClusters |
| servicenetworking | Azure.ResourceManager.ServiceNetworking | sdk/servicenetworking/Azure.ResourceManager.ServiceNetworking |
| sitemanager | Azure.ResourceManager.SiteManager | sdk/sitemanager/Azure.ResourceManager.SiteManager |
| standbypool | Azure.ResourceManager.StandbyPool | sdk/standbypool/Azure.ResourceManager.StandbyPool |
| storagemover | Azure.ResourceManager.StorageMover | sdk/storagemover/Azure.ResourceManager.StorageMover |
| terraform | Azure.ResourceManager.Terraform | sdk/terraform/Azure.ResourceManager.Terraform |
| virtualenclaves | Azure.ResourceManager.VirtualEnclaves | sdk/virtualenclaves/Azure.ResourceManager.VirtualEnclaves |
| workloadorchestration | Azure.ResourceManager.WorkloadOrchestration | sdk/workloadorchestration/Azure.ResourceManager.WorkloadOrchestration |
| workloadssapvirtualinstance | Azure.ResourceManager.WorkloadsSapVirtualInstance | sdk/workloadssapvirtualinstance/Azure.ResourceManager.WorkloadsSapVirtualInstance |


## Management Plane Libraries using Swagger

Total: 165

| Service | Library | Path |
| ------- | ------- | ---- |
| advisor | Azure.ResourceManager.Advisor | sdk/advisor/Azure.ResourceManager.Advisor |
| agrifood | Azure.ResourceManager.AgFoodPlatform | sdk/agrifood/Azure.ResourceManager.AgFoodPlatform |
| alertsmanagement | Azure.ResourceManager.AlertsManagement | sdk/alertsmanagement/Azure.ResourceManager.AlertsManagement |
| analysisservices | Azure.ResourceManager.Analysis | sdk/analysisservices/Azure.ResourceManager.Analysis |
| apicenter | Azure.ResourceManager.ApiCenter | sdk/apicenter/Azure.ResourceManager.ApiCenter |
| apimanagement | Azure.ResourceManager.ApiManagement | sdk/apimanagement/Azure.ResourceManager.ApiManagement |
| appcomplianceautomation | Azure.ResourceManager.AppComplianceAutomation | sdk/appcomplianceautomation/Azure.ResourceManager.AppComplianceAutomation |
| appconfiguration | Azure.ResourceManager.AppConfiguration | sdk/appconfiguration/Azure.ResourceManager.AppConfiguration |
| applicationinsights | Azure.ResourceManager.ApplicationInsights | sdk/applicationinsights/Azure.ResourceManager.ApplicationInsights |
| appplatform | Azure.ResourceManager.AppPlatform | sdk/appplatform/Azure.ResourceManager.AppPlatform |
| arc-scvmm | Azure.ResourceManager.ScVmm | sdk/arc-scvmm/Azure.ResourceManager.ScVmm |
| astronomer | Azure.ResourceManager.Astro | sdk/astronomer/Azure.ResourceManager.Astro |
| attestation | Azure.ResourceManager.Attestation | sdk/attestation/Azure.ResourceManager.Attestation |
| authorization | Azure.ResourceManager.Authorization | sdk/authorization/Azure.ResourceManager.Authorization |
| automanage | Azure.ResourceManager.Automanage | sdk/automanage/Azure.ResourceManager.Automanage |
| automation | Azure.ResourceManager.Automation | sdk/automation/Azure.ResourceManager.Automation |
| azurelargeinstance | Azure.ResourceManager.LargeInstance | sdk/azurelargeinstance/Azure.ResourceManager.LargeInstance |
| azurestackhci | Azure.ResourceManager.Hci | sdk/azurestackhci/Azure.ResourceManager.Hci |
| batch | Azure.ResourceManager.Batch | sdk/batch/Azure.ResourceManager.Batch |
| billing | Azure.ResourceManager.Billing | sdk/billing/Azure.ResourceManager.Billing |
| billingbenefits | Azure.ResourceManager.BillingBenefits | sdk/billingbenefits/Azure.ResourceManager.BillingBenefits |
| blueprint | Azure.ResourceManager.Blueprint | sdk/blueprint/Azure.ResourceManager.Blueprint |
| botservice | Azure.ResourceManager.BotService | sdk/botservice/Azure.ResourceManager.BotService |
| cdn | Azure.ResourceManager.Cdn | sdk/cdn/Azure.ResourceManager.Cdn |
| changeanalysis | Azure.ResourceManager.ChangeAnalysis | sdk/changeanalysis/Azure.ResourceManager.ChangeAnalysis |
| cognitiveservices | Azure.ResourceManager.CognitiveServices | sdk/cognitiveservices/Azure.ResourceManager.CognitiveServices |
| communication | Azure.ResourceManager.Communication | sdk/communication/Azure.ResourceManager.Communication |
| compute | Azure.ResourceManager.Compute | sdk/compute/Azure.ResourceManager.Compute |
| confidentialledger | Azure.ResourceManager.ConfidentialLedger | sdk/confidentialledger/Azure.ResourceManager.ConfidentialLedger |
| confluent | Azure.ResourceManager.Confluent | sdk/confluent/Azure.ResourceManager.Confluent |
| connectedvmwarevsphere | Azure.ResourceManager.ConnectedVMwarevSphere | sdk/connectedvmwarevsphere/Azure.ResourceManager.ConnectedVMwarevSphere |
| consumption | Azure.ResourceManager.Consumption | sdk/consumption/Azure.ResourceManager.Consumption |
| containerapps | Azure.ResourceManager.AppContainers | sdk/containerapps/Azure.ResourceManager.AppContainers |
| containerinstance | Azure.ResourceManager.ContainerInstance | sdk/containerinstance/Azure.ResourceManager.ContainerInstance |
| containerregistry | Azure.ResourceManager.ContainerRegistry | sdk/containerregistry/Azure.ResourceManager.ContainerRegistry |
| containerservice | Azure.ResourceManager.ContainerService | sdk/containerservice/Azure.ResourceManager.ContainerService |
| cosmosdb | Azure.ResourceManager.CosmosDB | sdk/cosmosdb/Azure.ResourceManager.CosmosDB |
| cosmosdbforpostgresql | Azure.ResourceManager.CosmosDBForPostgreSql | sdk/cosmosdbforpostgresql/Azure.ResourceManager.CosmosDBForPostgreSql |
| costmanagement | Azure.ResourceManager.CostManagement | sdk/costmanagement/Azure.ResourceManager.CostManagement |
| customer-insights | Azure.ResourceManager.CustomerInsights | sdk/customer-insights/Azure.ResourceManager.CustomerInsights |
| databoxedge | Azure.ResourceManager.DataBoxEdge | sdk/databoxedge/Azure.ResourceManager.DataBoxEdge |
| datadog | Azure.ResourceManager.Datadog | sdk/datadog/Azure.ResourceManager.Datadog |
| datafactory | Azure.ResourceManager.DataFactory | sdk/datafactory/Azure.ResourceManager.DataFactory |
| datalake-analytics | Azure.ResourceManager.DataLakeAnalytics | sdk/datalake-analytics/Azure.ResourceManager.DataLakeAnalytics |
| datalake-store | Azure.ResourceManager.DataLakeStore | sdk/datalake-store/Azure.ResourceManager.DataLakeStore |
| datamigration | Azure.ResourceManager.DataMigration | sdk/datamigration/Azure.ResourceManager.DataMigration |
| dataprotection | Azure.ResourceManager.DataProtectionBackup | sdk/dataprotection/Azure.ResourceManager.DataProtectionBackup |
| datashare | Azure.ResourceManager.DataShare | sdk/datashare/Azure.ResourceManager.DataShare |
| defendereasm | Azure.ResourceManager.DefenderEasm | sdk/defendereasm/Azure.ResourceManager.DefenderEasm |
| desktopvirtualization | Azure.ResourceManager.DesktopVirtualization | sdk/desktopvirtualization/Azure.ResourceManager.DesktopVirtualization |
| devcenter | Azure.ResourceManager.DevCenter | sdk/devcenter/Azure.ResourceManager.DevCenter |
| deviceupdate | Azure.ResourceManager.DeviceUpdate | sdk/deviceupdate/Azure.ResourceManager.DeviceUpdate |
| devspaces | Azure.ResourceManager.DevSpaces | sdk/devspaces/Azure.ResourceManager.DevSpaces |
| devtestlabs | Azure.ResourceManager.DevTestLabs | sdk/devtestlabs/Azure.ResourceManager.DevTestLabs |
| digitaltwins | Azure.ResourceManager.DigitalTwins | sdk/digitaltwins/Azure.ResourceManager.DigitalTwins |
| dns | Azure.ResourceManager.Dns | sdk/dns/Azure.ResourceManager.Dns |
| dnsresolver | Azure.ResourceManager.DnsResolver | sdk/dnsresolver/Azure.ResourceManager.DnsResolver |
| dynatrace | Azure.ResourceManager.Dynatrace | sdk/dynatrace/Azure.ResourceManager.Dynatrace |
| edgeorder | Azure.ResourceManager.EdgeOrder | sdk/edgeorder/Azure.ResourceManager.EdgeOrder |
| edgezones | Azure.ResourceManager.EdgeZones | sdk/edgezones/Azure.ResourceManager.EdgeZones |
| elastic | Azure.ResourceManager.Elastic | sdk/elastic/Azure.ResourceManager.Elastic |
| eventgrid | Azure.ResourceManager.EventGrid | sdk/eventgrid/Azure.ResourceManager.EventGrid |
| eventhub | Azure.ResourceManager.EventHubs | sdk/eventhub/Azure.ResourceManager.EventHubs |
| extendedlocation | Azure.ResourceManager.ExtendedLocations | sdk/extendedlocation/Azure.ResourceManager.ExtendedLocations |
| fleet | Azure.ResourceManager.ContainerServiceFleet | sdk/fleet/Azure.ResourceManager.ContainerServiceFleet |
| fluidrelay | Azure.ResourceManager.FluidRelay | sdk/fluidrelay/Azure.ResourceManager.FluidRelay |
| frontdoor | Azure.ResourceManager.FrontDoor | sdk/frontdoor/Azure.ResourceManager.FrontDoor |
| graphservices | Azure.ResourceManager.GraphServices | sdk/graphservices/Azure.ResourceManager.GraphServices |
| guestconfiguration | Azure.ResourceManager.GuestConfiguration | sdk/guestconfiguration/Azure.ResourceManager.GuestConfiguration |
| hdinsight | Azure.ResourceManager.HDInsight | sdk/hdinsight/Azure.ResourceManager.HDInsight |
| hdinsightcontainers | Azure.ResourceManager.HDInsight.Containers | sdk/hdinsightcontainers/Azure.ResourceManager.HDInsight.Containers |
| healthbot | Azure.ResourceManager.HealthBot | sdk/healthbot/Azure.ResourceManager.HealthBot |
| healthcareapis | Azure.ResourceManager.HealthcareApis | sdk/healthcareapis/Azure.ResourceManager.HealthcareApis |
| hybridaks | Azure.ResourceManager.HybridContainerService | sdk/hybridaks/Azure.ResourceManager.HybridContainerService |
| hybridcompute | Azure.ResourceManager.HybridCompute | sdk/hybridcompute/Azure.ResourceManager.HybridCompute |
| hybridnetwork | Azure.ResourceManager.HybridNetwork | sdk/hybridnetwork/Azure.ResourceManager.HybridNetwork |
| iot | Azure.ResourceManager.IotFirmwareDefense | sdk/iot/Azure.ResourceManager.IotFirmwareDefense |
| iotcentral | Azure.ResourceManager.IotCentral | sdk/iotcentral/Azure.ResourceManager.IotCentral |
| iothub | Azure.ResourceManager.IotHub | sdk/iothub/Azure.ResourceManager.IotHub |
| keyvault | Azure.ResourceManager.KeyVault | sdk/keyvault/Azure.ResourceManager.KeyVault |
| kubernetesconfiguration | Azure.ResourceManager.KubernetesConfiguration | sdk/kubernetesconfiguration/Azure.ResourceManager.KubernetesConfiguration |
| kusto | Azure.ResourceManager.Kusto | sdk/kusto/Azure.ResourceManager.Kusto |
| labservices | Azure.ResourceManager.LabServices | sdk/labservices/Azure.ResourceManager.LabServices |
| loadtestservice | Azure.ResourceManager.LoadTesting | sdk/loadtestservice/Azure.ResourceManager.LoadTesting |
| logic | Azure.ResourceManager.Logic | sdk/logic/Azure.ResourceManager.Logic |
| machinelearningcompute | Azure.ResourceManager.MachineLearningCompute | sdk/machinelearningcompute/Azure.ResourceManager.MachineLearningCompute |
| machinelearningservices | Azure.ResourceManager.MachineLearning | sdk/machinelearningservices/Azure.ResourceManager.MachineLearning |
| maintenance | Azure.ResourceManager.Maintenance | sdk/maintenance/Azure.ResourceManager.Maintenance |
| managednetwork | Azure.ResourceManager.ManagedNetwork | sdk/managednetwork/Azure.ResourceManager.ManagedNetwork |
| managednetworkfabric | Azure.ResourceManager.ManagedNetworkFabric | sdk/managednetworkfabric/Azure.ResourceManager.ManagedNetworkFabric |
| managedserviceidentity | Azure.ResourceManager.ManagedServiceIdentities | sdk/managedserviceidentity/Azure.ResourceManager.ManagedServiceIdentities |
| managedservices | Azure.ResourceManager.ManagedServices | sdk/managedservices/Azure.ResourceManager.ManagedServices |
| managementpartner | Azure.ResourceManager.ManagementPartner | sdk/managementpartner/Azure.ResourceManager.ManagementPartner |
| maps | Azure.ResourceManager.Maps | sdk/maps/Azure.ResourceManager.Maps |
| marketplace | Azure.ResourceManager.Marketplace | sdk/marketplace/Azure.ResourceManager.Marketplace |
| marketplaceordering | Azure.ResourceManager.MarketplaceOrdering | sdk/marketplaceordering/Azure.ResourceManager.MarketplaceOrdering |
| mediaservices | Azure.ResourceManager.Media | sdk/mediaservices/Azure.ResourceManager.Media |
| migrationassessment | Azure.ResourceManager.Migration.Assessment | sdk/migrationassessment/Azure.ResourceManager.Migration.Assessment |
| migrationdiscoverysap | Azure.ResourceManager.MigrationDiscoverySap | sdk/migrationdiscoverysap/Azure.ResourceManager.MigrationDiscoverySap |
| mixedreality | Azure.ResourceManager.MixedReality | sdk/mixedreality/Azure.ResourceManager.MixedReality |
| mobilenetwork | Azure.ResourceManager.MobileNetwork | sdk/mobilenetwork/Azure.ResourceManager.MobileNetwork |
| monitor | Azure.ResourceManager.Monitor | sdk/monitor/Azure.ResourceManager.Monitor |
| mysql | Azure.ResourceManager.MySql | sdk/mysql/Azure.ResourceManager.MySql |
| netapp | Azure.ResourceManager.NetApp | sdk/netapp/Azure.ResourceManager.NetApp |
| network | Azure.ResourceManager.Network | sdk/network/Azure.ResourceManager.Network |
| networkanalytics | Azure.ResourceManager.NetworkAnalytics | sdk/networkanalytics/Azure.ResourceManager.NetworkAnalytics |
| networkcloud | Azure.ResourceManager.NetworkCloud | sdk/networkcloud/Azure.ResourceManager.NetworkCloud |
| networkfunction | Azure.ResourceManager.NetworkFunction | sdk/networkfunction/Azure.ResourceManager.NetworkFunction |
| newrelicobservability | Azure.ResourceManager.NewRelicObservability | sdk/newrelicobservability/Azure.ResourceManager.NewRelicObservability |
| nginx | Azure.ResourceManager.Nginx | sdk/nginx/Azure.ResourceManager.Nginx |
| notificationhubs | Azure.ResourceManager.NotificationHubs | sdk/notificationhubs/Azure.ResourceManager.NotificationHubs |
| openenergyplatform | Azure.ResourceManager.EnergyServices | sdk/openenergyplatform/Azure.ResourceManager.EnergyServices |
| operationalinsights | Azure.ResourceManager.OperationalInsights | sdk/operationalinsights/Azure.ResourceManager.OperationalInsights |
| orbital | Azure.ResourceManager.Orbital | sdk/orbital/Azure.ResourceManager.Orbital |
| paloaltonetworks.ngfw | Azure.ResourceManager.PaloAltoNetworks.Ngfw | sdk/paloaltonetworks.ngfw/Azure.ResourceManager.PaloAltoNetworks.Ngfw |
| peering | Azure.ResourceManager.Peering | sdk/peering/Azure.ResourceManager.Peering |
| policyinsights | Azure.ResourceManager.PolicyInsights | sdk/policyinsights/Azure.ResourceManager.PolicyInsights |
| postgresql | Azure.ResourceManager.PostgreSql | sdk/postgresql/Azure.ResourceManager.PostgreSql |
| powerbidedicated | Azure.ResourceManager.PowerBIDedicated | sdk/powerbidedicated/Azure.ResourceManager.PowerBIDedicated |
| privatedns | Azure.ResourceManager.PrivateDns | sdk/privatedns/Azure.ResourceManager.PrivateDns |
| providerhub | Azure.ResourceManager.ProviderHub | sdk/providerhub/Azure.ResourceManager.ProviderHub |
| purview | Azure.ResourceManager.Purview | sdk/purview/Azure.ResourceManager.Purview |
| quantum | Azure.ResourceManager.Quantum | sdk/quantum/Azure.ResourceManager.Quantum |
| qumulo | Azure.ResourceManager.Qumulo | sdk/qumulo/Azure.ResourceManager.Qumulo |
| recoveryservices-backup | Azure.ResourceManager.RecoveryServicesBackup | sdk/recoveryservices-backup/Azure.ResourceManager.RecoveryServicesBackup |
| recoveryservices-siterecovery | Azure.ResourceManager.RecoveryServicesSiteRecovery | sdk/recoveryservices-siterecovery/Azure.ResourceManager.RecoveryServicesSiteRecovery |
| redis | Azure.ResourceManager.Redis | sdk/redis/Azure.ResourceManager.Redis |
| redisenterprise | Azure.ResourceManager.RedisEnterprise | sdk/redisenterprise/Azure.ResourceManager.RedisEnterprise |
| relay | Azure.ResourceManager.Relay | sdk/relay/Azure.ResourceManager.Relay |
| reservations | Azure.ResourceManager.Reservations | sdk/reservations/Azure.ResourceManager.Reservations |
| resourceconnector | Azure.ResourceManager.ResourceConnector | sdk/resourceconnector/Azure.ResourceManager.ResourceConnector |
| resourcegraph | Azure.ResourceManager.ResourceGraph | sdk/resourcegraph/Azure.ResourceManager.ResourceGraph |
| resourcehealth | Azure.ResourceManager.ResourceHealth | sdk/resourcehealth/Azure.ResourceManager.ResourceHealth |
| resourcemanager | Azure.ResourceManager | sdk/resourcemanager/Azure.ResourceManager |
| resourcemover | Azure.ResourceManager.ResourceMover | sdk/resourcemover/Azure.ResourceManager.ResourceMover |
| resources | Azure.ResourceManager.Resources | sdk/resources/Azure.ResourceManager.Resources |
| resources | Azure.ResourceManager.Resources.Deployments | sdk/resources/Azure.ResourceManager.Resources.Deployments |
| resources | Azure.ResourceManager.Resources.DeploymentStacks | sdk/resources/Azure.ResourceManager.Resources.DeploymentStacks |
| search | Azure.ResourceManager.Search | sdk/search/Azure.ResourceManager.Search |
| securitycenter | Azure.ResourceManager.SecurityCenter | sdk/securitycenter/Azure.ResourceManager.SecurityCenter |
| securitydevops | Azure.ResourceManager.SecurityDevOps | sdk/securitydevops/Azure.ResourceManager.SecurityDevOps |
| securityinsights | Azure.ResourceManager.SecurityInsights | sdk/securityinsights/Azure.ResourceManager.SecurityInsights |
| servicebus | Azure.ResourceManager.ServiceBus | sdk/servicebus/Azure.ResourceManager.ServiceBus |
| servicefabric | Azure.ResourceManager.ServiceFabric | sdk/servicefabric/Azure.ResourceManager.ServiceFabric |
| servicelinker | Azure.ResourceManager.ServiceLinker | sdk/servicelinker/Azure.ResourceManager.ServiceLinker |
| signalr | Azure.ResourceManager.SignalR | sdk/signalr/Azure.ResourceManager.SignalR |
| sphere | Azure.ResourceManager.Sphere | sdk/sphere/Azure.ResourceManager.Sphere |
| springappdiscovery | Azure.ResourceManager.SpringAppDiscovery | sdk/springappdiscovery/Azure.ResourceManager.SpringAppDiscovery |
| sqlmanagement | Azure.ResourceManager.Sql | sdk/sqlmanagement/Azure.ResourceManager.Sql |
| sqlvirtualmachine | Azure.ResourceManager.SqlVirtualMachine | sdk/sqlvirtualmachine/Azure.ResourceManager.SqlVirtualMachine |
| storage | Azure.ResourceManager.Storage | sdk/storage/Azure.ResourceManager.Storage |
| storagecache | Azure.ResourceManager.StorageCache | sdk/storagecache/Azure.ResourceManager.StorageCache |
| storagepool | Azure.ResourceManager.StoragePool | sdk/storagepool/Azure.ResourceManager.StoragePool |
| storagesync | Azure.ResourceManager.StorageSync | sdk/storagesync/Azure.ResourceManager.StorageSync |
| streamanalytics | Azure.ResourceManager.StreamAnalytics | sdk/streamanalytics/Azure.ResourceManager.StreamAnalytics |
| subscription | Azure.ResourceManager.Subscription | sdk/subscription/Azure.ResourceManager.Subscription |
| support | Azure.ResourceManager.Support | sdk/support/Azure.ResourceManager.Support |
| synapse | Azure.ResourceManager.Synapse | sdk/synapse/Azure.ResourceManager.Synapse |
| trafficmanager | Azure.ResourceManager.TrafficManager | sdk/trafficmanager/Azure.ResourceManager.TrafficManager |
| trustedsigning | Azure.ResourceManager.TrustedSigning | sdk/trustedsigning/Azure.ResourceManager.TrustedSigning |
| voiceservices | Azure.ResourceManager.VoiceServices | sdk/voiceservices/Azure.ResourceManager.VoiceServices |
| webpubsub | Azure.ResourceManager.WebPubSub | sdk/webpubsub/Azure.ResourceManager.WebPubSub |
| websites | Azure.ResourceManager.AppService | sdk/websites/Azure.ResourceManager.AppService |
| workloadmonitor | Azure.ResourceManager.WorkloadMonitor | sdk/workloadmonitor/Azure.ResourceManager.WorkloadMonitor |
| workloads | Azure.ResourceManager.Workloads | sdk/workloads/Azure.ResourceManager.Workloads |


## Libraries with No Generator

Libraries with no generator have neither autorest.md nor tsp-location.yaml files. Total: 38

| Service | Library | Path |
| ------- | ------- | ---- |
| cloudmachine | Azure.Projects | sdk/cloudmachine/Azure.Projects |
| cloudmachine | Azure.Projects.AI | sdk/cloudmachine/Azure.Projects.AI |
| cloudmachine | Azure.Projects.AI.Foundry | sdk/cloudmachine/Azure.Projects.AI.Foundry |
| cloudmachine | Azure.Projects.Provisioning | sdk/cloudmachine/Azure.Projects.Provisioning |
| cloudmachine | Azure.Projects.Tsp | sdk/cloudmachine/Azure.Projects.Tsp |
| cloudmachine | Azure.Projects.Web | sdk/cloudmachine/Azure.Projects.Web |
| communication | Azure.Communication.Common | sdk/communication/Azure.Communication.Common |
| communication | Shared | sdk/communication/Shared |
| core | Azure.Core | sdk/core/Azure.Core |
| core | Azure.Core.Amqp | sdk/core/Azure.Core.Amqp |
| core | Azure.Core.Experimental | sdk/core/Azure.Core.Experimental |
| core | System.ClientModel | sdk/core/System.ClientModel |
| eventhub | Azure.Messaging.EventHubs | sdk/eventhub/Azure.Messaging.EventHubs |
| eventhub | Azure.Messaging.EventHubs.Processor | sdk/eventhub/Azure.Messaging.EventHubs.Processor |
| eventhub | Azure.Messaging.EventHubs.Shared | sdk/eventhub/Azure.Messaging.EventHubs.Shared |
| extensions | Azure.Extensions.AspNetCore.Configuration.Secrets | sdk/extensions/Azure.Extensions.AspNetCore.Configuration.Secrets |
| extensions | Azure.Extensions.AspNetCore.DataProtection.Blobs | sdk/extensions/Azure.Extensions.AspNetCore.DataProtection.Blobs |
| extensions | Azure.Extensions.AspNetCore.DataProtection.Keys | sdk/extensions/Azure.Extensions.AspNetCore.DataProtection.Keys |
| identity | Azure.Identity | sdk/identity/Azure.Identity |
| identity | Azure.Identity.Broker | sdk/identity/Azure.Identity.Broker |
| keyvault | Azure.Security.KeyVault.Certificates | sdk/keyvault/Azure.Security.KeyVault.Certificates |
| keyvault | Azure.Security.KeyVault.Keys | sdk/keyvault/Azure.Security.KeyVault.Keys |
| keyvault | Azure.Security.KeyVault.Secrets | sdk/keyvault/Azure.Security.KeyVault.Secrets |
| keyvault | Azure.Security.KeyVault.Shared | sdk/keyvault/Azure.Security.KeyVault.Shared |
| loadtestservice | Azure.Developer.Playwright.MSTest | sdk/loadtestservice/Azure.Developer.Playwright.MSTest |
| loadtestservice | Azure.Developer.Playwright.NUnit | sdk/loadtestservice/Azure.Developer.Playwright.NUnit |
| modelsrepository | Azure.IoT.ModelsRepository | sdk/modelsrepository/Azure.IoT.ModelsRepository |
| monitor | Azure.Monitor.OpenTelemetry.AspNetCore | sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore |
| provisioning | Azure.Provisioning.Deployment | sdk/provisioning/Azure.Provisioning.Deployment |
| provisioning | Generator | sdk/provisioning/Generator |
| servicebus | Azure.Messaging.ServiceBus | sdk/servicebus/Azure.Messaging.ServiceBus |
| storage | Azure.Storage.Blobs.ChangeFeed | sdk/storage/Azure.Storage.Blobs.ChangeFeed |
| storage | Azure.Storage.DataMovement | sdk/storage/Azure.Storage.DataMovement |
| storage | Azure.Storage.DataMovement.Blobs | sdk/storage/Azure.Storage.DataMovement.Blobs |
| storage | Azure.Storage.DataMovement.Files.Shares | sdk/storage/Azure.Storage.DataMovement.Files.Shares |
| storage | Azure.Storage.Internal.Avro | sdk/storage/Azure.Storage.Internal.Avro |
| synapse | Azure.Analytics.Synapse.Shared | sdk/synapse/Azure.Analytics.Synapse.Shared |
| webpubsub | Azure.Messaging.WebPubSub.Client | sdk/webpubsub/Azure.Messaging.WebPubSub.Client |
