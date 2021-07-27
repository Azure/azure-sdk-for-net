<#
.SYNOPSIS
Filters PoliCheck Result.
.DESCRIPTION
This script will read data speciefied in one or more PoliCheckAllowList.yml files,
It then reamoves all allwed entries from the PoliCheckResult 
.PARAMETER PoliCheckResultFilePath
The Path to the PoliCheck Result. Usually named PoliCheck.sarif
.PARAMETER ServiceDirectory
If the PoliCheck scan is scoped to a particular service provide the ServiceDirectory
.PARAMETER AllowListLocation
A path to a folder containing yml defined policheck allowlist
.EXAMPLE
PS> ./FilterPoliCheckResults.ps1 -PoliCheckResultFilePath .\PoliCheck.sarif -ServiceDirectory <servicedirname> -AllowListLocation <location>
#>
[CmdletBinding()]
param(
  [Parameter(Mandatory=$true)]
  [String] $PoliCheckResultFilePath,
  [Parameter(Mandatory=$true)]
  [String] $ServiceDirectory,
  [Parameter(Mandatory=$true)]
  [String] $AllowListLocation,
  [String] $ToolsFeedUri="https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-tools/nuget/v2"
)

. (Join-path ${PSScriptRoot} logging.ps1)
. (Join-Path ${PSScriptRoot} Helpers PSModule-Helpers.ps1)

Install-ModuleIfNotInstalled -moduleName "powershell-yaml" `
-version 0.4.2 -repositoryUrl $ToolsFeedUri

$allowListFilePath = Join-Path $AllowListLocation "${ServiceDirectory}.yml"
$allowListData = @{}

if (Test-Path -Path $allowListFilePath)
{
    $allowListData = ConvertFrom-Yaml (Get-Content $allowListFilePath -Raw)
}
else
{
    LogError "Allow list path $allowListFilePath does not exist."
    exit 1
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

        $updatedLocations = @()

        foreach ($location in $result.locations)
        {
            $filePath = $location.physicalLocation.artifactLocation.uri
            $text = $location.physicalLocation.region.snippet.text
            $contextRegion = $location.physicalLocation.contextRegion.snippet.text

            if ($filePath.EndsWith("PoliCheckAllowList.yml"))
            {
                continue
            }

            if ($allowedEntries)
            {
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
            }

            $updatedLocations += $location
        }

        $result.locations = $updatedLocations

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
