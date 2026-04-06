<#
.SYNOPSIS
Queries Azure DevOps OData Analytics API for test assembly wall-clock runtimes and outputs
per-package weights for use by weighted test batching.

.DESCRIPTION
This script scans the repo's sdk/ directory to map test assemblies to their parent packages,
then queries the Azure DevOps Analytics OData API to get wall-clock runtimes for each assembly.
It uses a 24-hour window with a 30-day fallback for assemblies not found in the recent window.

The output is a JSON file mapping package names to their total test runtime in seconds.

.PARAMETER RepoRoot
Root directory of the azure-sdk-for-net repository.

.PARAMETER OutputFile
Path to write the JSON weights file.

.PARAMETER PipelineId
Azure DevOps pipeline ID to query. Default is 7327 (net - pullrequest).

.PARAMETER OrgUrl
Azure DevOps organization URL.

.PARAMETER ProjectId
Azure DevOps project ID.

.PARAMETER AccessToken
Access token for Azure DevOps API authentication.

.PARAMETER TargetAssemblies
Optional list of specific assembly names to query. If not provided, discovers all test assemblies.

.EXAMPLE
./eng/scripts/Get-TestAssemblyWeights.ps1 `
  -RepoRoot "." `
  -OutputFile "test-weights.json" `
  -AccessToken $env:SYSTEM_ACCESSTOKEN
#>

[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)][string]$RepoRoot,
  [Parameter(Mandatory = $true)][string]$OutputFile,
  [Parameter()][string]$PackageInfoFolder = "",
  [Parameter()][int]$PipelineId = 7327,
  [Parameter()][string]$OrgUrl = "https://analytics.dev.azure.com/azure-sdk",
  [Parameter()][string]$ProjectId = "29ec6040-b234-4e31-b139-33dc4287b756",
  [Parameter()][string]$AccessToken = $env:SYSTEM_ACCESSTOKEN,
  [Parameter()][int]$DefaultWeight = 1,
  [Parameter()][int]$BatchSize = 20,
  [Parameter()][int]$ThrottleLimit = 5
)

Set-StrictMode -Version 4
$ErrorActionPreference = "Continue"

if (-not $AccessToken) {
  Write-Warning "No access token provided. Writing empty weights file."
  "{}" | Set-Content $OutputFile
  exit 0
}

# Build assembly-to-package mapping by scanning sdk/ directory structure
Write-Host "Scanning $RepoRoot/sdk/ for test assemblies..."
$assemblyToPackage = @{}
foreach ($serviceDir in (Get-ChildItem (Join-Path $RepoRoot "sdk") -Directory)) {
  foreach ($packageDir in (Get-ChildItem $serviceDir.FullName -Directory)) {
    $srcDir = Join-Path $packageDir.FullName "src"
    $srcProj = Get-ChildItem $srcDir -Filter "*.csproj" -ErrorAction SilentlyContinue | Select-Object -First 1
    if ($srcProj) {
      $testsDir = Join-Path $packageDir.FullName "tests"
      Get-ChildItem $testsDir -Filter "*.csproj" -Recurse -ErrorAction SilentlyContinue | ForEach-Object {
        $asmName = $_.BaseName.ToLower() + ".dll"
        $assemblyToPackage[$asmName] = $srcProj.BaseName
      }
    }
  }
}
Write-Host "Found $($assemblyToPackage.Count) test assemblies mapped to packages."

# Scope to packages in PackageInfo folder if provided
$targetPackages = $null
if ($PackageInfoFolder -and (Test-Path $PackageInfoFolder)) {
  $packageInfoFiles = @(Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -Recurse)
  if ($packageInfoFiles.Count -gt 0) {
    $targetPackages = [System.Collections.Generic.HashSet[string]]::new()
    foreach ($f in $packageInfoFiles) {
      $json = Get-Content $f.FullName | ConvertFrom-Json
      if ($json.ArtifactName) { [void]$targetPackages.Add($json.ArtifactName) }
    }
    Write-Host "Scoping to $($targetPackages.Count) packages from PackageInfo folder."

    # Filter assemblies to only those belonging to target packages
    $scopedAssemblies = @($assemblyToPackage.GetEnumerator() | Where-Object { $targetPackages.Contains($_.Value) } | ForEach-Object { $_.Key } | Sort-Object)
    Write-Host "Scoped to $($scopedAssemblies.Count) assemblies (from $($assemblyToPackage.Count) total)."
  }
}

$allAssemblies = if ($scopedAssemblies) { $scopedAssemblies } else { @($assemblyToPackage.Keys | Sort-Object) }
if ($allAssemblies.Count -eq 0) {
  Write-Warning "No test assemblies found. Writing empty weights file."
  "{}" | Set-Content $OutputFile
  exit 0
}

# Build OData query URLs for a batch of assemblies
function Build-QueryUrls {
  param([string[]]$Assemblies, [string]$StartDate, [string]$EndDate)

  $urls = @()
  for ($i = 0; $i -lt $Assemblies.Count; $i += $BatchSize) {
    $end = [math]::Min($i + $BatchSize - 1, $Assemblies.Count - 1)
    $batch = $Assemblies[$i..$end]
    $containerFilter = ($batch | ForEach-Object { "Test/ContainerName eq '$_'" }) -join " or "
    $dateFilter = "CompletedDate gt $StartDate"
    if ($EndDate) { $dateFilter += " and CompletedDate lt $EndDate" }

    $url = "$OrgUrl/$ProjectId/_odata/v4.0-preview/TestResults?" +
      "`$apply=filter($dateFilter and Pipeline/PipelineId eq $PipelineId and Outcome eq 'Passed' and ($containerFilter))" +
      "/groupby((Test/ContainerName, TestRun/TestRunId), aggregate(StartedDate with min as S, CompletedDate with max as E))" +
      "&`$top=5000"
    $urls += $url
  }
  return $urls
}

