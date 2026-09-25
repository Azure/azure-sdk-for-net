#Requires -Version 7.0

<#
.SYNOPSIS
Adds validation-only PackageInfo entries for test projects not owned by a shipping artifact.

.DESCRIPTION
The repository-wide CI campaign begins with shipping PackageInfo roots, but a small number of test
projects live under non-shipping tools or shared projects. This script audits every source-graph
node under a tests directory and creates one synthetic singleton root for each uncovered project.
It writes the same entries to the matrix and published PackageInfo directories and emits a coverage
report. Synthetic entries exist only in pipeline artifacts; source package metadata is unchanged.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string] $SourceGraphPath,
    [Parameter(Mandatory = $true)][string[]] $PackageInfoDirectories,
    [Parameter(Mandatory = $true)][string] $CoverageOutputPath,
    [Parameter(Mandatory = $true)][string] $RepoRoot,
    [Parameter(Mandatory = $true)][string] $DefaultMatrixConfigPath,
    [Parameter(Mandatory = $true)][string] $GeneratedMatrixDirectory
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'

function Get-NormalizedRepositoryPath([string] $Path) {
    return $Path.Replace('\', '/').Trim('/')
}

foreach ($path in @($SourceGraphPath, $RepoRoot, $DefaultMatrixConfigPath) + $PackageInfoDirectories) {
    if (!(Test-Path -LiteralPath $path)) {
        throw "Sparse validation input does not exist: $path"
    }
}
if ($PackageInfoDirectories.Count -eq 0) {
    throw 'At least one PackageInfo directory is required.'
}

$sourceGraph = Get-Content -Raw -LiteralPath $SourceGraphPath | ConvertFrom-Json -Depth 100
if (!$sourceGraph.diagnostics.isComplete) {
    throw 'Cannot audit test-project coverage from an incomplete repository source graph.'
}
$RepoRoot = [System.IO.Path]::GetFullPath($RepoRoot)
$GeneratedMatrixDirectory = [System.IO.Path]::GetFullPath($GeneratedMatrixDirectory)
New-Item -ItemType Directory -Path $GeneratedMatrixDirectory -Force | Out-Null
Get-ChildItem -LiteralPath $GeneratedMatrixDirectory -Filter '*.json' -File -ErrorAction SilentlyContinue |
    Remove-Item -Force

# Most uncovered projects use the normal sparse matrix. If a project explicitly exposes only a
# subset of modern TFMs, generate a filtered matrix instead of sending an unsupported --framework.
. (Join-Path $RepoRoot 'eng/common/scripts/job-matrix/job-matrix-functions.ps1')
$defaultMatrixConfig = GetMatrixConfigFromFile (Get-Content -Raw -LiteralPath $DefaultMatrixConfigPath)
$defaultMatrixEntries = @(GenerateMatrix -config $defaultMatrixConfig `
    -selectFromMatrixType 'sparse' -skipEnvironmentVariables)
$generatedMatrixByFrameworks = @{}

function Get-FilteredMatrixConfig([string[]] $TargetFrameworks) {
    $modernFrameworks = @($TargetFrameworks | Where-Object { $_ -in @('net8.0', 'net9.0', 'net10.0') } |
        Sort-Object -Unique)
    if ($modernFrameworks.Count -eq 3) { return $null }
    if ($modernFrameworks.Count -eq 0) {
        throw "Unowned test project exposes no supported modern test framework: $($TargetFrameworks -join ', ')."
    }
    $key = $modernFrameworks -join ','
    if ($generatedMatrixByFrameworks.ContainsKey($key)) {
        return $generatedMatrixByFrameworks[$key]
    }

    $entries = @($defaultMatrixEntries | Where-Object {
        [string]$_.parameters.TestTargetFramework -in $modernFrameworks
    })
    if ($entries.Count -eq 0) {
        throw "Default sparse matrix has no entries for '$key'."
    }
    $keyBytes = [System.Text.Encoding]::UTF8.GetBytes($key)
    $keyHash = [Convert]::ToHexString([System.Security.Cryptography.SHA256]::HashData($keyBytes)).ToLowerInvariant()
    $matrixName = "synthetic-$($keyHash.Substring(0, 8))"
    $matrixPath = Join-Path $GeneratedMatrixDirectory "$matrixName.json"
    $validationCases = [ordered]@{}
    foreach ($entry in $entries) {
        $validationCases[[string]$entry.name] = $entry.parameters
    }
    [pscustomobject][ordered]@{
        matrix = [pscustomobject][ordered]@{
            ValidationCase = [pscustomobject]$validationCases
        }
    } | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath $matrixPath -Encoding utf8
    $relativeMatrixPath = [System.IO.Path]::GetRelativePath($RepoRoot, $matrixPath).Replace('\', '/')
    $reference = [pscustomobject][ordered]@{
        Name = $matrixName
        Path = $relativeMatrixPath
        Selection = 'all'
        NonSparseParameters = @()
    }
    $generatedMatrixByFrameworks[$key] = $reference
    return $reference
}

# A stale reusable graph may have already produced synthetic files before failing provenance
# validation. Remove only files marked as ours, then derive coverage from source PackageInfo again.
foreach ($directory in $PackageInfoDirectories) {
    foreach ($file in Get-ChildItem -LiteralPath $directory -Filter '*.json' -File -Recurse) {
        $package = Get-Content -Raw -LiteralPath $file.FullName | ConvertFrom-Json -Depth 100
        $syntheticProperty = $package.PSObject.Properties['SparseCheckoutValidationSynthetic']
        if ($syntheticProperty -and [bool]$syntheticProperty.Value) {
            Remove-Item -LiteralPath $file.FullName -Force
        }
    }
}

$packages = @(
    Get-ChildItem -LiteralPath $PackageInfoDirectories[0] -Filter '*.json' -File -Recurse |
        ForEach-Object { Get-Content -Raw -LiteralPath $_.FullName | ConvertFrom-Json -Depth 100 }
)
$packageRoots = [System.Collections.Generic.List[object]]::new()
foreach ($package in $packages) {
    $root = Get-NormalizedRepositoryPath ([string]$package.DirectoryPath)
    if (!$root) { throw "PackageInfo '$($package.ArtifactName)' has no DirectoryPath." }
    $packageRoots.Add([pscustomobject]@{ artifactName = [string]$package.ArtifactName; path = $root })
}

$testProjects = @(
    $sourceGraph.nodes | Where-Object {
        (Get-NormalizedRepositoryPath ([string]$_.projectPath)) -match '/tests/'
    } | Sort-Object { Get-NormalizedRepositoryPath ([string]$_.projectPath) } -Unique
)
$syntheticArtifacts = [System.Collections.Generic.List[object]]::new()
foreach ($projectNode in $testProjects) {
    $projectPath = Get-NormalizedRepositoryPath ([string]$projectNode.projectPath)
    $owners = @($packageRoots | Where-Object {
        $projectPath.StartsWith("$($_.path)/", [StringComparison]::OrdinalIgnoreCase)
    })
    if ($owners.Count -gt 0) { continue }
    if (!$projectPath.StartsWith('sdk/', [StringComparison]::OrdinalIgnoreCase)) {
        throw "Unowned test project is outside sdk: '$projectPath'."
    }

    $projectDirectory = Get-NormalizedRepositoryPath (Split-Path -Parent $projectPath)
    $projectName = [System.IO.Path]::GetFileNameWithoutExtension($projectPath) -replace '[^A-Za-z0-9._-]', '_'
    $pathBytes = [System.Text.Encoding]::UTF8.GetBytes($projectPath)
    $pathHash = [Convert]::ToHexString([System.Security.Cryptography.SHA256]::HashData($pathBytes)).ToLowerInvariant()
    $artifactName = "SparseCheckoutValidation.$projectName.$($pathHash.Substring(0, 8))"
    if ($packageRoots.artifactName -contains $artifactName) {
        throw "Synthetic sparse validation artifact '$artifactName' collides with PackageInfo."
    }
    $serviceDirectory = ($projectPath -split '/')[1]
    $matrixConfig = Get-FilteredMatrixConfig @($projectNode.targetFrameworks)
    $matrixConfigs = $null -eq $matrixConfig ? @() : @($matrixConfig)
    $synthetic = [pscustomobject][ordered]@{
        Name = $artifactName
        DirectoryPath = $projectDirectory
        ServiceDirectory = $serviceDirectory
        SdkType = 'all'
        ArtifactName = $artifactName
        IncludedForValidation = $false
        CIParameters = [pscustomobject][ordered]@{
            CIMatrixConfigs = $matrixConfigs
            BuildSnippets = $false
        }
        SparseCheckoutValidationSynthetic = $true
        SourceTestProject = $projectPath
    }
    foreach ($directory in $PackageInfoDirectories) {
        $synthetic | ConvertTo-Json -Depth 20 |
            Set-Content -LiteralPath (Join-Path $directory "$artifactName.json") -Encoding utf8
    }
    $packageRoots.Add([pscustomobject]@{ artifactName = $artifactName; path = $projectDirectory })
    $syntheticArtifacts.Add([pscustomobject][ordered]@{
        artifactName = $artifactName
        directoryPath = $projectDirectory
        projectPath = $projectPath
    })
}

$coverage = @($testProjects | ForEach-Object {
    $projectPath = Get-NormalizedRepositoryPath ([string]$_.projectPath)
    $owners = @($packageRoots | Where-Object {
        $projectPath.StartsWith("$($_.path)/", [StringComparison]::OrdinalIgnoreCase)
    } | ForEach-Object artifactName | Sort-Object -Unique)
    [pscustomobject][ordered]@{
        projectPath = $projectPath
        artifactNames = $owners
        covered = $owners.Count -gt 0
    }
})
$uncovered = @($coverage | Where-Object { !$_.covered })
if ($uncovered.Count -gt 0) {
    throw "Synthetic PackageInfo generation left $($uncovered.Count) test projects uncovered."
}

$coverageDirectory = Split-Path -Parent $CoverageOutputPath
if ($coverageDirectory) {
    New-Item -ItemType Directory -Path $coverageDirectory -Force | Out-Null
}
[pscustomobject][ordered]@{
    schemaVersion = 1
    sourceCommit = [string]$sourceGraph.sourceCommit
    testProjectCount = $coverage.Count
    uncoveredTestProjectCount = $uncovered.Count
    syntheticArtifactCount = $syntheticArtifacts.Count
    syntheticArtifacts = $syntheticArtifacts.ToArray()
    projects = $coverage
} | ConvertTo-Json -Depth 20 |
    Set-Content -LiteralPath $CoverageOutputPath -Encoding utf8

Write-Host "Sparse validation test-project coverage: projects=$($coverage.Count), syntheticArtifacts=$($syntheticArtifacts.Count), uncovered=0"
