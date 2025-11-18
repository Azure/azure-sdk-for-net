<# ==================================================================================================
 CMS Setup - Interactive, Step-by-Step
 - Press Enter to execute the step
 - Press 's' (or 'S') to skip the step
 - Ctrl + C to abort at any time

 Prerequisites:
 - Azure CLI version >= 2.77.0 installed (https://learn.microsoft.com/cli/azure/install-azure-cli)
 - Download the extension .whl file from this link: https://github.com/Azure/digital-ops-cms-tools/releases/download/v0.0.30-dev1/azure_iot-0.0.30.dev1-py3-none-any.whl 
 - Ensure the downloaded files are accessible from the working folder defined in the Variables section below.
 - Replace all occurrences of '<prefix>' in the script with your desired prefix.
 - Ensure you have Contributor access on the target subscription.

Additional Options:
 - By default, this script creates a new Resource Group on your behalf. If you would like to use an existing Resource Group, please follow the steps here:
        1. Include the name of that existing Resource Group under the variable $ResourceGroup
        2. Comment out Step #5 Create Resource Group

 Notes:
 - Warnings will not terminate the script. We stop only on non-zero exit codes via Stop-OnError.
 - IoT CLI commands require the Azure IoT CLI extension. See Step 6 to (optionally) install it.
================================================================================================== #>

# ---------------------------
# UX & Error Handling Helpers
# ---------------------------
$Host.UI.RawUI.WindowTitle = "IoT Hub Gen 2 Setup - Interactive Guided Run"

# Prefer continuing on warnings; stop only on real (non-zero exit code) errors
$ErrorActionPreference = 'Continue'
if ($PSVersionTable.PSVersion.Major -ge 7) {
    # Ensure native command stderr (e.g., az warnings) doesn't obey ErrorActionPreference as terminating
    $PSNativeCommandUseErrorActionPreference = $false
}

function Stop-OnError {
    param([string]$Step = 'Command')
    if ($LASTEXITCODE -ne 0) {
        Write-Host "ERROR: $Step failed (exit code $LASTEXITCODE)" -ForegroundColor Red
        exit $LASTEXITCODE
    }
}

function Show-Header {
    param([string]$Title)
    Write-Host ''
    Write-Host ('=' * 80)
    Write-Host " $Title" -ForegroundColor Cyan
    Write-Host ('=' * 80)
}

function Show-Step {
    param(
        [int]$Index,
        [int]$Total,
        [string]$Now,
        [string]$Next = ""
    )
    Write-Host ''
    Write-Host ("[Step {0}/{1}] {2}" -f $Index, $Total, $Now) -ForegroundColor Green
    if ($Next) { Write-Host (" Next → {0}" -f $Next) -ForegroundColor DarkGray }
}

function Show-Detail { param([string]$Text)  Write-Host $Text -ForegroundColor Yellow }
function Show-Command { param([string]$Text) Write-Host ("> {0}" -f $Text) -ForegroundColor DarkGray }

# Press Enter to proceed; 's' or 'S' to skip; Ctrl+C abort
function Prompt-Step {
    param([string]$Prompt = "Press Enter to continue, 's' to skip, or Ctrl + C to abort")
    $input = Read-Host -Prompt $Prompt
    if ($input -match '^[sS]$') { Write-Host "Skipped by user." -ForegroundColor Yellow; return $false }
    return $true
}

# ---------------------------
# Variables (adjust if needed)
# ---------------------------
$TenantId        = ''                # eg. 'ab23bf5d-24de-4d7a-b68b-b31995a05d1f'
$SubscriptionId  = ''                      # eg. 'c2cdd8fc-b5b3-4ee4-a9a3-5945e92127d0'

# Resource naming (ATTENTION: update <prefix> to your desired prefix and change 001 as needed)
$ResourceGroup   = ''
$Location        = ''            
$NamespaceName   = ''   #Lowercase and numerals only. Hyphens may be used, provided they are not the first or last character. Ex: msft-nameapace is accpetable
$HubName         = ''         #Lowercase and numerals only. Hyphens may be used, provided they are not the first or last character. Ex: msft-hub is accpetable
$HubLocation     = ''             
$DpsName         = ''         #Lowercase and numerals only. Hyphens may be used, provided they are not the first or last character. Ex: msft-dps is accpetable
$UserIdentity    = ''
$PolicyName      = ''                       
$EnrollmentId    = ''
$WorkingFolder   = ''

# Optional: working folder for your artifacts

# Counters
$totalSteps = 18
$step = 0

Show-Header -Title "IoT Hub Gen 2 with Azure Device Registry (ADR) + Certificate Managenent: Guided Setup"

# ---------------------------
# 0) Before you begin: Confirm that you have the IoT CLI Extension 
# ---------------------------
Show-Step -Index $step -Total $totalSteps -Now "Before you begin: Manage Azure IoT CLI extension" -Next "Navigate to your working folder"
Show-Detail "If IoT CLI commands fail, un-comment and run these:"
Show-Command "# az extension remove --name azure-iot"
Show-Command "# az extension add --name azure-iot"
Show-Command "# az extension show --name azure-iot"
if (Prompt-Step) {
    Write-Host "Leaving extension commands commented by default." -ForegroundColor Gray
} else { Write-Host "Skipping extension step." -ForegroundColor Yellow }

# ---------------------------
# 1) Navigate to working folder
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Navigate to working folder" -Next "Azure login"
Show-Detail "Location: $WorkingFolder"
Show-Command "Set-Location -Path '$WorkingFolder'"
if (Prompt-Step) {
    if (Test-Path -Path $WorkingFolder) {
        Set-Location -Path $WorkingFolder
    } else {
        Write-Host "WARNING: Working folder not found. Staying in $PWD" -ForegroundColor DarkYellow
    }
} else { Write-Host "Skipping folder change." -ForegroundColor Yellow }

# ---------------------------
# 2) Azure Login (tenant-scoped Graph permission)
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Azure Login (tenant-scoped Graph permission)" -Next "Set variables & select subscription"
Show-Detail "A browser may open. Ensure the correct tenant/account is used."
Show-Command "az login --tenant '$TenantId' --scope 'https://graph.microsoft.com//.default' --only-show-errors"
if (Prompt-Step) {
    az login --tenant "$TenantId" --scope "https://graph.microsoft.com//.default" --only-show-errors
    Stop-OnError "Azure login"
} else { Write-Host "Skipping Azure login." -ForegroundColor Yellow }

# ---------------------------
# 3) Environment Variables (set names/IDs)
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Set environment variables" -Next "Select Azure subscription"
Show-Detail "SUBSCRIPTION_ID: $SubscriptionId"
Show-Detail "RESOURCE_GROUP : $ResourceGroup"
Show-Detail "LOCATION       : $Location"
Show-Detail "NAMESPACE      : $NamespaceName"
Show-Detail "POLICY_NAME    : $PolicyName"
Show-Detail "HUB            : $HubName"
Show-Detail "HUB_LOCATION   : $HubLocation"
Show-Detail "DPS            : $DpsName"
Show-Detail "UAMI           : $UserIdentity"
Show-Detail "ENROLLMENT_ID  : $EnrollmentId"
if (Prompt-Step) {
    # No-op. Variables already set above.
    Write-Host "Variables are initialized." -ForegroundColor Gray
} else { Write-Host "Skipping variable confirmation." -ForegroundColor Yellow }

# ---------------------------
# 4) Select Subscription
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Select your subscription" -Next "Create a Resource Group"
Show-Command "az account set --subscription '$SubscriptionId' --only-show-errors"
if (Prompt-Step) {
    az account set --subscription "$SubscriptionId" --only-show-errors
    Stop-OnError "Set active subscription"
    az account show --subscription "$SubscriptionId" --only-show-errors | Out-Null
} else { Write-Host "Skipping subscription selection." -ForegroundColor Yellow }


# ---------------------------
# 5) Create Resource Group
# ---------------------------

$step++; Show-Step -Index $step -Total $totalSteps -Now "Create resource group" -Next "Create a User-Assigned Managed Identity"
Show-Command "az group create --name '$ResourceGroup' --location $Location --only-show-errors"
if (Prompt-Step) {
    az group create --name $ResourceGroup --location $Location --only-show-errors
} else { Write-Host "Skipping subscription selection and resource group creation." -ForegroundColor Yellow }

# ---------------------------
# 7) Assign Contributor to IoT Hub RP Principal at RG scope
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Assign Contributor to IoT Hub RP at RG scope" -Next "Create UAMI"
Show-Detail "IoT Hub RP Principal ID: 89d10474-74af-4874-99a7-c23c2f643083"
$rgScope = "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroup"
Show-Command "az role assignment create --assignee 89d10474-74af-4874-99a7-c23c2f643083 --role Contributor --scope '$rgScope' --only-show-errors"
if (Prompt-Step) {
    az role assignment create --assignee "89d10474-74af-4874-99a7-c23c2f643083" --role "Contributor" --scope "$rgScope" --only-show-errors
    Stop-OnError "Assign Contributor to IoT Hub RP"
} else { Write-Host "Skipping RP role assignment." -ForegroundColor Yellow }

# ---------------------------
# 8) Create User-Assigned Managed Identity (UAMI)
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Create User-Assigned Managed Identity (UAMI)" -Next "Create ADR Namespace"
Show-Command "az identity create --name '$UserIdentity' --resource-group '$ResourceGroup' --location '$Location' --only-show-errors"
if (Prompt-Step) {
    az identity create --name "$UserIdentity" --resource-group "$ResourceGroup" --location "$Location" --only-show-errors
    Stop-OnError "Create UAMI"
    $UamiResourceId = az identity show --name "$UserIdentity" --resource-group "$ResourceGroup" --query id -o tsv --only-show-errors
    Stop-OnError "Get UAMI resource ID"
    $UamiPrincipalId = az identity show --name "$UserIdentity" --resource-group "$ResourceGroup" --query principalId -o tsv --only-show-errors
    Stop-OnError "Get UAMI principal ID"
    Write-Host "UAMI Resource ID : $UamiResourceId" -ForegroundColor Gray
    Write-Host "UAMI Principal ID: $UamiPrincipalId" -ForegroundColor Gray
} else { Write-Host "Skipping UAMI creation." -ForegroundColor Yellow }

# ---------------------------
# 9) Create ADR Namespace & Inspect Defaults
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Create ADR Namespace & inspect defaults" -Next "Assign custom ADR role to UAMI (namespace scope)"
Show-Command "az iot adr ns create --name '$NamespaceName' --enable-credential-policy --resource-group '$ResourceGroup' --location '$Location' --only-show-errors"
if (Prompt-Step) {
    az iot adr ns create --name "$NamespaceName" --enable-credential-policy --resource-group "$ResourceGroup" --location "$Location" --policy-name "$PolicyName" --only-show-errors
    Stop-OnError "Create ADR Namespace"
    $NamespaceResourceId = az iot adr ns show --name "$NamespaceName" --resource-group "$ResourceGroup" --query id -o tsv --only-show-errors
    Stop-OnError "Get ADR Namespace resource ID"
    Write-Host "ADR Namespace Resource ID: $NamespaceResourceId" -ForegroundColor Gray

    # Optional peek at default credentials/policy
    az iot adr ns credential show --ns "$NamespaceName" --resource-group "$ResourceGroup" --only-show-errors
} else { Write-Host "Skipping ADR Namespace creation." -ForegroundColor Yellow }

# ---------------------------
# 10) Assign Azure Device Registry Contributor Role to UAMI on Namespace
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Assign Azure Device Registry Contributor role to UAMI on namespace" -Next "Create IoT Hub (with ADR integration)"
Show-Command "az role assignment create --assignee '$UamiPrincipalId' --role 'Azure Device Registry Onboarding' --scope '$NamespaceResourceId' --only-show-errors"
Show-Command "az role assignment create --assignee '$UamiPrincipalId' --role 'Azure Device Registry Contributor' --scope '$NamespaceResourceId' --only-show-errors"

if (Prompt-Step) {
    az role assignment create --assignee "$UamiPrincipalId" --role "a5c3590a-3a1a-4cd4-9648-ea0a32b15137" --scope "$NamespaceResourceId" --only-show-errors
    az role assignment create --assignee "$UamiPrincipalId" --role "547f7f0a-69c0-4807-bd9e-0321dfb66a84" --scope "$NamespaceResourceId" --only-show-errors

    Stop-OnError "Assign ADR custom role to UAMI"
} else { Write-Host "Skipping ADR-role assignment to UAMI." -ForegroundColor Yellow }

# ---------------------------
# 11) Create IoT Hub with ADR Integration
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Create IoT Hub (Gen2) with ADR integration & UAMI" -Next "Grant ADR principal access on Hub"
Show-Command "az iot hub create --name '$HubName' --resource-group '$ResourceGroup' --location '$HubLocation' --sku GEN2 --mi-user-assigned '$UamiResourceId' --ns-resource-id '$NamespaceResourceId' --ns-identity-id '$UamiResourceId' --query id -o tsv --only-show-errors"
if (Prompt-Step) {
    $HubResourceId = az iot hub create `
        --name "$HubName" `
        --resource-group "$ResourceGroup" `
        --location "$HubLocation" `
        --sku GEN2 `
        --mi-user-assigned "$UamiResourceId" `
        --ns-resource-id "$NamespaceResourceId" `
        --ns-identity-id "$UamiResourceId" `
        --query id -o tsv `
        --only-show-errors
    Stop-OnError "Create IoT Hub with ADR integration"
    Write-Host "IoT Hub Resource ID: $HubResourceId" -ForegroundColor Gray
} else { Write-Host "Skipping IoT Hub creation." -ForegroundColor Yellow }

# ---------------------------
# 12) Manual Role Assignments on Hub for ADR Principal
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Assign Hub roles (Contributor & IoT Hub Registry Contributor) to ADR principal" -Next "Create DPS with ADR"
Show-Command "az role assignment create --assignee '$AdrPrincipalId' --role Contributor --scope '$HubResourceId'"
Show-Command "az role assignment create --assignee '$AdrPrincipalId' --role 'IoT Hub Registry Contributor' --scope '$HubResourceId'"
if (Prompt-Step) {
    $AdrPrincipalId = az iot adr ns show --name "$NamespaceName" --resource-group "$ResourceGroup" --query "identity.principalId" -o tsv --only-show-errors
    Stop-OnError "Get ADR principal ID (from namespace identity)"

    az role assignment create --assignee "$AdrPrincipalId" --role "Contributor" --scope "$HubResourceId" --only-show-errors | Out-Null
    Stop-OnError "Assign Contributor (Hub) to ADR principal"

    az role assignment create --assignee "$AdrPrincipalId" --role "IoT Hub Registry Contributor" --scope "$HubResourceId" --only-show-errors | Out-Null
    Stop-OnError "Assign IoT Hub Registry Contributor (Hub) to ADR principal"
} else { Write-Host "Skipping Hub role assignments." -ForegroundColor Yellow }

# ---------------------------
# 13) Create DPS with ADR Integration
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Create DPS with ADR integration" -Next "Link Hub to DPS"
Show-Command "az iot dps create --name '$DpsName' --resource-group '$ResourceGroup' --location '$Location' --mi-user-assigned '$UamiResourceId' --ns-resource-id '$NamespaceResourceId' --ns-identity-id '$UamiResourceId' --only-show-errors"
if (Prompt-Step) {
    az iot dps create `
        --name "$DpsName" `
        --resource-group "$ResourceGroup" `
        --location "$Location" `
        --mi-user-assigned "$UamiResourceId" `
        --ns-resource-id "$NamespaceResourceId" `
        --ns-identity-id "$UamiResourceId" `
        --only-show-errors
    Stop-OnError "Create DPS with ADR integration"
} else { Write-Host "Skipping DPS creation." -ForegroundColor Yellow }

# ---------------------------
# 14) Link Hub to DPS
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Link IoT Hub to DPS" -Next "Sync ADR credentials"
Show-Command "az iot dps linked-hub create --dps-name '$DpsName' --resource-group '$ResourceGroup' --hub-name '$HubName' --only-show-errors"
if (Prompt-Step) {
    az iot dps linked-hub create --dps-name "$DpsName" --resource-group "$ResourceGroup" --hub-name "$HubName" --only-show-errors
    Stop-OnError "Link Hub to DPS"
} else { Write-Host "Skipping link Hub->DPS." -ForegroundColor Yellow }

# ---------------------------
# 15) Sync ADR Credentials
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Sync ADR credentials" -Next "Validate Hub certificates"
Show-Command "az iot adr ns credential sync --name '$NamespaceName' --resource-group '$ResourceGroup' --only-show-errors"
if (Prompt-Step) {
    az iot adr ns credential sync --ns "$NamespaceName" --resource-group "$ResourceGroup" --only-show-errors
    Stop-OnError "ADR credential sync"
} else { Write-Host "Skipping ADR credential sync." -ForegroundColor Yellow }

# ---------------------------
# 16) Validate Hub Certificate
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Validate IoT Hub certificates" -Next "Useful inspection commands"
Show-Command "az iot hub certificate list --hub-name '$HubName' --resource-group '$ResourceGroup' --only-show-errors"
if (Prompt-Step) {
    az iot hub certificate list --hub-name "$HubName" --resource-group "$ResourceGroup" --only-show-errors
    Stop-OnError "Validate IoT Hub certificates"
} else { Write-Host "Skipping certificate validation." -ForegroundColor Yellow }

# ---------------------------
# 17) Create an enrollment group in DPS
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Create an enrollment group in DPS" -Next "Useful inspection commands"
Show-Command "az iot dps enrollment-group create --dps-name '$DpsName' --resource-group '$ResourceGroup' --enrollment-id '$EnrollmentId' --credential-policy '$PolicyName' --only-show-errors"
if (Prompt-Step) {
    az iot dps enrollment-group create --dps-name $DpsName --resource-group $ResourceGroup --enrollment-id $EnrollmentId --credential-policy $PolicyName
    Stop-OnError "Create an enrollment group in DPS"
} else { Write-Host "Skipping enrollment group creation in DPS." -ForegroundColor Yellow }

# ---------------------------
# 18) Additional Useful Commands (optional)
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Additional ADR inspection commands (optional)" -Next "Undo EUAP workaround / cleanup"
Show-Command "az iot adr ns list --resource-group '$ResourceGroup'"
Show-Command "az iot adr ns show --name '$NamespaceName' --resource-group '$ResourceGroup'"
Show-Command "az iot adr ns credential show --ns '$NamespaceName' --resource-group '$ResourceGroup'"
Show-Command "az iot adr ns policy list --ns '$NamespaceName' --resource-group '$ResourceGroup'"
Show-Command "az iot adr ns policy show --ns '$NamespaceName' --resource-group '$ResourceGroup' --policy-name '$PolicyName'"
if (Prompt-Step) {
    # Non-critical inspection (no Stop-OnError)
    az iot adr ns list --resource-group "$ResourceGroup" --only-show-errors | Out-Null
    az iot adr ns show --name "$NamespaceName" --resource-group "$ResourceGroup" --only-show-errors | Out-Null
    az iot adr ns credential show --ns "$NamespaceName" --resource-group "$ResourceGroup" --only-show-errors | Out-Null
    az iot adr ns policy list --ns "$NamespaceName" --resource-group "$ResourceGroup" --only-show-errors | Out-Null
    az iot adr ns policy show --ns "$NamespaceName" --resource-group "$ResourceGroup" -n $PolicyName --only-show-errors
} else { Write-Host "Skipping inspection commands." -ForegroundColor Yellow }

# ---------------------------
# 29) Optional Cleanup | After runtime steps 
# ---------------------------
$step++; Show-Step -Index $step -Total $totalSteps -Now "Optional cleanup" -Next ""
Show-Detail "Optional cleanup (un-comment to use):"
Show-Command "# az iot adr ns delete --name '$NamespaceName' --resource-group '$ResourceGroup'"
Show-Command "# az iot hub delete --name '$HubName' --resource-group '$ResourceGroup'"
Show-Command "# az iot dps delete --name '$DpsName' --resource-group '$ResourceGroup'"
Show-Command "# az identity delete --name '$UserIdentity' --resource-group '$ResourceGroup'"
if (Prompt-Step) {
    az cloud update --endpoint-resource-manager "https://management.azure.com" | Out-Null
    # Cleanup lines are intentionally commented.
} else { Write-Host "Skipping undo/cleanup step." -ForegroundColor Yellow }

Write-Host ''
Write-Host 'Congratulations! You have completed all the guided steps. Here is a summary of what you created:' -ForegroundColor Green
Write-Host ''
Write-Host '1. Azure Device Registry (ADR) Namespace with a Credential (Root CA) enabled and one policy (Intermediate CA) created' -ForegroundColor Green
Write-Host '2. Device Provisioning Service linked to your ADR Namespace' -ForegroundColor Green
Write-Host '3. IoT Hub Gen 2 that linked to your ADR Namespace and Device Provisioning Service and is synced with your policy' -ForegroundColor Green
Write-Host '4. DPS Enrollment Group using a Symmetric Key Onboarding Credential' -ForegroundColor Green
Write-Host 'Review outputs above for warnings (non-blocking) and any red ERROR lines.' -ForegroundColor Yellow














