<#
    .SYNOPSIS
        Generates a JSON object representing an Azure Pipelines Job Matrix.
        See https://docs.microsoft.com/en-us/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#parallelexec

    .EXAMPLE
    ./eng/common/scripts/Create-JobMatrix $context
#>

[CmdletBinding()]
param (
    [Parameter(Mandatory=$True)][string] $ConfigPath,
    [Parameter(Mandatory=$True)][string] $Selection,
    [Parameter(Mandatory=$False)][string] $DisplayNameFilter,
    [Parameter(Mandatory=$False)][array] $Filters,
    [Parameter(Mandatory=$False)][array] $Replace,
    [Parameter(Mandatory=$False)][array] $NonSparseParameters,
    # Use for local generation/debugging when env: values are set in a matrix
    [Parameter(Mandatory=$False)][switch] $SkipEnvironmentVariables,
    [Parameter()][switch] $CI = ($null -ne $env:SYSTEM_TEAMPROJECTID)
)

. $PSScriptRoot/job-matrix-functions.ps1
. $PSScriptRoot/../logging.ps1

if (!(Test-Path $ConfigPath)) {
    Write-Error "ConfigPath '$ConfigPath' does not exist."
    exit 1
}
$rawConfig = Get-Content $ConfigPath -Raw
$config = GetMatrixConfigFromFile $rawConfig
# Strip empty string filters in order to be able to use azure pipelines yaml join()
$Filters = $Filters | Where-Object { $_ }

LogGroupStart "Matrix generation configuration"
Write-Host "Configuration File: $ConfigPath"
Write-Host $rawConfig
Write-Host "SelectionType: $Selection"
Write-Host "DisplayNameFilter: $DisplayNameFilter"
Write-Host "Filters: $Filters"
Write-Host "Replace: $Replace"
Write-Host "NonSparseParameters: $NonSparseParameters"
LogGroupEnd

[array]$matrix = GenerateMatrix `
    -config $config `
    -selectFromMatrixType $Selection `
    -displayNameFilter $DisplayNameFilter `
    -filters $Filters `
    -replace $Replace `
    -nonSparseParameters $NonSparseParameters `
    -skipEnvironmentVariables:$SkipEnvironmentVariables

$serialized = SerializePipelineMatrix $matrix

Write-Host "Generated matrix:"
Write-Host $serialized.pretty

if ($CI) {
    Write-Output "##vso[task.setVariable variable=matrix;isOutput=true]$($serialized.compressed)"
}
