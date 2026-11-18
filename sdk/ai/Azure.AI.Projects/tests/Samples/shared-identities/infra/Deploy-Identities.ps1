#Requires -Version 7.2
<#
.SYNOPSIS
Previews (default) or creates the azure-ai-projects shared sample identities and RBAC.

.EXAMPLE
# Prompts for subscription and region (Up/Down, Enter), then previews. No Azure changes.
.\tests\samples\shared-identities\infra\Deploy-Identities.ps1

.EXAMPLE
# Prompts for subscription and region, then creates the resource group, identities, and RBAC after confirmation.
.\tests\samples\shared-identities\infra\Deploy-Identities.ps1 -Apply

.EXAMPLE
# Non-interactive run with explicit values. Skips the prompts and confirmation.
.\tests\samples\shared-identities\infra\Deploy-Identities.ps1 -Apply -SubscriptionId <subscription-id> -Location westus3 -Confirm:$false
#>
[CmdletBinding(SupportsShouldProcess, ConfirmImpact = 'High')]
param(
    [string]$SubscriptionId,
    [string]$Location,
    [string]$ConfigPath = (Join-Path $PSScriptRoot 'IdentityConfiguration.json'),
    [switch]$Apply
)

$ErrorActionPreference = 'Stop'

function Select-ListItem {
    param(
        [Parameter(Mandatory)][string]$Title,
        [Parameter(Mandatory)][string[]]$Items,
        [int]$DefaultIndex = 0
    )
    if ($Items.Count -eq 0) { throw "No choices available for $Title." }
    if ([Console]::IsInputRedirected) { throw "$Title is required. Pass the matching parameter in non-interactive sessions." }

    $pageSize = [Math]::Min(15, $Items.Count)
    $index = [Math]::Min([Math]::Max($DefaultIndex, 0), $Items.Count - 1)
    $offset = [Math]::Max(0, [Math]::Min($index, $Items.Count - $pageSize))

    Write-Host "$Title (Up/Down to move, Enter to select, Esc to cancel)"
    1..$pageSize | ForEach-Object { Write-Host '' }
    $listTop = [Console]::CursorTop - $pageSize
    $width = [Math]::Max(1, [Console]::BufferWidth - 1)

    while ($true) {
        [Console]::SetCursorPosition(0, $listTop)
        for ($row = 0; $row -lt $pageSize; $row++) {
            $i = $offset + $row
            $marker = if ($i -eq $index) { '>' } else { ' ' }
            $color = if ($i -eq $index) { 'Cyan' } else { 'Gray' }
            $text = "$marker $($Items[$i])".PadRight($width).Substring(0, $width)
            Write-Host $text -ForegroundColor $color
        }

        $key = [Console]::ReadKey($true)
        switch ($key.Key) {
            'UpArrow'   { if ($index -gt 0) { $index-- } }
            'DownArrow' { if ($index -lt $Items.Count - 1) { $index++ } }
            'Enter'     { [Console]::SetCursorPosition(0, $listTop + $pageSize); return $index }
            'Escape'    { throw 'Selection cancelled.' }
        }
        if ($index -lt $offset) { $offset = $index }
        if ($index -ge $offset + $pageSize) { $offset = $index - $pageSize + 1 }
    }
}

function Select-AzureSubscription {
    $json = & az account list --query "[?state=='Enabled'].{name:name,id:id,isDefault:isDefault}" --output json
    if ($LASTEXITCODE -ne 0) { throw 'az account list failed. Run az login first.' }
    $subs = @(ConvertFrom-Json -InputObject ($json -join '') | Sort-Object name)
    if ($subs.Count -eq 0) { throw 'No enabled subscriptions found. Run az login first.' }

    $default = 0
    for ($i = 0; $i -lt $subs.Count; $i++) { if ($subs[$i].isDefault) { $default = $i; break } }
    $labels = @($subs | ForEach-Object { "$($_.name) ($($_.id))" })
    $choice = Select-ListItem -Title 'Select subscription' -Items $labels -DefaultIndex $default
    return $subs[$choice].id
}

