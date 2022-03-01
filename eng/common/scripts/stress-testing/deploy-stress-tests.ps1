# Set a default parameter set here so we can call this script without requiring -Login and -Subscription,
# but if it IS called with either of those, then both parameters need to be required. Not defining a
# default parameter set makes Login/Subscription required all the time.
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
