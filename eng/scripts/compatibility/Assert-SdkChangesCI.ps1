#Requires -Version 7.0
# Report validation does not load MSBuild and must report errors collected on unsupported hosts.
<#
.SYNOPSIS
Enforces collected native SDK API verdicts after existing CI validations and before report publication.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true)][string]$SdkRepoPath,
    [Parameter(Mandatory = $true)][string]$ReportDirectory,
    [Parameter(Mandatory = $true)][AllowEmptyString()][string]$ProjectNames
)

$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 3
. (Join-Path $PSScriptRoot 'SdkChangesCI.Helpers.ps1')

$verdict = Test-SdkChangesCIReports -ReportDirectory $ReportDirectory -ProjectNames $ProjectNames -SdkRepoPath $SdkRepoPath
foreach ($errorMessage in $verdict.Errors) { LogError $errorMessage }
foreach ($project in $verdict.ApprovedOptOuts) {
    LogWarning "${project}: detected breaking changes remain published; CI enforcement is waived by eng/apicompatbaselines/ApiCompatVersionOptOut.txt."
}
LogInfo "SDK API result counts: $($verdict.Counts | ConvertTo-Json -Compress)"
LogInfo "Job status before report collection: $($verdict.PreviousJobStatus). Existing validation failures are not replaced by API compatibility results."
if ($verdict.Counts.notApplicable -gt 0) {
    LogWarning "$($verdict.Counts.notApplicable) package(s) are not applicable (no GA baseline or IncludeBuildOutput=false); compatibility was not evaluated for those packages."
}
if ($verdict.Counts.selected -eq 0) { LogInfo 'No packages were selected for SDK API comparison in this job.' }
if (!$verdict.Passed) { exit 1 }
