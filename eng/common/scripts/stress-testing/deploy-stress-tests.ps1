#! /bin/env pwsh

# Not defining a default parameter set makes SkipLogin/Subscription required all the time.
[CmdletBinding(DefaultParameterSetName = 'Default')]
param(
    [string]$SearchDirectory,
    [hashtable]$Filters,
    [string]$Environment,
    [string]$Repository,
    [switch]$SkipPushImages,
    [string]$ClusterGroup,
    [string]$DeployId,
    [switch]$SkipLogin,
    [string]$Subscription,
    [string]$Tenant,

    # Default to true in Azure Pipelines environments
    [switch] $CI = ($null -ne $env:SYSTEM_TEAMPROJECTID),

    # Optional namespace override, otherwise the shell user or chart annotation will be used
    [string]$Namespace,

    # Override remote stress-test-addons with local on-disk addons for development
    [System.IO.FileInfo]$LocalAddonsPath,

    # Renders chart templates locally without deployment
    [Parameter(Mandatory=$False)][switch]$Template,

    [Parameter(Mandatory=$False)][switch]$RetryFailedTests,

    # Matrix generation parameters
    [Parameter(Mandatory=$False)][string]$MatrixFileName,
    [Parameter(Mandatory=$False)][string]$MatrixSelection,
    [Parameter(Mandatory=$False)][string]$MatrixDisplayNameFilter,
    [Parameter(Mandatory=$False)][array]$MatrixFilters,
    [Parameter(Mandatory=$False)][array]$MatrixReplace,
    [Parameter(Mandatory=$False)][array]$MatrixNonSparseParameters,

    # Prevent kubernetes from deleting nodes or rebalancing pods related to this test for N days
    [Parameter(Mandatory=$False)][ValidateRange(1, 14)][int]$LockDeletionForDays
)

. $PSScriptRoot/stress-test-deployment-lib.ps1

CheckDependencies
DeployStressTests @PSBoundParameters
