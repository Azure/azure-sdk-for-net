<#
.SYNOPSIS
Queries Azure DevOps Analytics for test assembly runtimes and writes per-package weights.

.DESCRIPTION
The PackageInfo files identify the packages required by the generated PR matrix. This script
maps those packages to their test assemblies, queries successful executions from the preceding
24 hours, and uses a 30-day fallback query for assemblies without recent data.

Each assembly receives at least a one-second weight. Package weights are the sum of their
assembly weights and are consumed by Apply-WeightedBatching.ps1.

.PARAMETER RepoRoot
Root directory of the azure-sdk-for-net repository.

.PARAMETER PackageInfoFolder
Folder containing the PackageInfo JSON files for the generated matrix.

.PARAMETER OutputFile
Path to write the package weight JSON file.

.PARAMETER PipelineId
Azure DevOps pipeline ID to query. The default is net - pullrequest.

.PARAMETER AccessToken
Azure DevOps access token used to query Analytics.

.PARAMETER MinimumCoveragePercent
Minimum percentage of target assemblies that must have runtime history after both query windows.
The default of 10 rejects empty or nearly empty Analytics results without requiring comprehensive
coverage. At least one observation is required whenever target assemblies exist.

.PARAMETER MaxRetryAttempts
Maximum number of attempts for transient Analytics request failures.

.PARAMETER RetryBaseDelaySeconds
Delay in seconds between retry attempts.
#>

[CmdletBinding()]
param (
  [Parameter(Mandatory = $true)][string]$RepoRoot,
  [Parameter(Mandatory = $true)][string]$PackageInfoFolder,
  [Parameter(Mandatory = $true)][string]$OutputFile,
  [Parameter()][int]$PipelineId = 7327,
  [Parameter()][string]$OrgUrl = "https://analytics.dev.azure.com/azure-sdk",
  [Parameter()][string]$ProjectId = "29ec6040-b234-4e31-b139-33dc4287b756",
  [Parameter()][string]$AccessToken = $env:SYSTEM_ACCESSTOKEN,
  [Parameter()][int]$DefaultWeight = 1,
  [Parameter()][int]$MinimumCoveragePercent = 10,
  [Parameter()][int]$QueryBatchSize = 20,
  [Parameter()][int]$ThrottleLimit = 5,
  [Parameter()][int]$MaxRetryAttempts = 3,
  [Parameter()][int]$RetryBaseDelaySeconds = 2
)

Set-StrictMode -Version 4
$ErrorActionPreference = "Stop"

function Get-TargetAssemblyMap {
  param(
    [Parameter(Mandatory = $true)][string]$RepoRoot,
    [Parameter(Mandatory = $true)][string]$PackageInfoFolder
  )

  $packageInfoFiles = @(Get-ChildItem -Path $PackageInfoFolder -Filter "*.json" -File -Recurse)
  if ($packageInfoFiles.Count -eq 0) {
    throw "No PackageInfo files were found in '$PackageInfoFolder'."
  }

  $packageAssemblies = [ordered]@{}
  $assemblyToPackage = @{}

  foreach ($file in ($packageInfoFiles | Sort-Object FullName)) {
    $packageInfo = Get-Content $file.FullName -Raw | ConvertFrom-Json
    $packageName = [string]$packageInfo.ArtifactName
    if ([string]::IsNullOrWhiteSpace($packageName)) {
      throw "PackageInfo '$($file.FullName)' does not contain an ArtifactName."
    }

    $packageAssemblies[$packageName] = @()
    $directoryPath = [string]$packageInfo.DirectoryPath
    if ([string]::IsNullOrWhiteSpace($directoryPath)) {
      Write-Warning "Package '$packageName' has no DirectoryPath and will use the default weight."
      continue
    }

    $packagePath = if ([System.IO.Path]::IsPathRooted($directoryPath)) {
      $directoryPath
    }
    else {
      Join-Path $RepoRoot $directoryPath
    }

    $testsPath = Join-Path $packagePath "tests"
    $assemblies = @(
      Get-ChildItem -Path $testsPath -Filter "*.csproj" -File -Recurse -ErrorAction SilentlyContinue |
        ForEach-Object { "$($_.BaseName.ToLowerInvariant()).dll" } |
        Sort-Object -Unique
    )

    foreach ($assembly in $assemblies) {
      if ($assemblyToPackage.ContainsKey($assembly) -and $assemblyToPackage[$assembly] -ne $packageName) {
        throw "Test assembly '$assembly' is mapped to both '$($assemblyToPackage[$assembly])' and '$packageName'."
      }
      $assemblyToPackage[$assembly] = $packageName
    }

    $packageAssemblies[$packageName] = $assemblies
  }

  return [PSCustomObject]@{
    PackageAssemblies = $packageAssemblies
    AssemblyToPackage = $assemblyToPackage
  }
}

