# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

<#
.SYNOPSIS
.NET sample CI adapter for the language-neutral resource provisioner.
.DESCRIPTION
Checks .NET sample assignments for overlap before batch admission, then delegates Azure
operations to Invoke-ResourceProvisioning.ps1. Sample selection never changes the resource bundle.
#>
[CmdletBinding(DefaultParameterSetName = 'Provision')]
param(
    [Parameter(Mandatory, ParameterSetName = 'Provision')] [string] $PlanPath,
    [Parameter(Mandatory, ParameterSetName = 'Provision')] [string] $StatePath,
    [Parameter(Mandatory, ParameterSetName = 'Provision')] [ValidateSet('q1', 'q2', 'q3', 'q4')] [string] $QueueName,
    [Parameter(ParameterSetName = 'Provision')] [switch] $ConfirmProvisioning,
    [Parameter(Mandatory, ParameterSetName = 'Admission')] [string] $BatchPlanDirectory,
    [Parameter(ParameterSetName = 'Admission')] [string] $ResolvedPlanDirectory
)

$ErrorActionPreference = 'Stop'
if ($PSCmdlet.ParameterSetName -eq 'Admission') {
    . (Join-Path $PSScriptRoot 'DotNetSampleAssignmentHelpers.ps1')
    $files = @(Get-ChildItem -LiteralPath $BatchPlanDirectory -Filter 'deployment-plan.json' -Recurse -File)
    if ($files.Count -lt 1 -or $files.Count -gt 4) { throw 'Expected one to four fresh queue plans.' }
    $assignedTests = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    $queues = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    foreach ($file in $files) {
        $queue = $file.Directory.Name
        $plan = Get-Content -LiteralPath $file.FullName -Raw | ConvertFrom-Json -AsHashtable
        Assert-DotNetSampleAssignment -Assignment $plan -QueueName $queue
        if (-not $queues.Add($queue)) { throw "Duplicate deployment plan for queue '$queue'." }
        foreach ($test in $plan.selectedTests) {
            if (-not $assignedTests.Add($test.fullName)) {
                throw "Sample '$($test.fullName)' is assigned to more than one queue."
            }
        }
    }
}
& (Join-Path $PSScriptRoot 'shared/Invoke-ResourceProvisioning.ps1') @PSBoundParameters
