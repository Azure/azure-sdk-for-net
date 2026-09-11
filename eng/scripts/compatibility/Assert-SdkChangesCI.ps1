#Requires -Version 7.0
<#
.SYNOPSIS
Enforces collected native SDK API verdicts after existing CI validations and before report publication.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string]$ReportDirectory,
    [Parameter(Mandatory = $true)][AllowEmptyString()][string]$ProjectNames
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot 'SdkChangesCI.Helpers.ps1')

$verdict = Test-SdkChangesCIReports -ReportDirectory $ReportDirectory -ProjectNames $ProjectNames
foreach ($errorMessage in $verdict.Errors) { LogError $errorMessage }
LogInfo "SDK API result counts: $($verdict.Counts | ConvertTo-Json -Compress)"
LogInfo "Job status before report collection: $($verdict.PreviousJobStatus). Existing validation failures are not replaced by API compatibility results."
if ($verdict.Counts.notApplicable -gt 0) {
    LogWarning "$($verdict.Counts.notApplicable) package(s) have no GA baseline; compatibility was not evaluated for those packages."
}
if ($verdict.Counts.selected -eq 0) { LogInfo 'No packages were selected for SDK API comparison in this job.' }
if (!$verdict.Passed) { exit 1 }
