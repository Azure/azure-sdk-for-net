#Requires -Version 6.0
#Requires -PSEdition Core

<#
.SYNOPSIS
Within an assets.json file that has in a conflicted state (specifically on asset tag), merge the two tags that are conflicting and leave the assets.json in a commitable state.

.DESCRIPTION
USAGE: resolve-asset-conflict.ps1 path/to/target_assets_json

Parses the assets.json file and determines which tags are in conflict. If there are no conflicts, the script exits.

1. Parse the tags (base and target) from conflicting assets.json.
2. Update the assets.json with the base tag, but remember the target tag.
3. merge-proxy-tags.ps1 $AssetsJson base_tag target_tag

This script requires that test-proxy or azure.sdk.tools.testproxy should be on the PATH.

.PARAMETER AssetsJson
The script uses a target assets.json to understand what tags are in conflict. This is the only required parameter.
#>

param(
  [Parameter(Position=0)]
  [string] $AssetsJson
)


. (Join-Path $PSScriptRoot ".." ".." "onboarding" "common-asset-functions.ps1")

function Get-AssetsBase {
    param(
        [Parameter(Position=0)]
        [string] $AssetsJson
    )
    
    $AssetsContent = Get-Content -Raw $AssetsJson
    

    # $Assets = ConvertFrom-Json $AssetsContent
    
    # $AssetsVersions = @{}
    
    # foreach ($Asset in $Assets) {
    #     $AssetsVersions[$Asset.name] = $Asset.version
    # }
    
    return $AssetsVersions
}

function Get-AssetsTarget {
    param(
        [Parameter(Position=0)]
        [string] $AssetsJson
    )
    
    $AssetsContent = Get-Content -Raw $AssetsJson
    

    # $Assets = ConvertFrom-Json $AssetsContent
    
    # $AssetsVersions = @{}
    
    # foreach ($Asset in $Assets) {
    #     $AssetsVersions[$Asset.name] = $Asset.version
    # }
    
    return $AssetsVersions
}

$TestProxy = Resolve-Proxy

if (!(Test-Path $AssetsJson)) {
  Write-Error "AssetsJson file does not exist: $AssetsJson"
  exit 1
}

$AssetsJson = Resolve-Path $AssetsJson

if ($AssetsJson.Name -ne "assets.json") {
  Write-Error "This script can only resolve conflicts within an assets.json. The file provided is not an assets.json: $AssetsJson"
  exit 1
}



$BaseAssets = Get-AssetsBase $AssetsJson
$TargetAssets = Get-AssetsTarget $AssetsJson

$TargetAssets | ConvertTo-Json -Depth 100 | Out-File $AssetsJson

$PSScriptRoot/../tag-merge/merge-proxy-tags.ps1 $AssetsJson $BaseAssets.Tag $TargetAssets.Tag
