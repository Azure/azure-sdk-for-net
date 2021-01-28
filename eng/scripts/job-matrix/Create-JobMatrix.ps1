<#
    .SYNOPSIS
        Generates a JSON object representing an Azure Pipelines Job Matrix.
        See https://docs.microsoft.com/en-us/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#parallelexec

    .EXAMPLE
    .\eng\scripts\Create-JobMatrix $context
#>

[CmdletBinding()]
param (
    [Parameter(Mandatory=$True)][string] $ConfigPath,
    [Parameter(Mandatory=$True)][string] $Selection,
    [Parameter(Mandatory=$False)][string] $DisplayNameFilter,
    [Parameter(Mandatory=$False)][array] $Filters
)

. $PSScriptRoot/job-matrix-functions.ps1

$config = GetMatrixConfigFromJson (Get-Content $ConfigPath)

[array]$matrix = GenerateMatrix $config $Selection $DisplayNameFilter $Filters
$serialized = SerializePipelineMatrix $matrix

Write-Output $serialized.pretty
Write-Output "##vso[task.setVariable variable=matrix;isOutput=true]$($serialized.compressed)"