function New-TestResultsQueries {
  param(
    [Parameter(Mandatory = $true)][string[]]$Assemblies,
    [Parameter(Mandatory = $true)][datetime]$StartTime,
    [Parameter(Mandatory = $true)][datetime]$EndTime,
    [Parameter(Mandatory = $true)][string]$OrgUrl,
    [Parameter(Mandatory = $true)][string]$ProjectId,
    [Parameter(Mandatory = $true)][int]$PipelineId,
    [Parameter(Mandatory = $true)][int]$BatchSize
  )

  if ($BatchSize -le 0) {
    throw "BatchSize must be greater than zero."
  }

  $queries = @()
  $start = $StartTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
  $end = $EndTime.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ")
  $sortedAssemblies = @($Assemblies | Sort-Object -Unique)

  for ($index = 0; $index -lt $sortedAssemblies.Count; $index += $BatchSize) {
    $lastIndex = [math]::Min($index + $BatchSize - 1, $sortedAssemblies.Count - 1)
    $batch = @($sortedAssemblies[$index..$lastIndex])
    $containerFilter = ($batch | ForEach-Object {
      "Test/ContainerName eq '$($_.Replace("'", "''"))'"
    }) -join " or "

    $apply = "filter(CompletedDate gt $start and CompletedDate lt $end and " +
      "Pipeline/PipelineId eq $PipelineId and Outcome eq 'Passed' and ($containerFilter))" +
      "/groupby((Test/ContainerName, TestRun/TestRunId), " +
      "aggregate(StartedDate with min as S, CompletedDate with max as E))"

    $queries += [PSCustomObject]@{
      Batch      = [int]($queries.Count + 1)
      Assemblies = $batch
      Url        = "$OrgUrl/$ProjectId/_odata/v4.0-preview/TestResults?`$apply=$apply&`$top=5000"
    }
  }

  return $queries
}

function Invoke-TestResultsQueries {
  param(
    [Parameter(Mandatory = $true)][object[]]$Queries,
    [Parameter(Mandatory = $true)][string]$AccessToken,
    [Parameter(Mandatory = $true)][int]$ThrottleLimit,
    [Parameter(Mandatory = $true)][string]$WindowLabel,
    [Parameter(Mandatory = $true)][int]$MaxRetryAttempts,
    [Parameter(Mandatory = $true)][int]$RetryBaseDelaySeconds
  )

  if ($Queries.Count -eq 0) {
    return @()
  }

  $results = @($Queries | ForEach-Object -Parallel {
    $query = $_
    try {
      $rows = @()
      $nextUrl = $query.Url
      while ($nextUrl) {
        # PowerShell retries transient web failures such as connection errors, 408, 429, and 5xx.
        $response = Invoke-RestMethod -Uri $nextUrl -Headers @{
          Authorization = "Bearer $using:AccessToken"
          Accept = "application/json"
        } -MaximumRetryCount $using:MaxRetryAttempts -RetryIntervalSec $using:RetryBaseDelaySeconds
        $rows += @($response.value)
        $nextLinkProperty = $response.PSObject.Properties['@odata.nextLink']
        $nextUrl = if ($nextLinkProperty) { $nextLinkProperty.Value } else { $null }
      }

      [PSCustomObject]@{
        Batch = $query.Batch
        Rows  = $rows
        Error = $null
      }
    }
    catch {
      $errorDetails = [System.Collections.Generic.List[string]]@($_.Exception.Message)
      $response = $_.Exception.Response
      if ($response) {
        $errorDetails.Add("HTTP status: $([int]$response.StatusCode) $($response.ReasonPhrase)")

        foreach ($headerName in @("X-TFS-Session", "X-VSS-E2EID", "ActivityId")) {
          if ($response.Headers.Contains($headerName)) {
            $headerValue = ($response.Headers.GetValues($headerName) -join ",")
            $errorDetails.Add("${headerName}: $headerValue")
          }
        }

        $responseBody = $_.ErrorDetails.Message
        if ([string]::IsNullOrWhiteSpace($responseBody) -and $response.Content) {
          try {
            $responseBody = $response.Content.ReadAsStringAsync().GetAwaiter().GetResult()
          }
          catch {
            $errorDetails.Add("Response body could not be read: $($_.Exception.Message)")
          }
        }
        if (-not [string]::IsNullOrWhiteSpace($responseBody)) {
          $responseBody = $responseBody -replace "\s+", " "
          if ($responseBody.Length -gt 2000) {
            $responseBody = $responseBody.Substring(0, 2000) + "..."
          }
          $errorDetails.Add("Response body: $responseBody")
        }
      }

      [PSCustomObject]@{
        Batch = $query.Batch
        Rows  = @()
        Error = $errorDetails -join "; "
      }
    }
  } -ThrottleLimit $ThrottleLimit)

  $failures = @($results | Where-Object { $_.Error })
  if ($failures.Count -gt 0) {
    $details = ($failures | Sort-Object Batch | ForEach-Object {
      "batch $($_.Batch): $($_.Error)"
    }) -join "; "
    throw "Azure DevOps Analytics $WindowLabel query failed: $details"
  }

  foreach ($result in ($results | Sort-Object Batch)) {
    Write-Host "  $WindowLabel batch $($result.Batch)/$($Queries.Count): $(@($result.Rows).Count) rows"
  }

  return @($results | ForEach-Object { $_.Rows })
}