# Query the API in parallel batches
function Invoke-ParallelQueries {
  param([string[]]$Urls, [string]$Token)

  $results = $Urls | ForEach-Object -Parallel {
    try {
      $response = Invoke-WebRequest $_ -Headers @{
        Authorization = "Bearer $using:Token"
        Accept = "application/json"
      } -UseBasicParsing
      ($response.Content | ConvertFrom-Json).value
    }
    catch {
      Write-Warning "Query failed: $($_.Exception.Message)"
      @()
    }
  } -ThrottleLimit $ThrottleLimit

  return $results
}

# Process API results into per-assembly average wall-clock seconds
function Process-Results {
  param($Rows, [hashtable]$Target)

  foreach ($row in $Rows) {
    if (-not $row.Test) { continue }
    $name = $row.Test.ContainerName
    $wallClock = [int][math]::Round(([datetime]$row.E - [datetime]$row.S).TotalSeconds)
    if ($wallClock -lt 0) { $wallClock = 0 }
    if (-not $Target[$name]) { $Target[$name] = @() }
    $Target[$name] += $wallClock
  }
}

$stopwatch = [Diagnostics.Stopwatch]::StartNew()
$assemblyWeights = @{}

# Single 7-day query — covers weekdays even if run on weekends
$now = [datetime]::UtcNow
$start7d = $now.AddDays(-7).ToString("yyyy-MM-ddTHH:mm:ssZ")
$end7d = $now.ToString("yyyy-MM-ddTHH:mm:ssZ")

$urls = Build-QueryUrls -Assemblies $allAssemblies -StartDate $start7d -EndDate $end7d
Write-Host "Querying 7-day window ($($urls.Count) batches, $($allAssemblies.Count) assemblies)..."

try {
  $results = Invoke-ParallelQueries -Urls $urls -Token $AccessToken
  Process-Results -Rows $results -Target $assemblyWeights
}
catch {
  Write-Warning "Query failed: $($_.Exception.Message)"
}

$missing = @($allAssemblies | Where-Object { -not $assemblyWeights[$_] })
Write-Host "  Found $($assemblyWeights.Count) assemblies, $($missing.Count) missing (will default to ${DefaultWeight}s)."

$stopwatch.Stop()
Write-Host "Total query time: $([math]::Round($stopwatch.ElapsedMilliseconds / 1000, 1))s"

# Aggregate: average wall-clock per assembly, then sum per package
$packageWeights = @{}
foreach ($pkg in ($assemblyToPackage.Values | Sort-Object -Unique)) {
  [int]$totalWeight = 0
  $assemblyToPackage.GetEnumerator() | Where-Object { $_.Value -eq $pkg } | ForEach-Object {
    $runs = $assemblyWeights[$_.Key]
    if ($runs -and $runs.Count -gt 0) {
      $totalWeight += [int][math]::Round(($runs | Measure-Object -Average).Average)
    }
  }
  if ($totalWeight -le 0) { $totalWeight = $DefaultWeight }
  $packageWeights[$pkg] = $totalWeight
}

Write-Host "Generated weights for $($packageWeights.Count) packages."
$packageWeights | ConvertTo-Json -Depth 1 | Set-Content $OutputFile -Encoding utf8
Write-Host "Weights written to $OutputFile"
