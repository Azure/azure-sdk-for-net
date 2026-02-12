#!/usr/bin/env pwsh
# Post-generation script: runs Export-API.ps1 and Update-Snippets.ps1 for each affected service SDK.
# Usage: pwsh ./run-post-generation.ps1

$ErrorActionPreference = 'Continue'
$repoRoot = $PSScriptRoot

$services = @(
    "advisor"
    "agricultureplatform"
    "appcomplianceautomation"
    "arizeaiobservabilityeval"
    "astronomer"
    "avs"
    "azurelargeinstance"
    "azurestackhci"
    "carbon"
    "chaos"
    "cloudhealth"
    "computefleet"
    "computelimit"
    "computerecommender"
    "computeschedule"
    "connectedcache"
    "containerorchestratorruntime"
    "databasewatcher"
    "databox"
    "dellstorage"
    "dependencymap"
    "deviceprovisioningservices"
    "deviceregistry"
    "devopsinfrastructure"
    "disconnectedoperations"
    "durabletask"
    "dynatrace"
    "edgeactions"
    "edgeorder"
    "edgezones"
    "elastic"
    "elasticsan"
    "fabric"
    "fileshares"
    "grafana"
    "hardwaresecuritymodules"
    "healthbot"
    "healthdataaiservices"
    "hybridconnectivity"
    "hybridkubernetes"
    "impactreporting"
    "informaticadatamanagement"
    "iotoperations"
    "keyvault"
    "lambdatesthyperexecute"
    "loadtestservice"
    "mongocluster"
    "mongodbatlas"
    "mysql"
    "neonpostgres"
    "nginx"
    "onlineexperimentation"
    "oracle"
    "paloaltonetworks.ngfw"
    "pineconevectordb"
    "planetarycomputer"
    "playwright"
    "portalservices"
    "powerbidedicated"
    "purestorageblock"
    "quantum"
    "qumulo"
    "quota"
    "recoveryservices"
    "recoveryservices-datareplication"
    "resourceconnector"
    "resources"
    "secretsstoreextension"
    "selfhelp"
    "servicefabricmanagedclusters"
    "servicenetworking"
    "signalr"
    "sitemanager"
    "sqlvirtualmachine"
    "standbypool"
    "storageactions"
    "storagediscovery"
    "storagemover"
    "storagesync"
    "terraform"
    "trustedsigning"
    "virtualenclaves"
    "weightsandbiases"
    "workloadorchestration"
    "workloadssapvirtualinstance"
)

$exportApiScript = Join-Path $repoRoot "eng/scripts/Export-API.ps1"
$updateSnippetsScript = Join-Path $repoRoot "eng/scripts/Update-Snippets.ps1"

$total = $services.Count
$current = 0
$exportApiFailed = @()
$updateSnippetsFailed = @()

foreach ($service in $services) {
    $current++
    Write-Host ""
    Write-Host "======================================" -ForegroundColor Cyan
    Write-Host "[$current/$total] Processing: $service" -ForegroundColor Cyan
    Write-Host "======================================" -ForegroundColor Cyan

    # --- Export-API ---
    Write-Host "  Running Export-API.ps1 for $service..." -ForegroundColor Yellow
    try {
        & $exportApiScript $service
        if ($LASTEXITCODE -ne 0) {
            Write-Host "  [WARN] Export-API.ps1 returned exit code $LASTEXITCODE for $service" -ForegroundColor Red
            $exportApiFailed += $service
        } else {
            Write-Host "  [OK] Export-API.ps1 succeeded for $service" -ForegroundColor Green
        }
    } catch {
        Write-Host "  [ERROR] Export-API.ps1 failed for $service : $_" -ForegroundColor Red
        $exportApiFailed += $service
    }

    # --- Update-Snippets ---
    Write-Host "  Running Update-Snippets.ps1 for $service..." -ForegroundColor Yellow
    try {
        & $updateSnippetsScript $service
        if ($LASTEXITCODE -ne 0) {
            Write-Host "  [WARN] Update-Snippets.ps1 returned exit code $LASTEXITCODE for $service" -ForegroundColor Red
            $updateSnippetsFailed += $service
        } else {
            Write-Host "  [OK] Update-Snippets.ps1 succeeded for $service" -ForegroundColor Green
        }
    } catch {
        Write-Host "  [ERROR] Update-Snippets.ps1 failed for $service : $_" -ForegroundColor Red
        $updateSnippetsFailed += $service
    }
}

Write-Host ""
Write-Host "======================================" -ForegroundColor Cyan
Write-Host "Summary" -ForegroundColor Cyan
Write-Host "======================================" -ForegroundColor Cyan
Write-Host "Total services processed: $total"

if ($exportApiFailed.Count -gt 0) {
    Write-Host "Export-API failures ($($exportApiFailed.Count)):" -ForegroundColor Red
    $exportApiFailed | ForEach-Object { Write-Host "  - $_" -ForegroundColor Red }
} else {
    Write-Host "Export-API: all passed" -ForegroundColor Green
}

if ($updateSnippetsFailed.Count -gt 0) {
    Write-Host "Update-Snippets failures ($($updateSnippetsFailed.Count)):" -ForegroundColor Red
    $updateSnippetsFailed | ForEach-Object { Write-Host "  - $_" -ForegroundColor Red }
} else {
    Write-Host "Update-Snippets: all passed" -ForegroundColor Green
}