function Select-AzureRegion {
    param(
        [Parameter(Mandatory)][string]$SubscriptionId,
        [string]$Default = 'westus3'
    )
    $url = "https://management.azure.com/subscriptions/$SubscriptionId/locations?api-version=2022-12-01"
    $json = & az rest --method get --url $url --query "value[?metadata.regionType=='Physical'].{name:name,displayName:displayName}" --output json
    if ($LASTEXITCODE -ne 0) { throw 'Listing regions failed. Check az login and subscription access.' }
    $regions = @(ConvertFrom-Json -InputObject ($json -join '') | Sort-Object name)

    $index = 0
    for ($i = 0; $i -lt $regions.Count; $i++) { if ($regions[$i].name -eq $Default) { $index = $i; break } }
    $labels = @($regions | ForEach-Object { "$($_.name) ($($_.displayName))" })
    $choice = Select-ListItem -Title 'Select region' -Items $labels -DefaultIndex $index
    return $regions[$choice].name
}

if (-not $SubscriptionId) { $SubscriptionId = Select-AzureSubscription }
if (-not $Location) { $Location = Select-AzureRegion -SubscriptionId $SubscriptionId }

$template = Join-Path $PSScriptRoot 'main.bicep'
$stamp = (Get-Date).ToUniversalTime().ToString('MMddyy_HHmmss')
$resourceGroup = "rg-azsdk-identities-$Location-$stamp"
$ownerToken = [guid]::NewGuid().ToString('N')
$tempDir = [System.IO.Path]::GetTempPath()
$paramsPath = Join-Path $tempDir "azsdk-identities-$stamp.parameters.json"
$compiled = Join-Path $tempDir "azsdk-identities-$stamp.json"

$config = Get-Content -Raw -Path $ConfigPath | ConvertFrom-Json
$targets = @($config.managedIdentities.target)
$identities = @($targets | ForEach-Object { [ordered]@{ target = $_; name = "mi-azsdk-sample-$_-$Location-$stamp" } })
$grants = @()
$conditionalGrants = @()
foreach ($row in $config.roleAssignments) {
    if ($row.target -eq 'pipeline') {
        Write-Warning 'Pipeline grant skipped: no pipeline principal is supplied to this template.'
        continue
    }
    $index = [array]::IndexOf($targets, $row.target)
    if ($index -lt 0) { throw "Role grant targets unknown identity '$($row.target)'." }
    $grant = [ordered]@{ identityIndex = $index; roleDefinitionId = $row.roleDefinitionId }
    if ($row.PSObject.Properties.Name -contains 'condition') {
        $grant.condition = $row.condition
        $grant.conditionVersion = $row.conditionVersion
        $conditionalGrants += $grant
    }
    else {
        $grants += $grant
    }
}

function Invoke-Az {
    & az @args
    if ($LASTEXITCODE -ne 0) {
        throw "az failed (exit $LASTEXITCODE): az $($args -join ' ')"
    }
}

try {
    @{
        '$schema'      = 'https://schema.management.azure.com/schemas/2019-04-01/deploymentParameters.json#'
        contentVersion = '1.0.0.0'
        parameters     = @{
            location           = @{ value = $Location }
            resourceGroupName  = @{ value = $resourceGroup }
            ownerToken         = @{ value = $ownerToken }
            identities         = @{ value = $identities }
            grants             = @{ value = $grants }
            conditionalGrants  = @{ value = $conditionalGrants }
        }
    } | ConvertTo-Json -Depth 10 | Set-Content -Path $paramsPath -Encoding utf8

    Invoke-Az bicep build --file $template --outfile $compiled
    Invoke-Az account show --subscription $SubscriptionId --output none

    Write-Host "Resource group : $resourceGroup"
    $identities | ForEach-Object { Write-Host "Identity       : $($_.name) ($($_.target))" }
    Write-Host "Role grants    : $($grants.Count + $conditionalGrants.Count)"

    Invoke-Az deployment sub what-if --subscription $SubscriptionId --location $Location --name "identities-preview-$stamp" --template-file $template --parameters "@$paramsPath"

    if (-not $Apply) {
        Write-Host 'Preview only: what-if completed, no resources created. Re-run with -Apply to deploy.'
        return
    }

    if (-not $PSCmdlet.ShouldProcess($resourceGroup, "Create resource group, $($identities.Count) identities and role grants in $Location")) {
        return
    }

    Invoke-Az deployment sub create --subscription $SubscriptionId --location $Location --name "identities-$stamp" --template-file $template --parameters "@$paramsPath" --query properties.outputs --output json
    Write-Host "Portal         : https://portal.azure.com/#resource/subscriptions/$SubscriptionId/resourceGroups/$resourceGroup/overview"
}
finally {
    Remove-Item -Path $paramsPath, $compiled -ErrorAction SilentlyContinue
}
