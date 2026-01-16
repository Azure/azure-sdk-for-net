<#
.SYNOPSIS
    Reverts all modified .csproj files to their state in origin/main.

.DESCRIPTION
    This script identifies all modified .csproj files and reverts them using git checkout origin/main.
    Useful for reverting formatting changes made by the NUnit migration script.

.PARAMETER RepoRoot
    The root directory of the repository. Defaults to current directory.

.PARAMETER DryRun
    If specified, shows what would be reverted without making changes.

.EXAMPLE
    .\Revert-CsprojFiles.ps1
    Reverts all modified .csproj files.

.EXAMPLE
    .\Revert-CsprojFiles.ps1 -DryRun
    Shows which files would be reverted without making changes.
#>

[CmdletBinding()]
param(
    [Parameter()]
    [string]$RepoRoot = ".",
    
    [Parameter()]
    [switch]$DryRun
)

$ErrorActionPreference = "Stop"

# Convert to absolute path
$RepoRoot = Resolve-Path $RepoRoot -ErrorAction Stop

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Revert .csproj Files Script" -ForegroundColor Cyan
Write-Host "========================================" -ForegroundColor Cyan
Write-Host "Repository: $RepoRoot" -ForegroundColor Yellow
Write-Host "Dry Run: $DryRun" -ForegroundColor Yellow
Write-Host ""

# Change to repo root
Push-Location $RepoRoot

