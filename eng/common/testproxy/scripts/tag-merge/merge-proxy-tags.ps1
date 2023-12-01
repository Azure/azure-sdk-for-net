<#
.SYNOPSIS
Merge multiple asset tagss worth of content into a single asset tag.

.DESCRIPTION
USAGE: merge-proxy-tags.ps1 path/to/target_assets_json. TAG1 TAG2 TAG3

Attempts to merge the contents of multiple assets tags into a live .assets repository.

In the case one of the targeted tags exists in the targeted assets.json, that tag will always be the start point.

1. test-proxy restore <assets-file>
2. locate recording location
3. walk the incoming tags, cherry-picking their changes directly into the changeset _in context_
4. In the case of a discovered git conflict, the process ends. A list of which tags merged and which didn't will be presented to the user.
  4a. Users should resolve the git conflicts themselves (don't commit, there's a proxy bug to detect already commit stuff :D)
  4b. Once users have the files into a state they like. They should test-proxy push.
  4c. After pushing the resolved conflict, if there are additional tags, they should re-run this script, just excluding the tags that have been merged.

This script requires that test-proxy or azure.sdk.tools.testproxy should be on the PATH.

.PARAMETER TargetTags
The set of tags whos contents should be merged into the targeted 

#>
param(
  [Parameter(Position=0)]
  [string] $AssetsJson
  [Parameter(Position=1, ValueFromRemainingArguments=$true)]
  [string[]] $TargetTags
)

. (Join-Path $PSScriptRoot ".." ".." "onboarding" "generate-assets-json.ps1")

function gcmd($CommandString,$WorkingDirectory=$null){
    Write-Host "git $CommandString"

    if ($WorkingDirectory){
        Push-Location $WorkingDirectory
    }

    $result = Invoke-Expression "git $CommandString"

    if ($WorkingDirectory){
        Pop-Location
    }

    if ($lastexitcode -ne 0) {
        Write-Error 
        Write-Error $result
        exit 1
    }

    return $result
}

function ResolveProxy {
    # this script requires the presence of git
    Test-Exe-In-Path -ExeToLookFor "git"

    $testProxyExe = "test-proxy"
    # this script requires the presence of the test-proxy on the PATH
    $proxyToolPresent = Test-Exe-In-Path -ExeToLookFor "test-proxy" -ExitOnError $false
    $proxyStandalonePresent = Test-Exe-In-Path -ExeToLookFor "Azure.Sdk.Tools.TestProxy" -ExitOnError $false

    if (-not $proxyToolPresent -and -not $proxyStandalonePresent){
        Write-Error "This script requires the presence of a test-proxy executable to complete its operations. Exiting."
        exit 1
    }

    if (-not $proxyToolPresent) {
        $testProxyExe = "Azure.Sdk.Tools.TestProxy"
    }

    return $testProxyExe
}

function Call-Proxy {
    param(
    [string] $TestProxyExe,
    [string] $CommandArgs,
    [string] $MountDirectory
    )

    $CommandArgs += " --storage-location=$MountDirectory"
    Write-Host "$TestProxyExe $CommandArgs"

    [array] $output = & "$TestProxyExe" $CommandArgs.Split(" ")
    
    return $output
}

function GetTagSHA($TagName){
    $results = gcmd "ls-remote $TagName"
    
    if ($results -and $lastexitcode -eq 0) {
        $arr = $results -split '\s+'
        
        return $arr[0]
    }
    
    Write-Error "Unable to fetch tag SHA for $TagName. The tag does not exist on the repository."
    exit 1
}

function StartMessage($AssetsRepository, $TargetTags){
    Write-Host "This script will work against " -nonewline
    Write-Host $assetsRepository -ForegroundColor Green -nonewline
    Write-Host " and attempt to merge tags " -noneStartDirwline
    Write-Host "$($TargetTags -join ', ')" -ForegroundColor Green
}

function FinishMessage($AssetsDirectory, $TargetTags){
    $len = $TargetTags.Length
    Write-Host "Successfully combined $len tags. Please commit the result found in " -nonewline
    Write-Host "$AssetsDirectory." -ForegroundColor Green
}

function CombineTags($RemainingTags){
    foreach($Tag in $RemainingTags){
        $tagSha = GetTagSHA -TagName $Tag

        gcmd "cherry-pick $tagSha"
    }
}

$ErrorActionPreference = "Stop"

$ProxyExe = ResolveProxy
$MountDirectory = Get-Repo-Root -StartDir $AssetsJson

# StartMessage -AssetsRepository $assetsRepository -RemainingTags $TargetTags
# CombineTags -RemainingTags $remainingTags
# FinishMessage -AssetsDirectory $assetsDirectory
