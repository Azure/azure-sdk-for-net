#Requires -Version 7.0
<#
.SYNOPSIS
    Creates prerequisite Azure resources for the DeviceRegistryCredentialsAndPoliciesFlowTest scenario tests.

.DESCRIPTION
    This script creates the following resources for BOTH 'sync' and 'async' test variants:
    - Resource Group
    - User-Assigned Managed Identity (UAMI)
    - ADR Namespace
    - Role assignments for UAMI on Namespace
    - IoT Hub (GEN2) with ADR Integration
    - DPS with ADR Integration
    - DPS-to-Hub link

    The test itself creates and cleans up Credentials and Policies during execution.

.PARAMETER SubscriptionId
    The Azure subscription ID. Defaults to the value used in the test code.

.PARAMETER Location
    The Azure region. Defaults to 'eastus2euap'.

.PARAMETER Suffix
    The suffix to use ('sync', 'async', or 'both'). Defaults to 'both'.

.PARAMETER Iteration
    Required iteration number (1, 2, 3, ...) appended to the suffix.
    Useful when you need to create multiple sets of resources (e.g., after a failed run).
    When set, resource names use suffix like 'sync2', 'async3', etc.
    NOTE: The test code must also be updated to match the iteration suffix.

.PARAMETER NoPrompt
    Skip all "Press Y to continue" prompts and run all steps automatically.

.EXAMPLE
    ./Setup-CmsTestPrerequisites.ps1 -Iteration 1
    ./Setup-CmsTestPrerequisites.ps1 -Suffix sync -Iteration 1
    ./Setup-CmsTestPrerequisites.ps1 -Suffix async -Iteration 2
    ./Setup-CmsTestPrerequisites.ps1 -Iteration 3 -NoPrompt
#>

# Example call:
#   .\Setup-CmsTestPrerequisites.ps1 -Suffix sync -Iteration 1 -NoPrompt

param(
    [string]$SubscriptionId = "53cd450b-b108-4e6e-b048-f63c1dcc8c8f",
    [string]$Location = "eastus2euap",
    [ValidateSet("sync", "async", "both")]
    [string]$Suffix = "both",
    [Parameter(Mandatory = $true)]
    [int]$Iteration,
    [switch]$NoPrompt
)

$ErrorActionPreference = "Stop"

# ADR RP Service Principal ID (for Contributor role on RG)
$AdrServicePrincipalId = "89d10474-74af-4874-99a7-c23c2f643083"

# Role GUIDs
$AdrContributorRoleId = "a5c3590a-3a1a-4cd4-9648-ea0a32b15137"
$AdrReaderRoleId = "547f7f0a-69c0-4807-bd9e-0321dfb66a84"

function Confirm-Step {
    param([string]$Message)
    if ($NoPrompt) {
        Write-Host ""
        Write-Host ">>> $Message" -ForegroundColor Cyan
        return $true
    }
    Write-Host ""
    Write-Host ">>> $Message" -ForegroundColor Cyan
    $response = Read-Host "    Press Y to continue, N to skip, Q to quit [Y/n/q]"
    if ($response -eq "Q" -or $response -eq "q") {
        Write-Host "Aborted." -ForegroundColor Red
        exit 1
    }
    return ($response -ne "N" -and $response -ne "n")
}