function Add-TestResultDurations {
  param(
    [Parameter(Mandatory = $true)][AllowEmptyCollection()][object[]]$Rows,
    [Parameter(Mandatory = $true)][hashtable]$Durations
  )

  foreach ($row in $Rows) {
    $assembly = [string]$row.Test.ContainerName
    if ([string]::IsNullOrWhiteSpace($assembly) -or -not $row.S -or -not $row.E) {
      continue
    }

    $assembly = $assembly.ToLowerInvariant()
    $duration = [math]::Max(
      1,
      [int][math]::Round(([datetime]$row.E - [datetime]$row.S).TotalSeconds)
    )

    if (-not $Durations.ContainsKey($assembly)) {
      $Durations[$assembly] = [System.Collections.Generic.List[int]]::new()
    }
    $Durations[$assembly].Add($duration)
  }
}

function Assert-MinimumDataCoverage {
  param(
    [Parameter(Mandatory = $true)][AllowEmptyCollection()][string[]]$Assemblies,
    [Parameter(Mandatory = $true)][hashtable]$Durations,
    [Parameter(Mandatory = $true)][int]$MinimumCoveragePercent
  )

  # Packages without candidate test assemblies legitimately have no Analytics observations.
  if ($Assemblies.Count -eq 0) {
    return
  }

  $observedCount = @($Assemblies | Where-Object {
    $runs = $Durations[$_]
    $runs -and $runs.Count -gt 0
  }).Count
  $requiredCount = [math]::Max(
    1,
    [int][math]::Ceiling($Assemblies.Count * $MinimumCoveragePercent / 100.0)
  )
  $coveragePercent = [math]::Round($observedCount * 100.0 / $Assemblies.Count, 1)

  if ($observedCount -lt $requiredCount) {
    throw "Azure DevOps Analytics runtime history covers $observedCount of $($Assemblies.Count) test assembly candidates ($coveragePercent%), below the required $requiredCount ($MinimumCoveragePercent% minimum)."
  }

  Write-Host "Runtime history coverage: $observedCount/$($Assemblies.Count) assemblies ($coveragePercent%; required: $requiredCount)."
}

function Get-ResolvedPackageWeights {
  param(
    [Parameter(Mandatory = $true)]$PackageAssemblies,
    [Parameter(Mandatory = $true)][hashtable]$Durations,
    [Parameter(Mandatory = $true)][int]$DefaultWeight
  )

  $assemblyWeights = @{}
  $packageWeights = [ordered]@{}

  foreach ($packageName in ($PackageAssemblies.Keys | Sort-Object)) {
    $assemblies = @($PackageAssemblies[$packageName])
    [int]$packageWeight = 0

    foreach ($assembly in $assemblies) {
      $runs = $Durations[$assembly]
      $weight = if ($runs -and $runs.Count -gt 0) {
        [math]::Max(
          $DefaultWeight,
          [int][math]::Round(($runs | Measure-Object -Average).Average)
        )
      }
      else {
        $DefaultWeight
      }

      $assemblyWeights[$assembly] = $weight
      $packageWeight += $weight
    }

    $packageWeights[$packageName] = [math]::Max($packageWeight, $DefaultWeight)
  }

  return [PSCustomObject]@{
    AssemblyWeights = $assemblyWeights
    PackageWeights  = $packageWeights
  }
}

if ([string]::IsNullOrWhiteSpace($AccessToken)) {
  throw "SYSTEM_ACCESSTOKEN is required to query Azure DevOps Analytics."
}
if ($DefaultWeight -le 0) {
  throw "DefaultWeight must be greater than zero."
}
if ($MinimumCoveragePercent -le 0 -or $MinimumCoveragePercent -gt 100) {
  throw "MinimumCoveragePercent must be between 1 and 100."
}
if ($ThrottleLimit -le 0) {
  throw "ThrottleLimit must be greater than zero."
}
if ($MaxRetryAttempts -le 0) {
  throw "MaxRetryAttempts must be greater than zero."
}
if ($RetryBaseDelaySeconds -le 0) {
  throw "RetryBaseDelaySeconds must be greater than zero."
}

