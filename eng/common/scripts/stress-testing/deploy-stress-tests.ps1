[CmdletBinding(DefaultParameterSetName = 'Default')]
param(
    [string]$SearchDirectory,
    [hashtable]$Filters,
    [string]$Environment,
    [string]$Repository,
    [switch]$PushImages,
    [string]$ClusterGroup,
    [string]$DeployId,

    [Parameter(ParameterSetName = 'DoLogin', Mandatory = $true)]
    [switch]$Login,

    [Parameter(ParameterSetName = 'DoLogin')]
    [string]$Subscription,

    # Default to true in Azure Pipelines environments
    [switch] $CI = ($null -ne $env:SYSTEM_TEAMPROJECTID)
)

. $PSScriptRoot/stress-test-deployment-lib.ps1

CheckDependencies
DeployStressTests @PSBoundParameters