function Setup-ForSuffix {
    param([string]$suffix)

    $ResourceGroup = "adr-sdk-test-cms-$suffix"
    $UserIdentity = "cms-test-uami-$suffix"
    $NamespaceName = "cms-test-namespace-$suffix"
    $HubName = "adr-sdk-cms-test-hub-$suffix"
    $DpsName = "adr-sdk-cms-test-dps-$suffix"

    Write-Host ""
    Write-Host "============================================================" -ForegroundColor Yellow
    Write-Host " Setting up resources for suffix: '$suffix'" -ForegroundColor Yellow
    Write-Host "============================================================" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "  Subscription:      $SubscriptionId"
    Write-Host "  Location:          $Location"
    Write-Host "  Resource Group:    $ResourceGroup"
    Write-Host "  Managed Identity:  $UserIdentity"
    Write-Host "  ADR Namespace:     $NamespaceName"
    Write-Host "  IoT Hub:           $HubName"
    Write-Host "  DPS:               $DpsName"
    Write-Host ""

    # Step 1: Create Resource Group
    if (Confirm-Step "Step 1: Create Resource Group '$ResourceGroup'") {
        Write-Host "    Creating resource group..." -ForegroundColor Green
        az group create --name $ResourceGroup --location $Location --subscription $SubscriptionId --output table
        if ($LASTEXITCODE -ne 0) { Write-Error "Failed to create resource group"; return }

        $rgScope = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroup"
        Write-Host "    Assigning Contributor role to ADR Service Principal..." -ForegroundColor Green
        az role assignment create --assignee $AdrServicePrincipalId --role Contributor --scope $rgScope --output table 2>$null
        Write-Host "    ✓ Resource group created and role assigned" -ForegroundColor Green
    }

    # Step 2: Create User-Assigned Managed Identity
    if (Confirm-Step "Step 2: Create Managed Identity '$UserIdentity'") {
        Write-Host "    Creating managed identity..." -ForegroundColor Green
        az identity create --name $UserIdentity --resource-group $ResourceGroup --location $Location --subscription $SubscriptionId --output table
        if ($LASTEXITCODE -ne 0) { Write-Error "Failed to create managed identity"; return }
        Write-Host "    ✓ Managed identity created" -ForegroundColor Green
    }

    # Step 3: Create ADR Namespace
    if (Confirm-Step "Step 3: Create ADR Namespace '$NamespaceName'") {
        Write-Host "    Creating ADR namespace (this may take a few minutes)..." -ForegroundColor Green
        az iot adr ns create --name $NamespaceName --resource-group $ResourceGroup --location $Location --subscription $SubscriptionId --output table --only-show-errors
        if ($LASTEXITCODE -ne 0) { Write-Error "Failed to create ADR namespace"; return }
        Write-Host "    ✓ ADR namespace created" -ForegroundColor Green
    }

    # Step 4: Assign roles to UAMI on Namespace
    if (Confirm-Step "Step 4: Assign ADR roles to Managed Identity on Namespace") {
        $NamespaceResourceId = az iot adr ns show --name $NamespaceName --resource-group $ResourceGroup --subscription $SubscriptionId --query id -o tsv --only-show-errors
        if ($LASTEXITCODE -ne 0) { Write-Error "Failed to get namespace resource ID"; return }

        $UamiResourceId = az identity show --name $UserIdentity --resource-group $ResourceGroup --subscription $SubscriptionId --query id -o tsv --only-show-errors
        $UamiPrincipalId = az identity show --name $UserIdentity --resource-group $ResourceGroup --subscription $SubscriptionId --query principalId -o tsv --only-show-errors
        if ($LASTEXITCODE -ne 0) { Write-Error "Failed to get UAMI details"; return }

        Write-Host "    Namespace ID: $NamespaceResourceId" -ForegroundColor DarkGray
        Write-Host "    UAMI Principal ID: $UamiPrincipalId" -ForegroundColor DarkGray

        Write-Host "    Assigning ADR Contributor role..." -ForegroundColor Green
        az role assignment create --assignee "$UamiPrincipalId" --role $AdrContributorRoleId --scope "$NamespaceResourceId" --output table 2>$null

        Write-Host "    Assigning ADR Reader role..." -ForegroundColor Green
        az role assignment create --assignee "$UamiPrincipalId" --role $AdrReaderRoleId --scope "$NamespaceResourceId" --output table 2>$null

        Write-Host "    ✓ Role assignments created" -ForegroundColor Green
    }

    # Step 5: Create IoT Hub with ADR Integration
    if (Confirm-Step "Step 5: Create IoT Hub '$HubName' with ADR Integration (this takes several minutes)") {
        $NamespaceResourceId = az iot adr ns show --name $NamespaceName --resource-group $ResourceGroup --subscription $SubscriptionId --query id -o tsv --only-show-errors
        $UamiResourceId = az identity show --name $UserIdentity --resource-group $ResourceGroup --subscription $SubscriptionId --query id -o tsv --only-show-errors

        Write-Host "    Creating IoT Hub (GEN2 SKU)..." -ForegroundColor Green
        az iot hub create `
            --name "$HubName" `
            --resource-group "$ResourceGroup" `
            --location "$Location" `
            --subscription "$SubscriptionId" `
            --sku GEN2 `
            --mi-user-assigned "$UamiResourceId" `
            --ns-resource-id "$NamespaceResourceId" `
            --ns-identity-id "$UamiResourceId" `
            --output table `
            --only-show-errors
        if ($LASTEXITCODE -ne 0) { Write-Error "Failed to create IoT Hub"; return }
        Write-Host "    ✓ IoT Hub created with ADR integration" -ForegroundColor Green
    }

    # Step 6: Create DPS with ADR Integration
    if (Confirm-Step "Step 6: Create DPS '$DpsName' with ADR Integration") {
        $NamespaceResourceId = az iot adr ns show --name $NamespaceName --resource-group $ResourceGroup --subscription $SubscriptionId --query id -o tsv --only-show-errors
        $UamiResourceId = az identity show --name $UserIdentity --resource-group $ResourceGroup --subscription $SubscriptionId --query id -o tsv --only-show-errors

        Write-Host "    Creating DPS..." -ForegroundColor Green
        az iot dps create `
            --name "$DpsName" `
            --resource-group "$ResourceGroup" `
            --location "$Location" `
            --subscription "$SubscriptionId" `
            --mi-user-assigned "$UamiResourceId" `
            --ns-resource-id "$NamespaceResourceId" `
            --ns-identity-id "$UamiResourceId" `
            --output table `
            --only-show-errors
        if ($LASTEXITCODE -ne 0) { Write-Error "Failed to create DPS"; return }
        Write-Host "    ✓ DPS created with ADR integration" -ForegroundColor Green
    }

    # Step 7: Link Hub to DPS
    if (Confirm-Step "Step 7: Link IoT Hub '$HubName' to DPS '$DpsName'") {
        Write-Host "    Linking Hub to DPS..." -ForegroundColor Green
        az iot dps linked-hub create `
            --dps-name "$DpsName" `
            --resource-group "$ResourceGroup" `
            --subscription "$SubscriptionId" `
            --hub-name "$HubName" `
            --output table `
            --only-show-errors
        if ($LASTEXITCODE -ne 0) { Write-Error "Failed to link Hub to DPS"; return }
        Write-Host "    ✓ Hub linked to DPS" -ForegroundColor Green
    }

    Write-Host ""
    Write-Host "============================================================" -ForegroundColor Green
    Write-Host " ✓ Setup complete for suffix: '$suffix'" -ForegroundColor Green
    Write-Host "============================================================" -ForegroundColor Green
}

# Main
Write-Host ""
Write-Host "================================================================" -ForegroundColor Magenta
Write-Host " DeviceRegistry CMS Test Prerequisites Setup" -ForegroundColor Magenta
Write-Host "================================================================" -ForegroundColor Magenta
Write-Host ""
Write-Host "This script creates prerequisite resources for the" -ForegroundColor White
Write-Host "DeviceRegistryCredentialsAndPoliciesFlowTest scenario tests." -ForegroundColor White
Write-Host ""

# Verify az cli login
Write-Host "Checking Azure CLI login status..." -ForegroundColor DarkGray
$account = az account show --query "{name:name, id:id}" -o tsv 2>$null
if ($LASTEXITCODE -ne 0) {
    Write-Error "Not logged in to Azure CLI. Run 'az login' first."
    exit 1
}
Write-Host "  Logged in: $account" -ForegroundColor DarkGray

# Set subscription
az account set --subscription $SubscriptionId
Write-Host "  Subscription set to: $SubscriptionId" -ForegroundColor DarkGray

# Check for azure-iot extension
$iotExt = az extension show --name azure-iot --query version -o tsv 2>$null
if ($LASTEXITCODE -ne 0) {
    Write-Host "  WARNING: 'azure-iot' CLI extension not found. Install with:" -ForegroundColor Red
    Write-Host "    az extension add --name azure-iot --allow-preview true" -ForegroundColor Yellow
    exit 1
}
Write-Host "  azure-iot extension version: $iotExt" -ForegroundColor DarkGray

$suffixes = if ($Suffix -eq "both") { @("sync", "async") } else { @($Suffix) }
$iterationSuffix = if ($Iteration -gt 0) { "$Iteration" } else { "" }

foreach ($s in $suffixes) {
    $fullSuffix = "${s}${iterationSuffix}"
    Setup-ForSuffix -suffix $fullSuffix
}

if ($Iteration -gt 0) {
    Write-Host ""
    Write-Host "⚠  IMPORTANT: You used -Iteration $Iteration" -ForegroundColor Yellow
    Write-Host "   Resource names use suffix like 'sync$Iteration' / 'async$Iteration'." -ForegroundColor Yellow
    Write-Host "   Ensure your test's resource name construction uses the same suffix pattern" -ForegroundColor Yellow
    Write-Host "   (for example, update the test's Iteration constant or suffix composition so that" -ForegroundColor Yellow
    Write-Host "   names end with 'sync$Iteration' / 'async$Iteration' as created by this script)." -ForegroundColor Yellow
    Write-Host ""
}

Write-Host ""
Write-Host "All done! You can now run the tests in Record mode:" -ForegroundColor Cyan
Write-Host '  $env:AZURE_TEST_MODE = "Record"' -ForegroundColor White
Write-Host '  $env:AZURE_SUBSCRIPTION_ID = "53cd450b-b108-4e6e-b048-f63c1dcc8c8f"' -ForegroundColor White
Write-Host '  $env:AZURE_TENANT_ID = "<your-tenant-id>"' -ForegroundColor White
Write-Host '  $env:AZURE_AUTHORITY_HOST = "https://login.microsoftonline.com"' -ForegroundColor White
Write-Host ""
