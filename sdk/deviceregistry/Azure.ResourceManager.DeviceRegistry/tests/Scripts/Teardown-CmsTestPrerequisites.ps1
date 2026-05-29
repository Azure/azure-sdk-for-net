#Requires -Version 7.0
<#
.SYNOPSIS
    Deletes prerequisite Azure resources created for the DeviceRegistryCredentialsAndPoliciesFlowTest scenario tests.

.DESCRIPTION
    This script deletes resources in reverse dependency order for BOTH 'sync' and 'async' test variants:
    1. DPS-to-Hub link
    2. DPS
    3. IoT Hub
    4. ADR Namespace
    5. Managed Identity
    6. Resource Group (deletes everything remaining)

.PARAMETER SubscriptionId
    The Azure subscription ID. Defaults to the value used in the test code.

.PARAMETER Suffix
    The suffix to use ('sync', 'async', or 'both'). Defaults to 'both'.

.PARAMETER Iteration
    Required iteration number (1, 2, 3, ...) appended to the suffix.
    Must match the iteration used during setup.

.PARAMETER Force
    Skip all confirmation prompts and delete everything.

.EXAMPLE
    ./Teardown-CmsTestPrerequisites.ps1 -Iteration 1
    ./Teardown-CmsTestPrerequisites.ps1 -Suffix sync -Iteration 1
    ./Teardown-CmsTestPrerequisites.ps1 -Suffix async -Iteration 2
    ./Teardown-CmsTestPrerequisites.ps1 -Iteration 3 -Force
#>

# Example call (Force skips all prompts):
#   .\Teardown-CmsTestPrerequisites.ps1 -Suffix sync -Iteration 1 -Force

param(
    [string]$SubscriptionId = "53cd450b-b108-4e6e-b048-f63c1dcc8c8f",
    [ValidateSet("sync", "async", "both")]
    [string]$Suffix = "both",
    [Parameter(Mandatory = $true)]
    [int]$Iteration,
    [switch]$Force
)

$ErrorActionPreference = "Stop"

function Confirm-Step {
    param([string]$Message)
    if ($Force) { return $true }
    Write-Host ""
    Write-Host ">>> $Message" -ForegroundColor Cyan
    $response = Read-Host "    Press Y to continue, N to skip, Q to quit [Y/n/q]"
    if ($response -eq "Q" -or $response -eq "q") {
        Write-Host "Aborted." -ForegroundColor Red
        exit 1
    }
    return ($response -ne "N" -and $response -ne "n")
}

function Remove-ResourceSafe {
    param(
        [string]$Description,
        [scriptblock]$Command
    )
    try {
        Write-Host "    Deleting $Description..." -ForegroundColor Yellow
        & $Command
        if ($LASTEXITCODE -eq 0) {
            Write-Host "    ✓ $Description deleted" -ForegroundColor Green
        } else {
            Write-Host "    ⚠ $Description may not exist or deletion returned non-zero" -ForegroundColor DarkYellow
        }
    } catch {
        Write-Host "    ⚠ $Description - skipped (may not exist): $_" -ForegroundColor DarkYellow
    }
}

