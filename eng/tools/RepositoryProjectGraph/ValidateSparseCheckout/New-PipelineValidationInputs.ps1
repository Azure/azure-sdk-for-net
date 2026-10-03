#Requires -Version 7.0

<#
.SYNOPSIS
Creates a singleton validation manifest for one generated Azure Pipelines test job.

.DESCRIPTION
The matrix generator may batch multiple artifact names into ProjectNames to control job count. This
script preserves that scheduling boundary but expands the batch back into one validation case per
artifact. Invoke-SparseCheckoutValidation.ps1 then gives every case its own clean sparse closure and
continues through the complete batch before reporting aggregate failure.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string] $RepoRoot,
    [Parameter(Mandatory = $true)][string] $InputRoot,
    [Parameter(Mandatory = $true)][string] $PackageInfoDirectory,
    [Parameter(Mandatory = $true)][string] $CheckoutGraphPath,
    [Parameter(Mandatory = $true)][string] $ArtifactNames,
    [Parameter(Mandatory = $true)][string] $SourceCommit,
    [Parameter(Mandatory = $true)][ValidateSet('Linux', 'Windows', 'macOS')][string] $TargetHost,
    [Parameter(Mandatory = $true)][string] $MatrixName,
    [Parameter(Mandatory = $true)][string] $TargetFramework,
    [Parameter(Mandatory = $true)][string] $BuildConfiguration,
    [string] $AdditionalTestArguments = '',
    [string] $AdditionalTestFilters = 'Placeholder!=DefaultIgnoreMe',
    [string] $CollectCoverage = 'false'
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'Validation.Common.ps1')

function Get-RelativeManifestPath([string] $Root, [string] $Path) {
    $relative = [System.IO.Path]::GetRelativePath($Root, $Path).Replace('\', '/')
    if ($relative.Equals('..', [StringComparison]::OrdinalIgnoreCase) -or
        $relative.StartsWith('../', [StringComparison]::OrdinalIgnoreCase) -or
        [System.IO.Path]::IsPathRooted($relative)) {
        throw "Validation input '$Path' must be beneath InputRoot '$Root'."
    }
    return $relative
}

$RepoRoot = [System.IO.Path]::GetFullPath($RepoRoot)
$InputRoot = [System.IO.Path]::GetFullPath($InputRoot)
$PackageInfoDirectory = [System.IO.Path]::GetFullPath($PackageInfoDirectory)
$CheckoutGraphPath = [System.IO.Path]::GetFullPath($CheckoutGraphPath)
foreach ($path in @($PackageInfoDirectory, $CheckoutGraphPath)) {
    if (!(Test-Path -LiteralPath $path)) {
        throw "Validation input does not exist: $path"
    }
}

$repoCommit = (& git -C $RepoRoot rev-parse HEAD).Trim()
if ($LASTEXITCODE -ne 0 -or !$repoCommit.Equals($SourceCommit, [StringComparison]::OrdinalIgnoreCase)) {
    throw "Repository HEAD '$repoCommit' does not match pipeline commit '$SourceCommit'."
}

$checkoutGraph = Get-Content -Raw -LiteralPath $CheckoutGraphPath | ConvertFrom-Json -Depth 100
if (!$checkoutGraph.isComplete -or
    !([string]$checkoutGraph.sourceCommit).Equals($SourceCommit, [StringComparison]::OrdinalIgnoreCase)) {
    throw 'Sparse checkout graph is incomplete or has mismatched commit provenance.'
}

$requestedArtifacts = @(
    $ArtifactNames -split ',' |
        ForEach-Object { $_.Trim() } |
        Where-Object { $_ } |
        Select-Object -Unique
)
if ($requestedArtifacts.Count -eq 0) {
    throw 'ArtifactNames contains no singleton validation cases.'
}

$packageByArtifact = @{}
foreach ($file in Get-ChildItem -LiteralPath $PackageInfoDirectory -Filter '*.json' -File -Recurse) {
    $package = Get-Content -Raw -LiteralPath $file.FullName | ConvertFrom-Json -Depth 100
    $artifactName = [string]$package.ArtifactName
    if (!$artifactName) {
        throw "PackageInfo '$($file.FullName)' has no ArtifactName."
    }
    if ($packageByArtifact.ContainsKey($artifactName)) {
        throw "PackageInfo contains duplicate artifact '$artifactName'."
    }
    $packageByArtifact[$artifactName] = $package
}

$collectCoverageValue = $false
if (![bool]::TryParse($CollectCoverage, [ref]$collectCoverageValue)) {
    throw "CollectCoverage must be true or false, got '$CollectCoverage'."
}

$cases = foreach ($artifactName in $requestedArtifacts) {
    if (!$packageByArtifact.ContainsKey($artifactName)) {
        throw "Generated matrix artifact '$artifactName' has no PackageInfo input."
    }
    $package = $packageByArtifact[$artifactName]
    $packageNameProperty = $package.PSObject.Properties['Name']
    [pscustomobject][ordered]@{
        artifactName = $artifactName
        packageName = $packageNameProperty ? [string]$packageNameProperty.Value : $artifactName
        directoryPath = [string]$package.DirectoryPath
        host = $TargetHost
        matrixName = $MatrixName
        targetFramework = $TargetFramework
        buildConfiguration = $BuildConfiguration
        additionalTestArguments = $AdditionalTestArguments
        additionalTestFilters = $AdditionalTestFilters
        collectCoverage = $collectCoverageValue
        includeSourceProjects = !(Test-SparseCheckoutArtifactHasTestProjects $checkoutGraph $artifactName)
        # The generated job already exposes every custom matrix value in its process environment.
        matrixParameters = [pscustomobject]@{}
        matrixConfig = 'azure-pipelines-generated-job'
    }
}

$casesPath = Join-Path $InputRoot 'cases.json'
$cases | ConvertTo-Json -Depth 20 -AsArray |
    Set-Content -LiteralPath $casesPath -Encoding utf8
$manifest = [pscustomobject][ordered]@{
    schemaVersion = 1
    harnessVersion = Get-SparseCheckoutValidationHarnessVersion $PSScriptRoot
    sourceCommit = $SourceCommit
    generatedAtUtc = [DateTime]::UtcNow.ToString('o')
    generatedOn = 'Azure Pipelines'
    targetHost = $TargetHost
    packageInfoDirectory = Get-RelativeManifestPath $InputRoot $PackageInfoDirectory
    packageInfoSha256 = Get-SparseCheckoutValidationDirectoryHash $PackageInfoDirectory
    checkoutGraphPath = Get-RelativeManifestPath $InputRoot $CheckoutGraphPath
    checkoutGraphSha256 = (Get-FileHash -Algorithm SHA256 -LiteralPath $CheckoutGraphPath).Hash.ToLowerInvariant()
    casesPath = Get-RelativeManifestPath $InputRoot $casesPath
    casesSha256 = (Get-FileHash -Algorithm SHA256 -LiteralPath $casesPath).Hash.ToLowerInvariant()
    packageCount = $requestedArtifacts.Count
    caseCount = $cases.Count
}
$manifestPath = Join-Path $InputRoot 'manifest.json'
$manifest | ConvertTo-Json -Depth 20 |
    Set-Content -LiteralPath $manifestPath -Encoding utf8

Write-Host "Pipeline sparse validation inputs: artifacts=$($requestedArtifacts.Count), matrix=$MatrixName, host=$TargetHost"
Write-Host "Manifest: $manifestPath"
return $manifest
