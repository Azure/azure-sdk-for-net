<#
.SYNOPSIS
Merge multiple asset tagss worth of content into a single asset tag.

.DESCRIPTION
USAGE: merge-proxy-tags.ps1 TAG1 TAG2 TAG3

Attempts to merge the contents of multiple assets tags. The first tag will be checked out, then successive tag's SHAs will be cherry-picked in one at a time.

In the occurence of a git conflict during a cherry-pick, the process is stopped, and the location of the .assets folder will be returned to the user.

Users should resolve the conflicts and re-run the script with the SAME ARGUMENTS.

.PARAMETER TargetTags
The set of tags whos contents should be merged into a single new tag. 

#>
param(
  [Parameter(Position=0, ValueFromRemainingArguments=$true)]
  [string[]] $TargetTags
)

function gcmd($CommandString){
    Write-Host "git $CommandString"
    $result = Invoke-Expression "git $CommandString"

    if ($lastexitcode -ne 0) {
        Write-Host $result
        exit 1
    }

    return $result
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
    Write-Host " and attempt to merge tags " -nonewline
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

$assetsRepository = $env:ASSETS_REPOSITORY ?? "azure/azure-sdk-assets"
$assetsDirectory = Resolve-Path -Path "assets"
$assetsUrl = "https://github.com/{0}" -f $assetsRepository

if (!(Test-Path $assetsDirectory)){
    New-Item -ItemType Directory -Path $assetsDirectory
    gcmd "clone -c core.longpaths=true --no-checkout --filter=tree:0 $assetsUrl $assetsDirectory" | Out-null
}
else {
    # do nothing, we've already cloned it
    # we need a way to be able to tell if we're in a good position to continue from last
}

StartMessage -AssetsRepository $assetsRepository -RemainingTags $TargetTags

$startTag = $TargetTags[0]
$remainingTags = $TargetTags[1..($TargetTags.Length - 1)]

Push-Location $assetsDirectory

gcmd "-c advice.detachedHead=false checkout $startTag"

CombineTags -RemainingTags $remainingTags

FinishMessage -AssetsDirectory $assetsDirectory

Pop-Location

