[CmdletBinding()]
Param (
  [Parameter(Mandatory=$True)]
  [array]$ArtifactList,
  [Parameter(Mandatory=$True)]
  [string]$ArtifactPath,
  [Parameter(Mandatory=$True)]
  [string]$RepoRoot,
  [Parameter(Mandatory=$True)]
  [string]$APIKey,
  [string]$ConfigFileDir,
  [string]$BuildDefinition,
  [string]$PipelineUrl,
  [string]$APIViewUri  = "https://apiview.dev/AutoReview/GetReviewStatus",
  [string]$Devops_pat = $env:DEVOPS_PAT
)

Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot common.ps1)

function ProcessPackage($PackageName, $ConfigFileDir)
{
    Write-Host "Artifact path: $($ArtifactPath)"
    Write-Host "Package Name: $($PackageName)"
    Write-Host "Config File directory: $($ConfigFileDir)"

    $pkgPropPath = Join-Path -Path $ConfigFileDir "$PackageName.json"
    if (-Not (Test-Path $pkgPropPath))
    {
        Write-Host " Package property file path $($pkgPropPath) is invalid."
        return $false
    }

    $pkgInfo = Get-Content $pkgPropPath | ConvertFrom-Json
    &$EngCommonScriptsDir/Validate-Package.ps1 `
        -PackageName $PackageName `
        -ArtifactPath $ArtifactPath `
        -RepoRoot $RepoRoot `
        -APIViewUri $APIViewUri `
        -APIKey $APIKey `
        -BuildDefinition $BuildDefinition `
        -PipelineUrl $PipelineUrl `
        -ConfigFileDir $ConfigFileDir `
        -Devops_pat $Devops_pat
    if ($LASTEXITCODE -ne 0)
    {
        Write-Error "Failed to validate package $PackageName"
        return $false
    }
    return $true
}

# Check if package config file is present. This file has package version, SDK type etc info.
if (-not $ConfigFileDir)
{
    $ConfigFileDir = Join-Path -Path $ArtifactPath "PackageInfo"
}
foreach ($artifact in $ArtifactList)
{
    Write-Host "Processing $($artifact.name)"
    ProcessPackage -PackageName $artifact.name -ConfigFileDir $ConfigFileDir
}