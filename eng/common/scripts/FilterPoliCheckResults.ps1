<#
.SYNOPSIS
Filters PoliCheck Result.
.DESCRIPTION
This script will read data speciefied in one or more PoliCheckAllowList.yml files,
It then reamoves all allwed entries from the PoliCheckResult 
.PARAMETER PoliCheckResultFilePath
The Path to the PoliCheck Result. Usually named PoliCheck.sarif
.PARAMETER ServiceDirtectory
If the PoliCheck scan is scoped to a particular service provide the ServiceDirectory
.EXAMPLE
PS> ./FilterPoliCheckResults.ps1 -PoliCheckResultFilePath .\PoliCheck.sarif
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory=$true)]
  [String] $PoliCheckResultFilePath,
  [String] $ServiceDirtectory
)

. "${PSScriptRoot}\logging.ps1"

$RepoRoot = Resolve-Path -Path "${PSScriptRoot}\..\..\..\"
$PathToAllowListFiles = Join-Path $RepoRoot $ServiceDirtectory
$PolicCheckAllowListFiles = Get-ChildItem -Path $PathToAllowListFiles -Recurse -File -Include "PoliCheckAllowList.yml"
$allowListData = @{}

# Combine all AllowLists Found
foreach ($file in $PolicCheckAllowListFiles)
{
    $allowListDataInFile = ConvertFrom-Yaml (Get-Content $file.FullName -Raw)
    $allowListData["PC1001"] += $allowListDataInFile["PC1001"]
    $allowListData["PC1002"] += $allowListDataInFile["PC1002"]
    $allowListData["PC1003"] += $allowListDataInFile["PC1003"]
    $allowListData["PC1004"] += $allowListDataInFile["PC1004"]
    $allowListData["PC1005"] += $allowListDataInFile["PC1005"]
    $allowListData["PC1006"] += $allowListDataInFile["PC1006"]
}

$poliCheckData = Get-Content $PoliCheckResultFilePath | ConvertFrom-Json
$poliCheckResultsCount = $poliCheckData.runs[0].results.Count
$newCount

$updatedRuns = @()

foreach ($run in $poliCheckData.runs)
{
    $updatedResults = @()
    foreach ($result in $run.results)
    {
        $ruleId = $result.ruleId
        $allowedEntries = $allowListData[$ruleId]
        if ($allowedEntries)
        {
            $updatedLocations = @()

            foreach ($location in $result.locations)
            {
                $filePath = $location.physicalLocation.artifactLocation.uri
                $text = $location.physicalLocation.region.snippet.text
                $contextRegion = $location.physicalLocation.contextRegion.snippet.text

                $allowedEntry = $allowedEntries[0] | Where-Object { $_.FilePath -eq $filePath }

                if ($allowedEntry.Count -gt 0)
                {
                    $foundAllowedInstance = $false
                    foreach ($instance in $allowedEntry.instances)
                    {
                        if (($instance.Text.Trim() -eq $text.Trim()) -and ($instance.ContextRegion.Trim() -eq $contextRegion.Trim()))
                        {
                            Write-Host "Found instance" -ForegroundColor Green
                            $foundAllowedInstance = $true
                        }
                    }
                    if ($foundAllowedInstance -eq $true)
                    {
                        continue
                    }
                }

                $updatedLocations += $location
            }

            $result.locations = $updatedLocations
        }

        if ($result.locations.Count -gt 0)
        {
            $updatedResults += $result 
        }
    }
    $run.results = $updatedResults
    $newCount = $run.results.Count
    $updatedRuns += $run
}

$poliCheckData.runs = $updatedRuns

Set-Content -Path $PoliCheckResultFilePath -Value ($poliCheckData | ConvertTo-Json -Depth 100)

LogDebug "Original Result Count: ${poliCheckResultsCount}"
LogDebug "New Result Count: ${newCount}"
