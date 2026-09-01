#Requires -Version 7.0

<#
.SYNOPSIS
Generates fresh PackageInfo, repository graph, sparse projection, and singleton validation cases.

.DESCRIPTION
VALIDATION ONLY. This script must run from a clean full checkout. It uses production graph and
matrix components but writes only beneath artifacts/validation/RepositoryProjectGraph by default.
#>
[CmdletBinding()]
param(
    [string] $RepoRoot,
    [string] $OutputRoot,
    [ValidateSet('Linux', 'Windows', 'All')]
    [string] $TargetHost = 'All',
    [string[]] $MatrixConfigPath = @('eng/pipelines/templates/stages/platform-matrix.json'),
    [switch] $ReuseInputs
)

Set-StrictMode -Version 3.0
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'Validation.Common.ps1')

function Invoke-CheckedCommand {
    param(
        [Parameter(Mandatory = $true)][string] $FilePath,
        [Parameter(Mandatory = $true)][string[]] $ArgumentList,
        [Parameter(Mandatory = $true)][string] $WorkingDirectory
    )

    Write-Host "> $FilePath $($ArgumentList -join ' ')"
    Push-Location $WorkingDirectory
    try {
        & $FilePath @ArgumentList
        if ($LASTEXITCODE -ne 0) {
            throw "Command failed with exit code ${LASTEXITCODE}: $FilePath $($ArgumentList -join ' ')"
        }
    }
    finally {
        Pop-Location
    }
}

function Get-ObjectValue($Object, [string] $Name, $Default = $null) {
    if ($null -eq $Object) { return $Default }
    if ($Object -is [System.Collections.IDictionary]) {
        return $Object.Contains($Name) ? $Object[$Name] : $Default
    }
    $property = $Object.PSObject.Properties[$Name]
    return $property ? $property.Value : $Default
}

function Get-MatrixHost($MatrixEntry) {
    $parameters = Get-ObjectValue $MatrixEntry 'parameters'
    $pool = [string](Get-ObjectValue $parameters 'Pool' '')
    $name = [string](Get-ObjectValue $MatrixEntry 'name' '')
    if ($pool -match 'LINUX' -or $name -match '^(Ubuntu|Linux)') { return 'Linux' }
    if ($pool -match 'WINDOWS' -or $name -match '^Windows') { return 'Windows' }
    if ($pool -match 'MAC' -or $name -match '^Mac') { return 'macOS' }
    throw "Unable to classify matrix entry '$name' from Pool '$pool'."
}

function Get-ConfigKey($Config) {
    $path = [string](Get-ObjectValue $Config 'Path')
    $selection = [string](Get-ObjectValue $Config 'Selection' 'sparse')
    $nonSparse = @((Get-ObjectValue $Config 'NonSparseParameters' @())) -join ','
    return "$path|$selection|$nonSparse"
}

if (!$RepoRoot) {
    $RepoRoot = Resolve-Path (Join-Path $PSScriptRoot '../../../..')
}
$RepoRoot = [System.IO.Path]::GetFullPath($RepoRoot)
if (!$OutputRoot) {
    $OutputRoot = Join-Path $RepoRoot 'artifacts/validation/RepositoryProjectGraph/sparse-checkout/inputs'
}
$OutputRoot = [System.IO.Path]::GetFullPath($OutputRoot)

$manifestPath = Join-Path $OutputRoot 'manifest.json'
$sourceCommit = (& git -C $RepoRoot rev-parse HEAD).Trim()
if ($LASTEXITCODE -ne 0 -or !$sourceCommit) {
    throw "Unable to read HEAD under '$RepoRoot'."
}
$harnessVersion = Get-SparseCheckoutValidationHarnessVersion $PSScriptRoot

