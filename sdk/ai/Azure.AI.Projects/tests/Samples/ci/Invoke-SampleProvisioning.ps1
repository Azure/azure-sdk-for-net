# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

<#
.SYNOPSIS
Python sample CI adapter for the language-neutral resource provisioner.
.DESCRIPTION
Checks the pytest-node partition before batch admission, then delegates Azure operations
to Invoke-ResourceProvisioning.ps1. Python sample selection never changes the resource
bundle. Other SDK languages call the shared provisioner directly with infrastructure plans.
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
    . (Join-Path $PSScriptRoot 'PythonSampleCiHelpers.ps1')
    $plans = @(Get-ChildItem -LiteralPath $BatchPlanDirectory -Filter 'deployment-plan.json' -Recurse -File |
        ForEach-Object { Get-Content -LiteralPath $_.FullName -Raw | ConvertFrom-Json -AsHashtable })
    if ($plans.Count -lt 1 -or $plans.Count -gt 4) { throw 'Expected one to four fresh queue plans.' }
    Assert-PythonSamplePartition -Plans $plans
}
& (Join-Path $PSScriptRoot 'Invoke-ResourceProvisioning.ps1') @PSBoundParameters