function Teardown-ForSuffix {
    param([string]$suffix)

    $ResourceGroup = "adr-sdk-test-cms-$suffix"
    $UserIdentity = "cms-test-uami-$suffix"
    $NamespaceName = "cms-test-namespace-$suffix"
    $HubName = "adr-sdk-cms-test-hub-$suffix"
    $DpsName = "adr-sdk-cms-test-dps-$suffix"

    Write-Host ""
    Write-Host "============================================================" -ForegroundColor Yellow
    Write-Host " Tearing down resources for suffix: '$suffix'" -ForegroundColor Yellow
    Write-Host "============================================================" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "  Resource Group:    $ResourceGroup"
    Write-Host "  Managed Identity:  $UserIdentity"
    Write-Host "  ADR Namespace:     $NamespaceName"
    Write-Host "  IoT Hub:           $HubName"
    Write-Host "  DPS:               $DpsName"
    Write-Host ""

    # Check if RG exists first
    $rgExists = az group exists --name $ResourceGroup --subscription $SubscriptionId 2>$null
    if ($rgExists -ne "true") {
        Write-Host "  Resource group '$ResourceGroup' does not exist. Skipping." -ForegroundColor DarkYellow
        return
    }

    # Step 1: Unlink Hub from DPS
    if (Confirm-Step "Step 1: Unlink IoT Hub '$HubName' from DPS '$DpsName'") {
        Remove-ResourceSafe -Description "DPS-Hub link" -Command {
            az iot dps linked-hub delete `
                --dps-name $DpsName `
                --resource-group $ResourceGroup `
                --subscription $SubscriptionId `
                --linked-hub $HubName `
                --only-show-errors 2>$null
        }
    }

    # Step 2: Delete DPS
    if (Confirm-Step "Step 2: Delete DPS '$DpsName'") {
        Remove-ResourceSafe -Description "DPS '$DpsName'" -Command {
            az iot dps delete `
                --name $DpsName `
                --resource-group $ResourceGroup `
                --subscription $SubscriptionId `
                --only-show-errors 2>$null
        }
    }

    # Step 3: Delete IoT Hub
    if (Confirm-Step "Step 3: Delete IoT Hub '$HubName'") {
        Remove-ResourceSafe -Description "IoT Hub '$HubName'" -Command {
            az iot hub delete `
                --name $HubName `
                --resource-group $ResourceGroup `
                --subscription $SubscriptionId `
                --only-show-errors 2>$null
        }
    }

    # Step 4: Delete ADR Namespace
    if (Confirm-Step "Step 4: Delete ADR Namespace '$NamespaceName'") {
        Remove-ResourceSafe -Description "ADR Namespace '$NamespaceName'" -Command {
            az iot adr ns delete `
                --name $NamespaceName `
                --resource-group $ResourceGroup `
                --subscription $SubscriptionId `
                --only-show-errors `
                --yes 2>$null
        }
    }

    # Step 5: Delete Managed Identity
    if (Confirm-Step "Step 5: Delete Managed Identity '$UserIdentity'") {
        Remove-ResourceSafe -Description "Managed Identity '$UserIdentity'" -Command {
            az identity delete `
                --name $UserIdentity `
                --resource-group $ResourceGroup `
                --subscription $SubscriptionId 2>$null
        }
    }

    # Step 6: Delete Resource Group (cleans up everything remaining)
    if (Confirm-Step "Step 6: Delete Resource Group '$ResourceGroup' (this will delete ALL remaining resources)") {
        Write-Host "    Deleting resource group '$ResourceGroup' (this may take a few minutes)..." -ForegroundColor Yellow
        az group delete `
            --name $ResourceGroup `
            --subscription $SubscriptionId `
            --yes `
            --no-wait
        Write-Host "    ✓ Resource group deletion initiated (--no-wait)" -ForegroundColor Green
    }

    Write-Host ""
    Write-Host "============================================================" -ForegroundColor Green
    Write-Host " ✓ Teardown complete for suffix: '$suffix'" -ForegroundColor Green
    Write-Host "============================================================" -ForegroundColor Green
}

# Main
Write-Host ""
Write-Host "================================================================" -ForegroundColor Red
Write-Host " DeviceRegistry CMS Test Prerequisites TEARDOWN" -ForegroundColor Red
Write-Host "================================================================" -ForegroundColor Red
Write-Host ""
Write-Host "This script DELETES prerequisite resources for the" -ForegroundColor White
Write-Host "DeviceRegistryCredentialsAndPoliciesFlowTest scenario tests." -ForegroundColor White
Write-Host ""

if (-not $Force) {
    Write-Host "⚠  WARNING: This will permanently delete Azure resources!" -ForegroundColor Red
    Write-Host ""
    $confirm = Read-Host "Are you sure you want to proceed? [y/N]"
    if ($confirm -ne "Y" -and $confirm -ne "y") {
        Write-Host "Aborted." -ForegroundColor Red
        exit 0
    }
}

# Verify az cli login
Write-Host ""
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

$suffixes = if ($Suffix -eq "both") { @("sync", "async") } else { @($Suffix) }
$iterationSuffix = if ($Iteration -gt 0) { "$Iteration" } else { "" }

foreach ($s in $suffixes) {
    $fullSuffix = "${s}${iterationSuffix}"
    Teardown-ForSuffix -suffix $fullSuffix
}

Write-Host ""
Write-Host "Teardown complete." -ForegroundColor Green
Write-Host "Note: Resource group deletions run with --no-wait." -ForegroundColor DarkGray
Write-Host "Check the Azure portal to confirm deletion is complete." -ForegroundColor DarkGray
Write-Host ""