if ($ReuseInputs -and (Test-Path -LiteralPath $manifestPath)) {
    $existing = Get-Content -Raw -LiteralPath $manifestPath | ConvertFrom-Json -Depth 100
    $canReuse = $false
    try {
        $existingGraphPath = Join-Path $OutputRoot ([string]$existing.checkoutGraphPath)
        $existingCasesPath = Join-Path $OutputRoot ([string]$existing.casesPath)
        $existingPackageInfoDirectory = Join-Path $OutputRoot ([string]$existing.packageInfoDirectory)
        $canReuse = $existing.sourceCommit -eq $sourceCommit -and
            $existing.targetHost -eq $TargetHost -and
            $existing.harnessVersion -eq $harnessVersion -and
            (Test-Path -LiteralPath $existingGraphPath) -and
            (Test-Path -LiteralPath $existingCasesPath) -and
            (Test-Path -LiteralPath $existingPackageInfoDirectory) -and
            (Get-FileHash -Algorithm SHA256 -LiteralPath $existingGraphPath).Hash.ToLowerInvariant() -eq $existing.checkoutGraphSha256 -and
            (Get-FileHash -Algorithm SHA256 -LiteralPath $existingCasesPath).Hash.ToLowerInvariant() -eq $existing.casesSha256 -and
            (Get-SparseCheckoutValidationDirectoryHash $existingPackageInfoDirectory) -eq $existing.packageInfoSha256
    }
    catch {
        Write-Warning "Existing validation manifest is incomplete: $($_.Exception.Message)"
    }
    if ($canReuse) {
        Write-Host "Reusing validation inputs for $sourceCommit at $OutputRoot"
        return $existing
    }
    Write-Warning 'Existing validation inputs do not match the commit, host scope, harness, or graph hash; regenerating them.'
}

if (Test-Path -LiteralPath $OutputRoot) {
    Remove-Item -LiteralPath $OutputRoot -Recurse -Force
}
$packageInfoDirectory = Join-Path $OutputRoot 'PackageInfo'
$sourceDirectory = Join-Path $OutputRoot 'source'
New-Item -ItemType Directory -Path $packageInfoDirectory, $sourceDirectory -Force | Out-Null

# PackageInfo defines the production artifact identity and root. Keep discovery independent from
# sparse projection so an unavailable graph cannot silently shrink the validation universe.
$savedGraphEnvironment = $env:AZURESDK_BUILD_SPARSE_CHECKOUT_GRAPH
try {
    $env:AZURESDK_BUILD_SPARSE_CHECKOUT_GRAPH = $null
    Invoke-CheckedCommand 'pwsh' @(
        '-NoProfile', '-NonInteractive', '-File',
        (Join-Path $RepoRoot 'eng/common/scripts/Save-Package-Properties.ps1'),
        '-outDirectory', $packageInfoDirectory
    ) $RepoRoot
}
finally {
    $env:AZURESDK_BUILD_SPARSE_CHECKOUT_GRAPH = $savedGraphEnvironment
}

$packages = @(
    Get-ChildItem -LiteralPath $packageInfoDirectory -Filter '*.json' -File -Recurse |
        Sort-Object FullName |
        ForEach-Object { Get-Content -Raw -LiteralPath $_.FullName | ConvertFrom-Json -Depth 100 } |
        Where-Object { !$_.IncludedForValidation }
)
if ($packages.Count -eq 0) {
    throw 'PackageInfo discovery produced no direct artifacts.'
}

# Generate once with the same Linux-hosted, Debug, input-root policy used by the PR matrix seed.
$graphPath = Join-Path $sourceDirectory 'repository-project-graph.reader.json'
Invoke-CheckedCommand 'dotnet' @(
    'msbuild', '/m', '/nr:false', '/nologo', '/tl:off',
    '/t:GenerateRepositoryProjectGraphWithProjectGraph',
    (Join-Path $RepoRoot 'eng/service.proj'),
    "/p:RepositoryProjectGraphReaderPath=$graphPath",
    '/p:SkipServiceProjectImports=true',
    '/p:IncludeRepositoryProjectGraphInputCheckoutRoots=true',
    '/p:IncludeSrc=false', '/p:IncludeStress=false', '/p:IncludeSamples=false',
    '/p:IncludePerf=false', '/p:RunApiCompat=false', '/p:InheritDocEnabled=false',
    '/p:BuildProjectReferences=false'
) $RepoRoot

