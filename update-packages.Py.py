'#"''
_omitted_paths:
  - archive/*
  - eng/*
  - tools/*
  - src/*
  - Documentation/*
  - sdk/*mgmt*/*
  - sdk/*/*.Management.*/*
  - samples/*
  - common/SmokeTests/*
language: net
root_check_enabled: True
required_readme_sections:
  - "Azure .+ client library for .NET"
  - ^Getting started$
  - ^Key concepts$
  - ^Examples$
  - ^Troubleshooting$
  - ^Next steps$
  - ^Contributing$
known_presence_issues:
  - ['sdk/keyvault','#5499']
  - ['sdk/servicebus','#5499']
  - ['sdk/eventhub','#5499']
  - ['sdk/eventgrid/Microsoft.Azure.EventGrid','#5499']
  - ['sdk/operationalinsights/Microsoft.Azure.OperationalInsights','#5499']
  - ['sdk/hdinsight/Microsoft.Azure.HDInsight.Job','#5499']
  - ['sdk/alertsmanagement/Microsoft.Azure.Management.AlertsManagement','#5499']
  - ['sdk/applicationinsights/Microsoft.Azure.ApplicationInsights.Query','#5499']
  - ['sdk/containerregistry/Microsoft.Azure.ContainerRegistry','#5499']
  - ['sdk/cognitiveservices/Language.LUIS.Runtime','#5499']
  - ['sdk/cognitiveservices/Search.BingEntitySearch','#5499']
  - ['sdk/cognitiveservices/Search.BingWebSearch','#5499']
  - ['sdk/cognitiveservices/Knowledge.QnAMaker','#5499']
  - ['sdk/cognitiveservices/AnomalyDetector','#5499']
  - ['sdk/cognitiveservices/Search.BingVisualSearch','#5499']
  - ['sdk/cognitiveservices/Search.BingCustomSearch','#5499']
  - ['sdk/cognitiveservices/Search.BingImageSearch','#5499']
  - ['sdk/cognitiveservices/Vision.FormRecognizer','#5499']
  - ['sdk/cognitiveservices/Search.BingVideoSearch','#5499']
  - ['sdk/cognitiveservices/Search.BingNewsSearch','#5499']
  - ['sdk/cognitiveservices/Personalizer','#5499']
  - ['sdk/cognitiveservices/Vision.ComputerVision','#5499']
  - ['sdk/cognitiveservices/Vision.CustomVision.Training','#5499']
  - ['sdk/cognitiveservices/Vision.Face','#5499']
  - ['sdk/cognitiveservices/Search.BingAutoSuggest','#5499']
  - ['sdk/cognitiveservices/Language.LUIS.Authoring','#5499']
  - ['sdk/cognitiveservices/Vision.ContentModerator','#5499']
  - ['sdk/cognitiveservices/Vision.CustomVision.Prediction','#5499']
  - ['sdk/cognitiveservices/Language.SpellCheck','#5499']
  - ['sdk/cognitiveservices/Language.TextAnalytics','#5499']
  - ['sdk/cognitiveservices/Search.BingLocalSearch','#5499']
  - ['sdk/cognitiveservices/Search.BingCustomImageSearch','#5499']
  - ['sdk/cognitiveservices/FormRecognizer','#5499']
  - ['sdk/batch/Microsoft.Azure.Batch.FileStaging','#5499']
  - ['sdk/graphrbac/Microsoft.Azure.Graph.RBAC','#5499']
  - ['sdk/search','#5499']
  - ['sdk/cognitiveservices/InkRecognizer','#5499']
known_content_issues:
  - ['README.md','Root readme']
  - ['doc/README.md','Doc readme']
  - ['sdk/core/Microsoft.Extensions.Azure/README.md','#5499']
  - ['sdk/keyvault/Microsoft.Azure.KeyVault/README.md','#5499']
  - ['sdk/servicebus/Microsoft.Azure.ServiceBus/README.md','#5499']
  - ['sdk/eventhub/Microsoft.Azure.EventHubs/README.md','#5499']
  - ['sdk/alertsmanagement/Microsoft.Azure.Management.AlertsManagement/README.md','#5499']
  - ['sdk/appconfiguration/Azure.Data.AppConfiguration/tests/Readme.md','#5499']
  - ['sdk/appconfiguration/Azure.Data.AppConfiguration/samples/README.md','#5499']
  - ['sdk/core/Azure.Core/README.md','#5499']
  - ['sdk/storage/README.md','azure-sdk-tools/issues/42']
  - ['sdk/storage/Azure.Storage.Blobs/swagger/readme.md','azure-sdk-tools/issues/42']
  - ['sdk/storage/Azure.Storage.Files.Shares/swagger/readme.md','azure-sdk-tools/issues/42']
  - ['sdk/storage/Azure.Storage.Files.DataLake/swagger/readme.md','azure-sdk-tools/issues/42']
  - ['sdk/storage/Azure.Storage.Queues/swagger/readme.md','azure-sdk-tools/issues/42']
  - ['sdk/storage/Azure.Storage.Common/swagger/Generator/readme.md','azure-sdk-tools/issues/42']
  - ['sdk/cognitiveservices/Language.TextAnalytics/src/Readme.md','#5499']
  - ['sdk/cognitiveservices/Personalizer/src/Readme.md','#5499']
  - ['sdk/cognitiveservices/textanalytics/Azure.AI.TextAnalytics/README.md','#5499']
  - ['sdk/batch/Microsoft.Azure.Batch/README.md','#5499']
  - ['sdk/batch/Microsoft.Azure.Batch.Conventions.Files/README.md','#5499']
# .net climbs upwards. placing these to prevent assigning readmes to the wrong project
package_indexing_exclusion_list:
  - 'AutoRest-AzureDotNetSDK'
  - 'NetCoreTestPublish'
  - 'ObjectModelCodeGenerator'
  - 'ProxyLayerParser'
  - 'IntegrationTestCommon'
  - 'Azure.Template'
  - 'SampleSDKTestPublish'
  - 'CSProjTestPublish'
  - 'ConfigureAwaitAnalyzer'
  - 'Microsoft.WindowsAzure.Build.Tasks'
  - 'Microsoft.Azure.Services.AppAuthentication.TestCommon'
  - 'RP2_Sdk'
  - 'RP1_MgmtPlane'
  - 'RP1_DataPlane'
  - 'Gallery'
  - 'Intune'
  - 'Common'
  - 'SnippetGenerator'
  - 'docgen'
package_indexing_traversal_stops:
  - 'sdk/'
  - 'src/SDKs/'
  - 'src/SdkCommon/'
  - 'src/AzureStack/'
  6  packages.md 
# Package Index - azure-sdk-for-net

| Package Id     | Readme    | Changelog                 | Published Url       |
|----------------|-----------|---------------------------|---------------------|
| [`Azure.AI.InkRecognizer`]( sdk/cognitiveservices/InkRecognizer/src/Azure.AI.InkRecognizer.csproj )|  N/A  |  N/A  | [![Azure.AI.InkRecognizer](https://img.shields.io/nuget/vpre/Azure.AI.InkRecognizer.svg)]( https://www.nuget.org/packages/Azure.AI.InkRecognizer/ ) |
| [`Azure.AI.InkRecognizer.UWP.Stroke`]( sdk/cognitiveservices/InkRecognizer.UWP.Stroke/src/Azure.AI.InkRecognizer.UWP.Stroke.csproj )|  N/A  |  N/A  | [![Azure.AI.InkRecognizer.UWP.Stroke](https://img.shields.io/nuget/vpre/Azure.AI.InkRecognizer.UWP.Stroke.svg)]( https://www.nuget.org/packages/Azure.AI.InkRecognizer.UWP.Stroke/ ) |
| [`Azure.AI.InkRecognizer.WPF.Stroke`]( sdk/cognitiveservices/InkRecognizer.WPF.Stroke/src/Azure.AI.InkRecognizer.WPF.Stroke.csproj )|  N/A  |  N/A  | [![Azure.AI.InkRecognizer.WPF.Stroke](https://img.shields.io/nuget/vpre/Azure.AI.InkRecognizer.WPF.Stroke.svg)]( https://www.nuget.org/packages/Azure.AI.InkRecognizer.WPF.Stroke/ ) |
| [`Azure.AI.TextAnalytics`]( sdk/cognitiveservices/textanalytics/Azure.AI.TextAnalytics/src/Azure.AI.TextAnalytics.csproj )| [Readme](sdk/cognitiveservices/textanalytics/Azure.AI.TextAnalytics/README.md) |  N/A  |  N/A  |
| [`Azure.Core`]( sdk/core/Azure.Core/src/Azure.Core.csproj )| [Readme](sdk/core/Azure.Core/README.md) | [Changelog](sdk/core/Azure.Core/CHANGELOG.md) | [![Azure.Core](https://img.shields.io/nuget/vpre/Azure.Core.svg)]( https://www.nuget.org/packages/Azure.Core/ ) |
| [`Azure.Data.AppConfiguration`]( sdk/appconfiguration/Azure.Data.AppConfiguration/src/Azure.Data.AppConfiguration.csproj )| [Readme](sdk/appconfiguration/Azure.Data.AppConfiguration/README.md) | [Changelog](sdk/appconfiguration/Azure.Data.AppConfiguration/CHANGELOG.md) | [![Azure.Data.AppConfiguration](https://img.shields.io/nuget/vpre/Azure.Data.AppConfiguration.svg)]( https://www.nuget.org/packages/Azure.Data.AppConfiguration/ ) |
| [`Azure.Identity`]( sdk/identity/Azure.Identity/src/Azure.Identity.csproj )| [Readme](sdk/identity/Azure.Identity/README.md) | [Changelog](sdk/identity/Azure.Identity/CHANGELOG.md) | [![Azure.Identity](https://img.shields.io/nuget/vpre/Azure.Identity.svg)]( https://www.nuget.org/packages/Azure.Identity/ ) |
| [`Azure.Messaging.EventHubs`]( sdk/eventhub/Azure.Messaging.EventHubs/src/Azure.Messaging.EventHubs.csproj )| [Readme](sdk/eventhub/Azure.Messaging.EventHubs/README.md) | [Changelog](sdk/eventhub/Azure.Messaging.EventHubs/CHANGELOG.md) | [![Azure.Messaging.EventHubs](https://img.shields.io/nuget/vpre/Azure.Messaging.EventHubs.svg)]( https://www.nuget.org/packages/Azure.Messaging.EventHubs/ ) |
| [`Azure.Messaging.EventHubs.CheckpointStore.Blobs`]( sdk/eventhub/Azure.Messaging.EventHubs.CheckpointStore.Blobs/src/Azure.Messaging.EventHubs.CheckpointStore.Blobs.csproj )| [Readme](sdk/eventhub/Azure.Messaging.EventHubs.CheckpointStore.Blobs/README.md) | [Changelog](sdk/eventhub/Azure.Messaging.EventHubs.CheckpointStore.Blobs/CHANGELOG.md) | [![Azure.Messaging.EventHubs.CheckpointStore.Blobs](https://img.shields.io/nuget/vpre/Azure.Messaging.EventHubs.CheckpointStore.Blobs.svg)]( https://www.nuget.org/packages/Azure.Messaging.EventHubs.CheckpointStore.Blobs/ ) |
| [`Azure.Security.KeyVault.Certificates`]( sdk/keyvault/Azure.Security.KeyVault.Certificates/src/Azure.Security.KeyVault.Certificates.csproj )| [Readme](sdk/keyvault/Azure.Security.KeyVault.Certificates/README.md) | [Changelog](sdk/keyvault/Azure.Security.KeyVault.Certificates/ChangeLog.md) | [![Azure.Security.KeyVault.Certificates](https://img.shields.io/nuget/vpre/Azure.Security.KeyVault.Certificates.svg)]( https://www.nuget.org/packages/Azure.Security.KeyVault.Certificates/ ) |
| [`Azure.Security.KeyVault.Keys`]( sdk/keyvault/Azure.Security.KeyVault.Keys/src/Azure.Security.KeyVault.Keys.csproj )| [Readme](sdk/keyvault/Azure.Security.KeyVault.Keys/README.md) | [Changelog](sdk/keyvault/Azure.Security.KeyVault.Keys/ChangeLog.md) | [![Azure.Security.KeyVault.Keys](https://img.shields.io/nuget/vpre/Azure.Security.KeyVault.Keys.svg)]( https://www.nuget.org/packages/Azure.Security.KeyVault.Keys/ ) |
| [`Azure.Security.KeyVault.Secrets`]( sdk/keyvault/Azure.Security.KeyVault.Secrets/src/Azure.Security.KeyVault.Secrets.csproj )| [Readme](sdk/keyvault/Azure.Security.KeyVault.Secrets/README.md) | [Changelog](sdk/keyvault/Azure.Security.KeyVault.Secrets/ChangeLog.md) | [![Azure.Security.KeyVault.Secrets](https://img.shields.io/nuget/vpre/Azure.Security.KeyVault.Secrets.svg)]( https://www.nuget.org/packages/Azure.Security.KeyVault.Secrets/ ) |
| [`Azure.Storage.Blobs`]( sdk/storage/Azure.Storage.Blobs/src/Azure.Storage.Blobs.csproj )| [Readme](sdk/storage/Azure.Storage.Blobs/README.md) |  N/A  | [![Azure.Storage.Blobs](https://img.shields.io/nuget/vpre/Azure.Storage.Blobs.svg)]( https://www.nuget.org/packages/Azure.Storage.Blobs/ ) |
| [`Azure.Storage.Blobs.Batch`]( sdk/storage/Azure.Storage.Blobs.Batch/src/Azure.Storage.Blobs.Batch.csproj )| [Readme](sdk/storage/Azure.Storage.Blobs.Batch/README.md) | [Changelog](sdk/storage/Azure.Storage.Blobs.Batch/CHANGELOG.md) | [![Azure.Storage.Blobs.Batch](https://img.shields.io/nuget/vpre/Azure.Storage.Blobs.Batch.svg)]( https://www.nuget.org/packages/Azure.Storage.Blobs.Batch/ ) |
| [`Azure.Storage.Blobs.Cryptography`]( sdk/storage/Azure.Storage.Blobs.Cryptography/src/Azure.Storage.Blobs.Cryptography.csproj )| [Readme](sdk/storage/Azure.Storage.Blobs.Cryptography/README.md) |  N/A  |  N/A  |
| [`Azure.Storage.Common`]( sdk/storage/Azure.Storage.Common/src/Azure.Storage.Common.csproj )| [Readme](sdk/storage/Azure.Storage.Common/README.md) |  N/A  | [![Azure.Storage.Common](https://img.shields.io/nuget/vpre/Azure.Storage.Common.svg)]( https://www.nuget.org/packages/Azure.Storage.Common/ ) |
| [`Azure.Storage.Files.DataLake`]( sdk/storage/Azure.Storage.Files.DataLake/src/Azure.Storage.Files.DataLake.csproj )| [Readme](sdk/storage/Azure.Storage.Files.DataLake/README.md) |  N/A  | [![Azure.Storage.Files.DataLake](https://img.shields.io/nuget/vpre/Azure.Storage.Files.DataLake.svg)]( https://www.nuget.org/packages/Azure.Storage.Files.DataLake/ ) |
| [`Azure.Storage.Files.Shares`]( sdk/storage/Azure.Storage.Files.Shares/src/Azure.Storage.Files.Shares.csproj )| [Readme](sdk/storage/Azure.Storage.Files.Shares/README.md) |  N/A  | [![Azure.Storage.Files.Shares](https://img.shields.io/nuget/vpre/Azure.Storage.Files.Shares.svg)]( https://www.nuget.org/packages/Azure.Storage.Files.Shares/ ) |
| [`Azure.Storage.Queues`]( sdk/storage/Azure.Storage.Queues/src/Azure.Storage.Queues.csproj )| [Readme](sdk/storage/Azure.Storage.Queues/README.md) |  N/A  | [![Azure.Storage.Queues](https://img.shields.io/nuget/vpre/Azure.Storage.Queues.svg)]( https://www.nuget.org/packages/Azure.Storage.Queues/ ) |
| [`Azure.Storage.Queues.Cryptography`]( sdk/storage/Azure.Storage.Queues.Cryptography/src/Azure.Storage.Queues.Cryptography.csproj )| [Readme](sdk/storage/Azure.Storage.Queues.Cryptography/README.md) |  N/A  |  N/A  |
| [`AzureDotNetSDK-TestProject`]( tools/ProjectTemplates/AzureDotNetSDK-TestProject/AzureDotNetSDK-TestProject.csproj )|  N/A  |  N/A  |  N/A  |
| [`CodeGenerationLibrary`]( sdk/batch/Microsoft.Azure.Batch/Tools/CodeGenerationLibrary/CodeGenerationLibrary.csproj )| [Readme](sdk/batch/Microsoft.Azure.Batch/README.md) | [Changelog](sdk/batch/Microsoft.Azure.Batch/changelog.md) |  N/A  |
| [`Microsoft.Azure.ApplicationInsights.Query`]( sdk/applicationinsights/Microsoft.Azure.ApplicationInsights.Query/src/Microsoft.Azure.ApplicationInsights.Query.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.ApplicationInsights.Query](https://img.shields.io/nuget/vpre/Microsoft.Azure.ApplicationInsights.Query.svg)]( https://www.nuget.org/packages/Microsoft.Azure.ApplicationInsights.Query/ ) |
| [`Microsoft.Azure.Batch`]( sdk/batch/Microsoft.Azure.Batch/src/Microsoft.Azure.Batch.csproj )| [Readme](sdk/batch/Microsoft.Azure.Batch/README.md) | [Changelog](sdk/batch/Microsoft.Azure.Batch/changelog.md) | [![Microsoft.Azure.Batch](https://img.shields.io/nuget/vpre/Microsoft.Azure.Batch.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Batch/ ) |
| [`Microsoft.Azure.Batch.Conventions.Files`]( sdk/batch/Microsoft.Azure.Batch.Conventions.Files/src/Microsoft.Azure.Batch.Conventions.Files.csproj )| [Readme](sdk/batch/Microsoft.Azure.Batch.Conventions.Files/README.md) |  N/A  | [![Microsoft.Azure.Batch.Conventions.Files](https://img.shields.io/nuget/vpre/Microsoft.Azure.Batch.Conventions.Files.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Batch.Conventions.Files/ ) |
| [`Microsoft.Azure.Batch.FileStaging`]( sdk/batch/Microsoft.Azure.Batch.FileStaging/src/Microsoft.Azure.Batch.FileStaging.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Batch.FileStaging](https://img.shields.io/nuget/vpre/Microsoft.Azure.Batch.FileStaging.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Batch.FileStaging/ ) |
| [`Microsoft.Azure.CognitiveServices.AnomalyDetector`]( sdk/cognitiveservices/AnomalyDetector/src/Microsoft.Azure.CognitiveServices.AnomalyDetector.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.CognitiveServices.AnomalyDetector](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.AnomalyDetector.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.AnomalyDetector/ ) |
| [`Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker`]( sdk/cognitiveservices/Knowledge.QnAMaker/src/Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker/ ) |
| [`Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring`]( sdk/cognitiveservices/Language.LUIS.Authoring/src/Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Language.LUIS.Authoring/ ) |
| [`Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime`]( sdk/cognitiveservices/Language.LUIS.Runtime/src/Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Language.LUIS.Runtime/ ) |
| [`Microsoft.Azure.CognitiveServices.Language.SpellCheck`]( sdk/cognitiveservices/Language.SpellCheck/src/Microsoft.Azure.CognitiveServices.Language.SpellCheck.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.CognitiveServices.Language.SpellCheck](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.Language.SpellCheck.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Language.SpellCheck/ ) |
| [`Microsoft.Azure.CognitiveServices.Language.TextAnalytics`]( sdk/cognitiveservices/Language.TextAnalytics/src/Microsoft.Azure.CognitiveServices.Language.TextAnalytics.csproj )| [Readme](sdk/cognitiveservices/Language.TextAnalytics/src/Readme.md) |  N/A  | [![Microsoft.Azure.CognitiveServices.Language.TextAnalytics](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.Language.TextAnalytics.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Language.TextAnalytics/ ) |
| [`Microsoft.Azure.CognitiveServices.Personalizer`]( sdk/cognitiveservices/Personalizer/src/Microsoft.Azure.CognitiveServices.Personalizer.csproj )| [Readme](sdk/cognitiveservices/Personalizer/src/Readme.md) |  N/A  | [![Microsoft.Azure.CognitiveServices.Personalizer](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.Personalizer.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Personalizer/ ) |
| [`Microsoft.Azure.CognitiveServices.Search.BingAutoSuggest`]( sdk/cognitiveservices/Search.BingAutoSuggest/src/Microsoft.Azure.CognitiveServices.Search.BingAutoSuggest.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Search.BingCustomImageSearch`]( sdk/cognitiveservices/Search.BingCustomImageSearch/src/Microsoft.Azure.CognitiveServices.Search.BingCustomImageSearch.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Search.BingCustomSearch`]( sdk/cognitiveservices/Search.BingCustomSearch/src/Microsoft.Azure.CognitiveServices.Search.BingCustomSearch.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Search.BingEntitySearch`]( sdk/cognitiveservices/Search.BingEntitySearch/src/Microsoft.Azure.CognitiveServices.Search.BingEntitySearch.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Search.BingImageSearch`]( sdk/cognitiveservices/Search.BingImageSearch/src/Microsoft.Azure.CognitiveServices.Search.BingImageSearch.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Search.BingLocalSearch`]( sdk/cognitiveservices/Search.BingLocalSearch/src/Microsoft.Azure.CognitiveServices.Search.BingLocalSearch.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Search.BingNewsSearch`]( sdk/cognitiveservices/Search.BingNewsSearch/src/Microsoft.Azure.CognitiveServices.Search.BingNewsSearch.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Search.BingVideoSearch`]( sdk/cognitiveservices/Search.BingVideoSearch/src/Microsoft.Azure.CognitiveServices.Search.BingVideoSearch.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Search.BingVisualSearch`]( sdk/cognitiveservices/Search.BingVisualSearch/src/Microsoft.Azure.CognitiveServices.Search.BingVisualSearch.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Search.BingWebSearch`]( sdk/cognitiveservices/Search.BingWebSearch/src/Microsoft.Azure.CognitiveServices.Search.BingWebSearch.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Vision.ComputerVision`]( sdk/cognitiveservices/Vision.ComputerVision/src/Microsoft.Azure.CognitiveServices.Vision.ComputerVision.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.CognitiveServices.Vision.ComputerVision](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.Vision.ComputerVision.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Vision.ComputerVision/ ) |
| [`Microsoft.Azure.CognitiveServices.Vision.ContentModerator`]( sdk/cognitiveservices/Vision.ContentModerator/src/Microsoft.Azure.CognitiveServices.Vision.ContentModerator.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction`]( sdk/cognitiveservices/Vision.CustomVision.Prediction/src/Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Vision.CustomVision.Prediction/ ) |
| [`Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training`]( sdk/cognitiveservices/Vision.CustomVision.Training/src/Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Vision.CustomVision.Training/ ) |
| [`Microsoft.Azure.CognitiveServices.Vision.Face`]( sdk/cognitiveservices/Vision.Face/src/Microsoft.Azure.CognitiveServices.Vision.Face.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.CognitiveServices.Vision.Face](https://img.shields.io/nuget/vpre/Microsoft.Azure.CognitiveServices.Vision.Face.svg)]( https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Vision.Face/ ) |
| [`Microsoft.Azure.CognitiveServices.Vision.FormRecognizer`]( sdk/cognitiveservices/FormRecognizer/src/Microsoft.Azure.CognitiveServices.Vision.FormRecognizer.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.ContainerRegistry`]( sdk/containerregistry/Microsoft.Azure.ContainerRegistry/src/Microsoft.Azure.ContainerRegistry.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.ContainerRegistry](https://img.shields.io/nuget/vpre/Microsoft.Azure.ContainerRegistry.svg)]( https://www.nuget.org/packages/Microsoft.Azure.ContainerRegistry/ ) |
| [`Microsoft.Azure.EventGrid`]( sdk/eventgrid/Microsoft.Azure.EventGrid/src/Microsoft.Azure.EventGrid.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.EventGrid](https://img.shields.io/nuget/vpre/Microsoft.Azure.EventGrid.svg)]( https://www.nuget.org/packages/Microsoft.Azure.EventGrid/ ) |
| [`Microsoft.Azure.EventHubs`]( sdk/eventhub/Microsoft.Azure.EventHubs/src/Microsoft.Azure.EventHubs.csproj )| [Readme](sdk/eventhub/Microsoft.Azure.EventHubs/README.md) |  N/A  | [![Microsoft.Azure.EventHubs](https://img.shields.io/nuget/vpre/Microsoft.Azure.EventHubs.svg)]( https://www.nuget.org/packages/Microsoft.Azure.EventHubs/ ) |
| [`Microsoft.Azure.EventHubs.Processor`]( sdk/eventhub/Microsoft.Azure.EventHubs.Processor/src/Microsoft.Azure.EventHubs.Processor.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.EventHubs.Processor](https://img.shields.io/nuget/vpre/Microsoft.Azure.EventHubs.Processor.svg)]( https://www.nuget.org/packages/Microsoft.Azure.EventHubs.Processor/ ) |
| [`Microsoft.Azure.EventHubs.ServiceFabricProcessor`]( sdk/eventhub/Microsoft.Azure.EventHubs.ServiceFabricProcessor/src/Microsoft.Azure.EventHubs.ServiceFabricProcessor.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.EventHubs.ServiceFabricProcessor](https://img.shields.io/nuget/vpre/Microsoft.Azure.EventHubs.ServiceFabricProcessor.svg)]( https://www.nuget.org/packages/Microsoft.Azure.EventHubs.ServiceFabricProcessor/ ) |
| [`Microsoft.Azure.Graph.RBAC`]( sdk/graphrbac/Microsoft.Azure.Graph.RBAC/src/Microsoft.Azure.Graph.RBAC.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Graph.RBAC](https://img.shields.io/nuget/vpre/Microsoft.Azure.Graph.RBAC.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Graph.RBAC/ ) |
| [`Microsoft.Azure.HDInsight.Job`]( sdk/hdinsight/Microsoft.Azure.HDInsight.Job/src/Microsoft.Azure.HDInsight.Job.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.KeyVault`]( sdk/keyvault/Microsoft.Azure.KeyVault/src/Microsoft.Azure.KeyVault.csproj )| [Readme](sdk/keyvault/Microsoft.Azure.KeyVault/README.md) |  N/A  | [![Microsoft.Azure.KeyVault](https://img.shields.io/nuget/vpre/Microsoft.Azure.KeyVault.svg)]( https://www.nuget.org/packages/Microsoft.Azure.KeyVault/ ) |
| [`Microsoft.Azure.KeyVault.Core`]( sdk/keyvault/Microsoft.Azure.KeyVault.Core/src/Microsoft.Azure.KeyVault.Core.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.KeyVault.Core](https://img.shields.io/nuget/vpre/Microsoft.Azure.KeyVault.Core.svg)]( https://www.nuget.org/packages/Microsoft.Azure.KeyVault.Core/ ) |
| [`Microsoft.Azure.KeyVault.Cryptography`]( sdk/keyvault/Microsoft.Azure.KeyVault.Cryptography/src/Microsoft.Azure.KeyVault.Cryptography.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.KeyVault.Cryptography](https://img.shields.io/nuget/vpre/Microsoft.Azure.KeyVault.Cryptography.svg)]( https://www.nuget.org/packages/Microsoft.Azure.KeyVault.Cryptography/ ) |
| [`Microsoft.Azure.KeyVault.Extensions`]( sdk/keyvault/Microsoft.Azure.KeyVault.Extensions/src/Microsoft.Azure.KeyVault.Extensions.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.KeyVault.Extensions](https://img.shields.io/nuget/vpre/Microsoft.Azure.KeyVault.Extensions.svg)]( https://www.nuget.org/packages/Microsoft.Azure.KeyVault.Extensions/ ) |
| [`Microsoft.Azure.KeyVault.WebKey`]( sdk/keyvault/Microsoft.Azure.KeyVault.WebKey/src/Microsoft.Azure.KeyVault.WebKey.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.KeyVault.WebKey](https://img.shields.io/nuget/vpre/Microsoft.Azure.KeyVault.WebKey.svg)]( https://www.nuget.org/packages/Microsoft.Azure.KeyVault.WebKey/ ) |
| [`Microsoft.Azure.Management.Advisor`]( sdk/advisor/Microsoft.Azure.Management.Advisor/src/Microsoft.Azure.Management.Advisor.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Advisor](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Advisor.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Advisor/ ) |
| [`Microsoft.Azure.Management.AlertsManagement`]( sdk/alertsmanagement/Microsoft.Azure.Management.AlertsManagement/src/Microsoft.Azure.Management.AlertsManagement.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.AlertsManagement](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.AlertsManagement.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.AlertsManagement/ ) |
| [`Microsoft.Azure.Management.Analysis`]( sdk/analysisservices/Microsoft.Azure.Management.AnalysisServices/src/Microsoft.Azure.Management.Analysis.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Analysis](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Analysis.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Analysis/ ) |
| [`Microsoft.Azure.Management.ApiManagement`]( sdk/apimanagement/Microsoft.Azure.Management.ApiManagement/src/Microsoft.Azure.Management.ApiManagement.csproj )|  N/A  | [Changelog](sdk/apimanagement/Microsoft.Azure.Management.ApiManagement/changelog.md) | [![Microsoft.Azure.Management.ApiManagement](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ApiManagement.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ApiManagement/ ) |
| [`Microsoft.Azure.Management.AppPlatform`]( sdk/appplatform/Microsoft.Azure.Management.AppPlatform/src/Microsoft.Azure.Management.AppPlatform.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.AppPlatform](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.AppPlatform.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.AppPlatform/ ) |
| [`Microsoft.Azure.Management.ApplicationInsights`]( sdk/applicationinsights/Microsoft.Azure.Management.ApplicationInsights/src/Microsoft.Azure.Management.ApplicationInsights.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ApplicationInsights](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ApplicationInsights.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ApplicationInsights/ ) |
| [`Microsoft.Azure.Management.Attestation`]( sdk/attestation/Microsoft.Azure.Management.Attestation/src/Microsoft.Azure.Management.Attestation.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Attestation](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Attestation.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Attestation/ ) |
| [`Microsoft.Azure.Management.Authorization`]( sdk/authorization/Microsoft.Azure.Management.Authorization/src/Microsoft.Azure.Management.Authorization.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Authorization](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Authorization.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Authorization/ ) |
| [`Microsoft.Azure.Management.Automation`]( sdk/automation/Microsoft.Azure.Management.Automation/src/Microsoft.Azure.Management.Automation.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Automation](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Automation.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Automation/ ) |
| [`Microsoft.Azure.Management.Batch`]( sdk/batch/Microsoft.Azure.Management.Batch/src/Microsoft.Azure.Management.Batch.csproj )|  N/A  | [Changelog](sdk/batch/Microsoft.Azure.Management.Batch/changelog.md) | [![Microsoft.Azure.Management.Batch](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Batch.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Batch/ ) |
| [`Microsoft.Azure.Management.BatchAI`]( sdk/batchai/Microsoft.Azure.Management.BatchAI/src/Microsoft.Azure.Management.BatchAI.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.BatchAI](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.BatchAI.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.BatchAI/ ) |
| [`Microsoft.Azure.Management.Billing`]( sdk/billing/Microsoft.Azure.Management.Billing/src/Microsoft.Azure.Management.Billing.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Billing](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Billing.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Billing/ ) |
| [`Microsoft.Azure.Management.Blueprint`]( sdk/blueprint/Microsoft.Azure.Management.Blueprint/src/Microsoft.Azure.Management.Blueprint.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Blueprint](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Blueprint.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Blueprint/ ) |
| [`Microsoft.Azure.Management.BotService`]( sdk/botservice/Microsoft.Azure.Management.BotService/src/Microsoft.Azure.Management.BotService.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.BotService](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.BotService.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.BotService/ ) |
| [`Microsoft.Azure.Management.Cdn`]( sdk/cdn/Microsoft.Azure.Management.Cdn/src/Microsoft.Azure.Management.Cdn.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Cdn](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Cdn.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Cdn/ ) |
| [`Microsoft.Azure.Management.CognitiveServices`]( sdk/cognitiveservices/Microsoft.Azure.Management.CognitiveServices/src/Microsoft.Azure.Management.CognitiveServices.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.CognitiveServices](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.CognitiveServices.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.CognitiveServices/ ) |
| [`Microsoft.Azure.Management.Compute`]( sdk/compute/Microsoft.Azure.Management.Compute/src/Microsoft.Azure.Management.Compute.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Compute](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Compute.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Compute/ ) |
| [`Microsoft.Azure.Management.Consumption`]( sdk/consumption/Microsoft.Azure.Management.Consumption/src/Microsoft.Azure.Management.Consumption.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Consumption](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Consumption.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Consumption/ ) |
| [`Microsoft.Azure.Management.ContainerInstance`]( sdk/containerinstance/Microsoft.Azure.Management.ContainerInstance/src/Microsoft.Azure.Management.ContainerInstance.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ContainerInstance](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ContainerInstance.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ContainerInstance/ ) |
| [`Microsoft.Azure.Management.ContainerRegistry`]( sdk/containerregistry/Microsoft.Azure.Management.ContainerRegistry/src/Microsoft.Azure.Management.ContainerRegistry.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ContainerRegistry](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ContainerRegistry.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ContainerRegistry/ ) |
| [`Microsoft.Azure.Management.ContainerService`]( sdk/containerservice/Microsoft.Azure.Management.ContainerService/src/Microsoft.Azure.Management.ContainerService.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.Management.CostManagement`]( sdk/cost-management/Microsoft.Azure.Management.CostManagement/src/Microsoft.Azure.Management.CostManagement.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.Management.CustomProviders`]( sdk/customproviders/Microsoft.Azure.Management.CustomProviders/src/Microsoft.Azure.Management.CustomProviders.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.Management.CustomerInsights`]( sdk/customer-insights/Microsoft.Azure.Management.CustomerInsights/src/Microsoft.Azure.Management.CustomerInsights.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.CustomerInsights](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.CustomerInsights.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.CustomerInsights/ ) |
| [`Microsoft.Azure.Management.DataBox`]( sdk/databox/Microsoft.Azure.Management.DataBox/src/Microsoft.Azure.Management.DataBox.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.DataBox](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.DataBox.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.DataBox/ ) |
| [`Microsoft.Azure.Management.DataBoxEdge`]( sdk/databoxedge/Microsoft.Azure.Management.DataBoxEdge/src/Microsoft.Azure.Management.DataBoxEdge.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.Management.DataFactory`]( sdk/datafactory/Microsoft.Azure.Management.DataFactory/src/Microsoft.Azure.Management.DataFactory.csproj )|  N/A  | [Changelog](sdk/datafactory/Microsoft.Azure.Management.DataFactory/src/changelog.md) | [![Microsoft.Azure.Management.DataFactory](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.DataFactory.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.DataFactory/ ) |
| [`Microsoft.Azure.Management.DataLake.Analytics`]( sdk/datalake-analytics/Microsoft.Azure.Management.DataLake.Analytics/src/Microsoft.Azure.Management.DataLake.Analytics.csproj )|  N/A  | [Changelog](sdk/datalake-analytics/Microsoft.Azure.Management.DataLake.Analytics/changelog.md) | [![Microsoft.Azure.Management.DataLake.Analytics](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.DataLake.Analytics.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.DataLake.Analytics/ ) |
| [`Microsoft.Azure.Management.DataLake.Store`]( sdk/datalake-store/Microsoft.Azure.Management.DataLake.Store/src/Microsoft.Azure.Management.DataLake.Store.csproj )|  N/A  | [Changelog](sdk/datalake-store/Microsoft.Azure.Management.DataLake.Store/changelog.md) | [![Microsoft.Azure.Management.DataLake.Store](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.DataLake.Store.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.DataLake.Store/ ) |
| [`Microsoft.Azure.Management.DataMigration`]( sdk/datamigration/Microsoft.Azure.Management.DataMigration/src/Microsoft.Azure.Management.DataMigration.csproj )| [Readme](sdk/datamigration/Microsoft.Azure.Management.DataMigration/src/README.md) |  N/A  | [![Microsoft.Azure.Management.DataMigration](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.DataMigration.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.DataMigration/ ) |
| [`Microsoft.Azure.Management.DataShare`]( sdk/datashare/Microsoft.Azure.Management.DataShare/src/Microsoft.Azure.Management.DataShare.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.DataShare](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.DataShare.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.DataShare/ ) |
| [`Microsoft.Azure.Management.DeploymentManager`]( sdk/deploymentmanager/Microsoft.Azure.Management.DeploymentManager/src/Microsoft.Azure.Management.DeploymentManager.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.DeploymentManager](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.DeploymentManager.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.DeploymentManager/ ) |
| [`Microsoft.Azure.Management.DevSpaces`]( sdk/devspaces/Microsoft.Azure.Management.DevSpaces/src/Microsoft.Azure.Management.DevSpaces.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.DevSpaces](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.DevSpaces.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.DevSpaces/ ) |
| [`Microsoft.Azure.Management.DevTestLabs`]( sdk/devtestlabs/Microsoft.Azure.Management.DevTestLabs/src/Microsoft.Azure.Management.DevTestLabs.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.DevTestLabs](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.DevTestLabs.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.DevTestLabs/ ) |
| [`Microsoft.Azure.Management.DeviceProvisioningServices`]( sdk/deviceprovisioningservices/Microsoft.Azure.Management.DeviceProvisioningServices/src/Microsoft.Azure.Management.DeviceProvisioningServices.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.DeviceProvisioningServices](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.DeviceProvisioningServices.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.DeviceProvisioningServices/ ) |
| [`Microsoft.Azure.Management.Dns`]( sdk/dns/Microsoft.Azure.Management.Dns/src/Microsoft.Azure.Management.Dns.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Dns](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Dns.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Dns/ ) |
| [`Microsoft.Azure.Management.EdgeGateway`]( sdk/edgegateway/Microsoft.Azure.Management.EdgeGateway/src/Microsoft.Azure.Management.EdgeGateway.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.EdgeGateway](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.EdgeGateway.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.EdgeGateway/ ) |
| [`Microsoft.Azure.Management.EventGrid`]( sdk/eventgrid/Microsoft.Azure.Management.EventGrid/src/Microsoft.Azure.Management.EventGrid.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.EventGrid](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.EventGrid.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.EventGrid/ ) |
| [`Microsoft.Azure.Management.EventHub`]( sdk/eventhub/Microsoft.Azure.Management.EventHub/src/Microsoft.Azure.Management.EventHub.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.EventHub](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.EventHub.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.EventHub/ ) |
| [`Microsoft.Azure.Management.FrontDoor`]( sdk/frontdoor/Microsoft.Azure.Management.FrontDoor/src/Microsoft.Azure.Management.FrontDoor.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.FrontDoor](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.FrontDoor.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.FrontDoor/ ) |
| [`Microsoft.Azure.Management.GuestConfiguration`]( sdk/guestconfiguration/Microsoft.Azure.Management.GuestConfiguration/src/Microsoft.Azure.Management.GuestConfiguration.csproj )|  N/A  | [Changelog](sdk/guestconfiguration/Microsoft.Azure.Management.GuestConfiguration/src/changelog.md) | [![Microsoft.Azure.Management.GuestConfiguration](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.GuestConfiguration.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.GuestConfiguration/ ) |
| [`Microsoft.Azure.Management.HDInsight`]( sdk/hdinsight/Microsoft.Azure.Management.HDInsight/src/Microsoft.Azure.Management.HDInsight.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.HDInsight](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.HDInsight.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.HDInsight/ ) |
| [`Microsoft.Azure.Management.HealthcareApis`]( sdk/healthcareapis/Microsoft.Azure.Management.HealthcareApis/src/Microsoft.Azure.Management.HealthcareApis.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.HealthcareApis](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.HealthcareApis.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.HealthcareApis/ ) |
| [`Microsoft.Azure.Management.HybridCompute`]( sdk/hybridcompute/Microsoft.Azure.Management.HybridCompute/src/Microsoft.Azure.Management.HybridCompute.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.HybridCompute](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.HybridCompute.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.HybridCompute/ ) |
| [`Microsoft.Azure.Management.HybridData`]( sdk/hybriddatamanager/Microsoft.Azure.Management.HybridDataManager/src/Microsoft.Azure.Management.HybridData.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.HybridData](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.HybridData.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.HybridData/ ) |
| [`Microsoft.Azure.Management.Insights`]( sdk/insights/Microsoft.Azure.Management.Insights/src/Microsoft.Azure.Management.Insights.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.Management.IotCentral`]( sdk/iotcentral/Microsoft.Azure.Management.IotCentral/src/Microsoft.Azure.Management.IotCentral.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.IotCentral](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.IotCentral.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.IotCentral/ ) |
| [`Microsoft.Azure.Management.IotHub`]( sdk/iothub/Microsoft.Azure.Management.IotHub/src/Microsoft.Azure.Management.IotHub.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.IotHub](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.IotHub.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.IotHub/ ) |
| [`Microsoft.Azure.Management.KeyVault`]( sdk/keyvault/Microsoft.Azure.Management.KeyVault/src/Microsoft.Azure.Management.KeyVault.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.KeyVault](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.KeyVault.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.KeyVault/ ) |
| [`Microsoft.Azure.Management.Kusto`]( sdk/kusto/Microsoft.Azure.Management.Kusto/src/Microsoft.Azure.Management.Kusto.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Kusto](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Kusto.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Kusto/ ) |
| [`Microsoft.Azure.Management.LabServices`]( sdk/labservices/Microsoft.Azure.Management.LabServices/src/Microsoft.Azure.Management.LabServices.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.LabServices](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.LabServices.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.LabServices/ ) |
| [`Microsoft.Azure.Management.LocationBasedServices`]( sdk/locationbasedservices/Microsoft.Azure.Management.LocationBasedServices/src/Microsoft.Azure.Management.LocationBasedServices.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.LocationBasedServices](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.LocationBasedServices.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.LocationBasedServices/ ) |
| [`Microsoft.Azure.Management.Logic`]( sdk/logic/Microsoft.Azure.Management.Logic/src/Microsoft.Azure.Management.Logic.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Logic](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Logic.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Logic/ ) |
| [`Microsoft.Azure.Management.MachineLearning`]( sdk/machinelearning/Microsoft.Azure.Management.MachineLearning/src/Microsoft.Azure.Management.MachineLearning.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.MachineLearning](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.MachineLearning.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.MachineLearning/ ) |
| [`Microsoft.Azure.Management.MachineLearningCompute`]( sdk/machinelearningcompute/Microsoft.Azure.Management.MachineLearningCompute/src/Microsoft.Azure.Management.MachineLearningCompute.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.MachineLearningCompute](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.MachineLearningCompute.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.MachineLearningCompute/ ) |
| [`Microsoft.Azure.Management.Maintenance`]( sdk/maintenance/Microsoft.Azure.Management.Maintenance/src/Microsoft.Azure.Management.Maintenance.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Maintenance](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Maintenance.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Maintenance/ ) |
| [`Microsoft.Azure.Management.ManagedNetwork`]( sdk/managednetwork/Microsoft.Azure.Management.ManagedNetwork/src/Microsoft.Azure.Management.ManagedNetwork.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ManagedNetwork](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ManagedNetwork.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ManagedNetwork/ ) |
| [`Microsoft.Azure.Management.ManagedServiceIdentity`]( sdk/managedserviceidentity/Microsoft.Azure.Management.ManagedServiceIdentity/src/Microsoft.Azure.Management.ManagedServiceIdentity.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ManagedServiceIdentity](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ManagedServiceIdentity.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ManagedServiceIdentity/ ) |
| [`Microsoft.Azure.Management.ManagedServices`]( sdk/managedservices/Microsoft.Azure.Management.ManagedServices/src/Microsoft.Azure.Management.ManagedServices.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ManagedServices](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ManagedServices.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ManagedServices/ ) |
| [`Microsoft.Azure.Management.ManagementGroups`]( sdk/managementgroups/Microsoft.Azure.Management.ManagementGroups/src/Microsoft.Azure.Management.ManagementGroups.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ManagementGroups](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ManagementGroups.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ManagementGroups/ ) |
| [`Microsoft.Azure.Management.ManagementPartner`]( sdk/managementpartner/Microsoft.Azure.Management.ManagementPartner/src/Microsoft.Azure.Management.ManagementPartner.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ManagementPartner](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ManagementPartner.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ManagementPartner/ ) |
| [`Microsoft.Azure.Management.Maps`]( sdk/maps/Microsoft.Azure.Management.Maps/src/Microsoft.Azure.Management.Maps.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Maps](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Maps.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Maps/ ) |
| [`Microsoft.Azure.Management.MarketplaceOrdering`]( sdk/marketplaceordering/Microsoft.Azure.Management.MarketplaceOrdering/src/Microsoft.Azure.Management.MarketplaceOrdering.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.MarketplaceOrdering](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.MarketplaceOrdering.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.MarketplaceOrdering/ ) |
| [`Microsoft.Azure.Management.Media`]( sdk/mediaservices/Microsoft.Azure.Management.Media/src/Microsoft.Azure.Management.Media.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Media](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Media.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Media/ ) |
| [`Microsoft.Azure.Management.MixedReality`]( sdk/mixedreality/Microsoft.Azure.Management.MixedReality/src/Microsoft.Azure.Management.MixedReality.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.MixedReality](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.MixedReality.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.MixedReality/ ) |
| [`Microsoft.Azure.Management.Monitor`]( sdk/monitor/Microsoft.Azure.Management.Monitor/src/Microsoft.Azure.Management.Monitor.csproj )|  N/A  | [Changelog](sdk/monitor/Microsoft.Azure.Management.Monitor/changelog.md) | [![Microsoft.Azure.Management.Monitor](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Monitor.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Monitor/ ) |
| [`Microsoft.Azure.Management.NetApp`]( sdk/netapp/Microsoft.Azure.Management.NetApp/src/Microsoft.Azure.Management.NetApp.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.NetApp](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.NetApp.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.NetApp/ ) |
| [`Microsoft.Azure.Management.Network`]( sdk/network/Microsoft.Azure.Management.Network/src/Microsoft.Azure.Management.Network.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Network](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Network.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Network/ ) |
| [`Microsoft.Azure.Management.NotificationHubs`]( sdk/notificationhubs/Microsoft.Azure.Management.NotificationHubs/src/Microsoft.Azure.Management.NotificationHubs.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.NotificationHubs](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.NotificationHubs.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.NotificationHubs/ ) |
| [`Microsoft.Azure.Management.OperationalInsights`]( sdk/operationalinsights/Microsoft.Azure.Management.OperationalInsights/src/Microsoft.Azure.Management.OperationalInsights.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.OperationalInsights](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.OperationalInsights.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.OperationalInsights/ ) |
| [`Microsoft.Azure.Management.Peering`]( sdk/peering/Microsoft.Azure.Management.Peering/src/Microsoft.Azure.Management.Peering.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Peering](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Peering.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Peering/ ) |
| [`Microsoft.Azure.Management.PolicyInsights`]( sdk/policyinsights/Microsoft.Azure.Management.PolicyInsights/src/Microsoft.Azure.Management.PolicyInsights.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.PolicyInsights](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.PolicyInsights.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.PolicyInsights/ ) |
| [`Microsoft.Azure.Management.PostgreSQL`]( sdk/postgresql/Microsoft.Azure.Management.PostgreSQL/src/Microsoft.Azure.Management.PostgreSQL.csproj )| [Readme](sdk/postgresql/Microsoft.Azure.Management.PostgreSQL/src/README.md) |  N/A  | [![Microsoft.Azure.Management.PostgreSQL](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.PostgreSQL.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.PostgreSQL/ ) |
| [`Microsoft.Azure.Management.PowerBIDedicated`]( sdk/powerbidedicated/Microsoft.Azure.Management.PowerBIDedicated/src/Microsoft.Azure.Management.PowerBIDedicated.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.PowerBIDedicated](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.PowerBIDedicated.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.PowerBIDedicated/ ) |
| [`Microsoft.Azure.Management.PowerBIEmbedded`]( tools/legacy/SdkBackup/PowerBIEmbedded/Management.PowerBIEmbedded/Microsoft.Azure.Management.PowerBIEmbedded.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.PowerBIEmbedded](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.PowerBIEmbedded.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.PowerBIEmbedded/ ) |
| [`Microsoft.Azure.Management.PrivateDns`]( sdk/privatedns/Microsoft.Azure.Management.PrivateDns/src/Microsoft.Azure.Management.PrivateDns.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.PrivateDns](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.PrivateDns.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.PrivateDns/ ) |
| [`Microsoft.Azure.Management.RecoveryServices`]( sdk/recoveryservices/Microsoft.Azure.Management.RecoveryServices/src/Microsoft.Azure.Management.RecoveryServices.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.RecoveryServices](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.RecoveryServices.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.RecoveryServices/ ) |
| [`Microsoft.Azure.Management.RecoveryServices.Backup`]( sdk/recoveryservices-backup/Microsoft.Azure.Management.RecoveryServices.Backup/src/Microsoft.Azure.Management.RecoveryServices.Backup.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.RecoveryServices.Backup](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.RecoveryServices.Backup.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.RecoveryServices.Backup/ ) |
| [`Microsoft.Azure.Management.RecoveryServices.SiteRecovery`]( sdk/recoveryservices-siterecovery/Microsoft.Azure.Management.RecoveryServices.SiteRecovery/src/Microsoft.Azure.Management.RecoveryServices.SiteRecovery.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.RecoveryServices.SiteRecovery](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.RecoveryServices.SiteRecovery.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.RecoveryServices.SiteRecovery/ ) |
| [`Microsoft.Azure.Management.Redis`]( sdk/redis/Microsoft.Azure.Management.RedisCache/src/Microsoft.Azure.Management.Redis.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Redis](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Redis.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Redis/ ) |
| [`Microsoft.Azure.Management.Relay`]( sdk/relay/Microsoft.Azure.Management.Relay/src/Microsoft.Azure.Management.Relay.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Relay](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Relay.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Relay/ ) |
| [`Microsoft.Azure.Management.Reservations`]( sdk/reservations/Microsoft.Azure.Management.Reservations/src/Microsoft.Azure.Management.Reservations.csproj )|  N/A  | [Changelog](sdk/reservations/Microsoft.Azure.Management.Reservations/changelog.md) | [![Microsoft.Azure.Management.Reservations](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Reservations.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Reservations/ ) |
| [`Microsoft.Azure.Management.ResourceGraph`]( sdk/resourcegraph/Microsoft.Azure.Management.ResourceGraph/src/Microsoft.Azure.Management.ResourceGraph.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ResourceGraph](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ResourceGraph.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ResourceGraph/ ) |
| [`Microsoft.Azure.Management.ResourceManager`]( sdk/resources/Microsoft.Azure.Management.Resource/src/Microsoft.Azure.Management.ResourceManager.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ResourceManager](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ResourceManager.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ResourceManager/ ) |
| [`Microsoft.Azure.Management.Scheduler`]( sdk/scheduler/Microsoft.Azure.Management.Scheduler/src/Microsoft.Azure.Management.Scheduler.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Scheduler](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Scheduler.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Scheduler/ ) |
| [`Microsoft.Azure.Management.Search`]( sdk/search/Microsoft.Azure.Management.Search/src/Microsoft.Azure.Management.Search.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Search](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Search.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Search/ ) |
| [`Microsoft.Azure.Management.SecurityCenter`]( sdk/securitycenter/Microsoft.Azure.Management.SecurityCenter/src/Microsoft.Azure.Management.SecurityCenter.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.SecurityCenter](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.SecurityCenter.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.SecurityCenter/ ) |
| [`Microsoft.Azure.Management.ServerManagement`]( sdk/servermanagement/Microsoft.Azure.Management.ServerManagement/src/Microsoft.Azure.Management.ServerManagement.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ServerManagement](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ServerManagement.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ServerManagement/ ) |
| [`Microsoft.Azure.Management.ServiceBus`]( sdk/servicebus/Microsoft.Azure.Management.ServiceBus/src/Microsoft.Azure.Management.ServiceBus.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ServiceBus](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ServiceBus.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ServiceBus/ ) |
| [`Microsoft.Azure.Management.ServiceFabric`]( sdk/servicefabric/Microsoft.Azure.Management.ServiceFabric/src/Microsoft.Azure.Management.ServiceFabric.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.ServiceFabric](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.ServiceFabric.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.ServiceFabric/ ) |
| [`Microsoft.Azure.Management.SignalR`]( sdk/signalr/Microsoft.Azure.Management.SignalR/src/Microsoft.Azure.Management.SignalR.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.SignalR](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.SignalR.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.SignalR/ ) |
| [`Microsoft.Azure.Management.Sql`]( sdk/sqlmanagement/Microsoft.Azure.Management.SqlManagement/src/Microsoft.Azure.Management.Sql.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Sql](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Sql.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Sql/ ) |
| [`Microsoft.Azure.Management.SqlVirtualMachine`]( sdk/sqlvirtualmachine/Microsoft.Azure.Management.SqlVirtualMachine/src/Microsoft.Azure.Management.SqlVirtualMachine.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.SqlVirtualMachine](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.SqlVirtualMachine.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.SqlVirtualMachine/ ) |
| [`Microsoft.Azure.Management.StorSimple1200Series`]( sdk/storsimple/Microsoft.Azure.Management.StorSimple/src/Microsoft.Azure.Management.StorSimple1200Series.csproj )|  N/A  |  N/A  |  N/A  |
| [`Microsoft.Azure.Management.StorSimple8000Series`]( sdk/storsimple8000series/Microsoft.Azure.Management.StorSimple8000Series/src/Microsoft.Azure.Management.StorSimple8000Series.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.StorSimple8000Series](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.StorSimple8000Series.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.StorSimple8000Series/ ) |
| [`Microsoft.Azure.Management.Storage`]( sdk/storage/Microsoft.Azure.Management.Storage/src/Microsoft.Azure.Management.Storage.csproj )|  N/A  | [Changelog](sdk/storage/Microsoft.Azure.Management.Storage/changelog.md) | [![Microsoft.Azure.Management.Storage](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Storage.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Storage/ ) |
| [`Microsoft.Azure.Management.StorageCache`]( sdk/storagecache/Microsoft.Azure.Management.StorageCache/src/Microsoft.Azure.Management.StorageCache.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.StorageCache](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.StorageCache.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.StorageCache/ ) |
| [`Microsoft.Azure.Management.StorageSync`]( sdk/storagesync/Microsoft.Azure.Management.StorageSync/src/Microsoft.Azure.Management.StorageSync.csproj )|  N/A  | [Changelog](sdk/storagesync/Microsoft.Azure.Management.StorageSync/changelog.md) | [![Microsoft.Azure.Management.StorageSync](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.StorageSync.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.StorageSync/ ) |
| [`Microsoft.Azure.Management.StreamAnalytics`]( sdk/streamanalytics/Microsoft.Azure.Management.StreamAnalytics/src/Microsoft.Azure.Management.StreamAnalytics.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.StreamAnalytics](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.StreamAnalytics.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.StreamAnalytics/ ) |
| [`Microsoft.Azure.Management.Subscription`]( sdk/subscription/Microsoft.Azure.Management.Subscription/src/Microsoft.Azure.Management.Subscription.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Subscription](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Subscription.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Subscription/ ) |
| [`Microsoft.Azure.Management.TrafficManager`]( sdk/trafficmanager/Microsoft.Azure.Management.TrafficManager/src/Microsoft.Azure.Management.TrafficManager.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.TrafficManager](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.TrafficManager.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.TrafficManager/ ) |
| [`Microsoft.Azure.Management.Websites`]( sdk/websites/Microsoft.Azure.Management.WebSites/src/Microsoft.Azure.Management.Websites.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Management.Websites](https://img.shields.io/nuget/vpre/Microsoft.Azure.Management.Websites.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Management.Websites/ ) |
| [`Microsoft.Azure.OperationalInsights`]( sdk/operationalinsights/Microsoft.Azure.OperationalInsights/src/Microsoft.Azure.OperationalInsights.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.OperationalInsights](https://img.shields.io/nuget/vpre/Microsoft.Azure.OperationalInsights.svg)]( https://www.nuget.org/packages/Microsoft.Azure.OperationalInsights/ ) |
| [`Microsoft.Azure.Search`]( sdk/search/Microsoft.Azure.Search/src/Microsoft.Azure.Search.csproj )|  N/A  | [Changelog](sdk/search/Microsoft.Azure.Search/CHANGELOG.md) | [![Microsoft.Azure.Search](https://img.shields.io/nuget/vpre/Microsoft.Azure.Search.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Search/ ) |
| [`Microsoft.Azure.Search.Common`]( sdk/search/Microsoft.Azure.Search.Common/src/Microsoft.Azure.Search.Common.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Search.Common](https://img.shields.io/nuget/vpre/Microsoft.Azure.Search.Common.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Search.Common/ ) |
| [`Microsoft.Azure.Search.Data`]( sdk/search/Microsoft.Azure.Search.Data/src/Microsoft.Azure.Search.Data.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Search.Data](https://img.shields.io/nuget/vpre/Microsoft.Azure.Search.Data.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Search.Data/ ) |
| [`Microsoft.Azure.Search.Service`]( sdk/search/Microsoft.Azure.Search.Service/src/Microsoft.Azure.Search.Service.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Search.Service](https://img.shields.io/nuget/vpre/Microsoft.Azure.Search.Service.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Search.Service/ ) |
| [`Microsoft.Azure.ServiceBus`]( sdk/servicebus/Microsoft.Azure.ServiceBus/src/Microsoft.Azure.ServiceBus.csproj )| [Readme](sdk/servicebus/Microsoft.Azure.ServiceBus/README.md) | [Changelog](sdk/servicebus/Microsoft.Azure.ServiceBus/changelog.md) | [![Microsoft.Azure.ServiceBus](https://img.shields.io/nuget/vpre/Microsoft.Azure.ServiceBus.svg)]( https://www.nuget.org/packages/Microsoft.Azure.ServiceBus/ ) |
| [`Microsoft.Azure.Services.AppAuthentication`]( sdk/mgmtcommon/AppAuthentication/Azure.Services.AppAuthentication/Microsoft.Azure.Services.AppAuthentication.csproj )| [Readme](sdk/mgmtcommon/AppAuthentication/README.md) |  N/A  | [![Microsoft.Azure.Services.AppAuthentication](https://img.shields.io/nuget/vpre/Microsoft.Azure.Services.AppAuthentication.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Services.AppAuthentication/ ) |
| [`Microsoft.Azure.Test.HttpRecorder`]( sdk/mgmtcommon/TestFramework/Microsoft.Azure.Test.HttpRecorder/Microsoft.Azure.Test.HttpRecorder.csproj )|  N/A  |  N/A  | [![Microsoft.Azure.Test.HttpRecorder](https://img.shields.io/nuget/vpre/Microsoft.Azure.Test.HttpRecorder.svg)]( https://www.nuget.org/packages/Microsoft.Azure.Test.HttpRecorder/ ) |
| [`Microsoft.AzureStack.Management.AzureBridge.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.AzureBridge.Admin/src/Microsoft.AzureStack.Management.AzureBridge.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.AzureBridge.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.AzureBridge.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.AzureBridge.Admin/ ) |
| [`Microsoft.AzureStack.Management.Backup.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.Backup.Admin/src/Microsoft.AzureStack.Management.Backup.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.Backup.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.Backup.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.Backup.Admin/ ) |
| [`Microsoft.AzureStack.Management.Commerce.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.Commerce.Admin/src/Microsoft.AzureStack.Management.Commerce.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.Commerce.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.Commerce.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.Commerce.Admin/ ) |
| [`Microsoft.AzureStack.Management.Compute.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.Compute.Admin/src/Microsoft.AzureStack.Management.Compute.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.Compute.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.Compute.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.Compute.Admin/ ) |
| [`Microsoft.AzureStack.Management.Fabric.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.Fabric.Admin/src/Microsoft.AzureStack.Management.Fabric.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.Fabric.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.Fabric.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.Fabric.Admin/ ) |
| [`Microsoft.AzureStack.Management.Gallery.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.Gallery.Admin/src/Microsoft.AzureStack.Management.Gallery.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.Gallery.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.Gallery.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.Gallery.Admin/ ) |
| [`Microsoft.AzureStack.Management.InfrastructureInsights.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.InfrastructureInsights.Admin/src/Microsoft.AzureStack.Management.InfrastructureInsights.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.InfrastructureInsights.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.InfrastructureInsights.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.InfrastructureInsights.Admin/ ) |
| [`Microsoft.AzureStack.Management.KeyVault.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.KeyVault.Admin/src/Microsoft.AzureStack.Management.KeyVault.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.KeyVault.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.KeyVault.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.KeyVault.Admin/ ) |
| [`Microsoft.AzureStack.Management.Network.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.Network.Admin/src/Microsoft.AzureStack.Management.Network.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.Network.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.Network.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.Network.Admin/ ) |
| [`Microsoft.AzureStack.Management.Storage.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.Storage.Admin/src/Microsoft.AzureStack.Management.Storage.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.Storage.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.Storage.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.Storage.Admin/ ) |
| [`Microsoft.AzureStack.Management.Subscription`]( sdk/azurestack/Microsoft.AzureStack.Management.Subscription/src/Microsoft.AzureStack.Management.Subscription.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.Subscription](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.Subscription.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.Subscription/ ) |
| [`Microsoft.AzureStack.Management.Subscriptions.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.Subscriptions.Admin/src/Microsoft.AzureStack.Management.Subscriptions.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.Subscriptions.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.Subscriptions.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.Subscriptions.Admin/ ) |
| [`Microsoft.AzureStack.Management.Update.Admin`]( sdk/azurestack/Microsoft.AzureStack.Management.Update.Admin/src/Microsoft.AzureStack.Management.Update.Admin.csproj )|  N/A  |  N/A  | [![Microsoft.AzureStack.Management.Update.Admin](https://img.shields.io/nuget/vpre/Microsoft.AzureStack.Management.Update.Admin.svg)]( https://www.nuget.org/packages/Microsoft.AzureStack.Management.Update.Admin/ ) |
| [`Microsoft.Extensions.Azure`]( sdk/core/Microsoft.Extensions.Azure/src/Microsoft.Extensions.Azure.csproj )| [Readme](sdk/core/Microsoft.Extensions.Azure/README.md) | [Changelog](sdk/core/Microsoft.Extensions.Azure/CHANGELOG.md) | [![Microsoft.Extensions.Azure](https://img.shields.io/nuget/vpre/Microsoft.Extensions.Azure.svg)]( https://www.nuget.org/packages/Microsoft.Extensions.Azure/ ) |
| [`Microsoft.Rest.ClientRuntime`]( sdk/mgmtcommon/ClientRuntime/ClientRuntime/Microsoft.Rest.ClientRuntime.csproj )|  N/A  |  N/A  | [![Microsoft.Rest.ClientRuntime](https://img.shields.io/nuget/vpre/Microsoft.Rest.ClientRuntime.svg)]( https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime/ ) |
| [`Microsoft.Rest.ClientRuntime.Azure`]( sdk/mgmtcommon/ClientRuntime.Azure/ClientRuntime.Azure/Microsoft.Rest.ClientRuntime.Azure.csproj )|  N/A  |  N/A  | [![Microsoft.Rest.ClientRuntime.Azure](https://img.shields.io/nuget/vpre/Microsoft.Rest.ClientRuntime.Azure.svg)]( https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime.Azure/ ) |
| [`Microsoft.Rest.ClientRuntime.Azure.Authentication`]( sdk/mgmtcommon/Auth/Az.Auth/Az.Authentication/Microsoft.Rest.ClientRuntime.Azure.Authentication.csproj )|  N/A  |  N/A  | [![Microsoft.Rest.ClientRuntime.Azure.Authentication](https://img.shields.io/nuget/vpre/Microsoft.Rest.ClientRuntime.Azure.Authentication.svg)]( https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime.Azure.Authentication/ ) |
| [`Microsoft.Rest.ClientRuntime.Azure.TestFramework`]( sdk/mgmtcommon/TestFramework/ClientRuntime.Azure.TestFramework/Microsoft.Rest.ClientRuntime.Azure.TestFramework.csproj )|  N/A  |  N/A  | [![Microsoft.Rest.ClientRuntime.Azure.TestFramework](https://img.shields.io/nuget/vpre/Microsoft.Rest.ClientRuntime.Azure.TestFramework.svg)]( https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime.Azure.TestFramework/ ) |
| [`Microsoft.Rest.ClientRuntime.Etw`]( sdk/mgmtcommon/ClientRuntime.Etw/Microsoft.Rest.ClientRuntime.Etw.csproj )| [Readme](sdk/mgmtcommon/ClientRuntime.Etw/README.md) |  N/A  | [![Microsoft.Rest.ClientRuntime.Etw](https://img.shields.io/nuget/vpre/Microsoft.Rest.ClientRuntime.Etw.svg)]( https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime.Etw/ ) |
| [`Microsoft.Rest.ClientRuntime.Log4Net`]( sdk/mgmtcommon/ClientRuntime.Log4Net/Microsoft.Rest.ClientRuntime.Log4Net.csproj )| [Readme](sdk/mgmtcommon/ClientRuntime.Log4Net/README.md) |  N/A  | [![Microsoft.Rest.ClientRuntime.Log4Net](https://img.shields.io/nuget/vpre/Microsoft.Rest.ClientRuntime.Log4Net.svg)]( https://www.nuget.org/packages/Microsoft.Rest.ClientRuntime.Log4Net/ ) |
| [`SnippetGenerator`]( eng/SnippetGenerator/SnippetGenerator.csproj )|  N/A  |  N/A  |  N/A  |
| [`docgen`]( eng/docgeneration/assets/docgen.csproj )|  N/A  |  N/A  |  N/A  |
  28  sdk/core/Azure.Core/Azure.Core.All.sln 
Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 16
VisualStudioVersion = 16.0.29315.20
MinimumVisualStudioVersion = 15.0.26124.0
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Core", "src\Azure.Core.csproj", "{B44F2086-D193-4304-8174-C1AFBAE859A4}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Core.Tests", "tests\Azure.Core.Tests.csproj", "{84491222-6C36-4FA7-BBAE-1FA804129151}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Data.AppConfiguration", "..\..\appconfiguration\Azure.Data.AppConfiguration\src\Azure.Data.AppConfiguration.csproj", "{2522B769-B443-4FDB-818D-74CAE8EC083D}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Data.AppConfiguration.Performance", "..\..\appconfiguration\Azure.Data.AppConfiguration\tests\Performance\Azure.Data.AppConfiguration.Performance.csproj", "{7F9959D6-66F0-4EC8-9875-60A23BAC812F}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Data.AppConfiguration.Samples.Tests", "..\..\appconfiguration\Azure.Data.AppConfiguration\samples\Azure.Data.AppConfiguration.Samples.Tests.csproj", "{069C9286-8602-4958-8C3A-25664B66FA62}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Data.AppConfiguration.Tests", "..\..\appconfiguration\Azure.Data.AppConfiguration\tests\Azure.Data.AppConfiguration.Tests.csproj", "{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Identity", "..\..\identity\Azure.Identity\src\Azure.Identity.csproj", "{0815662A-6754-428E-BC7C-FA9931E6A8C2}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Identity.Tests", "..\..\identity\Azure.Identity\tests\Azure.Identity.Tests.csproj", "{8B767463-EF7A-41FD-A424-0AE27885D7E0}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Messaging.EventHubs", "..\..\eventhub\Azure.Messaging.EventHubs\src\Azure.Messaging.EventHubs.csproj", "{DA902536-ADE4-41FB-B79A-ED9867C3738B}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Messaging.EventHubs.CheckpointStore.Blobs", "..\..\eventhub\Azure.Messaging.EventHubs.CheckpointStore.Blobs\src\Azure.Messaging.EventHubs.CheckpointStore.Blobs.csproj", "{DF56A85D-C171-4528-ACFB-4D923AA548B5}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Messaging.EventHubs.CheckpointStore.Blobs.Samples", "..\..\eventhub\Azure.Messaging.EventHubs.CheckpointStore.Blobs\samples\Azure.Messaging.EventHubs.CheckpointStore.Blobs.Samples.csproj", "{B8793F57-BD33-4123-B99B-ED4F51653F41}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Messaging.EventHubs.CheckpointStore.Blobs.Tests", "..\..\eventhub\Azure.Messaging.EventHubs.CheckpointStore.Blobs\tests\Azure.Messaging.EventHubs.CheckpointStore.Blobs.Tests.csproj", "{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Messaging.EventHubs.Samples", "..\..\eventhub\Azure.Messaging.EventHubs\samples\Azure.Messaging.EventHubs.Samples.csproj", "{D53F8B51-1B93-4F56-88B4-371A2B4E963E}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Messaging.EventHubs.Tests", "..\..\eventhub\Azure.Messaging.EventHubs\tests\Azure.Messaging.EventHubs.Tests.csproj", "{D94F8B83-80CD-4882-9D0E-47869935FA3F}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Security.KeyVault.Certificates", "..\..\keyvault\Azure.Security.KeyVault.Certificates\src\Azure.Security.KeyVault.Certificates.csproj", "{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Security.KeyVault.Certificates.Tests", "..\..\keyvault\Azure.Security.KeyVault.Certificates\tests\Azure.Security.KeyVault.Certificates.Tests.csproj", "{0A786C45-E062-4A41-853A-3A8F26DF4BA9}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Security.KeyVault.Keys", "..\..\keyvault\Azure.Security.KeyVault.Keys\src\Azure.Security.KeyVault.Keys.csproj", "{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Security.KeyVault.Keys.Tests", "..\..\keyvault\Azure.Security.KeyVault.Keys\tests\Azure.Security.KeyVault.Keys.Tests.csproj", "{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Security.KeyVault.Secrets", "..\..\keyvault\Azure.Security.KeyVault.Secrets\src\Azure.Security.KeyVault.Secrets.csproj", "{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Security.KeyVault.Secrets.Tests", "..\..\keyvault\Azure.Security.KeyVault.Secrets\tests\Azure.Security.KeyVault.Secrets.Tests.csproj", "{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Blobs", "..\..\storage\Azure.Storage.Blobs\src\Azure.Storage.Blobs.csproj", "{3131C71B-EB15-47E3-BB6D-32399D420292}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Blobs.Cryptography", "..\..\storage\Azure.Storage.Blobs.Cryptography\src\Azure.Storage.Blobs.Cryptography.csproj", "{713E0975-B551-47BA-B373-2C90518DBEB1}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Blobs.Samples.Tests", "..\..\storage\Azure.Storage.Blobs\samples\Azure.Storage.Blobs.Samples.Tests.csproj", "{D8932F99-0FE8-4947-AF14-86415920CC66}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Blobs.Tests", "..\..\storage\Azure.Storage.Blobs\tests\Azure.Storage.Blobs.Tests.csproj", "{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Common", "..\..\storage\Azure.Storage.Common\src\Azure.Storage.Common.csproj", "{3657795C-57D8-41C9-81F3-E5AEBF9838DB}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Common.Samples.Tests", "..\..\storage\Azure.Storage.Common\samples\Azure.Storage.Common.Samples.Tests.csproj", "{0191A692-B398-42B3-9DF9-88CCE49EC629}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Common.Tests", "..\..\storage\Azure.Storage.Common\tests\Azure.Storage.Common.Tests.csproj", "{4601FB32-1329-48A7-BA1E-4EAA9968639B}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Files.DataLake", "..\..\storage\Azure.Storage.Files.DataLake\src\Azure.Storage.Files.DataLake.csproj", "{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Files.DataLake.Samples.Tests", "..\..\storage\Azure.Storage.Files.DataLake\samples\Azure.Storage.Files.DataLake.Samples.Tests.csproj", "{79DA14BA-4A7F-440B-9246-46C86C2DF23E}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Files.DataLake.Tests", "..\..\storage\Azure.Storage.Files.DataLake\tests\Azure.Storage.Files.DataLake.Tests.csproj", "{13664876-6BFB-48A6-A363-C7B0C6924474}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Files.Shares", "..\..\storage\Azure.Storage.Files.Shares\src\Azure.Storage.Files.Shares.csproj", "{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Files.Shares.Samples.Tests", "..\..\storage\Azure.Storage.Files.Shares\samples\Azure.Storage.Files.Shares.Samples.Tests.csproj", "{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Files.Shares.Tests", "..\..\storage\Azure.Storage.Files.Shares\tests\Azure.Storage.Files.Shares.Tests.csproj", "{6730B668-63FF-49F0-91E1-123C4FB9A885}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Queues", "..\..\storage\Azure.Storage.Queues\src\Azure.Storage.Queues.csproj", "{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Queues.Cryptography", "..\..\storage\Azure.Storage.Queues.Cryptography\src\Azure.Storage.Queues.Cryptography.csproj", "{3B7B781E-92DA-46CA-A15F-4F9271355F19}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Queues.Samples.Tests", "..\..\storage\Azure.Storage.Queues\samples\Azure.Storage.Queues.Samples.Tests.csproj", "{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Queues.Tests", "..\..\storage\Azure.Storage.Queues\tests\Azure.Storage.Queues.Tests.csproj", "{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Microsoft.Extensions.Azure", "..\Microsoft.Extensions.Azure\src\Microsoft.Extensions.Azure.csproj", "{3D2D7FC1-F0C5-44A9-8356-24205B82F334}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Microsoft.Extensions.Azure.Samples", "..\Microsoft.Extensions.Azure\samples\Microsoft.Extensions.Azure.Samples.csproj", "{D8CA9940-58AB-49D0-9FCE-467B75C03033}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Microsoft.Extensions.Azure.Tests", "..\Microsoft.Extensions.Azure\tests\Microsoft.Extensions.Azure.Tests.csproj", "{F8A2ED33-F549-4126-8641-01208C69E29F}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.AI.InkRecognizer", "..\..\cognitiveservices\InkRecognizer\src\Azure.AI.InkRecognizer.csproj", "{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.AI.InkRecognizer.Tests", "..\..\cognitiveservices\InkRecognizer\tests\Azure.AI.InkRecognizer.Tests.csproj", "{D042FEB0-869D-4B50-9308-0BB22B5BA734}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Blobs.Batch", "..\..\storage\Azure.Storage.Blobs.Batch\src\Azure.Storage.Blobs.Batch.csproj", "{E46AE747-54C7-48C1-AE61-FE17B58A3651}"
EndProject
Project("{9A19103F-16F7-4668-BE54-9A1E7A4F7556}") = "Azure.Storage.Blobs.Batch.Tests", "..\..\storage\Azure.Storage.Blobs.Batch\tests\Azure.Storage.Blobs.Batch.Tests.csproj", "{B339B3B7-E256-462A-A6C1-03C086F5E70D}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Debug|x64 = Debug|x64
		Debug|x86 = Debug|x86
		Release|Any CPU = Release|Any CPU
		Release|x64 = Release|x64
		Release|x86 = Release|x86
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Debug|x64.ActiveCfg = Debug|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Debug|x64.Build.0 = Debug|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Debug|x86.ActiveCfg = Debug|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Debug|x86.Build.0 = Debug|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Release|Any CPU.Build.0 = Release|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Release|x64.ActiveCfg = Release|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Release|x64.Build.0 = Release|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Release|x86.ActiveCfg = Release|Any CPU
		{B44F2086-D193-4304-8174-C1AFBAE859A4}.Release|x86.Build.0 = Release|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Debug|x64.ActiveCfg = Debug|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Debug|x64.Build.0 = Debug|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Debug|x86.ActiveCfg = Debug|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Debug|x86.Build.0 = Debug|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Release|Any CPU.Build.0 = Release|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Release|x64.ActiveCfg = Release|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Release|x64.Build.0 = Release|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Release|x86.ActiveCfg = Release|Any CPU
		{84491222-6C36-4FA7-BBAE-1FA804129151}.Release|x86.Build.0 = Release|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Debug|x64.ActiveCfg = Debug|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Debug|x64.Build.0 = Debug|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Debug|x86.ActiveCfg = Debug|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Debug|x86.Build.0 = Debug|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Release|Any CPU.Build.0 = Release|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Release|x64.ActiveCfg = Release|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Release|x64.Build.0 = Release|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Release|x86.ActiveCfg = Release|Any CPU
		{2522B769-B443-4FDB-818D-74CAE8EC083D}.Release|x86.Build.0 = Release|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Debug|x64.ActiveCfg = Debug|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Debug|x64.Build.0 = Debug|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Debug|x86.ActiveCfg = Debug|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Debug|x86.Build.0 = Debug|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Release|Any CPU.Build.0 = Release|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Release|x64.ActiveCfg = Release|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Release|x64.Build.0 = Release|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Release|x86.ActiveCfg = Release|Any CPU
		{7F9959D6-66F0-4EC8-9875-60A23BAC812F}.Release|x86.Build.0 = Release|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Debug|x64.ActiveCfg = Debug|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Debug|x64.Build.0 = Debug|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Debug|x86.ActiveCfg = Debug|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Debug|x86.Build.0 = Debug|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Release|Any CPU.Build.0 = Release|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Release|x64.ActiveCfg = Release|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Release|x64.Build.0 = Release|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Release|x86.ActiveCfg = Release|Any CPU
		{069C9286-8602-4958-8C3A-25664B66FA62}.Release|x86.Build.0 = Release|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Debug|x64.ActiveCfg = Debug|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Debug|x64.Build.0 = Debug|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Debug|x86.ActiveCfg = Debug|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Debug|x86.Build.0 = Debug|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Release|Any CPU.Build.0 = Release|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Release|x64.ActiveCfg = Release|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Release|x64.Build.0 = Release|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Release|x86.ActiveCfg = Release|Any CPU
		{20FBBC26-7CC3-4C3E-A839-6E9A780EAA4B}.Release|x86.Build.0 = Release|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Debug|x64.ActiveCfg = Debug|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Debug|x64.Build.0 = Debug|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Debug|x86.ActiveCfg = Debug|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Debug|x86.Build.0 = Debug|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Release|Any CPU.Build.0 = Release|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Release|x64.ActiveCfg = Release|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Release|x64.Build.0 = Release|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Release|x86.ActiveCfg = Release|Any CPU
		{0815662A-6754-428E-BC7C-FA9931E6A8C2}.Release|x86.Build.0 = Release|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Debug|x64.ActiveCfg = Debug|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Debug|x64.Build.0 = Debug|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Debug|x86.ActiveCfg = Debug|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Debug|x86.Build.0 = Debug|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Release|Any CPU.Build.0 = Release|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Release|x64.ActiveCfg = Release|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Release|x64.Build.0 = Release|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Release|x86.ActiveCfg = Release|Any CPU
		{8B767463-EF7A-41FD-A424-0AE27885D7E0}.Release|x86.Build.0 = Release|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Debug|x64.ActiveCfg = Debug|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Debug|x64.Build.0 = Debug|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Debug|x86.ActiveCfg = Debug|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Debug|x86.Build.0 = Debug|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Release|Any CPU.Build.0 = Release|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Release|x64.ActiveCfg = Release|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Release|x64.Build.0 = Release|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Release|x86.ActiveCfg = Release|Any CPU
		{DA902536-ADE4-41FB-B79A-ED9867C3738B}.Release|x86.Build.0 = Release|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Debug|x64.ActiveCfg = Debug|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Debug|x64.Build.0 = Debug|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Debug|x86.ActiveCfg = Debug|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Debug|x86.Build.0 = Debug|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Release|Any CPU.Build.0 = Release|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Release|x64.ActiveCfg = Release|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Release|x64.Build.0 = Release|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Release|x86.ActiveCfg = Release|Any CPU
		{DF56A85D-C171-4528-ACFB-4D923AA548B5}.Release|x86.Build.0 = Release|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Debug|x64.ActiveCfg = Debug|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Debug|x64.Build.0 = Debug|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Debug|x86.ActiveCfg = Debug|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Debug|x86.Build.0 = Debug|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Release|Any CPU.Build.0 = Release|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Release|x64.ActiveCfg = Release|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Release|x64.Build.0 = Release|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Release|x86.ActiveCfg = Release|Any CPU
		{B8793F57-BD33-4123-B99B-ED4F51653F41}.Release|x86.Build.0 = Release|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Debug|x64.ActiveCfg = Debug|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Debug|x64.Build.0 = Debug|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Debug|x86.ActiveCfg = Debug|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Debug|x86.Build.0 = Debug|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Release|Any CPU.Build.0 = Release|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Release|x64.ActiveCfg = Release|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Release|x64.Build.0 = Release|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Release|x86.ActiveCfg = Release|Any CPU
		{8C8DF4EA-8C7B-4C4E-AF98-8CDF0F96947A}.Release|x86.Build.0 = Release|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Debug|x64.ActiveCfg = Debug|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Debug|x64.Build.0 = Debug|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Debug|x86.ActiveCfg = Debug|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Debug|x86.Build.0 = Debug|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Release|Any CPU.Build.0 = Release|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Release|x64.ActiveCfg = Release|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Release|x64.Build.0 = Release|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Release|x86.ActiveCfg = Release|Any CPU
		{D53F8B51-1B93-4F56-88B4-371A2B4E963E}.Release|x86.Build.0 = Release|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Debug|x64.ActiveCfg = Debug|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Debug|x64.Build.0 = Debug|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Debug|x86.ActiveCfg = Debug|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Debug|x86.Build.0 = Debug|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Release|Any CPU.Build.0 = Release|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Release|x64.ActiveCfg = Release|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Release|x64.Build.0 = Release|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Release|x86.ActiveCfg = Release|Any CPU
		{D94F8B83-80CD-4882-9D0E-47869935FA3F}.Release|x86.Build.0 = Release|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Debug|x64.ActiveCfg = Debug|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Debug|x64.Build.0 = Debug|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Debug|x86.ActiveCfg = Debug|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Debug|x86.Build.0 = Debug|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Release|Any CPU.Build.0 = Release|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Release|x64.ActiveCfg = Release|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Release|x64.Build.0 = Release|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Release|x86.ActiveCfg = Release|Any CPU
		{C7B11FD4-6DF3-46A0-BBA0-FE3BEE7E72C7}.Release|x86.Build.0 = Release|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Debug|x64.ActiveCfg = Debug|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Debug|x64.Build.0 = Debug|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Debug|x86.ActiveCfg = Debug|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Debug|x86.Build.0 = Debug|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Release|Any CPU.Build.0 = Release|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Release|x64.ActiveCfg = Release|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Release|x64.Build.0 = Release|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Release|x86.ActiveCfg = Release|Any CPU
		{0A786C45-E062-4A41-853A-3A8F26DF4BA9}.Release|x86.Build.0 = Release|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Debug|x64.ActiveCfg = Debug|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Debug|x64.Build.0 = Debug|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Debug|x86.ActiveCfg = Debug|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Debug|x86.Build.0 = Debug|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Release|Any CPU.Build.0 = Release|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Release|x64.ActiveCfg = Release|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Release|x64.Build.0 = Release|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Release|x86.ActiveCfg = Release|Any CPU
		{D3AAB7B3-FE77-4D95-9E6B-63013D7D1E19}.Release|x86.Build.0 = Release|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Debug|x64.ActiveCfg = Debug|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Debug|x64.Build.0 = Debug|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Debug|x86.ActiveCfg = Debug|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Debug|x86.Build.0 = Debug|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Release|Any CPU.Build.0 = Release|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Release|x64.ActiveCfg = Release|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Release|x64.Build.0 = Release|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Release|x86.ActiveCfg = Release|Any CPU
		{F72CF8B1-EB3F-45EE-AD3A-94637ACFA14E}.Release|x86.Build.0 = Release|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Debug|x64.ActiveCfg = Debug|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Debug|x64.Build.0 = Debug|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Debug|x86.ActiveCfg = Debug|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Debug|x86.Build.0 = Debug|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Release|Any CPU.Build.0 = Release|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Release|x64.ActiveCfg = Release|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Release|x64.Build.0 = Release|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Release|x86.ActiveCfg = Release|Any CPU
		{E65C48A9-963C-441B-BF3A-1A57B4AA01AC}.Release|x86.Build.0 = Release|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Debug|x64.ActiveCfg = Debug|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Debug|x64.Build.0 = Debug|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Debug|x86.ActiveCfg = Debug|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Debug|x86.Build.0 = Debug|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Release|Any CPU.Build.0 = Release|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Release|x64.ActiveCfg = Release|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Release|x64.Build.0 = Release|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Release|x86.ActiveCfg = Release|Any CPU
		{A1A9A9D6-7177-4BB6-8B25-9E309377DBF5}.Release|x86.Build.0 = Release|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Debug|x64.ActiveCfg = Debug|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Debug|x64.Build.0 = Debug|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Debug|x86.ActiveCfg = Debug|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Debug|x86.Build.0 = Debug|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Release|Any CPU.Build.0 = Release|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Release|x64.ActiveCfg = Release|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Release|x64.Build.0 = Release|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Release|x86.ActiveCfg = Release|Any CPU
		{3131C71B-EB15-47E3-BB6D-32399D420292}.Release|x86.Build.0 = Release|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Debug|x64.ActiveCfg = Debug|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Debug|x64.Build.0 = Debug|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Debug|x86.ActiveCfg = Debug|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Debug|x86.Build.0 = Debug|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Release|Any CPU.Build.0 = Release|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Release|x64.ActiveCfg = Release|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Release|x64.Build.0 = Release|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Release|x86.ActiveCfg = Release|Any CPU
		{713E0975-B551-47BA-B373-2C90518DBEB1}.Release|x86.Build.0 = Release|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Debug|x64.ActiveCfg = Debug|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Debug|x64.Build.0 = Debug|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Debug|x86.ActiveCfg = Debug|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Debug|x86.Build.0 = Debug|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Release|Any CPU.Build.0 = Release|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Release|x64.ActiveCfg = Release|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Release|x64.Build.0 = Release|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Release|x86.ActiveCfg = Release|Any CPU
		{D8932F99-0FE8-4947-AF14-86415920CC66}.Release|x86.Build.0 = Release|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Debug|x64.ActiveCfg = Debug|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Debug|x64.Build.0 = Debug|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Debug|x86.ActiveCfg = Debug|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Debug|x86.Build.0 = Debug|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Release|Any CPU.Build.0 = Release|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Release|x64.ActiveCfg = Release|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Release|x64.Build.0 = Release|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Release|x86.ActiveCfg = Release|Any CPU
		{DA6FF4BE-55F3-4180-A9D0-D2316AD6DABF}.Release|x86.Build.0 = Release|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Debug|x64.ActiveCfg = Debug|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Debug|x64.Build.0 = Debug|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Debug|x86.ActiveCfg = Debug|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Debug|x86.Build.0 = Debug|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Release|Any CPU.Build.0 = Release|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Release|x64.ActiveCfg = Release|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Release|x64.Build.0 = Release|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Release|x86.ActiveCfg = Release|Any CPU
		{3657795C-57D8-41C9-81F3-E5AEBF9838DB}.Release|x86.Build.0 = Release|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Debug|x64.ActiveCfg = Debug|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Debug|x64.Build.0 = Debug|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Debug|x86.ActiveCfg = Debug|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Debug|x86.Build.0 = Debug|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Release|Any CPU.Build.0 = Release|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Release|x64.ActiveCfg = Release|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Release|x64.Build.0 = Release|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Release|x86.ActiveCfg = Release|Any CPU
		{0191A692-B398-42B3-9DF9-88CCE49EC629}.Release|x86.Build.0 = Release|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Debug|x64.ActiveCfg = Debug|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Debug|x64.Build.0 = Debug|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Debug|x86.ActiveCfg = Debug|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Debug|x86.Build.0 = Debug|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Release|Any CPU.Build.0 = Release|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Release|x64.ActiveCfg = Release|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Release|x64.Build.0 = Release|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Release|x86.ActiveCfg = Release|Any CPU
		{4601FB32-1329-48A7-BA1E-4EAA9968639B}.Release|x86.Build.0 = Release|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Debug|x64.ActiveCfg = Debug|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Debug|x64.Build.0 = Debug|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Debug|x86.ActiveCfg = Debug|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Debug|x86.Build.0 = Debug|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Release|Any CPU.Build.0 = Release|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Release|x64.ActiveCfg = Release|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Release|x64.Build.0 = Release|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Release|x86.ActiveCfg = Release|Any CPU
		{3869B2C3-AF0C-4B94-BF43-98862F31D3DD}.Release|x86.Build.0 = Release|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Debug|x64.ActiveCfg = Debug|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Debug|x64.Build.0 = Debug|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Debug|x86.ActiveCfg = Debug|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Debug|x86.Build.0 = Debug|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Release|Any CPU.Build.0 = Release|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Release|x64.ActiveCfg = Release|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Release|x64.Build.0 = Release|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Release|x86.ActiveCfg = Release|Any CPU
		{79DA14BA-4A7F-440B-9246-46C86C2DF23E}.Release|x86.Build.0 = Release|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Debug|x64.ActiveCfg = Debug|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Debug|x64.Build.0 = Debug|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Debug|x86.ActiveCfg = Debug|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Debug|x86.Build.0 = Debug|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Release|Any CPU.Build.0 = Release|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Release|x64.ActiveCfg = Release|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Release|x64.Build.0 = Release|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Release|x86.ActiveCfg = Release|Any CPU
		{13664876-6BFB-48A6-A363-C7B0C6924474}.Release|x86.Build.0 = Release|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Debug|x64.ActiveCfg = Debug|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Debug|x64.Build.0 = Debug|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Debug|x86.ActiveCfg = Debug|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Debug|x86.Build.0 = Debug|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Release|Any CPU.Build.0 = Release|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Release|x64.ActiveCfg = Release|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Release|x64.Build.0 = Release|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Release|x86.ActiveCfg = Release|Any CPU
		{0E0AB91A-9A19-4EBC-AF3C-F29651B3425B}.Release|x86.Build.0 = Release|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Debug|x64.ActiveCfg = Debug|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Debug|x64.Build.0 = Debug|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Debug|x86.ActiveCfg = Debug|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Debug|x86.Build.0 = Debug|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Release|Any CPU.Build.0 = Release|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Release|x64.ActiveCfg = Release|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Release|x64.Build.0 = Release|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Release|x86.ActiveCfg = Release|Any CPU
		{8AE5CEDB-8A9A-4E44-A098-B141E67D7782}.Release|x86.Build.0 = Release|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Debug|x64.ActiveCfg = Debug|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Debug|x64.Build.0 = Debug|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Debug|x86.ActiveCfg = Debug|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Debug|x86.Build.0 = Debug|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Release|Any CPU.Build.0 = Release|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Release|x64.ActiveCfg = Release|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Release|x64.Build.0 = Release|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Release|x86.ActiveCfg = Release|Any CPU
		{6730B668-63FF-49F0-91E1-123C4FB9A885}.Release|x86.Build.0 = Release|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Debug|x64.ActiveCfg = Debug|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Debug|x64.Build.0 = Debug|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Debug|x86.ActiveCfg = Debug|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Debug|x86.Build.0 = Debug|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Release|Any CPU.Build.0 = Release|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Release|x64.ActiveCfg = Release|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Release|x64.Build.0 = Release|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Release|x86.ActiveCfg = Release|Any CPU
		{E01BF9E7-625A-42CA-A50C-AC5464CA30B7}.Release|x86.Build.0 = Release|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Debug|x64.ActiveCfg = Debug|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Debug|x64.Build.0 = Debug|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Debug|x86.ActiveCfg = Debug|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Debug|x86.Build.0 = Debug|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Release|Any CPU.Build.0 = Release|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Release|x64.ActiveCfg = Release|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Release|x64.Build.0 = Release|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Release|x86.ActiveCfg = Release|Any CPU
		{3B7B781E-92DA-46CA-A15F-4F9271355F19}.Release|x86.Build.0 = Release|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Debug|x64.ActiveCfg = Debug|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Debug|x64.Build.0 = Debug|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Debug|x86.ActiveCfg = Debug|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Debug|x86.Build.0 = Debug|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Release|Any CPU.Build.0 = Release|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Release|x64.ActiveCfg = Release|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Release|x64.Build.0 = Release|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Release|x86.ActiveCfg = Release|Any CPU
		{1B83F9FE-DB1C-4E26-96D3-FC7889B3554A}.Release|x86.Build.0 = Release|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Debug|x64.ActiveCfg = Debug|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Debug|x64.Build.0 = Debug|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Debug|x86.ActiveCfg = Debug|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Debug|x86.Build.0 = Debug|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Release|Any CPU.Build.0 = Release|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Release|x64.ActiveCfg = Release|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Release|x64.Build.0 = Release|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Release|x86.ActiveCfg = Release|Any CPU
		{A4E40B39-85DC-43D1-897C-5C5213CFBE6F}.Release|x86.Build.0 = Release|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Debug|x64.ActiveCfg = Debug|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Debug|x64.Build.0 = Debug|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Debug|x86.ActiveCfg = Debug|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Debug|x86.Build.0 = Debug|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Release|Any CPU.Build.0 = Release|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Release|x64.ActiveCfg = Release|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Release|x64.Build.0 = Release|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Release|x86.ActiveCfg = Release|Any CPU
		{3D2D7FC1-F0C5-44A9-8356-24205B82F334}.Release|x86.Build.0 = Release|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Debug|x64.ActiveCfg = Debug|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Debug|x64.Build.0 = Debug|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Debug|x86.ActiveCfg = Debug|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Debug|x86.Build.0 = Debug|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Release|Any CPU.Build.0 = Release|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Release|x64.ActiveCfg = Release|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Release|x64.Build.0 = Release|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Release|x86.ActiveCfg = Release|Any CPU
		{D8CA9940-58AB-49D0-9FCE-467B75C03033}.Release|x86.Build.0 = Release|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Debug|x64.ActiveCfg = Debug|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Debug|x64.Build.0 = Debug|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Debug|x86.ActiveCfg = Debug|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Debug|x86.Build.0 = Debug|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Release|Any CPU.Build.0 = Release|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Release|x64.ActiveCfg = Release|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Release|x64.Build.0 = Release|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Release|x86.ActiveCfg = Release|Any CPU
		{F8A2ED33-F549-4126-8641-01208C69E29F}.Release|x86.Build.0 = Release|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Debug|x64.ActiveCfg = Debug|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Debug|x64.Build.0 = Debug|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Debug|x86.ActiveCfg = Debug|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Debug|x86.Build.0 = Debug|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Release|Any CPU.Build.0 = Release|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Release|x64.ActiveCfg = Release|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Release|x64.Build.0 = Release|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Release|x86.ActiveCfg = Release|Any CPU
		{1A52E345-444E-4D5A-BCFF-82273CD6F4AE}.Release|x86.Build.0 = Release|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Debug|x64.ActiveCfg = Debug|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Debug|x64.Build.0 = Debug|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Debug|x86.ActiveCfg = Debug|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Debug|x86.Build.0 = Debug|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Release|Any CPU.Build.0 = Release|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Release|x64.ActiveCfg = Release|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Release|x64.Build.0 = Release|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Release|x86.ActiveCfg = Release|Any CPU
		{D042FEB0-869D-4B50-9308-0BB22B5BA734}.Release|x86.Build.0 = Release|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Debug|x64.ActiveCfg = Debug|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Debug|x64.Build.0 = Debug|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Debug|x86.ActiveCfg = Debug|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Debug|x86.Build.0 = Debug|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Release|Any CPU.Build.0 = Release|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Release|x64.ActiveCfg = Release|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Release|x64.Build.0 = Release|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Release|x86.ActiveCfg = Release|Any CPU
		{E46AE747-54C7-48C1-AE61-FE17B58A3651}.Release|x86.Build.0 = Release|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Debug|x64.ActiveCfg = Debug|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Debug|x64.Build.0 = Debug|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Debug|x86.ActiveCfg = Debug|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Debug|x86.Build.0 = Debug|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Release|Any CPU.Build.0 = Release|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Release|x64.ActiveCfg = Release|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Release|x64.Build.0 = Release|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Release|x86.ActiveCfg = Release|Any CPU
		{B339B3B7-E256-462A-A6C1-03C086F5E70D}.Release|x86.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = True
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = ```[```"(```057627CE-CC6C-40D6-AB12-90857D4986C4```)"```]```
	EndGlobalSection
EndGlobal