$stopwatch = [Diagnostics.Stopwatch]::StartNew()
$targetMap = Get-TargetAssemblyMap -RepoRoot $RepoRoot -PackageInfoFolder $PackageInfoFolder
$allAssemblies = @($targetMap.AssemblyToPackage.Keys | Sort-Object)
$durations = @{}

Write-Host "Resolved $($targetMap.PackageAssemblies.Count) packages to $($allAssemblies.Count) test assemblies."

if ($allAssemblies.Count -gt 0) {
  $now = [datetime]::UtcNow
  $recentStart = $now.AddHours(-24)
  $recentQueries = @(New-TestResultsQueries `
    -Assemblies $allAssemblies `
    -StartTime $recentStart `
    -EndTime $now `
    -OrgUrl $OrgUrl `
    -ProjectId $ProjectId `
    -PipelineId $PipelineId `
    -BatchSize $QueryBatchSize)

  Write-Host "Querying the preceding 24 hours in $($recentQueries.Count) scoped batches..."
  $recentRows = @(Invoke-TestResultsQueries `
    -Queries $recentQueries `
    -AccessToken $AccessToken `
    -ThrottleLimit $ThrottleLimit `
    -WindowLabel "24-hour" `
    -MaxRetryAttempts $MaxRetryAttempts `
    -RetryBaseDelaySeconds $RetryBaseDelaySeconds)
  Add-TestResultDurations -Rows $recentRows -Durations $durations

  $missingAssemblies = @($allAssemblies | Where-Object { -not $durations.ContainsKey($_) })
  if ($missingAssemblies.Count -gt 0) {
    $fallbackQueries = @(New-TestResultsQueries `
      -Assemblies $missingAssemblies `
      -StartTime $now.AddDays(-30) `
      -EndTime $recentStart `
      -OrgUrl $OrgUrl `
      -ProjectId $ProjectId `
      -PipelineId $PipelineId `
      -BatchSize $QueryBatchSize)

    Write-Host "Querying the preceding 30 days for $($missingAssemblies.Count) missing assemblies..."
    $fallbackRows = @(Invoke-TestResultsQueries `
      -Queries $fallbackQueries `
      -AccessToken $AccessToken `
      -ThrottleLimit $ThrottleLimit `
      -WindowLabel "30-day fallback" `
      -MaxRetryAttempts $MaxRetryAttempts `
      -RetryBaseDelaySeconds $RetryBaseDelaySeconds)
    Add-TestResultDurations -Rows $fallbackRows -Durations $durations
  }
}

# Reject successful but catastrophically sparse query results before one-second fallbacks can
# collapse many packages into a small number of oversized buckets.
Assert-MinimumDataCoverage `
  -Assemblies $allAssemblies `
  -Durations $durations `
  -MinimumCoveragePercent $MinimumCoveragePercent

$resolvedWeights = Get-ResolvedPackageWeights `
  -PackageAssemblies $targetMap.PackageAssemblies `
  -Durations $durations `
  -DefaultWeight $DefaultWeight

$fallbackCount = @($allAssemblies | Where-Object { -not $durations.ContainsKey($_) }).Count
Write-Host "Resolved package test weights ($fallbackCount assemblies use the ${DefaultWeight}s fallback):"
foreach ($packageName in $resolvedWeights.PackageWeights.Keys) {
  $assemblies = @($targetMap.PackageAssemblies[$packageName])
  $assemblyDetails = if ($assemblies.Count -eq 0) {
    "<none>"
  }
  else {
    ($assemblies | ForEach-Object {
      $suffix = if ($durations.ContainsKey($_)) { "" } else { " fallback" }
      "$_=$($resolvedWeights.AssemblyWeights[$_])s$suffix"
    }) -join ", "
  }

  Write-Host "  $packageName | weight=$($resolvedWeights.PackageWeights[$packageName])s | assemblies: $assemblyDetails"
}

$outputDirectory = Split-Path -Parent $OutputFile
if ($outputDirectory -and -not (Test-Path $outputDirectory)) {
  New-Item -Path $outputDirectory -ItemType Directory -Force | Out-Null
}

$resolvedWeights.PackageWeights |
  ConvertTo-Json -Depth 2 |
  Set-Content $OutputFile -Encoding utf8

$stopwatch.Stop()
Write-Host "Test assembly weights written to $OutputFile in $([math]::Round($stopwatch.Elapsed.TotalSeconds, 1))s."