$sourceGraph = Get-Content -Raw -LiteralPath $graphPath | ConvertFrom-Json -Depth 100
$packageRoots = @($packages | ForEach-Object {
    $path = [string]$_.DirectoryPath
    if ([System.IO.Path]::IsPathRooted($path)) {
        $path = [System.IO.Path]::GetRelativePath($RepoRoot, $path)
    }
    [pscustomobject]@{
        artifactName = [string]$_.ArtifactName
        path = $path.Replace('\', '/').Trim('/')
    }
})

# Artifact runs are sufficient only when every unit-test project belongs to at least one singleton
# PackageInfo root. Preserve the exceptions explicitly instead of calling the campaign “all tests.”
$projectCoverage = @($sourceGraph.nodes | Where-Object {
    $_.projectPath.Replace('\', '/') -match '/tests/'
} | ForEach-Object {
    $projectPath = $_.projectPath.Replace('\', '/').TrimStart('/')
    $owners = @($packageRoots | Where-Object {
        $projectPath.StartsWith("$($_.path)/", [StringComparison]::OrdinalIgnoreCase)
    } | ForEach-Object artifactName | Sort-Object -Unique)
    [pscustomobject][ordered]@{
        projectPath = $projectPath
        artifactNames = $owners
        covered = $owners.Count -gt 0
    }
})
$projectCoveragePath = Join-Path $OutputRoot 'project-coverage.json'
$projectCoverage | ConvertTo-Json -Depth 20 -AsArray |
    Set-Content -LiteralPath $projectCoveragePath -Encoding utf8
$uncoveredTestProjects = @($projectCoverage | Where-Object { !$_.covered })
if ($uncoveredTestProjects.Count -gt 0) {
    Write-Warning "$($uncoveredTestProjects.Count) test projects are not owned by a production PackageInfo artifact; see '$projectCoveragePath'."
}

$checkoutGraphPath = Join-Path $OutputRoot 'checkout-graph.json'
Invoke-CheckedCommand 'dotnet' @(
    'msbuild', '/nologo', '/nr:false', '/v:minimal',
    '/t:CreateSparseCheckoutGraph',
    (Join-Path $RepoRoot 'eng/tools/RepositoryProjectGraph/RepositoryProjectGraph.csproj'),
    "/p:SparseCheckoutPackageInfoDirectory=$packageInfoDirectory",
    "/p:SparseCheckoutRepoRoot=$RepoRoot",
    "/p:SparseCheckoutSourceGraphPath=$graphPath",
    "/p:SparseCheckoutOutputPath=$checkoutGraphPath",
    "/p:SparseCheckoutSourceCommit=$sourceCommit"
) $RepoRoot

$checkoutGraph = Get-Content -Raw -LiteralPath $checkoutGraphPath | ConvertFrom-Json -Depth 100
if (!$checkoutGraph.isComplete -or $checkoutGraph.sourceCommit -ne $sourceCommit) {
    throw 'Sparse checkout projection is incomplete or has mismatched commit provenance.'
}

# Reuse the repository's matrix implementation. Each artifact can override the default matrix
# through PackageInfo.CIParameters.CIMatrixConfigs; identical configs are expanded only once.
. (Join-Path $RepoRoot 'eng/common/scripts/job-matrix/job-matrix-functions.ps1')
$defaultConfigs = @($MatrixConfigPath | ForEach-Object {
    [pscustomobject]@{ Path = $_; Selection = 'sparse'; NonSparseParameters = @() }
})
$matrixCache = @{}
$cases = [System.Collections.Generic.List[object]]::new()
$caseKeys = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)

foreach ($package in $packages) {
    $configs = @()
    $ciParameters = Get-ObjectValue $package 'CIParameters'
    if ($ciParameters) {
        $configs = @((Get-ObjectValue $ciParameters 'CIMatrixConfigs' @()))
    }
    if ($configs.Count -eq 0) { $configs = $defaultConfigs }

    foreach ($configReference in $configs) {
        $configKey = Get-ConfigKey $configReference
        if (!$matrixCache.ContainsKey($configKey)) {
            $relativePath = [string](Get-ObjectValue $configReference 'Path')
            $selection = [string](Get-ObjectValue $configReference 'Selection' 'sparse')
            $nonSparse = @((Get-ObjectValue $configReference 'NonSparseParameters' @()))
            $configPath = [System.IO.Path]::GetFullPath((Join-Path $RepoRoot $relativePath))
            if (!(Test-Path -LiteralPath $configPath)) {
                throw "Matrix config '$relativePath' for '$($package.ArtifactName)' does not exist."
            }
            $matrixConfig = GetMatrixConfigFromFile (Get-Content -Raw -LiteralPath $configPath)
            $matrixCache[$configKey] = @(GenerateMatrix `
                -config $matrixConfig `
                -selectFromMatrixType $selection `
                -nonSparseParameters $nonSparse `
                -skipEnvironmentVariables)
        }

        foreach ($entry in @($matrixCache[$configKey])) {
            $entryHost = Get-MatrixHost $entry
            if ($entryHost -eq 'macOS' -or ($TargetHost -ne 'All' -and $entryHost -ne $TargetHost)) {
                continue
            }
            $parameters = Get-ObjectValue $entry 'parameters'
            $matrixName = [string](Get-ObjectValue $entry 'name')
            $caseKey = "$($package.ArtifactName)|$matrixName"
            if (!$caseKeys.Add($caseKey)) {
                throw "Artifact '$($package.ArtifactName)' produced duplicate matrix entry '$matrixName'."
            }

            $buildConfiguration = [string](Get-ObjectValue $parameters 'BuildConfiguration' 'Debug')
            $cases.Add([pscustomobject][ordered]@{
                artifactName = [string]$package.ArtifactName
                packageName = [string]$package.Name
                directoryPath = [string]$package.DirectoryPath
                host = $entryHost
                matrixName = $matrixName
                targetFramework = [string](Get-ObjectValue $parameters 'TestTargetFramework')
                buildConfiguration = $buildConfiguration
                additionalTestArguments = [string](Get-ObjectValue $parameters 'AdditionalTestArguments' '')
                additionalTestFilters = [string](Get-ObjectValue $parameters 'AdditionalTestFilters' 'Placeholder!=DefaultIgnoreMe')
                collectCoverage = [bool](Get-ObjectValue $parameters 'CollectCoverage' $false)
                includeSourceProjects = !(Test-SparseCheckoutArtifactHasTestProjects $checkoutGraph ([string]$package.ArtifactName))
                # Preserve custom matrix variables because tests may branch on their environment form.
                matrixParameters = [pscustomobject]$parameters
                matrixConfig = [string](Get-ObjectValue $configReference 'Path')
            })
        }
    }
}

if ($cases.Count -eq 0) {
    throw "Matrix expansion produced no $TargetHost validation cases."
}
$sortedCases = @($cases | Sort-Object host, artifactName, matrixName)
$casesPath = Join-Path $OutputRoot 'cases.json'
$sortedCases | ConvertTo-Json -Depth 20 -AsArray |
    Set-Content -LiteralPath $casesPath -Encoding utf8

$manifest = [pscustomobject][ordered]@{
    schemaVersion = 1
    harnessVersion = $harnessVersion
    sourceCommit = $sourceCommit
    generatedAtUtc = [DateTime]::UtcNow.ToString('o')
    generatedOn = [System.Runtime.InteropServices.RuntimeInformation]::OSDescription
    targetHost = $TargetHost
    # Keep manifest paths portable so Linux-generated inputs can be copied to a Windows host.
    packageInfoDirectory = 'PackageInfo'
    packageInfoSha256 = Get-SparseCheckoutValidationDirectoryHash $packageInfoDirectory
    sourceGraphPath = 'source/repository-project-graph.reader.json'
    checkoutGraphPath = 'checkout-graph.json'
    checkoutGraphSha256 = (Get-FileHash -Algorithm SHA256 -LiteralPath $checkoutGraphPath).Hash.ToLowerInvariant()
    casesPath = 'cases.json'
    casesSha256 = (Get-FileHash -Algorithm SHA256 -LiteralPath $casesPath).Hash.ToLowerInvariant()
    projectCoveragePath = 'project-coverage.json'
    packageCount = $packages.Count
    caseCount = $sortedCases.Count
    testProjectCount = $projectCoverage.Count
    uncoveredTestProjectCount = $uncoveredTestProjects.Count
    matrixConfigs = @($matrixCache.Keys | Sort-Object)
}
$manifest | ConvertTo-Json -Depth 20 | Set-Content -LiteralPath $manifestPath -Encoding utf8

Write-Host "Sparse validation inputs: packages=$($packages.Count), cases=$($sortedCases.Count), testProjects=$($projectCoverage.Count), uncoveredTestProjects=$($uncoveredTestProjects.Count), host=$TargetHost"
Write-Host "Manifest: $manifestPath"
return $manifest
