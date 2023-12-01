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
  [string] $AssetsJson,
  [Parameter(Position=1, ValueFromRemainingArguments=$true)]
  [string[]] $TargetTags
)

. (Join-Path $PSScriptRoot ".." ".." "onboarding" "common-asset-functions.ps1")

function Git-Command($CommandString,$WorkingDirectory=$null){
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

function Resolve-Proxy {
    # this script requires the presence of git
    Test-Exe-In-Path -ExeToLookFor "git" | Out-Null

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
    [string] $MountDirectory,
    [boolean] $Output = $true
    )

    $CommandArgs += " --storage-location=$MountDirectory"

    if ($Output -eq $true){
        Write-Host "$TestProxyExe $CommandArgs"
    }

    [array] $output = & "$TestProxyExe" $CommandArgs.Split(" ")

    if ($Output -eq $true){
        foreach($line in $output) {
            Write-Host $line
        }
    }

    return $output
}

function Locate-Assets-Slice($ProxyExe, $AssetsJson, $MountDirectory) {
    $CommandString = "config locate -a $AssetsJson"

    $output = Call-Proxy -TestProxyExe $ProxyExe -CommandArgs $CommandString -MountDirectory $MountDirectory -Output $false

    return $output[-1].Trim()
}

function GetTagSHA($TagName){
    $results = Git-Command "ls-remote $TagName"
    
    if ($results -and $lastexitcode -eq 0) {
        $arr = $results -split '\s+'
        
        return $arr[0]
    }
    
    Write-Error "Unable to fetch tag SHA for $TagName. The tag does not exist on the repository."
    exit 1
}

function StartMessage($AssetsJson, $TargetTags, $AssetsRepoLocation, $MountDirectory){
    Write-Host "`nThis script will attempt to merge the following tag" -nonewline
    if ($TargetTags.Length -gt 1){
        Write-Host "s" -nonewline
    }
    Write-Host ":"
    foreach($Tag in $TargetTags){
        Write-Host " - " -nonewline
        Write-Host "$Tag" -ForegroundColor Green
    }
    Write-Host "`nTargeting the assets slice targeted by " -nonewline
    Write-Host "$AssetsJson." -ForegroundColor Green
    Write-Host "`nThe work will be completed in " -nonewline
    Write-Host $AssetsRepoLocation -ForegroundColor Green -nonewline
    Write-Host "."
}

function FinishMessage($AssetsJson, $TargetTags, $AssetsRepoLocation, $MountDirectory){
    $len = $TargetTags.Length
    Write-Host "`nSuccessfully combined $len tags. Invoke `"test-proxy push " -nonewline
    Write-Host $AssetsJson -ForegroundColor Green -nonewline
    Write-Host "`" to push the results as a new tag."
}

function CombineTags($RemainingTags){
    foreach($Tag in $RemainingTags){
        $tagSha = GetTagSHA -TagName $Tag

        Git-Command "cherry-pick $tagSha"
    }
}

function Resolve-Target-Tags($AssetsJson, $TargetTags) {
    $jsonContent = Get-Content -Raw -Path $AssetsJson
    $jsonObj = $JsonContent | ConvertFrom-Json

    $existingTarget = $jsonObj.Tag

    return $TargetTags | Where-Object {
        if ($_ -eq $existingTarget) {
            Write-Host "Excluding tag $($_) due from tag list, it is present in assets.json."
        }
        $_ -ne $existingTarget
    }
}

$ErrorActionPreference = "Stop"

# resolve the proxy location so that we can invoke it easily
$ProxyExe = Resolve-Proxy

# figure out where the root of the repo for the passed assets.json is. We need it to properly set the mounting
# directory so that the test-proxy restore operations work IN PLACE with existing tooling
$MountDirectory = Get-Repo-Root -StartDir $AssetsJson

# using the MountingDirectory and the assets.json location, we can figure out where the assets slice actually lives within the .assets folder.
# we will use this to invoke individual cherry-picks before pushing up the result
$AssetsRepoLocation = Locate-Assets-Slice $ProxyExe $AssetsJson $MountDirectory

# resolve the tags that we will go after. If the target assets.json contains one of these tags, it will be run _first_ in the first restore.
# This script is intended to run in context of an existing repo, so this is just the way it's gotta be for consistency.
$Tags = Resolve-Target-Tags $AssetsJson $TargetTags

StartMessage $AssetsJson $Tags $AssetsRepoLocation $MountDirectory

# CombineTags -RemainingTags $remainingTags

FinishMessage $AssetsJson $Tags $AssetsRepoLocation $MountDirectory
