#Requires -Version 7.0
<#
.SYNOPSIS
Collects native SDK API change reports for the packages selected by this CI job.
.DESCRIPTION
ReportOnly defers enforcement until existing build validations have finished.
Every invocation creates a new report directory; failed output is never replayable as a successful report.
The summary records the executing PowerShell/runtime, prior job status, selection, and per-package outcomes.
Each package has result.json and either an unchanged sdk-changes.json or error.json and optional quarantined output.
CI publishes this directory even when Assert-SdkChangesCI.ps1 rejects breaking changes or detector errors.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string]$SdkRepoPath,
    [Parameter(Mandatory = $true)][string]$PackageInfoDirectory,
    [Parameter(Mandatory = $true)][AllowEmptyString()][string]$ProjectNames,
    [Parameter(Mandatory = $true)][string]$ReportRoot,
    [ValidateRange(1, 3600)][int]$TimeoutSeconds = 300,
    [switch]$ReportOnly
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot 'SdkChangesCI.Helpers.ps1')

$result = Invoke-SdkChangesCICollection -SdkRepoPath $SdkRepoPath -PackageInfoDirectory $PackageInfoDirectory `
    -ProjectNames $ProjectNames -ReportRoot $ReportRoot -TimeoutSeconds $TimeoutSeconds -PreviousJobStatus $env:AGENT_JOBSTATUS
LogInfo "SDK API reports: $($result.Directory)"
LogInfo "SDK API result counts: $($result.Summary.counts | ConvertTo-Json -Compress)"
if (!$ReportOnly) {
    $verdict = Test-SdkChangesCIReports -ReportDirectory $result.Directory -ProjectNames $ProjectNames
    foreach ($errorMessage in $verdict.Errors) { LogError $errorMessage }
    if (!$verdict.Passed) { exit 1 }
}
