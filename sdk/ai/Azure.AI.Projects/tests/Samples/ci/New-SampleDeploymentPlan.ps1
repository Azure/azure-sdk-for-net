# Copyright (c) Microsoft Corporation.
# Licensed under the MIT License.
#Requires -Version 7.2

<#
.SYNOPSIS
Adds a .NET queue assignment from New-SampleTestPlan.ps1 to the shared offline deployment plan.
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory)] [string] $SelectionManifest,
    [Parameter(Mandatory)] [string] $OutputDirectory,
    [Parameter(Mandatory)] [ValidateSet('q1', 'q2', 'q3', 'q4')] [string] $QueueName,
    [Parameter(Mandatory)] [AllowEmptyString()] [string] $IdentityResourceGroup,
    [ValidatePattern('^[A-Za-z0-9._-]+$')] [string] $ModelName = 'gpt-5.2',
    [ValidatePattern('^[A-Za-z0-9._-]+$')] [string] $ModelVersion = '2025-12-11',
    [ValidateSet('GlobalStandard', 'Standard')] [string] $ModelSku = 'GlobalStandard',
    [ValidateRange(1, 1000)] [int] $ModelCapacity = 10,
    [ValidatePattern('^\d+$')] [string] $DefinitionId = $env:SYSTEM_DEFINITIONID,
    [ValidatePattern('^\d+$')] [string] $BuildId = $env:BUILD_BUILDID,
    [ValidatePattern('^\d+$')] [string] $JobAttempt = $env:SYSTEM_JOBATTEMPT
)

$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'DotNetSampleAssignmentHelpers.ps1')
$assignment = Get-Content -LiteralPath $SelectionManifest -Raw | ConvertFrom-Json -AsHashtable
Assert-DotNetSampleAssignment -Assignment $assignment -QueueName $QueueName

$resourceArguments = @{} + $PSBoundParameters
$resourceArguments.Remove('SelectionManifest')
& (Join-Path $PSScriptRoot 'New-ResourceDeploymentPlan.ps1') @resourceArguments
$planPath = Join-Path $OutputDirectory 'deployment-plan.json'
$plan = Get-Content -LiteralPath $planPath -Raw | ConvertFrom-Json -AsHashtable
$plan['selectedTests'] = $assignment.selectedTests
$plan['filter'] = $assignment.filter
$plan | ConvertTo-Json -Depth 10 | Set-Content -LiteralPath $planPath -Encoding utf8