try {
    # Hardcoded list of .csproj files to revert
    $csprojFiles = @(
        "eng/packages/http-client-csharp/generator/Azure.Generator/test/Azure.Generator.Tests.csproj",
        "eng/packages/http-client-csharp/generator/Azure.Generator/test/common/Azure.Generator.Tests.Common.csproj",
        "eng/packages/http-client-csharp/generator/TestProjects/Spector.Tests/TestProjects.Spector.Tests.csproj",
        "sdk/agrifood/Azure.Verticals.AgriFood.Farming/tests/Azure.Verticals.AgriFood.Farming.Tests.csproj",
        "sdk/ai/Azure.AI.Agents.Persistent/tests/Azure.AI.Agents.Persistent.Tests.csproj",
        "sdk/ai/Azure.AI.Inference/tests/Azure.AI.Inference.Tests.csproj",
        "sdk/ai/Azure.AI.Projects/tests/Azure.AI.Projects.Tests.csproj",
        "sdk/ai/Azure.AI.VoiceLive/tests/Azure.AI.VoiceLive.Tests.csproj",
        "sdk/anomalydetector/Azure.AI.AnomalyDetector/tests/Azure.AI.AnomalyDetector.Tests.csproj",
        "sdk/appconfiguration/Azure.Data.AppConfiguration/perf/Azure.Data.AppConfiguration.Perf.csproj",
        "sdk/appconfiguration/Azure.Data.AppConfiguration/tests/Azure.Data.AppConfiguration.Tests.csproj",
        "sdk/batch/Azure.Compute.Batch/tests/Azure.Compute.Batch.Tests.csproj",
        "sdk/cloudmachine/Azure.Projects.AI/tests/Azure.Projects.AI.Tests.csproj",
        "sdk/cloudmachine/Azure.Projects.Provisioning/tests/Azure.Projects.Provisioning.Tests.csproj",
        "sdk/cloudmachine/Azure.Projects/tests/Azure.Projects.Tests.csproj",
        "sdk/cognitivelanguage/Azure.AI.Language.Conversations.Authoring/tests/Azure.AI.Language.Conversations.Authoring.Tests.csproj",
        "sdk/cognitivelanguage/Azure.AI.Language.Conversations/perf/Azure.AI.Language.Conversations.Perf.csproj",
        "sdk/cognitivelanguage/Azure.AI.Language.Conversations/tests/Azure.AI.Language.Conversations.Tests.csproj",
        "sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Authoring/tests/Azure.AI.Language.QuestionAnswering.Authoring.Tests.csproj",
        "sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering.Inference/tests/Azure.AI.Language.QuestionAnswering.Inference.Tests.csproj",
        "sdk/cognitivelanguage/Azure.AI.Language.QuestionAnswering/tests/Azure.AI.Language.QuestionAnswering.Tests.csproj",
        "sdk/cognitivelanguage/Azure.AI.Language.Text.Authoring/tests/Azure.AI.Language.Text.Authoring.Tests.csproj",
        "sdk/cognitivelanguage/Azure.AI.Language.Text/tests/Azure.AI.Language.Text.Tests.csproj",
        "sdk/communication/Azure.Communication.AlphaIds/tests/Azure.Communication.AlphaIds.Tests.csproj",
        "sdk/communication/Azure.Communication.CallAutomation/tests/Azure.Communication.CallAutomation.Tests.csproj",
        "sdk/communication/Azure.Communication.CallingServer/tests/Azure.Communication.CallingServer.Tests.csproj",
        "sdk/communication/Azure.Communication.Chat/tests/Azure.Communication.Chat.Tests.csproj",
        "sdk/communication/Azure.Communication.Common/tests/Azure.Communication.Common.Tests.csproj",
        "sdk/communication/Azure.Communication.Email/tests/Azure.Communication.Email.Tests.csproj",
        "sdk/communication/Azure.Communication.Identity/tests/Azure.Communication.Identity.Tests.csproj",
        "sdk/communication/Azure.Communication.JobRouter/tests/Azure.Communication.JobRouter.Tests.csproj",
        "sdk/communication/Azure.Communication.Messages/tests/Azure.Communication.Messages.Tests.csproj",
        "sdk/communication/Azure.Communication.PhoneNumbers/tests/Azure.Communication.PhoneNumbers.Tests.csproj",
        "sdk/communication/Azure.Communication.ProgrammableConnectivity/tests/Azure.Communication.ProgrammableConnectivity.Tests.csproj",
        "sdk/communication/Azure.Communication.Rooms/tests/Azure.Communication.Rooms.Tests.csproj",
        "sdk/communication/Azure.Communication.ShortCodes/tests/Azure.Communication.ShortCodes.Tests.csproj",
        "sdk/communication/Azure.Communication.Sms/tests/Azure.Communication.Sms.Tests.csproj",
        "sdk/confidentialledger/Azure.Security.CodeTransparency/tests/Azure.Security.CodeTransparency.Tests.csproj",
        "sdk/confidentialledger/Azure.Security.ConfidentialLedger/tests/Azure.Security.ConfidentialLedger.Tests.csproj",
        "sdk/containerregistry/Azure.Containers.ContainerRegistry/tests/Azure.Containers.ContainerRegistry.Tests.csproj",
        "sdk/contentsafety/Azure.AI.ContentSafety/tests/Azure.AI.ContentSafety.Tests.csproj",
        "sdk/contentunderstanding/Azure.AI.ContentUnderstanding/tests/Azure.AI.ContentUnderstanding.Tests.csproj",
        "sdk/core/Azure.Core.Amqp/tests/Azure.Core.Amqp.Tests.csproj",
        "sdk/core/Azure.Core.Experimental/tests/Azure.Core.Experimental.Tests.csproj",
        "sdk/core/Azure.Core.Expressions.DataFactory/tests/Azure.Core.Expressions.DataFactory.Tests.csproj",
        "sdk/core/Azure.Core.TestFramework/tests/Azure.Core.TestFramework.Tests.csproj",
        "sdk/core/Azure.Core/tests/Azure.Core.Tests.csproj",
        "sdk/core/Microsoft.Azure.Core.NewtonsoftJson/tests/Microsoft.Azure.Core.NewtonsoftJson.Tests.csproj",
        "sdk/core/Microsoft.Azure.Core.Spatial.NewtonsoftJson/tests/Microsoft.Azure.Core.Spatial.NewtonsoftJson.Tests.csproj",
        "sdk/core/Microsoft.Azure.Core.Spatial/tests/Microsoft.Azure.Core.Spatial.Tests.csproj",
        "sdk/core/Microsoft.ClientModel.TestFramework/tests/Microsoft.ClientModel.TestFramework.Tests.csproj",
        "sdk/core/System.ClientModel/tests/System.ClientModel.Tests.csproj",
        "sdk/core/System.ClientModel/tests/gen.unit/System.ClientModel.SourceGeneration.Unit.Tests.csproj",
        "sdk/core/System.ClientModel/tests/gen/System.ClientModel.SourceGeneration.Tests.csproj",
        "sdk/core/System.ClientModel/tests/internal.perf/System.ClientModel.Tests.Internal.Perf.csproj",
        "sdk/devcenter/Azure.Developer.DevCenter/tests/Azure.Developer.DevCenter.Tests.csproj",
        "sdk/deviceupdate/Azure.IoT.DeviceUpdate/tests/Azure.IoT.DeviceUpdate.Tests.csproj",
        "sdk/digitaltwins/Azure.DigitalTwins.Core/perf/Azure.DigitalTwins.Core.Perf/Azure.DigitalTwins.Core.Perf.csproj",
        "sdk/digitaltwins/Azure.DigitalTwins.Core/tests/Azure.DigitalTwins.Core.Tests.csproj",
        "sdk/documentintelligence/Azure.AI.DocumentIntelligence/tests/Azure.AI.DocumentIntelligence.Tests.csproj",
        "sdk/easm/Azure.Analytics.Defender.Easm/tests/Azure.Analytics.Defender.Easm.Tests.csproj",
        "sdk/entra/Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents/tests/Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents.Tests.csproj",
        "sdk/eventgrid/Azure.Messaging.EventGrid.Namespaces/tests/Azure.Messaging.EventGrid.Namespaces.Tests.csproj",
        "sdk/eventgrid/Azure.Messaging.EventGrid.SystemEvents/tests/Azure.Messaging.EventGrid.SystemEvents.Tests.csproj",
        "sdk/eventgrid/Azure.Messaging.EventGrid/tests/Azure.Messaging.EventGrid.Tests.csproj",
        "sdk/eventgrid/Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents/tests/Microsoft.Azure.Messaging.EventGrid.CloudNativeCloudEvents.Tests.csproj",
        "sdk/eventgrid/Microsoft.Azure.WebJobs.Extensions.EventGrid/tests/Microsoft.Azure.WebJobs.Extensions.EventGrid.Tests.csproj",
        "sdk/eventhub/Azure.Messaging.EventHubs.Processor/samples/aspnet-hosted-service/tests/Azure.Messaging.EventHubs.Processor.Samples.HostedService.Tests.csproj",
        "sdk/eventhub/Azure.Messaging.EventHubs.Processor/tests/Azure.Messaging.EventHubs.Processor.Tests.csproj",
        "sdk/eventhub/Azure.Messaging.EventHubs.Shared/tests/Azure.Messaging.EventHubs.Shared.Tests.csproj",
        "sdk/eventhub/Azure.Messaging.EventHubs/tests/Azure.Messaging.EventHubs.Tests.csproj",
        "sdk/eventhub/Microsoft.Azure.WebJobs.Extensions.EventHubs/tests/Microsoft.Azure.WebJobs.Extensions.EventHubs.Tests.csproj",
        "sdk/extension-wcf/Microsoft.CoreWCF.Azure.StorageQueues/tests/Microsoft.CoreWCF.Azure.StorageQueues.Tests.csproj",
        "sdk/extension-wcf/Microsoft.WCF.Azure.StorageQueues/tests/Microsoft.WCF.Azure.StorageQueues.Tests.csproj",
        "sdk/extensions/Azure.Extensions.AspNetCore.Configuration.Secrets/tests/Azure.Extensions.AspNetCore.Configuration.Secrets.Tests.csproj",
        "sdk/extensions/Azure.Extensions.AspNetCore.DataProtection.Blobs/tests/Azure.Extensions.AspNetCore.DataProtection.Blobs.Tests.csproj",
        "sdk/extensions/Azure.Extensions.AspNetCore.DataProtection.Keys/tests/Azure.Extensions.AspNetCore.DataProtection.Keys.Tests.csproj",
        "sdk/extensions/Microsoft.Azure.WebJobs.Extensions.Clients/tests/Microsoft.Azure.WebJobs.Extensions.Clients.Tests.csproj",
        "sdk/extensions/Microsoft.Extensions.Azure/tests/Microsoft.Extensions.Azure.Tests.csproj",
        "sdk/face/Azure.AI.Vision.Face/tests/Azure.AI.Vision.Face.Tests.csproj",
        "sdk/formrecognizer/Azure.AI.FormRecognizer/perf/Azure.AI.FormRecognizer.Perf/Azure.AI.FormRecognizer.Perf.csproj",
        "sdk/formrecognizer/Azure.AI.FormRecognizer/tests/Azure.AI.FormRecognizer.Tests.csproj",
        "sdk/healthdataaiservices/Azure.Health.Deidentification/tests/Azure.Health.Deidentification.Tests.csproj",
        "sdk/healthinsights/Azure.Health.Insights.CancerProfiling/tests/Azure.Health.Insights.CancerProfiling.Tests.csproj",
        "sdk/healthinsights/Azure.Health.Insights.ClinicalMatching/tests/Azure.Health.Insights.ClinicalMatching.Tests.csproj",
        "sdk/healthinsights/Azure.Health.Insights.RadiologyInsights/tests/Azure.Health.Insights.RadiologyInsights.Tests.csproj",
        "sdk/identity/Azure.Identity.Broker/tests/Azure.Identity.Broker.Tests.csproj",
        "sdk/identity/Azure.Identity/perf/Azure.Identity.Perf.csproj",
        "sdk/identity/Azure.Identity/tests/Azure.Identity.Tests.csproj",
        "sdk/keyvault/Azure.ResourceManager.KeyVault/tests/Azure.ResourceManager.KeyVault.Tests.csproj",
        "sdk/keyvault/Azure.Security.KeyVault.Administration/tests/Azure.Security.KeyVault.Administration.Tests.csproj",
        "sdk/keyvault/Azure.Security.KeyVault.Certificates/perf/Azure.Security.KeyVault.Certificates.Perf.csproj",
        "sdk/keyvault/Azure.Security.KeyVault.Certificates/tests/Azure.Security.KeyVault.Certificates.Tests.csproj",
        "sdk/keyvault/Azure.Security.KeyVault.Keys/perf/Azure.Security.KeyVault.Keys.Perf.csproj",
        "sdk/keyvault/Azure.Security.KeyVault.Keys/tests/Azure.Security.KeyVault.Keys.Tests.csproj",
        "sdk/keyvault/Azure.Security.KeyVault.Secrets/perf/Azure.Security.KeyVault.Secrets.Perf.csproj",
        "sdk/keyvault/Azure.Security.KeyVault.Secrets/tests/Azure.Security.KeyVault.Secrets.Tests.csproj",
        "sdk/loadtestservice/Azure.Developer.LoadTesting/tests/Azure.Developer.LoadTesting.Tests.csproj",
        "sdk/loadtestservice/Azure.Developer.Playwright.MSTest/tests/Azure.Developer.Playwright.MSTest.Tests.csproj",
        "sdk/loadtestservice/Azure.Developer.Playwright.NUnit/tests/Azure.Developer.Playwright.NUnit.Tests.csproj",
        "sdk/loadtestservice/Azure.Developer.Playwright/tests/Azure.Developer.Playwright.Tests.csproj",
        "sdk/maps/Azure.Maps.Common/tests/Azure.Maps.Common.Tests.csproj",
        "sdk/maps/Azure.Maps.Geolocation/tests/Azure.Maps.Geolocation.Tests.csproj",
        "sdk/maps/Azure.Maps.Rendering/tests/Azure.Maps.Rendering.Tests.csproj",
        "sdk/maps/Azure.Maps.Routing/tests/Azure.Maps.Routing.Tests.csproj",
        "sdk/maps/Azure.Maps.Search/tests/Azure.Maps.Search.Tests.csproj",
        "sdk/maps/Azure.Maps.TimeZones/tests/Azure.Maps.TimeZones.Tests.csproj",
        "sdk/maps/Azure.Maps.Weather/tests/Azure.Maps.Weather.Tests.csproj",
        "sdk/metricsadvisor/Azure.AI.MetricsAdvisor/perf/Azure.AI.MetricsAdvisor.Perf/Azure.AI.MetricsAdvisor.Perf.csproj",
        "sdk/metricsadvisor/Azure.AI.MetricsAdvisor/tests/Azure.AI.MetricsAdvisor.Tests.csproj",
        "sdk/mixedreality/Azure.MixedReality.Authentication/tests/Azure.MixedReality.Authentication.Tests/Azure.MixedReality.Authentication.Tests.csproj",
        "sdk/mixedreality/Azure.MixedReality.Authentication/tests/Shared.Azure.MixedReality.Authentication.Tests/Shared.Azure.MixedReality.Authentication.Tests.csproj",
        "sdk/modelsrepository/Azure.IoT.ModelsRepository/tests/Azure.IoT.ModelsRepository.Tests.csproj",
        "sdk/monitor/Azure.Monitor.Ingestion/perf/Azure.Monitor.Ingestion.Perf.csproj",
        "sdk/monitor/Azure.Monitor.Ingestion/tests/Azure.Monitor.Ingestion.Tests.csproj",
        "sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/tests/Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests/Azure.Monitor.OpenTelemetry.AspNetCore.Integration.Tests.csproj",
        "sdk/monitor/Azure.Monitor.OpenTelemetry.AspNetCore/tests/Azure.Monitor.OpenTelemetry.AspNetCore.Tests/Azure.Monitor.OpenTelemetry.AspNetCore.Tests.csproj",
        "sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/perf/Azure.Monitor.OpenTelemetry.Exporter.Perf.csproj",
        "sdk/monitor/Azure.Monitor.OpenTelemetry.Exporter/tests/Azure.Monitor.OpenTelemetry.Exporter.Tests/Azure.Monitor.OpenTelemetry.Exporter.Tests.csproj",
        "sdk/monitor/Azure.Monitor.OpenTelemetry.LiveMetrics/tests/Azure.Monitor.OpenTelemetry.LiveMetrics.Tests/Azure.Monitor.OpenTelemetry.LiveMetrics.Tests.csproj",
        "sdk/monitor/Azure.Monitor.Query.Logs/tests/Azure.Monitor.Query.Logs.Tests.csproj",
        "sdk/monitor/Azure.Monitor.Query.Metrics/tests/Azure.Monitor.Query.Metrics.Tests.csproj",
        "sdk/objectanchors/Azure.MixedReality.ObjectAnchors.Conversion/tests/Azure.MixedReality.ObjectAnchors.Conversion.Tests.csproj",
        "sdk/onlineexperimentation/Azure.Analytics.OnlineExperimentation/tests/Azure.Analytics.OnlineExperimentation.Tests.csproj",
        "sdk/openai/Azure.AI.OpenAI.Assistants/tests/Azure.AI.OpenAI.Assistants.Tests.csproj",
        "sdk/openai/Azure.AI.OpenAI/tests/Azure.AI.OpenAI.Tests.csproj",
        "sdk/openai/tools/TestFramework/tests/OpenAI.TestFramework.Tests.csproj",
        "sdk/personalizer/Azure.AI.Personalizer/tests/Azure.AI.Personalizer.Tests.csproj",
        "sdk/planetarycomputer/Azure.Analytics.PlanetaryComputer/tests/Azure.Analytics.PlanetaryComputer.Tests.csproj",
        "sdk/purview/Azure.Analytics.Purview.Account/tests/Azure.Analytics.Purview.Account.Tests.csproj",
        "sdk/purview/Azure.Analytics.Purview.Administration/tests/Azure.Analytics.Purview.Administration.Tests.csproj",
        "sdk/purview/Azure.Analytics.Purview.Catalog/tests/Azure.Analytics.Purview.Catalog.Tests.csproj",
        "sdk/purview/Azure.Analytics.Purview.DataMap/tests/Azure.Analytics.Purview.DataMap.Tests.csproj",
        "sdk/purview/Azure.Analytics.Purview.Scanning/tests/Azure.Analytics.Purview.Scanning.Tests.csproj",
        "sdk/purview/Azure.Analytics.Purview.Sharing/tests/Azure.Analytics.Purview.Sharing.Tests.csproj",
        "sdk/purview/Azure.Analytics.Purview.Workflows/tests/Azure.Analytics.Purview.Workflows.Tests.csproj",
        "sdk/quantum/Azure.Quantum.Jobs/tests/Azure.Quantum.Jobs.Tests.csproj",
        "sdk/schemaregistry/Azure.Data.SchemaRegistry/tests/Azure.Data.SchemaRegistry.Tests.csproj",
        "sdk/schemaregistry/Microsoft.Azure.Data.SchemaRegistry.ApacheAvro/tests/Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests.csproj",
        "sdk/search/Azure.ResourceManager.Search/tests/Azure.ResourceManager.Search.Tests.csproj",
        "sdk/search/Azure.Search.Documents/perf/Azure.Search.Documents.Perf/Azure.Search.Documents.Perf.csproj",
        "sdk/search/Azure.Search.Documents/tests/Azure.Search.Documents.Tests.csproj",
        "sdk/servicebus/Azure.Messaging.ServiceBus/tests/Azure.Messaging.ServiceBus.Tests.csproj",
        "sdk/servicebus/Microsoft.Azure.WebJobs.Extensions.ServiceBus/tests/Microsoft.Azure.WebJobs.Extensions.ServiceBus.Tests.csproj",
        "sdk/storage/Azure.Storage.Blobs/perf/Azure.Storage.Blobs.Perf/Azure.Storage.Blobs.Perf.csproj",
        "sdk/storage/Azure.Storage.Blobs/perf/Microsoft.Azure.Storage.Blob.Perf/Microsoft.Azure.Storage.Blob.Perf.csproj",
        "sdk/storage/Azure.Storage.Blobs/tests/Azure.Storage.Blobs.Tests.csproj",
        "sdk/storage/Azure.Storage.Common/tests/Azure.Storage.Common.Tests.csproj",
        "sdk/storage/Azure.Storage.DataMovement.Blobs.Files.Shares/tests/Azure.Storage.DataMovement.Blobs.Files.Shares.Tests.csproj",
        "sdk/storage/Azure.Storage.DataMovement.Blobs/perf/Azure.Storage.DataMovement.Blobs.Perf/Azure.Storage.DataMovement.Blobs.Perf.csproj",
        "sdk/storage/Azure.Storage.DataMovement.Blobs/perf/Microsoft.Azure.Storage.DataMovement.Perf/Microsoft.Azure.Storage.DataMovement.Perf.csproj",
        "sdk/storage/Azure.Storage.DataMovement.Blobs/tests/Azure.Storage.DataMovement.Blobs.Tests.csproj",
        "sdk/storage/Azure.Storage.DataMovement.Files.Shares/tests/Azure.Storage.DataMovement.Files.Shares.Tests.csproj",
        "sdk/storage/Azure.Storage.DataMovement/tests/Azure.Storage.DataMovement.Tests.csproj",
        "sdk/storage/Azure.Storage.Files.DataLake/perf/Azure.Storage.Files.DataLake.Perf/Azure.Storage.Files.DataLake.Perf.csproj",
        "sdk/storage/Azure.Storage.Files.DataLake/tests/Azure.Storage.Files.DataLake.Tests.csproj",
        "sdk/storage/Azure.Storage.Files.Shares/perf/Azure.Storage.Files.Shares.Perf/Azure.Storage.Files.Shares.Perf.csproj",
        "sdk/storage/Azure.Storage.Files.Shares/perf/Microsoft.Azure.Storage.File.Perf/Microsoft.Azure.Storage.File.Perf.csproj",
        "sdk/storage/Azure.Storage.Files.Shares/tests/Azure.Storage.Files.Shares.Tests.csproj",
        "sdk/storage/Azure.Storage.Internal.Avro/tests/Azure.Storage.Internal.Avro.Tests.csproj",
        "sdk/storage/Azure.Storage.Queues/tests/Azure.Storage.Queues.Tests.csproj",
        "sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs/tests/Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Tests.csproj",
        "sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Common/tests/Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests.csproj",
        "sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Queues/tests/Microsoft.Azure.WebJobs.Extensions.Storage.Queues.Tests.csproj",
        "sdk/storage/Microsoft.Azure.WebJobs.Extensions.Storage.Scenario.Tests/tests/Microsoft.Azure.WebJobs.Extensions.Storage.Scenario.Tests.csproj",
        "sdk/synapse/Azure.Analytics.Synapse.AccessControl/tests/Azure.Analytics.Synapse.AccessControl.Tests.csproj",
        "sdk/synapse/Azure.Analytics.Synapse.Artifacts/tests/Azure.Analytics.Synapse.Artifacts.Tests.csproj",
        "sdk/synapse/Azure.Analytics.Synapse.ManagedPrivateEndpoints/tests/Azure.Analytics.Synapse.ManagedPrivateEndpoints.Tests.csproj",
        "sdk/synapse/Azure.Analytics.Synapse.Monitoring/tests/Azure.Analytics.Synapse.Monitoring.Tests.csproj",
        "sdk/synapse/Azure.Analytics.Synapse.Spark/tests/Azure.Analytics.Synapse.Spark.Tests.csproj",
        "sdk/tables/Azure.Data.Tables/tests/Azure.Data.Tables.Tests.csproj",
        "sdk/tables/Microsoft.Azure.WebJobs.Extensions.Tables/tests/Microsoft.Azure.WebJobs.Extensions.Tables.Tests.csproj",
        "sdk/template/Azure.Template/tests/Azure.Template.Tests.csproj",
        "sdk/textanalytics/Azure.AI.TextAnalytics/tests/Azure.AI.TextAnalytics.Tests.csproj",
        "sdk/timeseriesinsights/Azure.IoT.TimeSeriesInsights/tests/Azure.IoT.TimeSeriesInsights.Tests.csproj",
        "sdk/translation/Azure.AI.Translation.Document/tests/Azure.AI.Translation.Document.Tests.csproj",
        "sdk/translation/Azure.AI.Translation.Text/tests/Azure.AI.Translation.Text.Tests.csproj",
        "sdk/videoanalyzer/Azure.Media.VideoAnalyzer.Edge/tests/Azure.Media.VideoAnalyzer.Edge.Tests.csproj",
        "sdk/vision/Azure.AI.Vision.ImageAnalysis/tests/Azure.AI.Vision.ImageAnalysis.Tests.csproj",
        "sdk/webpubsub/Azure.Messaging.WebPubSub.Client/tests/Azure.Messaging.WebPubSub.Client.Tests.csproj",
        "sdk/webpubsub/Azure.Messaging.WebPubSub/tests/Azure.Messaging.WebPubSub.Tests.csproj",
        "sdk/webpubsub/Microsoft.Azure.WebJobs.Extensions.WebPubSub/tests/Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests.csproj",
        "sdk/webpubsub/Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO/tests/Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests.csproj",
        "sdk/webpubsub/Microsoft.Azure.WebPubSub.AspNetCore/tests/Microsoft.Azure.WebPubSub.AspNetCore.Tests.csproj"
    )
    
    Write-Host "Found $($csprojFiles.Count) .csproj files to revert" -ForegroundColor Yellow
    Write-Host ""
    
    $revertedCount = 0
    $failedCount = 0
    
    foreach ($file in $csprojFiles) {
        if ($DryRun) {
            Write-Host "  [DRY RUN] Would revert: $file" -ForegroundColor Gray
            $revertedCount++
        }
        else {
            Write-Host "  Reverting: $file" -ForegroundColor Green
            
            try {
                git checkout origin/main -- $file
                
                if ($LASTEXITCODE -eq 0) {
                    $revertedCount++
                }
                else {
                    Write-Warning "  Failed to revert: $file (Exit code: $LASTEXITCODE)"
                    $failedCount++
                }
            }
            catch {
                Write-Warning "  Error reverting $file : $_"
                $failedCount++
            }
        }
    }
    
    Write-Host ""
    Write-Host "========================================" -ForegroundColor Cyan
    Write-Host "Summary:" -ForegroundColor Cyan
    Write-Host "  Files reverted: $revertedCount" -ForegroundColor Green
    
    if ($failedCount -gt 0) {
        Write-Host "  Files failed: $failedCount" -ForegroundColor Red
    }
    
    if ($DryRun) {
        Write-Host ""
        Write-Host "DRY RUN: No files were modified" -ForegroundColor Yellow
    }
    else {
        Write-Host ""
        Write-Host "Note: Don't forget to stage the reverted files if needed." -ForegroundColor Yellow
    }
}
finally {
    Pop-Location
}
